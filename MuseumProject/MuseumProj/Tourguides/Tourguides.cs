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
    public partial class Tourguides : Form
    {
        public Tourguides()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayTourguides DispTg = new DisplayTourguides();
            DispTg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddTourguides AddTg = new AddTourguides();
            AddTg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateTourguides UpdateTg = new UpdateTourguides();
            UpdateTg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveTourguide RemoveTg = new RemoveTourguide();
            RemoveTg.Show();
        }

        private void Tourguides_Load(object sender, EventArgs e)
        {

        }
    }
}
