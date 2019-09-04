using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace SampleDll
{
    public interface IEmployeeDatabase
    {
        void AddNewEmployee(string name, string address, double salary);
        void UpdateEmployee(int id, string name, string address, double salary);
        void DeleteEmployee(int id);
        DataTable GetAllEmployees();
    }

    class EmpDB : IEmployeeDatabase
    {
        const string strConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=SiemensDB;Integrated Security=True";
        const string strInsert = "insert into emptable values(@name, @address, @salary)";
        const string strUpdate = "Update EmpTable set empname = @name, empaddress = @address, empsalary = @salary where empid = @id";
        const string strDelete = "delete from emptable where empid = @id";
        const string strSelect = "select * from emptable";

        public void AddNewEmployee(string name, string address, double salary)
        {
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(strInsert, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@salary", salary);
            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();               
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException("Do it Urself...");
        }

        public DataTable GetAllEmployees()
        {
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(strSelect, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable("EmpRecords");
                table.Load(reader);
                return table;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            
        }

        public void UpdateEmployee(int id, string name, string address, double salary)
        {
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(strUpdate, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();//Update statement...
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }

    public class DBFactory
    {
        public static IEmployeeDatabase CreateDatabase()
        {
            return new EmpDB();
        }
    }
}
