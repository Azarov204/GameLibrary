using GameLibrary.Models;
using System;

namespace GameLibrary.ViewModels
{
    public class GameDetailsViewModel : ViewModelBase
    {
        public Game Game { get; }

        public string? HeroImageUri => Game.HeroImageUri;

        public string PlayTimeDisplay => makePlayTimeDisplay();

        public GameDetailsViewModel(Game game)
        {
            Game = game;
        }

        private string makePlayTimeDisplay()
        {
            // if game has 0-119 minutes, output as minutes
            // if game has 120-36000 minutes, display hours with decimal
            // if game has more than 36000 minutes, display hours only
            int minutes = Game.PlayTimeMinutes;
            int hours = minutes / 60;

            if (minutes < 120)
            {
                return $"{minutes} minutes";
            }
            else if (minutes < 36000) // 600 hours
            {
                double decimalHours = minutes / 60.0;
                return $"{decimalHours:F1} hours";
            }

            return $"{hours} hours";
        }
    }
}