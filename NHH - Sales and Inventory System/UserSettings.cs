using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace NHH___Sales_and_Inventory_System
{
    public partial class User_Settings : Form
    {
        public User_Settings()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void User_Settings_Load(object sender, EventArgs e)
        {
            if (User.sSave == "Edit")
            {
                txtUsername.Text = LogIn.susername;
                txtPassword.Text = LogIn.spassword;
                txtRetypePassword.Text = LogIn.spassword;
                txtFirstname.Text = LogIn.sGName;
                txtLastname.Text = LogIn.sLName;
                //txtContactnumber.Text = wfLogIn.sContactnumber;
                cbSecurityQuestion.Text = LogIn.SecurityQuestion;
                txtSecurityAnswer.Text = LogIn.SecurityAnswer;
            }
            CancelButton = bnCancel;
        }
        string sUserID;
        int iUserID;
        void vUserID()
        {
            LogIn.q = "SELECT userid FROM `user` where `date register` like '" + DateTime.Now.ToString("yyyy") + "%'";
            LogIn.vtable();
            iUserID = LogIn.table.Rows.Count;
            sUserID = DateTime.Now.ToString("yyyy") + "-U-" + (iUserID + 1).ToString("d4");
        }
        string dbUsername;
        string dbFullname;
        //userid, username, password, FName, LName, Usertype, Userstatus, SecurityQuestion, SecurityAnswer, Contactnumber, Date Register
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length < 5)
            {
                MessageBox.Show("UsUrname must be at 6 characters", "Username is too short", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsername.Focus();
            }
            else if (txtPassword.Text.Length < 5)
            {
                MessageBox.Show("Password must be at least 6 characters", "Password is too short", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
            }
            else if (txtRetypePassword.Text.Length < 5)
            {
                MessageBox.Show("Re-type password must be at least 6 charactes", "Re-type password is too short", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRetypePassword.Focus();
            }
            else if (txtFirstname.Text == "")
            {
                MessageBox.Show("Firstname must not be empty", "Firstname is empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFirstname.Focus();
            }
            else if (txtLastname.Text == "")
            {
                MessageBox.Show("Lastname must not be empty", " Lastname is empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLastname.Focus();
            }
            else if (cbSecurityQuestion.Text == "")
            {
                MessageBox.Show("Please select at least one security question", "Select security question", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbSecurityQuestion.Focus();
            }
            else if (txtSecurityAnswer.Text == "")
            {
                MessageBox.Show("Security Question must not be empty", "Security Quetion is empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSecurityAnswer.Focus();
            }
            else
            {
                if (txtPassword.Text != txtRetypePassword.Text)
                {
                    MessageBox.Show("Password and re-type password didn't match", "Did not match ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Focus();
                }
                else
                {
                    if (User.sSave == "Add")
                    {
                        LogIn.q = "SELECT userid FROM `user` where username = '" + txtUsername.Text + "' or concat(Fname,' ',Lname) = '" + txtFirstname.Text + " " + txtLastname.Text + "'";
                        LogIn.vtable();
                        if (LogIn.table.Rows.Count != 0)
                        {
                            MessageBox.Show("Username or Fullname is already exist!", "Already exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtUsername.Focus();
                        }
                        else
                        {
                            vUserID();//Insert into user values ('2013-U-0001','Cheche','family','Grace','Chua','Staff','Active','what is your favorite actress/actor?','Judy','2013-02-24
                            LogIn.q = "Insert into user values ('" + sUserID + "','" + txtUsername.Text
                                + "','" + txtPassword.Text
                                + "','" + txtFirstname.Text
                                + "','" + txtLastname.Text
                                + "','" + "Staff"
                                + "','" + "Active"
                                + "','" + cbSecurityQuestion.Text
                                + "','" + txtSecurityAnswer.Text
                                + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                                //+ "','" + txtContactnumber.Text + "')";
                            LogIn.vtable();
                            MessageBox.Show("Adding Successful");
                            Close();
                        }
                    }
                    else
                    {
                        LogIn.q = "select userName, concat(Fname,' ',LName),userid from user where username= '"
                            + txtUsername.Text + "' or concat(FName,' ', LName)='"
                            + txtFirstname.Text + " " + txtLastname.Text + " ' ";
                        LogIn.vtable();
                        if (LogIn.table.Rows.Count == 0)
                        {
                            vEdit();
                        }
                        else
                        {
                            dbUsername = LogIn.table.Rows[0][0].ToString().ToUpper();
                            dbFullname = LogIn.table.Rows[0][1].ToString().ToUpper();
                            if (dbUsername + dbFullname == txtUsername.Text.ToUpper() + txtPassword.Text.ToUpper())
                            {
                                vEdit();
                            }
                            else
                            {
                                if (LogIn.table.Rows[0][2].ToString() == LogIn.suserid)
                                    vEdit();
                                else
                                    MessageBox.Show("Username or Fullname is already exist!", "Already exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        void vEdit()
        {
            LogIn.q = "update user set userName ='" + txtUsername.Text
                   + "',password = '" + txtPassword.Text
                   + "', Fname = '" + txtFirstname.Text
                   + "', Lname = '" + txtLastname.Text
                   //+ "', connum = '" + txtContactnumber.Text
                   + "', SecurityAnswer ='" + txtSecurityAnswer.Text
                   + "', SecurityQuestion = '" + cbSecurityQuestion.Text
                   + "' where userid = '" + LogIn.suserid + "'";
            LogIn.vtable();
            MessageBox.Show("Editing is succesful");
            LogIn.susername = txtUsername.Text;
            LogIn.spassword = txtPassword.Text;
            LogIn.spassword = txtRetypePassword.Text;
            LogIn.sGName = txtFirstname.Text;
            LogIn.sLName = txtLastname.Text;
            //wfLogIn.sContactnumber = txtContactnumber.Text;
            LogIn.SecurityQuestion = cbSecurityQuestion.Text;
            LogIn.SecurityAnswer = txtSecurityAnswer.Text;
            Close();
        }
        private void cbSecurityQuestion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtFirstname_Leave(object sender, EventArgs e)
        {
            LogIn.sText = txtFirstname.Text;
            LogIn.vLeave();
            txtFirstname.Text = LogIn.sText;
        }

        private void txtLastname_Leave(object sender, EventArgs e)
        {
            LogIn.sText = txtLastname.Text;
            LogIn.vLeave();
            txtLastname.Text = LogIn.sText;
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            LogIn.txtToolTipText = txtUsername;
            LogIn.vKeyLettersAndNumbers(e);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            LogIn.txtToolTipText = txtPassword;
            LogIn.vKeyLettersAndNumbers(e);

        }
    }
}