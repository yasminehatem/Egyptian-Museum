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
    public partial class CheckPassword : Form
    {
        private Controller controllerObj; // A Reference of type Controller 
        int ID;
        string username;
        string password;
        public CheckPassword(int newID, string newusername, string newpassword)
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            label1.Hide();
            ID = newID;
            username = newusername;
            password = newpassword;
        }

        private void CheckPassword_Load(object sender, EventArgs e)
        {

        }

        private void TxtBx_username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                if (textBox1.Text != textBox2.Text)
                {
                    label1.Text = "Passwords don't match";
                    label1.Show();
                }
                else
                {
                    label1.Hide();
                }
            }
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please enter your password!");
            }
            else if (textBox1.Text.Length < 8)
            {
                label1.Text = "Password must be at least 8 chars.";
                label1.Show();
            }
            else if (controllerObj.CheckPassword(ID, textBox1.Text) == null)
            {
                label1.Text = "Password is incorrect";
                label1.Show();
            }
            else if (textBox1.Text != textBox2.Text)
            {
                label1.Text = "Passwords don't match";
                label1.Show();
            }
            else
            {
                if (username != null && password != null)
                {
                    int a = controllerObj.UpdateUsername(ID, username);
                    int b = controllerObj.UpdatePassword(ID, password);
                    MessageBox.Show("Account Info updated!");
                }
                else if (password != null)
                {
                    int a = controllerObj.UpdatePassword(ID, password);
                    MessageBox.Show("Account Info updated!");
                }
                else if (username != null)
                {
                    int a = controllerObj.UpdateUsername(ID, username);
                    MessageBox.Show("Account Info updated!");
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                if (textBox1.Text.Length < 8)
                {
                    label1.Text = "Password must be at least 8 chars.";
                    label1.Show();
                }
                else if (controllerObj.CheckPassword(ID, textBox1.Text) == null)
                {
                    label1.Text = "Password is incorrect";
                    label1.Show();
                }
                else
                {
                    label1.Hide();
                }
            }
        }
    }
}
