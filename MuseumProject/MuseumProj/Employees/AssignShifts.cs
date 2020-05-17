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
    public partial class AssignShifts : Form
    {
        int formID;
        int rank;
        private Controller controllerObj; // A Reference of type Controller 

        public AssignShifts(int ID)
        {
            formID = ID;
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            rank = controllerObj.CheckPosition(formID);
            label4.Hide();
            label5.Hide();
            label1.Hide();
            label6.Hide();
        }

        private void AssignShifts_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "1")
            {
                label5.Text = "Sunday - Thursday";
                label6.Text = "9:00 am - 5:00 pm";
            }
            else if (comboBox1.SelectedItem.ToString() == "2")
            {
                label5.Text = "Friday - Tuesday";
                label6.Text = "9:00 am - 5:00 pm";
            }
            else if (comboBox1.SelectedItem.ToString() == "3")
            {
                label5.Text = "Sunday - Thursday";
                label6.Text = "5:00 pm - 1:00 am";
            }
            else if (comboBox1.SelectedItem.ToString() == "4")
            {
                label5.Text = "Friday - Tuesday";
                label6.Text = "5:00 pm - 1:00 am";
            }
            else if (comboBox1.SelectedItem.ToString() == "5")
            {
                label5.Text = "Sunday - Thursday";
                label6.Text = "1:00 am - 9:00 am";
            }
            else if (comboBox1.SelectedItem.ToString() == "6")
            {
                label5.Text = "Friday - Tuesday";
                label6.Text = "1:00 am - 9:00 am";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                label4.Hide();
                label1.Text = ("Please enter an ID!");
                label1.Show();
                textBox2.Clear();
                button9.Enabled = false;
            }
            else if (controllerObj.CheckID2(Int32.Parse(textBox1.Text)) == false)
            {
                label1.Hide();
                label4.Text = "ID doesn't exist";
                label4.Show();
                textBox2.Clear();
                button9.Enabled = false;
            }
            else if (controllerObj.CheckPosition(Int32.Parse(textBox1.Text)) == 2)
            {
                if (rank == 2)
                {
                    label4.Hide();
                    label1.Text = "You're not authorized to do this action";
                    label1.Show();
                    textBox2.Clear();
                    button9.Enabled = false;
                }
            }
            else if (controllerObj.CheckPosition(Int32.Parse(textBox1.Text)) == 3)
            {
                label4.Hide();
                label1.Text = "You're not authorized to do this action";
                label1.Show();
                textBox2.Clear();
                button9.Enabled = false;
            }
            else
            {
                button9.Enabled = true;
                textBox2.Clear();
                label1.Hide();
                textBox2.Text = controllerObj.GetJob(Int32.Parse(textBox1.Text));
                if (controllerObj.GetJob(Int32.Parse(textBox1.Text)) == "Security" || controllerObj.GetJob(Int32.Parse(textBox1.Text)) == "Janitor")
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add('1');
                    comboBox1.Items.Add('2');
                    comboBox1.Items.Add('3');
                    comboBox1.Items.Add('4');
                    comboBox1.Items.Add('5');
                    comboBox1.Items.Add('6');
                    label5.Show();
                    label6.Show();
                }

                else
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add('1');
                    comboBox1.Items.Add('2');
                    label5.Show();
                    label6.Show();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                label1.Text = "Please Choose a shift";
                label1.Show();
            }
            else
            {
                int a = controllerObj.UpdateShift(Int32.Parse(textBox1.Text), Int32.Parse(comboBox1.SelectedItem.ToString()));
                MessageBox.Show("Shift updated successfully!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
