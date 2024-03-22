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
    public partial class frmPurchaseSettleInquiry : Form
    {
        DataTable dtBuyOrders = new DataTable();

        DataTable dtSellOrders = new DataTable();
        public DataView viewAccounts = new DataView();
        public DataView viewMonths = new DataView();
        public DataView viewCommodities = new DataView();
        public DataView viewOrdTypes = new DataView();
        public DataView viewCompanies = new DataView();
        DataTable dtTradingCompanies = new DataTable();
        int mColumnIndex;
        int mRowIndex;
        Boolean isNotValidated = false;
        Boolean isRowChanged = false;

        PurchaseSettle clsPurchaseSettle = new PurchaseSettle();

        public frmPurchaseSettleInquiry()
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
            try
            {
                GlobalStore.FillAccountsDataTable();
                viewAccounts = GlobalStore.mdtAccounts.DefaultView;
                GlobalStore.FillMonthsDataTable();
                cboAcct.DataSource = GlobalStore.mdtAccounts.Copy();
                cboAcct.DisplayMember = "TP_ACCT";
                cboAcct.ValueMember = "TP_ACCT";
                viewMonths = GlobalStore.mdtMonths.DefaultView;
                cboMon.DataSource = GlobalStore.mdtMonths.Copy();
                cboMon.DisplayMember = "SelectMonth";
                cboMon.ValueMember = "TP_MON";
                GlobalStore.FillCommodityDataTable();
                viewCommodities = GlobalStore.mdtCommodity.DefaultView;
                this.cboCommodities.DataSource = GlobalStore.mdtCommodity.Copy();
                cboCommodities.DisplayMember = "TP_COMM";
                cboCommodities.ValueMember = "TP_COMM";
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
                this.cboComp.DataSource = viewCompanies;
                cboAcct.SelectedIndex = -1;
                cboMon.SelectedIndex = -1;
                cboCommodities.SelectedIndex = -1;
                GlobalStore.FillCompaniesDataTable();
                viewCompanies = GlobalStore.mdtComps.DefaultView;
                cboComp.DataSource = GlobalStore.mdtComps.Copy();
                cboComp.DisplayMember = "CompanyID";
                cboComp.ValueMember = "CompanyID";
                cboComp.SelectedIndex = -1;
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Trades");
            }

            
            
        }

        private void dgvBuyOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int OrderID = 0;

            if (dgvBuyOrders.Columns[e.ColumnIndex].Name == "Edit")
            {
                Maintenance ordUpdate = new Maintenance();
                OrderID = Convert.ToInt32(dgvBuyOrders.Rows[e.RowIndex].Cells["OrderID"].Value.ToString());
                frmEditPurchaseSellOrder frm = new frmEditPurchaseSellOrder();
                frm.mOrderNumber = OrderID;
                frm.ShowDialog();
                FindOrders();
                
            }
            if (dgvBuyOrders.Columns[e.ColumnIndex].Name == "Apps")
            {
                Maintenance ordUpdate = new Maintenance();
                OrderID = Convert.ToInt32(dgvBuyOrders.Rows[e.RowIndex].Cells["OrderID"].Value.ToString());
                frmPurchaseSettleEditApplications frm = new frmPurchaseSettleEditApplications();
                frm.mOrderNumber = OrderID;
                frm.ShowDialog();
                //FindOrders();

            }
            if (dgvBuyOrders.Columns[e.ColumnIndex].Name == "BuyDelete")
            {
                try
                {
                    string ReturnMessage = "";

                    OrderID = Convert.ToInt32(dgvBuyOrders.Rows[e.RowIndex].Cells["OrderID"].Value.ToString());
                    if (MessageBox.Show("Delete Buy Order " + OrderID.ToString() + "?", "Hedge Order", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
                    {
                        clsPurchaseSettle.DeletePurchaseSettleBuyOrder(OrderID, ref ReturnMessage);
                        if (ReturnMessage != "")
                        {
                            MessageBox.Show(ReturnMessage, "HedgeOrder");
                        }
                        else
                        {
                            dtBuyOrders.Clear();
                            FindOrders();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void btnFindOrders_Click(object sender, EventArgs e)
        {
            FindOrders();
            
        }

        private void FindOrders()
        {
            Int32 Account = 0;
            Int32 OrderNumberFrom = 0;
            Int32 OrderNumberTo = 0;
            Int32 OrderID = 0;
            String OrderType = "";

            if (cboOrderType.Text != "")
            {
                OrderType = this.cboOrderType.SelectedValue.ToString();
            }

            if (cboAcct.Text != "")
            {
                Account = Convert.ToInt32(cboAcct.Text);
            }
            if (txtOrderID.Text != "")
            {
                OrderID = Convert.ToInt32(txtOrderID.Text);
            }
            if (this.txtOrderFrom.Text != "")
            {
                OrderNumberFrom = Convert.ToInt32(txtOrderFrom.Text);
            }
            if (txtOrderTo.Text != "")
            {
                OrderNumberTo = Convert.ToInt32(txtOrderTo.Text);
            }

            try
            {
                dtBuyOrders.Clear();
                clsPurchaseSettle.GetPurchaseSettleBuyOrders(cboComp.Text, Account, cboOrderType.Text, cboCommodities.Text, txtCardNo.Text, cboTransferred.Text,
                   cboTradingCompanies.Text, cboMon.Text, txtYear.Text, OrderID, OrderNumberFrom, OrderNumberTo, dtpFrom.Value.ToShortDateString(), dtpTo.Value.ToShortDateString(), dtBuyOrders);

                dgvBuyOrders.AutoGenerateColumns = false;
                dgvBuyOrders.DataSource = dtBuyOrders;
                if (dtBuyOrders.Rows.Count > 0)
                {
                    txtBuyContracts.Text = dtBuyOrders.Rows[0]["TotalAmount"].ToString();
                }
                else
                {
                    txtBuyContracts.Text = "0";
                }
 

                dtSellOrders.Clear();
                clsPurchaseSettle.GetPurchaseSettleSellOrders(cboComp.Text, Account, cboOrderType.Text, cboCommodities.Text, txtCardNo.Text, cboTransferred.Text,
                   cboTradingCompanies.Text, cboMon.Text, txtYear.Text, OrderID, OrderNumberFrom, OrderNumberTo, dtpFrom.Value.ToShortDateString(), dtpTo.Value.ToShortDateString(), dtSellOrders);

                dgvSellOrders.AutoGenerateColumns = false;
                dgvSellOrders.DataSource = dtSellOrders;
                if (dtSellOrders.Rows.Count > 0)
                {
                    txtSellContracts.Text = dtSellOrders.Rows[0]["TotalAmount"].ToString();
                }
                else
                {
                    txtSellContracts.Text = "0";
                }

                //txtSellContracts.Text = dtSellOrders.Rows[0]["TotalAmount"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void Print_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented.", "Hedge Orders");
        }

        private void dgvBuyOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvBuyOrders.EndEdit();
                isRowChanged = false;
            }
        }

        private void dgvBuyOrders_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvBuyOrders.CurrentCell.ColumnIndex;
                mRowIndex = dgvBuyOrders.CurrentCell.RowIndex;
            }
            isRowChanged = true;
        }

        private void dgvBuyOrders_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvBuyOrders_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBuyOrders_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    dgvBuyOrders.EndEdit();
                    string rIndex = dgvBuyOrders.Rows[e.RowIndex].Index.ToString();
                    int riIndex = Convert.ToInt16(rIndex);
                    string CardNumber = "";
                    string Amount = "";
                    string OrderType = "";
                    int OrderID = 0;
                    string FilledPrice = "";
                    string Comments = "";
                    string ReturnMessage = "";

                    OrderID = Convert.ToInt32(dgvBuyOrders.Rows[riIndex].Cells["OrderID"].Value.ToString());
                    CardNumber = dgvBuyOrders.Rows[riIndex].Cells["CardNumber"].Value.ToString();
                    Amount = dgvBuyOrders.Rows[riIndex].Cells["Amount"].Value.ToString();
                    OrderType = dgvBuyOrders.Rows[riIndex].Cells["OrdType"].Value.ToString();
                    FilledPrice = dgvBuyOrders.Rows[riIndex].Cells["FilledPrice"].Value.ToString();
                    Comments = dgvBuyOrders.Rows[riIndex].Cells["Comments"].Value.ToString();
                   
                    if (!clsPurchaseSettle.UpdatePurchaseSettleBuyOrdersLimited(OrderID, CardNumber, Amount, OrderType, FilledPrice, Comments, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage, "Hedge Orders");
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                    else
                    {
                        dtBuyOrders.Clear();
                        FindOrders();
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

        private void dgvBuyOrders_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvBuyOrders_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvBuyOrders_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Int32 OrderID = 0;
                string ReturnMessage = "";
                
                OrderID = Convert.ToInt32(dgvBuyOrders.Rows[e.RowIndex].Cells["OrderID"].Value.ToString());
                if (MessageBox.Show("Delete Buy Order " + OrderID.ToString() + "?", "Hedge Order", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
                {
                    clsPurchaseSettle.DeletePurchaseSettleBuyOrder(OrderID, ref ReturnMessage);
                    if (ReturnMessage != "")
                    {
                        MessageBox.Show(ReturnMessage, "HedgeOrder");
                    }
                    else
                    {
                        dtBuyOrders.Clear();
                        FindOrders();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Maintenance ordUpdate = new Maintenance();
                frmAddPurchaseSellOrder frm = new frmAddPurchaseSellOrder();
                frm.ShowDialog();
                FindOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Orders");
            }
        }

        private void dgvSellOrders_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    dgvSellOrders.EndEdit();
                    string rIndex = dgvSellOrders.Rows[e.RowIndex].Index.ToString();
                    int riIndex = Convert.ToInt16(rIndex);
                    string CardNumber = "";
                    string Amount = "";
                    string OrderType = "";
                    int OrderID = 0;
                    string FilledPrice = "";
                    string Comments = "";
                    string ReturnMessage = "";

                    OrderID = Convert.ToInt32(dgvSellOrders.Rows[riIndex].Cells["SellOrderID"].Value.ToString());
                    CardNumber = dgvSellOrders.Rows[riIndex].Cells["SellCardNumber"].Value.ToString();
                    Amount = dgvSellOrders.Rows[riIndex].Cells["SellAmount"].Value.ToString();
                    OrderType = dgvSellOrders.Rows[riIndex].Cells["SellOrdType"].Value.ToString();
                    FilledPrice = dgvSellOrders.Rows[riIndex].Cells["SellFillPrice"].Value.ToString();
                    Comments = dgvSellOrders.Rows[riIndex].Cells["SellComments"].Value.ToString();

                    if (!clsPurchaseSettle.UpdatePurchaseSettleSellOrdersLimited(OrderID, CardNumber, Amount, OrderType, FilledPrice, Comments, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage, "Hedge Orders");
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                    else
                    {
                        dtSellOrders.Clear();
                        FindOrders();
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

        private void dgvSellOrders_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvSellOrders_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgvSellOrders_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvSellOrders.CurrentCell.ColumnIndex;
                mRowIndex = dgvSellOrders.CurrentCell.RowIndex;
            }
            isRowChanged = true;
        }

        private void dgvSellOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int OrderID = 0;

            if (dgvSellOrders.Columns[e.ColumnIndex].Name == "SellEdit")
            {
                Maintenance ordUpdate = new Maintenance();
                OrderID = Convert.ToInt32(dgvSellOrders.Rows[e.RowIndex].Cells["SellOrderID"].Value.ToString());
                frmEditPurchaseSettleSellOrder frm = new frmEditPurchaseSettleSellOrder();
                frm.mOrderNumber = OrderID;
                frm.ShowDialog();
                FindOrders();

            }
            if (dgvSellOrders.Columns[e.ColumnIndex].Name == "SellApps")
            {
                Maintenance ordUpdate = new Maintenance();
                OrderID = Convert.ToInt32(dgvSellOrders.Rows[e.RowIndex].Cells["SellOrderID"].Value.ToString());
                frmPurchaseSettleEditSellApplications frm = new frmPurchaseSettleEditSellApplications();
                frm.mOrderNumber = OrderID;
                frm.ShowDialog();
                //FindOrders();

            }

            if (dgvSellOrders.Columns[e.ColumnIndex].Name == "SellDelete")
            {
                try
                {
                    string ReturnMessage = "";

                    OrderID = Convert.ToInt32(dgvSellOrders.Rows[e.RowIndex].Cells["SellOrderID"].Value.ToString());
                    if (MessageBox.Show("Delete Sell Order " + OrderID.ToString() + "?", "Hedge Order", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
                    {
                        clsPurchaseSettle.DeletePurchaseSettleSellOrder(OrderID, ref ReturnMessage);
                        if (ReturnMessage != "")
                        {
                            MessageBox.Show(ReturnMessage, "HedgeOrder");
                        }
                        else
                        {
                            dtSellOrders.Clear();
                            FindOrders();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void dgvSellOrders_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Int32 OrderID = 0;
                string ReturnMessage = "";

                OrderID = Convert.ToInt32(dgvBuyOrders.Rows[e.RowIndex].Cells["SellOrderID"].Value.ToString());
                if (MessageBox.Show("Delete Sell Order " + OrderID.ToString() + "?", "Hedge Order", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
                {
                    clsPurchaseSettle.DeletePurchaseSettleSellOrder(OrderID, ref ReturnMessage);
                    if (ReturnMessage != "")
                    {
                        MessageBox.Show(ReturnMessage, "HedgeOrder");
                    }
                    else
                    {
                        dtSellOrders.Clear();
                        FindOrders();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
