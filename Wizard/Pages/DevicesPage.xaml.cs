using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Prysm.AppVision.Common;

namespace SSI.GeoVision.Wizard.Pages
{
    public partial class DevicesPage : Page
    {
		public DevicesPage()
		{
			InitializeComponent();
			Loaded += DevicesPage_Loaded;
		}
		async void DevicesPage_Loaded(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
