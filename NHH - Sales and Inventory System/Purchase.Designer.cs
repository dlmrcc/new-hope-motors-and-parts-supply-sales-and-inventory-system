namespace NHH___Sales_and_Inventory_System
{
    partial class Purchase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgPurchase = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbOthers = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtSearchCust = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.bnPurchase = new System.Windows.Forms.Button();
            this.bnModify = new System.Windows.Forms.Button();
            this.bnRemove = new System.Windows.Forms.Button();
            this.bnPayment = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.bnReturn = new System.Windows.Forms.Button();
            this.lbPrevPayment = new System.Windows.Forms.Label();
            this.dgProd = new System.Windows.Forms.DataGridView();
            this.dgCusto = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCusto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPurchase
            // 
            this.dgPurchase.AllowUserToAddRows = false;
            this.dgPurchase.AllowUserToDeleteRows = false;
            this.dgPurchase.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPurchase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPurchase.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgPurchase.Location = new System.Drawing.Point(12, 70);
            this.dgPurchase.Name = "dgPurchase";
            this.dgPurchase.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPurchase.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgPurchase.RowHeadersVisible = false;
            this.dgPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPurchase.Size = new System.Drawing.Size(575, 404);
            this.dgPurchase.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Hope Motors and Parts Supply - Purchase";
            // 
            // lbOthers
            // 
            this.lbOthers.BackColor = System.Drawing.Color.Transparent;
            this.lbOthers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOthers.ForeColor = System.Drawing.Color.White;
            this.lbOthers.Location = new System.Drawing.Point(397, 483);
            this.lbOthers.Name = "lbOthers";
            this.lbOthers.Size = new System.Drawing.Size(190, 22);
            this.lbOthers.TabIndex = 350;
            this.lbOthers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(663, 268);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(132, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtSearchCust
            // 
            this.txtSearchCust.Location = new System.Drawing.Point(663, 67);
            this.txtSearchCust.Name = "txtSearchCust";
            this.txtSearchCust.Size = new System.Drawing.Size(132, 20);
            this.txtSearchCust.TabIndex = 0;
            this.txtSearchCust.TextChanged += new System.EventHandler(this.txtSearchCust_TextChanged);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(663, 239);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(132, 21);
            this.cbCategory.TabIndex = 2;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(594, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 356;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(603, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 357;
            this.label3.Text = "Product";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(592, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 358;
            this.label4.Text = "Customer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(603, 483);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 360;
            this.label5.Text = "Quantity";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(663, 481);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(132, 20);
            this.txtQty.TabIndex = 5;
            // 
            // bnPurchase
            // 
            this.bnPurchase.Location = new System.Drawing.Point(639, 514);
            this.bnPurchase.Name = "bnPurchase";
            this.bnPurchase.Size = new System.Drawing.Size(75, 23);
            this.bnPurchase.TabIndex = 6;
            this.bnPurchase.Text = "Purchase";
            this.bnPurchase.UseVisualStyleBackColor = true;
            this.bnPurchase.Click += new System.EventHandler(this.bnPurchase_Click);
            // 
            // bnModify
            // 
            this.bnModify.Location = new System.Drawing.Point(558, 514);
            this.bnModify.Name = "bnModify";
            this.bnModify.Size = new System.Drawing.Size(75, 23);
            this.bnModify.TabIndex = 7;
            this.bnModify.Text = "Modify";
            this.bnModify.UseVisualStyleBackColor = true;
            this.bnModify.Click += new System.EventHandler(this.bnModify_Click);
            // 
            // bnRemove
            // 
            this.bnRemove.Location = new System.Drawing.Point(477, 514);
            this.bnRemove.Name = "bnRemove";
            this.bnRemove.Size = new System.Drawing.Size(75, 23);
            this.bnRemove.TabIndex = 8;
            this.bnRemove.Text = "Remove";
            this.bnRemove.UseVisualStyleBackColor = true;
            this.bnRemove.Click += new System.EventHandler(this.bnRemove_Click);
            // 
            // bnPayment
            // 
            this.bnPayment.Location = new System.Drawing.Point(394, 514);
            this.bnPayment.Name = "bnPayment";
            this.bnPayment.Size = new System.Drawing.Size(75, 23);
            this.bnPayment.TabIndex = 9;
            this.bnPayment.Text = "Payment";
            this.bnPayment.UseVisualStyleBackColor = true;
            this.bnPayment.Click += new System.EventHandler(this.bnPayment_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(720, 514);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Close";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // bnReturn
            // 
            this.bnReturn.Location = new System.Drawing.Point(277, 514);
            this.bnReturn.Name = "bnReturn";
            this.bnReturn.Size = new System.Drawing.Size(111, 23);
            this.bnReturn.TabIndex = 10;
            this.bnReturn.Text = "Return Product";
            this.bnReturn.UseVisualStyleBackColor = true;
            this.bnReturn.Click += new System.EventHandler(this.bnReturn_Click);
            // 
            // lbPrevPayment
            // 
            this.lbPrevPayment.BackColor = System.Drawing.Color.Transparent;
            this.lbPrevPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrevPayment.ForeColor = System.Drawing.Color.White;
            this.lbPrevPayment.Location = new System.Drawing.Point(9, 483);
            this.lbPrevPayment.Name = "lbPrevPayment";
            this.lbPrevPayment.Size = new System.Drawing.Size(190, 40);
            this.lbPrevPayment.TabIndex = 368;
            this.lbPrevPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgProd
            // 
            this.dgProd.AllowUserToAddRows = false;
            this.dgProd.AllowUserToDeleteRows = false;
            this.dgProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProd.BackgroundColor = System.Drawing.Color.White;
            this.dgProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProd.Location = new System.Drawing.Point(593, 294);
            this.dgProd.Name = "dgProd";
            this.dgProd.ReadOnly = true;
            this.dgProd.RowHeadersVisible = false;
            this.dgProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProd.Size = new System.Drawing.Size(202, 180);
            this.dgProd.TabIndex = 4;
            this.dgProd.SelectionChanged += new System.EventHandler(this.dgProd_SelectionChanged);
            // 
            // dgCusto
            // 
            this.dgCusto.AllowUserToAddRows = false;
            this.dgCusto.AllowUserToDeleteRows = false;
            this.dgCusto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCusto.BackgroundColor = System.Drawing.Color.White;
            this.dgCusto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCusto.Location = new System.Drawing.Point(593, 93);
            this.dgCusto.Name = "dgCusto";
            this.dgCusto.ReadOnly = true;
            this.dgCusto.RowHeadersVisible = false;
            this.dgCusto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCusto.Size = new System.Drawing.Size(202, 140);
            this.dgCusto.TabIndex = 1;
            this.dgCusto.SelectionChanged += new System.EventHandler(this.dgCusto_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 272;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Quantity";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "cPrice";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "cAmount";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ProdCode";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Price";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Amount";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // wfPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NHH___Sales_and_Inventory_System.Properties.Resources.Interface1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(809, 549);
            this.Controls.Add(this.dgCusto);
            this.Controls.Add(this.dgProd);
            this.Controls.Add(this.lbPrevPayment);
            this.Controls.Add(this.bnReturn);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.bnPayment);
            this.Controls.Add(this.bnRemove);
            this.Controls.Add(this.bnModify);
            this.Controls.Add(this.bnPurchase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.txtSearchCust);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbOthers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgPurchase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wfPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase";
            this.Load += new System.EventHandler(this.wfPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCusto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPurchase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbOthers;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtSearchCust;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button bnPurchase;
        private System.Windows.Forms.Button bnModify;
        private System.Windows.Forms.Button bnRemove;
        private System.Windows.Forms.Button bnPayment;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button bnReturn;
        private System.Windows.Forms.Label lbPrevPayment;
        private System.Windows.Forms.DataGridView dgProd;
        private System.Windows.Forms.DataGridView dgCusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;

    }
}