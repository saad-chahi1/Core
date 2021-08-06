using Microsoft.Win32;
using Prysm.AppVision.Common;
using Rigel.GeoVision.Driver.Prysm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;


namespace SSI.Driver
{
    public partial class MainWindow : Window
    {
        public int MaxCount { get; set; } = 10000;
        public LogLevel LogLevel { get; set; } = LogLevel.Debug;
        public ObservableCollection<LogEntry> Items { get; } = new ObservableCollection<LogEntry>();

        public MainWindow()
        {
            //check licence
            VLicence.checkLicence();

            var args = Environment.GetCommandLineArgs();
            if (args.Length < 2)
                throw new Exception($"Usage: {Assembly.GetEntryAssembly().GetName().Name} protocolName[@hostName]");

            Title = Helper.ProductName + " v" + Helper.ProductVersion + " - " + args[1];
            if (!args[1].Contains('@'))
                Title += "@localhost";

            // load appvision labels
            try { RT.Load(Path.Combine(Helper.PathResources, "AppLab.txt")); }
            catch { }

            DataContext = this;
            InitializeComponent();

            new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.5), IsEnabled = true }.Tick += Tick;
            CollectionViewSource.GetDefaultView(Items).Filter = Items_Filter;
            level.ItemsSource = Enum.GetValues(typeof(LogLevel));
            Trace.LogEvent += NewLog;
        }

        #region logs
        List<LogEntry> _buffer = new List<LogEntry>();

        void NewLog(LogEntry it)
        {
            if (LogLevel >= it.Level)
                lock (_buffer)
                    if (_buffer.Count < 1000) // max 500 lines/s
                        _buffer.Add(it);
        }

        // display every 1/2sec
        void Tick(object sender, EventArgs e)
        {
            if (Items.Count > MaxCount) // purge 10% of the logs
                for (int i = 0; i < MaxCount / 10; i++)
                    Items.RemoveAt(0);

            if (_buffer.Count > 0)
                lock (_buffer)
                {
                    Items.AddRange(_buffer);
                    _buffer.Clear();
                }

            if (!ScrollLock)
                logs.GetChild<ScrollViewer>()?.ScrollToBottom();
        }

        public bool ScrollLock
        {
            get { return (bool)GetValue(ScrollLockProperty); }
            set { SetValue(ScrollLockProperty, value); }
        }
        public static readonly DependencyProperty ScrollLockProperty = DependencyProperty.Register("ScrollLock", typeof(bool), typeof(MainWindow));


        #endregion
        #region filter

        // affiche les lignes qui contient le filter.Text
        bool Items_Filter(object item)
        {
            if (!string.IsNullOrEmpty(filter.Text))
                if (((LogEntry)item).Message.IndexOf(filter.Text, StringComparison.CurrentCultureIgnoreCase) == -1)
                    return false;
            return true;
        }
        void Filter_Changed(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Items).Refresh();
        }
        void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            filter.Clear();
        }

        #endregion
        #region commands

        void Copy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (new WaitCursor())
            {
                if (logs.SelectedItem == null)
                    Clipboard.SetText(Items.Join()); // pas de sélection, on copie tout
                else
                    Clipboard.SetText(logs.SelectedItems.Cast<LogEntry>().Join());
            }
        }

        void Clear_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Items.Clear();
        }

        void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            var name = Assembly.GetEntryAssembly().GetName().Name;
            dlg.FileName = $"{name}_{DateTime.Now:yyMMdd_HHmm}.log";
            if (dlg.ShowDialog() != true)
                return;

            using (new WaitCursor())
            using (var file = new StreamWriter(dlg.FileName))
                foreach (var line in Items)
                    file.WriteLine(line);
        }
        #endregion
        #region misc

        // hide toolbar overflow grip
        void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            var toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
                overflowGrid.Visibility = Visibility.Collapsed;
        }
        void Tools_Click(object sender, RoutedEventArgs e)
        {
            toolsPopup.IsOpen = true;
        }

        #endregion
    }
}
