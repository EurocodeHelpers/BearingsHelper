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
using BearingsHelper.FluentValidation;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace BearingsHelper
{
    public partial class BearingHelpers : Form
    {
        public BearingHelpers()
        {
            InitializeComponent();
        }



        private void BtnCalculate_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Instantiate new instances of BDD class. 

                BearingDesignDisplacements b = ReturnBearingDesignDisplacemetnsObjectFromTBInputs();

                //Validate incoming data using FluentValidation

                var validator = new BearingDesignDisplacementsValidator();
                var results = validator.Validate(b);

                if (results.IsValid == false)
                {
                    //Clear results textboxes
                    ClearCalculationTextboxes();

                    //Report error messages.

                    foreach (var failure in results.Errors)
                    {
                        MessageBox.Show(failure.ErrorMessage);
                    }
                }
                else
                {
                    //Write values to calculation window

                    WriteDoubleToTextBox(ref txtTmax2, b.Tmax, 1);
                    WriteDoubleToTextBox(ref txtTmin2, b.Tmin, 1);
                    WriteDoubleToTextBox(ref txtAltitude2, b.Altitude, 1);
                    WriteDoubleToTextBox(ref txtTmaxA, b.Tmax_A, 1);
                    WriteDoubleToTextBox(ref txtTminA, b.Tmin_A, 1);

                    WriteDoubleToTextBox(ref txtDesignLife2, b.DesignLife, 1);
                    WriteDoubleToTextBox(ref txtP, b.p, 4);
                    WriteDoubleToTextBox(ref txtTmaxADL, b.Tmax_A_120, 1);
                    WriteDoubleToTextBox(ref txtTminADL, b.Tmin_A_120, 1);

                    //2. Calculate effective bridge temperatures 
                    WriteDoubleToTextBox(ref txtTemax, b.Temax, 1);
                    WriteDoubleToTextBox(ref txtTemin, b.Temin, 1);
                    WriteDoubleToTextBox(ref txtSurfacing2, b.SurfacingThickness, 0);
                    WriteDoubleToTextBox(ref txtTemaxadj, b.Temax_Adj, 1);
                    WriteDoubleToTextBox(ref txtTeminadj, b.Temin_Adj, 1);

                    //3. Calculate characteristic values of temperature change. 
                    WriteDoubleToTextBox(ref txtT02, b.T0, 1);
                    WriteDoubleToTextBox(ref txtTNexp, b.TN_exp, 1);
                    WriteDoubleToTextBox(ref txtTNcon, b.TN_con, 1);

                    //4. Calculate design movement ranges   
                    WriteDoubleToTextBox(ref txtTemaxadj2, b.Temax_Adj, 1);
                    WriteDoubleToTextBox(ref txtTeminadj2, b.Temin_Adj, 1);
                    WriteDoubleToTextBox(ref txtT02, b.T0, 1);
                    WriteDoubleToTextBox(ref txtTNexp, b.TN_exp, 1);
                    WriteDoubleToTextBox(ref txtTNcon, b.TN_con, 1);

                    WriteDoubleToTextBox(ref txtLength2, b.L, 0);
                    WriteDoubleToTextBox(ref txtAlpha2, b.Alpha, 6);
                    WriteDoubleToTextBox(ref txtVxexp, b.Vxexp, 1);
                    WriteDoubleToTextBox(ref txtVxcon, b.Vxcon, 1);
                    WriteDoubleToTextBox(ref txtTol, b.tol, 1);

                    WriteDoubleToTextBox(ref txtVxexpULS, b.Vxexp_ULS, 1);
                    WriteDoubleToTextBox(ref txtVxconULS, b.Vxcon_ULS, 1);
                    WriteDoubleToTextBox(ref txtVxexpSLS, b.Vxexp_SLS, 1);
                    WriteDoubleToTextBox(ref txtVxconSLS, b.Vxcon_SLS, 1);

                    //5. Summary Table

                    txtULS.Text = $"+{Math.Ceiling(b.Vxexp_ULS)}/-{Math.Ceiling(b.Vxcon_ULS)}";
                    txtSLS.Text = $"+{Math.Ceiling(b.Vxexp_SLS)}/-{Math.Ceiling(b.Vxcon_SLS)}";

                    WriteDoubleToTextBox(ref txtULSRange, b.Range_ULS, 1);
                    WriteDoubleToTextBox(ref txtSLSRange, b.Range_SLS, 1);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input. Please ensure all textboxes contain numbers/decimals and not characters.");
                ClearCalculationTextboxes();
            }
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

        private void TxtBridgeType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        #endregion

        #region

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

        private void ClearCalculationTextboxes()
        {
            TextboxHelpers.ClearTextBox(ref txtTmax2);
            TextboxHelpers.ClearTextBox(ref txtTmin2);
            TextboxHelpers.ClearTextBox(ref txtAltitude2);
            TextboxHelpers.ClearTextBox(ref txtTmaxA);
            TextboxHelpers.ClearTextBox(ref txtTminA);

            TextboxHelpers.ClearTextBox(ref txtDesignLife2);
            TextboxHelpers.ClearTextBox(ref txtP);
            TextboxHelpers.ClearTextBox(ref txtTmaxADL);
            TextboxHelpers.ClearTextBox(ref txtTminADL);

            TextboxHelpers.ClearTextBox(ref txtTemax);
            TextboxHelpers.ClearTextBox(ref txtTemin);
            TextboxHelpers.ClearTextBox(ref txtSurfacing2);
            TextboxHelpers.ClearTextBox(ref txtTemaxadj);
            TextboxHelpers.ClearTextBox(ref txtTeminadj);

            TextboxHelpers.ClearTextBox(ref txtTNexp);
            TextboxHelpers.ClearTextBox(ref txtTNcon);

            TextboxHelpers.ClearTextBox(ref txtTemaxadj2);
            TextboxHelpers.ClearTextBox(ref txtTeminadj2);
            TextboxHelpers.ClearTextBox(ref txtT02);
            TextboxHelpers.ClearTextBox(ref txtTNexp);
            TextboxHelpers.ClearTextBox(ref txtTNcon);

            TextboxHelpers.ClearTextBox(ref txtLength2);
            TextboxHelpers.ClearTextBox(ref txtAlpha2);

            TextboxHelpers.ClearTextBox(ref txtVxexp);
            TextboxHelpers.ClearTextBox(ref txtVxcon);
            TextboxHelpers.ClearTextBox(ref txtTol);

            TextboxHelpers.ClearTextBox(ref txtVxexpULS);
            TextboxHelpers.ClearTextBox(ref txtVxconULS);
            TextboxHelpers.ClearTextBox(ref txtVxexpSLS);
            TextboxHelpers.ClearTextBox(ref txtVxconSLS);
        }

        private BearingDesignDisplacements ReturnBearingDesignDisplacemetnsObjectFromTBInputs()
        {
            //Convert input boxes to variables and use try-catch to check for illegal input.
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

            //Instantiate instance of BearingDesignDisplacements object
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

            return b;
        }

        #endregion




        private void BtnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;
            var b = ReturnBearingDesignDisplacemetnsObjectFromTBInputs();

            //Start Excel, Get Application Object+New Workbook
            oXL = new Excel.Application();
            oXL.Visible = true;
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            //Enter in some sample data 
            oSheet.Cells[1, 1] = b.K1;
            oSheet.Cells[1, 2] = b.K2;
            oSheet.Cells[1, 3] = b.K3;
            oSheet.Cells[1, 4] = b.K4;

            //Make data bold and centred 
            oSheet.get_Range("A1", "D1").Font.Bold = true;
            oSheet.get_Range("A1", "D1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            oXL.Visible = true;
            oXL.UserControl = true; 
        }



    }
}

