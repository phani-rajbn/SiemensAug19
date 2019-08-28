using System;
using System.Data.SqlClient;
using System.IO;
//.NET has GC(Garbage collector) to handle the memory management. GC runs on a seperate thread which monitors all object creation as well as destruction. 
namespace ConsoleApp
{
    class TestComponent : IDisposable
    {
        private string name;
        public TestComponent(string name)
        {
            this.name = name;
            Console.WriteLine($"The Object by name {name} is created");
        }
        //No Access specifier, no args. Destructors cannot be called explicitly by a program in C#. It is invoked implicitly by GC when the object is being destroyed.  
        ~TestComponent()
        {
            name = string.Empty;
            Console.WriteLine($"The Object by name {name} is Destroyed");
        }

        public void Dispose()
        {
            Console.WriteLine($"The Object by name {name} is Destroyed using Dispose");
            name = string.Empty;
            GC.SuppressFinalize(this);//Tells the GC that the function has already handled all the releasing of any resources, dont call this object's destructor.......
        }
    }
    class DestructorsDemo
    {
        static void createAnDestroyObjects()
        {
            for (int i = 0; i < 10; i++)
            {
                using (TestComponent c = new TestComponent(i.ToString()))
                {

                }
                    //TestComponent c = new TestComponent(i.ToString());
                //c.Dispose();//The responsibility of the C# programmer is to call the Dispose method of the object if the class implements IDisposable. 

                GC.Collect();//GC is a static class that is available in .NET to represent the GC and allow to call methods to free the memory from the unused objects. U cannot specify the amount or the type or the no of objects to be removed....
                GC.WaitForPendingFinalizers();//It will make the Main thread wait till all the objects are released by the GC......

            }
        }
        static void Main(string[] args)
        {
            createAnDestroyObjects();
            Console.WriteLine("Object are only created here. Yet to be destroyed");
            Console.ReadKey();
        }
    }
}