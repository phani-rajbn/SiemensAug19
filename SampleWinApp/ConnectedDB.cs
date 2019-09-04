using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//Connect to database
//Create the table
//Add some records
//Configure the database to Server Explorer in VS 2017.

namespace SampleWinApp
{
    public partial class ConnectedDB : Form
    {
        public const string strConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=SiemensDB;Integrated Security=True";
        public ConnectedDB()
        {
            InitializeComponent();
        }

        private void ConnectedDB_Load(object sender, EventArgs e)
        {
            lstNames.Items.Clear();
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand("SELECT EMPNAME FROM EMPTABLE", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lstNames.Items.Add(reader["Empname"]);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void lstNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Format("SELECT * FROM EMPTABLE WHERE EMPNAME = '{0}'", lstNames.Text);
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtID.Text = reader[0].ToString();
                    txtName.Text = reader[1].ToString();
                    txtAddress.Text = reader[2].ToString();
                    txtSalary.Text = reader[3].ToString();
                    txtID.Enabled = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "Update EmpTable set empname = @name, empaddress = @address, empsalary = @salary where empid = @id";//variables of Sql statements will be prefixed with @....
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@salary", txtSalary.Text);
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();//Update statement...
                MessageBox.Show("Updated successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            ConnectedDB_Load(sender, e);//Reload the Listbox....
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Create the instance of the Form object
            //SHow the form...
            AddEmployee empForm = new AddEmployee();
            empForm.ShowDialog(this);//Displays as Modal Dialog.....
            //Next line will be executed only after the dialog is closed...
            ConnectedDB_Load(sender, e);
        }
    }
}
    
