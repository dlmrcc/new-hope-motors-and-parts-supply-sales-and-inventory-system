using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class BadOrder : Form
    {
        public BadOrder()
        {
            InitializeComponent();
        }

        private void wfBadOrder_Load(object sender, EventArgs e)
        {
            lbProdCode .Text= Product.sprodcode;
            lbProdname.Text = Product.sname;
            lbQtyRem.Text = Product.dqty.ToString();
        }

        private void txtBadOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57)
                           || e.KeyChar == 8)
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void txtBadOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogIn.sOldValue = lbProdCode.Text;
                LogIn.vAllowSingleQuote();
                if (txtBadOrder.Text != "")
                {
                    Close();
                }
                else
                    MessageBox.Show("Bad Order must not be empty.","Invalid Bad Order");

            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtBadOrder_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbNewQty.Text = (Product.dgqty - Convert.ToDouble(txtBadOrder.Text)).ToString();
            }
            catch { lbNewQty.Text = "0"; }
        }
    }
}
