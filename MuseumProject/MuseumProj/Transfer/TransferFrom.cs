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
    public partial class TransferFrom : Form
    {
        string lp;
        private bool button3WasClicked = false;
        string mname;
        string mcity;
        string mcountry;
        private Controller controllerObj;

        public TransferFrom()
        {
            
            InitializeComponent();
            controllerObj = new Controller();
            comboBox1.DisplayMember = "MuseumName";
            /*for (int i = 1; i <= controllerObj.MuseumCount(); i++)
            {
                comboBox1.Items.Add(controllerObj.MuseumsName(i));
            }*/
            comboBox1.DataSource = controllerObj.MuseumsNameList();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            button4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            //dataGridView1.Hide();
        }

        private void TransferFrom_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            label9.Hide();
            label10.Hide();
            label11.Hide();
            button4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            textBox6.Show();
            textBox4.Show();
            textBox5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label9.Hide();
            label10.Hide();
            label11.Hide();
            button4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            textBox6.Show();
            textBox4.Show();
            textBox5.Show();
            if (textBox6.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0)
            {
                MessageBox.Show("Please fill all items!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[a-zA-Z ]") || !System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "^[a-zA-Z ]") || !System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "^[a-zA-Z ]"))
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
                MessageBox.Show(" " + mname + " museum added to the museums' list!");
                comboBox1.DisplayMember = "MuseumName";
                /*comboBox1.Items.Clear();
                for (int i = 1; i <= controllerObj.MuseumCount(); i++)
                {
                    comboBox1.Items.Add(controllerObj.MuseumsName(i));
                }*/
                comboBox1.DataSource = controllerObj.MuseumsNameList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int parsedValue;
            label9.Hide();
            label10.Hide();
            label11.Hide();
            if (textBox7.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please fill all data!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z ]"))
            {MessageBox.Show("Piece title can only be in alphabetic letter");}
            else if (!int.TryParse(textBox7.Text, out parsedValue))
            {
                MessageBox.Show(" is a number only field");
                
            }
            else
            {
                int period = int.Parse(textBox7.Text);


                DateTime d = DateTime.Now;
                string start = d.ToString("yyyy-MM-dd");

                DateTime dt = DateTime.Now;//get the current date of the machne


                DateTime newDateTime = new DateTime();
                TimeSpan NumberOfDays = new TimeSpan(period, 0, 0, 0, 0);//update six more days to the current date for the delievery
                newDateTime = dt.Add(NumberOfDays);
                string end = newDateTime.ToString("yyyy-MM-dd");



                lp = comboBox1.Text;
                int msid = controllerObj.GetMuseumID(lp);
                string title = textBox2.Text;

                // int tid=TID++;
                int a = controllerObj.InsertLoanFrom(msid, title, lp, start, end, period);

                MessageBox.Show("Transfer added!");
                button3WasClicked = true;
                Hide();//hide while confirming
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Hide();
            label10.Hide();
            label11.Hide();
            lp = comboBox1.Text;

            DataTable dt = controllerObj.ShowMuseumInfo(lp);

            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            dataGridView1.Refresh();
        }

        private void TransferFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            label9.Hide();
            label10.Hide();
            label11.Hide();
            if (button3WasClicked == false)
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("Please confirm ?", "you didnt confirm your loan",
                   MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = false;// if he doeanst want to confirm than hide
                    Hide();
                }

                else
                    e.Cancel = true;//if he forgot to confirm than confirm again

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            label9.Hide();

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "^[a-zA-Z ]") && textBox6.Text != "")
            {
                label9.Show();
                label9.Text = "This is a alphabetic only field";
                label9.Show();
                return;
            }
            else
            { label9.Hide(); }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            label9.Hide();

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "^[a-zA-Z ]") && textBox5.Text != "")
            {
                label9.Show();
                label9.Text = "This is a alphabetic only field";
                label9.Show();
                return;
            }
            else
            { label9.Hide(); }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            label9.Hide();

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[a-zA-Z ]") && textBox4.Text != "")
            {
                label9.Show();
                label9.Text = "This is a alphabetic only field";
                label9.Show();
                return;
            }
            else
            { label9.Hide(); }
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {  label10.Hide();
            label11.Hide();
            label9.Hide();
          
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z ]")&& textBox2.Text!="")
            {
                label10.Show();
                label10.Text = "This is a character only field";
                label10.Show();
                return;
            }
            else
            { label10.Hide(); }
        
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            label9.Hide();
            label10.Hide();
            label11.Hide();
            int parsedValue;
            if (!int.TryParse(textBox7.Text, out parsedValue) && textBox7.Text != "")
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
