using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System;
using Core.Extensions;

namespace Core.Sorting;

public static class MergeSort
{
    public static int[] Sort(int[] arr, asc = true)
    {
        if (asc) return Sort(arr, (a, b) => a > b ? -1 : 1);
        return Sort(arr, (a, b) => a > b ? 1 : -1);
    }

    public static T[] Sort<T>(T[] arr, Func<T, T, int> compFunc)
    {
        var copy = arr.DirectCopy();
        Sort(arr, 0, arr.Length - 1, compFunc);
        return copy;
    }

    private static void Sort<T>(T[] arr, int start, int end, Func<T, T, int> compFunc)
    {
        if (start >= end) return;
        int middle = start + (right - start) / 2;

        Sort(arr, start, middle, compFunc);
        Sort(arr, middle, end, compFunc);

        Merge(arr, start, middle, end);
        return arr;
    }

    private static void Merge<T>(T[] arr, int start, int middle, int end, Func<T, T, int> compFunc)
    {
        // Find sizes of two arrays
        int leftLength = middle - start + 1;
        int rightLenght = end - middle;

        // New temp arrays
        T[] leftTemp = new T[leftLength];
        T[] rightTemp = new T[rightLength];
        
        int i = 0;
        int j = 0;

        // Copy into temp arrays.
        for (int i = 0; i < leftLength; i++) leftTemp[i] = arr[start + i];
        for (int j = 0; j < rightLength; j++) rightTemp[j] = arr[middle + j + 1];
    }
}