using System;

namespace Core.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            // Create a new array, we will copy into this array.
            T[] res = new T[length];
            Array.Copy(
                array, // Original array.
                offset, // Where to start the splice in original.
                res, // Destination array.
                0, // Where to start in destination array.
                length // Count of items to take from original array.
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
    }
}