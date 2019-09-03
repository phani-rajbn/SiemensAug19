using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class TestClass
    {
        public string TestName { get; set; }
        public override int GetHashCode()
        {
            return TestName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is TestClass)
            {
                var copy = obj as TestClass;
                return copy.TestName == TestName;
            }
            return false;
        }
    }
    class DataTypes
    {
        static void Main(string[] args)
        {
            //basicConversion();
            //converClassUsage();
            //findingTypeOfVariable();
            //createArrayAtRuntime();
            //boxingAndUnboxing();
            //getHashCodeExample();
            //hashCodeOnCollections();
        }

        private static void hashCodeOnCollections()
        {
            HashSet<TestClass> tests = new HashSet<TestClass>();
            do
            {
                Console.WriteLine("Enter the Test to be created");
                string name = Console.ReadLine();
                TestClass cls = new TestClass { TestName = name };
                if (tests.Add(cls))
                {
                    Console.WriteLine("Test added successfully");
                }
                else
                {
                    Console.WriteLine("Test already added to the database");
                }
            } while (true);
        }

        private static void getHashCodeExample()
        {
            int value = 123;
            Console.WriteLine("The value:{0}\thashCode:{1}", value, value.GetHashCode());
            
            double dValue = 5435.345;
            Console.WriteLine("The value:{0}\thashCode:{1}", dValue, dValue.GetHashCode());

            string info = "Apple123";
            Console.WriteLine("The value:{0}\thashCode:{1}", info, info.GetHashCode());
            string test = "Apple123";
            Console.WriteLine("{0} and {1}", test.GetHashCode(), info.GetHashCode());

            //Sharing the same hashcode makes them almost equal...
            Console.WriteLine(info == test);//R They Equal?

            TestClass cls = new TestClass { TestName = "Dotnet Training" };
            Console.WriteLine("The value:{0}\thashCode:{1}", cls.TestName, cls.GetHashCode());
        }

        private static void boxingAndUnboxing()
        {
            //object is a reference type. Similar to void* of C++. It can hold any kind of data in its variable. 
            object value = 123;
            value = "Apple";
            value = new Exception("Test Message");
            //Boxing is encapsulating the original info of the data into an Object type.  
            Console.WriteLine(((Exception)value).Message);
            //To perform any operations of the data type on Object, U must cast it to its type. This is called as UNBOXING. Unboxing is explicit and boxing is implicit. 
            //U should use C Style casting for Unboxing value types and as operator for unboxing reference types...
            //Unboxing is possible only if its casted back to the same type from which it was boxed....
            value = 123.8768;//int....
            long intValue = ((long)(double)value);//Invalid Cast
            Console.WriteLine(intValue);
            //if the boxed value is a reference type, u could use, is and as operators to have a safe casting...
            value = new TestClass { TestName = "C# Test" }; //Boxing....
            if(value is TestClass)//Only for reference types....
            {
                var unboxed = value as TestClass;
                Console.WriteLine(unboxed.TestName);
            }
        }

        private static void createArrayAtRuntime()
        {
            Console.WriteLine("Enter the size");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the CTS equivalent data type for the Array");
            Type selected = Type.GetType(Console.ReadLine());
            if(selected == null)
            {
                Console.WriteLine("Invalid Type, not recognized by CLR");
                return;
            }
            Array array = Array.CreateInstance(selected, size);
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the value of the type {0} at the location {1}", selected.Name, i);
                object value = Convert.ChangeType(Console.ReadLine(), selected);//Boxed value.....
                array.SetValue(value, i);
            }
            Console.WriteLine("All the values are set...");
            foreach(var val in array)
                Console.WriteLine(val);
        }

        private static void findingTypeOfVariable()
        {
            Console.WriteLine("Enter the value");
            object value = int.Parse(Console.ReadLine());
            Console.WriteLine("The Data type is " + value.GetType().Name);
            //To get the Type object of the data type itself, U use typeof operator..
            //System.Object has a method called GetType which gives the Type object through which U can get type information....
            Type info = typeof(int);
            Console.WriteLine("The Name is " + info.Name);//What is FullName
            Console.WriteLine("Its namespace is " + info.Namespace);
            Console.WriteLine("Its const fields no is " + info.GetFields().Length);

        }

        private static void converClassUsage()
        {
            int value = 234;
            long lValue = value;//Implicit casting....
            //value = (int)(lValue + 23424340980);//Explicit casting is required, but unsafe....
            try
            {
                value = Convert.ToInt32(lValue + 23424340980);
            }
            catch (OverflowException ov)
            {
                Console.WriteLine(ov.Message);
                Console.WriteLine("Range of the long does not fit into int....");
            }
            //U get an Exception if the range does not fit in, instead of giving some abnormal value...
            Console.WriteLine("The value of int is " + value);
        }

        private static void basicConversion()
        {
            double value = 123.234;
            int intValue = (int)value;//Explicit casting is required....
            Console.WriteLine("The value of the integer is " + intValue);

            value = intValue;//There is no possibility of loosing any data....
                             //C# recommends to use Convert class instead of C Style casting...
        }
    }
}