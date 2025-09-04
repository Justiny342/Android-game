using UnityEngine;

/// <summary>
/// Manages a game board, its nodes, and the player's position on it.
/// This is a C# conversion of the Python Board class from the original prototype.
/// It is a plain C# object that holds state and is managed by the GameManager.
/// </summary>
public class Board
{
    public string Name { get; private set; }
    public BoardData Data { get; private set; }

    private int playerPosition = -1; // Start at -1, so the first move is to position 0

    public Board(BoardData boardData)
    {
        Data = boardData;
        Name = boardData.name;
    }

    /// <summary>
    /// Moves the player to the next node on the board if they have enough energy.
    /// </summary>
    /// <param name="player">The player instance, used to check and decrement energy.</param>
    /// <returns>The NodeEvent for the new position, or null if the move is not possible or the board ends.</returns>
    public NodeEvent MovePlayer(Player player)
    {
        if (player.Energy < 1)
        {
            Debug.Log("Not enough energy to move!");
            return null;
        }

        if (playerPosition >= Data.nodes.Count - 1)
        {
            Debug.Log("You have reached the end of the board!");
            return null;
        }

        player.Energy -= 1;
        playerPosition++;

        NodeEvent currentNode = Data.nodes[playerPosition];
        Debug.Log($"Moved to node {playerPosition + 1}. Event: {currentNode.type}");

        return currentNode;
    }
}
