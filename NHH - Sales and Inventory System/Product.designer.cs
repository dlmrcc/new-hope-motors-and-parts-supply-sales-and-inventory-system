namespace NHH___Sales_and_Inventory_System
{
    partial class Product
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgProduct = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.bnEdit = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bnPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.bnAddQty = new System.Windows.Forms.Button();
            this.bnDefective = new System.Windows.Forms.Button();
            this.bnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProduct
            // 
            this.dgProduct.AllowUserToAddRows = false;
            this.dgProduct.AllowUserToDeleteRows = false;
            this.dgProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProduct.Location = new System.Drawing.Point(12, 72);
            this.dgProduct.Name = "dgProduct";
            this.dgProduct.ReadOnly = true;
            this.dgProduct.RowHeadersVisible = false;
            this.dgProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProduct.Size = new System.Drawing.Size(540, 363);
            this.dgProduct.TabIndex = 3;
            this.dgProduct.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dgProduct.DoubleClick += new System.EventHandler(this.dgProduct_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "List of Product";
            // 
            // bnEdit
            // 
            this.bnEdit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bnEdit.Location = new System.Drawing.Point(558, 231);
            this.bnEdit.Name = "bnEdit";
            this.bnEdit.Size = new System.Drawing.Size(95, 42);
            this.bnEdit.TabIndex = 24;
            this.bnEdit.Text = "Edit Product";
            this.bnEdit.UseVisualStyleBackColor = true;
            this.bnEdit.Click += new System.EventHandler(this.bnEdit_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(558, 389);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(95, 42);
            this.button6.TabIndex = 22;
            this.button6.Text = "Home";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Add
            // 
            this.Add.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.Location = new System.Drawing.Point(558, 135);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(95, 42);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add Product";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(419, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Keyword";
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "Product Code",
            "Name",
            "Unit"});
            this.cbSearch.Location = new System.Drawing.Point(290, 34);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(121, 21);
            this.cbSearch.TabIndex = 11;
  
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Location = new System.Drawing.Point(487, 34);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(155, 20);
            this.txtKeyword.TabIndex = 10;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(231, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search";
            // 
            // bnPrint
            // 
            this.bnPrint.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bnPrint.ForeColor = System.Drawing.Color.White;
            this.bnPrint.Location = new System.Drawing.Point(558, 85);
            this.bnPrint.Name = "bnPrint";
            this.bnPrint.Size = new System.Drawing.Size(95, 42);
            this.bnPrint.TabIndex = 8;
            this.bnPrint.Text = "Print";
            this.bnPrint.UseVisualStyleBackColor = true;
            this.bnPrint.Click += new System.EventHandler(this.bnPrint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // bnAddQty
            // 
            this.bnAddQty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bnAddQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bnAddQty.ForeColor = System.Drawing.Color.White;
            this.bnAddQty.Location = new System.Drawing.Point(558, 181);
            this.bnAddQty.Name = "bnAddQty";
            this.bnAddQty.Size = new System.Drawing.Size(95, 42);
            this.bnAddQty.TabIndex = 25;
            this.bnAddQty.Text = "Add Quantity";
            this.bnAddQty.UseVisualStyleBackColor = true;
            this.bnAddQty.Click += new System.EventHandler(this.bnAddQty_Click);
            // 
            // bnDefective
            // 
            this.bnDefective.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bnDefective.Location = new System.Drawing.Point(558, 281);
            this.bnDefective.Name = "bnDefective";
            this.bnDefective.Size = new System.Drawing.Size(95, 42);
            this.bnDefective.TabIndex = 26;
            this.bnDefective.Text = "Add Defective Product";
            this.bnDefective.UseVisualStyleBackColor = true;
            this.bnDefective.Click += new System.EventHandler(this.bnDefective_Click);
            // 
            // bnReturn
            // 
            this.bnReturn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bnReturn.Location = new System.Drawing.Point(558, 331);
            this.bnReturn.Name = "bnReturn";
            this.bnReturn.Size = new System.Drawing.Size(95, 50);
            this.bnReturn.TabIndex = 27;
            this.bnReturn.Text = "Return Defective Product";
            this.bnReturn.UseVisualStyleBackColor = true;
            this.bnReturn.Click += new System.EventHandler(this.bnReturn_Click);
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::NHH___Sales_and_Inventory_System.Properties.Resources.Interface1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(665, 447);
            this.Controls.Add(this.bnReturn);
            this.Controls.Add(this.bnDefective);
            this.Controls.Add(this.bnAddQty);
            this.Controls.Add(this.bnEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnPrint);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgProduct);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.label2);
            this.Name = "Product";
            this.Text = "Product";
            this.Load += new System.EventHandler(this.Product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add;

        private System.Windows.Forms.DataGridView dgProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button bnEdit;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Button bnAddQty;
        private System.Windows.Forms.Button bnDefective;
        private System.Windows.Forms.Button bnReturn;
    }
}