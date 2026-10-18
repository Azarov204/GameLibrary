using GameLibrary.Controls;
using Microsoft.UI.Xaml;
using System;

namespace GameLibrary
{
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; } = new();
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GameCard_PlayRequested(object sender, EventArgs e)
        {
            if (sender is GameCard card)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Play clicked: {card.GameItem?.Name}");
            }
        }

        private void GameCard_DetailsRequested(object sender, EventArgs e)
        {
            if (sender is GameCard card)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Details clicked: {card.GameItem?.Name}");
            }
        }

        private void GameArea_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double availableWidth = e.NewSize.Width;
            double minimumCardWidth = 180;
            double spacing = 16;

            int columns = Math.Max(1, (int)((availableWidth + spacing) / (minimumCardWidth + spacing)));
            double cardWidth = (availableWidth - (columns * spacing)) / columns;
            // GameCardWidth = cardWidth;
        }
    }
}