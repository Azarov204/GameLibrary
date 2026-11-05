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
                Name = "Assassin's Creed III",
                ExecutablePath = @"C:\Games\AssassinsCreed3\AC3SP.exe",
                InstallDirectory = @"C:\Games\AssassinsCreed3",
                Platform = GamePlatform.EaApp,
                Image = "ac3.png",
                Hero = "ac3_hero.jpg",
                Description = "Experience the American Revolution as Connor Kenway, an Assassin fighting to protect his people and secure freedom in a world on the brink of change.",
                Developer = "Ubisoft Montreal",
                ReleaseDate = new DateTime(2012, 10, 30),
                LastPlayed = DateTime.Now.AddDays(-3),
                PlayTimeMinutes = 1240,
                IsFavorite = true
            },
            new Game
            {
                Id = "2",
                Name = "Counter-Strike 2",
                ExecutablePath = @"C:\Games\CounterStrike2\cs2.exe",
                InstallDirectory = @"C:\Games\CounterStrike2",
                Platform = GamePlatform.Steam,
                Image = "cs2.png",
                Hero = "cs2_hero.png",
                Description = "A competitive tactical first-person shooter where teams of terrorists and counter-terrorists battle through objective-based rounds requiring teamwork, precision, and strategy.",
                Developer = "Valve",
                ReleaseDate = new DateTime(2023, 9, 27),
                LastPlayed = DateTime.Now.AddHours(-5),
                PlayTimeMinutes = 5830,
                IsFavorite = true
            },
            new Game
            {
                Id = "3",
                Name = "DOOM (2016)",
                ExecutablePath = @"C:\Games\DOOM\DOOMx64.exe",
                InstallDirectory = @"C:\Games\DOOM",
                Platform = GamePlatform.Steam,
                Image = "doom.png",
                Hero = "doom_hero.jpg",
                Description = "Fight demonic forces on Mars as the DOOM Slayer in a fast-paced first-person shooter built around aggressive combat, powerful weapons, and relentless action.",
                Developer = "id Software",
                ReleaseDate = new DateTime(2016, 5, 13),
                LastPlayed = DateTime.Now.AddDays(-14),
                PlayTimeMinutes = 720,
                IsFavorite = false
            },
            new Game
            {
                Id = "4",
                Name = "Cyberpunk 2077",
                ExecutablePath = @"C:\Games\Cyberpunk2077\bin\x64\Cyberpunk2077.exe",
                InstallDirectory = @"C:\Games\Cyberpunk2077",
                Platform = GamePlatform.GOG,
                Image = "cyberpunk.png",
                Hero = "cyberpunk_hero.jpg",
                Description = "An open-world action RPG set in Night City, a futuristic metropolis driven by corporate power, cybernetic enhancements, and underground crime. Play as V and shape your story through consequential choices.",
                Developer = "CD Projekt Red",
                ReleaseDate = new DateTime(2020, 12, 10),
                LastPlayed = DateTime.Now.AddDays(-1),
                PlayTimeMinutes = 2460,
                IsFavorite = true
            },
            new Game
            {
                Id = "5",
                Name = "Red Dead Redemption 2",
                ExecutablePath = @"C:\Games\RedDeadRedemption2\RDR2.exe",
                InstallDirectory = @"C:\Games\RedDeadRedemption2",
                Platform = GamePlatform.Rockstar,
                Image = "reddead2.png",
                Hero = "reddead2_hero.png",
                Description = "Follow outlaw Arthur Morgan and the Van der Linde gang as they struggle to survive in America's fading Wild West through a sprawling open-world adventure.",
                Developer = "Rockstar Studios",
                ReleaseDate = new DateTime(2018, 10, 26),
                LastPlayed = DateTime.Now.AddDays(-7),
                PlayTimeMinutes = 3120,
                IsFavorite = true
            },
            new Game
            {
                Id = "6",
                Name = "Assassin's Creed",
                ExecutablePath = @"C:\Games\AssassinsCreed\AssassinsCreed_Dx9.exe",
                InstallDirectory = @"C:\Games\AssassinsCreed",
                Platform = GamePlatform.Unknown,
                Image = "ac1.png",
                Hero = "ac1_hero.jpg",
                Description = "Play as Altaïr Ibn-La'Ahad, a skilled Assassin tasked with eliminating key targets during the Third Crusade while uncovering a conspiracy that threatens the balance of power.",
                Developer = "Ubisoft Montreal",
                ReleaseDate = new DateTime(2007, 11, 13),
                LastPlayed = DateTime.Now.AddDays(-45),
                PlayTimeMinutes = 540,
                IsFavorite = false
            },
            new Game
            {
                Id = "7",
                Name = "The Last of Us Part I",
                ExecutablePath = @"C:\Games\TheLastOfUsPart1\TheLastOfUsPart1.exe",
                InstallDirectory = @"C:\Games\TheLastOfUsPart1",
                Platform = GamePlatform.Steam,
                Image = "lastofus.png",
                Hero = "lastofus_hero.png",
                Description = "Survive a post-apocalyptic United States as Joel escorts Ellie across a dangerous landscape, forming a bond that becomes central to their journey.",
                Developer = "Naughty Dog",
                ReleaseDate = new DateTime(2023, 3, 28),
                LastPlayed = DateTime.Now.AddDays(-20),
                PlayTimeMinutes = 960,
                IsFavorite = false
            }
        };

    }
}
