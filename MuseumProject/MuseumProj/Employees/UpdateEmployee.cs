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
    public partial class UpdateEmployee : Form
    {
        int formID;
        int rank;
        private Controller controllerObj; // A Reference of type Controller 
     
        public UpdateEmployee(int ID)
        {
            formID = ID;
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            label4.Hide();
            label5.Hide();
            label1.Hide();
            rank = controllerObj.CheckPosition(formID);
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
            if (textBox1.Text.Length == 0)
            {
                label4.Hide();
                label5.Hide();
                label1.Text = ("Please enter an ID!");
                label1.Show();
            }
            else if (controllerObj.CheckID2(Int32.Parse(textBox1.Text)) == false)
            {
                label1.Hide();
                label5.Hide();
                label4.Text = "ID doesn't exist";
                label4.Show();
            }
            else if (controllerObj.CheckPosition(Int32.Parse(textBox1.Text)) == 2)
            {
                if (rank == 2)
                {
                    label4.Hide();
                    label5.Hide();
                    label1.Text = "You're not authorized to do this action";
                    label1.Show();
                }
            }
            else if (controllerObj.CheckPosition(Int32.Parse(textBox1.Text)) == 3)
            {
                label4.Hide();
                label5.Hide();
                label1.Text = "You're not authorized to do this action";
                label1.Show();
            }
            else if (textBox2.Text.Length == 0 && textBox3.Text.Length == 0 && comboBox2.SelectedItem == null)
            {
                label4.Hide();
                label5.Hide();
                label1.Text = "Please enter data to update";
                label1.Show();
            }
            else if (textBox2.Text.Length != 0 && !int.TryParse(textBox2.Text, out ParsedValue))
            {
                label1.Hide();
                label4.Hide();
                label5.Text = ("Phone No. field must contain only numeric values!");
                label5.Show();
               
            }
            else
            {
                if (textBox3.Text.Length != 0 && textBox2.Text.Length == 0 && comboBox2.SelectedItem == null)
                {
                    int Update = controllerObj.UpdateName(Int32.Parse(textBox1.Text), textBox3.Text); 
                    MessageBox.Show("Employee Info updated!");
                }
                else if (textBox3.Text.Length == 0 && textBox2.Text.Length != 0 && comboBox2.SelectedItem == null)
                {
                    int Update = controllerObj.UpdatePhoneNo(Int32.Parse(textBox1.Text), textBox2.Text); 
                    MessageBox.Show("Employee Info updated!");
                }
                else if (textBox3.Text.Length == 0 && textBox2.Text.Length == 0 && comboBox2.SelectedItem != null)
                {
                    int Update = controllerObj.UpdateJob(Int32.Parse(textBox1.Text), comboBox2.SelectedItem.ToString());
                    int Update1 = controllerObj.UpdatePosition(Int32.Parse(textBox1.Text), position);
                    int Update2 = controllerObj.UpdateSalary(Int32.Parse(textBox1.Text), salary);
                    MessageBox.Show("Employee Info updated!");
                }
                else if (textBox3.Text.Length != 0 && textBox2.Text.Length != 0 && comboBox2.SelectedItem == null)
                {
                    int Update = controllerObj.UpdateName(Int32.Parse(textBox1.Text), textBox3.Text);
                    int Update1 = controllerObj.UpdatePhoneNo(Int32.Parse(textBox1.Text), textBox2.Text);
                    MessageBox.Show("Employee Info updated!");
                }
                else if (textBox3.Text.Length != 0 && textBox2.Text.Length == 0 && comboBox2.SelectedItem != null)
                {
                    int Update = controllerObj.UpdateName(Int32.Parse(textBox1.Text), textBox3.Text);
                    int Update2 = controllerObj.UpdateJob(Int32.Parse(textBox1.Text), comboBox2.SelectedItem.ToString());
                    int Update3 = controllerObj.UpdatePosition(Int32.Parse(textBox1.Text), position);
                    int Update4 = controllerObj.UpdateSalary(Int32.Parse(textBox1.Text), salary);
                    MessageBox.Show("Employee Info updated!");
                }
                else if (textBox3.Text.Length == 0 && textBox2.Text.Length != 0 && comboBox2.SelectedItem != null)
                {
                    int Update1 = controllerObj.UpdatePhoneNo(Int32.Parse(textBox1.Text), textBox2.Text);
                    int Update2 = controllerObj.UpdateJob(Int32.Parse(textBox1.Text), comboBox2.SelectedItem.ToString());
                    int Update3 = controllerObj.UpdatePosition(Int32.Parse(textBox1.Text), position);
                    int Update4 = controllerObj.UpdateSalary(Int32.Parse(textBox1.Text), salary);
                    MessageBox.Show("Employee Info updated!");
                }

                else if (textBox3.Text.Length != 0 && textBox2.Text.Length != 0 && comboBox2.SelectedItem != null)
                {
                    int Update = controllerObj.UpdateName(Int32.Parse(textBox1.Text), textBox3.Text);
                    int Update1 = controllerObj.UpdatePhoneNo(Int32.Parse(textBox1.Text), textBox2.Text);
                    int Update2 = controllerObj.UpdateJob(Int32.Parse(textBox1.Text), comboBox2.SelectedItem.ToString());
                    int Update3 = controllerObj.UpdatePosition(Int32.Parse(textBox1.Text), position);
                    int Update4 = controllerObj.UpdateSalary(Int32.Parse(textBox1.Text), salary);
                    
                    MessageBox.Show("Employee Info updated!");
                }
            }
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
