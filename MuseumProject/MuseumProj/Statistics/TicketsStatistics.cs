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
    public partial class TicketsStatistics : Form
    {
        private Controller controllerObj;

        int MaxMonth;
        int MaxDay;
        int MaxYear;

        int MinMonth;
        int MinDay;
        int MinYear;

        public TicketsStatistics()
        {
            InitializeComponent();
            controllerObj = new Controller();
            this.comboBox1.Items.AddRange(new object[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            this.comboBox3.Items.AddRange(new object[] { "2018", "2017", "2016" });
            this.comboBox4.Items.AddRange(new object[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            this.comboBox6.Items.AddRange(new object[] { "2018", "2017", "2016" });
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int s = 0;
            if (comboBox1.Text == "January")
            { s = 1; }
            else if (comboBox1.Text == "February")
            { s = 2; }
            else if (comboBox1.Text == "March")
            { s = 3; }
            else if (comboBox1.Text == "April")
            { s = 4; }
            else if (comboBox1.Text == "May")
            { s = 5; }
            else if (comboBox1.Text == "June")
            { s = 6; }
            else if (comboBox1.Text == "July")
            { s = 7; }
            else if (comboBox1.Text == "August")
            { s = 8; }
            else if (comboBox1.Text == "September")
            { s = 9; }
            else if (comboBox1.Text == "October")
            { s = 10; }
            else if (comboBox1.Text == "November")
            { s = 11; }
            else if (comboBox1.Text == "December")
            { s = 12; }
            int g = 0;
            if (comboBox4.Text == "January")
            { g = 1; }
            else if (comboBox4.Text == "February")
            { g = 2; }
            else if (comboBox4.Text == "March")
            { g = 3; }
            else if (comboBox4.Text == "April")
            { g = 4; }
            else if (comboBox4.Text == "May")
            { g = 5; }
            else if (comboBox4.Text == "June")
            { g = 6; }
            else if (comboBox4.Text == "July")
            { g = 7; }
            else if (comboBox4.Text == "August")
            { g = 8; }
            else if (comboBox4.Text == "September")
            { g = 9; }
            else if (comboBox4.Text == "October")
            { g = 10; }
            else if (comboBox4.Text == "November")
            { g = 11; }
            else if (comboBox4.Text == "December")
            { g = 12; }

            int month1 = s;
            int year1;
            bool check1 = int.TryParse(comboBox3.Text, out year1);

            int month2 = g;
            int year2;
            bool check2 = int.TryParse(comboBox6.Text, out year2);

            if (comboBox1.Text == "Month" && comboBox3.Text == "Year" && comboBox4.Text == "Month" && comboBox6.Text == "Year")
            {
                int SumEgypNo = controllerObj.GetTotalEnNo() + controllerObj.GetTotalEsNo();
                int TotalPriceE = controllerObj.GetTotalEnPrice() + controllerObj.GetTotalEsPrice();
                int SumFNo = controllerObj.GetTotalFnNo() + controllerObj.GetTotalFsNo();
                int TotalPriceF = controllerObj.GetTotalFnPrice() + controllerObj.GetTotalFsPrice();

                int sumNo = controllerObj.GetTotalTicketsNo();
                int TotalPrice = controllerObj.GetTotalTicketPrice();

                textBox4.Text = SumEgypNo.ToString();
                textBox1.Text = TotalPriceE.ToString();

                textBox2.Text = SumFNo.ToString();
                textBox3.Text = TotalPriceF.ToString();

                textBox6.Text = sumNo.ToString();
                textBox5.Text = TotalPrice.ToString();

                MaxMonth = controllerObj.GetMaxTicketSalesDateMonth();
                MaxDay = controllerObj.GetMaxTicketSalesDateDay();
                MaxYear = controllerObj.GetMaxTicketSalesDateYear();

                MinMonth = controllerObj.GetMinTicketSalesDateMonth();
                MinDay = controllerObj.GetMinTicketSalesDateDay(); 
                MinYear = controllerObj.GetMinTicketSalesDateYear();   

                label8.Text = controllerObj.GetMaxTicketSalesDateMonth().ToString() + "-" + controllerObj.GetMaxTicketSalesDateDay().ToString() + "-" + controllerObj.GetMaxTicketSalesDateYear().ToString();
                label9.Text = controllerObj.GetMinTicketSalesDateMonth().ToString() + "-" + controllerObj.GetMinTicketSalesDateDay().ToString() + "-" + controllerObj.GetMinTicketSalesDateYear().ToString();

                int AvgSales = controllerObj.GetAvgTicketSales();
                textBox7.Text = AvgSales.ToString();
            }

            else if ((comboBox1.Text != "Month" && comboBox3.Text != "Year") && (comboBox4.Text == "Month" && comboBox6.Text == "Year"))
            {
                MessageBox.Show("Please fill the second date!");
            }
            else if ((comboBox1.Text != "Month" && comboBox3.Text != "Year") && (comboBox4.Text != "Month" && comboBox6.Text != "Year")&& s >= g && year1 >= year2)
            {
                MessageBox.Show("Invalid range is entered!");
            }
            else if ((comboBox1.Text != "Month" && comboBox3.Text != "Year") && (comboBox4.Text != "Month" && comboBox6.Text != "Year")&& s<g && year1<=year2)
            {
                int SumEgypNo = controllerObj.GetTotalEnNo2(month1, year1, month2, year2) + controllerObj.GetTotalEsNo2(month1, year1, month2, year2);
                int TotalPriceE = controllerObj.GetTotalEnPrice2(month1, year1, month2, year2) + controllerObj.GetTotalEsPrice2(month1, year1, month2, year2);
                int SumFNo = controllerObj.GetTotalFnNo2(month1, year1, month2, year2) + controllerObj.GetTotalFsNo2(month1, year1, month2, year2);
                int TotalPriceF = controllerObj.GetTotalFnPrice2(month1, year1, month2, year2) + controllerObj.GetTotalFsPrice2(month1, year1, month2, year2);

                int sumNo = controllerObj.GetTotalTicketsNo2(month1, year1, month2, year2);
                int TotalPrice = controllerObj.GetTotalTicketPrice2(month1, year1, month2, year2);

                textBox4.Text = SumEgypNo.ToString();
                textBox1.Text = TotalPriceE.ToString();

                textBox2.Text = SumFNo.ToString();
                textBox3.Text = TotalPriceF.ToString();

                textBox6.Text = sumNo.ToString();
                textBox5.Text = TotalPrice.ToString();

                MaxMonth = controllerObj.GetMaxTicketSalesDateMonth2(month1, year1, month2,  year2);
                MaxDay = controllerObj.GetMaxTicketSalesDateDay2(month1, year1, month2,  year2);
                MaxYear = controllerObj.GetMaxTicketSalesDateYear2(month1, year1, month2, year2);

                MinMonth = controllerObj.GetMinTicketSalesDateMonth2(month1, year1, month2, year2);
                MinDay = controllerObj.GetMinTicketSalesDateDay2(month1, year1, month2, year2);
                MinYear = controllerObj.GetMinTicketSalesDateYear2(month1, year1, month2, year2);

                label8.Text = MaxMonth.ToString() + "-" + MaxDay.ToString() + "-" + MaxYear.ToString();
                label9.Text = MinMonth.ToString() + "-" + MinDay.ToString() + "-" + MinYear.ToString();

                int AvgSales = controllerObj.GetAvgTicketSales2(month1, year1, month2, year2);
                textBox7.Text = AvgSales.ToString();
            } 
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            ShowDayTicketStatistics func = new ShowDayTicketStatistics(MaxMonth, MaxDay, MaxYear);
            func.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            ShowDayTicketStatistics func = new ShowDayTicketStatistics(MinMonth, MinDay, MinYear);
            func.Show();
        }

        private void TicketsStatistics_Load(object sender, EventArgs e)
        {

        }
    }
}
