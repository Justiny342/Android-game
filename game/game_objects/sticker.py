# Defines the data structure for Stickers.
from dataclasses import dataclass

@dataclass
class Sticker:
    """Represents a single sticker that belongs to an album."""
    id: str
    name: str
    album: str
    rarity: int  # e.g., 1 to 5 stars

    def __str__(self):
        return f"'{self.name}' Sticker (Album: {self.album}, Rarity: {self.rarity}*)"
