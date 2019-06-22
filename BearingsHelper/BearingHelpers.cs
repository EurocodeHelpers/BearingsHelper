using BearingsHelper.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BearingsHelper.Forms;


namespace BearingsHelper
{
    public partial class BearingHelpers : Form
    {
        public BearingHelpers()
        {
            InitializeComponent();
        }       

        public void WriteDoubleToTextBox(ref TextBox tb, double value, int NumberOfSF)
        {
            double roundedValue = Math.Round(value, NumberOfSF);
            tb.Text = roundedValue.ToString();
            return;
        }       

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            Form frm = new About();
            frm.Show();
        }

        private void BtnCalculate_Click_1(object sender, EventArgs e)
        {
            double Tmax = TextboxHelpers.TextBoxToDouble(txtTmax);
            double Tmin = TextboxHelpers.TextBoxToDouble(txtTmin);
            double T0 = TextboxHelpers.TextBoxToDouble(txtT0);
            double Altitude = TextboxHelpers.TextBoxToDouble(txtAltitude);
            double SurfacingThickness = TextboxHelpers.TextBoxToDouble(txtSurfacing);
            double L = TextboxHelpers.TextBoxToDouble(txtLength) * 1000;  //Convert to mm 

            double DesignLife = TextboxHelpers.TextBoxToDouble(txtDesignLife);
            double alpha = TextboxHelpers.TextBoxToDouble(txtAlpha);
            double k1 = TextboxHelpers.TextBoxToDouble(txtK1);
            double k2 = TextboxHelpers.TextBoxToDouble(txtK2);
            double k3 = TextboxHelpers.TextBoxToDouble(txtK3);
            double k4 = TextboxHelpers.TextBoxToDouble(txtK4);
            double yQ = TextboxHelpers.TextBoxToDouble(txtGammaQ);

            //Instantiate instance of BearingDesignDisplacementsClass

            BearingDesignDisplacements b = new BearingDesignDisplacements()
            {
                Alpha = alpha,
                DesignLife = DesignLife,
                Altitude = Altitude,
                L = L,
                SurfacingThickness = SurfacingThickness,
                T0 = T0,
                Tmax = Tmax,
                Tmin = Tmin,
                K1 = k1,
                K2 = k2,
                K3 = k3,
                K4 = k4,
                yQ = yQ
            };

            //Write values to calculation window

            WriteDoubleToTextBox(ref txtAltitude2, b.Altitude, 4);
            WriteDoubleToTextBox(ref txtTmaxA, b.Tmax_A, 4);
            WriteDoubleToTextBox(ref txtTminA, b.Tmin_A, 4);

            WriteDoubleToTextBox(ref txtDesignLife2, b.DesignLife, 4);
            WriteDoubleToTextBox(ref txtP, b.p, 4);
            WriteDoubleToTextBox(ref txtTmaxADL, b.Tmax_A_120, 4);
            WriteDoubleToTextBox(ref txtTminADL, b.Tmin_A_120, 4);

            //2. Calculate effective bridge temperatures 
            WriteDoubleToTextBox(ref txtTemax, b.Temax, 4);
            WriteDoubleToTextBox(ref txtTemin, b.Temin, 4);
            WriteDoubleToTextBox(ref txtSurfacing2, b.SurfacingThickness, 4);
            WriteDoubleToTextBox(ref txtTemaxadj, b.Temax_Adj, 4);
            WriteDoubleToTextBox(ref txtTeminadj, b.Temin_Adj, 4);

            //3. Calculate characteristic values of temperature change. 
            WriteDoubleToTextBox(ref txtTemaxadj, b.Temax_Adj, 4);
            WriteDoubleToTextBox(ref txtTeminadj, b.Temin_Adj, 4);
            WriteDoubleToTextBox(ref txtT02, b.T0, 4);
            WriteDoubleToTextBox(ref txtTNexp, b.TN_exp, 4);
            WriteDoubleToTextBox(ref txtTNcon, b.TN_con, 4);

            //4. Calculate design movement ranges 

            WriteDoubleToTextBox(ref txtTol, b.tol, 4);
            WriteDoubleToTextBox(ref txtTemaxadj2, b.Temax_Adj, 4);
            WriteDoubleToTextBox(ref txtTeminadj2, b.Temin_Adj, 4);

            WriteDoubleToTextBox(ref txtVxexpULS, b.Vxexp_ULS, 4);
            WriteDoubleToTextBox(ref txtVxconULS, b.Vxcon_ULS, 4);
            WriteDoubleToTextBox(ref txtVxexpSLS, b.Vxexp_SLS, 4);
            WriteDoubleToTextBox(ref txtVxconSLS, b.Vxcon_SLS, 4);

            txtULS.Text = $"+{Math.Ceiling(b.Vxexp_ULS)}/-{Math.Ceiling(b.Vxcon_ULS)}";
            txtSLS.Text = $"+{Math.Ceiling(b.Vxexp_SLS)}/-{Math.Ceiling(b.Vxcon_SLS)}";

            WriteDoubleToTextBox(ref txtULSRange, b.Range_ULS, 4);
            WriteDoubleToTextBox(ref txtSLSRange, b.Range_SLS, 4);
        }

        #region

        private void BearingHelpers_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label95_Click(object sender, EventArgs e)
        {

        }

        private void TabPage9_Click(object sender, EventArgs e)
        {

        }

        private void Label76_Click(object sender, EventArgs e)
        {

        }

        private void Label79_Click(object sender, EventArgs e)
        {

        }

        private void TabPage13_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void Label21_Click(object sender, EventArgs e)
        {

        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void Label27_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion




    }
}

