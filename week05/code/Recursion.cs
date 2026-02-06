using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: if n is zero or negative, nothing to add
        if (n <= 0)
            return 0;

        // Recursive case: n^2 + sum of squares up to (n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }


    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(
    List<string> results,
    string letters,
    int size,
    string word = "")
    {
        // Base case: when the word reaches the desired length
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive step: try adding each unused letter
        foreach (char ch in letters)
        {
            // Only use letters that are not already in the word
            if (!word.Contains(ch))
            {
                PermutationsChoose(results, letters, size, word + ch);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Create dictionary the first time the function runs
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base case: exactly 1 way to climb 0 stairs (do nothing)
        if (s == 0)
            return 1;

        // If s goes negative, it's not a valid path
        if (s < 0)
            return 0;

        // If we already solved this value, reuse it
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive step: try climbing 1, 2, or 3 steps
        decimal totalWays =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        // Store result for efficiency
        remember[s] = totalWays;

        return totalWays;
    }


    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base case: if there are no wildcards left, store the pattern
        int starIndex = pattern.IndexOf('*');

        if (starIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace the first * with 0
        string withZero =
            pattern.Substring(0, starIndex) + "0" + pattern.Substring(starIndex + 1);

        // Replace the first * with 1
        string withOne =
            pattern.Substring(0, starIndex) + "1" + pattern.Substring(starIndex + 1);

        // Recurse on both possibilities
        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
    }


    // currPath.Add((1,2)); // Use this syntax to add to the current path




    public static void SolveMaze(
     List<string> results,
     Maze maze,
     int x = 0,
     int y = 0,
     List<(int, int)>? currPath = null)
    {
        // First call: initialize the path list
        if (currPath == null)
        {
            currPath = new List<(int, int)>();
        }

        // Stop if the move is invalid
        if (!maze.IsValidMove(currPath, x, y))
        {
            return;
        }

        // Add current position to the path
        currPath.Add((x, y));

        // If we reached the end, save the solution path
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore recursively in all four directions
        SolveMaze(results, maze, x + 1, y, currPath); // Right
        SolveMaze(results, maze, x - 1, y, currPath); // Left
        SolveMaze(results, maze, x, y + 1, currPath); // Down
        SolveMaze(results, maze, x, y - 1, currPath); // Up

        // Backtrack before returning
        currPath.RemoveAt(currPath.Count - 1);
    }

}