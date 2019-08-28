using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
namespace ConsoleApp
{
    //U could create UR Own collection Classes by implemented interfaces of the Collections.
    //IEnumerable<T> is the fundamental interface that needs to be implemented for every Collection Class either directly or indirectly. This makes to create Components in a customized fine tuned manner there by removing many of the unnessasary things within the Framework. 
    /*
     * All the Collection Classes have a hirarchy of interfaces that are implemented. 
     * As a programmer U could implement the interfaces to create UR own functionalities to the datastructures. 
     * List<T>---->IList<T>---->ICollection<T>---->IEnumerable<T>--->IEnumerable.
     * HashSet<T>--->ISet<T>--->IList<T>....
     * Dictionary<K,V>--->IDictionary<K,V>--->ICollection<T>....
     * LinkedList<T>--->ICollection<T>......
     * Array is the only dataStructure class that is not the part of the Collections Framework and still implements the IEnumerable Interface...
     */
     /*
      * A Collection class in .NET is one whose object can be used in a foreach statement. 
      * If the class implements an interface IEnumerable from the Collections Namespace, then the object of that class will have an ability to be used inside a foreach statement.....
      */

    class Fruit :IEnumerable
    {
        public string name;
        public double price;

        public IEnumerator GetEnumerator()
        {
            Type selectedType = GetType();
            FieldInfo [] fields = selectedType.GetFields();
            return fields.GetEnumerator();
        }
    }

    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
    }

    interface IEmpRepository 
    {
        void AddNewEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
        List<Employee> Find(string name);
        Employee Find(int id);
    }
    class EmployeeRepository : IEmpRepository, IEnumerable<Employee>
    {
        private List<Employee> employees = new List<Employee>();
        public void AddNewEmployee(Employee emp)
        {
            employees.Add(emp);
        }

        public void DeleteEmployee(int id)
        {
            foreach(Employee emp in employees)
            {
                if(emp.EmpID == id)
                {
                    employees.Remove(emp);
                    return;
                }
            }
            throw new Exception("No Employee found to delete");
        }

        public List<Employee> Find(string name)
        {
            List<Employee> templist = new List<Employee>();
            foreach (var emp in employees)
            {
                if (emp.EmpName.Contains(name))
                    templist.Add(emp);
            }
            return templist;
        }

        public Employee Find(int id)
        {
            foreach (var emp in employees)
            {
                if (emp.EmpID == id)
                    return emp;
            }
            throw new Exception($"Employee not found by this ID {id}");
        }


        public void UpdateEmployee(Employee emp)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].EmpID == emp.EmpID)
                {
                    employees[i].EmpName = emp.EmpName;
                    employees[i].EmpAddress = emp.EmpAddress;
                    employees[i].EmpSalary = emp.EmpSalary;
                    return;
                }
            }
            throw new Exception($"Employee by ID {emp.EmpID} does not exist to update");
        }
        public IEnumerator<Employee> GetEnumerator()
        {
            throw new NotImplementedException();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class CustomCollection
    {
        static void Main(string[] args)
        {

            Array elements = Array.CreateInstance(typeof(string), 4);
            //for (int i = 0; i < elements.Length; i++)
            //{
            //    elements.SetValue(Common.GetString("enter string value"), i);
            //}

            //foreach (var item in elements) Console.WriteLine(item);

            ////////////////////////2nd Example////////////////////////////

            Fruit fruit = new Fruit { name = "Apple", price = 240 };
            foreach (var prop in fruit)//Forward only and read only....
            {
               if(prop is FieldInfo)
                {
                    var temp = prop as FieldInfo;
                    Console.WriteLine($"{temp.Name}:{temp.GetValue(fruit)}");
                }
                
            }
        }
    }
}