namespace HedgedeskApplication
{
    partial class frmAccountCommodityMaintenance
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
            this.dgvCommodityTradingCompany = new dgvCustom();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnGetOpenFutures = new System.Windows.Forms.Button();
            this.dgvClosingFutures = new dgvCustom();
            this.FuturesComm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuturesMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuturesYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuturesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuturesDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvCommodityLimits = new dgvCustom();
            this.Commodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RangeLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RangeHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoundingDivisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommodityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hedger = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MarketOrders = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chkDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommodityTradingCompany)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosingFutures)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommodityLimits)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(650, 619);
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
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 614);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage2.Controls.Add(this.btnDeleteSelected);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.dgvCommodityTradingCompany);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(786, 588);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Accounts";
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(677, 9);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(103, 27);
            this.btnDeleteSelected.TabIndex = 6;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(677, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 27);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvCommodityTradingCompany
            // 
            this.dgvCommodityTradingCompany.AllowUserToAddRows = false;
            this.dgvCommodityTradingCompany.AllowUserToDeleteRows = false;
            this.dgvCommodityTradingCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommodityTradingCompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountID,
            this.AccountDescription,
            this.Hedger,
            this.MarketOrders,
            this.Delete,
            this.chkDelete});
            this.dgvCommodityTradingCompany.Location = new System.Drawing.Point(7, 84);
            this.dgvCommodityTradingCompany.Name = "dgvCommodityTradingCompany";
            this.dgvCommodityTradingCompany.RowHeadersVisible = false;
            this.dgvCommodityTradingCompany.Size = new System.Drawing.Size(773, 500);
            this.dgvCommodityTradingCompany.TabIndex = 3;
            this.dgvCommodityTradingCompany.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCommodityTradingCompany_CellBeginEdit);
            this.dgvCommodityTradingCompany.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommodityTradingCompany_CellContentClick);
            this.dgvCommodityTradingCompany.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommodityTradingCompany_CellLeave);
            this.dgvCommodityTradingCompany.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCommodityTradingCompany_CellValidating);
            this.dgvCommodityTradingCompany.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCommodityTradingCompany_RowValidating);
            this.dgvCommodityTradingCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCommodityTradingCompany_KeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage3.Controls.Add(this.btnGetOpenFutures);
            this.tabPage3.Controls.Add(this.dgvClosingFutures);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(786, 588);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Account/Company Xref";
            // 
            // btnGetOpenFutures
            // 
            this.btnGetOpenFutures.Location = new System.Drawing.Point(630, 3);
            this.btnGetOpenFutures.Name = "btnGetOpenFutures";
            this.btnGetOpenFutures.Size = new System.Drawing.Size(150, 27);
            this.btnGetOpenFutures.TabIndex = 8;
            this.btnGetOpenFutures.Text = "Get Open Futures Positions";
            this.btnGetOpenFutures.UseVisualStyleBackColor = true;
            this.btnGetOpenFutures.Click += new System.EventHandler(this.btnGetOpenFutures_Click);
            // 
            // dgvClosingFutures
            // 
            this.dgvClosingFutures.AllowUserToAddRows = false;
            this.dgvClosingFutures.AllowUserToDeleteRows = false;
            this.dgvClosingFutures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClosingFutures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FuturesComm,
            this.FuturesMonth,
            this.FuturesYear,
            this.FuturesID,
            this.ClosingPrice,
            this.FuturesDelete});
            this.dgvClosingFutures.Location = new System.Drawing.Point(7, 36);
            this.dgvClosingFutures.Name = "dgvClosingFutures";
            this.dgvClosingFutures.RowHeadersVisible = false;
            this.dgvClosingFutures.Size = new System.Drawing.Size(773, 547);
            this.dgvClosingFutures.TabIndex = 7;
            this.dgvClosingFutures.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvClosingFutures_CellBeginEdit);
            this.dgvClosingFutures.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClosingFutures_CellContentClick);
            this.dgvClosingFutures.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClosingFutures_CellLeave);
            this.dgvClosingFutures.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvClosingFutures_CellValidating);
            this.dgvClosingFutures.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvClosingFutures_RowValidating);
            this.dgvClosingFutures.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvClosingFutures_KeyDown);
            // 
            // FuturesComm
            // 
            this.FuturesComm.DataPropertyName = "Commodity";
            this.FuturesComm.HeaderText = "Commodity";
            this.FuturesComm.Name = "FuturesComm";
            this.FuturesComm.ReadOnly = true;
            this.FuturesComm.Width = 150;
            // 
            // FuturesMonth
            // 
            this.FuturesMonth.DataPropertyName = "OptionMonth";
            this.FuturesMonth.HeaderText = "Option Month";
            this.FuturesMonth.Name = "FuturesMonth";
            // 
            // FuturesYear
            // 
            this.FuturesYear.DataPropertyName = "OptionYear";
            this.FuturesYear.HeaderText = "Option Year";
            this.FuturesYear.Name = "FuturesYear";
            // 
            // FuturesID
            // 
            this.FuturesID.DataPropertyName = "PSFuturesID";
            this.FuturesID.HeaderText = "FuturesID";
            this.FuturesID.Name = "FuturesID";
            this.FuturesID.Visible = false;
            // 
            // ClosingPrice
            // 
            this.ClosingPrice.DataPropertyName = "ClosingPrice";
            this.ClosingPrice.HeaderText = "Closing Price";
            this.ClosingPrice.Name = "ClosingPrice";
            // 
            // FuturesDelete
            // 
            this.FuturesDelete.HeaderText = "Delete";
            this.FuturesDelete.Name = "FuturesDelete";
            this.FuturesDelete.Text = "Delete";
            this.FuturesDelete.UseColumnTextForButtonValue = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvCommodityLimits);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(786, 588);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Company";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvCommodityLimits
            // 
            this.dgvCommodityLimits.AllowUserToAddRows = false;
            this.dgvCommodityLimits.AllowUserToDeleteRows = false;
            this.dgvCommodityLimits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommodityLimits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Commodity,
            this.Symbol,
            this.RangeLow,
            this.RangeHigh,
            this.LowLimit,
            this.RoundingDivisor,
            this.CommodityID});
            this.dgvCommodityLimits.Location = new System.Drawing.Point(7, 3);
            this.dgvCommodityLimits.Name = "dgvCommodityLimits";
            this.dgvCommodityLimits.Size = new System.Drawing.Size(745, 579);
            this.dgvCommodityLimits.TabIndex = 2;
            this.dgvCommodityLimits.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCommodityLimits_CellBeginEdit);
            this.dgvCommodityLimits.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommodityLimits_CellLeave);
            this.dgvCommodityLimits.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCommodityLimits_CellValidating);
            this.dgvCommodityLimits.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCommodityLimits_RowValidating);
            this.dgvCommodityLimits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCommodityLimits_KeyDown);
            // 
            // Commodity
            // 
            this.Commodity.DataPropertyName = "DESC";
            this.Commodity.HeaderText = "Commodity";
            this.Commodity.Name = "Commodity";
            this.Commodity.ReadOnly = true;
            this.Commodity.Width = 150;
            // 
            // Symbol
            // 
            this.Symbol.DataPropertyName = "Hedger_Position";
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // RangeLow
            // 
            this.RangeLow.DataPropertyName = "Range_Low";
            this.RangeLow.HeaderText = "Low Range";
            this.RangeLow.Name = "RangeLow";
            // 
            // RangeHigh
            // 
            this.RangeHigh.DataPropertyName = "Range_High";
            this.RangeHigh.HeaderText = "High Range";
            this.RangeHigh.Name = "RangeHigh";
            // 
            // LowLimit
            // 
            this.LowLimit.DataPropertyName = "LowLimit";
            this.LowLimit.HeaderText = "Auto Offer Low Limit";
            this.LowLimit.Name = "LowLimit";
            this.LowLimit.Width = 125;
            // 
            // RoundingDivisor
            // 
            this.RoundingDivisor.DataPropertyName = "RoundingDivisor";
            this.RoundingDivisor.HeaderText = "Rounding Divisor";
            this.RoundingDivisor.Name = "RoundingDivisor";
            this.RoundingDivisor.Width = 125;
            // 
            // CommodityID
            // 
            this.CommodityID.DataPropertyName = "TP_Comm";
            this.CommodityID.HeaderText = "CommodityID";
            this.CommodityID.Name = "CommodityID";
            this.CommodityID.Visible = false;
            // 
            // AccountID
            // 
            this.AccountID.DataPropertyName = "TP_ACCT";
            this.AccountID.HeaderText = "Account";
            this.AccountID.Name = "AccountID";
            // 
            // AccountDescription
            // 
            this.AccountDescription.DataPropertyName = "DESC";
            this.AccountDescription.HeaderText = "Description";
            this.AccountDescription.Name = "AccountDescription";
            this.AccountDescription.Width = 250;
            // 
            // Hedger
            // 
            this.Hedger.DataPropertyName = "Hedger";
            this.Hedger.HeaderText = "Hedger";
            this.Hedger.Name = "Hedger";
            this.Hedger.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Hedger.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MarketOrders
            // 
            this.MarketOrders.DataPropertyName = "Market_Orders";
            this.MarketOrders.HeaderText = "Market Order";
            this.MarketOrders.Name = "MarketOrders";
            this.MarketOrders.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MarketOrders.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // frmAccountCommodityMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 662);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmAccountCommodityMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCommodityLimits";
            this.Load += new System.EventHandler(this.frmCommodityLimits_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommodityTradingCompany)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosingFutures)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommodityLimits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private dgvCustom dgvCommodityLimits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RangeLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn RangeHigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoundingDivisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommodityID;
        private System.Windows.Forms.TabPage tabPage2;
        private dgvCustom dgvCommodityTradingCompany;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnGetOpenFutures;
        private dgvCustom dgvClosingFutures;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuturesComm;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuturesMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuturesYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuturesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosingPrice;
        private System.Windows.Forms.DataGridViewButtonColumn FuturesDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hedger;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MarketOrders;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkDelete;
    }
}