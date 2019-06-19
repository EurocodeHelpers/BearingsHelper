using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BearingsHelper.Classes
{
    public static class TextboxHelpers
    {
        public static double TextBoxToDouble(TextBox tb)
        {
            return double.Parse(tb.Text);
        }

        //Colour textbox green if Less than 1, else 
        public static TextBox TextBoxConditionalFormatting(ref TextBox tb)
        {
            double value = double.Parse(tb.Text);

            if (value < 1)
            {
                tb.ForeColor = Color.Green;
            }
            else
            {
                tb.ForeColor = Color.Red;
            }

            return tb;
        }

        public static TextBox TextBoxGreyIfNA(ref TextBox tb)
        {
            string value = tb.Text;

            if (value == "N/A")
            {
                tb.ForeColor = Color.LightGray;
            }
            else
            {
                tb.ForeColor = Color.Black;
            }
            return tb;
        }

        public static string ParseDoubleToTextBox(double x, int decimalPlaces)
        {
            return (Math.Round(x, decimalPlaces)).ToString();
        }       
    }
}
