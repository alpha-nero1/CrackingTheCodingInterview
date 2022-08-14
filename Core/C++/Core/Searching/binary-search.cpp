/*
    Performs a simple binary search on an array of integers.
*/

int binary_search(int arr[], int value, int length)
{
    return binary_search_inner(arr, value, 0, length - 1);
}

int binary_search_inner(int arr[], int value, int left, int right)
{
    if (left > right) return -1;
    int middle = (right - left) / 2;
    if (arr[middle] == value) return middle;
    if (arr[left] == value) return left;
    if (arr[right] == value) return right;

    if (value < middle) return binary_search_inner(arr, value, left, middle - 1);
    return binary_search_inner(arr, value, middle + 1, right);
}