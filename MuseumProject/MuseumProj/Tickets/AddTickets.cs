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
    public partial class AddTickets : Form
    {
        private Controller controllerObj;
        private UpdatePrice UpdatePriceObj;

        public AddTickets()
        {
            InitializeComponent();
            controllerObj = new Controller();
            UpdatePriceObj = new UpdatePrice();
            /*UpdatePrice.PriceEgyptianNormal = controllerObj.GetPEN();
            UpdatePrice.PriceEgyptianStudents = controllerObj.GetPES();
            UpdatePrice.PriceForeignerNormal = controllerObj.GetPFN();
            UpdatePrice.PriceForeignerStudents = controllerObj.GetPFS();*/
        }

        private void AddTickets_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int month = (int)DateTime.Now.Month;
            int day = (int)DateTime.Now.Day;
            int ForeignNormal;
            int ForeignStudent;
            int EgyptianNormal;
            int EgyptianStudent;
            int result;
            bool Check0 = Int32.TryParse(textBox1.Text, out result);
            bool Check1 = Int32.TryParse(textBox2.Text, out result);
            bool Check2 = Int32.TryParse(textBox3.Text, out result);
            bool Check3 = Int32.TryParse(textBox4.Text, out result);
            if (textBox1.Text == "")
                Check0 = true;
            if (textBox2.Text == "")
                Check1 = true;
            if (textBox3.Text == "")
                Check2 = true;
            if (textBox4.Text == "")
                Check3 = true;

            if (Check0 && Check1 && Check2 && Check3)
            {
                int PEN = UpdatePrice.PriceEgyptianNormal;
                int PES = UpdatePrice.PriceEgyptianStudents;
                int PFN = UpdatePrice.PriceForeignerNormal;
                int PFS = UpdatePrice.PriceForeignerStudents;
                if (textBox1.Text == "")
                { EgyptianNormal = 0; }
                else { EgyptianNormal = Int32.Parse(textBox1.Text); }
                if (textBox2.Text == "")
                { EgyptianStudent = 0; }
                else { EgyptianStudent = Int32.Parse(textBox2.Text); }
                if (textBox3.Text == "")
                { ForeignNormal = 0; }
                else { ForeignNormal = Int32.Parse(textBox3.Text); }
                if (textBox4.Text == "")
                { ForeignStudent = 0; }
                else { ForeignStudent = Int32.Parse(textBox4.Text); }

                int sum = EgyptianNormal + EgyptianStudent + ForeignNormal + ForeignStudent;
                int price = PEN * EgyptianNormal + PES * EgyptianStudent + PFN * ForeignNormal + PFS * ForeignStudent;

                int PENprice = PEN * EgyptianNormal;
                int PESprice = PES * EgyptianStudent;
                int PFNprice = PFN * ForeignNormal;
                int PFSprice = PFS * ForeignStudent;

                int tt = controllerObj.GetMonthTicket(month);
                if (tt == 0)
                {
                    int tri = controllerObj.AddTickets(month, day, ForeignNormal, ForeignStudent, EgyptianNormal, EgyptianStudent, sum, PESprice, PENprice, PFSprice, PFNprice, price);
                    MessageBox.Show("Tickets Added!");
                }
                else
                {
                    int d = controllerObj.GetDayTicket(day);
                    if (d == 0)
                    {
                        int trip = controllerObj.AddTickets(month, day, ForeignNormal, ForeignStudent, EgyptianNormal, EgyptianStudent, sum, PESprice, PENprice, PFSprice, PFNprice, price);
                        MessageBox.Show("Tickets Added!");
                    }

                    else
                    {
                        int x = controllerObj.GetEgyNormal(month, day);
                        int y = controllerObj.GetEgyStudent(month, day);
                        int z = controllerObj.GetForeignNormal(month, day);
                        int w = controllerObj.GetForeignStudents(month, day);
                        int SumEgyNor = x + EgyptianNormal;
                        int SumEgyStu = y + EgyptianStudent;
                        int SumForNor = z + ForeignNormal;
                        int SumForStu = w + ForeignStudent;
                        int SumAll = SumEgyNor + SumEgyStu + SumForNor + SumForStu;
                        
                        int PENp = controllerObj.GetPriceEgyNomal(month, day) + PENprice;
                        int PESp = controllerObj.GetPriceEgyStudent(month, day) + PESprice;
                        int PFNp = controllerObj.GetPriceForeignNormal(month, day) + PFNprice;
                        int PFSp = controllerObj.GetPriceForeignStudent(month, day) + PFSprice;
                        int total = controllerObj.GetPriceSum(month, day) + price;
                        
                        int up = controllerObj.UpdateTickets(SumEgyNor, SumEgyStu, SumForNor, SumForStu, SumAll, month, day, PENp, PESp, PFNp, PFSp, total);
                        MessageBox.Show("Tickets Updated!");
                    }
                }
            }
            else { MessageBox.Show("You've entered invalid Data"); }
        }
    }
}
