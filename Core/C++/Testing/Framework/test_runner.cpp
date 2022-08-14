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

void TestRunner::test_func(int (* test_func)(), string name)
{
    cout << "\nRunning " + name + "\n";
    int res = test_func();
    if (res > 0) tests_failed += 1;
    total_tests += 1;
}

void TestRunner::print_results()
{
    cout << cyan("\n##### TEST RESULTS #####");
    float tests_passed = static_cast<float>(total_tests - tests_failed);
    float total = static_cast<float>(total_tests);
    float ratio = tests_passed / total;
    float score = ratio * 100;
    cout << "\nResults: (" << tests_passed << "/" << total_tests << "), Score = " + to_string(score);

    if (tests_failed > 0)
    {
        cout << red("\nFAILURE");
        return;
    }
    cout << green("\nSUCCESS:");
    cout << " All tests passed!";
}
