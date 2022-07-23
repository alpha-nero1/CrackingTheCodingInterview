/*
    Bubble sort keeps looping the array to evaluate wither a > b and making
    the swap if it is. Bubble sort knows the sort is done when it made an iteration of
    the array and no swap occured.
*/

using System;
using Core.Extensions;

namespace Core.Sorting;

public static class BubbleSort
{
    public static int[] Sort(int[] arr, bool asc = true)
    {
        if (asc) return Sort(arr, (a, b) => a > b ? -1 : 1);
        return Sort(arr, (a, b) => a > b ? 1 : -1);
    }

    public static T[] Sort<T>(T[] arr, Func<T, T, int> compFunc)
    {
        var copy = arr.DirectCopy();
        bool swapMade = false;

        for (int i = 1; i < copy.Length; i++)
        {
            var prev = copy[i - 1];
            var curr = copy[i];

            if (compFunc(prev, curr) == -1)
            {
                // Swap.
                T temp = copy[i];
                copy[i] = copy[i - 1];
                copy[i - 1] = temp;
                swapMade = true;
            }
        }

        // If a swap was made then this pass was not completely in order to begin with
        // let's do more passes untill we are sure it is in order.
        if (swapMade) return Sort(copy, compFunc);

        return copy;
    }
}