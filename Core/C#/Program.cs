using System;

namespace C_
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
        }
    }
}
