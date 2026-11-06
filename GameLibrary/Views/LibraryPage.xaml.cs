
using GameLibrary.Controls;
using GameLibrary.Models;
using GameLibrary.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using WinRT.Interop;

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

    private async void AddGameButton_Click(object sender, RoutedEventArgs e)
    { 
        var picker = new FileOpenPicker();

        picker.ViewMode = PickerViewMode.List;
        picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
        picker.FileTypeFilter.Add(".exe");

        var hwnd = WindowNative.GetWindowHandle(App.MainWindow);
        InitializeWithWindow.Initialize(picker, hwnd);

        StorageFile file = await picker.PickSingleFileAsync();

        if (file == null)
        {
            return;
        }

        // Validate selected file
        if (!File.Exists(file.Path) || !string.Equals(Path.GetExtension(file.Path), ".exe", StringComparison.OrdinalIgnoreCase))
        {
            await ShowErrorAsync("Please select a valid executable (.exe) file.");
        }

        if (ViewModel.Games.Any(g => string.Equals(g.ExecutablePath, file.Path, StringComparison.OrdinalIgnoreCase)))
        {
            await ShowErrorAsync($"{Path.GetFileNameWithoutExtension(file.Name)} has already been added.");
            return;
        }

        // Create game object
        var game = new Game
        {
            Name = Path.GetFileNameWithoutExtension(file.Name),
            ExecutablePath = file.Path,
            InstallDirectory = Path.GetDirectoryName(file.Path) ?? string.Empty,
            IsFavorite = false,
            PlayTimeMinutes = 0
        };

        ViewModel.Games.Add(game);
    }

    private async Task ShowErrorAsync(string message)
    {
        var dialog = new ContentDialog
        {
            Title = "Unable to add game",
            Content = message,
            CloseButtonText = "OK",
            XamlRoot = this.XamlRoot
        };

        await dialog.ShowAsync();
    }
}
