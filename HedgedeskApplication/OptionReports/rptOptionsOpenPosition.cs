namespace HedgedeskApplication.OptionReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
     
    /// <summary>
    /// Summary description for rptOptionContractsBalancing.
    /// </summary>
    public partial class rptOptionsOpenPosition : Telerik.Reporting.Report
    {
        public rptOptionsOpenPosition()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            ReportParameters["HedgeUserID"].Value = 0;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

    }
}