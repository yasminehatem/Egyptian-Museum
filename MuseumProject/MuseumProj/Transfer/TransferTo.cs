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
    public partial class TransferTo : Form
    {
        private bool button1WasClicked = false;
        int opieceid;
        int ID;
        int CatNo;
        string date;
        string lp;
        string mname;
        string mcity;
        string mcountry;
        private Controller controllerObj;

        public TransferTo(int Cn, int oid, int id)
        {
            InitializeComponent();
            controllerObj = new Controller();
            CatNo = Cn;
            ID = id;
            opieceid = oid;
            comboBox1.DisplayMember = "MuseumName";
            /*for (int i = 1; i <= controllerObj.MuseumCount(); i++)
            {
                comboBox1.Items.Add(controllerObj.MuseumsName(i));
            }*/
            comboBox1.DataSource = controllerObj.MuseumsNameList();

            label3.Text = controllerObj.GetPieceTitle(Cn, id);
            label10.Hide();
            label11.Hide();
            textBox2.Hide();
            textBox7.Hide();
            button4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();

        }

        private void TransferTo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int parsedValue;
            label10.Hide();
            label11.Hide();
            if (textBox6.Text.Length == 0)
            {
                MessageBox.Show("Please fill the period");
                
            }
            else if (!int.TryParse(textBox6.Text, out parsedValue))
            {
                MessageBox.Show(" is a number only field");

            }
            else
            {
                int period = int.Parse(textBox6.Text);

                DateTime d = DateTime.Now;
                string start = d.ToString("yyyy-MM-dd");

                DateTime dt = DateTime.Now; //get the current date of the machine

                DateTime newDateTime = new DateTime();
                TimeSpan NumberOfDays = new TimeSpan(period, 0, 0, 0, 0); //update six more days to the current date for the delievery
                newDateTime = dt.Add(NumberOfDays);
                string end = newDateTime.ToString("yyyy-MM-dd");

                lp = comboBox1.Text;
                int msid = controllerObj.GetMuseumID(lp);

                // int tid=TID++;
                int a = controllerObj.InsertLoanTo(msid, label3.Text, lp, CatNo, opieceid, ID, period, start, end);
                int c = controllerObj.UpdateTransfer1(opieceid);
                int b = controllerObj.UpdateTransfer2(CatNo, ID);
                MessageBox.Show("Transfer done!");
                button1WasClicked = true;
                Hide();//hide while confirming
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            lp = comboBox1.Text;

            DataTable dt = controllerObj.ShowMuseumInfo(lp);

            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            button4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            button4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();
            if (textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0)
            {
                MessageBox.Show("Please fill all items!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[a-zA-Z ]") || !System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[a-zA-Z ]") || !System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("new museum fields only accept alphabetic letters");
            }
            else
            {
                // int Msid = msid++;
                mname = textBox3.Text;
                mcity = textBox4.Text;
                mcountry = textBox5.Text;
                int a = controllerObj.InsertMuseum(mname, mcity, mcountry);
                MessageBox.Show(" " + mname + " museum add to the museum's list!");
                comboBox1.DisplayMember = "MuseumName";
                //comboBox1.Items.Clear();
                /*for (int i = 1; i <= controllerObj.MuseumCount(); i++)
                {
                    comboBox1.Items.Add(controllerObj.MuseumsName(i));
                }*/
                comboBox1.DataSource = controllerObj.MuseumsNameList();
            }
        }

        private void TransferTo_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (button1WasClicked == false)
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("Please confirm ?", "you didnt confirm your transfer order",
                   MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = false;// if he doeanst want to confirm than hide
                    Hide();
                }

                else
                {
                    e.Cancel = true;//if he forgot to confirm than confirm again
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[a-zA-Z ]") && textBox3.Text != "")
            {
                label10.Show();
                label10.Text = "This is a alphabetic only field";
                label10.Show();
                return;
            }
            else
            { label10.Hide(); }

        }

        private void label10_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[a-zA-Z ]") && textBox4.Text != "")
            {
                label10.Show();
                label10.Text = "This is a alphabetic only field";
                label10.Show();
                return;
            }
            else
            { label10.Hide(); }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "^[a-zA-Z ]") && textBox5.Text != "")
            {
                label10.Show();
                label10.Text = "This is a alphabetic only field";
                label10.Show();
                return;
            }
            else
            { label10.Hide(); }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            int parsedValue;
            if (!int.TryParse(textBox6.Text, out parsedValue) && textBox6.Text != "")
            {
                label11.Show();
                label11.Text = "This is a number only field";
                label11.Show();
                return;
            }
            else
            { label11.Hide(); }
        }




    }
}
