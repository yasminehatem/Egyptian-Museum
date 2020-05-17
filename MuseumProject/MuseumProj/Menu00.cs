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
    public partial class Menu00 : Form
    {
        private Controller controllerObj; // A Reference of type Controller 
        public static int ID;

        public Menu00()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            ID = controllerObj.Count(); //starting number of existing customer accounts 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login func = Login.CreateObj();
            func.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();

        }
    }
}
