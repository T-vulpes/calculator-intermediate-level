using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calcu
{
    public partial class Form1 : Form
    {

        #region ozellikler
        private string operand = "";
        private double num1 = 0; 
        public string result { get => txtresult.Text; set=>txtresult.Text=value; }
        #endregion

        #region olaylar

        private void button_click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Text == "=") 
            {
                double num2 = Convert.ToDouble(txtresult.Text);
                double result = CalculateResult(num1, num2, operand);
                txtresult.Text = result.ToString(); 
            }
            else if (clickedButton.Text == "AC") 
            {
                txtresult.Text = ""; 
            }
            else if (clickedButton.Text == "+/-") 
            {
                double currentValue = Convert.ToDouble(txtresult.Text);
                currentValue = -currentValue;
                txtresult.Text = currentValue.ToString(); 
            }
            else if (clickedButton.Text == "Sqrt")
            {
                double sqrtvalue = Math.Sqrt(Convert.ToDouble(txtresult.Text));
                txtresult.Text = sqrtvalue.ToString();
            }
            else 
            {
                if (IsOperator(clickedButton.Text)) 
                {
                    operand = clickedButton.Text; 
                    num1 = Convert.ToDouble(txtresult.Text);
                    txtresult.Text = ""; 
                }
                else 
                {
                    txtresult.Text += clickedButton.Text; 
                }
            }
        }

        
        private bool IsOperator(string text)
        {
            return text == "+" || text == "-" || text == "/" || text == "X" || text == "%" || text == "POW";
        }

        
        private double CalculateResult(double num1, double num2, string operand)
        {
            double result = 0;
            switch (operand)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "X":
                    result = num1 * num2;
                    break;
                case "%":
                    result = num1 % num2;
                    break;
                case "POW":
                    result = Math.Pow(num1, num2);
                    break;
            }

            return result;
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

    }
}
