using Prysm.AppVision.Common;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SSI.Driver
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        AppDriver _driver;
        Window _window;

        protected override void OnStartup(StartupEventArgs a)
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) => UnhandledException((Exception)e.ExceptionObject);
            DispatcherUnhandledException += (s, e) => { UnhandledException(e.Exception); e.Handled = true; };

            _window = new MainWindow();
            _window.Closing += Window_Closing;
            _window.Show();

            _driver = new AppDriver();
            _driver.Start();
        }

        void Server_Closed()
        {
            _driver.Stop();
            _window.Closing -= Window_Closing;
            _window.Close();
        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == 0)
            {
                MessageBox.Show(RT.Get("No_user_stop"));
                e.Cancel = true;
            }
            else
                _driver?.Stop();
        }

        void UnhandledException(Exception ex)
        {
            Trace.Error(ex);
            MessageBox.Show(ex?.ToString() ?? "Fatal error", Helper.ProductName, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
