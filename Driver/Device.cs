using SSI.Driver.Prysm;
using System;
using System.Threading;

namespace SSI.Driver
{
    public partial class Device
	{
        private const int JOB_FREQ = 10000; // miliseconds

        private AppHelper _appHelper;
        private Thread _thread;
        private bool _stopThread;
        private Timer _timer;

        private string _name;
        public string Name { get => _name; set => _name = value; }

        public bool IsConnected { get => _isConnected; set => _isConnected = value; }
        private bool _isConnected;

        private Uri apiUri;

        public Device(string address, string rootVar, AppHelper appHelper)
        {
            _name = rootVar;
            _appHelper = appHelper;
            apiUri = new Uri(address);

            InitConnection();
        }

        private async void ExecuteJob(object state)
        {
            if (!_stopThread)
                _timer.Change(JOB_FREQ, Timeout.Infinite);
        }


        public void Start()
        {
            Log(LogLevel.Info, "Starting Device Thread ...");
            _thread = new Thread(new ThreadStart(Main));
            _thread.Start();
            _timer = new Timer(ExecuteJob, null, JOB_FREQ, Timeout.Infinite);
        }

        public void Stop()
        {
            if (_thread != null)
                if (_thread.IsAlive)
                {
                    Log(LogLevel.Info, "Stopping Device Thread ...");
                    _stopThread = true;
                    if (!_thread.Join(500))
                        _thread.Abort();
                }
        }

        private void Main()
        {
            Log(LogLevel.Info, "Start Device Thread ...");
            _stopThread = false;
            while (!_stopThread)
            {
                try
                {
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    Log(LogLevel.Error, "Main exception:" + ex.Message);
                }
            }
            Log(LogLevel.Info, "End Device Thread.");

            _isConnected = false;
        }

        private async void InitConnection()
        {
            
        }

        public void SendCommand(string command, string variableName)
        {
            
        }

        

        #region Log & LogException

        private void Log(LogLevel logLevel, string message)
        {
            Trace.Log(logLevel, $"From device {Name} | {message}");
        }

        private void LogException(string message, Exception ex)
        {
            Log(LogLevel.Error, $"{message}\n{ex.GetType().Name}\n{ex.Message}\n{ex.StackTrace}");
        }

        #endregion
    }
}
