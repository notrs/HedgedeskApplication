namespace HedgedeskReportProject
{
    partial class rptOptionsOpenPosition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptOptionsOpenPosition));
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.rptOptionsOpenPosition1 = new HedgedeskReportProject.rptOptionsOpenPosition();
            ((System.ComponentModel.ISupportInitialize)(this.rptOptionsOpenPosition1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            //this.reportViewer1.Report = this.rptOptionsOpenPosition1; // = this.rptOptionsOpenPosition1;
            this.reportViewer1.Resources.ReportParametersNullText = "Select All";
            this.reportViewer1.Size = new System.Drawing.Size(1034, 662);
            this.reportViewer1.TabIndex = 2;
            // 
            // rptOptionsOpenPosition1
            // 
            this.rptOptionsOpenPosition1.Name = "rptOptionsOpenPosition";
            // 
            // rptOptionsOpenPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 662);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rptOptionsOpenPosition";
            this.Text = "rptOptionsOpenPosition";
            ((System.ComponentModel.ISupportInitialize)(this.rptOptionsOpenPosition1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
        private HedgedeskReportProject.rptOptionsOpenPosition rptOptionsOpenPosition1;
    }
}