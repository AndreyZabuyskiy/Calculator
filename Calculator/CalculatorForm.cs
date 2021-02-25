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
    public partial class CalculatorForm : Form
    {
        public double FirstValue { get; set; }
        private double SecondValue { get; set; }
        private string Action { get; set; }
        private bool IsAction { get; set; }
        private bool IsCalculate { get; set; }
        private bool IsFirstValue { get; set; }
        private bool IsSecondValue { get; set; }

        public CalculatorForm()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            FirstValue = 0;
            SecondValue = 0;
            Action = "";
            LabelResult.Text = "0";
            IsAction = false;
            IsCalculate = false;
            IsFirstValue = true;
            IsSecondValue = false;
        }

        private void ButtonNumeralClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text.Equals(","))
            {
                LabelResult.Text += button.Text;
                return;
            }

            if (IsFirstValue)
                FillFirstValue(button);
            else
                FillSecondValue(button);
        }

        private void ButtonMathActionClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (IsSecondValue)
                Equally();

            Action = button.Text;
            IsAction = true;
            IsFirstValue = false;
            SecondValue = FirstValue;
            LabelResult.Text = SecondValue.ToString();
        }

        private void ButtonCalculateClick(object sender, EventArgs e)
        {
            Equally();

            IsAction = false;
            IsCalculate = true;
            IsFirstValue = true;
        }

        private void ButtonRemoveBackClick(object sender, EventArgs e)
        {
            if (LabelResult.Equals("0"))
                return;

            if (LabelResult.Text.Length > 1)
                LabelResult.Text = LabelResult.Text.Substring(0, LabelResult.Text.Length - 1);
            else
                LabelResult.Text = "0";


            if (IsFirstValue)
                FirstValue = double.Parse(LabelResult.Text);
            else
                SecondValue = double.Parse(LabelResult.Text);
        }

        private void ButtonClearClick(object sender, EventArgs e)
        {
            Initialization();
        }

        private void FillFirstValue(Button button)
        {
            if (IsCalculate)
            {
                LabelResult.Text = "";
                IsCalculate = false;
            }

            LabelResult.Text += button.Text;
            FirstValue = double.Parse(LabelResult.Text);
            LabelResult.Text = FirstValue.ToString();
            SecondValue = FirstValue;
        }

        private void FillSecondValue(Button button)
        {
            if (IsAction)
            {
                LabelResult.Text = "";
                IsAction = false;
            }

            LabelResult.Text += button.Text;
            SecondValue = double.Parse(LabelResult.Text);
            LabelResult.Text = SecondValue.ToString();
            IsSecondValue = true;
        }

        private void Equally()
        {
            if (Action.Equals(""))
                return;

            switch (Action)
            {
                case "+":
                    FirstValue += SecondValue;
                    break;

                case "-":
                    FirstValue -= SecondValue;
                    break;

                case "x":
                    FirstValue *= SecondValue;
                    break;

                case "/":
                    FirstValue /= SecondValue;
                    break;
            }

            LabelResult.Text = FirstValue.ToString();
            IsSecondValue = false;
        }
    }
}
