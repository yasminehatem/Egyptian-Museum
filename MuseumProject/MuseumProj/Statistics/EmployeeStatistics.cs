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
    public partial class EmployeeStatistics : Form
    {
        private Controller controllerObj; // A Reference of type Controller 
        int formRank;

        public EmployeeStatistics(int rank)
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            formRank = rank;
        }

        private void EmployeeStatistics_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (formRank == 2)
            {
                if (radioButton1.Checked == true)
                {
                    int EmpCount = controllerObj.GetTotalEmps();
                    textBox1.Text = EmpCount.ToString();
                    int EmpMaxSalary = controllerObj.GetEmpMaxSalary();
                    textBox2.Text = EmpMaxSalary.ToString();
                    int EmpMinSalary = controllerObj.GetEmpMinSalary();
                    textBox3.Text = EmpMinSalary.ToString();
                    int EmpAvgSalary = controllerObj.GetEmpAvgSalary();
                    textBox4.Text = EmpAvgSalary.ToString();
                }
                else if (radioButton2.Checked == true)
                {
                    int EmpCount = controllerObj.GetTotalMaleEmps();
                    textBox1.Text = EmpCount.ToString();
                    int EmpMaxSalary = controllerObj.GetEmpMaleMaxSalary();
                    textBox2.Text = EmpMaxSalary.ToString();
                    int EmpMinSalary = controllerObj.GetEmpMaleMinSalary();
                    textBox3.Text = EmpMinSalary.ToString();
                    int EmpAvgSalary = controllerObj.GetEmpMaleAvgSalary();
                    textBox4.Text = EmpAvgSalary.ToString();
                }
                else if (radioButton3.Checked == true)
                {
                    int EmpCount = controllerObj.GetTotalFemaleEmps();
                    textBox1.Text = EmpCount.ToString();
                    int EmpMaxSalary = controllerObj.GetEmpFemaleMaxSalary();
                    textBox2.Text = EmpMaxSalary.ToString();
                    int EmpMinSalary = controllerObj.GetEmpFemaleMinSalary();
                    textBox3.Text = EmpMinSalary.ToString();
                    int EmpAvgSalary = controllerObj.GetEmpFemaleAvgSalary();
                    textBox4.Text = EmpAvgSalary.ToString();   
                }
            }
            else if (formRank == 3)
            {
                if (radioButton1.Checked == true)
                {
                    int EmpCount = controllerObj.GetTotalEmps1();
                    textBox1.Text = EmpCount.ToString();
                    int EmpMaxSalary = controllerObj.GetEmpMaxSalary1();
                    textBox2.Text = EmpMaxSalary.ToString();
                    int EmpMinSalary = controllerObj.GetEmpMinSalary1();
                    textBox3.Text = EmpMinSalary.ToString();
                    int EmpAvgSalary = controllerObj.GetEmpAvgSalary1();
                    textBox4.Text = EmpAvgSalary.ToString();
                }
                else if (radioButton2.Checked == true)
                {
                    int EmpCount = controllerObj.GetTotalMaleEmps1();
                    textBox1.Text = EmpCount.ToString();
                    int EmpMaxSalary = controllerObj.GetEmpMaleMaxSalary1();
                    textBox2.Text = EmpMaxSalary.ToString();
                    int EmpMinSalary = controllerObj.GetEmpMaleMinSalary1();
                    textBox3.Text = EmpMinSalary.ToString();
                    int EmpAvgSalary = controllerObj.GetEmpMaleAvgSalary1();
                    textBox4.Text = EmpAvgSalary.ToString();
                }
                else if (radioButton3.Checked == true)
                {
                    int EmpCount = controllerObj.GetTotalFemaleEmps1();
                    textBox1.Text = EmpCount.ToString();
                    int EmpMaxSalary = controllerObj.GetEmpFemaleMaxSalary1();
                    textBox2.Text = EmpMaxSalary.ToString();
                    int EmpMinSalary = controllerObj.GetEmpFemaleMinSalary1();
                    textBox3.Text = EmpMinSalary.ToString();
                    int EmpAvgSalary = controllerObj.GetEmpFemaleAvgSalary1();
                    textBox4.Text = EmpAvgSalary.ToString();
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (formRank == 2)
            {
                DataTable dt = controllerObj.SelectEmpJobStatistics1();
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            else if (formRank == 3)
            {
                DataTable dt = controllerObj.SelectEmpJobStatistics2();
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
        }
    }
}
