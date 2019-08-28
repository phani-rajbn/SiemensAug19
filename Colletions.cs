using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq;//Use this for some new functions of .NET 4.0...
//Collections are in 2 versions: Older version is called Non Generic Collections where the data in the data structures are stored as objects. Everything is object, so its not safe. 
//Collections.Generics is the improvised version of collections which are type safe and are used to store data as individual types, not as object...
//Our Course focuses on Generics.
/*Some of the important Generic Collections:
 * List<T>
 * HashSet<T>
 * Dictionary<K,V>
 * Queue<T>
 * Stack<T>
 * LinkedList<N>
 */
//Generics is extended to normal programming which works like Templates of C++...
namespace ConsoleApp
{
    class TestClass
    {
        public int no;
        public string name;
        //Get the HashValue of UR object....
        public override int GetHashCode()
        {
            return no.GetHashCode();
        }

        //To match the logical equavalence of 2 objects.....
        public override bool Equals(object obj)
        {
            if (obj is TestClass)
            {
                var temp = obj as TestClass;
                if ((temp.no == no) && (temp.name == name))
                    return true;
            }
            return false;
        }
    }
    class Colletions
    {
        static void Main(string[] args)
        {
            //listExample();
            //hashSetExample();//WIll Hashset work in the same way for Custom data types?
            //customDataTypesOnHashSet();
            //dictionaryExample();//How to add and display the data...
            //dictionaryExample2();//New way of adding and finding the record....
            //queueExample();
            //stackExample();
            //linkedListExample();
        }

        private static void linkedListExample()
        {
            //Linked List allows to insert, delete and modify the Data at any point in a easy manner, but performance wise its not good....
            LinkedList<string> employees = new LinkedList<string>();
            employees.AddFirst("Phaniraj");
            employees.AddBefore(employees.Last, "Udemy");
            employees.AddAfter(employees.First, "Sachin");
            employees.AddLast("Somnath");
            employees.AddBefore(employees.Find("Udemy"), "Andrew");
            employees.AddAfter(employees.Find("Sachin"), "Stella");
            employees.AddLast("Zaheer Khan");

            foreach (var item in employees) Console.WriteLine(item);
        }

        private static void stackExample()
        {
            //Stack allow to place the items one on top of the other. The last item added will be the first item to be removed. First In-Last-Out...
            Stack<string> cart = new Stack<string>();
            int index = 0;
            do
            {
                string item = Common.GetString("Enter the Item to add to Cart");
                cart.Push(item);//Adds the item to the top of the List....
                index++;
            } while (index <= 5);
            while(cart.Count != 0)
            {
                string billingItem = cart.Pop();//Pulls out the first item in the Stack, it means it pulls the last added item from the list..
                Console.WriteLine(billingItem);
            }
        }

        private static void queueExample()
        {
            //Queue stores the data in the form of First In First Out basis. The Elements will be added to the bottom and the first element will the one that can be pulled out, so U cannot remove or move to the middle element untill the top elements are removed. 
            //Solitaire game is designed like this...
            Queue<string> recentList = new Queue<string>();
            do
            {
                string item = Common.GetString("Enter the Item U want to see");
                if (recentList.Count == 5)
                    recentList.Dequeue();//Removes the 1st element in the Queue and the other elements will reorder themselves...
                recentList.Enqueue(item);
                Console.WriteLine("UR recently Viewed Items:");
                var list = recentList.Reverse();
                foreach (var e in list) Console.WriteLine(e);
            } while (true);
        }

        private static void dictionaryExample2()
        {
            Dictionary<int, string> employees = new Dictionary<int, string>();
            //U could check for the Key before U attempt to add... 
            bool @continue;
            do
            {
            RETRY:
                int id = Common.GetNumber("Enter the ID to insert");
                if (employees.ContainsKey(id))
                {
                    Console.WriteLine("Employee ID already exists, please try again");
                    goto RETRY;
                }
                string name = Common.GetString("Enter the Name of the Employee");
                employees[id] = name;//Adds a key-value pair, if the key already exists, it replaces the value.....
                string choice = Common.GetString("Press N to add new Employee");
                @continue = choice == "N" ? true : false;
            } while (@continue);
            int empid = Common.GetNumber("Enter the ID of the Employee to find");
            if (employees.ContainsKey(empid))
            {
                Console.WriteLine("The Name is : " + employees[empid]);
            }
            else
            {
                Console.WriteLine("The ID does not exist");
            }
        }

        private static void dictionaryExample()
        {
            //Dictionary stores the data based on key-value pairs. In this, key is unique for the collection. They are represented as collection of the type KeyValuePair<K,V>. The uniqueness of the key is determined by the HashCode Value of the variable that U insert as a Key. 
            bool @continue;
            Dictionary<int, string> employees = new Dictionary<int, string>();
            do
            {
                RETRY:
                int id = Common.GetNumber("Enter the ID to insert");
                string name = Common.GetString("Enter the Name of the Employee");
                try
                {
                    employees.Add(id, name);
                    string choice = Common.GetString("Press N to add new Employee");
                    @continue = choice == "N" ? true : false; 
                }catch(Exception ex)//If the key already Exists....
                {
                    Console.WriteLine(ex.Message);
                    goto RETRY;
                }

            } while (@continue);
            foreach(KeyValuePair<int, string> pair in employees)
                Console.WriteLine($"{pair.Key}:{pair.Value}");
        }

        private static void customDataTypesOnHashSet()
        {
            HashSet<TestClass> classes = new HashSet<TestClass>();
            var t = new TestClass { no = 123 };
            var copy = t;
            Console.WriteLine("HashCode: " + t.GetHashCode());
            Console.WriteLine("HashCode: " + copy.GetHashCode());
            classes.Add(new TestClass { no = 123 });
            classes.Add(new TestClass { no = 123 });
            classes.Add(new TestClass { no = 123 });
            foreach (var item in classes)
            {
                Console.WriteLine(item.GetHashCode());
            }
            Console.WriteLine("The total no of classes: " + classes.Count);
        }

        private static void hashSetExample()
        {
            //List does not check for duplicates, so U can use HashSet a DS that identifies an object by its hashvalue and allows it to be inserted into the collection. hashset has almost all the features from LIST<T> with this added feature of uniqueness....
            HashSet<string> basket = new HashSet<string>();
            do
            {
                string answer = Common.GetString("Enter the fruit to add to basket");
                if(basket.Add(answer))
                    Console.WriteLine("Added");
                else
                    Console.WriteLine("Already Exists");
            } while (true);
        }

        private static void listExample()
        {
            //list is the improvised version of ArrayList that was available in Older Collections. 
            //List provides the feature of Dynamic Array where elements could be removed, added, inserted and deleted to perform optimized dynamic datastructure...
            List<string> fruits = new List<string>();//0 size.....
            fruits.Add("Apple");//Adds to the bottom of the list....
            fruits.Add("Mango");
            fruits.Add("Orange");
            fruits.Add("Gauva");
            fruits.Add("Pomogranate");

            foreach (var fruit in fruits) Console.WriteLine(fruit);
            if (fruits.Remove("Mango"))
                Console.WriteLine("Removed");
            else
                Console.WriteLine("Not found to remove"); 
            Console.WriteLine("After removing Mango...");
            fruits.Insert(3, "Kiwi Fruit");
            foreach (var fruit in fruits) Console.WriteLine(fruit);
            //iterating thro for loop
            Console.WriteLine("Displaying fruits  in reverse order......\n\n");
            for (int i = fruits.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(fruits[i]);//Displaying in reverse....
            }
        }
    }
}
