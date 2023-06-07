using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class AddQuantity : Form
    {
        public AddQuantity()
        {
            InitializeComponent();
        }

        private void wfAddQuantity_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-ph");
            lbProdCode.Text = Product.sprodcode;
            lbName.Text = Product.sname;
            lbQuantityLeft.Text = Product.dqty.ToString();
            txtArrQty.Text = "1";
            if (Product.sMarker == "0")
            {
                label2.Text = "Defective Items";
                Text = label2.Text;
                Text = "Defective Items";
                lb1.Text = "Good Qty Remaining";
                lb2.Text = "Enter Defective Qty";
                lb3.Text = "New Good Qty";
                lbQuantityLeft.Text = Product.dbqty.ToString();
            }
        }
        private void bnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        double dNewQty;
        private void txtArrQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Product.sMarker == "1")
                {
                    dNewQty = Convert.ToDouble(txtArrQty.Text) + Product.dgqty;
                    if (Convert.ToDouble(txtArrQty.Text) < 0)
                        txtArrQty.Text = "1";
                }
                else
                {
                    dNewQty = Product.dgqty - Convert.ToDouble(txtArrQty.Text);
                    if (Convert.ToDouble(txtArrQty.Text) < 0)
                        txtArrQty.Text = "1";
                }
            }
            catch { txtArrQty.Text = "1"; }

            lbNewQty.Text = dNewQty.ToString();
        }
        private void bnSave_Click(object sender, EventArgs e)
        {
            if (Product.sMarker == "1")
            {
                LogIn.q = "update product set gqty = (gqty + '" + txtArrQty.Text
                    + "'), qty = (qty + '" + txtArrQty.Text
                    + "') where prodcode = '" + lbProdCode.Text
                    + "' and dreceive = '" + Product.ddreceive.ToString("yyyy-MM-dd") + "'";
                LogIn.vtable();
                MessageBox.Show("Add quantity is successful");
            Close();
            }
            else
            {
                if (Product.dgqty > Convert.ToDouble(txtArrQty.Text))
                {
                    LogIn.q = "update product set gqty = (gqty - '" + txtArrQty.Text
                       + "'), bqty = (bqty + '" + txtArrQty.Text
                       + "') where prodcode = '" + lbProdCode.Text
                       + "' and dreceive = '" + Product.ddreceive.ToString("yyyy-MM-dd") + "'";
                    LogIn.vtable();
                    MessageBox.Show("bad qty");
                    Close();
                }
                else
                {
                    MessageBox.Show("qty must not be grater than " + Product.dgqty);
                    txtArrQty.Focus();
                }
            }
        }
    }
}