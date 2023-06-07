using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
        }
        void vCustomer()
        {
            lsBilling.Items.Clear();
            LogIn.q = "select customerid, companyname from cust where customerid in"
                + " (select custid from billing where flag = '1') and customerid != '1'";
            LogIn.vtable();
            aCustID = new String[LogIn.table.Rows.Count];
            for (int a = 0; a < LogIn.table.Rows.Count; a++)
            {
                lsBilling.Items.Add(LogIn.table.Rows[a][1]);
                aCustID[a] = LogIn.table.Rows[a][0].ToString();
            }
        }
        String[] aCustID;
        private void wfBilling_Load(object sender, EventArgs e)
        {
            vCustomer();
            txtCash.Text = "0";
        }
        void vOrderedProduct()
        {
            LogIn.q = "SELECT distinct p.name Item,"
                + " s.qty `Quantity`,"
                + " s.sPrice `Price`,"
                + " s.sAmount `Amount`,"
                + " s.billid FROM sub s left join (product p, billing b, user u, cust c)"
                + " on (p.prodcode = s.prodcode and s.billid = b.billid"
                + " and b.userid = u.userid and c.customerid = b.custid)"
                + " where b.custid = '" + sCustID
                + "' and b.flag = '1' and s.flag = '0'";
            LogIn.vtable();
            dgOrder.DataSource = LogIn.table;
            dgOrder.Columns[3].DefaultCellStyle.Format = "c";
            dgOrder.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgOrder.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgOrder.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgOrder.Columns[2].DefaultCellStyle.Format = "c";
            dgOrder.Columns[4].Visible = false;
            dgOrder.Columns[0].Width = dgOrder.Width - (303);
        }
        void vPayment()
        {
            string sBillID = "";
            try
            {
                sBillID = dgOrder.Rows[0].Cells[4].Value.ToString();
            }
            catch
            {
                sBillID = "";
            }
            LogIn.q = "SELECT amount `Total Amount`,"
                + " Cash,"
                + " VAT,"
                + " Vatable,"
                + " paydate `Payment Date` FROM payment p left join (billing b, cust c) on (b.billid = p.billid and b.custid = c.customerid) where"
                + " b.custid = '" + sCustID + "' and b.flag = '1'";
            LogIn.vtable();
            dgPayment.DataSource = LogIn.table;
            dgPayment.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPayment.Columns[0].DefaultCellStyle.Format = "c";
            dgPayment.Columns[0].Width = 100;
            dgPayment.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPayment.Columns[1].DefaultCellStyle.Format = "c";
            dgPayment.Columns[1].Width = 100;
            dgPayment.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPayment.Columns[2].DefaultCellStyle.Format = "c";
            dgPayment.Columns[2].Width = 100;
            dgPayment.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPayment.Columns[3].DefaultCellStyle.Format = "c";
            dgPayment.Columns[3].Width = 100;
            dgPayment.Columns[4].DefaultCellStyle.Format = "MMM. dd, yyyy hh:mm:ss tt";
            dgPayment.Columns[4].Width = 143;
        }
        string sCustID;
        private void lsBilling_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sCustID = aCustID[lsBilling.SelectedIndex];
            }
            catch { sCustID = ""; }
            vOrderedProduct();
            vPayment();
            double dTotalAmount = 0;
            for (int a = 0; a < dgOrder.Rows.Count; a++)
            {
                dTotalAmount += Convert.ToDouble(dgOrder.Rows[a].Cells[3].Value);
            }
            double dTotalPay = 0;
            for (int a = 0; a < dgPayment.Rows.Count; a++)
            {
                dTotalPay += Convert.ToDouble(dgPayment.Rows[a].Cells[1].Value);
            }
            dPrevBal = dTotalAmount - dTotalPay;
            lbPrevBal.Text = dPrevBal.ToString("c");
        }
        double dPrevBal;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 48 && e.KeyChar <= 57)
                || e.KeyChar == 8) || (e.KeyChar == 46) && (txtCash.Text.IndexOf('.') == -1))
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }
        double dCash;
        double dVatPercentage;
        double dBalance, dChange, dVat, dVatable;
        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dCash = Convert.ToDouble(txtCash.Text);
            }
            catch { txtCash.Text = "0"; }
            LogIn.vVat();
            dVatPercentage = LogIn.dVat / 100;
            if (dCash < dPrevBal)
            {
                dBalance = dPrevBal - dCash;
                dChange = 0;
                dVat = (dCash / (1 + dVatPercentage)) * dVatPercentage;
                dVatable = dCash / (1 + dVatPercentage);
            }
            else
            {
                dBalance = 0;
                dChange = dCash - dPrevBal;
                dVat = (dPrevBal / (1 + dVatPercentage)) * dVatPercentage;
                dVatable = (dPrevBal / (1 + dVatPercentage));
            }
            lbBalance.Text = dBalance.ToString("c");
            lbChange.Text = dChange.ToString("c");
        }
        void vPayID()
        {
            LogIn.q = "SELECT count(payid) FROM payment where paydate like '"
                + DateTime.Now.ToString("yyyy") + "%'";
            LogIn.vtable();
            sPayID = DateTime.Now.ToString("yyyy-MM-")
                + (Convert.ToInt32(LogIn.table.Rows[0][0]) + 1).ToString("d5");
        }
        string sPayID;
        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dCash > 0)
                {
                    double dMoney = dCash;
                    if (dCash>=dPrevBal)
                    {
                        dMoney = dPrevBal;
                    }
                    vPayID();
                    LogIn.q = "insert into payment (payid, amount, cash, billid, paydate, vat, vatable)"
                        + " values ('" + sPayID
                        + "','" + dMoney
                        + "','" + dCash
                        + "','" + dgOrder.SelectedRows[0].Cells[4].Value.ToString()
                        + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        + "','" + dVat
                        + "','" + dVatable + "')";
                    LogIn.vtable();
                    if (dCash>=dPrevBal)
                    {
                        LogIn.q = "update billing set flag = '0' where customerid = '" + sCustID + "'";
                        LogIn.vtable();
                    }
                    vCustomer();
                    vOrderedProduct();
                    vPayment();
                    if (lsBilling.Items.Count == 0)
                    {
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Amount must be at least greater than 0", "Unable to Pay");
                }
            }
        }

        private void txtCash_Leave(object sender, EventArgs e)
        {
            try
            {
                dCash = Convert.ToDouble(txtCash.Text);
            }
            catch { dCash = 0; }
        }

        private void bnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}