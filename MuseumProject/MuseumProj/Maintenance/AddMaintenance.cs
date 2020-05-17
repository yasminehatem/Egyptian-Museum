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
    public partial class AddMaintenance : Form
    {
        public static int MID;
        int opieceid;
        int ID;
        string Type;
        int CatNo;
        private Controller controllerObj;

        public AddMaintenance(int Cn, int oid, int id)
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
            comboBox1.Items.Add("Clean"); //flll combobox with maintenance type
            comboBox1.Items.Add("Periodic");
            comboBox1.Items.Add("Repair");
            opieceid = oid;
            ID = id;
            CatNo = Cn;
            MID = controllerObj.MaintCount(); //starting number of existing customer accounts
            label3.Text = controllerObj.GetPieceTitle(Cn, id);
        }

        private void AddMaintenance_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;//check if order now clicked without choosing a type
            if (index == -1)
            {
                MessageBox.Show("Please select a type");
                return;
            }
            Type = comboBox1.SelectedItem.ToString();

            ConfirmMaintenance func = new ConfirmMaintenance(CatNo, label3.Text, opieceid, ID, Type);
            func.Show();
        }
    }
}
