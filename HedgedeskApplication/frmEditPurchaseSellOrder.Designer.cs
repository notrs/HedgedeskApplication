namespace HedgedeskApplication
{
    partial class frmEditPurchaseSellOrder
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
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComp = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtComm = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtExch = new System.Windows.Forms.TextBox();
            this.txtAcct = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAcctXref = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSEQ = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrdType = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.btnUpdateBuyOrder = new System.Windows.Forms.Button();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMoveOrder = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvBuyOrdersFees = new dgvCustom();
            this.txtFeeAmount = new System.Windows.Forms.TextBox();
            this.btnAddFee = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.cboPSFeeType = new AutoCompleteComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.FeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeeTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteFees = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyOrdersFees)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(487, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Exch";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(441, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(359, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Month";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(321, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Comm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(579, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Filled Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(647, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Trd Comp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Account";
            // 
            // txtComp
            // 
            this.txtComp.BackColor = System.Drawing.Color.White;
            this.txtComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComp.Location = new System.Drawing.Point(647, 24);
            this.txtComp.Name = "txtComp";
            this.txtComp.Size = new System.Drawing.Size(54, 20);
            this.txtComp.TabIndex = 14;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Location = new System.Drawing.Point(573, 24);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(72, 20);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // txtComm
            // 
            this.txtComm.BackColor = System.Drawing.Color.White;
            this.txtComm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComm.Location = new System.Drawing.Point(321, 24);
            this.txtComm.Name = "txtComm";
            this.txtComm.Size = new System.Drawing.Size(36, 20);
            this.txtComm.TabIndex = 7;
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.Color.White;
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Location = new System.Drawing.Point(399, 24);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(36, 20);
            this.txtYear.TabIndex = 9;
            // 
            // txtMonth
            // 
            this.txtMonth.BackColor = System.Drawing.Color.White;
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonth.Location = new System.Drawing.Point(358, 24);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(40, 20);
            this.txtMonth.TabIndex = 8;
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(437, 24);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(49, 20);
            this.txtQty.TabIndex = 10;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtExch
            // 
            this.txtExch.BackColor = System.Drawing.Color.White;
            this.txtExch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExch.Location = new System.Drawing.Point(488, 24);
            this.txtExch.Name = "txtExch";
            this.txtExch.Size = new System.Drawing.Size(28, 20);
            this.txtExch.TabIndex = 11;
            // 
            // txtAcct
            // 
            this.txtAcct.BackColor = System.Drawing.Color.White;
            this.txtAcct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcct.Location = new System.Drawing.Point(271, 24);
            this.txtAcct.Name = "txtAcct";
            this.txtAcct.Size = new System.Drawing.Size(49, 20);
            this.txtAcct.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtAcctXref);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCardNumber);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtCompany);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtOrderDate);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtSEQ);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtOrderNumber);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtOrderID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtOrdType);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtAcct);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtExch);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtMonth);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtComm);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.txtComp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 59);
            this.panel1.TabIndex = 42;
            // 
            // txtAcctXref
            // 
            this.txtAcctXref.BackColor = System.Drawing.Color.White;
            this.txtAcctXref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcctXref.Location = new System.Drawing.Point(777, 24);
            this.txtAcctXref.Name = "txtAcctXref";
            this.txtAcctXref.Size = new System.Drawing.Size(49, 20);
            this.txtAcctXref.TabIndex = 16;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(776, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 57;
            this.label17.Text = "Acct Xref";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(705, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Card Number";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.BackColor = System.Drawing.Color.White;
            this.txtCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardNumber.Location = new System.Drawing.Point(703, 24);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(72, 20);
            this.txtCardNumber.TabIndex = 15;
            this.txtCardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(219, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 53;
            this.label16.Text = "Company";
            // 
            // txtCompany
            // 
            this.txtCompany.BackColor = System.Drawing.Color.White;
            this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompany.Location = new System.Drawing.Point(216, 24);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(54, 20);
            this.txtCompany.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(156, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "Order Date";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.BackColor = System.Drawing.Color.White;
            this.txtOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderDate.Location = new System.Drawing.Point(156, 24);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(59, 20);
            this.txtOrderDate.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(121, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Seq";
            // 
            // txtSEQ
            // 
            this.txtSEQ.BackColor = System.Drawing.Color.White;
            this.txtSEQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSEQ.Location = new System.Drawing.Point(115, 24);
            this.txtSEQ.Name = "txtSEQ";
            this.txtSEQ.Size = new System.Drawing.Size(39, 20);
            this.txtSEQ.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(65, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Order #";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.BackColor = System.Drawing.Color.White;
            this.txtOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderNumber.Location = new System.Drawing.Point(59, 24);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(54, 20);
            this.txtOrderNumber.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Order ID";
            // 
            // txtOrderID
            // 
            this.txtOrderID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderID.Location = new System.Drawing.Point(3, 24);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(54, 20);
            this.txtOrderID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(526, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Type";
            // 
            // txtOrdType
            // 
            this.txtOrdType.BackColor = System.Drawing.Color.White;
            this.txtOrdType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrdType.Location = new System.Drawing.Point(517, 24);
            this.txtOrdType.Name = "txtOrdType";
            this.txtOrdType.Size = new System.Drawing.Size(54, 20);
            this.txtOrdType.TabIndex = 12;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(854, 331);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(94, 23);
            this.cmdCancel.TabIndex = 43;
            this.cmdCancel.Text = "Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // btnUpdateBuyOrder
            // 
            this.btnUpdateBuyOrder.Location = new System.Drawing.Point(854, 6);
            this.btnUpdateBuyOrder.Name = "btnUpdateBuyOrder";
            this.btnUpdateBuyOrder.Size = new System.Drawing.Size(94, 23);
            this.btnUpdateBuyOrder.TabIndex = 17;
            this.btnUpdateBuyOrder.Text = "Update Order";
            this.btnUpdateBuyOrder.UseVisualStyleBackColor = true;
            this.btnUpdateBuyOrder.Click += new System.EventHandler(this.btnUpdateBuyOrder_Click);
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.BackColor = System.Drawing.Color.Azure;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.Location = new System.Drawing.Point(99, 64);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(0, 13);
            this.lblOrderNumber.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Azure;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "ORDER NO.:";
            // 
            // btnMoveOrder
            // 
            this.btnMoveOrder.Location = new System.Drawing.Point(854, 33);
            this.btnMoveOrder.Name = "btnMoveOrder";
            this.btnMoveOrder.Size = new System.Drawing.Size(94, 23);
            this.btnMoveOrder.TabIndex = 18;
            this.btnMoveOrder.Text = "Move Order";
            this.btnMoveOrder.UseVisualStyleBackColor = true;
            this.btnMoveOrder.Click += new System.EventHandler(this.btnMoveOrder_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Azure;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(12, 85);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(927, 19);
            this.label18.TabIndex = 52;
            this.label18.Text = "Fees";
            // 
            // dgvBuyOrdersFees
            // 
            this.dgvBuyOrdersFees.AllowUserToAddRows = false;
            this.dgvBuyOrdersFees.AllowUserToDeleteRows = false;
            this.dgvBuyOrdersFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuyOrdersFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FeeType,
            this.FeeTypeID,
            this.Amount,
            this.DeleteFees});
            this.dgvBuyOrdersFees.Location = new System.Drawing.Point(9, 111);
            this.dgvBuyOrdersFees.Name = "dgvBuyOrdersFees";
            this.dgvBuyOrdersFees.RowHeadersWidth = 5;
            this.dgvBuyOrdersFees.Size = new System.Drawing.Size(513, 151);
            this.dgvBuyOrdersFees.TabIndex = 51;
            this.dgvBuyOrdersFees.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBuyOrdersFees_CellBeginEdit);
            this.dgvBuyOrdersFees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuyOrdersFees_CellContentClick);
            this.dgvBuyOrdersFees.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuyOrdersFees_CellLeave);
            this.dgvBuyOrdersFees.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBuyOrdersFees_CellValidating);
            this.dgvBuyOrdersFees.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBuyOrdersFees_KeyDown);
            // 
            // txtFeeAmount
            // 
            this.txtFeeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFeeAmount.Location = new System.Drawing.Point(90, 308);
            this.txtFeeAmount.Name = "txtFeeAmount";
            this.txtFeeAmount.Size = new System.Drawing.Size(204, 20);
            this.txtFeeAmount.TabIndex = 53;
            // 
            // btnAddFee
            // 
            this.btnAddFee.Location = new System.Drawing.Point(323, 304);
            this.btnAddFee.Name = "btnAddFee";
            this.btnAddFee.Size = new System.Drawing.Size(94, 23);
            this.btnAddFee.TabIndex = 54;
            this.btnAddFee.Text = "Add Fee";
            this.btnAddFee.UseVisualStyleBackColor = true;
            this.btnAddFee.Click += new System.EventHandler(this.btnAddFee_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 284);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 13);
            this.label19.TabIndex = 56;
            this.label19.Text = "PS Fee Type:";
            // 
            // cboPSFeeType
            // 
            this.cboPSFeeType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboPSFeeType.FormattingEnabled = true;
            this.cboPSFeeType.Location = new System.Drawing.Point(90, 281);
            this.cboPSFeeType.Name = "cboPSFeeType";
            this.cboPSFeeType.Size = new System.Drawing.Size(204, 21);
            this.cboPSFeeType.Strict = true;
            this.cboPSFeeType.TabIndex = 55;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(38, 310);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 13);
            this.label20.TabIndex = 57;
            this.label20.Text = "Amount:";
            // 
            // FeeType
            // 
            this.FeeType.DataPropertyName = "PSFeeType";
            this.FeeType.HeaderText = "PS Fee Type";
            this.FeeType.Name = "FeeType";
            this.FeeType.Width = 300;
            // 
            // FeeTypeID
            // 
            this.FeeTypeID.DataPropertyName = "PSFeeTypeID";
            this.FeeTypeID.HeaderText = "FeeTypeID";
            this.FeeTypeID.Name = "FeeTypeID";
            this.FeeTypeID.Visible = false;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle1;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // DeleteFees
            // 
            this.DeleteFees.DataPropertyName = "PSBuyOrderFeeID";
            this.DeleteFees.HeaderText = "Delete";
            this.DeleteFees.Name = "DeleteFees";
            this.DeleteFees.Text = "Delete";
            this.DeleteFees.UseColumnTextForButtonValue = true;
            // 
            // frmEditPurchaseSellOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 366);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cboPSFeeType);
            this.Controls.Add(this.btnAddFee);
            this.Controls.Add(this.txtFeeAmount);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dgvBuyOrdersFees);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnUpdateBuyOrder);
            this.Controls.Add(this.btnMoveOrder);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.panel1);
            this.Name = "frmEditPurchaseSellOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Revise Order";
            this.Load += new System.EventHandler(this.frmAddOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyOrdersFees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComp;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtComm;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtExch;
        private System.Windows.Forms.TextBox txtAcct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrdType;
        private System.Windows.Forms.Button btnUpdateBuyOrder;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSEQ;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Button btnMoveOrder;
        private System.Windows.Forms.TextBox txtAcctXref;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Label label18;
        private dgvCustom dgvBuyOrdersFees;
        private System.Windows.Forms.TextBox txtFeeAmount;
        private System.Windows.Forms.Button btnAddFee;
        private System.Windows.Forms.Label label19;
        private AutoCompleteComboBox cboPSFeeType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteFees;
    }
}