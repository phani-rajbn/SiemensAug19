using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
/*
 * Serialization: An ability of saving the state of the object(object itself) into a  file is called Serialization. The process of extracting the object from the file is called deserialization..
 * Serialization can be done in 3 formats: Binary, XML and SOAP...
 * Every Serialization feature has 3 things:
 * Where: The location of serialization(FileSystem)
 * What: Which object or what kind of object to serialize. Any object of .NET whose class has an attribute called Serializable can be serialized. Attributes are additional properties that is injected into the code.
 * How: Format of serialization..
 */
namespace SampleWinApp
{
    public partial class SerializationDemo : Form
    {
        const string filename = "book.Bin";
        public SerializationDemo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //What to serialize.....
            BookInfo book = new BookInfo();
            book.BookID = int.Parse(txtID.Text);
            book.BookTitle = txtTitle.Text;
            book.BookPrice = double.Parse(txtCost.Text);
            book.Author = txtAuthor.Text;
            //Where to serialize...
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
            {
                //How to serialize....
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, book);
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //Opposite of what we did....
            //Filename
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            //Format
            BinaryFormatter fm = new BinaryFormatter();
            //object...
            var book = fm.Deserialize(fs) as BookInfo;
            txtID.Text = book.BookID.ToString();
            txtAuthor.Text = book.Author;
            txtCost.Text = book.BookPrice.ToString();
            txtTitle.Text = book.BookTitle;
            fs.Close();

        }
    }
}
