namespace HedgedeskApplication
{
    partial class frmCommodityAddEdit
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCommodityID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExchangeLetter = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtHedgerPosition = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAbbreviation = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtContractConversion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInitialMargin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContractHedgedeskLimit = new System.Windows.Forms.TextBox();
            this.lblchl = new System.Windows.Forms.Label();
            this.txtConfirmationConversion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTickSizeID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLowLimit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRoundingDivisor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCGBOnlineID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSendtoHedgedeskLimit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRangeHigh = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRangeLow = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkTrackBushels = new System.Windows.Forms.CheckBox();
            this.txtDailyPriceLimit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(490, 348);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(94, 23);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(390, 348);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(126, 56);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(238, 20);
            this.txtDescription.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Description:";
            // 
            // txtCommodityID
            // 
            this.txtCommodityID.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtCommodityID.Enabled = false;
            this.txtCommodityID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommodityID.Location = new System.Drawing.Point(126, 25);
            this.txtCommodityID.Name = "txtCommodityID";
            this.txtCommodityID.Size = new System.Drawing.Size(86, 20);
            this.txtCommodityID.TabIndex = 1;
            this.txtCommodityID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCommodityID_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Commodity ID:";
            // 
            // txtExchangeLetter
            // 
            this.txtExchangeLetter.BackColor = System.Drawing.SystemColors.Window;
            this.txtExchangeLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExchangeLetter.Location = new System.Drawing.Point(126, 184);
            this.txtExchangeLetter.Name = "txtExchangeLetter";
            this.txtExchangeLetter.Size = new System.Drawing.Size(86, 20);
            this.txtExchangeLetter.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(32, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 87;
            this.label13.Text = "Exchange Letter:";
            // 
            // txtSymbol
            // 
            this.txtSymbol.BackColor = System.Drawing.SystemColors.Window;
            this.txtSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSymbol.Location = new System.Drawing.Point(126, 152);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(86, 20);
            this.txtSymbol.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(76, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 89;
            this.label14.Text = "Symbol:";
            // 
            // txtHedgerPosition
            // 
            this.txtHedgerPosition.BackColor = System.Drawing.SystemColors.Window;
            this.txtHedgerPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHedgerPosition.Location = new System.Drawing.Point(126, 120);
            this.txtHedgerPosition.Name = "txtHedgerPosition";
            this.txtHedgerPosition.Size = new System.Drawing.Size(86, 20);
            this.txtHedgerPosition.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(35, 124);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 13);
            this.label15.TabIndex = 91;
            this.label15.Text = "Hedger Position:";
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.BackColor = System.Drawing.SystemColors.Window;
            this.txtAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbbreviation.Location = new System.Drawing.Point(126, 88);
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.Size = new System.Drawing.Size(86, 20);
            this.txtAbbreviation.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(51, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 13);
            this.label16.TabIndex = 93;
            this.label16.Text = "Abbreviation:";
            // 
            // txtContractConversion
            // 
            this.txtContractConversion.BackColor = System.Drawing.SystemColors.Window;
            this.txtContractConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractConversion.Location = new System.Drawing.Point(126, 215);
            this.txtContractConversion.Name = "txtContractConversion";
            this.txtContractConversion.Size = new System.Drawing.Size(86, 20);
            this.txtContractConversion.TabIndex = 6;
            this.txtContractConversion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContractConversion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Contract Conversion:";
            // 
            // txtInitialMargin
            // 
            this.txtInitialMargin.BackColor = System.Drawing.SystemColors.Window;
            this.txtInitialMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInitialMargin.Location = new System.Drawing.Point(126, 279);
            this.txtInitialMargin.Name = "txtInitialMargin";
            this.txtInitialMargin.Size = new System.Drawing.Size(86, 20);
            this.txtInitialMargin.TabIndex = 8;
            this.txtInitialMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInitialMargin_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 95;
            this.label5.Text = "Initial Margin:";
            // 
            // txtContractHedgedeskLimit
            // 
            this.txtContractHedgedeskLimit.BackColor = System.Drawing.SystemColors.Window;
            this.txtContractHedgedeskLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractHedgedeskLimit.Location = new System.Drawing.Point(498, 216);
            this.txtContractHedgedeskLimit.Name = "txtContractHedgedeskLimit";
            this.txtContractHedgedeskLimit.Size = new System.Drawing.Size(86, 20);
            this.txtContractHedgedeskLimit.TabIndex = 15;
            this.txtContractHedgedeskLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContractHedgedeskLimit_KeyPress);
            // 
            // lblchl
            // 
            this.lblchl.AutoSize = true;
            this.lblchl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchl.Location = new System.Drawing.Point(363, 218);
            this.lblchl.Name = "lblchl";
            this.lblchl.Size = new System.Drawing.Size(132, 13);
            this.lblchl.TabIndex = 117;
            this.lblchl.Text = "Contract Hedgedesk Limit:";
            // 
            // txtConfirmationConversion
            // 
            this.txtConfirmationConversion.BackColor = System.Drawing.SystemColors.Window;
            this.txtConfirmationConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmationConversion.Location = new System.Drawing.Point(498, 248);
            this.txtConfirmationConversion.Name = "txtConfirmationConversion";
            this.txtConfirmationConversion.Size = new System.Drawing.Size(86, 20);
            this.txtConfirmationConversion.TabIndex = 16;
            this.txtConfirmationConversion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmationConversion_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(371, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 115;
            this.label7.Text = "Confirmation Conversion:";
            // 
            // txtTickSizeID
            // 
            this.txtTickSizeID.BackColor = System.Drawing.SystemColors.Window;
            this.txtTickSizeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTickSizeID.Location = new System.Drawing.Point(498, 280);
            this.txtTickSizeID.Name = "txtTickSizeID";
            this.txtTickSizeID.Size = new System.Drawing.Size(86, 20);
            this.txtTickSizeID.TabIndex = 17;
            this.txtTickSizeID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTickSizeID_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(427, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 113;
            this.label8.Text = "Tick Size ID:";
            // 
            // txtLowLimit
            // 
            this.txtLowLimit.BackColor = System.Drawing.SystemColors.Window;
            this.txtLowLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowLimit.Location = new System.Drawing.Point(498, 89);
            this.txtLowLimit.Name = "txtLowLimit";
            this.txtLowLimit.Size = new System.Drawing.Size(86, 20);
            this.txtLowLimit.TabIndex = 11;
            this.txtLowLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLowLimit_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(441, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 111;
            this.label9.Text = "Low Limit:";
            // 
            // txtRoundingDivisor
            // 
            this.txtRoundingDivisor.BackColor = System.Drawing.SystemColors.Window;
            this.txtRoundingDivisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoundingDivisor.Location = new System.Drawing.Point(498, 121);
            this.txtRoundingDivisor.Name = "txtRoundingDivisor";
            this.txtRoundingDivisor.Size = new System.Drawing.Size(86, 20);
            this.txtRoundingDivisor.TabIndex = 12;
            this.txtRoundingDivisor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoundingDivisor_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(404, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 109;
            this.label10.Text = "Rounding Divisor:";
            // 
            // txtCGBOnlineID
            // 
            this.txtCGBOnlineID.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtCGBOnlineID.Enabled = false;
            this.txtCGBOnlineID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCGBOnlineID.Location = new System.Drawing.Point(498, 153);
            this.txtCGBOnlineID.Name = "txtCGBOnlineID";
            this.txtCGBOnlineID.Size = new System.Drawing.Size(86, 20);
            this.txtCGBOnlineID.TabIndex = 13;
            this.txtCGBOnlineID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCGBOnlineID_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(416, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 107;
            this.label11.Text = "CGB Online ID:";
            // 
            // txtSendtoHedgedeskLimit
            // 
            this.txtSendtoHedgedeskLimit.BackColor = System.Drawing.SystemColors.Window;
            this.txtSendtoHedgedeskLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendtoHedgedeskLimit.Location = new System.Drawing.Point(498, 185);
            this.txtSendtoHedgedeskLimit.Name = "txtSendtoHedgedeskLimit";
            this.txtSendtoHedgedeskLimit.Size = new System.Drawing.Size(86, 20);
            this.txtSendtoHedgedeskLimit.TabIndex = 14;
            this.txtSendtoHedgedeskLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSendtoHedgedeskLimit_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(366, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 13);
            this.label12.TabIndex = 105;
            this.label12.Text = "Send to Hedgedesk Limit:";
            // 
            // txtRangeHigh
            // 
            this.txtRangeHigh.BackColor = System.Drawing.SystemColors.Window;
            this.txtRangeHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRangeHigh.Location = new System.Drawing.Point(498, 57);
            this.txtRangeHigh.Name = "txtRangeHigh";
            this.txtRangeHigh.Size = new System.Drawing.Size(86, 20);
            this.txtRangeHigh.TabIndex = 10;
            this.txtRangeHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRangeHigh_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(428, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 13);
            this.label17.TabIndex = 103;
            this.label17.Text = "Range High:";
            // 
            // txtRangeLow
            // 
            this.txtRangeLow.BackColor = System.Drawing.SystemColors.Window;
            this.txtRangeLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRangeLow.Location = new System.Drawing.Point(498, 26);
            this.txtRangeLow.Name = "txtRangeLow";
            this.txtRangeLow.Size = new System.Drawing.Size(86, 20);
            this.txtRangeLow.TabIndex = 9;
            this.txtRangeLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRangeLow_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(430, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 101;
            this.label18.Text = "Range Low:";
            // 
            // chkTrackBushels
            // 
            this.chkTrackBushels.AutoSize = true;
            this.chkTrackBushels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkTrackBushels.Location = new System.Drawing.Point(126, 314);
            this.chkTrackBushels.Name = "chkTrackBushels";
            this.chkTrackBushels.Size = new System.Drawing.Size(94, 17);
            this.chkTrackBushels.TabIndex = 7;
            this.chkTrackBushels.Text = "Track Bushels";
            this.chkTrackBushels.UseVisualStyleBackColor = true;
            // 
            // txtDailyPriceLimit
            // 
            this.txtDailyPriceLimit.BackColor = System.Drawing.SystemColors.Window;
            this.txtDailyPriceLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDailyPriceLimit.Location = new System.Drawing.Point(126, 248);
            this.txtDailyPriceLimit.Name = "txtDailyPriceLimit";
            this.txtDailyPriceLimit.Size = new System.Drawing.Size(86, 20);
            this.txtDailyPriceLimit.TabIndex = 118;
            this.txtDailyPriceLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDailyPriceLimit_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 119;
            this.label4.Text = "Daily Price Limit:";
            // 
            // frmCommodityAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 393);
            this.Controls.Add(this.txtDailyPriceLimit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkTrackBushels);
            this.Controls.Add(this.txtContractHedgedeskLimit);
            this.Controls.Add(this.lblchl);
            this.Controls.Add(this.txtConfirmationConversion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTickSizeID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLowLimit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRoundingDivisor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCGBOnlineID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSendtoHedgedeskLimit);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtRangeHigh);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtRangeLow);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtContractConversion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInitialMargin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAbbreviation);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtHedgerPosition);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtExchangeLetter);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCommodityID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmCommodityAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Commodity Add Edit";
            this.Load += new System.EventHandler(this.frmCommodityAddEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCommodityID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExchangeLetter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtHedgerPosition;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAbbreviation;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtContractConversion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInitialMargin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContractHedgedeskLimit;
        private System.Windows.Forms.Label lblchl;
        private System.Windows.Forms.TextBox txtConfirmationConversion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTickSizeID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLowLimit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRoundingDivisor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCGBOnlineID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSendtoHedgedeskLimit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRangeHigh;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtRangeLow;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkTrackBushels;
        private System.Windows.Forms.TextBox txtDailyPriceLimit;
        private System.Windows.Forms.Label label4;
    }
}