using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HedgedeskApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //EventLog mHedge_Log = new EventLog();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //if (!System.Diagnostics.EventLog.SourceExists("NewSource"))
                //{
                //    System.Diagnostics.EventLog.CreateEventSource(
                //        "NewSource", "Hedge_Log");
                //}
                //mHedge_Log.Source = "NewSource";
                //mHedge_Log.Log = "Hedge_Log";
                //mHedge_Log.WriteEntry("HedgeApplication");
                Application.Run(new frmOrders());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Application");
                //mHedge_Log.WriteEntry(ex.ToString());
            }

        }
    }
}
