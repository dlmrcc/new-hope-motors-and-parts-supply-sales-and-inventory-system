using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NHH___Sales_and_Inventory_System
{
    public partial class ProdSet : Form
    {
        public ProdSet()
        {
            InitializeComponent();
        }
        void vUnit()
        {
            LogIn.q = "SELECT distinct unit FROM product order by unit";
            LogIn.vtable();
            for (int a = 0; a < LogIn.table.Rows.Count; a++)
                cbUnit.Items.Add(LogIn.table.Rows[a][0]);
        }
        private void bnSave_Click(object sender, EventArgs e)
        {
            if (txtProdCode.Text == "")
            {
                MessageBox.Show("Product Code must not be empty.", "Invalid Input");
                txtProdCode.Focus();
            }
            else if (txtName.Text.Length < 2 || txtName.Text.Length > 80)
            {
                MessageBox.Show("Product Name must be between 2 (two) to eighty (80) characters."
                    , "Invalid Input");
                txtName.Focus();
            }
            else if (cbUnit.Text == "")
            {
                MessageBox.Show("Product unit must not be empty.", "Invalid Input");
                cbUnit.Focus();
            }
            else if (Convert.ToDouble(txtSalePrice.Text) < Convert.ToDouble(txtPrice.Text))
            {
                MessageBox.Show("Sale price must be greater than cost price.","Invalid Sale Price");
                txtSalePrice.Focus();
            }
            else
            {
                if (Product.sSave == "Add")
                {
                    LogIn.q = "select prodcode from product where prodcode = '" + txtProdCode.Text
                        + "' and dreceive = '" + dtDateReceive.Value.ToString("yyyy-MM-dd") + "'";
                    LogIn.vtable();
                    if (LogIn.table.Rows.Count > 0)
                    {
                        LogIn.q = "update product set gqty = (gqty + '" + txtQty.Text
                            + "'), qty = (qty + '" + txtQty.Text
                            + "') where prodcode = '" + txtProdCode.Text 
                            + "' and dreceive = '" + dtDateReceive.Value.ToString("yyyy-MM-dd") + "'";
                        LogIn.vtable();
                        MessageBox.Show("Add quantity is successful");
                    }
                    else
                    {
                        LogIn.q = "insert into product (prodcode, name, unit, qty, price, crititem, sprice, category, dreceive, bqty, gqty) values ('" + txtProdCode.Text.ToUpper()
                            + "','" + txtName.Text
                            + "','" + cbUnit.Text
                            + "','" + txtQty.Text
                            + "','" + txtPrice.Text
                            + "','" + txtCritItem.Text
                            + "','" + txtSalePrice.Text
                            + "','" + cbCategory.Text
                            + "','" + dtDateReceive.Value.ToString("yyyy-MM-dd")
                            + "',0,'" + txtQty.Text + "')";
                        LogIn.vtable();
                        MessageBox.Show("Adding is successful");
                    }
                }
                else
                {
                    LogIn.q = "update product set prodcode = '" + txtProdCode.Text
                        + "',name = '" + txtName.Text
                        + "', unit = '" + cbUnit.Text
                        + "', crititem = '" + txtCritItem.Text
                        + "', price = '" + txtPrice.Text
                        + "', sprice = '" + txtSalePrice.Text
                        + "', category = '" + cbCategory.Text
                        + "' where prodcode = '" + Product.sprodcode + "'";
                    LogIn.vtable();
                    MessageBox.Show("Editing is successful");
                }
                Close();
            }
        }
        private void bnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void wfProdSet_Load(object sender, EventArgs e)
        {
            if (Product.sSave == "Edit")
            {
                txtProdCode.Text = Product.sprodcode;
                txtProdCode.Enabled = false;
                txtName.Text = Product.sname.ToString();
                cbUnit.Text = Product.sunit.ToString();
                txtQty.Text = Product.dgqty.ToString();
                txtPrice.Text = Product.dprice.ToString();
                txtSalePrice.Text = Product.dsprice.ToString();
                txtCritItem.Text = Product.dcrititem.ToString();
                cbCategory.Text = Product.scategory;
                dtDateReceive.Text = Product.ddreceive.ToString();
                if (LogIn.sUsertype != "Admin")
                {
                    txtPrice.Enabled = false;
                    txtSalePrice.Enabled = false;
                    dtDateReceive.Enabled = false;
                }
                txtQty.Enabled = false;
            }
            vUnit();
        }
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            LogIn.txtToolTipText = txtQty;
            LogIn.vKeyNumbersAndPeriod(e);
        }
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            LogIn.txtToolTipText = txtPrice;
            LogIn.vKeyNumbersAndPeriod(e);
        }

        private void txtCritItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            LogIn.txtToolTipText = txtCritItem;
            LogIn.vKeyNumbers(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            LogIn.txtToolTipText = txtPrice;
            LogIn.vKeyNumbersAndPeriod(e);
        }

        private void txtProdCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogIn.q = "SELECT name, unit, price, crititem, sprice, category, dreceive FROM product where prodcode = '" + txtProdCode.Text + "'";
                LogIn.vtable();
                if (LogIn.table.Rows.Count > 0)
                {
                    txtName.Text = LogIn.table.Rows[0][0].ToString();
                    cbUnit.Text = LogIn.table.Rows[0][1].ToString();
                    txtPrice.Text = LogIn.table.Rows[0][2].ToString();
                    txtCritItem.Text = LogIn.table.Rows[0][3].ToString();
                    txtSalePrice.Text = LogIn.table.Rows[0][4].ToString();
                    cbCategory.Text = LogIn.table.Rows[0][5].ToString();
                    dtDateReceive.Text = LogIn.table.Rows[0][6].ToString();
                    txtQty.Focus();
                }
                else
                {
                    txtName.Text = "";
                    cbUnit.Text = "";
                    txtPrice.Text = "";
                    txtCritItem.Text = "";
                    txtSalePrice.Text = "";
                    cbCategory.Text = "";
                    dtDateReceive.Value = DateTime.Now;
                }
            }
        }
    }
}