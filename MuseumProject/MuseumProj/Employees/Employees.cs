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
    public partial class Employees : Form
    {
        int formID;
        public Employees(int ID)
        {
            InitializeComponent();
            formID = ID;
        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayEmployees DispEmp = new DisplayEmployees(formID);
            DispEmp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveEmployee RemoveEmp = new RemoveEmployee(formID);
            RemoveEmp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEmployee AddEmp = new AddEmployee(formID);
            AddEmp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateEmployee UpdateEmp = new UpdateEmployee(formID);
            UpdateEmp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AssignShifts AssignShifts = new AssignShifts(formID);
            AssignShifts.Show();
        }
    }
}
