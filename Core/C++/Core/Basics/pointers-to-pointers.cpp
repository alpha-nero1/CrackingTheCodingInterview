#include <iostream>
using namespace std;

// This function demonstrates looping a C++ array without even needing the current
// index. Because we can do arithmetic directly on a pointer.
void print_arr(int arr[][8]) {
    cout << "\n\n";
    // While we have a pointer to a
    // * after type defines a pointer (int* my_pointer = 10)
    // * before type will de-reference (int my_val = *my_pointer)
    for (int _ = 0; _ < 8; _++)
    {
        int* inner_array = *arr;

        for (int __ = 0; __ < 8; __++) {
            int val = *inner_array;
            printf("\nval is %d", val);
            inner_array += 1;
        }

        arr += 1;
    }

}

void pointers_to_pointers()
{
    // This defines a 2d matrix like a chess board.
    int arr[8][8];

    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            printf("\neval %d %d %d", i + 1, j + 1, (i + 1) * (j + 1));
            arr[i][j] = (i + 1) * (j + 1);
        }
    }
    // It is also equivalent to int** arr;
    // because if int* translates to a pointer to an array (the start of it)
    // then int** is a pointer to an array of pointers to the first element of an array.
    print_arr(arr);
}