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
    public partial class Statistics : Form
    {
        private Controller controllerObj; // A Reference of type Controller 
        int formID;
        int rank;
        
        public Statistics(int ID)
        {
            formID = ID;
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            rank = controllerObj.CheckPosition(formID);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MonumentsStatistics MStat = new MonumentsStatistics();
            MStat.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeStatistics EmpStat = new EmployeeStatistics(rank);
            EmpStat.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TourguideStatistics TgStat = new TourguideStatistics();
            TgStat.Show();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TicketsStatistics func = new TicketsStatistics();
            func.Show();
        }
    }
}
