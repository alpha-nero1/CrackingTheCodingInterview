/*
    Performs a very simple linear search.
*/

using namespace std;

// Perform a linear search of the integer array and return the
// index in which the value was found.
// Returns -1 if not found.
// We need to pass in length because we can not accurately get the size of an array
// outside the scope of it's definition, that is because at this point `int arr[]`
// is transformed to int* arr
int linearSearch(int value, int arr[], int length)
{
    for (int i = 0; i < length; i += 1)
    {
        if (arr[i] == value) return i;
    }

    return -1;
}