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
    /// Het bordgrootte scherm
    /// </summary>
    public partial class ThemaSelectionScreen : Window
    {
        // De knop die nu is uitgezet
        Button currentButton;

        // Zorgt ervoor dat 4 x 4 de eerste geselecteerde optie is
        public ThemaSelectionScreen()
        {
            InitializeComponent();
            currentButton = DierenButton;
            GeneratePreview(SplitTags(currentButton));
        }

        // Genereert een preview van de bordgrootte wanneer je op een grootte klikt
        private void PreviewButtonClick(object sender, RoutedEventArgs e)
        {
            GeneratePreview(SplitTags(sender));
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            // Code om naar het volgende venster te gaan
        }

        // Zet de tags die je aan een knop kunt geven om naar arguments en schakelt de knop uit
        private string[] SplitTags(object sender)
        {
            // Zet de oude knop aan
            currentButton.IsEnabled = true;
            currentButton = sender as Button;
            // En de nieuwe knop uit
            currentButton.IsEnabled = false;
            // Hier wordt elk argument opgesplitst naar een array
            return currentButton.Tag.ToString().Split(' ');
        }

        // Genereert en laat een preview van de bordgrootte zien als grid
        private void GeneratePreview(string[] size)
        {
            // Maakt een nieuw grid aan
            Grid previewGrid = new();
            // Zorgt ervoor dat de preview op de juiste volgorde staat
            previewGrid.SetValue(Grid.RowProperty, 1);
            // Stelt de breedte en hoogte van het grid in
            int boardColumns = int.Parse(size[0]);
            int boardRows = int.Parse(size[1]);

            // Ruimte voor boven
            previewGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            // Voegt kolommen toe
            for (int y = 0; y < boardColumns; y++)
            {
                previewGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(135, GridUnitType.Pixel) });
            }
            // Ruimte voor onder
            previewGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            // Ruimte voor links
            previewGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            // Voegt rijen toe
            for (int x = 0; x < boardRows; x++)
            {
                previewGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(135, GridUnitType.Pixel) });
            }
            // Ruimte voor rechts
            previewGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            // Zet een kaart in elk leeg vakje
            for (int w = 0; w < boardColumns; w++)
            {
                for (int h = 0; h < boardRows; h++)
                {
                    // Maakt een nieuwe rechthoek aan voor elke kaart
                    Border rectangle = new()
                    {
                        Background = new SolidColorBrush(Color.FromRgb(255, 102, 102)),
                        BorderBrush = new SolidColorBrush(Color.FromRgb(43, 43, 43)),
                        BorderThickness = new Thickness(4),
                        CornerRadius = new CornerRadius(12),
                        // De ruimte tussen kaarten
                        Margin = new Thickness(5),
                    };
                    // Voegt de rechthoek toe aan de hierarchy
                    previewGrid.Children.Add(rectangle);
                    // Zet de rechthoek neer in het bijbehorende vakje
                    Grid.SetColumn(rectangle, previewGrid.ColumnDefinitions.Count - w - 2);
                    Grid.SetRow(rectangle, previewGrid.RowDefinitions.Count - h - 2);
                }
            }

            // Verwijdert het oude grid
            previewRow.Children.RemoveAt(2);
            // Voegt het nieuwe grid toe
            previewRow.Children.Add(previewGrid);
        }
    }
}
