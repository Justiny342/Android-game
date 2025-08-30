# Game Design Document: World Weavers

## 1. Game Title & Core Concept

**Game Title:** World Weavers (Alternate: Companion Quest)

**Core Concept:** A casual, free-to-play mobile game where players explore diverse, fantastical worlds on a virtual game board. The core loop involves spending "energy" to travel, collecting resources and companions, and using those resources to build and customize a personal home base. The game's design prioritizes long-term player retention, social interaction, and proven monetization strategies, targeting the top-earning spot on the Android platform.

## 2. Core Gameplay Loop (The "Adventure")

### 2.1. Board Exploration

The core of the game takes place on a beautifully illustrated, themed game board. Each board represents a unique world (e.g., "Whispering Forest," "Crystal Caves," "Sky Archipelago").

*   **Movement:** Players move along a linear path with branching points. Movement is not based on dice rolls but on spending a primary resource called "Energy." Each tap on the "Move" button consumes one Energy and moves the player to the next node on the path. This gives players a sense of control and strategic decision-making, especially when faced with branching paths.
*   **Board Progression:** Completing a board (reaching the final node) unlocks the next, more challenging and visually distinct world.

### 2.2. Node-Based Events

Each space on the board triggers an event. The variety of events keeps the gameplay fresh and exciting.

*   **Resource Nodes:** The most common type of node.
    *   **Coin Nodes:** Grant the primary soft currency, "Coins." The amount can be a fixed value or a small range.
    *   **Material Nodes:** Grant building materials (e.g., "Lumber," "Stone," "Magic Essence") used for constructing and upgrading the Home Base.
*   **Mini-Games:** Landing on these nodes initiates a simple, engaging skill challenge.
    *   **Match-3 Puzzle:** A small 5x5 grid where the player has a limited number of moves to match gems for bonus Coins and Materials.
    *   **Timing Tap:** A moving bar with a "critical hit" zone. A successful tap in the zone yields a large reward.
    *   **Memory Game:** A quick "flip and match" card game to find pairs of items.
*   **Friendly Raids ("Playful Plunder"):**
    *   This node allows the player to visit a randomly selected friend's (or a random player's) board.
    *   The player can choose to either:
        *   **Leave a Gift:** Drop a small bundle of Energy or Coins for the friend to collect. This action fosters goodwill.
        *   **Raid:** "Steal" a small, fixed percentage of the friend's available Coins. The amount is capped to prevent negative feelings. The raided player is notified and can perform a "Revenge Raid" to get their coins back. This interaction is designed to be playful and competitive, not punitive.
*   **Treasure Chests:**
    *   **Wooden Chest:** Contains a mix of Coins and Materials.
    *   **Golden Chest:** Contains a larger amount of Coins, rare Materials, and a chance for a Sticker Pack or a small amount of Gems.
*   **Narrative Nodes:**
    *   These nodes trigger short, charming story moments. This could be a dialogue with a world-specific character, a short animated scene, or a piece of lore about the world. These nodes help to build the game's universe and emotional connection.
*   **Companion Encounter Nodes:**
    *   A rare node that allows the player to meet a new Companion. This may trigger a short quest or a dialogue, after which the Companion is added to the player's collection.

## 3. Meta-Game & Progression (The "Collection")

### 3.1. Home Base

The Home Base is the player's personal, customizable space and the core of the long-term progression system.

*   **Building & Upgrading:** Players use Materials gathered from the boards to construct and upgrade various buildings.
    *   **Main House:** The central structure. Upgrading it unlocks new decorations and increases the player's overall "Prestige" level.
    *   **Resource Generators:** Buildings that passively generate Coins or Materials over time (e.g., "Coin Mint," "Lumber Mill").
    *   **Companion Habitats:** Structures where players can display their favorite Companions.
*   **Decoration:** Players can decorate their Home Base with a wide variety of cosmetic items, from paths and fences to statues and gardens. This provides a deep level of personalization and self-expression.
*   **Progression Gate:** Certain Home Base levels or specific building upgrades are required to unlock new game boards, creating a seamless link between the core loop and the meta-game.

### 3.2. Companion Collection System (Gacha)

Companions are charming creatures and characters that serve as the primary collectible and gacha element.

*   **Companion Roster:** A vast collection of Companions, each with unique art, animations, and a backstory.
*   **Passive Bonuses:** Each Companion provides a passive bonus that affects gameplay. These bonuses are designed to be helpful but not game-breaking.
    *   *Example Bonuses:* "+10% Coins from nodes," "15% chance to find extra Lumber," "Reduces the cost of building upgrades by 5%."
*   **Summoning Mechanic:** Companions are primarily acquired through a "Summoning Portal" at the Home Base.
    *   **Summoning Cost:** Uses the premium currency, "Gems."
    *   **Gacha Rates:** The system will have clear, published drop rates for different rarities of Companions (e.g., Common, Rare, Epic, Legendary).
    *   **Pity System:** A guaranteed Epic or Legendary Companion after a certain number of summons without one, ensuring player satisfaction.

### 3.3. Sticker Album System

This system is designed to be a powerful driver of social interaction and long-term engagement.

*   **Themed Albums:** Players collect "Stickers" to complete albums, each themed around a world, event, or Companion set.
*   **Acquisition:** Stickers are found in "Sticker Packs," which can be earned from Treasure Chests, event rewards, or purchased in the shop.
*   **Set Completion Rewards:** Completing a sticker set grants a massive one-time reward, such as a large amount of Energy, thousands of Coins, Gems, or even an exclusive, high-rarity Companion.
*   **Sticker Trading:**
    *   Players will inevitably collect duplicate stickers.
    *   The game will feature a robust trading system where players can trade their duplicates with friends.
    *   This creates a vibrant player-driven economy and makes the friends list a valuable asset. The social pressure and collaborative joy of completing albums together is a key retention mechanic.

## 4. Monetization Strategy

The economy is designed around multiple pillars to cater to different player spending habits, with a focus on value and long-term investment.

### 4.1. Energy System

*   **Function:** Energy is the primary gate for the core gameplay loop. Each move on the board costs Energy.
*   **Refill:** Energy refills automatically over time (e.g., 1 Energy every 10 minutes). The maximum Energy cap can be increased by leveling up.
*   **Purchase:** Players can instantly refill their Energy bar by spending Gems or by purchasing special Energy bundles in the shop for real money.

### 4.2. Premium Currency ("Gems")

*   **Acquisition:** Gems are primarily purchased with real money. Small amounts can be earned through gameplay (e.g., album completion, event rewards) to give non-spending players a taste of their power.
*   **Primary Use:** The main sink for Gems is the Companion Summoning system. This targets the "collector" or "whale" player archetype.
*   **Secondary Uses:**
    *   Bypassing timers on Home Base constructions.
    *   Purchasing exclusive cosmetic items for the Home Base.
    *   Buying Sticker Packs.

### 4.3. Event Passes (Seasonal "Journey Pass")

*   **Structure:** A monthly or bi-monthly pass with a free and a premium reward track.
*   **Progression:** Players complete daily and weekly quests (e.g., "Land on 20 Coin Nodes," "Raid 3 friends," "Open 5 Treasure Chests") to earn "Journey Points" and advance along the tracks.
*   **Rewards:**
    *   **Free Track:** Provides a steady stream of valuable resources like Coins, Energy, and Sticker Packs.
    *   **Premium Track:** Offers high-value, exclusive items, including:
        *   An exclusive Epic or Legendary Companion available only through the pass.
        *   Unique, themed decorations for the Home Base.
        *   Large quantities of Gems and Energy.
        *   Exclusive player profile cosmetics (avatars, frames).

### 4.4. Bundles & Special Offers

*   **Starter Bundles:** High-value, one-time purchase offers for new players, typically bundling a large amount of Energy, a good sum of Gems, and a guaranteed Rare Companion.
*   **Limited-Time Offers (LTOs):** Triggered by certain player actions (e.g., leveling up, running out of Energy). These offers provide a high-value bundle for a short period, creating a sense of urgency.
*   **Piggy Bank:** A feature where a percentage of Coins spent by the player accumulates in a "Piggy Bank." The player can then purchase the Piggy Bank for a small amount of real money to "break it open" and claim the accumulated Coins, often at a much better rate than standard Coin packs.

## 5. Social Features

Social interaction is at the heart of World Weavers, designed to create a strong community and enhance long-term retention.

### 5.1. Friends System

*   **Adding Friends:** Players can easily add friends via social media integration (Facebook), unique player IDs, or by sending requests to players they encounter through the "Playful Plunder" feature.
*   **Visiting Bases:** Players can visit their friends' Home Bases at any time to see their progress, check out their decorations, and view their Companion collection. This inspires competition and showcases collectible items.

### 5.2. Sticker Trading

*   **Interface:** A clean and intuitive interface for requesting specific stickers and offering duplicates in return. Players can browse their friends' available duplicates.
*   **Trade Limits:** To prevent exploitation, players might be limited to a certain number of trades per day (e.g., 5 trades). This also increases the perceived value of each trade.
*   **Community Hub:** The game could feature a dedicated Discord or forum, promoted in-game, to facilitate trading between players who are not on each other's friends list.

### 5.3. Leaderboards

*   **Timed Events:** The game will feature regular weekend events (e.g., "Sun Crystal Festival," "Forest Spirit Hunt"). During these events, special nodes appear on the board that grant event-specific tokens.
*   **Competitive Rankings:** Leaderboards will track who has collected the most event tokens, both globally and among a player's friends.
*   **Rewards:** Top-ranking players receive exclusive rewards, such as a rare Companion, unique decorations, or a large amount of Gems, fostering friendly competition.

## 6. Art Style & User Experience

### 6.1. Art Direction

*   **Style:** Stylized, vibrant, and welcoming. The art should feel like a living storybook. Characters and Companions should be designed with personality and charm, using soft shapes and expressive animations.
*   **Audience:** The visuals must be friendly and appealing to a very broad, casual audience (ages 13-55), avoiding overly complex or niche aesthetics. The goal is a universally appealing look that is both high-quality and approachable.
*   **Worlds:** Each world will have a distinct color palette and visual theme, making progression feel meaningful and exciting.

### 6.2. UI/UX

*   **Intuitive Design:** The user interface must be clean, intuitive, and free of clutter. Important buttons (like the "Move" button) should be large and easily accessible.
*   **One-Handed Play:** The layout will be optimized for portrait mode and one-handed play, allowing for easy gameplay during commutes or short breaks.
*   **Feedback:** The game will provide satisfying visual and audio feedback for all player actions, from collecting coins to summoning a new Companion. This enhances the feeling of reward and engagement.
*   **Onboarding:** A smooth and guided tutorial experience will introduce new players to the core mechanics (moving, building, collecting Companions) without overwhelming them. The tutorial will be integrated into the initial gameplay, making it feel natural and engaging.
