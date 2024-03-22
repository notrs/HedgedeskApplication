namespace HedgedeskApplication
{
    partial class frmAccountMaintenance
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
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvHedgeAccounts = new dgvCustom();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HedgeAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrokerAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chkDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHedgeAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(700, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvHedgeAccounts
            // 
            this.dgvHedgeAccounts.AllowUserToAddRows = false;
            this.dgvHedgeAccounts.AllowUserToDeleteRows = false;
            this.dgvHedgeAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHedgeAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.UserName,
            this.HedgeAccount,
            this.AccountDesc,
            this.BrokerAccount,
            this.Delete,
            this.chkDelete});
            this.dgvHedgeAccounts.Location = new System.Drawing.Point(12, 12);
            this.dgvHedgeAccounts.Name = "dgvHedgeAccounts";
            this.dgvHedgeAccounts.RowHeadersVisible = false;
            this.dgvHedgeAccounts.Size = new System.Drawing.Size(674, 526);
            this.dgvHedgeAccounts.TabIndex = 51;
            this.dgvHedgeAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHedgeAccounts_CellContentClick);
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "Hedge ID";
            this.UserID.Name = "UserID";
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 125;
            // 
            // HedgeAccount
            // 
            this.HedgeAccount.DataPropertyName = "TP_ACCT";
            this.HedgeAccount.HeaderText = "Hedge Account";
            this.HedgeAccount.Name = "HedgeAccount";
            this.HedgeAccount.Width = 150;
            // 
            // AccountDesc
            // 
            this.AccountDesc.DataPropertyName = "Desc";
            this.AccountDesc.HeaderText = "Account Desc";
            this.AccountDesc.Name = "AccountDesc";
            this.AccountDesc.ReadOnly = true;
            this.AccountDesc.Width = 150;
            // 
            // BrokerAccount
            // 
            this.BrokerAccount.DataPropertyName = "FCC_Account";
            this.BrokerAccount.HeaderText = "Broker Account";
            this.BrokerAccount.Name = "BrokerAccount";
            this.BrokerAccount.Width = 125;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Visible = false;
            // 
            // chkDelete
            // 
            this.chkDelete.HeaderText = "";
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Visible = false;
            this.chkDelete.Width = 50;
            // 
            // frmAccountMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 589);
            this.Controls.Add(this.dgvHedgeAccounts);
            this.Controls.Add(this.btnClose);
            this.Name = "frmAccountMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hedge Account Maintenance";
            this.Load += new System.EventHandler(this.frmAccountMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHedgeAccounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private dgvCustom dgvHedgeAccounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HedgeAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrokerAccount;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkDelete;
    }
}