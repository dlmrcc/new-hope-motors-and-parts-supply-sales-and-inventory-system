using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class ReceiptID : Form
    {
        public ReceiptID()
        {
            InitializeComponent();
        }

        private void wfReceiptID_Load(object sender, EventArgs e)
        {
            bStatus = false;
            dCash = 0;
            txt1.Focus();
        }

        private void txtReceiptNum_KeyDown(object sender, KeyEventArgs e)
        {
            txt3_KeyDown(sender, e);
        }
        public static String sReceiptNum;
        private void txtReceiptNum_TextChanged(object sender, EventArgs e)
        {
            if (txt1.Text.Length >= 4)
                txt2.Focus();
            if (txt1.Text.Length == 5)
                txt1.Text = txt1.Text.Remove(txt1.Text.Length - 1);
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            if (txt2.Text.Length >= 2)
                txt3.Focus();
            if (txt2.Text.Length == 3)
                txt2.Text = txt2.Text.Remove(txt2.Text.Length - 1);
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 && txt2.Text.Length == 1)
                txt1.Focus();
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 && txt3.Text.Length == 1)
                txt2.Focus();
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            if (txt3.Text.Length == 5)
                txt3.Text = txt3.Text.Remove(txt3.Text.Length - 1);
        }
        public static Int32 iCounter;
        public static String sBillID;
        private void txt3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sReceiptNum = txt1.Text + "-" + txt2.Text + "-" + txt3.Text;
                LogIn.q = "SELECT distinct c.companyname,"//0
                    + " p.name,"//1
                    + " s.qty,"//2
                    + " s.price,"//3
                    + " s.amount,"//4
                    + " p.unit,"//5
                    + " p.prodcode,"//6
                    + " s.sprice,"//7
                    + " s.samount,"//8
                    + " b.billdate,"//9
                    + " b.billid"//10
                    + " FROM sub s left join (billing b, product p, cust c, payment py)"
                    + " on (b.billid = s.billid and p.prodcode = s.prodcode"
                    + " and c.customerid = b.custid) where b.billid = '" + sReceiptNum
                    + "' and s.flag = '0'";
                LogIn.vtable();
                bStatus = false;
                iCounter = LogIn.table.Rows.Count;
                if (LogIn.table.Rows.Count > 0)
                {
                    bStatus = true;
                    sProduct = new String[LogIn.table.Rows.Count];
                    dQty = new Double[LogIn.table.Rows.Count];
                    dPrice = new Double[LogIn.table.Rows.Count];
                    dAmount = new Double[LogIn.table.Rows.Count];
                    sUnit = new String[LogIn.table.Rows.Count];
                    sProdCode = new String[LogIn.table.Rows.Count];
                    dsPrice = new Double[LogIn.table.Rows.Count];
                    dsAmount = new Double[LogIn.table.Rows.Count];
                    for (int a = 0; a < LogIn.table.Rows.Count; a++)
                    {
                        sCompany = LogIn.table.Rows[0][0].ToString();
                        sProduct[a] = LogIn.table.Rows[a][1].ToString();
                        dQty[a] = Convert.ToDouble(LogIn.table.Rows[a][2]);
                        dPrice[a] = Convert.ToDouble(LogIn.table.Rows[a][3]);
                        dAmount[a] = Convert.ToDouble(LogIn.table.Rows[a][4]);
                        sUnit[a] = LogIn.table.Rows[a][5].ToString();
                        sProdCode[a] = LogIn.table.Rows[a][6].ToString();
                        dsPrice[a] = Convert.ToDouble(LogIn.table.Rows[a][7]);
                        dsAmount[a] = Convert.ToDouble(LogIn.table.Rows[a][8]);
                        dtBillDate = Convert.ToDateTime(LogIn.table.Rows[0][9]);
                        sBillID = LogIn.table.Rows[0][10].ToString();
                       
                    } LogIn.q = "SELECT SUM(CASH) FROM PAYMENT WHERE billid = '" + sReceiptNum + "'";
                        LogIn.vtable();
                        dCash = 0;
                        if (LogIn.table.Rows.Count > 0)
                            dCash = Convert.ToDouble(LogIn.table.Rows[0][0]);
                    Close();
                }
                else
                {
                    bStatus = false;
                    MessageBox.Show("Receipt Number does not exist.", "Invalid Receipt Number");
                    txt1.Clear();
                    txt2.Clear();
                    txt3.Clear();
                    txt1.Focus();
                }
               
            }
        }
        public static Boolean bStatus = false;
        public static String sCompany;
        public static String[] sProduct;
        public static Double[] dQty;
        public static Double[] dPrice;
        public static Double[] dAmount;
        public static String[] sUnit;
        public static String[] sProdCode;
        public static Double[] dsPrice;
        public static Double[] dsAmount;
        public static DateTime dtBillDate;
        public static Double dCash;
        private void txt2_KeyDown(object sender, KeyEventArgs e)
        {
            txt3_KeyDown(sender, e);
        }
    }
}