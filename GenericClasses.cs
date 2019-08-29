using System;
using System.Collections;
using System.Collections.Generic;

namespace SampleConApp
{

    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public override bool Equals(object obj)
        {
            if(obj is Employee)
            {
                var temp = obj as Employee;
                if ((temp.EmpName == EmpName) && (temp.EmpID == EmpID))
                    return true;
            }
            return false;
        }
    }
    //Based on Templates of Cpp, C# provides Generic Classes that can allow you to create template kind of data structures which can be applied on certain kind of data types or all the data types. 
    class MyCollection<T> : IEnumerable<T> /*where T: struct*/
    {
        private List<T> items = new List<T>();
        public void AddNew(T item)
        {
            items.Add(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public void UpdateRecord(T item,Func<T, bool> finder)
        {
            var selected = items.Find(new Predicate<T>(finder));
            //selected = item;//Reference type equality is applied...
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(selected))
                    items[i] = item;
            }
        }

        public void DeleteRecord(T item, Func<T, bool> finder)
        {
            var selected = items.Find(new Predicate<T>(finder));
            items.Remove(selected);
        }

        public List<T> FindAll(Func<T, bool> finder)
        {
            return items.FindAll(new Predicate<T>(finder));
        }

        public T Find(Func<T, bool> finder)
        {
            return items.Find(new Predicate<T>(finder));
        }
    }
    class GenericClasses
    {
        static void Main(string[] args)
        {
            //stringbasedProgram();
            //intbasedProgram();
            employeebasedProgram();
        }

        private static void employeebasedProgram()
        {
            MyCollection<Employee> employees = new MyCollection<Employee>();
            employees.AddNew(new Employee { EmpID = 123, EmpName = "Phaniraj" });
            employees.AddNew(new Employee { EmpID = 124, EmpName = "Banu Prakash" });
            employees.AddNew(new Employee { EmpID = 125, EmpName = "Robert" });
            employees.AddNew(new Employee { EmpID = 126, EmpName = "Andrew" });
            employees.UpdateRecord(new Employee { EmpID = 152, EmpName = "VeryNew Name" }, (e) =>
                e.EmpID == 125
            );
            var subList = employees.FindAll((e) => e.EmpName.Contains(""));
            foreach (var item in subList) Console.WriteLine(item.EmpName);
        }

        private static void intbasedProgram()
        {
            MyCollection<int> integers = new MyCollection<int>();
            integers.AddNew(634);
            integers.AddNew(543);
            integers.AddNew(656);
            integers.AddNew(984);
            integers.AddNew(524);
            integers.UpdateRecord(345, (i) => i == 543);
            var nos = integers.FindAll((i) => i > 300);
            foreach (var no in nos) Console.WriteLine(no);
        }

        private static void stringbasedProgram()
        {
            MyCollection<string> integers = new MyCollection<string>();
            integers.AddNew("Apple");
            integers.AddNew("Mango");
            integers.AddNew("Orange");
            integers.AddNew("Banana");
            integers.AddNew("Pear");
            integers.UpdateRecord("Kashmir Apple", (i) => i == "Apple");
            var nos = integers.FindAll((i) => i.Contains(""));
            foreach (var no in nos) Console.WriteLine(no);
        }
    }
}