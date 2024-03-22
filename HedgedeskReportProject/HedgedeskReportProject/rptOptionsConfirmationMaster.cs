namespace HedgedeskReportProject
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class rptOptionsConfirmationMaster : Telerik.Reporting.Report
    {
        public rptOptionsConfirmationMaster(int HedgeUserID)
        {
            //int HedgeUserID = 7;
            InitializeComponent();

            DataTable results = new DataTable();
            results.Clear();
            results = GlobalStore.OptionConfirmationMaster(HedgeUserID);
            
            this.DataSource = results;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}