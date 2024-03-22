namespace HedgedeskApplication
{
    partial class frmMarginBalance
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvMarginBalance = new dgvCustom();
            this.Print = new System.Windows.Forms.Button();
            this.btnFindOrders = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAcct = new System.Windows.Forms.ComboBox();
            this.cboComp = new AutoCompleteComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalMargin = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMargin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAddComp = new AutoCompleteComboBox();
            this.cboAddAcct = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpAddMarginDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.MarginID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chkDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TradingCompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarginBalance)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(700, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(12, 60);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(85, 27);
            this.btnDeleteSelected.TabIndex = 53;
            this.btnDeleteSelected.Text = "Delete";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(687, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 27);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvMarginBalance
            // 
            this.dgvMarginBalance.AllowUserToAddRows = false;
            this.dgvMarginBalance.AllowUserToDeleteRows = false;
            this.dgvMarginBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarginBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MarginID,
            this.Company,
            this.Account,
            this.MarginBal,
            this.MarginDate,
            this.Delete,
            this.chkDelete,
            this.TradingCompanyID,
            this.AccountID});
            this.dgvMarginBalance.Location = new System.Drawing.Point(12, 148);
            this.dgvMarginBalance.Name = "dgvMarginBalance";
            this.dgvMarginBalance.RowHeadersVisible = false;
            this.dgvMarginBalance.Size = new System.Drawing.Size(773, 463);
            this.dgvMarginBalance.TabIndex = 51;
            this.dgvMarginBalance.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMarginBalance_CellBeginEdit);
            this.dgvMarginBalance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarginBalance_CellContentClick);
            this.dgvMarginBalance.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarginBalance_CellLeave);
            this.dgvMarginBalance.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvMarginBalance_CellValidating);
            this.dgvMarginBalance.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMarginBalance_RowValidating);
            this.dgvMarginBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMarginBalance_KeyDown);
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(700, 2);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(85, 27);
            this.Print.TabIndex = 63;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // btnFindOrders
            // 
            this.btnFindOrders.Location = new System.Drawing.Point(12, 2);
            this.btnFindOrders.Name = "btnFindOrders";
            this.btnFindOrders.Size = new System.Drawing.Size(85, 27);
            this.btnFindOrders.TabIndex = 1;
            this.btnFindOrders.Text = "Filter Records";
            this.btnFindOrders.UseVisualStyleBackColor = true;
            this.btnFindOrders.Click += new System.EventHandler(this.btnFindOrders_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(12, 31);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(85, 27);
            this.btnShowAll.TabIndex = 64;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Account:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Company:";
            // 
            // cboAcct
            // 
            this.cboAcct.FormattingEnabled = true;
            this.cboAcct.Location = new System.Drawing.Point(191, 52);
            this.cboAcct.Name = "cboAcct";
            this.cboAcct.Size = new System.Drawing.Size(95, 21);
            this.cboAcct.TabIndex = 3;
            // 
            // cboComp
            // 
            this.cboComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboComp.FormattingEnabled = true;
            this.cboComp.Location = new System.Drawing.Point(191, 22);
            this.cboComp.Name = "cboComp";
            this.cboComp.Size = new System.Drawing.Size(95, 21);
            this.cboComp.Strict = true;
            this.cboComp.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(332, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 76;
            this.label11.Text = "From:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(342, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 75;
            this.label12.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(366, 52);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(98, 20);
            this.dtpTo.TabIndex = 5;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(366, 22);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(98, 20);
            this.dtpFrom.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(384, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 72;
            this.label9.Text = "Margin Date:";
            // 
            // txtTotalMargin
            // 
            this.txtTotalMargin.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtTotalMargin.Location = new System.Drawing.Point(369, 617);
            this.txtTotalMargin.Name = "txtTotalMargin";
            this.txtTotalMargin.Size = new System.Drawing.Size(95, 20);
            this.txtTotalMargin.TabIndex = 78;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(326, 620);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 77;
            this.label15.Text = "Total :";
            // 
            // txtMargin
            // 
            this.txtMargin.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtMargin.Location = new System.Drawing.Point(382, 19);
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.Size = new System.Drawing.Size(95, 20);
            this.txtMargin.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "Margin :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Account:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "Company:";
            // 
            // cboAddComp
            // 
            this.cboAddComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboAddComp.FormattingEnabled = true;
            this.cboAddComp.Location = new System.Drawing.Point(62, 18);
            this.cboAddComp.Name = "cboAddComp";
            this.cboAddComp.Size = new System.Drawing.Size(95, 21);
            this.cboAddComp.Strict = true;
            this.cboAddComp.TabIndex = 6;
            // 
            // cboAddAcct
            // 
            this.cboAddAcct.FormattingEnabled = true;
            this.cboAddAcct.Location = new System.Drawing.Point(221, 18);
            this.cboAddAcct.Name = "cboAddAcct";
            this.cboAddAcct.Size = new System.Drawing.Size(95, 21);
            this.cboAddAcct.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpAddMarginDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMargin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboAddComp);
            this.groupBox1.Controls.Add(this.cboAddAcct);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(8, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 47);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Record";
            // 
            // dtpAddMarginDate
            // 
            this.dtpAddMarginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAddMarginDate.Location = new System.Drawing.Point(570, 18);
            this.dtpAddMarginDate.Name = "dtpAddMarginDate";
            this.dtpAddMarginDate.Size = new System.Drawing.Size(98, 20);
            this.dtpAddMarginDate.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(496, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "Margin Date:";
            // 
            // MarginID
            // 
            this.MarginID.DataPropertyName = "MarginID";
            this.MarginID.HeaderText = "ID";
            this.MarginID.Name = "MarginID";
            this.MarginID.ReadOnly = true;
            this.MarginID.Width = 50;
            // 
            // Company
            // 
            this.Company.DataPropertyName = "CompanyDesc";
            this.Company.HeaderText = "Trade Company";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            this.Company.Width = 150;
            // 
            // Account
            // 
            this.Account.DataPropertyName = "AccountDesc";
            this.Account.HeaderText = "Account";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            this.Account.Width = 150;
            // 
            // MarginBal
            // 
            this.MarginBal.DataPropertyName = "Margin";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.MarginBal.DefaultCellStyle = dataGridViewCellStyle1;
            this.MarginBal.HeaderText = "Margin";
            this.MarginBal.Name = "MarginBal";
            this.MarginBal.Width = 125;
            // 
            // MarginDate
            // 
            this.MarginDate.DataPropertyName = "MarginDate";
            this.MarginDate.HeaderText = "Margin Date";
            this.MarginDate.Name = "MarginDate";
            this.MarginDate.ReadOnly = true;
            this.MarginDate.Width = 125;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // chkDelete
            // 
            this.chkDelete.HeaderText = "";
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Width = 50;
            // 
            // TradingCompanyID
            // 
            this.TradingCompanyID.DataPropertyName = "Company";
            this.TradingCompanyID.HeaderText = "TradingCompanyID";
            this.TradingCompanyID.Name = "TradingCompanyID";
            this.TradingCompanyID.Visible = false;
            // 
            // AccountID
            // 
            this.AccountID.DataPropertyName = "Account";
            this.AccountID.HeaderText = "AccountID";
            this.AccountID.Name = "AccountID";
            this.AccountID.Visible = false;
            this.AccountID.Width = 125;
            // 
            // frmMarginBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 648);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTotalMargin);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAcct);
            this.Controls.Add(this.cboComp);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.btnFindOrders);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.dgvMarginBalance);
            this.Controls.Add(this.btnClose);
            this.Name = "frmMarginBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Margin Balance Maintenance";
            this.Load += new System.EventHandler(this.frmMarginBalance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarginBalance)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnAdd;
        private dgvCustom dgvMarginBalance;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Button btnFindOrders;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAcct;
        private AutoCompleteComboBox cboComp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalMargin;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMargin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private AutoCompleteComboBox cboAddComp;
        private System.Windows.Forms.ComboBox cboAddAcct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpAddMarginDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginDate;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradingCompanyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
    }
}