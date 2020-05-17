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
    public partial class Transfer : Form
    {
        private Controller controllerObj;

        public Transfer()
        {
            InitializeComponent();
            controllerObj = new Controller();
            dataGridView1.Hide();
            label1.Hide();
            button6.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            textBox4.Hide();
            textBox3.Hide();
            textBox2.Hide();
            textBox1.Hide();
            label6.Hide();
        }

        private void Transfer_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            button6.Hide();
            textBox4.Hide();
            textBox3.Hide();
            textBox2.Hide();
            textBox1.Hide();
            label6.Hide();
            label1.Show();
            label1.Text = "Egyptian Museum Pieces In-Transfer now";
            DateTime d = DateTime.Now;
            string start = d.ToString("yyyy-MM-dd");
            DataTable dt = controllerObj.SelectMyPieceT(start);
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            dataGridView1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            button6.Hide();
            textBox4.Hide();
            textBox3.Hide();
            textBox2.Hide();
            textBox1.Hide();
            label6.Hide();
            label1.Show();
            label1.Text = "Egyptian Museum Pieces Previously In-Transfer";
            DataTable dt = controllerObj.ShowPT();
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            button6.Hide();
            textBox4.Hide();
            textBox3.Hide();
            textBox2.Hide();
            textBox1.Hide();
            label6.Hide();
            label1.Show();
            label1.Text = "External Pieces In The Egyptian Museum now";
            DateTime d = DateTime.Now;
            string start = d.ToString("yyyy-MM-dd");
            DataTable dt = controllerObj.SelectPieceL(start);
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            button6.Show();
            label1.Show();
        
            textBox4.Show();
            textBox3.Show();
            textBox2.Show();
            textBox1.Show();

            label1.Text = "A transfer from The Egyptian Museum Transfer ending today, please enter the following data:";
            DateTime d = DateTime.Now;
            string start = d.ToString("yyyy-MM-dd");
            DataTable dt = controllerObj.EndMyTransfer(start);
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransferFrom func = new TransferFrom();
            func.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("no pieces are to end transfer today !");
            }
            else if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0||textBox4.Text.Length==0)
            {
                MessageBox.Show("Please fill all items!");
            }
          
            else if (!int.TryParse(textBox1.Text, out parsedValue) || !int.TryParse(textBox2.Text, out parsedValue) || !int.TryParse(textBox3.Text, out parsedValue) || !int.TryParse(textBox4.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
                
            }

            else if (controllerObj.CheckTransferTo(int.Parse(textBox1.Text), int.Parse(textBox4.Text), int.Parse(textBox3.Text), int.Parse(textBox2.Text)) == false)//check if entered order id doeasnt match the current customer 
            {
                MessageBox.Show("the transfer id doesnt match the chosen piece data");
                return;
            }   
            else
            {
                int POID = int.Parse(textBox1.Text);
                int PID = int.Parse(textBox2.Text);
                int Cno = int.Parse(textBox3.Text);
                int tid = int.Parse(textBox4.Text);
                //string sdate = controllerObj.GetTStartDate(tid);
                //string edate = controllerObj.GetTEndDate(tid);
                string lp = controllerObj.GetLoanPlace(tid);
                int p = controllerObj.GetPeriod(tid);
                string title = controllerObj.GetPieceTitle(Cno, PID);
                bool CheckStatusT = controllerObj.CheckPieceStatusD(POID);
                if (CheckStatusT)
                { MessageBox.Show("Sorry piece is on already on display"); }
                else
                {
                    int a = controllerObj.UpdateEndMaint1(POID);
                    int b = controllerObj.UpdateEndMaint2(Cno, PID);
                    //insert l awl
                    int d = controllerObj.InsertPtransfer(title, lp, Cno, p);
                    int c = controllerObj.DeleteLoanTo(tid);
                    MessageBox.Show("piece on display again!");
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label6.Hide();
            int parsedValue;
            if (!int.TryParse(textBox4.Text, out parsedValue) &&textBox4.Text!="")
                {
                    label6.Show();
                label6.Text="This is a number only field";
                label6.Show();
                return;
            }
            else
                { label6.Hide(); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label6.Hide();
            int parsedValue;
            if (!int.TryParse(textBox1.Text, out parsedValue) && textBox1.Text != "")
            {
                label6.Text = "This is a number only field";
                label6.Show();
                return;
            }
            { label6.Hide(); }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Hide();
            int parsedValue;
            if (!int.TryParse(textBox2.Text, out parsedValue) && textBox2.Text != "")
            {
                label6.Text = "This is a number only field";
                label6.Show();
                return;
            }
            { label6.Hide(); }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label6.Hide();
            int parsedValue;
            if (!int.TryParse(textBox3.Text, out parsedValue) && textBox3.Text != "")
            {
                label6.Text = "This is a number only field";
                label6.Show();
                return;
            }
            else
            { label6.Hide(); }

        }
    }
}
