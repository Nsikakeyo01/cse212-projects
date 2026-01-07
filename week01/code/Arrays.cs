using System;
using System.Collections.Generic;

namespace Week01
{
    public static class Arrays
    {
        // ===========================
        // Part 1: MultiplesOf
        // ===========================
        // Plan:
        // 1. Receive a starting number (start) and number of multiples (count).
        // 2. Create a new array of doubles with size equal to count.
        // 3. Loop from i = 0 to i < count:
        //      - Multiply start by (i + 1) to get the current multiple.
        //      - Store the result in the array at index i.
        // 4. After the loop, return the filled array.
        //
        // This plan ensures we generate exactly 'count' multiples starting from 'start'.
        public static double[] MultiplesOf(double start, int count)
        {
            double[] result = new double[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = start * (i + 1);
            }
            return result;
        }

        // ===========================
        // Part 2: RotateListRight
        // ===========================
        // Plan:
        // 1. Receive a List<int> called data and an integer amount to rotate.
        // 2. Calculate the index where we will split the list:
        //      - splitIndex = data.Count - amount
        // 3. Use GetRange to slice the list into two parts:
        //      - rightSegment = last 'amount' elements (from splitIndex to end)
        //      - leftSegment = first part of the list (from 0 to splitIndex)
        // 4. Clear the original list (data.Clear()) to prepare for rotation.
        // 5. Add elements back in rotated order:
        //      - first add rightSegment
        //      - then add leftSegment
        // 6. The original list is now rotated to the right by 'amount'.
        //
        // This approach uses slicing and AddRange to handle rotation efficiently.
        public static void RotateListRight(List<int> data, int amount)
        {
            int splitIndex = data.Count - amount;
            List<int> rightSegment = data.GetRange(splitIndex, amount);
            List<int> leftSegment = data.GetRange(0, splitIndex);
            data.Clear();
            data.AddRange(rightSegment);
            data.AddRange(leftSegment);
        }
    }
}
