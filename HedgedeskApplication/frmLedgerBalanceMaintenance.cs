using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HedgedeskApplication
{
    public partial class frmLedgerBalanceMaintenance : Form
    {
        DataTable dtCommodities = new DataTable();
        DataTable dtClosingFutures = new DataTable();
        Maintenance clsMaintenance = new Maintenance();
        public DataView viewAccounts = new DataView();
        public DataView viewMonths = new DataView();
        public DataView viewCommodities = new DataView();
        public DataView viewOrdTypes = new DataView();
        public DataView viewCompanies = new DataView();
        DataTable dtBalances = new DataTable();
        DataTable dtMaintenance = new DataTable();
        DataTable dtDetail = new DataTable();
        int mColumnIndex;
        int mRowIndex;
        Boolean isNotValidated = false;
        Boolean isRowChanged = false;
        public frmLedgerBalanceMaintenance()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void LoadForm()
        {
            try
            {
                GlobalStore.FillAccountsDataTable();
                viewAccounts = GlobalStore.mdtAccounts.DefaultView;
                cboAcct.DataSource = GlobalStore.mdtAccounts.Copy();
                cboAcct.DisplayMember = "TP_ACCT";
                cboAcct.ValueMember = "TP_ACCT";
                cboAddAcct.DataSource = GlobalStore.mdtAccounts.Copy();
                cboAddAcct.DisplayMember = "TP_ACCT";
                cboAddAcct.ValueMember = "TP_ACCT";
                cboAddAcct.SelectedIndex = -1;

                viewCompanies = GlobalStore.mdtComps.DefaultView;
                cboAddComp.DataSource = GlobalStore.mdtComps.Copy();
                cboAddComp.DisplayMember = "CompanyID";
                cboAddComp.ValueMember = "CompanyID";
                cboAddComp.SelectedIndex = -1;


                cboDetailAccount.DataSource = GlobalStore.mdtAccounts.Copy();
                cboDetailAccount.DisplayMember = "TP_ACCT";
                cboDetailAccount.ValueMember = "TP_ACCT";
                cboDetailAccount.SelectedIndex = -1;

                cboDetailComp.DataSource = GlobalStore.mdtComps.Copy();
                cboDetailComp.DisplayMember = "CompanyID";
                cboDetailComp.ValueMember = "CompanyID";
                cboDetailComp.SelectedIndex = -1;

                this.cboMaintAcct.DataSource = GlobalStore.mdtAccounts.Copy();
                cboMaintAcct.DisplayMember = "TP_ACCT";
                cboMaintAcct.ValueMember = "TP_ACCT";
                cboMaintAcct.SelectedIndex = -1;

                cboMaintComp.DataSource = GlobalStore.mdtComps.Copy();
                cboMaintComp.DisplayMember = "CompanyID";
                cboMaintComp.ValueMember = "CompanyID";
                cboMaintComp.SelectedIndex = -1;

                cboComp.DataSource = GlobalStore.mdtComps.Copy();
                cboComp.DisplayMember = "CompanyID";
                cboComp.ValueMember = "CompanyID";
                cboComp.SelectedIndex = -1;
                cboAcct.SelectedIndex = -1;

                this.cboDetailComm.DataSource = GlobalStore.mdtCommodity.Copy();
                cboDetailComm.DisplayMember = "DESC";
                cboDetailComm.ValueMember = "TP_COMM";
                cboDetailComm.SelectedIndex = -1;

                dtBalances.Clear();
                clsMaintenance.GetLedgerBalanceAdjustments(0, 0, "", "", dtBalances);
                dgvLedgerBalance.AutoGenerateColumns = false;
                this.dgvLedgerBalance.DataSource = dtBalances;
                clsMaintenance.GetLedgerBalanceMaintenance(dtMaintenance);
                dgvLedgerMaintenance.AutoGenerateColumns = false;
                this.dgvLedgerMaintenance.DataSource = dtMaintenance;
                clsMaintenance.GetLedgerBalanceDetailMaintenance(dtDetail);
                dgvLedgerDetail.AutoGenerateColumns = false;
                this.dgvLedgerDetail.DataSource = dtDetail;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void FindOrders()
        {
            try
            {
                int Company = 0;
                int Account = 0;

                if (cboAcct.Text != "")
                {
                    Account = Convert.ToInt32(cboAcct.Text);
                }
                if (cboComp.Text != "")
                {
                    Company = Convert.ToInt32(cboComp.Text);
                }

                dtBalances.Clear();
                clsMaintenance.GetLedgerBalanceAdjustments(Company, Account, this.dtpTo.Value.ToShortDateString(), this.dtpFrom.Value.ToShortDateString(), dtBalances);
                dgvLedgerBalance.AutoGenerateColumns = false;
                this.dgvLedgerBalance.DataSource = dtBalances;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void FindMaintenanceOrders()
        {
            try
            {

                dtMaintenance.Clear();
                clsMaintenance.GetLedgerBalanceMaintenance(dtMaintenance);
                dgvLedgerMaintenance.AutoGenerateColumns = false;
                this.dgvLedgerMaintenance.DataSource = dtMaintenance;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FindDetailOrders()
        {
            try
            {

                dtDetail.Clear();
                clsMaintenance.GetLedgerBalanceDetailMaintenance(dtDetail);
                dgvLedgerDetail.AutoGenerateColumns = false;
                this.dgvLedgerDetail.DataSource = dtDetail;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }



        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            int MarginID = 0;
            //int col = 8;
            for (int row = 0; row < this.dgvLedgerBalance.Rows.Count; row++)
            {
                if (dgvLedgerBalance.Rows[row].Cells["chkDelete"].Value != null)
                {
                    if (dgvLedgerBalance.Rows[row].Cells["chkDelete"].Value.ToString() == "True")
                    {
                        //MessageID = dgvECOrders.Rows[row].Cells["MessageID"].Value.ToString();
                        MarginID = Convert.ToInt32(dgvLedgerBalance.Rows[row].Cells["MarginID"].Value.ToString());
                        //uLastPrice = dgvECOrders.Rows[row].Cells["uLastPrice"].Value.ToString();
                        //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
                        clsMaintenance.DeleteLedgerBalanceAdjustment(MarginID);

                    }
                }


                //dtTradingCompanies.Clear();
                //clsMaintenance.GetCommoditiesTradingCompaniesForEdit(dtTradingCompanies);
                //dgvCommodityTradingCompany.AutoGenerateColumns = false;
                //this.dgvCommodityTradingCompany.DataSource = dtTradingCompanies;
                //dgvCommodityTradingCompany.Refresh();
            }

            dtBalances.Clear();
            FindOrders();
            dgvLedgerBalance.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //int Company = 0;
                //int Account = 0;
                string ReturnMessage = "";

                if (cboAddAcct.Text == "")
                {
                    MessageBox.Show("Please choose an account.", "Ledger Balance");
                    return;

                }
                if (cboAddComp.Text == "")
                {
                    MessageBox.Show("Please choose a company.", "Ledger Balance");
                    return;
                }
                if (txtAdjustment.Text == "")
                {
                    MessageBox.Show("Please enter margin.", "Ledger Balance");
                    return;
                }

                if (this.dtpAddAdjustmentDate.Value.ToShortDateString() == "")
                {
                    MessageBox.Show("Please enter date.", "Ledger Balance");
                    return;
                }

                if (!clsMaintenance.AddLedgerBalanceAdjustment(Convert.ToInt32(cboAddComp.Text), Convert.ToInt32(cboAddAcct.Text), txtAdjustment.Text, this.dtpAddAdjustmentDate.Value.ToShortDateString(), txtComments.Text, ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage, "Ledger Balance");
                    return;
                }

                //dgvMarginBalance.AutoGenerateColumns = false;
                //this.dgvMarginBalance.DataSource = dtBalances;
                FindOrders();

                cboAddAcct.DataSource = GlobalStore.mdtAccounts.Copy();
                cboAddAcct.DisplayMember = "TP_ACCT";
                cboAddAcct.ValueMember = "TP_ACCT";
                cboAddAcct.SelectedIndex = -1;
                //viewCompanies = GlobalStore.mdtComps.DefaultView;
                cboAddComp.DataSource = GlobalStore.mdtComps.Copy();
                cboAddComp.DisplayMember = "CompanyID";
                cboAddComp.ValueMember = "CompanyID";
                cboAddComp.SelectedIndex = -1;

                txtAdjustment.Text = "";
                txtComments.Text = "";
                cboAddComp.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }




        private void Print_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Functionality not yet implemented.", "Margin Balance");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnFindOrders_Click(object sender, EventArgs e)
        {
            FindOrders();
        }



        private void dgvLedgerBalance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int MarginID = 0;

            if (dgvLedgerBalance.Columns[e.ColumnIndex].Name == "Delete")
            {
                Maintenance ordUpdate = new Maintenance();
                MarginID = Convert.ToInt32(dgvLedgerBalance.Rows[e.RowIndex].Cells["MarginID"].Value.ToString());
                if (ordUpdate.DeleteLedgerBalanceAdjustment(MarginID))
                {
                    FindOrders();
                }
                //                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                //                "0", isChecked, ref SelectedAmount);
            }
        }

        private void dgvLedgerBalance_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (isRowChanged == false)
            {
                mColumnIndex = dgvLedgerBalance.CurrentCell.ColumnIndex;
                mRowIndex = dgvLedgerBalance.CurrentCell.RowIndex;
            }
            isRowChanged = true;


        }

        private void dgvLedgerBalance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLedgerBalance_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            if (isRowChanged)
            {
                try
                {
                    if (dgvLedgerBalance.Columns[e.ColumnIndex].Name != "chkDelete" && dgvLedgerBalance.Columns[e.ColumnIndex].Name != "Delete")
                    {
                        dgvLedgerBalance.EndEdit();
                        string rIndex = dgvLedgerBalance.Rows[e.RowIndex].Index.ToString();
                        int riIndex = Convert.ToInt16(rIndex);
                        string Margin = "";
                        string Comments = "";
                        string Date = "";

                        Int32 MarginID = 0;
                        string ReturnMessage = "";

                        MarginID = Convert.ToInt32(dgvLedgerBalance.Rows[riIndex].Cells["MarginID"].Value.ToString());
                        Margin = dgvLedgerBalance.Rows[riIndex].Cells["MarginBal"].Value.ToString();
                        Comments = dgvLedgerBalance.Rows[riIndex].Cells["Comments"].Value.ToString();
                        Date = dgvLedgerBalance.Rows[riIndex].Cells["MarginDate"].Value.ToString();

                        if (!clsMaintenance.UpdateLedgerBalanceAdjustments(MarginID, Date, Margin, Comments, ref ReturnMessage))
                        {
                            MessageBox.Show(ReturnMessage, "Ledger Balance Maintenance");
                            isRowChanged = false;
                            isNotValidated = false;
                        }
                        else
                        {
                            FindOrders();
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ledger Balance Maintenance");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }

        }

        private void dgvLedgerBalance_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvLedgerBalance_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (isNotValidated)
                e.Cancel = true;

        }

        private void dgvLedgerBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvLedgerBalance.EndEdit();
                isRowChanged = false;
            }
        }

        private void frmLedgerBalanceMaintenance_Load(object sender, EventArgs e)
        {

            LoadForm();

        }

        private void dgvLedgerDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int MarginID = 0;

            if (dgvLedgerDetail.Columns[e.ColumnIndex].Name == "DetailDelete")
            {
                Maintenance ordUpdate = new Maintenance();
                MarginID = Convert.ToInt32(dgvLedgerDetail.Rows[e.RowIndex].Cells["LedgerBalanceDetailID"].Value.ToString());
                if (ordUpdate.DeleteLedgerBalanceDetailMaintenance(MarginID))
                {
                    FindDetailOrders();
                }
                //                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                //                "0", isChecked, ref SelectedAmount);
            }
        }

        private void dgvLedgerMaintenance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int MarginID = 0;

            if (dgvLedgerMaintenance.Columns[e.ColumnIndex].Name == "MaintDelete")
            {
                Maintenance ordUpdate = new Maintenance();
                MarginID = Convert.ToInt32(dgvLedgerMaintenance.Rows[e.RowIndex].Cells["LedgerBalanceID"].Value.ToString());
                if (ordUpdate.DeleteLedgerBalanceMaintenance(MarginID))
                {
                    FindMaintenanceOrders();
                }
                //                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                //                "0", isChecked, ref SelectedAmount);
            }
        }

        private void dgvLedgerMaintenance_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvLedgerMaintenance.CurrentCell.ColumnIndex;
                mRowIndex = dgvLedgerMaintenance.CurrentCell.RowIndex;
            }
            isRowChanged = true;
        }

        private void dgvLedgerDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvLedgerDetail.CurrentCell.ColumnIndex;
                mRowIndex = dgvLedgerDetail.CurrentCell.RowIndex;
            }
            isRowChanged = true;
        }

        private void dgvLedgerDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    if (dgvLedgerDetail.Columns[e.ColumnIndex].Name != "DetailchkDelete" && dgvLedgerDetail.Columns[e.ColumnIndex].Name != "DetailDelete")
                    {
                        dgvLedgerDetail.EndEdit();
                        string rIndex = dgvLedgerDetail.Rows[e.RowIndex].Index.ToString();
                        int riIndex = Convert.ToInt16(rIndex);
                        string OpenEquity = "";
                        int SortOrder = 0;

                        Int32 MarginID = 0;
                        string ReturnMessage = "";

                        MarginID = Convert.ToInt32(dgvLedgerDetail.Rows[riIndex].Cells["LedgerBalanceDetailID"].Value.ToString());
                        OpenEquity = dgvLedgerDetail.Rows[riIndex].Cells["DetailOpenEquity"].Value.ToString();
                        SortOrder = Convert.ToInt32(dgvLedgerDetail.Rows[riIndex].Cells["SortOrder"].Value.ToString());
                        

                        if (!clsMaintenance.UpdateLedgerBalanceDetailMaintenance(MarginID, OpenEquity, SortOrder, ref ReturnMessage))
                        {
                            MessageBox.Show(ReturnMessage, "Ledger Balance Maintenance");
                            isRowChanged = false;
                            isNotValidated = false;
                        }
                        else
                        {
                            FindDetailOrders();
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ledger Balance Maintenance");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

        private void dgvLedgerMaintenance_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    if (dgvLedgerMaintenance.Columns[e.ColumnIndex].Name != "MaintchkDelete" && dgvLedgerMaintenance.Columns[e.ColumnIndex].Name != "MaintDelete")
                    {
                        dgvLedgerMaintenance.EndEdit();
                        string rIndex = dgvLedgerMaintenance.Rows[e.RowIndex].Index.ToString();
                        int riIndex = Convert.ToInt16(rIndex);
                        string OpenEquity = "";
                        int ReverseSettlement = 0;
                        string LedgerBalance;
                        string BrokerComms;
                        string Fees;
                        string MarginBalance;
                        string NetEquityPrevious;
                        string MarginPrevious;
                        string NetEquityPreviousYear;


                        Int32 MarginID = 0;
                        string ReturnMessage = "";

                        if(dgvLedgerMaintenance.Rows[riIndex].Cells["ReverseSettlement"].Value.ToString() == "True")
                        {
                            ReverseSettlement = 1;
                        }
                        MarginID = Convert.ToInt32(dgvLedgerMaintenance.Rows[riIndex].Cells["LedgerBalanceID"].Value.ToString());
                        OpenEquity = dgvLedgerMaintenance.Rows[riIndex].Cells["MaintOpenEquity"].Value.ToString();
                        LedgerBalance = dgvLedgerMaintenance.Rows[riIndex].Cells["MaintLedgerBal"].Value.ToString();
                        BrokerComms = dgvLedgerMaintenance.Rows[riIndex].Cells["BrokerCommissions"].Value.ToString();
                        Fees = dgvLedgerMaintenance.Rows[riIndex].Cells["Fees"].Value.ToString();
                        MarginBalance = dgvLedgerMaintenance.Rows[riIndex].Cells["MaintMarginBal"].Value.ToString();
                        NetEquityPrevious = dgvLedgerMaintenance.Rows[riIndex].Cells["NetPrevEquity"].Value.ToString();
                        MarginPrevious = dgvLedgerMaintenance.Rows[riIndex].Cells["MarginPrev"].Value.ToString();
                        NetEquityPreviousYear = dgvLedgerMaintenance.Rows[riIndex].Cells["NetPrevEquityYear"].Value.ToString();



                        if (!clsMaintenance.UpdateLedgerBalanceMaintenance(MarginID, LedgerBalance, BrokerComms, Fees, MarginBalance,
                            OpenEquity, NetEquityPrevious, MarginPrevious, ReverseSettlement, NetEquityPreviousYear, ref ReturnMessage))
                        {
                            MessageBox.Show(ReturnMessage, "Ledger Balance Maintenance");
                            isRowChanged = false;
                            isNotValidated = false;
                        }
                        else
                        {
                            FindMaintenanceOrders();
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ledger Balance Maintenance");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

        private void dgvLedgerMaintenance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLedgerDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLedgerDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvLedgerDetail.EndEdit();
                isRowChanged = false;
            }
        }

        private void dgvLedgerMaintenance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvLedgerMaintenance.EndEdit();
                isRowChanged = false;
            }
        }

        private void dgvLedgerMaintenance_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvLedgerDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvLedgerDetail_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvLedgerMaintenance_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void btnMaintAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //int Company = 0;
                //int Account = 0;
                string ReturnMessage = "";
                int Reverse = 0;

                if (cboMaintAcct.Text == "")
                {
                    MessageBox.Show("Please choose an account.", "Ledger Balance");
                    return;

                }
                if (cboMaintComp.Text == "")
                {
                    MessageBox.Show("Please choose a company.", "Ledger Balance");
                    return;
                }
                if (txtLedgerBalance.Text == "")
                {
                    MessageBox.Show("Please enter balance.", "Ledger Balance");
                    return;
                }
                if (chkRevStl.Checked.ToString() == "True")
                {
                    Reverse = 1;
                }


                if (!clsMaintenance.AddLedgerBalanceMaintenance(Convert.ToInt32(cboMaintComp.Text), Convert.ToInt32(cboMaintAcct.Text), txtLedgerBalance.Text, txtBrokerComms.Text,
                    txtFees.Text, txtMarginBalance.Text, txtOpenEquity.Text, txtNetPrevEquity.Text, txtMarginPrev.Text, Reverse, txtNetEqPrevYear.Text, ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage, "Ledger Balance");
                    return;
                }

                //dgvMarginBalance.AutoGenerateColumns = false;
                //this.dgvMarginBalance.DataSource = dtBalances;
                FindMaintenanceOrders();

                cboMaintAcct.DataSource = GlobalStore.mdtAccounts.Copy();
                cboMaintAcct.DisplayMember = "TP_ACCT";
                cboMaintAcct.ValueMember = "TP_ACCT";
                cboMaintAcct.SelectedIndex = -1;
                //viewCompanies = GlobalStore.mdtComps.DefaultView;
                cboMaintComp.DataSource = GlobalStore.mdtComps.Copy();
                cboMaintComp.DisplayMember = "CompanyID";
                cboMaintComp.ValueMember = "CompanyID";
                cboMaintComp.SelectedIndex = -1;

                txtLedgerBalance.Text = "";
                txtBrokerComms.Text = "";
                txtFees.Text = "";
                txtMarginBalance.Text = "";
                txtOpenEquity.Text = "";
                txtNetPrevEquity.Text = "";
                txtMarginPrev.Text = "";
                chkRevStl.Checked = false;
                txtNetEqPrevYear.Text = "";
                cboMaintComp.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnDetailAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //int Company = 0;
                //int Account = 0;
                string ReturnMessage = "";
                int SortOrder = 0;
                int Comm;

                if (this.cboDetailAccount.Text == "")
                {
                    MessageBox.Show("Please choose an account.", "Ledger Balance");
                    return;

                }
                if (cboDetailComp.Text == "")
                {
                    MessageBox.Show("Please choose a company.", "Ledger Balance");
                    return;
                }

                if (cboDetailComm.Text == "")
                {
                    MessageBox.Show("Please choose a commodity.", "Ledger Balance");
                    return;
                }
                else
                {
                    if (cboDetailComm.SelectedValue == null)
                    {
                        Comm = Convert.ToInt32(cboDetailComm.Text.ToString());
                    }
                    else
                    {
                        Comm = Convert.ToInt32(cboDetailComm.SelectedValue.ToString());
                    }
                }
                if (this.txtBegOpenEquityforMonth.Text == "")
                {
                    MessageBox.Show("Please enter Open Equity.", "Ledger Balance");
                    return;
                }

                if (this.txtSortOrder.Text != "")
                {
                    SortOrder = Convert.ToInt32(txtSortOrder.Text.ToString());
                }

                if (!clsMaintenance.AddLedgerBalanceDetailMaintenance(Convert.ToInt32(cboDetailComp.Text), Convert.ToInt32(cboDetailAccount.Text), Comm, SortOrder, txtBegOpenEquityforMonth.Text,
                     ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage, "Ledger Balance");
                    return;
                }

                //dgvMarginBalance.AutoGenerateColumns = false;
                //this.dgvMarginBalance.DataSource = dtBalances;
                FindDetailOrders();

                cboDetailAccount.DataSource = GlobalStore.mdtAccounts.Copy();
                cboDetailAccount.DisplayMember = "TP_ACCT";
                cboDetailAccount.ValueMember = "TP_ACCT";
                cboDetailAccount.SelectedIndex = -1;
                //viewCompanies = GlobalStore.mdtComps.DefaultView;
                cboDetailComp.DataSource = GlobalStore.mdtComps.Copy();
                cboDetailComp.DisplayMember = "CompanyID";
                cboDetailComp.ValueMember = "CompanyID";
                cboDetailComp.SelectedIndex = -1;

                this.cboDetailComm.DataSource = GlobalStore.mdtCommodity.Copy();
                cboDetailComm.DisplayMember = "DESC";
                cboDetailComm.ValueMember = "TP_COMM";
                cboDetailComm.SelectedIndex = -1;

                this.txtBegOpenEquityforMonth.Text = "";
                txtSortOrder.Text = "";

                cboDetailComp.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnDetailDelete_Click(object sender, EventArgs e)
        {
            int MarginID = 0;
            //int col = 8;
            for (int row = 0; row < this.dgvLedgerDetail.Rows.Count; row++)
            {
                System.Diagnostics.Debug.Print(row.ToString());
                if (dgvLedgerDetail.Rows[row].Cells["DetailchkDelete"].Value != null)
                {
                    if (dgvLedgerDetail.Rows[row].Cells["DetailchkDelete"].Value.ToString() == "True")
                    {
                        //MessageID = dgvECOrders.Rows[row].Cells["MessageID"].Value.ToString();
                        MarginID = Convert.ToInt32(dgvLedgerDetail.Rows[row].Cells["LedgerBalanceDetailID"].Value.ToString());
                        //uLastPrice = dgvECOrders.Rows[row].Cells["uLastPrice"].Value.ToString();
                        //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
                        clsMaintenance.DeleteLedgerBalanceDetailMaintenance(MarginID);

                    }
                }


                //dtTradingCompanies.Clear();
                //clsMaintenance.GetCommoditiesTradingCompaniesForEdit(dtTradingCompanies);
                //dgvCommodityTradingCompany.AutoGenerateColumns = false;
                //this.dgvCommodityTradingCompany.DataSource = dtTradingCompanies;
                //dgvCommodityTradingCompany.Refresh();
            }

            dtDetail.Clear();
            FindDetailOrders();

        }

        private void btnMaintDelete_Click(object sender, EventArgs e)
        {
            int MarginID = 0;
            //int col = 8;
            for (int row = 0; row < this.dgvLedgerMaintenance.Rows.Count; row++)
            {
                System.Diagnostics.Debug.Print(row.ToString());
                if (dgvLedgerMaintenance.Rows[row].Cells["MaintchkDelete"].Value != null)
                {
                    if (dgvLedgerMaintenance.Rows[row].Cells["MaintchkDelete"].Value.ToString() == "True")
                    {
                        //MessageID = dgvECOrders.Rows[row].Cells["MessageID"].Value.ToString();
                        MarginID = Convert.ToInt32(dgvLedgerMaintenance.Rows[row].Cells["LedgerBalanceID"].Value.ToString());
                        //uLastPrice = dgvECOrders.Rows[row].Cells["uLastPrice"].Value.ToString();
                        //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
                        clsMaintenance.DeleteLedgerBalanceMaintenance(MarginID);

                    }
                }


                //dtTradingCompanies.Clear();
                //clsMaintenance.GetCommoditiesTradingCompaniesForEdit(dtTradingCompanies);
                //dgvCommodityTradingCompany.AutoGenerateColumns = false;
                //this.dgvCommodityTradingCompany.DataSource = dtTradingCompanies;
                //dgvCommodityTradingCompany.Refresh();
            }

            dtMaintenance.Clear();
            FindMaintenanceOrders();
        }

        private void btnMaintShow_Click(object sender, EventArgs e)
        {
            dtMaintenance.Clear();
            FindMaintenanceOrders();
        }

        private void btnDetailShow_Click(object sender, EventArgs e)
        {
            dtDetail.Clear();
            FindDetailOrders();
        }





    }

}



