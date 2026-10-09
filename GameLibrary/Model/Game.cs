using System;

namespace GameLibrary.Model;

public class Game
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public string ExecutablePath { get; set; } = string.Empty;
    public string InstallDirectory { get; set; } = string.Empty;
    public GamePlatform Platform { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Developer { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public DateTime? LastPlayed { get; set; }
    public int PlayTimeMinutes { get; set; }
    public bool IsFavorite { get; set; }

}
