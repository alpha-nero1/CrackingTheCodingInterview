/*
    Linear search, looks at each individual element untill the
    value is located, runs in O(n) time.
*/

using System.Collections.Generic;

namespace Core.Searching;

public static class LinearSearch
{
    /// <summary>
    /// Perform a linear search and return matching index.
    /// Returns -1 if not found.
    /// </summary>
    public static int Search<T>(T[] arr, T element)
    {
        if (arr.Length == 0) return -1;
        var comparer = EqualityComparer<T>.Default;
        for (int i = 0; i < arr.Length; i++)
        {
            if (comparer.Equals(arr[i], element)) return i;
        }
        return default;
    }
}