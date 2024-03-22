using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HedgedeskApplication.Models;
using HedgedeskApplication.Classes;
using Telerik.Reporting.Processing;

namespace HedgedeskApplication
{
    public partial class frmOptions : Form
    {
        Boolean mLoading = false;

        public DataTable dtContractOptions = new DataTable();
        public Boolean isNotValidated = false;
        public DataTable dtContractOptionsNotWorking = new DataTable();
        public Boolean isOptionRowChanged = false;
        public int optionsTabIndex = 7;

        public string originalComment = "";
        public string originalContractOptionExecutedPremium = "";
        public string originalContractOptionFuturesPrice = "";
        public string originalContractOptionOrderNumber = "";
        public string originalContractOptionOrderDateTime = "";
        public string originalContractOptionAssignmentDate = "";
        public string originalContractOptionAssignedQuantity = "";
        public string originalContractOptionExpirationDate = "";
        public string originalContractOptionSoldPremium = "";
        public string originalContractOptionCardNumber = ""; 
        frmReports frmReports = null;

        public frmOptions()
        {
            InitializeComponent();

        }

        public Boolean CreatePopulateData()
		{
            try
            {
                mLoading = true;
                this.tbcContractOptions.Visible = false;
                dtContractOptions.Clear();
                dtContractOptionsNotWorking.Clear();
                dtContractOptions = Options.FillContractOptionsDataSet(1).Tables[0];
                dtContractOptionsNotWorking = Options.FillContractOptionsDataSet(0).Tables[0];
                dgvContractOptions.AutoGenerateColumns = false;
                dgvContractOptionsNotWorking.AutoGenerateColumns = false;
                
                this.dgvContractOptionsNotWorking.DataSource = dtContractOptionsNotWorking;
                dgvContractOptionsNotWorking.Columns["ContractOptionQuantityNotWorking"].DefaultCellStyle.Format = "#,##0.#####";
                dgvContractOptionsNotWorking.Columns["PremiumNotWorking"].DefaultCellStyle.Format = "#,##0.00###";
                dgvContractOptionsNotWorking.Columns["ExecutedPremiumNotWorking"].DefaultCellStyle.Format = "#,##0.00###";
                dgvContractOptionsNotWorking.Columns["OptionsFuturesPriceNotWorking"].DefaultCellStyle.Format = "#,##0.00###";
                dgvContractOptionsNotWorking.Columns["SoldPremiumNotWorking"].DefaultCellStyle.Format = "#,##0.00###";
                dgvContractOptionsNotWorking.Columns["FillPremiumNotWorking"].DefaultCellStyle.Format = "#,##0.00###";
                this.dgvContractOptions.DataSource = dtContractOptions;
                dgvContractOptions.Columns["ContractOptionQuantity"].DefaultCellStyle.Format = "#,##0.#####";
                dgvContractOptions.Columns["Premium"].DefaultCellStyle.Format = "#,##0.00###";
                dgvContractOptions.Columns["ExecutedPremium"].DefaultCellStyle.Format = "#,##0.00###";
                dgvContractOptions.Columns["OptionsFuturesPrice"].DefaultCellStyle.Format = "#,##0.00###";
                dgvContractOptions.Columns["SoldPremium"].DefaultCellStyle.Format = "#,##0.00###";
                dgvContractOptions.Columns["FillPremium"].DefaultCellStyle.Format = "#,##0.00###";
                this.tbcContractOptions.Visible = true;
                this.tpWorkingOptions.Focus();
                mLoading = false;
                return true;
            }
            catch (Exception ex)
            {
                if (mLoading == true) { mLoading = false; } 
                MessageBox.Show(ex.Message.ToString(), "Options");
                return false;
            }
        }

        public void RefreshContractOptionGrid()
        {
            isOptionRowChanged = false;

            int rowIndex = dgvContractOptions.FirstDisplayedScrollingRowIndex;

            dgvContractOptions.AutoGenerateColumns = false;
            dtContractOptions.Clear();
            dtContractOptions.Dispose();
            Options.mdsContractOptions.Dispose();
            dtContractOptions = Options.FillContractOptionsDataSet(1).Tables[0];
            dgvContractOptions.DataSource = dtContractOptions;
            dgvContractOptions.Refresh();
            //tbcOrder.Refresh();


            for (int row = 0; row < dgvContractOptions.Rows.Count; row++)
            {
                if ((dgvContractOptions["ContractOptionStatus", row].Value.ToString() != "Working") && (dgvContractOptions["ContractOptionStatus", row].Value.ToString() != "Executed")
                    && (dgvContractOptions["ContractOptionStatus", row].Value.ToString() != "Pending Cancelled"))
                {
                    dgvContractOptions["ExecutedPremium", row].ReadOnly = true;
                }
                if ((dgvContractOptions["Accepted", row].Value.ToString() == "1") && (dgvContractOptions["ContractOptionStatus", row].Value.ToString() != "Working"))
                {
                    dgvContractOptions["Accepted", row].ReadOnly = true;
                }
                if (dgvContractOptions["ContractOptionStatus", row].Value.ToString() == "Pending")
                {
                    dgvContractOptions["AssignedQuantity", row].ReadOnly = true;
                    dgvContractOptions.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                }
                if ((dgvContractOptions["ContractOptionStatus", row].Value.ToString() == "Pending Cancelled") ||
                    (dgvContractOptions["ContractOptionStatus", row].Value.ToString() == "Pending Sale"))
                {
                    dgvContractOptions.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                }
                if (dgvContractOptions["ContractOptionStatus", row].Value.ToString() != "Pending Sale")
                {
                    dgvContractOptions["SoldPremium", row].ReadOnly = true;
                }
                if ((dgvContractOptions["ContractOptionStatus", row].Value.ToString() == "Executed") &&
                        (DateTime.Parse(dgvContractOptions["ExpirationDate", row].Value.ToString()) <= DateTime.Now))
                {
                    dgvContractOptions.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            if ((rowIndex >= 0) && (dgvContractOptions.RowCount > 0))
            {
                dgvContractOptions.FirstDisplayedScrollingRowIndex = rowIndex;
            }
        }

        public void RefreshContractOptionNotWorkingGrid()
        {
            isOptionRowChanged = false;

            int rowIndex = dgvContractOptionsNotWorking.FirstDisplayedScrollingRowIndex;

            //dt needs to be change for not working grid
            dgvContractOptionsNotWorking.AutoGenerateColumns = false;
            dtContractOptionsNotWorking.Clear();
            dtContractOptionsNotWorking.Dispose();
            Options.mdsContractOptions.Dispose();
            dtContractOptionsNotWorking = Options.FillContractOptionsDataSet(0).Tables[0];
            dgvContractOptionsNotWorking.DataSource = dtContractOptionsNotWorking;
            dgvContractOptionsNotWorking.Refresh();
            //tbcOrder.Refresh();


            for (int row = 0; row < dgvContractOptionsNotWorking.Rows.Count; row++)
            {
                if (dgvContractOptionsNotWorking["ContractOptionStatusNotWorking", row].Value.ToString() != "Assigned")
                {
                    dgvContractOptionsNotWorking["AssignmentDateNotWorking", row].ReadOnly = true;
                }
                if (dgvContractOptionsNotWorking["ContractOptionStatusNotWorking", row].Value.ToString() != "Expired")
                {
                    dgvContractOptionsNotWorking["OptionsFuturesPriceNotWorking", row].ReadOnly = true;
                }
                if ((dgvContractOptionsNotWorking["ContractOptionStatusNotWorking", row].Value.ToString() == "Expired") && (dgvContractOptionsNotWorking["OptionsFuturesPriceNotWorking", row].Value.ToString() == "0.00000"))
                {
                    dgvContractOptionsNotWorking.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            if ((rowIndex >= 0) && (dgvContractOptionsNotWorking.RowCount > 0))
            {
                dgvContractOptionsNotWorking.FirstDisplayedScrollingRowIndex = rowIndex;
            }
        }

        private void dgvContractOptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvContractOptions.Columns[e.ColumnIndex].Name == "ExpireAssign")
                {
                    string returnMessage = "";
                    DialogResult drExpireAssign = DialogResult.No;
                    drExpireAssign = MessageBox.Show("Do you want to Expire or Assign this option?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (drExpireAssign == DialogResult.Yes)
                    {
                        int contractOptionID = Convert.ToInt32(dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionID"].Value.ToString());
                        decimal settlePrice;
                        Decimal.TryParse(txtSettlePrice.Text, out settlePrice);
                        ContractsOptionsData.ExpireAssignOption(contractOptionID, txtSymbol.Text, settlePrice, dtSettleDate.Value, out returnMessage);

                        if (returnMessage != "")
                        {
                            MessageBox.Show(returnMessage, "Hedgebook");
                        }

                        if (tbcContractOptions.SelectedIndex == 0)
                        {
                            RefreshContractOptionGrid();
                        }
                        else if (tbcContractOptions.SelectedIndex == 1)
                        {
                            RefreshContractOptionNotWorkingGrid();
                        }
                    }
                }
                else
                {
                    if (ContractOptions.UpdateAcceptedOrCancelledColumns(e, dgvContractOptions))
                    {
                        if (tbcContractOptions.SelectedIndex == 0)
                        {
                            RefreshContractOptionGrid();
                        }
                        else if (tbcContractOptions.SelectedIndex == 1)
                        {
                            RefreshContractOptionNotWorkingGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedgebook");
            }
        }

        private void dgvContractOptions_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ContractOptions_CellBeginEdit(dgvContractOptions);
        }

        private void dgvContractOptionsNotWorking_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ContractOptions_CellBeginEdit(dgvContractOptionsNotWorking);
        }

        private void dgvContractOptions_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            ContractOptions_CellLeave(e, dgvContractOptions);
        }

        private void dgvContractOptionsNotWorking_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            ContractOptions_CellLeave(e, dgvContractOptionsNotWorking);
        }

        private void dgvContractOptions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("A data error has occurred and the last change was not saved.\nPlease check your input and try again.", "Hedgebook");
            e.Cancel = false;
        }

        private void dgvContractOptionsNotWorking_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("A data error has occurred and the last change was not saved.\nPlease check your input and try again.", "Hedgebook");
            e.Cancel = false;
        }
        private void ContractOptions_CellBeginEdit(dgvCustom dgv)
        {
            string appendedName = "";
            if (dgv.Name == "dgvContractOptionsNotWorking")
            {
                appendedName = "NotWorking";
            }

            tmrPending.Stop();
            tmrPending.Start();

            string columnName = dgv.Columns[dgv.CurrentCell.ColumnIndex].Name;
            if ((columnName == "ExecutedPremium" + appendedName) || (columnName == "OptionsFuturesPrice" + appendedName)
                || (columnName == "OrderNo" + appendedName) || (columnName == "OrderDateTime" + appendedName)
                || (columnName == "AssignedQuantity" + appendedName) || (columnName == "AssignmentDate" + appendedName)
                || (columnName == "ExpirationDate" + appendedName) || (columnName == "SoldPremium" + appendedName)
                || (columnName == "CardNumber" + appendedName))
            {
                isOptionRowChanged = true;
                originalContractOptionExecutedPremium = dgv["ExecutedPremium" + appendedName, dgv.CurrentCell.RowIndex].Value.ToString();
                originalContractOptionFuturesPrice = dgv["OptionsFuturesPrice" + appendedName, dgv.CurrentCell.RowIndex].Value.ToString();
                originalContractOptionOrderNumber = dgv["OrderNo" + appendedName, dgv.CurrentCell.RowIndex].Value.ToString();
                originalContractOptionOrderDateTime = dgv["OrderDateTime" + appendedName, dgv.CurrentCell.RowIndex].Value.ToString();
                originalContractOptionAssignedQuantity = dgv["AssignedQuantity" + appendedName, dgv.CurrentCell.RowIndex].Value.ToString();
                originalContractOptionAssignmentDate = dgv["AssignmentDate" + appendedName, dgv.CurrentCell.RowIndex].Value.ToString();
                originalContractOptionExpirationDate = dgv["ExpirationDate" + appendedName, dgv.CurrentCell.RowIndex].Value.ToString();
                originalContractOptionSoldPremium = dgv["SoldPremium" + appendedName, dgv.CurrentCell.RowIndex].Value.ToString();
                originalContractOptionCardNumber = dgv["CardNumber" + appendedName, dgv.CurrentCell.RowIndex].Value.ToString();
            }
        }

        private void ContractOptions_CellLeave(DataGridViewCellEventArgs e, dgvCustom dgv)
        {
            if (isOptionRowChanged)
            {
                if (ContractOptions.SaveChanges(e, dgv, originalContractOptionExecutedPremium, originalContractOptionFuturesPrice,
                        originalContractOptionOrderNumber, originalContractOptionOrderDateTime, originalContractOptionAssignedQuantity,
                        originalContractOptionAssignmentDate, originalContractOptionExpirationDate, originalContractOptionSoldPremium,
                        originalContractOptionCardNumber))
                {
                    if (tbcContractOptions.SelectedIndex == 0)
                    {
                        RefreshContractOptionGrid();
                    }
                    else if (tbcContractOptions.SelectedIndex == 1)
                    {
                        RefreshContractOptionNotWorkingGrid();
                    }
                }
                isOptionRowChanged = false;
                isNotValidated = false;
            }
        }

        private void btnRefreshAll_OptionsTab_Click(object sender, EventArgs e)
        {
            RefreshAll(btnRefreshAll_OptionsTab);
        }

        private void tbcContractOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedTab.Name)
            {
                case "tpWorkingOptions":
                    RefreshContractOptionGrid();
                    break;
                case "tpNotWorkingOptions":
                    RefreshContractOptionNotWorkingGrid();
                    break;
                default:
                    break;
            }
        }

        private void RefreshAll(System.Windows.Forms.Button btn)
        {
            btn.Text = "Refreshing";
            btn.Update();


            if (tbcContractOptions.SelectedIndex == 0)
            {
                RefreshContractOptionGrid();
            }
            else if (tbcContractOptions.SelectedIndex == 1)
            {
                RefreshContractOptionNotWorkingGrid();
            }

            btn.Text = "Refresh All";
            btn.Update();
        }

        private void dgvContractOptions_MouseEnter(object sender, EventArgs e)
        {
            tmrPending.Interval = 30000;
        }

        private void dgvContractOptionsNotWorking_MouseEnter(object sender, EventArgs e)
        {
            tmrPending.Interval = 30000;
        }

        private void btnContractOptionDefaultSort_Click(object sender, EventArgs e)
        {
            if (tbcContractOptions.SelectedIndex == 0)
            {
                dtContractOptions.DefaultView.Sort = String.Empty;
                RefreshContractOptionGrid();
            }
            else if (tbcContractOptions.SelectedIndex == 1)
            {
                dtContractOptionsNotWorking.DefaultView.Sort = String.Empty;
                RefreshContractOptionNotWorkingGrid();
            }
        }

        
        

        private void tmrPending_Tick(object sender, EventArgs e)
        {
            if (tbcContractOptions.SelectedIndex == 0)
            {
                RefreshContractOptionGrid();
            }
            else if (tbcContractOptions.SelectedIndex == 1)
            {
                RefreshContractOptionNotWorkingGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        private void frmOptions_Load(object sender, EventArgs e)
        {
            CreatePopulateData();
            this.tbcContractOptions.SelectedIndex = 0;
            RefreshContractOptionGrid();
            tmrPending.Interval = 30000;
            tmrPending.Start();
        }

        private void rptOptionsOpenPosition_Click(object sender, EventArgs e)
        {
            if (frmReports == null)
            {
                frmReports = new frmReports();
                frmReports.ReportName = "rptOptionsOpenPosition";
                frmReports.FormClosed += frmReports_Closed;
                frmReports.Show(this);
            }
            else
            {
                frmReports.Focus();
                frmReports.BringToFront();
            }
        }

        private void rptOptionsTradedToday_Click(object sender, EventArgs e)
        {
            if (frmReports == null)
            {
                frmReports = new frmReports();
                frmReports.ReportName = "rptOptionsTotalToday";
                frmReports.FormClosed += frmReports_Closed;
                frmReports.Show(this);
            }
            else
            {
                frmReports.Focus();
                frmReports.BringToFront();
            }

        }


        void frmReports_Closed(object sender, EventArgs e)
        {
            frmReports = null;
        }

        private void dgvContractOptionsNotWorking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOptionConfirmation_Click(object sender, EventArgs e)
        {
            if (frmReports == null)
            {
                frmReports = new frmReports();
                frmReports.ReportName = "rptOptionConfirmationMaster";
                frmReports.FormClosed += frmReports_Closed;
                frmReports.Show(this);
            }
            else
            {
                frmReports.Focus();
                frmReports.BringToFront();
            }


        }

 
        
    }
}
