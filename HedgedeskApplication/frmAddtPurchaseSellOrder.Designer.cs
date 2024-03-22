namespace HedgedeskApplication
{
    partial class frmAddPurchaseSellOrder
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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtComm = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtAcct = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.CME = new System.Windows.Forms.CheckBox();
            this.txtSide = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrdType = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(215, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Month";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(258, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Comm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Filled Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Account";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Location = new System.Drawing.Point(329, 25);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(72, 20);
            this.txtPrice.TabIndex = 7;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice.Enter += new System.EventHandler(this.txtPrice_Enter);
            this.txtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // txtComm
            // 
            this.txtComm.BackColor = System.Drawing.Color.White;
            this.txtComm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComm.Location = new System.Drawing.Point(292, 25);
            this.txtComm.Name = "txtComm";
            this.txtComm.Size = new System.Drawing.Size(36, 20);
            this.txtComm.TabIndex = 6;
            this.txtComm.TextChanged += new System.EventHandler(this.txtComm_TextChanged);
            this.txtComm.Enter += new System.EventHandler(this.txtComm_Enter);
            this.txtComm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComm_KeyDown);
            this.txtComm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComm_KeyPress);
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.Color.White;
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Location = new System.Drawing.Point(255, 25);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(36, 20);
            this.txtYear.TabIndex = 5;
            this.txtYear.Enter += new System.EventHandler(this.txtYear_Enter);
            // 
            // txtMonth
            // 
            this.txtMonth.BackColor = System.Drawing.Color.White;
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonth.Location = new System.Drawing.Point(214, 25);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(40, 20);
            this.txtMonth.TabIndex = 4;
            this.txtMonth.TextChanged += new System.EventHandler(this.txtMonth_TextChanged);
            this.txtMonth.Enter += new System.EventHandler(this.txtMonth_Enter);
            this.txtMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMonth_KeyDown);
            this.txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonth_KeyPress);
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(164, 25);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(49, 20);
            this.txtQty.TabIndex = 3;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.Enter += new System.EventHandler(this.txtQty_Enter);
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtAcct
            // 
            this.txtAcct.BackColor = System.Drawing.Color.White;
            this.txtAcct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcct.Location = new System.Drawing.Point(63, 25);
            this.txtAcct.Name = "txtAcct";
            this.txtAcct.Size = new System.Drawing.Size(49, 20);
            this.txtAcct.TabIndex = 1;
            this.txtAcct.Enter += new System.EventHandler(this.txtAcct_Enter);
            this.txtAcct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcct_KeyDown);
            this.txtAcct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcct_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.CME);
            this.panel1.Controls.Add(this.txtSide);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCardNumber);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtCompany);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtOrderDate);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtOrderNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtOrdType);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.txtAcct);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtMonth);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtComm);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 59);
            this.panel1.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(518, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "CME";
            // 
            // CME
            // 
            this.CME.AutoSize = true;
            this.CME.Location = new System.Drawing.Point(525, 28);
            this.CME.Name = "CME";
            this.CME.Size = new System.Drawing.Size(15, 14);
            this.CME.TabIndex = 10;
            this.CME.UseVisualStyleBackColor = true;
            this.CME.Enter += new System.EventHandler(this.CME_Enter);
            // 
            // txtSide
            // 
            this.txtSide.BackColor = System.Drawing.Color.White;
            this.txtSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSide.Location = new System.Drawing.Point(113, 25);
            this.txtSide.Name = "txtSide";
            this.txtSide.Size = new System.Drawing.Size(49, 20);
            this.txtSide.TabIndex = 2;
            this.txtSide.Enter += new System.EventHandler(this.txtSide_Enter);
            this.txtSide.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSide_KeyDown);
            this.txtSide.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSide_KeyPress);
            this.txtSide.Leave += new System.EventHandler(this.txtSide_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Side";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(611, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Card Number";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.BackColor = System.Drawing.Color.White;
            this.txtCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardNumber.Location = new System.Drawing.Point(609, 25);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(72, 20);
            this.txtCardNumber.TabIndex = 11;
            this.txtCardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCardNumber.Enter += new System.EventHandler(this.txtCardNumber_Enter);
            this.txtCardNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNumber_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(461, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 53;
            this.label16.Text = "Company";
            // 
            // txtCompany
            // 
            this.txtCompany.BackColor = System.Drawing.Color.White;
            this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompany.Location = new System.Drawing.Point(458, 25);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(54, 20);
            this.txtCompany.TabIndex = 9;
            this.txtCompany.TextChanged += new System.EventHandler(this.txtCompany_TextChanged);
            this.txtCompany.Enter += new System.EventHandler(this.txtCompany_Enter);
            this.txtCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompany_KeyDown);
            this.txtCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompany_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "Order Date";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.BackColor = System.Drawing.Color.White;
            this.txtOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderDate.Location = new System.Drawing.Point(3, 25);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(59, 20);
            this.txtOrderDate.TabIndex = 0;
            this.txtOrderDate.Enter += new System.EventHandler(this.txtOrderDate_Enter);
            this.txtOrderDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderDate_KeyDown);
            this.txtOrderDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderDate_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(559, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Order #";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.BackColor = System.Drawing.Color.White;
            this.txtOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderNumber.Enabled = false;
            this.txtOrderNumber.Location = new System.Drawing.Point(553, 25);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(54, 20);
            this.txtOrderNumber.TabIndex = 2;
            this.txtOrderNumber.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Type";
            // 
            // txtOrdType
            // 
            this.txtOrdType.BackColor = System.Drawing.Color.White;
            this.txtOrdType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrdType.Location = new System.Drawing.Point(402, 25);
            this.txtOrdType.Name = "txtOrdType";
            this.txtOrdType.Size = new System.Drawing.Size(54, 20);
            this.txtOrdType.TabIndex = 8;
            this.txtOrdType.TextChanged += new System.EventHandler(this.txtOrdType_TextChanged);
            this.txtOrdType.Enter += new System.EventHandler(this.txtOrdType_Enter);
            this.txtOrdType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrdType_KeyDown);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(606, 71);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(94, 23);
            this.cmdCancel.TabIndex = 43;
            this.cmdCancel.Text = "Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(506, 71);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(94, 23);
            this.btnAddOrder.TabIndex = 12;
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // frmAddPurchaseSellOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 106);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.panel1);
            this.Name = "frmAddPurchaseSellOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Revise Order";
            this.Load += new System.EventHandler(this.frmAddOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtComm;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtAcct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrdType;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtSide;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox CME;
    }
}