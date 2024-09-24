/*
 * SOLUTION (root element) - Contains multiple projects
 * Project - Contains multiple items (classes , enums, interface, delegates....)
 * namespace - The namespace keyword is used to declare a scope 
                that contains a set of related objects.
*/


//importing namespace System 
//to use the classes, enum, interface, other namespaces ....
//present in it
using System;

/*
    namespace is a logical container
    used for grouping related objects like - classes, interface, 
    structures, enums, delegates, other namespaces, etc     
*/
namespace NareshIT
{
    class Program
    {
        //CONSTRUCTOR CHAINING
        int i;
        String n;

        Program(int i, String n)
        {
            this.i = i;
            this.n = n;
        }
        Program(int i) : this(i, "")
        {

        }
        Program(String n) : this(0, n)
        {

        }
        Program() : this(0, "")
        {

        }

        //ALTERNATIVE - OPTIONAL ARGUMENTS (in .NET 4 and more)
        //Program(int i=0,String n = "")
        //{
        //    this.i= i;
        //    this.n= n;
        //}

        //Main (capital M (proper case)) function required
        //so that class appears in startup object
        static void Main(string[] args)
        {
            //null-coalescing operator ??
            //The null - coalescing operators are right - associative.

            //without ? you cannot store null
            int? b= null;
            int? a = b??4; // a=4 as b is null

            //??= assigns the value of its right-hand operand to its left-hand operand
            //only if the left-hand operand evaluates to null
            b ??= 7;//if b is null store 7
            b??= 8;//since b is NOT null so b will remain 7

            Console.WriteLine(a+" "+b);//4 7
            int? c= null;
            int? d = 4;
            Console.WriteLine(b ?? d ?? c); //7 (b=7)
            //b ?? 4 ?? c GIVES ERROR as we CANNOT WRITE NON-NULL CONSTANT/VARIABLE (normal int d)
            //BEFORE EXPECTED NULL (int? d) variable,i.e, 4 cannot be written before c

            Program obj1= new Program();
            Program obj2= new Program(1);

            //IN CASE OF OPTIONAL ARGUMENTS, YOU NEED TO SPECIFY VARIABLE NAME FOR SECOND OR MORE ARGUMNETS
            //Program obj3 = new Program(n:"Om");

            Program obj3= new Program("Om");
            Program obj4= new Program(2,"Mehrotra");

            Console.WriteLine(obj1.i + " " + obj1.n);
            Console.WriteLine(obj2.i + " " + obj2.n);
            Console.WriteLine(obj3.i + " " + obj3.n);
            Console.WriteLine(obj4.i + " " + obj4.n);

            Console.WriteLine("Hello World!");
        }

        /*
            Method Overloading is caused in 3 cases - 
                Type of input changes
                Number of input changes
                Order of input changes

            IT DOES NOT DEPEND ON RETURN TYPE

            Method overloading can occur in same class as well as
            Parent child classes
            Method overriding occurs ONLY in Parent child classes
            
            Method overriding is used to change behaviour while overloading is
            used to define multiple behaviours.

            For Method overriding Child class reuquires PERMISSION from
            Parent class.
            Parent class needs to declare methods as VIRTUAL to give permission
            to the child class to override them

            Method hiding/shadowing same as method overriding but Child class
            can ALSO implement NON-VIRTUAL methods of Parent class.
            Use new in place of override in Child class.
            public new void methodname(){
                //This method is written in CHILD CLASS
            }
            WITHOUT new IT STILL WORKS SAME but only a WARNING is given by
            compiler

            If PARENT class REFERENCE created using CHILD class INSTANCE calls
                -OVERRIDDEN method, It calls CHILD CLASS METHOD
                -BUT for HIDDEN/SHADOWED method, It calls PARENT CLASS METHOD
              because Overriden methods are NOT PURELY DEFINED in
              child class
         */
    }
}