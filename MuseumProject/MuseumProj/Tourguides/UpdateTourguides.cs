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
    public partial class UpdateTourguides : Form
    {
        private Controller controllerObj; // A Reference of type Controller 

        public UpdateTourguides()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            label4.Hide();
            label5.Hide();
            label1.Hide();
            comboBox2.Items.Add("Full-Time");
            comboBox2.Items.Add("Part-Time");
            comboBox2.Items.Add("Intern");
        }

        private void UpdateTourguides_Load(object sender, EventArgs e)
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
            if (textBox1.Text.Length == 0)
            {
                label4.Hide();
                label5.Hide();
                label1.Text = ("Please enter an ID!");
                label1.Show();
            }
            else if (controllerObj.CheckTourguideID(Int32.Parse(textBox1.Text)) == false)
            {
                label1.Hide();
                label5.Hide();
                label4.Text = "ID doesn't exist";
                label4.Show();
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
                    int Update = controllerObj.UpdateTgName(Int32.Parse(textBox1.Text), textBox3.Text);
                    MessageBox.Show("Tourguide Info updated!");
                }
                else if (textBox3.Text.Length == 0 && textBox2.Text.Length != 0 && comboBox2.SelectedItem == null)
                {
                    int Update = controllerObj.UpdateTgPhoneNo(Int32.Parse(textBox1.Text), textBox2.Text);
                    MessageBox.Show("Tourguide Info updated!");
                }
                else if (textBox3.Text.Length == 0 && textBox2.Text.Length == 0 && comboBox2.SelectedItem != null)
                {
                    int Update = controllerObj.UpdateTgStatus(Int32.Parse(textBox1.Text), comboBox2.SelectedItem.ToString());
                    int Update2 = controllerObj.UpdateTgSalary(Int32.Parse(textBox1.Text), salary);
                    MessageBox.Show("Tourguide Info updated!");
                }
                else if (textBox3.Text.Length != 0 && textBox2.Text.Length != 0 && comboBox2.SelectedItem == null)
                {
                    int Update = controllerObj.UpdateTgName(Int32.Parse(textBox1.Text), textBox3.Text);
                    int Update1 = controllerObj.UpdateTgPhoneNo(Int32.Parse(textBox1.Text), textBox2.Text);
                    MessageBox.Show("Tourguide Info updated!");
                }
                else if (textBox3.Text.Length != 0 && textBox2.Text.Length == 0 && comboBox2.SelectedItem != null)
                {
                    int Update = controllerObj.UpdateTgName(Int32.Parse(textBox1.Text), textBox3.Text);
                    int Update2 = controllerObj.UpdateTgStatus(Int32.Parse(textBox1.Text), comboBox2.SelectedItem.ToString());
                    int Update4 = controllerObj.UpdateTgSalary(Int32.Parse(textBox1.Text), salary);
                    MessageBox.Show("Tourguide Info updated!");
                }
                else if (textBox3.Text.Length == 0 && textBox2.Text.Length != 0 && comboBox2.SelectedItem != null)
                {
                    int Update1 = controllerObj.UpdateTgPhoneNo(Int32.Parse(textBox1.Text), textBox2.Text);
                    int Update2 = controllerObj.UpdateTgStatus(Int32.Parse(textBox1.Text), comboBox2.SelectedItem.ToString());
                    int Update4 = controllerObj.UpdateTgSalary(Int32.Parse(textBox1.Text), salary);
                    MessageBox.Show("Tourguide Info updated!");
                }
                else if (textBox3.Text.Length != 0 && textBox2.Text.Length != 0 && comboBox2.SelectedItem != null)
                {
                    int Update = controllerObj.UpdateTgName(Int32.Parse(textBox1.Text), textBox3.Text);
                    int Update1 = controllerObj.UpdateTgPhoneNo(Int32.Parse(textBox1.Text), textBox2.Text);
                    int Update2 = controllerObj.UpdateTgStatus(Int32.Parse(textBox1.Text), comboBox2.SelectedItem.ToString());
                    int Update4 = controllerObj.UpdateTgSalary(Int32.Parse(textBox1.Text), salary);

                    MessageBox.Show("Tourguide Info updated!");
                }
            }


        }
    }
}
