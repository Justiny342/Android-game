using System;

/// <summary>
/// Represents the contents of an item available in the store.
/// This maps to the "contents" object in store.json.
/// Fields that are not present in the JSON for a specific item will default to 0.
/// </summary>
[Serializable]
public class StoreItemContents
{
    public int gems;
    public int coins;
}

/// <summary>
/// Represents a single item available for purchase in the in-game store.
/// This class is designed to be deserialized from the store.json file.
/// </summary>
[Serializable]
public class StoreItem
{
    public string id; // This will be populated from the key in the JSON dictionary
    public string name;
    public float price_usd;
    public StoreItemContents contents;
}
