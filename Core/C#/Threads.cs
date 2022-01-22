
// C# program to illustrate the creation
// of thread using static method
using System;
using System.Threading;

namespace Core
{
    public class ExThread {
    
        // Static method for thread a
        public static void thread1()
        {
            for (int z = 0; z < 5; z++) {
                Console.WriteLine(z);
            }
        }
    
        // static method for thread b
        public static void thread2()
        {
            for (int z = 0; z < 5; z++) {
                Console.WriteLine(z);
            }
        }
    }
    
    // public class GFG {
    
    //     // Main method
    //     public static void Main()
    //     {
    //         // Creating and initializing threads
    //         Thread a = new Thread(ExThread.thread1);
    //         Thread b = new Thread(ExThread.thread2);
    //         a.Start();
    //         b.Start();
    //     }
    // }
}
