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
    /// Interaction logic for ErrorScreen.xaml
    /// </summary>
    public partial class ErrorScreen : Window
    {
        public ErrorScreen()
        {
            InitializeComponent();
            Loaded += MyWindow_Loaded;
        }
        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Create Grid
            Grid dynamicGrid = new Grid
            {
                Width = 400,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                ShowGridLines = true,
                Background = new SolidColorBrush(Colors.LightSteelBlue)
            };
            
            
            dynamicGrid.ColumnDefinitions.Add(new ColumnDefinition(){ Width = new GridLength(20) });
            dynamicGrid.ColumnDefinitions.Add(new ColumnDefinition(){ Width = GridLength.Auto });
            dynamicGrid.ColumnDefinitions.Add(new ColumnDefinition(){ Width = GridLength.Auto });
            dynamicGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });

            dynamicGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            dynamicGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            dynamicGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            dynamicGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            dynamicGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });



            // Add first column header

            TextBlock txtBlock1 = new TextBlock();

            txtBlock1.Text = "Author Name";

            txtBlock1.FontSize = 14;

            txtBlock1.FontWeight = FontWeights.Bold;

            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);

            txtBlock1.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock1, 0);

            Grid.SetColumn(txtBlock1, 0);



            // Add second column header

            TextBlock txtBlock2 = new TextBlock();

            txtBlock2.Text = "Age";

            txtBlock2.FontSize = 14;

            txtBlock2.FontWeight = FontWeights.Bold;

            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);

            txtBlock2.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock2, 0);

            Grid.SetColumn(txtBlock2, 1);



            // Add third column header

            TextBlock txtBlock3 = new TextBlock();

            txtBlock3.Text = "Book";

            txtBlock3.FontSize = 14;

            txtBlock3.FontWeight = FontWeights.Bold;

            txtBlock3.Foreground = new SolidColorBrush(Colors.Green);

            txtBlock3.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock3, 0);

            Grid.SetColumn(txtBlock3, 2);



            //// Add column headers to the Grid

            dynamicGrid.Children.Add(txtBlock1);

            dynamicGrid.Children.Add(txtBlock2);

            dynamicGrid.Children.Add(txtBlock3);



            // Create first Row

            TextBlock authorText = new TextBlock();

            authorText.Text = "Mahesh Chand";

            authorText.FontSize = 12;

            authorText.FontWeight = FontWeights.Bold;

            Grid.SetRow(authorText, 1);

            Grid.SetColumn(authorText, 0);



            TextBlock ageText = new TextBlock();

            ageText.Text = "33";

            ageText.FontSize = 12;

            ageText.FontWeight = FontWeights.Bold;

            Grid.SetRow(ageText, 1);

            Grid.SetColumn(ageText, 1);



            TextBlock bookText = new TextBlock();

            bookText.Text = "GDI+ Programming";

            bookText.FontSize = 12;

            bookText.FontWeight = FontWeights.Bold;

            Grid.SetRow(bookText, 1);

            Grid.SetColumn(bookText, 2);

            // Add first row to Grid

            dynamicGrid.Children.Add(authorText);

            dynamicGrid.Children.Add(ageText);

            dynamicGrid.Children.Add(bookText);



            // Create second row

            authorText = new TextBlock();

            authorText.Text = "Mike Gold";

            authorText.FontSize = 12;

            authorText.FontWeight = FontWeights.Bold;

            Grid.SetRow(authorText, 2);

            Grid.SetColumn(authorText, 0);



            ageText = new TextBlock();

            ageText.Text = "35";

            ageText.FontSize = 12;

            ageText.FontWeight = FontWeights.Bold;

            Grid.SetRow(ageText, 2);

            Grid.SetColumn(ageText, 1);



            bookText = new TextBlock();

            bookText.Text = "Programming C#";

            bookText.FontSize = 12;

            bookText.FontWeight = FontWeights.Bold;

            Grid.SetRow(bookText, 2);

            Grid.SetColumn(bookText, 2);



            // Add second row to Grid

            dynamicGrid.Children.Add(authorText);

            dynamicGrid.Children.Add(ageText);

            dynamicGrid.Children.Add(bookText);

            var window = new Window
            {
                Content = dynamicGrid
            };
            
        }
    }
}
