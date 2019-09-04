using System;
using SampleDll;
using System.Data;
namespace ConsoleApp
{
    class DBProgram
    {
        static IEmployeeDatabase db;
        static void Main(string[] args)
        {
            try
            {
                db = DBFactory.CreateDatabase();
                //db.AddNewEmployee("ConsoleName", "ConsoleAddress", 65000);
                //db.UpdateEmployee(4, "UpdateName", "UpdateAddress", 55000);
                var table = db.GetAllEmployees();
                foreach(DataRow row in table.Rows)
                {
                    Console.WriteLine(row["Empname"]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}