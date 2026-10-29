using GameLibrary.Controls;
using GameLibrary.Model;
using GameLibrary.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace GameLibrary.Pages;

/// <summary>
public sealed partial class LibraryPage : Page
{
    public MainViewModel ViewModel { get; } = new();
    public LibraryPage()
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
        if (sender is GameCard card && card.GameItem is Game game)
        {
            Frame.Navigate(typeof(GameDetailsPage), game);
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
