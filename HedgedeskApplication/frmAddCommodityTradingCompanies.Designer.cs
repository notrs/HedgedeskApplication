namespace HedgedeskApplication
{
    partial class frmAddCommodityTradingCompanies
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
            this.txtTradingCompany = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the Year and Trading Company to create associations for all commodities and" +
    " commodity months for that year.";
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
            this.label3.Location = new System.Drawing.Point(23, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Trading Company:";
            // 
            // txtTradingCompany
            // 
            this.txtTradingCompany.Location = new System.Drawing.Point(122, 82);
            this.txtTradingCompany.Name = "txtTradingCompany";
            this.txtTradingCompany.Size = new System.Drawing.Size(100, 20);
            this.txtTradingCompany.TabIndex = 4;
            this.txtTradingCompany.TextChanged += new System.EventHandler(this.txtTradingCompany_TextChanged);
            this.txtTradingCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTradingCompany_KeyDown);
            this.txtTradingCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTradingCompany_KeyPress);
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
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(203, 125);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmAddCommodityTradingCompanies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 151);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtTradingCompany);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTradingYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAddCommodityTradingCompanies";
            this.Text = "Add Commodity Trading Companies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTradingYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTradingCompany;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
    }
}