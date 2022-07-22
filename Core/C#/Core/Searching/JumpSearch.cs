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

namespace Core.Searching;

public static class JumpSearch
{
    public static int Search(int[] arr, int x)
    {
        return -1;
    }
}