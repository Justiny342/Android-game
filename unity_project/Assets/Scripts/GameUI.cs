using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A simple UI script to demonstrate how to interact with the GameManager.
/// In a Unity scene, you would create a Canvas and add Buttons, then link their
/// OnClick events in the Inspector to call the public methods on this script.
/// </summary>
public class GameUI : MonoBehaviour
{
    // In the Unity Editor, you would drag your UI Buttons to these fields.
    public Button moveButton;
    public Button summonButton;
    // Add other buttons for store, etc., as needed.

    void Start()
    {
        // Add listeners to the buttons to call the appropriate methods when clicked.
        if (moveButton != null)
        {
            moveButton.onClick.AddListener(OnMoveButtonPressed);
        }

        if (summonButton != null)
        {
            summonButton.onClick.AddListener(OnSummonButtonPressed);
        }
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

    // You could add more methods here to handle other UI interactions,
    // such as opening the store, viewing companions, etc.
}
