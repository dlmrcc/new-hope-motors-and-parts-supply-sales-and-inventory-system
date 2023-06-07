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
    public partial class ReturnProduct : Form
    {
        public ReturnProduct()
        {
            InitializeComponent();
        }

        private void wfReturnProduct_Load(object sender, EventArgs e)
        {
            LogIn.q = "sELECT concat(u.fname,' ', u.lname) User,"//0
                + " p.name Product,"//1
                + " r.qty Quantity,"//2
                + " retdate `Return Date`"//3
                + " FROM retprod r left join (product p,user u)"
                + " on (p.prodcode = r.prodcode and u.userid = r.userid)";
            LogIn.vtable();
            dgProduct.DataSource = LogIn.table;
            dgProduct.Columns[0].Width = 200;
            dgProduct.Columns[1].Width = 200;
            dgProduct.Columns[3].DefaultCellStyle.Format = "MMM. dd, yyyy";
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
            xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath + @"\Returned Product", 0, true,
                5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int StartRow = 8;
            int a = 0;
            for (a = 0; a < dgProduct.Rows.Count; a++)
            {
                xlWorkSheet.Cells[a + StartRow, 1] = dgProduct.Rows[a].Cells[1].Value.ToString();
                xlWorkSheet.Cells[a + StartRow, 2] = dgProduct.Rows[a].Cells[2].Value.ToString();
                xlWorkSheet.Cells[a + StartRow, 3] = dgProduct.Rows[a].Cells[3].Value.ToString();
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

        private void bnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
