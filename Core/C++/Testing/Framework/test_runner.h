#include <iostream>
#include <string>

using namespace std;

class TestRunner
{
    public:
        TestRunner();
        int get_failed_tests();
        void test_func(int (* test_func)(), string name = "Anonymous");
        void print_results();

    private:
        int total_tests = 0;
        int tests_failed = 0;
};
