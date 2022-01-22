using System.Collections;
using System.ComponentModel;
using System;
using System.Text.Json;

namespace Core
{
    public class MergeSort
    {
        public static T[] Sort<T>(T[] arr, Func<T, T, bool> sortFunc)
        {
            // We can't do any further splits if array only has 1 element in it...
            if (arr.Length < 2) return arr;
            // Find the array middle to split on, this is an int value so it will round down.
            var arrayMiddle = arr.Length / 2;
            // Copy the left part into a new array and same for the right.
            var leftArr = new T[arrayMiddle];
            // The lenght of the right side might need to be 1 bigger in case the division was on an odd num.
            var rightLength = arr.Length % 2 == 0 ? arrayMiddle : arrayMiddle + 1;
            var rightArr = new T[rightLength];
            // Didn't use our SubArray extensions just for practice.
            Array.Copy(arr, 0, leftArr, 0, arrayMiddle);
            Array.Copy(arr, arrayMiddle, rightArr, 0, rightLength);

            // Call on left and right arrays.
            Sort(leftArr, sortFunc);
            Sort(rightArr, sortFunc);

            int leftIndex = 0;
            int rightIndex = 0;
            // K is always the cursor of the current array sent in
            // this is why it is allowed to always be 0 and not some mid-point.
            int k = 0;

            // While we haven't run out of left and right cursors...
            while (leftIndex < leftArr.Length && rightIndex < rightArr.Length)
            {
                // If the sort func passes for a, b.
                if (!sortFunc(leftArr[leftIndex], rightArr[rightIndex]))
                {
                    // Load left element.
                    arr[k] = leftArr[leftIndex];
                    leftIndex += 1;
                }
                else
                {
                    // Load right element.
                    arr[k] = rightArr[rightIndex];
                    rightIndex += 1;
                }
                // Increase array cursor.
                k += 1;
            }

            // Check if any elements were left over...
            while (leftIndex < leftArr.Length)
            {
                arr[k] = leftArr[leftIndex];
                leftIndex += 1;
                k += 1;
            }

            while (rightIndex < rightArr.Length)
            {
                arr[k] = rightArr[rightIndex];
                rightIndex += 1;
                k += 1;
            }

            return arr;
        }
    }
}