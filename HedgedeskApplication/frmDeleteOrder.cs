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
    public partial class frmDeleteOrder : Form
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
        public Boolean fromRegion = false;
        public string ReplPrice = "0";
        public string ReplQty = "0";
        public string RequestID = "";
        public OrdersUpdate ord = new OrdersUpdate();

        public frmDeleteOrder()
        {
            InitializeComponent();
        }
         
        public void AddOrder(string Acct, string Ind, string Month, string Year, string Type,
            string Price, string Qty, string Comp, string Comm, string GTC)
        {

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
                if (viewOrder.Count > 0)
                {
                    this.txtAcct.Text = viewOrder[0]["A/C"].ToString();
                    this.txtInd.Text = viewOrder[0]["B/S"].ToString();
                    this.txtMonth.Text = viewOrder[0]["Month"].ToString();
                    this.txtYear.Text = viewOrder[0]["Year"].ToString();
                    this.txtOrdType.Text = viewOrder[0]["Type"].ToString();
                    if (fromRegion == true && (ReplPrice != "" && ReplPrice != "0"))
                    {
                        this.txtPrice.Text = ReplPrice.ToString();
                    }
                    else
                    {
                        this.txtPrice.Text = viewOrder[0]["Price"].ToString();
                    }
                    if (fromRegion == true && (ReplPrice != "" && ReplPrice != "0"))
                    {
                        this.txtQty.Text = ReplQty.ToString();
                    }
                    else
                    {
                        this.txtQty.Text = viewOrder[0]["Qty"].ToString();
                    }
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
                    //BuildLabel();
                }
                else
                {
                    MessageBox.Show("Order not found.", "Hedge Order");
                }

                mLoading = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                if (fromRegion == true)
                {
                    OrdersUpdate ord = new OrdersUpdate();
                    ord.UnSelectOrder(Convert.ToInt32(RequestID));
                }
            }

        }
      

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {

            string ReturnMessage = "";
            if (MessageBox.Show("Are you sure you want to delete order " + mOrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                ord.DeleteOrder(mOrderNumber, ref ReturnMessage);
                if (ReturnMessage != "")
                {
                    MessageBox.Show(ReturnMessage.ToString());
                }
                else
                {
                    this.Close();
                }
            }
        }

        
        private void ShowMessage(string OrderSent, string ReturnMessage)
        {
            if (OrderSent != "1")
            {
                MessageBox.Show(ReturnMessage.ToString());
            }
        }

    }


}
    


