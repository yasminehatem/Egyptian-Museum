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
    public partial class DisplayShifts : Form
    {
        private Controller controllerObj;
        int formID;
        public DisplayShifts(int ID)
        {
            InitializeComponent();
            controllerObj = new Controller();
            formID = ID;
            if (controllerObj.GetShift(formID) == 1)
            {
                label7.Text = "Sunday - Thursday";
                label8.Text = "9:00 am - 5:00 pm";
            }
            else if (controllerObj.GetShift(formID) == 2)
            {
                label7.Text = "Friday - Tuesday";
                label8.Text = "9:00 am - 5:00 pm";
            }
            else if (controllerObj.GetShift(formID) == 3)
            {
                label7.Text = "Sunday - Thursday";
                label8.Text = "5:00 pm - 1:00 am";
            }
            else if (controllerObj.GetShift(formID) == 4)
            {
                label7.Text = "Friday - Tuesday";
                label8.Text = "5:00 pm - 1:00 am";
            }
            else if (controllerObj.GetShift(formID) == 5)
            {
                label7.Text = "Sunday - Thursday";
                label8.Text = "1:00 am - 9:00 am";
            }
            else if (controllerObj.GetShift(formID) == 6)
            {
                label7.Text = "Friday - Tuesday";
                label8.Text = "1:00 am - 9:00 am";
            }
        }

        private void DisplayShifts_Load(object sender, EventArgs e)
        {

        }
    }
}
