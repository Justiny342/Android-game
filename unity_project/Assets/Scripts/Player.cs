using System.Collections.Generic;
using System.Text;

/// <summary>
/// Represents the player and their current state in the game.
/// This class is a direct C# conversion of the Python Player class.
/// </summary>
public class Player
{
    public string Name { get; private set; }
    public int Energy { get; set; }
    public int Coins { get; set; }
    public int Lumber { get; set; }
    public int Stone { get; set; }
    public int Gems { get; set; }

    public Dictionary<string, Companion> Companions { get; private set; }
    public Dictionary<string, int> Stickers { get; private set; }

    public Player(string name)
    {
        Name = name;
        Energy = 50;
        Coins = 1000;
        Lumber = 0;
        Stone = 0;
        Gems = 500;
        Companions = new Dictionary<string, Companion>();
        Stickers = new Dictionary<string, int>();
    }

    /// <summary>
    /// Adds a new companion to the player's collection if it's not already present.
    /// </summary>
    public void AddCompanion(Companion companion)
    {
        if (!Companions.ContainsKey(companion.id))
        {
            Companions.Add(companion.id, companion);
            // In a real Unity game, you would use a logging framework or display this in the UI.
            // For this conversion, we'll use UnityEngine.Debug.Log in the GameManager.
        }
    }

    /// <summary>
    /// Adds a sticker to the player's album, or increments the count if it already exists.
    /// </summary>
    public void AddSticker(Sticker sticker, int quantity = 1)
    {
        if (Stickers.ContainsKey(sticker.id))
        {
            Stickers[sticker.id] += quantity;
        }
        else
        {
            Stickers.Add(sticker.id, quantity);
        }
    }

    /// <summary>
    /// Provides a string representation of the player's current status.
    /// </summary>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Player: {Name}");
        sb.AppendLine($"Energy: {Energy}, Coins: {Coins}, Gems: {Gems}, Lumber: {Lumber}, Stone: {Stone}");
        sb.AppendLine($"Companions: {Companions.Count}, Stickers: {Stickers.Values.Count}");
        return sb.ToString();
    }
}
