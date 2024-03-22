namespace HedgedeskApplication
{
    partial class frmMoveMonthEndTrades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTradeCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBrokers = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.txtNumberToMove = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTradeYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTradeMonth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTradeCompTo = new System.Windows.Forms.TextBox();
            this.btnUpdateMoveToCompany = new System.Windows.Forms.Button();
            this.dgvMoveTradesList = new dgvCustom();
            this.ContractDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HedgeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoveTradesList)).BeginInit();
            this.SuspendLayout();
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(18, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(153, 13);
            this.label29.TabIndex = 46;
            this.label29.Text = "Move To Trade Company:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTradeCount);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cboBrokers);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.btnMove);
            this.groupBox3.Controls.Add(this.txtNumberToMove);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtTradeYear);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtTradeMonth);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtTradeCompTo);
            this.groupBox3.Controls.Add(this.btnUpdateMoveToCompany);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(923, 120);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Move Trades";
            // 
            // txtTradeCount
            // 
            this.txtTradeCount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTradeCount.Enabled = false;
            this.txtTradeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTradeCount.Location = new System.Drawing.Point(853, 48);
            this.txtTradeCount.Name = "txtTradeCount";
            this.txtTradeCount.Size = new System.Drawing.Size(46, 20);
            this.txtTradeCount.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(796, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Count:";
            // 
            // cboBrokers
            // 
            this.cboBrokers.FormattingEnabled = true;
            this.cboBrokers.Location = new System.Drawing.Point(178, 54);
            this.cboBrokers.Name = "cboBrokers";
            this.cboBrokers.Size = new System.Drawing.Size(135, 21);
            this.cboBrokers.TabIndex = 59;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(824, 82);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(648, 82);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 57;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(739, 82);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 56;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // txtNumberToMove
            // 
            this.txtNumberToMove.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumberToMove.Location = new System.Drawing.Point(853, 21);
            this.txtNumberToMove.Name = "txtNumberToMove";
            this.txtNumberToMove.Size = new System.Drawing.Size(46, 20);
            this.txtNumberToMove.TabIndex = 55;
            this.txtNumberToMove.TextChanged += new System.EventHandler(this.txtNumberToMove_TextChanged);
            this.txtNumberToMove.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumberToMove_KeyDown);
            this.txtNumberToMove.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberToMove_KeyPress);
            this.txtNumberToMove.Leave += new System.EventHandler(this.txtNumberToMove_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(736, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Number to Move:";
            // 
            // txtTradeYear
            // 
            this.txtTradeYear.BackColor = System.Drawing.SystemColors.Window;
            this.txtTradeYear.Location = new System.Drawing.Point(512, 49);
            this.txtTradeYear.Name = "txtTradeYear";
            this.txtTradeYear.Size = new System.Drawing.Size(46, 20);
            this.txtTradeYear.TabIndex = 53;
            this.txtTradeYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTradeYear_KeyPress);
            this.txtTradeYear.Leave += new System.EventHandler(this.txtTradeYear_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(432, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Trade Year:";
            // 
            // txtTradeMonth
            // 
            this.txtTradeMonth.BackColor = System.Drawing.SystemColors.Window;
            this.txtTradeMonth.Location = new System.Drawing.Point(512, 19);
            this.txtTradeMonth.Name = "txtTradeMonth";
            this.txtTradeMonth.Size = new System.Drawing.Size(46, 20);
            this.txtTradeMonth.TabIndex = 51;
            this.txtTradeMonth.TextChanged += new System.EventHandler(this.txtTradeMonth_TextChanged);
            this.txtTradeMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTradeMonth_KeyPress);
            this.txtTradeMonth.Leave += new System.EventHandler(this.txtTradeMonth_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(423, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Trade Month:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Move From Trade Company:";
            // 
            // txtTradeCompTo
            // 
            this.txtTradeCompTo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTradeCompTo.Enabled = false;
            this.txtTradeCompTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTradeCompTo.Location = new System.Drawing.Point(177, 21);
            this.txtTradeCompTo.Name = "txtTradeCompTo";
            this.txtTradeCompTo.Size = new System.Drawing.Size(46, 20);
            this.txtTradeCompTo.TabIndex = 47;
            // 
            // btnUpdateMoveToCompany
            // 
            this.btnUpdateMoveToCompany.Location = new System.Drawing.Point(238, 19);
            this.btnUpdateMoveToCompany.Name = "btnUpdateMoveToCompany";
            this.btnUpdateMoveToCompany.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateMoveToCompany.TabIndex = 3;
            this.btnUpdateMoveToCompany.Text = "Update";
            this.btnUpdateMoveToCompany.UseVisualStyleBackColor = true;
            this.btnUpdateMoveToCompany.Click += new System.EventHandler(this.btnUpdateMoveToCompany_Click);
            // 
            // dgvMoveTradesList
            // 
            this.dgvMoveTradesList.AllowUserToAddRows = false;
            this.dgvMoveTradesList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvMoveTradesList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMoveTradesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContractDetailID,
            this.OrderNumber,
            this.Commodity,
            this.Month,
            this.Year,
            this.Price,
            this.HedgeQty,
            this.ContractQty});
            this.dgvMoveTradesList.Location = new System.Drawing.Point(12, 138);
            this.dgvMoveTradesList.Name = "dgvMoveTradesList";
            this.dgvMoveTradesList.RowHeadersWidth = 20;
            this.dgvMoveTradesList.Size = new System.Drawing.Size(923, 437);
            this.dgvMoveTradesList.TabIndex = 0;
            // 
            // ContractDetailID
            // 
            this.ContractDetailID.DataPropertyName = "contractDetailID";
            this.ContractDetailID.HeaderText = "Contract ID";
            this.ContractDetailID.Name = "ContractDetailID";
            this.ContractDetailID.Width = 150;
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "HedgeTradeID";
            this.OrderNumber.HeaderText = "Order Number";
            this.OrderNumber.Name = "OrderNumber";
            // 
            // Commodity
            // 
            this.Commodity.DataPropertyName = "TP_COMM";
            this.Commodity.HeaderText = "Commodity";
            this.Commodity.Name = "Commodity";
            this.Commodity.Width = 150;
            // 
            // Month
            // 
            this.Month.DataPropertyName = "TP_MON";
            this.Month.HeaderText = "Month";
            this.Month.Name = "Month";
            // 
            // Year
            // 
            this.Year.DataPropertyName = "TP_YEAR";
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "TP_PRICE";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // HedgeQty
            // 
            this.HedgeQty.DataPropertyName = "TP_AMT";
            this.HedgeQty.HeaderText = "Hedge Qty";
            this.HedgeQty.Name = "HedgeQty";
            // 
            // ContractQty
            // 
            this.ContractQty.DataPropertyName = "Quantity";
            this.ContractQty.HeaderText = "Contract Qty";
            this.ContractQty.Name = "ContractQty";
            // 
            // frmMoveMonthEndTrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 612);
            this.Controls.Add(this.dgvMoveTradesList);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmMoveMonthEndTrades";
            this.Text = "Hedge Settings";
            this.Load += new System.EventHandler(this.frmHedgeSettings_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoveTradesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdateMoveToCompany;
        private System.Windows.Forms.Label label29;
        private dgvCustom dgvMoveTradesList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.TextBox txtNumberToMove;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTradeYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTradeMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn HedgeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractQty;
        private System.Windows.Forms.TextBox txtTradeCompTo;
        private System.Windows.Forms.ComboBox cboBrokers;
        private System.Windows.Forms.TextBox txtTradeCount;
        private System.Windows.Forms.Label label5;
    }
}