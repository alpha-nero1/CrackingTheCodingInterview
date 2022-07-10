using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Core.Searching;
using Core.Sorting;
using Core.DataStructures;
using System.Linq;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            TestHashTable();

            int[] arr = new int[] { 1, 5, 7, 2, 9, 10, 2 };
            Console.WriteLine($"Insertion sorting {JsonSerializer.Serialize(arr)}...");
            arr = InsertionSort.Sort(
                arr, 
                0, 
                arr.Length - 1,
                new Func<int, int, bool>((int a, int b) => b < a)
            );
            Console.WriteLine($"Insertion sorted: {JsonSerializer.Serialize(arr)}");
            int[] nextArr = new int[] { 1, 5, 7, 2, 9, 10, 2 };
            Console.WriteLine($"Merge sorting {JsonSerializer.Serialize(nextArr)}...");
            arr = MergeSort.Sort(
                nextArr,
                new Func<int, int, bool>((int a, int b) => b < a)
            );
            Console.WriteLine($"Merge sorted: {JsonSerializer.Serialize(nextArr)}");
            Console.WriteLine("Trying a circular array of 4 positions");
            var circArr = new int[100];
            for (int i = 0; i < 100; i++)
            {
                circArr[i] = i;
            }
            Console.WriteLine($"End result: {JsonSerializer.Serialize(circArr)}");
        }

        static void TestHashTable()
        {
            HashTable<int> ht = new HashTable<int>(new List<KeyValuePair<string, int>> {
                new("hello", 98), 
                new("heyaas", 91 )
            });
            Console.WriteLine("Key count {0}", ht.Keys().Count());

            Console.WriteLine("Hashtable");
            Console.WriteLine(ht.Get("hello"));
            ht.Remove("heyaas");
            ht.Set("hell", 12);
            ht.Set("booo", 99);

            // Key accessor syntax.
            ht["Nicklaus"] = 21;

            Console.WriteLine(ht.Get("hell"));
            Console.WriteLine($"has heyaas: {ht.Has("heyaas")}");
            Console.WriteLine(ht);
        }
    }
}
