int linear_search_int(int value, int arr[], int length);

// Generic version of linear search.
// typename denotes that the value generic has this name
// but can be any instance type.
// Templates MUST be defined in header files...
template <typename TValue>
int linear_search(TValue value, TValue arr[], int length)
{
    for (int i = 0; i < length; i += 1)
    {
        if (arr[i] == value) return i;
    }

    return -1;
}