using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
namespace NHH___Sales_and_Inventory_System
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        double dPrevPayment;
        private void wfPayment_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ph");
            dPrevPayment = 0;
            if (ReceiptID.bStatus == true)
            {
                dPrevPayment = ReceiptID.dCash;
                lbPrevPayment.Text = dPrevPayment.ToString("c");
                lbTotalPayment.Visible = true;
                lbPrevPay.Visible = true;
                lbTotalPay.Visible = true;
                lbPrevPayment.Visible = true;
                Height = 364;
            }
            lbTotalAmount.Text = Purchase.dTotalAmount.ToString("c");
            cbMOP.SelectedIndex = 0;
            vPayment();
        }
        public static Double dCash;
        public static Double dBalance;
        public static Double dChange;
        public static Double dVat;
        public static Double dVatable;
        public static Double dVatValue;
        public static Double dVatPercentage;
        void vVat()
        {
            LogIn.q = "SELECT value from vat";
            LogIn.vtable();
            dVatValue = Convert.ToDouble(LogIn.table.Rows[0][0]);
        }
        public static Double dMoney;
        void vPayment()
        {
            vVat();
            try
            {
                dCash = Convert.ToDouble(txtCash.Text);
            }
            catch { dCash = 0; }
            dTotalPayment = dCash + dPrevPayment;
            dVatPercentage = dVatValue / 100;
            if (dTotalPayment >= Purchase.dTotalAmount)
            {
                dMoney = Purchase.dTotalAmount - dPrevPayment;
                dBalance = 0;
                dChange = dTotalPayment - Purchase.dTotalAmount;
                dVat = (dMoney / (1 + dVatPercentage)) * dVatPercentage;
                dVatable = (dMoney) / (1 + dVatPercentage);
            }
            else
            {
                dMoney = dCash;
                dBalance = Purchase.dTotalAmount - dTotalPayment;
                dChange = 0;
                dVat = (dCash / (1 + dVatPercentage)) * dVatPercentage;
                dVatable = dCash / (1 + dVatPercentage);
            }
            dTotalAmount = Purchase.dTotalAmount - ReceiptID.dCash;
            lbTotalPayment.Text = dTotalPayment.ToString("c");
            lbBalance.Text = dBalance.ToString("c");
            lbChange.Text = dChange.ToString("c");
            lbVat.Text = dVat.ToString("c");
            lbVatable.Text =  dVatable.ToString("c");
        }
        public static double dTotalAmount;
        double dTotalPayment;
        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            vPayment();
        }
        public static Boolean bStatus;
        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Purchase.sCustomerID == "")
                {
                    if (Purchase.dTotalAmount > dTotalPayment)
                    {
                        MessageBox.Show("Walk - In customer is not allowed to have balance.", "Insufficient Funds");
                        txtCash.Focus();
                        bStatus = false;
                    }
                    else
                    {
                        bStatus = true;
                        Close();
                    }
                }
                else
                {
                    bStatus = true;
                    Close();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                bStatus = false;
                Close();
            }
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 48 && e.KeyChar <= 57)
             || e.KeyChar == 8) || (e.KeyChar == 46) || (e.KeyChar == 45) && (txtCash.Text.IndexOf('.') == -1))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }
    }
}