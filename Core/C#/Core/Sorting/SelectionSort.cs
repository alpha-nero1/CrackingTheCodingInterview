/*
    Selection sort is one of the most basic sorting alogorithms, it loops the
    array and finds the next min value in the rest of the array.
    Runtime is O(n^2)

    In selection sort we are continually finding the next minimum value in the remainder of
    the array and swapping "i" our for it.
*/

using System;
using Core.Extensions;

namespace Core.Sorting;

public static class SelectionSort
{
    public static int[] Sort(int[] arr, bool asc = true)
    {
        if (asc) return Sort(arr, (min, next) => next < min ? -1 : 1);
        return Sort(arr, (max, next) => next > max ? -1 : 1);
    }

    public static T[] Sort<T>(T[] arr, Func<T, T, int> compFunc)
    {
        int length = arr.Length;
        var copy = arr.DirectCopy();

        for (int i = 0; i < copy.Length; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < copy.Length; j++)
            {
                // Run the comparison, see if we have a new min value.
                if (compFunc(copy[minIndex], copy[j]) == -1)
                {
                    minIndex = j;
                }
            }

            // Swap the next min value in position.
            T temp = copy[minIndex];
            copy[minIndex] = copy[i];
            copy[i] = temp;
        }

        return copy;
    }
}