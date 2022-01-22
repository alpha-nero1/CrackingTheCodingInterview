using System;

namespace Core
{
    public class InsertionSort
    {
        /// <summary>
        /// Perform an insertion sort on an array of type T. provides flexibility
        /// of letting you use any sort func.
        /// </summary>
        /// <param name="arr">Array to be sorted</param>
        /// <param name="start">Start index</param>
        /// <param name="end">End index to sort</param>
        /// <param name="sortFunc">Sort function, returning true will bubble a past b</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] Sort<T>(T[] arr, int start, int end, Func<T, T, bool> sortFunc = null)
        {
            for (int i = start + 1; i < end + 1; i++)
            {
                // Loop the range given for the insertion sort...
                int j = i;
                var a = arr[j - 1];
                var b = arr[j];
                // For each i do a sort pass...
                while (j > start && sortFunc(a, b))
                {
                    // Swap two places in the array.
                    T temp = arr[j - 1];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                    j -= 1;
                }
            }
            return arr;
        }
    }
}