using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class AdminPass : Form
    {
        public AdminPass()
        {
            InitializeComponent();
        }

        private void bnOk_Click(object sender, EventArgs e)
        {
            LogIn.q = "SELECT userid FROM `user` where password = '" + txtPassword.Text + "' and Usertype = 'Admin'";
            LogIn.vtable();
            if (LogIn.table.Rows.Count != 0)
            {
                Purchasing.bOk = true;
                Close();
            }
            else
            {
                Purchasing.bOk = false;
                Close();
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            Purchasing.bOk = false;
            Close();
        }
    }
}