using System;
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



namespace MemoryGame {
    /// <summary>
    /// Interaction logic for MemoryBoard.xaml
    /// </summary>
    public partial class MemoryBoard : Window {
        public MemoryBoard() {
            InitializeComponent();
            parent = parentGrid;
            //verwijder de lijn hieronder als alle knoppen werken
            generate(6, 5, "Dieren Plaatjes");
        }

        public static int width;
        public static int height;


        public static List<List<int>> cards = new List<List<int>>();

        public static Grid cardGrid;
        private static Grid parent;
        private static string ImgFolder;

        public static bool PlayerOneTurn = true;
        public static List<int[]> cardsturned = new List<int[]>();
        public static List<Button> buttonspressed = new List<Button>();

        public static int score1;
        public static int score2;

        public static bool generate(int w, int h, string folder) {
            width = w;
            height = h;
            ImgFolder = folder;

            score1 = 0;
            score2 = 0;
            PlayerOneTurn = true;

            int cardnum = width * height;
            if(cardnum % 2 == 0) { 
                //hoeveelheid kaarten is een even getal
                List<int> sortedcards = new List<int>();
                for(int i = 0; i < cardnum / 2; i++) {
                    //voeg de kaarten toe aan de unsorted list
                    sortedcards.Add(i);
                    sortedcards.Add(i);
                }
                Random rnd = new Random();
                Trace.WriteLine("memory layout:");
                for (int i = 0; i < height; i++) {
                    //genereer een tijdelijke lijst om toe te kunnen voegen aan de cards lijst
                    List<int> templist = new List<int>();
                    for(int j = 0; j < width; j++) {
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
            for(int i = 0; i < width; i++) {
                ColumnDefinition tempcol = new ColumnDefinition();
                cardGrid.ColumnDefinitions.Add(tempcol);
            }
            //voeg rows toe
            for(int i = 0; i < height; i++) {
                RowDefinition temprow = new RowDefinition();
                cardGrid.RowDefinitions.Add(temprow);
            }

            for(int i = 0; i < height; i++) {
                for(int j = 0; j < width; j++) {
                    Button tempbutton = new() {
                        Background = new SolidColorBrush(Color.FromRgb(255, 102, 102)),
                        BorderBrush = new SolidColorBrush(Color.FromRgb(43, 43, 43)),
                        BorderThickness = new Thickness(4),
                        
					    // De ruimte tussen kaarten
					    Margin = new Thickness(5),
                        Height = 100,
                        Width = 100,
                    };
                    tempbutton.SetResourceReference(Control.StyleProperty, "MemoryCardStyle");
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
        private static void ClickCard(object sender, RoutedEventArgs e) {
            Button tempbutton = (Button)sender;
            int column = Grid.GetColumn(tempbutton);
            int row = Grid.GetRow(tempbutton);
            tempbutton.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/" + ImgFolder + "/" + cards[row][column] + ".jpg")));
            cardsturned.Add(new int[2] { row, column});
            buttonspressed.Add(tempbutton);
            if(cardsturned.Count() >= 2) {
                //player turned 2 cards
                //TODO: wait a bit before ending turn
                EndTurn();
);
               
            }
		}
        private static void EndTurn() {
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
                cardGrid.Children.Remove(buttonspressed[0]);
                cardGrid.Children.Remove(buttonspressed[1]);
                Trace.WriteLine("removed buttons");
            }
            else {
                buttonspressed[0].Background = new SolidColorBrush(Color.FromRgb(255, 102, 102));
                buttonspressed[1].Background = new SolidColorBrush(Color.FromRgb(255, 102, 102));
                PlayerOneTurn = !PlayerOneTurn;
            }
            buttonspressed.RemoveAt(1);
            buttonspressed.RemoveAt(0);
            cardsturned.RemoveAt(1);
            cardsturned.RemoveAt(0);
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