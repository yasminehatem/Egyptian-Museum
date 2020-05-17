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
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTickets func = new AddTickets();
            func.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdatePrice func = new UpdatePrice();
            func.Show();
        }

        private void Tickets_Load(object sender, EventArgs e)
        {

        }
    }
}
