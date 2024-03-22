namespace HedgedeskApplication
{
    partial class frmHedgeSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpVCFOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpVCFOrderStart = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpCHOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpCHOrderStart = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUpdateContractTimes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpEMCTime = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpSundayPretrade = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpGTCOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpGTCOrderStart = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpLimitOrderStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpMarketOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpMarketOrderStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdateMarketTimes = new System.Windows.Forms.Button();
            this.txtNextTradeDate = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.chkHoliday = new System.Windows.Forms.CheckBox();
            this.dtpHolidayOpenDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpHolidayOpenTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUpdateHolidayInfo = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtHedgeBookSpreadLimit = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtHedgebookOrdLimit = new System.Windows.Forms.TextBox();
            this.btnUpdateHedgeBookLimits = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtHedgeDeskSpreadLimit = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtHedgeDeskOrdLimit = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnUpdateHedgedeskLimits = new System.Windows.Forms.Button();
            this.dgvExchangeCalendarDays = new dgvCustom();
            this.NextTradeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExchangeCalendarDays)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpVCFOrderEnd);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dtpVCFOrderStart);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpCHOrderEnd);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtpCHOrderStart);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnUpdateContractTimes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 171);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contract Hedge Order Settings";
            // 
            // dtpVCFOrderEnd
            // 
            this.dtpVCFOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpVCFOrderEnd.Location = new System.Drawing.Point(322, 108);
            this.dtpVCFOrderEnd.Name = "dtpVCFOrderEnd";
            this.dtpVCFOrderEnd.ShowUpDown = true;
            this.dtpVCFOrderEnd.Size = new System.Drawing.Size(95, 20);
            this.dtpVCFOrderEnd.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(258, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "End Time:";
            // 
            // dtpVCFOrderStart
            // 
            this.dtpVCFOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpVCFOrderStart.Location = new System.Drawing.Point(135, 108);
            this.dtpVCFOrderStart.Name = "dtpVCFOrderStart";
            this.dtpVCFOrderStart.ShowUpDown = true;
            this.dtpVCFOrderStart.Size = new System.Drawing.Size(95, 20);
            this.dtpVCFOrderStart.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(71, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Start Time:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(30, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "VCF Orders from Contracts:";
            // 
            // dtpCHOrderEnd
            // 
            this.dtpCHOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCHOrderEnd.Location = new System.Drawing.Point(322, 51);
            this.dtpCHOrderEnd.Name = "dtpCHOrderEnd";
            this.dtpCHOrderEnd.ShowUpDown = true;
            this.dtpCHOrderEnd.Size = new System.Drawing.Size(95, 20);
            this.dtpCHOrderEnd.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(258, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "End Time:";
            // 
            // dtpCHOrderStart
            // 
            this.dtpCHOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCHOrderStart.Location = new System.Drawing.Point(135, 51);
            this.dtpCHOrderStart.Name = "dtpCHOrderStart";
            this.dtpCHOrderStart.ShowUpDown = true;
            this.dtpCHOrderStart.Size = new System.Drawing.Size(95, 20);
            this.dtpCHOrderStart.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(30, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "CH Orders from Contracts:";
            // 
            // btnUpdateContractTimes
            // 
            this.btnUpdateContractTimes.Location = new System.Drawing.Point(429, 142);
            this.btnUpdateContractTimes.Name = "btnUpdateContractTimes";
            this.btnUpdateContractTimes.Size = new System.Drawing.Size(112, 23);
            this.btnUpdateContractTimes.TabIndex = 3;
            this.btnUpdateContractTimes.Text = "Update";
            this.btnUpdateContractTimes.UseVisualStyleBackColor = true;
            this.btnUpdateContractTimes.Click += new System.EventHandler(this.btnUpdateContractTimes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Time:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpEMCTime);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.dtpSundayPretrade);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.dtpGTCOrderEnd);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtpGTCOrderStart);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.dtpLimitOrderStart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpMarketOrderEnd);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpMarketOrderStart);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnUpdateMarketTimes);
            this.groupBox2.Location = new System.Drawing.Point(12, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 392);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CME Hedge Order Settings";
            // 
            // dtpEMCTime
            // 
            this.dtpEMCTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEMCTime.Location = new System.Drawing.Point(135, 241);
            this.dtpEMCTime.Name = "dtpEMCTime";
            this.dtpEMCTime.ShowUpDown = true;
            this.dtpEMCTime.Size = new System.Drawing.Size(95, 20);
            this.dtpEMCTime.TabIndex = 45;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(74, 245);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "End Time:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(30, 212);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 13);
            this.label20.TabIndex = 43;
            this.label20.Text = "EMC Cut Off:";
            // 
            // dtpSundayPretrade
            // 
            this.dtpSundayPretrade.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSundayPretrade.Location = new System.Drawing.Point(135, 309);
            this.dtpSundayPretrade.Name = "dtpSundayPretrade";
            this.dtpSundayPretrade.ShowUpDown = true;
            this.dtpSundayPretrade.Size = new System.Drawing.Size(95, 20);
            this.dtpSundayPretrade.TabIndex = 42;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(54, 313);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Pretrade Start:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(32, 280);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 13);
            this.label19.TabIndex = 40;
            this.label19.Text = "Sunday Hours:";
            // 
            // dtpGTCOrderEnd
            // 
            this.dtpGTCOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGTCOrderEnd.Location = new System.Drawing.Point(322, 168);
            this.dtpGTCOrderEnd.Name = "dtpGTCOrderEnd";
            this.dtpGTCOrderEnd.ShowUpDown = true;
            this.dtpGTCOrderEnd.Size = new System.Drawing.Size(95, 20);
            this.dtpGTCOrderEnd.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(258, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "End Time:";
            // 
            // dtpGTCOrderStart
            // 
            this.dtpGTCOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGTCOrderStart.Location = new System.Drawing.Point(135, 168);
            this.dtpGTCOrderStart.Name = "dtpGTCOrderStart";
            this.dtpGTCOrderStart.ShowUpDown = true;
            this.dtpGTCOrderStart.Size = new System.Drawing.Size(95, 20);
            this.dtpGTCOrderStart.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(71, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Start Time:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(30, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "GTC Pretrade:";
            // 
            // dtpLimitOrderStart
            // 
            this.dtpLimitOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpLimitOrderStart.Location = new System.Drawing.Point(135, 106);
            this.dtpLimitOrderStart.Name = "dtpLimitOrderStart";
            this.dtpLimitOrderStart.ShowUpDown = true;
            this.dtpLimitOrderStart.Size = new System.Drawing.Size(95, 20);
            this.dtpLimitOrderStart.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Start Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Limit Orders:";
            // 
            // dtpMarketOrderEnd
            // 
            this.dtpMarketOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpMarketOrderEnd.Location = new System.Drawing.Point(322, 77);
            this.dtpMarketOrderEnd.Name = "dtpMarketOrderEnd";
            this.dtpMarketOrderEnd.ShowUpDown = true;
            this.dtpMarketOrderEnd.Size = new System.Drawing.Size(95, 20);
            this.dtpMarketOrderEnd.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Market Close:";
            // 
            // dtpMarketOrderStart
            // 
            this.dtpMarketOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpMarketOrderStart.Location = new System.Drawing.Point(135, 50);
            this.dtpMarketOrderStart.Name = "dtpMarketOrderStart";
            this.dtpMarketOrderStart.ShowUpDown = true;
            this.dtpMarketOrderStart.Size = new System.Drawing.Size(95, 20);
            this.dtpMarketOrderStart.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Market Orders:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Start Time:";
            // 
            // btnUpdateMarketTimes
            // 
            this.btnUpdateMarketTimes.Location = new System.Drawing.Point(429, 350);
            this.btnUpdateMarketTimes.Name = "btnUpdateMarketTimes";
            this.btnUpdateMarketTimes.Size = new System.Drawing.Size(112, 23);
            this.btnUpdateMarketTimes.TabIndex = 8;
            this.btnUpdateMarketTimes.Text = "Update";
            this.btnUpdateMarketTimes.UseVisualStyleBackColor = true;
            this.btnUpdateMarketTimes.Click += new System.EventHandler(this.btnUpdateMarketTimes_Click);
            // 
            // txtNextTradeDate
            // 
            this.txtNextTradeDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtNextTradeDate.Enabled = false;
            this.txtNextTradeDate.Location = new System.Drawing.Point(117, 21);
            this.txtNextTradeDate.Name = "txtNextTradeDate";
            this.txtNextTradeDate.Size = new System.Drawing.Size(127, 20);
            this.txtNextTradeDate.TabIndex = 47;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(6, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(105, 13);
            this.label29.TabIndex = 46;
            this.label29.Text = "Next Trade Date:";
            // 
            // chkHoliday
            // 
            this.chkHoliday.AutoSize = true;
            this.chkHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHoliday.Location = new System.Drawing.Point(18, 70);
            this.chkHoliday.Name = "chkHoliday";
            this.chkHoliday.Size = new System.Drawing.Size(68, 17);
            this.chkHoliday.TabIndex = 36;
            this.chkHoliday.Text = "Holiday";
            this.chkHoliday.UseVisualStyleBackColor = true;
            // 
            // dtpHolidayOpenDate
            // 
            this.dtpHolidayOpenDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHolidayOpenDate.Location = new System.Drawing.Point(117, 95);
            this.dtpHolidayOpenDate.Name = "dtpHolidayOpenDate";
            this.dtpHolidayOpenDate.Size = new System.Drawing.Size(95, 20);
            this.dtpHolidayOpenDate.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(15, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "Holiday Open:";
            // 
            // dtpHolidayOpenTime
            // 
            this.dtpHolidayOpenTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHolidayOpenTime.Location = new System.Drawing.Point(218, 95);
            this.dtpHolidayOpenTime.Name = "dtpHolidayOpenTime";
            this.dtpHolidayOpenTime.ShowUpDown = true;
            this.dtpHolidayOpenTime.Size = new System.Drawing.Size(95, 20);
            this.dtpHolidayOpenTime.TabIndex = 39;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNextTradeDate);
            this.groupBox3.Controls.Add(this.btnUpdateHolidayInfo);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.dtpHolidayOpenTime);
            this.groupBox3.Controls.Add(this.chkHoliday);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.dtpHolidayOpenDate);
            this.groupBox3.Location = new System.Drawing.Point(583, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 165);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CME Holiday Settings";
            // 
            // btnUpdateHolidayInfo
            // 
            this.btnUpdateHolidayInfo.Location = new System.Drawing.Point(218, 132);
            this.btnUpdateHolidayInfo.Name = "btnUpdateHolidayInfo";
            this.btnUpdateHolidayInfo.Size = new System.Drawing.Size(112, 23);
            this.btnUpdateHolidayInfo.TabIndex = 3;
            this.btnUpdateHolidayInfo.Text = "Update";
            this.btnUpdateHolidayInfo.UseVisualStyleBackColor = true;
            this.btnUpdateHolidayInfo.Click += new System.EventHandler(this.btnUpdateHolidayInfo_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.txtHedgeBookSpreadLimit);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.txtHedgebookOrdLimit);
            this.groupBox4.Controls.Add(this.btnUpdateHedgeBookLimits);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Location = new System.Drawing.Point(583, 183);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(343, 117);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hedge Book Quantity Limits";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(242, 57);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(50, 13);
            this.label26.TabIndex = 42;
            this.label26.Text = "bushels";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(242, 25);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 13);
            this.label25.TabIndex = 41;
            this.label25.Text = "bushels";
            // 
            // txtHedgeBookSpreadLimit
            // 
            this.txtHedgeBookSpreadLimit.Location = new System.Drawing.Point(131, 54);
            this.txtHedgeBookSpreadLimit.Name = "txtHedgeBookSpreadLimit";
            this.txtHedgeBookSpreadLimit.Size = new System.Drawing.Size(105, 20);
            this.txtHedgeBookSpreadLimit.TabIndex = 40;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(23, 57);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(102, 13);
            this.label23.TabIndex = 39;
            this.label23.Text = "SPREAD Orders:";
            // 
            // txtHedgebookOrdLimit
            // 
            this.txtHedgebookOrdLimit.Location = new System.Drawing.Point(131, 22);
            this.txtHedgebookOrdLimit.Name = "txtHedgebookOrdLimit";
            this.txtHedgebookOrdLimit.Size = new System.Drawing.Size(105, 20);
            this.txtHedgebookOrdLimit.TabIndex = 38;
            // 
            // btnUpdateHedgeBookLimits
            // 
            this.btnUpdateHedgeBookLimits.Location = new System.Drawing.Point(225, 86);
            this.btnUpdateHedgeBookLimits.Name = "btnUpdateHedgeBookLimits";
            this.btnUpdateHedgeBookLimits.Size = new System.Drawing.Size(112, 23);
            this.btnUpdateHedgeBookLimits.TabIndex = 3;
            this.btnUpdateHedgeBookLimits.Text = "Update";
            this.btnUpdateHedgeBookLimits.UseVisualStyleBackColor = true;
            this.btnUpdateHedgeBookLimits.Click += new System.EventHandler(this.btnUpdateHedgeBookLimits_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(23, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 37;
            this.label21.Text = "ORD Orders:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.txtHedgeDeskSpreadLimit);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.txtHedgeDeskOrdLimit);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.btnUpdateHedgedeskLimits);
            this.groupBox5.Location = new System.Drawing.Point(583, 308);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(343, 117);
            this.groupBox5.TabIndex = 48;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "HedgeDesk Quantity Limits";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(242, 60);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(60, 13);
            this.label28.TabIndex = 46;
            this.label28.Text = "contracts";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(242, 27);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(60, 13);
            this.label27.TabIndex = 45;
            this.label27.Text = "contracts";
            // 
            // txtHedgeDeskSpreadLimit
            // 
            this.txtHedgeDeskSpreadLimit.Location = new System.Drawing.Point(131, 55);
            this.txtHedgeDeskSpreadLimit.Name = "txtHedgeDeskSpreadLimit";
            this.txtHedgeDeskSpreadLimit.Size = new System.Drawing.Size(105, 20);
            this.txtHedgeDeskSpreadLimit.TabIndex = 44;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(23, 58);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(102, 13);
            this.label22.TabIndex = 43;
            this.label22.Text = "SPREAD Orders:";
            // 
            // txtHedgeDeskOrdLimit
            // 
            this.txtHedgeDeskOrdLimit.Location = new System.Drawing.Point(131, 24);
            this.txtHedgeDeskOrdLimit.Name = "txtHedgeDeskOrdLimit";
            this.txtHedgeDeskOrdLimit.Size = new System.Drawing.Size(105, 20);
            this.txtHedgeDeskOrdLimit.TabIndex = 42;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(23, 27);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 13);
            this.label24.TabIndex = 41;
            this.label24.Text = "ORD Orders:";
            // 
            // btnUpdateHedgedeskLimits
            // 
            this.btnUpdateHedgedeskLimits.Location = new System.Drawing.Point(225, 87);
            this.btnUpdateHedgedeskLimits.Name = "btnUpdateHedgedeskLimits";
            this.btnUpdateHedgedeskLimits.Size = new System.Drawing.Size(112, 23);
            this.btnUpdateHedgedeskLimits.TabIndex = 3;
            this.btnUpdateHedgedeskLimits.Text = "Update";
            this.btnUpdateHedgedeskLimits.UseVisualStyleBackColor = true;
            this.btnUpdateHedgedeskLimits.Click += new System.EventHandler(this.btnUpdateHedgedeskLimits_Click);
            // 
            // dgvExchangeCalendarDays
            // 
            this.dgvExchangeCalendarDays.AllowUserToAddRows = false;
            this.dgvExchangeCalendarDays.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvExchangeCalendarDays.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExchangeCalendarDays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NextTradeDate,
            this.Commodity});
            this.dgvExchangeCalendarDays.Location = new System.Drawing.Point(583, 431);
            this.dgvExchangeCalendarDays.Name = "dgvExchangeCalendarDays";
            this.dgvExchangeCalendarDays.RowHeadersWidth = 20;
            this.dgvExchangeCalendarDays.Size = new System.Drawing.Size(343, 144);
            this.dgvExchangeCalendarDays.TabIndex = 0;
            // 
            // NextTradeDate
            // 
            this.NextTradeDate.DataPropertyName = "OpenDate";
            this.NextTradeDate.HeaderText = "Next Trade Date";
            this.NextTradeDate.Name = "NextTradeDate";
            this.NextTradeDate.Width = 150;
            // 
            // Commodity
            // 
            this.Commodity.DataPropertyName = "Commodity";
            this.Commodity.HeaderText = "Commodity";
            this.Commodity.Name = "Commodity";
            this.Commodity.Width = 150;
            // 
            // frmHedgeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 587);
            this.Controls.Add(this.dgvExchangeCalendarDays);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHedgeSettings";
            this.Text = "Hedge Settings";
            this.Load += new System.EventHandler(this.frmHedgeSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExchangeCalendarDays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdateContractTimes;
        private System.Windows.Forms.DateTimePicker dtpCHOrderStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpCHOrderEnd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpVCFOrderEnd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpVCFOrderStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpHolidayOpenTime;
        private System.Windows.Forms.DateTimePicker dtpHolidayOpenDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkHoliday;
        private System.Windows.Forms.DateTimePicker dtpGTCOrderEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpGTCOrderStart;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpLimitOrderStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpMarketOrderEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpMarketOrderStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdateMarketTimes;
        private System.Windows.Forms.DateTimePicker dtpEMCTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpSundayPretrade;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdateHolidayInfo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtHedgeBookSpreadLimit;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtHedgebookOrdLimit;
        private System.Windows.Forms.Button btnUpdateHedgeBookLimits;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtHedgeDeskSpreadLimit;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtHedgeDeskOrdLimit;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnUpdateHedgedeskLimits;
        private System.Windows.Forms.TextBox txtNextTradeDate;
        private System.Windows.Forms.Label label29;
        private dgvCustom dgvExchangeCalendarDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextTradeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commodity;
    }
}