using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NareshIT
{
    class MultiThreading
    {
        //Thread is lighweight process used to run code in application
        //Every application by default has 1 Thread which is the Main Thread

        /*
            Context Switching - Operating System switching between threads for time sharing
            i.e, before one thread completes execution OS switches to second thread and vice versa
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
        public static void Main(String[] args)
        {
            Thread myThread=Thread.CurrentThread;
            myThread.Name = "Main Thread";
            Console.WriteLine(Thread.CurrentThread.Name);

            /*
                The method inside Thread() must be VOID with
                NO Parameters because it is a 
                ThreadStart delegate which is public delegate void ThreadStart();
                so signatures (return type + Parameters) MUST match
            */
            //delegate instance imlicitly created by CLR
            Thread t1 = new Thread(Test1);

            //Calling Non-static methods
            MultiThreading ob=new MultiThreading();
            Thread t2 = new Thread(ob.Test2);

            t1.Start();
            t2.Start();

            //explicitly creating instance of ThreadStart delegate
            /*Instantiation of delegate is process of binding a 
             *  method with the delegate
            */
            //ThreadStart obj=Test3;
            //ThreadStart obj= delegate(){Test3();}; //Anonymous methods (No name)
            //ThreadStart obj= () => Test3(); //Lambda operator
            ThreadStart obj =new ThreadStart(Test3);
            Thread t3 = new Thread(obj);
            t3.Start();
            
            //t3 executed with a Higher priority (more CPU resources consumed)
            t3.Priority = ThreadPriority.Highest;

            Thread t4=new Thread(() => Test4(8));
            t4.Start();

            ParameterizedThreadStart obj2= new ParameterizedThreadStart(Test5);
            Thread t5=new Thread(obj2);
            t5.Start(20);

            /*
                LOCKING MECHANISM - The code is LOCKED i.e., ONLY ONE THREAD CAN EXECUTE THE
                            CODE AT A TIME ,ie, FIRST THREAD EXECUTES CODE COMPLETELY 
                            THEN ONLY SECOND THREAD STARTS EXECUTING IT ( THREADS EXECUTING
                            ANOTHER CODE WILL NOT STOP ) and so on
                    //use this only in non-static method
                    lock(this){
                        code
                    }   
            */
            Thread t6=new Thread(ob.Test6);
            t6.Start();
            Thread t7=new Thread(ob.Test6);
            t7.Start();

            Console.WriteLine("THIS STATEMENT CAN EXECUTE AT ANYTIME AS NO JOIN YET");
            /*
                The calling thread (thread which executes these) (here MainThread)
                CANNOT EXIT from program
                UNTIL all these threads finish their JOB
            */
            t1.Join();t2.Join();t3.Join();t4.Join();
            /*
                IF t5 does not exit WITHIN 3s THEN MainThread will EXIT 
            */
            t5.Join(3000);
            Console.WriteLine("NOW THIS STATEMENT WILL EXECUTE ONLY WHEN ALL THREADS ARE FINISHED");
            Console.WriteLine("Main Thread exiting");
        }
        static void Test1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("test 1 " + i);
                if (i == 5)
                {
                    Console.WriteLine("Test1 Sleeps");
                    Thread.Sleep(2000);
                    Console.WriteLine("Test1 AWAKE");
                }
            }

            Console.WriteLine("Thread 1 exiting");
        }
        void Test2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("test 2 " + i);
                if (i == 5)
                {
                    Console.WriteLine("Test2 Sleeps");
                    Thread.Sleep(2000);
                    Console.WriteLine("Test2 AWAKE");
                }
            }
            Console.WriteLine("Thread 2 exiting");
        }
        static void Test3()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("test 3 " + i);
                if (i == 5)
                {
                    Console.WriteLine("Test3 Sleeps");
                    Thread.Sleep(2000);
                    Console.WriteLine("Test3 AWAKE");
                }
            }
            Console.WriteLine("Thread 3 exiting");
        }
        static void Test4(int max)
        {
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine("test 4 " + i);
                if (i == 5)
                {
                    Console.WriteLine("Test4 Sleeps");
                    Thread.Sleep(2000);
                    Console.WriteLine("Test4 AWAKE");
                }
            }
            Console.WriteLine("Thread 4 exiting");
        }
        //ONLY object can pe passed as parameter for ParameterizedThreadStart
        static void Test5(object num)
        {
            int max=Convert.ToInt32(num);
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine("test 5 " + i);
                if (i == 5)
                {
                    Console.WriteLine("Test5 Sleeps");
                    Thread.Sleep(10000);
                    Console.WriteLine("Test5 AWAKE");
                }
            }
            Console.WriteLine("Thread 5 exiting");
        }
        void Test6()
        {
            //use this only in NON-STATIC methods
            lock (this)
            {
                /*
                    TWO THREADS CANNOT EXECUTE THIS CODE AT SAME TIME 
                */
                Console.Write("[C# is an ");
                Thread.Sleep(2000);
                Console.WriteLine("OOP Language]");
            }
        }
    }
}
