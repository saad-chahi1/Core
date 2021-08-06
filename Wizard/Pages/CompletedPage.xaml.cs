using System.Windows;
using System.Windows.Controls;

namespace SSI.GeoVision.Wizard.Pages
{
    public partial class CompletedPage : Page
    {
		public CompletedPage()
        {
            InitializeComponent();
			this.Loaded += CompletedPage_Loaded;
        }

		private void CompletedPage_Loaded(object sender, RoutedEventArgs e)
		{
			warning.Visibility = (((ViewModel)DataContext).VariableCreatedCount > 1000)? Visibility.Visible : Visibility.Collapsed;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
        {
			Properties.Settings.Default.Save();
			Application.Current.Shutdown(1);		// 1: pour indiquer au configurateur qu'une synchronisation a été faite
        }
    }
}
