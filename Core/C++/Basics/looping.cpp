#include <iostream>

using namespace std;

// Note because arr[5] is not yet turned into int*
// we can do for (int num : arr), however if we passed
// the array in as a paramater we could not use this syntax.
void foreachLoop()
{ 
    int arr[5];
    for (int num : arr)
    {
        cout << "\n" << num;
    }
}
