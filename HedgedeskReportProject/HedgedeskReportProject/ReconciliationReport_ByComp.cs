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
    public partial class ReconciliationReport_ByComp : Telerik.Reporting.Report
    {
        public ReconciliationReport_ByComp(string LastSettlementDate, int Company, int Account)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            GlobalStore.mdtLedgerBalance.Clear();
            GlobalStore.LedgerBalanceDataSourceByComp(Account, Company, LastSettlementDate);
            this.DataSource = GlobalStore.mdtLedgerBalance;

            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}