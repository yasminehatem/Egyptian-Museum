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
    public partial class AddTrip : Form
    {
        private Controller controllerObj;
        private UpdatePrice UpdatePriceObj;

        int ForeignNormal;
        int ForeignStudent;
        int EgyptianNormal;
        int EgyptianStudent;

        int PEN;
        int PES;
        int PFN;
        int PFS;

        public AddTrip()
        {
            InitializeComponent();
            controllerObj = new Controller();
            UpdatePriceObj = new UpdatePrice();
            this.comboBox1.Items.AddRange(new object[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            this.comboBox3.Items.AddRange(new object[] { "2018" });
            for (int i = 1; i <= controllerObj.OrganizationCount(); i++)
            {
                comboBox4.Items.Add(controllerObj.OrganizationName(i));
            }
            DataTable dt = new DataTable();
            dt = controllerObj.GetTourGuides();
            comboBox5.Items.Clear();
            foreach (DataRow item in dt.Rows)
            {
                comboBox5.Items.Add(item[0].ToString());
            }
            DataTable dat = new DataTable();
            dat = controllerObj.GetHR();
            comboBox6.Items.Clear();
            foreach (DataRow item in dat.Rows)
            {
                comboBox6.Items.Add(item[0].ToString());
            }
            label5.Hide();
            label6.Hide();
            textBox6.Hide();
            textBox7.Hide();
            button8.Hide();

            PEN = UpdatePrice.PriceEgyptianNormal;
            PES = UpdatePrice.PriceEgyptianStudents;
            PFN = UpdatePrice.PriceForeignerNormal;
            PFS = UpdatePrice.PriceForeignerStudents;
        }

        private void AddTrip_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            if ((comboBox1.Text == "January") || (comboBox1.Text == "March") || (comboBox1.Text == "May") || (comboBox1.Text == "July") || (comboBox1.Text == "August") || (comboBox1.Text == "October") || (comboBox1.Text == "December"))
            {
                this.comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" });
            }
            if (comboBox1.Text == "February")
            {
                this.comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28" });
            }
            if ((comboBox1.Text == "April") || (comboBox1.Text == "June") || (comboBox1.Text == "September") || (comboBox1.Text == "November"))
            {
                this.comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" });
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
                    }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label5.Show();
            label6.Show();
            textBox6.Show();
            textBox7.Show();
            button8.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int result;
            bool check1 = Int32.TryParse(textBox6.Text, out result);
            bool check2 = Int32.TryParse(textBox7.Text, out result);
            if (check1==false && check2==false)
            {
                int AddOrg = controllerObj.AddOrganization(textBox7.Text, textBox6.Text);
                if (AddOrg != 0)
                {
                    MessageBox.Show("Organization Added!");
                    comboBox4.Items.Clear();
                    for (int i = 1; i <= controllerObj.OrganizationCount(); i++)
                    {
                        comboBox4.Items.Add(controllerObj.OrganizationName(i));
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter a valid organisation's info");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            if ((comboBox1.Text == "January") || (comboBox1.Text == "March") || (comboBox1.Text == "May") || (comboBox1.Text == "July") || (comboBox1.Text == "August") || (comboBox1.Text == "October") || (comboBox1.Text == "December"))
            {
                this.comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" });
            }
            if (comboBox1.Text == "February")
            {
                this.comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28" });
            }
            if ((comboBox1.Text == "April") || (comboBox1.Text == "June") || (comboBox1.Text == "September") || (comboBox1.Text == "November"))
            {
                this.comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" });
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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
            int month = (int)DateTime.Now.Month;
            int day = (int)DateTime.Now.Day;
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

            if (comboBox1.Text != "Month" && comboBox2.Text != "Days" && comboBox3.Text != "Year" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "") && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "" && Check0 && Check1 && Check2 && Check3)
            {
                if (s > month || (s == month && Int32.Parse(comboBox2.Text) >= day))
                {
                    int ForeignNormal;
                    int ForeignStudent;
                    int EgyptianNormal;
                    int EgyptianStudent;

                    if (textBox1.Text == "")
                    {
                        ForeignNormal = 0;
                    }
                    else { ForeignNormal = Int32.Parse(textBox1.Text); }
                    if (textBox2.Text == "")
                    {
                        EgyptianNormal = 0;
                    }
                    else { EgyptianNormal = Int32.Parse(textBox2.Text); }
                    if (textBox3.Text == "")
                    {
                        ForeignStudent = 0;
                    }
                    else { ForeignStudent = Int32.Parse(textBox3.Text); }
                    if (textBox4.Text == "")
                    {
                        EgyptianStudent = 0;
                    }
                    else { EgyptianStudent = Int32.Parse(textBox4.Text); }

                    int sum = EgyptianNormal + EgyptianStudent + ForeignNormal + ForeignStudent;
                    int price = PEN * EgyptianNormal + PES * EgyptianStudent + PFN * ForeignNormal + PFS * ForeignStudent;

                    int PENprice = PEN * EgyptianNormal;
                    int PESprice = PES * EgyptianStudent;
                    int PFNprice = PFN * ForeignNormal;
                    int PFSprice = PFS * ForeignStudent;


                    if (sum >= 10 && sum <= 100)
                    {
                        int HR_ID = controllerObj.GetHR_ID(comboBox6.Text);
                        int TourGuideID = controllerObj.GetTourGuideID(comboBox5.Text);
                        int t = controllerObj.AddTrip(s, Int32.Parse(comboBox2.Text), 2018, ForeignNormal, ForeignStudent, EgyptianNormal, EgyptianStudent,price,comboBox4.Text, TourGuideID, HR_ID);
                        MessageBox.Show("You've added a new trip!");
                        int tt = controllerObj.GetMonthTicket(s);
                        if (tt == 0)
                        {
                            int tri = controllerObj.AddTickets(s, Int32.Parse(comboBox2.Text), ForeignNormal, ForeignStudent, EgyptianNormal, EgyptianStudent, sum, PESprice, PENprice, PFSprice, PFNprice, price);

                        }
                        else
                        {
                            int d = controllerObj.GetDayTicket(Int32.Parse(comboBox2.Text));
                            if (d == 0)
                            {
                                int trip = controllerObj.AddTickets(s, Int32.Parse(comboBox2.Text), ForeignNormal, ForeignStudent, EgyptianNormal, EgyptianStudent, sum, PESprice, PENprice, PFSprice, PFNprice, price);
                            }
                            else
                            {
                                int x = controllerObj.GetEgyNormal(s, Int32.Parse(comboBox2.Text));
                                int y = controllerObj.GetEgyStudent(s, Int32.Parse(comboBox2.Text));
                                int z = controllerObj.GetForeignNormal(s, Int32.Parse(comboBox2.Text));
                                int w = controllerObj.GetForeignStudents(s, Int32.Parse(comboBox2.Text));
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
                        
                                int up = controllerObj.UpdateTickets(SumEgyNor, SumEgyStu, SumForNor, SumForStu, SumAll, s, Int32.Parse(comboBox2.Text), PENp, PESp, PFNp, PFSp, total);
                            }
                        }
                    }
                    else { MessageBox.Show("Please enter a valid number of people!"); }
                }

                else { MessageBox.Show("Please enter an upcoming date!"); }
            }
            else { MessageBox.Show("Please fill and check all data!"); }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            int number;
            if (Int32.TryParse(this.textBox1.Text, out number))
            {
                if (number >= 10 && number <= 100)
                {
                    label3.Text = "VALID";
                    label3.Show();
                    if (textBox1.Text == "")
                    {
                        ForeignNormal = 0;
                    }
                    else { ForeignNormal = Int32.Parse(textBox1.Text); }
                    if (textBox2.Text == "")
                    {
                        EgyptianNormal = 0;
                    }
                    else { EgyptianNormal = Int32.Parse(textBox2.Text); }
                    if (textBox3.Text == "")
                    {
                        ForeignStudent = 0;
                    }
                    else { ForeignStudent = Int32.Parse(textBox3.Text); }
                    if (textBox4.Text == "")
                    {
                        EgyptianStudent = 0;
                    }
                    else { EgyptianStudent = Int32.Parse(textBox4.Text); }

                    int sum = EgyptianNormal * PEN + EgyptianStudent * PES + ForeignNormal * PFN + ForeignStudent * PFS;
                    textBox5.Text = sum.ToString();
                    textBox5.Refresh();
                }
                else
                {
                    label3.Text = "Number range from 10->100";
                    label3.Show();
                }
            }
            else
            {
                label3.Text = "Invalid Data";
                label3.Show();
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            int number;
            if (Int32.TryParse(this.textBox2.Text, out number))
            {
                if (number >= 10 && number <= 100)
                {
                    label3.Text = "VALID";
                    label3.Show();
                    if (textBox1.Text == "")
                    {
                        ForeignNormal = 0;
                    }
                    else { ForeignNormal = Int32.Parse(textBox1.Text); }
                    if (textBox2.Text == "")
                    {
                        EgyptianNormal = 0;
                    }
                    else { EgyptianNormal = Int32.Parse(textBox2.Text); }
                    if (textBox3.Text == "")
                    {
                        ForeignStudent = 0;
                    }
                    else { ForeignStudent = Int32.Parse(textBox3.Text); }
                    if (textBox4.Text == "")
                    {
                        EgyptianStudent = 0;
                    }
                    else { EgyptianStudent = Int32.Parse(textBox4.Text); }

                    int sum = EgyptianNormal * PEN + EgyptianStudent * PES + ForeignNormal * PFN + ForeignStudent * PFS;
                    textBox5.Text = sum.ToString();
                }
                else
                {
                    label3.Text = "Number range from 10->100";
                    label3.Show();
                }
            }
            else
            {
                label3.Text = "Invalid Data";
                label3.Show();
            }
            
            
         
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            int number;
            if (Int32.TryParse(this.textBox3.Text, out number))
            {
                if (number >= 10 && number <= 100)
                {
                    label3.Text = "VALID";
                    if (textBox1.Text == "")
                    {
                        ForeignNormal = 0;
                    }
                    else { ForeignNormal = Int32.Parse(textBox1.Text); }
                    if (textBox2.Text == "")
                    {
                        EgyptianNormal = 0;
                    }
                    else { EgyptianNormal = Int32.Parse(textBox2.Text); }
                    if (textBox3.Text == "")
                    {
                        ForeignStudent = 0;
                    }
                    else { ForeignStudent = Int32.Parse(textBox3.Text); }
                    if (textBox4.Text == "")
                    {
                        EgyptianStudent = 0;
                    }
                    else { EgyptianStudent = Int32.Parse(textBox4.Text); }

                    int sum = EgyptianNormal * PEN + EgyptianStudent * PES + ForeignNormal * PFN + ForeignStudent * PFS;
                    textBox5.Text = sum.ToString();
                }
                else
                {
                    label3.Text = "Number range from 10->100";
                    label3.Show();
                }
            }
            else
            {
                label3.Text = "Invalid Data";
                label3.Show();
            }

           
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            int number;
            if (Int32.TryParse(this.textBox4.Text, out number))
            {
                if (number >= 10 && number <= 100)
                {
                    label3.Text = "VALID";
                    label3.Show();
                    if (textBox1.Text == "")
                    {
                        ForeignNormal = 0;
                    }
                    else { ForeignNormal = Int32.Parse(textBox1.Text); }
                    if (textBox2.Text == "")
                    {
                        EgyptianNormal = 0;
                    }
                    else { EgyptianNormal = Int32.Parse(textBox2.Text); }
                    if (textBox3.Text == "")
                    {
                        ForeignStudent = 0;
                    }
                    else { ForeignStudent = Int32.Parse(textBox3.Text); }
                    if (textBox4.Text == "")
                    {
                        EgyptianStudent = 0;
                    }
                    else { EgyptianStudent = Int32.Parse(textBox4.Text); }

                    int sum = EgyptianNormal * PEN + EgyptianStudent * PES + ForeignNormal * PFN + ForeignStudent * PFS;
                    textBox5.Text = sum.ToString();
                }
                else
                {
                    label3.Text = "Number range from 10->100";
                    label3.Show();
                }
            }
            else
            {
                label3.Text = "Invalid Data";
                label3.Show();
            }

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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        { 
               
            
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

          
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
