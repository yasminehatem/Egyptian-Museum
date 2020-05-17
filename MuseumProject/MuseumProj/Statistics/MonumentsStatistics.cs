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
    public partial class MonumentsStatistics : Form
    {
        private Controller controllerObj; // A Reference of type Controller 

        public MonumentsStatistics()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int TotalMonuments = controllerObj.GetTotalMonuments();
            textBox1.Text = TotalMonuments.ToString();

            int TotalPrehistoric = controllerObj.GetTotalPrehistoricEra();
            textBox2.Text = TotalPrehistoric.ToString();

            int TotalEarlyAges = controllerObj.GetTotalEarlyAges();
            textBox3.Text = TotalEarlyAges.ToString();

            int TotalOld = controllerObj.GetTotalOldKingdom();
            textBox4.Text = TotalOld.ToString();

            int TotalMiddle = controllerObj.GetTotalMiddleKingdom();
            textBox5.Text = TotalMiddle.ToString();

            int TotalNew = controllerObj.GetTotalNewKingdom();
            textBox6.Text = TotalNew.ToString();

            int TotalLatePeriod = controllerObj.GetTotalLatePeriod();
            textBox7.Text = TotalLatePeriod.ToString();

            int TotalMonumentsDisp = controllerObj.GetTotalMonumentsDisp();
            textBox8.Text = TotalMonumentsDisp.ToString();

            int TotalMonumentsMaint = controllerObj.GetTotalMonumentsMaint();
            textBox9.Text = TotalMonumentsMaint.ToString();

            int TotalMonumentsTrans = controllerObj.GetTotalMonumentsTrans();
            textBox10.Text = TotalMonumentsTrans.ToString();

            int TotalPrehistoricEraDisp = controllerObj.GetTotalPrehistoricEraDisp();
            textBox16.Text = TotalPrehistoricEraDisp.ToString();

            int TotalPrehistoricEraMaint = controllerObj.GetTotalPrehistoricEraMaint();
            textBox22.Text = TotalPrehistoricEraMaint.ToString();

            int TotalPrehistoricEraTrans = controllerObj.GetTotalPrehistoricEraTrans();
            textBox28.Text = TotalPrehistoricEraTrans.ToString();

            int TotalEarlyAgesDisp = controllerObj.GetTotalEarlyAgesDisp();
            textBox15.Text = TotalEarlyAgesDisp.ToString();

            int TotalEarlyAgesMaint = controllerObj.GetTotalEarlyAgesMaint();
            textBox21.Text = TotalEarlyAgesMaint.ToString();

            int TotalEarlyAgesTrans = controllerObj.GetTotalEarlyAgesTrans();
            textBox27.Text = TotalEarlyAgesTrans.ToString();

            int TotalOldKingdomDisp = controllerObj.GetTotalOldKingdomDisp();
            textBox14.Text = TotalOldKingdomDisp.ToString();

            int TotalOldKingdomMaint = controllerObj.GetTotalOldKingdomMaint();
            textBox20.Text = TotalOldKingdomMaint.ToString();

            int TotalOldKingdomTrans = controllerObj.GetTotalOldKingdomTrans();
            textBox26.Text = TotalOldKingdomTrans.ToString();

            int TotalMiddleKingdomDisp = controllerObj.GetTotalMiddleKingdomDisp();
            textBox13.Text = TotalMiddleKingdomDisp.ToString();

            int TotalMiddleKingdomMaint = controllerObj.GetTotalMiddleKingdomMaint();
            textBox19.Text = TotalMiddleKingdomMaint.ToString();

            int TotalMiddleKingdomTrans = controllerObj.GetTotalMiddleKingdomTrans();
            textBox25.Text = TotalMiddleKingdomTrans.ToString();

            int TotalNewKingdomDisp = controllerObj.GetTotalNewKingdomDisp();
            textBox12.Text = TotalNewKingdomDisp.ToString();

            int TotalNewKingdomMaint = controllerObj.GetTotalNewKingdomMaint();
            textBox18.Text = TotalNewKingdomMaint.ToString();

            int TotalNewKingdomTrans = controllerObj.GetTotalNewKingdomTrans();
            textBox24.Text = TotalNewKingdomTrans.ToString();

            int TotalLatePeriodDisp = controllerObj.GetTotalLatePeriodDisp();
            textBox11.Text = TotalLatePeriodDisp.ToString();

            int TotalLatePeriodMaint = controllerObj.GetTotalLatePeriodMaint();
            textBox17.Text = TotalLatePeriodMaint.ToString();

            int TotalLatePeriodTrans = controllerObj.GetTotalLatePeriodTrans();
            textBox23.Text = TotalLatePeriodTrans.ToString();

        }

        private void MonumentsStatistics_Load(object sender, EventArgs e)
        {

        }
    }
}
