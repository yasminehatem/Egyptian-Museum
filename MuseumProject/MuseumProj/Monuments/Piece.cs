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
    public partial class Piece : Form
    {
        private Controller controllerObj; // A Reference of type Controller 
        int ID;
        int opid;
        int Category;
        
        public Piece(int category, int PieceID)
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            ID = PieceID;
            Category = category;
            opid = controllerObj.GetOPID(category, PieceID);

            label7.Text = controllerObj.GetPieceTitle(category, ID);
            label8.Text = controllerObj.GetPieceDynasty(category, ID).ToString();
            label9.Text = controllerObj.GetPieceMaterial(category, ID);
            label10.Text = controllerObj.GetPieceStatus(category, ID);
            label11.Text = controllerObj.GetPieceDescription(category, ID);
            if (controllerObj.GetPieceImage(category, ID) != "")
            {
                pictureBox2.Image = Image.FromFile(@controllerObj.GetPieceImage(category, ID));
            }
        }

        private void Piece_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool CheckStatusM = controllerObj.CheckPieceStatusM(opid);
            bool CheckStatusT = controllerObj.CheckPieceStatusT(opid);
            if (CheckStatusT)
            { 
                MessageBox.Show("Sorry the piece is in-transfer!"); 
            }
            else if (CheckStatusM)
            { 
                MessageBox.Show("Sorry the piece is already under-maintenance!"); 
            }
            else
            {
                AddMaintenance func = new AddMaintenance(Category, opid, ID);
                func.Show();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool CheckStatusM = controllerObj.CheckPieceStatusM(opid);
            bool CheckStatusT = controllerObj.CheckPieceStatusT(opid);
            if (CheckStatusT)
            { 
                MessageBox.Show("Sorry piece is already in-transfer!"); 
            }
            else if (CheckStatusM)
            { 
                MessageBox.Show("Sorry piece is under-maintenance!"); 
            }
            else
            {
                TransferTo func = new TransferTo(Category, opid, ID);
                func.Show();
            }        
        }
    }
}
