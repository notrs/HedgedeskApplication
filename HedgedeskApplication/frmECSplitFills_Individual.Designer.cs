namespace HedgedeskApplication
{
    partial class frmECSplitFills_Individual
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvECOrders = new System.Windows.Forms.DataGridView();
            this.SFFill = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.uLastPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradeCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECInd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMEQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECFilledQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECAvgPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECRemQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECSplitOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECApp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CreateRecord = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FillOriginal = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblOriginalQty = new System.Windows.Forms.Label();
            this.lblRemainingQty = new System.Windows.Forms.Label();
            this.chkGTC = new System.Windows.Forms.CheckBox();
            this.txtTP_ORD_NUMB = new System.Windows.Forms.TextBox();
            this.cmdSendEmail = new System.Windows.Forms.Button();
            this.cmdDeSelect = new System.Windows.Forms.Button();
            this.cmdFillCheckedItems = new System.Windows.Forms.Button();
            this.txtAMT = new System.Windows.Forms.TextBox();
            this.txtRemainingQty = new System.Windows.Forms.TextBox();
            this.btnFillSelectedOriginal = new System.Windows.Forms.Button();
            this.txtSelectedQuantity = new System.Windows.Forms.TextBox();
            this.lblSelectedQuantity = new System.Windows.Forms.Label();
            this.btnNewSplitFill = new System.Windows.Forms.Button();
            this.lblProcessed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvECOrders
            // 
            this.dgvECOrders.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dgvECOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvECOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvECOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvECOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvECOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvECOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SFFill,
            this.uLastPrice,
            this.MessageID,
            this.TradeCompany,
            this.OrderNo,
            this.ECCardNumber,
            this.ECOrderID,
            this.Transaction,
            this.ECStatus,
            this.ECInd,
            this.CMEQty,
            this.ECFilledQty,
            this.ECPrice,
            this.ECQty,
            this.ECAvgPrice,
            this.ECRemQty,
            this.ECSplitOrderID,
            this.ECApp,
            this.CreateRecord,
            this.FillOriginal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvECOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvECOrders.Location = new System.Drawing.Point(1, 118);
            this.dgvECOrders.MultiSelect = false;
            this.dgvECOrders.Name = "dgvECOrders";
            this.dgvECOrders.RowHeadersWidth = 15;
            this.dgvECOrders.Size = new System.Drawing.Size(1043, 522);
            this.dgvECOrders.TabIndex = 6;
            this.dgvECOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvECOrders_CellContentClick);
            this.dgvECOrders.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvECOrders_CellValueChanged);
            // 
            // SFFill
            // 
            this.SFFill.DataPropertyName = "Filled";
            this.SFFill.HeaderText = "Fill";
            this.SFFill.Name = "SFFill";
            this.SFFill.Width = 32;
            // 
            // uLastPrice
            // 
            this.uLastPrice.DataPropertyName = "unconvertedLastPrice";
            this.uLastPrice.HeaderText = "uLastPrice";
            this.uLastPrice.Name = "uLastPrice";
            this.uLastPrice.Visible = false;
            // 
            // MessageID
            // 
            this.MessageID.DataPropertyName = "MessageID";
            this.MessageID.HeaderText = "MessageID";
            this.MessageID.Name = "MessageID";
            this.MessageID.Visible = false;
            // 
            // TradeCompany
            // 
            this.TradeCompany.DataPropertyName = "TradeCompany";
            this.TradeCompany.HeaderText = "TradeCompany";
            this.TradeCompany.Name = "TradeCompany";
            this.TradeCompany.Visible = false;
            // 
            // OrderNo
            // 
            this.OrderNo.DataPropertyName = "ClientOrderID";
            this.OrderNo.HeaderText = "Order No.";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            this.OrderNo.Width = 60;
            // 
            // ECCardNumber
            // 
            this.ECCardNumber.DataPropertyName = "CardNumber";
            this.ECCardNumber.HeaderText = "Card #";
            this.ECCardNumber.Name = "ECCardNumber";
            this.ECCardNumber.ReadOnly = true;
            this.ECCardNumber.Width = 90;
            // 
            // ECOrderID
            // 
            this.ECOrderID.DataPropertyName = "Order ID";
            this.ECOrderID.HeaderText = "Order ID";
            this.ECOrderID.Name = "ECOrderID";
            this.ECOrderID.ReadOnly = true;
            this.ECOrderID.Width = 60;
            // 
            // Transaction
            // 
            this.Transaction.DataPropertyName = "Transaction";
            this.Transaction.HeaderText = "Transaction";
            this.Transaction.Name = "Transaction";
            this.Transaction.ReadOnly = true;
            this.Transaction.Width = 70;
            // 
            // ECStatus
            // 
            this.ECStatus.DataPropertyName = "Trans Type";
            this.ECStatus.HeaderText = "Type";
            this.ECStatus.Name = "ECStatus";
            this.ECStatus.ReadOnly = true;
            this.ECStatus.Width = 50;
            // 
            // ECInd
            // 
            this.ECInd.DataPropertyName = "Symbol";
            this.ECInd.HeaderText = "Side";
            this.ECInd.Name = "ECInd";
            this.ECInd.ReadOnly = true;
            this.ECInd.Width = 37;
            // 
            // CMEQty
            // 
            this.CMEQty.DataPropertyName = "Orig Qty";
            this.CMEQty.HeaderText = "Orig Qty";
            this.CMEQty.Name = "CMEQty";
            this.CMEQty.ReadOnly = true;
            this.CMEQty.Width = 60;
            // 
            // ECFilledQty
            // 
            this.ECFilledQty.DataPropertyName = "Fill Quantity";
            this.ECFilledQty.HeaderText = "Fill Qty";
            this.ECFilledQty.Name = "ECFilledQty";
            this.ECFilledQty.ReadOnly = true;
            this.ECFilledQty.Width = 60;
            // 
            // ECPrice
            // 
            this.ECPrice.DataPropertyName = "Last Price";
            this.ECPrice.HeaderText = "Last Prc";
            this.ECPrice.Name = "ECPrice";
            this.ECPrice.ReadOnly = true;
            this.ECPrice.Width = 60;
            // 
            // ECQty
            // 
            this.ECQty.DataPropertyName = "Total Filled";
            this.ECQty.HeaderText = "Fill Total";
            this.ECQty.Name = "ECQty";
            this.ECQty.ReadOnly = true;
            this.ECQty.Width = 60;
            // 
            // ECAvgPrice
            // 
            this.ECAvgPrice.DataPropertyName = "Avg Price";
            this.ECAvgPrice.HeaderText = "Avg Prc";
            this.ECAvgPrice.Name = "ECAvgPrice";
            this.ECAvgPrice.ReadOnly = true;
            this.ECAvgPrice.Width = 60;
            // 
            // ECRemQty
            // 
            this.ECRemQty.DataPropertyName = "Leaves Qty";
            this.ECRemQty.HeaderText = "Leaves";
            this.ECRemQty.Name = "ECRemQty";
            this.ECRemQty.ReadOnly = true;
            this.ECRemQty.Width = 50;
            // 
            // ECSplitOrderID
            // 
            this.ECSplitOrderID.DataPropertyName = "SplitOrderID";
            this.ECSplitOrderID.HeaderText = "Fill Ord #";
            this.ECSplitOrderID.Name = "ECSplitOrderID";
            this.ECSplitOrderID.ReadOnly = true;
            this.ECSplitOrderID.Width = 60;
            // 
            // ECApp
            // 
            this.ECApp.DataPropertyName = "Applied";
            this.ECApp.HeaderText = "Applied";
            this.ECApp.Name = "ECApp";
            this.ECApp.ReadOnly = true;
            this.ECApp.Width = 50;
            // 
            // CreateRecord
            // 
            this.CreateRecord.DataPropertyName = "OrderID";
            this.CreateRecord.HeaderText = "Create Record";
            this.CreateRecord.Name = "CreateRecord";
            this.CreateRecord.Text = "Create Record";
            this.CreateRecord.UseColumnTextForButtonValue = true;
            this.CreateRecord.Width = 85;
            // 
            // FillOriginal
            // 
            this.FillOriginal.DataPropertyName = "OrderID";
            this.FillOriginal.HeaderText = "Fill Original";
            this.FillOriginal.Name = "FillOriginal";
            this.FillOriginal.Text = "Fill Original";
            this.FillOriginal.UseColumnTextForButtonValue = true;
            this.FillOriginal.Width = 80;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Location = new System.Drawing.Point(12, 11);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(87, 17);
            this.lblOrderNumber.TabIndex = 7;
            this.lblOrderNumber.Text = "Order Number:";
            this.lblOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOriginalQty
            // 
            this.lblOriginalQty.Location = new System.Drawing.Point(12, 39);
            this.lblOriginalQty.Name = "lblOriginalQty";
            this.lblOriginalQty.Size = new System.Drawing.Size(87, 17);
            this.lblOriginalQty.TabIndex = 8;
            this.lblOriginalQty.Text = "Original Qty:";
            this.lblOriginalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemainingQty
            // 
            this.lblRemainingQty.Location = new System.Drawing.Point(12, 66);
            this.lblRemainingQty.Name = "lblRemainingQty";
            this.lblRemainingQty.Size = new System.Drawing.Size(87, 16);
            this.lblRemainingQty.TabIndex = 9;
            this.lblRemainingQty.Text = "Remaining Qty:";
            this.lblRemainingQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkGTC
            // 
            this.chkGTC.AutoSize = true;
            this.chkGTC.Location = new System.Drawing.Point(262, 9);
            this.chkGTC.Name = "chkGTC";
            this.chkGTC.Size = new System.Drawing.Size(48, 17);
            this.chkGTC.TabIndex = 10;
            this.chkGTC.Text = "GTC";
            this.chkGTC.UseVisualStyleBackColor = true;
            // 
            // txtTP_ORD_NUMB
            // 
            this.txtTP_ORD_NUMB.Location = new System.Drawing.Point(92, 9);
            this.txtTP_ORD_NUMB.Name = "txtTP_ORD_NUMB";
            this.txtTP_ORD_NUMB.Size = new System.Drawing.Size(100, 20);
            this.txtTP_ORD_NUMB.TabIndex = 11;
            // 
            // cmdSendEmail
            // 
            this.cmdSendEmail.Location = new System.Drawing.Point(862, 646);
            this.cmdSendEmail.Name = "cmdSendEmail";
            this.cmdSendEmail.Size = new System.Drawing.Size(170, 23);
            this.cmdSendEmail.TabIndex = 12;
            this.cmdSendEmail.Text = "Email Data";
            this.cmdSendEmail.UseVisualStyleBackColor = true;
            this.cmdSendEmail.Visible = false;
            this.cmdSendEmail.Click += new System.EventHandler(this.cmdSendEmail_Click);
            // 
            // cmdDeSelect
            // 
            this.cmdDeSelect.Location = new System.Drawing.Point(808, 89);
            this.cmdDeSelect.Name = "cmdDeSelect";
            this.cmdDeSelect.Size = new System.Drawing.Size(79, 23);
            this.cmdDeSelect.TabIndex = 13;
            this.cmdDeSelect.Text = "De-select All";
            this.cmdDeSelect.UseVisualStyleBackColor = true;
            this.cmdDeSelect.Click += new System.EventHandler(this.cmdDeSelect_Click);
            // 
            // cmdFillCheckedItems
            // 
            this.cmdFillCheckedItems.Location = new System.Drawing.Point(231, 88);
            this.cmdFillCheckedItems.Name = "cmdFillCheckedItems";
            this.cmdFillCheckedItems.Size = new System.Drawing.Size(79, 23);
            this.cmdFillCheckedItems.TabIndex = 14;
            this.cmdFillCheckedItems.Text = "Fill Selected";
            this.cmdFillCheckedItems.UseVisualStyleBackColor = true;
            this.cmdFillCheckedItems.Click += new System.EventHandler(this.cmdFillCheckedItems_Click);
            // 
            // txtAMT
            // 
            this.txtAMT.Location = new System.Drawing.Point(92, 37);
            this.txtAMT.Name = "txtAMT";
            this.txtAMT.Size = new System.Drawing.Size(100, 20);
            this.txtAMT.TabIndex = 15;
            // 
            // txtRemainingQty
            // 
            this.txtRemainingQty.Location = new System.Drawing.Point(92, 64);
            this.txtRemainingQty.Name = "txtRemainingQty";
            this.txtRemainingQty.Size = new System.Drawing.Size(100, 20);
            this.txtRemainingQty.TabIndex = 16;
            // 
            // btnFillSelectedOriginal
            // 
            this.btnFillSelectedOriginal.Location = new System.Drawing.Point(893, 89);
            this.btnFillSelectedOriginal.Name = "btnFillSelectedOriginal";
            this.btnFillSelectedOriginal.Size = new System.Drawing.Size(139, 23);
            this.btnFillSelectedOriginal.TabIndex = 17;
            this.btnFillSelectedOriginal.Text = "Fill Original From Selected";
            this.btnFillSelectedOriginal.UseVisualStyleBackColor = true;
            this.btnFillSelectedOriginal.Click += new System.EventHandler(this.btnFillSelectedOriginal_Click);
            // 
            // txtSelectedQuantity
            // 
            this.txtSelectedQuantity.Location = new System.Drawing.Point(92, 90);
            this.txtSelectedQuantity.Name = "txtSelectedQuantity";
            this.txtSelectedQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtSelectedQuantity.TabIndex = 19;
            // 
            // lblSelectedQuantity
            // 
            this.lblSelectedQuantity.Location = new System.Drawing.Point(12, 92);
            this.lblSelectedQuantity.Name = "lblSelectedQuantity";
            this.lblSelectedQuantity.Size = new System.Drawing.Size(87, 16);
            this.lblSelectedQuantity.TabIndex = 18;
            this.lblSelectedQuantity.Text = "Selected Qty:";
            this.lblSelectedQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNewSplitFill
            // 
            this.btnNewSplitFill.Location = new System.Drawing.Point(808, 33);
            this.btnNewSplitFill.Name = "btnNewSplitFill";
            this.btnNewSplitFill.Size = new System.Drawing.Size(139, 23);
            this.btnNewSplitFill.TabIndex = 20;
            this.btnNewSplitFill.Text = "Fill Split Fill New";
            this.btnNewSplitFill.UseVisualStyleBackColor = true;
            this.btnNewSplitFill.Visible = false;
            this.btnNewSplitFill.Click += new System.EventHandler(this.btnNewSplitFill_Click);
            // 
            // lblProcessed
            // 
            this.lblProcessed.AutoSize = true;
            this.lblProcessed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessed.ForeColor = System.Drawing.Color.Red;
            this.lblProcessed.Location = new System.Drawing.Point(229, 49);
            this.lblProcessed.Name = "lblProcessed";
            this.lblProcessed.Size = new System.Drawing.Size(450, 13);
            this.lblProcessed.TabIndex = 21;
            this.lblProcessed.Text = "This Split Fill has been processed.  This tab is for informational purposes only." +
    "";
            // 
            // frmECSplitFills_Individual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 681);
            this.Controls.Add(this.lblProcessed);
            this.Controls.Add(this.btnNewSplitFill);
            this.Controls.Add(this.txtSelectedQuantity);
            this.Controls.Add(this.lblSelectedQuantity);
            this.Controls.Add(this.btnFillSelectedOriginal);
            this.Controls.Add(this.txtRemainingQty);
            this.Controls.Add(this.txtAMT);
            this.Controls.Add(this.cmdFillCheckedItems);
            this.Controls.Add(this.cmdDeSelect);
            this.Controls.Add(this.cmdSendEmail);
            this.Controls.Add(this.txtTP_ORD_NUMB);
            this.Controls.Add(this.chkGTC);
            this.Controls.Add(this.lblRemainingQty);
            this.Controls.Add(this.lblOriginalQty);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.dgvECOrders);
            this.Name = "frmECSplitFills_Individual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Split Fills";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmECSplitFills_Individual_FormClosing);
            this.Load += new System.EventHandler(this.frmSplitFills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvECOrders;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblOriginalQty;
        private System.Windows.Forms.Label lblRemainingQty;
        private System.Windows.Forms.CheckBox chkGTC;
        private System.Windows.Forms.TextBox txtTP_ORD_NUMB;
        private System.Windows.Forms.Button cmdSendEmail;
        private System.Windows.Forms.Button cmdDeSelect;
        private System.Windows.Forms.Button cmdFillCheckedItems;
        private System.Windows.Forms.TextBox txtAMT;
        private System.Windows.Forms.TextBox txtRemainingQty;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SFFill;
        private System.Windows.Forms.DataGridViewTextBoxColumn uLastPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECInd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMEQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECFilledQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECAvgPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECRemQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECSplitOrderID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ECApp;
        private System.Windows.Forms.DataGridViewButtonColumn CreateRecord;
        private System.Windows.Forms.DataGridViewButtonColumn FillOriginal;
        private System.Windows.Forms.Button btnFillSelectedOriginal;
        private System.Windows.Forms.TextBox txtSelectedQuantity;
        private System.Windows.Forms.Label lblSelectedQuantity;
        private System.Windows.Forms.Button btnNewSplitFill;
        private System.Windows.Forms.Label lblProcessed;
    }
}