using Prysm.AppVision.Common;
using Prysm.AppVision.Data;
using Prysm.AppVision.SDK;
using SSI.GeoVision.Wizard.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SSI.GeoVision.Wizard
{
    public class ViewModel : INotifyPropertyChanged
    {
		public ViewModel()
		{

		}
		public ViewModel(Frame frame)
		{

		}

		#region AppServer
		protected AppServer AppServer
		{
			get
			{
				if (_AppServer == null)
					_AppServer = new AppServer();
				return _AppServer;
			}
		}
		AppServer _AppServer;
		#endregion

		#region AppHostname,AppUsername,AppPassword
		public string AppHostname
		{
			get
			{
				return Settings.Default.AppHostname;
			}
			set
			{
				Settings.Default.AppHostname = value;
			}
		}

		public string AppUsername
		{
			get
			{
				return Settings.Default.AppUsername;
			}
			set
			{
				Settings.Default.AppUsername = value;
			}
		}

		public string AppPassword
		{
			get
			{
				return _AppPassword;
			}
			set
			{
				_AppPassword = value;
			}
		}
		internal string _AppPassword;
		#endregion
		#region DeviceHostname,DeviceUsername,DevicePassword
		public string DeviceHostname
		{
			get
			{
				return Settings.Default.DeviceHostname;
			}
			set
			{
				Settings.Default.DeviceHostname = value;
			}
		}
		
		public string DevicePort
		{
			get
			{
				return Settings.Default.DevicePort;
			}
			set
			{
				Settings.Default.DevicePort = value;
			}
		}

		public string DeviceUsername
		{
			get
			{
				return Settings.Default.DeviceUsername;
			}
			set
			{
				Settings.Default.DeviceUsername = value;
			}
		}

		public string DevicePassword
		{
			get
			{
				return _DevicePassword;
			}
			set
			{
				this.DebugWriteLine(value);
				// Attention: ne pas prendre les valeurs vides (produit par PasswordBox après la saisie)
				if (!string.IsNullOrEmpty(value))
					_DevicePassword = value;
			}
		}
		string _DevicePassword;
		#endregion

		#region Devices, AreAllSelected, SelectedDevicesCount
		ObservableCollection<Device> _devices = new ObservableCollection<Device>();
		public ObservableCollection<Device> Devices
		{
			get
			{
				return _devices;
			}
			set
			{
				_devices = value;
				this.Notify("Devices");
			}
		}
		public bool AreAllSelected
		{
			get
			{
				return _AreAllSelected;// this.Devices.All(c => c.Selected);
			}
			set
			{
				_AreAllSelected = value;
				foreach (var item in this.Devices)
					item.IsSelected = value;
				this.Notify("AreAllSelected");
			}
		}
		bool _AreAllSelected;
		public int SelectedDevicesCount
		{
			get { return Devices.Where(d=>d.IsSelected).Count(); }
		}

        #endregion


        #region Details,Progress,NextContent
        public ObservableCollection<string> Details
		{
			get
			{
				return this._details;
			}
			set
			{
				this._details = value;
				this.Notify("Details");
			}
		}
		private ObservableCollection<string> _details=new ObservableCollection<string>();

		public int Progress
		{
			get
			{
				return this._progress;
			}
			set
			{
				this._progress = value;
				this.Notify("Progress");
			}
		}
		private int _progress = 0;
		public string NextContent
		{
			get { return _NextContent; }
			set
			{
				_NextContent = value; this.Notify("NextContent");
			}
		}
		public string _NextContent = "Create";
        #endregion
        public int VariableCreatedCount { get; set; }

        #region LoginApp(),LogoutApp()
        internal bool LoginApp(string hostname, string username, string password)
		{
			try
			{
				if (string.IsNullOrEmpty(hostname) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
					MessageBox.Show("Hostname username or password is missing", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
					return false;
				}	
                else
                {
					AppServer.Open(hostname);
					AppServer.Login(username, password);
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(Helper.GetInnerMessages(ex));
				return false;
			}
		}
		internal void LogoutApp()
		{
			try
			{
				AppServer.Logout();
				AppServer.Close();
			}
			catch (Exception)
			{
			}
		}
        #endregion

        

		#region INotifyPropertyChanged Membres

		public event PropertyChangedEventHandler PropertyChanged;
		protected void Notify(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				//_view.Dispatcher.BeginInvoke(new Action(delegate
				//{
					handler(this, new PropertyChangedEventArgs(propertyName));
				//}));
			}
		}

		#endregion

		// méthodes à remplacer
		#region LoginDevice(),LogoutDevice()
		internal bool LoginDevice(string hostname, string port, string username, string password)
		{
			try
			{
				if (string.IsNullOrEmpty(hostname) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
					MessageBox.Show("Hostname username or password is missing", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
					return false;
				}
                else
                {
					return true;	
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(Helper.GetInnerMessages(ex));
				return false;
			}
		}
		internal void LogoutDevice()
		{
			
		}
		#endregion
	}
}
