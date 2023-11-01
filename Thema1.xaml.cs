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

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for Thema1.xaml
    /// </summary>
    public partial class Thema1 : Window
    {
        public Thema1()
        {
            InitializeComponent();
        }

            private void NextButtonClick(object sender, RoutedEventArgs e)
            {
                // Code om naar het volgende venster te gaan
                MemoryBoard memboard = new MemoryBoard();
                MemoryBoard.generate(4, 4, "dieren plaatjes");
                memboard.Show();
                this.Close();
            }

            private void PreviewButton1Click(object sender, RoutedEventArgs e)
            {
                previewSize.Text = "Dieren";
                button1.IsEnabled = false;
                button2.IsEnabled = true;
                button3.IsEnabled = true;
                grid1.Visibility = Visibility.Visible;
                grid2.Visibility = Visibility.Hidden;
                grid3.Visibility = Visibility.Hidden;
            }

            private void PreviewButton2Click(object sender, RoutedEventArgs e)
            {
                previewSize.Text = "Landen";
                button1.IsEnabled = true;
                button2.IsEnabled = false;
                button3.IsEnabled = true;
                grid1.Visibility = Visibility.Hidden;
                grid2.Visibility = Visibility.Visible;
                grid3.Visibility = Visibility.Hidden;
            }

            private void PreviewButton3Click(object sender, RoutedEventArgs e)
            {
                previewSize.Text = "Knuffels";
                button1.IsEnabled = true;
                button2.IsEnabled = true;
                button3.IsEnabled = false;
                grid1.Visibility = Visibility.Hidden;
                grid2.Visibility = Visibility.Hidden;
                grid3.Visibility = Visibility.Visible;
            }
        

    }
}