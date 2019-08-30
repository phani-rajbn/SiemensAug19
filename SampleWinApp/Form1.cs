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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Apple123");
        }
        //Click event of the button...
        private void btnGet_Click(object sender, EventArgs e)
        {
            //get the first value
            double value1 = double.Parse(txtValue1.Text);
            double value2 = double.Parse(txtValue2.Text);
            string operation = cmbOptions.Text;
            switch (operation)
            {
                case "Add":
                    lblAnswer.Text = (value1 + value2).ToString();
                    break;
                case "Subtract":
                    lblAnswer.Text = (value1 - value2).ToString();
                    break;
                default:
                    lblAnswer.Text = (value1 * value2).ToString();
                    break;
                    //add the divide feature also...
            }
        }


        //This is the load event handler for the form which is invoked when the form is loaded into the memory...

    }
}
