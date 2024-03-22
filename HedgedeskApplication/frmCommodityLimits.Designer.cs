namespace HedgedeskApplication
{
    partial class frmCommodityLimits
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
            this.btnDeleteMonthYear = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvCommodityTradingCompany = new dgvCustom();
            this.TradingCommodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradingSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradingCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradingCompCommID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chkDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TradeCommodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradingCompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tpCommodity = new System.Windows.Forms.TabPage();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnAddCommodityMonth = new System.Windows.Forms.Button();
            this.btnAddEditCommodity = new System.Windows.Forms.Button();
            this.dgvCommodityMonths = new dgvCustom();
            this.MonthCommodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MonthSelectDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvCommodities = new dgvCustom();
            this.CommCommodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abbreviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HedgerPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExchgLtr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.UnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CommodityDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CommCommodityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommodityTradingCompany)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosingFutures)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommodityLimits)).BeginInit();
            this.tpCommodity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommodityMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommodities)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(682, 629);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 27);
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
            this.tabControl1.Controls.Add(this.tpCommodity);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 620);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage2.Controls.Add(this.btnDeleteMonthYear);
            this.tabPage2.Controls.Add(this.btnDeleteSelected);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.dgvCommodityTradingCompany);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(786, 594);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Commodity Trading Company";
            // 
            // btnDeleteMonthYear
            // 
            this.btnDeleteMonthYear.Location = new System.Drawing.Point(7, 18);
            this.btnDeleteMonthYear.Name = "btnDeleteMonthYear";
            this.btnDeleteMonthYear.Size = new System.Drawing.Size(113, 27);
            this.btnDeleteMonthYear.TabIndex = 7;
            this.btnDeleteMonthYear.Text = "Delete Month/Year";
            this.btnDeleteMonthYear.UseVisualStyleBackColor = true;
            this.btnDeleteMonthYear.Click += new System.EventHandler(this.btnDeleteMonthYear_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(6, 51);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(114, 27);
            this.btnDeleteSelected.TabIndex = 6;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(677, 51);
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
            this.TradingCommodity,
            this.TradingSymbol,
            this.Month,
            this.Year,
            this.TradingCompany,
            this.CommTID,
            this.TradingCompCommID,
            this.Delete,
            this.chkDelete,
            this.TradeCommodity,
            this.TradingCompanyID});
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
            // TradingCommodity
            // 
            this.TradingCommodity.DataPropertyName = "DESC";
            this.TradingCommodity.HeaderText = "Commodity";
            this.TradingCommodity.Name = "TradingCommodity";
            this.TradingCommodity.ReadOnly = true;
            this.TradingCommodity.Width = 150;
            // 
            // TradingSymbol
            // 
            this.TradingSymbol.DataPropertyName = "Hedger_Position";
            this.TradingSymbol.HeaderText = "Symbol";
            this.TradingSymbol.Name = "TradingSymbol";
            this.TradingSymbol.ReadOnly = true;
            // 
            // Month
            // 
            this.Month.DataPropertyName = "Month";
            this.Month.HeaderText = "Month";
            this.Month.Name = "Month";
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            // 
            // TradingCompany
            // 
            this.TradingCompany.DataPropertyName = "TradingCompany";
            this.TradingCompany.HeaderText = "Trade Company";
            this.TradingCompany.Name = "TradingCompany";
            this.TradingCompany.Width = 125;
            // 
            // CommTID
            // 
            this.CommTID.DataPropertyName = "CommTradingCompID";
            this.CommTID.HeaderText = "TradeCompID";
            this.CommTID.Name = "CommTID";
            this.CommTID.Visible = false;
            this.CommTID.Width = 125;
            // 
            // TradingCompCommID
            // 
            this.TradingCompCommID.DataPropertyName = "CommTradingCompID";
            this.TradingCompCommID.HeaderText = "TradingCompCommID";
            this.TradingCompCommID.Name = "TradingCompCommID";
            this.TradingCompCommID.Visible = false;
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
            // TradeCommodity
            // 
            this.TradeCommodity.DataPropertyName = "TP_Comm";
            this.TradeCommodity.HeaderText = "CommodityID";
            this.TradeCommodity.Name = "TradeCommodity";
            this.TradeCommodity.Visible = false;
            // 
            // TradingCompanyID
            // 
            this.TradingCompanyID.DataPropertyName = "TradingCompany";
            this.TradingCompanyID.HeaderText = "TradingCompanyID";
            this.TradingCompanyID.Name = "TradingCompanyID";
            this.TradingCompanyID.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage3.Controls.Add(this.btnGetOpenFutures);
            this.tabPage3.Controls.Add(this.dgvClosingFutures);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(786, 594);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Update Closing Futures Prices";
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
            this.dgvClosingFutures.Size = new System.Drawing.Size(572, 547);
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
            this.tabPage1.Size = new System.Drawing.Size(786, 594);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Commodity Limits";
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
            this.dgvCommodityLimits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommodityLimits_CellContentClick);
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
            // tpCommodity
            // 
            this.tpCommodity.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tpCommodity.Controls.Add(this.chkActive);
            this.tpCommodity.Controls.Add(this.btnAddCommodityMonth);
            this.tpCommodity.Controls.Add(this.btnAddEditCommodity);
            this.tpCommodity.Controls.Add(this.dgvCommodityMonths);
            this.tpCommodity.Controls.Add(this.dgvCommodities);
            this.tpCommodity.Location = new System.Drawing.Point(4, 22);
            this.tpCommodity.Name = "tpCommodity";
            this.tpCommodity.Size = new System.Drawing.Size(786, 594);
            this.tpCommodity.TabIndex = 3;
            this.tpCommodity.Text = "Commodity";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(569, 12);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(89, 17);
            this.chkActive.TabIndex = 13;
            this.chkActive.Text = "View Deleted";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // btnAddCommodityMonth
            // 
            this.btnAddCommodityMonth.Location = new System.Drawing.Point(677, 329);
            this.btnAddCommodityMonth.Name = "btnAddCommodityMonth";
            this.btnAddCommodityMonth.Size = new System.Drawing.Size(103, 27);
            this.btnAddCommodityMonth.TabIndex = 11;
            this.btnAddCommodityMonth.Text = "Add";
            this.btnAddCommodityMonth.UseVisualStyleBackColor = true;
            this.btnAddCommodityMonth.Click += new System.EventHandler(this.btnAddCommodityMonth_Click);
            // 
            // btnAddEditCommodity
            // 
            this.btnAddEditCommodity.Location = new System.Drawing.Point(677, 6);
            this.btnAddEditCommodity.Name = "btnAddEditCommodity";
            this.btnAddEditCommodity.Size = new System.Drawing.Size(103, 27);
            this.btnAddEditCommodity.TabIndex = 8;
            this.btnAddEditCommodity.Text = "Add";
            this.btnAddEditCommodity.UseVisualStyleBackColor = true;
            this.btnAddEditCommodity.Click += new System.EventHandler(this.btnAddEditCommodity_Click);
            // 
            // dgvCommodityMonths
            // 
            this.dgvCommodityMonths.AllowUserToAddRows = false;
            this.dgvCommodityMonths.AllowUserToDeleteRows = false;
            this.dgvCommodityMonths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommodityMonths.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MonthCommodity,
            this.MonthCode,
            this.MonthDesc,
            this.MonthID,
            this.MonthDelete,
            this.MonthSelectDelete});
            this.dgvCommodityMonths.Location = new System.Drawing.Point(6, 360);
            this.dgvCommodityMonths.Name = "dgvCommodityMonths";
            this.dgvCommodityMonths.RowHeadersVisible = false;
            this.dgvCommodityMonths.Size = new System.Drawing.Size(773, 229);
            this.dgvCommodityMonths.TabIndex = 10;
            this.dgvCommodityMonths.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommodityMonths_CellContentClick);
            // 
            // MonthCommodity
            // 
            this.MonthCommodity.DataPropertyName = "TP_COMM";
            this.MonthCommodity.HeaderText = "Commodity";
            this.MonthCommodity.Name = "MonthCommodity";
            this.MonthCommodity.ReadOnly = true;
            this.MonthCommodity.Width = 150;
            // 
            // MonthCode
            // 
            this.MonthCode.DataPropertyName = "TP_MON";
            this.MonthCode.HeaderText = "Month";
            this.MonthCode.Name = "MonthCode";
            // 
            // MonthDesc
            // 
            this.MonthDesc.DataPropertyName = "DESC";
            this.MonthDesc.HeaderText = "Description";
            this.MonthDesc.Name = "MonthDesc";
            // 
            // MonthID
            // 
            this.MonthID.DataPropertyName = "Month_ID";
            this.MonthID.HeaderText = "Month ID";
            this.MonthID.Name = "MonthID";
            this.MonthID.Width = 125;
            // 
            // MonthDelete
            // 
            this.MonthDelete.HeaderText = "Delete";
            this.MonthDelete.Name = "MonthDelete";
            this.MonthDelete.Text = "Delete";
            this.MonthDelete.UseColumnTextForButtonValue = true;
            // 
            // MonthSelectDelete
            // 
            this.MonthSelectDelete.HeaderText = "";
            this.MonthSelectDelete.Name = "MonthSelectDelete";
            // 
            // dgvCommodities
            // 
            this.dgvCommodities.AllowUserToAddRows = false;
            this.dgvCommodities.AllowUserToDeleteRows = false;
            this.dgvCommodities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommodities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CommCommodity,
            this.Description,
            this.Abbreviation,
            this.HedgerPosition,
            this.dataGridViewTextBoxColumn2,
            this.ExchgLtr,
            this.Edit,
            this.UnDelete,
            this.CommodityDelete,
            this.CommCommodityID});
            this.dgvCommodities.Location = new System.Drawing.Point(7, 37);
            this.dgvCommodities.Name = "dgvCommodities";
            this.dgvCommodities.RowHeadersVisible = false;
            this.dgvCommodities.Size = new System.Drawing.Size(773, 286);
            this.dgvCommodities.TabIndex = 7;
            this.dgvCommodities.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommodities_CellContentClick);
            this.dgvCommodities.SelectionChanged += new System.EventHandler(this.dgvCommodities_SelectionChanged);
            // 
            // CommCommodity
            // 
            this.CommCommodity.DataPropertyName = "TP_COMM";
            this.CommCommodity.HeaderText = "Commodity";
            this.CommCommodity.Name = "CommCommodity";
            this.CommCommodity.ReadOnly = true;
            this.CommCommodity.Width = 75;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "DESC";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 175;
            // 
            // Abbreviation
            // 
            this.Abbreviation.DataPropertyName = "AVVREV";
            this.Abbreviation.HeaderText = "Abbreviation";
            this.Abbreviation.Name = "Abbreviation";
            this.Abbreviation.Width = 75;
            // 
            // HedgerPosition
            // 
            this.HedgerPosition.DataPropertyName = "Hedger_Position";
            this.HedgerPosition.HeaderText = "Hedger Position";
            this.HedgerPosition.Name = "HedgerPosition";
            this.HedgerPosition.Width = 110;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Symbol";
            this.dataGridViewTextBoxColumn2.HeaderText = "Symbol";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // ExchgLtr
            // 
            this.ExchgLtr.DataPropertyName = "TP_EXCHLTR";
            this.ExchgLtr.HeaderText = "ExchgLtr";
            this.ExchgLtr.Name = "ExchgLtr";
            this.ExchgLtr.Width = 60;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 60;
            // 
            // UnDelete
            // 
            this.UnDelete.HeaderText = "UnDelete";
            this.UnDelete.Name = "UnDelete";
            this.UnDelete.Text = "UnDelete";
            this.UnDelete.UseColumnTextForButtonValue = true;
            this.UnDelete.Width = 60;
            // 
            // CommodityDelete
            // 
            this.CommodityDelete.HeaderText = "Delete";
            this.CommodityDelete.Name = "CommodityDelete";
            this.CommodityDelete.Text = "Delete";
            this.CommodityDelete.UseColumnTextForButtonValue = true;
            this.CommodityDelete.Width = 60;
            // 
            // CommCommodityID
            // 
            this.CommCommodityID.DataPropertyName = "TP_Comm";
            this.CommCommodityID.HeaderText = "CommodityID";
            this.CommCommodityID.Name = "CommCommodityID";
            this.CommCommodityID.Visible = false;
            // 
            // frmCommodityLimits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 662);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmCommodityLimits";
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
            this.tpCommodity.ResumeLayout(false);
            this.tpCommodity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommodityMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommodities)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn TradingCommodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradingSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradingCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradingCompCommID;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeCommodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradingCompanyID;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnGetOpenFutures;
        private dgvCustom dgvClosingFutures;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuturesComm;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuturesMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuturesYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuturesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosingPrice;
        private System.Windows.Forms.DataGridViewButtonColumn FuturesDelete;
        private System.Windows.Forms.Button btnDeleteMonthYear;
        private System.Windows.Forms.TabPage tpCommodity;
        private dgvCustom dgvCommodityMonths;
        private System.Windows.Forms.Button btnAddEditCommodity;
        private dgvCustom dgvCommodities;
        private System.Windows.Forms.Button btnAddCommodityMonth;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthCommodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthID;
        private System.Windows.Forms.DataGridViewButtonColumn MonthDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MonthSelectDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommCommodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abbreviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn HedgerPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExchgLtr;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn UnDelete;
        private System.Windows.Forms.DataGridViewButtonColumn CommodityDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommCommodityID;
    }
}