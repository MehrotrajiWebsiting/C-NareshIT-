using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    class Variables
    {
        /*
            There are 4 types of variables - 
            1) Static - Explicitly declared using static modifier 
                        or by declaring variable in Static Block
                    a) static int x;
                        or
                    b) static someFunctionOrMain(){
                            int x; // static variable
                        }
                    Memory for x is allocated AS SOON AS class Execution 
                    starts
                    CAN BE ACCESSED DIRECTLY WITHOUT OBJECT
                    Initialized ONLY ONCE in lifecycle of class
                    
            2) Non-static / Instance - 
                    int x;
                    Memory for x is allocated ONLY when class is
                    INSTANTIATED. So x can be accessed only by OBJECT 
                    of the class.
                    INITIALIZED n times where n is number of instances

            3) Constant - Declared using keyword const
                          CANNOT BE MODIFIED after declaration
                          MUST BE INITIALIZED at time of declaration ONLY
                    const int x = 123;
                    BEHAVIOUR same as STATIC VARIABLE ( eg - 
                    Initialized ONLY ONCE in lifecycle of class ,i.e. ONLY
                    ONE COPY EXISTS and 
                    Memory for x is allocated ONLY when class is
                    INSTANTIATED. So x can be accessed only by OBJECT 
                    of the class. )
                    THE ONLY DIFFERENCE BETWEEN STATIC AND CONSTANT - 
                    static - can be modified
                    constant - cannot be modified after declaration

            4) ReadOnly - Declared by using readonly keyword
                          Like CONSTANT they also CANNOT BE MODIFIED
                          BUT after INITIALIZATION ,i.e., they CAN BE 
                          INITIALIZED AFTER Declaration
                    readonly int x;
                    public abcClass(int i){
                        x=i;
                    }
                    BEHAVIOUR same as NON-STATIC VARIABLE (eg -
                    Memory for x is allocated ONLY when class is
                    INSTANTIATED. So x can be accessed only by OBJECT 
                    of the class.
                    INITIALIZED n times where n is number of instances )
                    THE ONLY DIFFERENCE BETWEEN NON-STATIC AND READONLY - 
                    non-static/instance - can be modified
                    readonly - cannot be modified after initialization

        CONSTANT variable is a fixed value for WHOLE CLASS
        READONLY variable is a fixed value specific to an INSTANCE of a 
            CLASS
        */
    }
}
