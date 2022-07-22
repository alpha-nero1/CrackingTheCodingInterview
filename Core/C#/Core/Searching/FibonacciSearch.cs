/*
    Fibonacci search executed the search only using +/- operators
    useful for certain CPUs.
*/

using System;

namespace Core.Searching;

public static class FibonacciSearch
{
    public static int Search(int[] arr, int value)
    {
        if (arr.Length == 0) return -1;

        // Initialise fibonacci.
        int fibValueTwo = 0;
        int fibValueOne = 1;
        int fibNext = fibValueTwo + fibValueOne;

        // Keep incrementing fib untill reached arr end (1, 2, 3, 5, 8, 13, 21, 34...)
        // Get fibNext to store smallest fibonacci number greater or equal to arr.Length.
        // Our case 55.
        while (fibNext < arr.Length)
        {
            fibValueTwo = fibValueOne;
            fibValueOne = fibNext;
            fibNext = fibValueTwo + fibValueOne;
        }

        // Marks the eliminated range from the front.
        int offset = -1;

        // We compare arr[fibValueTwo] with value,
        // When fibNext becomes 1, fibValueTwo becomes 0.
        while (fibNext > 1)
        {
            int nextSectionIndex = Math.Min(offset + fibValueTwo, arr.Length - 1);

            // We have found it, return element!
            if (arr[nextSectionIndex] == value) return nextSectionIndex;

            // If value is greater than fibValueTwo, cut the subarray from
            // offset to nextSectionIndex
            if (arr[nextSectionIndex] < value)
            {
                fibNext = fibValueOne;
                fibValueOne = fibValueTwo;
                fibValueTwo = fibNext - fibValueOne;
                offset = nextSectionIndex;
                continue;
            }
            // If value is less than fibValueTwo cut the subarray
            // after nextSectionIndex + 1;
            fibNext = fibValueTwo;
            fibValueOne = fibValueOne - fibValueTwo;
            fibValueTwo = fibNext - fibValueOne;
        }

        if (fibValueOne == 1 && arr[arr.Length - 1] == value) return arr.Length - 1;

        return -1;
    }
}
