using GameLibrary.Models;
using GameLibrary.Services;
using System.Collections.ObjectModel;

namespace GameLibrary.ViewModels;

public class LibraryViewModel : ViewModelBase
{
    private readonly IGameService _gameService;

    public ObservableCollection<Game> Games { get; } = new ObservableCollection<Game>();

    private Game? _selectedGame;

    public Game? SelectedGame
    {
        get => _selectedGame;
        set
        {
            if (ReferenceEquals(_selectedGame, value))
                return;

            _selectedGame = value;
            OnPropertyChanged();
        }
    }

    public LibraryViewModel(IGameService gameService)
    {
        _gameService = gameService;

        LoadGames();
    }

    private void LoadGames()
    {
        Games.Clear();

        foreach (Game game in _gameService.GetGames())
        {
            Games.Add(game);
        }
    }
}