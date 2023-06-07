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
    public partial class CriticalItem : Form
    {
        public CriticalItem()
        {
            InitializeComponent();
        }

        private void wfCriticalItem_Load(object sender, EventArgs e)
        {
            LogIn.q = "SELECT distinct prodcode `Product Code`,"
                + " name `Product`,"//1
                + " Unit,"//2
                + " Category,"//3
                + " sum(qty) `Quantity`"//4
                + " FROM product where qty <= crititem group by prodcode order by name";
            LogIn.vtable();
            dgPurchase.DataSource = LogIn.table;
            dgPurchase.Columns[0].Width = 130;
            dgPurchase.Columns[1].Width = 350;
            dgPurchase.Columns[2].Width = 80;
            dgPurchase.Columns[3].Width = 80;
            dgPurchase.Columns[4].Width = 80;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.ApplicationClass();
            xlApp.Visible = true;
            xlApp.UserControl = false;
            xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath + @"\crititem", 0, true,
                5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int StartRow = 8;
            int a = 0;
            for (a = 0; a < dgPurchase.Rows.Count; a++)
            {
                xlWorkSheet.Cells[a + StartRow, 1] = dgPurchase.Rows[a].Cells[0].Value.ToString();
                xlWorkSheet.Cells[a + StartRow, 2] = dgPurchase.Rows[a].Cells[1].Value.ToString();
                xlWorkSheet.Cells[a + StartRow, 3] = dgPurchase.Rows[a].Cells[2].Value.ToString();
                xlWorkSheet.Cells[a + StartRow, 4] = dgPurchase.Rows[a].Cells[3].Value.ToString();
                xlWorkSheet.Cells[a + StartRow, 5] = dgPurchase.Rows[a].Cells[4].Value.ToString();
            }
            xlWorkSheet.Cells[a + 3 + StartRow, 5] = "Printed By: ";
            xlWorkSheet.Cells[a + 4 + StartRow, 5] = LogIn.sGName + " " + LogIn.sLName;
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
