using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using ModelService;

namespace DevTool
{
    /// <summary>
    /// Interaction logic for TokenGenerator.xaml
    /// </summary>
    public partial class TokenGenerator : Window
    {
        public static bool IsBusy;
        public Stopwatch Stopwatch;
        public TokenGenerator()
        {
            Stopwatch = new Stopwatch();
            InitializeComponent();
        }

        private async void ButtonSandboxSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            Stopwatch.Start();
            if (!IsBusy)
            {
                IsBusy = true;
                ImageLoading.Visibility = Visibility.Visible;
                var snbToken = await UtilityService.Bold.GetTokenAsync(SourceAppCd.ATEST_SND_A_COR);
                if (snbToken.StatusCode == StatusCode.OK)
                {
                    TextBoxSnbClientSecret.Text = snbToken.Data.Split('|')[0];
                    TextBoxSnbToken.Text = snbToken.Data.Split('|')[1];
                    TextBoxSnbToken.Width = ViewboxSnbToken.ActualWidth;
                    TextBoxSnbToken.Height = ViewboxSnbToken.ActualHeight;
                }
                else
                {
                    TextBoxSnbClientSecret.Text = snbToken.Error.UiSafeMessage;
                    TextBoxSnbToken.Text = snbToken.Error.UiSafeMessage;
                    TextBoxSnbToken.Width = ViewboxSnbToken.ActualWidth;
                    TextBoxSnbToken.Height = ViewboxSnbToken.ActualHeight;
                }
                ImageLoading.Visibility = Visibility.Hidden;
                IsBusy = false;
            }
            TextBlockSnbTime.Text = Stopwatch.ElapsedMilliseconds + " ms";
            Stopwatch.Reset();
        }

        private async void ButtonProductionSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            Stopwatch.Start();
            if (!IsBusy)
            {
                IsBusy = true;
                ImageLoading.Visibility = Visibility.Visible;
                var prdToken = await UtilityService.Bold.GetTokenAsync(SourceAppCd.ATEST_PRD_A_COR);
                if (prdToken.StatusCode == StatusCode.OK)
                {
                    TextBoxPrdClientSecret.Text = prdToken.Data.Split('|')[0];
                    TextBoxPrdToken.Text = prdToken.Data.Split('|')[1];
                    TextBoxPrdToken.Width = ViewboxPrdToken.ActualWidth;
                    TextBoxPrdToken.Height = ViewboxPrdToken.ActualHeight;
                }
                else
                {
                    TextBoxPrdClientSecret.Text = prdToken.Error.UiSafeMessage;
                    TextBoxPrdToken.Text = prdToken.Error.DeveloperMessage;
                    TextBoxPrdToken.Width = ViewboxPrdToken.ActualWidth;
                    TextBoxPrdToken.Height = ViewboxPrdToken.ActualHeight;
                }
                ImageLoading.Visibility = Visibility.Hidden;
                IsBusy = false;
            }
            TextBlockPrdTime.Text = Stopwatch.ElapsedMilliseconds + " ms";
            Stopwatch.Reset();
        }
    }
}
