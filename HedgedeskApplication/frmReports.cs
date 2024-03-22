using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using HedgedeskApplication.Classes;
using Telerik.Reporting.Processing;

namespace HedgedeskApplication
{
    public partial class frmReports : Form
    {
        public String ReportName = "";
        public Boolean mLoading = false;
        public DataTable table = new DataTable();

        public frmReports()
        {
            GlobalStore.mdtMonths.Clear();
            GlobalStore.mdtAccounts.Clear();
            InitializeComponent();
            rvHedgedesk.Top = 3;
            rvHedgedesk.Height = 635;
            grpParameters.Visible = false;
            GlobalStore.FillAccountsDataTable();
            GlobalStore.FillMonthsDataTable();
            GlobalStore.FillFuturesPositionGroupsDataTable();
                
        }



        private void tvReports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (mLoading != true)
            {
                AfterSelect(e.Node.Name);

            }
        }

        private void AfterSelect(string NodeName)
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
            DataTable dtFuturesPositionGroup = new DataTable();
            dtFuturesPositionGroup = GlobalStore.mdtFuturesPositionGroup.Copy();



            Maintenance clsMaintanance = new Maintenance();
            DataTable dtHedgeAccounts = new DataTable();
            clsMaintanance.GetHedgeAccounts(dtHedgeAccounts);
            var reportName = "";
            if (tvReports.SelectedNode.Tag != null)
            {
                reportName = tvReports.SelectedNode.Tag.ToString();
            }
            if (reportName == "")
            {
                reportName = tvReports.SelectedNode.Name.ToString();
            }
            switch (NodeName)
            {

                case "tcFuturesConfirmations":
                    ReportName = "tcFuturesConfirmations";
                    rvHedgedesk.Top = 119;
                    this.cboParamAccount.DataSource = dtDailyAccount;
                    cboParamAccount.DisplayMember = "TP_ACCT";
                    cboParamAccount.ValueMember = "TP_ACCT";
                    cboParamAccount.SelectedIndex = -1;
                    this.cboParamCompany.DataSource = dtDailyCompanies;
                    cboParamCompany.DisplayMember = "CompanyID";
                    cboParamCompany.ValueMember = "CompanyID";
                    cboParamCompany.SelectedIndex = -1;
                    HideGroups();
                   
                    grpParameters.Visible = true;
                    rvHedgedesk.Height = 519;

                    break;
                case "DailySettlementReport":
                    ReportName = "DailySettlementReport";
                    rvHedgedesk.Top = 119;
                    this.cboDailyAcct.DataSource = dtDailyAccount;
                    cboDailyAcct.DisplayMember = "TP_ACCT";
                    cboDailyAcct.ValueMember = "TP_ACCT";
                    cboDailyAcct.SelectedIndex = -1;
                    this.cboDailyComp.DataSource = dtDailyCompanies;
                    cboDailyComp.DisplayMember = "CompanyID";
                    cboDailyComp.ValueMember = "CompanyID";
                    cboDailyComp.SelectedIndex = -1;
                    HideGroups();

                    grpDailySettlement.Visible = true;
                    //grpDailyPosition.Visible = false;
                    //grpOptionParamters.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpPostionsGrouped.Visible = false;
                    //grpCHConfirm.Visible = false;
                    rvHedgedesk.Height = 519;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;

                case "MonthlySettlementReport":
                    ReportName = "MonthlySettlementReport";
                    rvHedgedesk.Top = 119;
                    this.cboMonAccSettle.DataSource = dtDailyAccount;
                    cboMonAccSettle.DisplayMember = "TP_ACCT";
                    cboMonAccSettle.ValueMember = "TP_ACCT";
                    cboMonAccSettle.SelectedIndex = -1;
                    this.cboMonCoSettle.DataSource = dtDailyCompanies;
                    cboMonCoSettle.DisplayMember = "CompanyID";
                    cboMonCoSettle.ValueMember = "CompanyID";
                    cboMonCoSettle.SelectedIndex = -1;
                    HideGroups();

                    grpMonthlySettlement.Visible = true;
                    //grpDailyPosition.Visible = false;
                    //grpOptionParamters.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpPostionsGrouped.Visible = false;
                    //grpCHConfirm.Visible = false;
                    rvHedgedesk.Height = 519;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;
                case "CHConfirms":
                    ReportName = "CHConfirms";
                    rvHedgedesk.Top = 119;
                    //grpParameters.Visible = false;
                    //grpDailyPosition.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpPostionsGrouped.Visible = false;
                    //grpOptionParamters.Visible = false;
                    HideGroups();
                    grpCHConfirm.Visible = true;

                    rvHedgedesk.Height = 519;
                    chkLiveReport.Checked = true;
                    chkLiveReport.Enabled = true;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;

                case "MarginCallReport":
                    ReportName = "MarginCallReport";
                    rvHedgedesk.Top = 119;
                    foreach (Control c in this.Controls)
                    {
                        if (c.Name.Contains("grp"))
                        {
                            c.Visible = false;
                        }
                    }
                    //grpParameters.Visible = false;
                    //grpDailyPosition.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpPostionsGrouped.Visible = false;
                    //grpOptionParamters.Visible = false;
                    grpRunOnly.Visible = true;
                    rvHedgedesk.Height = 519;
                    chkLiveReport.Checked = true;
                    chkLiveReport.Enabled = true;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;

                case "CHSalesConfirms":
                    ReportName = "CHSalesConfirms";
                    rvHedgedesk.Top = 119;
                    //grpParameters.Visible = false;
                    //grpDailyPosition.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpPostionsGrouped.Visible = false;
                    //grpOptionParamters.Visible = false;
                    HideGroups();
                    grpCHConfirm.Visible = true;
                    rvHedgedesk.Height = 519;
                    chkLiveReport.Checked = true;
                    chkLiveReport.Enabled = true;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;

                case "rptDailyFuturesPositionReport":
                    ReportName = "rptDailyFuturesPostionReport";

                    SetUpPositionReports(ReportName);
                    this.cboDailyCompany.Visible = true;
                    this.cboDailyAccount.Visible = true;
                    lblcboDailyCompany.Visible = true;
                    lblcboDailyAccount.Visible = true;
                    break;

                case "DailyFuturesPositionGrouped":
                    ReportName = "rptDailyFuturesPostionReportGrouped";

                    rvHedgedesk.Top = 119;
                    this.cboFuturesPositionGrouped.DataSource = dtFuturesPositionGroup;
                    cboFuturesPositionGrouped.DisplayMember = "FuturesPositionGroup";
                    cboFuturesPositionGrouped.ValueMember = "FuturesPositionGroupID";
                    cboFuturesPositionGrouped.SelectedIndex = -1;
                    HideGroups();
                    //grpParameters.Visible = false;
                    //grpDailyPosition.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpOptionParamters.Visible = false;
                    grpPostionsGrouped.Visible = true;
                    //grpCHConfirm.Visible = false;
                    rvHedgedesk.Height = 519;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.DailyFuturesPositionReportByGroup(;
                    //this.rvHedgedesk.RefreshReport();
                    break;

                case "DailyFuturesPositionDetail":
                    ReportName = "rptDailyFuturesPostionReportGroupedDetail";

                    rvHedgedesk.Top = 119;
                    this.cboFuturesPositionGrouped.DataSource = dtFuturesPositionGroup;
                    cboFuturesPositionGrouped.DisplayMember = "FuturesPositionGroup";
                    cboFuturesPositionGrouped.ValueMember = "FuturesPositionGroupID";
                    cboFuturesPositionGrouped.SelectedIndex = -1;
                    HideGroups();
                    //grpParameters.Visible = false;
                    //grpDailyPosition.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpOptionParamters.Visible = false;
                    grpPostionsGrouped.Visible = true;
                    //grpCHConfirm.Visible = false;
                    rvHedgedesk.Height = 519;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.DailyFuturesPositionReportByGroup(;
                    //this.rvHedgedesk.RefreshReport();
                    break;
                case "LedgerBalanceReport":
                    SetUpLedgerReports(reportName);
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;
                case "ReconciliationByCompany":
                   SetUpLedgerReports(reportName);
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;
                case "ReconciliationByCommodity":
                    SetUpLedgerReports(reportName);
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;

                case "RatioPositionReport":
                    SetUpPositionReports(reportName);
                    this.cboDailyCompany.Visible = false;
                    this.cboDailyAccount.Visible = false;
                    lblcboDailyCompany.Visible = false;
                    lblcboDailyAccount.Visible = false;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;


                case "rptOptionsOpenPosition":
                    ReportName = "rptOptionOpenPosition";
                    cboHedgebookAccount.DataSource = dtHedgeAccounts;
                    cboHedgebookAccount.DisplayMember = "UserName";
                    cboHedgebookAccount.ValueMember = "UserID";
                    rvHedgedesk.Top = 119;
                    HideGroups();
                    //grpParameters.Visible = false;
                    //grpDailyPosition.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpPostionsGrouped.Visible = false;
                    grpOptionParamters.Visible = true;
                    //grpCHConfirm.Visible = false;
                    this.chkAllDate.Visible = true;
                    this.chkSelectTradeDate.Visible = true;
                    this.dtTradeDate.Visible = true;
                    this.lblTradeDate.Visible = true;
                    this.dtExpiration.Visible = true;
                    this.lblExpiration.Visible = true;
                    chkAllDate.Checked = true;
                    chkSelectAllAccount.Checked = true;
                    chkSelectTradeDate.Checked = true;
                    rvHedgedesk.Height = 519;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;
                case "rptOptionsTotalToday":
                    ReportName = "rptOptionTotalToday";
                    rvHedgedesk.Top = 119;
                    HideGroups();
                    //grpParameters.Visible = false;
                    //grpDailyPosition.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpPostionsGrouped.Visible = false;
                    grpOptionParamters.Visible = true;
                    //grpCHConfirm.Visible = false;

                    cboHedgebookAccount.DataSource = dtHedgeAccounts;
                    cboHedgebookAccount.DisplayMember = "UserName";
                    cboHedgebookAccount.ValueMember = "UserID";
                    chkAllDate.Checked = true;
                    chkSelectAllAccount.Checked = true;
                    this.chkAllDate.Visible = false;
                    this.chkSelectTradeDate.Visible = false;
                    this.dtExpiration.Visible = false;
                    this.lblExpiration.Visible = false;
                    this.chkSelectTradeDate.Visible = false;
                    this.dtTradeDate.Visible = false;
                    this.lblTradeDate.Visible = false;
                    rvHedgedesk.Height = 519;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;

                case "rptOptionConfirmationMaster":
                    ReportName = "rptOptionConfirmationMaster";
                    rvHedgedesk.Top = 119;
                    HideGroups();
                    //grpParameters.Visible = false;
                    //grpDailyPosition.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpPostionsGrouped.Visible = false;
                    grpOptionParamters.Visible = true;
                    //grpCHConfirm.Visible = false;

                    cboHedgebookAccount.DataSource = dtHedgeAccounts;
                    cboHedgebookAccount.DisplayMember = "UserName";
                    cboHedgebookAccount.ValueMember = "UserID";
                    chkAllDate.Checked = true;
                    chkSelectAllAccount.Checked = true;
                    chkSelectTradeDate.Checked = true;
                    this.chkAllDate.Visible = false;
                    this.dtExpiration.Visible = false;
                    this.lblExpiration.Visible = false;
                    this.chkSelectTradeDate.Visible = false;
                    this.dtTradeDate.Visible = false;
                    this.lblTradeDate.Visible = false;
                    rvHedgedesk.Height = 519;
                    //this.rvHedgedesk.Report = new HedgedeskReportProject.FuturesComfirmationReport("5/22/2012", 0, 0);
                    //this.rvHedgedesk.RefreshReport();
                    break;
                default:
                    rvHedgedesk.Top = 3;
                    rvHedgedesk.Height = 635;
                    //grpParameters.Visible = false;
                    //grpDailyPosition.Visible = false;
                    //grpParametersLedger.Visible = false;
                    //grpPostionsGrouped.Visible = false;
                    //grpOptionParamters.Visible = false;
                    //grpCHConfirm.Visible = false;
                    HideGroups();
                    break;

            }
        }

        private void HideGroups()
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name.Contains("grp"))
                {
                    c.Visible = false;
                }
            }
        }

        private void SetUpLedgerReports(string reportName)
        {
            DataTable dtDailyAccount = new DataTable();
            dtDailyAccount = GlobalStore.mdtAccounts.Copy();
            DataTable dtDailyCommodities = new DataTable();

            dtDailyCommodities = GlobalStore.mdtCommodity.Copy();
            DataTable dtDailyCompanies = new DataTable();
            dtDailyCompanies = GlobalStore.mdtComps.Copy();

            ReportName = reportName;
            this.cboLedgerAccounts.DataSource = dtDailyAccount;
            cboLedgerAccounts.DisplayMember = "TP_ACCT";
            cboLedgerAccounts.ValueMember = "TP_ACCT";
            cboLedgerAccounts.SelectedIndex = -1;
            cboLedgerCompanies.DataSource = dtDailyCompanies;
            cboLedgerCompanies.DisplayMember = "CompanyID";
            cboLedgerCompanies.ValueMember = "CompanyID";
            cboLedgerCompanies.SelectedIndex = -1;


            this.dtpLastSettlementDate.Format = DateTimePickerFormat.Custom;
            dtpLastSettlementDate.CustomFormat = "MM/dd/yyyy";
            dtpLastSettlementDate.Value = PreviousWorkDay(DateTime.Today.AddDays(-1));

            rvHedgedesk.Top = 119;
            grpParameters.Visible = false;
            grpDailyPosition.Visible = false;
            grpParametersLedger.Visible = true;
            grpPostionsGrouped.Visible = false;
            grpOptionParamters.Visible = false;
            grpCHConfirm.Visible = false;
            rvHedgedesk.Height = 519;
        }

        private void SetUpPositionReports(string reportName)
        {

            DataTable dtDailyAccount = new DataTable();
            dtDailyAccount = GlobalStore.mdtAccounts.Copy();
            DataTable dtDailyCommodities = new DataTable();
            dtDailyCommodities = GlobalStore.mdtCommodity.Copy();
            DataTable dtDailyCompanies = new DataTable();
            dtDailyCompanies = GlobalStore.mdtComps.Copy();
            DataTable dtDailyMonths = new DataTable();
            dtDailyMonths = GlobalStore.mdtMonths.Copy();
            DataTable dtFuturesPositionGroup = new DataTable();
            dtFuturesPositionGroup = GlobalStore.mdtFuturesPositionGroup.Copy();

            
            ReportName = reportName;
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
            grpDailyPosition.Visible = true;
            grpParametersLedger.Visible = false;
            grpOptionParamters.Visible = false;
            grpPostionsGrouped.Visible = false;
            grpCHConfirm.Visible = false;
            rvHedgedesk.Height = 519;

        }
        private void btnRunReport_Click(object sender, EventArgs e)
        {
            RunReport();
        }


        private DateTime PreviousWorkDay(DateTime date)
        {
            do { date = date.AddDays(-1); }
            while (Holiday.IsHoliday(date) || IsWeekend(date));

            return date;
      
         
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday;
        }
 
        private void RunReport()
        {
            int Commodity = 0;
            int Account = 0;
            int Company = 0;
            int Year = 0;
            int PositionGroup = 0;
            String Month = "";
            int Live =0;
            string dtExpire = "";
            int HedgeUserID = 0;
            string dtTrade = "";

            switch (ReportName)
            {

                case "tcFuturesConfirmations":


                    if (this.cboParamAccount.Text == "")
                    {
                        Account = 0;
                    }
                    else if (cboParamAccount.SelectedValue.ToString() == "")
                    {
                        Account = Convert.ToInt32(cboParamAccount.Text);
                    }
                    else
                    {
                        Account = Convert.ToInt32(cboParamAccount.SelectedValue.ToString());
                    }
                    if (this.cboParamCompany.Text == "")
                    {
                        Company = 0;
                    }
                    else if (cboParamCompany.SelectedValue.ToString() == "")
                    {
                        Company = Convert.ToInt32(cboParamCompany.Text);
                    }
                    else
                    {
                        Company = Convert.ToInt32(cboParamCompany.SelectedValue.ToString());
                    }


                    this.rvHedgedesk.ReportSource = new HedgedeskReportProject.FuturesComfirmationReport(dtpOrderDate.Value.ToShortDateString(), Company, Account);
                    this.rvHedgedesk.RefreshReport();
                    break;

                case "DailySettlementReport":


                    if (this.cboDailyAcct.Text == "")
                    {
                        Account = 0;
                    }
                    else if (cboDailyAcct.SelectedValue.ToString() == "")
                    {
                        Account = Convert.ToInt32(cboDailyAcct.Text);
                    }
                    else
                    {
                        Account = Convert.ToInt32(cboDailyAcct.SelectedValue.ToString());
                    }
                    if (this.cboDailyComp.Text == "")
                    {
                        Company = 0;
                    }
                    else if (cboDailyComp.SelectedValue.ToString() == "")
                    {
                        Company = Convert.ToInt32(cboDailyComp.Text);
                    }
                    else
                    {
                        Company = Convert.ToInt32(cboDailyComp.SelectedValue.ToString());
                    }


                    this.rvHedgedesk.ReportSource = new HedgedeskReportProject.DailySettlementReport(dtSettleDaily.Value.ToShortDateString(), Company, Account);
                    this.rvHedgedesk.RefreshReport();

                    break;

                case "MonthlySettlementReport":


                    if (this.cboMonAccSettle.Text == "")
                    {
                        Account = 0;
                    }
                    else if (cboMonAccSettle.SelectedValue.ToString() == "")
                    {
                        Account = Convert.ToInt32(cboMonAccSettle.Text);
                    }
                    else
                    {
                        Account = Convert.ToInt32(cboMonAccSettle.SelectedValue.ToString());
                    }
                    if (this.cboMonCoSettle.Text == "")
                    {
                        Company = 0;
                    }
                    else if (cboMonCoSettle.SelectedValue.ToString() == "")
                    {
                        Company = Convert.ToInt32(cboMonCoSettle.Text);
                    }
                    else
                    {
                        Company = Convert.ToInt32(cboMonCoSettle.SelectedValue.ToString());
                    }


                    this.rvHedgedesk.ReportSource = new HedgedeskReportProject.MonthlySettlementReport(Account, Company, dtSettleStart.Value.ToShortDateString(), dtSettleEnd.Value.ToShortDateString());
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "MarginCallReport":
                    this.rvHedgedesk.ReportSource = new HedgedeskReportProject.MarginCallReport();
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "CHSalesConfirms":
                    if (this.chkLiveReport.Checked)
                    {
                        Live = 1;
                    }
                    this.rvHedgedesk.ReportSource = new HedgedeskReportProject.CentralHedgeSalesComfirmationReport(Live, this.dtDateTimeCH.Value.ToShortDateString());
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "CHConfirms":

                    if (this.chkLiveReport.Checked)
                    {
                        Live = 1;
                    }
                    this.rvHedgedesk.ReportSource = new HedgedeskReportProject.CentralHedgeComfirmationReport(this.dtDateTimeCH.Value.ToShortDateString(), Live);
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "rptDailyFuturesPostionReport":

                    RunPositionReport(ReportName);
                    break;
                case "RatioPositionReport":

                    RunPositionReport(ReportName);
                    break;

                case "rptDailyFuturesPostionReportGrouped":


                    if (this.cboFuturesPositionGrouped.Text == "")
                    {
                        PositionGroup = 0;
                    }
                    else
                    {
                        PositionGroup = Convert.ToInt32(this.cboFuturesPositionGrouped.SelectedValue.ToString());
                    }

                    this.rvHedgedesk.Report = new HedgedeskReportProject.DailyFuturesPositionReportGrouped(PositionGroup);
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "rptDailyFuturesPostionReportGroupedDetail":


                    if (this.cboFuturesPositionGrouped.Text == "")
                    {
                        PositionGroup = 0;
                    }
                    else
                    {
                        PositionGroup = Convert.ToInt32(this.cboFuturesPositionGrouped.SelectedValue.ToString());
                    }

                    this.rvHedgedesk.Report = new HedgedeskReportProject.DailyFuturesPositionReportGroupedDetail(PositionGroup);
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "rptLedgerBalanceReport":
                    SetupRunForLedgerReports(ReportName);
                    break;
                case "ReconciliationReport_ByComm":
                    SetupRunForLedgerReports(ReportName);
                    break;
                case "ReconciliationReport_ByComp":
                    SetupRunForLedgerReports(ReportName);
                    break;
                case "rptOptionOpenPosition":

                    if (this.dtTradeDate.Value.ToShortDateString() != "")
                    {
                        dtTrade = dtTradeDate.Value.ToShortDateString();
                    }

                    if (this.dtExpiration.Value.ToShortDateString() != "")
                    {
                        dtExpire = dtExpiration.Value.ToShortDateString();
                    }
                    if (this.cboHedgebookAccount.SelectedIndex == -1)
                    {
                        HedgeUserID = 0;
                    }
                    else
                    {
                        HedgeUserID = Convert.ToInt32(cboHedgebookAccount.SelectedValue.ToString());
                    }


                    this.rvHedgedesk.Report = new HedgedeskReportProject.OptionOpenPosition(dtExpire, HedgeUserID, dtTrade);
                    this.rvHedgedesk.RefreshReport();
                    break;

                case "rptOptionTotalToday":


                    if (this.cboHedgebookAccount.SelectedIndex == -1)
                    {
                        HedgeUserID = 0;
                    }
                    else
                    {
                        HedgeUserID = Convert.ToInt32(cboHedgebookAccount.SelectedValue.ToString());
                    }

                    this.rvHedgedesk.Report = new HedgedeskReportProject.OptionsTradedToday(HedgeUserID);
                    this.rvHedgedesk.RefreshReport();
                    break;


                case "rptOptionConfirmationMaster":


                    if (this.cboHedgebookAccount.SelectedIndex == -1)
                    {
                        HedgeUserID = 0;
                    }
                    else
                    {
                        HedgeUserID = Convert.ToInt32(cboHedgebookAccount.SelectedValue.ToString());
                    }

                    this.rvHedgedesk.Report = new HedgedeskReportProject.rptOptionsConfirmationMaster(HedgeUserID);
                    this.rvHedgedesk.RefreshReport();
                    break;
                default:
                    break;


            }
        }


        private void SetupRunForLedgerReports(string reportName)
        {
            var Account = 0;
            var Company = 0;
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
            switch (reportName)
            {
                case "rptLedgerBalanceReport":
                    this.rvHedgedesk.Report = new HedgedeskReportProject.LedgerBalanceReport(dtpLastSettlementDate.Value.ToShortDateString(), Company, Account);
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "ReconciliationReport_ByComm":
                    this.rvHedgedesk.Report = new HedgedeskReportProject.ReconciliationReport_ByComm(dtpLastSettlementDate.Value.ToShortDateString(), Company, Account);
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "ReconciliationReport_ByComp":
                    this.rvHedgedesk.Report = new HedgedeskReportProject.ReconciliationReport_ByComp(dtpLastSettlementDate.Value.ToShortDateString(), Company, Account);
                    this.rvHedgedesk.RefreshReport();
                    break;
            }

            
        }

        private void RunPositionReport(string reportName)
        {
            int Commodity = 0;
            int Account = 0;
            int Company = 0;
            int Year = 0;
            int PositionGroup = 0;
            String Month = "";
            int Live = 0;
            string dtExpire = "";
            int HedgeUserID = 0;
            string dtTrade = "";

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

            switch (reportName)
            {
                case "rptDailyFuturesPostionReport":
                    this.rvHedgedesk.Report = new HedgedeskReportProject.DailyFuturesPositionReportByGroup(Company, Account, Commodity, Month, Year);
                    this.rvHedgedesk.RefreshReport();
                    break;
                case "RatioPositionReport":
                    this.rvHedgedesk.Report = new HedgedeskReportProject.RatioPositionReport(Commodity, Month, Year);
                    this.rvHedgedesk.RefreshReport();
                    break;
                
            }
            
        }
        private void btnDailyFuturesPosition_Click(object sender, EventArgs e)
        {
            RunReport();
        }


        private void btnLedgerReport_Click(object sender, EventArgs e)
        {

            RunReport();
            //this.rvHedgedesk.Report = new HedgedeskReportProject.LedgerBalanceReport(this.dtpLastSettlementDate.Value.ToShortDateString(), 0, 0);
            //this.rvHedgedesk.RefreshReport();
        }

        private void btnFuturesPositionReport_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void btnRunCHReport_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void chkLiveReport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLiveReport.Checked)
            {
                dtDateTimeCH.Value = DateTime.Today;
                dtDateTimeCH.Enabled = false;
            }
            else
            {
                dtDateTimeCH.Enabled = true;
            }
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            if(ReportName != "")
            {
                mLoading = true;
                AfterSelect(ReportName);
            }
        }

        private void chkAllDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllDate.Checked == false)
            {
                this.dtExpiration.Format = DateTimePickerFormat.Custom;
                dtExpiration.CustomFormat = "MM/dd/yyyy";
                dtExpiration.Value = DateTime.Today;
                this.dtExpiration.Enabled = true;
            }
            else
            {
                this.dtExpiration.Format = DateTimePickerFormat.Custom;
                dtExpiration.CustomFormat = " ";
                //dtExpiration.Value = DateTime.;
                this.dtExpiration.Enabled = false;

            }
        }

        private void chkSelectAllAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAllAccount.Checked == true)
            {
                this.cboHedgebookAccount.SelectedIndex = -1;
                this.cboHedgebookAccount.Enabled = false;
            }
            else
            {
                this.cboHedgebookAccount.SelectedIndex = 0;
                this.cboHedgebookAccount.Enabled = true;
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void chkSelectTradeDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllDate.Checked == false)
            {
                this.dtTradeDate.Format = DateTimePickerFormat.Custom;
                dtTradeDate.CustomFormat = "MM/dd/yyyy";
                dtTradeDate.Value = DateTime.Today;
                this.dtTradeDate.Enabled = true;
            }
            else
            {
                this.dtTradeDate.Format = DateTimePickerFormat.Custom;
                dtTradeDate.CustomFormat = " ";
                //dtExpiration.Value = DateTime.;
                this.dtTradeDate.Enabled = false;

            }
        }

        private void grpDailyPosition_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnMarginCall_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void btnDailySettlement_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void btnMonthlySettlement_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void btnDailySettlement_Click_1(object sender, EventArgs e)
        {
            RunReport();
        }

        private void grpDailySettlement_Enter(object sender, EventArgs e)
        {

        }

        private void btnSetNetEquity_Click(object sender, EventArgs e)
        {
            Maintenance maintenance = new Maintenance();
            MessageBox.Show(@"Hedgedesk",
                maintenance.SetPreviousNetEquity() ? @"Previous Net Equity Set" : @"Previous Net Equity Failure",
                MessageBoxButtons.OK);
        }

        private void btnFuturesConfirmationEmail_Click(object sender, EventArgs e)
        {
            
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();

            Task emailPositionReports = Task.Factory
            .StartNew(() => GetEmailData(), TaskCreationOptions.LongRunning)
            .ContinueWith(_ => SendMail(), uiContext);
            
        }

        private void GetEmailData()
        {
            var obj = new Maintenance();
            this.table.Clear();
            table = obj.GetPSReportRoutingGroups();

        }

        private void SendMail()
        {

            foreach (DataRow c in table.Rows)

            {
                var account = Convert.ToInt32(c["TP_ACCT"].ToString());
                var company = Convert.ToInt32(c["TP_COMP"].ToString());
                var email = c["Email"].ToString();

                
                var instanceReportSource = new Telerik.Reporting.InstanceReportSource();
                instanceReportSource.ReportDocument =
                    new HedgedeskReportProject.FuturesComfirmationReport(dtpOrderDate.Value.ToShortDateString(), company,
                        account);

                ReportProcessor reportProcessor = new ReportProcessor();
                RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

                MemoryStream ms = new MemoryStream(result.DocumentBytes);
                ms.Position = 0;

                var subject = "Account: " + account.ToString() + " Company: " + company.ToString() +
                              " Daily Futures Confirmation Report";

                var body = "The attached document contains the Daily Futures Confirmation Report for Account: " +
                           account.ToString() + " Company: " + company.ToString() + " Report Date: " +
                           dtpOrderDate.Value.ToShortDateString();


                Attachment attachment = new Attachment(ms,
                    dtpOrderDate.Value.Year.ToString() + dtpOrderDate.Value.Month.ToString() +
                    dtpOrderDate.Value.Day.ToString() + account.ToString() + company.ToString() + ".pdf");
                MailMessage msg = new MailMessage("sqladmin@cgb.com", email, subject, body);

                msg.Attachments.Add(attachment);

                string smtpHost = "smtp2.cgb.com";
                SmtpClient client = new SmtpClient(smtpHost);

                client.SendCompleted += (s, f) =>
                {
                    msg.Dispose();
                };

                ThreadPool.QueueUserWorkItem(o =>
                    client.SendAsync(msg, HedgedeskApplication.Classes.Tuple.New(client, msg)));
            }

         MessageBox.Show("Futures Confirmation", "Email Sent", MessageBoxButtons.OK);
        }
    }
}



public class Tuple<T1, T2>
{
    public T1 First { get; private set; }
    public T2 Second { get; private set; }
    internal Tuple(T1 first, T2 second)
    {
        First = first;
        Second = second;
    }
}
