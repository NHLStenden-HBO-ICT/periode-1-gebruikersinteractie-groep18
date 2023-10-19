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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string speler1 = invoerSpeler1.Text;
            weergevenSpeler1.Text = invoerSpeler1.Text;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            string speler2 = invoerSpeler2.Text;
            weergevenSpeler2.Text = invoerSpeler2.Text;
        }
    }
}
