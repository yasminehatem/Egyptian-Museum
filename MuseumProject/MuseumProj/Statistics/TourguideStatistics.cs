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
    public partial class TourguideStatistics : Form
    {
        private Controller controllerObj; // A Reference of type Controller 

        public TourguideStatistics()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectTgJobStatistics();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            DataTable dt = controllerObj.SelectTgUniStatistics();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                int TgCount = controllerObj.GetTotalTgs();
                textBox1.Text = TgCount.ToString();
            }
            else if (radioButton2.Checked == true)
            {
                int TgCount = controllerObj.GetTotalMaleTg();
                textBox1.Text = TgCount.ToString();
            }
            else if (radioButton3.Checked == true)
            {
                int TgCount = controllerObj.GetTotalFemaleTg();
                textBox1.Text = TgCount.ToString();
            }
        }

        private void TourguideStatistics_Load(object sender, EventArgs e)
        {

        }
    }
}
