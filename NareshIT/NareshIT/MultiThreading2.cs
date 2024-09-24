using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    /*
         Abort() - Terminating thread 
    */

    /*
            Thread Priorities -
                1) Lowest
                2) Below Normal
                3) Normal (default)
                4) Above Normal
                5) Highest
            Thread with Higher priority consume more CPU resources than others
            Thread which has more work to do should be generally given more priority
        */
    class MultiThreading2
    {
        static void Main(String[] args)
        {
            MultiThreading2 obj = new MultiThreading2();
            Thread t1 = new Thread(obj.Test1);
            Thread t2 = new Thread(obj.Test1);

            t1.Start();
            t2.Start();

            //Console.WriteLine("Main Thread going to sleep");
            //Thread.Sleep(10000);
            //Console.WriteLine("Main Thread Woke up");

            //NOT WORKING 
            //t1.Abort();
            //t2.Abort();

            t1.Join();
            t2.Join();

        }
        void Test1()
        {
            lock (this)
            {
                Console.Write("[C# is an");
                Thread.Sleep (5000);
                Console.WriteLine(" OOP LANGAGE]");
            }
        }
        static void Test2()
        {
        }
    }
}
