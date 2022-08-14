#include <iostream>
#include "test_runner.h"
#include "../../Core/Utility/colours/colours.h"

using namespace std;

// Implement the constructor.
TestRunner::TestRunner()
{

}

// Implementation for TestRunner class in header file.
// Note the <ret type> <class>::<func_name> syntax!
int TestRunner::get_failed_tests()
{
    return tests_failed;
}

void TestRunner::test_func(int (* test_func)())
{
    cout << "Running " << test_func;
    int res = test_func();
    if (res > 0) tests_failed += 1;
    total_tests += 1;
}

void TestRunner::print_results()
{
    cout << cyan("##### TEST RESULTS #####");
    int tests_passed = total_tests - tests_failed;
    float score = (tests_passed / total_tests) * 100;
    cout << "\nResults: (" << tests_passed << "/" << total_tests << "), Score =" + to_string(score);

    if (tests_failed > 0)
    {
        cout << red("\nFAILURE");
        return;
    }
    cout << green("\nSUCCESS:");
    cout << " All tests passed!";
}
