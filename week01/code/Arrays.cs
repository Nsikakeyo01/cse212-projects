using System;
using System.Collections.Generic;

namespace Week01
{
    public static class Arrays
    {
        // Part 1: Create an array of multiples of a number
        public static double[] MultiplesOf(double start, int count)
        {
            // Step 1: Create an array that can hold 'count' values
            double[] multiples = new double[count];

            // Step 2: Loop through the array indices
            for (int i = 0; i < count; i++)
            {
                // Step 3: Calculate each multiple
                // Multiply the starting number by (i + 1) to get sequential multiples
                multiples[i] = start * (i + 1);
            }

            // Step 4: Return the completed array
            return multiples;
        }

        // Part 2: Rotate a list to the right by 'amount'
        public static void RotateListRight(List<int> data, int amount)
        {
            // Step 1: Determine the split index
            // The last 'amount' of elements will move to the front
            int splitIndex = data.Count - amount;

            // Step 2: Extract the elements that will move to the front
            List<int> rightSegment = data.GetRange(splitIndex, amount);

            // Step 3: Extract the elements that will remain at the back
            List<int> leftSegment = data.GetRange(0, splitIndex);

            // Step 4: Clear the original list so we can rebuild it
            data.Clear();

            // Step 5: Add the right segment first (rotated elements)
            data.AddRange(rightSegment);

            // Step 6: Add the left segment after
            data.AddRange(leftSegment);
        }
    }
}
