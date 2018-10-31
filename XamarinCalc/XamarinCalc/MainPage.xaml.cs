using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCalc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        enum Operator { None, Add, Sub, Mul, Div};

        private Decimal m_firstNumber = 0;
        private Operator m_operator = Operator.None;
        private bool m_isOperatorClicked = false;

        void btn_Clicked(object sender, System.EventArgs e)
        {
            string txt = ((Button)sender).Text;
            if(m_isOperatorClicked == true)
            {
                txtResult.Text = txt;
                m_isOperatorClicked = false;
                return;
            }
            
            string strNumber = txtResult.Text + txt;
            if(decimal.TryParse(strNumber, out decimal dnumber))
            {
                txtResult.Text = dnumber.ToString();
            }
        }
        void btnPlus_Clicked(object sender, System.EventArgs e)
        {
            m_operator = Operator.Add;
            m_isOperatorClicked = true;
            UpdateFirstNumber();
        }
        void btnMinus_Clicked(object sender, System.EventArgs e)
        {
            m_operator = Operator.Sub;
            m_isOperatorClicked = true;
            UpdateFirstNumber();
        }
        void btnMul_Clicked(object sender, System.EventArgs e)
        {
            m_operator = Operator.Mul;
            m_isOperatorClicked = true;
            UpdateFirstNumber();
        }
        void btnDiv_Clicked(object sender, System.EventArgs e)
        {
            m_operator = Operator.Div;
            m_isOperatorClicked = true;
            UpdateFirstNumber();
        }
        void btnClear_Clicked(object sender, System.EventArgs e)
        {
            m_operator = Operator.None;
            m_isOperatorClicked = false;
            txtResult.Text = "0";
            m_firstNumber = 0;
        }
        void btnCalc_Clicked(object sender, System.EventArgs e)
        {
            if (decimal.TryParse(txtResult.Text, out decimal secondNumber))
            {
                decimal ret = 0;
                switch (m_operator) {
                    case Operator.Add:
                        ret = m_firstNumber + secondNumber;
                        break;
                    case Operator.Sub:
                        ret = m_firstNumber - secondNumber;
                        break;
                    case Operator.Mul:
                        ret = m_firstNumber * secondNumber;
                        break;
                    case Operator.Div:
                        ret = m_firstNumber / secondNumber;
                        break;
                }
                m_firstNumber = ret;
                UpdateDisplay(ret);
            }
            m_isOperatorClicked = true;
            m_operator = Operator.None;
        }
        
        private void UpdateDisplay(decimal val)
        {
            txtResult.Text = val.ToString("0.###############");
        }

        private void UpdateFirstNumber()
        {
            if (m_firstNumber != 0)
                return;
            if (decimal.TryParse(txtResult.Text, out decimal dnumber))
            {
                m_firstNumber = dnumber;
            }
        }
    }
}
