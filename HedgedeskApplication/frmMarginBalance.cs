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
    public partial class frmMarginBalance : Form
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
        int mColumnIndex;
        int mRowIndex;
        Boolean isNotValidated = false;
        Boolean isRowChanged = false;
        public frmMarginBalance()
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

                cboComp.DataSource = GlobalStore.mdtComps.Copy();
                cboComp.DisplayMember = "CompanyID";
                cboComp.ValueMember = "CompanyID";
                cboComp.SelectedIndex = -1;
                cboAcct.SelectedIndex = -1;
                dtBalances.Clear();
                clsMaintenance.GetMarginBalances(0, 0, "", "", dtBalances);
                dgvMarginBalance.AutoGenerateColumns = false;
                this.dgvMarginBalance.DataSource = dtBalances;
                if (dtBalances.Rows.Count > 0)
                {
                    String Total = dtBalances.Rows[0]["MarginTotal"].ToString();
                    Total = String.Format("{0:N2}", Convert.ToDecimal(Total));
                    txtTotalMargin.Text = Total;
                }
                else
                {
                    txtTotalMargin.Text = "";
                }

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
                clsMaintenance.GetMarginBalances(Company, Account, this.dtpTo.Value.ToShortDateString(), this.dtpFrom.Value.ToShortDateString(), dtBalances);
                dgvMarginBalance.AutoGenerateColumns = false;
                this.dgvMarginBalance.DataSource = dtBalances;
                if (dtBalances.Rows.Count > 0)
                {
                    String Total = dtBalances.Rows[0]["MarginTotal"].ToString();
                    Total = String.Format("{0:N2}", Convert.ToDecimal(Total));
                    txtTotalMargin.Text = Total;
                }
                else
                {
                    txtTotalMargin.Text = "";
                }

                //txtTotalMargin.Text = dtBalances.Rows[0]["MarginTotal"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }



        private void dgvMarginBalance_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvMarginBalance.CurrentCell.ColumnIndex;
                mRowIndex = dgvMarginBalance.CurrentCell.RowIndex;
            }
            isRowChanged = true;

        }

        private void dgvMarginBalance_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvMarginBalance_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    dgvMarginBalance.EndEdit();
                    string rIndex = dgvMarginBalance.Rows[e.RowIndex].Index.ToString();
                    int riIndex = Convert.ToInt16(rIndex);
                    string Margin = "";
                    
                    Int32 MarginID = 0;
                    string ReturnMessage = "";

                    MarginID = Convert.ToInt32(dgvMarginBalance.Rows[riIndex].Cells["MarginID"].Value.ToString());
                    Margin = dgvMarginBalance.Rows[riIndex].Cells["MarginBal"].Value.ToString();

                    if (!clsMaintenance.UpdateMarginBalances(MarginID, Margin, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage, "Margin Balance Maintenance");
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                    else
                    {
                        FindOrders();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Margin Balance Maintenance");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

        private void dgvMarginBalance_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvMarginBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvMarginBalance.EndEdit();
                isRowChanged = false;
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            int MarginID = 0;
            //int col = 8;
            for (int row = 0; row < this.dgvMarginBalance.Rows.Count; row++)
            {
                if (dgvMarginBalance.Rows[row].Cells["chkDelete"].Value != null)
                {
                    if (dgvMarginBalance.Rows[row].Cells["chkDelete"].Value.ToString() == "True")
                    {
                        //MessageID = dgvECOrders.Rows[row].Cells["MessageID"].Value.ToString();
                        MarginID = Convert.ToInt32(dgvMarginBalance.Rows[row].Cells["MarginID"].Value.ToString());
                        //uLastPrice = dgvECOrders.Rows[row].Cells["uLastPrice"].Value.ToString();
                        //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
                        clsMaintenance.DeleteMarginBalance(MarginID);

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
            dgvMarginBalance.Refresh();
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
                    MessageBox.Show("Please choose an account.", "Margin Balance");
                    return;

                }
                if (cboAddComp.Text == "")
                {
                    MessageBox.Show("Please choose a company.", "Margin Balance");
                    return;
                }
                if (txtMargin.Text == "")
                {
                    MessageBox.Show("Please enter margin.", "Margin Balance");
                    return;
                }

                dtBalances.Clear();
                if (!clsMaintenance.AddMarginBalances(Convert.ToInt32(cboAddComp.Text), Convert.ToInt32(cboAddAcct.Text), txtMargin.Text, this.dtpAddMarginDate.Value.ToShortDateString(), ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage, "Margin Balance");
                    return;
                }
                
                //dgvMarginBalance.AutoGenerateColumns = false;
                //this.dgvMarginBalance.DataSource = dtBalances;
                FindOrders();
                cboAddComp.SelectedIndex = -1;
                cboAddAcct.SelectedIndex = -1;
                txtMargin.Text = "";
                cboAddComp.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }
              

        

        private void frmMarginBalance_Load(object sender, EventArgs e)
        {
            LoadForm();
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

        private void dgvMarginBalance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int MarginID = 0;

            if (dgvMarginBalance.Columns[e.ColumnIndex].Name == "Delete")
            {
                Maintenance ordUpdate = new Maintenance();
                MarginID = Convert.ToInt32(dgvMarginBalance.Rows[e.RowIndex].Cells["MarginID"].Value.ToString());
                if (ordUpdate.DeleteMarginBalance(MarginID))
                {
                    FindOrders();
                }
                //                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                //                "0", isChecked, ref SelectedAmount);
            }
        }



    }
            
}



