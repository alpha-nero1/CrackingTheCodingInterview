# C++

## Installation
Best g++ installation instructions: https://www.freecodecamp.org/news/how-to-install-c-and-cpp-compiler-on-windows/

## Run a simple c++ program
To compile your program: `g++ -o <output_name> <filename>.cpp`.
To run your code you can invoke by just specifying the output name e.g. `./program`

## Running the Core and Testing projects.
Within this directory there are two primary folders, `Core/` and `Testing/`
\
As you might imagine `Core/` contains core implementations and `Testing/` contains
the actual code to test the core code, you would be correct!
\
Each project was created by following these instructions (after a healthy amount of trial and error of course):
1. Create the directory (e.g. `Core/`)
2. Add code (cpp and header files)
3. Add a `CMakeLists.txt` file, adding all sources to the project via the `add_executable` configuration. (E.g. `Core/CMakeLists.txt`)
4. Create a `Build/` directory where we will contain all the cmake generated files as to not clutter the project. (E.g. `Core/Build/`)
5. Checkout the `Build/` directory and bootstrap the cmake project running `cmake ../` this will create or replace a cmake project in the current build dir, based of implementations in the parent folder.
6. Once the cmake project creation has been done run `cmake --build .` to build the artifacts that were created, this will product your `.exe` file that you shoud now see under `/Build/bin/Debug`
7. Run the executable.
\
To assist in this procedure I have included a `build.bat` and `run.bat` file in both projects
to make building and running the projects easier than ever.

## Testing
To test the c++ implementations in the `/Core` folder, I have opted to use a simple local testing framework that I wrote myself and have full controll over. This code lives under `/Testing/Framework` where you can get access to the `TestRunner` class and simple assertion functions.
\
See `Testing/test.cpp` to see how the `TestRunner` is set up and `Testing/searching.cpp` to see how
tests should be defined.

~ Happy C++ Devving ;)

## Notes on C++
### Arrays
- "When you pass an array to a function, it decays into a pointer to the first element, at which point knowledge of its size is lost."
\
Array definition:
```
// Note that [10] goes on the variable name not the data type.
int arr[10] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
```