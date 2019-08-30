using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWinApp
{
    public partial class PatientInfo : Form
    {
        static PatientDatabase db = new PatientDatabase();
        public PatientInfo()
        {
            InitializeComponent();
        }

        private void PatientInfo_Load(object sender, EventArgs e)
        {
            lstNames.Items.Clear();
            var list = db.GetAllPatients();
            //lstNames.DataSource = list;
            //lstNames.DisplayMember = "PatientName";
            foreach (var p in list)
                lstNames.Items.Add(p);
            lstNames.DisplayMember = "PatientName";
        }

        private void lstNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = lstNames.SelectedItem as Patient;
            txtID.Text = selected.PatientID.ToString();
            txtName.Text = selected.PatientName;
            txtDiesease.Text = selected.Severity;
            txtDoc.Text = selected.Doctor;
            txtAmount.Text = selected.BillAmount.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //create the Patient object
            var p = new Patient();
            //Fill the values based on the entries in the text boxes.
            p.PatientID = int.Parse(txtID.Text);
            p.PatientName = txtName.Text;
            p.Doctor = txtDoc.Text;
            p.Severity = txtDiesease.Text;
            p.BillAmount = double.Parse(txtAmount.Text);
            //call the update function to update
            db.UpdatePatient(p);
            MessageBox.Show("New Details have been updated to the database");
            //Refill the listbox with new records....
            PatientInfo_Load(sender, e);//sender the object that triggered this event....
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //create the Patient object
            var p = new Patient();
            //Fill the values based on the entries in the text boxes.
            p.PatientID = int.Parse(txtID.Text);
            p.PatientName = txtName.Text;
            p.Doctor = txtDoc.Text;
            p.Severity = txtDiesease.Text;
            p.BillAmount = double.Parse(txtAmount.Text);
            db.AddNewPatient(p);
            
            MessageBox.Show("New Patient added to the database");
            PatientInfo_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do U really want to delete?", "Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                db.DeletePatient(int.Parse(txtID.Text));
                MessageBox.Show("Deleted Successfully");
                PatientInfo_Load(sender, e);
            }
            else
                return;
        }
    }
}
