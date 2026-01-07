using System;
using System.Collections.Generic;

namespace Week01
{
    public static class Arrays
    {
        // Part 1: MultiplesOf
        // Creates an array of multiples of 'start' for 'count' numbers
        public static double[] MultiplesOf(double start, int count)
        {
            double[] result = new double[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = start * (i + 1); // multiply start by 1..count
            }
            return result;
        }

        // Part 2: RotateListRight
        // Rotates a list of integers to the right by 'amount'
        public static void RotateListRight(List<int> data, int amount)
        {
            int splitIndex = data.Count - amount; // calculate the split point
            List<int> rightSegment = data.GetRange(splitIndex, amount); // last 'amount' items
            List<int> leftSegment = data.GetRange(0, splitIndex);      // first part
            data.Clear();                         // remove all items
            data.AddRange(rightSegment);          // add rotated right part first
            data.AddRange(leftSegment);           // add the remaining left part
        }
    }
}
