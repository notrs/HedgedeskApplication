namespace HedgedeskApplication
{
    partial class frmEditOrder
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
            this.btnRevise = new System.Windows.Forms.Button();
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrdType = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.btnCancelMarket = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRevise
            // 
            this.btnRevise.Location = new System.Drawing.Point(531, 37);
            this.btnRevise.Name = "btnRevise";
            this.btnRevise.Size = new System.Drawing.Size(94, 23);
            this.btnRevise.TabIndex = 2;
            this.btnRevise.Text = "Revise Order";
            this.btnRevise.UseVisualStyleBackColor = true;
            this.btnRevise.Click += new System.EventHandler(this.btnRevise_Click);
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
            this.label10.Location = new System.Drawing.Point(395, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Qty";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(159, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Month";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Comm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(457, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "GTC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Comp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "A/C";
            // 
            // GTC
            // 
            this.GTC.AutoSize = true;
            this.GTC.Enabled = false;
            this.GTC.Location = new System.Drawing.Point(340, 28);
            this.GTC.Name = "GTC";
            this.GTC.Size = new System.Drawing.Size(15, 14);
            this.GTC.TabIndex = 32;
            this.GTC.UseVisualStyleBackColor = true;
            // 
            // txtComp
            // 
            this.txtComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComp.Enabled = false;
            this.txtComp.Location = new System.Drawing.Point(282, 25);
            this.txtComp.Name = "txtComp";
            this.txtComp.Size = new System.Drawing.Size(37, 20);
            this.txtComp.TabIndex = 31;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.Cornsilk;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Location = new System.Drawing.Point(437, 25);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(72, 20);
            this.txtPrice.TabIndex = 30;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // txtComm
            // 
            this.txtComm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComm.Enabled = false;
            this.txtComm.Location = new System.Drawing.Point(241, 25);
            this.txtComm.Name = "txtComm";
            this.txtComm.Size = new System.Drawing.Size(36, 20);
            this.txtComm.TabIndex = 29;
            // 
            // txtYear
            // 
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Enabled = false;
            this.txtYear.Location = new System.Drawing.Point(201, 25);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(36, 20);
            this.txtYear.TabIndex = 28;
            // 
            // txtMonth
            // 
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonth.Enabled = false;
            this.txtMonth.Location = new System.Drawing.Point(157, 25);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(40, 20);
            this.txtMonth.TabIndex = 27;
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.Cornsilk;
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(382, 25);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(49, 20);
            this.txtQty.TabIndex = 26;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtInd
            // 
            this.txtInd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInd.Enabled = false;
            this.txtInd.Location = new System.Drawing.Point(126, 25);
            this.txtInd.Name = "txtInd";
            this.txtInd.Size = new System.Drawing.Size(23, 20);
            this.txtInd.TabIndex = 25;
            // 
            // txtAcct
            // 
            this.txtAcct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcct.Enabled = false;
            this.txtAcct.Location = new System.Drawing.Point(71, 25);
            this.txtAcct.Name = "txtAcct";
            this.txtAcct.Size = new System.Drawing.Size(49, 20);
            this.txtAcct.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtOrdType);
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
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 59);
            this.panel1.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Type";
            // 
            // txtOrdType
            // 
            this.txtOrdType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrdType.Enabled = false;
            this.txtOrdType.Location = new System.Drawing.Point(11, 25);
            this.txtOrdType.Name = "txtOrdType";
            this.txtOrdType.Size = new System.Drawing.Size(54, 20);
            this.txtOrdType.TabIndex = 42;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(531, 67);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(94, 23);
            this.cmdCancel.TabIndex = 43;
            this.cmdCancel.Text = "Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // btnCancelMarket
            // 
            this.btnCancelMarket.Location = new System.Drawing.Point(418, 67);
            this.btnCancelMarket.Name = "btnCancelMarket";
            this.btnCancelMarket.Size = new System.Drawing.Size(107, 23);
            this.btnCancelMarket.TabIndex = 44;
            this.btnCancelMarket.Text = "Cancel/Market";
            this.btnCancelMarket.UseVisualStyleBackColor = true;
            this.btnCancelMarket.Click += new System.EventHandler(this.btnCancelMarket_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(531, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "Cancel Order";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.BackColor = System.Drawing.Color.Honeydew;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.Location = new System.Drawing.Point(99, 72);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(0, 13);
            this.lblOrderNumber.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Honeydew;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "ORDER NO.:";
            // 
            // frmEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 97);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCancelMarket);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRevise);
            this.Name = "frmEditOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Revise Order";
            this.Load += new System.EventHandler(this.frmAddOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRevise;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrdType;
        private System.Windows.Forms.Button btnCancelMarket;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label label4;
    }
}