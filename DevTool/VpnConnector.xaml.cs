using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using UtilityService;

namespace DevTool
{
    /// <summary>
    /// Interaction logic for TokenGenerator.xaml
    /// </summary>
    public partial class VpnConnector : Window
    {
        public static bool IsBusy;
        public Stopwatch Stopwatch;
        public VpnConnector()
        {
            Stopwatch = new Stopwatch();
            InitializeComponent();
        }

        private async void ButtonConnect_OnClick(object sender, RoutedEventArgs e)
        {
            Stopwatch.Start();
            if (!IsBusy)
            {
                IsBusy = true;
                ImageLoading.Visibility = Visibility.Visible;
                TextBoxConsoleLogs.Text = (await CommandLine.ExecuteCommand("rasdial.exe", "\"backup-vpn\" \"abhishek.singh1@bold.com\" \"5nXhjv4j\"")).Data;
                TextBoxConsoleLogs.Width = ViewboxConsoleLogs.Width;
                ImageLoading.Visibility = Visibility.Hidden;
                IsBusy = false;
            }
            TextBlockTime.Text = Stopwatch.ElapsedMilliseconds + " ms";
            Stopwatch.Reset();
        }

        private async void ButtonDisconnect_OnClick(object sender, RoutedEventArgs e)
        {
            Stopwatch.Start();
            if (!IsBusy)
            {
                IsBusy = true;
                ImageLoading.Visibility = Visibility.Visible;
                TextBoxConsoleLogs.Text = (await CommandLine.ExecuteCommand("rasdial.exe", "\"backup-vpn\" /disconnect")).Data;
                TextBoxConsoleLogs.Width = ViewboxConsoleLogs.Width;
                ImageLoading.Visibility = Visibility.Hidden;
                IsBusy = false;
            }
            TextBlockTime.Text = Stopwatch.ElapsedMilliseconds + " ms";
            Stopwatch.Reset();
        }
    }
}
