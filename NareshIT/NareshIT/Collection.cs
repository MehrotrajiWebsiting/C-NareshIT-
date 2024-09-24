using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    //Collections are Dynamic array
    class Collection
    {
        public static void Main(String[] args)
        {
            //Array.Resize - creates new array, copies values to new array and Destroys old array
            int[] arr = new int[10];
            Array.Resize(ref arr, 15);

            //NON-GENERICS are NOT TYPE SAFE
            //GENERIC Collections are type-safe (like array) and also have
            //      resizing (like non-generic collections)


            //ArrayList - NON GENERIC
            //Initial capacity 10 ( al resizes itself everytime size crosses capacity)
            //ArrayList al = new ArrayList(10);
            ArrayList al= new ArrayList();
            al.Add(1);
            al.Add(2);
            al.Add(3);
            al.Add(4);
            al.Add(5);
            al.Add(6);
            al.Add("om");
            al.Add(1);
            //capacity - 0 4 8 ....
            Console.WriteLine(al.Count + " "  + al.Capacity); //6 8
            //remove value (first occurence)
            al.Remove(1);
            al.Insert(2, 100);
            al.Insert(2, 200);
            //remove at index
            al.RemoveAt(2);

            foreach (object item in al)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine(al[2]);

            //HASHTABLE - NON GENERIC
            Console.WriteLine("HASHTABLE");
            Hashtable ht = new Hashtable();
            //KEY/VALUE CAN BE OF ANY TYPE
            ht.Add("Name", "Om");
            ht.Add("Age",21);
            ht.Add(1, "id");

            Console.WriteLine(ht[1]);
            Console.WriteLine(ht["Name"]);
            //update old value or set new
            ht["age"] = 22;
            ht["Gender"] = "Male";
            ht.Remove("Name");

            //RETURNS EMPTY LINE
            Console.WriteLine(ht["Blank"]);
            //Blank is NOT ADDED TO HashTable as we have not assigned value so it
            //DOES NOT APPEAR IN HashTable
            Console.WriteLine(ht.ContainsKey("Blank")); //False 
            foreach (object key in ht.Keys)
            {
                Console.WriteLine(key + " = " + ht[key]);
            }


            //LIST - GENERIC ARRAYLIST
            List<int> list= new List<int>();
            //same methods as arrayList

            Console.WriteLine("DICTIONARY");
            //DICTIONARY - GENERIC HASHTABLE
            Dictionary<String, int> map = new Dictionary<string, int>();
            //same methods as Hashtable
            map.Add("om", 1);
            map["rahul"] = 2;

            foreach(String key in map.Keys)
            {
                Console.WriteLine($"{key} = {map[key]}");
            }

            Console.WriteLine("SORTED LIST");
            /*
             * SortedList - Sort on basis of Keys and accessed by both KEYS and INDEX
             * It is a sorted list of key/value pairs and provides functionality
             * similar to that found in the non-generic SortedList class.             
            */
            SortedList<String,int> sl= new SortedList<String,int>();
            sl.Add("c", 1);
            sl.Add("a", 2);
            sl.Add("z", 3);
            sl.Add("f", 4);
            foreach (String key in sl.Keys)
            {
                //OUTPUT SORTED ON BASIS OF KEYS
                Console.WriteLine(key + "=" + sl[key]);
            }
            //SORTED on BASIS OF KEYS
            Console.WriteLine("For index 1 " + sl.GetKeyAtIndex(1) + " " + sl.GetValueAtIndex(1));
            //For index 1 c 1

            Console.WriteLine("SORTED DICIONARY");
            /*
             * SortedDictionary - Sort on basis of Keys and accessed ONLY by KEYS
             * It is a sorted list of key/value pairs and provides functionality
             * similar to that found in the non-generic SortedList class. 
             * ONLY GENERIC SortedDictionary exist
            */
            SortedDictionary<String,int> sd=new SortedDictionary<String,int>();
            sd.Add("c", 1);
            sd.Add("a", 2);
            sd.Add("z", 3);
            sd.Add("f", 4);
            foreach (String key in sd.Keys)
            {
                //OUTPUT SORTED ON BASIS OF KEYS
                Console.WriteLine(key + "=" + sd[key]);
            }

            Console.WriteLine("HashSet");
            //HashSet - Same as in Java
            HashSet<String> set = new HashSet<String>();
            set.Add("om");
            set.Add("om");
            set.Add("Rahul");
            foreach (String s in set)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("LinkedList");
            //LinkedList - Same as Java - ONLY GENERIC LINKED LIST USED
            LinkedList<int> l = new LinkedList<int>();
            l.AddLast(1);
            l.AddLast(1);
            l.AddLast(2); 
            l.AddLast(1);
            l.AddLast(1);
            l.AddFirst(2);

            Console.WriteLine(l.Find(1)); //first node that contains 1
            Console.WriteLine(l.FindLast(1));//last node that contains 1

            Console.WriteLine("Length - "+l.Count);

            l.AddAfter(l.Find(1),10);
            l.AddBefore(l.FindLast(1),11);

            foreach (int i in l)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Queue");
            //Queue - Same as in Java
            Queue qq=new Queue(); //NON GENERIC
            Queue<int> q = new Queue<int>(); //GENERIC
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            Console.WriteLine(q.Contains(2));
            Console.WriteLine("Length - "+q.Count);

            Console.WriteLine("Front element - "+q.Dequeue());
            Console.WriteLine("Front element not removed - "+q.Peek());
            foreach (int i in q)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("STACK");
            //STACK - same as in Java
            Stack ss= new Stack(); //NON GENERIC
            Stack<int> st= new Stack<int>(); //GENERIC

            st.Push(1);
            st.Push(2);
            st.Push(3);
            st.Push(4);
            Console.WriteLine(st.Contains(2));
            Console.WriteLine(st.Peek());
            Console.WriteLine(st.Pop());

            foreach (int i in st)
            {
                Console.WriteLine(i);
            }
        }
    }
}
