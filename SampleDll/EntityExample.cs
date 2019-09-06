using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDll
{
    public interface IEntitiesComponent
    {
        void AddEmployee(EmpTable emp);
        void UpdateEmployee(EmpTable emp);
        void DeleteEmployee(int id);
        List<EmpTable> GetAllEmployees();
    }

    public class EntitesComponent : IEntitiesComponent
    {
        public void AddEmployee(EmpTable emp)
        {
            //No SQL Statements, everything is OOP....
            var context = new MyDBEntities();
            context.EmpTables.Add(emp);//Adds to the Collection...
            context.SaveChanges();//Commit to the database..
        }

        public void DeleteEmployee(int id)
        {
            var context = new MyDBEntities();
            var emp = context.EmpTables.FirstOrDefault((e) => e.EmpID == id);
            if (emp == null) throw new Exception("No Employee was found to delete");
            context.EmpTables.Remove(emp);
            context.SaveChanges();
        }

        public List<EmpTable> GetAllEmployees()
        {
            return new MyDBEntities().EmpTables.ToList();
        }

        public void UpdateEmployee(EmpTable emp)
        {
            throw new NotImplementedException("Do it urself...");
        }
    }
}
