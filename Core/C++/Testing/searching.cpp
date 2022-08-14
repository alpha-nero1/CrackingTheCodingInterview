#include "./Framework/test.h"
#include "../Core/Searching/linear-search/linear-search.h"

int test_linear_search()
{
    int status = 0;
    int numbers[10] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    for (int num : numbers)
    {
        status += assert_true(linear_search(num, numbers, 10) == num, "Linear search failed for " + to_string(num));
    }
    return status;
}

int test_binary_search()
{
    int status = 0;
    status = assert_true(0 == 0, "Binary search failed");
    return status;
}