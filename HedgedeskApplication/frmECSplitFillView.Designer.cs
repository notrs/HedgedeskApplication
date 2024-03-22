namespace HedgedeskApplication
{
    partial class frmECSplitFillView
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
            this.uLastPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradeCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECInd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMEQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECFilledQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECApp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.txtTP_ORD_NUMB = new System.Windows.Forms.TextBox();
            this.btnNewSplitFill = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
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
            this.uLastPrice,
            this.TradeCompany,
            this.OrderNo,
            this.ECCardNumber,
            this.ECStatus,
            this.ECInd,
            this.CMEQty,
            this.ECFilledQty,
            this.ECPrice,
            this.ECQty,
            this.ECApp});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvECOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvECOrders.Location = new System.Drawing.Point(0, 62);
            this.dgvECOrders.MultiSelect = false;
            this.dgvECOrders.Name = "dgvECOrders";
            this.dgvECOrders.RowHeadersWidth = 15;
            this.dgvECOrders.Size = new System.Drawing.Size(1043, 429);
            this.dgvECOrders.TabIndex = 6;
            // 
            // uLastPrice
            // 
            this.uLastPrice.DataPropertyName = "unconvertedLastPrice";
            this.uLastPrice.HeaderText = "uLastPrice";
            this.uLastPrice.Name = "uLastPrice";
            this.uLastPrice.Visible = false;
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
            // 
            // ECCardNumber
            // 
            this.ECCardNumber.DataPropertyName = "CardNumber";
            this.ECCardNumber.HeaderText = "Card #";
            this.ECCardNumber.Name = "ECCardNumber";
            this.ECCardNumber.ReadOnly = true;
            // 
            // ECStatus
            // 
            this.ECStatus.DataPropertyName = "Trans Type";
            this.ECStatus.HeaderText = "Type";
            this.ECStatus.Name = "ECStatus";
            this.ECStatus.ReadOnly = true;
            // 
            // ECInd
            // 
            this.ECInd.DataPropertyName = "Symbol";
            this.ECInd.HeaderText = "Symbol";
            this.ECInd.Name = "ECInd";
            this.ECInd.ReadOnly = true;
            // 
            // CMEQty
            // 
            this.CMEQty.DataPropertyName = "Orig Qty";
            this.CMEQty.HeaderText = "Orig Qty";
            this.CMEQty.Name = "CMEQty";
            this.CMEQty.ReadOnly = true;
            // 
            // ECFilledQty
            // 
            this.ECFilledQty.DataPropertyName = "Fill Quantity";
            this.ECFilledQty.HeaderText = "Fill Qty";
            this.ECFilledQty.Name = "ECFilledQty";
            this.ECFilledQty.ReadOnly = true;
            // 
            // ECPrice
            // 
            this.ECPrice.DataPropertyName = "Last Price";
            this.ECPrice.HeaderText = "Last Prc";
            this.ECPrice.Name = "ECPrice";
            this.ECPrice.ReadOnly = true;
            // 
            // ECQty
            // 
            this.ECQty.DataPropertyName = "Total Filled";
            this.ECQty.HeaderText = "Fill Total";
            this.ECQty.Name = "ECQty";
            this.ECQty.ReadOnly = true;
            // 
            // ECApp
            // 
            this.ECApp.DataPropertyName = "Applied";
            this.ECApp.HeaderText = "Applied";
            this.ECApp.Name = "ECApp";
            this.ECApp.ReadOnly = true;
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
            // txtTP_ORD_NUMB
            // 
            this.txtTP_ORD_NUMB.Location = new System.Drawing.Point(92, 9);
            this.txtTP_ORD_NUMB.Name = "txtTP_ORD_NUMB";
            this.txtTP_ORD_NUMB.Size = new System.Drawing.Size(100, 20);
            this.txtTP_ORD_NUMB.TabIndex = 11;
            // 
            // btnNewSplitFill
            // 
            this.btnNewSplitFill.Location = new System.Drawing.Point(914, 12);
            this.btnNewSplitFill.Name = "btnNewSplitFill";
            this.btnNewSplitFill.Size = new System.Drawing.Size(118, 23);
            this.btnNewSplitFill.TabIndex = 20;
            this.btnNewSplitFill.Text = "Process Split Fill";
            this.btnNewSplitFill.UseVisualStyleBackColor = true;
            this.btnNewSplitFill.Click += new System.EventHandler(this.btnNewSplitFill_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(914, 513);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblProcessed
            // 
            this.lblProcessed.AutoSize = true;
            this.lblProcessed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessed.ForeColor = System.Drawing.Color.Red;
            this.lblProcessed.Location = new System.Drawing.Point(274, 12);
            this.lblProcessed.Name = "lblProcessed";
            this.lblProcessed.Size = new System.Drawing.Size(450, 13);
            this.lblProcessed.TabIndex = 22;
            this.lblProcessed.Text = "This Split Fill has been processed.  This tab is for informational purposes only." +
    "";
            // 
            // frmECSplitFillView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 548);
            this.Controls.Add(this.lblProcessed);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNewSplitFill);
            this.Controls.Add(this.txtTP_ORD_NUMB);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.dgvECOrders);
            this.Name = "frmECSplitFillView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Split Fills";
            this.Load += new System.EventHandler(this.frmSplitFills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvECOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvECOrders;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TextBox txtTP_ORD_NUMB;
        private System.Windows.Forms.Button btnNewSplitFill;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn uLastPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECInd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMEQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECFilledQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECQty;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ECApp;
        private System.Windows.Forms.Label lblProcessed;
    }
}