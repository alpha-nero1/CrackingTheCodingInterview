/*
    Jump search involves finding first a chunk that we want to search in the array
    then doing a linear search on that chunk. Time complexity is O(√n)

    "Binary Search is better than Jump Search, but Jump Search has the
    advantage that we traverse back only once (Binary Search may require up to O(Log n) jumps,
    consider a situation where the element to be searched is the smallest element or
    just bigger than the smallest). So, in a system where binary search is costly,
    we use Jump Search."

    Performed on sorted algorithms.
*/

using System;

namespace Core.Searching;

public static class JumpSearch
{
    public static int Search(int[] arr, int x)
    {
        if (arr.Length == 0) return -1;
        int step = (int) Math.Sqrt(arr.Length);

        int stepEndIndex = 0;

        for (int i = 0; i < arr.Length; i += step)
        {
            stepEndIndex = Math.Min((i + step) - 1, arr.Length - 1);
            int val = arr[stepEndIndex];
            if (x < val) break;
        }

        // We have found the correct chunk.
        // Do a linear search on it.
        // Correct for chunk overshooting into negative.
        int stepStartIndex = (stepEndIndex - step);
        if (stepStartIndex < 0) stepStartIndex = 0;
        for (int j = stepStartIndex; j < (stepEndIndex + 1); j += 1)
        {
            if (arr[j] == x) return j;
        }

        return -1;
    }
}