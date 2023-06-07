using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            LogIn.q = "SELECT"
                + " userid,"
                + " username AS `Username`,"//1
                + " password,"//2
                + " FName," //3
                + " LName," //4
                + " concat(fname,' ',lname) as User,"//5
                //+ " connum as `Contact Number`,"//6
                + " Usertype as`User Type`, userstatus `User Status` FROM `user` where USERNAME like '" + textBox1.Text + "%'";
            LogIn.vtable();
            dataGridView1.DataSource = LogIn.table;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            lbresult.Text = dataGridView1.Rows.Count.ToString() + " User result has found!";
        }
        public static String USERID, USERNAME, password, FName, LName, fullname, USERTYPE, USERSTATUS, SecurityQuestion, SecurityAnswer, CONTACTNUMBER, DateRegister;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                USERID = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                cbUsertype.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
                cbUserStatus.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
            }
            catch
            {
                USERID = "";
                cbUsertype.Text = "";
                cbUserStatus.Text = "";
            }
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            User_Load(sender, e);
        }
        public static string sSave;
        private void button1_Click_1(object sender, EventArgs e)
        {
            sSave = "Add";
            vCall(sender, e);
        }
        void vCall(object sender, EventArgs e)
        {
            User_Settings u = new User_Settings();
            u.StartPosition = FormStartPosition.CenterScreen;
            u.ShowDialog();
            User_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbUsertype.Text != dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString() ||
                cbUserStatus.Text != dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString())
            {
                LogIn.q = "update user set Usertype = '" + cbUsertype.Text
                   + "', Userstatus = '" + cbUserStatus.Text
                   + "' where userid ='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                LogIn.vtable();
                User_Load(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}