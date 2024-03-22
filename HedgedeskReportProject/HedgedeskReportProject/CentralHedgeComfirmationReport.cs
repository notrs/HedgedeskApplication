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
    public partial class CentralHedgeComfirmationReport : Telerik.Reporting.Report
    {
        public CentralHedgeComfirmationReport(String OrderDate, int Live)
        {  
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            DataTable results = new DataTable();
            results.Clear();
            if (Live != 1)
            {
                results = GlobalStore.CentralHedgeConfirmationsDataSource(OrderDate);
                txtDate.Value =  "For " + OrderDate.ToString();
            }
            else
            {
                results = GlobalStore.CentralHedgeConfirmationsLiveDataSource();
                txtDate.Value = "For " + DateTime.Today.ToShortDateString(); 
            }
            this.DataSource = results;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public CentralHedgeComfirmationReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            String OrderDate = "12/10/2015";
            int Live = 0;
            DataTable results = new DataTable();
            results.Clear();
            if (Live != 1)
            {
                results = GlobalStore.CentralHedgeConfirmationsDataSource(OrderDate);
                txtDate.Value = "For " + OrderDate.ToString();
            }
            else
            {
                results = GlobalStore.CentralHedgeConfirmationsLiveDataSource();
                txtDate.Value = "For " + DateTime.Today.ToShortDateString();
            }
            this.DataSource = results;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}