using System;
using System.Collections.Generic;

namespace Week01
{
    public static class Arrays
    {
        // Part 1: Create an array of multiples of a given starting number
        public static double[] MultiplesOf(double start, int count)
        {
            // Step 1: Create an array that can hold 'count' values
            double[] result = new double[count];

            // Step 2: Loop over the array indices
            for (int i = 0; i < count; i++)
            {
                // Step 3: Each element is start * (i + 1)
                // This ensures the first element is start * 1
                result[i] = start * (i + 1);
            }

            // Step 4: Return the completed array
            return result;
        }

        // Part 2: Rotate a list to the right by 'amount'
        public static void RotateListRight(List<int> data, int amount)
        {
            // Step 1: Determine the index to split the list
            // Last 'amount' elements move to the front
            int splitIndex = data.Count - amount;

            // Step 2: Extract the elements to move to the front
            List<int> rightSegment = data.GetRange(splitIndex, amount);

            // Step 3: Extract the remaining elements
            List<int> leftSegment = data.GetRange(0, splitIndex);

            // Step 4: Clear the original list so we can rebuild it
            data.Clear();

            // Step 5: Add the right segment first
            data.AddRange(rightSegment);

            // Step 6: Add the left segment after
            data.AddRange(leftSegment);
        }
    }
}
jj