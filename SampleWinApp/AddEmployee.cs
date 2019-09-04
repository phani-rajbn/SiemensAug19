using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWinApp
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string insertion = "insert into emptable values(@name, @address, @salary)";
            SqlConnection con = new SqlConnection(ConnectedDB.strConnection);
            SqlCommand cmd = new SqlCommand(insertion, con);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@salary", txtSalary.Text);
            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected == 1 )
                    MessageBox.Show("Employee Added Successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            this.Close();
        }
    }
}
