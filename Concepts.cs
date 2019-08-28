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

        static void Main(string[] args)
        {
            Test[] tests = new Test[6];
            foreach(var test in tests)
                Console.WriteLine(test.name);
        }
    }
}
