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
    public partial class DailyFuturesPositionReportGroupedDetail : Telerik.Reporting.Report
    {
        public DailyFuturesPositionReportGroupedDetail(int Group)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            GlobalStore.mdtDailyPosition.Clear();
            GlobalStore.DailyPositionByGroupDataSource(Group);
            this.DataSource = GlobalStore.mdtDailyPosition;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}