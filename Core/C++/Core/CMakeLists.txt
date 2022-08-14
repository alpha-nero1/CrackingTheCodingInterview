# CMakeLists file for the main Core/ project.
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

cmake_minimum_required(VERSION 3.10)

include_directories(${PROJECT_SOURCE_DIR})

# set the project name
project(Core VERSION 1.0)

# add the executable
# All files are added here...
add_executable(
    Core
    ./main.cpp
    ./Utility/colours/colours.cpp
    ./Utility/colours/colours.h
)