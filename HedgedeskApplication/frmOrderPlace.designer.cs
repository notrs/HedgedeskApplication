namespace HedgedeskApplication
{
    partial class frmOrderPlace
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
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GTC = new System.Windows.Forms.CheckBox();
            this.txtComp = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkWeightedAverage = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWeightedAverage = new System.Windows.Forms.TextBox();
            this.lstLastFiveCHPrices = new System.Windows.Forms.ListBox();
            this.chkCMEPrice = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCMEPrice = new System.Windows.Forms.TextBox();
            this.cboAcct = new AutoCompleteComboBox();
            this.cboMon = new AutoCompleteComboBox();
            this.txtInd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCommodities = new System.Windows.Forms.ComboBox();
            this.cboOrderType = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.btnLimitOrder = new System.Windows.Forms.Button();
            this.btnMarketOrder = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSavedWeightedAverage = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSavedPosition = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(158, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 16);
            this.label11.TabIndex = 41;
            this.label11.Text = "B/S";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(553, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 16);
            this.label10.TabIndex = 40;
            this.label10.Text = "Qty";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(210, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "Month";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(274, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 38;
            this.label8.Text = "Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(321, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Comm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(602, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Last Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(497, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "GTC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(443, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Comp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(81, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "A/C";
            // 
            // GTC
            // 
            this.GTC.AutoSize = true;
            this.GTC.Location = new System.Drawing.Point(511, 46);
            this.GTC.Name = "GTC";
            this.GTC.Size = new System.Drawing.Size(15, 14);
            this.GTC.TabIndex = 13;
            this.GTC.UseVisualStyleBackColor = true;
            // 
            // txtComp
            // 
            this.txtComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComp.Location = new System.Drawing.Point(449, 40);
            this.txtComp.Name = "txtComp";
            this.txtComp.Size = new System.Drawing.Size(37, 20);
            this.txtComp.TabIndex = 0;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(602, 40);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(72, 20);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // txtYear
            // 
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Location = new System.Drawing.Point(277, 40);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(36, 20);
            this.txtYear.TabIndex = 11;
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(547, 40);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(49, 20);
            this.txtQty.TabIndex = 3;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtSavedPosition);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtSavedWeightedAverage);
            this.panel1.Controls.Add(this.chkWeightedAverage);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtWeightedAverage);
            this.panel1.Controls.Add(this.lstLastFiveCHPrices);
            this.panel1.Controls.Add(this.chkCMEPrice);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCMEPrice);
            this.panel1.Controls.Add(this.cboAcct);
            this.panel1.Controls.Add(this.cboMon);
            this.panel1.Controls.Add(this.txtInd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cboCommodities);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboOrderType);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtComp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.GTC);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 200);
            this.panel1.TabIndex = 1;
            this.panel1.TabStop = true;
            // 
            // chkWeightedAverage
            // 
            this.chkWeightedAverage.AutoSize = true;
            this.chkWeightedAverage.Location = new System.Drawing.Point(680, 96);
            this.chkWeightedAverage.Name = "chkWeightedAverage";
            this.chkWeightedAverage.Size = new System.Drawing.Size(15, 14);
            this.chkWeightedAverage.TabIndex = 60;
            this.chkWeightedAverage.UseVisualStyleBackColor = true;
            this.chkWeightedAverage.CheckedChanged += new System.EventHandler(this.chkWeightedAverage_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(426, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 16);
            this.label13.TabIndex = 59;
            this.label13.Text = "Last 5 CH Prices";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(446, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 16);
            this.label12.TabIndex = 57;
            this.label12.Text = "Weighted Avg. Price";
            // 
            // txtWeightedAverage
            // 
            this.txtWeightedAverage.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtWeightedAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeightedAverage.Enabled = false;
            this.txtWeightedAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeightedAverage.Location = new System.Drawing.Point(602, 92);
            this.txtWeightedAverage.Name = "txtWeightedAverage";
            this.txtWeightedAverage.Size = new System.Drawing.Size(72, 20);
            this.txtWeightedAverage.TabIndex = 56;
            // 
            // lstLastFiveCHPrices
            // 
            this.lstLastFiveCHPrices.FormattingEnabled = true;
            this.lstLastFiveCHPrices.Location = new System.Drawing.Point(554, 118);
            this.lstLastFiveCHPrices.Name = "lstLastFiveCHPrices";
            this.lstLastFiveCHPrices.Size = new System.Drawing.Size(120, 69);
            this.lstLastFiveCHPrices.TabIndex = 55;
            this.lstLastFiveCHPrices.SelectedIndexChanged += new System.EventHandler(this.lstLastFiveCHPrices_SelectedIndexChanged);
            // 
            // chkCMEPrice
            // 
            this.chkCMEPrice.AutoSize = true;
            this.chkCMEPrice.Location = new System.Drawing.Point(680, 68);
            this.chkCMEPrice.Name = "chkCMEPrice";
            this.chkCMEPrice.Size = new System.Drawing.Size(15, 14);
            this.chkCMEPrice.TabIndex = 54;
            this.chkCMEPrice.UseVisualStyleBackColor = true;
            this.chkCMEPrice.CheckedChanged += new System.EventHandler(this.chkCMEPrice_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(516, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "CME Price";
            // 
            // txtCMEPrice
            // 
            this.txtCMEPrice.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtCMEPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCMEPrice.Enabled = false;
            this.txtCMEPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCMEPrice.Location = new System.Drawing.Point(602, 66);
            this.txtCMEPrice.Name = "txtCMEPrice";
            this.txtCMEPrice.Size = new System.Drawing.Size(72, 20);
            this.txtCMEPrice.TabIndex = 52;
            // 
            // cboAcct
            // 
            this.cboAcct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboAcct.FormattingEnabled = true;
            this.cboAcct.Location = new System.Drawing.Point(78, 39);
            this.cboAcct.Name = "cboAcct";
            this.cboAcct.Size = new System.Drawing.Size(65, 21);
            this.cboAcct.Strict = true;
            this.cboAcct.TabIndex = 1;
            // 
            // cboMon
            // 
            this.cboMon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Location = new System.Drawing.Point(198, 39);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(65, 21);
            this.cboMon.Strict = true;
            this.cboMon.TabIndex = 10;
            // 
            // txtInd
            // 
            this.txtInd.Location = new System.Drawing.Point(151, 40);
            this.txtInd.Name = "txtInd";
            this.txtInd.Size = new System.Drawing.Size(40, 20);
            this.txtInd.TabIndex = 9;
            this.txtInd.TextChanged += new System.EventHandler(this.txtInd_TextChanged);
            this.txtInd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInd_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "Type";
            // 
            // cboCommodities
            // 
            this.cboCommodities.FormattingEnabled = true;
            this.cboCommodities.Location = new System.Drawing.Point(322, 39);
            this.cboCommodities.Name = "cboCommodities";
            this.cboCommodities.Size = new System.Drawing.Size(118, 21);
            this.cboCommodities.TabIndex = 12;
            // 
            // cboOrderType
            // 
            this.cboOrderType.AutoCompleteCustomSource.AddRange(new string[] {
            "ORD",
            "CH",
            "MOC",
            "MOO"});
            this.cboOrderType.FormattingEnabled = true;
            this.cboOrderType.Location = new System.Drawing.Point(6, 39);
            this.cboOrderType.Name = "cboOrderType";
            this.cboOrderType.Size = new System.Drawing.Size(66, 21);
            this.cboOrderType.TabIndex = 8;
            this.cboOrderType.SelectedIndexChanged += new System.EventHandler(this.cboOrderType_SelectedIndexChanged);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(719, 179);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(94, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // btnLimitOrder
            // 
            this.btnLimitOrder.Location = new System.Drawing.Point(719, 40);
            this.btnLimitOrder.Name = "btnLimitOrder";
            this.btnLimitOrder.Size = new System.Drawing.Size(94, 23);
            this.btnLimitOrder.TabIndex = 6;
            this.btnLimitOrder.Text = "Limit Order";
            this.btnLimitOrder.UseVisualStyleBackColor = true;
            this.btnLimitOrder.Click += new System.EventHandler(this.btnLimitOrder_Click);
            // 
            // btnMarketOrder
            // 
            this.btnMarketOrder.Location = new System.Drawing.Point(719, 6);
            this.btnMarketOrder.Name = "btnMarketOrder";
            this.btnMarketOrder.Size = new System.Drawing.Size(94, 23);
            this.btnMarketOrder.TabIndex = 5;
            this.btnMarketOrder.Text = "Market Order";
            this.btnMarketOrder.UseVisualStyleBackColor = true;
            this.btnMarketOrder.Click += new System.EventHandler(this.btnMarketOrder_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(10, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 16);
            this.label14.TabIndex = 62;
            this.label14.Text = "Saved Weighted Avg.";
            // 
            // txtSavedWeightedAverage
            // 
            this.txtSavedWeightedAverage.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtSavedWeightedAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSavedWeightedAverage.Enabled = false;
            this.txtSavedWeightedAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSavedWeightedAverage.Location = new System.Drawing.Point(170, 137);
            this.txtSavedWeightedAverage.Name = "txtSavedWeightedAverage";
            this.txtSavedWeightedAverage.Size = new System.Drawing.Size(72, 20);
            this.txtSavedWeightedAverage.TabIndex = 61;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(51, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 16);
            this.label15.TabIndex = 64;
            this.label15.Text = "Saved Position";
            // 
            // txtSavedPosition
            // 
            this.txtSavedPosition.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtSavedPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSavedPosition.Enabled = false;
            this.txtSavedPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSavedPosition.Location = new System.Drawing.Point(170, 167);
            this.txtSavedPosition.Name = "txtSavedPosition";
            this.txtSavedPosition.Size = new System.Drawing.Size(72, 20);
            this.txtSavedPosition.TabIndex = 63;
            // 
            // frmOrderPlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 209);
            this.Controls.Add(this.btnMarketOrder);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLimitOrder);
            this.Name = "frmOrderPlace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Place Order";
            this.Load += new System.EventHandler(this.frmAddOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox GTC;
        private System.Windows.Forms.TextBox txtComp;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimitOrder;
        private System.Windows.Forms.Button btnMarketOrder;
        private System.Windows.Forms.ComboBox cboCommodities;
        private System.Windows.Forms.ComboBox cboOrderType;
        private System.Windows.Forms.TextBox txtInd;
        private AutoCompleteComboBox cboMon;
        private AutoCompleteComboBox cboAcct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCMEPrice;
        private System.Windows.Forms.CheckBox chkCMEPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtWeightedAverage;
        private System.Windows.Forms.ListBox lstLastFiveCHPrices;
        private System.Windows.Forms.CheckBox chkWeightedAverage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSavedPosition;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSavedWeightedAverage;
    }
}