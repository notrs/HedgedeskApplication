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
    public partial class rsubOptionsConfirmation : Telerik.Reporting.Report
    {
        public rsubOptionsConfirmation()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void rsubOptionsConfirmation_ItemDataBinding(object sender, EventArgs e)
        {
            DataTable results = new DataTable();
            results.Clear();
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            GlobalStore.OptionConfirmation(Convert.ToInt32(report.Parameters["HedgeAccount"].Value.ToString()));
            
            this.DataSource = results;
          
         }

  
 
  
    }
}