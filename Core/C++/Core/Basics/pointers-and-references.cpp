/*
    C and C++ support pointers, which is different from most other programming languages
    such as Java, Python, Ruby, Perl and PHP as they ONLY SUPPORT REFERENCES.
    But interestingly, C++, along with pointers, also supports references.

    C# = only references
    C++ = references + pointers

    From https://www.geeksforgeeks.org/pointers-vs-references-cpp/
*/

#include <iostream>
using namespace std;

// Pointers
// A pointer is a variable that holds the memory address of another variable. A pointer
// must be dereferenced with the "*" operator to access the memory location it points to.

// References
// A reference variable is simply an alias for another variable, a reference like a pointer works
// by storing the memory address of the variable. A reference can be thought of as a constant
// pointer,

int i = 3;

// A pointer to variable i (stores the address of i)
int *ptr = &i;

// An alias for i.
int &ref = i;

void initialise_pointers() {
    int a = 10;
    // Note *p = a will not work because we need to access the mem location.
    int *p = &a;

    // See that you can set the reference after declaration.
    int *q;
    q = &a;
}

void initialise_references() {
    int a = 10;
    int &p = a;
    // This on the other hand is illegal
    // int &p;
}


// Keep in mind that pointers are symbolic representations of memory addresses. They enable programs
// to create and manipulate dynamic data structures and simulate call by reference.
void experiment_pointers() {
    int var = 10;

    int *pointer = &var;
    // Access the address and set 20 for var.
    *pointer = 20;

    int **pointer_to_pointer = &pointer;

    **pointer_to_pointer = 30;

    // Will print the now changed var.
    cout << "\nvar = " << var;
    // Will print the pointer address.
    cout << "\npointer = " << pointer;
    // Will print the pointer pointer address.
    cout << "\npointer_to_pointer = " << pointer_to_pointer;

    // Will print the value of 30.
    cout << "\npointer value = " << *pointer;
    // Will print the pointer address
    cout << "\npointer_to_pointer value = " << *pointer_to_pointer;
    // Will print the value of the original pointer.
    cout << "\npointer_to_pointer pointer value = " << **pointer_to_pointer;

    // Example runthrough:
    // var = 30
    // pointer = 000000562317F994
    // pointer_to_pointer = 000000562317F9B8
    // pointer value = 30
    // pointer_to_pointer value = 000000562317F994
    // pointer_to_pointer pointer value = 30
}

void experiment_pointers_and_arrays() {
    // An array name contains the first element of the array which acts as a constant pointer
    // meaning the address stored in the array name is immutable.

    int val[3] = { 2, 4, 6 };
    // Because val really is just a pointer to the first value.
    int *ptr = val;

    // Note that cout and printf() are interchangeable.
    cout << "\n";
    printf("Elements of the array are: ");
    printf("%d %d %d", ptr[0], ptr[1], ptr[2]);

    // Pointer expressions and pointer arithmetic.
    // A limited set of operations can be performed on pointers that allow us to
    // move current addresses.
    // ++ or += to increment.
    // -- or -= decrement.
    // p1 - p2 diff between two pointers.

    // NOTE THAT POINTER ARITHMETIC IS MEANINGLESS UNLESS USED ON AN ARRAY.
    // Example:
    int arr_length = 10;
    int values[10] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int* doubled_vals = new int[arr_length];

    // Arrays are simplified into *ptr when passed into funcs anyway.
    int *arr_ptr = values;
    int *ptr_double = doubled_vals;

    for (int i = 0; i < arr_length; i++) {

        int by_deref = *arr_ptr;
        int by_indexing = values[i];

        *ptr_double = by_deref * 2;

        printf("Doubled value is %d", *ptr_double);

        // Move pointer to next.
        arr_ptr++;
        ptr_double++;
    }
}
