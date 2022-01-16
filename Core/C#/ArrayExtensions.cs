using System;
namespace C_
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
    }
}