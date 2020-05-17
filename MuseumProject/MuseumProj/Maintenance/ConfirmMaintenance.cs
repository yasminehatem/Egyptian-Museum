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
    public partial class ConfirmMaintenance : Form
    {
        private bool button1WasClicked = false;
        int CatNo;//create variables to save the parameters passed in them
        int opid;
        int ID;
        string Title;
        int mid = AddMaintenance.MID;
        string date;
        string Type;
        private Controller controllerObj;

        public ConfirmMaintenance(int Catno, string title, int opieceid, int id, string type)
        {
            CatNo = Catno;
            Title = title;
            opid = opieceid;
            ID = id;
            Type = type;
            
            InitializeComponent();
            controllerObj = new Controller();
            timer1.Start();// the time reader operates      
        }

        private void ConfirmMaintenance_Load(object sender, EventArgs e)
        {
            AddMaintenance.MID = mid++; //count how many maintenance last done to generate new id
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;

            int c = controllerObj.InsertMaintenance(mid, CatNo, Title, opid, ID, Type, date, "");
            int a = controllerObj.UpdateMaint1(opid);
            int b = controllerObj.UpdateMaint2(CatNo, ID);
            MessageBox.Show("Maintenance done!");

            Hide();//hide while confirming
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;//get the current date of the machne
            this.textBox1.Text = dt.ToShortDateString();//show the current
            date = textBox1.Text;
        }

        private void ConfirmMaintenance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button1WasClicked == false)
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("Please confirm ?", "you didnt confirm your order",
                   MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = false;// if he doeanst want to confirm than hide
                    Hide();
                }

                else
                    e.Cancel = true;//if he forgot to confirm than confirm again

            }
        }
    }
}
