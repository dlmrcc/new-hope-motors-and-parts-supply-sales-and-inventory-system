namespace NHH___Sales_and_Inventory_System
{
    partial class SalesReport
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
            this.dgOrder = new System.Windows.Forms.DataGridView();
            this.dgPayment = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPayment = new System.Windows.Forms.Label();
            this.bnClose = new System.Windows.Forms.Button();
            this.lsBilling = new System.Windows.Forms.ListBox();
            this.lbName = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCust = new System.Windows.Forms.ComboBox();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTotalBillingCAmount = new System.Windows.Forms.Label();
            this.lbTotalCAmount = new System.Windows.Forms.Label();
            this.lbTotalCPayment = new System.Windows.Forms.Label();
            this.lbTotalSAmount = new System.Windows.Forms.Label();
            this.lbTotalBillingSAmount = new System.Windows.Forms.Label();
            this.lbTotalIAmount = new System.Windows.Forms.Label();
            this.lbTotalBillingIAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayment)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgOrder
            // 
            this.dgOrder.AllowUserToAddRows = false;
            this.dgOrder.AllowUserToOrderColumns = true;
            this.dgOrder.AllowUserToResizeColumns = false;
            this.dgOrder.AllowUserToResizeRows = false;
            this.dgOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrder.Location = new System.Drawing.Point(222, 42);
            this.dgOrder.Name = "dgOrder";
            this.dgOrder.ReadOnly = true;
            this.dgOrder.RowHeadersVisible = false;
            this.dgOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrder.Size = new System.Drawing.Size(598, 186);
            this.dgOrder.TabIndex = 2;
            // 
            // dgPayment
            // 
            this.dgPayment.AllowUserToAddRows = false;
            this.dgPayment.AllowUserToOrderColumns = true;
            this.dgPayment.AllowUserToResizeColumns = false;
            this.dgPayment.AllowUserToResizeRows = false;
            this.dgPayment.BackgroundColor = System.Drawing.Color.White;
            this.dgPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPayment.Location = new System.Drawing.Point(222, 319);
            this.dgPayment.Name = "dgPayment";
            this.dgPayment.ReadOnly = true;
            this.dgPayment.RowHeadersVisible = false;
            this.dgPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPayment.Size = new System.Drawing.Size(598, 186);
            this.dgPayment.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "List of Billing IDs";
            // 
            // lbPayment
            // 
            this.lbPayment.AutoSize = true;
            this.lbPayment.BackColor = System.Drawing.Color.Transparent;
            this.lbPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPayment.ForeColor = System.Drawing.Color.White;
            this.lbPayment.Location = new System.Drawing.Point(218, 292);
            this.lbPayment.Name = "lbPayment";
            this.lbPayment.Size = new System.Drawing.Size(135, 24);
            this.lbPayment.TabIndex = 3;
            this.lbPayment.Text = "List of Payment";
            // 
            // bnClose
            // 
            this.bnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnClose.Location = new System.Drawing.Point(732, 551);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(88, 27);
            this.bnClose.TabIndex = 4;
            this.bnClose.Text = "Close";
            this.bnClose.UseVisualStyleBackColor = true;
            this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
            // 
            // lsBilling
            // 
            this.lsBilling.FormattingEnabled = true;
            this.lsBilling.Location = new System.Drawing.Point(12, 198);
            this.lsBilling.Name = "lsBilling";
            this.lsBilling.Size = new System.Drawing.Size(200, 251);
            this.lsBilling.TabIndex = 1;
            this.lsBilling.SelectedIndexChanged += new System.EventHandler(this.lsBilling_SelectedIndexChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(222, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(203, 24);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "List of Ordered Product";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "MMM. dd, yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(74, 15);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(113, 20);
            this.dtFrom.TabIndex = 7;
            this.dtFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtFrom_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbCust);
            this.panel1.Controls.Add(this.cbUser);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtTo);
            this.panel1.Controls.Add(this.dtFrom);
            this.panel1.Location = new System.Drawing.Point(16, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 126);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(31, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "User";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Customer";
            // 
            // cbCust
            // 
            this.cbCust.DropDownWidth = 200;
            this.cbCust.FormattingEnabled = true;
            this.cbCust.Location = new System.Drawing.Point(74, 98);
            this.cbCust.Name = "cbCust";
            this.cbCust.Size = new System.Drawing.Size(115, 21);
            this.cbCust.TabIndex = 12;
            this.cbCust.SelectedIndexChanged += new System.EventHandler(this.cbCust_SelectedIndexChanged);
            // 
            // cbUser
            // 
            this.cbUser.DropDownWidth = 200;
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(74, 71);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(115, 21);
            this.cbUser.TabIndex = 11;
            this.cbUser.SelectedIndexChanged += new System.EventHandler(this.cbUser_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(43, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "From";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "MMM. dd, yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(74, 44);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(113, 20);
            this.dtTo.TabIndex = 9;
            this.dtTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtTo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(24, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Search";
            // 
            // lbTotalBillingCAmount
            // 
            this.lbTotalBillingCAmount.AutoSize = true;
            this.lbTotalBillingCAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalBillingCAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalBillingCAmount.ForeColor = System.Drawing.Color.White;
            this.lbTotalBillingCAmount.Location = new System.Drawing.Point(13, 514);
            this.lbTotalBillingCAmount.Name = "lbTotalBillingCAmount";
            this.lbTotalBillingCAmount.Size = new System.Drawing.Size(37, 16);
            this.lbTotalBillingCAmount.TabIndex = 15;
            this.lbTotalBillingCAmount.Text = "User";
            // 
            // lbTotalCAmount
            // 
            this.lbTotalCAmount.AutoSize = true;
            this.lbTotalCAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalCAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalCAmount.ForeColor = System.Drawing.Color.White;
            this.lbTotalCAmount.Location = new System.Drawing.Point(596, 236);
            this.lbTotalCAmount.Name = "lbTotalCAmount";
            this.lbTotalCAmount.Size = new System.Drawing.Size(37, 16);
            this.lbTotalCAmount.TabIndex = 16;
            this.lbTotalCAmount.Text = "User";
            // 
            // lbTotalCPayment
            // 
            this.lbTotalCPayment.AutoSize = true;
            this.lbTotalCPayment.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalCPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalCPayment.ForeColor = System.Drawing.Color.White;
            this.lbTotalCPayment.Location = new System.Drawing.Point(643, 514);
            this.lbTotalCPayment.Name = "lbTotalCPayment";
            this.lbTotalCPayment.Size = new System.Drawing.Size(37, 16);
            this.lbTotalCPayment.TabIndex = 17;
            this.lbTotalCPayment.Text = "User";
            // 
            // lbTotalSAmount
            // 
            this.lbTotalSAmount.AutoSize = true;
            this.lbTotalSAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalSAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalSAmount.ForeColor = System.Drawing.Color.White;
            this.lbTotalSAmount.Location = new System.Drawing.Point(596, 260);
            this.lbTotalSAmount.Name = "lbTotalSAmount";
            this.lbTotalSAmount.Size = new System.Drawing.Size(37, 16);
            this.lbTotalSAmount.TabIndex = 18;
            this.lbTotalSAmount.Text = "User";
            // 
            // lbTotalBillingSAmount
            // 
            this.lbTotalBillingSAmount.AutoSize = true;
            this.lbTotalBillingSAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalBillingSAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalBillingSAmount.ForeColor = System.Drawing.Color.White;
            this.lbTotalBillingSAmount.Location = new System.Drawing.Point(13, 538);
            this.lbTotalBillingSAmount.Name = "lbTotalBillingSAmount";
            this.lbTotalBillingSAmount.Size = new System.Drawing.Size(37, 16);
            this.lbTotalBillingSAmount.TabIndex = 20;
            this.lbTotalBillingSAmount.Text = "User";
            // 
            // lbTotalIAmount
            // 
            this.lbTotalIAmount.AutoSize = true;
            this.lbTotalIAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalIAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalIAmount.ForeColor = System.Drawing.Color.White;
            this.lbTotalIAmount.Location = new System.Drawing.Point(596, 284);
            this.lbTotalIAmount.Name = "lbTotalIAmount";
            this.lbTotalIAmount.Size = new System.Drawing.Size(37, 16);
            this.lbTotalIAmount.TabIndex = 21;
            this.lbTotalIAmount.Text = "User";
            // 
            // lbTotalBillingIAmount
            // 
            this.lbTotalBillingIAmount.AutoSize = true;
            this.lbTotalBillingIAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalBillingIAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalBillingIAmount.ForeColor = System.Drawing.Color.White;
            this.lbTotalBillingIAmount.Location = new System.Drawing.Point(13, 562);
            this.lbTotalBillingIAmount.Name = "lbTotalBillingIAmount";
            this.lbTotalBillingIAmount.Size = new System.Drawing.Size(37, 16);
            this.lbTotalBillingIAmount.TabIndex = 22;
            this.lbTotalBillingIAmount.Text = "User";
            // 
            // wfSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NHH___Sales_and_Inventory_System.Properties.Resources.Interface1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(832, 594);
            this.Controls.Add(this.lbTotalBillingIAmount);
            this.Controls.Add(this.lbTotalIAmount);
            this.Controls.Add(this.lbTotalBillingSAmount);
            this.Controls.Add(this.lbTotalSAmount);
            this.Controls.Add(this.lbTotalCPayment);
            this.Controls.Add(this.lbTotalCAmount);
            this.Controls.Add(this.lbTotalBillingCAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lsBilling);
            this.Controls.Add(this.bnClose);
            this.Controls.Add(this.lbPayment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgPayment);
            this.Controls.Add(this.dgOrder);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wfSalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.Load += new System.EventHandler(this.wfSalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayment)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgOrder;
        private System.Windows.Forms.DataGridView dgPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPayment;
        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.ListBox lsBilling;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCust;
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.Label lbTotalBillingCAmount;
        private System.Windows.Forms.Label lbTotalCAmount;
        private System.Windows.Forms.Label lbTotalCPayment;
        private System.Windows.Forms.Label lbTotalSAmount;
        private System.Windows.Forms.Label lbTotalBillingSAmount;
        private System.Windows.Forms.Label lbTotalIAmount;
        private System.Windows.Forms.Label lbTotalBillingIAmount;
    }
}