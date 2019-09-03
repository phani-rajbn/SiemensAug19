using System;
namespace ConsoleApp
{
    class SimpleClass
    {
       public static string StaticVariable { get; set; }
       public string InstanceVariable { get; set; }
        public SimpleClass()
        {
            Console.WriteLine("Instance Constructor");
        }

        static SimpleClass()
        {
            Console.WriteLine("Static Constructor");
        }
    }
    class OOPRecap
    {
        static void Main(string[] args)
        {
            //First Version....
            //SimpleClass cls = new SimpleClass();
            //cls.InstanceVariable = "Instance Variable";


            SimpleClass.StaticVariable = "Testing without creating object";
           //Observations: Static constructor is called once and only once, its called before the instance constructor. Even if the static member is not refered, still the static constructor gets called. If the static variable is used in the program with no instance, instance constructor will never gets called implicitly....

        }
    }
}