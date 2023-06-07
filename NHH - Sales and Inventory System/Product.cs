using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
namespace NHH___Sales_and_Inventory_System
{
    public partial class Product : Form
    {

        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ph");
            vProduct();
        }
        public static string sSave;
        private void Add_Click(object sender, EventArgs e)
        {
            sSave = "Add";
            ProdSet s = new ProdSet();
            s.ShowDialog();
            vProduct();
        }
        public static String sprodcode, sname, sunit, scategory;
        public static DateTime ddreceive;
        public static double dqty, dprice, dcrititem, dsprice, dbqty, dgqty;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ddreceive = Convert.ToDateTime(dgProduct.SelectedRows[0].Cells[0].Value);
                sprodcode = dgProduct.SelectedRows[0].Cells[1].Value.ToString();
                sname = dgProduct.SelectedRows[0].Cells[2].Value.ToString();
                sunit = dgProduct.SelectedRows[0].Cells[3].Value.ToString();
                dgqty = Convert.ToDouble(dgProduct.SelectedRows[0].Cells[4].Value);
                dbqty = Convert.ToDouble(dgProduct.SelectedRows[0].Cells[5].Value);
                dqty = Convert.ToDouble(dgProduct.SelectedRows[0].Cells[6].Value);
                dprice = Convert.ToDouble(dgProduct.SelectedRows[0].Cells[7].Value);
                dsprice = Convert.ToDouble(dgProduct.SelectedRows[0].Cells[8].Value);
                dcrititem = Convert.ToDouble(dgProduct.SelectedRows[0].Cells[10].Value);
                scategory = dgProduct.SelectedRows[0].Cells[11].Value.ToString();
            }
            catch { }
        }
        string sWhere;
        void vProduct()
        {
            LogIn.q = "SELECT dreceive `Date Received`,"
                + " prodcode `Product Code`,"
                + " name  `Product`,"
                + " Unit,"
                + " gqty `Good Qty`,"
                + " bqty `Bad Qty`,"
                + " Qty,"
                + " Price `Cost Price`,"
                + " sprice `Sale Price`,"
                + " '' `Total Sale`,"
                + " crititem  `Critical Item`,"
                + " Category FROM product" + sWhere;
            LogIn.vtable();
            dgProduct.DataSource = LogIn.table;
            dgProduct.Columns[0].DefaultCellStyle.Format = "MMM. dd, yyyy";
            dgProduct.Columns[1].Width = 100;
            dgProduct.Columns[2].Width = 300;
            dgProduct.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProduct.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProduct.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProduct.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProduct.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProduct.Columns[7].DefaultCellStyle.Format = "c";
            dgProduct.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProduct.Columns[8].DefaultCellStyle.Format = "c";
            dgProduct.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProduct.Columns[9].DefaultCellStyle.Format = "c";
            dgProduct.Columns[10].Visible = false;
            dgProduct.Columns[11].Visible = false;
            dWholePrice = 0;
            for (int a = 0; a < dgProduct.Rows.Count; a++)
            {
                dWholePrice = Convert.ToDouble(dgProduct.Rows[a].Cells[4].Value) * Convert.ToDouble(dgProduct.Rows[a].Cells[7].Value);
                dgProduct.Rows[a].Cells[9].Value = dWholePrice.ToString();
            }
        }
        double dWholePrice;
        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bnSearch_Click(object sender, EventArgs e)
        {
            vProduct();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            vProduct();
        }

        private void bnAddExisting_Click(object sender, EventArgs e)
        {

        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            if (dgProduct.Rows.Count > 0)
            {
                sSave = "Edit";
                ProdSet s = new ProdSet();
                s.ShowDialog();
                vProduct();
            }
            else
            {
                MessageBox.Show("You can't edit an empty information", "Unable to edit");
            }
        }
        Printing print;
        private bool SetupThePrinting()//==================
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;
            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;
            printDocument1.DocumentName = "Product Information";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            printDocument1.DefaultPageSettings.Landscape = MyPrintDialog.PrinterSettings.DefaultPageSettings.Landscape;
            print = new Printing(dgProduct, printDocument1, true, true, printDocument1.DocumentName
                , new Font("Tahoma", 18, FontStyle.Bold,
                GraphicsUnit.Point), Color.Black, true);
            return true;
        }
        private void bnPrint_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = printDocument1;
                MyPrintPreviewDialog.ShowDialog();
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = print.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == -1)
            {
                sWhere = "";
            }
            else if (cbSearch.SelectedIndex == 0)
            {
                sWhere = " where prodcode like '%" + txtKeyword.Text + "%'";
            }
            else if (cbSearch.SelectedIndex == 1)
            {
                sWhere = " where name like '" + txtKeyword.Text + "%'";
            }
            else if (cbSearch.SelectedIndex == 2)
            {
                sWhere = " where unit like '" + txtKeyword.Text + "%'";
            }
            vProduct();
        }

        private void bnAddQty_Click(object sender, EventArgs e)
        {
            sMarker = "1";
            vCall();
        }
        void vCall()
        {
            AddQuantity a = new AddQuantity();
            a.ShowDialog();
            Show();
            vProduct();
        }
        private void dgProduct_DoubleClick(object sender, EventArgs e)
        {
            sMarker = "1";
            vCall();
        }
        public static string sMarker;
        private void bnDefective_Click(object sender, EventArgs e)
        {
            sMarker = "0";
            vCall();
        }

        private void bnReturn_Click(object sender, EventArgs e)
        {
            if (dbqty > 0)
                if (MessageBox.Show("Do you want to return the bad quantity of " + sname + "(" + dbqty + ")?"
                    , "Return Product Confirmation"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    LogIn.q = "insert into retprod (retprodid, prodcode, userid,"
                        + " qty, retdate) values (null,'" + sprodcode
                        + "','" + LogIn.suserid
                        + "','" + dbqty
                        + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                    LogIn.vtable();
                    LogIn.q = "update product set qty = (qty - bqty),"
                        + " bqty = 0 where prodcode = '" + sprodcode
                        + "' and dreceive = '" + ddreceive.ToString("yyyy-MM-dd")
                        + "'";
                    LogIn.vtable();
                    vProduct();
                }
      

        }
    }
}