/*
    Performs a very simple cross-linear search.
*/

using namespace std;

int linearSearch(int value, int arr[], int length)
{
    for (int i = 0; i < length; i += 1)
    {
        int j = length - i;
        if (j < i) return -1;
        if (arr[j] == value) return i;
        if (arr[i] == value) return i;
    }

    return -1;
}