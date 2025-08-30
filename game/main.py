# Main entry point for the World Weavers game simulation.
import json
import random
import time
from pathlib import Path
from .game_logic.player import Player
from .game_logic.board import Board
from .game_objects.companion import load_all_companions

def handle_resource_node(player: Player, event: dict):
    """Handles the logic for when a player lands on a resource node."""
    resource = event.get("resource")
    amount = event.get("amount")
    if resource == "coins":
        player.coins += amount
        print(f"You found {amount} coins! Total coins: {player.coins}")
    elif resource == "lumber":
        player.lumber += amount
        print(f"You found {amount} lumber! Total lumber: {player.lumber}")
    # Can be expanded for other resource types

def handle_treasure_chest_node(player: Player, event: dict):
    """Handles the logic for opening a treasure chest."""
    chest_tier = event.get("tier", "wooden")
    data_path = Path(__file__).parent / "data" / "chests.json"

    with open(data_path, 'r') as f:
        chest_data = json.load(f)

    if chest_tier not in chest_data:
        print(f"Unknown chest tier: {chest_tier}")
        return

    chest = chest_data[chest_tier]
    reward = random.choice(chest["rewards"])

    print(f"You opened a {chest['name']} and found a reward!")

    reward_type = reward["type"]
    if reward_type == "coins":
        player.coins += reward["amount"]
        print(f"  -> Got {reward['amount']} coins!")
    elif reward_type == "lumber":
        player.lumber += reward["amount"]
        print(f"  -> Got {reward['amount']} lumber!")
    elif reward_type == "stone":
        player.stone += reward["amount"]
        print(f"  -> Got {reward['amount']} stone!")
    elif reward_type == "sticker_pack":
        print(f"  -> Got a {reward['pack_id']}! (Sticker logic not yet implemented)")

def handle_mini_game_node(player: Player, event: dict):
    """Handles the logic for a memory mini-game."""
    game_type = event.get("game")
    if game_type == "memory":
        print("\n--- Memory Mini-Game! ---")
        sequence = [str(random.randint(1, 9)) for _ in range(3)]
        print(f"Memorize this sequence: {' '.join(sequence)}")

        try:
            input("Press Enter when you have memorized the sequence...")
            print("\n" * 40)

            answer = input("Now, enter the sequence separated by spaces: ")

            if answer.split() == sequence:
                print("Correct! You win a prize!")
                reward = event.get("reward")
                if reward:
                    reward_type = reward.get("type")
                    amount = reward.get("amount")
                    if reward_type == "coins":
                        player.coins += amount
                        print(f"  -> You earned {amount} bonus coins!")
            else:
                print(f"Sorry, that's not correct. The sequence was {' '.join(sequence)}.")
        except Exception as e:
            print(f"An error occurred during the mini-game: {e}")
    else:
        print(f"Unknown mini-game type: {game_type}")

def handle_summon_companion(player: Player, companions_pool: dict):
    """Handles the companion summoning logic."""
    SUMMON_COST = 100
    if player.gems < SUMMON_COST:
        print("Not enough Gems to summon a companion!")
        return

    player.gems -= SUMMON_COST

    # Define rarity weights
    rarity_weights = {"Common": 0.60, "Rare": 0.30, "Epic": 0.09, "Legendary": 0.01}

    # Separate companions by rarity
    by_rarity = {"Common": [], "Rare": [], "Epic": [], "Legendary": []}
    for comp in companions_pool.values():
        by_rarity[comp.rarity].append(comp)

    # Weighted random choice for rarity
    rarities = list(rarity_weights.keys())
    weights = list(rarity_weights.values())
    chosen_rarity = random.choices(rarities, weights=weights, k=1)[0]

    # Randomly choose a companion from the chosen rarity
    if not by_rarity[chosen_rarity]:
        print(f"No companions of rarity {chosen_rarity} found in the pool!")
        return

    summoned_companion = random.choice(by_rarity[chosen_rarity])

    print("\n--- Summoning Portal ---")
    print(f"You spent {SUMMON_COST} Gems and summoned...")
    print(f"A wild {summoned_companion.name} appears! ({summoned_companion.rarity})")
    player.add_companion(summoned_companion)

def handle_store(player: Player):
    """Handles the in-game store logic."""
    data_path = Path(__file__).parent / "data" / "store.json"
    with open(data_path, 'r') as f:
        store_data = json.load(f)

    print("\n--- Welcome to the Store! ---")

    # Create a list of items to display
    items = list(store_data.values())
    for i, item in enumerate(items):
        contents = ", ".join(f"{v} {k}" for k, v in item["contents"].items())
        print(f"{i + 1}: {item['name']} (${item['price_usd']}) - Contains: {contents}")

    print("0: Exit Store")

    try:
        choice = input("What would you like to purchase? (Enter number): ")
        choice_idx = int(choice) - 1

        if choice_idx == -1:
            print("Exiting store.")
            return

        if 0 <= choice_idx < len(items):
            selected_item = items[choice_idx]
            print(f"\nSimulating purchase of {selected_item['name']}...")

            for resource, amount in selected_item["contents"].items():
                if hasattr(player, resource):
                    current_val = getattr(player, resource)
                    setattr(player, resource, current_val + amount)
                    print(f"  -> Added {amount} {resource}.")
                else:
                    print(f"  -> Unknown resource '{resource}' in bundle.")
            print("Purchase successful! Thank you!")
        else:
            print("Invalid selection.")
    except (ValueError, IndexError):
        print("Invalid input. Please enter a number from the list.")


def main_game_loop():
    """The main interactive loop for the game simulation."""
    player = Player(name="Jules")
    board = Board(board_id="whispering_forest")
    all_companions = load_all_companions()

    print("--- Welcome to World Weavers! ---")
    print(f"You are {player.name}, exploring the {board.name}.")
    print("---------------------------------")

    while True:
        print("\n" + str(player))
        print("Companions:", ", ".join(c.name for c in player.companions.values()) or "None")
        action = input("Press Enter to move, 's' to summon, 'shop' to visit the store, or 'q' to quit: ")
        action = action.lower()

        if action == 'q':
            print("Thanks for playing!")
            break

        elif action == 's':
            handle_summon_companion(player, all_companions)

        elif action == 'shop':
            handle_store(player)

        elif action == '':
            event = board.move_player(player)
            if event:
                event_type = event['type']
                if event_type == 'resource':
                    handle_resource_node(player, event)
                elif event_type == 'mini_game':
                    handle_mini_game_node(player, event)
                elif event_type == 'treasure_chest':
                    handle_treasure_chest_node(player, event)
            else:
                print("Game over for now.")
                break
        else:
            print("Invalid action.")

if __name__ == "__main__":
    main_game_loop()
