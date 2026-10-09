using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Model;
using GameLibrary.Services;

namespace GameLibrary;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    public partial int Count { get; set; } = 0;

    [ObservableProperty]
    public partial string Title { get; set; } = "Game Library - 0";

    public ObservableCollection<Game> Games { get; } = FakeGameService.GetGames();


    [RelayCommand]
    public void IncrementCount()
    {
        Count++;
        Title = $"Game Library - {Count}";
    }
}
