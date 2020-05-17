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
    public partial class ShowDayTicketStatistics : Form
    {
        private Controller controllerObj;

        int FormMonth;
        int FormDay;
        int FormYear;

        public ShowDayTicketStatistics(int month, int day, int year)
        {
            InitializeComponent();
            controllerObj = new Controller();
            FormMonth = month;
            FormDay = day;
            FormYear = year;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ShowDayTicketStatistics_Load(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectTicketSalesDate(FormMonth, FormDay, FormYear);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }
    }
}
