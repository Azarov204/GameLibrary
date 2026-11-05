using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using GameLibrary.Model;
using GameLibrary.Services;

namespace GameLibrary;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<Game> Games { get; } = FakeGameService.GetGames();
}
