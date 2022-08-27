/*
"Vectors in C++ are sequence containers representing arrays that can change
their size during runtime. They use contiguous storage locations for their
elements just as efficiently as in arrays, which means that their
elements can also be accessed using offsets on regular pointers to
its elements."
*/

#include<vector>
#include<iostream>

using namespace std;

void experiment_vectors()
{
    // This data type is more similar to arrays in other languages
    // that expand or contract given the size of elements inside.
    vector<int> my_arr = { 1, 2, 3, 4, 5 };

    for (int i = 0; i < 5; i++)
    {
        my_arr.push_back(6 + i);
    }

    cout << "Iterating the vector: ";
    for (auto i = my_arr.begin(); i != my_arr.end(); ++i)
        cout << *i << " ";
}