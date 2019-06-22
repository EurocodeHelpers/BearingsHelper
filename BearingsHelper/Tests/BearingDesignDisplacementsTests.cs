using BearingsHelper.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BearingsHelper.Tests
{
    public class BearingDesignDisplacementsTests
    {
        [Theory]
        [InlineData(0, 4)]
        [InlineData(40, 2)]
        [InlineData(100, 0)]
        [InlineData(200, -4)]
        public void Test01_VerifyTemaxAdjustmentForSurfacing(double tsurf, double expected)
        {
            List<double> x = new List<double>() { 0, 40, 100, 200 };
            List<double> y = new List<double>() { 4, 2, 0, -4 };

            double actual = MathHelpers.CalculateInterpolatedValue(tsurf, x, y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, -3)]
        [InlineData(40, -2)]
        [InlineData(100, 0)]
        [InlineData(200, 3)]
        public void Test02_VerifyTeminAdjustmentForSurfacing(double tsurf, double expected)
        {
            List<double> x = new List<double>() { 0, 40, 100, 200 };
            List<double> y = new List<double>() { -3, -2, 0, 3 };

            double actual = MathHelpers.CalculateInterpolatedValue(tsurf, x, y);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test03_VerifySCIP406WorkedExample1()
        {
            //NOTE - SCI P406 contains errors hence there are discrepancies between the "real" and calculated results, approximately 2% difference.

            BearingDesignDisplacements b = new BearingDesignDisplacements()
            {
                Tmax = 33,
                Tmin = -17,
                T0 = 10,
                Alpha = 12 * 0.001 * 0.001,
                DesignLife = 120,
                Altitude = 100,
                L = 56000,
                SurfacingThickness = 100,
                K1 = 0.781,
                K2 = 0.056,
                K3 = 0.393,
                K4 = -0.156,
                yQ = 1.45
            };

            List<double> actual = new List<double>() { b.Vxexp_ULS, b.Vxcon_ULS, b.Vxexp_SLS, b.Vxcon_SLS, };
            List<double> expected = new List<double>() { 49, 45, 40, 37 };

            for (int i = 0; i < actual.Count; i++)
            {
                double actual1 = actual[i];
                double expected1 = expected[i];
                double percentageDifference = 100 * Math.Abs((actual1 - expected1) / actual1);
                Assert.InRange(percentageDifference, 0, 2);
            }
        }

        [Fact]
        public void Test04_VerifyUnitTest1()
        {
            //NOTE - SCI P406 contains errors hence there are discrepancies between the "real" and calculated results, approximately 2% difference.

            BearingDesignDisplacements b = new BearingDesignDisplacements()
            {
                Tmax = 41,
                Tmin = -20,
                T0 = 16.67,
                Alpha = 15 * 0.001 * 0.001,
                DesignLife = 100,
                Altitude = 136,
                L = 68000,
                SurfacingThickness = 155,
                K1 = 0.666,
                K2 = 0.07,
                K3 = 0.410,
                K4 = -0.17,
                yQ = 1.33
            };

            List<double> actual = new List<double>() { b.Vxexp_ULS, b.Vxcon_ULS, b.Vxexp_SLS, b.Vxcon_SLS, };
            List<double> expected = new List<double>() { 56.5811, 69.0918, 47.9512, 57.3577 };

            for (int i = 0; i < actual.Count; i++)
            {
                double actual1 = actual[i];
                double expected1 = expected[i];
                double percentageDifference = 100 * Math.Abs((actual1 - expected1) / actual1);
                Assert.Equal(actual1, expected1, 3);
            }
        }
        //Add test to check SCI 1.04 and 1.14 factors 
    }
}
