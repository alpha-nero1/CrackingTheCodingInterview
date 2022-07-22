/*
    Binary search algorithm, works for sorted arrays in O(log n)
    because half the array is continually discarded on each pass!
*/

namespace Core.Searching;

public static class BinarySearch
{
    public static int Search(int[] arr, int value)
    {
        return Search(arr, 0, arr.Length - 1, value);
    }

    // Binary search, keep halving the array untill we find
    // that x is a middle point.
    // runtime = O(log n)
    private static int Search(int[] arr, int left, int right, int x)
    {
        if (right > left)
        {
            // We know we are searching normally.
            int middle = (left + (right - 1)) / 2;
            // If middle IS x then just return that.
            if (arr[middle] == x) return middle;

            // If element is smaller than mid, then can only be present in left array,
            // and vice versa.
            // (middle - 1 = the new right for the recursive call.)
            if (x < arr[middle]) return Search(arr, left, middle - 1, x);
            return Search(arr, middle + 1, right, x);
        }
        // If no item was returned the answer is not found.
        return -1;
    }
}