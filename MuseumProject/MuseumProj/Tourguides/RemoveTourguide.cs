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
    public partial class RemoveTourguide : Form
    {
        private Controller controllerObj; // A Reference of type Controller 

        public RemoveTourguide()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            label1.Hide();
            label2.Hide();
            textBox2.UseSystemPasswordChar = false;
            
        }

        private void RemoveTourguide_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please fill all items!");
            }
            else if (controllerObj.CheckTourguideID(Int32.Parse(textBox1.Text)) == false)
            {
                label1.Text = "ID doesn't exist";
                label1.Show();
                label2.Hide();
            }
            else if (controllerObj.CheckTourguideName(textBox2.Text, Int32.Parse(textBox1.Text)) == false)
            {
                label2.Text = "ID and Name don't match";
                label2.Show();
                label1.Hide();
            }
            else
            {
                label1.Hide();
                label2.Hide();
                DialogResult res = MessageBox.Show("Are you sure you want to remove Tourguide?",
                "Remove Tourguide",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    int insert = controllerObj.InsertPastTourguide(Int32.Parse(textBox1.Text), textBox2.Text);
                    int DeleteTg = controllerObj.DeleteTourguide(Int32.Parse(textBox1.Text), textBox2.Text);
                    if (insert == 0 && DeleteTg == 0)
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
    }
}
