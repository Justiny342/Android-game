# World Weavers - Python to Unity C# Conversion

This project is a C# conversion of the original Python-based "World Weavers" game simulation, designed to be used within the Unity game engine.

## Project Overview

The conversion includes the following key components:

*   **Data-Driven Design:** All game data (boards, companions, chests, etc.) is loaded from the original JSON files.
*   **Core Game Logic:** The main gameplay loop, including player movement, resource collection, and companion summoning, has been converted to C#.
*   **Organized Structure:** The C# scripts are organized into `Scripts` and `Scripts/Data` directories for clarity and maintainability.
*   **Unity Integration:** The code is structured using Unity's MonoBehaviour system and includes a `DataManager` and `GameManager` to manage the game state.

## How to Use in Unity

Follow these steps to get the project running in the Unity Editor:

1.  **Create a New Unity Project:** Start by creating a new 3D or 2D project in Unity Hub.

2.  **Copy Assets:** Copy the entire `Assets` folder from this `unity_project` directory into your new Unity project's root directory. This will bring in the `Scripts` and `Data` folders.

3.  **Create an Empty Scene:** If you have a sample scene, you can use it, or create a new empty scene (`File > New Scene`).

4.  **Set Up the Game Managers:**
    *   Create an empty GameObject and name it `DataManager`.
    *   With the `DataManager` GameObject selected, click "Add Component" in the Inspector and add the `DataManager` script.
    *   Create another empty GameObject and name it `GameManager`.
    *   Add the `GameManager` script to the `GameManager` GameObject.

5.  **Set Up the UI:**
    *   In the Hierarchy, right-click and go to `UI > Canvas` to create a UI canvas.
    *   Create an empty GameObject as a child of the Canvas and name it `UIController`. Add the `GameUI` script to this GameObject.
    *   Create the following UI elements as children of the `Canvas`:
        *   **Text (Legacy):** Create several Text elements for stats (`CoinsText`, `GemsText`, `EnergyText`, `LumberText`, `StoneText`).
        *   **Text (Legacy):** Create a larger Text element for game messages (`GameMessageText`).
        *   **Text (Legacy):** Create another Text element for the companion list (`CompanionListText`).
        *   **Button (Legacy):** Create two buttons, `MoveButton` and `SummonButton`.
    *   **Note:** You can use TextMeshPro instead of legacy Text for better quality, but you will need to change the variable types in `GameUI.cs` from `Text` to `TextMeshProUGUI` and add `using TMPro;`.

6.  **Connect the UI to the Logic:**
    *   Select the `UIController` GameObject.
    *   In the Inspector, you will see many empty fields on the `GameUI` script.
    *   Drag each of the `Text` and `Button` GameObjects you created from the Hierarchy into the corresponding slot in the `GameUI` script component.

7.  **Run the Game:**
    *   Press the "Play" button in the Unity Editor.
    *   The UI Text elements should now update automatically as you play.
    *   Click the "Move" and "Summon Companion" buttons to interact with the game. Watch the stats and messages change in your UI.

## Next Steps

This conversion provides a solid foundation for the "World Weavers" game. Here are some suggestions for what to do next:

*   **Build a Real UI:** Replace the `Debug.Log` statements with actual UI updates. Create UI elements to display the player's energy, coins, companions, and other stats.
*   **Implement Mini-Games:** The logic for mini-games was not included in this conversion. You can now design and implement the "Memory Game" or other mini-games as described in the GDD.
*   **Expand the Store:** Create a UI for the in-game store and implement the purchasing logic.
*   **Add Visuals:** The GDD describes a "beautifully illustrated" game. Start creating or importing art assets for the boards, companions, and UI to bring the game to life.
*   **Implement Saving and Loading:** Add functionality to save and load the player's progress.

Good luck, and have fun building your game!
