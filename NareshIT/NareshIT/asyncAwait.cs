using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    /*
        Async Await is used for asynchronus programming 

        async methods must have Task (or Task<datatype of return value>) 
        as return type
        
        async - Create a separate state machine
        Task - Bridge between state machine that async creates and your code
        await - Checkpoints within state machine (how many parts in state machine
                or how many times it will be called)
        
        async - Make method asynchronous
        await - Wait for completion (Stops execution until completed) 
                IF NOT COMPLETED
        
        Methods calling async methods must also use async and await otherwise 
        they WILL NOT wait for asynchronous operation to complete
    */
    class asyncAwait
    {
        //Task<string> - Returns string value
        //Task - Does not return anything (equivalent to void)
        public static async Task<string> MakeTeaAsync()
        {
            Console.WriteLine("Let's Begin");
            var boilingWater = BoilWaterAsync();

            //These will execute when BoilWaterAsync() is on Task.Delay(2000)
            Console.WriteLine("Take the cups out");
            Console.WriteLine("Put tea in cups");

            /*
                IF BEFORE REACHING await boilingWater the boilingWater is ready
                i.e, Delay is finished then a SEPERATE THREAD will execute it 
                while the current thread executes this code (before reaching await)
            */


            //Wait for BoilWaterAsync() to finish IF NOT FINISHED YET
            await boilingWater;

            Console.WriteLine("Pour water in cups");

            return "Tea Ready";
        }
        public static async Task BoilWaterAsync()
        {
            Console.WriteLine("Waiting for the kettle");

            //BoilWaterAsync() is waiting for 2s
            await Task.Delay(2000);

            Console.WriteLine("Kettle finished boiling");
        }
        //if await is NOT used before MakeTeaAsync() in Main,
        //Main will exit at Task.Delay(2000) - i.e, Execution continues without waiting
        //Last output will be Put tea in Cups
        static async Task Main()
        {
            //MakeTeaAsync();

            //wait for MakeTeaAsync() to finish
            Console.WriteLine(await MakeTeaAsync());
        }
    }
}
