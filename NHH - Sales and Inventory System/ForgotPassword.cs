using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class Forgot_Password : Form
    {
        public Forgot_Password()
        {
            InitializeComponent();
        }
        string sSecAns, sPassword;
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Enabled == false)
            {
                if (sSecAns.ToUpper() == txtSecAns.Text.ToUpper())
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                }
                else
                {
                    MessageBox.Show("Your Security Answer didn't match", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                LogIn.q = "SELECT  password,SecurityQuestion, SecurityAnswer FROM `user` where username= '" + txtUsername.Text + "'";
                LogIn.vtable();
                if (LogIn.table.Rows.Count != 0)
                {
                    sPassword = LogIn.table.Rows[0][LogIn.table.Columns[0], DataRowVersion.Current].ToString();
                    lbSecQues.Text = LogIn.table.Rows[0][LogIn.table.Columns[1], DataRowVersion.Current].ToString();
                    sSecAns = LogIn.table.Rows[0][LogIn.table.Columns[2], DataRowVersion.Current].ToString();
                    txtUsername.Enabled = false;
                    lbSA.Visible = true;
                    lbSecQues.Visible = true;
                    lbSQ.Visible = true;
                    txtSecAns.Visible = true;
                }

                else
                {
                    MessageBox.Show("Username does not exist!");
                }


            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your password is (" + sPassword + ")", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (txtNewPassword.Text.Length < 5)
            {
                MessageBox.Show("New password must be at least 6 characters", "Characters is too short");
                txtNewPassword.Focus();
            }
            else if (txtRetypePassword.Text.Length < 5)
            {
                MessageBox.Show("Retypepassword must be at least 6 characters", "Characaters is too short");
                txtRetypePassword.Focus();
            }
            else
            {
                if (txtRetypePassword.Text == txtNewPassword.Text)
                {
                    LogIn.q = "update user set password = '" + txtNewPassword.Text + "'where username = '" + txtUsername.Text + "'";
                    LogIn.vtable();
                    MessageBox.Show("Password has been succesfully change.", "Password Change");
                    Close();
                }
                else
                {
                    MessageBox.Show("New and re-type password did'n match!","Invalid input");
                    txtNewPassword.Clear();
                    txtRetypePassword.Clear();
                    txtNewPassword.Focus();
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
 