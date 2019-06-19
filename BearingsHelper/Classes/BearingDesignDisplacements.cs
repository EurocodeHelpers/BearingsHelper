using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearingsHelper.Classes
{
    public class BearingDesignDisplacements
    {
        //Constructor Inputs 
        public double Tmax { get; set; }
        public double Tmin { get; set; }
        public double T0 { get; set; }
        public double Altitude { get; set; }
        public double SurfacingThickness { get; set; }
        public double L { get; set; }

        public double DesignLife { get; set; }
        public double Alpha { get; set; }
        public double K1 { get; set; }
        public double K2 { get; set; }
        public double K3 { get; set; }
        public double K4 { get; set; }
        public double yQ { get; set; }

        //Calculated Parameters 
        public double Tmax_A => Tmax - 1.0 * Altitude / 100;    //A.1 Note 2/ EN 1991-1-5
        public double Tmin_A => Tmin - 0.5 * Altitude / 100;
        public double p => 1 / DesignLife;

        public double Tmax_A_120 => Tmax * (K1 - K2 * Math.Log(-Math.Log(1 - p)));
        public double Tmin_A_120 => Tmin * (K3 + K4 * Math.Log(-Math.Log(1 - p)));

        public double Temax => Tmax_A_120 + 4;
        public double Temin => Tmin_A_120 + 4;

        public double Temax_Adj => Temax + CalculateTemaxAdjustedForDeckSurfacing(SurfacingThickness);
        public double Temin_Adj => Temin + CalculateTeminAdjustedForDeckSurfacing(SurfacingThickness);

        public double TN_exp => Temax_Adj - T0;
        public double TN_con => T0 - Temin_Adj;

        public double tol => 15 + L / 10000;
        public double Vxexp => Alpha * L * TN_exp;
        public double Vxcon => Alpha * L * TN_con;

        public double Vxexp_ULS => yQ * Vxexp + tol;
        public double Vxcon_ULS => yQ * Vxcon + tol;

        public double Vxexp_SLS => Vxexp + tol;
        public double Vxcon_SLS => Vxcon + tol;

        public double Range_ULS => Math.Abs(Vxexp_ULS) + Math.Abs(Vxcon_ULS);
        public double Range_SLS => Math.Abs(Vxexp_SLS) + Math.Abs(Vxcon_SLS);

        //Helper Functions 

        public double CalculateTemaxAdjustedForDeckSurfacing(double tsurf)
        {
            List<double> x = new List<double> { 0, 40, 100, 200 };
            List<double> y = new List<double> { 0, 2, 0, -4 };
            return MathHelpers.CalculateInterpolatedValue(tsurf, x, y);
        }

        public double CalculateTeminAdjustedForDeckSurfacing(double tsurf)
        {
            List<double> x = new List<double> { 0, 40, 100, 200 };
            List<double> y = new List<double> { -3, -2, 0, 3 };
            return MathHelpers.CalculateInterpolatedValue(tsurf, x, y);
        }

        //Procedure 
        /*
         * 1. Calculate Tmax,A and Tmin,A
         * 2. Calculate Tmax,A,120 and Tmin,A,120 
         * 3. Calculate Temin
         */
    }
}
