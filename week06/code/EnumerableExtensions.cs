using System.Collections.Generic;
using System.Linq;

// Extension for test to match expected string format
public static class EnumerableExtensions
{
    public static IEnumerable<string> AsString(this IEnumerable<int> source)
    {
        // Wrap all numbers in "<IEnumerable>{...}" for the test
        yield return "<IEnumerable>{" + string.Join(", ", source) + "}";
    }
}
