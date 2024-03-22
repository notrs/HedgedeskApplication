namespace HedgedeskApplication
{
    partial class frmDeleteCommodityTradingCompanies
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTradingYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTradingMonth = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the Year and Month to delete associations for all commodities for that mont" +
    "h/year.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trading Year:";
            // 
            // txtTradingYear
            // 
            this.txtTradingYear.Location = new System.Drawing.Point(122, 56);
            this.txtTradingYear.Name = "txtTradingYear";
            this.txtTradingYear.Size = new System.Drawing.Size(100, 20);
            this.txtTradingYear.TabIndex = 2;
            this.txtTradingYear.TextChanged += new System.EventHandler(this.txtTradingYear_TextChanged);
            this.txtTradingYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTradingYear_KeyDown);
            this.txtTradingYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTradingYear_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Trading Month:";
            // 
            // txtTradingMonth
            // 
            this.txtTradingMonth.Location = new System.Drawing.Point(122, 82);
            this.txtTradingMonth.Name = "txtTradingMonth";
            this.txtTradingMonth.Size = new System.Drawing.Size(100, 20);
            this.txtTradingMonth.TabIndex = 4;
            this.txtTradingMonth.TextChanged += new System.EventHandler(this.txtTradingCompany_TextChanged);
            this.txtTradingMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTradingCompany_KeyDown);
            this.txtTradingMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTradingCompany_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(293, 125);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(203, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmDeleteCommodityTradingCompanies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 151);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtTradingMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTradingYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDeleteCommodityTradingCompanies";
            this.Text = "Add Commodity Trading Companies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTradingYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTradingMonth;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
    }
}