using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    //Generic classes and methods combine reusability, type safety, and efficiency
    //System.Collections.Generic namespace contains several generic-based collection classes. 
    class Generics
    {
        public static void Main(String[] args)
        {
            Hasher<String, int> generics = new Hasher<String, int>();
            generics.add("om", 1);
            Console.WriteLine(generics.Key + " " + generics.Value);

            Generics obj= new Generics();
            obj.displayType("OM");

            //ERROR AS int is expected
            //obj.displayType<int>("om");
            obj.displayType<int>(1);
            Console.WriteLine(obj.compare(1,1));
            Console.WriteLine(obj.compare<string>("om", "mo"));
            //implicit conversion works (eg - float to double)
            Console.WriteLine(obj.compare<double>(1.2f,1.2)); //False
            Console.WriteLine(obj.compare<double>(1, 1.0)); //True

            obj.Add(10,20);
        }
        public void Add<T>(T a, T b)
        {
            //gives error as T is unknown
            //Console.WriteLine(a + b);

            /*
                Datatype of dynamic variables is determined at runtime 
                when you pass the value (var identifies it at compilation time)
            */
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1+d2);
        }
        public bool compare<T>(T a,T b)
        {
            // == does not work
            return a.Equals(b);
        }
        public void displayType<T>(T a)
        {
            Console.WriteLine(a.GetType());
        }
    }
    class Hasher<K,V>
    {
        K key;V value;
        public K Key {  get { return key; } set { key = value; } }
        public V Value { get { return this.value; } set { this.value = value; } }
        public void add(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
