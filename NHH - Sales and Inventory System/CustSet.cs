using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class CustSet : Form
    {
        public CustSet()
        {
            InitializeComponent();

        }
        void vCustID()
        {
            LogIn.q = "select count(custid) from cust where year like '" + DateTime.Now.ToString("yyyy") + "%'";
            LogIn.vtable();
            sCustID = DateTime.Now.ToString("yyyy-") + (Convert.ToInt32(LogIn.table.Rows[0][0]) + 1).ToString("d4");
        }
        string sCustID;
        string sCompName;
        string sAddress;
        private void button1_Click(object sender, EventArgs e)
        {
            LogIn.sOldValue = txtcname.Text;
            LogIn.vAllowSingleQuote();
            sCompName = LogIn.sNewValue;
            LogIn.sOldValue = txtAddress.Text;
            LogIn.vAllowSingleQuote();
            sAddress = LogIn.sNewValue;
            if (txtcname.Text.Length < 6 || txtcname.Text.Length > 80)
            {
                MessageBox.Show("Company name must be six (6) to eighty (80) characters.", "Unable to save");
                txtcname.Focus();
            }
            else if (txtAddress.Text.Length < 6 || txtcname.Text.Length > 80)
            {
                MessageBox.Show("Company address must be six (6) to eighty (80) characters.", "Unable to save");
                txtcname.Focus();
            }
            else
            {
                if (Customer.sAdd == "Add")
                {
                    vCustID();
                    LogIn.q = "insert into cust (customerid, companyname, contactnumber, address, year) values ('" + sCustID + "','" + sCompName
                        + "','" + txtConNum.Text
                        + "','" + sAddress
                        + "','" + DateTime.Now.ToString("yyyy") + "')";
                }
                else
                {
                    LogIn.q = "update cust set Companyname = '" + sCompName
                        + "', ContactNumber = '" + txtConNum.Text
                        + "', Address = '" + sAddress
                        + "' where CustomerID= '" + Customer.sCustomerID + "'";
                }
                LogIn.vtable();
                Close();
            }
        }
        private void AddCustomer_Load(object sender, EventArgs e)
        {
            if (Customer.sAdd == "Edit")
            {
                txtcname.Text = Customer.sCompanyName;
                txtAddress.Text = Customer.sAddress;
                txtConNum.Text = Customer.sContactNumber;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtConNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            LogIn.txtToolTipText = txtConNum;
            LogIn.vKeyNumbers(e);
        }

        private void txtcname_KeyPress(object sender, KeyPressEventArgs e)
        {
            LogIn.txtToolTipText = txtcname;
            LogIn.vKeysOthers(e);
        }
    }
}