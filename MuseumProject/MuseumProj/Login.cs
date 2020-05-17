using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MuseumProj
{
    public partial class Login : Form
    {
        private bool _loggedin = false;
        public static int ID;
        private Controller controllerObj; // A Reference of type Controller 
        // (Initially NULL; NO Controller Object is created yet)
        private static Login Obj = null;
        public static Login CreateObj()
        {
            if (Obj == null)
            { Obj = new Login(); }
            return Obj;
        }

        private Login()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (TxtBx_username.TextLength == 0 && TxtBx_pass.TextLength == 0)
            {
                MessageBox.Show("Please fill the required fields to login!");
            }
            else
            {

                int ID = controllerObj.CheckAccount(TxtBx_username.Text, TxtBx_pass.Text);
                int Position = controllerObj.CheckPosition(ID);
                if (Position == 1) // Successful Login
                {
                    _loggedin = true;
                    EmpMainMenu emp = new EmpMainMenu(ID);
                    emp.Show();
                    TxtBx_pass.Clear();
                    TxtBx_username.Clear();
                    // Hide the Login Form 
                    this.Hide();
                }
                else if (Position == 2 || Position == 3) // Successful Login
                {
                    _loggedin = true;
                    // Create an Object of "Provided_Functionalities" Form and Show it
                    ManagerMainMenu func = new ManagerMainMenu(ID);
                    func.Show();
                    TxtBx_pass.Clear();
                    TxtBx_username.Clear();
                    // Hide the Login Form 
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username or password!");
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void TxtBx_username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
