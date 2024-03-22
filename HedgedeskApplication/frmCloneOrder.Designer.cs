namespace HedgedeskApplication
{
    partial class frmCloneOrder
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
            this.lblTradeCompany = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.pnlAddOrder = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.txtOrdType = new System.Windows.Forms.TextBox();
            this.txtSideB = new System.Windows.Forms.TextBox();
            this.txtSideA = new System.Windows.Forms.TextBox();
            this.txtBuy = new System.Windows.Forms.TextBox();
            this.txtSell = new System.Windows.Forms.TextBox();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.txtGTCBuy = new System.Windows.Forms.TextBox();
            this.txtGTCSell = new System.Windows.Forms.TextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
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
            this.txtComm = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtInd = new System.Windows.Forms.TextBox();
            this.txtAcct = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.pnlAddOrder.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTradeCompany
            // 
            this.lblTradeCompany.AutoSize = true;
            this.lblTradeCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTradeCompany.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTradeCompany.Location = new System.Drawing.Point(243, 9);
            this.lblTradeCompany.Name = "lblTradeCompany";
            this.lblTradeCompany.Size = new System.Drawing.Size(57, 20);
            this.lblTradeCompany.TabIndex = 0;
            this.lblTradeCompany.Text = "label1";
            this.lblTradeCompany.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(456, 310);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // pnlAddOrder
            // 
            this.pnlAddOrder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlAddOrder.Controls.Add(this.lblDate);
            this.pnlAddOrder.Controls.Add(this.lblDateTime);
            this.pnlAddOrder.Controls.Add(this.txtOrdType);
            this.pnlAddOrder.Controls.Add(this.txtSideB);
            this.pnlAddOrder.Controls.Add(this.txtSideA);
            this.pnlAddOrder.Controls.Add(this.txtBuy);
            this.pnlAddOrder.Controls.Add(this.txtSell);
            this.pnlAddOrder.Controls.Add(this.txtBuyPrice);
            this.pnlAddOrder.Controls.Add(this.txtSellPrice);
            this.pnlAddOrder.Controls.Add(this.txtGTCBuy);
            this.pnlAddOrder.Controls.Add(this.txtGTCSell);
            this.pnlAddOrder.Controls.Add(this.shapeContainer1);
            this.pnlAddOrder.Location = new System.Drawing.Point(3, 32);
            this.pnlAddOrder.Name = "pnlAddOrder";
            this.pnlAddOrder.Size = new System.Drawing.Size(531, 198);
            this.pnlAddOrder.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(9, 175);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(29, 13);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Now";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(9, 162);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(86, 13);
            this.lblDateTime.TabIndex = 18;
            this.lblDateTime.Text = "Entry Date Time:";
            // 
            // txtOrdType
            // 
            this.txtOrdType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrdType.Enabled = false;
            this.txtOrdType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdType.Location = new System.Drawing.Point(213, 140);
            this.txtOrdType.Name = "txtOrdType";
            this.txtOrdType.Size = new System.Drawing.Size(100, 13);
            this.txtOrdType.TabIndex = 17;
            this.txtOrdType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSideB
            // 
            this.txtSideB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSideB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSideB.Location = new System.Drawing.Point(5, 12);
            this.txtSideB.Name = "txtSideB";
            this.txtSideB.Size = new System.Drawing.Size(258, 29);
            this.txtSideB.TabIndex = 10;
            this.txtSideB.Text = "BUY";
            this.txtSideB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSideA
            // 
            this.txtSideA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSideA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSideA.Location = new System.Drawing.Point(270, 12);
            this.txtSideA.Name = "txtSideA";
            this.txtSideA.Size = new System.Drawing.Size(258, 29);
            this.txtSideA.TabIndex = 11;
            this.txtSideA.Text = "SELL";
            this.txtSideA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBuy
            // 
            this.txtBuy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuy.Location = new System.Drawing.Point(5, 40);
            this.txtBuy.Name = "txtBuy";
            this.txtBuy.Size = new System.Drawing.Size(258, 22);
            this.txtBuy.TabIndex = 8;
            this.txtBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSell
            // 
            this.txtSell.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSell.Location = new System.Drawing.Point(270, 40);
            this.txtSell.Name = "txtSell";
            this.txtSell.Size = new System.Drawing.Size(258, 22);
            this.txtSell.TabIndex = 9;
            this.txtSell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyPrice.Location = new System.Drawing.Point(5, 68);
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(258, 25);
            this.txtBuyPrice.TabIndex = 12;
            this.txtBuyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSellPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellPrice.Location = new System.Drawing.Point(270, 68);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Size = new System.Drawing.Size(258, 25);
            this.txtSellPrice.TabIndex = 13;
            this.txtSellPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGTCBuy
            // 
            this.txtGTCBuy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGTCBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGTCBuy.Location = new System.Drawing.Point(5, 99);
            this.txtGTCBuy.Name = "txtGTCBuy";
            this.txtGTCBuy.Size = new System.Drawing.Size(258, 22);
            this.txtGTCBuy.TabIndex = 14;
            this.txtGTCBuy.Text = "GTC";
            this.txtGTCBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGTCBuy.Visible = false;
            // 
            // txtGTCSell
            // 
            this.txtGTCSell.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGTCSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGTCSell.Location = new System.Drawing.Point(270, 99);
            this.txtGTCSell.Name = "txtGTCSell";
            this.txtGTCSell.Size = new System.Drawing.Size(258, 22);
            this.txtGTCSell.TabIndex = 15;
            this.txtGTCSell.Text = "GTC";
            this.txtGTCSell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGTCSell.Visible = false;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(531, 198);
            this.shapeContainer1.TabIndex = 16;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 266;
            this.lineShape1.X2 = 266;
            this.lineShape1.Y1 = 14;
            this.lineShape1.Y2 = 138;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "B/S";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Qty";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Month";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Comm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(325, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "GTC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Comp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "A/C";
            // 
            // GTC
            // 
            this.GTC.AutoSize = true;
            this.GTC.Location = new System.Drawing.Point(429, 29);
            this.GTC.Name = "GTC";
            this.GTC.Size = new System.Drawing.Size(15, 14);
            this.GTC.TabIndex = 32;
            this.GTC.UseVisualStyleBackColor = true;
            this.GTC.CheckedChanged += new System.EventHandler(this.GTC_CheckedChanged);
            // 
            // txtComp
            // 
            this.txtComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComp.Location = new System.Drawing.Point(375, 26);
            this.txtComp.Name = "txtComp";
            this.txtComp.Size = new System.Drawing.Size(37, 20);
            this.txtComp.TabIndex = 31;
            this.txtComp.TextChanged += new System.EventHandler(this.txtComp_TextChanged);
            this.txtComp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComp_KeyPress);
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Location = new System.Drawing.Point(310, 26);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(60, 20);
            this.txtPrice.TabIndex = 30;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // txtComm
            // 
            this.txtComm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComm.Location = new System.Drawing.Point(270, 26);
            this.txtComm.Name = "txtComm";
            this.txtComm.Size = new System.Drawing.Size(36, 20);
            this.txtComm.TabIndex = 29;
            this.txtComm.TextChanged += new System.EventHandler(this.txtComm_TextChanged);
            this.txtComm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComm_KeyPress);
            // 
            // txtYear
            // 
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Location = new System.Drawing.Point(230, 26);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(36, 20);
            this.txtYear.TabIndex = 28;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // txtMonth
            // 
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonth.Location = new System.Drawing.Point(186, 26);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(40, 20);
            this.txtMonth.TabIndex = 27;
            this.txtMonth.TextChanged += new System.EventHandler(this.txtMonth_TextChanged);
            this.txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonth_KeyPress);
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(153, 26);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(29, 20);
            this.txtQty.TabIndex = 26;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtInd
            // 
            this.txtInd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInd.Location = new System.Drawing.Point(126, 26);
            this.txtInd.Name = "txtInd";
            this.txtInd.Size = new System.Drawing.Size(23, 20);
            this.txtInd.TabIndex = 25;
            this.txtInd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInd_KeyPress);
            // 
            // txtAcct
            // 
            this.txtAcct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcct.Location = new System.Drawing.Point(92, 26);
            this.txtAcct.Name = "txtAcct";
            this.txtAcct.Size = new System.Drawing.Size(30, 20);
            this.txtAcct.TabIndex = 24;
            this.txtAcct.TextChanged += new System.EventHandler(this.txtAcct_TextChanged);
            this.txtAcct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcct_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtAcct);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtInd);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtMonth);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtComm);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtComp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.GTC);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 236);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 59);
            this.panel1.TabIndex = 42;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(374, 310);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 43;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmCloneOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 336);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAddOrder);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblTradeCompany);
            this.Name = "frmCloneOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Order";
            this.Load += new System.EventHandler(this.frmAddOrder_Load);
            this.pnlAddOrder.ResumeLayout(false);
            this.pnlAddOrder.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTradeCompany;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Panel pnlAddOrder;
        private System.Windows.Forms.TextBox txtSideB;
        private System.Windows.Forms.TextBox txtSideA;
        private System.Windows.Forms.TextBox txtBuy;
        private System.Windows.Forms.TextBox txtSell;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.TextBox txtSellPrice;
        private System.Windows.Forms.TextBox txtGTCBuy;
        private System.Windows.Forms.TextBox txtGTCSell;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox txtOrdType;
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
        private System.Windows.Forms.TextBox txtComm;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtInd;
        private System.Windows.Forms.TextBox txtAcct;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdCancel;
    }
}