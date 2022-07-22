/*
    Cross linear search, looks at values from the start and end of the array
    at the same time continually incrementing + decrementing to meet half way until
    the value is located, runs in O(n/2) time.
*/

using System.Collections.Generic;

namespace Core.Searching;

public static class CrossLinearSearch
{
    /// <summary>
    /// Perform a cross-linear search and return matching index.
    /// Returns -1 if not found.
    /// </summary>
    public static int Search<T>(T[] arr, T element)
    {
        if (arr.Length == 0) return -1;
        var comparer = EqualityComparer<T>.Default;
        for (int i = 0; i < arr.Length; i++)
        {
            int j = ((arr.Length - 1) - i);
            // If j is now lower than i, we have considered all values.
            if (j < i) return -1;
            if (comparer.Equals(arr[i], element)) return i;
            if (comparer.Equals(arr[j], element)) return j;
        }
        return -1;
    }
}