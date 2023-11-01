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
            score1Label.Content = MemoryBoard.score1.ToString();
            score2Label.Content = MemoryBoard.score2.ToString();
            speler1Label.Content = naamInvoerenScherm.speler1;
            speler2Label.Content = naamInvoerenScherm.speler2;
        }

        private void Button_ClickNieuwSpel(object sender, RoutedEventArgs e)
        {
            Window BoardSelectionScreen = new BoardSelectionScreen();
            BoardSelectionScreen.Show();
            this.Close();
        }

        private void Button_ClickNaarMenu(object sender, RoutedEventArgs e)
        {
            Window Titelscherm = new Titelscherm();
            Titelscherm.Show();
            this.Close();
        }
    }
}
