# C++

## Installation
Best g++ installation instructions: https://www.freecodecamp.org/news/how-to-install-c-and-cpp-compiler-on-windows/

## Run the program
To compile your program: `g++ -o <output_name> <filename>.cpp`.
To run your code you can invoke by just specifying the output name e.g. `./program`

## Notes on C++
### Arrays
- "When you pass an array to a function, it decays into a pointer to the first element, at which point knowledge of its size is lost."
\
Array definition:
```
// Note that [10] goes on the variable name not the data type.
int arr[10] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
```