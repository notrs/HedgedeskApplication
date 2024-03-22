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
    public partial class DailyFuturesPositionReportByGroup : Telerik.Reporting.Report
    {
        public DailyFuturesPositionReportByGroup(Int32 Company, Int32 Account, Int32 Commodity, String OptionMonth, Int32 OptionYear)
        {
            //
            // Required for telerik Reporting designer support
            //

            InitializeComponent();
            GlobalStore.mdtDailyPosition.Clear();
            GlobalStore.DailyPositionDataSource(Account, Company, Commodity, OptionMonth, OptionYear);
            this.DataSource = GlobalStore.mdtDailyPosition;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}