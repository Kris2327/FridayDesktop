using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Friday_1._1
{
    public partial class Calculator : Form
    {
        string first = "";
        string second = "";
        char function;
        double result = 0.0;
        string userInput = "";
        public Calculator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            first = "";
            second = "";
            userInput = "";
            result = 0.0;
            label1.Text = "0";
        }

        private void num1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            userInput += "1";
            label1.Text += userInput;
        }

        private void num2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            userInput += "2";
            label1.Text += userInput;
        }

        private void num3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            userInput += "3";
            label1.Text += userInput;
        }

        private void num4_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            userInput += "4";
            label1.Text += userInput;
        }

        private void num5_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            userInput += "5";
            label1.Text += userInput;
        }

        private void num6_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            userInput += "6";
            label1.Text += userInput;
        }

        private void num7_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            userInput += "7";
            label1.Text += userInput;
        }

        private void num8_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            userInput += "8";
            label1.Text += userInput;
        }

        private void num9_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            userInput += "9";
            label1.Text += userInput;
        }

        private void DelenieButton_Click(object sender, EventArgs e)
        {
            function = '/';
            first = userInput;
            userInput = "";
        }

        private void umnovenieButton_Click(object sender, EventArgs e)
        {
            function = '*';
            first = userInput;
            userInput = "";
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            function = '+';
            first = userInput;
            userInput = "";
        }

        private void menusButton_Click(object sender, EventArgs e)
        {
            function = '-';
            first = userInput;
            userInput = "";
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            second = userInput;
            double firstNum, secondNum;
            firstNum = Convert.ToDouble(first);
            secondNum = Convert.ToDouble(second);

            //plus
            if (function == '+')
            {
                result = firstNum + secondNum;
                label1.Text = result.ToString();
            }
            //menus
            else if (function == '-')
            {
                result = firstNum - secondNum;
                label1.Text = result.ToString();
            }
            //multiply
            else if (function == '*')
            {
                result = firstNum * secondNum;
                label1.Text = result.ToString();
            }
            //devide
            else if (function == '/')
            {
                if (secondNum == '0')
                {
                    label1.Text = "Error";
                }
                else
                {
                    result = firstNum / secondNum;
                    label1.Text = result.ToString();
                }
            }
        }

        private void dotbutton_Click(object sender, EventArgs e)
        {
            label1.Text = ".";
        }

        private void num0_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            userInput += "0";
            label1.Text += userInput;
        }
    }
}
