using System;
namespace ConApp
{
    //Set the entry point before U try this example.....Inheritance allows the derived classes to modify the existing functions of the base class in them. There are certain rules of engagement to be followed before the derived class is allowed to modify. 
    //The base class must declare the function with a modifier called virtual. This makes the functions in the derived class to reimplement them. 
    //The derived class will modify the virtual function using another modifier called override. Derived class will not have virtual keyword, but will have override keyword. override methods can further be overriden by its derived classes.
    class TestClass
    {
        protected int value;
        public virtual void TestFunc()
        {
            value = 123;
            Console.WriteLine("Test Func is called");
        }

        public void NonVirtualFunction() => Console.WriteLine("Not intended to be overriden");
    }

    class DerivedTestClass : TestClass
    {
        //Cannot use the override on the non-virtual functions. however U could still implement the function which becomes a new implementation of the function not associated with the base class version. Now this function has to be accessed like we do the independent functions. This way of reimplementing the base class functions as new implementation is called as Method Hiding. Hiding is like telling that the object will hide the implementation of the base....
        //Use of the new keyword will tell us that this function has a base class version also and we have intentionally modified it in the derived class. This function will not be in the process of runtime polymorphism....
        public new void NonVirtualFunction()
        {
            Console.WriteLine("Implemented in the Derived class");
        }

        //This class wishes to change the implementation of the base class's Function called TestFunc. 
        public override void TestFunc()
        {
            //Console.WriteLine("The Value: " + value);
            base.TestFunc();//The IDE will provide a default implementation for this function by simply calling the base version of the function....
            Console.WriteLine("Test Func is implemented in a new way in the derived class");
        }
        //new Functions of the derived classes will not be made available to the objects of the base class that will instantiate thro Runtime polymorphism. In such cases, U should type cast the object to the derived type and call its methods....
        public void IndependentFunc()
        {
            Console.WriteLine("The Value that is currently set is " + value);
            Console.WriteLine("Only available in the derived class");
        }
        
    }
    class MethodOverriding
    {
        static void Main(string[] args)
        {
            //DerivedTestClass cls = new DerivedTestClass();
            //cls.TestFunc();

            TestClass cls = new TestClass();
            cls.TestFunc();//It will call the base version....
            
            //Retaining the same variable but instantiate it to the new Derived version of the class....
            cls = new DerivedTestClass();
            cls.TestFunc();//It will call the derived class version, not the base version
            cls.NonVirtualFunction();//Still call the base version only as the base class is unaware of the derived version...

            //how to call the other functions of the derived using base class object?
            if (cls is DerivedTestClass)//check if the object is instantiated to the DerivedTestClass
            {
                var obj = cls as DerivedTestClass;//Reference type casting using as keyword.....
                //cls is now having a new name called obj.....
                obj.IndependentFunc();
                obj.NonVirtualFunction();//Calls the derived class version, no RTP here...
            }
        }
    }
}