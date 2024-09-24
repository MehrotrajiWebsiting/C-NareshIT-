using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NareshIT
{
    internal class ComparableComparater
    {
        static void Main(String[] args)
        {
            Student s1 = new Student { SId = 1, Name = "Om", Class = 12, Marks = 100 };
            Student s2 = new Student { SId = 2, Name = "Rahul", Class = 11, Marks = 75 };
            Student s3 = new Student { SId = 3, Name = "Shyam", Class = 10, Marks = 90 };
            Student s4 = new Student { SId = 4, Name = "Ram", Class = 11, Marks = 85 };
            Student s5 = new Student { SId = 5, Name = "Mohan", Class = 9, Marks = 70 };
            Student s6 = new Student { SId = 6, Name = "Raju", Class = 9, Marks = 80 };

            List<Student> list = new List<Student>() {s1,s2,s3,s4,s5,s6};

            //Sort by CompareTo function in Student class (IComparable)
            list.Sort();
            foreach (Student s in list)
            {
                Console.WriteLine($"{s.SId} {s.Name} {s.Class} {s.Marks}");
            }
            Console.WriteLine();

            //Sort by Compare function in StudenCompare Class (IComparer)
            //Same as implementing Comparator in Java

            //Sort only part of list - (start index, count , IComparer<> object)
            list.Sort(2,4,new StudentCompare());
            foreach (Student s in list)
            {
                Console.WriteLine($"{s.SId} {s.Name} {s.Class} {s.Marks}");
            }
            Console.WriteLine();
            //Sort complete list
            list.Sort(new StudentCompare());
            foreach (Student s in list)
            {
                Console.WriteLine($"{s.SId} {s.Name} {s.Class} {s.Marks}");
            }
            Console.WriteLine();

            //Using Comparison delegate ( int Comparison(Student x,Student y))
            list.Sort((x,y)=>x.Name.CompareTo(y.Name));
            foreach (Student s in list)
            {
                Console.WriteLine($"{s.SId} {s.Name} {s.Class} {s.Marks}");
            }
            Console.WriteLine();

            //implicit instantiation of de
            //legate
            list.Sort(abc);

            //explicit instantiation of delegate
            Comparison<Student> cmp = new Comparison<Student>(abc);
            list.Sort(cmp);

            foreach (Student s in list)
            {
                Console.WriteLine($"{s.SId} {s.Name} {s.Class} {s.Marks}");
            }
            Console.WriteLine();


            /*
                IEnumerable interface is parent of all the Collections
                -IEnumerable
                    -ICollection
                        -IList (Contains List, ArrayList,..)
                        -IDictionary (Contains Dictionary,HashTable,..)
                
                IEnumerable contains IEnumerator GetEnumerator(); method
                which MUST be implemented in EVERY COLLECTION CLASS so that
                foreach loop works.
            */
            School CMS=new School();
            CMS.Add(s1);CMS.Add(s2);CMS.Add(s3);CMS.Add(s4);CMS.Add(s5);CMS.Add(s6);
            
            //GIVES ERROR WITHOUT USING IEnumerable and GetEnumerator()
            foreach (Student s in CMS)
            {
                Console.WriteLine($"{s.SId} {s.Name} {s.Class} {s.Marks}");
            }
        }
        public static int abc(Student x,Student y)
        {
            return y.Name.CompareTo(x.Name);
        }
    }
    class StudentCompare : IComparer<Student>
    {
        public int Compare(Student x,Student y)
        {
            if (x.SId > y.SId) return 1;
            else if(x.SId < y.SId)return -1;
            return 0;

            //return x.SId-y.SId;
        }
    }
    class Student : IComparable<Student>
    {
        public int SId { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public float Marks {  get; set; } 
        public int CompareTo(Student? other)
        {
            //DESCENDING
            //if (other.Marks > this.Marks) return 1;
            //else if(other.Marks < this.Marks) return -1;
            //return 0;

            //SAME AS ABOVE
            return Convert.ToInt32(other.Marks-this.Marks);
        }
    }
    class School : IEnumerable
    {
        List<Student> students=new List<Student>();
        public void Add(Student student)
        {
            students.Add(student);
        }
        //to be used in SchoolEnumerator
        public int Count
        {
            get { return students.Count; }
        }
        //indexer to access elements
        public Student this[int index]
        {
            get
            {
                return students[index];
            }
        }
        public IEnumerator GetEnumerator()
        {
            //Using GetEnumerator of List<>
            //return students.GetEnumerator();

            //USING YOUR LOGIC
            //pass current class
            return new SchoolEnumerator(this);
        }
    }
    class SchoolEnumerator : IEnumerator
    {
        //School collection
        School SchoolColl;
        //Represents the Current index
        int CurrInd;
        //Refers to current student
        Student CurrStudent;
        
        //ACCESS THE COLLECTION THROUGH CONSTRUCTOR
        public SchoolEnumerator(School sc)
        {
            SchoolColl = sc;
            CurrInd = -1; //By default it points to Before First
        }
        /*
            Current is used to access the current record
        */
        public object Current
        {
            get { return CurrStudent; }
        }
        /*
            Moves pointer down the records until Found (returns true) or 
            Reached After Last (returns false) 
                //Pointer points to Before First
                =>Before First
                  Record1
                  Record2
                  After Last
        */
        public bool MoveNext()
        {
            if (++CurrInd >= SchoolColl.Count)
            {
                return false;
            }
            else
            {
                CurrStudent = SchoolColl[CurrInd];
                return true;
            }
        }
        //NOT REQUIRED AS RESET NOT USED IN COLLECTIONS BUT FUNCTION MUST BE MENTIONED
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
