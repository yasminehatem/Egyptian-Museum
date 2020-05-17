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
    public partial class Maintenance : Form
    {
        int POID;
        int Cno;
        int PID;
        bool dg;
        int mid;
  
        private Controller controllerObj;
        
        public Maintenance()
        {
            InitializeComponent();
            controllerObj = new Controller();
            timer1.Start();
            dataGridView1.Hide();
            label1.Hide();
            label2.Hide();
            label4.Hide();
            label6.Hide();
            label7.Hide();
            textBox3.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox4.Hide();
            textBox5.Hide();
            label5.Hide();
           
            button1.Hide();
        }

        private void Maintenance_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            label5.Hide();
            label4.Text = "Pieces Previously Maintained";
            label4.Show();

            DataTable dt = controllerObj.SelectPiecePM();
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            dataGridView1.Refresh();

            label1.Hide();
            label2.Hide();
            label6.Hide();
            label7.Hide();

            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox5.Hide();

            button1.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label5.Hide();
            label4.Text = "Pieces Currently Under Maintenance";
            label4.Show();

            DataTable dt = controllerObj.SelectPieceUM();
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            dataGridView1.Refresh();

            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox5.Hide();

            label1.Hide();
            label2.Hide();
            label6.Hide();
            label7.Hide();

            button1.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label5.Hide();
            label4.Text = "Pieces under maintenance, To end a piece's maintenance fill the following data:";
            label4.Show();

            DataTable dt = controllerObj.SelectPieceUM();
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            dataGridView1.Refresh();

            textBox5.Show();
            label7.Show();
            label1.Show();
            label2.Show();
            label6.Show();

            textBox3.Show();
            textBox1.Show();
            textBox2.Show();
            button1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int parsedValue;
           
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No pieces are under maintenance!");
            }
            else if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox5.Text.Length == 0)
            {
                MessageBox.Show("Please fill all items!");
               
            }
            else if (!int.TryParse(textBox1.Text, out parsedValue) || !int.TryParse(textBox2.Text, out parsedValue) || !int.TryParse(textBox3.Text, out parsedValue) || !int.TryParse(textBox5.Text, out parsedValue))
            {
                MessageBox.Show("This is a number only field");
            
            }
            else if (controllerObj.CheckMaintValid(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox5.Text)) == false)//check if entered order id doeasnt match the current customer 
            {
                MessageBox.Show("the transfer id doesnt match the chosen piece data");
             
            } 
            else
            {
                POID = int.Parse(textBox1.Text);
                Cno = int.Parse(textBox2.Text);
                PID = int.Parse(textBox3.Text);
                mid = int.Parse(textBox5.Text);
                bool CheckStatusT = controllerObj.CheckPieceStatusD(POID);
                if (CheckStatusT)
                { 
                    MessageBox.Show("Sorry piece is on already on display!"); 
                }
                else
                {
                    int a = controllerObj.UpdateEndMaint1(POID);
                    int b = controllerObj.UpdateEndMaint2(Cno, PID);
                    int c = controllerObj.UpdateEndDate(textBox4.Text, mid);
                    MessageBox.Show("Maintenance ended Successfully, Piece is on-display again!");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            DateTime dt = DateTime.Now;//get the current date of the machne
            this.textBox4.Text = dt.ToShortDateString();//show the current
        }

        private void Maintenance_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Hide();
            int parsedValue;
            if (!int.TryParse(textBox1.Text, out parsedValue) && textBox1.Text != "")
            {
                label5.Text = "This is a number only field";
                label5.Show();
                return;
            }
            { label5.Hide(); }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Hide();
            int parsedValue;
            if (!int.TryParse(textBox2.Text, out parsedValue) && textBox2.Text != "")
            {
                label5.Text = "This is a number only field";
                label5.Show();
                return;
            }
            { label5.Hide(); }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label5.Hide();
            int parsedValue;
            if (!int.TryParse(textBox3.Text, out parsedValue) && textBox3.Text != "")
            {
                label5.Text = "This is a number only field";
                label5.Show();
                return;
            }
            { label5.Hide(); }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label5.Hide();
            int parsedValue;
            if (!int.TryParse(textBox5.Text, out parsedValue) && textBox5.Text != "")
            {
                label5.Text = "This is a number only field";
                label5.Show();
                return;
            }
            { label5.Hide(); }

        }
    }
}
