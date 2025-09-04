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

5.  **Set Up a Simple UI:**
    *   In the Hierarchy, right-click and go to `UI > Canvas` to create a UI canvas.
    *   Right-click the `Canvas` and go to `UI > Button - TextMeshPro` to create a button. Name it `MoveButton` and change its text to "Move".
    *   Duplicate the button and name the new one `SummonButton`. Change its text to "Summon Companion".
    *   Create an empty GameObject and name it `UIController`.
    *   Add the `GameUI` script to the `UIController` GameObject.

6.  **Connect the UI to the Logic:**
    *   Select the `UIController` GameObject. In the Inspector, you will see two fields in the `GameUI` script: `Move Button` and `Summon Button`.
    *   Drag the `MoveButton` GameObject from the Hierarchy into the `Move Button` slot.
    *   Drag the `SummonButton` GameObject from the Hierarchy into the `Summon Button` slot. The `GameUI` script will automatically handle the button clicks.

7.  **Run the Game:**
    *   Press the "Play" button in the Unity Editor.
    *   Open the Console window (`Window > General > Console`) to see the game's output.
    *   Click the "Move" and "Summon Companion" buttons to interact with the game. You will see `Debug.Log` messages in the console reflecting the game's state changes.

## Next Steps

This conversion provides a solid foundation for the "World Weavers" game. Here are some suggestions for what to do next:

*   **Build a Real UI:** Replace the `Debug.Log` statements with actual UI updates. Create UI elements to display the player's energy, coins, companions, and other stats.
*   **Implement Mini-Games:** The logic for mini-games was not included in this conversion. You can now design and implement the "Memory Game" or other mini-games as described in the GDD.
*   **Expand the Store:** Create a UI for the in-game store and implement the purchasing logic.
*   **Add Visuals:** The GDD describes a "beautifully illustrated" game. Start creating or importing art assets for the boards, companions, and UI to bring the game to life.
*   **Implement Saving and Loading:** Add functionality to save and load the player's progress.

Good luck, and have fun building your game!
