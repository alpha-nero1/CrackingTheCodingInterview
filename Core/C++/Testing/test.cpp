#include "./searching.cpp"
#include "./Framework/test_runner.h"

// Entry testing function.
int main()
{
    TestRunner runner;
    // Search tests...
    runner.test_func(test_linear_search);
    runner.test_func(test_binary_search);
    runner.print_results();

    return runner.get_failed_tests();
}