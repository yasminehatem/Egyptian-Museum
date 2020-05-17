using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumProj
{
    public partial class AddTourguides : Form
    {
        private Controller controllerObj; // A Reference of type Controller 

        public AddTourguides()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            comboBox1.Items.Add('F');
            comboBox1.Items.Add('M');
            comboBox2.Items.Add("Full-Time");
            comboBox2.Items.Add("Part-Time");
            comboBox2.Items.Add("Intern");
            comboBox3.Items.Add("Cairo University");
            comboBox3.Items.Add("Ain Shams University");
            comboBox3.Items.Add("Helwan University");
            comboBox3.Items.Add("Mansoura University");
            comboBox3.Items.Add("Azhar University");
        }

        private void AddTourguides_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int salary = 0;
            if (comboBox2.Text == "Intern")
            {
                salary = 0;
            }
            else if (comboBox2.Text == "Full-Time")
            {
                salary = 2500;
            }
            else if (comboBox2.Text == "Part-Time")
            {
                salary = 2000;
            }

            int ParsedValue;
            if (textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                label1.Text = ("Please fill all fields!");
                label1.Show();

            }
            else if (!int.TryParse(textBox2.Text, out ParsedValue))
            {
                label1.Text = ("Phone No. field must contain only numeric values!");
                label1.Show();
            }
            else
            {
                label1.Hide();
                int InsertTourguide = controllerObj.InsertTourguide(textBox3.Text, Convert.ToChar(comboBox1.SelectedItem), Int32.Parse(textBox2.Text), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), salary);
                MessageBox.Show("Tourguide added successfully!");
            }

            
        }
    }
}
