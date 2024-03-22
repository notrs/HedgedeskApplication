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
    public partial class frmAccountMaintenance : Form
    {

        Maintenance clsMaintenance = new Maintenance();
        DataTable dtHedgeAccounts = new DataTable();
        int mColumnIndex;
        int mRowIndex;
        Boolean isNotValidated = false;
        Boolean isRowChanged = false;
        public frmAccountMaintenance()
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

                dtHedgeAccounts.Clear();
                clsMaintenance.GetHedgeAccountDetails(dtHedgeAccounts);
                dgvHedgeAccounts.AutoGenerateColumns = false;
                this.dgvHedgeAccounts.DataSource = dtHedgeAccounts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void dgvHedgeAccounts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvHedgeAccounts.CurrentCell.ColumnIndex;
                mRowIndex = dgvHedgeAccounts.CurrentCell.RowIndex;
            }
            isRowChanged = true;

        }

        private void dgvHedgeAccounts_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvHedgeAccounts_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    dgvHedgeAccounts.EndEdit();
                    //string rIndex = dgvHedgeAccounts.Rows[e.RowIndex].Index.ToString();
                    //int riIndex = Convert.ToInt16(rIndex);
                    //string LowLimit = "";
                    //string RangeLow = "";
                    //string RangeHigh = "";
                    //int CommodityID = 0;
                    //string RoundingDivisor = "";
                    //string ReturnMessage = "";

                    //CommodityID = Convert.ToInt32(dgvHedgeAccounts.Rows[riIndex].Cells["CommodityID"].Value.ToString());
                    //LowLimit = dgvHedgeAccounts.Rows[riIndex].Cells["LowLimit"].Value.ToString();
                    //RangeLow = dgvHedgeAccounts.Rows[riIndex].Cells["RangeLow"].Value.ToString();
                    //RangeHigh = dgvHedgeAccounts.Rows[riIndex].Cells["RangeHigh"].Value.ToString();
                    //RoundingDivisor = dgvHedgeAccounts.Rows[riIndex].Cells["RoundingDivisor"].Value.ToString();

                    //if (!clsMaintenance.UpdateHedgeLimits(LowLimit, RangeLow, RangeHigh, RoundingDivisor, CommodityID, ref ReturnMessage))
                    //{
                    //    MessageBox.Show(ReturnMessage, "Commodity Maintenance");
                    //    isRowChanged = false;
                    //    isNotValidated = false;
                    //}
                    //else
                    //{
                    //    dtCommodities.Clear();
                    //    clsMaintenance.GetCommoditiesForEdit(dtCommodities);
                    //    dgvHedgeAccounts.DataSource = dtCommodities;
                    isRowChanged = false;
                    isNotValidated = false;
                    //}
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Commodity Maintenance");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

        private void dgvHedgeAccounts_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvHedgeAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvHedgeAccounts.EndEdit();
                isRowChanged = false;
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            //int CommTradingCompID = 0;
            //int col = 8;
            //for (int row = 0; row < this.dgvHedgeAccounts.Rows.Count; row++)
            //{
            //    if (dgvHedgeAccounts.Rows[row].Cells["chkDelete"].Value != null)
            //    {
            //        if (dgvHedgeAccounts.Rows[row].Cells["chkDelete"].Value.ToString() == "True")
            //        {
            //            //MessageID = dgvECOrders.Rows[row].Cells["MessageID"].Value.ToString();
            //            CommTradingCompID = Convert.ToInt32(dgvHedgeAccounts.Rows[row].Cells["TradingCompCommID"].Value.ToString());
            //            //uLastPrice = dgvECOrders.Rows[row].Cells["uLastPrice"].Value.ToString();
            //            //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
            //            clsMaintenance.DeleteCommoditiesTradingID(CommTradingCompID);

            //        }
            //    }


            //    //dtTradingCompanies.Clear();
            //    //clsMaintenance.GetCommoditiesTradingCompaniesForEdit(dtTradingCompanies);
            //    //dgvCommodityTradingCompany.AutoGenerateColumns = false;
            //    //this.dgvCommodityTradingCompany.DataSource = dtTradingCompanies;
            //    //dgvCommodityTradingCompany.Refresh();
            //}

            //dtHedgeAccounts.Clear();
            //LoadForm();
            //dgvHedgeAccounts.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               

                
                //dtBalances.Clear();
                //clsMaintenance.GetMarginBalances(Company, Account, this.dtpTo.Value.ToShortDateString(), this.dtpFrom.Value.ToShortDateString(), dtBalances);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }
              

        

        private void frmAccountMaintenance_Load(object sender, EventArgs e)
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

        
        private void dgvHedgeAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int MarginID = 0;

            //if (dgvHedgeAccounts.Columns[e.ColumnIndex].Name == "Delete")
            //{
            //    Maintenance ordUpdate = new Maintenance();
            //    MarginID = Convert.ToInt32(dgvHedgeAccounts.Rows[e.RowIndex].Cells["MarginID"].Value.ToString());
            //    if (ordUpdate.DeleteCommoditiesTradingID(MarginID))
            //    {
            //        LoadForm();
            //    }
            //    //                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
            //    //                "0", isChecked, ref SelectedAmount);
            //}
        }



    }
            
}



