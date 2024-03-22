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
    public partial class OptionOpenPosition : Telerik.Reporting.Report
    {
        public OptionOpenPosition(string ExpirationDate, int HedgeUserID, string TradeDate)
        {
            //
            InitializeComponent();

            DataTable results = new DataTable();
            results.Clear();
            results = GlobalStore.OptionOpenPosition(ExpirationDate, HedgeUserID, TradeDate);
            
            this.DataSource = results;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}