using System.Data;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private bool dotEntered = false;
        private bool resultDisplayed = false;


        public Calculator()
        {
            InitializeComponent();
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            if (resultDisplayed)
            {
                txtScreen.Clear();
                resultDisplayed = false;
            }
            
            if (sender is Button btn)
            {
                if (btn.Text == ".")
                {
                    if (!dotEntered)
                    {
                        txtScreen.AppendText(btn.Text);
                        dotEntered = true;
                    }
                }
                else
                {
                    txtScreen.AppendText(btn.Text);
                }
            }
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {

            if (sender is Button Operator)
            {
                if (resultDisplayed)
                {
                    resultDisplayed = false;
                }

                dotEntered = false;
                txtScreen.AppendText(Operator?.Text);
            }
                

        }



        private void btnOptEqual_Click(object sender, EventArgs e)
        {
            var result = new DataTable().Compute(txtScreen.Text, null);
            txtScreen.Text = result.ToString();

            dotEntered = false;
            resultDisplayed = true;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtScreen.Clear();

        }
    }
}