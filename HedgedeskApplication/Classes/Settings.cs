using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace HedgedeskApplication
{
    class Settings
    {

        public void GetExchangeCalendarDays(DataTable dtCalendarDays)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetNextExchangeDates";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtCalendarDays);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
                       
        }

        public void GetBrokers(DataTable dtBrokers)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetBrokers";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtBrokers);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public Boolean UpdateContractTimes(string CHStart, string CHEnd, string VCFStart, string VCFEnd, ref String ReturnMessage)
        {
            try
            {
                              
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateContractHedgeTimes";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@CHStart", SqlDbType.VarChar).Value = CHStart;
                myCMD.Parameters.Add("@CHEnd", SqlDbType.VarChar).Value = CHEnd;
                myCMD.Parameters.Add("@VCFStart", SqlDbType.VarChar).Value = VCFStart;
                myCMD.Parameters.Add("@VCFEnd", SqlDbType.VarChar).Value = VCFEnd;
                SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();

                return true;

            }
            catch (Exception ex)
            {
                ReturnMessage = ex.Message.ToString();
                return false;
            }

        }

        public Boolean UpdateMoveToCompany(Int32 TradeCompany, ref String ReturnMessage)
        {
            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateMoveToCompany";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@TradeCompany", SqlDbType.Int).Value = TradeCompany;
                SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();

                return true;

            }
            catch (Exception ex)
            {
                ReturnMessage = ex.Message.ToString();
                return false;
            }

        }


        public Boolean UpdateMarketOrderTimes(string MarketStart, string MarketEnd, string LimitStart, string LimitEnd,
            string GTCStart, string GTCEnd, string SundayStart, string EMCEnd, ref String ReturnMessage)
        {
            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateMarketOrderTimes";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@MarketStart", SqlDbType.VarChar).Value = MarketStart;
                myCMD.Parameters.Add("@MarketEnd", SqlDbType.VarChar).Value = MarketEnd;
                myCMD.Parameters.Add("@LimitStart", SqlDbType.VarChar).Value = LimitStart;
                myCMD.Parameters.Add("@LimitEnd", SqlDbType.VarChar).Value = LimitEnd;
                myCMD.Parameters.Add("@GTCStart", SqlDbType.VarChar).Value = GTCStart;
                myCMD.Parameters.Add("@GTCEnd", SqlDbType.VarChar).Value = GTCEnd;
                myCMD.Parameters.Add("@SundayStart", SqlDbType.VarChar).Value = SundayStart;
                myCMD.Parameters.Add("@EMCEnd", SqlDbType.VarChar).Value = EMCEnd;
                SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();

                return true;

            }
            catch (Exception ex)
            {
                ReturnMessage = ex.Message.ToString();
                return false;
            }

        }

        public Boolean UpdateHolidayOrderTimes(int isHoliday, string HolidayDateTime, ref String ReturnMessage)
        {
            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateHolidayOrderTimes";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@isHoliday", SqlDbType.Int).Value = isHoliday;
                myCMD.Parameters.Add("@HolidayDateTime", SqlDbType.VarChar).Value = HolidayDateTime;
                SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();

                return true;

            }
            catch (Exception ex)
            {
                ReturnMessage = ex.Message.ToString();
                return false;
            }

        }

        public Boolean UpdateHedgebookOrderLimits(int OrdBushels, int SpreadBushels, ref String ReturnMessage)
        {
            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateHedgebookOrderLimits";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@OrdBushels", SqlDbType.Int).Value = OrdBushels;
                myCMD.Parameters.Add("@SpreadBushels", SqlDbType.Int).Value = SpreadBushels;
                SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();

                return true;

            }
            catch (Exception ex)
            {
                ReturnMessage = ex.Message.ToString();
                return false;
            }

        }

        public Boolean UpdateHedgeDeskOrderLimits(int OrdContracts, int SpreadContracts, ref String ReturnMessage)
        {
            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateHedgeDeskOrderLimits";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@OrdContracts", SqlDbType.Int).Value = OrdContracts;
                myCMD.Parameters.Add("@SpreadContracts", SqlDbType.Int).Value = SpreadContracts;
                SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();

                return true;

            }
            catch (Exception ex)
            {
                ReturnMessage = ex.Message.ToString();
                return false;
            }

        }
        
    }
}