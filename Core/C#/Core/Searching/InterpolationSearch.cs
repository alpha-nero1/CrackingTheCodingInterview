/*
    Similar to binary search, is optimised for uniformly distributed datasets.

    "The Interpolation Search is an improvement over Binary Search for instances,
    where the values in a sorted array are uniformly distributed.
    Interpolation constructs new data points within the range of a discrete set of
    known data points. Binary Search always goes to the middle element to check.
    On the other hand, interpolation search may go to different locations according
    to the value of the key being searched. For example, if the value of the key is closer
    to the last element, interpolation search is likely to start search toward the end side.
    To find the position to be searched, it uses the following formula."
*/

namespace Core.Searching;

public static class InterpolationSearch
{
    public static int Search(int[] arr, int value)
    {
        return Search(arr, 0, arr.Length - 1, value);
    }

    private static int Search(int[] arr, int lowIndex, int highIndex, int value)
    {
        int pos = 0;

        if (
            lowIndex <= highIndex
            && value >= arr[lowIndex]
            && value <= arr[highIndex]
        )
        {
            /*
                Imagine this:
                pos = (
                    0 +
                    (10 - 0) /
                    (10 - 0) *
                    (6 - 0)
                ) = 10 % (10 - 0) * (6 - 0)
                = 6

                Therefore because of the uniformly distributed values
                we are better able to "guess" the "middle" point and be
                "right' quicker!
            */
            pos = (
                lowIndex +
                (
                    // The next section.
                    (highIndex - lowIndex) /
                    // Divided by values at the low and high end.
                    (arr[highIndex] - arr[lowIndex]) *
                    // Multiplied by value at low index.
                    (value - arr[lowIndex])
                )
            );

            if (arr[pos] == value) return pos;
            if (arr[pos] < value) return Search(arr, pos + 1, highIndex, value);
            if (arr[pos] > value) return Search(arr, lowIndex, pos - 1, value);
        }

        return -1;
    }
}