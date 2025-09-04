using System;
using System.Collections.Generic;

/// <summary>
/// Represents a reward, typically from a mini-game.
/// This maps to the "reward" object within a mini-game node in boards.json.
/// </summary>
[Serializable]
public class RewardData
{
    public string type;
    public int amount;
}

/// <summary>
/// Represents a single event that can occur on a board node.
/// This class includes fields for all possible event types found in boards.json
/// (resource, mini_game, treasure_chest).
/// </summary>
[Serializable]
public class NodeEvent
{
    public string type;

    // For "resource" type
    public string resource;
    public int amount;

    // For "mini_game" type
    public string game;
    public RewardData reward;

    // For "treasure_chest" type
    public string tier;
}

/// <summary>
/// Represents a single game board, containing its name and a list of nodes.
/// This class is designed to be deserialized from the boards.json file.
/// </summary>
[Serializable]
public class BoardData
{
    public string id; // This will be populated from the key in the JSON dictionary
    public string name;
    public List<NodeEvent> nodes;
}
