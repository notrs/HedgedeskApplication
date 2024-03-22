namespace HedgedeskApplication
{
    partial class frmReports
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Futures Confirmations");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Daily Futures Position Report");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("CH Confirmations");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("CH Sales Confirmations");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Ratio Position Report");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Position Reports", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Ledger Balance Report");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Reconciliation By Company");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Reconciliation By Commodity");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Zen Noh Report");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Ledger Balance Reports", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Margin Call Report");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Daily Futures Position Grouped");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Daily Futures Position Grouped Detail");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Daily Position Grouped", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Options Open Position");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("OptionsTotalToday");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Option Confirmation");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Options Reports", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Daily Settlement Report");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Monthly Settlement Report");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Settlement Reports", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21});
            this.tvReports = new System.Windows.Forms.TreeView();
            this.grpParametersLedger = new System.Windows.Forms.GroupBox();
            this.btnSetNetEquity = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dtpLastSettlementDate = new System.Windows.Forms.DateTimePicker();
            this.btnLedgerReport = new System.Windows.Forms.Button();
            this.cboLedgerAccounts = new System.Windows.Forms.ComboBox();
            this.cboLedgerCompanies = new System.Windows.Forms.ComboBox();
            this.label120 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.rvHedgedesk = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.grpParameters = new System.Windows.Forms.GroupBox();
            this.btnFuturesConfirmationEmail = new System.Windows.Forms.Button();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.cboParamAccount = new System.Windows.Forms.ComboBox();
            this.cboParamCompany = new System.Windows.Forms.ComboBox();
            this.label112 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.grpDailyPosition = new System.Windows.Forms.GroupBox();
            this.txtDailyYear = new System.Windows.Forms.TextBox();
            this.label139 = new System.Windows.Forms.Label();
            this.cboDailyMonth = new System.Windows.Forms.ComboBox();
            this.label140 = new System.Windows.Forms.Label();
            this.cboDailyCommodity = new System.Windows.Forms.ComboBox();
            this.label132 = new System.Windows.Forms.Label();
            this.btnDailyFuturesPosition = new System.Windows.Forms.Button();
            this.cboDailyAccount = new System.Windows.Forms.ComboBox();
            this.cboDailyCompany = new System.Windows.Forms.ComboBox();
            this.lblcboDailyAccount = new System.Windows.Forms.Label();
            this.lblcboDailyCompany = new System.Windows.Forms.Label();
            this.grpPostionsGrouped = new System.Windows.Forms.GroupBox();
            this.btnFuturesPositionReport = new System.Windows.Forms.Button();
            this.cboFuturesPositionGrouped = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpCHConfirm = new System.Windows.Forms.GroupBox();
            this.chkLiveReport = new System.Windows.Forms.CheckBox();
            this.dtDateTimeCH = new System.Windows.Forms.DateTimePicker();
            this.btnRunCHReport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.grpOptionParamters = new System.Windows.Forms.GroupBox();
            this.chkSelectTradeDate = new System.Windows.Forms.CheckBox();
            this.dtTradeDate = new System.Windows.Forms.DateTimePicker();
            this.lblTradeDate = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.cboHedgebookAccount = new AutoCompleteComboBox();
            this.chkSelectAllAccount = new System.Windows.Forms.CheckBox();
            this.chkAllDate = new System.Windows.Forms.CheckBox();
            this.dtExpiration = new System.Windows.Forms.DateTimePicker();
            this.btnOptions = new System.Windows.Forms.Button();
            this.lblExpiration = new System.Windows.Forms.Label();
            this.grpRunOnly = new System.Windows.Forms.GroupBox();
            this.btnMarginCall = new System.Windows.Forms.Button();
            this.grpMonthlySettlement = new System.Windows.Forms.GroupBox();
            this.dtSettleStart = new System.Windows.Forms.DateTimePicker();
            this.cboMonAccSettle = new System.Windows.Forms.ComboBox();
            this.cboMonCoSettle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtSettleEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMonthlySettlement = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.grpDailySettlement = new System.Windows.Forms.GroupBox();
            this.cboDailyAcct = new System.Windows.Forms.ComboBox();
            this.cboDailyComp = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtSettleDaily = new System.Windows.Forms.DateTimePicker();
            this.btnDailySettlement = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.grpParametersLedger.SuspendLayout();
            this.grpParameters.SuspendLayout();
            this.grpDailyPosition.SuspendLayout();
            this.grpPostionsGrouped.SuspendLayout();
            this.grpCHConfirm.SuspendLayout();
            this.grpOptionParamters.SuspendLayout();
            this.grpRunOnly.SuspendLayout();
            this.grpMonthlySettlement.SuspendLayout();
            this.grpDailySettlement.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvReports
            // 
            this.tvReports.Location = new System.Drawing.Point(-1, -1);
            this.tvReports.Name = "tvReports";
            treeNode1.Name = "tcFuturesConfirmations";
            treeNode1.Text = "Futures Confirmations";
            treeNode2.Name = "rptDailyFuturesPositionReport";
            treeNode2.Text = "Daily Futures Position Report";
            treeNode3.Name = "CHConfirms";
            treeNode3.Text = "CH Confirmations";
            treeNode4.Name = "CHSalesConfirms";
            treeNode4.Text = "CH Sales Confirmations";
            treeNode5.Name = "RatioPositionReport";
            treeNode5.Text = "Ratio Position Report";
            treeNode6.Name = "trPositionReports";
            treeNode6.Text = "Position Reports";
            treeNode7.Name = "LedgerBalanceReport";
            treeNode7.Tag = "rptLedgerBalanceReport";
            treeNode7.Text = "Ledger Balance Report";
            treeNode8.Name = "ReconciliationByCompany";
            treeNode8.Tag = "ReconciliationReport_ByComp";
            treeNode8.Text = "Reconciliation By Company";
            treeNode9.Name = "ReconciliationByCommodity";
            treeNode9.Tag = "ReconciliationReport_ByComm";
            treeNode9.Text = "Reconciliation By Commodity";
            treeNode10.Name = "ZenNohReport";
            treeNode10.Text = "Zen Noh Report";
            treeNode11.Name = "LedgerBalanceReports";
            treeNode11.Tag = "rptLedgerBalanceReport";
            treeNode11.Text = "Ledger Balance Reports";
            treeNode12.Name = "MarginCallReport";
            treeNode12.Text = "Margin Call Report";
            treeNode13.Name = "DailyFuturesPositionGrouped";
            treeNode13.Text = "Daily Futures Position Grouped";
            treeNode14.Name = "DailyFuturesPositionDetail";
            treeNode14.Text = "Daily Futures Position Grouped Detail";
            treeNode15.Name = "trFuturesPositionReports";
            treeNode15.Text = "Daily Position Grouped";
            treeNode16.Name = "rptOptionsOpenPosition";
            treeNode16.Text = "Options Open Position";
            treeNode17.Name = "rptOptionsTotalToday";
            treeNode17.Text = "OptionsTotalToday";
            treeNode18.Name = "rptOptionConfirmationMaster";
            treeNode18.Text = "Option Confirmation";
            treeNode19.Name = "OptionsReports";
            treeNode19.Text = "Options Reports";
            treeNode20.Name = "DailySettlementReport";
            treeNode20.Text = "Daily Settlement Report";
            treeNode21.Name = "MonthlySettlementReport";
            treeNode21.Text = "Monthly Settlement Report";
            treeNode22.Name = "SettlementReports";
            treeNode22.Text = "Settlement Reports";
            this.tvReports.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode11,
            treeNode12,
            treeNode15,
            treeNode19,
            treeNode22});
            this.tvReports.Size = new System.Drawing.Size(238, 703);
            this.tvReports.TabIndex = 4;
            this.tvReports.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvReports_AfterSelect);
            // 
            // grpParametersLedger
            // 
            this.grpParametersLedger.Controls.Add(this.btnSetNetEquity);
            this.grpParametersLedger.Controls.Add(this.button4);
            this.grpParametersLedger.Controls.Add(this.dtpLastSettlementDate);
            this.grpParametersLedger.Controls.Add(this.btnLedgerReport);
            this.grpParametersLedger.Controls.Add(this.cboLedgerAccounts);
            this.grpParametersLedger.Controls.Add(this.cboLedgerCompanies);
            this.grpParametersLedger.Controls.Add(this.label120);
            this.grpParametersLedger.Controls.Add(this.label122);
            this.grpParametersLedger.Controls.Add(this.label123);
            this.grpParametersLedger.Location = new System.Drawing.Point(241, -1);
            this.grpParametersLedger.Name = "grpParametersLedger";
            this.grpParametersLedger.Size = new System.Drawing.Size(1015, 110);
            this.grpParametersLedger.TabIndex = 6;
            this.grpParametersLedger.TabStop = false;
            this.grpParametersLedger.Text = "Parameters";
            this.grpParametersLedger.Visible = false;
            // 
            // btnSetNetEquity
            // 
            this.btnSetNetEquity.Location = new System.Drawing.Point(699, 28);
            this.btnSetNetEquity.Name = "btnSetNetEquity";
            this.btnSetNetEquity.Size = new System.Drawing.Size(143, 23);
            this.btnSetNetEquity.TabIndex = 29;
            this.btnSetNetEquity.Text = "Set Previous Net Eqyuity";
            this.btnSetNetEquity.UseVisualStyleBackColor = true;
            this.btnSetNetEquity.Visible = false;
            this.btnSetNetEquity.Click += new System.EventHandler(this.btnSetNetEquity_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(487, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 23);
            this.button4.TabIndex = 28;
            this.button4.Text = "Send to Portal";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dtpLastSettlementDate
            // 
            this.dtpLastSettlementDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLastSettlementDate.Location = new System.Drawing.Point(197, 24);
            this.dtpLastSettlementDate.Name = "dtpLastSettlementDate";
            this.dtpLastSettlementDate.Size = new System.Drawing.Size(121, 20);
            this.dtpLastSettlementDate.TabIndex = 27;
            this.dtpLastSettlementDate.Value = new System.DateTime(2012, 6, 1, 8, 12, 0, 0);
            // 
            // btnLedgerReport
            // 
            this.btnLedgerReport.Location = new System.Drawing.Point(857, 28);
            this.btnLedgerReport.Name = "btnLedgerReport";
            this.btnLedgerReport.Size = new System.Drawing.Size(143, 23);
            this.btnLedgerReport.TabIndex = 26;
            this.btnLedgerReport.Text = "Run Report";
            this.btnLedgerReport.UseVisualStyleBackColor = true;
            this.btnLedgerReport.Click += new System.EventHandler(this.btnLedgerReport_Click);
            // 
            // cboLedgerAccounts
            // 
            this.cboLedgerAccounts.FormattingEnabled = true;
            this.cboLedgerAccounts.Location = new System.Drawing.Point(197, 74);
            this.cboLedgerAccounts.Name = "cboLedgerAccounts";
            this.cboLedgerAccounts.Size = new System.Drawing.Size(121, 21);
            this.cboLedgerAccounts.TabIndex = 25;
            // 
            // cboLedgerCompanies
            // 
            this.cboLedgerCompanies.FormattingEnabled = true;
            this.cboLedgerCompanies.Location = new System.Drawing.Point(197, 50);
            this.cboLedgerCompanies.Name = "cboLedgerCompanies";
            this.cboLedgerCompanies.Size = new System.Drawing.Size(121, 21);
            this.cboLedgerCompanies.TabIndex = 24;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(141, 78);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(50, 13);
            this.label120.TabIndex = 23;
            this.label120.Text = "Account:";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(133, 53);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(54, 13);
            this.label122.TabIndex = 22;
            this.label122.Text = "Company:";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(82, 28);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(109, 13);
            this.label123.TabIndex = 15;
            this.label123.Text = "Last Settlement Date:";
            // 
            // rvHedgedesk
            // 
            this.rvHedgedesk.Location = new System.Drawing.Point(243, 115);
            this.rvHedgedesk.Name = "rvHedgedesk";
            this.rvHedgedesk.Size = new System.Drawing.Size(1016, 587);
            this.rvHedgedesk.TabIndex = 5;
            // 
            // grpParameters
            // 
            this.grpParameters.Controls.Add(this.btnFuturesConfirmationEmail);
            this.grpParameters.Controls.Add(this.dtpOrderDate);
            this.grpParameters.Controls.Add(this.btnRunReport);
            this.grpParameters.Controls.Add(this.cboParamAccount);
            this.grpParameters.Controls.Add(this.cboParamCompany);
            this.grpParameters.Controls.Add(this.label112);
            this.grpParameters.Controls.Add(this.label113);
            this.grpParameters.Controls.Add(this.label111);
            this.grpParameters.Location = new System.Drawing.Point(241, -1);
            this.grpParameters.Name = "grpParameters";
            this.grpParameters.Size = new System.Drawing.Size(1015, 110);
            this.grpParameters.TabIndex = 7;
            this.grpParameters.TabStop = false;
            this.grpParameters.Text = "Parameters";
            this.grpParameters.Visible = false;
            // 
            // btnFuturesConfirmationEmail
            // 
            this.btnFuturesConfirmationEmail.Location = new System.Drawing.Point(857, 57);
            this.btnFuturesConfirmationEmail.Name = "btnFuturesConfirmationEmail";
            this.btnFuturesConfirmationEmail.Size = new System.Drawing.Size(143, 23);
            this.btnFuturesConfirmationEmail.TabIndex = 28;
            this.btnFuturesConfirmationEmail.Text = "Send To Portal";
            this.btnFuturesConfirmationEmail.UseVisualStyleBackColor = true;
            this.btnFuturesConfirmationEmail.Click += new System.EventHandler(this.btnFuturesConfirmationEmail_Click);
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(197, 24);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(121, 20);
            this.dtpOrderDate.TabIndex = 27;
            // 
            // btnRunReport
            // 
            this.btnRunReport.Location = new System.Drawing.Point(857, 22);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(143, 23);
            this.btnRunReport.TabIndex = 26;
            this.btnRunReport.Text = "Run Report";
            this.btnRunReport.UseVisualStyleBackColor = true;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // cboParamAccount
            // 
            this.cboParamAccount.FormattingEnabled = true;
            this.cboParamAccount.Location = new System.Drawing.Point(197, 74);
            this.cboParamAccount.Name = "cboParamAccount";
            this.cboParamAccount.Size = new System.Drawing.Size(121, 21);
            this.cboParamAccount.TabIndex = 25;
            // 
            // cboParamCompany
            // 
            this.cboParamCompany.FormattingEnabled = true;
            this.cboParamCompany.Location = new System.Drawing.Point(197, 50);
            this.cboParamCompany.Name = "cboParamCompany";
            this.cboParamCompany.Size = new System.Drawing.Size(121, 21);
            this.cboParamCompany.TabIndex = 24;
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(141, 78);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(50, 13);
            this.label112.TabIndex = 23;
            this.label112.Text = "Account:";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(98, 54);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(93, 13);
            this.label113.TabIndex = 22;
            this.label113.Text = "Trading Company:";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(130, 26);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(62, 13);
            this.label111.TabIndex = 15;
            this.label111.Text = "Order Date:";
            // 
            // grpDailyPosition
            // 
            this.grpDailyPosition.Controls.Add(this.txtDailyYear);
            this.grpDailyPosition.Controls.Add(this.label139);
            this.grpDailyPosition.Controls.Add(this.cboDailyMonth);
            this.grpDailyPosition.Controls.Add(this.label140);
            this.grpDailyPosition.Controls.Add(this.cboDailyCommodity);
            this.grpDailyPosition.Controls.Add(this.label132);
            this.grpDailyPosition.Controls.Add(this.btnDailyFuturesPosition);
            this.grpDailyPosition.Controls.Add(this.cboDailyAccount);
            this.grpDailyPosition.Controls.Add(this.cboDailyCompany);
            this.grpDailyPosition.Controls.Add(this.lblcboDailyAccount);
            this.grpDailyPosition.Controls.Add(this.lblcboDailyCompany);
            this.grpDailyPosition.Location = new System.Drawing.Point(241, -1);
            this.grpDailyPosition.Name = "grpDailyPosition";
            this.grpDailyPosition.Size = new System.Drawing.Size(1015, 110);
            this.grpDailyPosition.TabIndex = 31;
            this.grpDailyPosition.TabStop = false;
            this.grpDailyPosition.Text = "Daily Position Report";
            this.grpDailyPosition.Visible = false;
            this.grpDailyPosition.Enter += new System.EventHandler(this.grpDailyPosition_Enter);
            // 
            // txtDailyYear
            // 
            this.txtDailyYear.BackColor = System.Drawing.SystemColors.Window;
            this.txtDailyYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDailyYear.Location = new System.Drawing.Point(133, 74);
            this.txtDailyYear.Name = "txtDailyYear";
            this.txtDailyYear.Size = new System.Drawing.Size(121, 20);
            this.txtDailyYear.TabIndex = 32;
            this.txtDailyYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(61, 76);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(32, 13);
            this.label139.TabIndex = 31;
            this.label139.Text = "Year:";
            // 
            // cboDailyMonth
            // 
            this.cboDailyMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDailyMonth.FormattingEnabled = true;
            this.cboDailyMonth.Location = new System.Drawing.Point(133, 48);
            this.cboDailyMonth.Name = "cboDailyMonth";
            this.cboDailyMonth.Size = new System.Drawing.Size(121, 21);
            this.cboDailyMonth.TabIndex = 30;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(61, 52);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(40, 13);
            this.label140.TabIndex = 29;
            this.label140.Text = "Month:";
            // 
            // cboDailyCommodity
            // 
            this.cboDailyCommodity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDailyCommodity.FormattingEnabled = true;
            this.cboDailyCommodity.Location = new System.Drawing.Point(133, 22);
            this.cboDailyCommodity.Name = "cboDailyCommodity";
            this.cboDailyCommodity.Size = new System.Drawing.Size(121, 21);
            this.cboDailyCommodity.TabIndex = 28;
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(61, 26);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(61, 13);
            this.label132.TabIndex = 27;
            this.label132.Text = "Commodity:";
            // 
            // btnDailyFuturesPosition
            // 
            this.btnDailyFuturesPosition.Location = new System.Drawing.Point(848, 22);
            this.btnDailyFuturesPosition.Name = "btnDailyFuturesPosition";
            this.btnDailyFuturesPosition.Size = new System.Drawing.Size(143, 23);
            this.btnDailyFuturesPosition.TabIndex = 26;
            this.btnDailyFuturesPosition.Text = "Run Report";
            this.btnDailyFuturesPosition.UseVisualStyleBackColor = true;
            this.btnDailyFuturesPosition.Click += new System.EventHandler(this.btnDailyFuturesPosition_Click);
            // 
            // cboDailyAccount
            // 
            this.cboDailyAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDailyAccount.FormattingEnabled = true;
            this.cboDailyAccount.Location = new System.Drawing.Point(345, 21);
            this.cboDailyAccount.Name = "cboDailyAccount";
            this.cboDailyAccount.Size = new System.Drawing.Size(121, 21);
            this.cboDailyAccount.TabIndex = 25;
            // 
            // cboDailyCompany
            // 
            this.cboDailyCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDailyCompany.FormattingEnabled = true;
            this.cboDailyCompany.Location = new System.Drawing.Point(346, 48);
            this.cboDailyCompany.Name = "cboDailyCompany";
            this.cboDailyCompany.Size = new System.Drawing.Size(121, 21);
            this.cboDailyCompany.TabIndex = 24;
            // 
            // lblcboDailyAccount
            // 
            this.lblcboDailyAccount.AutoSize = true;
            this.lblcboDailyAccount.Location = new System.Drawing.Point(289, 25);
            this.lblcboDailyAccount.Name = "lblcboDailyAccount";
            this.lblcboDailyAccount.Size = new System.Drawing.Size(50, 13);
            this.lblcboDailyAccount.TabIndex = 23;
            this.lblcboDailyAccount.Text = "Account:";
            // 
            // lblcboDailyCompany
            // 
            this.lblcboDailyCompany.AutoSize = true;
            this.lblcboDailyCompany.Location = new System.Drawing.Point(289, 52);
            this.lblcboDailyCompany.Name = "lblcboDailyCompany";
            this.lblcboDailyCompany.Size = new System.Drawing.Size(54, 13);
            this.lblcboDailyCompany.TabIndex = 22;
            this.lblcboDailyCompany.Text = "Company:";
            // 
            // grpPostionsGrouped
            // 
            this.grpPostionsGrouped.Controls.Add(this.btnFuturesPositionReport);
            this.grpPostionsGrouped.Controls.Add(this.cboFuturesPositionGrouped);
            this.grpPostionsGrouped.Controls.Add(this.label5);
            this.grpPostionsGrouped.Location = new System.Drawing.Point(241, -1);
            this.grpPostionsGrouped.Name = "grpPostionsGrouped";
            this.grpPostionsGrouped.Size = new System.Drawing.Size(1015, 110);
            this.grpPostionsGrouped.TabIndex = 33;
            this.grpPostionsGrouped.TabStop = false;
            this.grpPostionsGrouped.Text = "Futures Position Grouped Report";
            this.grpPostionsGrouped.Visible = false;
            // 
            // btnFuturesPositionReport
            // 
            this.btnFuturesPositionReport.Location = new System.Drawing.Point(848, 22);
            this.btnFuturesPositionReport.Name = "btnFuturesPositionReport";
            this.btnFuturesPositionReport.Size = new System.Drawing.Size(143, 23);
            this.btnFuturesPositionReport.TabIndex = 26;
            this.btnFuturesPositionReport.Text = "Run Report";
            this.btnFuturesPositionReport.UseVisualStyleBackColor = true;
            this.btnFuturesPositionReport.Click += new System.EventHandler(this.btnFuturesPositionReport_Click);
            // 
            // cboFuturesPositionGrouped
            // 
            this.cboFuturesPositionGrouped.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuturesPositionGrouped.FormattingEnabled = true;
            this.cboFuturesPositionGrouped.Location = new System.Drawing.Point(192, 20);
            this.cboFuturesPositionGrouped.Name = "cboFuturesPositionGrouped";
            this.cboFuturesPositionGrouped.Size = new System.Drawing.Size(169, 21);
            this.cboFuturesPositionGrouped.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Futures Position Group:";
            // 
            // grpCHConfirm
            // 
            this.grpCHConfirm.Controls.Add(this.chkLiveReport);
            this.grpCHConfirm.Controls.Add(this.dtDateTimeCH);
            this.grpCHConfirm.Controls.Add(this.btnRunCHReport);
            this.grpCHConfirm.Controls.Add(this.label3);
            this.grpCHConfirm.Location = new System.Drawing.Point(241, 0);
            this.grpCHConfirm.Name = "grpCHConfirm";
            this.grpCHConfirm.Size = new System.Drawing.Size(1015, 110);
            this.grpCHConfirm.TabIndex = 34;
            this.grpCHConfirm.TabStop = false;
            this.grpCHConfirm.Text = "Parameters";
            this.grpCHConfirm.Visible = false;
            // 
            // chkLiveReport
            // 
            this.chkLiveReport.AutoSize = true;
            this.chkLiveReport.Location = new System.Drawing.Point(136, 70);
            this.chkLiveReport.Name = "chkLiveReport";
            this.chkLiveReport.Size = new System.Drawing.Size(112, 17);
            this.chkLiveReport.TabIndex = 28;
            this.chkLiveReport.Text = "Live Confirmations";
            this.chkLiveReport.UseVisualStyleBackColor = true;
            this.chkLiveReport.CheckedChanged += new System.EventHandler(this.chkLiveReport_CheckedChanged);
            // 
            // dtDateTimeCH
            // 
            this.dtDateTimeCH.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateTimeCH.Location = new System.Drawing.Point(197, 24);
            this.dtDateTimeCH.Name = "dtDateTimeCH";
            this.dtDateTimeCH.Size = new System.Drawing.Size(121, 20);
            this.dtDateTimeCH.TabIndex = 27;
            // 
            // btnRunCHReport
            // 
            this.btnRunCHReport.Location = new System.Drawing.Point(487, 20);
            this.btnRunCHReport.Name = "btnRunCHReport";
            this.btnRunCHReport.Size = new System.Drawing.Size(143, 23);
            this.btnRunCHReport.TabIndex = 26;
            this.btnRunCHReport.Text = "Run Report";
            this.btnRunCHReport.UseVisualStyleBackColor = true;
            this.btnRunCHReport.Click += new System.EventHandler(this.btnRunCHReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Order Date:";
            // 
            // grpOptionParamters
            // 
            this.grpOptionParamters.Controls.Add(this.chkSelectTradeDate);
            this.grpOptionParamters.Controls.Add(this.dtTradeDate);
            this.grpOptionParamters.Controls.Add(this.lblTradeDate);
            this.grpOptionParamters.Controls.Add(this.label141);
            this.grpOptionParamters.Controls.Add(this.cboHedgebookAccount);
            this.grpOptionParamters.Controls.Add(this.chkSelectAllAccount);
            this.grpOptionParamters.Controls.Add(this.chkAllDate);
            this.grpOptionParamters.Controls.Add(this.dtExpiration);
            this.grpOptionParamters.Controls.Add(this.btnOptions);
            this.grpOptionParamters.Controls.Add(this.lblExpiration);
            this.grpOptionParamters.Location = new System.Drawing.Point(241, 0);
            this.grpOptionParamters.Name = "grpOptionParamters";
            this.grpOptionParamters.Size = new System.Drawing.Size(1015, 110);
            this.grpOptionParamters.TabIndex = 35;
            this.grpOptionParamters.TabStop = false;
            this.grpOptionParamters.Text = "Parameters";
            this.grpOptionParamters.Visible = false;
            // 
            // chkSelectTradeDate
            // 
            this.chkSelectTradeDate.AutoSize = true;
            this.chkSelectTradeDate.Location = new System.Drawing.Point(367, 51);
            this.chkSelectTradeDate.Name = "chkSelectTradeDate";
            this.chkSelectTradeDate.Size = new System.Drawing.Size(132, 17);
            this.chkSelectTradeDate.TabIndex = 94;
            this.chkSelectTradeDate.Text = "Select All Trade Dates";
            this.chkSelectTradeDate.UseVisualStyleBackColor = true;
            this.chkSelectTradeDate.CheckedChanged += new System.EventHandler(this.chkSelectTradeDate_CheckedChanged);
            // 
            // dtTradeDate
            // 
            this.dtTradeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTradeDate.Location = new System.Drawing.Point(218, 49);
            this.dtTradeDate.Name = "dtTradeDate";
            this.dtTradeDate.Size = new System.Drawing.Size(121, 20);
            this.dtTradeDate.TabIndex = 93;
            // 
            // lblTradeDate
            // 
            this.lblTradeDate.AutoSize = true;
            this.lblTradeDate.Location = new System.Drawing.Point(130, 51);
            this.lblTradeDate.Name = "lblTradeDate";
            this.lblTradeDate.Size = new System.Drawing.Size(64, 13);
            this.lblTradeDate.TabIndex = 92;
            this.lblTradeDate.Text = "Trade Date:";
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(103, 81);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(109, 13);
            this.label141.TabIndex = 91;
            this.label141.Text = "Hedgebook Account:";
            // 
            // cboHedgebookAccount
            // 
            this.cboHedgebookAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboHedgebookAccount.FormattingEnabled = true;
            this.cboHedgebookAccount.Location = new System.Drawing.Point(218, 76);
            this.cboHedgebookAccount.Name = "cboHedgebookAccount";
            this.cboHedgebookAccount.Size = new System.Drawing.Size(121, 21);
            this.cboHedgebookAccount.Strict = true;
            this.cboHedgebookAccount.TabIndex = 90;
            // 
            // chkSelectAllAccount
            // 
            this.chkSelectAllAccount.AutoSize = true;
            this.chkSelectAllAccount.Location = new System.Drawing.Point(367, 79);
            this.chkSelectAllAccount.Name = "chkSelectAllAccount";
            this.chkSelectAllAccount.Size = new System.Drawing.Size(118, 17);
            this.chkSelectAllAccount.TabIndex = 29;
            this.chkSelectAllAccount.Text = "Select All Accounts";
            this.chkSelectAllAccount.UseVisualStyleBackColor = true;
            this.chkSelectAllAccount.CheckedChanged += new System.EventHandler(this.chkSelectAllAccount_CheckedChanged);
            // 
            // chkAllDate
            // 
            this.chkAllDate.AutoSize = true;
            this.chkAllDate.Location = new System.Drawing.Point(367, 26);
            this.chkAllDate.Name = "chkAllDate";
            this.chkAllDate.Size = new System.Drawing.Size(101, 17);
            this.chkAllDate.TabIndex = 28;
            this.chkAllDate.Text = "Select All Dates";
            this.chkAllDate.UseVisualStyleBackColor = true;
            this.chkAllDate.CheckedChanged += new System.EventHandler(this.chkAllDate_CheckedChanged);
            // 
            // dtExpiration
            // 
            this.dtExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpiration.Location = new System.Drawing.Point(218, 24);
            this.dtExpiration.Name = "dtExpiration";
            this.dtExpiration.Size = new System.Drawing.Size(121, 20);
            this.dtExpiration.TabIndex = 27;
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(848, 22);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(143, 23);
            this.btnOptions.TabIndex = 26;
            this.btnOptions.Text = "Run Report";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // lblExpiration
            // 
            this.lblExpiration.AutoSize = true;
            this.lblExpiration.Location = new System.Drawing.Point(130, 26);
            this.lblExpiration.Name = "lblExpiration";
            this.lblExpiration.Size = new System.Drawing.Size(82, 13);
            this.lblExpiration.TabIndex = 15;
            this.lblExpiration.Text = "Expiration Date:";
            // 
            // grpRunOnly
            // 
            this.grpRunOnly.Controls.Add(this.btnMarginCall);
            this.grpRunOnly.Location = new System.Drawing.Point(241, 0);
            this.grpRunOnly.Name = "grpRunOnly";
            this.grpRunOnly.Size = new System.Drawing.Size(1015, 110);
            this.grpRunOnly.TabIndex = 28;
            this.grpRunOnly.TabStop = false;
            this.grpRunOnly.Text = "Parameters";
            this.grpRunOnly.Visible = false;
            // 
            // btnMarginCall
            // 
            this.btnMarginCall.Location = new System.Drawing.Point(857, 22);
            this.btnMarginCall.Name = "btnMarginCall";
            this.btnMarginCall.Size = new System.Drawing.Size(143, 23);
            this.btnMarginCall.TabIndex = 26;
            this.btnMarginCall.Text = "Run Report";
            this.btnMarginCall.UseVisualStyleBackColor = true;
            this.btnMarginCall.Click += new System.EventHandler(this.btnMarginCall_Click);
            // 
            // grpMonthlySettlement
            // 
            this.grpMonthlySettlement.Controls.Add(this.dtSettleStart);
            this.grpMonthlySettlement.Controls.Add(this.cboMonAccSettle);
            this.grpMonthlySettlement.Controls.Add(this.cboMonCoSettle);
            this.grpMonthlySettlement.Controls.Add(this.label2);
            this.grpMonthlySettlement.Controls.Add(this.label6);
            this.grpMonthlySettlement.Controls.Add(this.dtSettleEnd);
            this.grpMonthlySettlement.Controls.Add(this.label1);
            this.grpMonthlySettlement.Controls.Add(this.btnMonthlySettlement);
            this.grpMonthlySettlement.Controls.Add(this.label4);
            this.grpMonthlySettlement.Location = new System.Drawing.Point(241, 0);
            this.grpMonthlySettlement.Name = "grpMonthlySettlement";
            this.grpMonthlySettlement.Size = new System.Drawing.Size(1015, 110);
            this.grpMonthlySettlement.TabIndex = 95;
            this.grpMonthlySettlement.TabStop = false;
            this.grpMonthlySettlement.Text = "Parameters";
            this.grpMonthlySettlement.Visible = false;
            // 
            // dtSettleStart
            // 
            this.dtSettleStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSettleStart.Location = new System.Drawing.Point(377, 22);
            this.dtSettleStart.Name = "dtSettleStart";
            this.dtSettleStart.Size = new System.Drawing.Size(121, 20);
            this.dtSettleStart.TabIndex = 98;
            // 
            // cboMonAccSettle
            // 
            this.cboMonAccSettle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonAccSettle.FormattingEnabled = true;
            this.cboMonAccSettle.Location = new System.Drawing.Point(117, 20);
            this.cboMonAccSettle.Name = "cboMonAccSettle";
            this.cboMonAccSettle.Size = new System.Drawing.Size(121, 21);
            this.cboMonAccSettle.TabIndex = 97;
            // 
            // cboMonCoSettle
            // 
            this.cboMonCoSettle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonCoSettle.FormattingEnabled = true;
            this.cboMonCoSettle.Location = new System.Drawing.Point(118, 47);
            this.cboMonCoSettle.Name = "cboMonCoSettle";
            this.cboMonCoSettle.Size = new System.Drawing.Size(121, 21);
            this.cboMonCoSettle.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Account:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 94;
            this.label6.Text = "Company:";
            // 
            // dtSettleEnd
            // 
            this.dtSettleEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSettleEnd.Location = new System.Drawing.Point(377, 48);
            this.dtSettleEnd.Name = "dtSettleEnd";
            this.dtSettleEnd.Size = new System.Drawing.Size(121, 20);
            this.dtSettleEnd.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Settlement End:";
            // 
            // btnMonthlySettlement
            // 
            this.btnMonthlySettlement.Location = new System.Drawing.Point(848, 22);
            this.btnMonthlySettlement.Name = "btnMonthlySettlement";
            this.btnMonthlySettlement.Size = new System.Drawing.Size(143, 23);
            this.btnMonthlySettlement.TabIndex = 26;
            this.btnMonthlySettlement.Text = "Run Report";
            this.btnMonthlySettlement.UseVisualStyleBackColor = true;
            this.btnMonthlySettlement.Click += new System.EventHandler(this.btnMonthlySettlement_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Settlement Start:";
            // 
            // grpDailySettlement
            // 
            this.grpDailySettlement.Controls.Add(this.cboDailyAcct);
            this.grpDailySettlement.Controls.Add(this.cboDailyComp);
            this.grpDailySettlement.Controls.Add(this.label7);
            this.grpDailySettlement.Controls.Add(this.label8);
            this.grpDailySettlement.Controls.Add(this.dtSettleDaily);
            this.grpDailySettlement.Controls.Add(this.btnDailySettlement);
            this.grpDailySettlement.Controls.Add(this.label10);
            this.grpDailySettlement.Location = new System.Drawing.Point(241, -1);
            this.grpDailySettlement.Name = "grpDailySettlement";
            this.grpDailySettlement.Size = new System.Drawing.Size(1015, 110);
            this.grpDailySettlement.TabIndex = 99;
            this.grpDailySettlement.TabStop = false;
            this.grpDailySettlement.Text = "Parameters";
            this.grpDailySettlement.Visible = false;
            this.grpDailySettlement.Enter += new System.EventHandler(this.grpDailySettlement_Enter);
            // 
            // cboDailyAcct
            // 
            this.cboDailyAcct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDailyAcct.FormattingEnabled = true;
            this.cboDailyAcct.Location = new System.Drawing.Point(117, 20);
            this.cboDailyAcct.Name = "cboDailyAcct";
            this.cboDailyAcct.Size = new System.Drawing.Size(121, 21);
            this.cboDailyAcct.TabIndex = 97;
            // 
            // cboDailyComp
            // 
            this.cboDailyComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDailyComp.FormattingEnabled = true;
            this.cboDailyComp.Location = new System.Drawing.Point(118, 47);
            this.cboDailyComp.Name = "cboDailyComp";
            this.cboDailyComp.Size = new System.Drawing.Size(121, 21);
            this.cboDailyComp.TabIndex = 96;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 95;
            this.label7.Text = "Account:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 94;
            this.label8.Text = "Company:";
            // 
            // dtSettleDaily
            // 
            this.dtSettleDaily.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSettleDaily.Location = new System.Drawing.Point(377, 23);
            this.dtSettleDaily.Name = "dtSettleDaily";
            this.dtSettleDaily.Size = new System.Drawing.Size(121, 20);
            this.dtSettleDaily.TabIndex = 27;
            // 
            // btnDailySettlement
            // 
            this.btnDailySettlement.Location = new System.Drawing.Point(848, 22);
            this.btnDailySettlement.Name = "btnDailySettlement";
            this.btnDailySettlement.Size = new System.Drawing.Size(143, 23);
            this.btnDailySettlement.TabIndex = 26;
            this.btnDailySettlement.Text = "Run Report";
            this.btnDailySettlement.UseVisualStyleBackColor = true;
            this.btnDailySettlement.Click += new System.EventHandler(this.btnDailySettlement_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Settlement Date:";
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 705);
            this.Controls.Add(this.rvHedgedesk);
            this.Controls.Add(this.tvReports);
            this.Controls.Add(this.grpRunOnly);
            this.Controls.Add(this.grpCHConfirm);
            this.Controls.Add(this.grpParameters);
            this.Controls.Add(this.grpParametersLedger);
            this.Controls.Add(this.grpPostionsGrouped);
            this.Controls.Add(this.grpDailyPosition);
            this.Controls.Add(this.grpDailySettlement);
            this.Controls.Add(this.grpMonthlySettlement);
            this.Controls.Add(this.grpOptionParamters);
            this.Name = "frmReports";
            this.Text = "frmReports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.grpParametersLedger.ResumeLayout(false);
            this.grpParametersLedger.PerformLayout();
            this.grpParameters.ResumeLayout(false);
            this.grpParameters.PerformLayout();
            this.grpDailyPosition.ResumeLayout(false);
            this.grpDailyPosition.PerformLayout();
            this.grpPostionsGrouped.ResumeLayout(false);
            this.grpPostionsGrouped.PerformLayout();
            this.grpCHConfirm.ResumeLayout(false);
            this.grpCHConfirm.PerformLayout();
            this.grpOptionParamters.ResumeLayout(false);
            this.grpOptionParamters.PerformLayout();
            this.grpRunOnly.ResumeLayout(false);
            this.grpMonthlySettlement.ResumeLayout(false);
            this.grpMonthlySettlement.PerformLayout();
            this.grpDailySettlement.ResumeLayout(false);
            this.grpDailySettlement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvReports;
        private System.Windows.Forms.GroupBox grpParametersLedger;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dtpLastSettlementDate;
        private System.Windows.Forms.Button btnLedgerReport;
        private System.Windows.Forms.ComboBox cboLedgerAccounts;
        private System.Windows.Forms.ComboBox cboLedgerCompanies;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.Label label123;
        private Telerik.ReportViewer.WinForms.ReportViewer rvHedgedesk;
        private System.Windows.Forms.GroupBox grpParameters;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.ComboBox cboParamAccount;
        private System.Windows.Forms.ComboBox cboParamCompany;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.GroupBox grpDailyPosition;
        private System.Windows.Forms.TextBox txtDailyYear;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.ComboBox cboDailyMonth;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.ComboBox cboDailyCommodity;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.Button btnDailyFuturesPosition;
        private System.Windows.Forms.ComboBox cboDailyAccount;
        private System.Windows.Forms.ComboBox cboDailyCompany;
        private System.Windows.Forms.Label lblcboDailyAccount;
        private System.Windows.Forms.Label lblcboDailyCompany;
        private System.Windows.Forms.GroupBox grpPostionsGrouped;
        private System.Windows.Forms.Button btnFuturesPositionReport;
        private System.Windows.Forms.ComboBox cboFuturesPositionGrouped;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpCHConfirm;
        private System.Windows.Forms.DateTimePicker dtDateTimeCH;
        private System.Windows.Forms.Button btnRunCHReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkLiveReport;
        private System.Windows.Forms.GroupBox grpOptionParamters;
        private System.Windows.Forms.CheckBox chkSelectAllAccount;
        private System.Windows.Forms.CheckBox chkAllDate;
        private System.Windows.Forms.DateTimePicker dtExpiration;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Label lblExpiration;
        private System.Windows.Forms.Label label141;
        private AutoCompleteComboBox cboHedgebookAccount;
        private System.Windows.Forms.CheckBox chkSelectTradeDate;
        private System.Windows.Forms.DateTimePicker dtTradeDate;
        private System.Windows.Forms.Label lblTradeDate;
        private System.Windows.Forms.GroupBox grpRunOnly;
        private System.Windows.Forms.Button btnMarginCall;
        private System.Windows.Forms.GroupBox grpMonthlySettlement;
        private System.Windows.Forms.DateTimePicker dtSettleEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMonthlySettlement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMonAccSettle;
        private System.Windows.Forms.ComboBox cboMonCoSettle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtSettleStart;
        private System.Windows.Forms.GroupBox grpDailySettlement;
        private System.Windows.Forms.ComboBox cboDailyAcct;
        private System.Windows.Forms.ComboBox cboDailyComp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtSettleDaily;
        private System.Windows.Forms.Button btnDailySettlement;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSetNetEquity;
        private System.Windows.Forms.Button btnFuturesConfirmationEmail;
    }
}