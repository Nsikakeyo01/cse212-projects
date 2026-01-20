// Maze.cs
using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<(int, int), bool[]> maze;
    private int x = 1;
    private int y = 1;

    public Maze(Dictionary<(int, int), bool[]> map)
    {
        maze = map;
    }

    public string GetStatus()
    {
        return $"Current location (x={x}, y={y})";
    }

    public void MoveLeft()
    {
        if (!maze[(x, y)][0])
            throw new InvalidOperationException("Can't go that way!");

        x--;
    }

    public void MoveRight()
    {
        if (!maze[(x, y)][1])
            throw new InvalidOperationException("Can't go that way!");

        x++;
    }

    public void MoveUp()
    {
        if (!maze[(x, y)][2])
            throw new InvalidOperationException("Can't go that way!");

        y--; // moving up decreases y
    }

    public void MoveDown()
    {
        if (!maze[(x, y)][3])
            throw new InvalidOperationException("Can't go that way!");

        y++; // moving down increases y
    }
}
