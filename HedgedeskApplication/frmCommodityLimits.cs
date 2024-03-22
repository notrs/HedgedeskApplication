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
    public partial class frmCommodityLimits : Form
    {
        DataTable dtCommodities = new DataTable();
        DataTable dtCommoditiesForUpdate = new DataTable();
        DataTable dtCommoditiesMonths = new DataTable();
        DataTable dtTradingCompanies = new DataTable();
        DataTable dtClosingFutures = new DataTable();
        Maintenance clsMaintenance = new Maintenance();
        int mColumnIndex;
        int mRowIndex;
        Boolean isNotValidated = false;
        Boolean isRowChanged = false;
        public frmCommodityLimits()
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
            int inActive = 0;
            clsMaintenance.GetCommoditiesForEdit(dtCommodities);
            dgvCommodityLimits.DataSource = dtCommodities;
            clsMaintenance.GetCommoditiesTradingCompaniesForEdit(dtTradingCompanies);
            dgvCommodityTradingCompany.AutoGenerateColumns = false;
            this.dgvCommodityTradingCompany.DataSource = dtTradingCompanies;
            dtClosingFutures.Clear();
            dgvClosingFutures.AutoGenerateColumns = false;
            clsMaintenance.GetClosingPrices(dtClosingFutures);
            this.dgvClosingFutures.DataSource = dtClosingFutures;

            if (chkActive.Checked == true)
            {
                inActive = 1;
            }
            
            dtCommoditiesForUpdate.Clear();
            this.dgvCommodities.AutoGenerateColumns = false;
            clsMaintenance.GetCommodities(inActive, dtCommoditiesForUpdate);
            this.dgvCommodities.DataSource = dtCommoditiesForUpdate;


        }

        private void dgvCommodityLimits_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvCommodityLimits.CurrentCell.ColumnIndex;
                mRowIndex = dgvCommodityLimits.CurrentCell.RowIndex;
            }
            isRowChanged = true;

        }

        private void dgvCommodityLimits_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvCommodityLimits_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    dgvCommodityLimits.EndEdit();
                    string rIndex = dgvCommodityLimits.Rows[e.RowIndex].Index.ToString();
                    int riIndex = Convert.ToInt16(rIndex);
                    string LowLimit = "";
                    string RangeLow = "";
                    string RangeHigh = "";
                    int CommodityID = 0;
                    string RoundingDivisor = "";
                    string ReturnMessage = "";
                    string InitialMargin = "";

                    CommodityID = Convert.ToInt32(dgvCommodityLimits.Rows[riIndex].Cells["CommodityID"].Value.ToString());
                    LowLimit = dgvCommodityLimits.Rows[riIndex].Cells["LowLimit"].Value.ToString();
                    RangeLow = dgvCommodityLimits.Rows[riIndex].Cells["RangeLow"].Value.ToString();
                    RangeHigh = dgvCommodityLimits.Rows[riIndex].Cells["RangeHigh"].Value.ToString();
                    RoundingDivisor = dgvCommodityLimits.Rows[riIndex].Cells["RoundingDivisor"].Value.ToString();
                    InitialMargin = dgvCommodityLimits.Rows[riIndex].Cells["InitialMargin"].Value.ToString();


                    if (!clsMaintenance.UpdateHedgeLimits(LowLimit, RangeLow, RangeHigh, RoundingDivisor, CommodityID, InitialMargin, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage, "Commodity Maintenance");
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                    else
                    {
                        dtCommodities.Clear();
                        clsMaintenance.GetCommoditiesForEdit(dtCommodities);
                        dgvCommodityLimits.DataSource = dtCommodities;
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Commodity Maintenance");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

        private void dgvCommodityLimits_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvCommodityLimits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvCommodityLimits.EndEdit();
                isRowChanged = false;
            }
        }

        private void dgvCommodityTradingCompany_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int CommTradingCompID = 0;

            if (dgvCommodityTradingCompany.Columns[e.ColumnIndex].Name == "Delete")
            {
                Maintenance ordUpdate = new Maintenance();
                CommTradingCompID = Convert.ToInt32(dgvCommodityTradingCompany.Rows[e.RowIndex].Cells["TradingCompCommID"].Value.ToString());
                if (ordUpdate.DeleteCommoditiesTradingID(CommTradingCompID))
                {
                    dtTradingCompanies.Clear();
                    clsMaintenance.GetCommoditiesTradingCompaniesForEdit(dtTradingCompanies);
                    dgvCommodityTradingCompany.AutoGenerateColumns = false;
                    this.dgvCommodityTradingCompany.DataSource = dtTradingCompanies;
                }
            //                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
            //                "0", isChecked, ref SelectedAmount);
            }
            
        }

        private void dgvCommodityTradingCompany_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int TradingCompanyId = 0;
            int CommodityID = 0;
            int Year = 0;
            string Month = "";
            int CommTradingCompID = 0;

            if (e.ColumnIndex == dgvCommodityTradingCompany.Columns["chkDelete"].Index)
            {
                isRowChanged = false;
                isNotValidated = false;
                return;

            }
            if (isRowChanged)
            {
                try
                {
                    dgvCommodityTradingCompany.EndEdit();
                    CommTradingCompID = Convert.ToInt32(dgvCommodityTradingCompany.Rows[e.RowIndex].Cells["TradingCompCommID"].Value.ToString());
                    Year = Convert.ToInt32(dgvCommodityTradingCompany.Rows[e.RowIndex].Cells["Year"].Value.ToString());
                    CommodityID = Convert.ToInt32(dgvCommodityTradingCompany.Rows[e.RowIndex].Cells["TradeCommodity"].Value.ToString());
                    TradingCompanyId = Convert.ToInt32(dgvCommodityTradingCompany.Rows[e.RowIndex].Cells["TradingCompany"].Value.ToString());
                    Month = dgvCommodityTradingCompany.Rows[e.RowIndex].Cells["Month"].Value.ToString();
                                                         
                    string ReturnMessage = "";

                    
                    if (!clsMaintenance.UpdateCommodityTradingCompany(CommTradingCompID, Month, Year, CommodityID, TradingCompanyId, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage, "Commodity Trading Maintenance");
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                    else
                    {
                        dtTradingCompanies.Clear();
                        clsMaintenance.GetCommoditiesTradingCompaniesForEdit(dtTradingCompanies);
                        dgvCommodityTradingCompany.AutoGenerateColumns = false;
                        this.dgvCommodityTradingCompany.DataSource = dtTradingCompanies;
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Commodity Maintenance");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

  
        private void dgvCommodityTradingCompany_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvCommodityTradingCompany_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvCommodityTradingCompany_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvCommodityTradingCompany.CurrentCell.ColumnIndex;
                mRowIndex = dgvCommodityTradingCompany.CurrentCell.RowIndex;
            }
            isRowChanged = true;
        }

        private void dgvCommodityTradingCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvCommodityTradingCompany.EndEdit();
                isRowChanged = false;
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            int CommTradingCompID = 0;

            for (int row = 0; row < this.dgvCommodityTradingCompany.Rows.Count; row++)
            {
                if (dgvCommodityTradingCompany.Rows[row].Cells["chkDelete"].Value != null)
                {
                    if (dgvCommodityTradingCompany.Rows[row].Cells["chkDelete"].Value.ToString() == "True")
                    {
                        //MessageID = dgvECOrders.Rows[row].Cells["MessageID"].Value.ToString();
                        CommTradingCompID = Convert.ToInt32(dgvCommodityTradingCompany.Rows[row].Cells["TradingCompCommID"].Value.ToString());
                        //uLastPrice = dgvECOrders.Rows[row].Cells["uLastPrice"].Value.ToString();
                        //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
                        clsMaintenance.DeleteCommoditiesTradingID(CommTradingCompID);

                    }
                }


            }

            dtTradingCompanies.Clear();
            clsMaintenance.GetCommoditiesTradingCompaniesForEdit(dtTradingCompanies);
            dgvCommodityTradingCompany.AutoGenerateColumns = false;
            this.dgvCommodityTradingCompany.DataSource = dtTradingCompanies;
            dgvCommodityTradingCompany.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCommodityTradingCompanies frmAdd = new frmAddCommodityTradingCompanies();
            frmAdd.ShowDialog();
            dtTradingCompanies.Clear();
            clsMaintenance.GetCommoditiesTradingCompaniesForEdit(dtTradingCompanies);
            dgvCommodityTradingCompany.AutoGenerateColumns = false;
            this.dgvCommodityTradingCompany.DataSource = dtTradingCompanies;

        }

        private void btnGetOpenFutures_Click(object sender, EventArgs e)
        {
            OrdersUpdate ord = new OrdersUpdate();
            
            try
            {
                ord.UpdateClosingFuturesPrices();
                MessageBox.Show("Futures Prices have been updated", "Hedge Futures");
                dgvClosingFutures.AutoGenerateColumns = false;
                dtClosingFutures.Clear();
                clsMaintenance.GetClosingPrices(dtClosingFutures);
                this.dgvClosingFutures.DataSource = dtClosingFutures;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            

        }

        private void dgvClosingFutures_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int FuturesID = 0;

            if (dgvClosingFutures.Columns[e.ColumnIndex].Name == "FuturesDelete")
            {
                Maintenance ordUpdate = new Maintenance();
                FuturesID = Convert.ToInt32(dgvClosingFutures.Rows[e.RowIndex].Cells["FuturesID"].Value.ToString());
                if (ordUpdate.DeleteFuturesID(FuturesID))
                {
                    this.dtClosingFutures.Clear();
                    clsMaintenance.GetClosingPrices(dtClosingFutures);
                    dgvClosingFutures.AutoGenerateColumns = false;
                    this.dgvClosingFutures.DataSource = dtClosingFutures;
                }
                //                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                //                "0", isChecked, ref SelectedAmount);
            }
        }

        private void dgvClosingFutures_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvClosingFutures.CurrentCell.ColumnIndex;
                mRowIndex = dgvClosingFutures.CurrentCell.RowIndex;
            }
            isRowChanged = true;
        }

        private void dgvClosingFutures_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int FuturesID = 0;
            string FuturesPrice = "";
            string Month = "";
            string Year = "";
            string Commodity = "";
            string ReturnMessage = "";
            
            if (isRowChanged)
            {
                try
                {
                    dgvClosingFutures.EndEdit();
                    FuturesID = Convert.ToInt32(dgvClosingFutures.Rows[e.RowIndex].Cells["FuturesID"].Value.ToString());
                    FuturesPrice = dgvClosingFutures.Rows[e.RowIndex].Cells["ClosingPrice"].Value.ToString();
                    Month = dgvClosingFutures.Rows[e.RowIndex].Cells["FuturesMonth"].Value.ToString();
                    Year = dgvClosingFutures.Rows[e.RowIndex].Cells["FuturesYear"].Value.ToString();
                    Commodity = dgvClosingFutures.Rows[e.RowIndex].Cells["FuturesComm"].Value.ToString(); 
                    

                    if (!clsMaintenance.UpdateClosingFutures(FuturesID, Month, Year, FuturesPrice, Commodity, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage, "Closing Futures Maintenance");
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                    else
                    {
                        this.dtClosingFutures.Clear();
                        clsMaintenance.GetClosingPrices(dtClosingFutures);
                        dgvClosingFutures.AutoGenerateColumns = false;
                        this.dgvClosingFutures.DataSource = dtClosingFutures;
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Commodity Maintenance");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

        private void dgvClosingFutures_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvClosingFutures_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvClosingFutures.EndEdit();
                isRowChanged = false;
            }
        }

        private void dgvClosingFutures_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void btnDeleteMonthYear_Click(object sender, EventArgs e)
        {
            frmDeleteCommodityTradingCompanies frmDelete = new frmDeleteCommodityTradingCompanies();
            frmDelete.ShowDialog();
            dtTradingCompanies.Clear();
            clsMaintenance.GetCommoditiesTradingCompaniesForEdit(dtTradingCompanies);
            dgvCommodityTradingCompany.AutoGenerateColumns = false;
            this.dgvCommodityTradingCompany.DataSource = dtTradingCompanies;
        }

        private void btnAddEditCommodity_Click(object sender, EventArgs e)
        {
            frmCommodityAddEdit frmAdd = new frmCommodityAddEdit();
            frmAdd.mUpdate = 0;
            frmAdd.ShowDialog();
            LoadForm();
        }

        private void dgvCommodities_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCommodities.RowCount != 0)
            {
                int rowIndex = 0;
                rowIndex = dgvCommodities.CurrentCell.RowIndex;

                int CommodityID = Convert.ToInt32(dgvCommodities.Rows[rowIndex].Cells["CommCommodityID"].Value.ToString());
                dtCommoditiesMonths.Clear();
                this.dgvCommodityMonths.AutoGenerateColumns = false;
                clsMaintenance.GetCommoditiesMonths(CommodityID, this.dtCommoditiesMonths);
                this.dgvCommodityMonths.DataSource = dtCommoditiesMonths;
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            dtCommoditiesMonths.Clear();
            LoadForm();
        }

        

        private void dgvCommodityMonths_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int CommodityID = 0;
            string Month = "";
            int rowIndex = 0;
            rowIndex = dgvCommodities.CurrentCell.RowIndex;
            try
            {
                if (dgvCommodityMonths.Columns[e.ColumnIndex].Name == "MonthDelete")
                {
                    Maintenance ordUpdate = new Maintenance();
                    
                    Month = dgvCommodityMonths.Rows[e.RowIndex].Cells["MonthCode"].Value.ToString();
                    CommodityID = Convert.ToInt32(dgvCommodities.Rows[rowIndex].Cells["CommCommodityID"].Value.ToString());
                    if (ordUpdate.DeleteCommodityMonth(Month, CommodityID))
                    {
                        
                        dtCommoditiesMonths.Clear();
                        this.dgvCommodityMonths.AutoGenerateColumns = false;
                        clsMaintenance.GetCommoditiesMonths(CommodityID, this.dtCommoditiesMonths);
                        this.dgvCommodityMonths.DataSource = dtCommoditiesMonths;
                    }
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Commodity Maintenance");

            }
        }

        private void dgvCommodities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int CommodityID = 0;
            //string Month = "";
            int rowIndex = 0;
            rowIndex = dgvCommodities.CurrentCell.RowIndex;
            try
            {
                if (dgvCommodities.Columns[e.ColumnIndex].Name == "Edit")
                {
                    CommodityID = Convert.ToInt32(dgvCommodities.Rows[e.RowIndex].Cells["CommCommodityID"].Value.ToString());
                    frmCommodityAddEdit frmAdd = new frmCommodityAddEdit();
                    frmAdd.mCommodity = CommodityID.ToString();
                    if(this.chkActive.Checked == true)
                    {
                        frmAdd.inActive = 1;
                    }
                    else
                    {
                        frmAdd.inActive = 0;
                    }
                    
                    frmAdd.mUpdate = 1;
                    frmAdd.ShowDialog();
                    LoadForm();

                }

                if (dgvCommodities.Columns[e.ColumnIndex].Name == "CommodityDelete")
                {
                    Maintenance ordUpdate = new Maintenance();
                    CommodityID = Convert.ToInt32(dgvCommodities.Rows[e.RowIndex].Cells["CommCommodityID"].Value.ToString());
                    if (ordUpdate.DeleteCommodity(CommodityID))
                    {
                        LoadForm();
                    }

                }

                if (dgvCommodities.Columns[e.ColumnIndex].Name == "UnDelete")
                {
                    Maintenance ordUpdate = new Maintenance();
                    CommodityID = Convert.ToInt32(dgvCommodities.Rows[e.RowIndex].Cells["CommCommodityID"].Value.ToString());
                    if (ordUpdate.UnDeleteCommodity(CommodityID))
                    {
                        LoadForm();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Commodity Maintenance");

            }
        }

        private void btnAddCommodityMonth_Click(object sender, EventArgs e)
        {
            if (dgvCommodities.RowCount > 0)
            {
                int rowIndex = dgvCommodities.CurrentCell.RowIndex;
                int CommodityID = Convert.ToInt32(dgvCommodities.Rows[rowIndex].Cells["CommCommodityID"].Value.ToString());
                frmAddCommodityMonth frmAdd = new frmAddCommodityMonth();
                frmAdd.mCommodityID = CommodityID;
                frmAdd.ShowDialog();
                LoadForm();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == tpCommodity)
            //{
            //    MessageBox.Show("Currently in testing", "Hedgedesk");
            //    tabControl1.SelectedTab = tabPage2;

            //}
        }

        private void dgvCommodityLimits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
            
}



