using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    /*
        Child class can inherit all members of parent class
        EXCEPT PRIVATE MEMBERS
     */
    /*
     1) Parent class CONSTRUCTOR MUST BE ACCESSIBLE to CHILD CLASS
        as whenever Child class instance is created, it implicitly
        CALLS PARENT CLASS CONSTRUCTOR 

        FIRST Parent class constructor is called
        AFTER THAT Child class constructor is called

        This happens as Child class constructor IMPLICITLY calls 
        PARENT class constructor
        i.e. - on instantiation - Control goes to CHILD class constructor
            which sends it to PARENT class constructor
            PARENT class Constructor EXECUTED and control RETURNED to 
            CHILD class constructor
            Then CHILD class constructor is EXECUTED

    2) Parent class cannot access PURE child class members

    3) We can initialize parent class variables by using instance of 
       child class to make it as a reference so that the reference will be
       consuming the memory of the child class instance
       BUT we CANNOT USE THIS PARENT REFERENCE to 
              ACCESS PURE CHILD CLASS MEMBERS

    4) Every class that is defined by us or pre-defined in libraries of 
       the language has a DEFAULT PARENT CLASS i.e. Object CLASS of
       System namespace. 
       If your class is NOT inheriting any other class then on COMPILE TIME
       your class automatically inherits Object class
       If it is inheriting another class then NO NEED to inherit Object class
       as Parent already inherits Object Class.
       4 methods of Object class (available in every class)- 
        a) Equals
        b) GetHashCode
        c) GetType
        d) ToString

    5) Type of inheritance - SAME AS JAVA

    6) For PARAMETERIZED Parent class constructor, Child class constructor 
       will call it EXPLICITLY to pass values by using base keyword

    7) base keyword CANNOT be used in STATIC blocks (line main method)
    */
    class inheritance : Parent, Interface1, Interface3, Interface4
    {
        int j;
        // explicit calling of parent class constructor
        // by using : base( values ) (base refers to parent class)
        // as it is parameterized
        inheritance(int i,int j) : base(i)
        {
            this.j = j;
        }
        //METHOD OVERRIDING
        public override void abc()
        {
            Console.WriteLine("CHILD CALLED");
        }
        //MUST implement the abstract method in parent interface
        //MUST be PUBLIC
        //represents for interface1 and interface3
        public void display()
        {

        }
        //MUST implement the abstract method in grandparent interface
        //MUST be PUBLIC
        public void display2()
        {

        }
        //PUBLIC is NOT allowed in such case
        //refers to Fdisplay of only interface3
        /*
            Class objects CANNOT call this
            You need REFERENCE for Interface3 to call it
        */
        void Interface3.Fdisplay()
        {

        }
        //PUBLIC is NOT allowed in such case
        //refers to Fdisplay of only interface4
        /*
            Class objects CANNOT call this
            You need REFERENCE for Interface4 to call it
        */
        void Interface4.Fdisplay()
        {

        }
        public static void Main(String[] args)
        {
            inheritance obj=new inheritance(1,2);
            Console.WriteLine(obj.i); 
            Console.WriteLine(obj.j);
            obj.abc(); //CHILD CALLED

            // obj2 is a REFERENCE of PARENT Class created by using
            // CHILD Class INSTANCE
            Parent obj2=new inheritance(3,4);
            Console.WriteLine(obj2.i);

            //GIVES ERROR AS j BELONGS TO CHILD
            //Console.WriteLine(obj2.j);
            obj2.abc(); //CHILD CALLED as virtual was written in parent
                        //and override was written in child

            Interface2 i=new inheritance(5,6);
            //only interface2 methods
            i.display2();

            Interface1 j = new inheritance(5, 6);
            //only interface1 AND interface2 methods
            j.display();
            j.display2();
        }
    }
    class Parent
    {
        public int i;
        public Parent(int i) {
            this.i = i;
        }
        public virtual void abc()
        {
            Console.WriteLine("PARENT CALLED");
        }
    }
    //default scope for interface is public
    interface Interface1 : Interface2{ 
        //NO FIELDS/VARIABLES ALLOWED
        void display();
    }
    interface Interface2
    {
        void display2();
    }
    interface Interface3
    {
        void display();
        void Fdisplay();
    }
    interface Interface4
    {
        void Fdisplay();
    }
}
