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
    public partial class ChangeAccountInfo : Form
    {
        int ID;
        string username;
        string password;
        private Controller controllerObj; // A Reference of type Controller 
        public ChangeAccountInfo(int newID)
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            label1.Hide();
            label2.Hide();
            ID = newID;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                bool CheckUsername = controllerObj.CheckUserName(textBox1.Text);
                if (CheckUsername == true)
                {
                    label1.Text = "Username exists";
                    label1.Show();
                }
                else
                {
                    label1.Hide();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
            {
                if (textBox2.Text.Length < 8)
                {
                    label2.Text = "Password must be at least 8 chars.";
                    label2.Show();
                }
                else if (controllerObj.CheckPassword(ID, textBox2.Text) == textBox2.Text)
                {
                    label2.Text = "This is your current password";
                    label2.Show();
                }
                else
                {
                    label2.Hide();
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool CheckUsername = controllerObj.CheckUserName(textBox1.Text);
            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please enter data to update!");
            }
            else if (controllerObj.CheckPassword(ID, textBox2.Text) == textBox2.Text)
            {
                label2.Text = "This is your current password";
                label2.Show();
            }
            else if (CheckUsername == true)
            {
                label1.Text = "Username exists";
                label1.Show();
            }
            else
            {
                username = textBox1.Text;
                password = textBox2.Text;

                if (textBox1.Text.Length == 0 || textBox1.Text.Length == 1)
                {
                    username = null;
                }
                if (textBox2.Text.Length < 8)
                {
                    password = null;
                }

                CheckPassword cp = new CheckPassword(ID, username, password);
                cp.Show();
            }
        }

        private void ChangeAccountInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
