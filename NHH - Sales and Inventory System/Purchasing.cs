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
    public partial class Purchasing : Form
    {
        double dAmount;
        double iQty;
        void vFormula()
        {
            try
            {
                dAmount = dQty * dPrice;
            }
            catch { txtQty.Text = "0"; }
            lbAmount.Text = dAmount.ToString("c");
        }
        public Purchasing() { InitializeComponent(); }
        public static Boolean bOk;
        void vCust()
        {
            LogIn.q = "select custid, company from cust where custid != 'Supplier' and company like '"
                + txtSearch.Text + "%'";
            LogIn.q = LogIn.q.ToUpper();
            LogIn.vtable();
            dgCust.DataSource = LogIn.table;
            dgCust.Columns[0].Visible = false;
            lbResult.Text = dgCust.Rows.Count + " customer result has found!";
            dgCust.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void dgProduct_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                sProdCode = dgProduct.SelectedRows[0].Cells[0].Value.ToString();
                sQty = dgProduct.SelectedRows[0].Cells[2].Value.ToString();
                dPrice = Convert.ToDouble(dgProduct.SelectedRows[0].Cells[3].Value);
                dManuDate = Convert.ToDateTime(dgProduct.SelectedRows[0].Cells[4].Value);
                dExpiDate = Convert.ToDateTime(dgProduct.SelectedRows[0].Cells[5].Value);
            }
            catch { }
            vFormula();
            txtQty_TextChanged(sender, e);
            lbPrice.Text = dPrice.ToString("c");
        }
        string sQty;
        DateTime dManuDate;
        DateTime dExpiDate;
        void vProduct()
        {
            LogIn.q = "SELECT prodcode `PRODUCT CODE`,"//0
                + " name `PRODUCT NAME`,"//1
                + " qty `QTY`,"//2
                + " price,"//3
                + " manudate,"//4
                + " expidate "//5
                + "FROM product where (prodcode like '" + txtSearchProd.Text
                + "%' or name like '%" + txtSearchProd.Text + "%') and qty > 0";
            LogIn.vtable();
            dgProduct.DataSource = LogIn.table;
            dgProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProduct.Columns[0].Visible = false;
            dgProduct.Columns[2].Visible = false;
            dgProduct.Columns[3].Visible = false;
            dgProduct.Columns[4].Visible = false;
            dgProduct.Columns[5].Visible = false;
        }
        void vLoad()
        {
            vCust();
            vProduct();
            vOrderedProduct();
            txtQty.Text = "1";
            txtCash.Text = "0";
        }
        private void wfPurchasing_Load(object sender, EventArgs e)
        {
            vLoad();
            sStatus = "Purchase";
            Text = sStatus;
        }
        double dPrice;
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dQty = Convert.ToDouble(txtQty.Text);
            }
            catch { dQty = 0; }
            if (dQty < 0)
                txtQty.Text = "0";
            else
                vFormula();
        }
        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
                txtQty.Text = "0";
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) { vCust(); }
        private void bnCreate_Click(object sender, EventArgs e)
        {
            Customer.sAdd = "Add";
            CustSet c = new CustSet();
            c.ShowDialog();
            vCust();
        }
        private void bnClose_Click(object sender, EventArgs e) { Close(); }
        private void txtSearchProd_TextChanged(object sender, EventArgs e) { vProduct(); }
        public static String sCustID;
        string sProdCode;
        void vBillingID()
        {
            LogIn.q = "select count(billingid) from billing where date like '"
                + DateTime.Now.ToString("yyyy") + "%'";
            LogIn.vtable();
            sBillingID = DateTime.Now.ToString("yyyy-") + (Convert.ToInt32(LogIn.table.Rows[0][0])
                + 1).ToString("d5");
        }
        string sBillingID;
        void vCallBillingID()
        {
            LogIn.q = "SELECT billingid FROM billing where CustomerId = '" + sCustID
                + "' and flag = 'N'";
            LogIn.vtable();
            if (LogIn.table.Rows.Count == 1)
            {
                sBillingID = LogIn.table.Rows[0][0].ToString();
            }
            else
            {
                vBillingID();
                LogIn.q = "insert into billing (BillingId, UserId, CustomerId, Date, flag) values ('"
                    + sBillingID
                    + "','" + LogIn.suserid
                    + "','" + sCustID
                    + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    + "','N')";
                LogIn.vtable();
            }
        }
        double dCustBalance;
        void vCustBalance()
        {
            LogIn.q = "SELECT balance FROM payment where customerid = '" + sCustID
                            + "' order by date desc limit 1";
            LogIn.vtable();
            try
            {
                dCustBalance = Convert.ToDouble(LogIn.table.Rows[0][0]);
            }
            catch
            {
                dCustBalance = 0;
            }
            if (dCustBalance > 0)
            {
                lbPrevBal.Visible = !false;
                lbPrevBalance.Visible = !false;
            }
            else
            {
                lbPrevBal.Visible = false;
                lbPrevBalance.Visible = false;
            }
            lbPrevBal.Text = dCustBalance.ToString("c");
        }
        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sStatus == "Purchase")
                {
                    if (Convert.ToDouble(txtQty.Text) > Convert.ToDouble(dgProduct.SelectedRows[0].Cells[2].Value))
                    {
                        MessageBox.Show("Quantity must not be more than " + dgProduct.SelectedRows[0].Cells[2].Value, "Unable to Purchase");
                        txtQty.Focus();
                    }
                    else
                    {
                        int q = 0;
                        for (int a = 0; a < dgPurchase.Rows.Count; a++)
                        {
                            if (dgPurchase.Rows[a].Cells[1].Value.ToString() ==
                                dgProduct.SelectedRows[0].Cells[1].Value.ToString())
                            {
                                q++;
                                break;
                            }
                        }
                        if (q == 0)
                        {
                            vCustBalance();
                            if (dCustBalance == 0)
                            {
                                vCallBillingID();
                                LogIn.q = "SELECT count(subid) FROM sub where year like '"
                                    + DateTime.Now.ToString("yyyy") + "%'";
                                LogIn.vtable();
                                sSubID = DateTime.Now.ToString("yyyy-")
                                    + (Convert.ToInt32(LogIn.table.Rows[0][0]) + 1).ToString("d5");
                                LogIn.q = "insert into sub"
                                    + " (SubId, BillingId, prodcode, Price, Quantity, Amount, status,"
                                    + " year, void) values ('" + sSubID
                                    + "','" + sBillingID
                                    + "','" + sProdCode
                                    + "','" + dPrice
                                    + "','" + txtQty.Text
                                    + "','" + dAmount
                                    + "','N','" + DateTime.Now.ToString("yyyy")
                                    + "','N')";
                                LogIn.vtable();
                                LogIn.q = "update product set qty = (qty - " + txtQty.Text
                                    + ") where prodcode = '" + sProdCode + "'";
                                LogIn.vtable();
                                vProduct();
                                vOrderedProduct();
                                txtQty.Text = "1";
                            }
                            else
                            {
                                if (MessageBox.Show(dgCust.SelectedRows[0].Cells[1].Value.ToString()
                                    + " has unsettled account. Do you want to settled it first?"
                                    , "Unable to Purchase"
                                    , MessageBoxButtons.YesNo
                                    , MessageBoxIcon.Question)
                                    == DialogResult.Yes)
                                {
                                    MessageBox.Show(sCompanyName + " " + sCustID);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(dgProduct.SelectedRows[0].Cells[1].Value
                                + " has been already purchased. Use Modify Items instead",
                                "Unable to Purchase");
                        }
                    }
                }
                else
                {
                    vModifyOrder();
                    sStatus = "Purchase";
                    modifyOrderToolStripMenuItem.Text = "Modify Order (F2)";
                }
            }
        }
        void vOrderedProduct()
        {
            LogIn.q = "SELECT s.subid,"
                + " p.Name,"
                + " s.Quantity,"
                + " s.Price,"
                + " s.Amount,"
                + " s.prodcode"
                + " FROM sub s left join (billing b, user u, product p, cust c)"
                + " on (s.billingid = b.billingid and b.customerid = c.custid and"
                + " p.prodcode = s.prodcode and b.userid = u.userid) where b.customerid = '" + sCustID
                + "' and s.void = 'N' and s.`status` = 'N' and b.flag = 'N'";
            LogIn.vtable();
            dgPurchase.DataSource = LogIn.table;
            dgPurchase.Columns[0].Visible = false;
            dgPurchase.Columns[5].Visible = false;
            dgPurchase.Columns[1].Width = 225;
            dgPurchase.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgPurchase.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPurchase.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPurchase.Columns[3].DefaultCellStyle.Format = "c";
            dgPurchase.Columns[4].DefaultCellStyle.Format = "c";
            vTotalAmount();
        }
        string sSubID;
        public static String sCompanyName;
        private void dgCust_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                sCustID = dgCust.SelectedRows[0].Cells[0].Value.ToString();
                sCompanyName = dgCust.SelectedRows[0].Cells[1].Value.ToString();
                vOrderedProduct();
                txtCash_TextChanged(sender, e);
                vCustBalance();
            }
            catch
            {
                lbTotalAmount.Text = "Php0.00";
                lbBalance.Text = "Php0.00";
                lbChange.Text = "Php0.00";
                lbVAT.Text = "Php0.00";
                lbVATable.Text = "Php0.00";
                lbTotalQty.Text = "0";
            }
        }
        double dTotalAmount;
        double dQty;       
        void vPayID()
        {
            LogIn.q = "SELECT count(payid) FROM payment where date like '"
                + DateTime.Now.ToString("yyyy") + "%'";
            LogIn.vtable();
            sPayID = DateTime.Now.ToString("yyyy-")
                + (Convert.ToInt32(LogIn.table.Rows[0][0]) + 1).ToString("d5");
        }
        string sPayID;
        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToDouble(txtCash.Text) > 0)
                {
                    vCallBillingID();
                    if (Convert.ToDouble(txtCash.Text) < dTotalAmount)
                    {
                        if (dgCust.SelectedRows[0].Cells[1].Value.ToString() == "Walk - In")
                        {
                            MessageBox.Show("Cash should be at least equal to " + dTotalAmount,
                                "Insufficient Funds");
                            txtCash.Focus();
                        }
                        else { vPayment(); }
                    }
                    else { vPayment(); }
                }
                else
                {
                    MessageBox.Show("You can't purchase with that amount of money.",
                        "Unable to purchase");
                    txtCash.Focus();
                }
            }
        }
         void vTotalAmount()
        {
            LogIn.q = "SELECT sum(amount), sum(quantity) FROM sub s left join billing b on"
                + " (b.billingid = s.billingid) where b.customerid = '" + sCustID
                + "' and b.flag = 'N' and s.void = 'N'";
            LogIn.vtable();
            try
            {
                if (Convert.ToDouble(LogIn.table.Rows[0][0]) > 0)
                {
                    dTotalAmount = Convert.ToDouble(LogIn.table.Rows[0][0]);
                    dQty = Convert.ToDouble(LogIn.table.Rows[0][1]);
                }
                else
                {
                    dTotalAmount = 0;
                    dQty = 0;
                }
            }
            catch
            {
                dTotalAmount = 0;
                dQty = 0;
            }
            lbTotalAmount.Text = dTotalAmount.ToString("c");
            lbTotalQty.Text = dQty.ToString();
        }
        void vPayment()
        {
            vPayID();
            LogIn.q = "SELECT billingid FROM billing where CustomerId = '" + sCustID
               + "' and flag = 'N'";
            LogIn.vtable();
            sBillingID = LogIn.table.Rows[0][0].ToString();
            LogIn.q = "insert into payment (payid, userid, customerid, amount, cash, `change`,"
                + " billingid, date, vat, vatable, balance) values ('" + sPayID
                + "','" + LogIn.suserid
                + "','" + sCustID
                + "','" + dTotalAmount
                + "','" + dCash
                + "','" + dChange
                + "','" + sBillingID
                + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                + "','" + dVat
                + "','" + dVatable
                + "','" + dBalance + "')";
            LogIn.vtable();
            if (dBalance == 0)
            {
                vCallBillingID();
                LogIn.q = "update billing set flag = 'Y' where billingid = '" + sBillingID + "'";
                LogIn.vtable();
            }
            LogIn.q = "update sub set status = 'Y' where subid = '" + sPSubID + "'";
            LogIn.vtable();
            vOrderedProduct();
            txtCash.Text = "0";
        }
      
        private void bnBack_Click(object sender, EventArgs e) { Close(); }
        double dCash;
        double dBalance;
        double dChange;
        double dVat;
        double dVatable;
        double dVatPercentage;
        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LogIn.vVat();
                dVatPercentage = LogIn.dVat / 100;
                dCash = Convert.ToDouble(txtCash.Text);
                if (dCash < dTotalAmount)
                {
                    dBalance = dTotalAmount - dCash;
                    dChange = 0;
                    dVat = (dCash / (1 + dVatPercentage)) * dVatPercentage;
                    dVatable = dCash / (1 + dVatPercentage);
                }
                else
                {
                    dBalance = 0;
                    dChange = dCash - dTotalAmount;
                    dVat = (dTotalAmount / (1 + dVatPercentage)) * dVatPercentage;
                    dVatable = (dTotalAmount / (1 + dVatPercentage));
                }
            }
            catch { txtCash.Text = "0"; }
            lbBalance.Text = dBalance.ToString("c");
            lbChange.Text = dChange.ToString("c");
            lbVAT.Text = dVat.ToString("c");
            lbVATable.Text = dVatable.ToString("c");
        }
        double dvQty;
        DateTime dvManudate, dvExpidate;
        string date;
        void vSelectProduct()
        {
            date = "";
            LogIn.q = "select qty, manudate, expidate from product where prodcode = '"
                + sProdCode + "'";
            LogIn.vtable();
            dvQty = Convert.ToDouble(LogIn.table.Rows[0][0]);
            try
            {
                dvManudate = Convert.ToDateTime(LogIn.table.Rows[0][1]);
                dvExpidate = Convert.ToDateTime(LogIn.table.Rows[0][2]);
                date = "'" + dvManudate.ToString("yyyy-MM-dd")
                + "','" + dvExpidate.ToString("yyyy-MM-dd") + "'";
            }
            catch { date = "null,null"; }
        }
        void vVoidItem()
        {
            vSelectProduct();
            LogIn.q = "update sub set void = 'Y' where subid = '" + sPSubID + "'";
            LogIn.vtable();
            LogIn.q = "update product set qty = (qty + " + dgProduct.SelectedRows[0].Cells[2].Value
                + ") where prodcode = '" + sProdCode + "'";
            LogIn.vtable();
            vProduct();
            vOrderedProduct();
        }
        private void voidOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgPurchase.Rows.Count > 0)
            {
                if (LogIn.sUsertype == "Admin")
                {
                    vVoidItem();
                }
                else
                {
                    Hide();
                    bOk = false;
                    AdminPass a = new AdminPass();
                    a.ShowDialog();
                    Show();
                    if (bOk == true)
                        vVoidItem();
                    else { MessageBox.Show("Wrong Password.", "Unable to Void"); }
                }
            }
            else { MessageBox.Show("Purchase a product first.", "Unable to void"); }
        }
        string sPSubID;
        double dPQty;
        double dPPrice;
        double dPAmount;
        string sProductCode;
        private void dgPurchase_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                sPSubID = dgPurchase.SelectedRows[0].Cells[0].Value.ToString();
                dPQty = Convert.ToDouble(dgPurchase.SelectedRows[0].Cells[2].Value);
                dPPrice = Convert.ToDouble(dgPurchase.SelectedRows[0].Cells[3].Value);
                dPAmount = Convert.ToDouble(dgPurchase.SelectedRows[0].Cells[4].Value);
                sProductCode = dgPurchase.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch { }
        }
        string sStatus;
        private void modifyOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modifyOrderToolStripMenuItem.Text == "Modify Order (F2)")
            {
                sStatus = "Modify";
                modifyOrderToolStripMenuItem.Text = "Cancel Modify Order (F2)";
            }
            else
            {
                sStatus = "Purchase";
                modifyOrderToolStripMenuItem.Text = "Modify Order (F2)";
            }
            Text = sStatus;
        }
        void vModifyOrder()
        {
            vSelectProduct();
            if ((dvQty + (Convert.ToDouble(txtQty.Text) - dPQty)) < 0)
            {
                MessageBox.Show("The Customer ordered exceeds stocks available. The remaining stocks is "
                  + (dvQty + (Convert.ToDouble(txtQty.Text))) + "\nPlease Contact the administrator."
                  , "Unable to Purchase");
                txtQty.Focus();
            }
            else
            {
                LogIn.q = "update sub set quantity = '" + (Convert.ToDouble(txtQty.Text) - dPQty)
                      + "' and amount = '" + ((Convert.ToDouble(txtQty.Text) - dPQty) * dPAmount)
                      + "' where subid = '" + sPSubID + "'";
                LogIn.vtable();
                LogIn.q = "update product set qty = (qty + '" + (Convert.ToDouble(txtQty.Text) - dPQty)
                    + "') where prodcode = '" + sProductCode + "'";
                LogIn.vtable();
                vOrderedProduct();
                vTotalAmount();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if (((e.KeyChar >= 48 && e.KeyChar <= 57)
                || e.KeyChar == 8 || e.KeyChar == 46)&&(txtQty.Text.IndexOf('.') == -1))
                e.Handled = false;
            else
            {
                if ((e.KeyChar >= 48 && e.KeyChar <= 57)
                || e.KeyChar == 8)
                    e.Handled = false;
                else
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nNumbers", txtQty);
            }
        }
        ToolTip tt = new ToolTip();
        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if ((e.KeyChar >= 48 && e.KeyChar <= 57)
                || e.KeyChar == 8 || e.KeyChar == 13)
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nNumbers)", txtCash);
            }
        }

        private void txtSearchProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 97 && e.KeyChar <= 122
                || e.KeyChar >= 65 && e.KeyChar <= 90
                || e.KeyChar >= 48 && e.KeyChar <= 57
                || e.KeyChar >= 40 && e.KeyChar <= 41
                || e.KeyChar >= 45 && e.KeyChar <= 47
                || e.KeyChar == 8
                || e.KeyChar == 32)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 97 && e.KeyChar <= 122
                || e.KeyChar >= 65 && e.KeyChar <= 90
                || e.KeyChar == 8
                || e.KeyChar == 46
                || e.KeyChar == 32)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}