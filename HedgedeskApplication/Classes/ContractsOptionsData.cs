using System;
using System.Data;
using System.Data.SqlClient;

namespace HedgedeskApplication.Classes
{
    static class ContractsOptionsData
    {
        public static DataTable MdtContractOptionDataTable = new DataTable();

        public static void SetOptionExpirationDate(int ContractOptionID, DateTime dateValue)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionStatusUpdateExpirationDate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = ContractOptionID;
            myCMD.Parameters.Add("@OptionExpirationDate", SqlDbType.Date).Value = dateValue;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void SetOptionStatusAccepted(int ContractOptionID, int checkedValue)
        {
            //get opposite of current checkedValue
            if (checkedValue == 0)
            {
                checkedValue = 1;
            }
            else
            {
                checkedValue = 0;
            }
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionStatusUpdatePending";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = ContractOptionID;
            myCMD.Parameters.Add("@Checked", SqlDbType.Int).Value = checkedValue;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void SetOptionStatusCancelled(int ContractOptionID)
        {

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionStatusUpdateCancelled";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = ContractOptionID;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void UpdateContractOptionExecutedPremium(int contractOptionID, decimal executedPremium, out string returnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionExecutedPremiumUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@ExecutedPremium", SqlDbType.Decimal).Value = executedPremium;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            returnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void ExpireAssignOption(int contractOptionID, string symbol, decimal settlePrice, DateTime settleDate, out string returnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionExpireOrAssign";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@Symbol", SqlDbType.VarChar).Value = symbol;
            myCMD.Parameters.Add("@SettlePrice", SqlDbType.Decimal).Value = settlePrice;
            myCMD.Parameters.Add("@SettleDate", SqlDbType.Date).Value = settleDate;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            returnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void UpdateContractOptionSetPremium(int contractOptionID, decimal executedPremium)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionSetPremiumUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@ExecutedPremium", SqlDbType.Decimal).Value = executedPremium;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void UpdateContractDetailFuturesPrice(int contractOptionID, decimal futuresPrice)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionFuturesPriceUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@FuturesPrice", SqlDbType.Decimal).Value = futuresPrice;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void UpdateContractDetailSoldPremium(int contractOptionID, decimal soldPremium, out string returnMessage)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionStatusUpdateSold";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@SoldPremium", SqlDbType.Decimal).Value = soldPremium;
            myCMD.Parameters.Add("@ReturnMessage", SqlDbType.VarChar);
            myCMD.Parameters["@ReturnMessage"].Size = 250;
            myCMD.Parameters["@ReturnMessage"].Direction = ParameterDirection.Output;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            returnMessage = (myCMD.Parameters["@ReturnMessage"].Value.ToString());
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void UpdateContractDetailOrderNumber(int contractOptionID, int orderNumber)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionOrderNumberUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = orderNumber;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void UpdateContractDetailCardNumber(int contractOptionID, String cardNumber)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionCardNumberUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@CardNumber", SqlDbType.VarChar).Value = cardNumber;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void UpdateContractDetailOrderDateTime(int contractOptionID, DateTime orderDateTime)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionOrderDateTimeUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@OrderDateTime", SqlDbType.DateTime).Value = orderDateTime;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void UpdateContractDetailAssignmentDate(int contractOptionID, DateTime assignmentDate)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionAssignmentDateUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@AssignmentDate", SqlDbType.DateTime).Value = assignmentDate;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void UpdateContractDetailAssignedQuantity(int contractOptionID, int assignedQuantity)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionAssignedQuantityUpdate";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@AssignedQuantity", SqlDbType.Int).Value = assignedQuantity;
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void OptionEmail(int contractOptionID, string emailType)
        {
            switch (emailType)
            {
                case "Executed" :
                    ExecutedPremiumEmail(contractOptionID);
                    break;
                case "Working":
                    WorkingStatusEmail(contractOptionID);
                    break; 
                case "Cancelled" :
                    OptionCancelledEmail(contractOptionID);
                    break;
                case "FuturesSet":
                    OptionFuturesSetEmail(contractOptionID);
                    break;
                case "SoldPremium":
                    OptionFuturesSoldPremium(contractOptionID);
                    break;
            }
        }

        public static void ExecutedPremiumEmail(int contractOptionID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionEmailSender";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@Type", SqlDbType.VarChar).Value = "Executed";
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void WorkingStatusEmail(int contractOptionID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionEmailSender";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@Type", SqlDbType.VarChar).Value = "Working";
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void OptionFuturesSetEmail(int contractOptionID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionEmailSender";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@Type", SqlDbType.VarChar).Value = "FuturesSet";
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void OptionFuturesSoldPremium(int contractOptionID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionEmailSender";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@Type", SqlDbType.VarChar).Value = "Sold";
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void OptionCancelledEmail(int contractOptionID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_OptionEmailSender";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            myCMD.Parameters.Add("@ContractOptionID", SqlDbType.Int).Value = contractOptionID;
            myCMD.Parameters.Add("@Type", SqlDbType.VarChar).Value = "Cancelled";
            Conn.Open();
            myCMD.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }
    }
}
