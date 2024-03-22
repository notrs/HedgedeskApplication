using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Timers;
using System.Security.Permissions;
using HedgedeskReportProject;
using System.IO;
using System.Xml;
using Telerik.Reporting.Processing;
using System.Net.Mail;
using System.Threading.Tasks;
using HedgedeskApplication.Classes;
using HedgedeskApplication.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HedgedeskApplication
{
    public partial class frmOrders : Form
    {

        public DataGridViewEditingControlShowingEventHandler mKeyUpController;
        public Boolean misAdding = false;
        public Boolean mLoading = false;
        public String ReportName = "";
        public int mColumnIndex = 0;
        public int mRowsIndex = 0;
        public Boolean isRegionOrder = false;
        public Boolean isRowChanged = false;
        public Boolean isNotValidated = false;
        public int mRowIndex = 0;
        //public EventLog mHedge_Log = new EventLog();
        public DataView viewAccounts = new DataView();
        public DataView viewMonths = new DataView();
        public DataView viewCommodities = new DataView();
        public DataView viewOrdTypes = new DataView();
        public DataView viewCompanies = new DataView();
        public DataView viewAccountComps = new DataView();
        public DataView viewClosingPrices = new DataView();
        public DataTable dtOrders = new DataTable();
        public DataTable dtECSplitOrders = new DataTable();
        public DataTable dtECPartialOrders = new DataTable();
        public DataTable dtECOrders = new DataTable();
        public DataTable dtBuyOrders = new DataTable();
        public DataTable dtSellOrders = new DataTable();
        public DataTable dtCornRiskTrading = new DataTable();
        public DataTable dtBeanRiskTrading = new DataTable();
        public DataTable dtWheatRiskTrading = new DataTable();
        public DataTable dtWhiteCornRiskTrading = new DataTable();
        public DataTable dtMiloRiskTrading = new DataTable();
        public DataTable dtHardRedWheatRiskTrading = new DataTable();
        public DataTable dtCashCornRiskTrading = new DataTable();
        public DataTable dtCashBeanRiskTrading = new DataTable();
        public DataTable dtCashWheatRiskTrading = new DataTable();
        public DataTable dtCashWhiteCornRiskTrading = new DataTable();
        public DataTable dtCashMiloRiskTrading = new DataTable();
        public DataTable dtCashHardRedWheatRiskTrading = new DataTable();

        public DataTable dtRegionOrders = new DataTable();
        public DataTable dtRegionVCFOrders = new DataTable();
        public DataTable dtCGBVCFOrders = new DataTable();
        public DataTable dtCancelledOrders = new DataTable();
        public DataTable dtFilledOrders = new DataTable();
        public DataTable dtPartialFillOrders = new DataTable();
        public DataTable dtSplitFillOrders = new DataTable();
        public DataTable dtRejectedOrders = new DataTable();
        public DataTable dtRegionOrdersSpreads = new DataTable();
        public DataTable dtHedgeAccounts = new DataTable();

        public string BuyTotal = "";
        public string SellTotal = "";
        public string NetPosition = "";
        DataView dvECOrders = new DataView();

        public BindingSource bsCorn = new BindingSource();
        BindingSource bsBean2 = new BindingSource();
        BindingSource bsKC = new BindingSource();
        BindingSource bsWheat = new BindingSource();
        BindingSource bsCornTotal = new BindingSource();
        BindingSource bsWheatTotal = new BindingSource();
        BindingSource bsKCTotal = new BindingSource();
        BindingSource bsBeans2Total = new BindingSource();
        DataTable dtBean2 = new DataTable();
        DataTable dtCorn2 = new DataTable();
        DataTable dtWheat2 = new DataTable();
        DataTable dtKC2 = new DataTable();
        DataTable dtCorn2Total = new DataTable();
        DataTable dtWheat2Total = new DataTable();
        DataTable dtKC2Total = new DataTable();
        DataTable dtBeans2Total = new DataTable();


        frmHedgePad frmHedgePad = null;
        frmReports frmReports = null;
        frmOptions frmOptions = null;
        frmOrderFills frmOrderFills = null;
        frmKillSwitch frmKillSwitch = null;
          
        public BindingSource bsRegionOrders = new BindingSource();
        public bool OrderAdded = false;
        public bool optionsRed = false;

        
        public frmOrders()
        {
            try
            {
                InitializeComponent();
                //if (!System.Diagnostics.EventLog.SourceExists("NewSource"))
                //{
                //    System.Diagnostics.EventLog.CreateEventSource(
                //        "NewSource", "Hedge_Log");
                //}
                //mHedge_Log.Source = "NewSource";
                //mHedge_Log.Log = "Hedge_Log";
                //mHedge_Log.WriteEntry("HedgeLog");
                tmrOrders.Stop();
                tmrPosition.Stop();
                tmrRiskPosition.Stop();
                tmrRegionOrders.Stop();
                tmrECorders.Stop();
                this.tmrVCF.Stop();
                if (!GetUserSettings())
                {
                    MessageBox.Show("Error getting user settings.  Please contact system administration.", "Hedge Order");
                    this.Dispose();
                    return;

                }
                else
                {
                    if (GlobalStore.mdtUserSettings.Rows.Count == 0)
                    {
                        MessageBox.Show("Not a valid user in database.  Please contact system administration.", "Hedge Order");
                        this.Close();
                        this.Dispose();
                        return;
                    }
                    else
                    {
                        if (GlobalStore.mdtUserSettings.Rows[0]["ShowOrderPad"].ToString() == "True")
                        {
                            Properties.Settings.Default.ShowOrderPad = true;
                        }
                        else
                        {
                            Properties.Settings.Default.ShowOrderPad = false;
                        }
                        if (GlobalStore.mdtUserSettings.Rows[0]["AllowChangeOrderSetting"].ToString() == "True")
                        {
                            Properties.Settings.Default.AllowOrderPadChange = true;
                        }
                        else
                        {
                            Properties.Settings.Default.AllowOrderPadChange = false;
                        }
                        if (GlobalStore.mdtUserSettings.Rows[0]["StartPage"].ToString() == "Orders")
                        {
                            Properties.Settings.Default.StartPage = "Orders";
                        }
                        else
                        {
                            Properties.Settings.Default.StartPage = "Position";
                        }

                        Properties.Settings.Default.HedgeUserID = Convert.ToInt32(GlobalStore.mdtUserSettings.Rows[0]["HedgeUserID"].ToString());

                        if (LoadHedgeAccounts())
                        {
                            if (Properties.Settings.Default.HedgeUserID != 0)
                            {
                                this.cboHedgebookAccount.SelectedValue = Properties.Settings.Default.HedgeUserID;
                            }
                        }
                    }
                }
                if (!GetSystemSettings())
                {
                    MessageBox.Show("Error getting data from database.  Please contact system administration.", "Hedge Order");
                    this.Close();
                    return;
                }


                if (CreatePopulateData())
                {
                    if (CreatePopulateDataPosition())
                    {

                        //tmrOrders.Interval = 500;
                        //RefreshOrderGrid();
                        //GetDataForOrders();
                        //SetUpOrdersGrid();
                        tmrOrders.Start();
                        
                        tmrPosition.Start();
                        tmrRegionOrders.Start();
                        tmrECorders.Start();
                        tmrRiskPosition.Start();
                        tmrVCF.Start();

                    }
                    else
                    {
                        MessageBox.Show("Error getting data from database.  Please contact system administration.", "Hedge Order");
                        this.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error getting data from database.  Please contact system administration.", "Hedge Order");
                    this.Close();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }



        }

        public Boolean GetSystemSettings()
        {
            try
            {
                DataView viewSystem = new DataView();
                GlobalStore.FillSystemSettingsDataTable();
                viewSystem = GlobalStore.mdtSystemSettings.DefaultView;
                this.dtpCurrentHedgeDate.Value = Convert.ToDateTime(viewSystem[0]["CurrentHedgeDate"].ToString());
                this.dtpCurrentOrderDate.Value = Convert.ToDateTime(viewSystem[0]["CurrentOrderDate"].ToString());
                this.dtpCurrentHedgeDate2.Value = Convert.ToDateTime(viewSystem[0]["CurrentHedgeDate"].ToString());
                this.dtpCurrentOrderDate2.Value = Convert.ToDateTime(viewSystem[0]["CurrentOrderDate"].ToString());
                Properties.Settings.Default.TradeCompanyID = Convert.ToInt32(viewSystem[0]["TradeCompanyID"].ToString());
                Properties.Settings.Default.GEMDirectory = viewSystem[0]["GEMDirectory"].ToString();
                Properties.Settings.Default.HedgeContractLimit = Convert.ToInt32(viewSystem[0]["HedgeContractLimit"].ToString());
                

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean GetUserSettings()
        {
            try
            {
                GlobalStore.FillUserSettingsDataTable();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean LoadHedgeAccounts()
        {
            try
            {
                Maintenance clsMaintanance = new Maintenance();
                clsMaintanance.GetHedgeAccounts(dtHedgeAccounts);
                cboHedgebookAccount.DataSource = dtHedgeAccounts;
                cboHedgebookAccount.DisplayMember = "UserName";
                cboHedgebookAccount.ValueMember = "UserID";
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean CreatePopulateData()
        {
            try
            {
                mLoading = true;
                DataGridViewColumn[] columns = new DataGridViewColumn[dgvOrders.Columns.Count];
                int countColumn = dgvOrders.Columns.Count;
                dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                dtECOrders = GlobalStore.FillECOrdersDataTable().Tables[0];
                dgvOrders.AutoGenerateColumns = false;
                dgvOrders.DataSource = dtOrders;
                dgvECOrders.DataSource = dtECOrders;
                dtRegionVCFOrders = GlobalStore.FillRegionVCFOrdersDataTable();
                dtCGBVCFOrders = GlobalStore.FillCGBVCFOrdersDataTable();
                dtRegionOrders = GlobalStore.FillRegionOrdersDataSet().Tables[0];
                dtRegionOrdersSpreads = GlobalStore.FillRegionSpreadsDataSet().Tables[0];
                dtFilledOrders = GlobalStore.FillFilledOrdersDataSet().Tables[0];
                dtCancelledOrders = GlobalStore.FillCancelledOrdersDataSet().Tables[0];
                dtPartialFillOrders = GlobalStore.FillPartialFilledOrdersDataSet().Tables[0];
                dtRejectedOrders = GlobalStore.FillRejectedOrdersDataSet().Tables[0];
                dtSplitFillOrders = GlobalStore.FillSplitFillOrdersDataSet().Tables[0];

                SetUpRiskPositions();

                dgvECOrders.AutoGenerateColumns = false;
                dgvRegionVCF.AutoGenerateColumns = false;
                dgvRejected.AutoGenerateColumns = false;
                this.dgvRegionVCF.DataSource = dtRegionVCFOrders;
                this.dgvRegionOrders.DataSource = dtRegionOrders;
                this.dgvRejected.DataSource = dtRejectedOrders;
                this.dgvCancelled.DataSource = dtCancelledOrders;
                dgvPartial.AutoGenerateColumns = false;
                dgvSplit.AutoGenerateColumns = false;
                this.dgvPartial.DataSource = dtPartialFillOrders;
                this.dgvSplit.DataSource = dtSplitFillOrders;
                this.dgvFilled.DataSource = dtFilledOrders;
                dtBuyOrders = GlobalStore.FillBuyOrdersDataSet().Tables[0];
                dtSellOrders = GlobalStore.FillSellOrdersDataSet().Tables[0];
                SellTotal = dtSellOrders.Compute("Sum(Qty)", "").ToString();
                BuyTotal = dtBuyOrders.Compute("Sum(Qty)", "").ToString();
                if (BuyTotal == "")
                { BuyTotal = "0"; }
                if (SellTotal == "")
                { SellTotal = "0"; }
                this.txtSellTotal.Text = SellTotal.ToString();
                this.txtBuyTotal.Text = BuyTotal.ToString();
                if (BuyTotal == "0")
                {
                    this.txtNetPosition.Text = "N/A".ToString();
                }
                else
                {
                    NetPosition = (Convert.ToDecimal(BuyTotal) - Convert.ToDecimal(SellTotal)).ToString();
                    this.txtNetPosition.Text = NetPosition.ToString();
                }
                this.dgvSell.DataSource = dtSellOrders;
                this.dgvBuy.DataSource = dtBuyOrders;
                ChangeControlColor(txtType);
                chkConfirmOrder.Checked = Properties.Settings.Default.ShowOrderPad;
                chkConfirmOrder.Enabled = Properties.Settings.Default.AllowOrderPadChange;
                if (Properties.Settings.Default.StartPage == "Orders")
                {
                    this.tbcOrder.SelectedTab = tpOrder;
                    ActiveControl = txtType;
                }
                else
                {
                    this.tbcOrder.SelectedTab = tpPositionCH;

                    ActiveControl = this.cboCompanies;
                }
                GlobalStore.FillAccountsDataTable();
                viewAccounts = GlobalStore.mdtAccounts.DefaultView;
                GlobalStore.FillMonthsDataTable();
                cboAcct.DataSource = GlobalStore.mdtAccounts.Copy();
                cboAcct.DisplayMember = "TP_ACCT";
                cboAcct.ValueMember = "TP_ACCT";
                cboAccount.DataSource = GlobalStore.mdtAccounts.Copy();
                cboAccount.DisplayMember = "TP_ACCT";
                cboAccount.ValueMember = "TP_ACCT";

                cboFindAcct.DataSource = GlobalStore.mdtAccounts.Copy();
                cboFindAcct.DisplayMember = "TP_ACCT";
                cboFindAcct.ValueMember = "TP_ACCT";

                viewMonths = GlobalStore.mdtMonths.DefaultView;
                cboMon.DataSource = GlobalStore.mdtMonths.Copy();
                cboMon.DisplayMember = "SelectMonth";
                cboMon.ValueMember = "TP_MON";
                cboMonths.DataSource = GlobalStore.mdtMonths.Copy();
                cboMonths.DisplayMember = "SelectMonth";
                cboMonths.ValueMember = "TP_MON";
                cboFindMon.DataSource = GlobalStore.mdtMonths.Copy();
                cboFindMon.DisplayMember = "SelectMonth";
                cboFindMon.ValueMember = "TP_MON";

                GlobalStore.FillCommodityDataTable();
                viewCommodities = GlobalStore.mdtCommodity.DefaultView;
                this.cboComp.DataSource = GlobalStore.mdtCommodity.Copy();
                cboComp.DisplayMember = "DESC";
                cboComp.ValueMember = "TP_COMM";

                this.cboFindComm.DataSource = GlobalStore.mdtCommodity.Copy();
                cboFindComm.DisplayMember = "DESC";
                cboFindComm.ValueMember = "TP_COMM";

                cboCommodities.DataSource = GlobalStore.mdtCommodity.Copy();
                cboCommodities.DisplayMember = "DESC";
                cboCommodities.ValueMember = "TP_COMM";
                cboCommodities.SelectedIndex = -1;
                cboComp.SelectedIndex = -1;
                cboAcct.SelectedIndex = -1;
                cboFindComm.SelectedIndex = -1;
                cboFindAcct.SelectedIndex = -1;

                cboAccount.SelectedIndex = -1;
                cboMonths.SelectedIndex = -1;
                cboMon.SelectedIndex = -1;
                cboFindMon.SelectedIndex = -1;
                cboCommodities.SelectedIndex = -1;
                GlobalStore.FillCompaniesDataTable();
                viewCompanies = GlobalStore.mdtComps.DefaultView;
                GlobalStore.FillAccountCompsDataTable();
                viewAccountComps = GlobalStore.mdtAccountsComps.DefaultView;
                GlobalStore.FillOrderTypesDataTable();
                viewOrdTypes = GlobalStore.mdtOrderTypes.DefaultView;
                cboOrderType.DataSource = GlobalStore.mdtOrderTypes.Copy();
                cboOrderType.DisplayMember = "TP_ORD_TYPE";
                cboOrderType.ValueMember = "TP_ORD_TYPE";
                cboOrderType.SelectedIndex = -1;
                cboTradingCompanies.DataSource = GlobalStore.mdtComps.Copy();
                cboTradingCompanies.DisplayMember = "CompanyDescription";
                cboTradingCompanies.ValueMember = "CompanyID";
                cboTradingCompanies.SelectedIndex = -1;
                cboCompanies.DataSource = viewCompanies;
                cboCompanies.DisplayMember = "CompanyDescription";
                cboCompanies.ValueMember = "CompanyID";
                cboCompanies.SelectedIndex = 1;
                mLoading = false;
                if (PopulateDataForPosition())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean PopulateDataForPosition()
        {
            try
            {

                GlobalStore.mdtBeanPosition.Clear();
                GlobalStore.mdtBeanPosition.Dispose();
                GlobalStore.mdtCornPosition.Clear();
                GlobalStore.mdtCornPosition.Dispose();
                GlobalStore.mdtWheatPosition.Clear();
                GlobalStore.mdtWheatPosition.Dispose();
                GlobalStore.mdtCornTotal.Clear();
                GlobalStore.mdtCornTotal.Dispose();
                GlobalStore.mdtBeansTotal.Clear();
                GlobalStore.mdtBeansTotal.Dispose();
                GlobalStore.mdtWheatTotal.Clear();
                GlobalStore.mdtKCPosition.Clear();
                GlobalStore.mdtKCPosition.Dispose();
                GlobalStore.mdtKCTotal.Clear();
                GlobalStore.mdtKCTotal.Dispose();

                OrdersUpdate ord = new OrdersUpdate();
                ord.UpdateStartingPosition();
                dtBean2.Clear();
                GlobalStore.FillBeanDataTable(cboCompanies.SelectedValue.ToString());
                dtBean2 = GlobalStore.mdtBeanPosition.Copy();
                dtBean2.DefaultView.RowFilter = "TP_ACCT = 2";
                dtBean2.AcceptChanges();
                bsBean2.DataSource = dtBean2.DefaultView;


                GlobalStore.FillCornDataTable(cboCompanies.SelectedValue.ToString());
                dtCorn2.Clear();
                dtCorn2 = GlobalStore.mdtCornPosition.Copy();
                dtCorn2.DefaultView.RowFilter = "TP_ACCT = 2";
                GlobalStore.FillCornTotalDataTable(cboCompanies.SelectedValue.ToString());
                dtCorn2Total = GlobalStore.mdtCornTotal.Copy();
                dtCorn2Total.DefaultView.RowFilter = "TP_ACCT = 2";

                bsCornTotal.DataSource = dtCorn2Total.DefaultView;
                bsCorn.DataSource = dtCorn2.DefaultView;
 
                GlobalStore.FillBeanTotalDataTable(cboCompanies.SelectedValue.ToString());
                dtBeans2Total = GlobalStore.mdtBeansTotal.Copy();
                dtBeans2Total.DefaultView.RowFilter = "TP_ACCT = 2";

                bsBeans2Total.DataSource = dtBeans2Total.DefaultView;
 
                GlobalStore.FillWheatDataTable(cboCompanies.SelectedValue.ToString());
                dtWheat2.Clear();
                dtWheat2.Dispose();
                dtWheat2 = GlobalStore.mdtWheatPosition.Copy();
                dtWheat2.DefaultView.RowFilter = "TP_ACCT = 2";
                 GlobalStore.FillWheatTotalDataTable(cboCompanies.SelectedValue.ToString());
                dtWheat2Total = GlobalStore.mdtWheatTotal.Copy();
                dtWheat2Total.DefaultView.RowFilter = "TP_ACCT = 2";

                bsWheatTotal.DataSource = dtWheat2Total.DefaultView;
                bsWheat.DataSource = dtWheat2.DefaultView;

                GlobalStore.FillKCDataTable(cboCompanies.SelectedValue.ToString());
                dtKC2.Clear();
                dtKC2.Dispose();
                dtKC2 = GlobalStore.mdtKCPosition.Copy();
                dtKC2.DefaultView.RowFilter = "TP_ACCT = 2";

                GlobalStore.FillKCTotalDataTable(cboCompanies.SelectedValue.ToString());
                dtKC2Total = GlobalStore.mdtKCTotal.Copy();
                dtKC2Total.DefaultView.RowFilter = "TP_ACCT = 2";

                bsKCTotal.DataSource = dtKC2Total.DefaultView;
                bsKC.DataSource = dtKC2.DefaultView;
 

                this.txtB2Buy.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "BUY"));


                this.txtB2Sell.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "SELL"));
                this.txtB2PRICE.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "TP_PRICE"));
                this.txtB2OrderStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "OrderStatus"));
                this.txtB2Filled.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "TP_FILLED_PRICE"));
                this.txtB2OrdType.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "TP_ORD_TYPE"));
                this.txtB2Month.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "MonthYear"));
                this.txtB2CumQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "CumQty"));
                this.txtB2CGBOrd.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "TP_ORD_NUMB"));
                this.txtB2OrderID.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "OrderID"));

                this.txtC2Buy.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "BUY"));
                this.txtC2Sell.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "SELL"));
                this.txtC2PRICE.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "TP_PRICE"));
                this.txtC2OrderStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "OrderStatus"));
                this.txtC2OrdType.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "TP_ORD_TYPE"));
                this.txtC2Filled.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "TP_FILLED_PRICE"));
                this.txtC2Month.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "MonthYear"));
                this.txtC2CumQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "CumQty"));
                this.txtC2OrderID.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "OrderID"));
                this.txtC2CGBOrd.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "TP_ORD_NUMB"));
                //this.txtC2CGBOrd.DataBindings.Add(new System.Windows.Forms.Binding("Tag", bsCorn, "TP_ORD_NUMB"));

 

                this.lblC2HP.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCornTotal, "HEDGER_POSITION"));
                this.lblC2Mon.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCornTotal, "TP_MON"));
                this.lblC2Year.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCornTotal, "TP_YEAR"));
                this.txtC2AMT.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCornTotal, "TP_AMT"));
 
                this.txtW2Buy.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "BUY"));
                this.txtW2Sell.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "SELL"));
                this.txtW2PRICE.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "TP_PRICE"));
                this.txtW2OrderStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "OrderStatus"));
                this.txtW2Filled.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "TP_FILLED_PRICE"));
                this.txtW2OrdType.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "TP_ORD_TYPE"));
                this.txtW2Month.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "MonthYear"));
                this.txtW2CumQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "CumQty"));
                this.txtW2OrderID.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "OrderID"));
                this.txtW2CGBOrd.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "TP_ORD_NUMB"));

 

                this.lblW2HP.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheatTotal, "HEDGER_POSITION"));
                this.lblW2Mon.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheatTotal, "TP_MON"));
                this.lblW2Year.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheatTotal, "TP_YEAR"));
                this.txtW2AMT.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheatTotal, "TP_AMT"));


                this.txtKC2Buy.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "BUY"));
                this.txtKC2Sell.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "SELL"));
                this.txtKC2PRICE.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "TP_PRICE"));
                this.txtKC2OrderStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "OrderStatus"));
                this.txtKC2Filled.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "TP_FILLED_PRICE"));
                this.txtKC2OrdType.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "TP_ORD_TYPE"));
                this.txtKC2Month.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "MonthYear"));
                this.txtKC2CumQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "CumQty"));
                this.txtKC2OrderID.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "OrderID"));
                this.txtKC2CGBOrd.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "TP_ORD_NUMB"));



                this.lblKC2HP.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKCTotal, "HEDGER_POSITION"));
                this.lblKC2Mon.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKCTotal, "TP_MON"));
                this.lblKC2Year.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKCTotal, "TP_YEAR"));
                this.txtKC2AMT.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKCTotal, "TP_AMT"));
                
                
                
                
                this.lblB2HP.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBeans2Total, "HEDGER_POSITION"));
                this.lblB2Mon.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBeans2Total, "TP_MON"));
                this.lblB2Year.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBeans2Total, "TP_YEAR"));
                this.txtB2AMT.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBeans2Total, "TP_AMT"));
 
                
                this.txtB2Current.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "TotalBuyAcct2"));
                this.txtB2Begin.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBeans2Total, "POS2"));
 
                
                this.txtBean2GrandTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBeans2Total, "T_POS2"));
                this.txtC2Current.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "TotalBuyAcct2"));
                this.txtC2Begin.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCornTotal, "Pos2"));
                this.txtCorn2GrandTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCornTotal, "T_Pos2"));
                this.txtW2Current.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheat, "TotalBuyAcct2"));
                this.txtW2Begin.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheatTotal, "POS2"));
                this.txtWheat2GrandTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsWheatTotal, "T_POS2"));
                this.txtKC2Current.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "TotalBuyAcct2"));
                this.txtKC2Begin.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKCTotal, "POS2"));
                this.txtKC2GrandTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKCTotal, "T_POS2"));

 

                this.drWheat2Total.DataSource = bsWheatTotal;
                this.drBeansTotal2.DataSource = bsBeans2Total;
                this.drCorn2Total.DataSource = bsCornTotal;
                this.drKC2Total.DataSource = bsKCTotal;

                this.drWheat2.DataSource = bsWheat;
                this.drCorn2.DataSource = bsCorn;
                this.dtrBeans2.DataSource = bsBean2;
                this.drKC2.DataSource = bsKC;

                this.Refresh();

                GC.Collect();

                if (CreatePopulateDataPosition())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }


        }

        public Boolean RefreshDataForPosition()
        {
            try
            {
                
                GlobalStore.mdtBeanPosition.Clear();
                GlobalStore.mdtKCPosition.Clear();
                GlobalStore.mdtKCPosition.Dispose();
                GlobalStore.mdtBeanPosition.Dispose();
                GlobalStore.mdtCornPosition.Clear();
                GlobalStore.mdtCornPosition.Dispose();
                GlobalStore.mdtWheatPosition.Clear();
                GlobalStore.mdtWheatPosition.Dispose();
                GlobalStore.mdtCornTotal.Clear();
                GlobalStore.mdtCornTotal.Dispose();
                GlobalStore.mdtBeansTotal.Clear();
                GlobalStore.mdtBeansTotal.Dispose();
                GlobalStore.mdtWheatTotal.Clear();
                GlobalStore.mdtKCTotal.Clear();


                dtBean2.Clear();
                dtBean2.Dispose();
 
                dtBeans2Total.Clear();
                dtBeans2Total.Dispose();

                dtCorn2.Clear();
                dtCorn2.Dispose();

                dtCorn2Total.Clear();
                dtCorn2Total.Dispose();

                dtWheat2.Clear();
                dtWheat2.Dispose();

                dtWheat2Total.Clear();
                dtWheat2Total.Dispose();

                dtKC2.Clear();
                dtKC2.Dispose();

                dtKC2Total.Clear();
                dtKC2Total.Dispose();

                
                OrdersUpdate ord = new OrdersUpdate();
                ord.UpdateStartingPosition();
                GlobalStore.FillBeanDataTable(cboCompanies.SelectedValue.ToString());
 

 
                dtBean2 = GlobalStore.mdtBeanPosition.Copy();
                dtBean2.DefaultView.RowFilter = "TP_ACCT = 2";
                dtBean2.AcceptChanges();

                bsBean2.DataSource = dtBean2.DefaultView;

                this.dtrBeans2.BeginResetItemTemplate();
                this.txtB2Buy.DataBindings.Clear();
                this.txtB2Sell.DataBindings.Clear();
                this.txtB2PRICE.DataBindings.Clear();
                this.txtB2OrderStatus.DataBindings.Clear();
                this.txtB2Filled.DataBindings.Clear();
                this.txtB2Month.DataBindings.Clear();
                this.txtB2OrdType.DataBindings.Clear();
                this.txtB2CumQty.DataBindings.Clear();
                this.txtB2OrderID.DataBindings.Clear();
                this.txtB2CGBOrd.DataBindings.Clear();

                this.txtB2Buy.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "BUY"));
                this.txtB2Sell.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "SELL"));
                this.txtB2PRICE.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "TP_PRICE"));
                this.txtB2OrderStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "OrderStatus"));
                this.txtB2Filled.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "TP_FILLED_PRICE"));
                this.txtB2Month.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "MonthYear"));
                this.txtB2OrdType.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "TP_ORD_TYPE"));
                this.txtB2CumQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "CumQty"));
                this.txtB2OrderID.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "OrderID"));
                this.txtB2CGBOrd.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsBean2, "TP_ORD_NUMB"));
                this.dtrBeans2.EndResetItemTemplate();

                this.dtrBeans2.BeginResetItemTemplate();
                dtrBeans2.DataSource = bsBean2;
                
                
                this.dtrBeans2.EndResetItemTemplate();

                GlobalStore.FillCornDataTable(cboCompanies.SelectedValue.ToString());

                dtCorn2 = GlobalStore.mdtCornPosition.Copy();
                dtCorn2.DefaultView.RowFilter = "TP_ACCT = 2";
                dtCorn2.AcceptChanges();

                bsCorn.DataSource = dtCorn2.DefaultView;
                this.drCorn2.BeginResetItemTemplate();
                this.txtC2Buy.DataBindings.Clear();
                this.txtC2Sell.DataBindings.Clear();
                this.txtC2PRICE.DataBindings.Clear();
                this.txtC2OrderStatus.DataBindings.Clear();
                this.txtC2Filled.DataBindings.Clear();
                this.txtC2Month.DataBindings.Clear();
                this.txtC2OrdType.DataBindings.Clear();
                this.txtC2CumQty.DataBindings.Clear();
                this.txtC2OrderID.DataBindings.Clear();
                this.txtC2CGBOrd.DataBindings.Clear();

                this.txtC2Buy.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "BUY"));
                this.txtC2Sell.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "SELL"));
                this.txtC2PRICE.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "TP_PRICE"));
                this.txtC2OrderStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "OrderStatus"));
                this.txtC2Filled.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "TP_FILLED_PRICE"));
                this.txtC2Month.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "MonthYear"));
                this.txtC2OrdType.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "TP_ORD_TYPE"));
                this.txtC2CumQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "CumQty"));
                this.txtC2OrderID.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "OrderID"));
                this.txtC2CGBOrd.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsCorn, "TP_ORD_NUMB"));


                this.drCorn2.EndResetItemTemplate();
                drCorn2.DataSource = bsCorn;

                //GlobalStore.FillKCDataTable(cboCompanies.SelectedValue.ToString());

                //dtKC2 = GlobalStore.mdtKCPosition.Copy();
                //dtKC2.DefaultView.RowFilter = "TP_ACCT = 2";
                //dtKC2.AcceptChanges();


                //bsKC.DataSource = dtKC2.DefaultView;
                //this.drKC2.BeginResetItemTemplate();
                //this.txtKC2Buy.DataBindings.Clear();
                //this.txtKC2Sell.DataBindings.Clear();
                //this.txtKC2PRICE.DataBindings.Clear();
                //this.txtKC2OrderStatus.DataBindings.Clear();
                //this.txtKC2Filled.DataBindings.Clear();
                //this.txtKC2Month.DataBindings.Clear();
                //this.txtKC2OrdType.DataBindings.Clear();
                //this.txtKC2CumQty.DataBindings.Clear();
                //this.txtKC2OrderID.DataBindings.Clear();
                //this.txtKC2CGBOrd.DataBindings.Clear();

                //this.txtKC2Buy.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "BUY"));
                //this.txtKC2Sell.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "SELL"));
                //this.txtKC2PRICE.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "TP_PRICE"));
                //this.txtKC2OrderStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "OrderStatus"));
                //this.txtKC2Filled.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "TP_FILLED_PRICE"));
                //this.txtKC2Month.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "MonthYear"));
                //this.txtKC2OrdType.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "TP_ORD_TYPE"));
                //this.txtKC2CumQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "CumQty"));
                //this.txtKC2OrderID.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "OrderID"));
                //this.txtKC2CGBOrd.DataBindings.Add(new System.Windows.Forms.Binding("Text", bsKC, "TP_ORD_NUMB"));
                //this.drKC2.DataSource = dtKC2.DefaultView;
                //drKC2.EndResetItemTemplate();

                GlobalStore.FillWheatDataTable(cboCompanies.SelectedValue.ToString());

                dtWheat2 = GlobalStore.mdtWheatPosition.Copy();
                dtWheat2.DefaultView.RowFilter = "TP_ACCT = 2";
                dtWheat2.AcceptChanges();

                drWheat2.BeginResetItemTemplate();
                bsWheat.DataSource = dtWheat2.DefaultView;
                drWheat2.DataSource = bsWheat;
                drWheat2.EndResetItemTemplate();

                GlobalStore.FillKCDataTable(cboCompanies.SelectedValue.ToString());

                dtKC2 = GlobalStore.mdtKCPosition.Copy();
                dtKC2.DefaultView.RowFilter = "TP_ACCT = 2";
                dtKC2.AcceptChanges();

                drKC2.BeginResetItemTemplate();
                bsKC.DataSource = dtKC2.DefaultView;
                drKC2.DataSource = bsKC;
                drKC2.EndResetItemTemplate();



                GlobalStore.FillCornTotalDataTable(cboCompanies.SelectedValue.ToString());

                dtCorn2Total = GlobalStore.mdtCornTotal.Copy();
                dtCorn2Total.DefaultView.RowFilter = "TP_ACCT = 2";
                dtCorn2Total.AcceptChanges();


                bsCornTotal.DataSource = dtCorn2Total.DefaultView;


                GlobalStore.FillBeanTotalDataTable(cboCompanies.SelectedValue.ToString());
 

                dtBeans2Total = GlobalStore.mdtBeansTotal.Copy();
                dtBeans2Total.DefaultView.RowFilter = "TP_ACCT = 2";
                dtBeans2Total.AcceptChanges();




                bsBeans2Total.DataSource = dtBeans2Total.DefaultView;

                GlobalStore.FillKCTotalDataTable(cboCompanies.SelectedValue.ToString());
                dtKC2Total = GlobalStore.mdtKCTotal.Copy();
                dtKC2Total.DefaultView.RowFilter = "TP_ACCT = 2";
                dtKC2Total.AcceptChanges();
                bsKCTotal.DataSource = dtKC2Total.DefaultView;

                GlobalStore.FillWheatTotalDataTable(cboCompanies.SelectedValue.ToString());
                dtWheat2Total = GlobalStore.mdtWheatTotal.Copy();
                dtWheat2Total.DefaultView.RowFilter = "TP_ACCT = 2";
                dtWheat2Total.AcceptChanges();

                bsWheatTotal.DataSource = dtWheat2Total.DefaultView;
 
                dtWheat2Total.Dispose();
                dtBean2.Dispose();


                this.Refresh();




                return true;


            }
            catch (Exception ex)
            {
                //mHedge_Log.WriteEntry(ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                //MessageBox.Show("Error getting data from database.  Please close and reopen application.", "Hedge Error");
                return false;
            }


        }
        public Boolean CreatePopulateDataPosition()
        {
            try
            {


                return true;


            }
            catch 
            {
                //mHedge_Log.WriteEntry(ex.ToString());
                return false;
            }
        }

        public Boolean PopulateDataPosition()
        {
            try
            {
                this.txtB2Buy.DataBindings.Clear();
                this.txtB2Buy.Invalidate();

                this.txtB2Sell.DataBindings.Clear();
                this.txtB2PRICE.DataBindings.Clear();
                this.txtB2OrderStatus.DataBindings.Clear();
                this.txtB2OrdType.DataBindings.Clear();
                this.txtB2Filled.DataBindings.Clear();
                this.txtB2Month.DataBindings.Clear();
                this.txtB2CumQty.DataBindings.Clear();
                this.btnBean2Clone.DataBindings.Clear();
                this.btnBean2Edit.DataBindings.Clear();
                this.txtB2Begin.DataBindings.Clear();
                this.txtB2Current.DataBindings.Clear();


                this.txtC2Buy.DataBindings.Clear();
                this.txtC2Sell.DataBindings.Clear();
                this.txtC2PRICE.DataBindings.Clear();
                this.txtC2OrderStatus.DataBindings.Clear();
                this.txtC2Filled.DataBindings.Clear();
                this.txtC2Month.DataBindings.Clear();
                this.txtC2OrdType.DataBindings.Clear();
                this.txtC2CumQty.DataBindings.Clear();
                this.corn2Order.DataBindings.Clear();
                this.btnCorn2Clone.DataBindings.Clear();
                this.btnCorn2Edit.DataBindings.Clear();
                this.txtC2Begin.DataBindings.Clear();
                this.txtC2Current.DataBindings.Clear();
 
                this.txtW2Buy.DataBindings.Clear();
                this.txtW2Sell.DataBindings.Clear();
                this.txtW2PRICE.DataBindings.Clear();
                this.txtW2OrderStatus.DataBindings.Clear();
                this.txtW2Filled.DataBindings.Clear();
                this.txtW2Month.DataBindings.Clear();
                this.txtW2OrdType.DataBindings.Clear();
                this.txtW2CumQty.DataBindings.Clear();
                this.btnWheat2Clone.DataBindings.Clear();
                this.btnWheat2Edit.DataBindings.Clear();
                this.txtW2Begin.DataBindings.Clear();
                this.txtW2Current.DataBindings.Clear();

                this.txtKC2Buy.DataBindings.Clear();
                this.txtKC2Sell.DataBindings.Clear();
                this.txtKC2PRICE.DataBindings.Clear();
                this.txtKC2OrderStatus.DataBindings.Clear();
                this.txtKC2Filled.DataBindings.Clear();
                this.txtKC2Month.DataBindings.Clear();
                this.txtKC2OrdType.DataBindings.Clear();
                this.txtKC2CumQty.DataBindings.Clear();
                this.btnKC2Clone.DataBindings.Clear();
                this.btnKC2Edit.DataBindings.Clear();
                this.txtKC2Begin.DataBindings.Clear();
                this.txtKC2Current.DataBindings.Clear();

                this.lblC2HP.DataBindings.Clear();
                this.lblC2Mon.DataBindings.Clear();
                this.lblC2Year.DataBindings.Clear();
                this.txtC2AMT.DataBindings.Clear();

                this.lblB2HP.DataBindings.Clear();
                this.lblB2Mon.DataBindings.Clear();
                this.lblB2Year.DataBindings.Clear();
                this.txtB2AMT.DataBindings.Clear();

                this.lblW2HP.DataBindings.Clear();
                this.lblW2Mon.DataBindings.Clear();
                this.lblW2Year.DataBindings.Clear();
                this.txtW2AMT.DataBindings.Clear();

                this.lblKC2HP.DataBindings.Clear();
                this.lblKC2Mon.DataBindings.Clear();
                this.lblKC2Year.DataBindings.Clear();
                this.txtKC2AMT.DataBindings.Clear();

                this.corn2Order.DataBindings.Clear();
                 this.bean2Order.DataBindings.Clear();
                //this.bean3Order.DataBindings.Clear();
                this.wheat2Order.DataBindings.Clear();
                this.KC2Order.DataBindings.Clear();


                this.txtB2Buy.Invalidate();

                this.txtB2Sell.Invalidate();
                this.txtB2PRICE.Invalidate();
                this.txtB2OrderStatus.Invalidate();
                this.txtB2OrdType.Invalidate();
                this.txtB2Filled.Invalidate();
                this.txtB2Month.Invalidate();
                this.txtB2CumQty.Invalidate();
                this.btnBean2Clone.Invalidate();
                this.btnBean2Edit.Invalidate();
                //this.btnBean3Clone.Invalidate();
                //this.btnBean3Edit.Invalidate();
                this.txtB2Begin.Invalidate();
                this.txtB2Current.Invalidate();
 
                this.txtC2Buy.Invalidate();
                this.txtC2Sell.Invalidate();
                this.txtC2PRICE.Invalidate();
                this.txtC2OrderStatus.Invalidate();
                this.txtC2Filled.Invalidate();
                this.txtC2Month.Invalidate();
                this.txtC2OrdType.Invalidate();
                this.txtC2CumQty.Invalidate();
                this.corn2Order.Invalidate();
                this.btnCorn2Clone.Invalidate();
                this.btnCorn2Edit.Invalidate();
                this.txtC2Begin.Invalidate();
                this.txtC2Current.Invalidate();

                this.txtW2Buy.Invalidate();
                this.txtW2Sell.Invalidate();
                this.txtW2PRICE.Invalidate();
                this.txtW2OrderStatus.Invalidate();
                this.txtW2Filled.Invalidate();
                this.txtW2Month.Invalidate();
                this.txtW2OrdType.Invalidate();
                this.txtW2CumQty.Invalidate();
                this.btnWheat2Clone.Invalidate();
                this.btnWheat2Edit.Invalidate();
                this.txtW2Begin.Invalidate();
                this.txtW2Current.Invalidate();

                this.lblC2HP.Invalidate();
                this.lblC2Mon.Invalidate();
                this.lblC2Year.Invalidate();
                this.txtC2AMT.Invalidate();
 

                this.lblB2HP.Invalidate();
                this.lblB2Mon.Invalidate();
                this.lblB2Year.Invalidate();
                this.txtB2AMT.Invalidate();

                this.lblW2HP.Invalidate();
                this.lblW2Mon.Invalidate();
                this.lblW2Year.Invalidate();
                this.txtW2AMT.Invalidate();
                this.corn2Order.Invalidate();
                this.bean2Order.Invalidate();
                this.wheat2Order.Invalidate();
 
                //mHedge_Log.WriteEntry(GC.GetGeneration(drCorn2).ToString());
                //mHedge_Log.WriteEntry(GC.CollectionCount(GC.GetGeneration(drCorn2)).ToString());
                //mHedge_Log.WriteEntry("Before GC");



                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }


         private void btnEC_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalStore.FillMonthsDataTable();
                GlobalStore.FillCommodityDataTable();
                viewCommodities = GlobalStore.mdtCommodity.DefaultView;
                viewMonths = GlobalStore.mdtMonths.DefaultView;
                if (misAdding == false)
                {
                    if (txtType.Text == "ORD" && EO.Checked == false)
                    {
                        if (MessageBox.Show(this, "CME is not checked for this order.  Order will not go to CME.  Continue?", "Hedge Order", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    }

                    if (txtType.Text == "ORD" && (txtFilled.Text != "" && txtFilled.Text != "0"))
                    {
                        if (MessageBox.Show(this, "This order has a fill price.  Order will not go to CME.  Continue?", "Hedge Order", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    }
                    
                    if (txtType.Text == "EX")
                    {

                        if (ValidateEntry(txtFilled.Text, txtAcct.Text, txtInd.Text, txtQty.Text,
                        txtYear.Text, txtMonth.Text, txtComm.Text, txtType.Text,
                        txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                        txtSYear.Text, false, this.EO.ToString(), this.GTC.ToString()) == true)
                        {
                            if (ValidateEntry(txtSFilled.Text, txtSAcct.Text, txtSBuy.Text, txtSQty.Text,
                            txtSYear.Text, txtSMonth.Text, txtSComm.Text, txtSType.Text,
                            txtSComp.Text, txtSPrice.Text, txtPremSide.Text, txtSMonth.Text,
                            txtSYear.Text, false, this.EO.ToString(), this.GTC.ToString()) == true)
                            {
                                misAdding = true;
                                AddNonECEXOrder();
                                ClearFields();
                                ClearSpreadFields();
                                HideSpreadFields();
                                ChangeControlColorFocus(txtType);
                                misAdding = false;
                                return;

                            }
                        }
                        else
                        {
                            return;
                        }



                    }
                    if (txtCardNumber.Text == "" && (txtFilled.Text == "" || txtFilled.Text == "0"))
                    {
                        if (txtAcct.Text == "" || txtComp.Text == "")
                        {
                            MessageBox.Show("Please enter an account and company.", "Hedge Order");
                            return;
                        }

                        viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text.ToString() + " AND TP_TRADE_COMP = " + txtComp.Text.ToString();
                        if (viewAccountComps.Count == 0)
                        {
                            MessageBox.Show("Invalid Account/Company combination.", "Hedge Order");
                            return;
                        }

                        if (EO.Checked == true && viewAccountComps[0]["SendToEC"].ToString() == "True")
                        {
                            if ((txtType.Text == "MOC" || txtType.Text == "MOO" || txtType.Text == "ORD" || txtType.Text == "EMC") && (Convert.ToInt32(txtQty.Text) > Convert.ToInt32(viewAccountComps[0]["ECContractLimit"].ToString())))
                            {
                                MessageBox.Show("This order exceeds the contract amount for EC.", "Hedge Order");
                                return;
                            }
                            switch (txtType.Text)
                            {
                                case "ORD":
                                case "EMC":
                                    if (txtCardNumber.Text != "")
                                    {
                                        if (ValidateEntry(txtFilled.Text, txtAcct.Text, txtInd.Text, txtQty.Text,
                                        txtYear.Text, txtMonth.Text, txtComm.Text, txtType.Text,
                                        txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                        txtSYear.Text, false, this.EO.ToString(), this.GTC.ToString()) == true)
                                        {
                                            misAdding = true;
                                            AddNonECOrder();
                                            ClearFields();
                                            HideSpreadFields();
                                            ChangeControlColorFocus(txtType);
                                            misAdding = false;

                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (ValidateEntry(txtFilled.Text, txtAcct.Text, txtInd.Text, txtQty.Text,
                                        txtYear.Text, txtMonth.Text, txtComm.Text, txtType.Text,
                                        txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                        txtSYear.Text, false, this.EO.ToString(), this.GTC.ToString()) == true)
                                        {
                                            misAdding = true;
                                            AddOrder();
                                            ClearFields();
                                            HideSpreadFields();
                                            ChangeControlColorFocus(txtType);
                                            misAdding = false;

                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    break;

                                case "SPR":
                                    if (txtSpreadCardNumber.Text == "" && txtCardNumber.Text == "" && (txtFilled.Text == ""))
                                    {
                                        if (txtPremSide.Visible == true || txtPrice.Text != "")
                                        {

                                            if (txtPremSide.Text.ToString() == "")
                                            {
                                                MessageBox.Show("Premium side selection is required.", "Add Spread Order");
                                                this.txtPremSide.Focus();
                                                return;
                                            }
                                            if (txtPremSide.Text.ToString() == "E" && (txtPrice.Text.ToString() != "" && txtPrice.Text.ToString() != "0"))
                                            {
                                                MessageBox.Show("Premium cannot be greater than 0 when premium side is Even.", "Add Spread Order");
                                                this.txtPrice.Focus();
                                                return;
                                            }
                                        }


                                        if (ValidateEntry(txtFilled.Text, txtAcct.Text, txtInd.Text, txtQty.Text,
                                            txtYear.Text, txtMonth.Text, txtComm.Text, txtType.Text,
                                            txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                            txtSYear.Text, true, this.EO.ToString(), this.GTC.ToString()) == true)
                                        {
                                            misAdding = true;
                                            AddOrder();
                                            ClearFields();
                                            HideSpreadFields();
                                            ChangeControlColorFocus(txtType);
                                            misAdding = false;

                                        }


                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (ValidateEntry(txtFilled.Text, txtAcct.Text, txtInd.Text, txtQty.Text,
                                            txtYear.Text, txtMonth.Text, txtComm.Text, txtType.Text,
                                            txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                            txtSYear.Text, true, this.EO.ToString(), this.GTC.ToString()) == true)
                                        {
                                            misAdding = true;
                                            AddNonECSpreadOrder();
                                            ClearFields();
                                            HideSpreadFields();
                                            ChangeControlColorFocus(txtType);
                                            misAdding = false;

                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    break;

                                default:

                                    MessageBox.Show("This order type cannot be sent as EC.", "Hedge Order");
                                    return;

                            }
                        }
                        else
                        {
                            if (txtType.Text != "SPR")
                            {
                                if (ValidateEntry(txtFilled.Text, txtAcct.Text, txtInd.Text, txtQty.Text,
                                            txtYear.Text, txtMonth.Text, txtComm.Text, txtType.Text,
                                            txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                            txtSYear.Text, false, this.EO.ToString(), this.GTC.ToString()) == true)
                                {
                                    misAdding = true;
                                    AddNonECOrder();
                                    ClearFields();
                                    HideSpreadFields();
                                    ChangeControlColorFocus(txtType);
                                    misAdding = false;

                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                if (ValidateEntry(txtFilled.Text, txtAcct.Text, txtInd.Text, txtQty.Text,
                                            txtYear.Text, txtMonth.Text, txtComm.Text, txtType.Text,
                                            txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                            txtSYear.Text, true, this.EO.ToString(), this.GTC.ToString()) == true)
                                {
                                    misAdding = true;
                                    AddNonECSpreadOrder();
                                    ClearFields();
                                    HideSpreadFields();
                                    ChangeControlColorFocus(txtType);
                                    misAdding = false;

                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (txtType.Text != "SPR")
                        {
                            if (ValidateEntry(txtFilled.Text, txtAcct.Text, txtInd.Text, txtQty.Text,
                                        txtYear.Text, txtMonth.Text, txtComm.Text, txtType.Text,
                                        txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                        txtSYear.Text, false, this.EO.ToString(), this.GTC.ToString()) == true)
                            {
                                misAdding = true;
                                AddNonECOrder();
                                ClearFields();
                                HideSpreadFields();
                                ChangeControlColorFocus(txtType);
                                misAdding = false;

                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (ValidateEntry(txtFilled.Text, txtAcct.Text, txtInd.Text, txtQty.Text,
                                        txtYear.Text, txtMonth.Text, txtComm.Text, txtType.Text,
                                        txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                        txtSYear.Text, true, this.EO.ToString(), this.GTC.ToString()) == true)
                            {
                                misAdding = true;
                                AddNonECSpreadOrder();
                                ClearFields();
                                HideSpreadFields();
                                ChangeControlColorFocus(txtType);
                                misAdding = false;

                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                tmrOrders.Interval = 10000;
                tmrRegionOrders.Interval = 600;
                tmrVCF.Interval = 10000;
                tmrPosition.Interval = 15000;
                tmrRegionOrders.Interval = 600;
                tmrECorders.Interval = 10000;
            }
            catch (Exception ex)
            {
                //mHedge_Log.WriteEntry(ex.ToString());
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }


        private void AddOrder()
        {

            try
            {
                if (this.chkConfirmOrder.Checked)
                {
                    if (txtType.Text == "SPR")
                    {
                        frmAddOrderSpread frmAdd = new frmAddOrderSpread();
                        OrdersNew clsOrdersNew = new OrdersNew();
                        frmAdd.frmCopyOrders = this;
                        frmAdd.ShowDialog(this);
                        frmAdd.Dispose();
                        //frmAdd.frmCopyOrders.Dispose();



                    }
                    else
                    {
                        frmAddOrder frmAdd = new frmAddOrder();
                        OrdersNew clsOrdersNew = new OrdersNew();
                        frmAdd.frmCopyOrders = this;
                        frmAdd.ShowDialog(this);
                        frmAdd.Dispose();
                        //frmAdd.frmCopyOrders.Dispose();
                    }

                }
                else
                {
                    if (txtType.Text == "SPR")
                    {
                        AddECSpreadOrder();
                    }
                    else
                    {
                        AddECOrder();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void AddSpreadOrder()
        {
            frmAddOrder frmAdd = new frmAddOrder();
            OrdersNew clsOrdersNew = new OrdersNew();
            frmAdd.frmCopyOrders = this;
            try
            {
                if (this.chkConfirmOrder.Checked)
                {
                    frmAdd.ShowDialog(this);
                }
                else
                {
                    AddECSpreadOrder();
                }
                //Display the frmAddOrder as a modal dialog box.
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmAdd.Dispose();

            //frmAdd.frmCopyOrders.Dispose();

        }
        private void AddECOrder()
        {
            try
            {
                viewCommodities = GlobalStore.mdtCommodity.DefaultView;

                viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
                viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
                viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "' AND TP_COMM = " + txtComm.Text;
                viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + txtType.Text + "'";
                string strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                string strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                int AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
                int FixEO = 0;
                int FixGTC = 0;
                string OrderSent = "";
                string ReturnMessage = "";
                string Company = viewAccountComps[0]["TP_COMP"].ToString();
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
                if (this.EO.Checked)
                {
                    FixEO = 1;
                }
                else
                {
                    FixEO = 0;
                }
                if (this.GTC.Checked)
                {
                    FixGTC = 1;
                }
                else
                {
                    FixGTC = 0;
                }
                OrdersNew Ord = new OrdersNew();
                Ord.AddOrderSingle(txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
                   txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtType.Text, Company,
                   FixEO, FixGTC, AcctXref, CurrentUser, TransType, ref OrderSent, ref ReturnMessage);

                if (OrderSent != "")
                {
                    ShowMessage(OrderSent, ReturnMessage);
                }
                dtOrders.Clear();
                //dtOrders.GetChanges();
                dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                //dgvOrders.DataSource = null;
                dgvOrders.DataSource = dtOrders;
                //dgvOrders.AutoResizeRowHeadersWidth(true, false);
                dgvOrders.Refresh();
                RefreshPositions();
                frmHedgePad hedgepad = new frmHedgePad();
                hedgepad.RefreshPositions();
                hedgepad.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }
        private void AddECSpreadOrder()
        {
            string Override = "N";
            try
            {
                viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
                viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
                viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "' AND TP_COMM = " + txtComm.Text;
                viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + txtType.Text + "'";
                string strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                string strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                int AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
                int FixEO = 0;
                int FixGTC = 0;
                string OrderSent = "";
                string ReturnMessage = "";
                string OverrideMessage = "";
                string PremiumSide;
                string Company = viewAccountComps[0]["TP_COMP"].ToString();
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
                if (this.EO.Checked)
                {
                    FixEO = 1;
                }
                else
                {
                    FixEO = 0;
                }
                if (this.GTC.Checked)
                {
                    FixGTC = 1;
                }
                else
                {
                    FixGTC = 0;
                }
                PremiumSide = txtPremSide.Text;

                OrdersNew Ord = new OrdersNew();
                OrdersUpdate ordUpdate = new OrdersUpdate();

                
                Ord.AddOrderSpread(txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
                   txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtType.Text, Company,
                   FixEO, FixGTC, AcctXref, CurrentUser, TransType, PremiumSide, txtSMonth.Text, txtSYear.Text,
                   txtSBuy.Text, txtSFilled.Text, txtRequestID1.Text, txtRequestID2.Text, ref OrderSent,
                   ref ReturnMessage, txtComments.Text, txtSComments.Text, Override, ref OverrideMessage);

                if (OrderSent.ToString() == "9" && (txtRequestID1.Text != "" || txtRequestID2.Text != ""))
                {
                    ShowMessage(OrderSent, ReturnMessage);
                    if (txtRequestID1.Text != "")
                    {
                        ordUpdate.UnSelectOrder(Convert.ToInt32(txtRequestID1.Text));
                    }
                    if (txtRequestID2.Text != "")
                    {
                        ordUpdate.UnSelectOrder(Convert.ToInt32(txtRequestID2.Text));
                    }

                }
                else if (OverrideMessage == "Y" && OrderSent.ToString() == "9")
                {

                    if (MessageBox.Show(ReturnMessage.ToString() + " ", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {

                        Ord.AddOrderSpread(txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
                        txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtType.Text, Company,
                        FixEO, FixGTC, AcctXref, CurrentUser, TransType, PremiumSide, txtSMonth.Text, txtSYear.Text,
                        txtSBuy.Text, txtSFilled.Text, txtRequestID1.Text, txtRequestID2.Text, ref OrderSent,
                        ref ReturnMessage, txtComments.Text, txtSComments.Text, "Y", ref OverrideMessage);
                        
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }

                    }
                }
                else if (OrderSent != "")
                {
                    ShowMessage(OrderSent, ReturnMessage);
                }

                dtOrders.Clear();
                //dtOrders.GetChanges();
                dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                //dgvOrders.DataSource = null;
                dgvOrders.DataSource = dtOrders;
                //dgvOrders.AutoResizeRowHeadersWidth(true, false);
                dgvOrders.Refresh();
                RefreshPositions();
                frmHedgePad hedgepad = new frmHedgePad();
                hedgepad.RefreshPositions();
                hedgepad.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void AddNonECOrder()
        {
            string OrderSent = "";
            string ReturnMessage = "";

            viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
            viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
            viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "' AND TP_COMM = " + txtComm.Text;
            viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + txtType.Text + "'";
            string strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
            string strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
            int AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
            int FixEO = 0;
            int FixGTC = 0;
            string Company = viewAccountComps[0]["TP_COMP"].ToString();
            string CurrentUser = WindowsIdentity.GetCurrent().Name;
            string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
            if (this.EO.Checked)
            {
                FixEO = 1;
            }
            else
            {
                FixEO = 0;
            }
            if (this.GTC.Checked)
            {
                FixGTC = 1;
            }
            else
            {
                FixGTC = 0;
            }
            OrdersNew Ord = new OrdersNew();
            Ord.AddNonECOrder(txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
               txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtType.Text, Company,
               FixEO, FixGTC, AcctXref, CurrentUser, TransType, txtCardNumber.Text, txtVCAccount.Text, txtVCComments.Text, txtVCComp.Text, txtFilled.Text, ref OrderSent,
                        ref ReturnMessage);

            if (OrderSent != "")
            {
                ShowMessage(OrderSent, ReturnMessage);
            }
            else
            {
                dtOrders.Clear();
                //dtOrders.GetChanges();
                dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                //dgvOrders.DataSource = null;
                dgvOrders.DataSource = dtOrders;
                //dgvOrders.AutoResizeRowHeadersWidth(true, false);
                dgvOrders.Refresh();
                this.txtAcct.Clear();
                this.txtCardNumber.Clear();
                this.txtComm.Clear();
                this.txtComp.Clear();
                this.txtFilled.Clear();
                this.txtInd.Clear();
                this.txtMonth.Clear();
                this.txtPrice.Clear();
                this.txtQty.Clear();
                this.txtType.Clear();
                this.txtYear.Clear();
                this.GTC.Checked = false;
                this.EO.Checked = false;
                RefreshPositions();
                frmHedgePad hedgepad = new frmHedgePad();
                hedgepad.RefreshPositions();
                hedgepad.Dispose();

                this.Refresh();
            }
        }
        private void AddNonECEXOrder()
        {
            string OrderSent = "";
            string ReturnMessage = "";

            viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
            viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
            viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "' AND TP_COMM = " + txtComm.Text;
            viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + txtType.Text + "'";
            string strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
            string strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
            int AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
            int FixEO = 0;
            int FixGTC = 0;
            string Company = viewAccountComps[0]["TP_COMP"].ToString();
            string CurrentUser = WindowsIdentity.GetCurrent().Name;
            string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
            if (this.EO.Checked)
            {
                FixEO = 1;
            }
            else
            {
                FixEO = 0;
            }
            if (this.GTC.Checked)
            {
                FixGTC = 1;
            }
            else
            {
                FixGTC = 0;
            }
            OrdersNew Ord = new OrdersNew();
            Ord.AddNonECOrder(txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
               txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtType.Text, Company,
               FixEO, FixGTC, AcctXref, CurrentUser, TransType, txtSpreadCardNumber.Text, txtVCAccount.Text, txtVCComments.Text, txtVCComp.Text, txtFilled.Text, ref OrderSent,
                        ref ReturnMessage);

            if (OrderSent != "")
            {
                ShowMessage(OrderSent, ReturnMessage);
            }
            else
            {

                viewAccountComps.RowFilter = "TP_ACCT = " + txtSAcct.Text + " AND TP_TRADE_COMP = " + txtSComp.Text;
                viewCommodities.RowFilter = "TP_COMM = " + txtSComm.Text;
                viewMonths.RowFilter = "TP_MON = '" + txtSMonth.Text + "' AND TP_COMM = " + txtSComm.Text;
                viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + txtSType.Text + "'";
                strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
                FixEO = 0;
                FixGTC = 0;
                Company = viewAccountComps[0]["TP_COMP"].ToString();
                CurrentUser = WindowsIdentity.GetCurrent().Name;
                TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
                if (this.EO.Checked)
                {
                    FixEO = 1;
                }
                else
                {
                    FixEO = 0;
                }
                if (this.GTC.Checked)
                {
                    FixGTC = 1;
                }
                else
                {
                    FixGTC = 0;
                }
                Ord.AddNonECOrder(txtSComp.Text, txtSBuy.Text, txtSAcct.Text, txtSComm.Text, strExchangeLetter,
                   txtSMonth.Text, txtSYear.Text, txtSQty.Text, txtSPrice.Text, txtSType.Text, Company,
                   FixEO, FixGTC, AcctXref, CurrentUser, TransType, txtSpreadCardNumber.Text, txtVCAccount.Text, txtVCComments.Text, txtVCComp.Text, txtSFilled.Text, ref OrderSent,
                        ref ReturnMessage);

                RefreshOrderGrid();
                RefreshPositions();

                //dtOrders.Clear();
                ////dtOrders.GetChanges();
                //dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                ////dgvOrders.DataSource = null;
                //dgvOrders.DataSource = dtOrders;
                ////dgvOrders.AutoResizeRowHeadersWidth(true, false);
                //dgvOrders.Refresh();
                ////this.txtAcct.Clear();
                //this.txtCardNumber.Clear();
                //this.txtComm.Clear();
                //this.txtComp.Clear();
                //this.txtFilled.Clear();
                //this.txtInd.Clear();
                //this.txtMonth.Clear();
                //this.txtPrice.Clear();
                //this.txtQty.Clear();
                //this.txtType.Clear();
                //this.txtYear.Clear();
                //this.GTC.Checked = false;
                //this.EO.Checked = false;
                btnEC.BackColor = Color.Transparent;


                this.Refresh();
            }
        }


        private void AddNonECSpreadOrder()
        {
            viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
            viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
            viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "' AND TP_COMM = " + txtComm.Text;
            viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + txtType.Text + "'";
            string strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
            string strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
            int AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
            int FixEO = 0;
            int FixGTC = 0;
            string Company = viewAccountComps[0]["TP_COMP"].ToString();
            string CurrentUser = WindowsIdentity.GetCurrent().Name;
            string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
            if (this.EO.Checked)
            {
                FixEO = 1;
            }
            else
            {
                FixEO = 0;
            }
            if (this.GTC.Checked)
            {
                FixGTC = 1;
            }
            else
            {
                FixGTC = 0;
            }
            OrdersNew Ord = new OrdersNew();
            Ord.AddOrderNonECSpread(txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
               txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtType.Text, Company,
               FixEO, FixGTC, AcctXref, CurrentUser, TransType, txtFilled.Text,
               txtPremSide.Text, txtSMonth.Text, txtSYear.Text, txtSBuy.Text, txtSFilled.Text,
               txtRequestID1.Text, txtRequestID2.Text, txtSpreadCardNumber.Text);

            RefreshOrderGrid();
            RefreshPositions();
            frmHedgePad hedgepad = new frmHedgePad();
            hedgepad.RefreshPositions();
            hedgepad.Dispose();


            //dtOrders.Clear();
            ////dtOrders.GetChanges();
            //dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
            ////dgvOrders.DataSource = null;
            //dgvOrders.DataSource = dtOrders;
            ////dgvOrders.AutoResizeRowHeadersWidth(true, false);
            //dgvOrders.Refresh();
            //this.txtAcct.Clear();
            //this.txtCardNumber.Clear();
            //this.txtComm.Clear();
            //this.txtComp.Clear();
            //this.txtFilled.Clear();
            //this.txtInd.Clear();
            //this.txtMonth.Clear();
            //this.txtPrice.Clear();
            //this.txtQty.Clear();
            //this.txtType.Clear();
            //this.txtYear.Clear();
            //this.GTC.Checked = false;
            //this.EO.Checked = false;
            btnEC.BackColor = Color.Transparent;

            this.Refresh();
        }
        private void AddRegionNonECOrder(Int32 RequestID, Int32 TradeCompany)
        {
            try
            {
                string OrderSent = "";
                string ReturnMessage = "";
                string Company = viewAccountComps[0]["TP_COMP"].ToString();
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
                OrdersNew Ord = new OrdersNew();
                OrdersUpdate ordUpdate = new OrdersUpdate();
                Ord.AddRegionNonECOrderSingle(CurrentUser, TradeCompany.ToString(), RequestID.ToString(), ref OrderSent, ref ReturnMessage);

                if (OrderSent != "")
                {
                    ShowMessage(OrderSent, ReturnMessage);
                }
                //dtOrders.Clear();
                ////dtOrders.GetChanges();
                //dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                ////dgvOrders.DataSource = null;
                //dgvOrders.DataSource = dtOrders;
                ////dgvOrders.AutoResizeRowHeadersWidth(true, false);
                //dgvOrders.Refresh();
                ordUpdate.UnSelectOrder(RequestID);
                RefreshOrderGrid();
                RefreshPositions();
                UpdateRegionGrid();
                frmHedgePad hedgepad = new frmHedgePad();
                hedgepad.RefreshPositions();
                hedgepad.Dispose();
                btnEC.BackColor = Color.Transparent;



            }
            catch (Exception ex)
            {
                OrdersUpdate ord = new OrdersUpdate();
                ord.UnSelectOrder(RequestID);
                UpdateRegionGrid();
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                btnEC.BackColor = Color.Transparent;

            }
        }

        private void AddRegionVCFOrder(Int32 RequestID, Int32 TradeCompany, string CardNumber)
        {
            try
            {
                string OrderSent = "";
                string ReturnMessage = "";
                string Company = viewAccountComps[0]["TP_COMP"].ToString();
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
                OrdersNew Ord = new OrdersNew();
                Ord.AddRegionNonECOrderSingle(CurrentUser, TradeCompany.ToString(), RequestID.ToString(), ref OrderSent, ref ReturnMessage, CardNumber);

                if (OrderSent != "")
                {
                    ShowMessage(OrderSent, ReturnMessage);
                }
                dtOrders.Clear();
                //dtOrders.GetChanges();
                dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                //dgvOrders.DataSource = null;
                dgvOrders.DataSource = dtOrders;
                //dgvOrders.AutoResizeRowHeadersWidth(true, false);
                dgvOrders.Refresh();
                RefreshVCFOrderGrid();
                RefreshPositions();
                btnEC.BackColor = Color.Transparent;



            }
            catch (Exception ex)
            {
                OrdersUpdate ord = new OrdersUpdate();
                ord.UnSelectOrder(RequestID);
                UpdateRegionGrid();
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                btnEC.BackColor = Color.Transparent;

            }
        }
        public void AddRegionECOrder(Int32 RequestID, Int32 TradeCompany)
        {
            try
            {
                string OrderSent = "";
                string ReturnMessage = "";
                string Company = viewAccountComps[0]["TP_COMP"].ToString();
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
                OrdersNew Ord = new OrdersNew();
                OrdersUpdate ord = new OrdersUpdate();
                Ord.AddRegionOrderSingle(CurrentUser, TradeCompany.ToString(), RequestID.ToString(), ref OrderSent, ref ReturnMessage);

                if (OrderSent.ToString() == "9")
                {
                    ShowMessage(OrderSent, ReturnMessage);
                    ord.UnSelectOrder(RequestID);


                }
                else if (OrderSent != "" && OrderSent != "9")
                {
                    ShowMessage(OrderSent, ReturnMessage);
                }
                dtOrders.Clear();
                //dtOrders.GetChanges();
                dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                //dgvOrders.DataSource = null;
                dgvOrders.DataSource = dtOrders;
                //dgvOrders.AutoResizeRowHeadersWidth(true, false);
                dgvOrders.Refresh();
                ord.UnSelectOrder(RequestID);
                UpdateRegionGrid();
                RefreshPositions();
                frmHedgePad hedgepad = new frmHedgePad();
                hedgepad.RefreshPositions();
                hedgepad.Dispose();

                btnEC.BackColor = Color.Transparent;



            }
            catch (Exception ex)
            {
                OrdersUpdate ord = new OrdersUpdate();
                ord.UnSelectOrder(RequestID);
                UpdateRegionGrid();
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                btnEC.BackColor = Color.Transparent;

            }
        }

        private void AddOpenOrder()
        {
            frmOpenAddOrder frmAdd = new frmOpenAddOrder();
            frmAdd.frmCopyOrders = this;
            try
            {
                frmAdd.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            finally
            {
                dtOrders.Clear();
                //dtOrders.GetChanges();
                dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                //dgvOrders.DataSource = null;
                dgvOrders.DataSource = dtOrders;
                //dgvOrders.AutoResizeRowHeadersWidth(true, false);
                dgvOrders.Refresh();
                frmAdd.Dispose();
                //frmAdd.frmCopyOrders.Dispose();

                this.Refresh();
            }
        }
        private int Get4LetterYear(int twoLetterYear)
        {
            int firstTwoDigits = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(0, 2));
            return Get4LetterYear(twoLetterYear, firstTwoDigits);
        }
        private int Get4LetterYear(int twoLetterYear, int firstTwoDigits)
        {
            return Convert.ToInt32(firstTwoDigits.ToString() + twoLetterYear.ToString());
        }
        private int Get2LetterYear(int fourLetterYear)
        {
            return Convert.ToInt32(fourLetterYear.ToString().Substring(2, 2));
        }





        private void txtAcct_KeyPress(object sender, KeyPressEventArgs e)
        {
            isRegionOrder = false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void txtAcct_TextChanged(object sender, EventArgs e)
        {
            if (txtAcct.Text.Length == 3)
            {
                switch (txtType.Text.ToString())
                {
                    case "EX":
                        ChangeControlColor(this.txtSAcct);
                        break;
                    default:
                        ChangeControlColor(txtInd);
                        break;
                }
            }
        }

        private void EO_Click(object sender, EventArgs e)
        {
            try
            {
                if (EO.Checked)
                {
                    switch (txtType.Text.ToString())
                    {
                        case "ERX":
                        case "MKT":
                        case "PIT":
                        case "ZGTC":
                        case "ORD":
                        case "EMC":
                        case "SPR":
                            break;
                        case "":
                            MessageBox.Show("Please select an order type before choosing electronic order.", "Hedge Order");
                            EO.Checked = false;
                            break;
                        default:
                            MessageBox.Show("This order type cannot be set as EO.", "Hedge Order");
                            EO.Checked = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                    case '.':
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void txtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                e.Handled = true;

            }
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text.Length == 1)
            {


                viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "'";
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("Invalid Option month.", "Hedge Order");
                    return;

                }
                else
                {
                    txtMonth.Text = txtMonth.Text.ToUpper();
                    int iYear = System.DateTime.Today.Year;
                    DateTime dtHedgeDate = new DateTime(iYear, Convert.ToInt32(viewMonths[0]["Month_ID"].ToString()), Convert.ToInt32("16".ToString()));
                    DateTime time = DateTime.Now;              // Use current time
                    string format = "yy";    // Use this format

                    if (System.DateTime.Today > dtHedgeDate)
                    {
                        txtYear.Text = time.AddYears(1).ToString(format);
                    }
                    else
                    {
                        txtYear.Text = time.ToString(format);
                    }

                    ChangeControlColor(txtYear);
                }
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void txtComm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void txtFilled_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                    case (char)Keys.Decimal:
                    case '.':
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            if (System.Text.RegularExpressions.Regex.IsMatch(txtType.Text.ToString(), "\\d+"))
            {
                switch (txtType.Text)
                {
                    case "1":
                        txtType.Text = "MOO".ToUpper();
                        break;
                    case "2":
                        txtType.Text = "MOC".ToUpper();
                        break;
                    case "3":
                        txtType.Text = "SPR".ToUpper();
                        txtSType.Text = "SPR".ToUpper();
                        break;
                    case "4":
                        txtType.Text = "ORD".ToUpper();
                        break;
                    case "5":
                        txtType.Text = "CH".ToUpper();
                        break;
                    case "6":
                        txtType.Text = "EX".ToUpper();
                        break;
                    case "7":
                        txtType.Text = "VCF".ToUpper();
                        break;
                    case "8":
                        txtType.Text = "EMC".ToUpper();
                        break;
                    default:
                        txtType.Text = "";
                        break;
                }
            }
            else
            {
                switch (txtType.Text)
                {
                    case "S":
                    case "s":
                        txtType.Text = "SPR".ToUpper();
                        txtSType.Text = "SPR".ToUpper();
                        break;
                    case "O":
                    case "o":
                        txtType.Text = "ORD".ToUpper();
                        break;
                    case "C":
                    case "c":
                        txtType.Text = "CH".ToUpper();
                        break;
                    case "EX":
                    case "ex":
                    case "Ex":
                    case "eX":
                        txtType.Text = "EX".ToUpper();
                        break;
                    case "Em":
                    case "EM":
                    case "eM":
                    case "em":
                        txtType.Text = "EMC".ToUpper();
                        break;
                    case "V":
                    case "v":
                        txtType.Text = "VCF".ToUpper();
                        break;
                    default:
                        txtType.Text = txtType.Text;
                        break;
                }
                if (txtType.Text == "SPR" || txtType.Text == "EX")
                { txtSType.Text = txtType.Text; }
            }

            ValidateOrderType(txtType);
        }

        private void ValidateOrderType(System.Windows.Forms.TextBox tbox)
        {
            if (tbox.TextLength == 2)
            {
                if (tbox.Text.ToString().ToUpper() == "CH")
                {
                    ClearSpreadFields();
                    tbox.Text = tbox.Text.ToUpper();
                    ElectronicOrder(false, false, false, false, false, false);
                }
                if (tbox.Text.ToString().ToUpper() == "EX")
                {
                    ElectronicOrder(false, false, false, true, false, true);
                }

            }
            else if (tbox.TextLength == 3)
            {
                tbox.Text = tbox.Text.ToUpper();
                switch (tbox.Text)
                {
                    case "MOO":
                    case "MOC":
                        ClearSpreadFields();
                        ElectronicOrder(false, false, false, false, false, false);
                        break;
                    case "SPR":
                        txtSType.Text = "SPR".ToUpper();
                        ElectronicOrder(true, true, false, true, isRegionOrder, false);
                        break;
                    case "ORD":
                    case "EMC":
                        ClearSpreadFields();
                        ElectronicOrder(true, true, false, false, false, false);
                        break;
                    case "VCF":
                        ClearSpreadFields();
                        ElectronicOrder(false, false, true, false, false, false);
                        break;
                    default:
                        MessageBox.Show("Invalid Order Type", "Hedge Order");
                        tbox.Text = "";
                        break;
                }
            }
        }
        private void ElectronicOrder(Boolean isGTC, Boolean isEO, Boolean ShowVCF, Boolean isSpread, Boolean isRegionSpread, Boolean isEX)
        {
            GTC.Checked = false;
            EO.Checked = isEO;
            GTC.Enabled = isGTC;
            EO.Enabled = isEO;
            txtVCAccount.Visible = ShowVCF;
            txtVCComments.Visible = ShowVCF;
            txtVCComp.Visible = ShowVCF;
            lblVCAccount.Visible = ShowVCF;
            lblVCTradeComments.Visible = ShowVCF;
            lblVCTradeComp.Visible = ShowVCF;
            txtSAcct.Visible = isSpread;
            txtSBuy.Visible = isSpread;
            this.txtSpreadCardNumber.Visible = isSpread;
            this.txtCardNumber.Visible = !isSpread;
            this.txtSComm.Visible = isSpread;
            this.txtSComp.Visible = isSpread;
            this.txtSFilled.Visible = isSpread;
            this.txtSMonth.Visible = isSpread;
            this.txtSPrice.Visible = isSpread;
            this.txtSQty.Visible = isSpread;
            this.txtSType.Visible = isSpread;
            this.txtSYear.Visible = isSpread;
            if ((txtPrice.Text != "" || txtSPrice.Text != "") && isEX == false)
            {
                this.txtPremSide.Visible = isSpread;
                lblPremiumSide.Visible = isSpread;

            }
            this.lblRequestID.Visible = isRegionSpread;
            this.txtRequestID1.Visible = isRegionSpread;
            this.txtRequestID2.Visible = isRegionSpread;
            this.lblComments.Visible = isRegionSpread;
            this.txtComments.Visible = isRegionSpread;
            this.txtSComments.Visible = isRegionSpread;
            if (isEX == true)
            {
                this.txtSAcct.Enabled = true;
                this.txtSAcct.BackColor = System.Drawing.Color.White;
                
                this.txtSMonth.Enabled = false;
                this.txtSMonth.BackColor = System.Drawing.Color.LightGray;
                this.txtSYear.Enabled = false;
                this.txtSYear.BackColor = System.Drawing.Color.LightGray;
                this.txtSFilled.Enabled = false;
                this.txtSFilled.BackColor = System.Drawing.Color.LightGray;
                this.txtComp.Text = "15";

            }
            else
            {
                this.txtSAcct.Enabled = false;
                this.txtSAcct.BackColor = System.Drawing.Color.LightGray;
                this.txtSMonth.Enabled = true;
                this.txtSMonth.BackColor = System.Drawing.Color.White;
                this.txtSYear.Enabled = true;
                this.txtSYear.BackColor = System.Drawing.Color.White;
                this.txtSFilled.Enabled = true;
                this.txtSFilled.BackColor = System.Drawing.Color.White;

            }
            ChangeControlColor(txtAcct);


        }

        private void ChangeControlColorFocus(System.Windows.Forms.TextBox tbox)
        {
            foreach (Control c in tbAddOrder.Controls)
            {

                if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {
                    c.BackColor = System.Drawing.Color.Transparent;
                }
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    if (c.Name != tbox.Name)
                    {
                        c.BackColor = System.Drawing.Color.White;
                        c.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        c.BackColor = System.Drawing.Color.OldLace;
                        c.ForeColor = System.Drawing.Color.DarkGreen;
                    }
            }
            btnEC.BackColor = Color.Transparent;

        }

        private void ChangeControlColorCboxFocus(System.Windows.Forms.CheckBox cbox)
        {
            foreach (Control c in tbAddOrder.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.BackColor = System.Drawing.Color.White;
                    c.ForeColor = System.Drawing.Color.Black;
                }
            }
            foreach (Control c in tbAddOrder.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                    if (c.Name != cbox.Name)
                    {
                        c.BackColor = System.Drawing.Color.Transparent;
                    }
                    else
                    {
                        c.BackColor = System.Drawing.Color.Turquoise;

                    }
            }
        }


        private void ChangeControlColor(System.Windows.Forms.TextBox tbox)
        {
            foreach (Control c in tbAddOrder.Controls)
            {

                if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {
                    c.BackColor = System.Drawing.Color.Transparent;
                }
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    if (c.Name != tbox.Name)
                    {
                        c.BackColor = System.Drawing.Color.White;
                        c.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        c.BackColor = System.Drawing.Color.OldLace;
                        c.ForeColor = System.Drawing.Color.DarkGreen;
                        c.Focus();
                    }
            }
        }

        private void ChangeControlColorCbox(System.Windows.Forms.CheckBox cbox)
        {
            foreach (Control c in tbAddOrder.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.BackColor = System.Drawing.Color.White;
                    c.ForeColor = System.Drawing.Color.Black;
                }
            }
            foreach (Control c in tbAddOrder.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                    if (c.Name != cbox.Name)
                    {
                        c.BackColor = System.Drawing.Color.Transparent;
                    }
                    else
                    {
                        c.BackColor = System.Drawing.Color.Turquoise;
                        c.Focus();
                    }
            }
        }
        private void GTC_CheckedChanged(object sender, EventArgs e)
        {
            CheckGTC(GTC);
        }

        private void CheckGTC(System.Windows.Forms.CheckBox objGTC)
        {
            try
            {
                if (objGTC.Checked)
                {
                    switch (txtType.Text.ToString())
                    {
                        case "ERX":
                        case "MKT":
                        case "PIT":
                        case "ORD":
                        case "SPR":
                        case "EMC":
                            break;
                        case "":
                            MessageBox.Show("Please select an order type before choosing EO or GTC.", "Hedge Order");
                            objGTC.Checked = false;
                            break;
                        default:
                            MessageBox.Show("This order type cannot be set as EO or GTC.", "Hedge Order");
                            objGTC.Checked = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }


        public Boolean ValidateEntry(string Filled, string Acct, string Ind, string Qty, string sYear,
            string sMonth, string Comm, string Type, string Comp, string Price, string PremSide,
            string s2Month, string s2Year, Boolean Grid, string EO, string GTC)
        {
            double dblPrice = 0;
            double dblRange_Low = 0;
            string strExchangeLetter = "";
            string strHedgerPosition = "";
            double dblRange_High = 0;
            string sInd = Ind;
            string OrdCardNumber = this.txtCardNumber.Text;
            string OrdCardNumber2 = this.txtSpreadCardNumber.Text;
            string OrdCardNumber3 = this.txtCardNo.Text;

            if (txtType.Text == "EMC" || txtType.Text == "ORD")
            {
                if (txtQty.Text != "")
                {
                    if (Convert.ToDecimal(txtQty.Text) > Convert.ToDecimal(Properties.Settings.Default.HedgeContractLimit))
                    {
                        MessageBox.Show("Quantity cannot be greater than " + Properties.Settings.Default.HedgeContractLimit.ToString() + " contracts.");
                        txtQty.Text = "";
                        txtQty.Focus();
                        return false;
                    }
                }
            }
            
            DataTable dtClosingPrices = new DataTable();
            OrdersUpdate ords = new OrdersUpdate();

            ords.GetClosingPrices(dtClosingPrices);
            viewClosingPrices = dtClosingPrices.DefaultView;
            try
            {
                if (Type != "ORD" && Type != "SPR" && Type !="EMC")
                {
                    if (EO == "True")
                    {
                        MessageBox.Show("This order type cannot be set as EO", "Hedge Order");
                        return false;
                    }
                }

                if (Filled.ToString() == "")
                {
                    dblPrice = 0;
                }
                if (Acct.ToString() == "")
                {
                    MessageBox.Show("Enter an account", "Hedge Order");
                    return false;
                }
                else
                {
                    viewAccounts.RowFilter = "TP_ACCT = " + Acct.ToString();
                    if (viewAccounts.Count == 0)
                    {
                        MessageBox.Show("Invalid Account entered", "Hedge Order");
                        return false;

                    }
                }

                if (Ind.ToString() == "")
                {
                    MessageBox.Show("Enter Buy or Sell", "Hedge Order");
                    return false;
                }
                if (Qty.ToString() == "" || Qty.ToString() == "0")
                {
                    MessageBox.Show("Enter a Quantity", "Hedge Order");
                    return false;
                }


                if (sMonth.ToString() == "")
                {
                    MessageBox.Show("Enter a Month", "Hedge Order");
                    return false;
                }
                else
                {
                    viewMonths.RowFilter = "TP_MON = '" + sMonth.ToString() + "'";
                    if (viewMonths.Count == 0)
                    {
                        MessageBox.Show("Invalid Month entered", "Hedge Order");
                        return false;

                    }
                }
                if (sYear.ToString() == "")
                {
                    MessageBox.Show("Enter a valid Year", "Hedge Order");
                    return false;
                }
                else
                {

                    DateTime time = DateTime.Now;              // Use current time
                    string format = "yy";    // Use this format
                    if (Convert.ToInt16(sYear.ToString()) < Convert.ToInt16(time.ToString(format)))
                    {
                        MessageBox.Show("Enter a valid Year.", "Hedge Order");
                        return false;
                    }

                }


                if (Comm.ToString() == "")
                {
                    MessageBox.Show("Enter a Commodity", "Hedge Order");
                    return false;
                }
                else
                {

                    viewCommodities.RowFilter = "TP_COMM = " + Comm.ToString();
                    if (viewCommodities.Count == 0)
                    {
                        MessageBox.Show("Invalid Commodity entered", "Hedge Order");
                        return false;

                    }
                    else
                    {
                        for (int i = 0; i < viewCommodities.Count; i++)
                        {
                            dblRange_High = Convert.ToDouble(viewCommodities[0]["Range_High"].ToString());
                            dblRange_Low = Convert.ToDouble(viewCommodities[0]["Range_Low"].ToString());
                            strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                            strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                        }

                    }

                }
                if (Type.ToString() == "")
                {
                    MessageBox.Show("Enter an Order Type", "Hedge Order");
                    return false;
                }
                else
                {

                    viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + Type.ToString() + "'";
                    if (viewOrdTypes.Count == 0)
                    {
                        MessageBox.Show("Invalid Order type", "Hedge Order");
                        return false;

                    }
                    else
                    {
                        if (Type.ToString() == "SPR")
                        {
                            sInd = this.txtSBuy.Text.ToString();
                        }
                    }

                }
                if (Comp.ToString() == "")
                {
                    MessageBox.Show("Select a Trading Company.", "Hedge Order");
                    return false;
                }
                else
                {

                    viewAccountComps.RowFilter = "TP_COMP = " + Comp.ToString();
                    if (viewAccountComps.Count == 0)
                    {
                        MessageBox.Show("Invalid Trading Company.", "Hedge Order");
                        return false;

                    }
                }

                viewMonths.RowFilter = "TP_MON = '" + sMonth.ToString() + "' AND TP_COMM = " + Comm.ToString();
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("Invalid Option month for the Commodity selected.", "Hedge Order");
                    return false;

                }

                viewAccountComps.RowFilter = "TP_ACCT = " + Acct.ToString() + " AND TP_TRADE_COMP = " + Comp.ToString();
                if (viewAccountComps.Count == 0)
                {
                    MessageBox.Show("Invalid Trading Account/Company combination.", "Hedge Order");
                    return false;

                }
                //else
                //{
                //    if (EO.ToString() == "True")
                //    {
                //        if ((Type.ToString() == "MOC" || Type.ToString() == "MOO" || Type.ToString() == "ORD" || Type.ToString() == "SPR") && (Convert.ToInt32(Qty.ToString()) > Convert.ToInt32(viewAccountComps[0]["ECContractLimit"].ToString())))
                //        {
                //            MessageBox.Show("This order exceeds the contract amount for EC.", "Hedge Order");
                //            return false;
                //        }
                //    }
                //}
                System.Diagnostics.Debug.Print(EO.ToString());
                System.Diagnostics.Debug.Print(GTC.ToString());
                if (Price.ToString() != "" && this.GTC.Checked.ToString() == "False")
                {
                    dblPrice = Convert.ToDouble(Price.ToString());
                    if (dblPrice > 0 && Type.ToString() != "SPR")
                    {
                        viewClosingPrices.RowFilter = "Commodity = '" + strHedgerPosition.ToString() + "' AND OptionMonth = '" + sMonth.ToString() + "' AND OptionYear = " + sYear.ToString();
                        if (viewClosingPrices.Count == 0)
                        {
                            if (MessageBox.Show("No Futures Closing Values was found." + Environment.NewLine + "Please choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if ((dblPrice <= Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) - dblRange_Low) || (dblPrice >= Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) + dblRange_High))
                            {
                                if (MessageBox.Show("Price is out of Range." + Environment.NewLine + "Low = " + (Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) - dblRange_Low).ToString() + " High = " + (Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) + dblRange_High).ToString() + Environment.NewLine + "Please choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                {
                                    return false;
                                }

                            }
                        }
                    }
                }
                if (sYear.ToString() != "" && sMonth.ToString() != "")
                {
                    int iYear = Get4LetterYear(Convert.ToInt32(sYear.ToString()));
                    DateTime dtHedgeDate = new DateTime(iYear, Convert.ToInt32(viewMonths[0]["Month_ID"].ToString()), Convert.ToInt32("16".ToString()));
                    if (System.DateTime.Today > dtHedgeDate)
                    {
                        if (MessageBox.Show("The option you entered is no longer trading." + Environment.NewLine + "Choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return false;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Please enter a month and year.");
                    return false;
                }

                if (Type.ToString() == "SPR" && Grid == true)
                {
                    if (Price.ToString() != "")
                    {
                        if (Convert.ToDouble(Price.ToString()) > 1 && CardNumber.ToString() == "")
                            if (MessageBox.Show("The premium entered is greater than 1." + Environment.NewLine + "  Is this is the correct premium?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                this.txtPrice.Focus();
                                return false;
                            }
                    }

                    if (s2Month.ToString() == "")
                    {
                        MessageBox.Show("Enter a Month", "Hedge Order");
                        return false;
                    }
                    else
                    {
                        viewMonths.RowFilter = "TP_MON = '" + s2Month.ToString() + "'";
                        if (viewMonths.Count == 0)
                        {
                            MessageBox.Show("Invalid Spread Month entered", "Hedge Order");
                            return false;

                        }
                    }
                    if (s2Year.ToString() == "")
                    {
                        MessageBox.Show("Enter a valid Year", "Hedge Order");
                        return false;
                    }
                    else
                    {

                        DateTime time = DateTime.Now;              // Use current time
                        string format = "yy";    // Use this format
                        if (Convert.ToInt16(s2Year.ToString()) < Convert.ToInt16(time.ToString(format)))
                        {
                            MessageBox.Show("Enter a valid Spread Year.", "Hedge Order");
                            return false;
                        }

                    }
                    if (PremSide.ToString() == "" && (Price.ToString() != "" && Price.ToString() != "0" && txtSpreadCardNumber.Text.ToString() == ""))
                    {
                        MessageBox.Show("Market Order cannot include a price.  Remove price or specify premium.", "Hedge Order");
                        return false;
                    }
                    if ((sYear.ToString() == s2Year.ToString()) && (sMonth.ToString() == s2Month.ToString()))
                    {
                        MessageBox.Show("Month/Year combination cannot be the same for both sides of the spread.", "Hedge Order");
                        return false;
                    }
                    if (Ind.ToString() == sInd.ToString())
                    {
                        MessageBox.Show("Side cannot be the same for both sides of the spread.", "Hedge Order");
                        return false;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                return false;

            }
        }

        public Boolean ValidateRegionEntry(string Filled, string Acct, string Ind, string Qty, string sYear,
            string sMonth, string Comm, string Type, string Comp, string Price, Boolean Grid, string EO, string GTC)
        {
            double dblPrice = 0;
            double dblRange_Low = 0;
            string strExchangeLetter = "";
            string strHedgerPosition = "";
            double dblRange_High = 0;


            DataTable dtClosingPrices = new DataTable();
            OrdersUpdate ords = new OrdersUpdate();

            if (Type == "EMC" || Type == "ORD")
            {
                if (Qty != "")
                {
                    if (Convert.ToDecimal(Qty) > Convert.ToDecimal(Properties.Settings.Default.HedgeContractLimit))
                    {
                        MessageBox.Show("Quantity cannot be greater than " + Properties.Settings.Default.HedgeContractLimit.ToString() + " contracts.");
                        return false;
                    }
                }
            }

            if (Type != "ORD" && Type != "SPR" && Type != "EMC")
            {
                if (EO == "True")
                {
                    MessageBox.Show("This order type cannot be set as EO", "Hedge Order");
                    return false;
                }
            }
            ords.GetClosingPrices(dtClosingPrices);
            viewClosingPrices = dtClosingPrices.DefaultView;
            try
            {
                if (Filled.ToString() == "")
                {
                    dblPrice = 0;
                }
                if (Acct.ToString() == "")
                {
                    MessageBox.Show("Enter an account", "Hedge Order");
                    return false;
                }
                else
                {
                    viewAccounts.RowFilter = "TP_ACCT = " + Acct.ToString();
                    if (viewAccounts.Count == 0)
                    {
                        MessageBox.Show("Invalid Account entered", "Hedge Order");
                        return false;

                    }
                }

                if (Ind.ToString() == "")
                {
                    MessageBox.Show("Enter Buy or Sell", "Hedge Order");
                    return false;
                }
                if (Qty.ToString() == "" || Qty.ToString() == "0")
                {
                    MessageBox.Show("Enter a Quantity", "Hedge Order");
                    return false;
                }


                if (sMonth.ToString() == "")
                {
                    MessageBox.Show("Enter a Month", "Hedge Order");
                    return false;
                }
                else
                {
                    viewMonths.RowFilter = "TP_MON = '" + sMonth.ToString() + "'";
                    if (viewMonths.Count == 0)
                    {
                        MessageBox.Show("Invalid Month entered", "Hedge Order");
                        return false;

                    }
                }
                if (sYear.ToString() == "")
                {
                    MessageBox.Show("Enter a valid Year", "Hedge Order");
                    return false;
                }
                else
                {

                    DateTime time = DateTime.Now;              // Use current time
                    string format = "yy";    // Use this format
                    if (Convert.ToInt16(sYear.ToString()) < Convert.ToInt16(time.ToString(format)))
                    {
                        MessageBox.Show("Enter a valid Year.", "Hedge Order");
                        return false;
                    }

                }


                if (Comm.ToString() == "")
                {
                    MessageBox.Show("Enter a Commodity", "Hedge Order");
                    return false;
                }
                else
                {

                    viewCommodities.RowFilter = "TP_COMM = " + Comm.ToString();
                    if (viewCommodities.Count == 0)
                    {
                        MessageBox.Show("Invalid Commodity entered", "Hedge Order");
                        return false;

                    }
                    else
                    {
                        for (int i = 0; i < viewCommodities.Count; i++)
                        {
                            dblRange_High = Convert.ToDouble(viewCommodities[0]["Range_High"].ToString());
                            dblRange_Low = Convert.ToDouble(viewCommodities[0]["Range_Low"].ToString());
                            strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                            strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                        }

                    }

                }
                if (Type.ToString() == "")
                {
                    MessageBox.Show("Enter an Order Type", "Hedge Order");
                    return false;
                }
                else
                {

                    viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + Type.ToString() + "'";
                    if (viewOrdTypes.Count == 0)
                    {
                        MessageBox.Show("Invalid Order type", "Hedge Order");
                        return false;

                    }

                }
                viewMonths.RowFilter = "TP_MON = '" + sMonth.ToString() + "' AND TP_COMM = " + Comm.ToString();
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("Invalid Option month for the Commodity selected.", "Hedge Order");
                    return false;

                }

                if (Price.ToString() != "" && GTC != "True")
                {
                    dblPrice = Convert.ToDouble(Price.ToString());
                    if (dblPrice > 0 && Type.ToString() != "SPR")
                    {
                        viewClosingPrices.RowFilter = "Commodity = '" + strHedgerPosition.ToString() + "' AND OptionMonth = '" + sMonth.ToString() + "' AND OptionYear = " + sYear.ToString();
                        if (viewClosingPrices.Count == 0)
                        {
                            if (MessageBox.Show("No Futures Closing Values was found." + Environment.NewLine + "Please choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if ((dblPrice <= Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) - dblRange_Low) || (dblPrice >= Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) + dblRange_High))
                            {
                                if (MessageBox.Show("Price is out of Range." + Environment.NewLine + "Low = " + (Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) - dblRange_Low).ToString() + " High = " + (Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) + dblRange_High).ToString() + Environment.NewLine + "Please choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                {
                                    return false;
                                }

                            }
                        }
                    }
                }
                if (sYear.ToString() != "" && sMonth.ToString() != "")
                {
                    int iYear = Get4LetterYear(Convert.ToInt32(sYear.ToString()));
                    DateTime dtHedgeDate = new DateTime(iYear, Convert.ToInt32(viewMonths[0]["Month_ID"].ToString()), Convert.ToInt32("16".ToString()));
                    if (System.DateTime.Today > dtHedgeDate)
                    {
                        if (MessageBox.Show("The option you entered is no longer trading." + Environment.NewLine + "Choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return false;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Please enter a month and year.");
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                return false;

            }
        }


        public Boolean ValidateVCFEntry(string Filled, string Acct, string Ind, string Qty,
            string sYear, string sMonth, string Comm, string Type, string Comp)
        {
            //double dblPrice = 0;
            double dblRange_Low = 0;
            string strExchangeLetter = "";
            string strHedgerPosition = "";
            double dblRange_High = 0;


            DataTable dtClosingPrices = new DataTable();
            OrdersUpdate ords = new OrdersUpdate();

            ords.GetClosingPrices(dtClosingPrices);
            viewClosingPrices = dtClosingPrices.DefaultView;
            try
            {
                //if (Filled.ToString() == "")
                //{
                //    dblPrice = 0;
                //}
                if (Acct.ToString() == "")
                {
                    MessageBox.Show("Enter an account", "Hedge Order");
                    return false;
                }
                else
                {
                    viewAccounts.RowFilter = "TP_ACCT = " + Acct.ToString();
                    if (viewAccounts.Count == 0)
                    {
                        MessageBox.Show("Invalid Account entered", "Hedge Order");
                        return false;

                    }
                }

                if (Ind.ToString() == "")
                {
                    MessageBox.Show("Enter Buy or Sell", "Hedge Order");
                    return false;
                }
                if (Qty.ToString() == "" || Qty.ToString() == "0")
                {
                    MessageBox.Show("Enter a Quantity", "Hedge Order");
                    return false;
                }


                if (sMonth.ToString() == "")
                {
                    MessageBox.Show("Enter a Month", "Hedge Order");
                    return false;
                }
                else
                {
                    viewMonths.RowFilter = "TP_MON = '" + sMonth.ToString() + "'";
                    if (viewMonths.Count == 0)
                    {
                        MessageBox.Show("Invalid Month entered", "Hedge Order");
                        return false;

                    }
                }
                if (sYear.ToString() == "")
                {
                    MessageBox.Show("Enter a valid Year", "Hedge Order");
                    return false;
                }
                else
                {

                    DateTime time = DateTime.Now;              // Use current time
                    string format = "yy";    // Use this format
                    if (Convert.ToInt16(sYear.ToString()) < Convert.ToInt16(time.ToString(format)))
                    {
                        MessageBox.Show("Enter a valid Year.", "Hedge Order");
                        return false;
                    }

                }


                if (Comm.ToString() == "")
                {
                    MessageBox.Show("Enter a Commodity", "Hedge Order");
                    return false;
                }
                else
                {

                    viewCommodities.RowFilter = "TP_COMM = " + Comm.ToString();
                    if (viewCommodities.Count == 0)
                    {
                        MessageBox.Show("Invalid Commodity entered", "Hedge Order");
                        return false;

                    }
                    else
                    {
                        for (int i = 0; i < viewCommodities.Count; i++)
                        {
                            dblRange_High = Convert.ToDouble(viewCommodities[0]["Range_High"].ToString());
                            dblRange_Low = Convert.ToDouble(viewCommodities[0]["Range_Low"].ToString());
                            strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                            strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                        }

                    }

                }
                if (Type.ToString() == "")
                {
                    MessageBox.Show("Enter an Order Type", "Hedge Order");
                    return false;
                }
                else
                {

                    viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + Type.ToString() + "'";
                    if (viewOrdTypes.Count == 0)
                    {
                        MessageBox.Show("Invalid Order type", "Hedge Order");
                        return false;

                    }

                }
                viewMonths.RowFilter = "TP_MON = '" + sMonth.ToString() + "' AND TP_COMM = " + Comm.ToString();
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("Invalid Option month for the Commodity selected.", "Hedge Order");
                    return false;

                }
                viewAccountComps.RowFilter = "TP_ACCT = " + Acct.ToString() + " AND TP_TRADE_COMP = " + Comp.ToString();
                if (viewAccountComps.Count == 0)
                {
                    MessageBox.Show("Invalid Trading Account/Company combination.", "Hedge Order");
                    return false;

                }
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                return false;

            }
        }

        public Boolean ValidateRegionSpreadEntry(string Filled, string Acct, string Ind, string Qty, string sYear,
            string sMonth, string Comm, string Type, string Comp, Boolean Grid)
        {
            //double dblPrice = 0;
            double dblRange_Low = 0;
            string strExchangeLetter = "";
            string strHedgerPosition = "";
            double dblRange_High = 0;


            DataTable dtClosingPrices = new DataTable();
            OrdersUpdate ords = new OrdersUpdate();

            ords.GetClosingPrices(dtClosingPrices);
            viewClosingPrices = dtClosingPrices.DefaultView;
            try
            {
                //if (Filled.ToString() == "")
                //{
                //    dblPrice = 0;
                //}
                if (Acct.ToString() == "")
                {
                    MessageBox.Show("Enter an account", "Hedge Order");
                    return false;
                }
                else
                {
                    viewAccounts.RowFilter = "TP_ACCT = " + Acct.ToString();
                    if (viewAccounts.Count == 0)
                    {
                        MessageBox.Show("Invalid Account entered", "Hedge Order");
                        return false;

                    }
                }

                if (Ind.ToString() == "")
                {
                    MessageBox.Show("Enter Buy or Sell", "Hedge Order");
                    return false;
                }
                if (Qty.ToString() == "" || Qty.ToString() == "0")
                {
                    MessageBox.Show("Enter a Quantity", "Hedge Order");
                    return false;
                }


                if (sMonth.ToString() == "")
                {
                    MessageBox.Show("Enter a Month", "Hedge Order");
                    return false;
                }
                else
                {
                    viewMonths.RowFilter = "TP_MON = '" + sMonth.ToString() + "'";
                    if (viewMonths.Count == 0)
                    {
                        MessageBox.Show("Invalid Month entered", "Hedge Order");
                        return false;

                    }
                }
                if (sYear.ToString() == "")
                {
                    MessageBox.Show("Enter a valid Year", "Hedge Order");
                    return false;
                }
                else
                {

                    DateTime time = DateTime.Now;              // Use current time
                    string format = "yy";    // Use this format
                    if (Convert.ToInt16(sYear.ToString()) < Convert.ToInt16(time.ToString(format)))
                    {
                        MessageBox.Show("Enter a valid Year.", "Hedge Order");
                        return false;
                    }

                }


                if (Comm.ToString() == "")
                {
                    MessageBox.Show("Enter a Commodity", "Hedge Order");
                    return false;
                }
                else
                {

                    viewCommodities.RowFilter = "TP_COMM = " + Comm.ToString();
                    if (viewCommodities.Count == 0)
                    {
                        MessageBox.Show("Invalid Commodity entered", "Hedge Order");
                        return false;

                    }
                    else
                    {
                        for (int i = 0; i < viewCommodities.Count; i++)
                        {
                            dblRange_High = Convert.ToDouble(viewCommodities[0]["Range_High"].ToString());
                            dblRange_Low = Convert.ToDouble(viewCommodities[0]["Range_Low"].ToString());
                            strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                            strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                        }

                    }

                }
                if (Type.ToString() == "")
                {
                    MessageBox.Show("Enter an Order Type", "Hedge Order");
                    return false;
                }
                else
                {

                    viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + Type.ToString() + "'";
                    if (viewOrdTypes.Count == 0)
                    {
                        MessageBox.Show("Invalid Order type", "Hedge Order");
                        return false;

                    }

                }
                viewMonths.RowFilter = "TP_MON = '" + sMonth.ToString() + "' AND TP_COMM = " + Comm.ToString();
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("Invalid Option month for the Commodity selected.", "Hedge Order");
                    return false;

                }

                if (sYear.ToString() != "" && sMonth.ToString() != "")
                {
                    int iYear = Get4LetterYear(Convert.ToInt32(sYear.ToString()));
                    DateTime dtHedgeDate = new DateTime(iYear, Convert.ToInt32(viewMonths[0]["Month_ID"].ToString()), Convert.ToInt32("16".ToString()));
                    if (System.DateTime.Today > dtHedgeDate)
                    {
                        if (MessageBox.Show("The option you entered is no longer trading." + Environment.NewLine + "Choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return false;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Please enter a month and year.");
                    return false;
                }


                return true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                return false;

            }
        }


        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tmrOrders.Interval = 120000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            int OrderNumber = 0;
            int ContractDetailID = 0;
            String Status = "";
            Int32 giRowIndex = 1;
            string Canc = "";
            string OrderSent = "";

            if (dgvOrders.Columns[e.ColumnIndex].Name == "EC")
            {

                Point p = dgvOrders.PointToClient(new Point(e.RowIndex, e.ColumnIndex));
                DataGridView.HitTestInfo info = dgvOrders.HitTest(p.X, p.Y);

                if (info.RowIndex != -1 && info.ColumnIndex != -1)
                {
                    DataGridViewCell cell = this.dgvOrders[info.ColumnIndex, info.RowIndex];
                }

                Int32 iRowIndex = Convert.ToInt32(e.RowIndex);

                // Set as selected 
                dgvOrders.Rows[iRowIndex].Selected = true;

                giRowIndex = iRowIndex;
                string TradeComp = dgvOrders.Rows[iRowIndex].Cells["Comp"].Value.ToString();
                string EO = dgvOrders.Rows[iRowIndex].Cells["chkEO"].Value.ToString();
                string GTC = dgvOrders.Rows[iRowIndex].Cells["chkGTC"].Value.ToString();
                string curAcct = dgvOrders.Rows[iRowIndex].Cells["OrdAcct"].Value.ToString();
                string Qty = dgvOrders.Rows[iRowIndex].Cells["OrdQty"].Value.ToString();
                Status = dgvOrders.Rows[iRowIndex].Cells["Status"].Value.ToString();
                OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                string OrdType = dgvOrders.Rows[iRowIndex].Cells["Type"].Value.ToString();
                Canc = dgvOrders.Rows[iRowIndex].Cells["Can"].Value.ToString();
                GlobalStore.mdtCLOrder.Clear();
                GlobalStore.FillCLOrderDataTable(OrderNumber.ToString());
                if (dgvOrders.Rows[iRowIndex].Cells["ContractDetailID"].Value.ToString() != "")
                {
                    ContractDetailID = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["ContractDetailID"].Value.ToString());
                }
                

                DataView viewOrder = GlobalStore.mdtCLOrder.DefaultView;
                if (ContractDetailID != 0)
                {
                    if (MessageBox.Show(OrderNumber + " is an Offer placed through CGBOnline.  Are you sure you want to revise this Order?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }


                }

                if (Canc == "True")
                {
                    MessageBox.Show("This order has been cancelled.", "Hedge Order");
                    return;

                }

                if (Status == "After Market" || Status == "Mkt Close")
                {

                    if (viewOrder.Count > 0)
                    {
                        if (MessageBox.Show("Order Number " + dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString() + " has a status of " + Status + ".  This order cannot be revised.  Do you want to cancel this order? ", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                        else
                        {
                            OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                            CancelOrder(OrderNumber, ref OrderSent);
                            RefreshOrderGrid();
                            return;
                        }
                    }
                    else if (OrdType.ToString() == "SPR")
                    {
                        if (OrderNumber.ToString() != dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString() && dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString() != "")
                        {
                            GlobalStore.FillCLOrderDataTable(dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString());
                            viewOrder = GlobalStore.mdtCLOrder.DefaultView;
                            if (viewOrder.Count != 0)
                            {
                                if (MessageBox.Show("Order Number " + dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString() + " has a status of " + Status + ".  This order cannot be revised.  Do you want to cancel this order? ", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                {
                                    return;
                                }
                                else
                                {
                                    OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                                    CancelOrder(OrderNumber, ref OrderSent);
                                    RefreshOrderGrid();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Not an EC Order.", "Hedge Order");
                                return;
                            }
                        }
                    }
                                     
                    

                }
                if (Status == "Filled" || Status == "Expired" || Status == "In Transit" || Status == "Rejected" || Status == "In Process")
                {
                    MessageBox.Show("This order status is " + Status + ".  The order can not be revised or cancelled.", "Hedge Order");
                    return;

                }

                if (TradeComp == "55" || TradeComp == "33" || TradeComp == "25" || TradeComp == "19")
                {
                    if (EO.ToString() == "False")
                    {
                        MessageBox.Show("This trade company can only accept electronic orders.", "Hedge Order");
                        return;
                    }
                    if (TradeComp == "55" && GTC == "true")
                    {
                        MessageBox.Show("This trade company does not currently accept GTC orders.", "Hedge Order");
                        return;

                    }

                }
                viewAccountComps.RowFilter = "TP_ACCT = " + curAcct + " AND TP_TRADE_COMP = " + TradeComp;
                if (viewAccountComps.Count > 0)
                {
                    if (viewAccountComps[0]["SendToEC"].ToString() == "1" && Convert.ToInt32(Qty) > Convert.ToInt32(viewAccountComps[0]["ECContractLimit"].ToString()))
                    {
                        MessageBox.Show("This contract amount cannot be sent through EC.", "Hedge Order");
                        return;
                    }
                    if (OrdType == "SPR" || OrdType == "ORD" || OrdType == "EMC")
                    {
                        if (viewOrder.Count > 0)
                        {
                            if (OrdType == "SPR")
                            {
                                ReviseOrderSpread(OrderNumber);
                            }
                            else
                            {
                                ReviseOrder(OrderNumber);
                            }
                        }
                        else if (OrdType.ToString() == "SPR")
                        {
                            if (OrderNumber.ToString() != dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString() && dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString() != "")
                            {
                                GlobalStore.FillCLOrderDataTable(dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString());
                                viewOrder = GlobalStore.mdtCLOrder.DefaultView;
                                if (viewOrder.Count != 0)
                                {
                                    ReviseOrderSpread(Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString()));
                                }
                                else
                                {
                                    MessageBox.Show("Not an EC Order.", "Hedge Order");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Not an EC Order.", "Hedge Order");
                                return;
                            }
                        }
                        else
                        {
                            if (dgvOrders.Rows[iRowIndex].Cells["CardNumber"].Value.ToString() == "")
                            {

                                if (OrdType.ToString() == "SPR")
                                {
                                    frmAddOrderSpread frmAdd = new frmAddOrderSpread();
                                    OrdersNew clsOrdersNew = new OrdersNew();
                                    frmAdd.frmCopyOrders = this;
                                    frmAdd.fromECButton = true;
                                    frmAdd.mOrderID = OrderNumber.ToString();
                                    frmAdd.ShowDialog(this);
                                    frmAdd.Dispose();
                                    //// frmAdd.frmCopyOrders.Dispose();

                                }
                                else
                                {
                                    frmAddOrder frmAdd = new frmAddOrder();
                                    OrdersNew clsOrdersNew = new OrdersNew();
                                    frmAdd.fromECButton = true;
                                    frmAdd.mOrderID = OrderNumber.ToString();
                                    frmAdd.frmCopyOrders = this;
                                    frmAdd.ShowDialog(this);
                                    frmAdd.Dispose();
                                    //// frmAdd.frmCopyOrders.Dispose();
                                }

                            }
                            else
                            {
                                MessageBox.Show("This order was entered manually.", "Hedge Order");
                                return;
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Not an EC Order.", "Hedge Order");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Not an EC Order.", "Hedge Order");
                    return;
                }
                //tmrOrders.Start();
                dgvOrders.Rows[giRowIndex].Cells[mColumnIndex].Selected = true;

            }
            if (dgvOrders.Columns[e.ColumnIndex].Name == "PS")
            {

                Point p = dgvOrders.PointToClient(new Point(e.RowIndex, e.ColumnIndex));
                DataGridView.HitTestInfo info = dgvOrders.HitTest(p.X, p.Y);

                if (info.RowIndex != -1 && info.ColumnIndex != -1)
                {
                    DataGridViewCell cell = this.dgvOrders[info.ColumnIndex, info.RowIndex];
                }

                Int32 iRowIndex = Convert.ToInt32(e.RowIndex);

                // Set as selected 
                dgvOrders.Rows[iRowIndex].Selected = true;

                giRowIndex = iRowIndex;
                OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                Canc = dgvOrders.Rows[iRowIndex].Cells["Can"].Value.ToString();
                GlobalStore.mdtCLOrder.Clear();
                GlobalStore.FillCLOrderDataTable(OrderNumber.ToString());

                DataView viewOrder = GlobalStore.mdtCLOrder.DefaultView;
                if (Canc == "True" && Status != "Partial Fill")
                {
                    MessageBox.Show("This order has been cancelled.", "Hedge Order");
                    //return;

                }

                Maintenance ordUpdate = new Maintenance();
                frmMoveToPurchaseSettleTables frm = new frmMoveToPurchaseSettleTables();
                frm.frmCopyOrders = this;
                frm.mOrderNumber = OrderNumber;
                frm.ShowDialog();
                //tmrOrders.Start();
                dgvOrders.Rows[giRowIndex].Cells[mColumnIndex].Selected = true;

            }

            
            if (dgvOrders.Columns[e.ColumnIndex].Name == "OrderDelete")
            {

                Point p = dgvOrders.PointToClient(new Point(e.RowIndex, e.ColumnIndex));
                DataGridView.HitTestInfo info = dgvOrders.HitTest(p.X, p.Y);

                if (info.RowIndex != -1 && info.ColumnIndex != -1)
                {
                    DataGridViewCell cell = this.dgvOrders[info.ColumnIndex, info.RowIndex];
                }

                Int32 iRowIndex = Convert.ToInt32(e.RowIndex);

                // Set as selected 
                dgvOrders.Rows[iRowIndex].Selected = true;
                Status = dgvOrders.Rows[iRowIndex].Cells["Status"].Value.ToString();
                giRowIndex = iRowIndex;
                OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                OrdersNew ord = new OrdersNew();

                string OrdType = dgvOrders.Rows[iRowIndex].Cells["Type"].Value.ToString();


                if (Status == "Rejected" || Status == "In Transit" || Status == "In Process")
                {
                    //MessageBox.Show("This order will be hidden.", "Hedge Order");
                    OrdersUpdate ordUpdate = new OrdersUpdate();
                    ordUpdate.HideOrder(OrderNumber);
                    RefreshOrderGrid();
                    return;

                }
                else
                {
                    if (Status == "Partial Fill"  || Status == "Filled")
                    {
                        MessageBox.Show("This order has a fill and cannot be deleted.", "Hedge Order");
                        return;

                    }

                    if (Status == "New" || Status == "Replaced")
                    {
                        MessageBox.Show("Please cancel this order prior to deleting.", "Hedge Order");
                        return;

                    }

                    if (MessageBox.Show("Delete Order ID " + OrderNumber.ToString() + "?", "Hedge Order", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
                    {

                        if (OrdType == "SPR")
                        {
                            DeleteOrderSpread(OrderNumber);
                        }
                        else
                        {
                            DeleteOrder(OrderNumber);
                        }

                    }
                    RefreshOrderGrid();
                }

            }

            if (dgvOrders.Columns[e.ColumnIndex].Name == "Cancel")
            {
                Int32 iRowIndex = Convert.ToInt32(e.RowIndex);

                // Set as selected 
                dgvOrders.Rows[iRowIndex].Selected = true;

                giRowIndex = iRowIndex;
                string TradeComp = dgvOrders.Rows[iRowIndex].Cells["Comp"].Value.ToString();
                string EO = dgvOrders.Rows[iRowIndex].Cells["chkEO"].Value.ToString();
                string GTC = dgvOrders.Rows[iRowIndex].Cells["chkGTC"].Value.ToString();
                string curAcct = dgvOrders.Rows[iRowIndex].Cells["OrdAcct"].Value.ToString();
                //string Qty = dgvOrders.Rows[iRowIndex].Cells["OrdQty"].Value.ToString();
                Status = dgvOrders.Rows[iRowIndex].Cells["Status"].Value.ToString();
                OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                string OrdType = dgvOrders.Rows[iRowIndex].Cells["Type"].Value.ToString();
                Canc = dgvOrders.Rows[iRowIndex].Cells["Can"].Value.ToString();
                Canc = dgvOrders.Rows[e.RowIndex].Cells["Can"].Value.ToString();

                if (dgvOrders.Rows[iRowIndex].Cells["ContractDetailID"].Value.ToString() != "")
                {
                    ContractDetailID = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["ContractDetailID"].Value.ToString());
                }
                
                if (ContractDetailID != 0)
                {
                    if (MessageBox.Show(OrderNumber + " is an Offer placed through CGBOnline.  Are you sure you want to revise this Order?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }

                }

                if (Canc == "True" && Status != "After Market" && Status != "Mkt Close")
                {
                    MessageBox.Show("This order has been cancelled.", "Hedge Order");
                    return;

                }
                if (Canc == "True" && Status == "After Market" && Status != "Mkt Close")
                {
                    MessageBox.Show(OrderNumber + " Will be cancelled when the market opens - this cannot be cancelled.  Please place a new order.", "Hedge Order");
                    {
                        return;
                    }
                    

                }

                if (Status == "Filled" || Status == "Expired" || Status == "In Transit" || Status == "Rejected" || Status == "In Process")
                {
                    MessageBox.Show("This order status is " + Status + ".  The order can not be revised or cancelled.", "Hedge Order");
                    return;

                }

                OrderNumber = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["OrderNumb"].Value.ToString());
                GlobalStore.FillCLOrderDataTable(OrderNumber.ToString());
                DataView viewOrder = GlobalStore.mdtCLOrder.DefaultView;
                DataGridView.HitTestInfo info = dgvOrders.HitTest(e.RowIndex, e.ColumnIndex);
                //Int32 iRowIndex = Convert.ToInt32(e.RowIndex);

                // Set as selected 
                dgvOrders.Rows[e.RowIndex].Selected = true;
                //string OrdType = dgvOrders.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                giRowIndex = iRowIndex;
                if (OrdType == "SPR" || OrdType == "ORD" || OrdType == "EMC")
                {
                    if (viewOrder.Count > 0)
                    {
                        if (MessageBox.Show("Are you sure you want to cancel order " + dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                        else
                        {
                            OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                            CancelOrder(OrderNumber, ref OrderSent);
                            RefreshOrderGrid();
                        }
                    }
                    else if (OrdType.ToString() == "SPR")
                    {
                        if (OrderNumber.ToString() != dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString() && dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString() != "")
                        {
                            GlobalStore.FillCLOrderDataTable(dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString());
                            viewOrder = GlobalStore.mdtCLOrder.DefaultView;
                            if (viewOrder.Count != 0)
                            {
                                if (MessageBox.Show("Are you sure you want to cancel order " + dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                {
                                    return;
                                }
                                else
                                {
                                    OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                                    CancelOrder(OrderNumber, ref OrderSent);
                                    RefreshOrderGrid();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Not an EC Order.", "Hedge Order");
                                return;
                            }
                        }
                    }
                    else
                    {


                        OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                        OrdersNew ord = new OrdersNew();
                        string Type = "";
                        string Acct = "";
                        string Ind = "";
                        string Qty = "";
                        string sMonth = "";
                        string sYear = "";
                        string Comm = "";
                        string Price = "";
                        string Filled = "";
                        string Comp = "";
                        //string PremSide = "";
                        //string S2Month = "";
                        //string S2Year = "";
                        int FixEO = 0;
                        int FixGTC = 0;
                        int Can = 0;
                        string VCAccount = "";
                        string VCComments = "";
                        string VCCustomer = "";
                        string CurrentUser = WindowsIdentity.GetCurrent().Name;
                        string ReturnMessage = "";
                        string CardNumber = "";
                        string OrderDate = "";
                        string Comments = "";
                        string ParentID = "";

                        //Boolean Grid = true;
                        if (dgvOrders.Rows[iRowIndex].Cells["chkEO"].Value.ToString() == "True")
                        {
                            FixEO = 1;
                        }
                        if (dgvOrders.Rows[iRowIndex].Cells["chkGTC"].Value.ToString() == "True")
                        {
                            FixGTC = 1;
                        }
                        Can = 1;
                        //FixEO = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkEO"].Value.ToString());
                        //FixGTC = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkGTC"].Value.ToString());
                        VCAccount = dgvOrders.Rows[e.RowIndex].Cells["VCAccount"].Value.ToString();
                        VCComments = dgvOrders.Rows[e.RowIndex].Cells["VCComments"].Value.ToString();
                        VCCustomer = dgvOrders.Rows[e.RowIndex].Cells["VCCustomer"].Value.ToString();
                        CardNumber = dgvOrders.Rows[e.RowIndex].Cells["CardNumber"].Value.ToString();
                        Status = dgvOrders.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                        OrderDate = dgvOrders.Rows[e.RowIndex].Cells["OrderDate"].Value.ToString();
                        Comments = dgvOrders.Rows[e.RowIndex].Cells["Comments"].Value.ToString();
                        Type = dgvOrders.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                        Acct = dgvOrders.Rows[e.RowIndex].Cells["OrdAcct"].Value.ToString();
                        Ind = dgvOrders.Rows[e.RowIndex].Cells["OrdInd"].Value.ToString();
                        Qty = dgvOrders.Rows[e.RowIndex].Cells["OrdQty"].Value.ToString();
                        sMonth = dgvOrders.Rows[e.RowIndex].Cells["OrdMonth"].Value.ToString();
                        sYear = dgvOrders.Rows[e.RowIndex].Cells["OrdYear"].Value.ToString();
                        Comm = dgvOrders.Rows[e.RowIndex].Cells["OrdComm"].Value.ToString();
                        Price = dgvOrders.Rows[e.RowIndex].Cells["OrdPrice"].Value.ToString();
                        Filled = dgvOrders.Rows[e.RowIndex].Cells["OrdFilled"].Value.ToString();
                        ParentID = dgvOrders.Rows[e.RowIndex].Cells["ParentID"].Value.ToString();
                        Comp = dgvOrders.Rows[e.RowIndex].Cells["Comp"].Value.ToString();
                        //Boolean CheckValue = true;

                        viewCommodities.RowFilter = "TP_COMM = " + Comm.ToString();
                        string ExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();

                        ord.EditOrderInGrid(OrderNumber.ToString(), Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                                Filled, Type, Comp, ParentID, FixEO, FixGTC, CardNumber, Status, Comments,
                                OrderDate, VCAccount, VCCustomer, VCComments, CurrentUser, ExchangeLetter, ref OrderSent,
                                ref ReturnMessage, Can);
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }

                        RefreshOrderGrid();
                        tmrOrders.Interval = 10000;
                        tmrRegionOrders.Interval = 600;
                        tmrVCF.Interval = 10000;
                        tmrPosition.Interval = 15000;

                        tmrRegionOrders.Interval = 600;
                        tmrECorders.Interval = 10000;
                        dgvOrders.Rows[giRowIndex].Cells[mColumnIndex].Selected = true;

                    }
                }
                else
                {

                    OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                    OrdersNew ord = new OrdersNew();
                    string Type = "";
                    string Acct = "";
                    string Ind = "";
                    string Qty = "";
                    string sMonth = "";
                    string sYear = "";
                    string Comm = "";
                    string Price = "";
                    string Filled = "";
                    string Comp = "";
                    //string PremSide = "";
                    //string S2Month = "";
                    //string S2Year = "";
                    int FixEO = 0;
                    int FixGTC = 0;
                    int Can = 0;
                    string VCAccount = "";
                    string VCComments = "";
                    string VCCustomer = "";
                    string CurrentUser = WindowsIdentity.GetCurrent().Name;
                    string ReturnMessage = "";
                    string CardNumber = "";
                    string OrderDate = "";
                    string Comments = "";
                    string ParentID = "";

                    //Boolean Grid = true;
                    if (dgvOrders.Rows[iRowIndex].Cells["chkEO"].Value.ToString() == "True")
                    {
                        FixEO = 1;
                    }
                    if (dgvOrders.Rows[iRowIndex].Cells["chkGTC"].Value.ToString() == "True")
                    {
                        FixGTC = 1;
                    }
                    Can = 1;
                    //FixEO = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkEO"].Value.ToString());
                    //FixGTC = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkGTC"].Value.ToString());
                    VCAccount = dgvOrders.Rows[e.RowIndex].Cells["VCAccount"].Value.ToString();
                    VCComments = dgvOrders.Rows[e.RowIndex].Cells["VCComments"].Value.ToString();
                    VCCustomer = dgvOrders.Rows[e.RowIndex].Cells["VCCustomer"].Value.ToString();
                    CardNumber = dgvOrders.Rows[e.RowIndex].Cells["CardNumber"].Value.ToString();
                    Status = dgvOrders.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                    OrderDate = dgvOrders.Rows[e.RowIndex].Cells["OrderDate"].Value.ToString();
                    Comments = dgvOrders.Rows[e.RowIndex].Cells["Comments"].Value.ToString();
                    Type = dgvOrders.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                    Acct = dgvOrders.Rows[e.RowIndex].Cells["OrdAcct"].Value.ToString();
                    Ind = dgvOrders.Rows[e.RowIndex].Cells["OrdInd"].Value.ToString();
                    Qty = dgvOrders.Rows[e.RowIndex].Cells["OrdQty"].Value.ToString();
                    sMonth = dgvOrders.Rows[e.RowIndex].Cells["OrdMonth"].Value.ToString();
                    sYear = dgvOrders.Rows[e.RowIndex].Cells["OrdYear"].Value.ToString();
                    Comm = dgvOrders.Rows[e.RowIndex].Cells["OrdComm"].Value.ToString();
                    Price = dgvOrders.Rows[e.RowIndex].Cells["OrdPrice"].Value.ToString();
                    Filled = dgvOrders.Rows[e.RowIndex].Cells["OrdFilled"].Value.ToString();
                    ParentID = dgvOrders.Rows[e.RowIndex].Cells["ParentID"].Value.ToString();

                    Comp = dgvOrders.Rows[e.RowIndex].Cells["Comp"].Value.ToString();
                    //Boolean CheckValue = true;

                    viewCommodities.RowFilter = "TP_COMM = " + Comm.ToString();
                    string ExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();

                    ord.EditOrderInGrid(OrderNumber.ToString(), Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                            Filled, Type, Comp, ParentID, FixEO, FixGTC, CardNumber, Status, Comments,
                            OrderDate, VCAccount, VCCustomer, VCComments, CurrentUser, ExchangeLetter, ref OrderSent,
                            ref ReturnMessage, Can);
                    if (OrderSent != "")
                    {
                        ShowMessage(OrderSent, ReturnMessage);
                    }

                    RefreshOrderGrid();
                    tmrOrders.Interval = 10000;
                    tmrRegionOrders.Interval = 600;
                    tmrVCF.Interval = 10000;
                    tmrPosition.Interval = 15000;

                    tmrRegionOrders.Interval = 600;
                    tmrECorders.Interval = 10000;
                    dgvOrders.Rows[giRowIndex].Cells[mColumnIndex].Selected = true;

                }
            }

        }


        private void ReviseOrder(int OrderNumber)
        {
            frmEditOrder frmEdit = new frmEditOrder();
            OrdersNew clsOrdersNew = new OrdersNew();
            frmEdit.frmCopyOrders = this;
            try
            {
                frmEdit.mOrderNumber = OrderNumber;
                frmEdit.ShowDialog(this);
                RefreshOrderGrid();
                RefreshPositions();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmEdit.Dispose();
            // frmEdit.frmCopyOrders.Dispose();

        }

        private void ReviseRegionOrder(int OrderNumber, string Price, string Qty, string RequestID)
        {
            frmEditOrder frmEdit = new frmEditOrder();
            OrdersNew clsOrdersNew = new OrdersNew();
            CRMProcessing crm = new CRMProcessing();
            frmEdit.frmCopyOrders = this;

            try
            {
                frmEdit.ReplPrice = Price;
                frmEdit.ReplQty = Qty;
                frmEdit.fromRegion = true;
                frmEdit.RequestID = RequestID;
                frmEdit.mOrderNumber = OrderNumber;
                frmEdit.ShowDialog(this);
                RefreshOrderGrid();
                UpdateRegionGrid();
                RefreshPositions();

                crm.ProcessUpdateCRMonUpdate(OrderNumber);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmEdit.Dispose();
            // frmEdit.frmCopyOrders.Dispose();

        }


        private void ReviseOrderSpread(int OrderNumber)
        {
            frmEditOrderSpread frmEdit = new frmEditOrderSpread();
            OrdersNew clsOrdersNew = new OrdersNew();
            frmEdit.frmCopyOrders = this;
            try
            {
                frmEdit.mOrderNumber = OrderNumber;
                frmEdit.ShowDialog(this);
                RefreshPositions();
                RefreshOrderGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmEdit.Dispose();
            //frmEdit.frmCopyOrders.Dispose();


        }

        private void DeleteOrderSpread(int OrderNumber)
        {
            frmDeleteOrderSpread frmEdit = new frmDeleteOrderSpread();
            OrdersNew clsOrdersNew = new OrdersNew();
            frmEdit.frmCopyOrders = this;
            try
            {
                frmEdit.mOrderNumber = OrderNumber;
                frmEdit.ShowDialog(this);
                RefreshPositions();
                RefreshOrderGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmEdit.Dispose();
            //frmEdit.frmCopyOrders.Dispose();


        }

        private void DeleteOrder(int OrderNumber)
        {
            frmDeleteOrder frmEdit = new frmDeleteOrder();
            OrdersNew clsOrdersNew = new OrdersNew();
            frmEdit.frmCopyOrders = this;
            try
            {
                frmEdit.mOrderNumber = OrderNumber;
                frmEdit.ShowDialog(this);
                RefreshOrderGrid();
                RefreshPositions();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmEdit.Dispose();
            // frmEdit.frmCopyOrders.Dispose();

        }

        private void ViewOrder(int OrderNumber)
        {
            frmViewOrder frmEdit = new frmViewOrder();
            OrdersNew clsOrdersNew = new OrdersNew();
            frmEdit.frmCopyOrders = this;
            try
            {
                frmEdit.mOrderNumber = OrderNumber;
                frmEdit.ShowDialog(this);
                //RefreshPositions();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmEdit.Dispose();
            //frmEdit.frmCopyOrders.Dispose();


        }

        private void ViewOrderSpread(int OrderNumber)
        {
            frmViewOrderSpread frmEdit = new frmViewOrderSpread();
            OrdersNew clsOrdersNew = new OrdersNew();
            frmEdit.frmCopyOrders = this;
            try
            {
                frmEdit.mOrderNumber = OrderNumber;
                frmEdit.ShowDialog(this);
                //RefreshPositions();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmEdit.Dispose();
            //frmEdit.frmCopyOrders.Dispose();


        }


        private void ViewOrderHistory(int OrderNumber)
        {
            frmViewOrderHistory frmEdit = new frmViewOrderHistory();
            OrdersNew clsOrdersNew = new OrdersNew();
            frmEdit.frmCopyOrders = this;
            try
            {
                frmEdit.mOrderNumber = OrderNumber;
                frmEdit.ShowDialog(this);
                //RefreshPositions();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmEdit.Dispose();
            //frmEdit.frmCopyOrders.Dispose();


        }

        private void ViewOrderSpreadHistory(int OrderNumber)
        {
            frmViewOrderSpreadHistory frmEdit = new frmViewOrderSpreadHistory();
            OrdersNew clsOrdersNew = new OrdersNew();
            frmEdit.frmCopyOrders = this;
            try
            {
                frmEdit.mOrderNumber = OrderNumber;
                frmEdit.ShowDialog(this);
                //RefreshPositions();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmEdit.Dispose();
            //frmEdit.frmCopyOrders.Dispose();


        }


        public void CancelOrder(int OrderNumber, ref string OrderSent)
        {
            OrdersNew clsOrdersNew = new OrdersNew();
            CRMProcessing crm = new CRMProcessing();
            string ErrorMessage = "";
            string OverrideMessage = "";
            string Override = "N";
            //string OrderSent = "";
            string ReturnMessage = "";
            try
            {
                clsOrdersNew.CancelOrder(OrderNumber, ref ErrorMessage, ref OverrideMessage, Override, ref OrderSent, ref ReturnMessage);
                if (OverrideMessage == "Y")
                {

                    if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to cancel order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        clsOrdersNew.CancelOrder(OrderNumber, ref ErrorMessage, ref OverrideMessage, "Y", ref OrderSent, ref ReturnMessage);
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                        RefreshOrderGrid();
                        RefreshPositions();
                        UpdateRegionGrid();
                        crm.ProcessUpdateCRMonCancellation(OrderNumber);


                    }
                }
                else
                {
                    if (ErrorMessage != "")
                    {
                        ShowMessage("4", ErrorMessage);
                        OrderSent = "9";
                    }
                    else
                    {
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                        RefreshOrderGrid();
                        RefreshPositions();
                        UpdateRegionGrid();


                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }

        }

        public void ShowMessage(string OrderSent, string ReturnMessage)
        {
            if (OrderSent != "1")
            {
                MessageBox.Show(ReturnMessage.ToString());
            }
            RefreshOrderGrid();
            RefreshPositions();
            UpdateRegionGrid();
        }

        private void dgvRegionOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OrdersUpdate ordUpdate = new OrdersUpdate();
            CRMProcessing crm = new CRMProcessing();
            int RegID = 0;
            string OrderNumber = "";
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 120000;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrECorders.Interval = 10000;
            try
            {
                OrdersNew ord = new OrdersNew();
                //OrdersUpdate ordUpdate = new OrdersUpdate();
                int RowIndex = 0;
                string RegType = "";
                string Acct = "";
                //string Filled = "";
                string Ind = "";
                string Qty = "";
                string sYear = "";
                string sMonth = "";
                string Comm = "";
                string Type = "";
                string Price = "";
                string GTC = "0";
                string EO = "0";
                string Comments = "";
                string PremSide = "";
                string s2Month = "";
                string s2year = "";
                string RegionOrder = "";
                string ReplQty = "0";
                string ReplPrice = "0";
                string CancReq = "0";
                string ReplReq = "0";
                string OrderSent = "";
                string TradeCompany = "";
                DataTable SecondSpreadSide = new DataTable();
                DataView SecondSideView = new DataView();

                //string Comments = "";


                if (dgvRegionOrders.Columns[e.ColumnIndex].Name == "EX" || dgvRegionOrders.Columns[e.ColumnIndex].Name == "Rsn" ||
                    dgvRegionOrders.Columns[e.ColumnIndex].Name == "FT" || dgvRegionOrders.Columns[e.ColumnIndex].Name == "CH" ||
                    dgvRegionOrders.Columns[e.ColumnIndex].Name == "Miz")
                {
                    Acct = dgvRegionOrders.Rows[e.RowIndex].Cells["Acct"].Value.ToString();
                    Ind = dgvRegionOrders.Rows[e.RowIndex].Cells["Ind"].Value.ToString();
                    Qty = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqQty"].Value.ToString();
                    sYear = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqYear"].Value.ToString();
                    sMonth = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqMonth"].Value.ToString();
                    Comm = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqComm"].Value.ToString();
                    Type = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqType"].Value.ToString();
                    Price = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqPrice"].Value.ToString();
                    GTC = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqGTC"].Value.ToString();
                    EO = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqEO"].Value.ToString();
                    CancReq = dgvRegionOrders.Rows[e.RowIndex].Cells["CancReq"].Value.ToString();
                    ReplReq = dgvRegionOrders.Rows[e.RowIndex].Cells["ReplReq"].Value.ToString();
                    ReplQty = dgvRegionOrders.Rows[e.RowIndex].Cells["NewRegQty"].Value.ToString();
                    ReplPrice = dgvRegionOrders.Rows[e.RowIndex].Cells["NewReqPrice"].Value.ToString();
                    PremSide = dgvRegionOrders.Rows[e.RowIndex].Cells["PremiumSide"].Value.ToString();
                    RowIndex = e.RowIndex;
                    RegID = Convert.ToInt32(dgvRegionOrders.Rows[e.RowIndex].Cells["Reg_ID"].Value.ToString());
                    RegType = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqType"].Value.ToString();
                    OrderNumber = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqOrdID"].Value.ToString();
                    Comments = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqComments"].Value.ToString();
                    Decimal decQty = Convert.ToDecimal(Qty);
                    int intQty = (int)Math.Round(decQty, MidpointRounding.ToEven);
                    Qty = intQty.ToString();
                    viewAccounts.RowFilter = "TP_ACCT = " + Acct.ToString();
                    if (Convert.ToInt32(viewAccounts[0]["SingleSideAccount"].ToString()) == 1)
                    {
                        TradeCompany = "25";
                    }

                    if (RegType == "ORD" && EO == "False")
                    {
                        if (MessageBox.Show("This ORD does not have EO checked.  You will need to call this order into the pit.  Do you want to bring this order in?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }

                    isRegionOrder = true;
                }
                if (dgvRegionOrders.Columns[e.ColumnIndex].Name == "EX")
                {
                    //if(Comm.ToString() == "26")
                    //{
                    //    MessageBox.Show("KC Wheat is not an EX order.", "Hedge Order");
                    //    return;
                    //}

                    
                    if (Type != "EX")
                    {
                        MessageBox.Show("This is not an EX order.", "Hedge Order");
                        return;
                    }
                    ordUpdate.CheckOrder(RegID, ref RegionOrder);
                    if (RegionOrder == "0" || RegionOrder == "")
                    {
                        MessageBox.Show("This order has already been selected for processing by another hedger.", "Hedge Order");
                        UpdateRegionGrid();
                        return;
                    }
                    ordUpdate.SelectOrder(RegID);
                    UpdateRegionGrid();
                    if (ValidateRegionEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, "15", Price, false, EO, GTC))
                    {
                        AddRegionNonECOrder(RegID, 15);
                    }
                    else
                    {
                        ordUpdate.UnSelectOrder(RegID);
                        UpdateRegionGrid();
                    }
                }
                if (dgvRegionOrders.Columns[e.ColumnIndex].Name == "Rsn")
                {
                    if (Comm.ToString() == "26")
                    {
                        MessageBox.Show("KC Wheat is not a valid commodity for this company.", "Hedge Order");
                        return;
                    }

                    if (Type == "EX")
                    {
                        MessageBox.Show("This is not an EC order.", "Hedge Order");
                        return;
                    }
                    ordUpdate.CheckOrder(RegID, ref RegionOrder);
                    if (RegionOrder == "0" || RegionOrder == "")
                    {
                        MessageBox.Show("This order has already been selected for processing by another hedger.", "Hedge Order");
                        UpdateRegionGrid();
                        return;
                    }
                    ordUpdate.SelectOrder(RegID);
                    if (Convert.ToInt32(viewAccounts[0]["SingleSideAccount"].ToString()) == 1)
                    {
                        TradeCompany = "25";
                    }
                    else
                    {
                        TradeCompany = "55";
                    }
                    
                    if (Type == "CH")
                    {

                        //if (Comm.ToString() == "26")
                        //{
                        //    MessageBox.Show("KC Wheat is not a valid CH commodity.", "Hedge Order");
                        //    return;
                        //}
                        if (MessageBox.Show("Bring in CH order and place Rosenthal market order?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            ordUpdate.UnSelectOrder(RegID);
                            UpdateRegionGrid();
                            return;
                        }
                        else
                        {
                            if (ValidateEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany, Price, PremSide, s2Month, s2year, false, EO, GTC))
                            {
                                AddRegionNonECOrder(RegID, 11);
                                crm.ProcessUpdateCRMonApproval(RegID);
                                if (Acct.ToString() == "41")
                                {
                                    Acct = "3";
                                }
                                //else if (Acct.ToString() == "53")
                                //{
                                //    Acct = "5";
                                //}
                                else
                                {
                                    Acct = "2";
                                }
                                viewAccountComps.RowFilter = "TP_ACCT = " + Acct + " AND TP_TRADE_COMP = " + TradeCompany.ToString();
                                viewCommodities.RowFilter = "TP_COMM = " + Comm;
                                viewMonths.RowFilter = "TP_MON = '" + sMonth + "' AND TP_COMM = " + Comm;
                                viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + "ORD" + "'";
                                string strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                                string strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                                int AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
                                int FixEO = 0;
                                int FixGTC = 0;
                                string ReturnMessage = "";
                                string Company = viewAccountComps[0]["TP_COMP"].ToString();
                                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                                string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
                                FixEO = 1;
                                FixGTC = 0;
                                OrdersNew Ord = new OrdersNew();
                                Ord.AddOrderSingle(TradeCompany, Ind, Acct, Comm, strExchangeLetter,
                                   sMonth, sYear, Qty, "0", "ORD", TradeCompany,
                                   FixEO, FixGTC, AcctXref, CurrentUser, TransType, ref OrderSent, ref ReturnMessage);

                                if (OrderSent != "")
                                {
                                    ShowMessage(OrderSent, ReturnMessage);
                                }

                            }
                            else
                            {
                                ordUpdate.UnSelectOrder(RegID);
                                UpdateRegionGrid();
                                return;

                            }
                        }
                    }
                    else
                    {
                        if (OrderNumber.ToString() != "")
                        {
                            if (CancReq.ToString() == "True")
                            {
                                CancelOrder(Convert.ToInt32(OrderNumber.ToString()), ref OrderSent);
                                if (OrderSent.ToString() == "9")
                                {
                                    ordUpdate.UnSelectOrder(RegID);
                                }
                            }
                            if (ReplReq.ToString() == "True")
                            {
                                ReviseRegionOrder(Convert.ToInt32(OrderNumber.ToString()), ReplPrice, ReplQty, RegID.ToString());
                            }
                        }
                        else
                        {

                            if (Type.ToString() != "SPR")
                            {
                                if (ValidateRegionEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany, Price, false, EO, GTC))
                                {
                                    viewAccountComps.RowFilter = "TP_ACCT = " + Acct.ToString() + " AND TP_TRADE_COMP = " + TradeCompany.ToString();
                                    if (viewAccountComps.Count == 0)
                                    {
                                        MessageBox.Show("Invalid Account/Company combination.", "Hedge Order");
                                        return;
                                    }
                                    if (EO.ToString() == "True" && viewAccountComps[0]["SendToEC"].ToString() == "True")
                                    {
                                        if (Convert.ToInt32(Qty.ToString()) > Convert.ToInt32(viewAccountComps[0]["ECContractLimit"].ToString()))
                                        {
                                            MessageBox.Show("This order exceeds the contract amount for EC.", "Hedge Order");
                                            return;
                                        }

                                        if (this.chkConfirmOrder.Checked)
                                        {
                                            frmAddOrder frmAdd = new frmAddOrder();
                                            OrdersNew clsOrdersNew = new OrdersNew();
                                            frmAdd.frmCopyOrders = this;
                                            frmAdd.fromRegionButton = true;
                                            frmAdd.mTradeCompID = TradeCompany.ToString();
                                            frmAdd.mRequestID = RegID;
                                            frmAdd.ShowDialog(this);
                                            frmAdd.Dispose();
                                            //frmAdd.frmCopyOrders.Dispose();

                                        }
                                        else
                                        {
                                            AddRegionECOrder(RegID, Convert.ToInt32(TradeCompany.ToString()));
                                            crm.ProcessUpdateCRMonApproval(RegID);
                                        }
                                    }
                                    else
                                    {
                                        AddRegionNonECOrder(RegID, Convert.ToInt32(TradeCompany.ToString()));
                                        crm.ProcessUpdateCRMonApproval(RegID);
                                    }
                                }
                                else
                                {
                                    ordUpdate.UnSelectOrder(RegID);
                                    UpdateRegionGrid();
                                }
                            }
                            else
                            {
                                if (ValidateRegionSpreadEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany.ToString(), true))
                                {
                                    viewAccountComps.RowFilter = "TP_ACCT = " + Acct.ToString() + " AND TP_TRADE_COMP = " + TradeCompany.ToString();
                                    if (viewAccountComps.Count == 0)
                                    {
                                        MessageBox.Show("Invalid Account/Company combination.", "Hedge Order");
                                        return;
                                    }
                                    if (EO.ToString() == "True" && viewAccountComps[0]["SendToEC"].ToString() == "True")
                                    {
                                        //if (Convert.ToInt32(Qty.ToString()) > Convert.ToInt32(viewAccountComps[0]["ECContractLimit"].ToString()))
                                        //{
                                        //    MessageBox.Show("This order exceeds the contract amount for EC.", "Hedge Order");
                                        //    return;
                                        //}
                                    }
                                    if (this.txtMonth.Text == "" && this.txtQty.Text == "")
                                    {
                                        if (ProcessSpreadLeg1(Acct, Type, Ind, sYear, sMonth, Comm, TradeCompany, Qty, RegID.ToString(), Price, GTC, EO, Comments, PremSide))
                                        {
                                            GlobalStore.mdtSecondSpreadOrder.Clear();
                                            SecondSpreadSide = GlobalStore.FillSecondSpreadOrderDataTable(RegID);
                                            SecondSideView = SecondSpreadSide.DefaultView;
                                            if (SecondSpreadSide.Rows.Count == 0)
                                            {
                                                MessageBox.Show("No spread that matches the first leg was found.  There is an error with this order or you will need to select the second side manually.", "Hedge Order");
                                                return;
                                            }
                                            else if (SecondSpreadSide.Rows.Count > 1)
                                            {
                                                MessageBox.Show("There is more than one spread that matches the first leg.  You will need to select the second side manually.", "Hedge Order");
                                                return;
                                            }
                                            else
                                            {
                                                RegID = Convert.ToInt32(SecondSideView[0]["Request_ID"].ToString());
                                                ordUpdate.SelectOrder(RegID);
                                                UpdateRegionGrid();
                                                Acct = SecondSideView[0]["TP_ACCT"].ToString();
                                                Ind = SecondSideView[0]["TP_IND"].ToString();
                                                sYear = SecondSideView[0]["TP_YEAR"].ToString();
                                                sMonth = SecondSideView[0]["TP_MON"].ToString();
                                                Comm = SecondSideView[0]["TP_COMM"].ToString();
                                                Qty = SecondSideView[0]["TP_AMT"].ToString();
                                                Price = SecondSideView[0]["TP_Price"].ToString();
                                                Comments = SecondSideView[0]["Comments"].ToString();
                                                GTC = SecondSideView[0]["GTC"].ToString();
                                                EO = SecondSideView[0]["FixElectonicOrder"].ToString();

                                                if (ProcessSpreadLeg2(Acct, "SPR", Ind, sYear, sMonth, Comm, TradeCompany, Qty, RegID.ToString(), Price, GTC, EO, Comments))
                                                {
                                                    //txtPremSide.Focus();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("There was an error entering the second leg.  Clear all and try again.", "Hedge Order");
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("There was an error entering the first leg.  Clear all and try again.", "Hedge Order");
                                        }
                                    }
                                    else
                                    {
                                        if (this.txtMonth.Text != "" && this.txtSMonth.Text != "")
                                        {
                                            MessageBox.Show("Both leg sides have entries.  Clear the form and begin again.", "Hedge Order");
                                            ordUpdate.UnSelectOrder(RegID);
                                            UpdateRegionGrid();
                                            return;
                                        }
                                        else
                                        {
                                            ProcessSpreadLeg2(Acct, Type, Ind, sYear, sMonth, Comm, TradeCompany, Qty, RegID.ToString(), Price, GTC, EO, Comments);
                                            //txtPremSide.Focus();
                                        }
                                    }
                                }
                                else
                                {
                                    ordUpdate.UnSelectOrder(RegID);
                                    UpdateRegionGrid();
                                }
                            }
                        }
                    }
                }
                if (dgvRegionOrders.Columns[e.ColumnIndex].Name == "DN")
                {
                    ordUpdate.CheckOrder(RegID, ref RegionOrder);
                    if (RegionOrder == "0" || RegionOrder == "")
                    {
                        MessageBox.Show("This order has already been selected for processing by another hedger.", "Hedge Order");
                        UpdateRegionGrid();
                        return;
                    }
                    ordUpdate.SelectOrder(RegID);
                    UpdateRegionGrid();
                    if (ValidateRegionEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, "25", Price, false, EO, GTC))
                    {
                        if (EO.ToString() == "True")
                        {
                            AddRegionECOrder(RegID, 25);
                        }
                        else
                        {
                            AddRegionNonECOrder(RegID, 25);
                        }
                    }
                    else
                    {
                        ordUpdate.UnSelectOrder(RegID);
                        UpdateRegionGrid();

                    }
                }

                if (dgvRegionOrders.Columns[e.ColumnIndex].Name == "FT")
                {

                    if (Type == "EX")
                    {
                        MessageBox.Show("This is not an EC order.", "Hedge Order");
                        return;
                    }
                    ordUpdate.CheckOrder(RegID, ref RegionOrder);
                    UpdateRegionGrid();

                    if (RegionOrder == "0" || RegionOrder == "")
                    {
                        MessageBox.Show("This order has already been selected for processing by another hedger.", "Hedge Order");
                        UpdateRegionGrid();
                        return;
                    }
                    ordUpdate.SelectOrder(RegID);
                    if (Convert.ToInt32(viewAccounts[0]["SingleSideAccount"].ToString()) == 1)
                    {
                        TradeCompany = "25";
                    }
                    else
                    {
                        TradeCompany = "33";
                    }
                    if (Type == "CH")
                    {

                        //if (Comm.ToString() == "26")
                        //{
                        //    MessageBox.Show("KC Wheat is not a valid CH commodity.", "Hedge Order");
                        //    return;
                        //}
                        if (MessageBox.Show("Bring in CH order and place Fortis market order?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            ordUpdate.UnSelectOrder(RegID);
                            UpdateRegionGrid();
                            return;
                        }
                        else
                        {
                            if (ValidateEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany, Price, PremSide, s2Month, s2year, false, EO, GTC))
                            {
                                AddRegionNonECOrder(RegID, 11);
                                crm.ProcessUpdateCRMonApproval(RegID);
                                if (Acct.ToString() == "41")
                                {
                                    Acct = "3";
                                }
                                //else if (Acct.ToString() == "53")
                                //{
                                //    Acct = "5";
                                //}
                                else
                                {
                                    Acct = "2";
                                }
                                viewAccountComps.RowFilter = "TP_ACCT = " + Acct + " AND TP_TRADE_COMP = " + TradeCompany.ToString();
                                viewCommodities.RowFilter = "TP_COMM = " + Comm;
                                viewMonths.RowFilter = "TP_MON = '" + sMonth + "' AND TP_COMM = " + Comm;
                                viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + "ORD" + "'";
                                string strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                                string strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                                int AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
                                int FixEO = 0;
                                int FixGTC = 0;
                                string ReturnMessage = "";
                                string Company = viewAccountComps[0]["TP_COMP"].ToString();
                                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                                string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
                                FixEO = 1;
                                FixGTC = 0;
                                OrdersNew Ord = new OrdersNew();
                                Ord.AddOrderSingle(TradeCompany, Ind, Acct, Comm, strExchangeLetter,
                                   sMonth, sYear, Qty, "0", "ORD", TradeCompany,
                                   FixEO, FixGTC, AcctXref, CurrentUser, TransType, ref OrderSent, ref ReturnMessage);

                                if (OrderSent != "")
                                {
                                    ShowMessage(OrderSent, ReturnMessage);
                                }

                            }
                            else
                            {
                                ordUpdate.UnSelectOrder(RegID);
                                UpdateRegionGrid();
                                return;

                            }
                        }
                    }
                    else
                    {
                        if (OrderNumber.ToString() != "")
                        {
                            if (CancReq.ToString() == "True")
                            {
                                CancelOrder(Convert.ToInt32(OrderNumber.ToString()), ref OrderSent);
                                if (OrderSent.ToString() == "9")
                                {
                                    ordUpdate.UnSelectOrder(RegID);
                                }
                            }
                            if (ReplReq.ToString() == "True")
                            {
                                ReviseRegionOrder(Convert.ToInt32(OrderNumber.ToString()), ReplPrice, ReplQty, RegID.ToString());
                            }
                        }
                        else
                        {
                            if (Type.ToString() != "SPR")
                            {
                                if (ValidateRegionEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany, Price, false, EO, GTC))
                                {
                                    viewAccountComps.RowFilter = "TP_ACCT = " + Acct.ToString() + " AND TP_TRADE_COMP = " + TradeCompany.ToString();
                                    if (viewAccountComps.Count == 0)
                                    {
                                        MessageBox.Show("Invalid Account/Company combination.", "Hedge Order");
                                        return;
                                    }
                                    if (EO.ToString() == "True" && viewAccountComps[0]["SendToEC"].ToString() == "True")
                                    {
                                        if (Convert.ToInt32(Qty.ToString()) > Convert.ToInt32(viewAccountComps[0]["ECContractLimit"].ToString()))
                                        {
                                            MessageBox.Show("This order exceeds the contract amount for EC.", "Hedge Order");
                                            return;
                                        }
                                    }
                                    if (EO.ToString() == "True" && viewAccountComps[0]["SendToEC"].ToString() == "True")
                                    {
                                        if (this.chkConfirmOrder.Checked)
                                        {
                                            frmAddOrder frmAdd = new frmAddOrder();
                                            OrdersNew clsOrdersNew = new OrdersNew();
                                            frmAdd.frmCopyOrders = this;
                                            frmAdd.fromRegionButton = true;
                                            frmAdd.mTradeCompID = TradeCompany.ToString();
                                            frmAdd.mRequestID = RegID;
                                            frmAdd.ShowDialog(this);
                                            frmAdd.Dispose();
                                            //frmAdd.frmCopyOrders.Dispose();

                                        }
                                        else
                                        {
                                            AddRegionECOrder(RegID, Convert.ToInt32(TradeCompany));
                                            crm.ProcessUpdateCRMonApproval(RegID);
                                        }
                                    }
                                    else
                                    {
                                        AddRegionNonECOrder(RegID, Convert.ToInt32(TradeCompany));
                                        crm.ProcessUpdateCRMonApproval(RegID);
                                    }
                                }
                                else
                                {
                                    ordUpdate.UnSelectOrder(RegID);
                                    UpdateRegionGrid();

                                }
                            }
                            else
                            {
                                if (ValidateRegionSpreadEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany, true))
                                {
                                    if (this.txtMonth.Text == "" && this.txtQty.Text == "")
                                    {
                                        if (ProcessSpreadLeg1(Acct, Type, Ind, sYear, sMonth, Comm, TradeCompany, Qty, RegID.ToString(), Price, GTC, EO, Comments, PremSide))
                                        {
                                            GlobalStore.mdtSecondSpreadOrder.Clear();
                                            SecondSpreadSide = GlobalStore.FillSecondSpreadOrderDataTable(RegID);
                                            SecondSideView = SecondSpreadSide.DefaultView;
                                            if (SecondSpreadSide.Rows.Count == 0)
                                            {
                                                MessageBox.Show("No spread that matches the first leg was found.  There is an error with this order or you will need to select the second side manually.", "Hedge Order");
                                                return;
                                            }
                                            else if (SecondSpreadSide.Rows.Count > 1)
                                            {
                                                MessageBox.Show("There is more than one spread that matches the first leg.  You will need to select the second side manually.", "Hedge Order");
                                                return;
                                            }
                                            else
                                            {
                                                RegID = Convert.ToInt32(SecondSideView[0]["Request_ID"].ToString());
                                                ordUpdate.SelectOrder(RegID);
                                                UpdateRegionGrid();
                                                Acct = SecondSideView[0]["TP_ACCT"].ToString();
                                                Ind = SecondSideView[0]["TP_IND"].ToString();
                                                sYear = SecondSideView[0]["TP_YEAR"].ToString();
                                                sMonth = SecondSideView[0]["TP_MON"].ToString();
                                                Comm = SecondSideView[0]["TP_COMM"].ToString();
                                                Qty = SecondSideView[0]["TP_AMT"].ToString();
                                                Decimal decQty = Convert.ToDecimal(Qty);
                                                int intQty = (int)Math.Round(decQty, MidpointRounding.ToEven);
                                                Qty = intQty.ToString();
                                                Price = SecondSideView[0]["TP_Price"].ToString();
                                                Comments = SecondSideView[0]["Comments"].ToString();
                                                GTC = SecondSideView[0]["GTC"].ToString();
                                                EO = SecondSideView[0]["FixElectonicOrder"].ToString();

                                                if (ProcessSpreadLeg2(Acct, "SPR", Ind, sYear, sMonth, Comm, TradeCompany, Qty, RegID.ToString(), Price, GTC, EO, Comments))
                                                {
                                                    //txtPremSide.Focus();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("There was an error entering the second leg.  Clear all and try again.", "Hedge Order");
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("There was an error entering the first leg.  Clear all and try again.", "Hedge Order");
                                        }
                                    }
                                    else
                                    {
                                        if (this.txtMonth.Text != "" && this.txtSMonth.Text != "")
                                        {
                                            MessageBox.Show("Both leg sides have entries.  Clear the form and begin again.", "Hedge Order");
                                            ordUpdate.UnSelectOrder(RegID);
                                            UpdateRegionGrid();
                                            return;
                                        }
                                        else
                                        {
                                            ProcessSpreadLeg2(Acct, Type, Ind, sYear, sMonth, Comm, TradeCompany, Qty, RegID.ToString(), Price, GTC, EO, Comments);
                                            //txtPremSide.Focus();
                                        }
                                    }
                                }
                                else
                                {
                                    ordUpdate.UnSelectOrder(RegID);
                                    UpdateRegionGrid();
                                }

                            }
                        }
                    }
                }
                if (dgvRegionOrders.Columns[e.ColumnIndex].Name == "CH")
                {
                    //if (Comm.ToString() == "26")
                    //{
                    //    MessageBox.Show("KC Wheat is not a valid CH commodity.", "Hedge Order");
                    //    return;
                    //}
                    if (Type != "CH" && Type != "MOO" && Type != "MOC")
                    {
                        MessageBox.Show("This is not a CH order.", "Hedge Order");
                        return;
                    }
                    ordUpdate.CheckOrder(RegID, ref RegionOrder);
                    if (RegionOrder == "0" || RegionOrder == "")
                    {
                        MessageBox.Show("This order has already been selected for processing by another hedger.", "Hedge Order");
                        UpdateRegionGrid();
                        return;
                    }
                    ordUpdate.SelectOrder(RegID);
                    UpdateRegionGrid();
                    if (ValidateRegionEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, "11", Price, false, EO, GTC))
                    { AddRegionNonECOrder(RegID, 11);
                    crm.ProcessUpdateCRMonApproval(RegID);
                    }
                    else
                    {
                        ordUpdate.UnSelectOrder(RegID);
                        UpdateRegionGrid();

                    }
                }
                if (dgvRegionOrders.Columns[e.ColumnIndex].Name == "Miz")
                {
                    if (Comm.ToString() == "26")
                    {
                        MessageBox.Show("KC Wheat is not a valid commodity for this company.", "Hedge Order");
                        return;
                    }
                    if (Type == "EX")
                    {
                        MessageBox.Show("This is not an EC order.", "Hedge Order");
                        return;
                    }
                    ordUpdate.CheckOrder(RegID, ref RegionOrder);
                    if (RegionOrder == "0" || RegionOrder == "")
                    {
                        MessageBox.Show("This order has already been selected for processing by another hedger.", "Hedge Order");
                        UpdateRegionGrid();
                        return;
                    }
                    ordUpdate.SelectOrder(RegID);
                    if (Convert.ToInt32(viewAccounts[0]["SingleSideAccount"].ToString()) == 1)
                    {
                        TradeCompany = "25";
                    }
                    else
                    {
                        TradeCompany = "19";
                    }
                    //UpdateRegionGrid();
                    if (Type == "CH")
                    {

                        //if (Comm.ToString() == "26")
                        //{
                        //    MessageBox.Show("KC Wheat is not a valid CH commodity.", "Hedge Order");
                        //    return;
                        //}
                        if (MessageBox.Show("Bring in CH order and place Mizuho market order?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            ordUpdate.UnSelectOrder(RegID);
                            UpdateRegionGrid();
                            return;
                        }
                        else
                        {
                            if (ValidateEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany, Price, PremSide, s2Month, s2year, false, EO, GTC))
                            {
                                AddRegionNonECOrder(RegID, 11);
                                crm.ProcessUpdateCRMonApproval(RegID);
                                if (Acct.ToString() == "41")
                                {
                                    Acct = "3";
                                }
                                //else if (Acct.ToString() == "53")
                                //{
                                //    Acct = "5";
                                //}
                                else
                                {
                                    Acct = "2";
                                }
                                viewAccountComps.RowFilter = "TP_ACCT = " + Acct + " AND TP_TRADE_COMP = " + TradeCompany.ToString();
                                viewCommodities.RowFilter = "TP_COMM = " + Comm;
                                viewMonths.RowFilter = "TP_MON = '" + sMonth + "' AND TP_COMM = " + Comm;
                                viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + "ORD" + "'";
                                string strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                                string strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                                int AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
                                int FixEO = 0;
                                int FixGTC = 0;
                                string ReturnMessage = "";
                                string Company = viewAccountComps[0]["TP_COMP"].ToString();
                                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                                string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
                                FixEO = 1;
                                FixGTC = 0;
                                OrdersNew Ord = new OrdersNew();
                                Ord.AddOrderSingle(TradeCompany, Ind, Acct, Comm, strExchangeLetter,
                                   sMonth, sYear, Qty, "0", "ORD", TradeCompany,
                                   FixEO, FixGTC, AcctXref, CurrentUser, TransType, ref OrderSent, ref ReturnMessage);

                                if (OrderSent != "")
                                {
                                    ShowMessage(OrderSent, ReturnMessage);
                                }

                            }
                            else
                            {
                                ordUpdate.UnSelectOrder(RegID);
                                UpdateRegionGrid();
                                return;

                            }
                        }
                    }
                    else
                    {
                        if (OrderNumber.ToString() != "")
                        {
                            if (CancReq.ToString() == "True")
                            {
                                CancelOrder(Convert.ToInt32(OrderNumber.ToString()), ref OrderSent);
                                if (OrderSent.ToString() == "9")
                                {
                                    ordUpdate.UnSelectOrder(RegID);
                                }
                            }
                            if (ReplReq.ToString() == "True")
                            {
                                ReviseRegionOrder(Convert.ToInt32(OrderNumber.ToString()), ReplPrice, ReplQty, RegID.ToString());
                                                            }
                        }

                        else
                        {
                            if (Type.ToString() != "SPR")
                            {
                                if (ValidateRegionEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany, Price, false, EO, GTC))
                                {
                                    viewAccountComps.RowFilter = "TP_ACCT = " + Acct.ToString() + " AND TP_TRADE_COMP = " + TradeCompany.ToString();

                                    if (viewAccountComps.Count == 0)
                                    {
                                        MessageBox.Show("Invalid Account/Company combination.", "Hedge Order");
                                        return;
                                    }
                                    if (EO.ToString() == "True" && viewAccountComps[0]["SendToEC"].ToString() == "True")
                                    {
                                        if (Convert.ToInt32(Qty.ToString()) > Convert.ToInt32(viewAccountComps[0]["ECContractLimit"].ToString()))
                                        {
                                            MessageBox.Show("This order exceeds the contract amount for EC.", "Hedge Order");
                                            return;
                                        }
                                    }
                                    if (EO.ToString() == "True" && viewAccountComps[0]["SendToEC"].ToString() == "True")
                                    {

                                        if (this.chkConfirmOrder.Checked)
                                        {
                                            frmAddOrder frmAdd = new frmAddOrder();
                                            OrdersNew clsOrdersNew = new OrdersNew();
                                            frmAdd.frmCopyOrders = this;
                                            frmAdd.fromRegionButton = true;
                                            frmAdd.mTradeCompID = TradeCompany.ToString();
                                            frmAdd.mRequestID = RegID;
                                            frmAdd.ShowDialog(this);
                                            frmAdd.Dispose();
                                            //frmAdd.frmCopyOrders.Dispose();
                                        }
                                        else
                                        {
                                            AddRegionECOrder(RegID, Convert.ToInt32(TradeCompany.ToString()));
                                            crm.ProcessUpdateCRMonApproval(RegID);
                                        }
                                    }
                                    else
                                    {
                                        AddRegionNonECOrder(RegID, Convert.ToInt32(TradeCompany.ToString()));
                                        crm.ProcessUpdateCRMonApproval(RegID);
                                    }
                                }
                                else
                                {
                                    ordUpdate.UnSelectOrder(RegID);
                                    UpdateRegionGrid();
                                }
                            }
                            else
                            {
                                if (ValidateRegionSpreadEntry("0", Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany, true))
                                {
                                    if (this.txtMonth.Text == "" && this.txtQty.Text == "")
                                    {
                                        if (ProcessSpreadLeg1(Acct, Type, Ind, sYear, sMonth, Comm, TradeCompany, Qty, RegID.ToString(), Price, GTC, EO, Comments, PremSide))
                                        {
                                            GlobalStore.mdtSecondSpreadOrder.Clear();
                                            SecondSpreadSide = GlobalStore.FillSecondSpreadOrderDataTable(RegID);
                                            SecondSideView = SecondSpreadSide.DefaultView;
                                            if (SecondSpreadSide.Rows.Count == 0)
                                            {
                                                MessageBox.Show("No spread that matches the first leg was found.  There is an error with this order or you will need to select the second side manually.", "Hedge Order");
                                                return;
                                            }
                                            else if (SecondSpreadSide.Rows.Count > 1)
                                            {
                                                MessageBox.Show("There is more than one spread that matches the first leg.  You will need to select the second side manually.", "Hedge Order");
                                                return;
                                            }
                                            else
                                            {
                                                RegID = Convert.ToInt32(SecondSideView[0]["Request_ID"].ToString());
                                                ordUpdate.SelectOrder(RegID);
                                                UpdateRegionGrid();
                                                Acct = SecondSideView[0]["TP_ACCT"].ToString();
                                                Ind = SecondSideView[0]["TP_IND"].ToString();
                                                sYear = SecondSideView[0]["TP_YEAR"].ToString();
                                                sMonth = SecondSideView[0]["TP_MON"].ToString();
                                                Comm = SecondSideView[0]["TP_COMM"].ToString();
                                                Qty = SecondSideView[0]["TP_AMT"].ToString();
                                                Price = SecondSideView[0]["TP_Price"].ToString();
                                                Comments = SecondSideView[0]["Comments"].ToString();
                                                GTC = SecondSideView[0]["GTC"].ToString();
                                                EO = SecondSideView[0]["FixElectonicOrder"].ToString();

                                                if (ProcessSpreadLeg2(Acct, "SPR", Ind, sYear, sMonth, Comm, TradeCompany, Qty, RegID.ToString(), Price, GTC, EO, Comments))
                                                {
                                                    //txtPremSide.Focus();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("There was an error entering the second leg.  Clear all and try again.", "Hedge Order");
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("There was an error entering the first leg.  Clear all and try again.", "Hedge Order");
                                        }
                                    }
                                    else
                                    {
                                        if (this.txtMonth.Text != "" && this.txtSMonth.Text != "")
                                        {
                                            MessageBox.Show("Both leg sides have entries.  Clear the form and begin again.", "Hedge Order");
                                            ordUpdate.UnSelectOrder(RegID);
                                            UpdateRegionGrid();
                                            return;
                                        }
                                        else
                                        {
                                            ProcessSpreadLeg2(Acct, Type, Ind, sYear, sMonth, Comm, TradeCompany, Qty, RegID.ToString(), Price, GTC, EO, Comments);
                                            //txtPremSide.Focus();
                                        }
                                    }
                                }
                                else
                                {
                                    ordUpdate.UnSelectOrder(RegID);
                                    UpdateRegionGrid();
                                }
                            }
                        }

                    }
                }
                isRegionOrder = false;
            }
            catch (Exception ex)
            {
                if (RegID != 0)
                {
                    ordUpdate.UnSelectOrder(RegID);
                    UpdateRegionGrid();
                }
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void AddRegionOrder(int RequestRowIndex)
        {
            try
            {
                frmAddRegionOrder frmRegionAdd = new frmAddRegionOrder();
                frmRegionAdd.frmCopyOrders = this;
                frmRegionAdd.RequestRowIndex = RequestRowIndex;
                frmRegionAdd.ShowDialog(this);
                frmRegionAdd.Dispose();
                //frmRegionAdd.frmCopyOrders.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            finally
            {
                dtRegionOrders.Clear();
                dtRegionOrders = GlobalStore.FillRegionOrdersDataSet().Tables[0];
                dgvRegionOrders.DataSource = dtRegionOrders;
                dgvRegionOrders.Refresh();
                dtOrders.Clear();
                dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                dgvOrders.DataSource = dtOrders;
                dgvOrders.Refresh();
            }
        }

        private void AddRegionOrder(int RequestRowIndex, int TradeCo, Int32 RegID)
        {
            try
            {

                //this.tmrRegionOrders.Start();
                frmAddRegionOrder frmRegionAdd = new frmAddRegionOrder();
                frmRegionAdd.frmCopyOrders = this;
                frmRegionAdd.RequestRowIndex = RequestRowIndex;
                frmRegionAdd.RequestTradeCo = TradeCo.ToString();
                frmRegionAdd.ReqID = RegID;

                frmRegionAdd.ShowDialog(this);
                frmRegionAdd.Dispose();
                //frmRegionAdd.frmCopyOrders.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            finally
            {
                dtRegionOrders.Clear();
                dtRegionOrders = GlobalStore.FillRegionOrdersDataSet().Tables[0];
                dgvRegionOrders.DataSource = dtRegionOrders;
                dgvRegionOrders.Refresh();
                dtOrders.Clear();
                dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                dgvOrders.DataSource = dtOrders;
                dgvOrders.Refresh();
            }
        }


        private void dataRepeater1_CurrentItemIndexChanged(object sender, EventArgs e)
        {

        }

        private void EO_CheckedChanged(object sender, EventArgs e)
        {
            CheckGTC(EO);
        }


        private void btnCorn2Edit_Click(object sender, EventArgs e)
        {
            try
            {
                tmrOrders.Interval = 10000;
                tmrRegionOrders.Interval = 600;
                tmrVCF.Interval = 10000;
                tmrPosition.Interval = 15000;

                tmrRegionOrders.Interval = 600;
                tmrECorders.Interval = 10000;
                Int32 OrderNumber = 0;
                //// Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
                //dr = drCorn2;
                string OrderType = drCorn2.CurrentItem.Controls["txtC2OrdType"].Text.ToString();
                OrderNumber = Convert.ToInt32(drCorn2.CurrentItem.Controls["txtC2CGBOrd"].Text.ToString());
                OrdersNew ord = new OrdersNew();
                string OrderSent = "";
                string ReturnMessage = "";
                string ErrorMessage = "";
                string ReturnOverrideMessage = "";
                string Override = "N";

                if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to Clone order " + OrderNumber.ToString() + " at the market?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }

                //int FixGTC = 0;
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                //if (this.GTC.Checked)
                //{
                //    FixGTC = 1;
                //}
                //else
                //{
                //    FixGTC = 0;
                //}
                OrdersNew Ord = new OrdersNew();

                Ord.CloneMarketOrder(CurrentUser, OrderNumber, 2, ref ErrorMessage, ref ReturnOverrideMessage, Override, ref OrderSent, ref ReturnMessage);

                if (ReturnOverrideMessage == "Y")
                {

                    if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to Clone order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        Ord.CloneMarketOrder(CurrentUser, OrderNumber, 2, ref ErrorMessage, ref ReturnOverrideMessage, "Y", ref OrderSent, ref ReturnMessage);

                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }

                    }
                }
                else
                {
                    if (ErrorMessage != "")
                    {
                        ShowMessage("4", ReturnMessage);
                    }
                    else
                    {
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                    }
                }
                ////dr.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }

        }


        public void CancelReplaceMarketOrder(int OrderNumber)
        {
            OrdersNew clsOrdersNew = new OrdersNew();
            string ErrorMessage = "";
            string OverrideMessage = "";
            string Override = "N";
            string OrderSent = "";
            string ReturnMessage = "";
            string CurrentUser = WindowsIdentity.GetCurrent().Name;

            try
            {
                clsOrdersNew.CancelReplaceMarketOrder(CurrentUser, OrderNumber, ref ErrorMessage, ref OverrideMessage, Override, ref OrderSent, ref ReturnMessage);
                if (OverrideMessage == "Y")
                {

                    if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to cancel order " + OrderNumber.ToString() + " and place a market order for the balance?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        clsOrdersNew.CancelReplaceMarketOrder(CurrentUser, OrderNumber, ref ErrorMessage, ref OverrideMessage, "Y", ref OrderSent, ref ReturnMessage);
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }

                    }
                }
                else
                {
                    if (ErrorMessage != "")
                    {
                        ShowMessage("4", ErrorMessage);
                    }
                    else
                    {
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }

        }



        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (txtType.Text == "EMC" || txtType.Text == "ORD")
            {
                if (txtQty.Text != "" && txtQty.Text != ".")
                {
                    if(Convert.ToDecimal(txtQty.Text) > Convert.ToDecimal(Properties.Settings.Default.HedgeContractLimit))
                    {
                        MessageBox.Show("Quantity cannot be greater than " + Properties.Settings.Default.HedgeContractLimit.ToString() + " contracts.");
                        txtQty.Text = "";
                        txtQty.Focus();
                        return;
                    }
                }
            }
            this.txtSQty.Text = txtQty.Text;
            //ChangeControlColor(txtMonth);

        }

        private void txtInd_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                    e.Handled = true;
                    txtInd.Text = "S".ToUpper();
                    txtSBuy.Text = "B";
                    ChangeControlColor(txtQty);
                    break;
                case '2':
                    e.Handled = true;
                    txtInd.Text = "B".ToUpper();
                    txtSBuy.Text = "S";
                    ChangeControlColor(txtQty);
                    break;
                case 's':
                case 'S':
                    e.Handled = true;
                    txtInd.Text = "S".ToUpper();
                    txtSBuy.Text = "B";
                    ChangeControlColor(txtQty);
                    break;
                case 'b':
                case 'B':
                    e.Handled = true;
                    txtInd.Text = "B".ToUpper();
                    txtSBuy.Text = "S";
                    ChangeControlColor(txtQty);
                    break;
                case (char)Keys.Return:
                case (char)Keys.Back:
                case (char)Keys.Space:
                case (char)Keys.Escape:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        private void txtAcct_Leave(object sender, EventArgs e)
        {
            if (txtType.Text == "SPR")
            { this.txtSAcct.Text = this.txtAcct.Text; }
            //ChangeControlColor(txtInd);

        }

        private void txtSMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                e.Handled = true;

            }
        }

        private void txtSMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtSMonth.Text.Length == 1)
            {


                viewMonths.RowFilter = "TP_MON = '" + txtSMonth.Text + "'";
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("Invalid Option month.", "Hedge Order");
                    return;

                }
                else
                {
                    txtSMonth.Text = txtSMonth.Text.ToUpper();
                    int iYear = System.DateTime.Today.Year;
                    DateTime dtHedgeDate = new DateTime(iYear, Convert.ToInt32(viewMonths[0]["Month_ID"].ToString()), Convert.ToInt32("16".ToString()));
                    DateTime time = DateTime.Now;              // Use current time
                    string format = "yy";    // Use this format

                    if (System.DateTime.Today > dtHedgeDate)
                    {
                        txtSYear.Text = time.AddYears(1).ToString(format);
                    }
                    else
                    {
                        txtSYear.Text = time.ToString(format);
                    }
                    //txtMonth.Text = txtSMonth.Text;
                    ChangeControlColor(txtSYear);
                }
            }
        }


        private void txtSYear_TextChanged(object sender, EventArgs e)
        {
            if (txtSYear.Text.Length == 2)
            {
                //txtYear.Text = txtSYear.Text;
                ChangeControlColor(txtComm);
            }
        }

        private void txtSYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void btnOpenAddOrder_Click(object sender, EventArgs e)
        {

            UpdateRegionGrid();
            RefreshPositions();
            //RefreshVCFOrderGrid();
            //RefreshECOrderGrid();

            //this.RecreateHandle();
            //this.Refresh();
            //txtC2Buy.Refresh();

            //GC.Collect();
            //this.AddOpenOrder();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Length == 2)
            {
                txtSYear.Text = txtYear.Text;
                if (txtType.Text == "SPR")
                {
                    ChangeControlColor(txtSMonth);
                }
                else
                {
                    ChangeControlColor(txtComm);
                }
            }

        }


        private void txtComm_TextChanged(object sender, EventArgs e)
        {
            if (txtComm.Text.Length == 2)
            {
                txtSComm.Text = txtComm.Text;
                if (this.txtType.Text == "EX")
                {
                    if (this.txtComm.Text != "22" && this.txtComm.Text != "28")
                    {
                        this.txtSComm.Enabled = false;
                    }
                    else
                    {
                        this.txtSComm.Enabled = true;
                    }
                }
                ChangeControlColor(txtPrice);
            }
        }



        private void txtSPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                    case (char)Keys.Decimal:
                    case '.':
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
                txtPrice.Text = txtSPrice.Text;

            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                    case (char)Keys.Decimal:
                    case '.':
                        break;
                    default:
                        e.Handled = true;
                        break;
                }


            }
        }

        private void txtSFilled_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                    case (char)Keys.Decimal:
                    case '.':
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
                txtSFilled.Text = txtSFilled.Text;
            }
        }

        private void txtComp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                        //case (char)Keys.OemPeriod:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void txtComp_TextChanged(object sender, EventArgs e)
        {
            if (txtComp.Text.Length == 2)
            {
                txtSComp.Text = txtComp.Text;
                if (GTC.Enabled == true)
                {
                    ChangeControlColorCbox(GTC);
                }
                else if (EO.Enabled == true)
                {
                    ChangeControlColorCbox(EO);
                }
                else
                {
                    ChangeControlColor(txtCardNumber);
                }
            }

        }

        private void btnCorn2Clone_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            try
            {
                // Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
                //dr = drCorn2;
                //Int32 OrderNumber = Convert.ToInt32(drCorn2.CurrentItem.Controls["btnCorn2Clone"].Tag.ToString());
                Int32 OrderNumber = Convert.ToInt32(drCorn2.CurrentItem.Controls["txtC2CGBOrd"].Text.ToString());
                string OrderType = drCorn2.CurrentItem.Controls["txtC2OrdType"].Text.ToString();
                if (OrderType == "SPR")
                {
                    ReviseOrderSpread(OrderNumber);
                }
                else
                {
                    ReviseOrder(OrderNumber);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }


        private void btnBean2Clone_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            try
            {
                // Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
                //dr = dtrBeans2;
                Int32 OrderNumber = Convert.ToInt32(dtrBeans2.CurrentItem.Controls["txtB2CGBOrd"].Text.ToString());
                //Int32 OrderNumber = Convert.ToInt32(dtrBeans2.CurrentItem.Controls["btnBean2Clone"].Tag.ToString());
                string OrderType = dtrBeans2.CurrentItem.Controls["txtB2OrdType"].Text.ToString();
                if (OrderType == "SPR")
                {
                    ReviseOrderSpread(OrderNumber);
                }
                else
                {
                    ReviseOrder(OrderNumber);
                }
                //dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

 

        private void btnWheat2Clone_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            try
            {
                // Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
                //dr = drWheat2;
                //Int32 OrderNumber = Convert.ToInt32(drWheat2.CurrentItem.Controls["btnWheat2Clone"].Tag.ToString());
                Int32 OrderNumber = Convert.ToInt32(drWheat2.CurrentItem.Controls["txtW2CGBOrd"].Text.ToString());
                string OrderType = drWheat2.CurrentItem.Controls["txtW2OrdType"].Text.ToString();
                if (OrderType == "SPR")
                {
                    ReviseOrderSpread(OrderNumber);
                }
                else
                {
                    ReviseOrder(OrderNumber);
                }
                //dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        


        private void AddCloneOrder(string OrderNumber)
        {
            frmCloneOrder frmAdd = new frmCloneOrder();
            frmAdd.frmCopyOrders = this;
            frmAdd.mOrderNumber = Convert.ToInt32(OrderNumber);
            try
            {
                frmAdd.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            finally
            {
                dtOrders.Clear();
                //dtOrders.GetChanges();
                dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                //dgvOrders.DataSource = null;
                dgvOrders.DataSource = dtOrders;
                //dgvOrders.AutoResizeRowHeadersWidth(true, false);
                dgvOrders.Refresh();
                this.Refresh();
            }
            frmAdd.Dispose();
            //frmAdd.frmCopyOrders.Dispose();
        }

        private void txtYear_Leave(object sender, EventArgs e)
        {
            if (txtType.Text == "SPR")
            {
                //ChangeControlColor(txtSMonth);
            }
            else
            {
                //ChangeControlColor(txtComm);
            }
            if (txtType.Text == "EX")
            { this.txtSYear.Text = this.txtYear.Text; }

        }

        private void txtSYear_Leave(object sender, EventArgs e)
        {
            if (txtType.Text == "SPR")
            {
                //ChangeControlColor(txtComm);
            }
            else
            {
                //ChangeControlColor(txtComm);
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (txtType.Text == "SPR")
            {
                if (txtPrice.Text != "")
                {
                    txtPremSide.Visible = true;
                    lblPremiumSide.Visible = true;

                }
                else
                {
                    txtPremSide.Visible = false;
                    lblPremiumSide.Visible = false;

                }
                txtSPrice.Text = txtPrice.Text;

            }
            if (txtType.Text == "EX")
            {
                txtSPrice.Text = txtPrice.Text;
            }
            //ChangeControlColor(txtFilled);
        }

        private void txtSPrice_Leave(object sender, EventArgs e)
        {
            if (txtType.Text == "SPR" && txtPrice.Text != "")
            {
                txtPremSide.Visible = true;
            }
            //ChangeControlColor(txtFilled);

            if (txtType.Text == "EX")
            { this.txtSPrice.Text = this.txtPrice.Text; }

        }

        private void txtFilled_Leave(object sender, EventArgs e)
        {
            //ChangeControlColor(txtComp);
            if (txtType.Text == "EX")
            { this.txtSFilled.Text = this.txtFilled.Text; }

            if (txtFilled.Text != "" && txtPrice.Text == "")
            {
                txtPrice.Text = txtFilled.Text;
            }

        }

        private void txtSFilled_Leave(object sender, EventArgs e)
        {
            //ChangeControlColor(txtComp);
            if (txtSFilled.Text != "" && txtSPrice.Text == "")
            {
                txtSPrice.Text = txtSFilled.Text;
            }
        }

        private void GTC_Enter(object sender, EventArgs e)
        {
            ChangeControlColorCboxFocus(GTC);
        }

        public class MyCB : System.Windows.Forms.CheckBox
        {
            protected override void OnEnter(EventArgs e)
            {
                base.OnEnter(e);
                base.OnMouseEnter(e);
            }

            protected override void OnLeave(EventArgs e)
            {
                base.OnLeave(e);
                base.OnMouseLeave(e);
            }
        }

        private void tmrRegionOrders_Tick(object sender, EventArgs e)
        {
            tmrRegionOrders.Stop();

            try
            {
                tmrRegionOrders.Interval = 600;
                UpdateRegionOrderGrid();


            }
            catch (Exception ex)
            {

                tmrRegionOrders.Stop();
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");

            }
            
        }

        private void UpdateRegionOrderGrid()
        {
            GetRegionOrderData();
            UpdateRegionGrid();
            //var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            //SynchronizationContext ctx = SynchronizationContext.Current;
            //Task ordersTask = Task.Factory
            //.StartNew(() => GetRegionOrderData(), TaskCreationOptions.PreferFairness)
            //.ContinueWith(_ => UpdateRegionGrid(), UIContext.Current);

        }
        private void GetRegionOrderData()
        {
            this.dtRegionOrders.Clear();
            this.dtRegionOrders.Dispose();
            GlobalStore.mdsRegionOrders.Dispose();
            //dtOrders.GetChanges();
            dtRegionOrders = GlobalStore.FillRegionOrdersDataSet().Tables[0];
            //dgvOrders.DataSource = null;
            dgvRegionOrders.DataSource = dtRegionOrders;
        }

        private void UpdateRegionGrid()
        {
            try
            {

                int col;

                col = 11;
                for (int row = 0; row < dgvRegionOrders.Rows.Count; row++)
                {
                    if (dgvRegionOrders[col, row].Value.ToString() == "MOC")
                    {
                        dgvRegionOrders.Rows[row].DefaultCellStyle.BackColor = Color.LightPink;
                    }

                    if (dgvRegionOrders[col, row].Value.ToString() == "ORD")
                    {
                        dgvRegionOrders.Rows[row].DefaultCellStyle.BackColor = Color.LightGreen;
                    }

                    if (dgvRegionOrders[col, row].Value.ToString() == "SPR")
                    {
                        dgvRegionOrders.Rows[row].DefaultCellStyle.BackColor = Color.LightBlue;
                    }

                    if (dgvRegionOrders[col, row].Value.ToString() == "MOO")
                    {
                        dgvRegionOrders.Rows[row].DefaultCellStyle.BackColor = Color.LightPink;
                    }

                    if (dgvRegionOrders[col, row].Value.ToString() == "CH")
                    {
                        dgvRegionOrders.Rows[row].DefaultCellStyle.BackColor = Color.Aqua;
                    }

                }
                col = 19;
                for (int row = 0; row < dgvRegionOrders.Rows.Count - 1; row++)
                {
                    System.Diagnostics.Debug.Print(dgvRegionOrders[col, row].Value.ToString());

                    if (dgvRegionOrders[col, row].Value.ToString() == "33")
                    {
                        dgvRegionOrders[col, row].Style.BackColor = Color.MediumOrchid;
                    }

                    if (dgvRegionOrders[col, row].Value.ToString() == "55")
                    {
                        dgvRegionOrders[col, row].Style.BackColor = Color.SeaGreen;
                    }

                    if (dgvRegionOrders[col, row].Value.ToString() == "19")
                    {
                        dgvRegionOrders[col, row].Style.BackColor = Color.Khaki;
                    }

                }

                tmrRegionOrders.Interval = 600;
                dgvRegionOrders.Refresh();

                tmrRegionOrders.Start();
                //dgvRegionOrders.Visible = true;

            }
            catch
            {
                tmrRegionOrders.Stop();
                MessageBox.Show("Error getting data from database.  Please contact system administration.", "Hedge Order");
                return;
            }
        }
        //public static void UpdateRegionDataset()
        //{
        //    frmOrders ord = new frmOrders();
        //    ord.dtRegionOrders.Clear();
        //    ord.dtRegionOrders.Dispose();
        //    GlobalStore.mdsRegionOrders.Dispose();
        //    //dtOrders.GetChanges();
        //    ord.dtRegionOrders = GlobalStore.FillRegionOrdersDataSet().Tables[0];
        //    //dgvOrders.DataSource = null;
        //    ord.dgvRegionOrders.DataSource = ord.dtRegionOrders;
        //    //dgvOrders.AutoResizeRowHeadersWidth(true, false);
        //    ord.dgvRegionOrders.Refresh();
        //    //this.Refresh();
        //}
        private void dgvRegionOrders_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 30000;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrECorders.Interval = 10000;

        }

        private void dgvRegionOrders_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 10000;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrECorders.Interval = 30000;
        }


        private void GetRiskPositionData()
        {
            dtCornRiskTrading.Clear();
            dtBeanRiskTrading.Clear();
            dtWheatRiskTrading.Clear();
            dtWhiteCornRiskTrading.Clear();
            dtMiloRiskTrading.Clear();
            dtHardRedWheatRiskTrading.Clear();

            dtCashCornRiskTrading.Clear();
            dtCashBeanRiskTrading.Clear();
            dtCashWheatRiskTrading.Clear();
            dtCashWhiteCornRiskTrading.Clear();
            dtCashMiloRiskTrading.Clear();
            dtCashHardRedWheatRiskTrading.Clear();

            GlobalStore.RiskPosition(22, 1, dtCornRiskTrading);
            GlobalStore.RiskPosition(24, 1, dtBeanRiskTrading);
            GlobalStore.RiskPosition(25, 1, dtWheatRiskTrading);
            GlobalStore.RiskPosition(31, 1, dtWhiteCornRiskTrading);
            GlobalStore.RiskPosition(28, 1, dtMiloRiskTrading);
            GlobalStore.RiskPosition(26, 1, dtHardRedWheatRiskTrading);

            
            GlobalStore.RiskPosition(22, 0, dtCashCornRiskTrading);
            GlobalStore.RiskPosition(24, 0, dtCashBeanRiskTrading);
            GlobalStore.RiskPosition(25, 0, dtCashWheatRiskTrading);
            GlobalStore.RiskPosition(31, 0, dtCashWhiteCornRiskTrading);
            GlobalStore.RiskPosition(28, 0, dtCashMiloRiskTrading);
            GlobalStore.RiskPosition(26, 0, dtCashHardRedWheatRiskTrading);

        }

        private void SetupRiskPositionUI()
        {
            int RiskPositionSetting = 0;
            int SetRiskPositionSetting = 0;


            Models.RiskPosition rp = new Models.RiskPosition();

            GlobalStore.RiskPositionSetting = 0;
            rp.SetupRiskPosition(lvBean, dtBeanRiskTrading, ref RiskPositionSetting);
            SetRiskPositionSetting = SetRiskPositionSetting + RiskPositionSetting;
            RiskPositionSetting = 0;

            rp.SetupRiskPosition(lvCorn, dtCornRiskTrading, ref RiskPositionSetting);
            SetRiskPositionSetting = SetRiskPositionSetting + RiskPositionSetting;
            RiskPositionSetting = 0;

            rp.SetupRiskPosition(lvWheat, dtWheatRiskTrading, ref RiskPositionSetting);
            SetRiskPositionSetting = SetRiskPositionSetting + RiskPositionSetting;
            RiskPositionSetting = 0;

            rp.SetupRiskPosition(lvWhiteCorn, dtWhiteCornRiskTrading, ref RiskPositionSetting);
            SetRiskPositionSetting = SetRiskPositionSetting + RiskPositionSetting;
            RiskPositionSetting = 0;

            rp.SetupRiskPosition(lvMilo, dtMiloRiskTrading, ref RiskPositionSetting);
            SetRiskPositionSetting = SetRiskPositionSetting + RiskPositionSetting;
            RiskPositionSetting = 0;

            rp.SetupRiskPosition(lvHardRedWheat, dtHardRedWheatRiskTrading, ref RiskPositionSetting);
            SetRiskPositionSetting = SetRiskPositionSetting + RiskPositionSetting;
            RiskPositionSetting = 0;


            if (SetRiskPositionSetting > 0)
            {
                GlobalStore.RiskPositionSetting = 1;
            }
            else
            {
                GlobalStore.RiskPositionSetting = 0;
            }


            rp.SetupRiskPositionCash(lvCashBeans, dtCashBeanRiskTrading);
            rp.SetupRiskPositionCash(lvCashCorn, dtCashCornRiskTrading);
            rp.SetupRiskPositionCash(lvCashWheat, dtCashWheatRiskTrading);
            rp.SetupRiskPositionCash(lvCashWhiteCorn, dtCashWhiteCornRiskTrading);
            rp.SetupRiskPositionCash(lvCashMilo, dtCashMiloRiskTrading);
            rp.SetupRiskPositionCash(lvCashHardRedWheat, dtCashHardRedWheatRiskTrading);
        }

        private void SetUpRiskPositions()
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();

            Task riskPositionDataTask = Task.Factory
            .StartNew(() => GetRiskPositionData(), TaskCreationOptions.AttachedToParent)
            .ContinueWith(_ => SetupRiskPositionUI(), uiContext);

        }

        private void GetDataForOrders()
        {
            dgvOrders.AutoGenerateColumns = false;
            dtOrders.Clear();
            dtOrders.Dispose();
            GlobalStore.mdsOrders.Dispose();
            dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
            dgvOrders.DataSource = dtOrders;
        }

        private void SetUpOrdersGrid()
        {
            int col = 17;
            for (int row = 0; row < dgvOrders.Rows.Count - 1; row++)
            {

                if (dgvOrders[col, row].Value.ToString() == "Rejected")
                {
                    dgvOrders[col, row].Style.BackColor = Color.DarkSalmon;
                    dgvOrders[col, row].Style.ForeColor = Color.White;
                    //dgvOrders[col, row].Style.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                }

                if (dgvOrders[col, row].Value.ToString() == "In Transit" || dgvOrders[col, row].Value.ToString() == "In Process")
                {
                    dgvOrders[col, row].Style.BackColor = Color.DarkSalmon;
                    dgvOrders[col, row].Style.ForeColor = Color.White;
                    //dgvOrders[col, row].Style.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                }

                if (dgvOrders[col, row].Value.ToString() == "After Market" || dgvOrders[col, row].Value.ToString() == "Mkt Close")
                {
                    dgvOrders[col, row].Style.ForeColor = Color.Red;
                    //dgvOrders[col, row].Style.Font = new Font(dgvOrders.Font, FontStyle.Bold);
                }

                if (dgvOrders[col, row].Value.ToString() == "Filled" || dgvOrders[col, row].Value.ToString() == "Partial Fill")
                {
                    dgvOrders[col, row].Style.ForeColor = Color.Blue;
                    //dgvOrders[col, row].Style.Font =  new Font(dgvOrders.Font, FontStyle.Bold);

                }

            }


            col = 12;
            int col2 = 36;

            for (int row = 0; row < dgvOrders.Rows.Count - 1; row++)
            {

                if (dgvOrders[col2, row].Value.ToString() != "")
                {

                    dgvOrders[col, row].Style.BackColor = Color.Orange;
                }

            }

            col = 27;
            for (int row = 0; row < dgvOrders.Rows.Count - 1; row++)
            {

                dgvOrders[col, row].Style.BackColor = Color.Red;
            }

            col = 14;
            for (int row = 0; row < dgvOrders.Rows.Count - 1; row++)
            {

                dgvOrders[col, row].Style.BackColor = Color.LightGreen;
            }

            col = 15;
            for (int row = 0; row < dgvOrders.Rows.Count - 1; row++)
            {

                dgvOrders[col, row].Style.BackColor = Color.LightGreen;
            }

            col = 9;
            for (int row = 0; row < dgvOrders.Rows.Count - 1; row++)
            {
                System.Diagnostics.Debug.Print(dgvOrders[col, row].Value.ToString());

                if (dgvOrders[col, row].Value.ToString() == "33")
                {
                    dgvOrders[col, row].Style.BackColor = Color.MediumOrchid;
                }

                if (dgvOrders[col, row].Value.ToString() == "55")
                {
                    dgvOrders[col, row].Style.BackColor = Color.SeaGreen;
                }

                if (dgvOrders[col, row].Value.ToString() == "19")
                {
                    dgvOrders[col, row].Style.BackColor = Color.Khaki;
                }

            }

            dgvOrders.Refresh();
        }


        public void RefreshOrderGrid()
        {
            GetDataForOrders();
            SetUpOrdersGrid();
            CheckOptions();
            //var uiContext = TaskScheduler.FromCurrentSynchronizationContext();

            //Task ordersTask = Task.Factory
            //.StartNew(() => GetDataForOrders(), TaskCreationOptions.LongRunning)
            //.ContinueWith(_ => SetUpOrdersGrid(), uiContext);

        }

        public void CheckOptions()
        {
            DataTable dtContractOptions = new DataTable();
            DataTable dtContractOptionsNotWorking = new DataTable();

            Options.FillContractOptionsDataSetForStatus(1, dtContractOptions);
            Options.FillContractOptionsDataSetForStatus(0, dtContractOptionsNotWorking);
            dtContractOptions.DefaultView.RowFilter = " Status = 'Pending' OR Status = 'Pending Cancelled' OR Status = 'Pending Sale'";
            dtContractOptions.AcceptChanges();
            if (dtContractOptions.Rows.Count > 0)
            {
                optionsRed = true;
            }
            else
            {
                optionsRed = false;
            }
            dtContractOptions.DefaultView.RowFilter = "";
            if (optionsRed == false)
            {
                dtContractOptions.DefaultView.RowFilter = " Status = 'Expired' AND FuturesPrice = 0";
                dtContractOptions.AcceptChanges();
                if (dtContractOptions.Rows.Count > 0)
                {
                    optionsRed = true;
                }
                else
                {
                    optionsRed = false;
                }
            }
            dtContractOptions.DefaultView.RowFilter = "";
            if (optionsRed == false)
            {
                dtContractOptions.DefaultView.RowFilter = " Status = 'Executed' AND OptionExpirationDate <= " + "'" + DateTime.Now + "'"; // 'Pending Sale'";
                dtContractOptions.AcceptChanges();
                if (dtContractOptions.Rows.Count > 0)
                {
                    optionsRed = true;
                }
                else
                {
                    optionsRed = false;
                }
            }
            if (optionsRed == true)
            {
                this.btnOptions.BackColor = Color.Red;
            }
            else
            {
                this.btnOptions.BackColor = SystemColors.Info;
            }

            dtContractOptions.Clear();
            dtContractOptionsNotWorking.Clear();
            //DataTable dtOptions =  
        }

       
        public void RefreshECOrderGrid()
        {
            tmrECorders.Stop();
            FilterECOrders();

            dgvFilled.AutoGenerateColumns = false;
            this.dtFilledOrders.Clear();
            this.dtFilledOrders.Dispose();
            GlobalStore.mdsFilledOrders.Dispose();
            dtFilledOrders = GlobalStore.FillFilledOrdersDataSet().Tables[0];
            this.dgvFilled.DataSource = dtFilledOrders;
            dgvFilled.Refresh();

            dgvRejected.AutoGenerateColumns = false;
            this.dtRejectedOrders.Clear();
            this.dtRejectedOrders.Dispose();
            GlobalStore.mdsRejectedOrders.Dispose();
            dtRejectedOrders = GlobalStore.FillRejectedOrdersDataSet().Tables[0];
            this.dgvRejected.DataSource = dtRejectedOrders;
            dgvRejected.Refresh();

            FilterBSOrders();

            dgvCancelled.AutoGenerateColumns = false;
            this.dtCancelledOrders.Clear();
            this.dtCancelledOrders.Dispose();
            GlobalStore.mdsCancelledOrders.Dispose();
            dtCancelledOrders = GlobalStore.FillCancelledOrdersDataSet().Tables[0];
            this.dgvCancelled.DataSource = dtCancelledOrders;
            dgvCancelled.Refresh();

            dgvSplit.AutoGenerateColumns = false;
            this.dtSplitFillOrders.Clear();
            this.dtSplitFillOrders.Dispose();
            GlobalStore.mdsSplitFillOrders.Clear();
            GlobalStore.mdsSplitFillOrders.Dispose();
            dtSplitFillOrders = GlobalStore.FillSplitFillOrdersDataSet().Tables[0];
            dgvSplit.AutoGenerateColumns = false;
            this.dgvSplit.DataSource = dtSplitFillOrders;
            dgvSplit.Refresh();

            dgvPartial.AutoGenerateColumns = false;
            this.dtPartialFillOrders.Clear();
            this.dtPartialFillOrders.Dispose();
            GlobalStore.mdsPartialFilledOrders.Clear();
            GlobalStore.mdsPartialFilledOrders.Dispose();
            dtPartialFillOrders = GlobalStore.FillPartialFilledOrdersDataSet().Tables[0];
            dgvPartial.AutoGenerateColumns = false;
            this.dgvPartial.DataSource = dtPartialFillOrders;

            int col = 20;

            for (int row = 0; row < dgvPartial.Rows.Count; row++)
            {

                if (dgvPartial[col, row].Value.ToString() != "False")
                {

                    dgvPartial.Rows[row].DefaultCellStyle.BackColor = Color.LightGreen;
                }

            }
            
            

            dgvPartial.Refresh();



            tbcOrdersDetails.Refresh();
            tmrECorders.Start();

        }

        public void RefreshVCFOrderGrid()
        {
            int col;
            this.tmrVCF.Stop();
            dgvRegionVCF.AutoGenerateColumns = false;
            this.dtRegionVCFOrders.Clear();
            this.dtRegionVCFOrders.Dispose();
            GlobalStore.mdtRegionOrdersVCF.Dispose();
            dtRegionVCFOrders = GlobalStore.FillRegionVCFOrdersDataTable();
            this.dgvRegionVCF.DataSource = dtRegionVCFOrders;
            col = 0;
            for (int row = 0; row < dgvRegionVCF.Rows.Count -1; row++)
            {
                if (dgvRegionVCF[col, row].Value.ToString() == "41")
                {
                    dgvRegionVCF.Rows[row].DefaultCellStyle.BackColor = Color.LightPink;
                }

                //if (dgvRegionVCF[col, row].Value.ToString() == "53")
                //{
                //    dgvRegionVCF.Rows[row].DefaultCellStyle.BackColor = Color.LightCyan;
                //}

                
            }

            dgvRegionVCF.Refresh();

            tbcOrdersDetails.Refresh();
            this.tmrVCF.Interval = 10000;
            this.tmrVCF.Start();
        }
        private void tmrOrders_Tick(object sender, EventArgs e)
        {

            try
            {
                tmrOrders.Interval = 10000; 
                RefreshOrderGrid(); 
                

            }
            catch (Exception ex)
            {

                tmrOrders.Stop();
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");

            }


        }
        private void GTC_Leave(object sender, EventArgs e)
        {
            //ChangeControlColorCbox(EO);

        }

        private void EO_Leave(object sender, EventArgs e)
        {
            //ChangeControlColor(txtCardNumber);
        }


        private void txtType_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtType);
            txtType.SelectAll();
        }

        private void dgvOrders_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 120000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void dgvOrders_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void cboCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mLoading != true)
            {
                RefreshDataForPosition();
            }
        }

        private void txtAcct_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtAcct);
            txtAcct.SelectAll();

        }

        private void txtInd_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtInd);
            txtInd.SelectAll();

        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtQty);
            txtQty.SelectAll();

        }

        private void txtMonth_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtMonth);
            txtMonth.SelectAll();

        }

        private void txtSMonth_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtSMonth);
            txtSMonth.SelectAll();

        }

        private void txtYear_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtYear);
            txtAcct.SelectAll();

        }

        private void txtSYear_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtSYear);
            txtSYear.SelectAll();

        }

        private void txtComm_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtComm);
            txtComm.SelectAll();

        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtPrice);
            txtPrice.SelectAll();

        }


        private void txtComp_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtComp);
            txtComp.SelectAll();

        }

        private void txtPremSide_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtPremSide);
            txtPremSide.SelectAll();
        }

        private void txtFilled_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtFilled);
            txtFilled.SelectAll();
        }

        private void txtSFilled_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtSFilled);
            txtSFilled.SelectAll();
            

        }


        private void txtSpreadCardNumber_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtSpreadCardNumber);
            txtSpreadCardNumber.SelectAll();

        }



        private void txtCardNumber_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtCardNumber);
            txtCardNumber.SelectAll();
        }



        private void txtVCAccount_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtVCAccount);
            txtVCAccount.SelectAll();

        }

        private void txtVCComp_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtVCComp);
            txtVCComp.SelectAll();
        }

        private void txtRequestID1_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtRequestID1);
            txtRequestID1.SelectAll();
        }

        private void txtRequestID2_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtRequestID2);
            txtRequestID2.SelectAll();
        }

        private void txtVCComments_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtVCComments);
            txtVCComments.SelectAll();

        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
                ClearSpreadFields();
                HideSpreadFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }
        public void ClearSpreadFields()
        {
            OrdersNew ord = new OrdersNew();
            OrdersUpdate ordUpdate = new OrdersUpdate();
            this.txtSYear.Clear();
            this.txtSMonth.Clear();
            this.txtSAcct.Clear();
            this.txtSBuy.Clear();
            this.txtSComm.Clear();
            this.txtSComp.Clear();
            this.txtSFilled.Clear();
            this.txtSpreadCardNumber.Clear();
            this.txtSPrice.Clear();
            this.txtSQty.Clear();
            this.txtSType.Clear();
            this.txtPremSide.Clear();
            //this.txtAcct.Clear();
            if (txtType.Text != "EX")
            {
                this.txtComp.Clear();
            }
            if (this.txtRequestID1.Text != "")
            {
                ordUpdate.UnSelectOrder(Convert.ToInt32(txtRequestID1.Text));
                this.txtRequestID1.Clear();
            }
            if (this.txtRequestID2.Text != "")
            {
                ordUpdate.UnSelectOrder(Convert.ToInt32(txtRequestID2.Text));
                this.txtRequestID2.Clear();
            }
            //RefreshECOrderGrid();
            //RefreshOrderGrid();
            //RefreshVCFOrderGrid();
            //RefreshPositions();
            //UpdateRegionGrid();
            ChangeControlColor(txtType);
        }
        public void HideSpreadFields()
        {
            this.txtSYear.Visible = false;
            this.txtSMonth.Visible = false;
            this.txtSAcct.Visible = false;
            this.txtSBuy.Visible = false;
            this.txtSComm.Visible = false;
            this.txtSComp.Visible = false;
            this.txtSFilled.Visible = false;
            this.txtSpreadCardNumber.Visible = false;
            this.txtSPrice.Visible = false;
            this.txtSQty.Visible = false;
            this.txtSType.Visible = false;
            this.txtPremSide.Visible = false;
            this.txtRequestID1.Visible = false;
            this.txtRequestID2.Visible = false;
            this.lblPremiumSide.Visible = false;
            this.txtCardNumber.Visible = true;
            this.txtComments.Visible = false;
            this.txtSComments.Visible = false;
            this.lblComments.Visible = false;
            this.lblRequestID.Visible = false;


        }
        public void ClearFields()
        {
            OrdersNew ord = new OrdersNew();
            OrdersUpdate ordUpdate = new OrdersUpdate();
            if (txtType.Text != "SPR")
            {
                this.txtAcct.Clear();
                this.txtCardNumber.Clear();
                this.txtComm.Clear();
                this.txtComp.Clear();
                this.txtFilled.Clear();
                this.txtInd.Clear();
                this.txtMonth.Clear();
                this.txtPrice.Clear();
                this.txtQty.Clear();
                this.txtType.Clear();
                this.txtYear.Clear();
                this.GTC.Checked = false;
                this.EO.Checked = false;
                this.txtVCAccount.Clear();
                this.txtVCComments.Clear();
                this.txtVCComp.Clear();
                this.txtSYear.Clear();
                this.txtSMonth.Clear();
                this.txtSAcct.Clear();
                this.txtSBuy.Clear();
                this.txtSComm.Clear();
                this.txtSComp.Clear();
                this.txtSFilled.Clear();
                this.txtSpreadCardNumber.Clear();
                this.txtSPrice.Clear();
                this.txtSQty.Clear();
                this.txtSType.Clear();
                this.txtPremSide.Clear();
                this.txtComments.Clear();
                this.txtSComments.Clear();
                if (this.txtRequestID1.Text != "")
                {
                    ordUpdate.UnSelectOrder(Convert.ToInt32(this.txtRequestID1.Text));
                }
                if (this.txtRequestID2.Text != "")
                {
                    ordUpdate.UnSelectOrder(Convert.ToInt32(this.txtRequestID2.Text));
                }

                ChangeControlColor(txtType);
                RefreshECOrderGrid();
                RefreshOrderGrid();
                RefreshVCFOrderGrid();
                RefreshPositions();
                UpdateRegionGrid();
                misAdding = false;
            }
            else
            {
                this.txtAcct.Clear();
                this.txtCardNumber.Clear();
                this.txtComm.Clear();
                this.txtComp.Clear();
                this.txtFilled.Clear();
                this.txtInd.Clear();
                this.txtMonth.Clear();
                this.txtPrice.Clear();
                this.txtQty.Clear();
                this.txtType.Clear();
                this.txtYear.Clear();
                this.GTC.Checked = false;
                this.EO.Checked = false;
                this.txtSYear.Clear();
                this.txtSMonth.Clear();
                this.txtSAcct.Clear();
                this.txtSBuy.Clear();
                this.txtSComm.Clear();
                this.txtSComp.Clear();
                this.txtSFilled.Clear();
                this.txtSpreadCardNumber.Clear();
                this.txtSPrice.Clear();
                this.txtSQty.Clear();
                this.txtSType.Clear();
                this.txtPremSide.Clear();
                this.txtComments.Clear();
                this.txtSComments.Clear();
                if (this.txtRequestID1.Text != "")
                {
                    ordUpdate.UnSelectOrder(Convert.ToInt32(txtRequestID1.Text));
                    this.txtRequestID1.Clear();
                }
                if (this.txtRequestID2.Text != "")
                {
                    ordUpdate.UnSelectOrder(Convert.ToInt32(txtRequestID2.Text));
                    this.txtRequestID2.Clear();
                }
                ChangeControlColor(txtType);
                misAdding = false;
                RefreshECOrderGrid();
                RefreshOrderGrid();
                RefreshVCFOrderGrid();
                RefreshPositions();
                UpdateRegionGrid();
            }
        }

        private void dgvOrders_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            if (isRowChanged == false)
            {
                mColumnIndex = dgvOrders.CurrentCell.ColumnIndex;
                mRowsIndex = dgvOrders.CurrentCell.RowIndex;
            }
            
            isRowChanged = true;


        }

        private void dgvRegionOrders_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 30000;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            //tmrRegionOrders.Interval = 30000;
            tmrECorders.Interval = 10000;
            isRowChanged = true;
            mColumnIndex = dgvRegionOrders.CurrentCell.ColumnIndex;
            mRowIndex = dgvRegionOrders.CurrentCell.RowIndex;

        }

        private void dgvRegionOrders_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;

        }

        private void dgvRegionOrders_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (isRowChanged)
            //{
            //    OrdersNew ord = new OrdersNew();
            //    dgvRegionOrders.EndEdit();
            //    string rIndex = dgvRegionOrders.Rows[e.RowIndex].Index.ToString();
            //    int riIndex = Convert.ToInt16(rIndex);
            //    string Type = "";
            //    string Acct = "";
            //    string Ind = "";
            //    string Qty = "";
            //    string sMonth = "";
            //    string sYear = "";
            //    string Comm = "";
            //    string Price = "";
            //    string Filled = "";
            //    string Comp = "";
            //    string PremSide = "";
            //    string S2Month = "";
            //    string S2Year = "";
            //    string OrderNumber = "";
            //    int FixEO = 0;
            //    int FixGTC = 0;
            //    int Can = 0;
            //    string CurrentUser = WindowsIdentity.GetCurrent().Name;
            //    string OrderSent = "";
            //    string ReturnMessage = "";
            //    string CardNumber = "";
            //    string VCAccount = "";
            //    string VCComments = "";
            //    string VCCustomer = "";

            //    string Status = "";
            //    string OrderDate = "";
            //    string Comments = "";
            //    string RequestID = "";
            //    Boolean Grid = true;
            //    string EO = "";
            //    string GTC = "";

            //    EO = dgvRegionOrders.Rows[riIndex].Cells["ReqEO"].Value.ToString();
            //    GTC = dgvRegionOrders.Rows[riIndex].Cells["ReqGTC"].Value.ToString();
            //    OrderNumber = dgvRegionOrders.Rows[riIndex].Cells["ReqOrdID"].Value.ToString();

            //    if (dgvRegionOrders.Rows[riIndex].Cells["ReqEO"].Value.ToString() == "True")
            //    {
            //        FixEO = 1;
            //    }
            //    if (dgvRegionOrders.Rows[riIndex].Cells["ReqGTC"].Value.ToString() == "True")
            //    {
            //        FixGTC = 1;
            //    }
            //    if (dgvRegionOrders.Rows[riIndex].Cells["CancReq"].Value.ToString() == "True")
            //    {
            //        Can = 1;
            //    }
            //    //FixEO = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkEO"].Value.ToString());
            //    //FixGTC = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkGTC"].Value.ToString());
            //    VCAccount = dgvRegionOrders.Rows[riIndex].Cells["VCAcct"].Value.ToString();
            //    VCComments = dgvRegionOrders.Rows[riIndex].Cells["VCComm"].Value.ToString();
            //    VCCustomer = dgvRegionOrders.Rows[riIndex].Cells["VCCompany"].Value.ToString();
            //    CardNumber = dgvRegionOrders.Rows[riIndex].Cells["CardNumber"].Value.ToString();
            //    //Status = dgvRegionOrders.Rows[riIndex].Cells["Status"].Value.ToString();
            //    OrderDate = dgvRegionOrders.Rows[riIndex].Cells["Date"].Value.ToString();
            //    Comments = dgvRegionOrders.Rows[riIndex].Cells["ReqComments"].Value.ToString();
            //    Type = dgvRegionOrders.Rows[riIndex].Cells["ReqType"].Value.ToString();
            //    Acct = dgvRegionOrders.Rows[riIndex].Cells["Acct"].Value.ToString();
            //    Ind = dgvRegionOrders.Rows[riIndex].Cells["Ind"].Value.ToString();
            //    Qty = dgvRegionOrders.Rows[riIndex].Cells["ReqQty"].Value.ToString();
            //    sMonth = dgvRegionOrders.Rows[riIndex].Cells["ReqMonth"].Value.ToString();
            //    sYear = dgvRegionOrders.Rows[riIndex].Cells["ReqYear"].Value.ToString();
            //    Comm = dgvRegionOrders.Rows[riIndex].Cells["ReqComm"].Value.ToString();
            //    Price = dgvRegionOrders.Rows[riIndex].Cells["ReqPrice"].Value.ToString();
            //    Comp = dgvRegionOrders.Rows[riIndex].Cells["TradeCo"].Value.ToString();
            //    RequestID = dgvRegionOrders.Rows[riIndex].Cells["Reg_ID"].Value.ToString();
            //    Boolean CheckValue = true;
            //    //Comp = dgvRegionSpreads.Rows[riIndex].Cells["Comp"].Value.ToString();


            //    if (ValidateRegionEntry(Filled, Acct, Ind, Qty, sYear, sMonth, Comm, Type, Comp, Price,
            //       Grid, EO, GTC) == true)
            //    {
            //        isRowChanged = false;
            //        isNotValidated = false;
            //        if (MessageBox.Show("Are you sure you want to change region order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //        {
            //            isRowChanged = false;
            //            isNotValidated = false;
            //            return;
            //        }
            //        else
            //        {

            //            ord.EditOrderInGrid(OrderNumber, Acct, Ind, Qty, sMonth, sYear, Comm, Price,
            //                  Type, Comp, FixEO, FixGTC, CardNumber, Status, Comments,
            //                  OrderDate, VCAccount, VCCustomer, VCComments, CurrentUser, ref OrderSent,
            //                  ref ReturnMessage, Can, RequestID);
            //            isRowChanged = false;
            //            isNotValidated = false;
            //            if (OrderSent != "")
            //            {
            //                ShowMessage(OrderSent, ReturnMessage);
            //            }
            //            RefreshVCFOrderGrid();
            //            RefreshECOrderGrid();
            //            UpdateRegionGrid();
            //            RefreshOrderGrid();
            //            RefreshPositions();
            //            if (dgvRegionOrders.RowCount > 1)
            //            {
            //                dgvRegionOrders.CurrentCell.Selected = false;
            //                dgvRegionOrders.Rows[riIndex - 1].Cells[mColumnIndex].Selected = true;
            //            } 

            //        }

            //    }
            //    else
            //    {
            //        if (CheckValue)
            //        {
            //            isRowChanged = false;
            //            isNotValidated = true;
            //            UpdateRegionGrid();
            //            tmrRegionOrders.Interval = 120000;
            //            
            //            if (dgvRegionOrders.RowCount > 1)
            //            {
            //                dgvRegionOrders.CurrentCell.Selected = false;
            //                dgvRegionOrders.Rows[riIndex - 1].Cells[mColumnIndex].Selected = true;
            //            } 

            //            //dgvRegionOrders.CurrentCell = dgvRegionOrders.SelectedCells[[0];
            //            isRowChanged = false;
            //            isNotValidated = false;
            //            CheckValue = false;
            //            tmrRegionOrders.Interval = 120000;
            //            


            //        }
            //        else
            //        {
            //            isRowChanged = false;
            //            isNotValidated = false;

            //        }
            //    }
            //}
        }


        private void dgvOrders_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (isNotValidated)
            //    e.Cancel = true;

        }

        private void drCorn2_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Stop();
            tmrPosition.Interval = 15000;
            tmrPosition.Start();

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void drCorn2_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Stop();
            tmrPosition.Interval = 15000;
            tmrPosition.Start();
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;

        }

        private void dtrBeans2_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

     
        private void drWheat2_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;

        }

        private void drWheat2_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Stop();
            tmrPosition.Interval = 15000;
            tmrPosition.Start();

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;

        }

  
        private void dtrBeans2_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Stop();
            tmrPosition.Interval = 15000;
            tmrPosition.Start();

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;

        }

 
        private void tmrPosition_Tick(object sender, EventArgs e)
        {
            try
            {
                RefreshPositions();
            }
            catch (Exception)
            {
                tmrPosition.Stop();
                MessageBox.Show("Error getting data from database.  Please contact system administration.", "Hedge Order");
                return;
            }

        }

        public void RefreshPositions()
        {
            tmrPosition.Stop();
            if (RefreshDataForPosition())
            {
                tmrPosition.Interval = 15000;
                tmrPosition.Start();
            }
            else
            {
                if (MessageBox.Show("Error getting data from database.  Try again?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    if (RefreshDataForPosition())
                    {
                        tmrPosition.Interval = 15000;
                        tmrPosition.Start();
                    }
                    else
                    {
                        MessageBox.Show("Error getting data from database.  Please Contact System Admin.", "Hedge Order", MessageBoxButtons.OK);

                    }
                }
            }

        }

        //private void drCorn2_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        //{

        //    if (e.DataRepeaterItem.Controls["corn2order"].Tag.ToString() == "0" || e.DataRepeaterItem.Controls["corn2order"].Tag.ToString() == "" ||
        //        e.DataRepeaterItem.Controls["txtC2OrderStatus"].Text.ToString() == "Rejected" ||
        //        e.DataRepeaterItem.Controls["txtC2OrderStatus"].Text.ToString() == "Cancelled")
        //    {
        //        e.DataRepeaterItem.Controls["btnCorn2Clone"].Enabled = false;
        //    }
        //    if ((e.DataRepeaterItem.Controls["corn2order"].Tag.ToString() != "0" && e.DataRepeaterItem.Controls["corn2order"].Tag.ToString() != "") &&
        //        (e.DataRepeaterItem.Controls["txtC2OrderStatus"].Text.ToString() != "Filled" &&
        //        e.DataRepeaterItem.Controls["txtC2OrderStatus"].Text.ToString() != "Rejected" &&
        //        e.DataRepeaterItem.Controls["txtC2OrderStatus"].Text.ToString() != "Cancelled"))
        //    {
        //        e.DataRepeaterItem.Controls["txtC2Price"].BackColor = Color.LightSkyBlue;

        //    }

        //    if (e.DataRepeaterItem.Controls["txtC2OrdType"].Text.ToString() == "CH")
        //    {
        //        e.DataRepeaterItem.Controls["txtC2OrdType"].BackColor = Color.Cornsilk;
        //        e.DataRepeaterItem.Controls["btnCorn2Edit"].Enabled = true;
        //        e.DataRepeaterItem.Controls["btnCorn2Priced"].Enabled = true;

        //    }
        //    else
        //    {
        //        e.DataRepeaterItem.Controls["btnCorn2Edit"].Enabled = false;
        //        e.DataRepeaterItem.Controls["btnCorn2Priced"].Enabled = false;
        //    }
        //}


        private void ChangeTabColor(DrawItemEventArgs e)
        {

            Brush BackBrush = new SolidBrush(Color.Turquoise);

            e.Graphics.FillRectangle(BackBrush, e.Bounds);

            BackBrush.Dispose();


        }


        private void tbRegion_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font f;
            //For background color
            Brush backBrush;
            //For forground color
            Brush foreBrush;

            //This construct will hell you to deside which tab page have current focus
            //to change the style.

            if (e.Index == 0)
            {
                //This line of code will help you to change the apperance like size,name,style.
                f = e.Font; //new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                //f = new Font(e.Font, FontStyle.Bold);
                if (dgvRegionOrders.RowCount > 0)
                {
                    backBrush = new System.Drawing.SolidBrush(Color.White);
                    foreBrush = Brushes.Red;

                }
                else
                {
                    backBrush = new System.Drawing.SolidBrush(Color.White);
                    foreBrush = Brushes.Black;
                }


            }
            else
            {
                //f = new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                //f = new Font(e.Font, FontStyle.Bold);
                f = e.Font;


                backBrush = new System.Drawing.SolidBrush(Color.White);
                foreBrush = Brushes.Black;


            }

            //To set the alignment of the caption.
            string tabName = this.tbRegion.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            //Thsi will help you to fill the interior portion of
            //selected tabpage.
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(tabName, f, foreBrush, r, sf);

            sf.Dispose();

        }

        public static void DrawTabText(TabControl tabControl, DrawItemEventArgs e, System.Drawing.Color foreColor, string caption, TabPage tbPage)
        {
            Color backColor = (Color)System.Drawing.SystemColors.Control;
            DrawTabText(tabControl, e, backColor, foreColor, caption, tbPage);
        }

        public static void DrawTabText(TabControl tabControl, DrawItemEventArgs e, System.Drawing.Color backColor, System.Drawing.Color foreColor, string caption, TabPage tbPage)
        {
            #region setup
            Font tabFont;
            Brush foreBrush = new SolidBrush(foreColor);
            Rectangle r = e.Bounds;
            Brush backBrush = new SolidBrush(backColor);
            string tabName = caption; // tabControl.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            #endregion

            #region drawing
            e.Graphics.FillRectangle(backBrush, r);


            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            if (e.Index == 2)
            {
                tabFont = new Font(e.Font, FontStyle.Italic);
                tabFont = new Font(tabFont, FontStyle.Bold);
            }
            else
            {
                tabFont = e.Font;
            }

            e.Graphics.DrawString(caption, tabFont, foreBrush, r, sf);
            #endregion

            #region cleanup
            sf.Dispose();
            if (e.Index == tabControl.SelectedIndex)
            {
                tabFont.Dispose();
                backBrush.Dispose();
            }
            else
            {
                backBrush.Dispose();
                foreBrush.Dispose();
            }
            #endregion

        }


        private Boolean ProcessSpreadLeg1(string Acct, string Type, string Ind, string sYear, string sMonth,
            string Comm, string Comp, string Qty, string ReqID, string Price, string GTC, string EO, string Comments, string PremSide)
        {
            this.txtAcct.Text = Acct;
            this.txtType.Text = Type;
            this.txtInd.Text = Ind;
            this.txtMonth.Text = sMonth;
            this.txtYear.Text = sYear;
            this.txtComm.Text = Comm;
            this.txtComp.Text = Comp;
            this.txtQty.Text = Qty;
            this.txtRequestID1.Text = ReqID;
            this.txtPrice.Text = Price;
            this.txtComments.Text = Comments;
            this.txtPremSide.Text = PremSide;
            ElectronicOrder(true, true, false, true, isRegionOrder, false);
            if (GTC == "True")
            {
                this.GTC.Checked = true;
                this.GTC.Refresh();
            }
            else
            {
                this.GTC.Checked = false;
                this.GTC.Refresh();

            }
            //if (EO == "True")
            //{
            this.EO.Checked = true;
            //}
            //else
            //{
            // this.EO.Checked = false;
            //}


            return true;
        }

        private Boolean ProcessSpreadLeg2(string Acct, string Type, string Ind, string sYear, string sMonth,
            string Comm, string Comp, string Qty, string ReqID, string Price, string GTC, string EO, string Comments)
        {
            this.txtSAcct.Text = Acct;
            this.txtSType.Text = Type;
            this.txtSBuy.Text = Ind;
            this.txtSComm.Text = Comm;
            this.txtSComp.Text = Comp;
            this.txtSQty.Text = Qty;
            this.txtSMonth.Text = sMonth;
            this.txtSYear.Text = sYear;
            this.txtRequestID2.Text = ReqID;
            this.txtSPrice.Text = Price;
            this.txtSComments.Text = Comments;

            if (this.txtSPrice.Text != "")
            {
                if (this.txtPrice.Text == "")
                {
                    this.txtPrice.Text = this.txtSPrice.Text;
                }
                else
                {
                    if (this.txtPrice.Text != this.txtSPrice.Text)
                    {
                        MessageBox.Show("These two spread legs have different prices.  Please confirm price and edit the side appropriately before processing this spread.", "Hedge Order");
                    }
                }
            }
            if (this.txtPrice.Text != "")
            {
                txtPremSide.Focus();
            }
            else
            {
                btnEC.Focus();
            }
            return true;
        }



        private void tmrECorders_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrECorders.Interval = 10000;
                RefreshECOrderGrid();
            }
            catch (Exception)
            {
                tmrECorders.Stop();
                MessageBox.Show("Error getting data from database.  Please contact system administration.", "Hedge Order");
                return;
            }
        }

        private void dgvECOrders_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
            //isRowChanged = true;
            mColumnIndex = dgvECOrders.CurrentCell.ColumnIndex;
            mRowIndex = dgvECOrders.CurrentCell.RowIndex;

        }

        private void dgvECOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (dgvECOrders.Columns[e.ColumnIndex].Name == "ECFill")
                {
                    string CurrentUser = WindowsIdentity.GetCurrent().Name;
                    //int OrderNumber = 0;
                    Int32 OrderID = Convert.ToInt32(dgvECOrders.Rows[e.RowIndex].Cells["OrderNo"].Value.ToString());
                    string OrderStatus = dgvECOrders.Rows[e.RowIndex].Cells["ECStatus"].Value.ToString();
                    string Split = dgvECOrders.Rows[e.RowIndex].Cells["ECSplit"].Value.ToString();
                    Int32 Leaves = Convert.ToInt32(dgvECOrders.Rows[e.RowIndex].Cells["ECRemQty"].Value.ToString());
                    Int32 CumQty = Convert.ToInt32(dgvECOrders.Rows[e.RowIndex].Cells["ECFilledQty"].Value.ToString());
                    string sFilledPrice = dgvECOrders.Rows[e.RowIndex].Cells["ECFilledPrice"].Value.ToString();
                    Int32 OrigQty = Convert.ToInt32(dgvECOrders.Rows[e.RowIndex].Cells["ECOrigQty"].Value.ToString());
                    Int32 Qty = Convert.ToInt32(dgvECOrders.Rows[e.RowIndex].Cells["ECQty"].Value.ToString());
                    string TradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["ECComp"].Value.ToString();
                    string ErrorMessage = "";
                    string OverrideMessage = "";
                    //string Override = "N";
                    string OrderSent = "";
                    string ReturnMessage = "";
                    Decimal FilledPrice = 0;
                    if (sFilledPrice != "")
                    {
                        FilledPrice = Convert.ToDecimal(sFilledPrice);
                    }
                    OrdersNew ord = new OrdersNew();
                    OrdersUpdate ordUpdate = new OrdersUpdate();
                    if (dgvECOrders.Rows[e.RowIndex].Cells["ECSplit"].Value.ToString() == "True")
                    {
                        frmECSplitFills frmSplit = new frmECSplitFills();
                        frmSplit.mOrderNumber = OrderID;
                        this.dtECSplitOrders.Clear();
                        dtECSplitOrders = GlobalStore.FillSplitFillOrdersDataSet().Tables[0];

                        frmSplit.mOrderNumber = OrderID;
                        frmSplit.mOrig_Qty = OrigQty;
                        frmSplit.mTradeCompany = TradeCompany;
                        frmSplit.mdtECSplitOrders.Clear();
                        frmSplit.mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(OrderID.ToString()).Tables[0];
                        frmSplit.dvECSplitOrders = frmSplit.mdtECSplitOrders.DefaultView;
                        if (frmSplit.LoadGrid())
                        {
                            frmSplit.ShowDialog(this);
                        }
                        else
                        {
                            MessageBox.Show("Error loading form.  Please contact system admin.", "Hedge Order");
                        }
                        this.dtECSplitOrders.Clear();
                        dtECSplitOrders = GlobalStore.FillSplitFillOrdersDataSet().Tables[0];
                        frmSplit.Dispose();
                        //frmSplit.frmCopyOrders.Dispose();

                    }
                    else if ((OrderStatus == "Partial Fill" && Leaves < Qty) || (OrderStatus == "Cancelled" &&
                        CumQty > 0 && OrigQty > CumQty && FilledPrice <= 0) || (OrderStatus == "Expired" &&
                        CumQty > 0 && OrigQty > CumQty && FilledPrice <= 0))
                    {
                        this.dtECPartialOrders.Clear();
                        //dtOrders.GetChanges();
                        dtECPartialOrders = GlobalStore.FillECPartialOrdersDataSet().Tables[0];

                        frmECPartialFills frmPartial = new frmECPartialFills();
                        frmPartial.mOrderNumber = OrderID;
                        frmPartial.mOrig_Qty = OrigQty;
                        frmPartial.mTradeCompany = TradeCompany;
                        frmPartial.mdtECSplitOrders = dtECPartialOrders;
                        frmPartial.dvECSplitOrders = dtECPartialOrders.DefaultView;
                        frmPartial.dvECSplitOrders.RowFilter = "ClientOrderID = " + OrderID.ToString();
                        if (frmPartial.LoadGrid())
                        {
                            frmPartial.ShowDialog(this);
                        }
                        else
                        {
                            MessageBox.Show("Error loading form.  Please contact system admin.", "Hedge Order");
                        }
                        this.dtECPartialOrders.Clear();
                        //dtOrders.GetChanges();
                        dtECPartialOrders = GlobalStore.FillECPartialOrdersDataSet().Tables[0];
                        frmPartial.Dispose();
                        //frmPartial.frmCopyOrders.Dispose();
                    }
                    else
                    {
                        if (sFilledPrice != "")
                        {
                            ordUpdate.FillOrder(CurrentUser, OrderID, sFilledPrice, ref ErrorMessage, ref OverrideMessage, "Y", ref OrderSent, ref ReturnMessage);
                            if (OrderSent != "")
                            {
                                ShowMessage(OrderSent, ReturnMessage);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Fill Price is zero for " + OrderID.ToString() + ".", "Hedge Order");
                        }


                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void dgvECOrders_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
        }

        private void dgvECOrders_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void dgvECOrders_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvECOrders_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void txtPremSide_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 's':
                case 'S':
                    e.Handled = true;
                    txtPremSide.Text = "S".ToUpper();
                    break;
                case 'e':
                case 'E':
                    e.Handled = true;
                    txtPremSide.Text = "E".ToUpper();
                    break;
                case 'b':
                case 'B':
                    e.Handled = true;
                    txtPremSide.Text = "B".ToUpper();
                    break;
                case (char)Keys.Return:
                case (char)Keys.Back:
                case (char)Keys.Space:
                case (char)Keys.Escape:
                    break;
                default:
                    e.Handled = true;
                    break;
            }

        }

        private void tbcOrdersDetails_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void tbcOrdersDetails_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font f;
            //For background color
            Brush backBrush;
            //For forground color
            Brush foreBrush;
            foreBrush = Brushes.Black;
            f = e.Font;
            backBrush = new System.Drawing.SolidBrush(Color.White);
            try
            {
                //This construct will hell you to deside which tab page have current focus
                //to change the style.

                if (e.Index == 2)
                {
                    //This line of code will help you to change the apperance like size,name,style.
                    f = e.Font; //new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    //f = new Font(e.Font, FontStyle.Bold);
                    if (dgvFilled.RowCount > 0)
                    {
                        backBrush = new System.Drawing.SolidBrush(Color.White);
                        foreBrush = Brushes.Red;

                    }
                    else
                    {
                        backBrush = new System.Drawing.SolidBrush(Color.White);
                        foreBrush = Brushes.Black;
                    }


                }
                else if (e.Index == 4)
                {
                    //This line of code will help you to change the apperance like size,name,style.
                    f = e.Font; //new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    //f = new Font(e.Font, FontStyle.Bold);
                    if (dgvPartial.RowCount > 0)
                    {
                        backBrush = new System.Drawing.SolidBrush(Color.White);
                        foreBrush = Brushes.Red;

                    }
                    else
                    {
                        backBrush = new System.Drawing.SolidBrush(Color.White);
                        foreBrush = Brushes.Black;
                    }

                }
                else if (e.Index == 3)
                {
                    //This line of code will help you to change the apperance like size,name,style.
                    f = e.Font; //new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    //f = new Font(e.Font, FontStyle.Bold);
                    int NotCompleted = 0;

                    int col = 15;
                    for (int row = 0; row < dgvSplit.Rows.Count - 1; row++)
                    {

                        if (dgvSplit[col, row].Value.ToString() == "False")
                        {
                            NotCompleted = 1;
                        }

                    }

                    if (NotCompleted == 1)
                    {
                        backBrush = new System.Drawing.SolidBrush(Color.White);
                        foreBrush = Brushes.Red;

                    }
                    else
                    {
                        backBrush = new System.Drawing.SolidBrush(Color.White);
                        foreBrush = Brushes.Black;
                    }

                }
                else if (e.Index == 7)
                {
                    //This line of code will help you to change the apperance like size,name,style.
                    f = e.Font; //new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    //f = new Font(e.Font, FontStyle.Bold);
                    if (this.dgvRegionVCF.RowCount > 1)
                    {
                        backBrush = new System.Drawing.SolidBrush(Color.White);
                        foreBrush = Brushes.Red;

                    }
                    else
                    {
                        backBrush = new System.Drawing.SolidBrush(Color.White);
                        foreBrush = Brushes.Black;
                    }

                }

                else
                {
                    //f = new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    //f = new Font(e.Font, FontStyle.Bold);
                    f = e.Font;
                    backBrush = new System.Drawing.SolidBrush(Color.White);
                    foreBrush = Brushes.Black;

                }

                //To set the alignment of the caption.
                string tabName = this.tbcOrdersDetails.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;

                //Thsi will help you to fill the interior portion of
                //selected tabpage.
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                Rectangle r = e.Bounds;
                r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
                e.Graphics.DrawString(tabName, f, foreBrush, r, sf);


                sf.Dispose();
            }
            catch (Exception ex)
            {
                //mHedge_Log.WriteEntry(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }


        }

        private void btnBean2Edit_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            try
            {
                Int32 OrderNumber = 0;
                // Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
                //dr = dtrBeans2;
                OrderNumber = Convert.ToInt32(dtrBeans2.CurrentItem.Controls["txtB2CGBOrd"].Text.ToString());
                //OrderNumber = Convert.ToInt32(dtrBeans2.CurrentItem.Controls["btnBean2Edit"].Tag.ToString());
                string OrderType = dtrBeans2.CurrentItem.Controls["txtB2OrdType"].Text.ToString();
                OrdersNew ord = new OrdersNew();
                string OrderSent = "";
                string ReturnMessage = "";
                string ErrorMessage = "";
                string ReturnOverrideMessage = "";
                string Override = "N";
                if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to Clone order " + OrderNumber.ToString() + " at the market?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }

                //int FixGTC = 0;
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                //if (this.GTC.Checked)
                //{
                //    FixGTC = 1;
                //}
                //else
                //{
                //    FixGTC = 0;
                //}
                OrdersNew Ord = new OrdersNew();

                Ord.CloneMarketOrder(CurrentUser, OrderNumber, 2, ref ErrorMessage, ref ReturnOverrideMessage, Override, ref OrderSent, ref ReturnMessage);

                if (ReturnOverrideMessage == "Y")
                {

                    if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to Clone order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        Ord.CloneMarketOrder(CurrentUser, OrderNumber, 2, ref ErrorMessage, ref ReturnOverrideMessage, "Y", ref OrderSent, ref ReturnMessage);

                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }

                    }
                }
                else
                {
                    if (ErrorMessage != "")
                    {
                        ShowMessage("4", ReturnMessage);
                    }
                    else
                    {
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                    }
                }
                //dr.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        

               

        private void PlaceCloneSingleOrder(Int32 AccountNumber, string QuantitySent, string BS,
            string HedgeMonth, string HedgeYear, string Price, Int32 CommodityID)
        {
            Int32 QuantityInt;
            Decimal Quantity;
    
            
            if (AccountNumber == 0)
            {
                return;
            }

            Quantity = Convert.ToDecimal(QuantitySent);
            QuantityInt = Convert.ToInt32(Quantity);
            if (QuantityInt == 0) { QuantityInt = 1; }
            QuantitySent = QuantityInt.ToString();
            if (QuantityInt < 0)
            {
                QuantitySent = (QuantityInt * -1).ToString();
            }


            OrdersNew ord = new OrdersNew();
            try
            {
                DataTable dtCommPrice = new DataTable();
                DataTable dtHedgePrice = new DataTable();

                ord.GetCMEPrice(CommodityID, HedgeMonth.Trim(), HedgeYear.Trim(), dtCommPrice);
                String DTNPrice = dtCommPrice.DefaultView[0]["Price"].ToString();

                PlaceOrder(AccountNumber, CommodityID.ToString(), HedgeYear, Price.ToString(), QuantitySent, HedgeMonth, BS, DTNPrice.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void PlaceOrder(int AccountNumber, string Commodity, string Year, string Price, string Quantity, string Month, string bs, string DTNPrice)
        {
            frmOrderPlace frmOrder = new frmOrderPlace();
            OrdersNew clsOrdersNew = new OrdersNew();

            try
            {
                frmOrder.mAcct = AccountNumber;
                frmOrder.mCommodity = Commodity;
                frmOrder.mMonth = Month;
                frmOrder.mYear = Year;
                frmOrder.mPrice = Price;
                frmOrder.mDTNPrice = DTNPrice;
                frmOrder.mQty = Quantity;
                frmOrder.mBS = bs;
                frmOrder.ShowDialog(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmOrder.Dispose();
            RefreshPositions();

        }


        private void ClonePriced(Int32 OrderNumber, string Type, int Acct)
        {

            try
            {

                OrdersNew ord = new OrdersNew();
                string OrderSent = "";
                string ReturnMessage = "";
                string ErrorMessage = "";
                string ReturnOverrideMessage = "";
                string Override = "N";
                if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to Clone Priced order " + OrderNumber.ToString() + "?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }

                //int FixGTC = 0;
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                //if (this.GTC.Checked)
                //{
                //    FixGTC = 1;
                //}
                //else
                //{
                //    FixGTC = 0;
                //}
                OrdersNew Ord = new OrdersNew();

                Ord.ClonePricedOrder(CurrentUser, OrderNumber, Acct, ref ErrorMessage, ref ReturnOverrideMessage, Override, ref OrderSent, ref ReturnMessage);

                if (ReturnOverrideMessage == "Y")
                {

                    if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to Clone Priced order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {

                        Ord.ClonePricedOrder(CurrentUser, OrderNumber, Acct, ref ErrorMessage, ref ReturnOverrideMessage, "Y", ref OrderSent, ref ReturnMessage);

                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }

                    }
                }
                else
                {
                    if (ErrorMessage != "")
                    {
                        ShowMessage("4", ReturnMessage);
                    }
                    else
                    {
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }


        private void btnWheat2Edit_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            try
            {
                Int32 OrderNumber = 0;
                // Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
                //dr = drWheat2;
                //OrderNumber = Convert.ToInt32(drWheat2.CurrentItem.Controls["btnWheat2Edit"].Tag.ToString());
                OrderNumber = Convert.ToInt32(drWheat2.CurrentItem.Controls["txtW2CGBOrd"].Text.ToString());
                string OrderType = drWheat2.CurrentItem.Controls["txtW2OrdType"].Text.ToString();
                OrdersNew ord = new OrdersNew();
                string OrderSent = "";
                string ReturnMessage = "";
                string ErrorMessage = "";
                string ReturnOverrideMessage = "";
                string Override = "N";
                if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to Clone order " + OrderNumber.ToString() + " at the market?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }

                //int FixGTC = 0;
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                //if (this.GTC.Checked)
                //{
                //    FixGTC = 1;
                //}
                //else
                //{
                //    FixGTC = 0;
                //}
                OrdersNew Ord = new OrdersNew();

                Ord.CloneMarketOrder(CurrentUser, OrderNumber, 2, ref ErrorMessage, ref ReturnOverrideMessage, Override, ref OrderSent, ref ReturnMessage);

                if (ReturnOverrideMessage == "Y")
                {

                    if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to Clone order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        Ord.CloneMarketOrder(CurrentUser, OrderNumber, 2, ref ErrorMessage, ref ReturnOverrideMessage, "Y", ref OrderSent, ref ReturnMessage);

                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }

                    }
                }
                else
                {
                    if (ErrorMessage != "")
                    {
                        ShowMessage("4", ReturnMessage);
                    }
                    else
                    {
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                    }
                }
                //dr.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void btnBeginNewDay_Click(object sender, EventArgs e)
        {
            OrdersUpdate Ord = new OrdersUpdate();
            Maintenance mt = new Maintenance();
            DateTime OrderDate = System.DateTime.Today;
            string ReturnMessage = "";
            DataTable dt = new DataTable();

            try
            {
                mt.ShowHedgersNotBalanced(dt);
                if (dt.Rows.Count > 0)
                {
                    if (MessageBox.Show("The following accounts have not completed balancing" + Environment.NewLine + dt.DefaultView[0]["StringAccounts"].ToString() + 
                         Environment.NewLine + "Continue Begin New Day?", "Begin New Day", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Begin New Day");
                return;
            }
            try
            {
                OrderDate = Convert.ToDateTime(dtpNewHedgeDate.Value.ToShortDateString());
            }
            catch (Exception)
            {
                MessageBox.Show("Order date entered is invalid.", "Begin New Day");
                return;
            }
            try
            {
                OrderDate = Convert.ToDateTime(dtpNewHedgeDate.Value.ToShortDateString());
                if (OrderDate.ToShortDateString() != dtpNewOrderDate.Value.ToShortDateString())
                {
                    if (MessageBox.Show("Order date does not match hedgedate. " +
                        "Are you sure you want to continue?", "Begin New Day", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Order date entered is invalid", "Begin New Day");
                return;
            }
            try
            {
                OrderDate = Convert.ToDateTime(dtpNewHedgeDate.Value.ToShortDateString());
                if (OrderDate < System.DateTime.Today)
                {
                    MessageBox.Show("Hedge date cannot be prior to current date.", "Begin New Day");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Order date entered is invalid", "Begin New Day");
            }

            try
            {
                if (MessageBox.Show("This will archive all Day Records prior to " + dtpNewHedgeDate.Value.ToShortDateString() + Environment.NewLine +
                    "Choose OK to save your changes or Cancel to undo your changes.", "Begin New Day", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    try
                    {
                        Ord.SetHedgeDate(OrderDate.ToShortDateString());
                        MessageBox.Show("Hedge date has been changed to: " + dtpNewOrderDate.Value.ToShortDateString(), "Begin New Day");
                        dtpCurrentHedgeDate.Value = OrderDate;
                        dtpCurrentHedgeDate2.Value = OrderDate;
                        Ord.BeginNewDay(ref ReturnMessage);
                        if (ReturnMessage == "")
                        {
                            MessageBox.Show("All Day Records have been archived prior to: " + dtpNewOrderDate.Value.ToShortDateString(), "Begin New Day");
                        }
                        else
                        {
                            MessageBox.Show(ReturnMessage.ToString(), "Hedgedesk");
                            return;
                        }
                        Ord.UpdateHedgerPosition(ref ReturnMessage);
                        if (ReturnMessage == "")
                        {
                            MessageBox.Show("Hedge Position has been updated.", "Hedge Position");
                        }
                        else
                        {
                            MessageBox.Show(ReturnMessage.ToString(), "Hedgedesk");
                            return;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Hedge Date Change");
                        return;

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Order date entered is invalid", "Hedge Date Change");
                return;
            }

        }
        private void EO_Enter(object sender, EventArgs e)
        {
            ChangeControlColorCboxFocus(EO);

        }
        private void btnSetOrderDate_Click(object sender, EventArgs e)
        {
            OrdersUpdate Ord = new OrdersUpdate();
            DateTime OrderDate = System.DateTime.Today;
            try
            {
                OrderDate = Convert.ToDateTime(dtpNewOrderDate.Value.ToShortDateString());
            }
            catch (Exception)
            {
                MessageBox.Show("Order date entered is invalid.", "Hedge Date Change");
            }
            try
            {
                OrderDate = Convert.ToDateTime(dtpNewOrderDate.Value.ToString());
                if (OrderDate < System.DateTime.Today)
                {
                    MessageBox.Show("Order date cannot be prior to current date.", "Hedge Date Change");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Order date entered is invalid", "Hedge Date Change");
            }
            try
            {
                if (MessageBox.Show("You are changing the order date to " + dtpNewOrderDate.Value.ToShortDateString() + Environment.NewLine +
                    "Choose OK to save your changes or Cancel to undo your changes.", "Hedge Date Change", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    try
                    {
                        Ord.SetHedgeOrderDate(OrderDate.ToShortDateString());
                        MessageBox.Show("Order date has been changed to: " + dtpNewOrderDate.Value.ToShortDateString(), "Hedge Date Change");
                        dtpCurrentOrderDate.Value = OrderDate;
                        dtpCurrentOrderDate2.Value = OrderDate;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Hedge Date Change");

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Order date entered is invalid", "Hedge Date Change");
            }
        }
        private void dgvFilled_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 30000;
        }

        private void dgvFilled_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;

        }

        private void dgvFilled_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tmrOrders.Interval = 10000;
                tmrRegionOrders.Interval = 600;
                tmrVCF.Interval = 120000;
                tmrPosition.Interval = 15000;

                tmrRegionOrders.Interval = 600;
                tmrECorders.Interval = 120000;
                if (dgvFilled.Columns[e.ColumnIndex].Name == "FillFill")
                {
                    string CurrentUser = WindowsIdentity.GetCurrent().Name;
                    int OrderNumber = 0;
                    Int32 OrderID = Convert.ToInt32(dgvFilled.Rows[e.RowIndex].Cells["FillOrderNo"].Value.ToString());
                    string OrderStatus = dgvFilled.Rows[e.RowIndex].Cells["FillStatus"].Value.ToString();
                    Int32 Leaves = Convert.ToInt32(dgvFilled.Rows[e.RowIndex].Cells["FillRem"].Value.ToString());
                    Int32 CumQty = Convert.ToInt32(dgvFilled.Rows[e.RowIndex].Cells["FillCumQty"].Value.ToString());
                    string sFilledPrice = dgvFilled.Rows[e.RowIndex].Cells["FillECPrice"].Value.ToString();
                    Int32 OrigQty = Convert.ToInt32(dgvFilled.Rows[e.RowIndex].Cells["FillOrigOrdQty"].Value.ToString());
                    Int32 Qty = Convert.ToInt32(dgvFilled.Rows[e.RowIndex].Cells["FillQty"].Value.ToString());
                    string ErrorMessage = "";
                    string OverrideMessage = "";
                    string Override = "N";
                    string OrderSent = "";
                    string ReturnMessage = "";
                    Decimal FilledPrice = 0;
                    if (sFilledPrice != "")
                    {
                        FilledPrice = Convert.ToDecimal(sFilledPrice);
                    }
                    else
                    {
                        FilledPrice = 0;
                    }
                    OrdersNew ord = new OrdersNew();
                    OrdersUpdate ordUpdate = new OrdersUpdate();
                    if (FilledPrice == 0)
                    {
                        MessageBox.Show("Fill Price is zero for " + OrderNumber.ToString(), "Hedge Order");
                    }
                    else
                    {
                        ordUpdate.FillOrder(CurrentUser, OrderID, sFilledPrice, ref ErrorMessage, ref OverrideMessage, Override, ref OrderSent, ref ReturnMessage);
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                        else
                        {
                            RefreshECOrderGrid();
                            if (dgvFilled.RowCount > 1)
                            {
                                dgvFilled.CurrentCell.Selected = false;
                                dgvFilled.Rows[mRowsIndex].Cells[mColumnIndex].Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void dgvSplit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int OrderID = Convert.ToInt32(dgvSplit.Rows[e.RowIndex].Cells["SplitOrderNo"].Value.ToString());
            int Completed = 1;
            int OrigQty = Convert.ToInt32(dgvSplit.Rows[e.RowIndex].Cells["SplitOrigOrdQty"].Value.ToString());
            string OrderType = dgvSplit.Rows[e.RowIndex].Cells["SplitType"].Value.ToString();
            if (dgvSplit.Rows[e.RowIndex].Cells["SplitDone"].Value.ToString() == "True")
            {
                Completed = 1;
            }
            else
            {
                Completed = 0;
            }

            if (dgvSplit.Columns[e.ColumnIndex].Name == "SplitLegs")
            {
                
                string TradeCompany = dgvSplit.Rows[e.RowIndex].Cells["SplitComp"].Value.ToString();

                this.dtSplitFillOrders.Clear();
                //dtOrders.GetChanges();
                DataSet SplitFills = new DataSet();
                GlobalStore.mdsECSplitOrders.Clear();
                GlobalStore.mdsECSplitOrders.Dispose();

                GlobalStore.FillECSplitOrdersDataSet(OrderID.ToString());
                SplitFills = GlobalStore.mdsECSplitOrders.Copy();
                frmECSplitFills_Individual frmSplit = new frmECSplitFills_Individual();
                frmSplit.mOrderNumber = OrderID;
                frmSplit.frmCopyOrders = this;
                frmSplit.mOrderType = OrderType;
                //this.dtECSplitOrders.Clear();
                //dtECSplitOrders = GlobalStore.FillSplitFillOrdersDataSet().Tables[0];

                frmSplit.mOrderNumber = OrderID;
                frmSplit.mOrig_Qty = OrigQty;
                frmSplit.mTradeCompany = TradeCompany;
                frmSplit.mdtECSplitOrders.Clear();
                frmSplit.mdtECSplitOrders = SplitFills.Tables[0];
                frmSplit.dvECSplitOrders = frmSplit.mdtECSplitOrders.DefaultView;
                frmSplit.Completed = Completed;
                if (frmSplit.LoadGrid())
                {
                    frmSplit.Show(this);
                    RefreshOrderGrid();
                    RefreshECOrderGrid();
                }
                else
                {
                    MessageBox.Show("Error loading form.  Please contact system admin.", "Hedge Order");
                }
                
                
            }
            else if (dgvSplit.Columns[e.ColumnIndex].Name == "SplitFill")
            {
                DataTable ContractOrders = new DataTable();
                if (dgvSplit.Rows[e.RowIndex].Cells["SplitDone"].Value.ToString() == "True")
                {
                    MessageBox.Show("This Split has already been processed", "Hedge Order");
                    return;
                } 
                
                OrdersUpdate ordUpdate = new OrdersUpdate();
                CRMProcessing crm = new CRMProcessing();
                String ReturnMessage = "";
                if (OrderType == "SPR")
                {

                    ordUpdate.ProcessSplitFillSpread(OrderID, ref ReturnMessage);

                }
                else
                {
                    try
                    {
                        ordUpdate.ProcessSplitFill(OrderID, ref ReturnMessage, ContractOrders);
                        if (ContractOrders.Rows.Count > 0)
                        {
                            crm.ProcessCRMSplitFill(ContractOrders);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.Message);
                    }
                    //crm.ProcessCRMSplitFill();
                }

                RefreshOrderGrid();
                RefreshECOrderGrid();
            }

            else if (dgvSplit.Columns[e.ColumnIndex].Name == "SplitView")
            {
                frmECSplitFillView frmSplit = new frmECSplitFillView();
                frmSplit.mOrderNumber = OrderID;
                frmSplit.mOrderType = OrderType;
                frmSplit.Completed = Completed;
 
                frmSplit.mdtECSplitOrders.Clear();
                
                if (frmSplit.LoadGrid())
                {
                    frmSplit.Show(this);
                    RefreshOrderGrid();
                    RefreshECOrderGrid();
                }
                else
                {
                    MessageBox.Show("Error loading form.  Please contact system admin.", "Hedge Order");
                }
            }
        }

        private void dgvSplit_MouseEnter(object sender, EventArgs e)
        {
            
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 300000;

        }

        private void dgvSplit_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;

        }

        private void corn2Order_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            try
            {
                Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
                dr = drCorn2;
                Int32 OrderNumber = Convert.ToInt32(dr.CurrentItem.Controls["txtC2CGBOrd"].Text.ToString());
                string OrderType = dr.CurrentItem.Controls["txtC2OrdType"].Text.ToString();
                if (OrderType == "SPR")
                {
                    ViewOrderSpread(OrderNumber);
                }
                else
                {
                    ViewOrder(OrderNumber);
                }
                //dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }


        
        private void bean2Order_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            try
            {
                // Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
                //dr = dtrBeans2;
                Int32 OrderNumber = Convert.ToInt32(dtrBeans2.CurrentItem.Controls["txtB2CGBOrd"].Text.ToString());
                //Int32 OrderNumber = Convert.ToInt32(dtrBeans2.CurrentItem.Controls["btnBean2Clone"].Tag.ToString());
                string OrderType = dtrBeans2.CurrentItem.Controls["txtB2OrdType"].Text.ToString();
                if (OrderType == "SPR")
                {
                    ViewOrderSpread(OrderNumber);
                }
                else
                {
                    ViewOrder(OrderNumber);
                }
                //dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        

        
        private void wheat2Order_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            try
            {
                // Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
                //dr = drWheat3;
                Int32 OrderNumber = Convert.ToInt32(drWheat2.CurrentItem.Controls["txtW2CGBOrd"].Text.ToString());
                //Int32 OrderNumber = Convert.ToInt32(drWheat2.CurrentItem.Controls["btnWheat2Clone"].Tag.ToString());
                string OrderType = drWheat2.CurrentItem.Controls["txtW2OrdType"].Text.ToString();
                if (OrderType == "SPR")
                {
                    ViewOrderSpread(OrderNumber);
                }
                else
                {
                    ViewOrder(OrderNumber);
                }
                //dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtAcct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtInd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtSMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtSYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtComm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtFilled_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtSFilled_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtComp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtSpreadCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtPremSide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtVCAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtVCComp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtVCComments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void dgvCGBVCF_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 120000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
            isRowChanged = true;
            mColumnIndex = dgvECOrders.CurrentCell.ColumnIndex;
            mRowIndex = dgvECOrders.CurrentCell.RowIndex;
        }


        private void dgvCGBVCF_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

            //if (isRowChanged || GlobalStore.getIsRowChanged())
            //{
            //    OrdersNew ord = new OrdersNew();
            //    dgvCGBVCF.EndEdit();
            //    string rIndex = dgvCGBVCF.Rows[e.RowIndex].Index.ToString();
            //    int riIndex = Convert.ToInt16(rIndex);
            //    string Type = "";
            //    string Acct = "";
            //    string Ind = "";
            //    string Qty = "";
            //    string sMonth = "";
            //    string sYear = "";
            //    string Comm = "";
            //    string Price = "";
            //    string Filled = "";
            //    string Comp = "";
            //    string PremSide = "";
            //    string S2Month = "";
            //    string S2Year = "";
            //    string OrderNumber = "";
            //    int FixEO = 0;
            //    int FixGTC = 0;
            //    int Can = 0;
            //    string VCAccount = "";
            //    string VCComments = "";
            //    string VCCustomer = "";
            //    string CurrentUser = WindowsIdentity.GetCurrent().Name;
            //    string OrderSent = "";
            //    string ReturnMessage = "";
            //    string CardNumber = "";
            //    string Status = "";
            //    string OrderDate = "";
            //    string Comments = "";
            //    string TradeCompany = "";

            //    Boolean Grid = true;
            //    OrderNumber = dgvCGBVCF.Rows[riIndex].Cells["CGBOrderNo"].Value.ToString();
            //    VCAccount = dgvCGBVCF.Rows[riIndex].Cells["CGBVCAcct"].Value.ToString();
            //    VCComments = dgvCGBVCF.Rows[riIndex].Cells["CGBVCComments"].Value.ToString();
            //    VCCustomer = dgvCGBVCF.Rows[riIndex].Cells["CGBVCTradeComp"].Value.ToString();
            //    CardNumber = dgvCGBVCF.Rows[riIndex].Cells["CGBCardNumber"].Value.ToString();
            //    Comments = dgvCGBVCF.Rows[riIndex].Cells["CGBComments"].Value.ToString();
            //    Type = dgvCGBVCF.Rows[riIndex].Cells["CGBType"].Value.ToString();
            //    Acct = dgvCGBVCF.Rows[riIndex].Cells["CGBAcct"].Value.ToString();
            //    Ind = dgvCGBVCF.Rows[riIndex].Cells["CGBInd"].Value.ToString();
            //    Qty = dgvCGBVCF.Rows[riIndex].Cells["CGBQty"].Value.ToString();
            //    sMonth = dgvCGBVCF.Rows[riIndex].Cells["CGBMonth"].Value.ToString();
            //    sYear = dgvCGBVCF.Rows[riIndex].Cells["CGBYear"].Value.ToString();
            //    Comm = dgvCGBVCF.Rows[riIndex].Cells["CGBComm"].Value.ToString();
            //    Filled = dgvCGBVCF.Rows[riIndex].Cells["CGBFilled"].Value.ToString();
            //    TradeCompany = dgvCGBVCF.Rows[riIndex].Cells["TradeCompany"].Value.ToString();
            //    Boolean CheckValue = true;

            //    if (ValidateVCFEntry(Filled, Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany) == true)
            //    {
            //        if (MessageBox.Show("Are you sure you want to change order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //        {
            //            isRowChanged = false;
            //            GlobalStore.setIsRowChanged(false);
            //            RefreshVCFOrderGrid();
            //            tmrVCF.Interval = 120000;
            //            if (dgvCGBVCF.RowCount > 1)
            //            {
            //                dgvCGBVCF.CurrentCell.Selected = false;
            //                dgvCGBVCF.Rows[riIndex - 1].Cells[mColumnIndex].Selected = true;
            //            } 
            //            isNotValidated = false;
            //            return;
            //        }
            //        else
            //        {
            //            ord.EditCGBVCFOrderInGrid(Acct, Ind, Qty, sMonth, sYear, Comm,
            //                  Filled, Type, CardNumber, Comments,
            //                  OrderDate, VCAccount, VCCustomer, VCComments, CurrentUser,
            //                  OrderNumber, TradeCompany);
            //            isRowChanged = false;
            //            GlobalStore.setIsRowChanged(false);
            //            isNotValidated = false;
            //            if (OrderSent != "")
            //            {
            //                ShowMessage(OrderSent, ReturnMessage);
            //            }
            //            RefreshVCFOrderGrid();
            //            if (dgvCGBVCF.RowCount > 1)
            //            {
            //                dgvCGBVCF.CurrentCell.Selected = false;
            //                dgvCGBVCF.Rows[riIndex].Cells[mColumnIndex].Selected = true;
            //            }
            //        }

            //    }
            //    else
            //    {
            //        if (CheckValue)
            //        {
            //            isRowChanged = false;
            //            isNotValidated = true;
            //            GlobalStore.setIsRowChanged(false);
            //            RefreshVCFOrderGrid();
            //            tmrVCF.Interval = 120000;
            //            if (dgvCGBVCF.RowCount > 1)
            //            {
            //                dgvCGBVCF.CurrentCell.Selected = false;
            //                dgvCGBVCF.Rows[riIndex].Cells[mColumnIndex].Selected = true;
            //            }
            //            //dgvOrders.CurrentCell = dgvOrders.SelectedCells[0];
            //            isRowChanged = true;
            //            CheckValue = false;

            //        }
            //    }
            //}

        }

        private void dgvCGBVCF_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvRegionVCF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tmrOrders.Interval = 10000;
                tmrRegionOrders.Interval = 600;
                tmrVCF.Interval = 30000;
                tmrPosition.Interval = 15000;

                tmrRegionOrders.Interval = 600;
                tmrECorders.Interval = 30000;
                OrdersNew ord = new OrdersNew();
                OrdersUpdate ordUpdate = new OrdersUpdate();
                int RowIndex = 0;
                int RegID = 0;
                string VCAcct = "";
                string Acct = "";
                string VCTradeCompany = "";
                string Ind = "";
                string Qty = "";
                string sYear = "";
                string sMonth = "";
                string Comm = "";
                string Type = "";
                string Price = "";
                //string GTC = "0";
                //string EO = "0";
                string Comments = "";
                //string PremSide = "";
                //string s2Month = "";
                //string s2year = "";
                string VCComments = "";
                string CardNumber = "";
                string TradeCompany = "";
                string OrderNumber = "";
                string OrderSent = "";
                string ReturnMessage = "";
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                string OrderDate = "";
                string Filled = "";


                if (dgvRegionVCF.Columns[e.ColumnIndex].Name == "VCFRsn" ||
                    dgvRegionVCF.Columns[e.ColumnIndex].Name == "VCFFT" || dgvRegionVCF.Columns[e.ColumnIndex].Name == "VCFDN" ||
                    dgvRegionVCF.Columns[e.ColumnIndex].Name == "VCFmiz" || dgvRegionVCF.Columns[e.ColumnIndex].Name == "RegComplete")
                {
                    Acct = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFAcct"].Value.ToString();
                    Ind = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFInd"].Value.ToString();
                    Qty = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFQty"].Value.ToString();
                    sYear = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFYear"].Value.ToString();
                    sMonth = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFMonth"].Value.ToString();
                    Comm = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFComm"].Value.ToString();
                    Type = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFType"].Value.ToString();
                    Price = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFPrice"].Value.ToString();
                    VCAcct = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFVCAcct"].Value.ToString();
                    VCComments = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFVCComm"].Value.ToString();
                    VCTradeCompany = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFTradeComp"].Value.ToString();
                    Comments = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFComments"].Value.ToString();
                    CardNumber = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFCardNumber"].Value.ToString();
                    RowIndex = e.RowIndex;
                    if (dgvRegionVCF.Rows[e.RowIndex].Cells["VCFReqID"].Value.ToString() != "")
                    {
                        RegID = Convert.ToInt32(dgvRegionVCF.Rows[e.RowIndex].Cells["VCFReqID"].Value.ToString());
                    }
                    TradeCompany = dgvRegionVCF.Rows[e.RowIndex].Cells["RegTradeComp"].Value.ToString();
                    OrderNumber = dgvRegionVCF.Rows[e.RowIndex].Cells["OrderNumber"].Value.ToString();
                    OrderDate = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFDate"].Value.ToString();
                    Filled = dgvRegionVCF.Rows[e.RowIndex].Cells["VCFFilled"].Value.ToString();
                    if (Acct == "" && Ind == "" && Qty == "" && sYear == "" && sMonth == "" && Comm == "")
                    {
                        return;//RegType = dgvRegionOrders.Rows[e.RowIndex].Cells["ReqType"].Value.ToString();
                    }
                    if (OrderNumber != "" && TradeCompany == "")
                    {
                        MessageBox.Show("Please enter a Trade Company in the trade company field.", "Validate Order");
                        return;
                    }
                    if ((OrderNumber == "") && (CardNumber.ToString() == "" || CardNumber.ToString() == " "))
                    {
                        MessageBox.Show("Please enter a card number to complete this transaction.", "Validate Order");
                        return;
                    }
                    isRegionOrder = true;
                }
                if (dgvRegionVCF.Columns[e.ColumnIndex].Name == "VCFRsn")
                {
                    ordUpdate.SelectOrder(RegID);
                    if (ValidateVCFEntry(Filled, Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany))
                    {
                        if (OrderNumber == "")
                        {
                            AddRegionVCFOrder(RegID, 55, CardNumber);
                        }
                        else
                        {
                            ord.EditCGBVCFOrderInGrid(Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                              Filled, Type, CardNumber, Comments,
                              OrderDate, VCAcct, VCTradeCompany, VCComments, CurrentUser,
                              OrderNumber, "55");
                            isRowChanged = false;
                            isNotValidated = false;
                            if (OrderSent != "")
                            {
                                ShowMessage(OrderSent, ReturnMessage);
                            }
                            RefreshVCFOrderGrid();
                            if (dgvRegionVCF.RowCount > 1)
                            {
                                dgvRegionVCF.CurrentCell.Selected = false;
                                dgvRegionVCF.Rows[e.RowIndex].Cells[16].Selected = true;
                            }

                        }
                    }
                    else
                    {
                        ordUpdate.UnSelectOrder(RegID);
                    }
                }
                if (dgvRegionVCF.Columns[e.ColumnIndex].Name == "VCFDN")
                {
                    ordUpdate.SelectOrder(RegID);
                    if (ValidateVCFEntry(Filled, Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany))
                    {
                        if (OrderNumber == "")
                        {
                            AddRegionVCFOrder(RegID, 25, CardNumber);
                        }
                        else
                        {
                            ord.EditCGBVCFOrderInGrid(Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                              Filled, Type, CardNumber, Comments,
                              OrderDate, VCAcct, VCTradeCompany, VCComments, CurrentUser,
                              OrderNumber, "25");
                            isRowChanged = false;
                            isNotValidated = false;
                            if (OrderSent != "")
                            {
                                ShowMessage(OrderSent, ReturnMessage);
                            }
                            RefreshVCFOrderGrid();
                            if (dgvRegionVCF.RowCount > 1)
                            {
                                dgvRegionVCF.CurrentCell.Selected = false;
                                dgvRegionVCF.Rows[e.RowIndex].Cells[16].Selected = true;
                            }
                        }
                    }
                    else
                    {
                        ordUpdate.UnSelectOrder(RegID);
                    }
                }

                if (dgvRegionVCF.Columns[e.ColumnIndex].Name == "VCFFT")
                {
                    ordUpdate.SelectOrder(RegID);
                    if (ValidateVCFEntry(Filled, Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany))
                    {
                        if (OrderNumber == "")
                        {
                            AddRegionVCFOrder(RegID, 33, CardNumber);
                        }
                        else
                        {
                            ord.EditCGBVCFOrderInGrid(Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                              Filled, Type, CardNumber, Comments,
                              OrderDate, VCAcct, VCTradeCompany, VCComments, CurrentUser,
                              OrderNumber, "33");
                            isRowChanged = false;
                            isNotValidated = false;
                            if (OrderSent != "")
                            {
                                ShowMessage(OrderSent, ReturnMessage);
                            }
                            RefreshVCFOrderGrid();
                            if (dgvRegionVCF.RowCount > 1)
                            {
                                dgvRegionVCF.CurrentCell.Selected = false;
                                dgvRegionVCF.Rows[e.RowIndex].Cells[16].Selected = true;
                            }
                        }
                    }
                    else
                    {
                        ordUpdate.UnSelectOrder(RegID);
                    }
                }

                if (dgvRegionVCF.Columns[e.ColumnIndex].Name == "VCFmiz")
                {
                    ordUpdate.SelectOrder(RegID);
                    if (ValidateVCFEntry(Filled, Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany))
                    {
                        if (OrderNumber == "")
                        {
                            AddRegionVCFOrder(RegID, 19, CardNumber);
                        }
                        else
                        {
                            ord.EditCGBVCFOrderInGrid(Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                              Filled, Type, CardNumber, Comments,
                              OrderDate, VCAcct, VCTradeCompany, VCComments, CurrentUser,
                              OrderNumber, "19");
                            isRowChanged = false;
                            isNotValidated = false;
                            if (OrderSent != "")
                            {
                                ShowMessage(OrderSent, ReturnMessage);
                            }
                            RefreshVCFOrderGrid();
                            if (dgvRegionVCF.RowCount > 1)
                            {
                                dgvRegionVCF.CurrentCell.Selected = false;
                                dgvRegionVCF.Rows[e.RowIndex].Cells[16].Selected = true;
                            }
                        }
                    }
                    else
                    {
                        ordUpdate.UnSelectOrder(RegID);
                    }

                }
                if (dgvRegionVCF.Columns[e.ColumnIndex].Name == "RegComplete")
                {
                    if (TradeCompany.ToString() == "")
                    {
                        MessageBox.Show("Please enter a trade company to complete this transaction.", "Validate Order");
                        return;
                    }
                    ordUpdate.SelectOrder(RegID);
                    if (ValidateVCFEntry(Filled, Acct, Ind, Qty, sYear, sMonth, Comm, Type, TradeCompany.ToString()))
                    {
                        if (OrderNumber == "")
                        {
                            AddRegionVCFOrder(RegID, Convert.ToInt32(TradeCompany.ToString()), CardNumber);
                        }
                        else
                        {
                            ord.EditCGBVCFOrderInGrid(Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                              Filled, Type, CardNumber, Comments,
                              OrderDate, VCAcct, VCTradeCompany, VCComments, CurrentUser,
                              OrderNumber, TradeCompany);
                            isRowChanged = false;
                            isNotValidated = false;
                            if (OrderSent != "")
                            {
                                ShowMessage(OrderSent, ReturnMessage);
                            }
                            RefreshVCFOrderGrid();
                            if (dgvRegionVCF.RowCount > 1)
                            {
                                dgvRegionVCF.CurrentCell.Selected = false;
                                dgvRegionVCF.Rows[e.RowIndex].Cells[16].Selected = true;
                            }
                        }
                    }
                    else
                    {
                        ordUpdate.UnSelectOrder(RegID);
                    }
                }
                isRegionOrder = false;
                tmrOrders.Interval = 10000;
                tmrRegionOrders.Interval = 600;
                tmrVCF.Interval = 10000;
                tmrPosition.Interval = 15000;

                tmrRegionOrders.Interval = 600;
                tmrECorders.Interval = 10000;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void dgvRegionVCF_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 30000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            isRowChanged = true;
            mColumnIndex = dgvECOrders.CurrentCell.ColumnIndex;
            mRowIndex = dgvECOrders.CurrentCell.RowIndex;
        }

        private void dgvRegionVCF_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (isRowChanged)
            //{
            //    OrdersNew ord = new OrdersNew();
            //    dgvRegionVCF.EndEdit();
            //    string rIndex = dgvRegionVCF.Rows[e.RowIndex].Index.ToString();
            //    int riIndex = Convert.ToInt16(rIndex);
            //    string Type = "";
            //    string Acct = "";
            //    string Ind = "";
            //    string Qty = "";
            //    string sMonth = "";
            //    string sYear = "";
            //    string Comm = "";
            //    string Price = "";
            //    string Filled = "";
            //    string Comp = "";
            //    string PremSide = "";
            //    string S2Month = "";
            //    string S2Year = "";
            //    string OrderNumber = "";
            //    int FixEO = 0;
            //    int FixGTC = 0;
            //    int Can = 0;
            //    string VCAccount = "";
            //    string VCComments = "";
            //    string VCCustomer = "";
            //    string CurrentUser = WindowsIdentity.GetCurrent().Name;
            //    string OrderSent = "";
            //    string ReturnMessage = "";
            //    string CardNumber = "";
            //    string Status = "";
            //    string OrderDate = "";
            //    string Comments = "";
            //    string RequestID = "";
            //    string TradeCompany = "";
            //    Boolean Grid = true;

            //    Acct = dgvRegionVCF.Rows[riIndex].Cells["VCFAcct"].Value.ToString();
            //    VCComments = dgvRegionVCF.Rows[riIndex].Cells["VCFVCComm"].Value.ToString();
            //    VCCustomer = dgvRegionVCF.Rows[riIndex].Cells["VCFTradeComp"].Value.ToString();
            //    CardNumber = dgvRegionVCF.Rows[riIndex].Cells["VCFCardNumber"].Value.ToString();
            //    OrderDate = dgvRegionVCF.Rows[riIndex].Cells["VCFDate"].Value.ToString();
            //    Comments = dgvRegionVCF.Rows[riIndex].Cells["VCFComments"].Value.ToString();
            //    Type = dgvRegionVCF.Rows[riIndex].Cells["VCFType"].Value.ToString();
            //    VCAccount = dgvRegionVCF.Rows[riIndex].Cells["VCFVCAcct"].Value.ToString();
            //    Ind = dgvRegionVCF.Rows[riIndex].Cells["VCFInd"].Value.ToString();
            //    Qty = dgvRegionVCF.Rows[riIndex].Cells["VCFQty"].Value.ToString();
            //    sMonth = dgvRegionVCF.Rows[riIndex].Cells["VCFMonth"].Value.ToString();
            //    sYear = dgvRegionVCF.Rows[riIndex].Cells["VCFYear"].Value.ToString();
            //    Comm = dgvRegionVCF.Rows[riIndex].Cells["VCFComm"].Value.ToString();
            //    Price = dgvRegionVCF.Rows[riIndex].Cells["VCFPrice"].Value.ToString();
            //    RequestID = dgvRegionVCF.Rows[riIndex].Cells["VCFReqID"].Value.ToString();
            //    TradeCompany = dgvRegionVCF.Rows[riIndex].Cells["RegTradeComp"].Value.ToString();
            //    Boolean CheckValue = true;


            //    isRowChanged = false;
            //    isNotValidated = false;
            //    if (MessageBox.Show("Are you sure you want to change VCF order " + RequestID.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //    {
            //        isRowChanged = false;
            //        GlobalStore.setIsRowChanged(false);
            //        RefreshVCFOrderGrid();
            //        tmrVCF.Interval = 120000;
            //        if (dgvRegionVCF.RowCount > 1)
            //        {
            //            dgvRegionVCF.CurrentCell.Selected = false;
            //            dgvRegionVCF.Rows[riIndex].Cells[mColumnIndex].Selected = true;
            //        }

            //        isNotValidated = false;
            //        return;
            //    }
            //    else
            //    {

            //        ord.EditVCFOrderInGrid(Acct, Ind, Qty, sMonth, sYear, Comm, Price,
            //              Type, CardNumber, Comments, OrderDate, VCAccount, VCCustomer, VCComments,
            //              CurrentUser, RequestID, TradeCompany.ToString());
            //        isRowChanged = false;
            //        isNotValidated = false;
            //        if (OrderSent != "")
            //        {
            //            ShowMessage(OrderSent, ReturnMessage);
            //        }
            //        else
            //        {
            //            RefreshVCFOrderGrid();
            //            RefreshECOrderGrid();
            //            RefreshOrderGrid();
            //            RefreshPositions();
            //            if (dgvRegionVCF.RowCount > 1)
            //            {
            //                dgvRegionVCF.CurrentCell.Selected = false;
            //                dgvRegionVCF.Rows[riIndex].Cells[mColumnIndex].Selected = true;
            //            }

            //        }
            //    }
            //}

        }

        private void dgvRegionVCF_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;

        }

        private void dgvRegionVCF_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 90000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 90000;

        }

        private void dgvRegionVCF_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void dgvRegionVCF_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 120000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;

        }

        private void FilterECOrders()
        {
            dgvECOrders.AutoGenerateColumns = false;
            dtECOrders.Clear();
            dtECOrders = GlobalStore.FillECOrdersDataTable().Tables[0];
            DataView dvECOrders = new DataView();
            dvECOrders = dtECOrders.DefaultView;
            string ECFilter = "";
            if (cboComp.SelectedIndex != -1)
            {
                ECFilter = "TP_COMM = " + cboComp.SelectedValue;
            }
            if (cboAcct.SelectedIndex != -1)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND [A/C] = " + cboAcct.SelectedValue;
                }
                else
                {
                    ECFilter = ECFilter + "[A/C] = " + cboAcct.SelectedValue;
                }
            }
            if (cboMon.SelectedIndex != -1)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND TP_MON = '" + cboMon.SelectedValue + "'";
                }
                else
                {
                    ECFilter = ECFilter + "TP_MON = '" + cboMon.SelectedValue + "'";
                }
            }
            if (txtYearText.Text != "")
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND TP_YEAR = '" + txtYearText.Text + "'";
                }
                else
                {
                    ECFilter = ECFilter + "TP_YEAR = '" + txtYearText.Text + "'";
                }
            }
            if (txtCardNo.Text != "")
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND CardNumber = '" + txtCardNo.Text + "'";
                }
                else
                {
                    ECFilter = ECFilter + "CardNumber = '" + txtCardNo.Text + "'";
                }
            }
            if (txtOrderFrom.Text != "")
            {
                if (txtOrderTo.Text != "")
                {
                    if (ECFilter != "")
                    {
                        ECFilter = ECFilter + " AND TP_ORD_NUMB >= " + txtOrderFrom.Text;
                    }
                    else
                    {
                        ECFilter = ECFilter + "TP_ORD_NUMB >= " + txtOrderFrom.Text;
                    }
                }
                else
                {
                    if (ECFilter != "")
                    {
                        ECFilter = ECFilter + " AND TP_ORD_NUMB = " + txtOrderFrom.Text;
                    }
                    else
                    {
                        ECFilter = ECFilter + "TP_ORD_NUMB = " + txtOrderFrom.Text;
                    }
                }
            }
            if (txtOrderTo.Text != "")
            {
                if (txtOrderFrom.Text != "")
                {
                    if (ECFilter != "")
                    {
                        ECFilter = ECFilter + " AND TP_ORD_NUMB <= " + txtOrderTo.Text;
                    }
                    else
                    {
                        ECFilter = ECFilter + "TP_ORD_NUMB <= " + txtOrderTo.Text;
                    }
                }
                else
                {
                    if (ECFilter != "")
                    {
                        ECFilter = ECFilter + " AND TP_ORD_NUMB = " + txtOrderTo.Text;
                    }
                    else
                    {
                        ECFilter = ECFilter + "TP_ORD_NUMB = " + txtOrderTo.Text;
                    }
                }
            }
            if (rbFilled.Checked)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND OrigOrderQty = CumQty AND (TP_FILLED_PRICE <= 0 OR TP_Filled_PRICE > 0) " +
                        "AND OrderStatus = '" + "Filled" + "'";
                }
                else
                {
                    ECFilter = ECFilter + "OrigOrderQty = CumQty AND (TP_FILLED_PRICE <= 0 OR TP_Filled_PRICE > 0) " +
                        "AND OrderStatus = '" + "Filled" + "'";
                }
            }
            if (rbGTC.Checked)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND GTC = 1 ";
                }
                else
                {
                    ECFilter = ECFilter + " GTC = 1 ";
                }
            }
            if (rbWorking.Checked)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND OrigOrderQty <> CumQty AND " +
                        "OrderStatus IN ('" + "New" + "', 'Partial Fill', '" + "Replaced" + "')";
                }
                else
                {
                    ECFilter = ECFilter + "OrigOrderQty <> CumQty AND " +
                        "OrderStatus IN ('" + "New" + "', 'Partial Fill', '" + "Replaced" + "')";
                }
            }
            if (rbCorrected.Checked)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND IsCorrected = TRUE ";
                }
                else
                {
                    ECFilter = ECFilter + " IsCorrected = TRUE ";
                }
            }
            if (rbCancelled.Checked)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND FixOrderCanceled = TRUE OR " +
                        "OrderStatus IN ('" + "Cancelled" + "', 'Rejected')";
                }
                else
                {
                    ECFilter = ECFilter + "FixOrderCanceled = TRUE OR " +
                        "OrderStatus IN ('" + "Cancelled" + "', 'Rejected')";
                }
            }
            if (rbSplit.Checked)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND IsSplitFill = TRUE ";
                }
                else
                {
                    ECFilter = ECFilter + " IsSplitFill = TRUE ";
                }
            }
            if (rbPartial.Checked)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND (OrderStatus = 'Partial Fill' AND LeavesQty < TP_AMT) OR " +
                        "(OrderStatus = 'Cancelled' AND CumQty > 0 AND OrigOrderQty > CumQty AND TP_Filled_Price <=0) OR " +
                        "(OrderStatus = 'Expired' AND CumQty > 0 AND OrigorderQty > CumQty AND TP_Filled_Price <= 0)";
                }
                else
                {
                    ECFilter = ECFilter + "(OrderStatus = 'Partial Fill' AND LeavesQty < TP_AMT) OR " +
                        "(OrderStatus = 'Cancelled' AND CumQty > 0 AND OrigOrderQty > CumQty AND TP_Filled_Price <=0) OR " +
                        "(OrderStatus = 'Expired' AND CumQty > 0 AND OrigorderQty > CumQty AND TP_Filled_Price <= 0)";
                }
            }
            dvECOrders.RowFilter = ECFilter;
            dgvECOrders.DataSource = dvECOrders;
            dgvECOrders.Refresh();
        }

        private void SearchForOrders()
        {
            tmrOrders.Interval = 120000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            dgvOrders.AutoGenerateColumns = false;
            dtOrders.Clear();
            dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];

            dvECOrders = dtOrders.DefaultView;
            string ECFilter = "";
            if (cboFindComm.SelectedIndex != -1)
            {
                ECFilter = "Comm = " + cboFindComm.SelectedValue;
            }
            if (cboFindAcct.SelectedIndex != -1)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND [A/C] = " + cboFindAcct.SelectedValue;
                }
                else
                {
                    ECFilter = ECFilter + "[A/C] = " + cboFindAcct.SelectedValue;
                }
            }
            if (cboFindMon.SelectedIndex != -1)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND Month = '" + cboFindMon.SelectedValue + "'";
                }
                else
                {
                    ECFilter = ECFilter + "Month = '" + cboFindMon.SelectedValue + "'";
                }
            }
            if (txtFindYearText.Text != "")
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND Year = '" + txtFindYearText.Text + "'";
                }
                else
                {
                    ECFilter = ECFilter + "Year = '" + txtFindYearText.Text + "'";
                }
            }
            if (txtFindCardNumber.Text != "")
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND [Card #] = '" + txtFindCardNumber.Text + "'";
                }
                else
                {
                    ECFilter = ECFilter + "[Card #] = '" + txtFindCardNumber.Text + "'";
                }
            }
            if (txtFindOrderFrom.Text != "")
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND [Order No.] >= " + txtFindOrderFrom.Text;
                }
                else
                {
                    ECFilter = ECFilter + "[Order No.] >= " + txtFindOrderFrom.Text;
                }
            }
            if (txtOrderTo.Text != "")
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND [Order No.] <= " + txtFindOrderTo.Text;
                }
                else
                {
                    ECFilter = ECFilter + "[Order No.] <= " + txtFindOrderTo.Text;
                }
            }

            if (txtOrderNumber.Text != "")
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND [Order No.] = " + txtOrderNumber.Text;
                }
                else
                {
                    ECFilter = ECFilter + "[Order No.] = " + txtOrderNumber.Text;
                }
            }

            dvECOrders.RowFilter = ECFilter;
            dgvOrders.DataSource = dvECOrders;
            dgvOrders.Refresh();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

            try
            {
                FilterECOrders();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
            }

        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                try
                {
                    FilterECOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void rbFilled_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFilled.Checked)
            {
                try
                {
                    FilterECOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void rbWorking_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWorking.Checked)
            {
                try
                {
                    FilterECOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void rbCorrected_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCorrected.Checked)
            {
                try
                {
                    FilterECOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void rbCancelled_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCancelled.Checked)
            {
                try
                {
                    FilterECOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void rbSplit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSplit.Checked)
            {
                try
                {
                    FilterECOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void rbPartial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPartial.Checked)
            {
                try
                {
                    FilterECOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void cboCommodities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void FilterBSOrders()
        {
            dtBuyOrders.Clear();
            dtBuyOrders.Dispose();
            GlobalStore.mdsBuyOrders.Dispose();
            dtBuyOrders = GlobalStore.FillBuyOrdersDataSet().Tables[0];
            DataView dvBuyOrders = new DataView();


            dtSellOrders.Clear();
            dtSellOrders.Dispose();
            GlobalStore.mdsSellOrders.Dispose();
            dtSellOrders = GlobalStore.FillSellOrdersDataSet().Tables[0];
            DataView dvSellOrders = new DataView();

            string ECFilter = "";
            if (cboCommodities.SelectedIndex != -1)
            {
                ECFilter = "COMM = '" + cboCommodities.SelectedValue.ToString() + "'";
            }
            if (cboAccount.SelectedIndex != -1)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND [A/C] = '" + cboAccount.SelectedValue.ToString() + "'";
                }
                else
                {
                    ECFilter = ECFilter + "[A/C] = '" + cboAccount.SelectedValue.ToString() + "'";
                }
            }
            if (cboMonths.SelectedIndex != -1)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND TP_MON = '" + cboMonths.SelectedValue + "'";
                }
                else
                {
                    ECFilter = ECFilter + "TP_MON = '" + cboMonths.SelectedValue + "'";
                }
            }
            if (cboOrderType.SelectedIndex != -1)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND TYPE = '" + cboOrderType.SelectedValue + "'";
                }
                else
                {
                    ECFilter = ECFilter + "TYPE = '" + cboOrderType.SelectedValue + "'";
                }
            }
            if (cboFilterVC.SelectedIndex != -1)
            {
                switch (cboFilterVC.SelectedIndex)
                {

                    case 1:
                        if (ECFilter != "")
                        {
                            ECFilter = ECFilter + " AND TYPE = 'VCF'";
                        }
                        else
                        {
                            ECFilter = ECFilter + "TYPE = 'VCF'";
                        }
                        break;
                    case 2:
                        if (ECFilter != "")
                        {
                            ECFilter = ECFilter + " AND TYPE <> 'VCF'";
                        }
                        else
                        {
                            ECFilter = ECFilter + "TYPE <> 'VCF'";
                        }
                        break;
                    default:
                        break;
                }

            }
            if (this.txtYR.Text != "")
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND TP_YEAR = '" + txtYR.Text + "'";
                }
                else
                {
                    ECFilter = ECFilter + "TP_YEAR = '" + txtYR.Text + "'";
                }
            }
            if (this.cboTradingCompanies.SelectedIndex != -1)
            {
                if (ECFilter != "")
                {
                    ECFilter = ECFilter + " AND COMP = '" + cboTradingCompanies.SelectedValue + "'";
                }
                else
                {
                    ECFilter = ECFilter + "COMP = '" + cboTradingCompanies.SelectedValue + "'";
                }
            }
            //dtBuyOrders = GlobalStore.FillBuyOrdersDataSet().Tables[0];
            //dtSellOrders = GlobalStore.FillSellOrdersDataSet().Tables[0];
            BuyTotal = dtBuyOrders.Compute("Sum(Qty)", ECFilter).ToString();
            SellTotal = dtSellOrders.Compute("Sum(Qty)", ECFilter).ToString();
            dvBuyOrders = dtBuyOrders.DefaultView;
            dvSellOrders = dtSellOrders.DefaultView;
            dvBuyOrders.RowFilter = ECFilter;
            dvSellOrders.RowFilter = ECFilter;
            this.txtSellTotal.Text = SellTotal.ToString();
            this.txtBuyTotal.Text = BuyTotal.ToString();

            if (BuyTotal == "")
            {
                BuyTotal = "0";
            }
            if (SellTotal == "")
            {
                SellTotal = "0";
            }
            if (BuyTotal == "0")
            {
                this.txtNetPosition.Text = "N/A".ToString();
            }
            else
            {
                NetPosition = (Convert.ToDecimal(BuyTotal) - Convert.ToDecimal(SellTotal)).ToString();
                this.txtNetPosition.Text = NetPosition.ToString();
            }
            dgvBuy.DataSource = dvBuyOrders;
            dgvSell.DataSource = dvSellOrders;
            txtNetPosition.Refresh();
            tpBuySellOrders.Refresh();
        }

        private void txtYR_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading)
            { FilterBSOrders(); }
        }

        private void cboMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void cboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void cboFilterVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }

        }

        private void cboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void cboTradingCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }

        }

        private void tpBuySellOrders_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
        }

        private void tpBuySellOrders_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void txtMonth_Leave(object sender, EventArgs e)
        {
            if (txtType.Text == "EX")
            { this.txtSMonth.Text = this.txtMonth.Text; }

        }

        private void btnFindClear_Click(object sender, EventArgs e)
        {
            dgvOrders.AutoGenerateColumns = false;
            cboFindAcct.SelectedIndex = -1;
            cboFindComm.SelectedIndex = -1;
            cboFindMon.SelectedIndex = -1;
            txtFindCardNumber.Text = "";
            txtFindOrderFrom.Text = "";
            txtFindOrderTo.Text = "";
            txtOrderNumber.Text = "";

            dtOrders.Clear();
            dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
            DataView dvECOrders = new DataView();
            dvECOrders = dtOrders.DefaultView;
            dvECOrders.RowFilter = "";
            dgvOrders.DataSource = dtOrders;
            RefreshOrderGrid();
            HideSpreadFields();
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 120000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;

            SearchForOrders();
        }

        private void dtrBeans2_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            if (e.DataRepeaterItem.Controls["txtB2OrderID"].Text.ToString() == "0" || e.DataRepeaterItem.Controls["txtB2OrderID"].Text.ToString() == "" ||
                e.DataRepeaterItem.Controls["txtB2OrderStatus"].Text.ToString() == "Rejected" ||
                e.DataRepeaterItem.Controls["txtB2OrderStatus"].Text.ToString() == "Cancelled")
            {
                e.DataRepeaterItem.Controls["btnBean2Clone"].Enabled = false;

            }
            else
            {
                e.DataRepeaterItem.Controls["btnBean2Clone"].Enabled = true;

            }
            if ((e.DataRepeaterItem.Controls["txtB2OrderID"].Text.ToString() != "0" && e.DataRepeaterItem.Controls["txtB2OrderID"].Text.ToString() != "") &&
                (e.DataRepeaterItem.Controls["txtB2OrderStatus"].Text.ToString() != "Filled" &&
                e.DataRepeaterItem.Controls["txtB2OrderStatus"].Text.ToString() != "Rejected" &&
                e.DataRepeaterItem.Controls["txtB2OrderStatus"].Text.ToString() != "Cancelled"))
            {
                e.DataRepeaterItem.Controls["txtB2Price"].BackColor = Color.LightSkyBlue;

            }
            else
            {
                e.DataRepeaterItem.Controls["txtB2Price"].BackColor = Color.WhiteSmoke;
            }
            if (e.DataRepeaterItem.Controls["txtB2OrdType"].Text.ToString() == "CH")
            {
                e.DataRepeaterItem.Controls["txtB2OrdType"].BackColor = Color.Cornsilk;
                e.DataRepeaterItem.Controls["btnBean2Edit"].Enabled = true;
                e.DataRepeaterItem.Controls["btnBean2Priced"].Enabled = true;

            }
            else
            {
                e.DataRepeaterItem.Controls["txtB2OrdType"].BackColor = Color.WhiteSmoke;
                e.DataRepeaterItem.Controls["btnBean2Edit"].Enabled = false;
                e.DataRepeaterItem.Controls["btnBean2Priced"].Enabled = false;
            }

        }

        private void drWheat2_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            if (e.DataRepeaterItem.Controls["txtW2OrderID"].Text.ToString() == "0" || e.DataRepeaterItem.Controls["txtW2OrderID"].Text.ToString() == "" ||
                e.DataRepeaterItem.Controls["txtW2OrderStatus"].Text.ToString() == "Rejected" ||
                e.DataRepeaterItem.Controls["txtW2OrderStatus"].Text.ToString() == "Cancelled")
            {
                e.DataRepeaterItem.Controls["btnWheat2Clone"].Enabled = false;

            }
            else
            {
                e.DataRepeaterItem.Controls["btnWheat2Clone"].Enabled = true;

            }
            if ((e.DataRepeaterItem.Controls["txtW2OrderID"].Text.ToString() != "0" && e.DataRepeaterItem.Controls["txtW2OrderID"].Text.ToString() != "") &&
                (e.DataRepeaterItem.Controls["txtW2OrderStatus"].Text.ToString() != "Filled" &&
                e.DataRepeaterItem.Controls["txtW2OrderStatus"].Text.ToString() != "Rejected" &&
                e.DataRepeaterItem.Controls["txtW2OrderStatus"].Text.ToString() != "Cancelled"))
            {
                e.DataRepeaterItem.Controls["txtW2Price"].BackColor = Color.LightSkyBlue;

            }
            else
            {
                e.DataRepeaterItem.Controls["txtW2Price"].BackColor = Color.WhiteSmoke;
            }

            if (e.DataRepeaterItem.Controls["txtW2OrdType"].Text.ToString() == "CH")
            {
                e.DataRepeaterItem.Controls["txtW2OrdType"].BackColor = Color.Cornsilk;
                e.DataRepeaterItem.Controls["btnWheat2Edit"].Enabled = true;
                e.DataRepeaterItem.Controls["btnWheat2Priced"].Enabled = true;

            }
            else
            {
                e.DataRepeaterItem.Controls["txtW2OrdType"].BackColor = Color.WhiteSmoke;
                e.DataRepeaterItem.Controls["btnWheat2Edit"].Enabled = false;
                e.DataRepeaterItem.Controls["btnWheat2Priced"].Enabled = false;
            }
        }


       

        private void btnEC_Enter(object sender, EventArgs e)
        {
            foreach (Control c in tbAddOrder.Controls)
            {

                if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {
                    c.BackColor = System.Drawing.Color.Transparent;
                }
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.BackColor = System.Drawing.Color.White;
                    c.ForeColor = System.Drawing.Color.Black;
                }
            }
            btnEC.BackColor = Color.Cornsilk;
        }


        private void dgvBuy_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
        }

        private void dgvOrders_Leave(object sender, EventArgs e)
        {
            RefreshOrderGrid();
            RefreshECOrderGrid();
            RefreshVCFOrderGrid();
            UpdateRegionGrid();
            RefreshPositions();
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }


        private void dgvPartial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CRMProcessing crm = new CRMProcessing();
            if (dgvPartial.Columns[e.ColumnIndex].Name == "PartFill")
            {
                int OrderID = Convert.ToInt32(dgvPartial.Rows[e.RowIndex].Cells["PartOrderNo"].Value.ToString());
                int OrigQty = Convert.ToInt32(dgvPartial.Rows[e.RowIndex].Cells["PartOrigOrdQty"].Value.ToString());
                string TradeCompany = dgvPartial.Rows[e.RowIndex].Cells["PartComp"].Value.ToString();
                this.dtECPartialOrders.Clear();
                //dtOrders.GetChanges();
                dtECPartialOrders = GlobalStore.FillECPartialOrdersDataSet().Tables[0];

                frmECPartialFills frmPartial = new frmECPartialFills();
                frmPartial.frmCopyOrders = this;
                frmPartial.mOrderNumber = OrderID;
                frmPartial.mOrig_Qty = OrigQty;
                frmPartial.mTradeCompany = TradeCompany;
                frmPartial.mdtECSplitOrders = dtECPartialOrders;
                frmPartial.dvECSplitOrders = dtECPartialOrders.DefaultView;
                frmPartial.dvECSplitOrders.RowFilter = "ClientOrderID = " + OrderID.ToString();
                if (frmPartial.LoadGrid())
                {
                    frmPartial.Show(this);
                }
                else
                {
                    MessageBox.Show("Error loading form.  Please contact system admin.", "Hedge Order");
                }
                
                //frmPartial.frmCopyOrders.Dispose();
            }
        }

        private void tbAddOrder_Enter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Stop();

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void dgvOrders_DoubleClick(object sender, EventArgs e)
        {

            int OrderNumber = 0;
            isRowChanged = false;

            Int32 giRowIndex = 1;
            Int32 iRowIndex = 0;
            DataGridViewRow dgvCurrentRow = this.dgvOrders.CurrentRow;
            iRowIndex = dgvCurrentRow.Index;
            // Set as selected 
            dgvOrders.Rows[iRowIndex].Selected = true;

            giRowIndex = iRowIndex;
            string TradeComp = dgvOrders.Rows[iRowIndex].Cells["Comp"].Value.ToString();
            string EO = dgvOrders.Rows[iRowIndex].Cells["chkEO"].Value.ToString();
            string GTC = dgvOrders.Rows[iRowIndex].Cells["chkGTC"].Value.ToString();
            string curAcct = dgvOrders.Rows[iRowIndex].Cells["OrdAcct"].Value.ToString();
            string Qty = dgvOrders.Rows[iRowIndex].Cells["OrdQty"].Value.ToString();
            OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
            string OrdType = dgvOrders.Rows[iRowIndex].Cells["Type"].Value.ToString();
            GlobalStore.FillCLOrderDataTable(OrderNumber.ToString());
            DataView viewOrder = GlobalStore.mdtCLOrder.DefaultView;
            if (OrdType == "SPR")
            {
                ViewOrderSpread(OrderNumber);
            }
            else
            {
                ViewOrder(OrderNumber);
            }
        }


        private void dgvOrders_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 120000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }


        private void tbcOrders_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void tbcOrders_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;

        }

        private void tbcOrdersDetails_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
        }

        private void tbcOrdersDetails_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void tmrVCF_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrVCF.Interval = 10000;
                RefreshVCFOrderGrid();
            }
            catch (Exception)
            {
                tmrVCF.Stop();
                MessageBox.Show("Error getting data from database.  Please contact system administration.", "Hedge Order");
                return;
            }
        }

        private void dgvCGBVCF_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 120000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
        }

        private void tbcOrdersDetails_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 30000;
        }

        private void dgvRegionOrders_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 30000;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrECorders.Interval = 10000;
        }

        private void dgvRegionSpreads_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 120000;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrECorders.Interval = 10000;
        }

        private void gbCorn_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void dgvSplit_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
        }

        private void dgvFilled_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
        }

        private void dgvPartial_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
        }

        private void dgvPartial_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 120000;
        }

        private void dgvPartial_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void tbcOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvECOrders.RowFilter = "";
            RefreshOrderGrid();
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;

        }

        private void GTC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void EO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtComments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtSComments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void dgvRegionOrders_Scroll(object sender, ScrollEventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 30000;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrECorders.Interval = 10000;
        }

        private void dgvRegionSpreads_Scroll(object sender, ScrollEventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 120000;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrECorders.Interval = 10000;
        }

        private void drCorn2_Scroll(object sender, ScrollEventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            
            tmrPosition.Stop();
            tmrPosition.Interval = 30000;
            tmrPosition.Start();
            tmrECorders.Interval = 10000;
        }

        private void dtrBeans2_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrECorders.Interval = 10000;
        }

        private void dtrBeans2_Scroll(object sender, ScrollEventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Stop();
            tmrPosition.Interval = 30000;
            tmrPosition.Start();
            tmrECorders.Interval = 10000;
        }

        private void drWheat2_Scroll(object sender, ScrollEventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Stop();
            tmrPosition.Interval = 30000;
            tmrPosition.Start();
            tmrECorders.Interval = 10000;
        }

        
        private void drWheat2_MouseHover(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void tpPositionCH_MouseEnter(object sender, EventArgs e)
        {
            //tmrOrders.Interval = 10000;
            //tmrRegionOrders.Interval = 600;
            //tmrVCF.Interval = 10000;
            //tmrPosition.Interval = 15000;
            //
            //tmrRegionOrders.Interval = 600;
            //tmrECorders.Interval = 10000; 
        }

        private void tpPositionCH_MouseHover(object sender, EventArgs e)
        {
            //tmrOrders.Interval = 10000;
            //tmrRegionOrders.Interval = 600;
            //tmrVCF.Interval = 10000;
            //tmrPosition.Interval = 15000;
            //
            //tmrRegionOrders.Interval = 600;
            //tmrECorders.Interval = 10000; 
        }

        private void tpPositionCH_MouseLeave(object sender, EventArgs e)
        {
            //tmrOrders.Interval = 10000;
            //tmrRegionOrders.Interval = 600;
            //tmrVCF.Interval = 10000;
            //tmrPosition.Interval = 15000;
            //
            //tmrRegionOrders.Interval = 600;
            //tmrECorders.Interval = 10000; 
        }

        private void gbWheat_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void gbCorn_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void gbBeans_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void gbBeans_MouseHover(object sender, EventArgs e)
        {

        }

        private void txtOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch.Focus();
            }
        }

        private void txtFindCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch.Focus();
            }
        }

        private void dgvOrders_Scroll(object sender, ScrollEventArgs e)
        {
            tmrOrders.Interval = 120000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Stop();
            tmrPosition.Interval = 20000;
            tmrPosition.Start();
            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void dgvOrders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //System.Diagnostics.Debug.Print(dgvOrders.CurrentCell.Value.ToString());
        }

        private void dgvOrders_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                if (e.ColumnIndex == dgvOrders.Columns["OrdFilled"].Index && dgvOrders.Rows[e.RowIndex].Cells["ContractDetailID"].Value.ToString() != "")
                {
                    if (MessageBox.Show(dgvOrders.Rows[e.RowIndex].Cells["OrderNumb"].Value.ToString() + " is an Offer order.  Are you sure you want to fill this order?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        isRowChanged = false;
                        isNotValidated = false;
                        return;
                    }

                }
                try
                {
                    OrdersNew ord = new OrdersNew();
                    dgvOrders.EndEdit();
                    string rIndex = dgvOrders.Rows[e.RowIndex].Index.ToString();
                    int riIndex = Convert.ToInt16(rIndex);
                    string Type = "";
                    string Acct = "";
                    string Ind = "";
                    string Qty = "";
                    string sMonth = "";
                    string sYear = "";
                    string Comm = "";
                    string Price = "";
                    string Filled = "";
                    string Comp = "";
                    string PremSide = "";
                    string S2Month = "";
                    string S2Year = "";
                    string OrderNumber = "";
                    int FixEO = 0;
                    int FixGTC = 0;
                    int Can = 0;
                    string VCAccount = "";
                    string VCComments = "";
                    string VCCustomer = "";
                    string CurrentUser = WindowsIdentity.GetCurrent().Name;
                    string OrderSent = "";
                    string ReturnMessage = "";
                    string CardNumber = "";
                    string Status = "";
                    string OrderDate = "";
                    string Comments = "";
                    string Canc = "";
                    string EO = "";
                    string GTC = "";
                    string Parent = "";

                    Canc = dgvOrders.Rows[riIndex].Cells["Can"].Value.ToString();
                    if (Canc == "True")
                    {
                        MessageBox.Show("This order has been cancelled.", "Hedge Order");
                        isRowChanged = false;
                        isNotValidated = false;
                        //RefreshOrderGrid();
                        tmrOrders.Interval = 120000;
                        tmrRegionOrders.Interval = 600;
                        tmrVCF.Interval = 10000;
                        tmrPosition.Interval = 15000;

                        tmrRegionOrders.Interval = 600;
                        tmrECorders.Interval = 10000;
                        return;

                    }

                    Boolean Grid = false;
                    OrderNumber = dgvOrders.Rows[riIndex].Cells["OrderNumb"].Value.ToString();
                    if (dgvOrders.Rows[riIndex].Cells["chkEO"].Value.ToString() == "True")
                    {
                        FixEO = 1;
                    }
                    if (dgvOrders.Rows[riIndex].Cells["chkGTC"].Value.ToString() == "True")
                    {
                        FixGTC = 1;
                    }
                    if (dgvOrders.Rows[riIndex].Cells["Can"].Value.ToString() == "True")
                    {
                        Can = 1;
                    }
                    EO = dgvOrders.Rows[riIndex].Cells["chkEO"].Value.ToString();
                    GTC = dgvOrders.Rows[riIndex].Cells["chkGTC"].Value.ToString();
                    VCAccount = dgvOrders.Rows[riIndex].Cells["VCAccount"].Value.ToString();
                    VCComments = dgvOrders.Rows[riIndex].Cells["VCComments"].Value.ToString();
                    VCCustomer = dgvOrders.Rows[riIndex].Cells["VCCustomer"].Value.ToString();
                    CardNumber = dgvOrders.Rows[riIndex].Cells["CardNumber"].Value.ToString();
                    Status = dgvOrders.Rows[riIndex].Cells["Status"].Value.ToString();
                    Parent = dgvOrders.Rows[riIndex].Cells["ParentID"].Value.ToString();
                    OrderDate = dgvOrders.Rows[riIndex].Cells["OrderDate"].Value.ToString();
                    Comments = dgvOrders.Rows[riIndex].Cells["Comments"].Value.ToString();
                    Type = dgvOrders.Rows[riIndex].Cells["Type"].Value.ToString();
                    Acct = dgvOrders.Rows[riIndex].Cells["OrdAcct"].Value.ToString();
                    Ind = dgvOrders.Rows[riIndex].Cells["OrdInd"].Value.ToString();
                    Qty = dgvOrders.Rows[riIndex].Cells["OrdQty"].Value.ToString();
                    sMonth = dgvOrders.Rows[riIndex].Cells["OrdMonth"].Value.ToString();
                    sYear = dgvOrders.Rows[riIndex].Cells["OrdYear"].Value.ToString();
                    Comm = dgvOrders.Rows[riIndex].Cells["OrdComm"].Value.ToString();
                    Price = dgvOrders.Rows[riIndex].Cells["OrdPrice"].Value.ToString();
                    Filled = dgvOrders.Rows[riIndex].Cells["OrdFilled"].Value.ToString();
                    Comp = dgvOrders.Rows[riIndex].Cells["Comp"].Value.ToString();
                    Boolean CheckValue = true;

                    viewCommodities.RowFilter = "TP_COMM = " + Comm.ToString();
                    string ExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                    if (e.ColumnIndex == dgvOrders.Columns["Comments"].Index || e.ColumnIndex == dgvOrders.Columns["OrderDate"].Index || e.ColumnIndex == dgvOrders.Columns["ParentID"].Index || e.ColumnIndex == dgvOrders.Columns["OrdQty"].Index)
                    {
                        tmrOrders.Interval = 10000;
                        tmrRegionOrders.Interval = 120000;
                        tmrVCF.Interval = 10000;
                        tmrPosition.Interval = 15000;

                        tmrRegionOrders.Interval = 600;
                        tmrECorders.Interval = 10000;
                        //if (MessageBox.Show("Are you sure you want to change order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        //{
                        //    isRowChanged = false;
                        //    isNotValidated = false;
                        //    return;
                        //}
                        //else
                        //{
                            ord.EditOrderInGrid(OrderNumber, Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                                  Filled, Type, Comp, Parent, FixEO, FixGTC, CardNumber, Status, Comments,
                                  OrderDate, VCAccount, VCCustomer, VCComments, CurrentUser, ExchangeLetter, ref OrderSent,
                                  ref ReturnMessage, Can);

                            if (OrderSent != "0")
                            {
                                ShowMessage(OrderSent, ReturnMessage);
                            }
                            isRowChanged = false;
                            isNotValidated = false;
                            RefreshOrderGrid();
                            if (dgvOrders.RowCount > 1)
                            {
                                dgvOrders.CurrentCell.Selected = false;
                                dgvOrders.Rows[mRowsIndex].Cells[mColumnIndex].Selected = true;
                            }
                            isRowChanged = false;
                            isNotValidated = false;
                        return;


                    }
                    else if (ValidateEntry(Filled, Acct, Ind, Qty, sYear, sMonth, Comm, Type, Comp, Price,
                           PremSide, S2Month, S2Year, Grid, EO, GTC) == true)
                        {
                            tmrOrders.Interval = 10000;
                            tmrRegionOrders.Interval = 120000;
                            tmrVCF.Interval = 10000;
                            tmrPosition.Interval = 15000;

                            tmrRegionOrders.Interval = 600;
                            tmrECorders.Interval = 10000;
                            //if (MessageBox.Show("Are you sure you want to change order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            //{
                            //    isRowChanged = false;
                            //    isNotValidated = false;
                            //    return;
                            //}
                            //else
                            //{
                                ord.EditOrderInGrid(OrderNumber, Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                                      Filled, Type, Comp, Parent, FixEO, FixGTC, CardNumber, Status, Comments,
                                      OrderDate, VCAccount, VCCustomer, VCComments, CurrentUser, ExchangeLetter, ref OrderSent,
                                      ref ReturnMessage, Can);

                                if (OrderSent != "0")
                                {
                                    ShowMessage(OrderSent, ReturnMessage);
                                }
                                isRowChanged = false;
                                isNotValidated = false;
                                RefreshOrderGrid();
                                if (dgvOrders.RowCount > 1)
                                {
                                    dgvOrders.CurrentCell.Selected = false;
                                    dgvOrders.Rows[mRowsIndex].Cells[mColumnIndex].Selected = true;
                                }
                                isRowChanged = false;
                                isNotValidated = false;


                        //    }

                        }
                    
                    else
                    {
                        if (CheckValue)
                        {
                            isRowChanged = false;
                            isNotValidated = false;
                            //RefreshOrderGrid();
                            this.tmrOrders.Interval = 120000;
                            if (dgvOrders.RowCount > 1)
                            {
                                dgvOrders.CurrentCell.Selected = false;
                                dgvOrders.Rows[mRowsIndex].Cells[mColumnIndex].Selected = true;
                            }
                            //dgvOrders.CurrentCell = dgvOrders.SelectedCells[0];
                            isRowChanged = false;
                            CheckValue = false;


                        }
                        else
                        {
                            //    this.tmrOrders.Interval = 120000;
                            //    if (dgvOrders.RowCount > 1)
                            //    {
                            //        dgvOrders.CurrentCell.Selected = false;
                            //        dgvOrders.Rows[riIndex].Cells[mColumnIndex].Selected = true;
                            //    }
                            //RefreshOrderGrid();
                            //this.tmrOrders.Interval = 120000; 
                            isNotValidated = false;
                            isRowChanged = false;
                            CheckValue = false;
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

        private void dgvOrders_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvECOrders_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvECOrders_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (isNotValidated)
            //    e.Cancel = true;
        }

        private void dgvRegionVCF_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    OrdersNew ord = new OrdersNew();
                    dgvRegionVCF.EndEdit();
                    string rIndex = dgvRegionVCF.Rows[e.RowIndex].Index.ToString();
                    int riIndex = Convert.ToInt16(rIndex);
                    string Type = "";
                    string Acct = "";
                    string Ind = "";
                    string Qty = "";
                    string sMonth = "";
                    string sYear = "";
                    string Comm = "";
                    string Price = "";
                    string Filled = "";
                    //string Comp = "";
                    //string PremSide = "";
                    //string S2Month = "";
                    //string S2Year = "";
                    string OrderNumber = "";
                    //int FixEO = 0;
                    //int FixGTC = 0;
                    //int Can = 0;
                    string VCAccount = "";
                    string VCComments = "";
                    string VCCustomer = "";
                    string CurrentUser = WindowsIdentity.GetCurrent().Name;
                    string OrderSent = "";
                    string ReturnMessage = "";
                    string CardNumber = "";
                    //string Status = "";
                    string OrderDate = "";
                    string Comments = "";
                    string RequestID = "";
                    string TradeCompany = "";
                    //string OrderNumber = "";
                    //string Filled = "";
                    //Boolean Grid = true;

                    Acct = dgvRegionVCF.Rows[riIndex].Cells["VCFAcct"].Value.ToString();
                    VCComments = dgvRegionVCF.Rows[riIndex].Cells["VCFVCComm"].Value.ToString();
                    VCCustomer = dgvRegionVCF.Rows[riIndex].Cells["VCFTradeComp"].Value.ToString();
                    CardNumber = dgvRegionVCF.Rows[riIndex].Cells["VCFCardNumber"].Value.ToString();
                    OrderDate = dgvRegionVCF.Rows[riIndex].Cells["VCFDate"].Value.ToString();
                    Comments = dgvRegionVCF.Rows[riIndex].Cells["VCFComments"].Value.ToString();
                    Type = dgvRegionVCF.Rows[riIndex].Cells["VCFType"].Value.ToString();
                    VCAccount = dgvRegionVCF.Rows[riIndex].Cells["VCFVCAcct"].Value.ToString();
                    Ind = dgvRegionVCF.Rows[riIndex].Cells["VCFInd"].Value.ToString();
                    Qty = dgvRegionVCF.Rows[riIndex].Cells["VCFQty"].Value.ToString();
                    sMonth = dgvRegionVCF.Rows[riIndex].Cells["VCFMonth"].Value.ToString();
                    sYear = dgvRegionVCF.Rows[riIndex].Cells["VCFYear"].Value.ToString();
                    Comm = dgvRegionVCF.Rows[riIndex].Cells["VCFComm"].Value.ToString();
                    Price = dgvRegionVCF.Rows[riIndex].Cells["VCFPrice"].Value.ToString();
                    RequestID = dgvRegionVCF.Rows[riIndex].Cells["VCFReqID"].Value.ToString();
                    TradeCompany = dgvRegionVCF.Rows[riIndex].Cells["RegTradeComp"].Value.ToString();
                    OrderNumber = dgvRegionVCF.Rows[riIndex].Cells["OrderNumber"].Value.ToString();
                    Filled = dgvRegionVCF.Rows[riIndex].Cells["VCFFilled"].Value.ToString();
                    //Boolean CheckValue = true;


                    isRowChanged = false;
                    isNotValidated = false;
                    //if (MessageBox.Show("Are you sure you want to change VCF order " + RequestID.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    //{
                    //    isRowChanged = false;
                    //    GlobalStore.setIsRowChanged(false);
                    //    RefreshVCFOrderGrid();
                    //    tmrVCF.Interval = 120000;
                    //    if (dgvRegionVCF.RowCount > 1)
                    //    {
                    //        dgvRegionVCF.CurrentCell.Selected = false;
                    //        dgvRegionVCF.Rows[riIndex].Cells[mColumnIndex].Selected = true;
                    //    }

                    //    isNotValidated = false;
                    //    return;
                    //}
                    //else
                    //{
                    if (OrderNumber == "")
                    {
                        ord.EditVCFOrderInGrid(Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                              Type, CardNumber, Comments, OrderDate, VCAccount, VCCustomer, VCComments,
                              CurrentUser, RequestID, TradeCompany.ToString());
                        isRowChanged = false;
                        isNotValidated = false;
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                        else
                        {
                            RefreshVCFOrderGrid();
                            RefreshECOrderGrid();
                            RefreshOrderGrid();
                            RefreshPositions();
                            if (dgvRegionVCF.RowCount > 1)
                            {
                                dgvRegionVCF.CurrentCell.Selected = false;
                                dgvRegionVCF.Rows[riIndex].Cells[16].Selected = true;
                            }

                        }
                        //}
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                    else
                    {
                        ord.EditCGBVCFOrderInGrid(Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                              Filled, Type, CardNumber, Comments,
                              OrderDate, VCAccount, VCCustomer, VCComments, CurrentUser,
                              OrderNumber, TradeCompany);
                        isRowChanged = false;
                        GlobalStore.setIsRowChanged(false);
                        isNotValidated = false;
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                        RefreshVCFOrderGrid();
                        tmrVCF.Interval = 120000;
                        if (dgvRegionVCF.RowCount > 1)
                        {
                            dgvRegionVCF.CurrentCell.Selected = false;
                            dgvRegionVCF.Rows[riIndex].Cells[16].Selected = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

        private void dgvRegionVCF_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }


        private void dgvRegionOrders_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    OrdersNew ord = new OrdersNew();
                    dgvRegionOrders.EndEdit();
                    string rIndex = dgvRegionOrders.Rows[e.RowIndex].Index.ToString();
                    int riIndex = Convert.ToInt16(rIndex);
                    string Type = "";
                    string Acct = "";
                    string Ind = "";
                    string Qty = "";
                    string sMonth = "";
                    string sYear = "";
                    string Comm = "";
                    string Price = "";
                    string ChgPrice = "";
                    string Filled = "";
                    string Comp = "";
                    //string PremSide = "";
                    //string S2Month = "";
                    //string S2Year = "";
                    string OrderNumber = "";
                    int FixEO = 0;
                    int FixGTC = 0;
                    int Can = 0;
                    string CurrentUser = WindowsIdentity.GetCurrent().Name;
                    string OrderSent = "";
                    string ReturnMessage = "";
                    string CardNumber = "";
                    string VCAccount = "";
                    string VCComments = "";
                    string VCCustomer = "";

                    string Status = "";
                    string OrderDate = "";
                    string Comments = "";
                    string RequestID = "";
                    Boolean Grid = true;
                    string EO = "";
                    string GTC = "";

                    EO = dgvRegionOrders.Rows[riIndex].Cells["ReqEO"].Value.ToString();
                    GTC = dgvRegionOrders.Rows[riIndex].Cells["ReqGTC"].Value.ToString();
                    OrderNumber = dgvRegionOrders.Rows[riIndex].Cells["ReqOrdID"].Value.ToString();

                    
                    if (dgvRegionOrders.Rows[riIndex].Cells["ReqEO"].Value.ToString() == "True")
                    {
                        FixEO = 1;
                    }
                    if (dgvRegionOrders.Rows[riIndex].Cells["ReqGTC"].Value.ToString() == "True")
                    {
                        FixGTC = 1;
                    }
                    if (dgvRegionOrders.Rows[riIndex].Cells["CancReq"].Value.ToString() == "True")
                    {
                        Can = 1;
                    }
                    //FixEO = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkEO"].Value.ToString());
                    //FixGTC = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkGTC"].Value.ToString());
                    VCAccount = dgvRegionOrders.Rows[riIndex].Cells["VCAcct"].Value.ToString();
                    VCComments = dgvRegionOrders.Rows[riIndex].Cells["VCComm"].Value.ToString();
                    VCCustomer = dgvRegionOrders.Rows[riIndex].Cells["VCCompany"].Value.ToString();
                    CardNumber = dgvRegionOrders.Rows[riIndex].Cells["CardNumber"].Value.ToString();
                    //Status = dgvRegionOrders.Rows[riIndex].Cells["Status"].Value.ToString();
                    OrderDate = dgvRegionOrders.Rows[riIndex].Cells["Date"].Value.ToString();
                    Comments = dgvRegionOrders.Rows[riIndex].Cells["ReqComments"].Value.ToString();
                    Type = dgvRegionOrders.Rows[riIndex].Cells["ReqType"].Value.ToString();
                    Acct = dgvRegionOrders.Rows[riIndex].Cells["Acct"].Value.ToString();
                    Ind = dgvRegionOrders.Rows[riIndex].Cells["Ind"].Value.ToString();
                    Qty = dgvRegionOrders.Rows[riIndex].Cells["ReqQty"].Value.ToString();
                    sMonth = dgvRegionOrders.Rows[riIndex].Cells["ReqMonth"].Value.ToString();
                    sYear = dgvRegionOrders.Rows[riIndex].Cells["ReqYear"].Value.ToString();
                    Comm = dgvRegionOrders.Rows[riIndex].Cells["ReqComm"].Value.ToString();
                    Price = dgvRegionOrders.Rows[riIndex].Cells["ReqPrice"].Value.ToString();
                    ChgPrice = dgvRegionOrders.Rows[riIndex].Cells["NewReqPrice"].Value.ToString();
                    Comp = dgvRegionOrders.Rows[riIndex].Cells["TradeCo"].Value.ToString();
                    RequestID = dgvRegionOrders.Rows[riIndex].Cells["Reg_ID"].Value.ToString();
                    Boolean CheckValue = true;
                    //Comp = dgvRegionSpreads.Rows[riIndex].Cells["Comp"].Value.ToString();
                    if (Type.ToString() == "EMC".ToString())
                    {
                        if (dgvRegionOrders.Rows[riIndex].Cells["ReqEO"].Value.ToString() == "False")
                        {
                            dgvRegionOrders.Rows[riIndex].Cells["ReqEO"].Value = "True";
                            FixEO = 1;
                        }
                    }
                    if (Type.ToString() == "MOC".ToString())
                    {
                        if (dgvRegionOrders.Rows[riIndex].Cells["ReqEO"].Value.ToString() == "True")
                        {
                            dgvRegionOrders.Rows[riIndex].Cells["ReqEO"].Value = "False";
                            FixEO = 0;
                            EO = "false";
                        }
                    }


                    if (ValidateRegionEntry(Filled, Acct, Ind, Qty, sYear, sMonth, Comm, Type, Comp, Price,
                       Grid, EO, GTC) == true)
                    {
                        isRowChanged = false;
                        isNotValidated = false;
                        if (MessageBox.Show("Are you sure you want to change region order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            isRowChanged = false;
                            isNotValidated = false;
                            return;
                        }
                        else
                        {

                            ord.EditOrderInGrid(OrderNumber, Acct, Ind, Qty, sMonth, sYear, Comm, Price, ChgPrice,
                                  Type, Comp, FixEO, FixGTC, CardNumber, Status, Comments,
                                  OrderDate, VCAccount, VCCustomer, VCComments, CurrentUser, ref OrderSent,
                                  ref ReturnMessage, Can, RequestID);
                            isRowChanged = false;
                            isNotValidated = false;
                            if (OrderSent != "")
                            {
                                ShowMessage(OrderSent, ReturnMessage);
                            }
                            RefreshVCFOrderGrid();
                            RefreshECOrderGrid();
                            UpdateRegionGrid();
                            RefreshOrderGrid();
                            RefreshPositions();
                            if (dgvRegionOrders.RowCount > 1)
                            {
                                dgvRegionOrders.CurrentCell.Selected = false;
                                dgvRegionOrders.Rows[mRowIndex].Cells[mColumnIndex].Selected = true;
                            }

                        }

                    }
                    else
                    {
                        if (CheckValue)
                        {
                            isRowChanged = false;
                            isNotValidated = true;
                            UpdateRegionGrid();
                            tmrRegionOrders.Interval = 120000;

                            if (dgvRegionOrders.RowCount > 1)
                            {
                                dgvRegionOrders.CurrentCell.Selected = false;
                                dgvRegionOrders.Rows[mRowIndex].Cells[mColumnIndex].Selected = true;
                            }

                            //dgvRegionOrders.CurrentCell = dgvRegionOrders.SelectedCells[[0];
                            isRowChanged = false;
                            isNotValidated = false;
                            CheckValue = false;
                            tmrRegionOrders.Interval = 120000;



                        }
                        else
                        {
                            isRowChanged = false;
                            isNotValidated = false;

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                }
                isRowChanged = false;
                isNotValidated = false;
            }
        }

        private void dgvRegionOrders_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }


        private void dgvOrders_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send(Keys.Space.ToString());
            //}
            //else if (e.KeyCode == Keys.Return)
            //{
            //    SendKeys.Send(Keys.Space.ToString());
            //}

        }

        private void dgvRegionOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvRegionOrders.EndEdit();
                isRowChanged = false;
            }
        }

        private void dgvOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvOrders.EndEdit();
                isRowChanged = false;
            }
        }

        private void btnCorn2Priced_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            String QuantitySent = "";
            String BS = "";
            String HedgeMonth = "";
            String HedgeYear = "";
            String HedgeMonthYear = "";
            String Price = "";

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            Int32 OrderNumber = 0;
            //// Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            //dr = drCorn2;
            //OrderNumber = Convert.ToInt32(drCorn2.CurrentItem.Controls["btnCorn2Edit"].Tag.ToString());
            OrderNumber = Convert.ToInt32(drCorn2.CurrentItem.Controls["txtC2CGBOrd"].Text.ToString());
            string Type = "";
            Type = drCorn2.CurrentItem.Controls["txtC2OrdType"].Text.ToString();

            /////////////////////////New code for Clone button//////////////////////
            if(drCorn2.CurrentItem.Controls["txtC2Buy"].Text.ToString() == "0.00")
            {
                QuantitySent = drCorn2.CurrentItem.Controls["txtC2Sell"].Text.ToString();
                BS = "B";
            }
            else
            {
                QuantitySent = drCorn2.CurrentItem.Controls["txtC2Buy"].Text.ToString();
                BS = "S";
            }
            Price = drCorn2.CurrentItem.Controls["txtC2Price"].Text.ToString();
            HedgeMonthYear = drCorn2.CurrentItem.Controls["txtC2Month"].Text.ToString();
            HedgeMonth = HedgeMonthYear.Substring(0, 1).ToString();
            HedgeMonth = HedgeMonth.Trim();
            HedgeYear = HedgeMonthYear.Substring(1, 3).ToString();
            HedgeYear = HedgeYear.Trim();
            PlaceCloneSingleOrder(2, QuantitySent, BS, HedgeMonth, HedgeYear, Price, 22);
            //ClonePriced(OrderNumber, Type.ToString(), 2);
            ////dr.Dispose();

        }

 
        private void btnBean2Priced_Click(object sender, EventArgs e)
        {
  
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            String QuantitySent = "";
            String BS = "";
            String HedgeMonth = "";
            String HedgeYear = "";
            String HedgeMonthYear = "";
            String Price = "";

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            Int32 OrderNumber = 0;
            //// Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            //dr = drBean2;
            //OrderNumber = Convert.ToInt32(drBean2.CurrentItem.Controls["btnBean2Edit"].Tag.ToString());
            OrderNumber = Convert.ToInt32(dtrBeans2.CurrentItem.Controls["txtB2CGBOrd"].Text.ToString());
            string Type = "";
            Type = dtrBeans2.CurrentItem.Controls["txtB2OrdType"].Text.ToString();

            /////////////////////////New code for Clone button//////////////////////
            if (dtrBeans2.CurrentItem.Controls["txtB2Buy"].Text.ToString() == "0.00")
            {
                QuantitySent = dtrBeans2.CurrentItem.Controls["txtB2Sell"].Text.ToString();
                BS = "B";
            }
            else
            {
                QuantitySent = dtrBeans2.CurrentItem.Controls["txtB2Buy"].Text.ToString();
                BS = "S";
            }
            Price = dtrBeans2.CurrentItem.Controls["txtB2Price"].Text.ToString();
            HedgeMonthYear = dtrBeans2.CurrentItem.Controls["txtB2Month"].Text.ToString();
            HedgeMonth = HedgeMonthYear.Substring(0, 1).ToString();
            HedgeMonth = HedgeMonth.Trim();
            HedgeYear = HedgeMonthYear.Substring(1, 3).ToString();
            HedgeYear = HedgeYear.Trim();
            PlaceCloneSingleOrder(2, QuantitySent, BS, HedgeMonth, HedgeYear, Price, 24);
            //ClonePriced(OrderNumber, Type.ToString(), 2);
            ////dr.Dispose();
        }

  
        private void btnWheat2Priced_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            String QuantitySent = "";
            String BS = "";
            String HedgeMonth = "";
            String HedgeYear = "";
            String HedgeMonthYear = "";
            String Price = "";

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            Int32 OrderNumber = 0;
            //// Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            //dr = drWheat2;
            //OrderNumber = Convert.ToInt32(drWheat2.CurrentItem.Controls["btnWheat2Edit"].Tag.ToString());
            OrderNumber = Convert.ToInt32(drWheat2.CurrentItem.Controls["txtW2CGBOrd"].Text.ToString());
            string Type = "";
            Type = drWheat2.CurrentItem.Controls["txtW2OrdType"].Text.ToString();

            /////////////////////////New code for Clone button//////////////////////
            if (drWheat2.CurrentItem.Controls["txtW2Buy"].Text.ToString() == "0.00")
            {
                QuantitySent = drWheat2.CurrentItem.Controls["txtW2Sell"].Text.ToString();
                BS = "B";
            }
            else
            {
                QuantitySent = drWheat2.CurrentItem.Controls["txtW2Buy"].Text.ToString();
                BS = "S";
            }
            Price = drWheat2.CurrentItem.Controls["txtW2Price"].Text.ToString();
            HedgeMonthYear = drWheat2.CurrentItem.Controls["txtW2Month"].Text.ToString();
            HedgeMonth = HedgeMonthYear.Substring(0, 1).ToString();
            HedgeMonth = HedgeMonth.Trim();
            HedgeYear = HedgeMonthYear.Substring(1, 3).ToString();
            HedgeYear = HedgeYear.Trim();
            PlaceCloneSingleOrder(2, QuantitySent, BS, HedgeMonth, HedgeYear, Price, 25);
            //ClonePriced(OrderNumber, Type.ToString(), 2);
            ////dr.Dispose();

        }

        
        private void txtSAcct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            RefreshOrderGrid();
            //RefreshPositions();
            RefreshVCFOrderGrid();
            UpdateRegionGrid();
            RefreshECOrderGrid();
        }

        private void drCorn2_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            if (e.DataRepeaterItem.Controls["txtC2OrderID"].Text.ToString() == "0" || e.DataRepeaterItem.Controls["txtC2OrderID"].Text.ToString() == "" ||
                e.DataRepeaterItem.Controls["txtC2OrderStatus"].Text.ToString() == "Rejected" ||
                e.DataRepeaterItem.Controls["txtC2OrderStatus"].Text.ToString() == "Cancelled")
            {
                e.DataRepeaterItem.Controls["btnCorn2Clone"].Enabled = false;

            }
            else
            {
                e.DataRepeaterItem.Controls["btnCorn2Clone"].Enabled = true;

            }
            if ((e.DataRepeaterItem.Controls["txtC2OrderID"].Text.ToString() != "0" && e.DataRepeaterItem.Controls["txtC2OrderID"].Text.ToString() != "") &&
                (e.DataRepeaterItem.Controls["txtC2OrderStatus"].Text.ToString() != "Filled" &&
                e.DataRepeaterItem.Controls["txtC2OrderStatus"].Text.ToString() != "Rejected" &&
                e.DataRepeaterItem.Controls["txtC2OrderStatus"].Text.ToString() != "Cancelled"))
            {
                e.DataRepeaterItem.Controls["txtC2Price"].BackColor = Color.LightSkyBlue;

            }
            else
            {
                e.DataRepeaterItem.Controls["txtC2Price"].BackColor = Color.WhiteSmoke;

            }
            if (e.DataRepeaterItem.Controls["txtC2OrdType"].Text.ToString() == "CH")
            {
                e.DataRepeaterItem.Controls["txtC2OrdType"].BackColor = Color.Cornsilk;
                e.DataRepeaterItem.Controls["btnCorn2Edit"].Enabled = true;
                e.DataRepeaterItem.Controls["btnCorn2Priced"].Enabled = true;

            }
            else
            {
                e.DataRepeaterItem.Controls["txtC2OrdType"].BackColor = Color.WhiteSmoke;
                e.DataRepeaterItem.Controls["btnCorn2Edit"].Enabled = false;
                e.DataRepeaterItem.Controls["btnCorn2Priced"].Enabled = false;
            }
        }

        private void txtComments_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtComments);
            txtComments.SelectAll();
        }

        private void txtSComments_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtSComments);
            txtSComments.SelectAll();
        }

        private void txtFindYearText_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtFindYearText);
            txtFindYearText.SelectAll();
        }

        private void txtFindYearText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtFindOrderFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtFindOrderFrom_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtFindOrderFrom);
            txtFindOrderFrom.SelectAll();
        }

        private void txtFindOrderTo_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtFindOrderTo);
            txtFindOrderTo.SelectAll();
        }

        private void txtFindOrderTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtOrderNumber_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtOrderNumber);
            txtOrderNumber.SelectAll();
        }

        private void txtFindCardNumber_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtFindCardNumber);
            txtFindCardNumber.SelectAll();
        }

       
        private void txtSAcct_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtSAcct);
            txtSAcct.SelectAll();
        }

        private void frmOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                tmrECorders.Stop();
                tmrOrders.Stop();
                tmrPosition.Stop();
                tmrRegionOrders.Stop();
                tmrVCF.Stop();

            }
            catch
            {
                //mHedge_Log.WriteEntry("Application Closing");
                MessageBox.Show("Application Closing Error", "Hedge Order");
            }

            
        }

        private void frmOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                
                //mHedge_Log.WriteEntry("Application Closing"); 
                tmrECorders.Stop();
                tmrOrders.Stop();
                tmrRiskPosition.Stop();
                tmrPosition.Stop();
                tmrRegionOrders.Stop();
                tmrVCF.Stop();
                Process.GetCurrentProcess().Kill(); 
                this.Dispose();
                Application.Exit();
                
            }
            catch
            {
                //mHedge_Log.WriteEntry("Application Closing");
            }

        }

        private void rbGTC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGTC.Checked)
            {
                try
                {
                    FilterECOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void dgvRegionOrders_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 RegID = 0;
            string ReturnMessage = "";
            OrdersUpdate ord = new OrdersUpdate();
            RegID = Convert.ToInt32(dgvRegionOrders.Rows[e.RowIndex].Cells["Reg_ID"].Value.ToString());
            if (MessageBox.Show("Delete Region Order with Request ID " + RegID.ToString() + "?", "Hedge Order", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
            {
                ord.DeleteRegionOrder(RegID, ref ReturnMessage);
                if (ReturnMessage != "")
                {
                    MessageBox.Show(ReturnMessage, "HedgeOrder");
                }
            }
            
        }

        private void btnUpdateHedgeLimits_Click(object sender, EventArgs e)
        {
            frmCommodityLimits frmUpdate = new frmCommodityLimits();
            frmUpdate.ShowDialog(this);
            frmUpdate.Dispose();
        }

        private void dgvCancelled_DoubleClick(object sender, EventArgs e)
        {
            int OrderNumber = 0;
            isRowChanged = false;

            Int32 giRowIndex = 1;
            Int32 iRowIndex = 0;
            DataGridViewRow dgvCurrentRow = this.dgvCancelled.CurrentRow;
            iRowIndex = dgvCurrentRow.Index;
            // Set as selected 
            dgvOrders.Rows[iRowIndex].Selected = true;

            giRowIndex = iRowIndex;
            string TradeComp = dgvCancelled.Rows[iRowIndex].Cells["Comp"].Value.ToString();
            string EO = dgvCancelled.Rows[iRowIndex].Cells["chkEO"].Value.ToString();
            string GTC = dgvCancelled.Rows[iRowIndex].Cells["chkGTC"].Value.ToString();
            string curAcct = dgvCancelled.Rows[iRowIndex].Cells["OrdAcct"].Value.ToString();
            string Qty = dgvCancelled.Rows[iRowIndex].Cells["OrdQty"].Value.ToString();
            OrderNumber = Convert.ToInt32(dgvCancelled.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
            string OrdType = dgvCancelled.Rows[iRowIndex].Cells["Type"].Value.ToString();
            GlobalStore.FillCLOrderDataTable(OrderNumber.ToString());
            DataView viewOrder = GlobalStore.mdtCLOrder.DefaultView;
            if (OrdType == "SPR")
            {
                ViewOrderSpread(OrderNumber);
            }
            else
            {
                ViewOrder(OrderNumber);
            }
        }

        private void dgvRejected_DoubleClick(object sender, EventArgs e)
        {
            int OrderNumber = 0;
            isRowChanged = false;

            Int32 giRowIndex = 1;
            Int32 iRowIndex = 0;
            DataGridViewRow dgvCurrentRow = this.dgvRejected.CurrentRow;
            iRowIndex = dgvCurrentRow.Index;
            // Set as selected 
            dgvRejected.Rows[iRowIndex].Selected = true;

            giRowIndex = iRowIndex;
            string TradeComp = dgvRejected.Rows[iRowIndex].Cells["RejTradeCo"].Value.ToString();
            //string EO = dgvOrders.Rows[iRowIndex].Cells["chkEO"].Value.ToString();
            string GTC = dgvRejected.Rows[iRowIndex].Cells["RejchkGTC"].Value.ToString();
            string curAcct = dgvRejected.Rows[iRowIndex].Cells["RejAcct"].Value.ToString();
            string Qty = dgvRejected.Rows[iRowIndex].Cells["RejQty"].Value.ToString();
            OrderNumber = Convert.ToInt32(dgvRejected.Rows[iRowIndex].Cells["RejOrderNumber"].Value.ToString());
            string OrdType = dgvRejected.Rows[iRowIndex].Cells["RejType"].Value.ToString();
            GlobalStore.FillCLOrderDataTable(OrderNumber.ToString());
            DataView viewOrder = GlobalStore.mdtCLOrder.DefaultView;
            if (OrdType == "SPR")
            {
                ViewOrderSpread(OrderNumber);
            }
            else
            {
                ViewOrder(OrderNumber);
            }
        }

        private void btnDailyHedgePad_Click(object sender, EventArgs e)
        {
            if (frmHedgePad == null)
            {
                frmHedgePad = new frmHedgePad();
                frmHedgePad.FormClosed += frmHedgePad_Closed;
                frmHedgePad.Show(this);
            }
            else
            {
                frmHedgePad.Focus();
                frmHedgePad.BringToFront();
            }
 
        
        }

        void frmHedgePad_Closed(object sender, EventArgs e)
        {
            frmHedgePad = null;
        }

        void frmKillSwitch_Closed(object sender, EventArgs e)
        {
            frmKillSwitch = null;
        }

        void frmOrderFills_Closed(object sender, EventArgs e)
        {
            frmOrderFills = null;
        }

        void frmReports_Closed(object sender, EventArgs e)
        {
            frmReports = null;
        }

        void frmOptions_Closed(object sender, EventArgs e)
        {
            frmOptions = null;
        }
         
        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvCancelled_Enter(object sender, EventArgs e)
        {
            tmrECorders.Stop();
        }

        private void dgvCancelled_Leave(object sender, EventArgs e)
        {
            tmrECorders.Start();
        }

        private void btnPurchaseSettle_Click(object sender, EventArgs e)
        {
            frmPurchaseSettle frmPSUpdate = new frmPurchaseSettle();
            frmPSUpdate.ShowDialog(this);
            frmPSUpdate.Dispose();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {

           
        }

        private void tvReports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            rvHedgedesk.Reset();
            DataTable dtDailyAccount = new DataTable();
            dtDailyAccount = GlobalStore.mdtAccounts.Copy();
            DataTable dtDailyCommodities = new DataTable();
            dtDailyCommodities = GlobalStore.mdtCommodity.Copy();
            DataTable dtDailyCompanies = new DataTable();
            dtDailyCompanies = GlobalStore.mdtComps.Copy();
            DataTable dtDailyMonths = new DataTable();
            dtDailyMonths = GlobalStore.mdtMonths.Copy();


            switch (e.Node.Name)
            {

                case "tcFuturesConfirmations":
                    ReportName = "tcFuturesConfirmations";
                    rvHedgedesk.Top = 119;
                    this.cboLedgerAccounts.DataSource = dtDailyAccount;
                    cboLedgerAccounts.DisplayMember = "TP_ACCT";
                    cboLedgerAccounts.ValueMember = "TP_ACCT";
                    cboLedgerAccounts.SelectedIndex = -1;
                    cboLedgerCompanies.DataSource = dtDailyCompanies;
                    cboLedgerCompanies.DisplayMember = "CompanyID";
                    cboLedgerCompanies.ValueMember = "CompanyID";
                    cboLedgerCompanies.SelectedIndex = -1;
                    grpParameters.Visible = true;
                    grpDailyPosition.Visible = false;
                    grpParametersLedger.Visible = false;
                    rvHedgedesk.Height = 519;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;
                case "rptDailyFuturesPositionReport":
                    ReportName = "rptDailyFuturesPostionReport";

                    rvHedgedesk.Top = 119;
                    cboDailyAccount.DataSource = dtDailyAccount;
                    cboDailyAccount.DisplayMember = "TP_ACCT";
                    cboDailyAccount.ValueMember = "TP_ACCT";
                    cboDailyAccount.SelectedIndex = -1;
                    cboDailyCommodity.DataSource = dtDailyCommodities;
                    cboDailyCommodity.DisplayMember = "TP_COMM";
                    cboDailyCommodity.ValueMember = "TP_COMM";
                    cboDailyCommodity.SelectedIndex = -1;
                    cboDailyMonth.DataSource = dtDailyMonths;
                    cboDailyMonth.DisplayMember = "TP_MON";
                    cboDailyMonth.ValueMember = "TP_MON";
                    cboDailyMonth.SelectedIndex = -1;
                    cboDailyCompany.DataSource = dtDailyCompanies;
                    cboDailyCompany.DisplayMember = "CompanyID";
                    cboDailyCompany.ValueMember = "CompanyID";
                    cboDailyCompany.SelectedIndex = -1;
                    grpParameters.Visible = false;
                    grpParametersLedger.Visible = false;
                    grpDailyPosition.Visible = true;
                    rvHedgedesk.Height = 519;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;
                case "LedgerBalanceReport":
                    ReportName = "rptLedgerBalanceReport";
                    rvHedgedesk.Top = 119;
                    grpDailyPosition.Visible = false;
                    grpParametersLedger.Visible = true;
                    grpParameters.Visible = false;
                    rvHedgedesk.Height = 519;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;
                default:
                    rvHedgedesk.Top = 3;
                    rvHedgedesk.Height = 635;
                    grpParameters.Visible = false;
                    grpDailyPosition.Visible = false;
                    grpParametersLedger.Visible = false;
                    break;

            }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void RunReport()
        {
            int Commodity = 0;
            int Account = 0;
            int Company = 0;
            int Year = 0;
            String Month = "";
            switch (ReportName)
            {

                case "tcFuturesConfirmations":


                    if (this.cboLedgerAccounts.Text == "")
                    {
                        Account = 0;
                    }
                    else if (cboLedgerAccounts.SelectedValue.ToString() == "")
                    {
                        Account = Convert.ToInt32(cboLedgerAccounts.Text);
                    }
                    else
                    {
                        Account = Convert.ToInt32(cboLedgerAccounts.SelectedValue.ToString());
                    }
                    if (this.cboLedgerCompanies.Text == "")
                    {
                        Company = 0;
                    }
                    else if (cboLedgerCompanies.SelectedValue.ToString() == "")
                    {
                        Company = Convert.ToInt32(cboLedgerCompanies.Text);
                    }
                    else
                    {
                        Company = Convert.ToInt32(cboLedgerCompanies.SelectedValue.ToString());
                    }


                    this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport(dtpOrderDate.Value.ToShortDateString(), Company, Account);
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "rptDailyFuturesPostionReport":


                    if (this.cboDailyCommodity.Text == "")
                    {
                        Commodity = 0;
                    }
                    else
                    {
                        Commodity = Convert.ToInt32(cboDailyCommodity.SelectedValue.ToString());
                    }
                    if (this.cboDailyAccount.Text == "")
                    {
                        Account = 0;
                    }
                    else
                    {
                        Account = Convert.ToInt32(cboDailyAccount.SelectedValue.ToString());
                    }
                    if (this.cboDailyCompany.Text == "")
                    {
                        Company = 0;
                    }
                    else
                    {
                        Company = Convert.ToInt32(cboDailyCompany.SelectedValue.ToString());
                    }

                    if (this.cboDailyMonth.Text == "")
                    {
                        Month = "";
                    }
                    else
                    {
                        Month = cboDailyMonth.SelectedValue.ToString();
                    }

                    if (this.txtDailyYear.Text == "")
                    {
                        Year = 0;
                    }
                    else if (this.txtDailyYear.Text.Length > 2)
                    {
                        MessageBox.Show("Year must be a 2 digit value.");
                        return;
                    }
                    else
                    {
                        Year = Convert.ToInt32(txtDailyYear.Text);
                    }
                    this.rvHedgedesk.Report = new HedgedeskReportProject.DailyFuturesPositionReportByGroup(Company, Account, Commodity, Month, Year);
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "rptLedgerBalanceReport":
                    this.rvHedgedesk.Report = new HedgedeskReportProject.LedgerBalanceReport(dtpLastSettlementDate.Value.ToShortDateString(), 0, 0);
                    this.rvHedgedesk.RefreshReport();
                    break;
                default:
                    break;

            }
        }

        private void tbcOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcOrder.SelectedIndex == 4)
            {
                rvHedgedesk.Top = 3;
                rvHedgedesk.Height = 635;
                grpParameters.Visible = false;

                frmReports rpt = new frmReports();
                rpt.Show();

            }

        }

        private void btnLedgerReport_Click(object sender, EventArgs e)
        {
            this.rvHedgedesk.Report = new HedgedeskReportProject.LedgerBalanceReport(this.dtpLastSettlementDate.Value.ToShortDateString(), 0, 0);
            this.rvHedgedesk.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet dtXML = new DataSet();
            DataSet dtXMLPrices = new DataSet();

            string strXmlTestCasePath = Properties.Settings.Default.HedgedeskConnectionString + "/HedgedeskFuturesPosition.xml";
            string strXmlPrices = Properties.Settings.Default.HedgedeskConnectionString + "/HedgedeskFuturesPrices.xml";
            Maintenance clsMaintenance = new Maintenance();
            clsMaintenance.GetXMLForZennoh(dtXML);
            using (XmlWriter xw = XmlWriter.Create(strXmlTestCasePath))
            {
                xw.WriteStartDocument();
                dtXML.DataSetName = "dataroot";
                dtXML.Tables[0].TableName = "qryTransferTextCreate_Zennoh_XML";
                dtXML.WriteXml(xw, XmlWriteMode.IgnoreSchema);    // from here on, you can use the XmlWriter to add XML to the end; you then    // have to wrap things up by closing the enclosing "container" element:    ...    
                xw.WriteEndDocument();
            }
            clsMaintenance.GetXMLFuturesForZennoh(dtXMLPrices);
            using (XmlWriter xw = XmlWriter.Create(strXmlPrices))
            {
                xw.WriteStartDocument();
                dtXMLPrices.DataSetName = "dataroot";
                dtXMLPrices.Tables[0].TableName = "qryTransferZenNohFutures";
                dtXMLPrices.WriteXml(xw, XmlWriteMode.IgnoreSchema);    // from here on, you can use the XmlWriter to add XML to the end; you then    // have to wrap things up by closing the enclosing "container" element:    ...    
                xw.WriteEndDocument();
            }
        }

        private void dgvRegionVCF_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 RegID = 0;
            string ReturnMessage = "";
            OrdersUpdate ord = new OrdersUpdate();
            RegID = Convert.ToInt32(dgvRegionVCF.Rows[e.RowIndex].Cells["VCFReqID"].Value.ToString());
            Int32 OrderNum = 0;
            
            if (RegID == 0)
            {
                OrderNum = Convert.ToInt32(dgvRegionVCF.Rows[e.RowIndex].Cells["OrderNumber"].Value.ToString()); 
                MessageBox.Show("Please cancel order number " + OrderNum.ToString() + " in the order grid.", "VCF Cancel");
                return;
            }
            if (MessageBox.Show("Delete VCF Order with Request ID " + RegID.ToString() + "?", "Hedge Order", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
            {
                ord.DeleteRegionOrder(RegID, ref ReturnMessage);
                if (ReturnMessage != "")
                {
                    MessageBox.Show(ReturnMessage, "HedgeOrder");
                }
            }
        }

        private void btnDailyFuturesPosition_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void btnPurchaseSettleInquiry_Click(object sender, EventArgs e)
        {
            frmPurchaseSettleInquiry frm = new frmPurchaseSettleInquiry();
            frm.Show();
        }

        private void txtVCComp_Leave(object sender, EventArgs e)
        {
            txtVCComments.Text = txtVCComp.Text;
        }

        private void btnMarginBalance_Click(object sender, EventArgs e)
        {
            frmMarginBalance frm = new frmMarginBalance();
            frm.Show();
        }

        private void btnViewAccounts_Click(object sender, EventArgs e)
        {
            frmAccountMaintenance frm = new frmAccountMaintenance();
            frm.Show();
        }

        private void btnSetAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Maintenance clsMaintenance = new Maintenance();
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                String HedgeUserID = "";
                if (this.cboHedgebookAccount.Text == "")
                {
                    MessageBox.Show("Please select an account.", "Hedge Account Maintenenance");
                    return;
                }
                else
                {
                    HedgeUserID = cboHedgebookAccount.SelectedValue.ToString();
                }
                clsMaintenance.UpdateHedgeAccount(CurrentUser, Convert.ToInt32(HedgeUserID.ToString()));
                Properties.Settings.Default.HedgeUserID = Convert.ToInt32(HedgeUserID.ToString());

                if (LoadHedgeAccounts())
                {
                    if (Properties.Settings.Default.HedgeUserID != 0)
                    {
                        this.cboHedgebookAccount.SelectedValue = Properties.Settings.Default.HedgeUserID;
                    }
                }
                MessageBox.Show("Hedge account updated.  Pleast close and reopen hedgebook to see changes.", "Hedge Account");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnLedgerBalance_Click(object sender, EventArgs e)
        {
            frmLedgerBalanceMaintenance frm = new frmLedgerBalanceMaintenance();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Telerik.Reporting.Report report = new HedgedeskReportProject.LedgerBalanceReport(this.dtpLastSettlementDate.Value.ToShortDateString(), 0, 0);

            MailReport(report, "Paige@notrs.com", "Paige@notrs.com", "Ledger Balance Report", "Hennepin");
        }
        void MailReport(Telerik.Reporting.Report report, string from, string to, string subject, string body)
        {
            ReportProcessor reportProcessor = new ReportProcessor();
            RenderingResult result = reportProcessor.RenderReport("PDF", report, null);

            MemoryStream ms = new MemoryStream(result.DocumentBytes);
            ms.Position = 0;

            Attachment attachment = new Attachment(ms, report.Name + ".pdf");
            MailMessage msg = new MailMessage(from, to, subject, body);
            msg.Attachments.Add(attachment);
            //smtp host is the name or IP of the host computer used for sending the email
            string smtpHost = "255.255.255.0";
            SmtpClient client = new SmtpClient(smtpHost);
            client.Send(msg);
        }

        private void btnHedgeSettings_Click(object sender, EventArgs e)
        {

    //        ServicePointManager.ServerCertificateValidationCallback +=
    //(sender2, cert, chain, sslPolicyErrors) => true;
             
    //        using (var client = new HttpClient())
    //        {
    //            client.BaseAddress = new Uri(@"https://giintegration.cgb.com");
    //            client.DefaultRequestHeaders.Accept.Clear();
    //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //            //api/ContractSigner/GetESignatureProfile?agrisId=40042683
    //            var response = client.PostAsync(@"https://giintegration.cgb.com/api/Offer/UpdateOffer?offerId=38686f48-1a6c-e811-a960-005056a975ba&hedgeTradeId=161987", new StringContent("")).Result; 
    //            if (response.IsSuccessStatusCode)
    //            {
    //                MessageBox.Show("Success");
    //            }

    //        }
    //        //https://giintegration.cgb.com/api/Offer/UpdateOffer?offerId=38686f48-1a6c-e811-a960-005056a975ba&hedgeTradeId=161987
            frmHedgeSettings frmHedge = new frmHedgeSettings();
            frmHedge.ShowDialog(this);
            frmHedge.Dispose();
        }

        private void tbcOrder_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font f;
            //For background color
            Brush backBrush;
            //For forground color
            Brush foreBrush;
            foreBrush = Brushes.Black;
            f = e.Font;
            backBrush = new System.Drawing.SolidBrush(SystemColors.ButtonFace);
            try
            {
                //This construct will hell you to deside which tab page have current focus
                //to change the style.

                if (e.Index == 2)
                {
                    //This line of code will help you to change the apperance like size,name,style.
                    f = e.Font; //new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    
                    //f = new Font(e.Font, FontStyle.Bold);
                    if (GlobalStore.RiskPositionSetting == 1)
                    {
                        backBrush = new System.Drawing.SolidBrush(SystemColors.ButtonFace);
                        foreBrush = Brushes.Red;

                    }
                    else
                    {
                        backBrush = new System.Drawing.SolidBrush(SystemColors.ButtonFace);
                        foreBrush = Brushes.Black;
                    }


                }
                

                else
                {
                    //f = new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    //f = new Font(e.Font, FontStyle.Bold);
                    f = e.Font;
                    backBrush = new System.Drawing.SolidBrush(SystemColors.ButtonFace);
                    foreBrush = Brushes.Black;

                }

                //To set the alignment of the caption.
                string tabName = this.tbcOrder.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;

                //Thsi will help you to fill the interior portion of
                //selected tabpage.
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                Rectangle r = e.Bounds;
                r = new Rectangle(r.X, r.Y + 3, r.Width + 6, r.Height - 3);
                e.Graphics.DrawString(tabName, f, foreBrush, r, sf);


                sf.Dispose();
            }
            catch (Exception ex)
            {
                //mHedge_Log.WriteEntry(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSpreadLimits frmAdd = new frmSpreadLimits();
            frmAdd.ShowDialog();
            SetUpRiskPositions();
        }

        private void tmrRiskPosition_Tick(object sender, EventArgs e)
        {
            SetUpRiskPositions();
        }

        private void btnMoveMonthEndTrades_Click(object sender, EventArgs e)
        {
            frmMoveMonthEndTrades frmMove = new frmMoveMonthEndTrades();
            frmMove.Show();
            //RefreshOrderGrid();
        }

        private void btnAccountCompanySetup_Click(object sender, EventArgs e)
        {
            //frmAccountCommodityMaintenance frmAccounts = new frmAccountCommodityMaintenance();
            //frmAccounts.Show();
        }

        private void btnKC2Priced_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;
            String QuantitySent = "";
            String BS = "";
            String HedgeMonth = "";
            String HedgeYear = "";
            String HedgeMonthYear = "";
            String Price = "";

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            Int32 OrderNumber = 0;
            //// Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            //dr = drWheat3;
            //OrderNumber = Convert.ToInt32(drWheat3.CurrentItem.Controls["btnWheat3Edit"].Tag.ToString());
            OrderNumber = Convert.ToInt32(drKC2.CurrentItem.Controls["txtKC2CGBOrd"].Text.ToString());
            string Type = "";
            Type = drKC2.CurrentItem.Controls["txtKC2OrdType"].Text.ToString();

            /////////////////////////New code for Clone button//////////////////////
            if (drKC2.CurrentItem.Controls["txtKC2Buy"].Text.ToString() == "0.00")
            {
                QuantitySent = drKC2.CurrentItem.Controls["txtKC2Sell"].Text.ToString();
                BS = "B";
            }
            else
            {
                QuantitySent = drKC2.CurrentItem.Controls["txtKC2Buy"].Text.ToString();
                BS = "S";
            }
            Price = drKC2.CurrentItem.Controls["txtKC2Price"].Text.ToString();
            HedgeMonthYear = drKC2.CurrentItem.Controls["txtKC2Month"].Text.ToString();
            HedgeMonth = HedgeMonthYear.Substring(0, 1).ToString();
            HedgeMonth = HedgeMonth.Trim();
            HedgeYear = HedgeMonthYear.Substring(1, 3).ToString();
            HedgeYear = HedgeYear.Trim();
            PlaceCloneSingleOrder(2, QuantitySent, BS, HedgeMonth, HedgeYear, Price, 26);
        }

        private void btnKC2Clone_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            try
            {
                Int32 OrderNumber = Convert.ToInt32(drKC2.CurrentItem.Controls["txtKC2CGBOrd"].Text.ToString());
                string OrderType = drKC2.CurrentItem.Controls["txtKC2OrdType"].Text.ToString();
                if (OrderType == "SPR")
                {
                    ReviseOrderSpread(OrderNumber);
                }
                else
                {
                    ReviseOrder(OrderNumber);
                }
                //dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void KC2Order_Click(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
            try
            {
                // Microsoft.VisualBasic.PowerPacks.DataRepeater dr = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
                //dr = drWheat3;
                //Int32 OrderNumber = Convert.ToInt32(drWheat3.CurrentItem.Controls["btnWheat3Clone"].Tag.ToString());
                Int32 OrderNumber = Convert.ToInt32(drKC2.CurrentItem.Controls["txtKC2CGBOrd"].Text.ToString());
                string OrderType = drKC2.CurrentItem.Controls["txtKC2OrdType"].Text.ToString();
                if (OrderType == "SPR")
                {
                    ViewOrderSpread(OrderNumber);
                }
                else
                {
                    ViewOrder(OrderNumber);
                }
                //dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

 
        private void drKC2_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            if (e.DataRepeaterItem.Controls["txtKC2OrderID"].Text.ToString() == "0" || e.DataRepeaterItem.Controls["txtKC2OrderID"].Text.ToString() == "" ||
                 e.DataRepeaterItem.Controls["txtKC2OrderStatus"].Text.ToString() == "Rejected" ||
                 e.DataRepeaterItem.Controls["txtKC2OrderStatus"].Text.ToString() == "Cancelled")
                        {
                e.DataRepeaterItem.Controls["btnKC2Clone"].Enabled = false;

            }
            else
            {
                e.DataRepeaterItem.Controls["btnKC2Clone"].Enabled = true;

            }
            if ((e.DataRepeaterItem.Controls["txtKC2OrderID"].Text.ToString() != "0" && e.DataRepeaterItem.Controls["txtKC2OrderID"].Text.ToString() != "") &&
                (e.DataRepeaterItem.Controls["txtKC2OrderStatus"].Text.ToString() != "Filled" &&
                e.DataRepeaterItem.Controls["txtKC2OrderStatus"].Text.ToString() != "Rejected" &&
                e.DataRepeaterItem.Controls["txtKC2OrderStatus"].Text.ToString() != "Cancelled"))
            {
                e.DataRepeaterItem.Controls["txtKC2Price"].BackColor = Color.LightSkyBlue;

            }
            else
            {
                e.DataRepeaterItem.Controls["txtKC2Price"].BackColor = Color.WhiteSmoke;
            }

            if (e.DataRepeaterItem.Controls["txtKC2OrdType"].Text.ToString() == "CH")
            {
                e.DataRepeaterItem.Controls["txtKC2OrdType"].BackColor = Color.Cornsilk;
                e.DataRepeaterItem.Controls["btnKC2Edit"].Enabled = true;
                e.DataRepeaterItem.Controls["btnKC2Priced"].Enabled = true;

            }
            else
            {
                e.DataRepeaterItem.Controls["txtKC2OrdType"].BackColor = Color.WhiteSmoke;
                e.DataRepeaterItem.Controls["btnKC2Edit"].Enabled = false;
                e.DataRepeaterItem.Controls["btnKC2Priced"].Enabled = false;
            }
        }

        private void drKC2_MouseEnter(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Interval = 15000;

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void drKC2_MouseLeave(object sender, EventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Stop();
            tmrPosition.Interval = 15000;
            tmrPosition.Start();

            tmrRegionOrders.Interval = 600;
            tmrECorders.Interval = 10000;
        }

        private void drKC2_Scroll(object sender, ScrollEventArgs e)
        {
            tmrOrders.Interval = 10000;
            tmrRegionOrders.Interval = 600;
            tmrVCF.Interval = 10000;
            tmrPosition.Stop();
            tmrPosition.Interval = 30000;
            tmrPosition.Start();
            tmrECorders.Interval = 10000;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            
            if (frmReports == null)
            {
                frmReports = new frmReports();
                frmReports.FormClosed += frmReports_Closed;
                frmReports.Show(this);
            }
            else
            {
                frmReports.Focus();
                frmReports.BringToFront();
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {

            if (frmOptions == null)
            {
                frmOptions = new frmOptions();
                frmOptions.FormClosed += frmOptions_Closed;
                frmOptions.Show(this);
            }
            else
            {
                frmOptions.Focus();
                frmOptions.BringToFront();
            }
        }

        private void cboAccount_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            mLoading = true;

            cboAccount.SelectedValue = -1;
            cboAccount.Text = "";
            this.cboTradingCompanies.SelectedValue = -1;
            cboTradingCompanies.Text = "";
            cboCommodities.SelectedValue = -1;
            cboCommodities.Text = "";
            this.cboMonths.SelectedValue = -1;
            cboMonths.Text = "";
            this.cboFilterVC.SelectedValue = -1;
            this.cboOrderType.SelectedValue = -1;
            cboOrderType.Text = "";
            this.txtYR.Text = "";

            FilterBSOrders();

            mLoading = false;
        }


        private void cboTradingCompanies_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void cboOrderType_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void cboOrderType_KeyDown(object sender, KeyEventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void cboAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void cboTradingCompanies_KeyDown(object sender, KeyEventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void btnReFilter_Click(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    FilterBSOrders();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }

        private void btnOrderFills_Click(object sender, EventArgs e)
        {
            if (frmOrderFills == null)
            {
                frmOrderFills = new frmOrderFills();
                frmOrderFills.FormClosed += frmOrderFills_Closed;
                frmOrderFills.Show(this);
            }
            else
            {
                frmOrderFills.Focus();
                frmOrderFills.BringToFront();
            }

        }

        private void btnActivateUsers_Click(object sender, EventArgs e)
        {
            if (frmKillSwitch == null)
            {
                frmKillSwitch = new frmKillSwitch();
                frmKillSwitch.FormClosed += frmKillSwitch_Closed;
                frmKillSwitch.Show(this);
            }
            else
            {
                frmKillSwitch.Focus();
                frmKillSwitch.BringToFront();
            }
        }

        private void lvCorn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSetNetEquity_Click(object sender, EventArgs e)
        {
            if (!mLoading)
            {
                try
                {
                    Maintenance maintenance = new Maintenance();
                    maintenance.SetNetEquity();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                    //mHedge_Log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                }
            }
        }
    }

}
public class AutoCompleteComboBox : System.Windows.Forms.ComboBox
{
    public event System.ComponentModel.CancelEventHandler NotInList;

    private bool strict = true;
    private bool isEditing = false;

    public AutoCompleteComboBox()
        : base()
    {
    }

    public bool Strict
    {
        get { return strict; }
        set { strict = value; }
    }

    protected virtual void OnNotInList(System.ComponentModel.CancelEventArgs e)
    {
        if (NotInList != null)
        {
            NotInList(this, e);
        }
    }

    protected override void OnTextChanged(System.EventArgs e)
    {
        if (isEditing)
        {
            string input = Text;
            int index = this.FindString(input);

            if (index >= 0)
            {
                isEditing = false;
                SelectedIndex = index;
                isEditing = true;
                Select(input.Length, Text.Length);
            }
        }

        base.OnTextChanged(e);
    }

    protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
    {
        if (this.Strict)
        {
            int pos = this.FindStringExact(this.Text);

            if (pos == -1)
            {
                OnNotInList(e);
            }
            else
            {
                this.SelectedIndex = pos;
            }
        }

        base.OnValidating(e);
    }

    protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
    {
        isEditing = (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete);
        base.OnKeyDown(e);
    }
}





public class dgvCustom : System.Windows.Forms.DataGridView
{

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
    {
        if (keyData == Keys.Return | keyData == Keys.Tab)
        {
            if (CurrentCellAddress.X == ColumnCount - 1)
            {
                keyData = Keys.Cancel;
                {
                    msg.WParam = (IntPtr)Keys.Cancel;
                }
            }
            else
            {
                keyData = Keys.Tab;
                {
                    msg.WParam = (IntPtr)Keys.Tab;
                }
            }
        }


        if (keyData == (Keys.Shift | Keys.Tab))
        {
            if (CurrentCellAddress.X == 0)
            {
                keyData = Keys.Cancel;
                {
                    msg.WParam = (IntPtr)Keys.Cancel;
                }
            }
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
    {

        if (keyData == Keys.Return | keyData == Keys.Tab)
        {
            if (CurrentCellAddress.X == ColumnCount - 1)
            {
                keyData = Keys.Cancel;
            }
            else
            {
                keyData = Keys.Tab;
            }
        }
        if (keyData == Keys.Delete)
        {
            keyData = Keys.Back;

        }

        if (keyData == (Keys.Shift | Keys.Tab))
        {
            if (CurrentCellAddress.X == 0)
            {
                keyData = Keys.Cancel;
            }
        }

        return base.ProcessDialogKey(keyData);
    }

}

public class dgvCustomVCF : System.Windows.Forms.DataGridView
{

    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
    {
        try
        {
            HedgedeskApplication.GlobalStore.setIsRowChanged(false);
            string myControl = "";
            myControl = this.CurrentCell.GetType().ToString();
            if (keyData == Keys.Return && myControl == "System.Windows.Forms.DataGridViewButtonCell")
            {
                keyData = Keys.Enter;
                {
                    HedgedeskApplication.GlobalStore.setIsRowChanged(true);
                    msg.WParam = (IntPtr)Keys.Enter;
                }
            }

            else if (keyData == Keys.Return | keyData == Keys.Tab)
            {
                if (CurrentCellAddress.X == ColumnCount - 1)
                {
                    keyData = Keys.Cancel;
                    {
                        msg.WParam = (IntPtr)Keys.Cancel;
                    }
                }
                else
                {
                    keyData = Keys.Tab;
                    {
                        msg.WParam = (IntPtr)Keys.Tab;
                    }
                }
            }


            if (keyData == (Keys.Shift | Keys.Tab))
            {
                if (CurrentCellAddress.X == 0)
                {
                    keyData = Keys.Cancel;
                    {
                        msg.WParam = (IntPtr)Keys.Cancel;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
    {

        if (keyData == Keys.Return | keyData == Keys.Tab)
        {
            if (CurrentCellAddress.X == ColumnCount - 1)
            {
                keyData = Keys.Cancel;
            }
            else
            {
                keyData = Keys.Tab;
            }
        }

        if (keyData == (Keys.Shift | Keys.Tab))
        {
            if (CurrentCellAddress.X == 0)
            {
                keyData = Keys.Cancel;
            }
        }

        return base.ProcessDialogKey(keyData);
    }

}




