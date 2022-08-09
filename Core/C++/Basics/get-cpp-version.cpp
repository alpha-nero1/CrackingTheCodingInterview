#include <iostream>

using namespace std;

// Get's the string representation for the current cpp version
// installed/used.
string getCppVersion()
{
    if (__cplusplus == 201703L) return "C++17";
    if (__cplusplus == 201402L) return "C++14";
    if (__cplusplus == 201103L) return "C++11";
    if (__cplusplus == 199711L) return "C++98";
    return "pre-standard C++";
}
