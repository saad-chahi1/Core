using Prysm.AppVision.Data;
using Prysm.AppVision.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSI.Driver.Prysm
{
    public class AppHelper
    {
        private AppDriver appDriver;
        private string serverHostname;
        private string protocolName;

        public AppServerForDriver AppServer { get => appServer; }
        private AppServerForDriver appServer;

        public bool AppServerConnected { get => appServer.IsConnected; }


        public AppHelper(AppDriver appDriver, string protocolName, string serverHostname)
        {
            this.appDriver = appDriver;
            this.protocolName = protocolName;
            this.serverHostname = serverHostname;


            appServer = new AppServerForDriver();
            appServer.VariableManager.StateChanged += appDriver.On_VariableManager_StateChanged;
            appServer.ControllerManager.Closed += appDriver.Stop;
            appServer.ControllerManager.Restart += appDriver.Restart;
        }

        public void InitializeConnection()
        {
            Trace.Info("Server connection ...");
            appServer.Open(serverHostname);
            appServer.Login(protocolName);
            if (appServer.CurrentProtocol == null)
            {
                Trace.Info("No protocol " + protocolName);
                throw new AppServerInitializationException();
            }

            SynchronizeProtocol();
        }

        private void SynchronizeProtocol()
        {
            List<string> listNotification = new List<string>();
            var variablesProtocol = appServer.GetVariablesByProtocol(protocolName);
            if (variablesProtocol.Length == 0) Trace.Info("No variable connected to this protocol");
            foreach (var t in variablesProtocol) listNotification.Add("$V." + t.Name + ".*");
            appServer.AddFilterNotifications(string.Join("|", listNotification));
            AppServer.AddFilterNotifications("Variable.StateType=1");
            appServer.StartNotifications(false);
            appServer.ProtocolSynchronized();

            Trace.Info("Connection successful - " + protocolName);
        }

        public VariableRow[] GetVariablesByProtocol()
        {
            return appServer.GetVariablesByProtocol(protocolName);
        }

        public void SendVariable(string varName, object v)
        {
            try
            {
                SetVariable(varName, v);
            }
            catch (Exception ex)
            {
                Trace.Error("VariableManager.Set: " + ex.Message);
            }
        }
        private void SetVariable(string name, object value, string info = null, string operation = "@ChangeOnly", DateTime date = default(DateTime))
        {
               if (date == default(DateTime))
                    date = DateTime.Now;
                Trace.Info($"SendVariable: {name}={value}		{date}	{info}");
                AppServer.VariableManager.Set(name, value, info, operation, date);
        }

        public void SendInfo(int severity, string message, string info)
        {
            
            try
            {
                if (severity > 0)
                {
                    AppServer.AlarmManager.AddAlarm(severity, message, info);
                    Trace.Error("SendInfo " + info + " - " + message);
                }
                else
                {
                    AppServer.EventManager.AddEvent(message, info);
                    Trace.Info("SendInfo " + info + " - " + message);
                }
            }
            catch (Exception ex)
            {
                Trace.Error("SendInfo exception: " + ex.Message);
            }
        }
    }
}
