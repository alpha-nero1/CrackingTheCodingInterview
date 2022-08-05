using System;
using Core.DataStructures.HashTable;

namespace Core.Experiments;

public static class GetHashCodeExperiment
{
    public static void Experiment()
    {
        int a = 0;
        int b = 1;
        HashTable<string> c = new HashTable<string>();
        HashTable<string> d = c;
        HashTable<string> e = new HashTable<string>();
        HashTable<string> f = new HashTable<string>();
        string g = "Hello partner!";
        string h = g;
        string i = "hello!";

        Console.WriteLine(a.GetHashCode());
        Console.WriteLine(b.GetHashCode());
        Console.WriteLine(c.GetHashCode());
        Console.WriteLine(d.GetHashCode());
        Console.WriteLine(e.GetHashCode());
        Console.WriteLine(f.GetHashCode());
        Console.WriteLine(g.GetHashCode());
        Console.WriteLine(h.GetHashCode());
        Console.WriteLine(i.GetHashCode());

        // Hashtable has 1000 available array positions internally.
        var hashTableInnerSize = 1000;

        var hashIndexC = (c.GetHashCode() * 17) % hashTableInnerSize;
        var hashIndexD = (d.GetHashCode() * 17) % hashTableInnerSize;
        var hashIndexE = (e.GetHashCode() * 17) % hashTableInnerSize;
        var hashIndexF = (f.GetHashCode() * 17) % hashTableInnerSize;

        Console.WriteLine(hashIndexC);
        Console.WriteLine(hashIndexD);
        Console.WriteLine(hashIndexE);
        Console.WriteLine(hashIndexF);
    }

}
