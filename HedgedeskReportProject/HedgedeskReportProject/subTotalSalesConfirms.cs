namespace HedgedeskReportProject
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class subTotalSalesConfirms : Telerik.Reporting.Report
    {
        public subTotalSalesConfirms()
        {
            InitializeComponent();
           
        }
    

        private void groupFooterSection1_ItemDataBinding(object sender, EventArgs e)
        {
            //DataTable results = new DataTable();
            //Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            ////GlobalStore.subLedgerBalanceDataSource(Convert.ToInt32(report.Parameters["Company"].Value.ToString()), Convert.ToInt32(report.Parameters["Account"].Value.ToString()));
            ////GlobalStore.subLedgerBalanceDataSource(10,20);
            //results.Clear();
            //results = GlobalStore.CentralHedgeConfirmationsLiveSalesDataSource(1);

            //this.DataSource = results;
        }

        private void subTotalSalesConfirms_ItemDataBinding(object sender, EventArgs e)
        {
            DataTable results = new DataTable();
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            //GlobalStore.subLedgerBalanceDataSource(Convert.ToInt32(report.Parameters["Company"].Value.ToString()), Convert.ToInt32(report.Parameters["Account"].Value.ToString()));
            //GlobalStore.subLedgerBalanceDataSource(10,20);
            results.Clear();
            int Live = 0;
            String OrderDate; 
            Live = Convert.ToInt32(report.Parameters["Live"].Value.ToString());
            OrderDate = report.Parameters["OrderDate"].Value.ToString();

            if (Live != 1)
            {
                results = GlobalStore.CentralHedgeConfirmationsSalesDataSource(1, OrderDate);
            }
            else
            {
                results = GlobalStore.CentralHedgeConfirmationsLiveSalesDataSource(1);
            }

            this.DataSource = results;
        }
            //this.reportHeaderSection1.Visible = GlobalStore.mdtsubLedgerBalance.Rows.Count > 0; 
    }
}