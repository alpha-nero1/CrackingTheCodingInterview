using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable(new object[,] {{ "hello", 98 }, { "heyaas", "LGHJ678" }});
            Console.WriteLine("Hashtable");
            Console.WriteLine(ht.get("hello"));
            ht.remove("heyaas");
            ht.set("hell", "llk7899");
            Console.WriteLine(ht.get("hell"));
            Console.WriteLine($"has heyaas: {ht.has("heyaas")}");
            Console.WriteLine(ht);

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
            var circArr = new int[] { 0, 0, 0, 0 };
            for (int i = 0; i < 100; i++)
            {
                circArr.Append(i, i);
            }
            Console.WriteLine($"End result: {JsonSerializer.Serialize(circArr)}");
        }
    }
}
