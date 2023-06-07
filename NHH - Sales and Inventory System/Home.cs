using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
namespace NHH___Sales_and_Inventory_System
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbuser.Text = LogIn.sGName + " " + LogIn.sLName;
            lbdate.Text = DateTime.Now.ToString("MMMM dd ,yyyy hh:mm:ss tt");
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        void vCloseExistingForm()
        {
            int d;
            for (int a = 0; a < MdiChildren.Length; a++)
            {
                d = 0;
                for (int s = 0; s < MdiChildren.Length; s++)
                {
                    if (MdiChildren[a].Text == MdiChildren[s].Text)
                        d++;
                    if (d > 1)
                        MdiChildren[a].Close();
                }
            }
        }
        private void changeUserInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.sSave = "Edit";
            User_Settings s = new User_Settings();
            s.ShowDialog();
            timer1_Tick(sender, e);
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (LogIn.sUsertype == "Admin")
            {
                User user = new User();
                user.MdiParent = this;
                user.WindowState = FormWindowState.Maximized;
                user.Show();
                vCloseExistingForm();
            }
            else
            {
                MessageBox.Show("Unable to use this form.");
            }
        }


        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Confirm exit", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }

        }
        private void Home_Load(object sender, EventArgs e)
        {            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ph");
            timer1_Tick(sender, e);
            criticalItemToolStripMenuItem_Click(sender, e);
        }

        private void logInHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History l = new History();
            l.MdiParent = this;
            l.WindowState = FormWindowState.Maximized;
            l.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.MdiParent = this;
            c.WindowState = FormWindowState.Maximized;
            c.Show();
            vCloseExistingForm();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product f = new Product();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
            vCloseExistingForm();
        }

        private void inventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (LogIn.sUsertype != "Staff")
            {
                Hide();
                Invent i = new Invent();
                i.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Unable to use this form.");
            }
        }

        private void salesReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            SalesReport s = new SalesReport();
            s.ShowDialog();
            Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            Billing b = new Billing();
            b.ShowDialog();
            Show();
        }

        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Purchase p = new Purchase();
            p.ShowDialog();
            Show();    
        }

        private void returnedProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            ReturnProduct r = new ReturnProduct();
            r.ShowDialog();
            Show();
        }

        private void criticalItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            CriticalItem c = new CriticalItem();
            c.ShowDialog();
            Show();
        }
    }
}