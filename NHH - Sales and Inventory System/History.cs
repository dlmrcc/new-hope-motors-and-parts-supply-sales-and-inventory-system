using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }
        void vLoad()
        {//q = "SELECT logid,concat(u.fname,' ',u.lname) `USER`, Login `LOG - IN`, logout `LOG - OUT` FROM loghistory l left join (`user` u) on (u.userid = l.userid) where Login between '2010-03-01 00:00:00' and '2013-03-01 23:59:59' and  u.userid 001-003"
            LogIn.q = "SELECT logid,concat(u.fname,' ',u.lname) `USER`,"
                + " Login `LOG - IN`,"
                + " logout `LOG - OUT`"
                + " FROM loghistory l left join (`user` u) on (u.userid = l.userid) where Login between '" + dtFrom.Value.ToString("yyyy-MM-dd 00:00:00")
                + "' and '" + dtTo.Value.ToString("yyyy-MM-dd 23:59:59") + "' and " + sUserID;
            LogIn.vtable();
            dataGridView1.DataSource = LogIn.table;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].DefaultCellStyle.Format = "MMM. dd, yyyy hh:mm:ss tt";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "MMM. dd, yyyy hh:mm:ss tt";
        }
        private void LogHistory_Load(object sender, EventArgs e)
        {
            vUser();
            cbUser.SelectedIndex = 0;
        }
        String[] aUserID;
        string sUserID;
        void vUser()
        {
            LogIn.q = "SELECT concat(fname,' ',lname), userid FROM `user`";
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
            printDocument1.DocumentName = "Log History";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            printDocument1.DefaultPageSettings.Landscape = MyPrintDialog.PrinterSettings.DefaultPageSettings.Landscape;
            print = new Printing(dataGridView1, printDocument1, false, false, "Log History"
                , new Font("Tahoma", 18, FontStyle.Bold,
                GraphicsUnit.Point), Color.Black, true);
            return true;
        }
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            bool more = print.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            sUserID = " u.userid like '%'";
            if(cbUser.SelectedIndex>0)
            {
                sUserID = " u.userid = '" + aUserID[cbUser.SelectedIndex - 1] + "'";
            }
            vLoad();
        }
        
        private void dtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                vLoad();
        }

        private void dtTo_KeyDown(object sender, KeyEventArgs e)
        {
            dtFrom_KeyDown(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}