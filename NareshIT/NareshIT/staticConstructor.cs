using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    All constructors uptil now were NON-STATIC or instance constructors

    Static constructors are those which are explicitly declared using 
    static keyword.

    An implicit non-static constructor is always created by COMPILER after
    compilation if ONLY static constructors (or no constructors) 
    are declared in class

    Static constructors are also defined IMPLICITLY by compiler ONLY IF
    class contains STATIC FIELDS/VARIABLES

    Non static constructors are defined IMPLICITLY in all classes 
    (except STATIC class) IF NOT DEFINED EXPLICITLY by programmer.

    Static constructors INITIALIZE static variables/fields while 
    non-static constructors initialize non-static variables/fields.

    Static constructors are NEVER called explicitly and are FIRST to
    execute under any class (non static constructors are ALWAYS called 
    EXPLICITLY (on object creation/instantiation)) i.e., it's the first block
    of code to run under a class even if written after the Main method.

    Static constructor is called ONLY ONCE in life cycle of the class whereas 
    Non-static constructors are called each and every time object of class
    is created in the current life cycle (start and end of execution of class).

    Static constructors CANNOT be parameterized (as they are implicitly called
    so we never get chance to pass the value and also they are first executed
    so when we can pass the value?) and thus overloading is also NOT POSSIBLE

    Static members can be accessed DIRECTLY in class 
    Non static member can be accessed ONLY through INSTANCE/object of class
*/
namespace NareshIT
{
    class staticConstructor
    {
        //static constructor
        static staticConstructor() {
            Console.WriteLine("Static constructor called!");
        }
        public static void Main(String[] args)
        {
            Console.WriteLine("This line is printed after " +
                "the one in static constructor even if the constructor is" +
                " defined BELOW/ABOVE the Main function");
        }
    }
}
