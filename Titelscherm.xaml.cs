using System;
using System.Media;
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
    /// Interaction logic for Titelscherm.xaml
    /// </summary>
    public partial class Titelscherm : Window
    {
        public Titelscherm()
        {
            InitializeComponent();

        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            naamInvoerenScherm naamInvoerenScherm = new naamInvoerenScherm();
            naamInvoerenScherm.Show(); 
            this.Close();
        }

        private void Sluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Geluid_aan_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = "BangersShort.wav";
            musicPlayer.PlayLooping();

            Geluid_uit.Visibility = Visibility.Visible;
            Geluid_aan.Visibility = Visibility.Collapsed;

        }

        private void Geluid_uit_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = "BangersShort.wav";
            musicPlayer.Stop();

            Geluid_uit.Visibility = Visibility.Collapsed;
            Geluid_aan.Visibility = Visibility.Visible;
        }
    }
}
