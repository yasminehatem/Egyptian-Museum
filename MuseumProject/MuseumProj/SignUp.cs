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
    public partial class SignUp : Form
    {
        private Controller controllerObj; // A Reference of type Controller 
        public SignUp()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 && textBox2.TextLength == 0 && textBox3.TextLength == 0 && textBox4.TextLength == 0 && textBox7.TextLength == 0)
            {
                MessageBox.Show("Please fill the required fields to sign up!");
            }
            else
            {
                //to check for existance of employee
                //1st ID
                bool IDCheck = controllerObj.CheckID(int.Parse(textBox4.Text));
                if (IDCheck == true) //ID does exist
                {
                    //2nd Name
                    bool NameCheck = controllerObj.CheckName(textBox3.Text, int.Parse(textBox4.Text));
                    if (NameCheck == true)
                    {
                        //2nd to check for username previous existance 
                        bool UserNameCheck = controllerObj.CheckUserName(textBox1.Text);
                        if (UserNameCheck == false)
                        {
                            //3rd to check password is over 8 chars
                            if (textBox2.Text.Length >= 8)
                            {
                                //4th to check e-mail is valid with @ 
                                if (textBox7.Text.Contains('@') || String.IsNullOrEmpty(textBox7.Text))
                                {
                                    string email = textBox7.Text;
                                    if (String.IsNullOrEmpty(textBox7.Text) == true)
                                    {
                                        email = "NULL";
                                    }
                                    int a = controllerObj.InsertAccount(int.Parse(textBox4.Text), textBox1.Text, textBox2.Text, email);
                                    MessageBox.Show("You successfully signed-up, Welcome!");
                                    int PositionCheck = controllerObj.CheckPosition(int.Parse(textBox4.Text));
                                    if (PositionCheck == 1)
                                    {
                                        EmpMainMenu emp = new EmpMainMenu(int.Parse(textBox4.Text));
                                        emp.Show(this);
                                        this.Hide();
                                    }
                                    else if (PositionCheck == 1)
                                    {
                                        ManagerMainMenu manager = new ManagerMainMenu(int.Parse(textBox4.Text));
                                        manager.Show(this);
                                        this.Hide();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please check the email you entered!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Password must be at least 8 characters!");
                            }
                        }

                        else
                        {
                            MessageBox.Show("Username already exists, please choose another one!");
                        }
                    }

                    else
                    {
                        MessageBox.Show("Name is incorrect, please try again!");
                    }
                }
                else
                {
                    MessageBox.Show("Please check your ID, either it doesn't exist or you already have an account!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
