namespace HedgedeskApplication
{
    partial class frmOrderFills
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvOrders = new dgvCustom();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.FilledPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Yr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new HedgedeskApplication.Classes.CalendarDateColumn();
            this.Amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.tabControl1.SuspendLayout();
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvOrders);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(786, 594);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Order Fills";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FilledPrice,
            this.OrderNumber,
            this.Comm,
            this.Mon,
            this.Yr,
            this.Acct,
            this.Date,
            this.Amt,
            this.Price});
            this.dgvOrders.Location = new System.Drawing.Point(7, 3);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(773, 579);
            this.dgvOrders.TabIndex = 2;
            this.dgvOrders.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvOrders_CellBeginEdit);
            this.dgvOrders.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellLeave);
            this.dgvOrders.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvOrders_CellValidating);
            this.dgvOrders.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvOrders_RowValidating);
            this.dgvOrders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOrders_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 620);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // FilledPrice
            // 
            this.FilledPrice.DataPropertyName = "FilledPrice";
            this.FilledPrice.HeaderText = "Filled Price";
            this.FilledPrice.Name = "FilledPrice";
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "OrderNumber";
            this.OrderNumber.HeaderText = "Order Number";
            this.OrderNumber.Name = "OrderNumber";
            // 
            // Comm
            // 
            this.Comm.DataPropertyName = "Comm";
            this.Comm.HeaderText = "Comm";
            this.Comm.Name = "Comm";
            this.Comm.ReadOnly = true;
            this.Comm.Width = 50;
            // 
            // Mon
            // 
            this.Mon.DataPropertyName = "Mon";
            this.Mon.HeaderText = "Mon";
            this.Mon.Name = "Mon";
            this.Mon.ReadOnly = true;
            this.Mon.Width = 60;
            // 
            // Yr
            // 
            this.Yr.DataPropertyName = "Yr";
            this.Yr.HeaderText = "Yr";
            this.Yr.Name = "Yr";
            this.Yr.ReadOnly = true;
            this.Yr.Width = 60;
            // 
            // Acct
            // 
            this.Acct.DataPropertyName = "Acct";
            this.Acct.HeaderText = "Acct";
            this.Acct.Name = "Acct";
            this.Acct.ReadOnly = true;
            this.Acct.Width = 50;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "CREATED_DATE";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Amt
            // 
            this.Amt.DataPropertyName = "AMT";
            this.Amt.HeaderText = "Qty";
            this.Amt.Name = "Amt";
            this.Amt.ReadOnly = true;
            this.Amt.Width = 75;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // frmOrderFills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 662);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmOrderFills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Fills";
            this.Load += new System.EventHandler(this.frmOrderFills_Load);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tabPage1;
        private dgvCustom dgvOrders;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilledPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Yr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acct;
        private Classes.CalendarDateColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}