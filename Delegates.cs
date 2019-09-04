using System;
namespace ConsoleApp
{
    //Delegates are like function pointers of C++. They allow to treat functions are reference variables so that it could be passed as arguments for a function. functional references are used to perform callback functions in a given program...
    //Delegates are objects that refers to a method. Practically delegates are used in multi Threading, Event handling, Callback functions and many scenarios where a method is required to be called without knowing its actual name...
    //Delegates are to be declared like a class. Delegate definition contains the signature of the method on which it could be used as reference. 
    delegate double Operation(double first, double second);

    class DelegatesExample
    {
        //A function that takes a delegate as arg which could be used to pass the function as arg while calling it. 
        static void InvokeFunc(Operation func)
        {
            //Take inputs for the funtion
            double v1 = Common.GetDouble("Enter v1");
            double v2 = Common.GetDouble("Enter v2");
            //Call the function
            if (func != null)
            {
                var res = func(v1, v2);//invoking the function....
                Console.WriteLine("The result : " + res);
            }
        }
        static void Main(string[] args)
        {
            //Operation op = new Operation(addFunc);
            //InvokeFunc(op);
            //InvokeFunc(addFunc);//New syntax of delegates in C# 2.0....
            ////Here the function is infered as object of the delegate pointing to it....

            ////U could create the method as an anonymous method and pass as arg into the function..
            //InvokeFunc(delegate (double v1, double v2)
            //{
            //    return v1 - v2;
            //});
            ////This is called Anonymous method where the method is created adhoc and not need to create new methods. To reuse the Anonymous method, U could create the delegate object and call thro it. delegete keyword is used not only to create delegate but also create objects for the delegate....
            ////creating a delegate object thro anonymous method
            //Operation mul = delegate (double v1, double v2)
            //{
            //    return v1 * v2;
            //};
            //Console.WriteLine(mul(123, 234));//invoking the anonymous method thro the delegate object...
            //Console.WriteLine(mul(543, 45));//invoking the anonymous method thro the delegate object...
            //MulticastDelegateExample();
            lambdaExpressions();
        }

        private static void lambdaExpressions()
        {
            Action action =  () => Console.WriteLine("Simple Action");

            //Old Syntax of c# 3.0
            //In C# 3.5, a new syntax for a shorter implementation was sought....
            Operation op = (v1, v2) => v2 / v1;
            Console.WriteLine($"{op(123, 23):#.##}");//reduces the decimal count to 2...
        }

        private static void MulticastDelegateExample()
        {
            //Action is a .NET delegate that can be used to call any kind of function that are void.
          
            Action actions = new Action(delegate ()
            {
                Console.WriteLine("First Function");
            });
            actions += new Action(delegate ()
            {
                Console.WriteLine("Second Function");
            });
            actions += new Action(delegate ()
            {
                Console.WriteLine("Third Function");
            });
            actions();//All the 3 functions get called in the order of their object creations.
            //This way of creating a delegate object that can point to multiple functions at a time is called as MulticastDelegate. MUlti casting Delegate is not suitable for return functions as the return value of the last function is what u can store. rest cannot be stored..
        }

        static double addFunc(double v1, double v2) => v1 + v2;
    }
}