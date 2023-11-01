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
    /// Interaction logic for naamInvoerenScherm.xaml
    /// </summary>
    public partial class naamInvoerenScherm : Window
    {
       
        public naamInvoerenScherm()
        {
            InitializeComponent();
            
            
        }
        public static string speler1 = "";
        public static string speler2 = "";
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_ClickVolgendScherm(object sender, RoutedEventArgs e)
        {
            speler1 = invoerSpeler1.Text;
            speler2 = invoerSpeler2.Text;

            Window BoardSelectionScreen = new BoardSelectionScreen();
            BoardSelectionScreen.Show();
            this.Close();
        }

        private void Button_ClickVorigeScherm(object sender, RoutedEventArgs e)
        {
            Window Titelscherm = new Titelscherm();
            Titelscherm.Show();
            this.Close();
        }
    }
}
