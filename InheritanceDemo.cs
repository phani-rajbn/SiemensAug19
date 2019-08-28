using System;
namespace ConApp
{
    class BaseClass
    {
        public void TestFunc() => Console.WriteLine("Test Func from the base class");
    }

    //This is the syntax of Inheritance in C#. There is no public or private inheritance, its simply public inheritance, all the members of the base class will retain their accessibility in the derived classes.....
    //The Derived class can have only one base class at any level. There is no multiple inheritance in C#. However U have multi level Inheritance. 

    class DerivedClass : BaseClass
    {
        public void DerivedFunc() => Console.WriteLine("Derived Func is called");
    }
    class InheritanceExample
    {
        static void Main(string[] args)
        {
            firstExample();
        }

        private static void firstExample()
        {
            DerivedClass derivedClass = new DerivedClass();
            derivedClass.DerivedFunc();
            derivedClass.TestFunc();
        }
    }
}