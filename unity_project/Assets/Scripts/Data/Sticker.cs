using System;

/// <summary>
/// Represents a single sticker that belongs to an album.
/// This class is a C# representation of the Python Sticker class.
/// In the current Python prototype, this class is defined but not used in any JSON data.
/// It's included here for completeness based on the Python source.
/// </summary>
[Serializable]
public class Sticker
{
    public string id;
    public string name;
    public string album;
    public int rarity; // e.g., 1 to 5 stars

    public override string ToString()
    {
        return $"'{name}' Sticker (Album: {album}, Rarity: {rarity}*)";
    }
}
