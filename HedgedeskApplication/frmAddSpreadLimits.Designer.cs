namespace HedgedeskApplication
{
    partial class frmAddSpreadLimits
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSpreadLimit = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCommodityID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the commodity ID, account and Spread limit.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Spread Limit:";
            // 
            // txtSpreadLimit
            // 
            this.txtSpreadLimit.Location = new System.Drawing.Point(122, 99);
            this.txtSpreadLimit.Name = "txtSpreadLimit";
            this.txtSpreadLimit.Size = new System.Drawing.Size(121, 20);
            this.txtSpreadLimit.TabIndex = 4;
            this.txtSpreadLimit.TextChanged += new System.EventHandler(this.txtSpreadLimit_TextChanged);
            this.txtSpreadLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommodityID_KeyDown);
            this.txtSpreadLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpreadLimit_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(293, 145);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(203, 145);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboAccount
            // 
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(122, 42);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(121, 21);
            this.cboAccount.TabIndex = 23;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(66, 45);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(50, 13);
            this.label64.TabIndex = 22;
            this.label64.Text = "Account:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Commodity ID:";
            // 
            // txtCommodityID
            // 
            this.txtCommodityID.Location = new System.Drawing.Point(122, 71);
            this.txtCommodityID.Name = "txtCommodityID";
            this.txtCommodityID.Size = new System.Drawing.Size(121, 20);
            this.txtCommodityID.TabIndex = 25;
            // 
            // frmAddSpreadLimits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 170);
            this.Controls.Add(this.txtCommodityID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboAccount);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSpreadLimit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmAddSpreadLimits";
            this.Text = "Add Account Spread Limits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSpreadLimit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboAccount;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCommodityID;
    }
}