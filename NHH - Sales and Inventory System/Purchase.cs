using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
namespace NHH___Sales_and_Inventory_System
{
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
        }
        public static String sCustomerID;
        public static String sCustName;
        public static String sProdCode;
        public static String sProdName;
        string sPCode;
        double dPPrice;
        string sPUnit;
        double dPSPrice;
        double dPQty;
        string sPPName;
        void vProduct()
        {
            LogIn.q = "SELECT prodcode `Product Code`, name `Item `, price, sum(gqty), unit, sprice FROM product where"
                + " gqty > 0 and (prodcode like '" + txtSearch.Text
                + "%' or name like '" + txtSearch.Text
                + "%') " + sCategory
                + "group by prodcode order by name";
            LogIn.vtable();
            dgProd.DataSource = LogIn.table;
            dgProd.Columns[0].Visible = false;
            dgProd.Columns[2].Visible = false;
            dgProd.Columns[3].Visible = false;
            dgProd.Columns[4].Visible = false;
            dgProd.Columns[5].Visible = false;
            if (LogIn.table.Rows.Count > 0)
            {
                sProdCode = LogIn.table.Rows[0][0].ToString();
            }
        }
        string sCategory;
        void vCust()
        {
            LogIn.q = "SELECT customerid `Customer ID`, Companyname `Customer` FROM cust where companyname like '%" + txtSearchCust.Text
                + "%' and customerid != 'Supplier' order by companyname";
            LogIn.vtable();
            dgCusto.DataSource = LogIn.table;
            dgCusto.Columns[0].Visible = false;
        }
        private void wfPurchase_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ph");
            sCustomerID = "";
            dgPurchase.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgPurchase.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPurchase.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgPurchase.Columns[5].DefaultCellStyle.Format = "c";
            dgPurchase.Columns[6].DefaultCellStyle.Format = "c";
            vTotalAmount();
            vProduct();
            vprodType();
            cbCategory.SelectedIndex = 0;
            txtQty.Text = "1";
            vCust();
            sCustomerID = "";
        }
        void vprodType()
        {
            LogIn.q = "SELECT distinct category FROM product order by category";
            LogIn.vtable();
            cbCategory.Items.Add("View All");
            for (int a = 0; a < LogIn.table.Rows.Count; a++)
                cbCategory.Items.Add(LogIn.table.Rows[a][0]);
        }
        public static string sLegend;
        string sBillID;
        public static Double dTotalAmount;
        void vTotalAmount()
        {
            dTotalAmount = 0;
            for (int z = 0; z < dgPurchase.Rows.Count; z++)
                dTotalAmount += Convert.ToDouble(dgPurchase.Rows[z].Cells[6].Value);
            lbOthers.Text
                = "Total Amount: " + dTotalAmount.ToString("c");
        }
        void vPrint()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.ApplicationClass();
            xlApp.Visible = !true;
            xlApp.UserControl = false;
            xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath + @"\Purchase", 0, true,
                5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[4, 1] = DateTime.Now.ToString("dddd, MMM. dd, yyyy hh:mm:ss tt");
            int StartRow = 8;
            int a = 0;
            double dTotalItems = 0;
            for (a = 0; a < dgPurchase.Rows.Count; a++)
            {
                xlWorkSheet.Cells[a + StartRow, 1]
                    = dgPurchase.Rows[a].Cells[0].Value.ToString();

                xlWorkSheet.Cells[a + StartRow, 1 + 1]
                    = dgPurchase.Rows[a].Cells[1].Value.ToString();

                xlWorkSheet.Cells[a + StartRow, 1 + 2]
                  = Convert.ToDouble(dgPurchase.Rows[a].Cells[2].Value).ToString("c");

                xlWorkSheet.Cells[a + StartRow, 1 + 3]
                  = Convert.ToDouble(dgPurchase.Rows[a].Cells[3].Value).ToString("c");

                dTotalItems += Convert.ToDouble(dgPurchase.Rows[a].Cells[1].Value);
            }

            xlWorkSheet.Cells[a + 1 + StartRow, 2 + 1] = "Total Items:";
            xlWorkSheet.Cells[a + 1 + StartRow, 2 + 2]
                 = dTotalItems.ToString();
            xlWorkSheet.Cells[a + 2 + StartRow, 2 + 1] = "Total Amount:";
            xlWorkSheet.Cells[a + 2 + StartRow, 2 + 2]
                 = dTotalAmount.ToString("c");
            xlWorkSheet.Cells[a + 3 + StartRow, 2 + 1] = "Cash Rendered:";
            xlWorkSheet.Cells[a + 3 + StartRow, 2 + 2]
                 = Payment.dCash.ToString("c");
            xlWorkSheet.Cells[a + 4 + StartRow, 2 + 1] = "Balance:";
            xlWorkSheet.Cells[a + 4 + StartRow, 2 + 2]
                 = Payment.dBalance.ToString("c");
            xlWorkSheet.Cells[a + 5 + StartRow, 2 + 1] = "Change:";
            xlWorkSheet.Cells[a + 5 + StartRow, 2 + 2]
                 = Payment.dChange.ToString("c");
            xlWorkSheet.Cells[a + 6 + StartRow, 2 + 1] = "VAT (" + Payment.dVatValue + " %):";
            xlWorkSheet.Cells[a + 6 + StartRow, 2 + 2]
                 = Payment.dVat.ToString("c");
            xlWorkSheet.Cells[a + 7 + StartRow, 2 + 1] = "VATable:";
            xlWorkSheet.Cells[a + 7 + StartRow, 2 + 2]
                 = Payment.dVatable.ToString("c");
            xlWorkSheet.Cells[a + 8 + StartRow, 2 + 1] = "Customer:";
            xlWorkSheet.Cells[a + 8 + StartRow, 2 + 2]
                 = sCustName;
            xlWorkSheet.Cells[a + 9 + StartRow, 2 + 1] = "Cashier:";
            xlWorkSheet.Cells[a + 9 + StartRow, 2 + 2]
                 = LogIn.sLName;

            xlWorkSheet.Cells[6, 1] = "Receipt Number: " + sBillID;
            xlWorkSheet.PageSetup.PrintArea = "";
            xlWorkBook.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Process[] AllProcesses = Process.GetProcessesByName("excel");
            Hashtable myHashtable = new Hashtable();
            foreach (Process ExcelProcess in AllProcesses)
            {
        //        if (ExcelProcess.MainWindowTitle == "Microsoft Excel - Purchase.xls  [Read-Only]  [Compatibility Mode]")
         //           ExcelProcess.Kill();
            }
            AllProcesses = null;
        }

        private void bnPurchase_Click(object sender, EventArgs e)
        {
            int xx = 0, x;
            for (x = 0; x < dgPurchase.Rows.Count; x++)
            {
                if (sPPName + " (" + sPUnit + ")" ==
                    dgPurchase.Rows[x].Cells[0].Value.ToString())
                {
                    xx++;
                    break;
                }
            }
            if (xx == 0)
            {
                dgPurchase.Rows.Add(sPPName + " (" + sPUnit + ")"
                    , txtQty.Text
                    , dPPrice
                    , dPPrice * Convert.ToDouble(txtQty.Text)
                    , sPCode
                    , dPSPrice
                    , dPSPrice * Convert.ToDouble(txtQty.Text)
                    );
            }
            else
            {
                if (Convert.ToDouble(dgPurchase.Rows[x].Cells[1].Value) < dPQty)
                {
                    dgPurchase.Rows[x].Cells[1].Value
                        = Convert.ToDouble(dgPurchase.Rows[x].Cells[1].Value) + Convert.ToDouble(txtQty.Text);
                    dgPurchase.Rows[x].Cells[3].Value
                        = Convert.ToDouble(dgPurchase.Rows[x].Cells[1].Value)
                        * Convert.ToDouble(dgPurchase.Rows[x].Cells[2].Value);
                    dgPurchase.Rows[x].Cells[6].Value
                       = Convert.ToDouble(dgPurchase.Rows[x].Cells[1].Value)
                       * Convert.ToDouble(dgPurchase.Rows[x].Cells[5].Value);
                }
                else
                {
                    MessageBox.Show("Mali");
                }
            }
            vTotalAmount();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bnModify_Click(object sender, EventArgs e)
        {
            if (dgPurchase.Rows.Count > 0)
            {
                if (Convert.ToDouble(txtQty.Text) > dPQty)
                {
                    MessageBox.Show("Mali");
                }
                else
                {
                    dgPurchase.Rows[dgPurchase.CurrentCell.RowIndex].Cells[1].Value
                          = Convert.ToDouble(txtQty.Text);
                    dgPurchase.Rows[dgPurchase.CurrentCell.RowIndex].Cells[3].Value
                        = Convert.ToDouble(txtQty.Text)
                        * Convert.ToDouble(dgPurchase.Rows[dgPurchase.CurrentCell.RowIndex].Cells[2].Value);
                    dgPurchase.Rows[dgPurchase.CurrentCell.RowIndex].Cells[6].Value
                        = Convert.ToDouble(txtQty.Text)
                        * Convert.ToDouble(dgPurchase.Rows[dgPurchase.CurrentCell.RowIndex].Cells[5].Value);
                }
                vTotalAmount();
            }
        }

        private void bnRemove_Click(object sender, EventArgs e)
        {
            if (dgPurchase.Rows.Count > 0)
            {
                if (MessageBox.Show("Do you want to delete "
                    + dgPurchase.Rows[dgPurchase.CurrentCell.RowIndex].Cells[0].Value.ToString()
                    + "?"
                    , "Confirm Delete"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    dgPurchase.Rows.RemoveAt(dgPurchase.CurrentCell.RowIndex);
                }
                vTotalAmount();
            }
        }

        private void bnPayment_Click(object sender, EventArgs e)
        {
            if (dgPurchase.Rows.Count > 0)
            {
                Payment p = new Payment();
                p.ShowDialog();
                if (Payment.bStatus == true)
                {
                    LogIn.q = "SELECT count(billid) FROM billing"
                        + " where billdate like '" + DateTime.Now.ToString("yyyy-MM") + "%'";
                    LogIn.vtable();
                    sBillID = DateTime.Now.ToString("yyyy-MM-")
                        + (Convert.ToInt32(LogIn.table.Rows[0][0]) + 1).ToString("d4");
                    if (ReceiptID.bStatus == false)
                    {
                        LogIn.q = "insert into billing (billid, userid, custid, billdate, flag) values ('"
                            + sBillID
                            + "','" + LogIn.suserid
                            + "','" + sCustomerID
                            + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            + "','" + "1" + "')";
                        LogIn.vtable();
                    }
                    else
                    {
                        sBillID = ReceiptID.sBillID;
                        LogIn.q = "update sub set flag = '1' where billid = '" + sBillID + "'";
                        LogIn.vtable();
                        for (int a = 0; a < ReceiptID.iCounter; a++)
                        {
                            LogIn.q = "select dreceive from product where prodcode = '" + ReceiptID.sProdCode[a]
                                + "' order by dreceive desc limit 1";
                            LogIn.vtable();
                            string sRecDate = Convert.ToDateTime(LogIn.table.Rows[0][0]).ToString("yyyy-MM-dd");
                            LogIn.q = "update product set qty = (qty + " + ReceiptID.dQty[a]
                                + "), gqty = (gqty + " + ReceiptID.dQty[a]
                                + ") where prodcode = '" + ReceiptID.sProdCode[a]
                                + "' and dreceive = '" + sRecDate + "'";
                            LogIn.vtable();
                        }
                    }
                    for (int a = 0; a < dgPurchase.Rows.Count; a++)
                    {
                        LogIn.q = "select count(subid) from sub"
                            + " where subdate like '" + DateTime.Now.ToString("yyyy-MM") + "%'";
                        LogIn.vtable();
                        string sSubID = DateTime.Now.ToString("yyyy-MM-")
                        + (Convert.ToInt32(LogIn.table.Rows[0][0]) + 1).ToString("d5");
                        LogIn.q = "insert into sub (subid, billid, prodcode, price,"
                            + " qty, amount, subdate, sprice, samount, flag) values ('" + sSubID
                            + "','" + sBillID
                            + "','" + dgPurchase.Rows[a].Cells[4].Value
                            + "','" + dgPurchase.Rows[a].Cells[2].Value
                            + "','" + dgPurchase.Rows[a].Cells[1].Value
                            + "','" + dgPurchase.Rows[a].Cells[3].Value
                            + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            + "','" + dgPurchase.Rows[a].Cells[5].Value
                            + "','" + dgPurchase.Rows[a].Cells[6].Value
                            + "','0')";
                        LogIn.vtable();
                        double ddQty = Convert.ToDouble(dgPurchase.Rows[a].Cells[1].Value);
                        string sPRodCode = dgPurchase.Rows[a].Cells[4].Value.ToString();


                        LogIn.q = "SELECT gqty, dreceive FROM product where prodcode = '"
                            + sPRodCode + "' and gqty > 0 order by dreceive";
                        LogIn.vtable();
                        for (int d = 0; d < LogIn.table.Rows.Count; d++)
                        {
                            string sDateRec = Convert.ToDateTime(LogIn.table.Rows[d][1]).ToString("yyyy-MM-dd");
                            double dbQty = Convert.ToDouble(LogIn.table.Rows[d][0]);
                            double dCounter = ddQty;
                            ddQty = ddQty - dbQty;
                            if (ddQty > 0)
                            {
                                LogIn.q = "update product set gqty = (gqty - '" + dbQty
                                    + "'), qty = (qty - '" + dbQty
                                    + "') where prodcode = '" + sPRodCode
                                    + "' and dreceive = '" + sDateRec + "'";
                                LogIn.vtable1();
                            }
                            else
                            {
                                LogIn.q = "update product set gqty = (gqty - '" + dCounter
                                    + "'), qty = (qty - '" + dCounter
                                    + "') where prodcode = '" + sPRodCode
                                    + "' and dreceive = '" + sDateRec + "'";
                                LogIn.vtable1();
                                break;
                            }
                        }
                    }
                    double dMoney = 0;
                    if (dTotalAmount > Payment.dCash)
                        dMoney = Payment.dCash;
                    else
                        dMoney = dTotalAmount;
                    LogIn.q = "select count(payid) from payment where paydate like '"
                        + DateTime.Now.ToString("yyyy-MM") + "%'";
                    LogIn.vtable();
                    string sPayID = DateTime.Now.ToString("yyyy-MM-")
                        + (Convert.ToInt32(LogIn.table.Rows[0][0]) + 1).ToString("d5");
                    if (Payment.dCash != 0)
                    {
                        LogIn.q = "insert into payment (payid, amount, cash, billid, paydate,"
                            + " vat, vatable) values ('" + sPayID
                            + "','" + Payment.dTotalAmount
                            + "','" + Payment.dMoney
                            + "','" + sBillID
                            + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            + "','" + Payment.dVat.ToString("f")
                            + "','" + Payment.dVatable.ToString("f") + "')";
                        LogIn.vtable();
                    }
                    if (Payment.dCash >= dTotalAmount||Payment.dChange==0)
                    {
                        LogIn.q = "update billing set flag = '0' where billid = '" + sBillID + "'";
                        LogIn.vtable();
                    }
                    vPrint();
                    if (ReceiptID.bStatus == true)
                    {
                        ReceiptID.bStatus = false;
                        dgPurchase.Rows.Clear();
                        bnReturn.Text = "Return Product";
                        dgCusto.Enabled = true;
                        txtSearchCust.Enabled = true;
                        ReceiptID.dCash = 0;
                        lbPrevPayment.Text = "";
                    }
                    dgPurchase.Rows.Clear();
                    vProduct();
                }
            }
            vTotalAmount();
            vCust();
            sCustomerID = "";           
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            sCategory = " and category like '%'";
            if (cbCategory.SelectedIndex > 0)
                sCategory = "and category = '" + cbCategory.Text + "'";
            vProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            vProduct();
        }

        private void bnReturn_Click(object sender, EventArgs e)
        {
            if (bnReturn.Text == "Return Product")
            {
                if (dgPurchase.Rows.Count == 0)
                {
                    ReceiptID r = new ReceiptID();
                    r.ShowDialog();
                    if (ReceiptID.bStatus == true)
                    {
                        for (int a = 0; a < ReceiptID.iCounter; a++)
                        {
                            dgPurchase.Rows.Add(ReceiptID.sProduct[a] + " (" + ReceiptID.sUnit[a] + ")"
                                , ReceiptID.dQty[a]
                                , ReceiptID.dPrice[a]
                                , ReceiptID.dAmount[a]
                                , ReceiptID.sProdCode[a]
                                , ReceiptID.dsPrice[a]
                                , ReceiptID.dsAmount[a]);
                        }
                        vTotalAmount();
                        txtSearchCust.Text = ReceiptID.sCompany;
                        dgCusto.Enabled = false;
                        txtSearchCust.Enabled = false;
                        lbPrevPayment.Text = "Previous Payment: " + ReceiptID.dCash.ToString("c");
                        bnReturn.Text = "Cancel Return";
                    }
                }
            }
            else
            {
                dgPurchase.Rows.Clear();
                bnReturn.Text = "Return Product";
                dgCusto.Enabled = true;
                txtSearchCust.Enabled = true;
                ReceiptID.dCash = 0;
                lbPrevPayment.Text = "";
            }
        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            vCust();
        }

        private void dgProd_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //int iIndex = dgProd.CurrentCell.RowIndex;
                int iIndex = 0;
                sPCode = dgProd.SelectedRows[iIndex].Cells[0].Value.ToString();
                sPPName = dgProd.SelectedRows[iIndex].Cells[1].Value.ToString();
                dPPrice = Convert.ToDouble(dgProd.SelectedRows[iIndex].Cells[2].Value);
                dPQty = Convert.ToDouble(dgProd.SelectedRows[iIndex].Cells[3].Value);
                sPUnit = dgProd.SelectedRows[iIndex].Cells[4].Value.ToString();
                dPSPrice = Convert.ToDouble(dgProd.SelectedRows[iIndex].Cells[5].Value);
                //sPCode = dgProd.Rows[iIndex].Cells[0].Value.ToString();
                //sPPName = dgProd.Rows[iIndex].Cells[1].Value.ToString();
                //dPPrice = Convert.ToDouble(dgProd.Rows[iIndex].Cells[2].Value);
                //dPQty = Convert.ToDouble(dgProd.Rows[iIndex].Cells[3].Value);
                //sPUnit = dgProd.Rows[iIndex].Cells[4].Value.ToString();
                //dPSPrice = Convert.ToDouble(dgProd.Rows[iIndex].Cells[5].Value);
            }
            catch { sPCode = ""; }
        }

        private void dgCusto_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                sCustomerID = dgCusto.SelectedRows[0].Cells[0].Value.ToString();
                sCustName = dgCusto.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch { }
        }
    }
}