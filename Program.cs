using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void addOperation()
        {
            Console.WriteLine("Enter the First no");
            double firstValue = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Second no");
            double secondValue = double.Parse(Console.ReadLine());

            Console.WriteLine("The Added value: " + (firstValue+ secondValue));
        }

        static void subOperation()
        {
            Console.WriteLine("Enter the First no");
            double firstValue = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Second no");
            double secondValue = double.Parse(Console.ReadLine());

            Console.WriteLine("The Subtracted value: " + (firstValue - secondValue));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Which Operation U want\nPress A for Addition and S for Subtraction");
            string choice = Console.ReadLine();

            if (choice.ToUpper() == "A")
                addOperation();
            else
                subOperation();
        }
    }
}
