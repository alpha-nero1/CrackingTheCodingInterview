using System;

namespace Core
{
    public static class CircularArrayExtensions
    {
        public static void Append<T>(this T[] arr, int index, T item)
        {
            if (index < 0) return;
            // E.g. index = 10, arr length = 4, pos inserted = 2
            // E.g. index = 11, arr length = 4, pos inserted = 3
            // E.g. index = 12, arr length = 4, pos inserted = 0
            // E.g. index = 13, arr length = 4, pos inserted = 1 ...
            arr[index % arr.Length] = item;
        }
    }
}