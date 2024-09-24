using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    class OperatorOverloading
    {
        /*
            Operator Overloading is used to define MULTIPLE behaviours
            to an operator on the basis of OPERAND TYPES between which 
            operator is used

            operator method is used for operator overloading                
        */
        int x;
        public OperatorOverloading(int x)
        {
            this.x = x;
        }
        //operands must be of container types
        //it was not working for int a,int b
        public static OperatorOverloading operator+(OperatorOverloading a,
               OperatorOverloading b)
        {
            OperatorOverloading c = new OperatorOverloading(a.x + b.x);
            return c;
        }
        //override is important to make it work
        public override string ToString()
        {
            return $"{x}";
        }
        public static void Main(String[] args)
        {
            OperatorOverloading a = new OperatorOverloading(1);
            OperatorOverloading b = new OperatorOverloading(2);
            Console.WriteLine((a+b).x);
            Console.WriteLine(a + b);
        }
    }
}
