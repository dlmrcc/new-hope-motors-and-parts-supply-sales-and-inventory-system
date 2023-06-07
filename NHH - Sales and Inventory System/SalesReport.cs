using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }
        void vBilling()
        {
            lsBilling.Items.Clear();
            LogIn.q = "SELECT BillId FROM billing b left join (user u, cust c) on (b.userid = u.userid and c.customerid = b.custid)"
                + " where b.billdate between '" + dtFrom.Value.ToString("yyyy-MM-dd 00:00:00")
                + "' and '" + dtTo.Value.ToString("yyyy-MM-dd 23:59:58") + "' and " + sUserID
                + " and " + sCustID;
            LogIn.vtable();
            for (int a = 0; a < LogIn.table.Rows.Count; a++)
                lsBilling.Items.Add(LogIn.table.Rows[a][0]);
            vTotalAmount();
        }
        double dTotalCAmount;
        double dTotalSAmount;
        void vTotalAmount()
        {
            LogIn.q = "SELECT sum(amount),sum(samount) FROM sub s left join (billing b, cust c, user u)"
                + " on (s.billid = b.billid and b.custid = c.customerid and b.userid = u.userid)"
                + " where b.billdate between '" + dtFrom.Value.ToString("yyyy-MM-dd 00:00:00")
                + "' and '" + dtTo.Value.ToString("yyyy-MM-dd 23:59:58")
                + "' and " + sUserID + " and " + sCustID;
            LogIn.vtable();
            try
            {
                dTotalCAmount = Convert.ToDouble(LogIn.table.Rows[0][0]);
                dTotalSAmount = Convert.ToDouble(LogIn.table.Rows[0][1]);
            }
            catch { dTotalCAmount = 0; dTotalSAmount = 0; }
            lbTotalBillingCAmount.Text = "Total Cost Billing Amount: " + dTotalCAmount.ToString("c");
            lbTotalBillingSAmount.Text = "Total Sale Billing Amount: " + dTotalSAmount.ToString("c");
            lbTotalBillingIAmount.Text = "Total Income Billing Amount: " + (dTotalSAmount - dTotalCAmount).ToString("c");
        }
        void vOrder()
        {
            LogIn.q = "SELECT distinct c.Companyname,"
                + " p.Name,"
                + " s.Qty,"
                + " s.sPrice `Sale Price`,"
                + " s.sAmount `Sale Amount`,"
                + " s.Price `Cost Price`,"
                + " s.Amount `Cost Amount`"
                + " FROM sub s left join (billing b, product p, cust c)"
                + " on (b.billid = s.billid and s.prodcode = p.prodcode"
                + " and b.custid = c.customerid) where b.billid = '" + sBillingID + "' and s.flag = '0'";
            LogIn.vtable();
            dgOrder.DataSource = LogIn.table;
            dgOrder.Columns[0].Visible = false;
            dgOrder.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgOrder.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgOrder.Columns[3].DefaultCellStyle.Format = "c";
            dgOrder.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgOrder.Columns[4].DefaultCellStyle.Format = "c";
            dgOrder.Columns[2 + 3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgOrder.Columns[3 + 2].DefaultCellStyle.Format = "c";
            dgOrder.Columns[4 + 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgOrder.Columns[4 + 2].DefaultCellStyle.Format = "c";
            dgOrder.Columns[1].Width = dgOrder.Width - 303;
            if (dgOrder.RowCount != 0)
                lbName.Text = "List of Ordered Product for " + dgOrder.SelectedRows[0].Cells[0].Value.ToString();
            dCAmount = 0;
            dSAmount = 0;
            for (int a = 0; a < dgOrder.Rows.Count; a++)
            {
                dSAmount += Convert.ToDouble(dgOrder.Rows[a].Cells[4].Value);
                dCAmount += Convert.ToDouble(dgOrder.Rows[a].Cells[6].Value);
            }
            lbTotalCAmount.Text = "Total Cost Amount: " + dCAmount.ToString("c");
            lbTotalSAmount.Text = "Total Sale Amount: " + dSAmount.ToString("c");
            lbTotalIAmount.Text = "Total Income Amount: " + (dSAmount - dCAmount).ToString("c");
        }
        double dCAmount;
        double dSAmount;
        void vPayment()
        {
            LogIn.q = "SELECT p.Amount `Total Amount`,"
                + " p.Cash,"
                + " p.VAT,"
                + " p.Vatable,"
                + " p.paydate `Payment Date` FROM payment p left join"
                + " (billing b, cust c) on (c.customerid ="
                + " b.custid and p.billid = b.billid)"
                + " where b.billid = '" + sBillingID + "'";
            LogIn.vtable();
            dgPayment.DataSource = LogIn.table;
            dgPayment.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPayment.Columns[0].DefaultCellStyle.Format = "c";
            dgPayment.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPayment.Columns[1].DefaultCellStyle.Format = "c";
            dgPayment.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPayment.Columns[2].DefaultCellStyle.Format = "c";
            dgPayment.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPayment.Columns[3].DefaultCellStyle.Format = "c";
            dgPayment.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPayment.Columns[4].DefaultCellStyle.Format = "MMM. dd, yyyy hh:mm:ss tt";
            dgPayment.Columns[4].Width = dgPayment.Width - 404;
            if (dgPayment.RowCount != 0)
                lbPayment.Text = "List of Payment for " + dgOrder.SelectedRows[0].Cells[0].Value.ToString();
            dTotalCPayment = 0;
            for (int a = 0; a < dgPayment.Rows.Count; a++)
            {
                dTotalCPayment += Convert.ToDouble(dgPayment.Rows[0].Cells[1].Value);
            }
            lbTotalCPayment.Text = "Total Payment: " + dTotalCPayment.ToString("c");
        }
        double dTotalCPayment;
        double dTotalSPayment;
        private void wfSalesReport_Load(object sender, EventArgs e)
        {
            vUser();
            vCustomer();
            cbCust.SelectedIndex = 0;
            cbUser.SelectedIndex = 0;
            vBilling();
            lbTotalBillingCAmount.Text = "Total Cost Billing Amount: " + dTotalCAmount.ToString("c");
            lbTotalBillingSAmount.Text = "Total Sale Billing Amount: " + dTotalSAmount.ToString("c");
            lbTotalCAmount.Text = "Total Cost Amount: " + dCAmount.ToString("c");
            lbTotalSAmount.Text = "Total Sale Amount: " + dSAmount.ToString("c");
            lbTotalCPayment.Text = "Total Payment: " + dTotalCPayment.ToString("c");
        }
        String[] aCustID;
        string sCustID;
        void vCustomer()
        {
            LogIn.q = "SELECT companyname, customerid FROM cust c where c.customerid in (select b.custid"
                + " from billing b where b.billdate between '" + dtFrom.Value.ToString("yyyy-MM-dd 00:00:00")
                + "' and '" + dtTo.Value.ToString("yyyy-MM-dd 23:59:58") + "')";
            LogIn.vtable();
            cbCust.Items.Clear();
            cbCust.Items.Add("All");
            aCustID = new String[LogIn.table.Rows.Count];
            for (int a = 0; a < LogIn.table.Rows.Count; a++)
            {
                cbCust.Items.Add(LogIn.table.Rows[a][0]);
                aCustID[a] = LogIn.table.Rows[a][1].ToString();
            }
        }
        String[] aUserID;
        string sUserID;
        void vUser()
        {
            LogIn.q = "SELECT concat(FName, ' ',LName), userid FROM `user` u where u.userid in (select b.userid from billing b where b. billdate between '" + dtFrom.Value.ToString("yyyy-MM-dd 00:00:00")
                + "' and '" + dtTo.Value.ToString("yyyy-MM-dd 23:59:58") + "')";
            LogIn.vtable();
            cbUser.Items.Clear();
            cbUser.Items.Add("All");
            aUserID = new String[LogIn.table.Rows.Count];
            for (int a = 0; a < LogIn.table.Rows.Count; a++)
            {
                cbUser.Items.Add(LogIn.table.Rows[a][0]);
                aUserID[a] = LogIn.table.Rows[a][1].ToString();
            }
        }
        private void bnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsBilling_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sBillingID = lsBilling.SelectedItem.ToString();
            }
            catch { sBillingID = ""; }
            vOrder();
            vPayment();
        }
        string sBillingID;

        private void dtTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                vUser();
                vCustomer();
                vBilling();
            }
        }

        private void dtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                vUser();
                vCustomer();
                vBilling();
            }
        }
        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            sUserID = "u.userid like '%'";
            if (cbUser.SelectedIndex > 0)
                sUserID = "u.userid = '" + aUserID[cbUser.SelectedIndex - 1] + "'";
            sCustID = "c.customerid like '%'";
            if (cbCust.SelectedIndex > 0)
                sCustID = "c.customerid = '" + aCustID[cbCust.SelectedIndex - 1] + "'";
            vBilling();
        }
        private void cbCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            sUserID = "u.userid like '%'";
            if (cbUser.SelectedIndex > 0)
                sUserID = "u.userid = '" + aUserID[cbUser.SelectedIndex - 1] + "'";
            sCustID = "c.customerid like '%'";
            if (cbCust.SelectedIndex > 0)
                sCustID = "c.customerid= '" + aCustID[cbCust.SelectedIndex - 1] + "'";
            vBilling();
        }
    }
}