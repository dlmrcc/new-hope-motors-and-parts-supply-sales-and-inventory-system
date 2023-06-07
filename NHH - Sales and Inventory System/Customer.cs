using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Globalization;                                   //
using System.Threading;                                       //
using Excel = Microsoft.Office.Interop.Excel;                 //
using System.Reflection;                                      //
using System.Diagnostics;                                     //
using System.Collections;                                     
namespace NHH___Sales_and_Inventory_System
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();

        }

        private void Customer_Load(object sender, EventArgs e)
        {              //CustomerID, CompanyName, ContactNumber, Address, Year
            LogIn.q = "select CustomerID,"//0
                + " CompanyName,"//1
                + " ContactNumber,"//2
                + " Address"//3
                + " from cust where CustomerID != 'None' and (CustomerID != 'Supplier' and CustomerID != '1') and companyname like '%" + txtSearch.Text + "%'";
            LogIn.vtable();
            dataGridView1.DataSource = LogIn.table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lbResult.Text = dataGridView1.Rows.Count.ToString() + " customer result has found!";
        }
        public static string sAdd;
        private void bnAdd_Click(object sender, EventArgs e)
        {
            Customer.sAdd = "Add";
            CustSet a = new CustSet();
            a.StartPosition = FormStartPosition.CenterScreen;
            a.FormBorderStyle = FormBorderStyle.FixedSingle;
            a.ShowDialog();
            Customer_Load(sender, e);
        }
        public static string sCustomerID, sCompanyName, sContactNumber, sAddress;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                sCustomerID = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                sCompanyName = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                sContactNumber = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                sAddress = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            }
            catch { }
        }
        private void bnEdit_Click(object sender, EventArgs e)
        {
            Customer.sAdd = "Edit";
            CustSet a = new CustSet();
            a.StartPosition = FormStartPosition.CenterScreen;
            a.FormBorderStyle = FormBorderStyle.FixedSingle;
            a.ShowDialog();
            Customer_Load(sender, e);
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Customer_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.ApplicationClass();
            xlApp.Visible = true;
            xlApp.UserControl = false;
            xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath + @"\cust", 0, true,
                5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int StartRow = 8;
            int a = 0;
            for (a = 0; a < dataGridView1.Rows.Count; a++)
            {
                xlWorkSheet.Cells[a + StartRow, 1] = dataGridView1.Rows[a].Cells[1].Value.ToString();
                xlWorkSheet.Cells[a + StartRow, 2] = dataGridView1.Rows[a].Cells[2].Value.ToString();
                xlWorkSheet.Cells[a + StartRow, 3] = dataGridView1.Rows[a].Cells[3].Value.ToString();
            }
            xlWorkSheet.Cells[a + 3 + StartRow, 3] = "Printed By: ";
            xlWorkSheet.Cells[a + 4 + StartRow, 3] = LogIn.sGName + " " + LogIn.sLName;
            xlWorkBook.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Process[] AllProcesses = Process.GetProcessesByName("excel");
            Hashtable myHashtable = new Hashtable();
            foreach (Process ExcelProcess in AllProcesses)
            {
                ExcelProcess.Kill();
            }
            AllProcesses = null;

      

        }
    }
}