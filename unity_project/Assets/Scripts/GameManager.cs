using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

/// <summary>
/// The central hub for the game's logic, managing the player, board, and game state.
/// This is a C# conversion of the logic found in the main.py file of the Python prototype.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Player currentPlayer;
    private Board currentBoard;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Ensure DataManager has loaded its data first
        if (DataManager.Instance == null)
        {
            Debug.LogError("DataManager instance not found. Make sure it's in the scene and loads first.");
            return;
        }
        StartNewGame();
    }

    /// <summary>
    /// Initializes a new game, creating the player and the first board.
    /// </summary>
    public void StartNewGame()
    {
        currentPlayer = new Player("Jules");

        // Load the initial board from the DataManager
        if (DataManager.Instance.AllBoardData.TryGetValue("whispering_forest", out BoardData boardData))
        {
            currentBoard = new Board(boardData);
            Debug.Log($"--- Welcome to World Weavers! ---");
            Debug.Log($"You are {currentPlayer.Name}, exploring the {currentBoard.Name}.");
            Debug.Log("---------------------------------");
            PrintPlayerStatus();
        }
        else
        {
            Debug.LogError("Initial board 'whispering_forest' not found in DataManager.");
        }
    }

    /// <summary>
    /// This method is called when the player chooses to move.
    /// </summary>
    public void MovePlayer()
    {
        if (currentBoard == null) return;

        NodeEvent eventData = currentBoard.MovePlayer(currentPlayer);
        if (eventData != null)
        {
            HandleNodeEvent(eventData);
        }
        else
        {
            Debug.Log("Cannot move further or not enough energy.");
        }
        PrintPlayerStatus();
    }

    private void HandleNodeEvent(NodeEvent eventData)
    {
        switch (eventData.type)
        {
            case "resource":
                HandleResourceNode(eventData);
                break;
            case "treasure_chest":
                HandleTreasureChestNode(eventData);
                break;
            case "mini_game":
                // Mini-game logic is complex and would require its own systems.
                // For this conversion, we'll just acknowledge it.
                Debug.Log($"Landed on a mini-game node: {eventData.game}. Logic not implemented in this conversion.");
                break;
            default:
                Debug.LogWarning($"Unknown event type: {eventData.type}");
                break;
        }
    }

    private void HandleResourceNode(NodeEvent eventData)
    {
        if (eventData.resource == "coins")
        {
            currentPlayer.Coins += eventData.amount;
            Debug.Log($"You found {eventData.amount} coins! Total coins: {currentPlayer.Coins}");
        }
        else if (eventData.resource == "lumber")
        {
            currentPlayer.Lumber += eventData.amount;
            Debug.Log($"You found {eventData.amount} lumber! Total lumber: {currentPlayer.Lumber}");
        }
    }

    private void HandleTreasureChestNode(NodeEvent eventData)
    {
        if (DataManager.Instance.AllChestData.TryGetValue(eventData.tier, out Chest chest))
        {
            if (chest.rewards.Count > 0)
            {
                // Select a random reward from the chest's reward list
                ChestReward reward = chest.rewards[Random.Range(0, chest.rewards.Count)];
                Debug.Log($"You opened a {chest.name} and found a reward!");

                switch (reward.type)
                {
                    case "coins":
                        currentPlayer.Coins += reward.amount;
                        Debug.Log($"  -> Got {reward.amount} coins!");
                        break;
                    case "lumber":
                        currentPlayer.Lumber += reward.amount;
                        Debug.Log($"  -> Got {reward.amount} lumber!");
                        break;
                    case "stone":
                        currentPlayer.Stone += reward.amount;
                        Debug.Log($"  -> Got {reward.amount} stone!");
                        break;
                    case "sticker_pack":
                        Debug.Log($"  -> Got a {reward.pack_id}! (Sticker logic not yet implemented)");
                        break;
                }
            }
        }
        else
        {
            Debug.LogWarning($"Chest tier '{eventData.tier}' not found in DataManager.");
        }
    }

    /// <summary>
    /// Handles the companion summoning logic.
    /// </summary>
    public void SummonCompanion()
    {
        const int SUMMON_COST = 100;
        if (currentPlayer.Gems < SUMMON_COST)
        {
            Debug.Log("Not enough Gems to summon a companion!");
            return;
        }

        currentPlayer.Gems -= SUMMON_COST;

        // This simplified summoning logic gives an equal chance to all companions.
        // The weighted logic from Python could be implemented here if needed.
        var allCompanions = new List<Companion>(DataManager.Instance.AllCompanionData.Values);
        if (allCompanions.Count > 0)
        {
            Companion summonedCompanion = allCompanions[Random.Range(0, allCompanions.Count)];
            currentPlayer.AddCompanion(summonedCompanion);

            Debug.Log("\n--- Summoning Portal ---");
            Debug.Log($"You spent {SUMMON_COST} Gems and summoned...");
            Debug.Log($"A wild {summonedCompanion.name} appears! ({summonedCompanion.rarity})");
            Debug.Log($"Companion added to your collection: {summonedCompanion.name}");
        }
        else
        {
            Debug.Log("No companions available to summon.");
        }
        PrintPlayerStatus();
    }

    private void PrintPlayerStatus()
    {
        Debug.Log("\n" + currentPlayer.ToString());
        string companionNames = "";
        foreach(var c in currentPlayer.Companions.Values)
        {
            companionNames += c.name + ", ";
        }
        Debug.Log("Companions: " + (companionNames.Length > 0 ? companionNames.Substring(0, companionNames.Length - 2) : "None"));

    }
}
