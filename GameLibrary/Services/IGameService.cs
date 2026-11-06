using System.Collections.Generic;
using GameLibrary.Models;

namespace GameLibrary.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetGames();
    }
}