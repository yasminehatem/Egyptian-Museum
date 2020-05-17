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
    public partial class DisplayEmployees : Form
    {
        private Controller controllerObj; // A Reference of type Controller 
        int formID;
        int rank;
        public DisplayEmployees(int ID)
        {
            formID = ID;
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            rank = controllerObj.CheckPosition(formID);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectCurrentEmployees(rank);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectPastEmployees(rank);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void DisplayEmployees_Load(object sender, EventArgs e)
        {

        }
    }
}
