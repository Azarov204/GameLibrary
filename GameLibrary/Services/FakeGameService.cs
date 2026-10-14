using GameLibrary.Model;
using System;
using System.Collections.ObjectModel;

namespace GameLibrary.Services;

public static class FakeGameService
{
    public static ObservableCollection<Game> GetGames()
    {
        return new ObservableCollection<Game>
        {
            new Game
            {
                Id = "1",
                Name = "The Witcher 3: Wild Hunt",
                ExecutablePath = @"C:\Games\Witcher3\witcher3.exe",
                InstallDirectory = @"C:\Games\Witcher3",
                Platform = GamePlatform.Steam,
                Image = "witcher3.jpg",
                Description = "An open-world RPG set in a fantasy universe full of meaningful choices and impactful consequences.",
                Developer = "CD Projekt Red",
                ReleaseDate = new DateTime(2015, 5, 19),
                LastPlayed = DateTime.Now.AddDays(-10),
                PlayTimeMinutes = 856,
                IsFavorite = true
            },
            new Game
            {
                Id = "2",
                Name = "Cyberpunk 2077",
                ExecutablePath = @"C:\Games\Cyberpunk2077\cyberpunk2077.exe",
                InstallDirectory = @"C:\Games\Cyberpunk2077",
                Platform = GamePlatform.EpicGames,
                Image = "cyberpunk2077.jpg",
                Description = "An open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification.",
                Developer = "CD Projekt Red",
                ReleaseDate = new DateTime(2020, 12, 10),
                LastPlayed = DateTime.Now.AddDays(-30),
                PlayTimeMinutes = 337,
                IsFavorite = false
            }
        };
    }
}
