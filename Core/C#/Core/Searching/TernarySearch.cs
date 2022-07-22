/*
    Ternary search algorithm, works for sorted arrays in O(log n base 3)
    because two-thirds of the array is continually discarded on each pass!
    runtime is better than binary.
*/

namespace Core.Searching;

public static class TernarySearch
{
    public static int Search(int[] arr, int value)
    {
        return Search(arr, 0, arr.Length - 1, value);
    }

    // Ternary search, keep halving the array untill we find
    // that x is a middle point.
    // runtime = O(log n)
    private static int Search(int[] arr, int left, int right, int x)
    {
        if (right > left)
        {
            // We know we are searching normally.
            int middleOne = (left + (right - 1)) / 3;
            int middleTwo = (right - (left - 1)) / 3;

            // If middles ARE x then just return that.
            if (arr[middleOne] == x) return middleOne;
            if (arr[middleTwo] == x) return middleTwo;

            if (x < arr[middleOne]) return Search(arr, left, middleOne - 1, x);
            if (x < arr[middleTwo]) return Search(arr, middleOne + 1, middleTwo - 1, x);
            return Search(arr, middleTwo + 1, right, x);
        }
        // If no item was returned the answer is not found.
        return -1;
    }
}