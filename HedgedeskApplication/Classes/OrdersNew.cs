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
    public class OrdersNew
    {
        public string CurrentCLOrderID = "";

        // Create the delegate that invokes methods for the timer.
        //public string SqlConnectionConn = "Server=MAN051FS;Database=FIX;Integrated Security=False;User id=IUser_HedgeBook;Password=hedgebook;";
        //public EventLog mHedge_Log = new EventLog();

        //private Timer mtmEC;

        public void AddOrderSingle(string TradeCompany, string Side, string Acct, string Commodity, string ExchangeLetter,
                   string Month, string Year, string Qty, string Price, string OrdType, string FilledPrice, string Company,
                   int FixEO, int FixGTC, int AcctXref, string Comments, string VCAccount, string VCTradeComp,
                   string VCComments, string SpreadID, string CurrentUser, string TransType)
        {

        }

        public void AddOrderSpread(string TradeCompany, string Side, string Acct, string Commodity, string ExchangeLetter,
           string Month, string Year, string Qty, string Price, string OrdType, string Company,
           int FixEO, int FixGTC, int AcctXref, string CurrentUser, string TransType,
           string PremiumSide, string SMonth, string SYear, string Side2, string SpreadFilledPrice,
           string RequestID1, string RequestID2, ref string OrderSent, ref string ReturnMessage, string Comments, 
           string SComments, string Override, ref string OverrideMessage)
        {
            decimal decPrice = 0;
            if (Price == "")
            {
                decPrice = 0;
            }
            else
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddOrderSpread";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
 
            myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company.ToString();
            myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@ExchangeLetter", SqlDbType.VarChar).Value = ExchangeLetter;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@Qty", SqlDbType.Int).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@FixEO", SqlDbType.Bit).Value = FixEO;
            myCMD.Parameters.Add("@FixGTC", SqlDbType.Bit).Value = FixGTC;
            myCMD.Parameters.Add("@AcctXref", SqlDbType.Int).Value = Convert.ToInt32(AcctXref.ToString());
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@TransType", SqlDbType.VarChar).Value = TransType.ToString();
            myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments.ToString();
            myCMD.Parameters["@Comments"].Size = 250;
            myCMD.Parameters.Add("@PremiumSide", SqlDbType.VarChar).Value = PremiumSide.ToString();
            myCMD.Parameters.Add("@Month2", SqlDbType.VarChar).Value = SMonth;
            myCMD.Parameters.Add("@Year2", SqlDbType.VarChar).Value = SYear;
            myCMD.Parameters.Add("@Side2", SqlDbType.VarChar).Value = Side2.ToString();
            //myCMD.Parameters.Add("@Scomments", SqlDbType.Int).Value = Convert.ToInt32(SComments.ToString());
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;
            if (RequestID1 != "")
            {
                myCMD.Parameters.Add("@RequestID1", SqlDbType.Int).Value = Convert.ToInt32(RequestID1.ToString());
                myCMD.Parameters.Add("@RequestID2", SqlDbType.Int).Value = Convert.ToInt32(RequestID2.ToString());
            }
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override.ToString();
            myCMD.Parameters["@Override"].Size = 1;
            myCMD.Parameters.Add("@OverrideMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@OverrideMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters["@OverrideMessage"].Size = 250;


            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            OverrideMessage = (myCMD.Parameters["@OverrideMessage"].Value.ToString());
            myCMD.Dispose();


        }

        public void AddOrderECSpread(string OrderNumber, string TradeCompany, string Side, string Acct, string Commodity, string ExchangeLetter,
           string Month, string Year, string Qty, string Price, string OrdType, string Company,
           int FixEO, int FixGTC, int AcctXref, string CurrentUser, string TransType,
           string PremiumSide, string SMonth, string SYear, string Side2, string SpreadFilledPrice,
           string RequestID1, string RequestID2, ref string OrderSent, ref string ReturnMessage)
        {
            decimal decPrice = 0;
            if (Price == "")
            {
                decPrice = 0;
            }
            else
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddOrderECSpread";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber.ToString());
            myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company.ToString();
            myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@ExchangeLetter", SqlDbType.VarChar).Value = ExchangeLetter;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@Qty", SqlDbType.Int).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@FixEO", SqlDbType.Bit).Value = FixEO;
            myCMD.Parameters.Add("@FixGTC", SqlDbType.Bit).Value = FixGTC;
            myCMD.Parameters.Add("@AcctXref", SqlDbType.Int).Value = Convert.ToInt32(AcctXref.ToString());
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@TransType", SqlDbType.VarChar).Value = TransType.ToString();
            myCMD.Parameters.Add("@PremiumSide", SqlDbType.VarChar).Value = PremiumSide.ToString();
            myCMD.Parameters.Add("@Month2", SqlDbType.VarChar).Value = SMonth;
            myCMD.Parameters.Add("@Year2", SqlDbType.VarChar).Value = SYear;
            myCMD.Parameters.Add("@Side2", SqlDbType.VarChar).Value = Side2.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;
            if (RequestID1 != "")
            {
                myCMD.Parameters.Add("@RequestID1", SqlDbType.Int).Value = Convert.ToInt32(RequestID1.ToString());
                myCMD.Parameters.Add("@RequestID2", SqlDbType.Int).Value = Convert.ToInt32(RequestID2.ToString());
            }


            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            myCMD.Dispose();

        }


        public void AddOrderNonECSpread(string TradeCompany, string Side, string Acct, string Commodity, string ExchangeLetter,
           string Month, string Year, string Qty, string Price, string OrdType, string Company,
           int FixEO, int FixGTC, int AcctXref, string CurrentUser, string TransType, string FilledPrice,
           string PremiumSide, string SMonth, string SYear, string Side2, string SpreadFilledPrice,
           string RequestID1, string RequestID2, string CardNumber)
        {
            decimal decPrice = 0;
            if (Price == "")
            {
                decPrice = 0;
            }
            else
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }
            decimal decFilledPrice = 0;
            if (FilledPrice == "")
            {
                decFilledPrice = 0;
            }
            else
            {
                decFilledPrice = Convert.ToDecimal(FilledPrice.ToString());
            }
            decimal decFilledPrice2 = 0;
            if (SpreadFilledPrice == "")
            {
                decFilledPrice2 = 0;
            }
            else
            {
                decFilledPrice2 = Convert.ToDecimal(SpreadFilledPrice.ToString());
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddOrderNonECSpread";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company.ToString();
            myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@ExchangeLetter", SqlDbType.VarChar).Value = ExchangeLetter;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@Qty", SqlDbType.Int).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@FixEO", SqlDbType.Bit).Value = FixEO;
            myCMD.Parameters.Add("@FixGTC", SqlDbType.Bit).Value = FixGTC;
            myCMD.Parameters.Add("@AcctXref", SqlDbType.Int).Value = Convert.ToInt32(AcctXref.ToString());
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@TransType", SqlDbType.VarChar).Value = TransType.ToString();
            myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber.ToString();
            myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilledPrice;
            myCMD.Parameters["@FilledPrice"].Precision = 18;
            myCMD.Parameters["@FilledPrice"].Scale = 4;
            myCMD.Parameters.Add("@PremiumSide", SqlDbType.VarChar).Value = PremiumSide.ToString();
            myCMD.Parameters.Add("@Month2", SqlDbType.VarChar).Value = SMonth;
            myCMD.Parameters.Add("@Year2", SqlDbType.VarChar).Value = SYear;
            myCMD.Parameters.Add("@Side2", SqlDbType.VarChar).Value = Side2.ToString();
            myCMD.Parameters.Add("@FilledPrice2", SqlDbType.Decimal).Value = decFilledPrice2;
            myCMD.Parameters["@FilledPrice2"].Precision = 18;
            myCMD.Parameters["@FilledPrice2"].Scale = 4;
            if (RequestID1 != "")
            {
                myCMD.Parameters.Add("@RequestID1", SqlDbType.Int).Value = Convert.ToInt32(RequestID1.ToString());
                myCMD.Parameters.Add("@RequestID2", SqlDbType.Int).Value = Convert.ToInt32(RequestID2.ToString());
            }


            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void AddOrderSingle(string TradeCompany, string Side, string Acct, string Commodity, string ExchangeLetter,
           string Month, string Year, string Qty, string Price, string OrdType, string Company,
           int FixEO, int FixGTC, int AcctXref, string CurrentUser, string TransType, ref string OrderSent, ref string ReturnMessage)
        {
            decimal decPrice = 0;
            if (Price == "")
            {
                decPrice = 0;
            }
            else
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddOrderSingle";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company.ToString();
            myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@ExchangeLetter", SqlDbType.VarChar).Value = ExchangeLetter;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@Qty", SqlDbType.Int).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@FixEO", SqlDbType.Bit).Value = FixEO;
            myCMD.Parameters.Add("@FixGTC", SqlDbType.Bit).Value = FixGTC;
            myCMD.Parameters.Add("@AcctXref", SqlDbType.Int).Value = Convert.ToInt32(AcctXref.ToString());
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@TransType", SqlDbType.VarChar).Value = TransType.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void AddOrderECSingle(string OrderNumber, string TradeCompany, string Side, string Acct, string Commodity, string ExchangeLetter,
           string Month, string Year, string Qty, string Price, string OrdType, string Company,
           int FixEO, int FixGTC, int AcctXref, string CurrentUser, string TransType, ref string OrderSent, ref string ReturnMessage)
        {
            decimal decPrice = 0;
            if (Price == "")
            {
                decPrice = 0;
            }
            else
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddECOrderSingle";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber.ToString());
            myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company.ToString();
            myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@ExchangeLetter", SqlDbType.VarChar).Value = ExchangeLetter;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@Qty", SqlDbType.Int).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@FixEO", SqlDbType.Bit).Value = FixEO;
            myCMD.Parameters.Add("@FixGTC", SqlDbType.Bit).Value = FixGTC;
            myCMD.Parameters.Add("@AcctXref", SqlDbType.Int).Value = Convert.ToInt32(AcctXref.ToString());
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@TransType", SqlDbType.VarChar).Value = TransType.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void AddCTSOrder(string OrderNumber, string Qty, string Price, string CurrentUser, ref string ReturnMessage)
        {
            try
            {
                decimal decPrice = 0;
                if (Price == "")
                {
                    decPrice = 0;
                }
                else
                {
                    decPrice = Convert.ToDecimal(Price.ToString());
                }
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_AddCTSFillOrder";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@ClientOrderID", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber.ToString());
                myCMD.Parameters.Add("@Amount", SqlDbType.Int).Value = Convert.ToDecimal(Qty.ToString());
                myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decPrice;
                myCMD.Parameters["@FilledPrice"].Precision = 18;
                myCMD.Parameters["@FilledPrice"].Scale = 4;
                myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
            }
            catch (Exception ex)
            {
                ReturnMessage = ex.Message.ToString();
            }



        }
        public void EditOrderInGrid(string OrderNumber, string Acct, string Side, string Qty,
            string Month, string Year, string Commodity, string Price, string FilledPrice, string OrdType, 
            string TradeCompany, string ParentID,
            int FixEO, int FixGTC, string CardNumber, string Status, string Comments, string OrderDate,
            string VCAccount, string VCTradeCompany, string VCComments, string CurrentUser, 
            string ExchangeLetter, ref string OrderSent, ref string ReturnMessage, int Can)
        {
            decimal decPrice = 0;
            decimal decFilledPrice = 0;
            if (Price == "")
            {
                decPrice = 0;
            }
            else
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }
            if (FilledPrice == "")
            {
                decFilledPrice = 0;
            }
            else
            {
                decFilledPrice = Convert.ToDecimal(FilledPrice.ToString());
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_UpdateOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber.ToString());
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
            myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
            myCMD.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters["@Qty"].Precision = 18;
            myCMD.Parameters["@Qty"].Scale = 2;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilledPrice;
            myCMD.Parameters["@FilledPrice"].Precision = 18;
            myCMD.Parameters["@FilledPrice"].Scale = 4;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            if (ParentID == "")
            {
                myCMD.Parameters.Add("@Parent", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myCMD.Parameters.Add("@Parent", SqlDbType.Int).Value = Convert.ToInt32(ParentID.ToString());
            }
            myCMD.Parameters.Add("@FixEO", SqlDbType.Bit).Value = FixEO;
            myCMD.Parameters.Add("@FixGTC", SqlDbType.Bit).Value = FixGTC;
            myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber.ToString();
            myCMD.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.ToString();
            myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments.ToString();
            myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate.ToString();
            myCMD.Parameters.Add("@VCAccount", SqlDbType.VarChar).Value = VCAccount.ToString();
            myCMD.Parameters.Add("@VCTradeCompany", SqlDbType.VarChar).Value = VCTradeCompany.ToString();
            myCMD.Parameters.Add("@VCComments", SqlDbType.VarChar).Value = VCComments.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ExchangeLetter", SqlDbType.VarChar).Value = ExchangeLetter;
            myCMD.Parameters.Add("@Cancelled", SqlDbType.Bit).Value = Can;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();


        }
        public Boolean EditOrder(string OrderNumber, string Acct, string Side, string Qty,
            string Month, string Year, string Commodity, string ExchangeLetter, string FilledPrice, string OrdType,
            string Company, string OrderDate, string CardNumber, string TradeCompany, string AcctXref, string Seq,
            string Acct2, string Side2, string Qty2,
            string Month2, string Year2, string Commodity2, string ExchangeLetter2, string FilledPrice2, string OrdType2,
            string Company2, string OrderDate2, string CardNumber2, string TradeCompany2, string AcctXref2, string Seq2,
            string CurrentUser, ref string ReturnMessage)
        {
            try
            {
                decimal decFilledPrice = 0;

                if (FilledPrice == "")
                {
                    decFilledPrice = 0;
                }
                else
                {
                    decFilledPrice = Convert.ToDecimal(FilledPrice.ToString());
                }


                decimal decFilledPrice2 = 0;

                if (FilledPrice2 == "")
                {
                    decFilledPrice2 = 0;
                }
                else
                {
                    decFilledPrice2 = Convert.ToDecimal(FilledPrice2.ToString());
                }
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateOrderFinal";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber.ToString());
                myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
                myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
                myCMD.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.ToString());
                myCMD.Parameters["@Qty"].Precision = 18;
                myCMD.Parameters["@Qty"].Scale = 2;
                myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
                myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
                myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
                myCMD.Parameters.Add("@ExchangeLetter", SqlDbType.VarChar).Value = ExchangeLetter;
                myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilledPrice;
                myCMD.Parameters["@FilledPrice"].Precision = 18;
                myCMD.Parameters["@FilledPrice"].Scale = 4;
                myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
                myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company.ToString();
                myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate.ToString();
                myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber.ToString();
                myCMD.Parameters.Add("@AcctXref", SqlDbType.VarChar).Value = AcctXref.ToString();
                myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
                myCMD.Parameters.Add("@SEQ", SqlDbType.VarChar).Value = Seq.ToString();
                if (Acct2.ToString() != "")
                {
                    myCMD.Parameters.Add("@Acct2", SqlDbType.Int).Value = Convert.ToInt32(Acct2.ToString());
                }
                else
                {
                    myCMD.Parameters.Add("@Acct2", SqlDbType.Int).Value = 0;
                }
                myCMD.Parameters.Add("@Side2", SqlDbType.VarChar).Value = Side2.ToString();
                if (Qty2.ToString() != "")
                {
                    myCMD.Parameters.Add("@Qty2", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty2.ToString());
                }
                else
                {
                    myCMD.Parameters.Add("@Qty2", SqlDbType.Decimal).Value = 0;
                }
                
                myCMD.Parameters["@Qty2"].Precision = 18;
                myCMD.Parameters["@Qty2"].Scale = 2;
                myCMD.Parameters.Add("@Month2", SqlDbType.VarChar).Value = Month2;
                myCMD.Parameters.Add("@Year2", SqlDbType.VarChar).Value = Year2;
                myCMD.Parameters.Add("@Commodity2", SqlDbType.VarChar).Value = Commodity2;
                myCMD.Parameters.Add("@ExchangeLetter2", SqlDbType.VarChar).Value = ExchangeLetter2;
                myCMD.Parameters.Add("@FilledPrice2", SqlDbType.Decimal).Value = decFilledPrice2;
                myCMD.Parameters["@FilledPrice2"].Precision = 18;
                myCMD.Parameters["@FilledPrice2"].Scale = 4;
                myCMD.Parameters.Add("@OrdType2", SqlDbType.VarChar).Value = OrdType2;
                myCMD.Parameters.Add("@Company2", SqlDbType.VarChar).Value = Company2.ToString();
                myCMD.Parameters.Add("@OrderDate2", SqlDbType.VarChar).Value = OrderDate2.ToString();
                myCMD.Parameters.Add("@CardNumber2", SqlDbType.VarChar).Value = CardNumber2.ToString();
                myCMD.Parameters.Add("@AcctXref2", SqlDbType.VarChar).Value = AcctXref2.ToString();
                myCMD.Parameters.Add("@TradeCompany2", SqlDbType.VarChar).Value = TradeCompany2.ToString();
                myCMD.Parameters.Add("@SEQ2", SqlDbType.VarChar).Value = Seq2.ToString();

                myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();

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
            catch (Exception ex)
            {
                ReturnMessage = ex.Message.ToString();
                return false;
            }

        }


        public void EditOrderInGrid(string OrderNumber, string Acct, string Side, string Qty,
            string Month, string Year, string Commodity, string Price, string ChgPrice, string OrdType,
            string TradeCompany,
            int FixEO, int FixGTC, string CardNumber, string Status, string Comments, string OrderDate,
            string VCAccount, string VCTradeCompany, string VCComments, string CurrentUser,
            ref string OrderSent, ref string ReturnMessage, int Can, string RequestID)
        {
            decimal decPrice = 0;
            if (Price == "")
            {
                decPrice = 0;
            }
            else
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }
            decimal decChgPrice = 0;
            if (ChgPrice == "")
            {
                decChgPrice = 0;
            }
            else
            {
                decChgPrice = Convert.ToDecimal(ChgPrice.ToString());
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_UpdateRegionOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            //myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber.ToString());
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
            myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
            myCMD.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters["@Qty"].Precision = 18;
            myCMD.Parameters["@Qty"].Scale = 2;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@FixEO", SqlDbType.Bit).Value = FixEO;
            myCMD.Parameters.Add("@FixGTC", SqlDbType.Bit).Value = FixGTC;
            myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber.ToString();
            //myCMD.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.ToString();
            myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments.ToString();
            myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate.ToString();
            myCMD.Parameters.Add("@VCAccount", SqlDbType.VarChar).Value = VCAccount.ToString();
            myCMD.Parameters.Add("@VCTradeCompany", SqlDbType.VarChar).Value = VCTradeCompany.ToString();
            myCMD.Parameters.Add("@VCComments", SqlDbType.VarChar).Value = VCComments.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@Cancelled", SqlDbType.Bit).Value = Can;
            myCMD.Parameters.Add("@ChgPrice", SqlDbType.Decimal).Value = decChgPrice;
            myCMD.Parameters["@ChgPrice"].Precision = 18;
            myCMD.Parameters["@ChgPrice"].Scale = 4;
            myCMD.Parameters.Add("@Request_ID", SqlDbType.Int).Value = Convert.ToInt32(RequestID.ToString());
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();


        }
        public void EditVCFOrderInGrid(string Acct, string Side, string Qty,
            string Month, string Year, string Commodity, string Price, string OrdType,
            string CardNumber, string Comments, string OrderDate,
            string VCAccount, string VCTradeCompany, string VCComments, string CurrentUser,
            string RequestID, string TradeCompany)
        {
            decimal decPrice = 0;
            if (Price == "")
            {
                decPrice = 0;
            }
            else
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_UpdateRegionVCFOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
            myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
            myCMD.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
            myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber.ToString();
            myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments.ToString();
            myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate.ToString();
            myCMD.Parameters.Add("@VCAccount", SqlDbType.VarChar).Value = VCAccount.ToString();
            myCMD.Parameters.Add("@VCTradeCompany", SqlDbType.VarChar).Value = VCTradeCompany.ToString();
            myCMD.Parameters.Add("@VCComments", SqlDbType.VarChar).Value = VCComments.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@Request_ID", SqlDbType.Int).Value = Convert.ToInt32(RequestID.ToString());
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.Int).Value = Convert.ToInt32(TradeCompany.ToString());

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }
        public void EditCGBVCFOrderInGrid(string Acct, string Side, string Qty,
            string Month, string Year, string Commodity, string Price, string FilledPrice,
            string OrdType,
            string CardNumber, string Comments, string OrderDate,
            string VCAccount, string VCTradeCompany, string VCComments, string CurrentUser,
            string OrderNumber, string TradeCompany)
        {
            decimal decPrice = 0;
            if (Price == "")
            {
                decPrice = 0;
            }
            else
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }

            decimal decFilledPrice = 0;
            if (FilledPrice == "")
            {
                decFilledPrice = 0;
            }
            else
            {
                decFilledPrice = Convert.ToDecimal(FilledPrice.ToString());
            }

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_UpdateCGBVCFOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
            myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
            myCMD.Parameters.Add("@Qty", SqlDbType.Int).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4; 
            myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilledPrice;
            myCMD.Parameters["@FilledPrice"].Precision = 18;
            myCMD.Parameters["@FilledPrice"].Scale = 4;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
            myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber.ToString();
            myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments.ToString();
            myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate.ToString();
            myCMD.Parameters.Add("@VCAccount", SqlDbType.VarChar).Value = VCAccount.ToString();
            myCMD.Parameters.Add("@VCTradeCompany", SqlDbType.VarChar).Value = VCTradeCompany.ToString();
            myCMD.Parameters.Add("@VCComments", SqlDbType.VarChar).Value = VCComments.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber.ToString());
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.Int).Value = Convert.ToInt32(TradeCompany.ToString());

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }
        public void AddRegionOrderSingle(string CurrentUser, string TradeCompany, string Request_ID, ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddRegionOrderSingle";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Request_ID", SqlDbType.Int).Value = Convert.ToInt32(Request_ID.ToString());
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void AddRegionNonECOrderSingle(string CurrentUser, string TradeCompany, string Request_ID, ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddRegionNONECOrderSingle";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Request_ID", SqlDbType.Int).Value = Convert.ToInt32(Request_ID.ToString());
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void Dispose()
        {
            GC.Collect();
        }

        public void AddRegionNonECOrderSingle(string CurrentUser, string TradeCompany, string Request_ID, ref string OrderSent, ref string ReturnMessage, string CardNumber)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddRegionNONECOrderSingle";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Request_ID", SqlDbType.Int).Value = Convert.ToInt32(Request_ID.ToString());
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();


        }


        public void CancelOrder(int OrderNumber, ref string ErrorMessage, ref string ReturnOverrideMessage, string Override,
            ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_CancelOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Return_Value",  SqlDbType.Int).Value = -1;
            myCMD.Parameters["@Return_Value"].Direction = ParameterDirection.ReturnValue;
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@ErrorMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@ErrorMessage"].Size = 250;
            myCMD.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OverrideMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@OverrideMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters["@OverrideMessage"].Size = 250;
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override;
            myCMD.Parameters["@Override"].Size = 1;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            if (Int32.Parse(myCMD.Parameters["@Return_Value"].Value.ToString()) == -1)
            {
                ErrorMessage = myCMD.Parameters["@ErrorMessage"].Value.ToString();
                ReturnOverrideMessage = myCMD.Parameters["@OverrideMessage"].Value.ToString();

            }
            else
            {
                OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            }
            Conn.Dispose();
            myCMD.Dispose();

        }

        


        public void CancelReplaceMarketOrder(string CurrentUser, int OrderNumber, ref string ErrorMessage, ref string ReturnOverrideMessage, string Override,
            ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_CancelOrderAddMarket";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Return_Value", SqlDbType.Int).Value = -1;
            myCMD.Parameters["@Return_Value"].Direction = ParameterDirection.ReturnValue;
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ErrorMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@ErrorMessage"].Size = 250;
            myCMD.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OverrideMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@OverrideMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters["@OverrideMessage"].Size = 250;
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override;
            myCMD.Parameters["@Override"].Size = 1;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            if (Int32.Parse(myCMD.Parameters["@Return_Value"].Value.ToString()) == -1)
            {
                ErrorMessage = myCMD.Parameters["@ErrorMessage"].Value.ToString();
                ReturnOverrideMessage = myCMD.Parameters["@OverrideMessage"].Value.ToString();

            }
            else
            {
                OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            }
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void CloneMarketOrder(string CurrentUser, int OrderNumber, int Acct, ref string ErrorMessage, ref string ReturnOverrideMessage, string Override,
            ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_CloneOrderAddMarket";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Request_ID", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber.ToString());
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Acct;
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void ClonePricedOrder(string CurrentUser, int OrderNumber, int Acct, ref string ErrorMessage, ref string ReturnOverrideMessage, string Override,
            ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_CloneOrderAddPriced";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Request_ID", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber.ToString());
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Acct;
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void CancelReplaceMarketSpreadOrder(string CurrentUser, int OrderNumber, ref string ErrorMessage, ref string ReturnOverrideMessage, string Override,
            ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_CancelOrderAddMarketSpread";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Return_Value", SqlDbType.Int).Value = -1;
            myCMD.Parameters["@Return_Value"].Direction = ParameterDirection.ReturnValue;
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ErrorMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@ErrorMessage"].Size = 250;
            myCMD.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OverrideMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@OverrideMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters["@OverrideMessage"].Size = 250;
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override;
            myCMD.Parameters["@Override"].Size = 1;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            if (Int32.Parse(myCMD.Parameters["@Return_Value"].Value.ToString()) == -1)
            {
                ErrorMessage = myCMD.Parameters["@ErrorMessage"].Value.ToString();
                ReturnOverrideMessage = myCMD.Parameters["@OverrideMessage"].Value.ToString();

            }
            else
            {
                OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            }
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void CloneMarketSpreadOrder(string CurrentUser, int OrderNumber, ref string ErrorMessage, ref string ReturnOverrideMessage, string Override,
            ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_CloneOrderAddMarketSpread";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Return_Value", SqlDbType.Int).Value = -1;
            myCMD.Parameters["@Return_Value"].Direction = ParameterDirection.ReturnValue;
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ErrorMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@ErrorMessage"].Size = 250;
            myCMD.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OverrideMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@OverrideMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters["@OverrideMessage"].Size = 250;
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override;
            myCMD.Parameters["@Override"].Size = 1;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            if (Int32.Parse(myCMD.Parameters["@Return_Value"].Value.ToString()) == -1)
            {
                ErrorMessage = myCMD.Parameters["@ErrorMessage"].Value.ToString();
                ReturnOverrideMessage = myCMD.Parameters["@OverrideMessage"].Value.ToString();

            }
            else
            {
                OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            }
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void ClonePricedSpreadOrder(string CurrentUser, int OrderNumber, ref string ErrorMessage, ref string ReturnOverrideMessage, string Override,
            ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_CloneOrderAddPricedSpread";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Return_Value", SqlDbType.Int).Value = -1;
            myCMD.Parameters["@Return_Value"].Direction = ParameterDirection.ReturnValue;
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ErrorMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@ErrorMessage"].Size = 250;
            myCMD.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OverrideMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@OverrideMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters["@OverrideMessage"].Size = 250;
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override;
            myCMD.Parameters["@Override"].Size = 1;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            if (Int32.Parse(myCMD.Parameters["@Return_Value"].Value.ToString()) == -1)
            {
                ErrorMessage = myCMD.Parameters["@ErrorMessage"].Value.ToString();
                ReturnOverrideMessage = myCMD.Parameters["@OverrideMessage"].Value.ToString();

            }
            else
            {
                OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            }
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void CancelReplaceOrder(int OrderNumber, string Qty, string Price, 
           int FixGTC, string CurrentUser, ref string ErrorMessage, ref string ReturnOverrideMessage, string Override,
           ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            decimal decPrice = 0;
            if (Price != "")
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_CancelReplaceOrderSingle";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Return_Value", SqlDbType.Int).Value = -1;
            myCMD.Parameters["@Return_Value"].Direction = ParameterDirection.ReturnValue;
            myCMD.Parameters.Add("@TP_ORD_NUMB", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters["@Qty"].Precision = 18;
            myCMD.Parameters["@Qty"].Scale = 2;
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@FixGTC", SqlDbType.Bit).Value = FixGTC;
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ErrorMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@ErrorMessage"].Size = 250;
            myCMD.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OverrideMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@OverrideMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters["@OverrideMessage"].Size = 250;
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override;
            myCMD.Parameters["@Override"].Size = 1;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            if (Int32.Parse(myCMD.Parameters["@Return_Value"].Value.ToString()) == -1)
            {
                ErrorMessage = myCMD.Parameters["@ErrorMessage"].Value.ToString();
                ReturnOverrideMessage = myCMD.Parameters["@OverrideMessage"].Value.ToString();

            }
            else
            {
                OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            }
            Conn.Dispose();
            myCMD.Dispose();
        }
        public void CancelReplaceSpreadOrder(int OrderNumber, string Qty, string Price,
           int FixGTC, string CurrentUser, ref string ErrorMessage, ref string ReturnOverrideMessage, string Override,
           ref string OrderSent, ref string ReturnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            decimal decPrice = 0;
            if (Price != "")
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_CancelReplaceOrderSpread";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Return_Value", SqlDbType.Int).Value = -1;
            myCMD.Parameters["@Return_Value"].Direction = ParameterDirection.ReturnValue;
            myCMD.Parameters.Add("@TP_ORD_NUMB", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters["@Qty"].Precision = 18;
            myCMD.Parameters["@Qty"].Scale = 2;
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@FixGTC", SqlDbType.Bit).Value = FixGTC;
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ErrorMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@ErrorMessage"].Size = 250;
            myCMD.Parameters["@ErrorMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OverrideMessage", SqlDbType.VarChar).Value = null;
            myCMD.Parameters["@OverrideMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters["@OverrideMessage"].Size = 250;
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override;
            myCMD.Parameters["@Override"].Size = 1;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            if (Int32.Parse(myCMD.Parameters["@Return_Value"].Value.ToString()) == -1)
            {
                ErrorMessage = myCMD.Parameters["@ErrorMessage"].Value.ToString();
                ReturnOverrideMessage = myCMD.Parameters["@OverrideMessage"].Value.ToString();

            }
            else
            {
                OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
                ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            }
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void AddNonECOrder(string TradeCompany, string Side, string Acct, string Commodity, string ExchangeLetter,
                   string Month, string Year, string Qty, string Price, string OrdType, string Company,
                   int FixEO, int FixGTC, int AcctXref, string CurrentUser, string TransType, string CardNumber,
                    string VCAccount, string VCComments, string VCComp, string FilledPrice, ref string OrderSent, ref string ReturnMessage)
        {
            decimal decPrice = 0;
            decimal decFilledPrice = 0;
            if (Price == "")
            {
                decPrice = 0;
            }
            else
            {
                decPrice = Convert.ToDecimal(Price.ToString());
            }
            if (FilledPrice == "")
            {
                decFilledPrice = 0;
            }
            else
            {
                decFilledPrice = Convert.ToDecimal(FilledPrice.ToString());
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company.ToString();
            myCMD.Parameters.Add("@Side", SqlDbType.VarChar).Value = Side.ToString();
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Convert.ToInt32(Acct.ToString());
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@ExchangeLetter", SqlDbType.VarChar).Value = ExchangeLetter;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(Qty.ToString());
            myCMD.Parameters["@Qty"].Precision = 18;
            myCMD.Parameters["@Qty"].Scale = 2;
            myCMD.Parameters.Add("@Price", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@Price"].Precision = 18;
            myCMD.Parameters["@Price"].Scale = 4;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrdType;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@FixEO", SqlDbType.Bit).Value = FixEO;
            myCMD.Parameters.Add("@FixGTC", SqlDbType.Bit).Value = FixGTC;
            myCMD.Parameters.Add("@AcctXref", SqlDbType.Int).Value = Convert.ToInt32(AcctXref.ToString());
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@TransType", SqlDbType.VarChar).Value = TransType.ToString();
            myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber.ToString();
            myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilledPrice;
            myCMD.Parameters["@FilledPrice"].Precision = 18;
            myCMD.Parameters["@FilledPrice"].Scale = 4;
            myCMD.Parameters.Add("@VCAccount", SqlDbType.VarChar).Value = VCAccount.ToString();
            myCMD.Parameters.Add("@VCTradeCompany", SqlDbType.VarChar).Value = VCComp.ToString();
            myCMD.Parameters.Add("@VCComments", SqlDbType.VarChar).Value = VCComments.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();
        }
        public void GetPrice(Int32 Commodity, String HedgeMonth, String HedgeYear, DataTable dtPrice)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_HedgebookGetPrice";
            myCMD.Parameters.Add("@CommodityIN", SqlDbType.Int).Value = Commodity;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = HedgeMonth.ToString();
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = HedgeYear.ToString();
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtPrice);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }

        public void GetCMEPrice(Int32 Commodity, String HedgeMonth, String HedgeYear, DataTable dtPrice)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DTNGetPrice";
            myCMD.Parameters.Add("@CommodityIN", SqlDbType.Int).Value = Commodity;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = HedgeMonth.ToString();
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = HedgeYear.ToString();
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtPrice);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();


        }

        public Boolean DeleteOrder(int OrderID, ref string ReturnMessage)
        {
            try
            {
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_DeleteOrder";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
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
            catch(Exception ex)
            {
                ReturnMessage = ex.Message.ToString();
                return false;
            }
        }
            
    }
}
