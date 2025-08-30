# Manages the game board, nodes, and events.
import json
from pathlib import Path
from typing import List, Dict, Any
from .player import Player

class Board:
    """Manages a game board, its nodes, and player movement."""
    def __init__(self, board_id: str):
        self.board_id = board_id
        self.name, self.nodes = self._load_board_data()
        self.player_position = 0

    def _load_board_data(self) -> (str, List[Dict[str, Any]]):
        """Loads the board layout and nodes from the JSON data file."""
        data_path = Path(__file__).parent.parent / "data" / "boards.json"
        with open(data_path, 'r') as f:
            data = json.load(f)
            if self.board_id not in data:
                raise ValueError(f"Board with id '{self.board_id}' not found.")
            board_data = data[self.board_id]
            return board_data['name'], board_data['nodes']

    def move_player(self, player: Player) -> Dict[str, Any] | None:
        """Moves the player to the next node if they have enough energy."""
        if player.energy < 1:
            print("Not enough energy to move!")
            return None

        if self.player_position >= len(self.nodes) - 1:
            print("You have reached the end of the board!")
            return None

        player.energy -= 1
        self.player_position += 1
        current_node = self.nodes[self.player_position]
        print(f"Moved to node {self.player_position + 1}. Event: {current_node['type']}")
        return current_node

    def __str__(self):
        return f"Board: {self.name} ({len(self.nodes)} nodes)"
