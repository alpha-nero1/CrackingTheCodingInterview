#include <string>
#include <iostream>
using namespace std;

// Assert if a confition is true, if not, print
// the failure message and return 1, else return 0 (all ok!).
int assert_true(bool condition, string failure_text);

// Assert if a confition is false, if not, print
// the failure message and return 1, else return 0 (all ok!).
int assert_false(bool condition, string failure_text);