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
    public partial class DisplayTourguides : Form
    {
        private Controller controllerObj; // A Reference of type Controller 

        public DisplayTourguides()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectCurrentTourguides();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectPastTourguides();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}
