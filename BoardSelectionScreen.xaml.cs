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

namespace MemoryGame {
	/// <summary>
	/// Het bordgrootte scherm
	/// </summary>
	public partial class BoardSelectionScreen : Window {
		public BoardSelectionScreen() {
			InitializeComponent();
		}

		private void NextButtonClick(object sender, RoutedEventArgs e) {
			// Code om naar het volgende venster te gaan
			if(previewSize.Text == "4 x 4") {
				Thema1 thema1 = new Thema1();
				thema1.Show();
			}
			else if(previewSize.Text == "5 x 4") {
                Thema2 thema2 = new Thema2();
                thema2.Show();
            }
			else {
                Thema3 thema3 = new Thema3();
                thema3.Show();
            }
			this.Close();
		}

		private void PreviousButtonClick(object sender, RoutedEventArgs e) {
			Titelscherm screen = new();
			screen.Show();
			Close();
		}

		private void PreviewButton1Click(object sender, RoutedEventArgs e) {
			previewSize.Text = "4 x 4";
			button1.IsEnabled = false;
			button2.IsEnabled = true;
			button3.IsEnabled = true;
			grid1.Visibility = Visibility.Visible;
			grid2.Visibility = Visibility.Hidden;
			grid3.Visibility = Visibility.Hidden;
		}

		private void PreviewButton2Click(object sender, RoutedEventArgs e) {
			previewSize.Text = "5 x 4";
			button1.IsEnabled = true;
			button2.IsEnabled = false;
			button3.IsEnabled = true;
			grid1.Visibility = Visibility.Hidden;
			grid2.Visibility = Visibility.Visible;
			grid3.Visibility = Visibility.Hidden;
		}

		private void PreviewButton3Click(object sender, RoutedEventArgs e) {
			previewSize.Text = "6 x 5";
			button1.IsEnabled = true;
			button2.IsEnabled = true;
			button3.IsEnabled = false;
			grid1.Visibility = Visibility.Hidden;
			grid2.Visibility = Visibility.Hidden;
			grid3.Visibility = Visibility.Visible;
		}
	}
}
