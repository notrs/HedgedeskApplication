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
    public partial class MonthlySettlementReport : Telerik.Reporting.Report
    {
        public MonthlySettlementReport(int Account, int Company, string SettlementStartDate, string SettlementEndDate)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            GlobalStore.mdtMonthlySettlement.Clear();
            GlobalStore.MonthlySettlementDataSource(Account, Company, SettlementStartDate, SettlementEndDate);
            this.DataSource = GlobalStore.mdtMonthlySettlement;
            this.txtStartDate.Value = SettlementStartDate;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
} 