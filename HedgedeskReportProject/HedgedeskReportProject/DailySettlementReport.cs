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
    public partial class DailySettlementReport : Telerik.Reporting.Report
    {
        public DailySettlementReport(string SettlementDate, int Company, int Account)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            GlobalStore.mdtDailySettlement.Clear();
            GlobalStore.DailySettlementDataSource(SettlementDate, Company, Account);
            this.DataSource = GlobalStore.mdtDailySettlement;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}