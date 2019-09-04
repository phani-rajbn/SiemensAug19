using ConsoleApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ConsoleApp;//Namespace of the Other project...

namespace SampleWinApp
{
    public partial class StudentDB : Form
    {
        public StudentDB()
        {
            InitializeComponent();
        }
        //This function is generated based on the dbl-clk on the Form
        private void StudentDB_Load(object sender, EventArgs e)
        {
            lstStudents.Items.Clear();//Clear old list....
            ExaminationPortal portal = new ExaminationPortal();
            var data = portal.GetStudents();
            foreach (var student in data)
                lstStudents.Items.Add(student);
            lstStudents.DisplayMember = "StudentName";//property of the student class to display
        }
    }
}
