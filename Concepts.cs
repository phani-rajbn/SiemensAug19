using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Test
    {
        public string name;
    }
    class Concepts
    {
        //Values into the function can be passed in 4 ways in C#: pass by Value, pass by Reference, pass by Out and params....
        public static void MathFunc(int v1, int v2, ref int res1, ref int res2, out double res3)
        {
            res1 = v1 + v2;
            res2 = v1 - v2;
            if (v2 != 0)
                res3 = v1 / v2;
            else
                res3 = 0;
            //The only difference b/w the ref and the out is the out parameter must be set within the function and the function cannot exit without setting the value in the function. ref parameters are initialized by the caller before its being sent into the function, out parameters need not initialize, rather it will and must be set within the function.... 
        }//Provide a feature of multiple return types for UR function.....

        public static int addValues(params int[] args)
        {
            int res = 0;
            foreach (var arg in args) res += arg;
            return res;
            /*
             * params is always an array...
             * There should be only one params within the parameter list of the function...
             * params should be the last of the parameter list...
             * params cannot be passed by ref or out...
             */
        }
        static void Main(string[] args)
        {
            //referenceTypeArrays();
            //passByOutAndRef();
            var res = addValues(123, 234, 234, 432, 234, 5435, 345, 345, 234, 345, 345, 345, 5434, 56);
            Console.WriteLine("The Added value: " + res);
        }

        private static void passByOutAndRef()
        {
            int res1 = 0, res2=0;
            double res3;
            MathFunc(123, 23, ref res1, ref res2, out res3);
            Console.WriteLine($"The Added value is {res1} and the Subtracted value is {res2}");
        }

        private static void referenceTypeArrays()
        {
            Test[] tests = new Test[6];
            foreach (var test in tests)
                Console.WriteLine(test.name);
        }
    }
}
