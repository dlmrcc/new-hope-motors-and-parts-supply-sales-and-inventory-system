using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class Quantity : Form
    {
        public Quantity()
        {
            InitializeComponent();
        }
        public static String sQuantity;
        public static Boolean bStatus;
        private void txtQuanity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bStatus = true;
                sQuantity = txtQuanity.Text;
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                bStatus = false;
                Close();
            }
        }

        private void txtQuanity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtQuanity.Text.IndexOf('.') == -1)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}