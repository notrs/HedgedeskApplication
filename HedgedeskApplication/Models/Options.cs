using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Security.Principal;

using System.Drawing;

namespace HedgedeskApplication.Models
{
    public static class Options
    {

        public static DataSet mdsContractOptions = new DataSet();
        public static DataSet mdsContractOptionsForStatus = new DataSet();


        public static DataSet FillContractOptionsDataSet(int workingOrders)
        {
            mdsContractOptions.Clear();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCurrentRegionContractOptions";
            myCMD.Parameters.Add("@HedgeUserID", SqlDbType.Int).Value = 0;
            myCMD.Parameters.Add("@WorkingOrders", SqlDbType.Int).Value = workingOrders;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsContractOptions);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsContractOptions;
        }

        public static void FillContractOptionsDataSetForStatus(int workingOrders, DataTable dt)
        {
            //mdsContractOptions.Clear();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCurrentRegionContractOptions";
            myCMD.Parameters.Add("@HedgeUserID", SqlDbType.Int).Value = 0;
            myCMD.Parameters.Add("@WorkingOrders", SqlDbType.Int).Value = workingOrders;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dt);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }
    }

}
