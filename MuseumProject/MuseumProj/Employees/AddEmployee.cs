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
    public partial class AddEmployee : Form
    {
        int formID;
        int rank;
        private Controller controllerObj; // A Reference of type Controller 
        public AddEmployee(int ID)
        {
            formID = ID;
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            rank = controllerObj.CheckPosition(formID);
            comboBox1.Items.Add('F');
            comboBox1.Items.Add('M');
            if (rank == 2)
            {
                comboBox2.Items.Add("Receptionist");
                comboBox2.Items.Add("Janitor");
                comboBox2.Items.Add("Researcher");
                comboBox2.Items.Add("Security");
                comboBox2.Items.Add("HR");
            }
            else if (rank == 3)
            {
                comboBox2.Items.Add("Security Supervisor");
                comboBox2.Items.Add("Researchers Supervisor");
                comboBox2.Items.Add("HR Supervisor");
                comboBox2.Items.Add("Receptionists Supervisor");
                comboBox2.Items.Add("Treasury Supervisor");
                comboBox2.Items.Add("Monuments Supervisor'");
                comboBox2.Items.Add("Janitors Supervisor'");
                comboBox2.Items.Add("Receptionist");
                comboBox2.Items.Add("Janitor");
                comboBox2.Items.Add("Researcher");
                comboBox2.Items.Add("Security");
                comboBox2.Items.Add("HR");
            }
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int salary = 0;
            int position = 0;
            if (comboBox2.Text == "Receptionist")
            {
                salary = 2000;
                position = 1;
            }
            else if (comboBox2.Text == "Janitor")
            {
                salary = 800;
                position = 1;
            }
            else if (comboBox2.Text == "Researcher")
            {
                salary = 3000; 
                position = 1;
            }
            else if (comboBox2.Text=="Security")
            {
                salary = 1500;
                position = 1;
            }
            else if (comboBox2.Text == "HR")
            {
                salary = 3000;
                position = 1;
            }
            else if (comboBox2.Text == "Security Supervisor")
            {
                salary = 3500;
                position = 2;
            }
            else if (comboBox2.Text == "Researchers Supervisor")
            {
                salary = 4000;
                position = 2;
            }
            else if (comboBox2.Text == "HR Supervisor")
            {
                salary = 4000;
                position = 2;
            }
            else if (comboBox2.Text == "Receptionists Supervisor")
            {
                salary = 4000;
                position = 2;
            }
            else if (comboBox2.Text == "Treasury Supervisor")
            {
                salary = 3500;
                position = 2;
            }
            else if (comboBox2.Text == "Monuments Supervisor")
            {
                salary = 3500;
                position = 2;
            }
            else if (comboBox2.Text == "Janitors Supervisor")
            {
                salary = 1500;
                position = 2;
            }
            
            int ParsedValue;
            if (textBox2.Text.Length == 0 || textBox3.Text.Length == 0 ||  comboBox1.SelectedItem == null|| comboBox2.SelectedItem == null)
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
                int InsertEmployee = controllerObj.InsertEmployee(textBox3.Text, Convert.ToChar(comboBox1.SelectedItem), Int32.Parse(textBox2.Text), comboBox2.SelectedItem.ToString(), salary, position);
                MessageBox.Show("Employee added successfully!");
            }

        }
    }
}
