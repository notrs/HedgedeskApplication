using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Security.Principal;

namespace HedgedeskApplication
{
    public partial class frmDeleteOrderSpread : Form
    {
        public frmOrders frmCopyOrders;
        public DataView viewAccounts = new DataView();
        public DataView viewMonths = new DataView();
        public DataView viewCommodities = new DataView();
        public DataView viewOrdTypes = new DataView();
        public DataView viewAccountComps = new DataView();
        public DataView viewClosingPrices = new DataView();
        public DataView viewOrder = new DataView();
        public Boolean mLoading;
        public Int32 mOrderNumber;

        public frmDeleteOrderSpread()
        {
            InitializeComponent();
        }


        private void frmAddOrder_Load(object sender, EventArgs e)
        {
            try
            {
                mLoading = true;
                GlobalStore.FillAccountsDataTable();
                viewAccounts = GlobalStore.mdtAccounts.DefaultView;
                GlobalStore.FillMonthsDataTable();
                viewMonths = GlobalStore.mdtMonths.DefaultView;
                GlobalStore.FillCommodityDataTable();
                viewCommodities = GlobalStore.mdtCommodity.DefaultView;
                GlobalStore.FillAccountCompsDataTable();
                viewAccountComps = GlobalStore.mdtAccountsComps.DefaultView;
                GlobalStore.FillOrderTypesDataTable();
                viewOrdTypes = GlobalStore.mdtOrderTypes.DefaultView;
                GlobalStore.mdsOrder.Clear();
                GlobalStore.FillOrderDataTable(mOrderNumber.ToString());
                viewOrder = GlobalStore.mdsOrder.DefaultView;
                string SpreadID = viewOrder[0]["SecondID"].ToString();
                this.txtAcct.Text = viewOrder[0]["A/C"].ToString();
                this.txtInd.Text = viewOrder[0]["B/S"].ToString();
                this.txtMonth.Text = viewOrder[0]["Month"].ToString();
                this.txtYear.Text = viewOrder[0]["Year"].ToString();
                this.txtOrdType.Text = viewOrder[0]["Type"].ToString();
                this.txtPrice.Text = viewOrder[0]["Price"].ToString();
                this.txtQty.Text = viewOrder[0]["Qty"].ToString();
                this.txtComp.Text = viewOrder[0]["Comp"].ToString();
                this.txtComm.Text = viewOrder[0]["Comm"].ToString();
                this.lblOrderNumber.Text = mOrderNumber.ToString();
                if (viewOrder[0]["GTC"].ToString() == "1")
                {
                    this.GTC.Checked = true;
                }
                else
                {
                    this.GTC.Checked = false;
                }
                GlobalStore.mdsOrder.Clear();
                GlobalStore.FillOrderDataTable(SpreadID.ToString());
                viewOrder = GlobalStore.mdsOrder.DefaultView;
                this.txtSAcct.Text = viewOrder[0]["A/C"].ToString();
                this.txtSInd.Text = viewOrder[0]["B/S"].ToString();
                this.txtSMonth.Text = viewOrder[0]["Month"].ToString();
                this.txtSYear.Text = viewOrder[0]["Year"].ToString();
                this.txtSOrdType.Text = viewOrder[0]["Type"].ToString();
                this.txtSComp.Text = viewOrder[0]["Comp"].ToString();
                this.txtSComm.Text = viewOrder[0]["Comm"].ToString();
                //BuildLabel();
                mLoading = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
            }

        }




        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string ReturnMessage = "";
            OrdersNew ord = new OrdersNew();
            ord.DeleteOrder(mOrderNumber, ref ReturnMessage);
        }

    }


}
    


