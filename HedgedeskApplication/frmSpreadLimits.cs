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
    public partial class frmSpreadLimits : Form
    {
        DataTable dtCommodities = new DataTable();
        DataTable dtSpreadLimits = new DataTable();
        DataTable dtClosingFutures = new DataTable();
        Maintenance clsMaintenance = new Maintenance();
        int mColumnIndex;
        int mRowIndex;
        Boolean isNotValidated = false;
        Boolean isRowChanged = false;

        public frmSpreadLimits()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmCommodityLimits_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            clsMaintenance.GetSpreadLimitsForEdit(dtSpreadLimits);
            dgvSpreadLimits.AutoGenerateColumns = false;
            this.dgvSpreadLimits.DataSource = dtSpreadLimits;
        }

 
        private void dgvSpreadLimits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int AccountCommodityLimitID = 0;

            if (dgvSpreadLimits.Columns[e.ColumnIndex].Name == "Delete")
            {
                Maintenance ordUpdate = new Maintenance();
                AccountCommodityLimitID = Convert.ToInt32(dgvSpreadLimits.Rows[e.RowIndex].Cells["AccountCommodityLimitID"].Value.ToString());
                if (ordUpdate.DeleteAccountCommodityLimit(AccountCommodityLimitID))
                {
                    dtSpreadLimits.Clear();
                    clsMaintenance.GetSpreadLimitsForEdit(dtSpreadLimits);
                    dgvSpreadLimits.AutoGenerateColumns = false;
                    this.dgvSpreadLimits.DataSource = dtSpreadLimits;
                }
            //                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
            //                "0", isChecked, ref SelectedAmount);
            }
            
        }

        private void dgvSpreadLimits_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            int CommodityID = 0;
            int Account = 0;
            int SpreadLimit = 0;
            int AccountCommodityLimitID = 0;

            if (e.ColumnIndex == dgvSpreadLimits.Columns["chkDelete"].Index)
            {
                isRowChanged = false;
                isNotValidated = false;
                return;

            }
            if (isRowChanged)
            {
                try
                {
                    dgvSpreadLimits.EndEdit();
                    AccountCommodityLimitID = Convert.ToInt32(dgvSpreadLimits.Rows[e.RowIndex].Cells["AccountCommodityLimitID"].Value.ToString());
                    SpreadLimit = Convert.ToInt32(dgvSpreadLimits.Rows[e.RowIndex].Cells["SpreadLimit"].Value.ToString());
                    CommodityID = Convert.ToInt32(dgvSpreadLimits.Rows[e.RowIndex].Cells["CommodityID"].Value.ToString());
                    Account = Convert.ToInt32(dgvSpreadLimits.Rows[e.RowIndex].Cells["AccountID"].Value.ToString());
                                                         
                    string ReturnMessage = "";


                    if (!clsMaintenance.UpdateAccountCommodityLimits(AccountCommodityLimitID, CommodityID, Account, SpreadLimit, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage, "Spread Limits");
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                    else
                    {
                        dtSpreadLimits.Clear();
                        clsMaintenance.GetSpreadLimitsForEdit(dtSpreadLimits);
                        dgvSpreadLimits.AutoGenerateColumns = false;
                        this.dgvSpreadLimits.DataSource = dtSpreadLimits;
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Spread Limits");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

  
        private void dgvSpreadLimits_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvSpreadLimits_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvSpreadLimits_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvSpreadLimits.CurrentCell.ColumnIndex;
                mRowIndex = dgvSpreadLimits.CurrentCell.RowIndex;
            }
            isRowChanged = true;
        }

        private void dgvSpreadLimits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvSpreadLimits.EndEdit();
                isRowChanged = false;
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            int AccountCommodityLimitID = 0;

            for (int row = 0; row < this.dgvSpreadLimits.Rows.Count; row++)
            {
                if (dgvSpreadLimits.Rows[row].Cells["chkDelete"].Value != null)
                {
                    if (dgvSpreadLimits.Rows[row].Cells["chkDelete"].Value.ToString() == "True")
                    {
                        AccountCommodityLimitID = Convert.ToInt32(dgvSpreadLimits.Rows[row].Cells["AccountCommodityLimitID"].Value.ToString());
                        clsMaintenance.DeleteAccountCommodityLimit(AccountCommodityLimitID);

                    }
                }



            }

            dtSpreadLimits.Clear();
            clsMaintenance.GetSpreadLimitsForEdit(dtSpreadLimits);
            dgvSpreadLimits.AutoGenerateColumns = false;
            this.dgvSpreadLimits.DataSource = dtSpreadLimits;
            dgvSpreadLimits.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddSpreadLimits frmAdd = new frmAddSpreadLimits();
            frmAdd.ShowDialog();
            dtSpreadLimits.Clear();
            clsMaintenance.GetSpreadLimitsForEdit(dtSpreadLimits);
            dgvSpreadLimits.AutoGenerateColumns = false;
            this.dgvSpreadLimits.DataSource = dtSpreadLimits;

        }

          
    }
            
}



