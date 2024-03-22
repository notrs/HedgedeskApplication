
namespace HedgedeskApplication
{
    partial class frmPurchaseSettleEditApplications
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.dgvBuyApplications = new dgvCustom();
            this.OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptionMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptionYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilledPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradeComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcctXref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicationAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuyContracts = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(935, 235);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(94, 23);
            this.cmdCancel.TabIndex = 43;
            this.cmdCancel.Text = "Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // dgvBuyApplications
            // 
            this.dgvBuyApplications.AllowUserToAddRows = false;
            this.dgvBuyApplications.AllowUserToDeleteRows = false;
            this.dgvBuyApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuyApplications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderID,
            this.OrderNumber,
            this.Seq,
            this.OrderDate,
            this.Company,
            this.Account,
            this.Commodity,
            this.OptionMonth,
            this.OptionYear,
            this.Amount,
            this.Exch,
            this.OrderType,
            this.FilledPrice,
            this.TradeComp,
            this.CardNumber,
            this.AcctXref,
            this.ApplicationDate,
            this.ApplicationAmount});
            this.dgvBuyApplications.Location = new System.Drawing.Point(4, 1);
            this.dgvBuyApplications.Name = "dgvBuyApplications";
            this.dgvBuyApplications.RowHeadersVisible = false;
            this.dgvBuyApplications.Size = new System.Drawing.Size(1036, 182);
            this.dgvBuyApplications.TabIndex = 50;
            // 
            // OrderID
            // 
            this.OrderID.DataPropertyName = "PSSellOrderId";
            this.OrderID.HeaderText = "Order ID";
            this.OrderID.Name = "OrderID";
            this.OrderID.ReadOnly = true;
            this.OrderID.Width = 75;
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "OrderNumber";
            this.OrderNumber.HeaderText = "Order#";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            this.OrderNumber.Width = 70;
            // 
            // Seq
            // 
            this.Seq.DataPropertyName = "OrderSeq";
            this.Seq.HeaderText = "Seq";
            this.Seq.Name = "Seq";
            this.Seq.ReadOnly = true;
            this.Seq.Width = 40;
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "OrderDate";
            this.OrderDate.HeaderText = "Order Date";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            this.OrderDate.Width = 75;
            // 
            // Company
            // 
            this.Company.DataPropertyName = "Company";
            this.Company.HeaderText = "Comp";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            this.Company.Width = 45;
            // 
            // Account
            // 
            this.Account.DataPropertyName = "Account";
            this.Account.HeaderText = "Acct";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            this.Account.Width = 45;
            // 
            // Commodity
            // 
            this.Commodity.DataPropertyName = "Commodity";
            this.Commodity.HeaderText = "Comm";
            this.Commodity.Name = "Commodity";
            this.Commodity.ReadOnly = true;
            this.Commodity.Width = 50;
            // 
            // OptionMonth
            // 
            this.OptionMonth.DataPropertyName = "OptionMonth";
            this.OptionMonth.HeaderText = "Month";
            this.OptionMonth.Name = "OptionMonth";
            this.OptionMonth.ReadOnly = true;
            this.OptionMonth.Width = 40;
            // 
            // OptionYear
            // 
            this.OptionYear.DataPropertyName = "OptionYear";
            this.OptionYear.HeaderText = "Year";
            this.OptionYear.Name = "OptionYear";
            this.OptionYear.ReadOnly = true;
            this.OptionYear.Width = 40;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 50;
            // 
            // Exch
            // 
            this.Exch.DataPropertyName = "ExchLtr";
            this.Exch.HeaderText = "Exch";
            this.Exch.Name = "Exch";
            this.Exch.ReadOnly = true;
            this.Exch.Width = 35;
            // 
            // OrderType
            // 
            this.OrderType.DataPropertyName = "OrderType";
            this.OrderType.HeaderText = "Order Type";
            this.OrderType.Name = "OrderType";
            this.OrderType.ReadOnly = true;
            this.OrderType.Width = 60;
            // 
            // FilledPrice
            // 
            this.FilledPrice.DataPropertyName = "FilledPrice";
            this.FilledPrice.HeaderText = "Filled Price";
            this.FilledPrice.Name = "FilledPrice";
            this.FilledPrice.ReadOnly = true;
            this.FilledPrice.Width = 75;
            // 
            // TradeComp
            // 
            this.TradeComp.DataPropertyName = "TradeCompany";
            this.TradeComp.HeaderText = "Trade Comp";
            this.TradeComp.Name = "TradeComp";
            this.TradeComp.ReadOnly = true;
            this.TradeComp.Width = 50;
            // 
            // CardNumber
            // 
            this.CardNumber.DataPropertyName = "CardNumber";
            this.CardNumber.HeaderText = "Card #";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.ReadOnly = true;
            this.CardNumber.Width = 75;
            // 
            // AcctXref
            // 
            this.AcctXref.DataPropertyName = "AccountXref";
            this.AcctXref.HeaderText = "Acct Xref";
            this.AcctXref.Name = "AcctXref";
            this.AcctXref.ReadOnly = true;
            this.AcctXref.Width = 50;
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.DataPropertyName = "ApplicationDate";
            this.ApplicationDate.HeaderText = "Application Date";
            this.ApplicationDate.Name = "ApplicationDate";
            this.ApplicationDate.ReadOnly = true;
            this.ApplicationDate.Width = 65;
            // 
            // ApplicationAmount
            // 
            this.ApplicationAmount.DataPropertyName = "ApplicationAmount";
            this.ApplicationAmount.HeaderText = "Application Amount";
            this.ApplicationAmount.Name = "ApplicationAmount";
            this.ApplicationAmount.ReadOnly = true;
            this.ApplicationAmount.Width = 70;
            // 
            // txtBuyContracts
            // 
            this.txtBuyContracts.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtBuyContracts.Location = new System.Drawing.Point(944, 189);
            this.txtBuyContracts.Name = "txtBuyContracts";
            this.txtBuyContracts.Size = new System.Drawing.Size(70, 20);
            this.txtBuyContracts.TabIndex = 56;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(801, 192);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(142, 13);
            this.label15.TabIndex = 55;
            this.label15.Text = "Total P/S Contracts Applied:";
            // 
            // frmPurchaseSettleEditApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 270);
            this.Controls.Add(this.txtBuyContracts);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dgvBuyApplications);
            this.Controls.Add(this.cmdCancel);
            this.Name = "frmPurchaseSettleEditApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "P/S Buy Applications";
            this.Load += new System.EventHandler(this.frmPurchaseSettleEditApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private dgvCustom dgvBuyApplications;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exch;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilledPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcctXref;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicationAmount;
        private System.Windows.Forms.TextBox txtBuyContracts;
        private System.Windows.Forms.Label label15;
    }
}