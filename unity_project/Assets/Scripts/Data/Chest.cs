using System;
using System.Collections.Generic;

/// <summary>
/// Represents a single potential reward item from a treasure chest.
/// This maps to the objects inside the "rewards" array in chests.json.
/// </summary>
[Serializable]
public class ChestReward
{
    public string type;
    public int amount;
    public string pack_id; // Used for sticker packs
}

/// <summary>
/// Represents a treasure chest with a collection of possible rewards.
/// This class is designed to be deserialized from the chests.json file.
/// </summary>
[Serializable]
public class Chest
{
    public string tier; // This will be populated from the key in the JSON dictionary
    public string name;
    public List<ChestReward> rewards;
}
