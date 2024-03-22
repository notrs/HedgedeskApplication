using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Security.Principal;

namespace HedgedeskReportProject
{
    public static class GlobalStore
    {
        public static DataTable mdtCommodity = new DataTable();
        public static DataTable mdtFuturesConfirmations = new DataTable();
        public static DataTable mdtDailyPosition = new DataTable();
        public static DataTable mdtLedgerBalance = new DataTable();
        public static DataTable mdtsubLedgerBalance = new DataTable();
        public static DataTable mdtDailySettlement = new DataTable();
        public static DataTable mdtMonthlySettlement = new DataTable();
        public static DataTable mdtMarginCall = new DataTable();
        public static DataTable mdtMarginCall740 = new DataTable();
        public static DataTable mdtMarginCall19 = new DataTable();
        public static DataTable mdtRatioPositions = new DataTable();
        public static DataTable mdtLedgerBalanceZennoh = new DataTable();
        public static Boolean misRowChanged = false;

        public static DataTable FuturesConfirmationsDataSource(String OrderDate, Int32 AccountID, Int32 CompanyID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptFuturesConfirmationReport";
            myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate;
            myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = AccountID;
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtFuturesConfirmations);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtFuturesConfirmations;
        }

        public static DataTable CentralHedgeConfirmationsDataSource(String OrderDate)
        {
            DataTable results = new DataTable();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptCHFuturesConfirmationReport";
            myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate;
            //myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = AccountID;
            //myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(results);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return results;
        }

        public static DataTable OptionTotalToday(int HedgeUserID)
        {
            DataTable results = new DataTable();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptHBOptionsTradedToday";
            myCMD.Parameters.Add("@HedgeUserID", SqlDbType.Int).Value = HedgeUserID;
            //myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(results);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return results;
        }

        public static DataTable OptionConfirmationMaster(int HedgeUserID)
        {
            DataTable results = new DataTable();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptHBOptionsConfirmationMaster";
            myCMD.Parameters.Add("@HedgeUserID", SqlDbType.Int).Value = HedgeUserID;
            //myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(results);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return results;
        }

        public static DataTable OptionConfirmation(int HedgeAccount)
        {
            DataTable results = new DataTable();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptHBOptionsConfirmation";
            myCMD.Parameters.Add("@HedgeAccount", SqlDbType.Int).Value = HedgeAccount;
            //myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(results);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return results;
        }

        public static DataTable OptionConfirmationOffset(int HedgeAccount)
        {
            DataTable results = new DataTable();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptHBOptionsConfirmation_Offset";
            myCMD.Parameters.Add("@HedgeAccount", SqlDbType.Int).Value = HedgeAccount;
            //myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(results);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return results;
        }

        public static DataTable OptionOpenPosition(String ExpirationDate, int HedgeUserID, String TradeDate)
        {
            DataTable results = new DataTable();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptHBOptionsOpenPosition";
            myCMD.Parameters.Add("@OptionExpirationDate", SqlDbType.VarChar).Value = ExpirationDate;
            myCMD.Parameters.Add("@HedgeUserID", SqlDbType.Int).Value = HedgeUserID;
            myCMD.Parameters.Add("@ContractOptionAddDate", SqlDbType.VarChar).Value = TradeDate;
            //myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(results);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return results;
        }

        public static DataTable CentralHedgeConfirmationsLiveDataSource()
        {
            DataTable results = new DataTable();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptCHFuturesConfirmationReportLive";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(results);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return results;
        }

        public static DataTable CentralHedgeConfirmationsLiveSalesDataSource(int Total)
        {
            DataTable results = new DataTable();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptCHFuturesConfirmationSalesReportLive";
            myCMD.Parameters.Add("@Total", SqlDbType.Int).Value = Total;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(results);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return results;
        }

        public static DataTable CentralHedgeConfirmationsSalesDataSource(int Total, String OrderDate)
        {
            DataTable results = new DataTable();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptCHFuturesConfirmationSalesReport";
            myCMD.Parameters.Add("@Total", SqlDbType.Int).Value = Total;
            myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(results);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return results;
        }

        public static DataTable DailyPositionDataSource(Int32 AccountID, Int32 CompanyID,
            Int32 Commodity, String OptionMonth, Int32 OptionYear)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptDailyFuturesPosition";
            myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = AccountID;
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.Parameters.Add("@Commodity", SqlDbType.Int).Value = Commodity;
            myCMD.Parameters.Add("@OptionMonth", SqlDbType.VarChar).Value = OptionMonth;
            myCMD.Parameters.Add("@OptionYear", SqlDbType.Int).Value = OptionYear;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtDailyPosition);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtDailyPosition;
        }

        public static DataTable DailyPositionByGroupDataSource(Int32 Group)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptDailyFuturesPositionGrouped";
            myCMD.Parameters.Add("@FuturesPositionGroup", SqlDbType.Int).Value = Group;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtDailyPosition);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtDailyPosition;
        }

        public static DataTable LedgerBalanceDataSource(Int32 AccountID, Int32 CompanyID, String SettlementDate)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandTimeout = 6000;
            myCMD.CommandText = "proc_rptLedgerBalanceReport";
            myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = AccountID;
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.Parameters.Add("@LastSettlementDate", SqlDbType.VarChar).Value = SettlementDate;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtLedgerBalance);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtLedgerBalance;
        }

        public static DataTable LedgerBalanceDataSourceByComm(Int32 AccountID, Int32 CompanyID, String SettlementDate)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandTimeout = 2000;
            myCMD.CommandText = "proc_rptLedgerBalanceReport_ReconciliationByCommodity";
            myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = AccountID;
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.Parameters.Add("@LastSettlementDate", SqlDbType.VarChar).Value = SettlementDate;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.CommandTimeout = 60000;
            
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtLedgerBalance);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtLedgerBalance;
        }

        public static DataTable LedgerBalanceDataSourceByComp(Int32 AccountID, Int32 CompanyID, String SettlementDate)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandTimeout = 2000;
            myCMD.CommandText = "proc_rptLedgerBalanceReport_ReconciliationByCompany";
            myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = AccountID;
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = CompanyID;
            myCMD.Parameters.Add("@LastSettlementDate", SqlDbType.VarChar).Value = SettlementDate;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.CommandTimeout = 60000;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtLedgerBalance);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtLedgerBalance;
        }


        public static DataTable subLedgerBalanceDataSource(Int32 Company, Int32 Account)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandTimeout = 2000;
            myCMD.CommandText = "proc_rptSubLedgerBalanceReportZennoh";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Company;
            myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = Account;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtsubLedgerBalance);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtsubLedgerBalance;
        }

        public static DataTable RiskPosition(Int32 CommodityID, Int32 Spec)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_qryCurrentPosition_Hedgedesk";
            myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
            myCMD.Parameters.Add("@Spec", SqlDbType.Int).Value = Spec;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtsubLedgerBalance);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtsubLedgerBalance;
        }

        public static DataTable DailySettlementDataSource(String SettlementDate, Int32 Company, Int32 Account)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptDailySettlement";
            myCMD.Parameters.Add("@SettlementDate", SqlDbType.VarChar).Value = SettlementDate;
            myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = Account;
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Company;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtDailySettlement);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtDailySettlement;
        }

        public static DataTable MonthlySettlementDataSource(Int32 Account, Int32 Company, String SettlementStartDate,
            String SettlementEndDate)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptMonthlySettlement";
            myCMD.Parameters.Add("@Account", SqlDbType.Int).Value = Account;
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Company;
            myCMD.Parameters.Add("@SettlementStartDate", SqlDbType.VarChar).Value = SettlementStartDate;
            myCMD.Parameters.Add("@SettlementEndDate", SqlDbType.VarChar).Value = SettlementEndDate;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtMonthlySettlement);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtMonthlySettlement;
        }

        public static DataTable MarginCallDataSource()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptMarginCall";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtMarginCall);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtMarginCall;
        }

        public static DataTable MarginCall740DataSource()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptMarginCall740";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtMarginCall740);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtMarginCall740;
        }

        public static DataTable MarginCall19DataSource()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptMarginCall19";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtMarginCall19);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtMarginCall19;
        }

        public static DataTable RatioPositionsDataSource(Int32 Commodity, String Month, Int32 Year)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_rptRatioPosition";
            myCMD.Parameters.Add("@Commodity", SqlDbType.Int).Value = Commodity;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtRatioPositions);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtRatioPositions;
        }
    }
}
