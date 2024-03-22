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
    public partial class RatioPositionReport : Telerik.Reporting.Report
    {
        public RatioPositionReport(int Commodity, string Month, int Year)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            GlobalStore.mdtRatioPositions.Clear();
            GlobalStore.RatioPositionsDataSource(Commodity, Month, Year);
            this.DataSource = GlobalStore.mdtRatioPositions;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}