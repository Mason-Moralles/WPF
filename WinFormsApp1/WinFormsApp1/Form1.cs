using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operation = "";
        private bool isOperationClicked = false;
        private Label labelHistory;
        private TextBox textBoxResult;
        private Label labelOperation;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new Size(320, 460);
            this.MinimumSize = new Size(320, 460);

            labelHistory = new Label
            {
                Location = new Point(10, 0),
                Size = new Size(280, 20),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.DimGray,
                Text = "",
                TextAlign = ContentAlignment.MiddleRight
            };
            this.Controls.Add(labelHistory);

            textBoxResult = new TextBox
            {
                Location = new Point(10, 20),
                Size = new Size(280, 40),
                Font = new Font("Segoe UI", 18),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                Text = "0"
            };
            this.Controls.Add(textBoxResult);

            labelOperation = new Label
            {
                Location = new Point(15, 25),
                Size = new Size(40, 30),
                Font = new Font("Segoe UI", 16),
                ForeColor = Color.Gray,
                Text = ""
            };
            this.Controls.Add(labelOperation);
            labelOperation.BringToFront();

            var table = new TableLayoutPanel
            {
                Location = new Point(10, 60),
                Size = new Size(280, 350),
                ColumnCount = 4,
                RowCount = 5
            };
            for (int i = 0; i < 4; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            for (int i = 0; i < 5; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.Controls.Add(table);

            string[] texts = {
                "", "C", "<-", "/",
                "7", "8", "9", "*",
                "4", "5", "6", "-",
                "1", "2", "3", "+",
                "", "0", ",", "=",
            };

            for (int i = 0; i < 20; i++)
            {
                var btn = new Button
                {
                    Text = texts[i],
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 16)
                };

                if ("0123456789,".Contains(texts[i]))
                    btn.Click += DigitButton_Click;
                else if ("+-*/".Contains(texts[i]))
                    btn.Click += OperationButton_Click;
                else if (texts[i] == "=")
                    btn.Click += EqualButton_Click;
                else if (texts[i] == "C")
                    btn.Click += ClearButton_Click;
                else if (texts[i] == "<-")
                    btn.Click += DelButton_Click;

                table.Controls.Add(btn, i % 4, i / 4);
            }
        }


        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
            isOperationClicked = false;
            labelOperation.Text = "";
            labelHistory.Text = "";
        }
    
        private void DelButton_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text.Length > 1)
            {
                textBoxResult.Text = textBoxResult.Text.Remove(textBoxResult.Text.Length - 1, 1);
            }
            else
            {
                textBoxResult.Text = "0";
            }
        }
        private void DigitButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (textBoxResult.Text == "0" || isOperationClicked)
                textBoxResult.Text = "";
            isOperationClicked = false;
            textBoxResult.Text += button.Text;
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            firstNumber = double.Parse(textBoxResult.Text);
            operation = button.Text;
            isOperationClicked = true;
            labelOperation.Text = operation;
            labelHistory.Text = $"{firstNumber} {operation}";
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            secondNumber = double.Parse(textBoxResult.Text);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                    {
                        MessageBox.Show("Деление на ноль невозможно");
                        result = 0;
                    }
                    break;
            }
            labelHistory.Text = $"{firstNumber} {operation} {secondNumber} =";
            textBoxResult.Text = result.ToString();
            isOperationClicked = false;
            labelOperation.Text = operation;
        }
    }
}