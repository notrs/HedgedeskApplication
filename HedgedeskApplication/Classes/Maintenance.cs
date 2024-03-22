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
    class Maintenance
    {

        public DataTable GetPSReportRoutingGroups()
        {
            var table = new DataTable();

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetPSReportRoutingGroups";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(table);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return table;

        }

        public void GetMarginBalances(Int32 Company, Int32 Account, String MarginDateTo, String MarginDateFrom,
            DataTable dtBalances)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetMarginBalances";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company;
            myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = Account;
            myCMD.Parameters.Add("@DateFrom", SqlDbType.VarChar).Value = MarginDateFrom;
            myCMD.Parameters.Add("@DateTo", SqlDbType.VarChar).Value = MarginDateTo;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtBalances);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();



        }

        public void GetLedgerBalanceAdjustments(Int32 Company, Int32 Account, String AdjustmentDateTo, String AdjustmentDateFrom,
            DataTable dtBalances)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetLedgerBalanceAdjustments";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company;
            myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = Account;
            myCMD.Parameters.Add("@DateFrom", SqlDbType.VarChar).Value = AdjustmentDateFrom;
            myCMD.Parameters.Add("@DateTo", SqlDbType.VarChar).Value = AdjustmentDateTo;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtBalances);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();



        }

        public void GetLedgerBalanceMaintenance(DataTable dtMaintenance)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetLedgerBalanceMaintenance";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtMaintenance);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();



        }

        public void GetLedgerBalanceDetailMaintenance(DataTable dtDetail)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetLedgerBalanceDetailMaintenance";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtDetail);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();



        }



        public Boolean UpdateMarginBalances(Int32 MarginID, String Margin, ref String ReturnMessage)
        {
            try
            {

                decimal decMargin = 0;
                if (Margin != "")
                {
                    decMargin = Convert.ToDecimal(Margin.ToString());
                }

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateMarginBalance";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@MarginBalanceID", SqlDbType.Int).Value = MarginID;
                myCMD.Parameters.Add("@Margin", SqlDbType.Decimal).Value = decMargin;
                myCMD.Parameters["@Margin"].Precision = 18;
                myCMD.Parameters["@Margin"].Scale = 4;
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

        public Boolean UpdateLedgerBalanceAdjustments(Int32 LedgerBalanceAdjustmentID, String AdjustmentDate, String AdjustmentAmount, String Comments, ref String ReturnMessage)
        {
            try
            {

                decimal decAdjustmentAmount = 0;
                if (AdjustmentAmount != "")
                {
                    decAdjustmentAmount = Convert.ToDecimal(AdjustmentAmount.ToString());
                }

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateLedgerBalanceAdjustment";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@LedgerBalanceAdjustmentID", SqlDbType.Int).Value = LedgerBalanceAdjustmentID;
                myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments;
                myCMD.Parameters.Add("@AdjustmentDate", SqlDbType.VarChar).Value = AdjustmentDate;
                myCMD.Parameters.Add("@AdjustmentAmount", SqlDbType.Decimal).Value = decAdjustmentAmount;
                myCMD.Parameters["@AdjustmentAmount"].Precision = 18;
                myCMD.Parameters["@AdjustmentAmount"].Scale = 4;
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

        public Boolean UpdateLedgerBalanceMaintenance(Int32 LedgerBalanceID, string BeginningLedgerBalance, string BrokerCommissions,
            string Fees, string MarginBalance, string OpenEquity, string NetEquityPrevious, string MarginPrevious,
            int ReverseSettlement, string NetEquityPreviousYear, ref string ReturnMessage)
        {

            try
            {
                decimal decBeginningLedgerBalance = 0;
                string Balance = BeginningLedgerBalance.ToString().Replace(",", "");
                BeginningLedgerBalance = Balance;
                if (BeginningLedgerBalance != "")
                {
                    decBeginningLedgerBalance = Convert.ToDecimal(BeginningLedgerBalance.ToString());
                }

                decimal decBrokerCommissions = 0;
                string Commissions = BrokerCommissions.ToString().Replace(",", "");
                BrokerCommissions = Commissions;
                if (BrokerCommissions != "")
                {
                    decBrokerCommissions = Convert.ToDecimal(BrokerCommissions.ToString());
                }

                decimal decFees = 0;
                string strFees = Fees.ToString().Replace(",", "");
                Fees = strFees;
                if (Fees != "")
                {
                    decFees = Convert.ToDecimal(Fees.ToString());
                }

                decimal decMarginBalance = 0;
                string strMarginBalance = MarginBalance.ToString().Replace(",", "");
                MarginBalance = strMarginBalance;
                if (MarginBalance != "")
                {
                    decMarginBalance = Convert.ToDecimal(MarginBalance.ToString());
                }

                decimal decOpenEquity = 0;
                string strOpenEquity = OpenEquity.ToString().Replace(",", "");
                OpenEquity = strOpenEquity;
                if (OpenEquity != "")
                {
                    decOpenEquity = Convert.ToDecimal(OpenEquity.ToString());
                }

                decimal decNetEquityPrevious = 0;
                string strNetEquityPrevious = NetEquityPrevious.ToString().Replace(",", "");
                NetEquityPrevious = strNetEquityPrevious;
                if (NetEquityPrevious != "")
                {
                    decNetEquityPrevious = Convert.ToDecimal(NetEquityPrevious.ToString());
                }

                decimal decMarginPrevious = 0;
                string strMarginPrevious = MarginPrevious.ToString().Replace(",", "");
                MarginPrevious = strMarginPrevious;
                if (MarginPrevious != "")
                {
                    decMarginPrevious = Convert.ToDecimal(MarginPrevious.ToString());
                }

                decimal decNetEquityPreviousYear = 0;
                string strNetEquityPreviousYear = NetEquityPreviousYear.ToString().Replace(",", "");
                NetEquityPreviousYear = strNetEquityPreviousYear;
                if (NetEquityPreviousYear != "")
                {
                    decNetEquityPreviousYear = Convert.ToDecimal(NetEquityPreviousYear.ToString());
                }



                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateLedgerBalanceMaintenance";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@LedgerBalanceID", SqlDbType.Int).Value = LedgerBalanceID;
                myCMD.Parameters.Add("@BeginningLedgerBalance", SqlDbType.Decimal).Value = decBeginningLedgerBalance;
                myCMD.Parameters["@BeginningLedgerBalance"].Precision = 18;
                myCMD.Parameters["@BeginningLedgerBalance"].Scale = 4;
                myCMD.Parameters.Add("@BrokerCommissions", SqlDbType.Decimal).Value = decBrokerCommissions;
                myCMD.Parameters["@BrokerCommissions"].Precision = 18;
                myCMD.Parameters["@BrokerCommissions"].Scale = 4;
                myCMD.Parameters.Add("@Fees", SqlDbType.Decimal).Value = decFees;
                myCMD.Parameters["@Fees"].Precision = 18;
                myCMD.Parameters["@Fees"].Scale = 4;
                myCMD.Parameters.Add("@MarginBalance", SqlDbType.Decimal).Value = decMarginBalance;
                myCMD.Parameters["@MarginBalance"].Precision = 18;
                myCMD.Parameters["@MarginBalance"].Scale = 4;
                myCMD.Parameters.Add("@OpenEquity", SqlDbType.Decimal).Value = decOpenEquity;
                myCMD.Parameters["@OpenEquity"].Precision = 18;
                myCMD.Parameters["@OpenEquity"].Scale = 4;
                myCMD.Parameters.Add("@NetEquityPrevious", SqlDbType.Decimal).Value = decNetEquityPrevious;
                myCMD.Parameters["@NetEquityPrevious"].Precision = 18;
                myCMD.Parameters["@NetEquityPrevious"].Scale = 4;
                myCMD.Parameters.Add("@MarginPrevious", SqlDbType.Decimal).Value = decMarginPrevious;
                myCMD.Parameters["@MarginPrevious"].Precision = 18;
                myCMD.Parameters["@MarginPrevious"].Scale = 4;
                myCMD.Parameters.Add("@NetEquityPreviousYear", SqlDbType.Decimal).Value = decNetEquityPreviousYear;
                myCMD.Parameters["@NetEquityPreviousYear"].Precision = 18;
                myCMD.Parameters["@NetEquityPreviousYear"].Scale = 4;
                myCMD.Parameters.Add("@ReverseSettlement", SqlDbType.Int).Value = ReverseSettlement;
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

        public void GetCommodities(int inActive, DataTable dtCommodities)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCommoditiesForUpdate";
            myCMD.Parameters.Add("@InActive", SqlDbType.Int).Value = inActive;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtCommodities);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void GetCommoditiesMonths(Int32 CommodityID, DataTable dtCommodities)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetMonthsCommsForUpdate";
            myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtCommodities);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public Boolean AddCommodity(Int32 CommodityID, string Desc, string Abbrev,
            string Hedger_Position, decimal Range_Low, decimal Range_High, int ContractConversion, string TP_Exchltr, 
            string Symbol, int ConfirmationConversion, int TrackBushels, int TickSizeID, int InitialMargin, string Created_User,
            int LowLimit, int RoundingDivisor, int CGBID, int SendToHedgedeskLimit, int ContractHedgedeskLimit, decimal DailyPriceLimit,
            ref string ReturnMessage)
        {

            try
            {
                
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_AddCommodity";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
                myCMD.Parameters.Add("@Desc", SqlDbType.VarChar).Value = Desc;
                myCMD.Parameters.Add("@Abbrev", SqlDbType.VarChar).Value = Abbrev;
                myCMD.Parameters.Add("@Hedger_Position", SqlDbType.VarChar).Value = Hedger_Position;
                myCMD.Parameters.Add("@Range_Low", SqlDbType.Decimal).Value = Range_Low;
                myCMD.Parameters["@Range_Low"].Precision = 18;
                myCMD.Parameters["@Range_Low"].Scale = 4;
                myCMD.Parameters.Add("@Range_High", SqlDbType.Decimal).Value = Range_High;
                myCMD.Parameters["@Range_High"].Precision = 18;
                myCMD.Parameters["@Range_High"].Scale = 4;
                myCMD.Parameters.Add("@ContractConversion", SqlDbType.Int).Value = ContractConversion;
                myCMD.Parameters.Add("@TP_Exchltr", SqlDbType.VarChar).Value = TP_Exchltr;
                myCMD.Parameters.Add("@Symbol", SqlDbType.VarChar).Value = Symbol;
                myCMD.Parameters.Add("@ConfirmationConversion", SqlDbType.Int).Value = ConfirmationConversion;
                myCMD.Parameters.Add("@TrackBushels", SqlDbType.Int).Value = TrackBushels;
                myCMD.Parameters.Add("@TickSizeID", SqlDbType.Int).Value = TickSizeID;
                myCMD.Parameters.Add("@InitialMargin", SqlDbType.Int).Value = InitialMargin;
                myCMD.Parameters.Add("@Created_User", SqlDbType.VarChar).Value = Created_User;
                myCMD.Parameters.Add("@LowLimit", SqlDbType.Int).Value = TickSizeID;
                myCMD.Parameters.Add("@RoundingDivisor", SqlDbType.Int).Value = TrackBushels;
                myCMD.Parameters.Add("@CGBID", SqlDbType.Int).Value = TickSizeID;
                myCMD.Parameters.Add("@SendToHedgedeskLimit", SqlDbType.Int).Value = TrackBushels;
                myCMD.Parameters.Add("@ContractHedgedeskLimit", SqlDbType.Int).Value = TickSizeID;
                myCMD.Parameters.Add("@DailyPriceLimit", SqlDbType.Decimal).Value = DailyPriceLimit;
                myCMD.Parameters["@DailyPriceLimit"].Precision = 18;
                myCMD.Parameters["@DailyPriceLimit"].Scale = 2;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

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

        public Boolean UpdateCommodity(Int32 CommodityID, string Desc, string Abbrev,
            string Hedger_Position, decimal Range_Low, decimal Range_High, Int32 ContractConversion, string TP_Exchltr,
            string Symbol, Int32 ConfirmationConversion, Int32 TrackBushels, Int32 TickSizeID, Int32 InitialMargin, string Created_User,
            Int32 LowLimit, Int32 RoundingDivisor, Int32 CGBID, Int32 SendToHedgedeskLimit, Int32 ContractHedgedeskLimit, Int32 InActive, 
            decimal DailyPriceLimit, ref string ReturnMessage)
        {

            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateCommodity";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
                myCMD.Parameters.Add("@Desc", SqlDbType.VarChar).Value = Desc;
                myCMD.Parameters.Add("@Abbrev", SqlDbType.VarChar).Value = Abbrev;
                myCMD.Parameters.Add("@Hedger_Position", SqlDbType.VarChar).Value = Hedger_Position;
                myCMD.Parameters.Add("@Range_Low", SqlDbType.Decimal).Value = Range_Low;
                myCMD.Parameters["@Range_Low"].Precision = 18;
                myCMD.Parameters["@Range_Low"].Scale = 4;
                myCMD.Parameters.Add("@Range_High", SqlDbType.Decimal).Value = Range_High;
                myCMD.Parameters["@Range_High"].Precision = 18;
                myCMD.Parameters["@Range_High"].Scale = 4;
                myCMD.Parameters.Add("@ContractConversion", SqlDbType.Int).Value = ContractConversion;
                myCMD.Parameters.Add("@TP_Exchltr", SqlDbType.VarChar).Value = TP_Exchltr;
                myCMD.Parameters.Add("@Symbol", SqlDbType.VarChar).Value = Symbol;
                myCMD.Parameters.Add("@ConfirmationConversion", SqlDbType.Int).Value = ConfirmationConversion;
                myCMD.Parameters.Add("@TrackBushels", SqlDbType.Int).Value = TrackBushels;
                myCMD.Parameters.Add("@TickSizeID", SqlDbType.Int).Value = TickSizeID;
                myCMD.Parameters.Add("@InitialMargin", SqlDbType.Int).Value = InitialMargin;
                myCMD.Parameters.Add("@Modified_User", SqlDbType.VarChar).Value = Created_User;
                myCMD.Parameters.Add("@LowLimit", SqlDbType.Int).Value = LowLimit;
                myCMD.Parameters.Add("@RoundingDivisor", SqlDbType.Int).Value = RoundingDivisor;
                myCMD.Parameters.Add("@CGBID", SqlDbType.Int).Value = CGBID;
                myCMD.Parameters.Add("@SendToHedgedeskLimit", SqlDbType.Int).Value = SendToHedgedeskLimit;
                myCMD.Parameters.Add("@ContractHedgedeskLimit", SqlDbType.Int).Value = ContractHedgedeskLimit;
                myCMD.Parameters.Add("@InActive", SqlDbType.Int).Value = InActive;
                myCMD.Parameters.Add("@DailyPriceLimit", SqlDbType.Decimal).Value = DailyPriceLimit;
                myCMD.Parameters["@DailyPriceLimit"].Precision = 18;
                myCMD.Parameters["@DailyPriceLimit"].Scale = 2;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;


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

        public Boolean UpdateLedgerBalanceDetailMaintenance(Int32 LedgerBalanceDetailID, string OpenEquity, int SortOrder, ref string ReturnMessage)
        {

            try
            {
                
                decimal decOpenEquity = 0;
                string strOpenEquity = OpenEquity.ToString().Replace(",", "");
                OpenEquity = strOpenEquity;
                if (OpenEquity != "")
                {
                    decOpenEquity = Convert.ToDecimal(OpenEquity.ToString());
                }

                
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateLedgerBalanceMaintenance";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@LedgerBalanceDetailID", SqlDbType.Int).Value = LedgerBalanceDetailID;
                myCMD.Parameters.Add("@OpenEquity", SqlDbType.Decimal).Value = decOpenEquity;
                myCMD.Parameters["@OpenEquity"].Precision = 18;
                myCMD.Parameters["@OpenEquity"].Scale = 4;
                myCMD.Parameters.Add("@SortOrder", SqlDbType.Int).Value = SortOrder;
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

        public void UpdateHedgeAccount(String CurrentUser, Int32 HedgeUserID)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_UpdateUserHedgeAccount";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@User", SqlDbType.VarChar).Value = CurrentUser;
            myCMD.Parameters.Add("@HedgeUserID", SqlDbType.Int).Value = HedgeUserID;
            //myCMD.Parameters.Add("@Margin", SqlDbType.Decimal).Value = decMargin;
            //myCMD.Parameters["@Margin"].Precision = 18;
            //myCMD.Parameters["@Margin"].Scale = 4;
            //myCMD.Parameters.Add("@MarginDate", SqlDbType.VarChar).Value = MarginDate;
            //myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            //myCMD.Parameters["@ReturnMessage"].Size = 250;
            //myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }

        public static void GetTradingCompaniesForEdit(DataTable dtTradingCompanies)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCommodityTradingCompany";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtTradingCompanies);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void GetHedgeAccountDetails(DataTable dtHedgeAccounts)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetHedgeAccountDetails";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtHedgeAccounts);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void GetHedgeAccounts(DataTable dtHedgeAccounts)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetHedgeAccounts";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtHedgeAccounts);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void GetXMLForZennoh(DataSet dtXML)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_TransferToGEM";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.CommandTimeout = 60000;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            
            Conn.Open();
            adapter.Fill(dtXML);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void GetXMLFuturesForZennoh(DataSet dtXML)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_TransferFuturesToGEM";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtXML);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void GetCommoditiesForEdit(DataTable dtCommodities)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetHedgeLimits";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtCommodities);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void ShowHedgersNotBalanced(DataTable dt)
        { 
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_ShowHedgersNotBalanced";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dt);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void GetOrdersForFill(DataTable dt)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetSystemInPauseOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dt);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void GetUsers(DataTable dt)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetUsers";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dt);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        } 


        public void GetCommoditiesForUpdate(DataTable dtCommodities, int inActive)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCommoditiesForUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Parameters.Add("@InActive", SqlDbType.Int).Value = inActive;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtCommodities);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }


        public void TransferTradesToPSTables(DataTable dtCommodities)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetHedgeLimits";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtCommodities);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }


        public void GetCommoditiesTradingCompaniesForEdit(DataTable dtTradeCompanies)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCommodityTradingCompanyForUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtTradeCompanies);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void GetSpreadLimitsForEdit(DataTable dtSpreadLimits)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetAccountCommodityLimitsForUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtSpreadLimits);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void GetClosingPrices(DataTable dtClosingPrices)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetClosingPrices";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtClosingPrices);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public Boolean DeleteCommoditiesTradingID(int CommodityTradingID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteCommodityTradingComp";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@CommTradingCompID", SqlDbType.Int).Value = CommodityTradingID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }


        public Boolean DeleteFee(int feeID, string orderType)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeletePSOrderFees";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@FeeID", SqlDbType.Int).Value = feeID;
            myCMD.Parameters.Add("@OrderType", SqlDbType.VarChar).Value = orderType;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }
        public Boolean DeleteCommodity(int CommodityID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteCommodity";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }

        public Boolean UnDeleteCommodity(int CommodityID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_UnDeleteCommodity";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }

        public Boolean SetNetEquity()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_SetNetEquity";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }

        public Boolean DeleteAccountCommodityLimit(int AccountCommodityLimitID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteAccountCommodityLimit";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@AccountCommodityLimitID", SqlDbType.Int).Value = AccountCommodityLimitID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }
        
        public Boolean DeleteCommoditiesTradingMonthYear(string Year, string Month, ref string ReturnMessage) 
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteCommodityTradingCompMonthYear";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@CommTradingCompMonth", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@CommTradingCompYear", SqlDbType.VarChar).Value = Year;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }


        public Boolean DeleteMarginBalance(int MarginBalanceID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteMarginBalance";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@MarginBalanceID", SqlDbType.Int).Value = MarginBalanceID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }

        public Boolean DeleteLedgerBalanceAdjustment(int MarginBalanceID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteLedgerBalanceAdjustment";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@LedgerBalanceAdjustmentID", SqlDbType.Int).Value = MarginBalanceID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }

        public Boolean DeleteLedgerBalanceMaintenance(int MarginBalanceID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteLedgerBalanceMaintenance";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@LedgerBalanceID", SqlDbType.Int).Value = MarginBalanceID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }

        public Boolean DeleteLedgerBalanceDetailMaintenance(int MarginBalanceID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteLedgerBalanceDetailMaintenance";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@LedgerBalanceDetailID", SqlDbType.Int).Value = MarginBalanceID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }

        public Boolean DeleteFuturesID(int FuturesID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteClosingFutures";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@FuturesID", SqlDbType.Int).Value = FuturesID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }

        public Boolean DeleteCommodityMonth(string Month, int CommodityID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteCommodityMonthXref";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }

        public Boolean AddCommodityMonth(string Month, int CommodityID, string CurrentUser, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddCommodityMonthXref";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return true;
        }

        public Boolean UpdateHedgeLimits(string LowLimit, string RangeLow, string RangeHigh, string RoundingDivisor, int CommodityID, string InitialMargin,
            ref string ReturnMessage)
        {

            try
            {
                decimal decLowLimit = 0;
                decimal decRangeLow = 0;
                decimal decRangeHigh = 0;
                decimal decRoundingDivisor = 0;
                decimal decInitialMargin = 0;
                if (LowLimit != "")
                {
                    decLowLimit = Convert.ToDecimal(LowLimit.ToString());
                }

                if (RangeLow != "")
                {
                    decRangeLow = Convert.ToDecimal(RangeLow.ToString());
                }
                if (RangeHigh != "")
                {
                    decRangeHigh = Convert.ToDecimal(RangeHigh.ToString());
                }
                if (RoundingDivisor != "")
                {
                    decRoundingDivisor = Convert.ToDecimal(RoundingDivisor.ToString());
                }
                if (InitialMargin != "")
                {
                    decInitialMargin = Convert.ToDecimal(InitialMargin.ToString());
                }

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateHedgeLimits";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
                myCMD.Parameters.Add("@LowLimit", SqlDbType.Decimal).Value = decLowLimit;
                myCMD.Parameters["@LowLimit"].Precision = 18;
                myCMD.Parameters["@LowLimit"].Scale = 4;
                myCMD.Parameters.Add("@RoundingDivisor", SqlDbType.Decimal).Value = decRoundingDivisor;
                myCMD.Parameters["@RoundingDivisor"].Precision = 18;
                myCMD.Parameters["@RoundingDivisor"].Scale = 4;
                myCMD.Parameters.Add("@RangeHigh", SqlDbType.Decimal).Value = decRangeHigh;
                myCMD.Parameters["@RangeHigh"].Precision = 18;
                myCMD.Parameters["@RangeHigh"].Scale = 4;
                myCMD.Parameters.Add("@RangeLow", SqlDbType.Decimal).Value = decRangeLow;
                myCMD.Parameters["@RangeLow"].Precision = 18;
                myCMD.Parameters["@RangeLow"].Scale = 4;
                myCMD.Parameters.Add("@InitialMargin", SqlDbType.Decimal).Value = decInitialMargin;
                myCMD.Parameters["@InitialMargin"].Precision = 18;
                myCMD.Parameters["@InitialMargin"].Scale = 4;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }

        public Boolean UpdateCommodityTradingCompany(int CommodityTradingCompanyID, string Month, int Year,
            int CommodityID, int TradingCompanyID, ref string ReturnMessage)
        {

            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateCommodityTradingComp";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@CommodityTradingCompanyID", SqlDbType.Int).Value = CommodityTradingCompanyID;
                myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
                myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
                myCMD.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                myCMD.Parameters.Add("@TradingCompanyID", SqlDbType.Int).Value = TradingCompanyID;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }

        public Boolean UpdateAccountCommodityLimits(int AccountCommodityLimitID, int CommodityID,
            int AccountID, int SpreadLimit, ref string ReturnMessage)
        {

            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateAccountCommodityLimit";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@AccountCommodityLimitID", SqlDbType.Int).Value = AccountCommodityLimitID;
                myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
                myCMD.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
                myCMD.Parameters.Add("@SpreadLimit", SqlDbType.Int).Value = SpreadLimit;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }

        public Boolean UpdateOpenOrder(int OrderNumber, decimal FilledPrice, ref string ReturnMessage)
        {

            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateFillPrice";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@TP_ORD_NUMB", SqlDbType.Int).Value = OrderNumber;
                myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = FilledPrice;
                myCMD.Parameters["@FilledPrice"].Precision = 18;
                myCMD.Parameters["@FilledPrice"].Scale = 5;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }

        public Boolean InactivateUser(int AllowTrading, int UserID, ref string ReturnMessage)
        {

            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_InactivateHedgebookUser";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@AllowTrading", SqlDbType.Int).Value = AllowTrading;
                myCMD.Parameters.Add("@UserSettingID", SqlDbType.Int).Value = UserID;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }


        public Boolean UpdateClosingFutures(int FuturesID, string Month, string Year,
            String ClosingPrice, string Commodity, ref string ReturnMessage)
        {

            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateClosingFutures";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@FuturesID", SqlDbType.Int).Value = FuturesID;
                myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
                myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
                myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
                myCMD.Parameters.Add("@ClosingPrice", SqlDbType.VarChar).Value = ClosingPrice;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }

        public Boolean SetPreviousNetEquity()
        {
            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_SetPreviousNetEquity";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public Boolean AddCommodityTradingCompanyForYear(int Year,
                int TradingCompanyID, ref string ReturnMessage)
        {

            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_AddCommodityTradingCompForYear";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                myCMD.Parameters.Add("@TradingCompany", SqlDbType.Int).Value = TradingCompanyID;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }

        public Boolean AddSpreadLimitForAccount(int CommodityID, int AccountID,
                int SpreadLimit, ref string ReturnMessage)
        {

            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_AddAccountCommodityLimit";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
                myCMD.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
                myCMD.Parameters.Add("@SpreadLimit", SqlDbType.Int).Value = SpreadLimit;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();

                if (myCMD.Parameters["@ReturnMessage"].Value.ToString() != "")
                {
                    ReturnMessage = myCMD.Parameters["@ReturnMessage"].Value.ToString();
                }

                Conn.Dispose();
                myCMD.Dispose();

                
                return true;
            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }


        public Boolean AddMarginBalances(int Company, int Account, string Margin, string MarginDate, ref string ReturnMessage)
        {

            decimal decMargin = 0;
            if (Margin != "")
            {
                decMargin = Convert.ToDecimal(Margin.ToString());
            }
            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_AddMarginBalance";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Company;
                myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = Account;
                myCMD.Parameters.Add("@Margin", SqlDbType.Decimal).Value = decMargin;
                myCMD.Parameters["@Margin"].Precision = 18;
                myCMD.Parameters["@Margin"].Scale = 4;
                myCMD.Parameters.Add("@MarginDate", SqlDbType.VarChar).Value = MarginDate;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
                if (ReturnMessage != "")
                {
                    return false;
                }
                else
                {

                    return true;
                }

            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }

        public Boolean AddLedgerBalanceAdjustment(int Company, int Account, string AdjustmentAmount, string AdjustmentDate,
            string Comments, ref string ReturnMessage)
        {

            decimal decAdjustmentAmount = 0;
            string Adjustment = AdjustmentAmount.ToString().Replace(",", "");
            AdjustmentAmount = Adjustment;
            if (AdjustmentAmount != "")
            {
                decAdjustmentAmount = Convert.ToDecimal(AdjustmentAmount.ToString());
            }
            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_AddLedgerBalanceAdjustment";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Company;
                myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = Account;
                myCMD.Parameters.Add("@AdjustmentAmount", SqlDbType.Decimal).Value = decAdjustmentAmount;
                myCMD.Parameters["@AdjustmentAmount"].Precision = 18;
                myCMD.Parameters["@AdjustmentAmount"].Scale = 4;
                myCMD.Parameters.Add("@AdjustmentDate", SqlDbType.VarChar).Value = AdjustmentDate;
                myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
                if (ReturnMessage != "")
                {
                    return false;
                }
                else
                {

                    return true;
                }

            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }



        public Boolean AddLedgerBalanceMaintenance(int Company, int Account, string BeginningLedgerBalance, string BrokerCommissions,
            string Fees, string MarginBalance, string OpenEquity, string NetEquityPrevious, string MarginPrevious,
            int ReversSettlement, string NetEquityPreviousYear, ref string ReturnMessage)
        {

            decimal decBeginningLedgerBalance = 0;
            string Balance = BeginningLedgerBalance.ToString().Replace(",", "");
            BeginningLedgerBalance = Balance;
            if (BeginningLedgerBalance != "")
            {
                decBeginningLedgerBalance = Convert.ToDecimal(BeginningLedgerBalance.ToString());
            }

            decimal decBrokerCommissions = 0;
            string Commissions = BrokerCommissions.ToString().Replace(",", "");
            BrokerCommissions = Commissions;
            if (BrokerCommissions != "")
            {
                decBrokerCommissions = Convert.ToDecimal(BrokerCommissions.ToString());
            }

            decimal decFees = 0;
            string strFees = Fees.ToString().Replace(",", "");
            Fees = strFees;
            if (Fees != "")
            {
                decFees = Convert.ToDecimal(Fees.ToString());
            }

            decimal decMarginBalance = 0;
            string strMarginBalance = MarginBalance.ToString().Replace(",", "");
            MarginBalance = strMarginBalance;
            if (MarginBalance != "")
            {
                decMarginBalance = Convert.ToDecimal(MarginBalance.ToString());
            }

            decimal decOpenEquity = 0;
            string strOpenEquity = OpenEquity.ToString().Replace(",", "");
            OpenEquity = strOpenEquity;
            if (OpenEquity != "")
            {
                decOpenEquity = Convert.ToDecimal(OpenEquity.ToString());
            }

            decimal decNetEquityPrevious = 0;
            string strNetEquityPrevious = NetEquityPrevious.ToString().Replace(",", "");
            NetEquityPrevious = strNetEquityPrevious;
            if (NetEquityPrevious != "")
            {
                decNetEquityPrevious = Convert.ToDecimal(NetEquityPrevious.ToString());
            }

            decimal decMarginPrevious = 0;
            string strMarginPrevious = MarginPrevious.ToString().Replace(",", "");
            MarginPrevious = strMarginPrevious;
            if (MarginPrevious != "")
            {
                decMarginPrevious = Convert.ToDecimal(MarginPrevious.ToString());
            }

            decimal decNetEquityPreviousYear = 0;
            string strNetEquityPreviousYear = NetEquityPreviousYear.ToString().Replace(",", "");
            NetEquityPreviousYear = strNetEquityPreviousYear;
            if (NetEquityPreviousYear != "")
            {
                decNetEquityPreviousYear = Convert.ToDecimal(NetEquityPreviousYear.ToString());
            }

            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_AddLedgerBalanceMaintenance";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Company;
                myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = Account;
                myCMD.Parameters.Add("@BeginningLedgerBalance", SqlDbType.Decimal).Value = decBeginningLedgerBalance;
                myCMD.Parameters["@BeginningLedgerBalance"].Precision = 18;
                myCMD.Parameters["@BeginningLedgerBalance"].Scale = 4;
                myCMD.Parameters.Add("@BrokerCommissions", SqlDbType.Decimal).Value = decBrokerCommissions;
                myCMD.Parameters["@BrokerCommissions"].Precision = 18;
                myCMD.Parameters["@BrokerCommissions"].Scale = 4;
                myCMD.Parameters.Add("@Fees", SqlDbType.Decimal).Value = decFees;
                myCMD.Parameters["@Fees"].Precision = 18;
                myCMD.Parameters["@Fees"].Scale = 4;
                myCMD.Parameters.Add("@MarginBalance", SqlDbType.Decimal).Value = decMarginBalance;
                myCMD.Parameters["@MarginBalance"].Precision = 18;
                myCMD.Parameters["@MarginBalance"].Scale = 4;
                myCMD.Parameters.Add("@OpenEquity", SqlDbType.Decimal).Value = decOpenEquity;
                myCMD.Parameters["@OpenEquity"].Precision = 18;
                myCMD.Parameters["@OpenEquity"].Scale = 4;
                myCMD.Parameters.Add("@NetEquityPrevious", SqlDbType.Decimal).Value = decNetEquityPrevious;
                myCMD.Parameters["@NetEquityPrevious"].Precision = 18;
                myCMD.Parameters["@NetEquityPrevious"].Scale = 4;
                myCMD.Parameters.Add("@MarginPrevious", SqlDbType.Decimal).Value = decMarginPrevious;
                myCMD.Parameters["@MarginPrevious"].Precision = 18;
                myCMD.Parameters["@MarginPrevious"].Scale = 4;
                myCMD.Parameters.Add("@NetEquityPreviousYear", SqlDbType.Decimal).Value = decNetEquityPreviousYear;
                myCMD.Parameters["@NetEquityPreviousYear"].Precision = 18;
                myCMD.Parameters["@NetEquityPreviousYear"].Scale = 4;
                myCMD.Parameters.Add("@ReverseSettlement", SqlDbType.Int).Value = ReversSettlement;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
                if (ReturnMessage != "")
                {
                    return false;
                }
                else
                {

                    return true;
                }

            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }

        public Boolean AddLedgerBalanceDetailMaintenance(int Company, int Account, int Commodity, int SortOrder, string OpenEquity, ref string ReturnMessage)
        {

            decimal decOpenEquity = 0;
            string strOpenEquity = OpenEquity.ToString().Replace(",", "");
            OpenEquity = strOpenEquity;
            if (OpenEquity != "")
            {
                decOpenEquity = Convert.ToDecimal(OpenEquity.ToString());
            }


            try
            {

                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_AddLedgerBalanceDetailMaintenance";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Company;
                myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = Account;
                myCMD.Parameters.Add("@Commodity", SqlDbType.Int).Value = Commodity;
                myCMD.Parameters.Add("@OpenEquity", SqlDbType.Decimal).Value = decOpenEquity;
                myCMD.Parameters["@OpenEquity"].Precision = 18;
                myCMD.Parameters["@OpenEquity"].Scale = 4;
                myCMD.Parameters.Add("@SortOrder", SqlDbType.Int).Value = SortOrder;
                myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
                myCMD.Parameters["@ReturnMessage"].Size = 250;
                myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
                if (ReturnMessage != "")
                {
                    return false;
                }
                else
                {

                    return true;
                }

            }
            catch (Exception e)
            {
                ReturnMessage = e.Message.ToString();
                return false;
            }
        }
    }
}