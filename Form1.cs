using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {

        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void button_click(object sender, EventArgs e)
        {
            if (textBox_result.Text == "0" || isOperationPerformed) textBox_result.Clear();

            Button button = (Button)sender;
            isOperationPerformed = false;
            if (button.Text == ".")
            {
                if (!textBox_result.Text.Contains("."))
                    textBox_result.Text = textBox_result.Text + button.Text;

            }
            else
                textBox_result.Text = textBox_result.Text + button.Text;

        }


        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0)
            {
                btnEqual.PerformClick();
                operationPerformed = button.Text;
                labelOperations.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {

                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_result.Text);
                labelOperations.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
            resultValue = 0;
            labelOperations.Text = "";
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBox_result.Text = (resultValue + Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "-":
                    textBox_result.Text = (resultValue - Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "*":
                    textBox_result.Text = (resultValue * Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "/":
                    textBox_result.Text = (resultValue / Double.Parse(textBox_result.Text)).ToString();
                    break;

                case "^2":
                    textBox_result.Text = Math.Pow(Double.Parse(textBox_result.Text), 2).ToString();
                    break;
                case "^y":
                    textBox_result.Text = Math.Pow(resultValue,Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "sqrt":
                    textBox_result.Text = Math.Sqrt(Double.Parse(textBox_result.Text)).ToString();
                    break;

                default:
                    break;


            }
            resultValue = Double.Parse(textBox_result.Text);
            labelOperations.Text = " ";
            
        }
    }
}
