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
    public partial class Monuments : Form
    {
        public Monuments()
        {
            InitializeComponent();
        }

        private void Era_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Prehistoric pre = new Prehistoric();
            pre.Show();
        }

        private void Monuments_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewKingdom nk = new NewKingdom();
            nk.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EarlyAges ea = new EarlyAges();
            ea.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OldKingdom ok = new OldKingdom();
            ok.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MiddleKingdom mk = new MiddleKingdom();
            mk.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LatePeriod lp = new LatePeriod();
            lp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddMonument am = new AddMonument();
            am.Show();
        }
    }
}
