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
    class PurchaseSettle
    {

        public Boolean MoveSingleOrder(string OrderNumber, string CurrentUser, ref string ReturnMessage)
        {
            try
            {
                
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_MoveSingleOrderToPSOrderTables";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber.ToString());
                
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
        
        
        public void TransferTradesToPSTables()
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandTimeout = 120;
            myCMD.CommandText = "proc_AddOrdersToPSTables";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void RunPurchaseUnsettle(string NewDate)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandTimeout = 120;
            myCMD.CommandText = "proc_PSUnsettle";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@UnSettleDate", SqlDbType.DateTime).Value = NewDate;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void RunPurchaseSettle(string NewDate)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "sp_PurchaseSettle";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@SettleDate", SqlDbType.DateTime).Value = NewDate;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }


        public Boolean UpdatePurchaseSettleBuyOrdersLimited(int OrderID, string CardNumber, string Amount, string OrderType, string FilledPrice, string Comments, ref string ReturnMessage)
        {

            try
            {
                decimal decAmount = 0;
                decimal decFilledPrice = 0;

                if (Amount != "")
                {
                    decAmount = Convert.ToDecimal(Amount.ToString());
                }

                if (FilledPrice != "")
                {
                    decFilledPrice = Convert.ToDecimal(FilledPrice.ToString());
                }


                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdatePurchaseSettleBuyOrdersLimited";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilledPrice;
                myCMD.Parameters["@FilledPrice"].Precision = 18;
                myCMD.Parameters["@FilledPrice"].Scale = 4;
                myCMD.Parameters.Add("@Amount", SqlDbType.Decimal).Value = decAmount;
                myCMD.Parameters["@Amount"].Precision = 18;
                myCMD.Parameters["@Amount"].Scale = 4;
                myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber;
                myCMD.Parameters.Add("@OrderType", SqlDbType.VarChar).Value = OrderType;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
                myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments;

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

        public Boolean UpdatePurchaseSettleSellOrdersLimited(int OrderID, string CardNumber, string Amount, string OrderType, string FilledPrice, string Comments, ref string ReturnMessage)
        {

            try
            {
                decimal decAmount = 0;
                decimal decFilledPrice = 0;

                if (Amount != "")
                {
                    decAmount = Convert.ToDecimal(Amount.ToString());
                }

                if (FilledPrice != "")
                {
                    decFilledPrice = Convert.ToDecimal(FilledPrice.ToString());
                }


                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdatePurchaseSettleSellOrdersLimited";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilledPrice;
                myCMD.Parameters["@FilledPrice"].Precision = 18;
                myCMD.Parameters["@FilledPrice"].Scale = 4;
                myCMD.Parameters.Add("@Amount", SqlDbType.Decimal).Value = decAmount;
                myCMD.Parameters["@Amount"].Precision = 18;
                myCMD.Parameters["@Amount"].Scale = 4;
                myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber;
                myCMD.Parameters.Add("@OrderType", SqlDbType.VarChar).Value = OrderType;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
                myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments;

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

        public Boolean UpdatePurchaseSettleBuyOrders(int OrderID, string CardNumber, string Amount, string OrderType, string FilledPrice, 
            string Account, string Exch, string OptionMonth, string OptionYear, string TradeCompany, string Commodity,
            string AcctXref, string Company, string OrderDate, string OrderNumber, string Seq, ref string ReturnMessage)
        {

            try
            {
                decimal decAmount = 0;
                decimal decFilledPrice = 0;

                if (Amount != "")
                {
                    decAmount = Convert.ToDecimal(Amount.ToString());
                }

                if (FilledPrice != "")
                {
                    decFilledPrice = Convert.ToDecimal(FilledPrice.ToString());
                }


                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdatePurchaseSettleBuyOrders";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilledPrice;
                myCMD.Parameters["@FilledPrice"].Precision = 18;
                myCMD.Parameters["@FilledPrice"].Scale = 4;
                myCMD.Parameters.Add("@Amount", SqlDbType.Decimal).Value = decAmount;
                myCMD.Parameters["@Amount"].Precision = 18;
                myCMD.Parameters["@Amount"].Scale = 4;
                myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber;
                myCMD.Parameters.Add("@OrderType", SqlDbType.VarChar).Value = OrderType;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
                //myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments;
                myCMD.Parameters.Add("@Account", SqlDbType.VarChar).Value = Account;
                myCMD.Parameters.Add("@Exch", SqlDbType.VarChar).Value = Exch;
                myCMD.Parameters.Add("@OptionMonth", SqlDbType.VarChar).Value = OptionMonth;
                myCMD.Parameters.Add("@OptionYear", SqlDbType.VarChar).Value = OptionYear;
                myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
                myCMD.Parameters.Add("@AcctXref", SqlDbType.VarChar).Value = AcctXref;
                myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate;
                myCMD.Parameters.Add("@OrderNumber", SqlDbType.VarChar).Value = OrderNumber;
                myCMD.Parameters.Add("@OrderSeq", SqlDbType.VarChar).Value = Seq;

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

        public Boolean UpdatePurchaseSettleSellOrders(int OrderID, string CardNumber, string Amount, string OrderType, string FilledPrice,
           string Account, string Exch, string OptionMonth, string OptionYear, string TradeCompany, string Commodity,
           string AcctXref, string Company, string OrderDate, string OrderNumber, string Seq, ref string ReturnMessage)
        {

            try
            {
                decimal decAmount = 0;
                decimal decFilledPrice = 0;

                if (Amount != "")
                {
                    decAmount = Convert.ToDecimal(Amount.ToString());
                }

                if (FilledPrice != "")
                {
                    decFilledPrice = Convert.ToDecimal(FilledPrice.ToString());
                }


                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdatePurchaseSettleSellOrders";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilledPrice;
                myCMD.Parameters["@FilledPrice"].Precision = 18;
                myCMD.Parameters["@FilledPrice"].Scale = 4;
                myCMD.Parameters.Add("@Amount", SqlDbType.Decimal).Value = decAmount;
                myCMD.Parameters["@Amount"].Precision = 18;
                myCMD.Parameters["@Amount"].Scale = 4;
                myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber;
                myCMD.Parameters.Add("@OrderType", SqlDbType.VarChar).Value = OrderType;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
                //myCMD.Parameters.Add("@Comments", SqlDbType.VarChar).Value = Comments;
                myCMD.Parameters.Add("@Account", SqlDbType.VarChar).Value = Account;
                myCMD.Parameters.Add("@Exch", SqlDbType.VarChar).Value = Exch;
                myCMD.Parameters.Add("@OptionMonth", SqlDbType.VarChar).Value = OptionMonth;
                myCMD.Parameters.Add("@OptionYear", SqlDbType.VarChar).Value = OptionYear;
                myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
                myCMD.Parameters.Add("@AcctXref", SqlDbType.VarChar).Value = AcctXref;
                myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate;
                myCMD.Parameters.Add("@OrderNumber", SqlDbType.VarChar).Value = OrderNumber;
                myCMD.Parameters.Add("@OrderSeq", SqlDbType.VarChar).Value = Seq;

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

        public Boolean MoveBuyOrders(int OrderID, ref string ReturnMessage)
        {

            try
            {


                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_MovePurchaseSettleBuyOrders";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;

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

        public Boolean MoveSellOrders(int OrderID, ref string ReturnMessage)
        {

            try
            {


                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_MovePurchaseSettleSellOrders";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;

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

        public Boolean UpdateBuyOrdersFees(int OrderID, string FeeTypeID, string Amount, ref string ReturnMessage)
        {

            try
            {
                decimal decAmount = 0;

                if (Amount != "")
                {
                    decAmount = Convert.ToDecimal(Amount.ToString());
                }

                
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdatePurchaseSettleBuyOrdersFees";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@Amount", SqlDbType.Decimal).Value = decAmount;
                myCMD.Parameters["@Amount"].Precision = 18;
                myCMD.Parameters["@Amount"].Scale = 4;
                myCMD.Parameters.Add("@FeeTypeID", SqlDbType.VarChar).Value = FeeTypeID;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;

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

        public void AddPurchaseSettleBuyOrder(string TradeCompany, string Side, string Acct, string Commodity, string ExchangeLetter,
                   string Month, string Year, string Qty, string Price, string OrdType, string Company,
                   int FixEO, int FixGTC, int AcctXref, string CurrentUser, string TransType, string CardNumber,
                    string VCAccount, string VCComments, string VCComp, string FilledPrice, string OrderDate)
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
            myCMD.CommandText = "proc_AddPurchaseSettleBuyOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate.ToString();
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
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void AddPurchaseSettleSellOrder(string TradeCompany, string Side, string Acct, string Commodity, string ExchangeLetter,
                   string Month, string Year, string Qty, string Price, string OrdType, string Company,
                   int FixEO, int FixGTC, int AcctXref, string CurrentUser, string TransType, string CardNumber,
                    string VCAccount, string VCComments, string VCComp, string FilledPrice, string OrderDate)
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
            myCMD.CommandText = "proc_AddPurchaseSettleSellOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = OrderDate.ToString();
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
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void DeletePurchaseSettleBuyOrder(int OrderID, ref string ReturnMessage)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeletePSBuyOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void DeletePurchaseSettleSellOrder(int OrderID, ref string ReturnMessage)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeletePSSellOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();

        }

        public Boolean AddBuyOrdersFees(int OrderID, string FeeTypeID, string Amount, ref string ReturnMessage)
        {

            try
            {
                decimal decAmount = 0;

                if (Amount != "")
                {
                    decAmount = Convert.ToDecimal(Amount.ToString());
                }


                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_AddPurchaseSettleBuyOrdersFees";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@Amount", SqlDbType.Decimal).Value = decAmount;
                myCMD.Parameters["@Amount"].Precision = 18;
                myCMD.Parameters["@Amount"].Scale = 4;
                myCMD.Parameters.Add("@FeeTypeID", SqlDbType.VarChar).Value = FeeTypeID;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;

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

        public Boolean AddSellOrdersFees(int OrderID, string FeeTypeID, string Amount, ref string ReturnMessage)
        {

            try
            {
                decimal decAmount = 0;

                if (Amount != "")
                {
                    decAmount = Convert.ToDecimal(Amount.ToString());
                }


                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_AddPurchaseSettleSellOrdersFees";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@Amount", SqlDbType.Decimal).Value = decAmount;
                myCMD.Parameters["@Amount"].Precision = 18;
                myCMD.Parameters["@Amount"].Scale = 4;
                myCMD.Parameters.Add("@FeeTypeID", SqlDbType.VarChar).Value = FeeTypeID;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;

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

        public Boolean UpdateSellOrdersFees(int OrderID, string FeeTypeID, string Amount, ref string ReturnMessage)
        {

            try
            {
                decimal decAmount = 0;

                if (Amount != "")
                {
                    decAmount = Convert.ToDecimal(Amount.ToString());
                }


                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdatePurchaseSettleSellOrdersFees";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@Amount", SqlDbType.Decimal).Value = decAmount;
                myCMD.Parameters["@Amount"].Precision = 18;
                myCMD.Parameters["@Amount"].Scale = 4;
                myCMD.Parameters.Add("@FeeTypeID", SqlDbType.VarChar).Value = FeeTypeID;
                myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;

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

        public void UpdateLastSettleDate(string NewDate)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_SetLastSettleDate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@SettleDate", SqlDbType.DateTime).Value = NewDate;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void GetPurchaseSettleBuyOrders(String Company, Int32 Account, String OrderType,
            String Commodity, String CardNumber, String Transferred, String TradingCompany,
            String Month, String Year, Int32 OrderID, Int32 OrderNumberFrom, Int32 OrderNumberTo,
            String OrderDateFrom, String OrderDateTo, DataTable dtBuyOrders)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetPurchaseBuyOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company;
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Account;
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrderType;
            myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber;
            myCMD.Parameters.Add("@Transferred", SqlDbType.VarChar).Value = Transferred;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradingCompany;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
            myCMD.Parameters.Add("@OrderNumberFrom", SqlDbType.Int).Value = OrderNumberFrom;
            myCMD.Parameters.Add("@OrderNumberTo", SqlDbType.Int).Value = OrderNumberTo;
            myCMD.Parameters.Add("@OrderDateFrom", SqlDbType.VarChar).Value = OrderDateFrom;
            myCMD.Parameters.Add("@OrderDateTo", SqlDbType.VarChar).Value = OrderDateTo;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtBuyOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose(); 

        }

        public void GetPurchaseSettleBuyApplications(String OrderID,  DataTable dtBuyOrders)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetPSBuyApplications";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(OrderID.ToString());
            
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtBuyOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void GetPurchaseSettleSellApplications(String OrderID, DataTable dtSellOrders)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetPSSellApplications";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(OrderID.ToString());

            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtSellOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void GetPurchaseSettleSellOrders(String Company, Int32 Account, String OrderType,
    String Commodity, String CardNumber, String Transferred, String TradingCompany,
    String Month, String Year, Int32 OrderID, Int32 OrderNumberFrom, Int32 OrderNumberTo,
    String OrderDateFrom, String OrderDateTo, DataTable dtSellOrders)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetPurchaseSellOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company;
            myCMD.Parameters.Add("@Acct", SqlDbType.Int).Value = Account;
            myCMD.Parameters.Add("@Commodity", SqlDbType.VarChar).Value = Commodity;
            myCMD.Parameters.Add("@OrdType", SqlDbType.VarChar).Value = OrderType;
            myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber;
            myCMD.Parameters.Add("@Transferred", SqlDbType.VarChar).Value = Transferred;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradingCompany;
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month;
            myCMD.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
            myCMD.Parameters.Add("@OrderNumberFrom", SqlDbType.Int).Value = OrderNumberFrom;
            myCMD.Parameters.Add("@OrderNumberTo", SqlDbType.Int).Value = OrderNumberTo;
            myCMD.Parameters.Add("@OrderDateFrom", SqlDbType.VarChar).Value = OrderDateFrom;
            myCMD.Parameters.Add("@OrderDateTo", SqlDbType.VarChar).Value = OrderDateTo;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtSellOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }


    }
}
