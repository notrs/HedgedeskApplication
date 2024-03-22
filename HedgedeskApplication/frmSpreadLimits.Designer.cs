namespace HedgedeskApplication
{
    partial class frmSpreadLimits
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvSpreadLimits = new dgvCustom();
            this.Commodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountCommodityLimitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpreadLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommodityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chkDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpreadLimits)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(448, 619);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(577, 614);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage2.Controls.Add(this.btnDeleteSelected);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.dgvSpreadLimits);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(569, 588);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Spread Limits";
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(6, 51);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(126, 27);
            this.btnDeleteSelected.TabIndex = 6;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(458, 51);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 27);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvSpreadLimits
            // 
            this.dgvSpreadLimits.AllowUserToAddRows = false;
            this.dgvSpreadLimits.AllowUserToDeleteRows = false;
            this.dgvSpreadLimits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpreadLimits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Commodity,
            this.AccountCommodityLimitID,
            this.Account,
            this.SpreadLimit,
            this.AccountID,
            this.CommodityID,
            this.Delete,
            this.chkDelete});
            this.dgvSpreadLimits.Location = new System.Drawing.Point(7, 84);
            this.dgvSpreadLimits.Name = "dgvSpreadLimits";
            this.dgvSpreadLimits.RowHeadersVisible = false;
            this.dgvSpreadLimits.Size = new System.Drawing.Size(554, 500);
            this.dgvSpreadLimits.TabIndex = 3;
            this.dgvSpreadLimits.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSpreadLimits_CellBeginEdit);
            this.dgvSpreadLimits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpreadLimits_CellContentClick);
            this.dgvSpreadLimits.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpreadLimits_CellLeave);
            this.dgvSpreadLimits.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSpreadLimits_CellValidating);
            this.dgvSpreadLimits.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSpreadLimits_RowValidating);
            this.dgvSpreadLimits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSpreadLimits_KeyDown);
            // 
            // Commodity
            // 
            this.Commodity.DataPropertyName = "Commodity";
            this.Commodity.HeaderText = "Commodity";
            this.Commodity.Name = "Commodity";
            this.Commodity.ReadOnly = true;
            this.Commodity.Width = 150;
            // 
            // AccountCommodityLimitID
            // 
            this.AccountCommodityLimitID.DataPropertyName = "AccountCommodityLimitID";
            this.AccountCommodityLimitID.HeaderText = "AccountCommodityLimitID";
            this.AccountCommodityLimitID.Name = "AccountCommodityLimitID";
            this.AccountCommodityLimitID.Visible = false;
            // 
            // Account
            // 
            this.Account.DataPropertyName = "AccountID";
            this.Account.HeaderText = "Account";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            // 
            // SpreadLimit
            // 
            this.SpreadLimit.DataPropertyName = "SpreadLimit";
            this.SpreadLimit.HeaderText = "Spread Limit";
            this.SpreadLimit.Name = "SpreadLimit";
            // 
            // AccountID
            // 
            this.AccountID.DataPropertyName = "AccountID";
            this.AccountID.HeaderText = "AccountID";
            this.AccountID.Name = "AccountID";
            this.AccountID.Visible = false;
            this.AccountID.Width = 125;
            // 
            // CommodityID
            // 
            this.CommodityID.DataPropertyName = "CommodityID";
            this.CommodityID.HeaderText = "CommodityID";
            this.CommodityID.Name = "CommodityID";
            this.CommodityID.Visible = false;
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
            // 
            // frmSpreadLimits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 662);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmSpreadLimits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Spread Limits";
            this.Load += new System.EventHandler(this.frmCommodityLimits_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpreadLimits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private dgvCustom dgvSpreadLimits;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCommodityLimitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpreadLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommodityID;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkDelete;
    }
}