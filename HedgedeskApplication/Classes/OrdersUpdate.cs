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
using System.Security.Principal;


namespace HedgedeskApplication
{
    public class OrdersUpdate
    {
        public void UnSelectOrder(int ReqID)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_UnSelectRegionOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ReqID", SqlDbType.Int).Value = ReqID;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void CheckSplitFillOrder(int OrderNumber, string isApplied, string CompletedFill,
            ref string ReturnMessage, ref string OrderSent, string TradeCompany,
            string MessageID, string FilledPrice, int FillQty, string uLastPrice, string isChecked,
            ref int SelectedAmount)
        {
            string CurrentUser = WindowsIdentity.GetCurrent().Name;
            int Applied = 0;
            int Completed = 0;
            decimal decFilled = 0;
            int Checked = 0;

            if (isApplied == "1")
            {
                Applied = 1;
            }

            if (CompletedFill == "1")
            {
                Completed = 1;
            }

            if (isChecked == "1")
            {
                Checked = 1;
            }

            if (FilledPrice != "" && FilledPrice != "0")
            {
                decFilled = Convert.ToDecimal(FilledPrice);
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_SelectSplitPartialFillOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ClientOrderID", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@Applied", SqlDbType.Bit).Value = Applied;
            myCMD.Parameters.Add("@CompletedFill", SqlDbType.Bit).Value = Completed;
            myCMD.Parameters.Add("@isChecked", SqlDbType.Bit).Value = Checked;
            myCMD.Parameters.Add("@unconvertedLastPrice", SqlDbType.VarChar).Value = uLastPrice;
            myCMD.Parameters.Add("@FillQty", SqlDbType.Int).Value = Convert.ToInt32(FillQty.ToString());
            myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilled;
            myCMD.Parameters.Add("@MessageID", SqlDbType.Int).Value = Convert.ToInt32(MessageID.ToString());
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@Check", SqlDbType.Bit);
            myCMD.Parameters["@Check"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@SelectedAmount", SqlDbType.Int);
            myCMD.Parameters["@SelectedAmount"].Direction = ParameterDirection.Output;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            SelectedAmount = Convert.ToInt32((myCMD.Parameters["@SelectedAmount"].Value.ToString()));
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void AddSplitFillOrder(int OrderNumber, string isApplied, string CompletedFill,
    ref string ReturnMessage, ref string OrderSent, string TradeCompany,
    string MessageID, string FilledPrice, int FillQty, string uLastPrice, string isChecked,
           string LeavesQty, string OriginalQty, ref int RemainingQuantity, DataTable ContractOrders)
        {
            string CurrentUser = WindowsIdentity.GetCurrent().Name;
            int Applied = 0;
            int Completed = 0;
            decimal decFilled = 0;
            int Leaves = 0;
            int Original = 0;

            if (OriginalQty != "" && OriginalQty != "0")
            {
                Original = Convert.ToInt32(OriginalQty);
            }


            if (isApplied == "1")
            {
                Applied = 1;
            }

            if (CompletedFill == "1")
            {
                Completed = 1;
            }


            if (FilledPrice != "" && FilledPrice != "0")
            {
                decFilled = Convert.ToDecimal(FilledPrice);
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddSplitFillOrder_CRM";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            myCMD.Parameters.Add("@ClientOrderID", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@Applied", SqlDbType.Bit).Value = Applied;
            myCMD.Parameters.Add("@CompletedFill", SqlDbType.Bit).Value = Completed;
            //myCMD.Parameters.Add("@isChecked", SqlDbType.Bit).Value = Checked;
            //myCMD.Parameters.Add("@unconvertedLastPrice", SqlDbType.VarChar).Value = uLastPrice;
            myCMD.Parameters.Add("@FillQty", SqlDbType.Int).Value = Convert.ToInt32(FillQty.ToString());
            myCMD.Parameters.Add("@LeavesQty", SqlDbType.Int).Value = Leaves;
            myCMD.Parameters.Add("@OriginalQty", SqlDbType.Int).Value = Original;
            myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilled;
            myCMD.Parameters.Add("@MessageID", SqlDbType.Int).Value = Convert.ToInt32(MessageID.ToString());
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@RemainingQuantity", SqlDbType.Int);
            myCMD.Parameters["@RemainingQuantity"].Direction = ParameterDirection.Output;



            Conn.Open();
            adapter.Fill(ContractOrders);
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            if (myCMD.Parameters["@RemainingQuantity"].Value.ToString() == "")
            {
                RemainingQuantity = 0;
            }
            else
            {
                RemainingQuantity = Convert.ToInt32((myCMD.Parameters["@RemainingQuantity"].Value.ToString()));
            }
            
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void AddMultipleSplitFillOrder(int OrderNumber,
    ref string ReturnMessage, ref string OrderSent, string TradeCompany,
    string FilledPrice, string OriginalQty, int MessageID, string Override, ref int RemainingQuantity, DataTable ContractOrders)
        {
            string CurrentUser = WindowsIdentity.GetCurrent().Name;

            decimal decFilled = 0;

            int Original = 0;

            if (OriginalQty != "" && OriginalQty != "0")
            {
                Original = Convert.ToInt32(OriginalQty);
            }


            if (FilledPrice != "" && FilledPrice != "0")
            {
                decFilled = Convert.ToDecimal(FilledPrice);
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddMulitpleSplitFillOrder_CRM";
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ClientOrderID", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@OriginalQty", SqlDbType.Int).Value = Original;
            myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilled;
            myCMD.Parameters.Add("@MessageID", SqlDbType.Int).Value = MessageID;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@RemainingQuantity", SqlDbType.Int);
            myCMD.Parameters["@RemainingQuantity"].Direction = ParameterDirection.Output;



            Conn.Open();
            adapter.Fill(ContractOrders);
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            if (myCMD.Parameters["@RemainingQuantity"].Value.ToString() == "")
            {
                RemainingQuantity = 0;
            }
            else
            {
                RemainingQuantity = Convert.ToInt32((myCMD.Parameters["@RemainingQuantity"].Value.ToString()));
            }
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void AddMultipleSplitFillOriginal(int OrderNumber,
    ref string ReturnMessage, ref string OrderSent, string TradeCompany,
    string FilledPrice, string OriginalQty, int MessageID, string Override, ref int RemainingQuantity, DataTable ContractOrders)
        {
            string CurrentUser = WindowsIdentity.GetCurrent().Name;

            decimal decFilled = 0;

            int Original = 0;

            if (OriginalQty != "" && OriginalQty != "0")
            {
                Original = Convert.ToInt32(OriginalQty);
            }


            if (FilledPrice != "" && FilledPrice != "0")
            {
                decFilled = Convert.ToDecimal(FilledPrice);
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddMulitpleSplitFillOriginal";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ClientOrderID", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@OriginalQty", SqlDbType.Int).Value = Original;
            myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilled;
            myCMD.Parameters.Add("@MessageID", SqlDbType.Int).Value = MessageID;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@RemainingQuantity", SqlDbType.Int);
            myCMD.Parameters["@RemainingQuantity"].Direction = ParameterDirection.Output;




            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            if (myCMD.Parameters["@RemainingQuantity"].Value.ToString() == "")
            {
                RemainingQuantity = 0;
            }
            else
            {
                RemainingQuantity = Convert.ToInt32((myCMD.Parameters["@RemainingQuantity"].Value.ToString()));
            }
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void AddSplitFillOriginal(int OrderNumber, string isApplied, string CompletedFill,
    ref string ReturnMessage, ref string OrderSent, string TradeCompany,
    string MessageID, string FilledPrice, int FillQty, string uLastPrice, string Override,
           string LeavesQty, string OriginalQty, ref int RemainingQuantity, DataTable  ContractOrders)
        {
            string CurrentUser = WindowsIdentity.GetCurrent().Name;
            int Applied = 0;
            int Completed = 0;
            decimal decFilled = 0;
            int Leaves = 0;
            int Original = 0;

            if (OriginalQty != "" && OriginalQty != "0")
            {
                Original = Convert.ToInt32(OriginalQty);
            }


            if (isApplied == "1")
            {
                Applied = 1;
            }

            if (CompletedFill == "1")
            {
                Completed = 1;
            }


            if (FilledPrice != "" && FilledPrice != "0")
            {
                decFilled = Convert.ToDecimal(FilledPrice);
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddSplitFillOriginal";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ClientOrderID", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@Applied", SqlDbType.Bit).Value = Applied;
            myCMD.Parameters.Add("@CompletedFill", SqlDbType.Bit).Value = Completed;
            //myCMD.Parameters.Add("@isChecked", SqlDbType.Bit).Value = Checked;
            //myCMD.Parameters.Add("@unconvertedLastPrice", SqlDbType.VarChar).Value = uLastPrice;
            myCMD.Parameters.Add("@FillQty", SqlDbType.Int).Value = Convert.ToInt32(FillQty.ToString());
            myCMD.Parameters.Add("@LeavesQty", SqlDbType.Int).Value = Leaves;
            myCMD.Parameters.Add("@OriginalQty", SqlDbType.Int).Value = Original;
            myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decFilled;
            myCMD.Parameters.Add("@MessageID", SqlDbType.Int).Value = Convert.ToInt32(MessageID.ToString());
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.VarChar).Value = TradeCompany.ToString();
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
            myCMD.Parameters.Add("@Override", SqlDbType.VarChar).Value = Override.ToString();
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@OrderSent", SqlDbType.Int);
            myCMD.Parameters["@OrderSent"].Direction = ParameterDirection.Output;
            myCMD.Parameters.Add("@RemainingQuantity", SqlDbType.Int);
            myCMD.Parameters["@RemainingQuantity"].Direction = ParameterDirection.Output;



            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            OrderSent = (myCMD.Parameters["@OrderSent"].Value.ToString());
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            if (myCMD.Parameters["@RemainingQuantity"].Value.ToString() == "")
            {
                RemainingQuantity = 0;
            }
            else
            {
                RemainingQuantity = Convert.ToInt32((myCMD.Parameters["@RemainingQuantity"].Value.ToString()));
            }
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void ProcessSplitFillSpread(int OrderNumber, ref String ReturnMessage)
        {
            string CurrentUser = WindowsIdentity.GetCurrent().Name;

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddOrder_HedgeSplitFill_Spread";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ClientOrderID", SqlDbType.Int).Value = OrderNumber;

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

        public void SplitFillFetch(int OrderNumber, ref String ReturnMessage, DataTable dtSplitFills)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_HedgeSplitFillFetch";

            myCMD.Parameters.Add("@ClientOrderID", SqlDbType.Int).Value = OrderNumber;

            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtSplitFills);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void ProcessSplitFill(int OrderNumber, ref String ReturnMessage, DataTable ContractOrders)
        {
            string CurrentUser = WindowsIdentity.GetCurrent().Name;

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_AddOrder_HedgeSplitFill_CRM";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ClientOrderID", SqlDbType.Int).Value = OrderNumber;

            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;

            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(ContractOrders);
            Conn.Close();
            //Conn.Dispose();
            //myCMD.Dispose();

            //Conn.Open();
            //myCMD.ExecuteNonQuery();
            //Conn.Close();

            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());

            Conn.Dispose();
            myCMD.Dispose();
        }



        public void SelectOrder(int ReqID)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_SelectRegionOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ReqID", SqlDbType.Int).Value = ReqID;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void HideOrder(int OrderNumber)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_HideOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = OrderNumber;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void CheckOrder(int ReqID, ref string RegionOrder)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_CheckRegionOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ReqID", SqlDbType.Int).Value = ReqID;
            myCMD.Parameters.Add("@RegionOrder", SqlDbType.Int);
            myCMD.Parameters["@RegionOrder"].Direction = ParameterDirection.Output;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            RegionOrder = (myCMD.Parameters["@RegionOrder"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void DeleteRegionOrder(int ReqID, ref string ReturnMessage)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_DeleteRegionOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@RequestID", SqlDbType.Int).Value = ReqID;
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

        public void DeleteOrder(int OrderID, ref string ReturnMessage)
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
            ReturnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void BeginNewDay(ref string ReturnMessage)
        {

            try
            {
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandTimeout = 120;
                myCMD.CommandText = "proc_ArchiveOrders";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
            }
            catch (Exception ex)
            {
                ReturnMessage = ex.InnerException.ToString();
            }

        }

        public void UpdateClosingFuturesPrices()
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetOpenFuturesPositions";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void UpdateHedgerPosition(ref string ReturnMessage)
        {
            try
            {
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_UpdateHedgerPosition";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;

                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
            }
            catch (Exception ex)
            {
                ReturnMessage = ex.InnerException.ToString();
            }

        }

        public void GetClosingSymbols(DataTable dtClosingSymbols)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_PSOpenPositionDetailUnion";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtClosingSymbols);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public void GetUnfilledHedgepadOrders(DataTable dtOrders)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetUnfilledHedgepadOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;

            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void SetHedgeOrderDate(string NewDate)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_SetCurrentOrderDate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = NewDate;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void SetHedgeDate(string NewDate)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_SetCurrentHedgeDate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@CurrentHedgeDate", SqlDbType.DateTime).Value = NewDate;

            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void UpdateStartingPosition()
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_UpdateStartingPosition";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;

            Conn.Open();
            myCMD.ExecuteNonQuery();
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

        public void GetMoveableTrades(String Month, Int32 TradeYear, Int32 TradeCompany, DataTable dtMoveableTrades)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_MoveTradesList";
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month.ToString();
            myCMD.Parameters.Add("@Year", SqlDbType.Int).Value = TradeYear;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.Int).Value = TradeCompany;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtMoveableTrades);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void GetMoveableTradesCount(String Month, Int32 TradeYear, Int32 TradeCompany, DataTable dtMoveableTradesCount)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_MoveTradesCount";
            myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month.ToString();
            myCMD.Parameters.Add("@Year", SqlDbType.Int).Value = TradeYear;
            myCMD.Parameters.Add("@TradeCompany", SqlDbType.Int).Value = TradeCompany;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtMoveableTradesCount);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public void FillOrder(string CurrentUser, int OrderNumber, string FilledPrice, ref string ErrorMessage, ref string ReturnOverrideMessage, string Override,
            ref string OrderSent, ref string ReturnMessage)
        {

            decimal decPrice = 0;
            if (FilledPrice != "")
            {
                decPrice = Convert.ToDecimal(FilledPrice.ToString());
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_UpdateFillOnOrder";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@Return_Value", SqlDbType.Int).Value = -1;
            myCMD.Parameters["@Return_Value"].Direction = ParameterDirection.ReturnValue;
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = OrderNumber;
            myCMD.Parameters.Add("@FilledPrice", SqlDbType.Decimal).Value = decPrice;
            myCMD.Parameters["@FilledPrice"].Precision = 18;
            myCMD.Parameters["@FilledPrice"].Scale = 4;
            myCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = CurrentUser.ToString();
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

        public void MoveTrades(String Month, Int32 TradeYear, Int32 TradeCompany, Int32 ContractDetailCount, ref string ReturnMessage)
        {

            try
            {
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_MoveTradesMonthEnd";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                myCMD.Parameters.Add("@Return_Value", SqlDbType.Int).Value = -1;
                myCMD.Parameters["@Return_Value"].Direction = ParameterDirection.ReturnValue;
                myCMD.Parameters.Add("@Month", SqlDbType.VarChar).Value = Month.ToString();
                myCMD.Parameters.Add("@Year", SqlDbType.Int).Value = TradeYear;
                myCMD.Parameters.Add("@ContractDetailCount", SqlDbType.Int).Value = ContractDetailCount;
                myCMD.Parameters.Add("@TradeCompanyID", SqlDbType.Int).Value = TradeCompany;


                Conn.Open();
                myCMD.ExecuteNonQuery();
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
            }
            catch (Exception ex)
            {
                ReturnMessage = ex.Message;
            }
        }
    }

}
