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
    /// Interaction logic for eindScherm.xaml
    /// </summary>
    public partial class eindScherm : Window
    {
        public eindScherm()
        {
            InitializeComponent();
        }

        private void Button_ClickNieuwSpel(object sender, RoutedEventArgs e)
        {
            Window Titelscherm = new Titelscherm();
            Titelscherm.Show();
            this.Close();
        }

        private void Button_ClickNaarMenu(object sender, RoutedEventArgs e)
        {
            Window BoardSelectionScreen = new BoardSelectionScreen();
            BoardSelectionScreen.Show();
            this.Close();
        }
    }
}
