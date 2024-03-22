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
    public partial class MarginCallReport : Telerik.Reporting.Report
    {
        public MarginCallReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            GlobalStore.mdtMarginCall.Clear();
            GlobalStore.MarginCallDataSource();
            this.DataSource = GlobalStore.mdtMarginCall;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}