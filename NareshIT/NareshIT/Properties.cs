using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    /*
        Property - It is a member of the class using which we can expose values (private values)
                   associated with a class to the outside environment. 

        <modifiers> <type> <Name>{
            get { } // Get Accessor
            set { } // Set Accessor
        }
        
        CONVENTION - ( ONLY WHEN YOU WANT TO DEFINE PROPERTY ON A VARIABLE )
            Field    -  _Name
            Property -  Name

        You can control GET / SET accessors through Properties

        YOU CAN ALLOW CONDITIONAL GET using PROPERTIES -
            E.g.- Return BALANCE as 0 when AccountStatus is false (INACTIVE)
        
        YOU CAN ALLOW CONDITIONAL SET using PROPERTIES -
            E.g- Set BALANCE only when AccountStatus is true (ACTIVE)

        UPDATE BALANCE ONLY IF IT DOES NOT GO BELOW 500
           public double Balance{
                set{
                    if( value >= 500 )
                        this._Balance = value;
                }
           }
            NOW if
                obj.Balance = 1600;
                obj.Balance -= 1600; 
                Balance will NOT change as value will be 
                    obj.Balance - 1600 = 1600 - 1600 = 0 < 500
            Thus it will NOT CHANGE

        ALLOW USER TO CHOSE ONLY FROM A SET OF VALUES BY SHOWING HIM THOSE VALUES (CREATING ENUM)
        E.g. - User should only 4 cities - Delhi,Mumbai,Gurgaon,Lucknow
        - CREATE ENUM
          enum Cities{
            Delhi, Mumbai, Gurgaon, Lucknow
          }
        - CREATE PROPERTY USING enum
          Cities _City = Cities.Lucknow;
          public Cities City{
            get { return _City; }
            set { _City = value; }
          }
          //NO NEED OF CUSTOM CHECKING

        ALLOW ONLY CHILD CLASSES TO CHANGE BALANCE (protected set)
            public double Balance{
              // GET IS STILL PUBLIC
              get { return _Balance; }
              //ONLY CHILD CAN set
              protected set {
                this._Balance = value;
              }
            }

        AUTO-IMPLEMENTED / AUTOMATIC PROPERTY - Property defined WITHOUT any field.
            It MUST have GET accessor.
            CONDITIONAL GET/SET CANNOT BE USED

        AUTO PROPERTY INITIALIZER - ( ONLY FOR AUTO-IMPLEMENTED PROPERTIES )
            public int abc { get; } = 4; 
    */
    public class Circle
    {
        /*
            ANYONE CAN GET OR SET VALUES WHICH ARE PUBLIC 
            SO FIELDS SHOULD NEVER BE PUBLIC OR YOU LOSE CONTROL OVER VALUE
        */
        //Radius is private
        double _Radius = 16.5;

        //BY USING FUNCTIONS
        //ONLY get ACCESS
        public double GetRadius()
        {
            return _Radius;
        }
        //ONLY set ACCESS
        public void setRadius(double value)
        {
            this._Radius = value;
        }

        //BY USING PROPERTY
        //BOTH GET AND SET
        //public double Radius
        //{
        //    get { return _Radius; }
        //    set { _Radius = value; }
        //}

        //ONLY GET - READONLY PROPERTY
        //public double Radius
        //{
        //    get { return this._Radius; }
        //}

        //ONLY SET
        //public double Radius
        //{
        //    set { this._Radius = value; }
        //}

        //CONDITIONAL SET
        public double Radius
        {
            set 
            {
                if (value > this._Radius)
                {
                    this._Radius = value;
                }
            }
        }  
        //public int abc { set; } - THIS IS AUTO-IMPLEMENTED PROPERTY. It MUST have GET accessor
        public int def { get; } //- THIS DOES NOT GIVE ERROR and is set to DEFAULT VALUE - 0

        public int def2 { get; } = 4; // AUTO PROPERTY INITIALIZER

        //STACK OVERFLOW AS IT AUTOMATED PROPERTY SO GET WILL JUST CALL ITSELF EVERYTIME
        //public int ghi { 
        //    get { return ghi; } 
        //    set {
        //        if (value > this.ghi)
        //            ghi = value;
        //    } }
        
        //CHOOSE ONLY FROM PRE-DEFINED (BY PROGRAMMER) SET OF VALUES
        //enum must be public
        public enum Cities
        {
            Lucknow,Delhi,Mumbai,Gurgaon
        }
        Cities _City = Cities.Lucknow;
        public Cities City
        {
            get { return _City; }
            set { _City = value; }
        }

        int _Count = 0;
        public int Count
        {
            get { return _Count; }
            //ONLY CHILD CLASSES CAN NOW CHANGE VALUE
            protected set { _Count = value; }
        }

        //READ-ONLY PROPERTY
        public string Message { get; }
        public Circle (string message)
        {
            this.Message = message;
        }
    }
    internal class Properties
    {
        static void Main(String[] args)
        {
            Circle obj = new Circle("FIRST MESSAGE");

            Console.WriteLine(obj.GetRadius());

            obj.setRadius(24);
            Console.WriteLine(obj.GetRadius());

            //Console.WriteLine(obj.Radius); //error if get is not defined - It lacks get accessor
            //obj.Radius = 12; //error if set is not defined - It is read only

            obj.Radius = 10; /* 
                              * In case of conditional set like set only when value greater than 
                              * previous ( 24 ) 
                              * THE VALUE WILL NOT CHANGE ( 10 < 24 )
                              * BUT NO ERROR IS RAISED                              
                             */
            Console.WriteLine(obj.GetRadius()); // 24 ( THE VALUE DID NOT CHANGE )
            
            Console.WriteLine(obj.def); // 0 
            Console.WriteLine(obj.def2); //4

            //if enum was outside Circle class then Circle was also NOT required
            obj.City = Circle.Cities.Lucknow;

            Console.WriteLine(obj.Count);//0
            //ERROR - Set accessor is inaccessible (it is protected)
            //obj.Count = 4;

            //Error as Message is readonly
            //obj.Message="OM";

            Console.WriteLine(obj.Message);
        }
    }
    class ChildCircle : Circle
    {
        public void changeValue()
        {
            Count = 10; //Child class can Access
        }
        ChildCircle(String message):base(message) {}
    }
}
