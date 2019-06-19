using BearingsHelper.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearingsHelper.Tests
{
    public class BearingDesignDisplacementsTests
    {
        [Fact]
        public void VerifySCIP406WorkedExample1()
        {
            double expected = 49;

            BearingDesignDisplacements b = new BearingDesignDisplacements()
            {
                Alpha = 12 * 0.001 * 0.001,
                DesignLife = 120,
                Altitude = 100,
                L = 56000,
                SurfacingThickness = 100,
                T0 = 10,
                Tmax = 33,
                Tmin = -17,
                K1 = 0.781,
                K2 = 0.056,
                K3 = 0.393,
                K4 = -0.156,
                yQ = 1.45
            };

            double actual = Math.Round(b.Vxexp_ULS);

            Assert.Equal(expected, actual);
        }
    }
}
