using System;

/// <summary>
/// Represents the bonus a companion provides.
/// This is a direct mapping to the "bonus" object in companions.json.
/// </summary>
[Serializable]
public class CompanionBonus
{
    public string type;
    public float value;
}

/// <summary>
/// Represents a single companion creature in the game.
/// This class is designed to be deserialized from the companions.json file.
/// </summary>
[Serializable]
public class Companion
{
    public string id; // This will be populated from the key in the JSON dictionary
    public string name;
    public string rarity;
    public CompanionBonus bonus;

    public override string ToString()
    {
        // The bonus type string is formatted to be more human-readable.
        string formattedBonusType = bonus.type.Replace('_', ' ');
        return $"{name} ({rarity}) - Bonus: +{bonus.value * 100}% {formattedBonusType}";
    }
}
