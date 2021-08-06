using Prysm.AppVision.Data;
using SSI.Driver.Prysm;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace SSI.Driver
{
    public partial class AppDriver
	{
        internal AppHelper _appHelper;
        internal Thread _thread;
        internal bool _stopWaiting;
        internal bool _restart = false;

        private List<Device> _devices = new List<Device>();
        private ConcurrentQueue<object> _events = new ConcurrentQueue<object>();

        public AppDriver()
		{
			Trace.Info(Environment.CommandLine);

            var args = Environment.GetCommandLineArgs();
            var a = args[1].Split('@');
            var protocolName = a[0];
            var hostName = (a.Length > 1) ? a[1] : "";

            _appHelper = new AppHelper(this, protocolName, hostName);
            _appHelper.InitializeConnection();
			
			//Trace.LogEvent += NewLog;
		}

		void NewLog(LogEntry it)
		{
            _appHelper.AppServer.Log((int)it.Level, it.Message);
		}

		public void Start()
		{
			try
			{
                _thread = new Thread(new ThreadStart(Main));
                _thread.Start();
            }
			catch (Exception ex)
			{
				_appHelper.SendInfo(10, ex.Message, "Starting thread exception !");
			}
		}

		public void Stop()
		{
			Trace.Info("Stopping");
			try
			{
				foreach (var device in _devices)
				{
					device.Stop();
				}
				_devices.Clear();

				if (_appHelper.AppServerConnected)
				{
					_appHelper.AppServer.Close();
				}
				Trace.Info("Stopped");
                App.Current.Shutdown();
                Process.GetCurrentProcess().Kill();
            }
			catch (Exception ex)
			{
				Trace.Error(ex);
			}
		}

        public void Restart()
        {
            Stop(); Start();
        }

        private void Main()
        {
            try
            {
                CreateDevices();
                
                bool deviceStopWaiting = false;
                _stopWaiting = false;

                for (; ; )
                {
                    if (_stopWaiting)
                    {
                        if (deviceStopWaiting)
                        {
                            if (AllDevicesClosed()) break;
                        }
                        else
                        {
                            CloseDevices();
                            deviceStopWaiting = true;
                        }
                    }



                    int count = 0;
                    object e;
                    while (_events.TryDequeue(out e))
                    {
                        count++;
                        OnVariableState(e as VariableState);
                    }

                    if (count == 0) Thread.Sleep(50);
                }
            }
            catch (AppServerInitializationException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                try
                {
                    Trace.Info("Driver : finally");
                    if (_appHelper.AppServerConnected)
                    {
                        _appHelper.AppServer.Logout();
                        _appHelper.AppServer.Close();
                    }
                }
                catch { }

                if (_restart)
                {
                    _restart = false;
                    Start();
                }
            }
        }

        public void On_VariableManager_StateChanged(VariableState obj)
        {
            _events.Enqueue(obj);
        }

        private void OnVariableState(VariableState variableState)
        {
            string val = variableState.Value.ToString();
            Trace.Info("From AppServer: " + variableState.Name + "=" + val);
            Device d = GetDeviceByVariable(variableState);
            if (d == null)
            {
                Trace.Info(" device not found");
            }
            else
            {
                d.SendCommand(variableState.Value.ToString(), variableState.Name);
            }
        }

        private void CreateDevices()
        {
            var deviceVars = _appHelper.GetVariablesByProtocol();
            foreach (var var in deviceVars)
            {
                try
                {
                    var device = new Device(var.Address, var.Name, _appHelper);
                    device.Start();
                    _devices.Add(device);
                }
                catch (Exception ex)
                {
                    _appHelper.SendInfo(10, ex.Message, var.Name);
                }
            }
        }

        private Device GetDeviceByVariable(VariableState variableState)
        {
            string deviceName = variableState.Name.Split('.')[0];
            foreach (Device d in _devices)
            {
                if (d.Name.Equals(deviceName))
                {
                    return d;
                }
            }
            return null;
        }

        private void CloseDevices()
        {
            foreach (var d in _devices)
            {
                try
                {
                    d.Stop();
                }
                catch (Exception ex)
                {
                    _appHelper.SendInfo(1, ex.Message, d.Name);
                }
            }
        }
        private bool AllDevicesClosed()
        {
            foreach (var d in _devices)
                if (d.IsConnected)
                    return false;
            return true;
        }


        internal bool IsAlive
        {
            get
            {
                if (_thread == null)
                    return false;
                return _thread.IsAlive;
            }
        }
    }
}