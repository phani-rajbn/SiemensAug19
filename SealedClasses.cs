using System;
namespace ConsoleApp
{
    //If U want to create classes that should not be inherited, U could mark the class as sealed. Sealed Classes are not good for OOP. This stops from inheriting which is one of the fundamental features of OOP. 
    class Simple
    {
        public virtual void TestFunc()
        {
            Console.WriteLine("Test Func is called");
        }
    }

    sealed class Example : Simple
    {
        public override void TestFunc()
        {
            Console.WriteLine("Overriden Func"); 
        }
        public void ExampleFunc()
        {
            Console.WriteLine("Example Func");
        }

        //public virtual void VirtualFunction()//Cannot have virtual functions...

        
    }
    class SealedClasses
    {
        static void Main(string[] args)
        {
            Example ex = new Example();
            ex.ExampleFunc();
            ex.TestFunc();
        }
    }
}