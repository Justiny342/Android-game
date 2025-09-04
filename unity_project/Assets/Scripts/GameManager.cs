using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

/// <summary>
/// The central hub for the game's logic, managing the player, board, and game state.
/// This version uses events to communicate with the UI layer.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Events for the UI to subscribe to
    public static event Action<Player> OnPlayerStatsChanged;
    public static event Action<string> OnGameMessage;

    public Player CurrentPlayer { get; private set; }
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
        if (DataManager.Instance == null)
        {
            Debug.LogError("DataManager instance not found. Make sure it's in the scene and loads first.");
            return;
        }
        StartNewGame();
    }

    public void StartNewGame()
    {
        CurrentPlayer = new Player("Jules");

        if (DataManager.Instance.AllBoardData.TryGetValue("whispering_forest", out BoardData boardData))
        {
            currentBoard = new Board(boardData);
            OnGameMessage?.Invoke($"--- Welcome to World Weavers! ---\nYou are {CurrentPlayer.Name}, exploring the {currentBoard.Name}.");
            OnPlayerStatsChanged?.Invoke(CurrentPlayer);
        }
        else
        {
            Debug.LogError("Initial board 'whispering_forest' not found in DataManager.");
        }
    }

    public void MovePlayer()
    {
        if (currentBoard == null) return;

        NodeEvent eventData = currentBoard.MovePlayer(CurrentPlayer);
        if (eventData != null)
        {
            HandleNodeEvent(eventData);
        }
        else
        {
            OnGameMessage?.Invoke("Cannot move further or not enough energy.");
        }
        OnPlayerStatsChanged?.Invoke(CurrentPlayer);
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
                OnGameMessage?.Invoke($"Landed on a mini-game node: {eventData.game}. Logic not implemented.");
                break;
            default:
                Debug.LogWarning($"Unknown event type: {eventData.type}");
                break;
        }
    }

    private void HandleResourceNode(NodeEvent eventData)
    {
        string message = "";
        if (eventData.resource == "coins")
        {
            CurrentPlayer.Coins += eventData.amount;
            message = $"You found {eventData.amount} coins!";
        }
        else if (eventData.resource == "lumber")
        {
            CurrentPlayer.Lumber += eventData.amount;
            message = $"You found {eventData.amount} lumber!";
        }
        OnGameMessage?.Invoke(message);
    }

    private void HandleTreasureChestNode(NodeEvent eventData)
    {
        if (DataManager.Instance.AllChestData.TryGetValue(eventData.tier, out Chest chest))
        {
            if (chest.rewards.Count > 0)
            {
                ChestReward reward = chest.rewards[Random.Range(0, chest.rewards.Count)];
                string message = $"You opened a {chest.name} and found a reward!\n";

                switch (reward.type)
                {
                    case "coins":
                        CurrentPlayer.Coins += reward.amount;
                        message += $"  -> Got {reward.amount} coins!";
                        break;
                    case "lumber":
                        CurrentPlayer.Lumber += reward.amount;
                        message += $"  -> Got {reward.amount} lumber!";
                        break;
                    case "stone":
                        CurrentPlayer.Stone += reward.amount;
                        message += $"  -> Got {reward.amount} stone!";
                        break;
                    case "sticker_pack":
                        message += $"  -> Got a {reward.pack_id}! (Sticker logic not yet implemented)";
                        break;
                }
                OnGameMessage?.Invoke(message);
            }
        }
        else
        {
            Debug.LogWarning($"Chest tier '{eventData.tier}' not found in DataManager.");
        }
    }

    public void SummonCompanion()
    {
        const int SUMMON_COST = 100;
        if (CurrentPlayer.Gems < SUMMON_COST)
        {
            OnGameMessage?.Invoke("Not enough Gems to summon a companion!");
            return;
        }

        CurrentPlayer.Gems -= SUMMON_COST;

        var allCompanions = new List<Companion>(DataManager.Instance.AllCompanionData.Values);
        if (allCompanions.Count > 0)
        {
            Companion summonedCompanion = allCompanions[Random.Range(0, allCompanions.Count)];
            CurrentPlayer.AddCompanion(summonedCompanion);

            string message = $"--- Summoning Portal ---\n";
            message += $"You spent {SUMMON_COST} Gems and summoned...\n";
            message += $"A wild {summonedCompanion.name} appears! ({summonedCompanion.rarity})";
            OnGameMessage?.Invoke(message);
        }
        else
        {
            OnGameMessage?.Invoke("No companions available to summon.");
        }
        OnPlayerStatsChanged?.Invoke(CurrentPlayer);
    }
}
