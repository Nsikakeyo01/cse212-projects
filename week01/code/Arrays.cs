using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// Generates an array of multiples of a given number.
    /// </summary>
    /// <param name="start">The starting number for the multiples.</param>
    /// <param name="count">The number of multiples to generate.</param>
    /// <returns>An array of doubles containing the multiples.</returns>
    public static double[] MultiplesOf(double start, int count)
    {
        // Step 1: Create an array to hold the multiples
        double[] multiples = new double[count];

        // Step 2: Loop through the array and calculate each multiple
        for (int i = 0; i < count; i++)
        {
            multiples[i] = start * (i + 1);
        }

        // Step 3: Return the array filled with multiples
        return multiples;
    }

    /// <summary>
    /// Rotates a list of integers to the right by a specified amount.
    /// </summary>
    /// <param name="data">The list to rotate.</param>
    /// <param name="amount">The number of positions to rotate right.</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate where the list should be split
        int splitIndex = data.Count - amount;

        // Step 2: Get the portion that will move to the front
        List<int> tail = data.GetRange(splitIndex, amount);

        // Step 3: Get the remaining elements
        List<int> head = data.GetRange(0, splitIndex);

        // Step 4: Clear the original list
        data.Clear();

        // Step 5: Add the rotated elements back in correct order
        data.AddRange(tail);
        data.AddRange(head);
    }
}
