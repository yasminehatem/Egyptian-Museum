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
    public partial class RemoveEmployee : Form
    {
        int formID;
        int rank;
        private Controller controllerObj; // A Reference of type Controller 
        public RemoveEmployee(int ID)
        {
            formID = ID;
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            label1.Hide();
            label2.Hide();
            textBox2.UseSystemPasswordChar = false;
            rank = controllerObj.CheckPosition(formID);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please fill all items!");
            }
            else if (controllerObj.CheckID2(Int32.Parse(textBox1.Text)) == false)
            {
                label1.Text = "ID doesn't exist";
                label1.Show();
                label2.Hide();
            }
            else if (controllerObj.CheckPosition(Int32.Parse(textBox1.Text)) == 2)
            {
                if (rank == 2)
                {
                    label1.Text = "You're not authorized to do this action";
                    label1.Show();
                    label2.Hide();
                }
            }
            else if (controllerObj.CheckPosition(Int32.Parse(textBox1.Text)) == 3)
            {
                    label1.Text = "You're not authorized to do this action";
                    label1.Show();
                    label2.Hide();
            }
            else if (controllerObj.CheckName(textBox2.Text, Int32.Parse(textBox1.Text)) == false)
            {
                label2.Text = "ID and Name don't match";
                label2.Show();
                label1.Hide();
            }
            else
            {
                label1.Hide();
                label2.Hide();
                DialogResult res = MessageBox.Show("Are you sure you want to remove Employee?",
                "Remove Employee",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    int insert = controllerObj.InsertPastEmployee(Int32.Parse(textBox1.Text), textBox2.Text);
                    int DeleteEmp = controllerObj.DeleteEmployee(Int32.Parse(textBox1.Text), textBox2.Text);
                    int DeleteAcc = controllerObj.DeleteAccount(Int32.Parse(textBox1.Text), textBox2.Text);
                    if (insert == 0 && DeleteEmp == 0 && DeleteAcc == 0)
                    {
                        MessageBox.Show("Process failed!");
                    }
                    else
                    {
                        MessageBox.Show("Process succeeded!");
                    }
                }
                else
                {

                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RemoveEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
