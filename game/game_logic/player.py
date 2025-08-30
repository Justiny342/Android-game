# Manages the player's state, including energy, resources, and companions.
from dataclasses import dataclass, field
from typing import Dict
from ..game_objects.companion import Companion
from ..game_objects.sticker import Sticker

@dataclass
class Player:
    """Represents the player and their current state in the game."""
    name: str
    energy: int = 50
    coins: int = 1000
    lumber: int = 0
    stone: int = 0
    gems: int = 500

    # Collections
    companions: Dict[str, Companion] = field(default_factory=dict)
    stickers: Dict[str, int] = field(default_factory=dict) # sticker_id -> count

    def add_companion(self, companion: Companion):
        """Adds a new companion to the player's collection."""
        if companion.id not in self.companions:
            self.companions[companion.id] = companion
            print(f"Added {companion.name} to your collection!")

    def add_sticker(self, sticker: Sticker, quantity: int = 1):
        """Adds a sticker to the player's album."""
        self.stickers[sticker.id] = self.stickers.get(sticker.id, 0) + quantity
        print(f"You got a '{sticker.name}' sticker! You now have {self.stickers[sticker.id]}.")

    def __str__(self):
        return (
            f"Player: {self.name}\n"
            f"Energy: {self.energy}, Coins: {self.coins}, Gems: {self.gems}, Lumber: {self.lumber}, Stone: {self.stone}\n"
            f"Companions: {len(self.companions)}, Stickers: {sum(self.stickers.values())}"
        )
