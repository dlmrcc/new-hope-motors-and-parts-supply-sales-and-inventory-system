using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NHH___Sales_and_Inventory_System
{
    public partial class LogIn : Form
    {
        public static MySqlConnection cn = new MySqlConnection("data source = localhost; username = root; database = hope;");
        public static MySqlDataAdapter da = new MySqlDataAdapter();
        public static DataTable table;
        public static DataTable table1;
        public static MySqlCommand cmd;
        public static String q;
        public static void vtable()
        {
            table = new DataTable();
            da.SelectCommand = new MySqlCommand(q, cn);
            da.Fill(LogIn.table);
        }
        public static void vtable1()
        {
            table1 = new DataTable();
            da.SelectCommand = new MySqlCommand(q, cn);
            da.Fill(LogIn.table1);
        }
        public LogIn()
        {
            InitializeComponent();
        }
        public static String suserid;
        public static String susername;
        public static String spassword;
        public static String sGName;
        public static String sLName;
        public static String sUsertype;
        public static String sUserstatus;
        public static String SecurityQuestion;
        public static String SecurityAnswer;
        public static String sContactnumber;
        public static String sDateRegister;
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public static double dVat;
        public static void vVat()
        {
            LogIn.q = "SELECT value FROM vat";
            LogIn.vtable();
            dVat = Convert.ToDouble(LogIn.table.Rows[0][0]);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            q = "SELECT userid,"//0
                + " username,"//01
                + " password,"//02
                + " FName,"//03
                + " LName,"//04
                + " Usertype,"//05
                + " Userstatus,"//06
                + " SecurityQuestion,"//07
                + " SecurityAnswer,"//08
                + " `Date Register` FROM user"//10
                + " where username = '" + txtUsername.Text
                + "' and password = '" + txtPassword.Text + "'";
            vtable();
            if (table.Rows.Count > 0)
            {
                suserid = table.Rows[0][0].ToString();
                susername = table.Rows[0][1].ToString();
                spassword = table.Rows[0][2].ToString();
                sGName = table.Rows[0][3].ToString();
                sLName = table.Rows[0][4].ToString();
                sUsertype = table.Rows[0][5].ToString();
                sUserstatus = table.Rows[0][6].ToString();
                SecurityQuestion = table.Rows[0][7].ToString();
                SecurityAnswer = table.Rows[0][8].ToString();
                sDateRegister = table.Rows[0][9].ToString();
                //sContactnumber = table.Rows[0][10].ToString();
                if (sUserstatus == "Active")
                {
                    Hide();
                    string sLogIn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    q = "insert into loghistory (LogId, UserId, LOgIn, LogOut) values (null,'" + suserid
                        + "', '" + sLogIn
                        + "',null)";
                    vtable();
                    Home f = new Home();
                    f.WindowState = FormWindowState.Maximized;
                    f.ShowDialog();
                    Show();
                    q = "update loghistory set logout = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        + "' where userid = '" + suserid + "' and login = '" + sLogIn + "'";
                    LogIn.vtable();
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    txtUsername.Focus();
                }
                else
                {
                    MessageBox.Show("Your account is currently blocked.", "Please contact your administrator");
                    txtUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgot_Password f = new Forgot_Password();
            Hide(); 
            f.ShowDialog();
            Show();
        }
        public static String sText;
        public static void vLeave()
        {
            sText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sText);
        }
        private void bnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static TextBox txtToolTipText;
        public static void vKeyLettersAndSpace(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if ((e.KeyChar >= 97 && e.KeyChar <= 122)
                || (e.KeyChar >= 65 && e.KeyChar <= 90)
                || e.KeyChar == 32 || e.KeyChar == 8)
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nA - Z (Lower and Uppercase)\nSpace", txtToolTipText);
            }
        }

        public static String[] sArrayAddress;
        public static String sOldValue;
        public static String sNewValue;
        public static void vAllowSingleQuote()
        {
            sNewValue = "";
            sArrayAddress = sOldValue.Split('\'');
            for (int a = 0; a < sArrayAddress.Length; a++)
            {
                if (a < sArrayAddress.Length - 1)
                    sNewValue += sArrayAddress[a].ToString() + "\\'";
                else
                    sNewValue += sArrayAddress[a].ToString();
            }
        }

        public static void vKeyLetters(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if ((e.KeyChar >= 97 && e.KeyChar <= 122)
                || (e.KeyChar >= 65 && e.KeyChar <= 90)
                || e.KeyChar == 8)
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nA - Z (Lower and Uppercase)", txtToolTipText);
            }
        }
        public static void vKeyNumbers(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if ((e.KeyChar >= 48 && e.KeyChar <= 57)
                || e.KeyChar == 8)
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nNumbers)", txtToolTipText);
            }
        }
        public static void vKeyNumbersAndPeriod(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if (((e.KeyChar >= 48 && e.KeyChar <= 57)
                || e.KeyChar == 8)||( e.KeyChar == 46) && (txtToolTipText.Text.IndexOf('.') == -1))
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nNumbers)", txtToolTipText);
            }
        }
        public static ToolTip tt = new ToolTip();
        public static void vKeyLettersAndNumbers(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if ((e.KeyChar >= 97 && e.KeyChar <= 122)
                || (e.KeyChar >= 65 && e.KeyChar <= 90)
                || (e.KeyChar >= 48 && e.KeyChar <= 57)
                || e.KeyChar == 8 || e.KeyChar == 95)
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nLetters from A - Z (Lower and Uppercase)\nNumbers", txtToolTipText);
            }
        }
        public static void vKeysOthers(KeyPressEventArgs e)
        {// @ # space ' letters numbers & ( ) / . ,
            tt.RemoveAll();
            if ((e.KeyChar >= 97 && e.KeyChar <= 122)
                || (e.KeyChar >= 64 && e.KeyChar <= 90)
                || (e.KeyChar >= 44 && e.KeyChar <= 57)
                || e.KeyChar == 8 || e.KeyChar == 32
                || e.KeyChar == 35 || (e.KeyChar >= 38
                && e.KeyChar <= 41))
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nLetters from A - Z (Lower and Uppercase)"
                    + "\nNumbers\n@ / % ' & ( ) , . -", txtToolTipText);
            }
        }
        public static void vKeysToolStripOtherKeys(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if ((e.KeyChar >= 97 && e.KeyChar <= 122)
                || (e.KeyChar >= 64 && e.KeyChar <= 90)
                || (e.KeyChar >= 44 && e.KeyChar <= 57)
                || e.KeyChar == 8 || e.KeyChar == 32
                || e.KeyChar == 35 || (e.KeyChar >= 38
                && e.KeyChar <= 41))
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nLetters from A - Z (Lower and Uppercase)"
                    + "\nNumbers\n@ / % ' & ( ) , . -", tsTxt);
            }
        }
        public static void vKeysToolStripvKeyLettersAndNumbers(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if ((e.KeyChar >= 97 && e.KeyChar <= 122)
                || (e.KeyChar >= 65 && e.KeyChar <= 90)
                || (e.KeyChar >= 48 && e.KeyChar <= 57)
                || e.KeyChar == 8)
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nLetters from A - Z (Lower and Uppercase)\nNumbers", tsTxt);
            }
        }

        public static void vKeysToolStripvKeyLettersAndSpace(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if ((e.KeyChar >= 97 && e.KeyChar <= 122)
                || (e.KeyChar >= 65 && e.KeyChar <= 90)
                || e.KeyChar == 32 || e.KeyChar == 8)
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nA - Z (Lower and Uppercase)\nSpace", tsTxt);
            }
        }
        public static void vKeysToolStripvKeyLetters(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            if ((e.KeyChar >= 97 && e.KeyChar <= 122)
                || (e.KeyChar >= 65 && e.KeyChar <= 90)
                || e.KeyChar == 8)
                e.Handled = false;
            else
            {
                e.Handled = true;
                tt.Show("The accepted keys are the following.\nA - Z (Lower and Uppercase)", tsTxt);
            }
        }
        public static ToolStrip tsTxt;
        public static void vKeysAll(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            e.Handled = true;
            tt.Show("None accepted keys are Available.\n", tsTxt);
        }
        public static ComboBox cbTipText;
        public static void vKeysCb(KeyPressEventArgs e)
        {
            tt.RemoveAll();
            e.Handled = true;
            tt.Show("None accepted keys are Available.\n", cbTipText);
        }
        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Do you want to exit?", "Confirm exit", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}