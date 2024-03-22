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
    public partial class FuturesComfirmationReport : Telerik.Reporting.Report
    {
        public FuturesComfirmationReport(String OrderDate, Int32 Company, Int32 Account)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            GlobalStore.mdtFuturesConfirmations.Clear();
            GlobalStore.FuturesConfirmationsDataSource(OrderDate, Account, Company);
            this.DataSource = GlobalStore.mdtFuturesConfirmations;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}