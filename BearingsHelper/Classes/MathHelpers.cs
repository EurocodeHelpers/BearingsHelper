using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearingsHelper.Classes
{
    public static class MathHelpers
    {
        public static double CalculateInterpolatedValue(double xi, double x1, double y1, double x2, double y2)
        {
            double yi = y1 + (xi - x1) * (y2 - y1) / (x2 - x1);
            return yi;
        }

        public static double CalculateAreaOfACircle(double D)
        {
            return 0.25 * Math.PI * D * D;
        }

        public static double CalculateResultant(double X, double Y)
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public static double CalculateInterpolatedValue(double xi, List<double> xList, List<double> yList)
        {
            //Validate parameters, i.e. check xi is within extents of Table, and that number of elements
            //is the same in both Lists 

            //Check number of elements is the same in both Lists 
            if (xList.Count != yList.Count) { throw new IndexOutOfRangeException("Element count must be same for both Lists."); }
            if (xi < xList.Min()) { throw new IndexOutOfRangeException("Xi < Minimum Value in y Array."); }
            if (xi > xList.Max()) { throw new IndexOutOfRangeException("Xi > Maximum Value in y Array."); }

            //Calculate lower and upper bound indexes. 
            for (int i = 0; i < xList.Count; i++)
            {
                if (xi >= xList[i] && xi <= xList[i + 1])
                {
                    double x1 = xList[i];
                    double y1 = yList[i];
                    double x2 = xList[i + 1];
                    double y2 = yList[i + 1];

                    //Calculate interpolated value 

                    double yi = CalculateInterpolatedValue(xi, x1, y1, x2, y2);
                    return yi;
                }
            }

            throw new ArgumentException("Invalid data input - check data.");
        }

        public static double CalculateLowerBoundValue(double xi, List<double> xList, List<double> yList)
        {
            if (xList.Count != yList.Count) { throw new IndexOutOfRangeException("Element count must be same for both Lists."); }
            if (xi < xList.Min()) { throw new IndexOutOfRangeException("Xi < Minimum Value in y Array."); }
            if (xi > xList.Max()) { throw new IndexOutOfRangeException("Xi > Maximum Value in y Array."); }

            //Calculate lower bound value
            for (int i = 0; i < xList.Count; i++)
            {
                if (xi <= xList[i])
                {
                    return yList[i];
                }
            }

            throw new OutOfMemoryException("Invalid data input - check data.");
        }
    }
}
