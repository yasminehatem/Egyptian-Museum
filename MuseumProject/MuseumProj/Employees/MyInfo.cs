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
    public partial class MyInfo : Form
    {
        private Controller controllerObj; // A Reference of type Controller 

        public MyInfo(int ID)
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            label7.Text = controllerObj.GetName(ID);
            label8.Text = ID.ToString();
            if ((controllerObj.GetGender(ID)) == "M")
            {
                label9.Text = "Male";
            }
            else
            {
                label9.Text = "Female";
            }
            label10.Text = (controllerObj.GetPhone(ID)).ToString();
            label11.Text = controllerObj.GetJob(ID);
            label12.Text = (controllerObj.GetSalary(ID)).ToString();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MyInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
