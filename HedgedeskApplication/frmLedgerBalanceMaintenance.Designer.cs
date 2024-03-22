namespace HedgedeskApplication
{
    partial class frmLedgerBalanceMaintenance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbLedgerBalance = new System.Windows.Forms.TabControl();
            this.tbpLedgerBalanceAdjustments = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.dtpAddAdjustmentDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAdjustment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAddAcct = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFindOrders = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAcct = new System.Windows.Forms.ComboBox();
            this.Print = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbpLedgerBalanceMaintenance = new System.Windows.Forms.TabPage();
            this.btnPrintMaintenance = new System.Windows.Forms.Button();
            this.btnMaintClose = new System.Windows.Forms.Button();
            this.tbpLedgerBalanceDetailMaintenance = new System.Windows.Forms.TabPage();
            this.btnPrintDetail = new System.Windows.Forms.Button();
            this.btnDetailClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLedgerBalance = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cboMaintAcct = new System.Windows.Forms.ComboBox();
            this.btnMaintAdd = new System.Windows.Forms.Button();
            this.btnMaintDelete = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtBegOpenEquityforMonth = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cboDetailAccount = new System.Windows.Forms.ComboBox();
            this.btnDetailAdd = new System.Windows.Forms.Button();
            this.btnDetailDelete = new System.Windows.Forms.Button();
            this.txtCommodity = new System.Windows.Forms.Label();
            this.cboDetailComm = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBrokerComms = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMarginBalance = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtOpenEquity = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNetPrevEquity = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtMarginPrev = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtNetEqPrevYear = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.chkRevStl = new System.Windows.Forms.CheckBox();
            this.txtSortOrder = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cboAddComp = new AutoCompleteComboBox();
            this.dgvLedgerBalance = new dgvCustom();
            this.MarginID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chkDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TradingCompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboComp = new AutoCompleteComboBox();
            this.cboMaintComp = new AutoCompleteComboBox();
            this.dgvLedgerMaintenance = new dgvCustom();
            this.LedgerBalanceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintLedgerBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrokerCommissions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintMarginBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintOpenEquity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetPrevEquity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarginPrev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReverseSettlement = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NetPrevEquityYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MaintchkDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboDetailComp = new AutoCompleteComboBox();
            this.dgvLedgerDetail = new dgvCustom();
            this.LedgerBalanceDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailCommodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailOpenEquity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DetailchkDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMaintShow = new System.Windows.Forms.Button();
            this.btnDetailShow = new System.Windows.Forms.Button();
            this.tbLedgerBalance.SuspendLayout();
            this.tbpLedgerBalanceAdjustments.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbpLedgerBalanceMaintenance.SuspendLayout();
            this.tbpLedgerBalanceDetailMaintenance.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerMaintenance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tbLedgerBalance
            // 
            this.tbLedgerBalance.Controls.Add(this.tbpLedgerBalanceAdjustments);
            this.tbLedgerBalance.Controls.Add(this.tbpLedgerBalanceMaintenance);
            this.tbLedgerBalance.Controls.Add(this.tbpLedgerBalanceDetailMaintenance);
            this.tbLedgerBalance.Location = new System.Drawing.Point(4, 3);
            this.tbLedgerBalance.Name = "tbLedgerBalance";
            this.tbLedgerBalance.SelectedIndex = 0;
            this.tbLedgerBalance.Size = new System.Drawing.Size(1037, 647);
            this.tbLedgerBalance.TabIndex = 0;
            // 
            // tbpLedgerBalanceAdjustments
            // 
            this.tbpLedgerBalanceAdjustments.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.label11);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.label12);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.dtpTo);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.dtpFrom);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.label9);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.label2);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.groupBox1);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.btnFindOrders);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.btnDeleteSelected);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.dgvLedgerBalance);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.label1);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.cboAcct);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.cboComp);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.Print);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.btnShowAll);
            this.tbpLedgerBalanceAdjustments.Controls.Add(this.btnClose);
            this.tbpLedgerBalanceAdjustments.Location = new System.Drawing.Point(4, 22);
            this.tbpLedgerBalanceAdjustments.Name = "tbpLedgerBalanceAdjustments";
            this.tbpLedgerBalanceAdjustments.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLedgerBalanceAdjustments.Size = new System.Drawing.Size(1029, 621);
            this.tbpLedgerBalanceAdjustments.TabIndex = 0;
            this.tbpLedgerBalanceAdjustments.Text = "Ledger Balance Adjustments";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(326, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 106;
            this.label11.Text = "From:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(336, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 105;
            this.label12.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(360, 58);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(98, 20);
            this.dtpTo.TabIndex = 97;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(360, 28);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(98, 20);
            this.dtpFrom.TabIndex = 96;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(364, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 104;
            this.label9.Text = "Adjustment Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Account:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtComments);
            this.groupBox1.Controls.Add(this.dtpAddAdjustmentDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAdjustment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboAddComp);
            this.groupBox1.Controls.Add(this.cboAddAcct);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(2, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 68);
            this.groupBox1.TabIndex = 107;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Record";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(456, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 94;
            this.label7.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtComments.Location = new System.Drawing.Point(456, 39);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(498, 20);
            this.txtComments.TabIndex = 10;
            // 
            // dtpAddAdjustmentDate
            // 
            this.dtpAddAdjustmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAddAdjustmentDate.Location = new System.Drawing.Point(250, 39);
            this.dtpAddAdjustmentDate.Name = "dtpAddAdjustmentDate";
            this.dtpAddAdjustmentDate.Size = new System.Drawing.Size(98, 20);
            this.dtpAddAdjustmentDate.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "Adjustment Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "Adjustment Amount";
            // 
            // txtAdjustment
            // 
            this.txtAdjustment.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtAdjustment.Location = new System.Drawing.Point(355, 39);
            this.txtAdjustment.Name = "txtAdjustment";
            this.txtAdjustment.Size = new System.Drawing.Size(95, 20);
            this.txtAdjustment.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Account";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "Company";
            // 
            // cboAddAcct
            // 
            this.cboAddAcct.FormattingEnabled = true;
            this.cboAddAcct.Location = new System.Drawing.Point(131, 39);
            this.cboAddAcct.Name = "cboAddAcct";
            this.cboAddAcct.Size = new System.Drawing.Size(113, 21);
            this.cboAddAcct.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(960, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 27);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFindOrders
            // 
            this.btnFindOrders.Location = new System.Drawing.Point(6, 8);
            this.btnFindOrders.Name = "btnFindOrders";
            this.btnFindOrders.Size = new System.Drawing.Size(85, 27);
            this.btnFindOrders.TabIndex = 93;
            this.btnFindOrders.Text = "Filter Records";
            this.btnFindOrders.UseVisualStyleBackColor = true;
            this.btnFindOrders.Click += new System.EventHandler(this.btnFindOrders_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(6, 66);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(85, 27);
            this.btnDeleteSelected.TabIndex = 99;
            this.btnDeleteSelected.Text = "Delete";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Company:";
            // 
            // cboAcct
            // 
            this.cboAcct.FormattingEnabled = true;
            this.cboAcct.Location = new System.Drawing.Point(185, 58);
            this.cboAcct.Name = "cboAcct";
            this.cboAcct.Size = new System.Drawing.Size(95, 21);
            this.cboAcct.TabIndex = 95;
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(935, 8);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(85, 27);
            this.Print.TabIndex = 100;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(6, 37);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(85, 27);
            this.btnShowAll.TabIndex = 101;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(935, 37);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 27);
            this.btnClose.TabIndex = 92;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbpLedgerBalanceMaintenance
            // 
            this.tbpLedgerBalanceMaintenance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbpLedgerBalanceMaintenance.Controls.Add(this.btnMaintShow);
            this.tbpLedgerBalanceMaintenance.Controls.Add(this.groupBox2);
            this.tbpLedgerBalanceMaintenance.Controls.Add(this.btnMaintDelete);
            this.tbpLedgerBalanceMaintenance.Controls.Add(this.btnPrintMaintenance);
            this.tbpLedgerBalanceMaintenance.Controls.Add(this.btnMaintClose);
            this.tbpLedgerBalanceMaintenance.Controls.Add(this.dgvLedgerMaintenance);
            this.tbpLedgerBalanceMaintenance.Location = new System.Drawing.Point(4, 22);
            this.tbpLedgerBalanceMaintenance.Name = "tbpLedgerBalanceMaintenance";
            this.tbpLedgerBalanceMaintenance.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLedgerBalanceMaintenance.Size = new System.Drawing.Size(1029, 621);
            this.tbpLedgerBalanceMaintenance.TabIndex = 1;
            this.tbpLedgerBalanceMaintenance.Text = "Ledger Balance Maintenance";
            // 
            // btnPrintMaintenance
            // 
            this.btnPrintMaintenance.Location = new System.Drawing.Point(935, 6);
            this.btnPrintMaintenance.Name = "btnPrintMaintenance";
            this.btnPrintMaintenance.Size = new System.Drawing.Size(85, 27);
            this.btnPrintMaintenance.TabIndex = 102;
            this.btnPrintMaintenance.Text = "Print";
            this.btnPrintMaintenance.UseVisualStyleBackColor = true;
            // 
            // btnMaintClose
            // 
            this.btnMaintClose.Location = new System.Drawing.Point(935, 35);
            this.btnMaintClose.Name = "btnMaintClose";
            this.btnMaintClose.Size = new System.Drawing.Size(85, 27);
            this.btnMaintClose.TabIndex = 101;
            this.btnMaintClose.Text = "Close";
            this.btnMaintClose.UseVisualStyleBackColor = true;
            // 
            // tbpLedgerBalanceDetailMaintenance
            // 
            this.tbpLedgerBalanceDetailMaintenance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbpLedgerBalanceDetailMaintenance.Controls.Add(this.btnDetailShow);
            this.tbpLedgerBalanceDetailMaintenance.Controls.Add(this.groupBox3);
            this.tbpLedgerBalanceDetailMaintenance.Controls.Add(this.btnDetailDelete);
            this.tbpLedgerBalanceDetailMaintenance.Controls.Add(this.btnPrintDetail);
            this.tbpLedgerBalanceDetailMaintenance.Controls.Add(this.btnDetailClose);
            this.tbpLedgerBalanceDetailMaintenance.Controls.Add(this.dgvLedgerDetail);
            this.tbpLedgerBalanceDetailMaintenance.Location = new System.Drawing.Point(4, 22);
            this.tbpLedgerBalanceDetailMaintenance.Name = "tbpLedgerBalanceDetailMaintenance";
            this.tbpLedgerBalanceDetailMaintenance.Size = new System.Drawing.Size(1029, 621);
            this.tbpLedgerBalanceDetailMaintenance.TabIndex = 2;
            this.tbpLedgerBalanceDetailMaintenance.Text = "Ledger Balance Detail Maintenance";
            // 
            // btnPrintDetail
            // 
            this.btnPrintDetail.Location = new System.Drawing.Point(941, 9);
            this.btnPrintDetail.Name = "btnPrintDetail";
            this.btnPrintDetail.Size = new System.Drawing.Size(85, 27);
            this.btnPrintDetail.TabIndex = 103;
            this.btnPrintDetail.Text = "Print";
            this.btnPrintDetail.UseVisualStyleBackColor = true;
            // 
            // btnDetailClose
            // 
            this.btnDetailClose.Location = new System.Drawing.Point(941, 38);
            this.btnDetailClose.Name = "btnDetailClose";
            this.btnDetailClose.Size = new System.Drawing.Size(85, 27);
            this.btnDetailClose.TabIndex = 101;
            this.btnDetailClose.Text = "Close";
            this.btnDetailClose.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.chkRevStl);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.txtNetEqPrevYear);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.txtMarginPrev);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txtNetPrevEquity);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtOpenEquity);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtMarginBalance);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtFees);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtBrokerComms);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtLedgerBalance);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cboMaintComp);
            this.groupBox2.Controls.Add(this.cboMaintAcct);
            this.groupBox2.Controls.Add(this.btnMaintAdd);
            this.groupBox2.Location = new System.Drawing.Point(4, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1022, 68);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Record";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(161, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 89;
            this.label13.Text = "Beg Ledger Bal";
            // 
            // txtLedgerBalance
            // 
            this.txtLedgerBalance.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtLedgerBalance.Location = new System.Drawing.Point(161, 39);
            this.txtLedgerBalance.Name = "txtLedgerBalance";
            this.txtLedgerBalance.Size = new System.Drawing.Size(100, 20);
            this.txtLedgerBalance.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(89, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 88;
            this.label14.Text = "Account";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 87;
            this.label15.Text = "Company";
            // 
            // cboMaintAcct
            // 
            this.cboMaintAcct.FormattingEnabled = true;
            this.cboMaintAcct.Location = new System.Drawing.Point(86, 39);
            this.cboMaintAcct.Name = "cboMaintAcct";
            this.cboMaintAcct.Size = new System.Drawing.Size(69, 21);
            this.cboMaintAcct.TabIndex = 7;
            // 
            // btnMaintAdd
            // 
            this.btnMaintAdd.Location = new System.Drawing.Point(958, 36);
            this.btnMaintAdd.Name = "btnMaintAdd";
            this.btnMaintAdd.Size = new System.Drawing.Size(58, 27);
            this.btnMaintAdd.TabIndex = 17;
            this.btnMaintAdd.Text = "Add";
            this.btnMaintAdd.UseVisualStyleBackColor = true;
            this.btnMaintAdd.Click += new System.EventHandler(this.btnMaintAdd_Click);
            // 
            // btnMaintDelete
            // 
            this.btnMaintDelete.Location = new System.Drawing.Point(8, 36);
            this.btnMaintDelete.Name = "btnMaintDelete";
            this.btnMaintDelete.Size = new System.Drawing.Size(85, 27);
            this.btnMaintDelete.TabIndex = 109;
            this.btnMaintDelete.Text = "Delete";
            this.btnMaintDelete.UseVisualStyleBackColor = true;
            this.btnMaintDelete.Click += new System.EventHandler(this.btnMaintDelete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.txtSortOrder);
            this.groupBox3.Controls.Add(this.txtCommodity);
            this.groupBox3.Controls.Add(this.cboDetailComm);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtBegOpenEquityforMonth);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.cboDetailComp);
            this.groupBox3.Controls.Add(this.cboDetailAccount);
            this.groupBox3.Controls.Add(this.btnDetailAdd);
            this.groupBox3.Location = new System.Drawing.Point(4, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1022, 68);
            this.groupBox3.TabIndex = 113;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add Record";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(369, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(163, 13);
            this.label18.TabIndex = 89;
            this.label18.Text = "Beginning Open Equity for Month";
            // 
            // txtBegOpenEquityforMonth
            // 
            this.txtBegOpenEquityforMonth.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtBegOpenEquityforMonth.Location = new System.Drawing.Point(369, 39);
            this.txtBegOpenEquityforMonth.Name = "txtBegOpenEquityforMonth";
            this.txtBegOpenEquityforMonth.Size = new System.Drawing.Size(205, 20);
            this.txtBegOpenEquityforMonth.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(132, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 88;
            this.label19.Text = "Account";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 13);
            this.label20.TabIndex = 87;
            this.label20.Text = "Company";
            // 
            // cboDetailAccount
            // 
            this.cboDetailAccount.FormattingEnabled = true;
            this.cboDetailAccount.Location = new System.Drawing.Point(131, 39);
            this.cboDetailAccount.Name = "cboDetailAccount";
            this.cboDetailAccount.Size = new System.Drawing.Size(113, 21);
            this.cboDetailAccount.TabIndex = 7;
            // 
            // btnDetailAdd
            // 
            this.btnDetailAdd.Location = new System.Drawing.Point(958, 35);
            this.btnDetailAdd.Name = "btnDetailAdd";
            this.btnDetailAdd.Size = new System.Drawing.Size(58, 27);
            this.btnDetailAdd.TabIndex = 10;
            this.btnDetailAdd.Text = "Add";
            this.btnDetailAdd.UseVisualStyleBackColor = true;
            this.btnDetailAdd.Click += new System.EventHandler(this.btnDetailAdd_Click);
            // 
            // btnDetailDelete
            // 
            this.btnDetailDelete.Location = new System.Drawing.Point(8, 36);
            this.btnDetailDelete.Name = "btnDetailDelete";
            this.btnDetailDelete.Size = new System.Drawing.Size(85, 27);
            this.btnDetailDelete.TabIndex = 112;
            this.btnDetailDelete.Text = "Delete";
            this.btnDetailDelete.UseVisualStyleBackColor = true;
            this.btnDetailDelete.Click += new System.EventHandler(this.btnDetailDelete_Click);
            // 
            // txtCommodity
            // 
            this.txtCommodity.AutoSize = true;
            this.txtCommodity.Location = new System.Drawing.Point(251, 23);
            this.txtCommodity.Name = "txtCommodity";
            this.txtCommodity.Size = new System.Drawing.Size(58, 13);
            this.txtCommodity.TabIndex = 96;
            this.txtCommodity.Text = "Commodity";
            // 
            // cboDetailComm
            // 
            this.cboDetailComm.FormattingEnabled = true;
            this.cboDetailComm.Location = new System.Drawing.Point(250, 39);
            this.cboDetailComm.Name = "cboDetailComm";
            this.cboDetailComm.Size = new System.Drawing.Size(113, 21);
            this.cboDetailComm.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(267, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 96;
            this.label10.Text = "Broker Comms";
            // 
            // txtBrokerComms
            // 
            this.txtBrokerComms.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtBrokerComms.Location = new System.Drawing.Point(267, 39);
            this.txtBrokerComms.Name = "txtBrokerComms";
            this.txtBrokerComms.Size = new System.Drawing.Size(80, 20);
            this.txtBrokerComms.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(353, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 98;
            this.label16.Text = "Fees";
            // 
            // txtFees
            // 
            this.txtFees.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtFees.Location = new System.Drawing.Point(353, 39);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(70, 20);
            this.txtFees.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(430, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 100;
            this.label8.Text = "Margin Balance";
            // 
            // txtMarginBalance
            // 
            this.txtMarginBalance.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtMarginBalance.Location = new System.Drawing.Point(430, 39);
            this.txtMarginBalance.Name = "txtMarginBalance";
            this.txtMarginBalance.Size = new System.Drawing.Size(80, 20);
            this.txtMarginBalance.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(516, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 13);
            this.label17.TabIndex = 102;
            this.label17.Text = "Open Equity";
            // 
            // txtOpenEquity
            // 
            this.txtOpenEquity.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtOpenEquity.Location = new System.Drawing.Point(516, 39);
            this.txtOpenEquity.Name = "txtOpenEquity";
            this.txtOpenEquity.Size = new System.Drawing.Size(104, 20);
            this.txtOpenEquity.TabIndex = 12;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(626, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(81, 13);
            this.label21.TabIndex = 104;
            this.label21.Text = "Net Equity Prev";
            // 
            // txtNetPrevEquity
            // 
            this.txtNetPrevEquity.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtNetPrevEquity.Location = new System.Drawing.Point(626, 39);
            this.txtNetPrevEquity.Name = "txtNetPrevEquity";
            this.txtNetPrevEquity.Size = new System.Drawing.Size(100, 20);
            this.txtNetPrevEquity.TabIndex = 13;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(732, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 13);
            this.label22.TabIndex = 106;
            this.label22.Text = "Margin Previous";
            // 
            // txtMarginPrev
            // 
            this.txtMarginPrev.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtMarginPrev.Location = new System.Drawing.Point(732, 39);
            this.txtMarginPrev.Name = "txtMarginPrev";
            this.txtMarginPrev.Size = new System.Drawing.Size(80, 20);
            this.txtMarginPrev.TabIndex = 14;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(818, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 13);
            this.label23.TabIndex = 112;
            this.label23.Text = "Net Eq Prev Year";
            // 
            // txtNetEqPrevYear
            // 
            this.txtNetEqPrevYear.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtNetEqPrevYear.Location = new System.Drawing.Point(818, 39);
            this.txtNetEqPrevYear.Name = "txtNetEqPrevYear";
            this.txtNetEqPrevYear.Size = new System.Drawing.Size(90, 20);
            this.txtNetEqPrevYear.TabIndex = 15;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(916, 23);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 13);
            this.label24.TabIndex = 114;
            this.label24.Text = "Rev Stl";
            // 
            // chkRevStl
            // 
            this.chkRevStl.AutoSize = true;
            this.chkRevStl.BackColor = System.Drawing.Color.Transparent;
            this.chkRevStl.Location = new System.Drawing.Point(932, 42);
            this.chkRevStl.Name = "chkRevStl";
            this.chkRevStl.Size = new System.Drawing.Size(15, 14);
            this.chkRevStl.TabIndex = 16;
            this.chkRevStl.UseVisualStyleBackColor = false;
            // 
            // txtSortOrder
            // 
            this.txtSortOrder.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtSortOrder.Location = new System.Drawing.Point(580, 39);
            this.txtSortOrder.Name = "txtSortOrder";
            this.txtSortOrder.Size = new System.Drawing.Size(82, 20);
            this.txtSortOrder.TabIndex = 97;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(580, 23);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(55, 13);
            this.label25.TabIndex = 98;
            this.label25.Text = "Sort Order";
            // 
            // cboAddComp
            // 
            this.cboAddComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboAddComp.FormattingEnabled = true;
            this.cboAddComp.Location = new System.Drawing.Point(6, 39);
            this.cboAddComp.Name = "cboAddComp";
            this.cboAddComp.Size = new System.Drawing.Size(119, 21);
            this.cboAddComp.Strict = true;
            this.cboAddComp.TabIndex = 6;
            // 
            // dgvLedgerBalance
            // 
            this.dgvLedgerBalance.AllowUserToAddRows = false;
            this.dgvLedgerBalance.AllowUserToDeleteRows = false;
            this.dgvLedgerBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLedgerBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MarginID,
            this.Company,
            this.Account,
            this.MarginDate,
            this.MarginBal,
            this.Comments,
            this.Delete,
            this.chkDelete,
            this.TradingCompanyID,
            this.AccountID});
            this.dgvLedgerBalance.Location = new System.Drawing.Point(6, 175);
            this.dgvLedgerBalance.Name = "dgvLedgerBalance";
            this.dgvLedgerBalance.RowHeadersVisible = false;
            this.dgvLedgerBalance.Size = new System.Drawing.Size(1020, 440);
            this.dgvLedgerBalance.TabIndex = 98;
            this.dgvLedgerBalance.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLedgerBalance_CellBeginEdit);
            this.dgvLedgerBalance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedgerBalance_CellContentClick);
            this.dgvLedgerBalance.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedgerBalance_CellEndEdit);
            this.dgvLedgerBalance.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedgerBalance_CellLeave);
            this.dgvLedgerBalance.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvLedgerBalance_CellValidating);
            this.dgvLedgerBalance.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLedgerBalance_RowValidating);
            this.dgvLedgerBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLedgerBalance_KeyDown);
            // 
            // MarginID
            // 
            this.MarginID.DataPropertyName = "LedgerBalanceAdjustmentID";
            this.MarginID.HeaderText = "ID";
            this.MarginID.Name = "MarginID";
            this.MarginID.ReadOnly = true;
            this.MarginID.Width = 60;
            // 
            // Company
            // 
            this.Company.DataPropertyName = "CompanyDesc";
            this.Company.HeaderText = "Company";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            this.Company.Width = 115;
            // 
            // Account
            // 
            this.Account.DataPropertyName = "AccountDesc";
            this.Account.HeaderText = "Account";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            this.Account.Width = 115;
            // 
            // MarginDate
            // 
            this.MarginDate.DataPropertyName = "AdjustmentDate";
            this.MarginDate.HeaderText = "Adjustment Date";
            this.MarginDate.Name = "MarginDate";
            this.MarginDate.Width = 110;
            // 
            // MarginBal
            // 
            this.MarginBal.DataPropertyName = "AdjustmentAmount";
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.MarginBal.DefaultCellStyle = dataGridViewCellStyle11;
            this.MarginBal.HeaderText = "Adjustment Amount";
            this.MarginBal.Name = "MarginBal";
            this.MarginBal.Width = 125;
            // 
            // Comments
            // 
            this.Comments.DataPropertyName = "Comments";
            this.Comments.HeaderText = "Comments";
            this.Comments.Name = "Comments";
            this.Comments.Width = 400;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 50;
            // 
            // chkDelete
            // 
            this.chkDelete.HeaderText = "";
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Width = 25;
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
            // cboComp
            // 
            this.cboComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboComp.FormattingEnabled = true;
            this.cboComp.Location = new System.Drawing.Point(185, 28);
            this.cboComp.Name = "cboComp";
            this.cboComp.Size = new System.Drawing.Size(95, 21);
            this.cboComp.Strict = true;
            this.cboComp.TabIndex = 94;
            // 
            // cboMaintComp
            // 
            this.cboMaintComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboMaintComp.FormattingEnabled = true;
            this.cboMaintComp.Location = new System.Drawing.Point(6, 39);
            this.cboMaintComp.Name = "cboMaintComp";
            this.cboMaintComp.Size = new System.Drawing.Size(74, 21);
            this.cboMaintComp.Strict = true;
            this.cboMaintComp.TabIndex = 6;
            // 
            // dgvLedgerMaintenance
            // 
            this.dgvLedgerMaintenance.AllowUserToAddRows = false;
            this.dgvLedgerMaintenance.AllowUserToDeleteRows = false;
            this.dgvLedgerMaintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLedgerMaintenance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LedgerBalanceID,
            this.MaintCompany,
            this.MaintAccount,
            this.MaintLedgerBal,
            this.BrokerCommissions,
            this.Fees,
            this.MaintMarginBal,
            this.MaintOpenEquity,
            this.NetPrevEquity,
            this.MarginPrev,
            this.ReverseSettlement,
            this.NetPrevEquityYear,
            this.MaintDelete,
            this.MaintchkDelete,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn15});
            this.dgvLedgerMaintenance.Location = new System.Drawing.Point(8, 145);
            this.dgvLedgerMaintenance.Name = "dgvLedgerMaintenance";
            this.dgvLedgerMaintenance.RowHeadersVisible = false;
            this.dgvLedgerMaintenance.Size = new System.Drawing.Size(1018, 440);
            this.dgvLedgerMaintenance.TabIndex = 108;
            this.dgvLedgerMaintenance.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLedgerMaintenance_CellBeginEdit);
            this.dgvLedgerMaintenance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedgerMaintenance_CellContentClick);
            this.dgvLedgerMaintenance.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedgerMaintenance_CellEndEdit);
            this.dgvLedgerMaintenance.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedgerMaintenance_CellLeave);
            this.dgvLedgerMaintenance.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvLedgerMaintenance_CellValidating);
            this.dgvLedgerMaintenance.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLedgerMaintenance_RowValidating);
            this.dgvLedgerMaintenance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLedgerMaintenance_KeyDown);
            // 
            // LedgerBalanceID
            // 
            this.LedgerBalanceID.DataPropertyName = "LedgerBalanceID";
            this.LedgerBalanceID.HeaderText = "ID";
            this.LedgerBalanceID.Name = "LedgerBalanceID";
            this.LedgerBalanceID.ReadOnly = true;
            this.LedgerBalanceID.Width = 50;
            // 
            // MaintCompany
            // 
            this.MaintCompany.DataPropertyName = "CompanyDesc";
            this.MaintCompany.HeaderText = "Company";
            this.MaintCompany.Name = "MaintCompany";
            this.MaintCompany.ReadOnly = true;
            this.MaintCompany.Width = 85;
            // 
            // MaintAccount
            // 
            this.MaintAccount.DataPropertyName = "AccountDesc";
            this.MaintAccount.HeaderText = "Account";
            this.MaintAccount.Name = "MaintAccount";
            this.MaintAccount.ReadOnly = true;
            this.MaintAccount.Width = 80;
            // 
            // MaintLedgerBal
            // 
            this.MaintLedgerBal.DataPropertyName = "LedgerBalance";
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.MaintLedgerBal.DefaultCellStyle = dataGridViewCellStyle12;
            this.MaintLedgerBal.HeaderText = "Beginning Ledger Bal";
            this.MaintLedgerBal.Name = "MaintLedgerBal";
            // 
            // BrokerCommissions
            // 
            this.BrokerCommissions.DataPropertyName = "BrokerCommissions";
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.BrokerCommissions.DefaultCellStyle = dataGridViewCellStyle13;
            this.BrokerCommissions.HeaderText = "Broker Commissions";
            this.BrokerCommissions.Name = "BrokerCommissions";
            this.BrokerCommissions.Width = 75;
            // 
            // Fees
            // 
            this.Fees.DataPropertyName = "Fees";
            dataGridViewCellStyle14.Format = "N2";
            this.Fees.DefaultCellStyle = dataGridViewCellStyle14;
            this.Fees.HeaderText = "Fees";
            this.Fees.Name = "Fees";
            this.Fees.Width = 50;
            // 
            // MaintMarginBal
            // 
            this.MaintMarginBal.DataPropertyName = "MarginBalance";
            dataGridViewCellStyle15.Format = "N2";
            this.MaintMarginBal.DefaultCellStyle = dataGridViewCellStyle15;
            this.MaintMarginBal.HeaderText = "Margin Bal";
            this.MaintMarginBal.Name = "MaintMarginBal";
            // 
            // MaintOpenEquity
            // 
            this.MaintOpenEquity.DataPropertyName = "OpenEquity";
            dataGridViewCellStyle16.Format = "N2";
            this.MaintOpenEquity.DefaultCellStyle = dataGridViewCellStyle16;
            this.MaintOpenEquity.HeaderText = "Open Equity";
            this.MaintOpenEquity.Name = "MaintOpenEquity";
            // 
            // NetPrevEquity
            // 
            this.NetPrevEquity.DataPropertyName = "NetEquityPrevious";
            dataGridViewCellStyle17.Format = "N2";
            this.NetPrevEquity.DefaultCellStyle = dataGridViewCellStyle17;
            this.NetPrevEquity.HeaderText = "Net Prev Equity";
            this.NetPrevEquity.Name = "NetPrevEquity";
            // 
            // MarginPrev
            // 
            this.MarginPrev.DataPropertyName = "MarginPrevious";
            dataGridViewCellStyle18.Format = "N2";
            this.MarginPrev.DefaultCellStyle = dataGridViewCellStyle18;
            this.MarginPrev.HeaderText = "Margin Prev";
            this.MarginPrev.Name = "MarginPrev";
            this.MarginPrev.Width = 65;
            // 
            // ReverseSettlement
            // 
            this.ReverseSettlement.DataPropertyName = "Reverse_Settlement";
            this.ReverseSettlement.HeaderText = "Rev Stl";
            this.ReverseSettlement.Name = "ReverseSettlement";
            this.ReverseSettlement.Width = 40;
            // 
            // NetPrevEquityYear
            // 
            this.NetPrevEquityYear.DataPropertyName = "NetEquityPreviousYear";
            dataGridViewCellStyle19.Format = "N2";
            this.NetPrevEquityYear.DefaultCellStyle = dataGridViewCellStyle19;
            this.NetPrevEquityYear.HeaderText = "Net Equity Prev Year";
            this.NetPrevEquityYear.Name = "NetPrevEquityYear";
            // 
            // MaintDelete
            // 
            this.MaintDelete.HeaderText = "Delete";
            this.MaintDelete.Name = "MaintDelete";
            this.MaintDelete.Text = "Del";
            this.MaintDelete.UseColumnTextForButtonValue = true;
            this.MaintDelete.Width = 30;
            // 
            // MaintchkDelete
            // 
            this.MaintchkDelete.HeaderText = "";
            this.MaintchkDelete.Name = "MaintchkDelete";
            this.MaintchkDelete.Width = 25;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Company";
            this.dataGridViewTextBoxColumn7.HeaderText = "TradingCompanyID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Account";
            this.dataGridViewTextBoxColumn15.HeaderText = "AccountID";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Visible = false;
            this.dataGridViewTextBoxColumn15.Width = 125;
            // 
            // cboDetailComp
            // 
            this.cboDetailComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboDetailComp.FormattingEnabled = true;
            this.cboDetailComp.Location = new System.Drawing.Point(6, 39);
            this.cboDetailComp.Name = "cboDetailComp";
            this.cboDetailComp.Size = new System.Drawing.Size(119, 21);
            this.cboDetailComp.Strict = true;
            this.cboDetailComp.TabIndex = 6;
            // 
            // dgvLedgerDetail
            // 
            this.dgvLedgerDetail.AllowUserToAddRows = false;
            this.dgvLedgerDetail.AllowUserToDeleteRows = false;
            this.dgvLedgerDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLedgerDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LedgerBalanceDetailID,
            this.DetailCompany,
            this.DetailAccount,
            this.DetailCommodity,
            this.DetailOpenEquity,
            this.SortOrder,
            this.DetailDelete,
            this.DetailchkDelete,
            this.dataGridViewTextBoxColumn14});
            this.dgvLedgerDetail.Location = new System.Drawing.Point(8, 145);
            this.dgvLedgerDetail.Name = "dgvLedgerDetail";
            this.dgvLedgerDetail.RowHeadersVisible = false;
            this.dgvLedgerDetail.Size = new System.Drawing.Size(1018, 473);
            this.dgvLedgerDetail.TabIndex = 111;
            this.dgvLedgerDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLedgerDetail_CellBeginEdit);
            this.dgvLedgerDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedgerDetail_CellContentClick);
            this.dgvLedgerDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedgerDetail_CellEndEdit);
            this.dgvLedgerDetail.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLedgerDetail_CellLeave);
            this.dgvLedgerDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvLedgerDetail_CellValidating);
            this.dgvLedgerDetail.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLedgerDetail_RowValidating);
            this.dgvLedgerDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLedgerDetail_KeyDown);
            // 
            // LedgerBalanceDetailID
            // 
            this.LedgerBalanceDetailID.DataPropertyName = "LedgerBalanceDetailID";
            this.LedgerBalanceDetailID.HeaderText = "ID";
            this.LedgerBalanceDetailID.Name = "LedgerBalanceDetailID";
            this.LedgerBalanceDetailID.ReadOnly = true;
            this.LedgerBalanceDetailID.Width = 50;
            // 
            // DetailCompany
            // 
            this.DetailCompany.DataPropertyName = "CompanyDesc";
            this.DetailCompany.HeaderText = "Company";
            this.DetailCompany.Name = "DetailCompany";
            this.DetailCompany.ReadOnly = true;
            // 
            // DetailAccount
            // 
            this.DetailAccount.DataPropertyName = "AccountDesc";
            this.DetailAccount.HeaderText = "Account";
            this.DetailAccount.Name = "DetailAccount";
            this.DetailAccount.ReadOnly = true;
            this.DetailAccount.Width = 115;
            // 
            // DetailCommodity
            // 
            this.DetailCommodity.DataPropertyName = "Commodity";
            this.DetailCommodity.HeaderText = "Commodity";
            this.DetailCommodity.Name = "DetailCommodity";
            this.DetailCommodity.Width = 110;
            // 
            // DetailOpenEquity
            // 
            this.DetailOpenEquity.DataPropertyName = "OpenEquity";
            dataGridViewCellStyle20.Format = "N2";
            dataGridViewCellStyle20.NullValue = null;
            this.DetailOpenEquity.DefaultCellStyle = dataGridViewCellStyle20;
            this.DetailOpenEquity.HeaderText = "Beginning Open Equity for Month";
            this.DetailOpenEquity.Name = "DetailOpenEquity";
            this.DetailOpenEquity.Width = 200;
            // 
            // SortOrder
            // 
            this.SortOrder.DataPropertyName = "SortOrder";
            this.SortOrder.HeaderText = "Sort Order";
            this.SortOrder.Name = "SortOrder";
            // 
            // DetailDelete
            // 
            this.DetailDelete.HeaderText = "Delete";
            this.DetailDelete.Name = "DetailDelete";
            this.DetailDelete.Text = "Delete";
            this.DetailDelete.UseColumnTextForButtonValue = true;
            this.DetailDelete.Width = 50;
            // 
            // DetailchkDelete
            // 
            this.DetailchkDelete.HeaderText = "";
            this.DetailchkDelete.Name = "DetailchkDelete";
            this.DetailchkDelete.Width = 25;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Company";
            this.dataGridViewTextBoxColumn14.HeaderText = "TradingCompanyID";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // btnMaintShow
            // 
            this.btnMaintShow.Location = new System.Drawing.Point(8, 6);
            this.btnMaintShow.Name = "btnMaintShow";
            this.btnMaintShow.Size = new System.Drawing.Size(85, 27);
            this.btnMaintShow.TabIndex = 111;
            this.btnMaintShow.Text = "Show All";
            this.btnMaintShow.UseVisualStyleBackColor = true;
            this.btnMaintShow.Click += new System.EventHandler(this.btnMaintShow_Click);
            // 
            // btnDetailShow
            // 
            this.btnDetailShow.Location = new System.Drawing.Point(8, 9);
            this.btnDetailShow.Name = "btnDetailShow";
            this.btnDetailShow.Size = new System.Drawing.Size(85, 27);
            this.btnDetailShow.TabIndex = 114;
            this.btnDetailShow.Text = "Show All";
            this.btnDetailShow.UseVisualStyleBackColor = true;
            this.btnDetailShow.Click += new System.EventHandler(this.btnDetailShow_Click);
            // 
            // frmLedgerBalanceMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 655);
            this.Controls.Add(this.tbLedgerBalance);
            this.Name = "frmLedgerBalanceMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ledger Balance Maintenance";
            this.Load += new System.EventHandler(this.frmLedgerBalanceMaintenance_Load);
            this.tbLedgerBalance.ResumeLayout(false);
            this.tbpLedgerBalanceAdjustments.ResumeLayout(false);
            this.tbpLedgerBalanceAdjustments.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbpLedgerBalanceMaintenance.ResumeLayout(false);
            this.tbpLedgerBalanceDetailMaintenance.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerMaintenance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbLedgerBalance;
        private System.Windows.Forms.TabPage tbpLedgerBalanceAdjustments;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.DateTimePicker dtpAddAdjustmentDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAdjustment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private AutoCompleteComboBox cboAddComp;
        private System.Windows.Forms.ComboBox cboAddAcct;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFindOrders;
        private System.Windows.Forms.Button btnDeleteSelected;
        private dgvCustom dgvLedgerBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAcct;
        private AutoCompleteComboBox cboComp;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tbpLedgerBalanceMaintenance;
        private System.Windows.Forms.Button btnPrintMaintenance;
        private System.Windows.Forms.Button btnMaintClose;
        private System.Windows.Forms.TabPage tbpLedgerBalanceDetailMaintenance;
        private System.Windows.Forms.Button btnPrintDetail;
        private System.Windows.Forms.Button btnDetailClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLedgerBalance;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private AutoCompleteComboBox cboMaintComp;
        private System.Windows.Forms.ComboBox cboMaintAcct;
        private System.Windows.Forms.Button btnMaintAdd;
        private System.Windows.Forms.Button btnMaintDelete;
        private dgvCustom dgvLedgerMaintenance;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label txtCommodity;
        private System.Windows.Forms.ComboBox cboDetailComm;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBegOpenEquityforMonth;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private AutoCompleteComboBox cboDetailComp;
        private System.Windows.Forms.ComboBox cboDetailAccount;
        private System.Windows.Forms.Button btnDetailAdd;
        private System.Windows.Forms.Button btnDetailDelete;
        private dgvCustom dgvLedgerDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradingCompanyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LedgerBalanceDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailCommodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailOpenEquity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortOrder;
        private System.Windows.Forms.DataGridViewButtonColumn DetailDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DetailchkDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtNetEqPrevYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtMarginPrev;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtNetPrevEquity;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtOpenEquity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMarginBalance;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBrokerComms;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.CheckBox chkRevStl;
        private System.Windows.Forms.DataGridViewTextBoxColumn LedgerBalanceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaintCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaintAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaintLedgerBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrokerCommissions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fees;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaintMarginBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaintOpenEquity;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetPrevEquity;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarginPrev;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ReverseSettlement;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetPrevEquityYear;
        private System.Windows.Forms.DataGridViewButtonColumn MaintDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MaintchkDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtSortOrder;
        private System.Windows.Forms.Button btnMaintShow;
        private System.Windows.Forms.Button btnDetailShow;

    }
}