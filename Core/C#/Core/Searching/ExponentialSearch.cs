/*
    Exponential searching is a combination of
    1. Finding the range where the value is present.
    2. Binary searching in that range.

    "Applications of Exponential Search:
    - Exponential Binary Search is particularly useful for unbounded searches,
        where size of array is infinite. Please refer Unbounded Binary Search for an example.
    - It works better than Binary Search for bounded arrays, and also when the
        element to be searched is closer to the first element."
*/

using System;
using Core.Extensions;

namespace Core.Searching;

public static class ExponentialSearch
{
    public static int Search(int[] arr, int value)
    {
        if (value < 0) return -1;
        if (arr[0] == value) return 0;

        int segmentEndIndex = -1;

        for (int i = 1; i < arr.Length; i *= 2)
        {
            segmentEndIndex = Math.Min(arr.Length - 1, i * 2);
            // If we happen to land on the value then just return.
            if (arr[segmentEndIndex] == value) return segmentEndIndex;
            if (value <= arr[segmentEndIndex])
            {
                var segment = arr.SubArray(segmentEndIndex / 2, segmentEndIndex / 2 + 1);
                var res = BinarySearch.Search(segment, value);
                if (res == -1) return -1;
                return i + res;
            }
        }

        return -1;
    }
}