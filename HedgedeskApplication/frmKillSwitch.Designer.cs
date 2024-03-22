namespace HedgedeskApplication
{
    partial class frmKillSwitch
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
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvKillSwitch = new dgvCustom();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKillSwitch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(294, 445);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(396, 436);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage2.Controls.Add(this.dgvKillSwitch);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(388, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User Trading Setting";
            // 
            // dgvKillSwitch
            // 
            this.dgvKillSwitch.AllowUserToAddRows = false;
            this.dgvKillSwitch.AllowUserToDeleteRows = false;
            this.dgvKillSwitch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKillSwitch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User,
            this.Activate,
            this.UserID});
            this.dgvKillSwitch.Location = new System.Drawing.Point(7, 6);
            this.dgvKillSwitch.Name = "dgvKillSwitch";
            this.dgvKillSwitch.RowHeadersVisible = false;
            this.dgvKillSwitch.Size = new System.Drawing.Size(375, 398);
            this.dgvKillSwitch.TabIndex = 3;
            this.dgvKillSwitch.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvKillSwitch_CellBeginEdit);
            this.dgvKillSwitch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKillSwitch_CellContentClick);
            this.dgvKillSwitch.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKillSwitch_CellLeave);
            this.dgvKillSwitch.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvKillSwitch_CellValidating);
            this.dgvKillSwitch.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvKillSwitch_RowValidating);
            this.dgvKillSwitch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvKillSwitch_KeyDown);
            // 
            // User
            // 
            this.User.DataPropertyName = "UserName";
            this.User.HeaderText = "User";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Width = 175;
            // 
            // Activate
            // 
            this.Activate.DataPropertyName = "AllowTrading";
            this.Activate.HeaderText = "";
            this.Activate.Name = "Activate";
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserSettingID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.Visible = false;
            // 
            // frmKillSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 484);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmKillSwitch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Maintenance";
            this.Load += new System.EventHandler(this.frmKillSwitch_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKillSwitch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private dgvCustom dgvKillSwitch;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
    }
}