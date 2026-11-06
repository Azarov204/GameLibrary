
using GameLibrary.Controls;
using GameLibrary.Models;
using GameLibrary.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

namespace GameLibrary.Views;

public sealed partial class LibraryPage : Page
{
    public LibraryViewModel? ViewModel { get; private set; }

    public LibraryPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        if (e.Parameter is LibraryViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;
        }
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

        int columns = Math.Max(1,
            (int)((availableWidth + spacing) /
            (minimumCardWidth + spacing)));

        double cardWidth =
            (availableWidth - (columns * spacing)) / columns;

        // GameCardWidth = cardWidth;
    }
}
