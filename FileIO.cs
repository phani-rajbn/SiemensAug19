using System;
using System.Collections.Generic;
using System.IO;
//System.IO is the namespace for performing file related operations within the OS...
//File class can be used to read, write text files which internally uses Stream object to interact with the physical file
namespace ConsoleApp
{
    class FileDemo
    {
        static void Main(string[] args)
        {
            ///////////////////////////First Example//////////////////////////////
            //var fs = File.Create("SampleFile.txt");
            //fs.Close();
            //File.WriteAllText("SampleFile.txt", "Apple 123 in a simple file to be placed in a file called SampleFile.txt");
            //////////////////////////Reading File Example//////////////////////
            //string filename = "..\\..\\FileIO.cs";
            //if (File.Exists(filename))
            //{
            //    string content = File.ReadAllText(filename);
            //    Console.WriteLine(content);
            //}
            ///////////////////////////////Writing a CSV file Example//////////////////////
            //StreamWriter writer = new StreamWriter("Data.csv", true);//appends the file...
            //writer.WriteLine(string.Format("{0},{1},{2},{3}", 123, "Phaniraj", "Bangalore", 45000));
            //writer.Close();
            ///////////////////////Reading the data from CSV Into List<Employee>.............
            const string filename = "Employees.csv";
            //We should line by line, split the line based on , and finally refer the values into an object. Add the object into the collection...
            StreamReader reader = new StreamReader(filename);
            List<Employee> dataList = new List<Employee>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();//Reads the single line and moves to the next line if exists.
                var words = line.Split(',');//Split the line based on ,
                Employee emp = new Employee
                {
                    EmpID = int.Parse(words[0]),
                    EmpName = words[1],
                    EmpAddress = words[2],
                    EmpSalary = double.Parse(words[3])
                };
                dataList.Add(emp);
            }
            reader.Close();
            foreach (var emp in dataList) Console.WriteLine(emp.EmpName);
        }
    }
}