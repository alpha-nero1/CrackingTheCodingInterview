# CMakeLists file for the main Testing/ project.
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

cmake_minimum_required(VERSION 3.10)

include_directories(${PROJECT_SOURCE_DIR})

# set the project name
project(Testing VERSION 1.0)

# add the executable
# All files are added here...
add_executable(
    Testing
    ./test.cpp
    ./Framework/test_runner.h
    ./Framework/test_runner.cpp
    ./Framework/test.h
    ./Framework/test.cpp
    ../Core/Utility/colours/colours.cpp
    ../Core/Utility/colours/colours.h
    ../Core/Searching/linear-search/linear-search.h
    ../Core/Searching/linear-search/linear-search.cpp
)