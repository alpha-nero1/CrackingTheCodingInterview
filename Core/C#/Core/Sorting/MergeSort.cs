/*
    Merge sort, sort arrays in O(n log n). This is an amazing algorithm that takes
    two sides of an array until no longer divisible and continually joins them
    back together in an orderly fashion.
*/

using System;
using Core.Extensions;

namespace Core.Sorting;

public static class MergeSort
{
    public static int[] Sort(int[] arr, bool asc = true)
    {
        if (asc) return Sort(arr, (a, b) => a > b ? -1 : 1);
        return Sort(arr, (a, b) => a > b ? 1 : -1);
    }

    // Entry method.
    public static T[] Sort<T>(T[] arr, Func<T, T, int> compFunc)
    {
        var copy = arr.DirectCopy();
        return Sort(copy, 0, copy.Length - 1, compFunc);
    }

    private static T[] Sort<T>(T[] arr, int start, int end, Func<T, T, int> compFunc)
    {
        if (start >= end) return arr;
        int middle = start + (end - start) / 2;

        // Recursive calls to acheive granularity.
        Sort(arr, start, middle, compFunc);
        Sort(arr, middle + 1, end, compFunc);

        Merge(arr, start, middle, end, compFunc);
        return arr;
    }

    // Used to split arrays into left and right sides.
    private static T[] GetArraySegment<T>(T[] arr, int offset, int length)
    {
        T[] segment = new T[length];
        for (int i = 0; i < length; i++) segment[i] = arr[offset + i];
        return segment;
    }

    // Main algorithm.
    private static void Merge<T>(T[] arr, int start, int middle, int end, Func<T, T, int> compFunc)
    {
        // Find sizes of two arrays
        int leftLength = middle - start + 1;
        int rightLength = end - middle;

        // New left and right array.
        T[] leftArray = GetArraySegment(arr, start, leftLength);
        T[] rightArray = GetArraySegment(arr, middle + 1, rightLength);

        int leftCursor = 0;
        int rightCursor = 0;

        // Reference to actual final array index...
        int resultCursor = start;

        // While there are comparsions to be made...
        // This is the bulk of the algorithm.
        while (leftCursor < leftLength && rightCursor < rightLength)
        {
            if (compFunc(leftArray[leftCursor], rightArray[rightCursor]) == -1)
            {
                // If right element is greater than left element then
                // set the insertion element to be that on the right array.
                arr[resultCursor] = rightArray[rightCursor];
                rightCursor += 1;
                resultCursor += 1;
                continue;
            }
            // Else insertion element will be that on the left.
            arr[resultCursor] = leftArray[leftCursor];
            leftCursor += 1;
            resultCursor += 1;
        }

        // Copy any remaining elements in the case the arrays were not even.
        // The next two while loops are just cleanup for extra items...
        while (leftCursor < leftLength)
        {
            arr[resultCursor] = leftArray[leftCursor];
            leftCursor += 1;
            resultCursor += 1;
        }

        while (rightCursor < rightLength)
        {
            arr[resultCursor] = rightArray[rightCursor];
            rightCursor += 1;
            resultCursor += 1;
        }
    }
}