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
    public partial class ManagerMainMenu : Form
    {
        int formID;
        public ManagerMainMenu(int ID)
        {
            InitializeComponent();
            formID = ID;
        }

        private void myShiftsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ManagerMainMenu_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void myInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyInfo info = new MyInfo(formID);
            info.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to log out?",
            "Log out",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Monuments monum = new Monuments();
            monum.Show();
        }

        private void updateAccountInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeAccountInfo cai = new ChangeAccountInfo(formID);
            cai.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees(formID);
            emp.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Tourguides TourGuides = new Tourguides();
            TourGuides.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Statistics Statistics = new Statistics(formID);
            Statistics.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Maintenance func = new Maintenance();
            func.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Transfer func = new Transfer();
            func.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trips func = new Trips();
            func.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tickets ti = new Tickets();
            ti.Show();
        }
    }
}
