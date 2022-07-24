/*
    Quicksort works much like merge sort, however,
*/

using System;
using Core.Extensions;

namespace Core.Sorting;

public static class QuickSort
{
    public static int[] Sort(int[] arr, bool asc = true)
    {
        if (asc) return Sort(arr, (a, b) => a > b ? -1 : 1);
        return Sort(arr, (a, b) => a > b ? 1 : -1);
    }

    public static T[] Sort<T>(T[] arr, Func<T, T, int> compFunc)
    {
        var copy = arr.DirectCopy();
        Sort(copy, 0, copy.Length - 1, compFunc);
        return copy;
    }

    private static void Sort<T>(T[] arr, int low, int high, Func<T, T, int> compFunc)
    {
        if (low >= high) return;
        int pivot = Partition(arr, low, high, compFunc);

        // Sort elements on left and right of pivot.
        Sort(arr, low, pivot - 1, compFunc);
        Sort(arr, pivot + 1, high, compFunc);
    }

    private static int Partition<T>(T[] arr, int low, int high, Func<T, T, int> compFunc)
    {
        var pivot = arr[high];

        int i = low - 1;

        // This code ensures that everything on the left
        // of the pivot is lower than everything on the right.
        for (int j = low; j < high; j++)
        {
            var next = arr[j];
            if (compFunc(pivot, next) == -1)
            {
                i += 1;
                arr.Swap(i, j);
            }
        }

        arr.Swap(i + 1, high);

        return i + 1;
    }
}