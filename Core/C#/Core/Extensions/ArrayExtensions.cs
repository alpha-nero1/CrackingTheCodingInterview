using System;

namespace Core.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Get a sub array of the greater array. Example use:
        /// array = [0, 1, 2, 3, 4, 5]
        /// SubArray(0, 3) = [0, 1, 2]
        /// </summary>
        /// <param name="array">Array to splice.</param>
        /// <param name="offset">Where in the array to start copying (can thing of cursor sits before)</param>
        /// <param name="length">How many items to take from the offset.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            // Create a new array, we will copy into this array.
            T[] res = new T[length + 1];
            Array.Copy(
                array, // Original array.
                offset, // Where to start the splice in original.
                res, // Destination array.
                0, // Where to start in destination array.
                length + 1 // Count of items to take from original array.
            );
            return res;
        }

        /// <summary>
        /// Get back an exact copy of an array.
        /// </summary>
        public static T[] DirectCopy<T>(this T[] arr)
        {
            T[] res = new T[arr.Length];
            Array.Copy(
                arr,
                0,
                res,
                0,
                arr.Length
            );
            return res;
        }

        /// <summary>
        /// Swap array positions.
        /// </summary>
        public static void Swap<T>(this T[] arr, int i, int j)
        {
            if (i == j) return;
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        /// <summary>
        /// Shift array elements to the left.
        /// </summary>
        public static T[] ShiftLeft<T>(this T[] arr, int positions = 1)
        {
            var copy = new T[arr.Length - positions];
            for (int i = positions; i < arr.Length; i++)
            {
                copy[i - positions] = arr[i];
            }
            return copy;
        }

        /// <summary>
        /// Shift array elements to the right.
        /// </summary>
        public static T[] ShiftRight<T>(this T[] arr, int positions = 1)
        {
            var copy = new T[arr.Length + positions];
            for (int i = 0; i < arr.Length; i++)
            {
                copy[i + positions] = arr[i];
            }
            return copy;
        }
    }
}