# Defines the data structure for Companions.
import json
from pathlib import Path
from dataclasses import dataclass

@dataclass
class Companion:
    """Represents a single companion creature in the game."""
    id: str
    name: str
    rarity: str
    bonus_type: str
    bonus_value: float

    def __str__(self):
        return f"{self.name} ({self.rarity}) - Bonus: +{self.bonus_value * 100}% {self.bonus_type.replace('_', ' ')}"

def load_all_companions() -> dict[str, Companion]:
    """Loads all companion definitions from the JSON data file."""
    data_path = Path(__file__).parent.parent / "data" / "companions.json"
    companions = {}
    with open(data_path, 'r') as f:
        data = json.load(f)
        for comp_id, details in data.items():
            companions[comp_id] = Companion(
                id=comp_id,
                name=details['name'],
                rarity=details['rarity'],
                bonus_type=details['bonus']['type'],
                bonus_value=details['bonus']['value']
            )
    return companions
