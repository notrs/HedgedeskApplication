namespace HedgedeskApplication
{
    partial class frmOrdersHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOrders = new dgvCustom();
            this.OrdAcct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdInd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdComm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdFilled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkGTC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkEO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OrderNumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EC = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Cancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrigQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyFilled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RmQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrdAcct,
            this.OrdInd,
            this.OrdQty,
            this.OrdMonth,
            this.OrdYear,
            this.OrdComm,
            this.OrdPrice,
            this.OrdFilled,
            this.Type,
            this.Comp,
            this.chkGTC,
            this.chkEO,
            this.OrderNumb,
            this.CardNumber,
            this.EC,
            this.Cancel,
            this.Status,
            this.Comments,
            this.OrigQty,
            this.QtyFilled,
            this.RmQty,
            this.OrderDate});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrders.Location = new System.Drawing.Point(3, 1);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 10;
            this.dgvOrders.Size = new System.Drawing.Size(1087, 112);
            this.dgvOrders.TabIndex = 5;
            this.dgvOrders.TabStop = false;
            // 
            // OrdAcct
            // 
            this.OrdAcct.DataPropertyName = "A/C";
            this.OrdAcct.HeaderText = "A/C";
            this.OrdAcct.Name = "OrdAcct";
            this.OrdAcct.Width = 32;
            // 
            // OrdInd
            // 
            this.OrdInd.DataPropertyName = "B/S";
            this.OrdInd.HeaderText = "B/S";
            this.OrdInd.Name = "OrdInd";
            this.OrdInd.Width = 32;
            // 
            // OrdQty
            // 
            this.OrdQty.DataPropertyName = "Qty";
            this.OrdQty.HeaderText = "Qty";
            this.OrdQty.Name = "OrdQty";
            this.OrdQty.Width = 29;
            // 
            // OrdMonth
            // 
            this.OrdMonth.DataPropertyName = "Month";
            this.OrdMonth.HeaderText = "Month";
            this.OrdMonth.Name = "OrdMonth";
            this.OrdMonth.Width = 45;
            // 
            // OrdYear
            // 
            this.OrdYear.DataPropertyName = "Year";
            this.OrdYear.HeaderText = "Year";
            this.OrdYear.Name = "OrdYear";
            this.OrdYear.Width = 40;
            // 
            // OrdComm
            // 
            this.OrdComm.DataPropertyName = "Comm";
            this.OrdComm.HeaderText = "Comm";
            this.OrdComm.Name = "OrdComm";
            this.OrdComm.Width = 45;
            // 
            // OrdPrice
            // 
            this.OrdPrice.DataPropertyName = "Price";
            this.OrdPrice.HeaderText = "Price";
            this.OrdPrice.Name = "OrdPrice";
            this.OrdPrice.Width = 55;
            // 
            // OrdFilled
            // 
            this.OrdFilled.DataPropertyName = "Filled";
            this.OrdFilled.HeaderText = "Filled";
            this.OrdFilled.Name = "OrdFilled";
            this.OrdFilled.Width = 55;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.Width = 37;
            // 
            // Comp
            // 
            this.Comp.DataPropertyName = "Comp";
            this.Comp.HeaderText = "Comp";
            this.Comp.Name = "Comp";
            this.Comp.Width = 40;
            // 
            // chkGTC
            // 
            this.chkGTC.DataPropertyName = "GTC";
            this.chkGTC.HeaderText = "GTC";
            this.chkGTC.Name = "chkGTC";
            this.chkGTC.Width = 35;
            // 
            // chkEO
            // 
            this.chkEO.DataPropertyName = "EO";
            this.chkEO.HeaderText = "CME";
            this.chkEO.Name = "chkEO";
            this.chkEO.Width = 37;
            // 
            // OrderNumb
            // 
            this.OrderNumb.DataPropertyName = "Order No.";
            this.OrderNumb.HeaderText = "Order No.";
            this.OrderNumb.Name = "OrderNumb";
            this.OrderNumb.ReadOnly = true;
            this.OrderNumb.Width = 85;
            // 
            // CardNumber
            // 
            this.CardNumber.DataPropertyName = "Card #";
            this.CardNumber.HeaderText = "Card #";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.Width = 80;
            // 
            // EC
            // 
            this.EC.DataPropertyName = "Order No.";
            this.EC.HeaderText = "CME";
            this.EC.Name = "EC";
            this.EC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EC.Text = "Revise";
            this.EC.ToolTipText = "Order No.";
            this.EC.UseColumnTextForButtonValue = true;
            this.EC.Width = 47;
            // 
            // Cancel
            // 
            this.Cancel.DataPropertyName = "Order No.";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.Cancel.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cancel.HeaderText = "Can";
            this.Cancel.Name = "Cancel";
            this.Cancel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cancel.Text = "Can";
            this.Cancel.ToolTipText = "Cancel Order";
            this.Cancel.UseColumnTextForButtonValue = true;
            this.Cancel.Width = 33;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 55;
            // 
            // Comments
            // 
            this.Comments.DataPropertyName = "Comments";
            this.Comments.HeaderText = "Comments";
            this.Comments.Name = "Comments";
            this.Comments.Width = 80;
            // 
            // OrigQty
            // 
            this.OrigQty.DataPropertyName = "Orig Qty";
            this.OrigQty.HeaderText = "CME Qty";
            this.OrigQty.Name = "OrigQty";
            this.OrigQty.ReadOnly = true;
            this.OrigQty.Width = 55;
            // 
            // QtyFilled
            // 
            this.QtyFilled.DataPropertyName = "FilledQty";
            this.QtyFilled.HeaderText = "Filled";
            this.QtyFilled.Name = "QtyFilled";
            this.QtyFilled.ReadOnly = true;
            this.QtyFilled.Width = 38;
            // 
            // RmQty
            // 
            this.RmQty.DataPropertyName = "Rm Qty";
            this.RmQty.HeaderText = "Leaves";
            this.RmQty.Name = "RmQty";
            this.RmQty.ReadOnly = true;
            this.RmQty.Width = 48;
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "Order Date";
            this.OrderDate.HeaderText = "Order Date";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.Width = 70;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 266);
            this.Controls.Add(this.dgvOrders);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public dgvCustom dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdAcct;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdInd;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdComm;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdFilled;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkGTC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkEO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewButtonColumn EC;
        private System.Windows.Forms.DataGridViewButtonColumn Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrigQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyFilled;
        private System.Windows.Forms.DataGridViewTextBoxColumn RmQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
    }
}