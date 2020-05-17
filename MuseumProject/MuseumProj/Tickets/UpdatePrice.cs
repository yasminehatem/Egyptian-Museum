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
    public partial class UpdatePrice : Form
    {
        private Controller controllerObj;
        public static int PriceEgyptianNormal;
        public static int PriceEgyptianStudents;
        public static int PriceForeignerNormal;
        public static int PriceForeignerStudents;

        public UpdatePrice()
        {
            InitializeComponent();
            controllerObj = new Controller();
            PriceEgyptianNormal = controllerObj.GetPEN();
            PriceEgyptianStudents = controllerObj.GetPES();
            PriceForeignerNormal = controllerObj.GetPFN();
            PriceForeignerStudents = controllerObj.GetPFS();
            label8.Hide();
        }

        private void UpdatePrice_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ParsedValue;
           
            if (int.TryParse(textBox1.Text, out ParsedValue) && int.TryParse(textBox2.Text, out ParsedValue) && int.TryParse(textBox3.Text, out ParsedValue) && int.TryParse(textBox4.Text, out ParsedValue))
            {
                int update = controllerObj.UpdatePEN(int.Parse(textBox1.Text));

                int update1 = controllerObj.UpdatePES(int.Parse(textBox2.Text));

                int update2 = controllerObj.UpdatePFN(int.Parse(textBox3.Text));

                int update3 = controllerObj.UpdatePFS(int.Parse(textBox4.Text));
                MessageBox.Show("Tickets Prices Updated!");

            }
            else
            {
                MessageBox.Show("Please enter only numeric values");

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int Result;
            if (Int32.TryParse(this.textBox1.Text, out Result))
            {
                label8.Text = "Valid";
                label8.Show();
            }
            else
            {
                label8.Text = "Field must contain only numeric values";
                label8.Show();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int Result;
            if (Int32.TryParse(this.textBox2.Text, out Result))
            {
                label8.Text = "Valid";
                label8.Show();
            }
            else
            {
                label8.Text = "Field must contain only numeric values";
                label8.Show();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int Result;
            if (Int32.TryParse(this.textBox3.Text, out Result))
            {
                label8.Text = "Valid";
                label8.Show();
            }
            else
            {
                label8.Text = "Field must contain only numeric values";
                label8.Show();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int Result;
            if (Int32.TryParse(this.textBox4.Text, out Result))
            {
                label8.Text = "Valid";
                label8.Show();
            }
            else
            {
                label8.Text = "Field must contain only numeric values";
                label8.Show();
            }
        }
    }
}
