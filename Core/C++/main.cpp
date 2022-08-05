#include "./Searching/linear-search.cpp"
#include <iostream>

using namespace std;

int main()
{
    int arr[10] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int arrIndex = linearSearch(2, arr, 10);
    cout << "Found index = " << arrIndex;

    return 0;
}