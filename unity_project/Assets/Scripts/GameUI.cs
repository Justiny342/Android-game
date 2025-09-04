using UnityEngine;
using UnityEngine.UI;
using System.Text;

/// <summary>
/// Manages all the main UI elements for the game.
/// This script subscribes to events from the GameManager to keep the UI in sync with the game state.
/// </summary>
public class GameUI : MonoBehaviour
{
    [Header("Player Stats Display")]
    public Text coinsText;
    public Text gemsText;
    public Text energyText;
    public Text lumberText;
    public Text stoneText;

    [Header("Message and Companion Display")]
    public Text gameMessageText;
    public Text companionListText;

    [Header("Player Actions")]
    public Button moveButton;
    public Button summonButton;

    void OnEnable()
    {
        // Subscribe to events
        GameManager.OnPlayerStatsChanged += UpdatePlayerStats;
        GameManager.OnGameMessage += DisplayGameMessage;

        // Set up button listeners
        if (moveButton != null)
        {
            moveButton.onClick.AddListener(OnMoveButtonPressed);
        }

        if (summonButton != null)
        {
            summonButton.onClick.AddListener(OnSummonButtonPressed);
        }
    }

    void OnDisable()
    {
        // Unsubscribe from events to prevent memory leaks
        GameManager.OnPlayerStatsChanged -= UpdatePlayerStats;
        GameManager.OnGameMessage -= DisplayGameMessage;

        // It's also good practice to remove listeners on disable/destroy
        if (moveButton != null)
        {
            moveButton.onClick.RemoveListener(OnMoveButtonPressed);
        }

        if (summonButton != null)
        {
            summonButton.onClick.RemoveListener(OnSummonButtonPressed);
        }
    }

    /// <summary>
    /// This method is called when the OnPlayerStatsChanged event is fired.
    /// It updates all the UI text elements with the latest player data.
    /// </summary>
    private void UpdatePlayerStats(Player player)
    {
        if (player == null) return;

        coinsText.text = $"Coins: {player.Coins}";
        gemsText.text = $"Gems: {player.Gems}";
        energyText.text = $"Energy: {player.Energy}";
        lumberText.text = $"Lumber: {player.Lumber}";
        stoneText.text = $"Stone: {player.Stone}";

        // Update companion list
        var sb = new StringBuilder("Companions: ");
        if (player.Companions.Count > 0)
        {
            foreach (var companion in player.Companions.Values)
            {
                sb.Append(companion.name);
                sb.Append(", ");
            }
            // Remove the last ", "
            sb.Length -= 2;
        }
        else
        {
            sb.Append("None");
        }
        companionListText.text = sb.ToString();
    }

    /// <summary>
    /// This method is called when the OnGameMessage event is fired.
    /// It displays a message to the player.
    /// </summary>
    private void DisplayGameMessage(string message)
    {
        gameMessageText.text = message;
    }

    /// <summary>
    /// Called when the "Move" button is pressed.
    /// </summary>
    public void OnMoveButtonPressed()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.MovePlayer();
        }
    }

    /// <summary>
    /// Called when the "Summon" button is pressed.
    /// </summary>
    public void OnSummonButtonPressed()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SummonCompanion();
        }
    }
}
