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
    public partial class AddMonument : Form
    {
        private Controller controllerObj; // A Reference of type Controller 
        int ID = Menu00.ID;
       
        public AddMonument()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            for (int i = 0; i <= 31; i++)
            {
                string[] numbers = { i.ToString() };
                comboBox1.Items.AddRange(numbers);
            }
            comboBox2.Items.Add("On-Display");
            comboBox2.Items.Add("Under-Maintenance");
            comboBox2.Items.Add("In-Transfer");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void AddMonument_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
              
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = open.FileName;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox3.TextLength != 0 && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            { 

                int CategoryNo = 0;
                if (Int32.Parse(comboBox1.SelectedItem.ToString()) == 0)
                {
                    CategoryNo = 1;
                }
                else if (Int32.Parse(comboBox1.SelectedItem.ToString()) == 1 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 2)
                {
                    CategoryNo = 2;
                }
                else if (Int32.Parse(comboBox1.SelectedItem.ToString()) == 3 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 4 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 5 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 6 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 7 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 8 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 9 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 10)
                {
                    CategoryNo = 3;
                }
                else if (Int32.Parse(comboBox1.SelectedItem.ToString()) == 11 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 12 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 13 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 14 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 15 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 16 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 17)
                {
                    CategoryNo = 4;
                }
                else if (Int32.Parse(comboBox1.SelectedItem.ToString()) == 18 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 19 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 20 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 21 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 22 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 23 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 24 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 25)
                {
                    CategoryNo = 5;
                }
                else if (Int32.Parse(comboBox1.SelectedItem.ToString()) == 26 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 27 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 28 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 29 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 30 || Int32.Parse(comboBox1.SelectedItem.ToString()) == 31)
                {
                    CategoryNo = 6;
                }

                Menu00.ID = ID++;
                int a = controllerObj.InsertPiece(CategoryNo, ID, textBox3.Text, Int32.Parse(comboBox1.SelectedItem.ToString()), textBox4.Text, comboBox2.SelectedItem.ToString(), textBox1.Text, textBox7.Text);
                if (a != 0)
                {
                    MessageBox.Show("Piece successfully added!");
                }
            }
            else
            {
                MessageBox.Show("Please fill the required items to add a new piece!");
            
            
            }
        }
    }
}
