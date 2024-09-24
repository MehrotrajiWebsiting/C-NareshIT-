using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    // used to create multiple instances with same Values
    // it take object of same class as parameter    
    class copyConstructor
    {
        String name;
        int age;
        public copyConstructor(String name,int age) { 
            this.name = name;
            this.age = age;
        }
        public copyConstructor(copyConstructor obj)
        {
            this.name = obj.name;
            this.age = obj.age;
        }
        public void display()
        {
            Console.WriteLine($"Name = {name}\tAge = {age}");
        }
        public static void Main(String[] args)
        {
            copyConstructor obj1=new copyConstructor("Om",21);
            copyConstructor obj2 = new copyConstructor(obj1);

            obj1.display();
            obj2.display();

            obj1.age = 24;
            obj1.display();
            obj2.display();
        }
    }
}
