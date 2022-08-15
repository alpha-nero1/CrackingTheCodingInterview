/*
    C and C++ support pointers, which is different from most other programming languages
    such as Java, Python, Ruby, Perl and PHP as they ONLY SUPPORT REFERENCES.
    But interestingly, C++, along with pointers, also supports references.

    C# = only references
    C++ = references + pointers

    From https://www.geeksforgeeks.org/pointers-vs-references-cpp/
*/

// Pointers
// A pointer is a variable that holds the memory address of another variable. A pointer
// must be dereferenced with the "*" operator to access the memory location it points to.

// References
// A reference variable is simply an alias for another variable, a reference like a pointer works
// by storing the memory address of the variable. A reference can be thought of as a constant
// pointer,

int i = 3;

int *ptr = &i;

int &ref = i;

