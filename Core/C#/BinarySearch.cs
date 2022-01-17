namespace C_
{
    public class BinarySearch
    {
        // Binary search, keep halving the array untill we find
        // that x is a middle point.
        // runtime = N(log n)
        public static int Search(int[] arr, int left, int right, int x)
        {
            if (right > left)
            {
                // We know we are searching normally.
                int middle = left + (r - 1) / 2;
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
}