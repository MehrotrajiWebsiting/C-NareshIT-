using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    //ENUMS CAN BE DEFINED INSIDE CLASS AND STRUCTURES TOO

    //enums Name : type{
    //
    //}
    enum Days
    {
        Monday,Tuesday, Wednesday,Thursday,Friday,Saturday
    }

    //INDEX NOW STARTS FROM 1
    enum Days2
    {
        Monday=1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
    class Enums 
    {
        static Days MeetingDate = (Days)1;
        static void Main(String[] args)
        {
            //ONLY 0 can be written like this for others use (Days)
            Days d1 = 0;

            Days d2 = (Days)1;

            Console.WriteLine($"{d1} {d2}"); // Monday Tuesday
            Console.WriteLine((Days)10); //10 - out of size so no Name

            Console.WriteLine((Days2)2); //Tuesday

            Console.WriteLine(Days2.Thursday); //Thurdsday
            Console.WriteLine((int)Days2.Thursday); //4

            //returns INTEGERS
            foreach (int i in Enum.GetValues(typeof(Days)))
            {
                Console.Write(i+":" +(Days)i+" ");
            }
            Console.WriteLine();
            //return names
            foreach (String i in Enum.GetNames(typeof(Days)))
            {
                Console.Write(i + " " );
            }
            Console.WriteLine();

            MeetingDate = Days.Monday;

            //ERROR AS Sunday not exist
            //MeetingDate = Days.Sunday;
        }
    }
}
