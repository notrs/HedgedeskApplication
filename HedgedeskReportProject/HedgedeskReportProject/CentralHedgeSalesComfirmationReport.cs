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
    public partial class CentralHedgeSalesComfirmationReport : Telerik.Reporting.Report
    {
        public CentralHedgeSalesComfirmationReport(int Live, string OrderDate)
        {   
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            DataTable results = new DataTable();
            results.Clear();

            if (Live != 1)
            {
                results = GlobalStore.CentralHedgeConfirmationsSalesDataSource(0, OrderDate);
                //lblOrderDate.Visible = true;
                txtDate.Value = "For " + OrderDate.ToString(); 
            }
            else
            {
                results = GlobalStore.CentralHedgeConfirmationsLiveSalesDataSource(0);
                //lblOrderDate.Visible = false;
                txtDate.Value = "For " + DateTime.Today.ToShortDateString(); 
            }

            //results = GlobalStore.CentralHedgeConfirmationsLiveSalesDataSource(0);
            
            this.DataSource = results;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}