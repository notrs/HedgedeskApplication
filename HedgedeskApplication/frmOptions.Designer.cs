using HedgedeskApplication.Classes;
namespace HedgedeskApplication
{
    partial class frmOptions
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnContractOptionDefaultSort = new System.Windows.Forms.Button();
            this.tbcContractOptions = new System.Windows.Forms.TabControl();
            this.tpWorkingOptions = new System.Windows.Forms.TabPage();
            this.tpNotWorkingOptions = new System.Windows.Forms.TabPage();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.btnRefreshAll_OptionsTab = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.btnOptionsExpireOrAssign = new System.Windows.Forms.Button();
            this.txtSettlePrice = new System.Windows.Forms.TextBox();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.tmrPending = new System.Windows.Forms.Timer(this.components);
            this.dtSettleDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.radDropDownButton1 = new Telerik.WinControls.UI.RadDropDownButton();
            this.rptOptionsOpenPosition = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.rptOptionsTradedToday = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.dgvContractOptions = new dgvCustom();
            this.dataGridViewTextBoxColumn60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merchandiser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractOptionBuySell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractOptionQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accepted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ContractOptionStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancelled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ExpireAssign = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Option = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Premium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExecutedPremium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptionsFuturesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FillPremium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldPremium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDateTime = new HedgedeskApplication.Classes.CalendarColumn();
            this.AssignmentDate = new HedgedeskApplication.Classes.CalendarDateColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractOptionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvContractOptionsNotWorking = new dgvCustom();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNoNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNumberNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchandiserNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractOptionNotWorkingBuySell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractOptionQuantityNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedQuantityNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcceptedNotWorking = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ContractOptionStatusNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CancelledNotWorking = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OptionNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpirationDateNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PremiumNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExecutedPremiumNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptionsFuturesPriceNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FillPremiumNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldPremiumNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDateTimeNotWorking = new HedgedeskApplication.Classes.CalendarColumn();
            this.AssignmentDateNotWorking = new HedgedeskApplication.Classes.CalendarDateColumn();
            this.dataGridViewTextBoxColumn67 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn68 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractTypeNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn72 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractOptionIDNotWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOptionConfirmation = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.tbcContractOptions.SuspendLayout();
            this.tpWorkingOptions.SuspendLayout();
            this.tpNotWorkingOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtSettleDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractOptionsNotWorking)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContractOptionDefaultSort
            // 
            this.btnContractOptionDefaultSort.Location = new System.Drawing.Point(1183, 32);
            this.btnContractOptionDefaultSort.Name = "btnContractOptionDefaultSort";
            this.btnContractOptionDefaultSort.Size = new System.Drawing.Size(78, 23);
            this.btnContractOptionDefaultSort.TabIndex = 130;
            this.btnContractOptionDefaultSort.TabStop = false;
            this.btnContractOptionDefaultSort.Text = "Clear Sorting";
            this.btnContractOptionDefaultSort.UseVisualStyleBackColor = true;
            this.btnContractOptionDefaultSort.Click += new System.EventHandler(this.btnContractOptionDefaultSort_Click);
            // 
            // tbcContractOptions
            // 
            this.tbcContractOptions.Controls.Add(this.tpWorkingOptions);
            this.tbcContractOptions.Controls.Add(this.tpNotWorkingOptions);
            this.tbcContractOptions.Location = new System.Drawing.Point(1, 40);
            this.tbcContractOptions.Name = "tbcContractOptions";
            this.tbcContractOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbcContractOptions.SelectedIndex = 0;
            this.tbcContractOptions.Size = new System.Drawing.Size(1278, 713);
            this.tbcContractOptions.TabIndex = 122;
            this.tbcContractOptions.SelectedIndexChanged += new System.EventHandler(this.tbcContractOptions_SelectedIndexChanged);
            // 
            // tpWorkingOptions
            // 
            this.tpWorkingOptions.Controls.Add(this.dgvContractOptions);
            this.tpWorkingOptions.Location = new System.Drawing.Point(4, 22);
            this.tpWorkingOptions.Name = "tpWorkingOptions";
            this.tpWorkingOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tpWorkingOptions.Size = new System.Drawing.Size(1270, 687);
            this.tpWorkingOptions.TabIndex = 0;
            this.tpWorkingOptions.Text = "Working";
            this.tpWorkingOptions.UseVisualStyleBackColor = true;
            // 
            // tpNotWorkingOptions
            // 
            this.tpNotWorkingOptions.Controls.Add(this.dgvContractOptionsNotWorking);
            this.tpNotWorkingOptions.Location = new System.Drawing.Point(4, 22);
            this.tpNotWorkingOptions.Name = "tpNotWorkingOptions";
            this.tpNotWorkingOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tpNotWorkingOptions.Size = new System.Drawing.Size(1270, 687);
            this.tpNotWorkingOptions.TabIndex = 1;
            this.tpNotWorkingOptions.Text = "Not Working";
            this.tpNotWorkingOptions.UseVisualStyleBackColor = true;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(629, 16);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(63, 13);
            this.label46.TabIndex = 129;
            this.label46.Text = "Settle Date:";
            this.label46.Visible = false;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(487, 16);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(64, 13);
            this.label45.TabIndex = 128;
            this.label45.Text = "Settle Price:";
            this.label45.Visible = false;
            // 
            // btnRefreshAll_OptionsTab
            // 
            this.btnRefreshAll_OptionsTab.Location = new System.Drawing.Point(1183, 8);
            this.btnRefreshAll_OptionsTab.Name = "btnRefreshAll_OptionsTab";
            this.btnRefreshAll_OptionsTab.Size = new System.Drawing.Size(78, 23);
            this.btnRefreshAll_OptionsTab.TabIndex = 123;
            this.btnRefreshAll_OptionsTab.TabStop = false;
            this.btnRefreshAll_OptionsTab.Text = "Refresh All";
            this.btnRefreshAll_OptionsTab.UseVisualStyleBackColor = true;
            this.btnRefreshAll_OptionsTab.Click += new System.EventHandler(this.btnRefreshAll_OptionsTab_Click);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(368, 15);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(44, 13);
            this.label44.TabIndex = 127;
            this.label44.Text = "Symbol:";
            this.label44.Visible = false;
            // 
            // btnOptionsExpireOrAssign
            // 
            this.btnOptionsExpireOrAssign.Location = new System.Drawing.Point(873, 11);
            this.btnOptionsExpireOrAssign.Name = "btnOptionsExpireOrAssign";
            this.btnOptionsExpireOrAssign.Size = new System.Drawing.Size(158, 23);
            this.btnOptionsExpireOrAssign.TabIndex = 126;
            this.btnOptionsExpireOrAssign.TabStop = false;
            this.btnOptionsExpireOrAssign.Text = "Expire/Assign (Test Only)";
            this.btnOptionsExpireOrAssign.UseVisualStyleBackColor = true;
            this.btnOptionsExpireOrAssign.Visible = false;
            // 
            // txtSettlePrice
            // 
            this.txtSettlePrice.Location = new System.Drawing.Point(557, 13);
            this.txtSettlePrice.Name = "txtSettlePrice";
            this.txtSettlePrice.Size = new System.Drawing.Size(61, 20);
            this.txtSettlePrice.TabIndex = 125;
            this.txtSettlePrice.Visible = false;
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(415, 13);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(59, 20);
            this.txtSymbol.TabIndex = 124;
            this.txtSymbol.Visible = false;
            // 
            // tmrPending
            // 
            this.tmrPending.Interval = 10000;
            this.tmrPending.Tick += new System.EventHandler(this.tmrPending_Tick);
            // 
            // dtSettleDate
            // 
            this.dtSettleDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtSettleDate.Location = new System.Drawing.Point(698, 15);
            this.dtSettleDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtSettleDate.MinDate = new System.DateTime(((long)(0)));
            this.dtSettleDate.Name = "dtSettleDate";
            this.dtSettleDate.NullableValue = new System.DateTime(2014, 7, 5, 14, 0, 33, 680);
            this.dtSettleDate.NullDate = new System.DateTime(((long)(0)));
            this.dtSettleDate.Size = new System.Drawing.Size(150, 18);
            this.dtSettleDate.TabIndex = 131;
            this.dtSettleDate.TabStop = false;
            this.dtSettleDate.Text = "radDateTimePicker1";
            this.dtSettleDate.Value = new System.DateTime(2014, 7, 5, 14, 0, 33, 680);
            this.dtSettleDate.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1197, 759);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 132;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // radDropDownButton1
            // 
            this.radDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rptOptionsOpenPosition,
            this.rptOptionsTradedToday,
            this.btnOptionConfirmation});
            this.radDropDownButton1.Location = new System.Drawing.Point(214, 8);
            this.radDropDownButton1.Name = "radDropDownButton1";
            this.radDropDownButton1.Size = new System.Drawing.Size(140, 24);
            this.radDropDownButton1.TabIndex = 133;
            this.radDropDownButton1.Text = "Reports";
            // 
            // rptOptionsOpenPosition
            // 
            this.rptOptionsOpenPosition.AccessibleDescription = "Options Open Position";
            this.rptOptionsOpenPosition.AccessibleName = "Options Open Position";
            // 
            // 
            // 
            this.rptOptionsOpenPosition.ButtonElement.AccessibleDescription = "Options Open Position";
            this.rptOptionsOpenPosition.ButtonElement.AccessibleName = "Options Open Position";
            this.rptOptionsOpenPosition.Name = "rptOptionsOpenPosition";
            this.rptOptionsOpenPosition.Text = "Options Open Position";
            this.rptOptionsOpenPosition.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.rptOptionsOpenPosition.Click += new System.EventHandler(this.rptOptionsOpenPosition_Click);
            // 
            // rptOptionsTradedToday
            // 
            this.rptOptionsTradedToday.AccessibleDescription = "Options Traded Today";
            this.rptOptionsTradedToday.AccessibleName = "Options Traded Today";
            // 
            // 
            // 
            this.rptOptionsTradedToday.ButtonElement.AccessibleDescription = "Options Traded Today";
            this.rptOptionsTradedToday.ButtonElement.AccessibleName = "Options Traded Today";
            this.rptOptionsTradedToday.Name = "rptOptionsTradedToday";
            this.rptOptionsTradedToday.Text = "Options Traded Today";
            this.rptOptionsTradedToday.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.rptOptionsTradedToday.Click += new System.EventHandler(this.rptOptionsTradedToday_Click);
            // 
            // dgvContractOptions
            // 
            this.dgvContractOptions.AllowUserToAddRows = false;
            this.dgvContractOptions.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dgvContractOptions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContractOptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContractOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContractOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn60,
            this.OrderNo,
            this.CardNumber,
            this.dataGridViewTextBoxColumn32,
            this.Merchandiser,
            this.dataGridViewTextBoxColumn45,
            this.ContractOptionBuySell,
            this.ContractOptionQuantity,
            this.AssignedQuantity,
            this.Accepted,
            this.ContractOptionStatus,
            this.Cancelled,
            this.ExpireAssign,
            this.Option,
            this.ExpirationDate,
            this.Premium,
            this.ExecutedPremium,
            this.OptionsFuturesPrice,
            this.FillPremium,
            this.SoldPremium,
            this.OrderDateTime,
            this.AssignmentDate,
            this.dataGridViewTextBoxColumn52,
            this.dataGridViewTextBoxColumn53,
            this.ContractType,
            this.dataGridViewTextBoxColumn61,
            this.ContractOptionID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContractOptions.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvContractOptions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvContractOptions.Location = new System.Drawing.Point(1, 0);
            this.dgvContractOptions.Margin = new System.Windows.Forms.Padding(0);
            this.dgvContractOptions.MultiSelect = false;
            this.dgvContractOptions.Name = "dgvContractOptions";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContractOptions.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvContractOptions.RowHeadersWidth = 10;
            this.dgvContractOptions.Size = new System.Drawing.Size(1266, 691);
            this.dgvContractOptions.TabIndex = 0;
            this.dgvContractOptions.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvContractOptions_CellBeginEdit);
            this.dgvContractOptions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContractOptions_CellContentClick);
            this.dgvContractOptions.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContractOptions_CellLeave);
            this.dgvContractOptions.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvContractOptions_DataError);
            this.dgvContractOptions.MouseEnter += new System.EventHandler(this.dgvContractOptions_MouseEnter);
            // 
            // dataGridViewTextBoxColumn60
            // 
            this.dataGridViewTextBoxColumn60.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn60.DataPropertyName = "HedgeAccount";
            this.dataGridViewTextBoxColumn60.HeaderText = "Acct";
            this.dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
            this.dataGridViewTextBoxColumn60.ReadOnly = true;
            this.dataGridViewTextBoxColumn60.Width = 54;
            // 
            // OrderNo
            // 
            this.OrderNo.DataPropertyName = "OrderNumber";
            this.OrderNo.HeaderText = "Order#";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Visible = false;
            // 
            // CardNumber
            // 
            this.CardNumber.DataPropertyName = "CardNumber";
            this.CardNumber.HeaderText = "Card #";
            this.CardNumber.Name = "CardNumber";
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn32.DataPropertyName = "ContractNumber";
            this.dataGridViewTextBoxColumn32.HeaderText = "Contract #";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Width = 82;
            // 
            // Merchandiser
            // 
            this.Merchandiser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Merchandiser.DataPropertyName = "Merchandiser";
            this.Merchandiser.HeaderText = "Merchandiser";
            this.Merchandiser.Name = "Merchandiser";
            this.Merchandiser.ReadOnly = true;
            this.Merchandiser.Width = 96;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn45.DataPropertyName = "Commodity";
            this.dataGridViewTextBoxColumn45.HeaderText = "Commodity";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            this.dataGridViewTextBoxColumn45.Width = 83;
            // 
            // ContractOptionBuySell
            // 
            this.ContractOptionBuySell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContractOptionBuySell.DataPropertyName = "BuySell";
            this.ContractOptionBuySell.HeaderText = "B/S";
            this.ContractOptionBuySell.Name = "ContractOptionBuySell";
            this.ContractOptionBuySell.ReadOnly = true;
            this.ContractOptionBuySell.Width = 51;
            // 
            // ContractOptionQuantity
            // 
            this.ContractOptionQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContractOptionQuantity.DataPropertyName = "Quantity";
            this.ContractOptionQuantity.HeaderText = "Qty";
            this.ContractOptionQuantity.Name = "ContractOptionQuantity";
            this.ContractOptionQuantity.ReadOnly = true;
            this.ContractOptionQuantity.Width = 48;
            // 
            // AssignedQuantity
            // 
            this.AssignedQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AssignedQuantity.DataPropertyName = "AssignedQuantity";
            this.AssignedQuantity.HeaderText = "Assigned Qty";
            this.AssignedQuantity.Name = "AssignedQuantity";
            this.AssignedQuantity.Width = 94;
            // 
            // Accepted
            // 
            this.Accepted.DataPropertyName = "Accepted";
            this.Accepted.HeaderText = "Accepted";
            this.Accepted.Name = "Accepted";
            this.Accepted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Accepted.Width = 60;
            // 
            // ContractOptionStatus
            // 
            this.ContractOptionStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContractOptionStatus.DataPropertyName = "Status";
            this.ContractOptionStatus.HeaderText = "Status";
            this.ContractOptionStatus.Name = "ContractOptionStatus";
            this.ContractOptionStatus.ReadOnly = true;
            this.ContractOptionStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ContractOptionStatus.Width = 62;
            // 
            // Cancelled
            // 
            this.Cancelled.DataPropertyName = "Cancelled";
            this.Cancelled.HeaderText = "Cancelled";
            this.Cancelled.Name = "Cancelled";
            this.Cancelled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cancelled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cancelled.Width = 60;
            // 
            // ExpireAssign
            // 
            this.ExpireAssign.DataPropertyName = "ContractOptionID";
            this.ExpireAssign.HeaderText = "Exp/Assn";
            this.ExpireAssign.Name = "ExpireAssign";
            this.ExpireAssign.ReadOnly = true;
            this.ExpireAssign.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpireAssign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ExpireAssign.Text = "Exp/Assn";
            this.ExpireAssign.ToolTipText = "Expire or Assign";
            this.ExpireAssign.UseColumnTextForButtonValue = true;
            this.ExpireAssign.Visible = false;
            this.ExpireAssign.Width = 60;
            // 
            // Option
            // 
            this.Option.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Option.DataPropertyName = "Option";
            this.Option.HeaderText = "Option";
            this.Option.Name = "Option";
            this.Option.ReadOnly = true;
            this.Option.Width = 63;
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ExpirationDate.DataPropertyName = "OptionExpirationDate";
            this.ExpirationDate.HeaderText = "Expire Date";
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.ReadOnly = true;
            this.ExpirationDate.Width = 87;
            // 
            // Premium
            // 
            this.Premium.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Premium.DataPropertyName = "OptionPremium";
            this.Premium.HeaderText = "Premium";
            this.Premium.Name = "Premium";
            this.Premium.ReadOnly = true;
            this.Premium.Width = 72;
            // 
            // ExecutedPremium
            // 
            this.ExecutedPremium.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ExecutedPremium.DataPropertyName = "OptionClosingPremium";
            this.ExecutedPremium.HeaderText = "Executed Prem.";
            this.ExecutedPremium.Name = "ExecutedPremium";
            this.ExecutedPremium.Width = 107;
            // 
            // OptionsFuturesPrice
            // 
            this.OptionsFuturesPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OptionsFuturesPrice.DataPropertyName = "FuturesPrice";
            this.OptionsFuturesPrice.HeaderText = "Futures Price";
            this.OptionsFuturesPrice.Name = "OptionsFuturesPrice";
            this.OptionsFuturesPrice.ReadOnly = true;
            this.OptionsFuturesPrice.Visible = false;
            // 
            // FillPremium
            // 
            this.FillPremium.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FillPremium.DataPropertyName = "FillPremium";
            this.FillPremium.HeaderText = "Exit Prem.";
            this.FillPremium.Name = "FillPremium";
            this.FillPremium.ReadOnly = true;
            this.FillPremium.Width = 79;
            // 
            // SoldPremium
            // 
            this.SoldPremium.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SoldPremium.DataPropertyName = "SoldPremium";
            this.SoldPremium.HeaderText = "Sold Prem.";
            this.SoldPremium.Name = "SoldPremium";
            this.SoldPremium.Width = 83;
            // 
            // OrderDateTime
            // 
            this.OrderDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OrderDateTime.DataPropertyName = "OriginalOrderDateTime";
            this.OrderDateTime.HeaderText = "Orig. Order Time";
            this.OrderDateTime.Name = "OrderDateTime";
            this.OrderDateTime.ReadOnly = true;
            this.OrderDateTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OrderDateTime.Width = 109;
            // 
            // AssignmentDate
            // 
            this.AssignmentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AssignmentDate.DataPropertyName = "AssignmentDate";
            this.AssignmentDate.HeaderText = "Assignment Date";
            this.AssignmentDate.Name = "AssignmentDate";
            this.AssignmentDate.ReadOnly = true;
            this.AssignmentDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AssignmentDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AssignmentDate.Width = 112;
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn52.DataPropertyName = "CustomerName";
            this.dataGridViewTextBoxColumn52.HeaderText = "Customer";
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.ReadOnly = true;
            this.dataGridViewTextBoxColumn52.Width = 76;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn53.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn53.HeaderText = "Location";
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.ReadOnly = true;
            this.dataGridViewTextBoxColumn53.Width = 73;
            // 
            // ContractType
            // 
            this.ContractType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContractType.DataPropertyName = "ContractType";
            this.ContractType.HeaderText = "Contract Type";
            this.ContractType.Name = "ContractType";
            this.ContractType.ReadOnly = true;
            this.ContractType.Width = 99;
            // 
            // dataGridViewTextBoxColumn61
            // 
            this.dataGridViewTextBoxColumn61.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn61.DataPropertyName = "ContractDate";
            this.dataGridViewTextBoxColumn61.HeaderText = "Contract Date";
            this.dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
            this.dataGridViewTextBoxColumn61.ReadOnly = true;
            this.dataGridViewTextBoxColumn61.Width = 98;
            // 
            // ContractOptionID
            // 
            this.ContractOptionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContractOptionID.DataPropertyName = "ContractOptionID";
            this.ContractOptionID.HeaderText = "ContractOptionID";
            this.ContractOptionID.Name = "ContractOptionID";
            this.ContractOptionID.ReadOnly = true;
            this.ContractOptionID.Visible = false;
            // 
            // dgvContractOptionsNotWorking
            // 
            this.dgvContractOptionsNotWorking.AllowUserToAddRows = false;
            this.dgvContractOptionsNotWorking.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info;
            this.dgvContractOptionsNotWorking.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContractOptionsNotWorking.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvContractOptionsNotWorking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContractOptionsNotWorking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn44,
            this.OrderNoNotWorking,
            this.CardNumberNotWorking,
            this.dataGridViewTextBoxColumn50,
            this.MerchandiserNotWorking,
            this.dataGridViewTextBoxColumn54,
            this.ContractOptionNotWorkingBuySell,
            this.ContractOptionQuantityNotWorking,
            this.AssignedQuantityNotWorking,
            this.AcceptedNotWorking,
            this.ContractOptionStatusNotWorking,
            this.CancelledNotWorking,
            this.OptionNotWorking,
            this.ExpirationDateNotWorking,
            this.PremiumNotWorking,
            this.ExecutedPremiumNotWorking,
            this.OptionsFuturesPriceNotWorking,
            this.FillPremiumNotWorking,
            this.SoldPremiumNotWorking,
            this.OrderDateTimeNotWorking,
            this.AssignmentDateNotWorking,
            this.dataGridViewTextBoxColumn67,
            this.dataGridViewTextBoxColumn68,
            this.ContractTypeNotWorking,
            this.dataGridViewTextBoxColumn72,
            this.ContractOptionIDNotWorking});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContractOptionsNotWorking.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvContractOptionsNotWorking.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvContractOptionsNotWorking.Location = new System.Drawing.Point(1, 0);
            this.dgvContractOptionsNotWorking.MultiSelect = false;
            this.dgvContractOptionsNotWorking.Name = "dgvContractOptionsNotWorking";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContractOptionsNotWorking.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvContractOptionsNotWorking.RowHeadersWidth = 10;
            this.dgvContractOptionsNotWorking.Size = new System.Drawing.Size(1266, 688);
            this.dgvContractOptionsNotWorking.TabIndex = 114;
            this.dgvContractOptionsNotWorking.TabStop = false;
            this.dgvContractOptionsNotWorking.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvContractOptionsNotWorking_CellBeginEdit);
            this.dgvContractOptionsNotWorking.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContractOptionsNotWorking_CellLeave);
            this.dgvContractOptionsNotWorking.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvContractOptionsNotWorking_DataError);
            this.dgvContractOptionsNotWorking.MouseEnter += new System.EventHandler(this.dgvContractOptionsNotWorking_MouseEnter);
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn44.DataPropertyName = "HedgeAccount";
            this.dataGridViewTextBoxColumn44.HeaderText = "Acct";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.ReadOnly = true;
            this.dataGridViewTextBoxColumn44.Width = 54;
            // 
            // OrderNoNotWorking
            // 
            this.OrderNoNotWorking.DataPropertyName = "OrderNumber";
            this.OrderNoNotWorking.HeaderText = "Order#";
            this.OrderNoNotWorking.Name = "OrderNoNotWorking";
            this.OrderNoNotWorking.Visible = false;
            // 
            // CardNumberNotWorking
            // 
            this.CardNumberNotWorking.DataPropertyName = "CardNumber";
            this.CardNumberNotWorking.HeaderText = "Card #";
            this.CardNumberNotWorking.Name = "CardNumberNotWorking";
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn50.DataPropertyName = "ContractNumber";
            this.dataGridViewTextBoxColumn50.HeaderText = "Contract #";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.ReadOnly = true;
            this.dataGridViewTextBoxColumn50.Width = 82;
            // 
            // MerchandiserNotWorking
            // 
            this.MerchandiserNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MerchandiserNotWorking.DataPropertyName = "Merchandiser";
            this.MerchandiserNotWorking.HeaderText = "Merchandiser";
            this.MerchandiserNotWorking.Name = "MerchandiserNotWorking";
            this.MerchandiserNotWorking.ReadOnly = true;
            this.MerchandiserNotWorking.Width = 96;
            // 
            // dataGridViewTextBoxColumn54
            // 
            this.dataGridViewTextBoxColumn54.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn54.DataPropertyName = "Commodity";
            this.dataGridViewTextBoxColumn54.HeaderText = "Commodity";
            this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
            this.dataGridViewTextBoxColumn54.ReadOnly = true;
            this.dataGridViewTextBoxColumn54.Width = 83;
            // 
            // ContractOptionNotWorkingBuySell
            // 
            this.ContractOptionNotWorkingBuySell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContractOptionNotWorkingBuySell.DataPropertyName = "BuySell";
            this.ContractOptionNotWorkingBuySell.HeaderText = "B/S";
            this.ContractOptionNotWorkingBuySell.Name = "ContractOptionNotWorkingBuySell";
            this.ContractOptionNotWorkingBuySell.ReadOnly = true;
            this.ContractOptionNotWorkingBuySell.Width = 51;
            // 
            // ContractOptionQuantityNotWorking
            // 
            this.ContractOptionQuantityNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContractOptionQuantityNotWorking.DataPropertyName = "Quantity";
            this.ContractOptionQuantityNotWorking.HeaderText = "Qty";
            this.ContractOptionQuantityNotWorking.Name = "ContractOptionQuantityNotWorking";
            this.ContractOptionQuantityNotWorking.ReadOnly = true;
            this.ContractOptionQuantityNotWorking.Width = 48;
            // 
            // AssignedQuantityNotWorking
            // 
            this.AssignedQuantityNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AssignedQuantityNotWorking.DataPropertyName = "AssignedQuantity";
            this.AssignedQuantityNotWorking.HeaderText = "Assigned Qty";
            this.AssignedQuantityNotWorking.Name = "AssignedQuantityNotWorking";
            this.AssignedQuantityNotWorking.Width = 94;
            // 
            // AcceptedNotWorking
            // 
            this.AcceptedNotWorking.DataPropertyName = "Accepted";
            this.AcceptedNotWorking.HeaderText = "Accepted";
            this.AcceptedNotWorking.Name = "AcceptedNotWorking";
            this.AcceptedNotWorking.ReadOnly = true;
            this.AcceptedNotWorking.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AcceptedNotWorking.Width = 60;
            // 
            // ContractOptionStatusNotWorking
            // 
            this.ContractOptionStatusNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContractOptionStatusNotWorking.DataPropertyName = "Status";
            this.ContractOptionStatusNotWorking.HeaderText = "Status";
            this.ContractOptionStatusNotWorking.Name = "ContractOptionStatusNotWorking";
            this.ContractOptionStatusNotWorking.ReadOnly = true;
            this.ContractOptionStatusNotWorking.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ContractOptionStatusNotWorking.Width = 62;
            // 
            // CancelledNotWorking
            // 
            this.CancelledNotWorking.DataPropertyName = "Cancelled";
            this.CancelledNotWorking.HeaderText = "Cancelled";
            this.CancelledNotWorking.Name = "CancelledNotWorking";
            this.CancelledNotWorking.ReadOnly = true;
            this.CancelledNotWorking.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CancelledNotWorking.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CancelledNotWorking.Width = 60;
            // 
            // OptionNotWorking
            // 
            this.OptionNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OptionNotWorking.DataPropertyName = "Option";
            this.OptionNotWorking.HeaderText = "Option";
            this.OptionNotWorking.Name = "OptionNotWorking";
            this.OptionNotWorking.ReadOnly = true;
            this.OptionNotWorking.Width = 63;
            // 
            // ExpirationDateNotWorking
            // 
            this.ExpirationDateNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ExpirationDateNotWorking.DataPropertyName = "OptionExpirationDate";
            this.ExpirationDateNotWorking.HeaderText = "Expire Date";
            this.ExpirationDateNotWorking.Name = "ExpirationDateNotWorking";
            this.ExpirationDateNotWorking.ReadOnly = true;
            this.ExpirationDateNotWorking.Width = 87;
            // 
            // PremiumNotWorking
            // 
            this.PremiumNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PremiumNotWorking.DataPropertyName = "OptionPremium";
            this.PremiumNotWorking.HeaderText = "Premium";
            this.PremiumNotWorking.Name = "PremiumNotWorking";
            this.PremiumNotWorking.ReadOnly = true;
            this.PremiumNotWorking.Width = 72;
            // 
            // ExecutedPremiumNotWorking
            // 
            this.ExecutedPremiumNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ExecutedPremiumNotWorking.DataPropertyName = "OptionClosingPremium";
            this.ExecutedPremiumNotWorking.HeaderText = "Executed Prem.";
            this.ExecutedPremiumNotWorking.Name = "ExecutedPremiumNotWorking";
            this.ExecutedPremiumNotWorking.ReadOnly = true;
            this.ExecutedPremiumNotWorking.Width = 107;
            // 
            // OptionsFuturesPriceNotWorking
            // 
            this.OptionsFuturesPriceNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OptionsFuturesPriceNotWorking.DataPropertyName = "FuturesPrice";
            this.OptionsFuturesPriceNotWorking.HeaderText = "Futures Price";
            this.OptionsFuturesPriceNotWorking.Name = "OptionsFuturesPriceNotWorking";
            this.OptionsFuturesPriceNotWorking.Visible = false;
            // 
            // FillPremiumNotWorking
            // 
            this.FillPremiumNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FillPremiumNotWorking.DataPropertyName = "FillPremium";
            this.FillPremiumNotWorking.HeaderText = "Exit Prem.";
            this.FillPremiumNotWorking.Name = "FillPremiumNotWorking";
            this.FillPremiumNotWorking.ReadOnly = true;
            this.FillPremiumNotWorking.Width = 79;
            // 
            // SoldPremiumNotWorking
            // 
            this.SoldPremiumNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SoldPremiumNotWorking.DataPropertyName = "SoldPremium";
            this.SoldPremiumNotWorking.HeaderText = "Sold Prem.";
            this.SoldPremiumNotWorking.Name = "SoldPremiumNotWorking";
            this.SoldPremiumNotWorking.ReadOnly = true;
            this.SoldPremiumNotWorking.Width = 83;
            // 
            // OrderDateTimeNotWorking
            // 
            this.OrderDateTimeNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OrderDateTimeNotWorking.DataPropertyName = "OriginalOrderDateTime";
            this.OrderDateTimeNotWorking.HeaderText = "Orig. Order Time";
            this.OrderDateTimeNotWorking.Name = "OrderDateTimeNotWorking";
            this.OrderDateTimeNotWorking.ReadOnly = true;
            this.OrderDateTimeNotWorking.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderDateTimeNotWorking.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OrderDateTimeNotWorking.Width = 109;
            // 
            // AssignmentDateNotWorking
            // 
            this.AssignmentDateNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AssignmentDateNotWorking.DataPropertyName = "AssignmentDate";
            this.AssignmentDateNotWorking.HeaderText = "Assignment Date";
            this.AssignmentDateNotWorking.Name = "AssignmentDateNotWorking";
            this.AssignmentDateNotWorking.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AssignmentDateNotWorking.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AssignmentDateNotWorking.Width = 112;
            // 
            // dataGridViewTextBoxColumn67
            // 
            this.dataGridViewTextBoxColumn67.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn67.DataPropertyName = "CustomerName";
            this.dataGridViewTextBoxColumn67.HeaderText = "Customer";
            this.dataGridViewTextBoxColumn67.Name = "dataGridViewTextBoxColumn67";
            this.dataGridViewTextBoxColumn67.ReadOnly = true;
            this.dataGridViewTextBoxColumn67.Width = 76;
            // 
            // dataGridViewTextBoxColumn68
            // 
            this.dataGridViewTextBoxColumn68.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn68.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn68.HeaderText = "Location";
            this.dataGridViewTextBoxColumn68.Name = "dataGridViewTextBoxColumn68";
            this.dataGridViewTextBoxColumn68.ReadOnly = true;
            this.dataGridViewTextBoxColumn68.Width = 73;
            // 
            // ContractTypeNotWorking
            // 
            this.ContractTypeNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContractTypeNotWorking.DataPropertyName = "ContractType";
            this.ContractTypeNotWorking.HeaderText = "Contract Type";
            this.ContractTypeNotWorking.Name = "ContractTypeNotWorking";
            this.ContractTypeNotWorking.ReadOnly = true;
            this.ContractTypeNotWorking.Width = 99;
            // 
            // dataGridViewTextBoxColumn72
            // 
            this.dataGridViewTextBoxColumn72.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn72.DataPropertyName = "ContractDate";
            this.dataGridViewTextBoxColumn72.HeaderText = "Contract Date";
            this.dataGridViewTextBoxColumn72.Name = "dataGridViewTextBoxColumn72";
            this.dataGridViewTextBoxColumn72.ReadOnly = true;
            this.dataGridViewTextBoxColumn72.Width = 98;
            // 
            // ContractOptionIDNotWorking
            // 
            this.ContractOptionIDNotWorking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ContractOptionIDNotWorking.DataPropertyName = "ContractOptionID";
            this.ContractOptionIDNotWorking.HeaderText = "ContractOptionID";
            this.ContractOptionIDNotWorking.Name = "ContractOptionIDNotWorking";
            this.ContractOptionIDNotWorking.ReadOnly = true;
            this.ContractOptionIDNotWorking.Visible = false;
            // 
            // btnOptionConfirmation
            // 
            this.btnOptionConfirmation.AccessibleDescription = "Option Confirmation";
            this.btnOptionConfirmation.AccessibleName = "Option Confirmation";
            // 
            // 
            // 
            this.btnOptionConfirmation.ButtonElement.AccessibleDescription = "Option Confirmation";
            this.btnOptionConfirmation.ButtonElement.AccessibleName = "Option Confirmation";
            this.btnOptionConfirmation.Name = "btnOptionConfirmation";
            this.btnOptionConfirmation.Text = "Option Confirmation";
            this.btnOptionConfirmation.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnOptionConfirmation.Click += new System.EventHandler(this.btnOptionConfirmation_Click);
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 791);
            this.Controls.Add(this.btnContractOptionDefaultSort);
            this.Controls.Add(this.tbcContractOptions);
            this.Controls.Add(this.radDropDownButton1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtSettleDate);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.btnRefreshAll_OptionsTab);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.btnOptionsExpireOrAssign);
            this.Controls.Add(this.txtSettlePrice);
            this.Controls.Add(this.txtSymbol);
            this.Name = "frmOptions";
            this.Text = "frmOptions";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.tbcContractOptions.ResumeLayout(false);
            this.tpWorkingOptions.ResumeLayout(false);
            this.tpNotWorkingOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtSettleDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractOptionsNotWorking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public dgvCustom dgvContractOptions;
        private System.Windows.Forms.Button btnContractOptionDefaultSort;
        private System.Windows.Forms.TabControl tbcContractOptions;
        private System.Windows.Forms.TabPage tpWorkingOptions;
        private System.Windows.Forms.TabPage tpNotWorkingOptions;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button btnRefreshAll_OptionsTab;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button btnOptionsExpireOrAssign;
        private System.Windows.Forms.TextBox txtSettlePrice;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Timer tmrPending;
        private Telerik.WinControls.UI.RadDateTimePicker dtSettleDate;
        private System.Windows.Forms.Button btnClose;
        public dgvCustom dgvContractOptionsNotWorking;
        private Telerik.WinControls.UI.RadDropDownButton radDropDownButton1;
        private Telerik.WinControls.UI.RadMenuButtonItem rptOptionsOpenPosition;
        private Telerik.WinControls.UI.RadMenuButtonItem rptOptionsTradedToday;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merchandiser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractOptionBuySell;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractOptionQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedQuantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Accepted;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractOptionStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cancelled;
        private System.Windows.Forms.DataGridViewButtonColumn ExpireAssign;
        private System.Windows.Forms.DataGridViewTextBoxColumn Option;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Premium;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExecutedPremium;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionsFuturesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn FillPremium;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldPremium;
        private CalendarColumn OrderDateTime;
        private CalendarDateColumn AssignmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractOptionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNoNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumberNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchandiserNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractOptionNotWorkingBuySell;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractOptionQuantityNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedQuantityNotWorking;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AcceptedNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractOptionStatusNotWorking;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CancelledNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpirationDateNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn PremiumNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExecutedPremiumNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionsFuturesPriceNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn FillPremiumNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldPremiumNotWorking;
        private CalendarColumn OrderDateTimeNotWorking;
        private CalendarDateColumn AssignmentDateNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractTypeNotWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractOptionIDNotWorking;
        private Telerik.WinControls.UI.RadMenuButtonItem btnOptionConfirmation;

    }
}