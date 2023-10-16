using System;
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
    public partial class MemoryBoard : Page {
        public MemoryBoard() {
            InitializeComponent();
        }
        public static List<List<int>> cards = new List<List<int>>();
        public static void generate(int w, int h) {
            int cardnum = w * h;
            if(cardnum % 2 == 0) { 
                //hoeveelheid kaarten is een even getal
                List<int> sortedcards = new List<int>();
                for(int i = 0; i < cardnum / 2; i++) {
                    //voeg de kaarten toe aan de unsorted list
                    sortedcards.Add(i);
                    sortedcards.Add(i);
                }
                Random rnd = new Random();
                for (int i = 0; i < h; i++) {
                    List<int> templist = new List<int>();
                    for(int j = 0; j < w; j++) {
                        int rand = rnd.Next(0, sortedcards.Count() - 1);
                        templist.Add(sortedcards[rand]);
                        sortedcards.RemoveAt(rand);
                    }
                    cards.Add(templist);
                }
                
            }
            else {
                Trace.WriteLine("de ingevoegde grootte levert een oneven aantal kaarten.");
            }
        }
    }
}
