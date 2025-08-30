# World Weavers - Game Simulation

This project is a Python-based simulation of the mobile game concept "World Weavers," based on the Game Design Document (`gdd.md`).

## Project Structure

- `gdd.md`: The main Game Design Document.
- `game/`: The root directory for the game's Python source code.
  - `main.py`: The main entry point to run the game simulation.
  - `game_logic/`: Contains the core gameplay mechanics.
    - `board.py`: Manages the game board, nodes, and events.
    - `player.py`: Manages the player's state (energy, resources, etc.).
  - `game_objects/`: Contains the data definitions for in-game items.
    - `companion.py`: Defines the Companion class.
    - `sticker.py`: Defines the Sticker class.
  - `data/`: Contains JSON files for game data.
    - `boards.json`: Defines the structure and events of game boards.
    - `companions.json`: Defines the stats and bonuses for Companions.
- `requirements.txt`: Lists the Python dependencies for this project.
