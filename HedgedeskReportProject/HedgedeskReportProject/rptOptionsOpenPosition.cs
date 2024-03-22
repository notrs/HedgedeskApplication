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
    public partial class rptOptionsOpenPosition : Form
    {
        public rptOptionsOpenPosition()
        {
            InitializeComponent();

            HedgedeskReportProject.rptOptionsOpenPosition report = new HedgedeskReportProject.rptOptionsOpenPosition();

            //this.reportViewer1.Report = report;
            reportViewer1.RefreshReport();
        }
    }
}