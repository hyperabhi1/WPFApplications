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
using System.Windows.Shapes;

namespace DevTool
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private bool isVpnActive = false;
        private bool isTokenActive = false;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void ImageVPN_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isVpnActive)
            {
                var vpn = new VpnConnector();
                vpn.Show();
                isVpnActive = true;
            }
        }

        private void ImageToken_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isTokenActive)
            {
                var token = new TokenGenerator();
                token.Show();
                isTokenActive = true;
            }
        }
    }
}
