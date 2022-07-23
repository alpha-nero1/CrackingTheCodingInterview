/*
    Insertion sort is similar to bubble in that it compares element a to b continually.
    The only different is that a is then placed at the correct position in the left side of
    the array right away. Insertion sort is still O(n^2)
*/

using System;
using Core.Extensions;

namespace Core.Sorting;

public class InsertionSort
{
    public static int[] Sort(int[] arr, bool asc = true)
    {
        if (asc) return Sort(arr, (a, b) => a > b ? -1 : 1);
        return Sort(arr, (a, b) => a > b ? 1 : -1);
    }

    public static T[] Sort<T>(T[] arr, Func<T, T, int> compFunc)
    {
        var copy = arr.DirectCopy();
        for (int i = 1; i < copy.Length; i++)
        {
            // J is the element always before...
            int j = i - 1;

            // The left of pivot is always sorted in asc order.
            var pivot = copy[i];

            while (j >= 0 && compFunc(pivot, copy[j]) == -1)
            {
                // We keep shifting up untill we have found the insertion point.
                copy[j + 1] = copy[j];
                j -= 1;
            }
            // now that we have the insertion point, insert i.
            copy[j + 1] = pivot;
        }
        return copy;
    }
}

// () = i
// item before () = j
// [5, (4), 3, 2, 1]
// [4, 5, (3), 2, 1]
// [3, 4, 5, (2), 1]
// [2, 3, 4, 5, (1)]
// [1, 2, 3, 4, 5]