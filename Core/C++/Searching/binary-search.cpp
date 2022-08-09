/*
    Performs a simple binary search on an array of integers.
*/

int binarySearch(int arr[], int value, int length)
{
    return binarySearchInner(arr, value, 0, length - 1);
}

int binarySearchInner(int arr[], int value, int left, int right)
{
    if (left > right) return -1;
    int middle = (right - left) / 2;
    if (arr[middle] == value) return middle;
    if (arr[left] == value) return left;
    if (arr[right] == value) return right;

    if (value < middle) return binarySearchInner(arr, value, left, middle - 1);
    return binarySearchInner(arr, value, middle + 1, right);
}