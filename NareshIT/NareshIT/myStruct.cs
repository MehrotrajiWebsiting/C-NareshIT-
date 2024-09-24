using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    /*
        1) Class is a REFERENCE type ( Memory allocated on the Managed HEAP )
           but STRUCTURE is VALUE type ( Memory allocated on the STACK memory )

        2) Memory allocation for instances of class performed on the Managed HEAP whereas
           Memory allocation for instance of structure is performed on the STACK

        3) Classes used for representing ENTITY with LARGER VOLUMES OF DATA whereas
           Strcutures used for representing ENTITY with SMALLER VOLUMES OF DATA

        4) Pre-defined data types under libraries which come under reference type category
           like String and Object are CLASSES whereas
           Pre-defined data types under libraries which come under value type category
           like int(Int32), float(Single), bool(Boolean) are STRUCTURES

        5) For class 'new' keyword is MANDATORY to create instance whereas
           For structure 'new' keyword is OPTIONAL to create instance

        6) Fields of class can be initialized at time of declaration whereas
           it's NOT POSSIBLE with FIELDS of structure

        7) In case of fields in structure either 
            a) initialize it using obj.i=value; in main OR
            b) Intantiate using NEW keyword to call constructor
         
        8) In structure, ONLY PARAMETRISED CONSTRUCTORS can be defined EXPLICITLY
           as parameter less are always IMPLICIT in Structures

        9) NO INHERITANCE in structures
        
       10) Structures CAN IMPLEMENT interface
    */
    struct myStruct
    {
        int i;
        //ONLY PARAMETERISED constructor ALLOWED
        myStruct(int i) 
        { 
            this.i = i; 
        }
        public void display()
        {
            Console.WriteLine("Its a structure");
        }
        public static void Main()
        {
            //new is OPTIONAL
            myStruct m1;
            //without this it gives error
            m1.i = 4;
            m1.display();

            //no need to initialize i as constructor is called
            myStruct m2= new myStruct();
            m2.display();
        }
    }
}
