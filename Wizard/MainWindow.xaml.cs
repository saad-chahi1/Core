
using SSI.GeoVision.Wizard.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SSI.GeoVision.Wizard
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			this.Closed += MainWindow_Closed;
			DataContext = new ViewModel(MainFrame);
			this.MainFrame.Navigate(new WelcomePage { DataContext = DataContext });
		}

		private void MainWindow_Closed(object sender, EventArgs e)
		{
			((ViewModel)DataContext).LogoutApp();
			((ViewModel)DataContext).LogoutDevice();
		}
	}
}
