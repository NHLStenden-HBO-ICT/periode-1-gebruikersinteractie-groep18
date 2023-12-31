﻿using System;
using System.Media;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Runtime.CompilerServices;

namespace MemoryGame {
    /// <summary>
    /// Interaction logic for MemoryBoard.xaml
    /// </summary>
    public partial class MemoryBoard : Window {
        public MemoryBoard() {
            Trace.WriteLine("initializing memoryboard");
            InitializeComponent();
            parent = parentGrid;
			//verwijder de lijn hieronder als alle knoppen werken
			//generate(6, 5, "Dieren Plaatjes");
			mediaPlayer.Open(new("pack://siteoforigin:,,,/BangersShort.wav"));

		}

		public static int width;
        public static int height;
		MediaPlayer mediaPlayer = new MediaPlayer();


		public static List<List<int>> cards = new List<List<int>>();

        public static Grid cardGrid;
        private static Grid parent;
        private static string ImgFolder;

        public static bool PlayerOneTurn = true;
        public static List<int[]> cardsturned = new List<int[]>();
        public static List<Button> buttonspressed = new List<Button>();
        public static int RemainingCards;

        public static int score1;
        public static int score2;

        public static bool blockinput = false;

		private void PreviousButtonClick(object sender, RoutedEventArgs e) {
			Titelscherm screen = new();
			screen.Show();
			Close();
		}

        public bool generate(int w, int h, string folder) {
            width = w;
            height = h;
            ImgFolder = folder;

            score1 = 0;
            score2 = 0;
            PlayerOneTurn = true;

            int cardnum = width * height;
            RemainingCards = cardnum;

            if (cardnum % 2 == 0) {
                //hoeveelheid kaarten is een even getal
                List<int> sortedcards = new List<int>();
                for (int i = 0; i < cardnum / 2; i++) {
                    //voeg de kaarten toe aan de unsorted list
                    sortedcards.Add(i);
                    sortedcards.Add(i);
                }
                Random rnd = new Random();
                Trace.WriteLine("memory layout:");
                for (int i = 0; i < height; i++) {
                    //genereer een tijdelijke lijst om toe te kunnen voegen aan de cards lijst
                    List<int> templist = new List<int>();
                    for (int j = 0; j < width; j++) {
                        //genereer een willekeurig nummer
                        int rand = rnd.Next(0, sortedcards.Count());
                        //voeg de id uit de lijst toe aan de tijdelijke lijst en verwijder heb uit de gesorteerde lijst
                        templist.Add(sortedcards[rand]);
                        sortedcards.RemoveAt(rand);
                    }
                    //voeg de tijdelijke lijst toe aan de cards lijst
                    templist.ForEach(k => Trace.Write(k + "\t"));
                    Trace.Write("\n");
                    cards.Add(templist);
                }

            }
            else {
                Trace.WriteLine("de ingevoegde grootte levert een oneven aantal kaarten.");
                return false;
            }

            // Maakt een nieuw grid aan
            cardGrid = new Grid();
            cardGrid.HorizontalAlignment = HorizontalAlignment.Center;
            cardGrid.VerticalAlignment = VerticalAlignment.Center;

            //voeg columns toe
            for (int i = 0; i < width; i++) {
                ColumnDefinition tempcol = new ColumnDefinition();
                cardGrid.ColumnDefinitions.Add(tempcol);
            }
            //voeg rows toe
            for (int i = 0; i < height; i++) {
                RowDefinition temprow = new RowDefinition();
                cardGrid.RowDefinitions.Add(temprow);
            }

            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    Button tempbutton = new() {
                        Background = new SolidColorBrush(Color.FromRgb(255, 102, 102)),
                        BorderBrush = new SolidColorBrush(Color.FromRgb(43, 43, 43)),
                        BorderThickness = new Thickness(4),

                        // De ruimte tussen kaarten
                        Margin = new Thickness(5),
                        Height = 100,
                        Width = 100,
                    };
                    tempbutton.SetResourceReference(Control.StyleProperty, "MemoryCardStylep1");
                    tempbutton.Click += new RoutedEventHandler(ClickCard);
                    //zet de row on column
                    Grid.SetColumn(tempbutton, j);
                    Grid.SetRow(tempbutton, i);
                    //voeg hem toe aan de card grid
                    cardGrid.Children.Add(tempbutton);
                }
            }
            //voeg de card grid toe aan de parent grid
            parent.Children.Add(cardGrid);

            return true;
        }
        private void ClickCard(object sender, RoutedEventArgs e) {
            if(!blockinput) {
                    if (buttonspressed.Count() == 0 || buttonspressed[0] != (Button)sender) {
						Button tempbutton = (Button)sender;
						int column = Grid.GetColumn(tempbutton);
						int row = Grid.GetRow(tempbutton);
						if (ImgFolder == "Landen plaatjes") {
							//stomme edge case die minder moeite is dan alles converten naar jpg
							tempbutton.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/" + ImgFolder + "/" + cards[row][column] + ".png")));
						}
						else {
							tempbutton.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/" + ImgFolder + "/" + cards[row][column] + ".jpg")));
						}

						tempbutton.Focusable = false;
						cardsturned.Add(new int[2] { row, column });
						buttonspressed.Add(tempbutton);
						if (cardsturned.Count() >= 2) {
							//player turned 2 cards
							//TODO: wait a bit before ending turn
							var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
							blockinput = true;
							timer.Start();
							timer.Tick += (sender, args) =>
							{
								timer.Stop();
								blockinput = false;
								EndTurn();
							};
						}
					}
               
            }
            
		}
        private void EndTurn() {
            int row1 = cardsturned[0][0];
            int column1 = cardsturned[0][1];
            int row2 = cardsturned[1][0];
            int column2 = cardsturned[1][1];
            Trace.WriteLine("1: " + cards[row1][column1]);
            Trace.WriteLine("2: " + cards[row2][column2]);
            if(cards[row1][column1] == cards[row2][column2]) {
                //cards are the same

                if(PlayerOneTurn) {
                    score1++;
                }
                else {
                    score2++;
                }
                buttonspressed[0].Visibility = Visibility.Hidden;
                buttonspressed[1].Visibility = Visibility.Hidden;
                Trace.WriteLine("removed buttons");
                RemainingCards -= 2;
                if(RemainingCards <= 0) {
                    //game ended
                    Trace.WriteLine("game ended");
                    Trace.WriteLine("player 1: " + score1);
                    Trace.WriteLine("player 2: " + score2);
                    eindScherm eindscherm = new eindScherm();
                    eindscherm.Show();
                    this.Close();
                }
            }
            else {
                PlayerOneTurn = !PlayerOneTurn;
                foreach (var item in cardGrid.Children) {
                    Button tempbtn = (Button)item;
                    if (PlayerOneTurn) {
                        tempbtn.SetResourceReference(Control.StyleProperty, "MemoryCardStylep1");
						//FFFF3477
						tempbtn.Background = new SolidColorBrush(Color.FromRgb(255, 52, 119));
                    }
                    else {
                        tempbtn.SetResourceReference(Control.StyleProperty, "MemoryCardStylep2");
                        tempbtn.Background = new SolidColorBrush(Color.FromRgb(255, 188, 55));
                    }
                }
                buttonspressed[0].Focusable = true;
                buttonspressed[1].Focusable = true;
            }
            
            buttonspressed.RemoveAt(1);
            buttonspressed.RemoveAt(0);
            cardsturned.RemoveAt(1);
            cardsturned.RemoveAt(0);
        }

        private void Geluid_aan_Click(object sender, RoutedEventArgs e)
        {
			mediaPlayer.Play();

			Geluid_uit.Visibility = Visibility.Visible;
            Geluid_aan.Visibility = Visibility.Hidden;

        }

        private void Geluid_uit_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();

            Geluid_uit.Visibility = Visibility.Hidden;
            Geluid_aan.Visibility = Visibility.Visible;
        }
    }
}