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
    public partial class Trips : Form
    {
        public Trips()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayTrips func = new DisplayTrips();
            func.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddTrip func = new AddTrip();
            func.Show();
        }
    }
}
