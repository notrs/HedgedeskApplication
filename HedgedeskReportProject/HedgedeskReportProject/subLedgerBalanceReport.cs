namespace HedgedeskReportProject
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class subLedgerBalanceReport : Telerik.Reporting.Report
    {
        public subLedgerBalanceReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void DisplayNumber(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.TextBox textbox = sender as Telerik.Reporting.Processing.TextBox;

            double value = 0;
            double.TryParse(textbox.Value.ToString(), out value);

            if (value == 0) textbox.Value = string.Empty;
            else textbox.Value = value.ToString("N2");
        } 

        private void subLedgerBalanceReport_NeedDataSource(object sender, EventArgs e)
        {
            //GlobalStore.mdtsubLedgerBalance.Clear();
            //Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            ////Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender; 
            ////Telerik.Reporting.Processing.Report detailReport = (Telerik.Reporting.Processing.Report)subReport.InnerReport;
            ////Telerik.Reporting.Processing.Report mainReport = (Telerik.Reporting.Processing.Report)subReport.Report;
            //GlobalStore.subLedgerBalanceDataSource(Convert.ToInt32(report.Parameters["Company"].Value.ToString()), Convert.ToInt32(report.Parameters["Account"].Value.ToString()));
            ////GlobalStore.subLedgerBalanceDataSource(10,20);
            //this.DataSource = GlobalStore.mdtsubLedgerBalance;
        }

        private void subLedgerBalanceReport_ItemDataBinding(object sender, EventArgs e)
        {
            GlobalStore.mdtsubLedgerBalance.Clear();
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            //Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender; 
            //Telerik.Reporting.Processing.Report detailReport = (Telerik.Reporting.Processing.Report)subReport.InnerReport;
            //Telerik.Reporting.Processing.Report mainReport = (Telerik.Reporting.Processing.Report)subReport.Report;
            GlobalStore.subLedgerBalanceDataSource(Convert.ToInt32(report.Parameters["Company"].Value.ToString()), Convert.ToInt32(report.Parameters["Account"].Value.ToString()));
            //GlobalStore.subLedgerBalanceDataSource(10,20);
            this.DataSource = GlobalStore.mdtsubLedgerBalance;
            //this.reportHeaderSection1.Visible = GlobalStore.mdtsubLedgerBalance.Rows.Count > 0; 
            



        }

        private void textBox9_ItemDataBound(object sender, EventArgs e)
        {
            DisplayNumber(sender, e);
        }
    }
}