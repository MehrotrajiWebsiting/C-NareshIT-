using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    /*
        Type of errors - 1)Compile Time Errors - Syntactical Mistakes. Occur on compilation
                         2)Run Time Errors - Occur at time of execution. Due to 
                               a)Wrong Implementation of Logic (like index going out of 
                                    array size)
                               b)Wrong input supplied (wrong type of value passed)
                               c)Missing required resources (Opening missing file)
                               AND MANY MORE
        In case of Runtime error, Program execution stops and REMAINING lines of code are 
        NOT EXECUTED causing abnormal termination.

        Exception - Exception is a class(or classes) responsible for this 
                    abnormal termination of program whenever Runtime error occurs
                    in the program.

        Exception class - 1)It has logic for abnormal termination
                          2)Contains a readonly Property - Message
                            (to display an error message) and is declared as VIRTUAL
                            i.e, IT IS OVERRIDDEN by child CLASSES
                          3)It has 2 child classes -

                            a)ApplicationException - Non-Fatal Errors ( Can be performed
                                BUT we do NOT want to perform it)
                                They are caused by Programmers
                                e.g. - Don't want my application to divide a number 
                                    by odd number ( application specific)

                            b)SystemException - Fatal Errors (Should never be performed
                                System will not allow to perform it)
                                They are caused by CLR.
                                e.g. - Dividing number 0 (universal)
                                Its subclasses are - 
                                    i)IndexOutOfBounds Exception
                                    ii)Format Exception
                                    iii)Arithmetic Exception
                                        -DivideByZero Exception
                                        -Overflow Exception
                                    ETC.....

        Exception Handling - Stopping the abnormal termination of the program
                             whenever Runtime Errors occur in the program.
                             It also helps to display user friendly Error messages to
                             describe about the error.
                             We can perform corrective action to resolve the problems
                             that may come into picture due to the error.
                             E.g.-Rollback transaction in case of failure.

        CUSTOM/APPLICATION EXCEPTION - 1)Create instance of ApplicationException with 
                                           Error Message as parameter
                                          throw objectOfApplicationException
                                          catch using ApplicationException
                                          
                                       2)Defining our own Exception class which
                                         inherits Exception class
                                         Inside the class - 
                                         public override string Message{
                                            get{
                                                return "My message";
                                            }
                                         }
                                         THEN - 
                                         throw objectOfThisClass
                                         catch using name of class

        throws (as in Java) DOES NOT EXIST in C#.
    */
    internal class ExceptionHandling
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter First Number");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Second Number");
                int b = int.Parse(Console.ReadLine());

                //CUSTOM EXCEPTION
                //by ApplicationException
                if (a == b)
                {
                    //in case of a=0 and b=0 
                    //This exception is caught first BECAUSE
                    //This statement comes
                    //BEFORE c=a/b;
                    throw new ApplicationException("BOTH NUMBERS CANNOT BE EQUAL");
                }

                //by creating custom class
                if (b>a)
                {
                    //using Namespace will get e as NareshIT.MyException
                    //throw new NareshIT.MyException();

                    //without namespace it still work same and give same output
                    throw new MyException();
                }
                /*
                ------THIS HAPPENS WHEN THIS STATEMENT IS NOT UNDER TRY-CATCH BLOCK------
                    if b=0, it causes error
                    CLR picks the class associated with error,i.e, DivideByZeroException,
                    and Creates its instance and
                    Throws this object
                    This object thrown by CLR will perform ABNORMAL TERMINATION
                */
                int c = a / b;
                Console.WriteLine("The result is: " + c);
                if (b == 1)
                {
                    //FINALLY WILL STILL EXECUTE BUT THE OUTSIDE CODE WILL NOT
                    return;
                }
            }
            //catch our Custom Application exception
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (MyException e)
            {
                Console.WriteLine(e);
            }
            catch (DivideByZeroException e)
            {
                //predefined Message property
                Console.WriteLine(e.Message); //Attempted to divide by zero.
            }
            catch (FormatException e)
            {
                Console.WriteLine("WRONG DATA TYPE");
            }
            //use this at LAST
            /*
                If this catch block is not there and some 3rd exception occurs
                like OverflowException then it will cause ABNORMAL TERMINATION
                BUT FINALLY STILL EXECUTES
            */
            catch (Exception e)
            {
                Console.WriteLine("Some other exception : "+e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally always executes");
            }
            //THIS IS NOT EXECUTED WHEN PROGRAM CONTROL GOES OUTSIDE THE FUNCTION
            //AS IN CASE OF RETURN STATEMENT OR WHEN
            //SOME EXCEPTION OCCURS WHICH IS NOT MENTIONED IN catch BLOCK
            //BUT FINALLY WILL STILL EXECUTE
            Console.WriteLine("Outside try catch is NOT EXECUTED WHEN " +
                "try calls return statement. \n OR \n" +
                "some exception occurs which is NOT MENTIONED IN catch block" +
                "causing ABNORMAL TERMINATION (finally still executes)");
        }
    }
    //CUSTOM or APPLICATION Exception
    class MyException : Exception
    {
        public override string Message
        {
            get { return "Second number should be small"; }
        }
    }
}
