namespace HedgedeskApplication
{
    partial class frmPurchaseSettle
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dtpLastPSSettlementDate = new System.Windows.Forms.DateTimePicker();
            this.dtpSettlementCutOffDate = new System.Windows.Forms.DateTimePicker();
            this.btnRunPSRoutine = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrentPSStartDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentPSEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpUnSettleDate = new System.Windows.Forms.DateTimePicker();
            this.btnUnsettle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnsettleCurrentPSStartDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUnsettleCurrentPSEndDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUnsettleSettleDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpLastTransferDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTransferOrdersToPS = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTransferToGEM = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.dtpLastPSSettlementDate);
            this.groupBox1.Controls.Add(this.dtpSettlementCutOffDate);
            this.groupBox1.Controls.Add(this.btnRunPSRoutine);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCurrentPSStartDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCurrentPSEndDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 174);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Purchase Settle";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(370, 78);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dtpLastPSSettlementDate
            // 
            this.dtpLastPSSettlementDate.Location = new System.Drawing.Point(164, 79);
            this.dtpLastPSSettlementDate.Name = "dtpLastPSSettlementDate";
            this.dtpLastPSSettlementDate.Size = new System.Drawing.Size(200, 20);
            this.dtpLastPSSettlementDate.TabIndex = 2;
            // 
            // dtpSettlementCutOffDate
            // 
            this.dtpSettlementCutOffDate.Location = new System.Drawing.Point(164, 37);
            this.dtpSettlementCutOffDate.Name = "dtpSettlementCutOffDate";
            this.dtpSettlementCutOffDate.Size = new System.Drawing.Size(200, 20);
            this.dtpSettlementCutOffDate.TabIndex = 1;
            // 
            // btnRunPSRoutine
            // 
            this.btnRunPSRoutine.Location = new System.Drawing.Point(426, 129);
            this.btnRunPSRoutine.Name = "btnRunPSRoutine";
            this.btnRunPSRoutine.Size = new System.Drawing.Size(163, 23);
            this.btnRunPSRoutine.TabIndex = 4;
            this.btnRunPSRoutine.Text = "Run Purchase Settle Routine";
            this.btnRunPSRoutine.UseVisualStyleBackColor = true;
            this.btnRunPSRoutine.Click += new System.EventHandler(this.btnRunPSRoutine_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current Period Start Date:";
            // 
            // txtCurrentPSStartDate
            // 
            this.txtCurrentPSStartDate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtCurrentPSStartDate.Location = new System.Drawing.Point(164, 105);
            this.txtCurrentPSStartDate.Name = "txtCurrentPSStartDate";
            this.txtCurrentPSStartDate.Size = new System.Drawing.Size(147, 20);
            this.txtCurrentPSStartDate.TabIndex = 6;
            this.txtCurrentPSStartDate.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current Period End Date:";
            // 
            // txtCurrentPSEndDate
            // 
            this.txtCurrentPSEndDate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtCurrentPSEndDate.Location = new System.Drawing.Point(164, 131);
            this.txtCurrentPSEndDate.Name = "txtCurrentPSEndDate";
            this.txtCurrentPSEndDate.Size = new System.Drawing.Size(147, 20);
            this.txtCurrentPSEndDate.TabIndex = 4;
            this.txtCurrentPSEndDate.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Settlement Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Settlement Date:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpUnSettleDate);
            this.groupBox2.Controls.Add(this.btnUnsettle);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtUnsettleCurrentPSStartDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtUnsettleCurrentPSEndDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtUnsettleSettleDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(17, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 174);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Un-Settle";
            // 
            // dtpUnSettleDate
            // 
            this.dtpUnSettleDate.Location = new System.Drawing.Point(164, 33);
            this.dtpUnSettleDate.Name = "dtpUnSettleDate";
            this.dtpUnSettleDate.Size = new System.Drawing.Size(200, 20);
            this.dtpUnSettleDate.TabIndex = 5;
            // 
            // btnUnsettle
            // 
            this.btnUnsettle.Location = new System.Drawing.Point(421, 129);
            this.btnUnsettle.Name = "btnUnsettle";
            this.btnUnsettle.Size = new System.Drawing.Size(163, 23);
            this.btnUnsettle.TabIndex = 6;
            this.btnUnsettle.Text = "Un-Settle";
            this.btnUnsettle.UseVisualStyleBackColor = true;
            this.btnUnsettle.Click += new System.EventHandler(this.btnUnsettle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Current Period Start Date:";
            // 
            // txtUnsettleCurrentPSStartDate
            // 
            this.txtUnsettleCurrentPSStartDate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtUnsettleCurrentPSStartDate.Location = new System.Drawing.Point(164, 105);
            this.txtUnsettleCurrentPSStartDate.Name = "txtUnsettleCurrentPSStartDate";
            this.txtUnsettleCurrentPSStartDate.Size = new System.Drawing.Size(147, 20);
            this.txtUnsettleCurrentPSStartDate.TabIndex = 6;
            this.txtUnsettleCurrentPSStartDate.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Current Period End Date:";
            // 
            // txtUnsettleCurrentPSEndDate
            // 
            this.txtUnsettleCurrentPSEndDate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtUnsettleCurrentPSEndDate.Location = new System.Drawing.Point(164, 131);
            this.txtUnsettleCurrentPSEndDate.Name = "txtUnsettleCurrentPSEndDate";
            this.txtUnsettleCurrentPSEndDate.Size = new System.Drawing.Size(147, 20);
            this.txtUnsettleCurrentPSEndDate.TabIndex = 4;
            this.txtUnsettleCurrentPSEndDate.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Last Settlement Date:";
            // 
            // txtUnsettleSettleDate
            // 
            this.txtUnsettleSettleDate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtUnsettleSettleDate.Location = new System.Drawing.Point(164, 79);
            this.txtUnsettleSettleDate.Name = "txtUnsettleSettleDate";
            this.txtUnsettleSettleDate.Size = new System.Drawing.Size(147, 20);
            this.txtUnsettleSettleDate.TabIndex = 2;
            this.txtUnsettleSettleDate.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(72, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Un-Settle Date:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpLastTransferDate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnTransferOrdersToPS);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(607, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transfer Orders to PS Tables";
            // 
            // dtpLastTransferDate
            // 
            this.dtpLastTransferDate.Enabled = false;
            this.dtpLastTransferDate.Location = new System.Drawing.Point(164, 39);
            this.dtpLastTransferDate.Name = "dtpLastTransferDate";
            this.dtpLastTransferDate.Size = new System.Drawing.Size(200, 20);
            this.dtpLastTransferDate.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Last Transfer Date:";
            // 
            // btnTransferOrdersToPS
            // 
            this.btnTransferOrdersToPS.Location = new System.Drawing.Point(426, 57);
            this.btnTransferOrdersToPS.Name = "btnTransferOrdersToPS";
            this.btnTransferOrdersToPS.Size = new System.Drawing.Size(163, 23);
            this.btnTransferOrdersToPS.TabIndex = 0;
            this.btnTransferOrdersToPS.Text = "Transfer Orders to PS Tables";
            this.btnTransferOrdersToPS.UseVisualStyleBackColor = true;
            this.btnTransferOrdersToPS.Click += new System.EventHandler(this.btnTransferOrdersToPS_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTransferToGEM);
            this.groupBox4.Location = new System.Drawing.Point(17, 497);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(607, 44);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transfer To GEM";
            // 
            // btnTransferToGEM
            // 
            this.btnTransferToGEM.Location = new System.Drawing.Point(421, 15);
            this.btnTransferToGEM.Name = "btnTransferToGEM";
            this.btnTransferToGEM.Size = new System.Drawing.Size(163, 23);
            this.btnTransferToGEM.TabIndex = 6;
            this.btnTransferToGEM.Text = "Transfer to GEM";
            this.btnTransferToGEM.UseVisualStyleBackColor = true;
            this.btnTransferToGEM.Click += new System.EventHandler(this.btnTransferToGEM_Click);
            // 
            // frmPurchaseSettle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 553);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPurchaseSettle";
            this.Text = "frmPurchaseSettle";
            this.Load += new System.EventHandler(this.frmPurchaseSettle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrentPSStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentPSEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunPSRoutine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUnsettle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnsettleCurrentPSStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUnsettleCurrentPSEndDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUnsettleSettleDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpSettlementCutOffDate;
        private System.Windows.Forms.DateTimePicker dtpUnSettleDate;
        private System.Windows.Forms.DateTimePicker dtpLastPSSettlementDate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpLastTransferDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTransferOrdersToPS;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnTransferToGEM;
    }
}