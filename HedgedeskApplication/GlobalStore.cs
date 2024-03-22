using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Security.Principal;


namespace HedgedeskApplication
{
    public static class GlobalStore
    {   
        public static int RiskPositionSetting { get; set; }
        public static DataTable mdtCommodity = new DataTable(); 
        public static DataTable mdtCommodityTradingComp = new DataTable();
        public static Boolean misRowChanged = false;
        public static DataTable mdtAccounts = new DataTable();
        public static DataTable mdtFuturesPositionGroup = new DataTable();
        public static DataTable mdtMonths = new DataTable();
        public static DataTable mdtAccountsComps = new DataTable();
        public static DataTable mdtOrderTypes = new DataTable();
        public static DataTable mdtCLOrder = new DataTable();
        public static DataSet mdsOrders = new DataSet();
        public static DataSet mdsECOrder = new DataSet();
        public static DataSet mdsRegionOrders = new DataSet();
        public static DataTable mdsRegionOrdersSingle = new DataTable();
        public static DataSet mdsRejectedOrders = new DataSet();
        public static DataSet mdsCancelledOrders = new DataSet();
        public static DataSet mdsFilledOrders = new DataSet();
        public static DataSet mdsPartialFilledOrders = new DataSet();
        public static DataSet mdsSplitFillOrders = new DataSet();
        public static DataSet mdsRegionOrdersSpreads = new DataSet();
        public static DataTable mdtRegionOrdersVCF = new DataTable();
        public static DataTable mdtOrdersVCF = new DataTable();
        public static DataTable mdtOrdersDetail = new DataTable();
        public static DataTable mdtOrdersDetailHistory = new DataTable();
        public static DataTable mdtOrdersView = new DataTable();
        public static DataSet mdsECOrders = new DataSet();
        public static DataTable mdtCornPosition = new DataTable();
        public static DataTable mdtCornTotal = new DataTable(); 
        public static DataTable mdtBeanPosition = new DataTable();
        public static DataTable mdtBeanPosition_HedgePad = new DataTable();
        public static DataTable mdtBeansTotal_HedgePad = new DataTable();
        public static DataTable mdtCornPosition_HedgePad = new DataTable();
        public static DataTable mdtCornTotal_HedgePad = new DataTable();
        public static DataTable mdtWheatPosition_HedgePad = new DataTable();
        public static DataTable mdtWheatTotal_HedgePad = new DataTable();
        public static DataTable mdtBeansTotal = new DataTable();
        public static DataTable mdtWheatPosition = new DataTable();
        public static DataTable mdtWheatTotal = new DataTable();
        public static DataTable mdtComps = new DataTable();
        public static DataSet mdsBuyOrders = new DataSet();
        public static DataSet mdsSellOrders = new DataSet();
        public static DataSet mdsECSplitOrders = new DataSet();
        public static DataSet mdsECPartialOrders = new DataSet();
        public static DataTable mdsOrder = new DataTable();
        //public static DataTable mdsECOrder = new DataTable();
        public static SqlCommand myOrdersCMD = new SqlCommand();
        public static SqlDataAdapter Ordersadapter = new SqlDataAdapter(myOrdersCMD);
        public static SqlConnection OrdersConn = new SqlConnection();
        public static DataTable mdtUserSettings = new DataTable();
        public static DataTable mdtSystemSettings = new DataTable();
        public static DataTable mdtRemainingQuantity = new DataTable();
        public static DataTable mdtSecondSpreadOrder = new DataTable();
        public static DataTable mdtKCPosition_HedgePad = new DataTable();
        public static DataTable mdtKCPosition = new DataTable();
        public static DataTable mdtKCTotal = new DataTable();
        public static DataTable mdtKCTotal_HedgePad = new DataTable();
         

        public static DataTable FillCompaniesDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCompanies";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtComps);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtComps;
        }

        public static DataTable FillUserSettingsDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetUserSettings";
            myCMD.Parameters.Add("@User", SqlDbType.VarChar).Value = WindowsIdentity.GetCurrent().Name;
            myCMD.Parameters["@User"].Size = 50;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtUserSettings);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtUserSettings;
        }

        public static Boolean getIsRowChanged()
        {
            return misRowChanged;
        }

        public static void setIsRowChanged(Boolean RowChanged)
        {
            misRowChanged = RowChanged;
        }

        public static void FillCommodityTradingCompDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCommodityTradingCompany";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtCommodityTradingComp);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static DataTable FillRegionVCFOrdersDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCurrentRegionVCFOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtRegionOrdersVCF);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtRegionOrdersVCF;
        }

        public static DataTable FillSecondSpreadOrderDataTable(Int32 RequestID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetSecondSpreadOrder";
            myCMD.Parameters.Add("@RequestID", SqlDbType.Int).Value = RequestID;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtSecondSpreadOrder);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtSecondSpreadOrder;
        }
        public static DataTable FillCGBVCFOrdersDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCurrentCGBVCFOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtOrdersVCF);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtOrdersVCF;
        }


        public static DataTable FillSystemSettingsDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetSystemSettings";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtSystemSettings);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtSystemSettings;
        }

        public static DataTable FillHedgeSettingsDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetSystemHedgeSettings";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtSystemSettings);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtSystemSettings;
        }

        public static DataTable FillCornDataTable(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgedeskCHPage";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "C"; 
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtCornPosition);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtCornPosition;
        }

        public static DataTable FillCornDataTable_HedgePad(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgePad_Decimal_New";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "C";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtCornPosition_HedgePad);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtCornPosition_HedgePad;
        }

        public static DataTable FillBeanDataTable(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgedeskCHPage";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "S";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtBeanPosition);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtBeanPosition;
        }

        public static DataTable FillKCDataTable(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgedeskCHPage";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "KW";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtKCPosition);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtKCPosition;
        }

        public static DataTable FillBeanDataTable_HedgePad(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgePad_Decimal_New";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "S";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtBeanPosition_HedgePad);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtBeanPosition_HedgePad;
        }

        public static DataTable FillKCDataTable_HedgePad(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgePad_Decimal_New";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "KW";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtKCPosition_HedgePad);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtKCPosition_HedgePad;
        }

        public static DataTable FillWheatDataTable(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgedeskCHPage";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "W";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtWheatPosition);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return mdtWheatPosition;
        }

        public static DataTable FillWheatDataTable_HedgePad(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgePad_Decimal_New";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "W";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtWheatPosition_HedgePad);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return mdtWheatPosition_HedgePad;
        }
        public static DataTable FillCornTotalDataTable(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgedeskPositionPage";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "C";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtCornTotal);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtCornTotal;
        }
        public static DataTable FillBeanTotalDataTable(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgedeskPositionPage";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "S";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtBeansTotal);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtBeansTotal;
        }

        public static DataTable FillKCTotalDataTable(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgedeskPositionPage";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "KW";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtKCTotal);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtKCTotal;
        }

        public static DataTable FillWheatTotalDataTable(string Company)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_Position_HedgedeskPositionPage";
            myCMD.Parameters.Add("@Company", SqlDbType.Int).Value = Convert.ToInt32(Company);
            myCMD.Parameters.Add("@HedgerPosition", SqlDbType.VarChar).Value = "W";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtWheatTotal);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtWheatTotal;
        }

        public static DataSet FillBuyOrdersDataSet()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetBuyOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsBuyOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsBuyOrders;
        }

        public static DataSet FillSellOrdersDataSet()
        {
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_GetSellOrders";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
                Conn.Open();
                adapter.Fill(mdsSellOrders);
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();
                return mdsSellOrders;
        }
        public static DataSet FillOrdersDataTable()
        {
                OrdersConn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
                myOrdersCMD.CommandText = "proc_GetCurrentEnteredOrders";
                myOrdersCMD.CommandType = CommandType.StoredProcedure;
                myOrdersCMD.Connection = OrdersConn;
                OrdersConn.Open();
                Ordersadapter.Fill(mdsOrders);
                OrdersConn.Close();
                OrdersConn.Dispose();
                myOrdersCMD.Dispose();

            return mdsOrders;
        }

        public static DataSet FillECOrdersDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetECOrdersCurrent";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsECOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
            return mdsECOrders;


        }
        public static DataTable FillOrderDataTable(string OrderNumber)
        {
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_GetOrder";
                myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
                Conn.Open();
                adapter.Fill(mdsOrder);
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();

            return mdsOrder;
        }

        public static DataTable FillOrderDataTableSide2(string OrderNumber)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetOrderSide2";
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsOrder);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsOrder;
        }

        public static void FillBuyOrderDataTable(string OrderNumber, DataTable dtBuyOrder)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetPurchaseBuyOrder";
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtBuyOrder);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public static void FillBuyOrderFeesDataTable(string OrderNumber, DataTable dtBuyOrder)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetPurchaseBuyOrdersFees";
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtBuyOrder);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public static void FillOrderFeeTypesDataTable(DataTable dtOrderFeeTypes)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetOrderFeeTypes";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtOrderFeeTypes);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public static void FillSellOrderDataTable(string OrderNumber, DataTable dtSellOrder)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetPurchaseSellOrder";
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtSellOrder);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public static void FillSellOrderFeesDataTable(string OrderNumber, DataTable dtSellOrder)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetPurchaseSellOrdersFees";
            myCMD.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtSellOrder);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

        }

        public static DataTable FillOrderDetailDataTable(string OrderNumber)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetOrderDetail";
            myCMD.Parameters.Add("@TP_ORD_NUMB", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtOrdersDetail);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtOrdersDetail;
        }

        public static DataTable FillOrderDetailHistoryDataTable(string OrderNumber)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetOrderDetail";
            myCMD.Parameters.Add("@TP_ORD_NUMB", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtOrdersDetailHistory);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtOrdersDetailHistory;
        }

        public static DataTable FillOrderViewDataTable(string OrderNumber)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetOrderForView";
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtOrdersView);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtOrdersView;
        }
        public static DataTable FillRegionOrderDataTable(string RequestID)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetRegionOrder";
            myCMD.Parameters.Add("@RequestID", SqlDbType.Int).Value = Convert.ToInt32(RequestID);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsRegionOrdersSingle);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsRegionOrdersSingle;
        }
        public static DataSet FillRegionOrdersDataSet()
        {
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
                SqlCommand myCMD = new SqlCommand();
                myCMD.CommandText = "proc_GetCurrentRegionOrders";
                myCMD.CommandType = CommandType.StoredProcedure;
                myCMD.Connection = Conn;
                SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
                Conn.Open();
                adapter.Fill(mdsRegionOrders);
                Conn.Close();
                Conn.Dispose();
                myCMD.Dispose();

            return mdsRegionOrders;
        }

        public static DataSet FillECSplitOrdersDataSet(string OrderNumber)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetECSplitFills";
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsECSplitOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsECSplitOrders;
        }

        public static DataTable FillRemainingQuantityDataTable(string OrderNumber)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetSplitPartialRemainingQuantity";
            myCMD.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = Convert.ToInt32(OrderNumber);
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtRemainingQuantity);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtRemainingQuantity;
        }

        public static DataTable FillCLOrderDataTable(string OrderNumber)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_FindECOrder";
            myCMD.Parameters.Add("@CLOrderID", SqlDbType.VarChar).Value = OrderNumber.ToString();
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtCLOrder);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdtCLOrder;
        }


        public static DataSet FillECPartialOrdersDataSet()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetECPartialFills";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsECPartialOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsECPartialOrders;
        }


        public static DataSet FillRegionSpreadsDataSet()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCurrentRegionOrdersSpreads";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsRegionOrdersSpreads);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsRegionOrdersSpreads;
        }

        public static DataSet FillRejectedOrdersDataSet()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCurrentRejectedOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsRejectedOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsRejectedOrders;
        }

        public static DataSet FillCancelledOrdersDataSet()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCurrentCancelledOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsCancelledOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsCancelledOrders;
        }

        public static DataSet FillFilledOrdersDataSet()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCurrentFilledOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsFilledOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsFilledOrders;
        }

        public static DataSet FillPartialFilledOrdersDataSet()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCurrentPartialFillOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsPartialFilledOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsPartialFilledOrders;
        }

        public static DataSet FillSplitFillOrdersDataSet()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCurrentSplitFillOrders";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdsSplitFillOrders);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return mdsSplitFillOrders;
        }
        public static void FillCommodityDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetCommodities";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtCommodity);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void FillAccountsDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetAccounts";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtAccounts);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void FillMonthsDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetMonthsComms";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtMonths);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void FillFuturesPositionGroupsDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetFuturesPositionGroups";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtFuturesPositionGroup);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        

        public static void FillAccountCompsDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetAcctsComps";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtAccountsComps);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static void FillOrderTypesDataTable()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.HedgedeskConnectionString;

            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_GetOrderTypes";
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(mdtOrderTypes);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();
        }

        public static DataTable RiskPosition(Int32 CommodityID, Int32 Spec, DataTable dtPosition)
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = Properties.Settings.Default.Hedge100;
            SqlCommand myCMD = new SqlCommand();
            myCMD.CommandText = "proc_qryCurrentPosition_Hedgedesk";
            myCMD.Parameters.Add("@CommodityID", SqlDbType.Int).Value = CommodityID;
            myCMD.Parameters.Add("@SpecAcct", SqlDbType.Int).Value = Spec;
            myCMD.CommandType = CommandType.StoredProcedure;
            myCMD.Connection = Conn;
            SqlDataAdapter adapter = new SqlDataAdapter(myCMD);
            Conn.Open();
            adapter.Fill(dtPosition);
            Conn.Close();
            Conn.Dispose();
            myCMD.Dispose();

            return dtPosition;
        }
    }

    
}
