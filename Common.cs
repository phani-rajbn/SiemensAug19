using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //It contains only static functions and it cannot be instantiated. As it contains only static methods, U dont need an object and can be called by its classname... 
    static class Common
    {
        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static int GetNumber(string question)=> int.Parse(GetString(question));

        public static DateTime GetDate(string question) => DateTime.Parse(GetString(question));

        public static double GetDouble(string q) => double.Parse(GetString(q));
    }
}
