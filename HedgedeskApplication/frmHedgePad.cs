using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Timers;
using System.Security.Permissions;

namespace HedgedeskApplication
{
    public partial class frmHedgePad : Form
    {
        public BindingSource bsCorn = new BindingSource();
        BindingSource bsBean2 = new BindingSource();
        BindingSource bsBean3 = new BindingSource();
        BindingSource bsBean5 = new BindingSource();
        BindingSource bsCorn3 = new BindingSource();
        BindingSource bsCorn5 = new BindingSource();

        BindingSource bsWheat = new BindingSource();
        BindingSource bsWheat3 = new BindingSource();
        BindingSource bsWheat5 = new BindingSource();
        BindingSource bsKC = new BindingSource();
        BindingSource bsKC3 = new BindingSource();
        BindingSource bsKC5 = new BindingSource();

        BindingSource bsCornTotal = new BindingSource();
        BindingSource bsCorn3Total = new BindingSource();
        BindingSource bsCorn5Total = new BindingSource();

        BindingSource bsWheatTotal = new BindingSource();
        BindingSource bsWheat3Total = new BindingSource();
        BindingSource bsWheat5Total = new BindingSource();

        BindingSource bsKCTotal = new BindingSource();
        BindingSource bsKC3Total = new BindingSource();
        BindingSource bsKC5Total = new BindingSource();
        BindingSource bsBeans2Total = new BindingSource();
        BindingSource bsBeans3Total = new BindingSource();
        BindingSource bsBeans5Total = new BindingSource();
        DataTable dtBean3 = new DataTable();
        DataTable dtBean5 = new DataTable();

        DataTable dtBean2 = new DataTable();
        DataTable dtCorn2 = new DataTable();
        DataTable dtCorn3 = new DataTable();
        DataTable dtCorn5 = new DataTable();

        DataTable dtWheat2 = new DataTable();
        DataTable dtWheat3 = new DataTable();
        DataTable dtWheat5 = new DataTable();



        DataTable dtKC2 = new DataTable();
        DataTable dtKC3 = new DataTable();
        DataTable dtKC5 = new DataTable();

        DataTable dtCorn2Total = new DataTable();
        DataTable dtCorn3Total = new DataTable();
        DataTable dtCorn5Total = new DataTable();

        DataTable dtWheat2Total = new DataTable();
        DataTable dtWheat5Total = new DataTable();
        DataTable dtBeans3Total = new DataTable();

        DataTable dtKC2Total = new DataTable();
        DataTable dtKC3Total = new DataTable();
        DataTable dtKC5Total = new DataTable();

        DataTable dtBeans2Total = new DataTable();
        DataTable dtBeans5Total = new DataTable();


        DataTable dtOrders = new DataTable();
        public DataView viewAccountComps = new DataView();
        public DataView viewCommodities = new DataView();
        int mColumnIndex;

        public frmHedgePad()
        {
            InitializeComponent();
            PopulateDataForPosition();
            tmHedgePadTimer.Interval = 30000;
            tmHedgePadTimer.Start();

        }



        public Boolean PopulateDataForPosition()
        {
            try
            {

                GlobalStore.mdtBeanPosition_HedgePad.Clear();
                GlobalStore.mdtBeanPosition_HedgePad.Dispose();
                GlobalStore.mdtKCPosition_HedgePad.Clear();
                GlobalStore.mdtKCPosition_HedgePad.Dispose();
                GlobalStore.mdtCornPosition_HedgePad.Clear();
                GlobalStore.mdtCornPosition_HedgePad.Dispose();
                GlobalStore.mdtWheatPosition_HedgePad.Clear();
                GlobalStore.mdtWheatPosition_HedgePad.Dispose();

                GlobalStore.mdtCornTotal_HedgePad.Clear();
                GlobalStore.mdtCornTotal_HedgePad.Dispose();
                GlobalStore.mdtBeansTotal_HedgePad.Clear();
                GlobalStore.mdtBeansTotal_HedgePad.Dispose();
                GlobalStore.mdtKCTotal_HedgePad.Clear();
                GlobalStore.mdtKCTotal_HedgePad.Dispose();
                GlobalStore.mdtWheatTotal_HedgePad.Clear();
                dtOrders.Clear();

                OrdersUpdate ord = new OrdersUpdate();
                ord.GetUnfilledHedgepadOrders(dtOrders);
                viewAccountComps = GlobalStore.mdtAccountsComps.DefaultView;
                ord.UpdateStartingPosition();
                dtBean2.Clear();
                GlobalStore.FillBeanDataTable_HedgePad("11".ToString());
                dtBean2 = GlobalStore.mdtBeanPosition_HedgePad.Copy();

                GlobalStore.FillCornDataTable_HedgePad("11".ToString());
                dtCorn2.Clear();
                dtCorn2 = GlobalStore.mdtCornPosition_HedgePad.Copy();

                GlobalStore.FillWheatDataTable_HedgePad("11".ToString());
                dtWheat2.Clear();
                dtWheat2 = GlobalStore.mdtWheatPosition_HedgePad.Copy();

                GlobalStore.FillKCDataTable_HedgePad("11".ToString());
                dtKC2.Clear();
                dtKC2 = GlobalStore.mdtKCPosition_HedgePad.Copy();

                this.dgvOrders.AutoGenerateColumns = false;
                this.dgvOrders.DataSource = dtOrders;

                dgvHedgeCorn.AutoGenerateColumns = false;
                this.dgvHedgeCorn.DataSource = dtCorn2;

                dgvHedgeBean.AutoGenerateColumns = false;
                this.dgvHedgeBean.DataSource = dtBean2;

                dgvHedgeWheat.AutoGenerateColumns = false;
                this.dgvHedgeWheat.DataSource = dtWheat2;

                this.dgvKCWheat.AutoGenerateColumns = false;
                this.dgvKCWheat.DataSource = dtKC2;

                if (dtCorn2.Rows.Count != 0)
                {
                    this.txtC2Begin.Text = dtCorn2.DefaultView[0]["Begin2"].ToString();
                    this.txtC2Current.Text = dtCorn2.DefaultView[0]["Total2"].ToString();
                    this.txtCorn2Total.Text = dtCorn2.DefaultView[0]["Total2"].ToString();


                }

                if (dtBean2.Rows.Count != 0)
                {
                    this.txtB2Begin.Text = dtBean2.DefaultView[0]["Begin2"].ToString();
                    this.txtB2Current.Text = dtBean2.DefaultView[0]["Total2"].ToString();
                    this.txtBean2Total.Text = dtBean2.DefaultView[0]["Total2"].ToString();
                    this.txtB3Begin.Text = dtBean2.DefaultView[0]["Begin3"].ToString();
                    this.txtB3Current.Text = dtBean2.DefaultView[0]["Total3"].ToString();
                    this.txtBean3Total.Text = dtBean2.DefaultView[0]["Total3"].ToString();

                }

                if (dtWheat2.Rows.Count != 0)
                {
                    this.txtW2Begin.Text = dtWheat2.DefaultView[0]["Begin2"].ToString();
                    this.txtW2Current.Text = dtWheat2.DefaultView[0]["Total2"].ToString();
                    this.txtWheat2Total.Text = dtWheat2.DefaultView[0]["Total2"].ToString();

                }

                if (dtKC2.Rows.Count != 0)
                {
                    this.txtKC2Begin.Text = dtKC2.DefaultView[0]["Begin2"].ToString();
                    this.txtKC2Current.Text = dtKC2.DefaultView[0]["Total2"].ToString();
                    this.txtKC2Total.Text = dtKC2.DefaultView[0]["Total2"].ToString();

                }


                this.Refresh();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }

        public Boolean RefreshDataForPosition()
        {
            try
            {

                this.Refresh();


                return true;


            }
            catch (Exception)
            {
                MessageBox.Show("Error getting data from database.  Please close and reopen application.", "Hedge Error");
                return false;
            }


        }



        private void PlaceOrder(int AccountNumber, string Commodity, string Year, string Price, string Quantity, string Month, string bs, string DTNPrice)
        {
            frmOrderPlace frmOrder = new frmOrderPlace();
            OrdersNew clsOrdersNew = new OrdersNew();

            try
            {
                frmOrder.mAcct = AccountNumber;
                frmOrder.mCommodity = Commodity;
                frmOrder.mMonth = Month;
                frmOrder.mYear = Year;
                frmOrder.mPrice = Price;
                frmOrder.mDTNPrice = DTNPrice;
                frmOrder.mQty = Quantity;
                frmOrder.mBS = bs;
                frmOrder.ShowDialog(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmOrder.Dispose();
            RefreshPositions();

        }


        public void RefreshPositions()
        {
            tmHedgePadTimer.Stop();
            if (PopulateDataForPosition())
            {
                tmHedgePadTimer.Interval = 30000;
                tmHedgePadTimer.Start();
            }
            else
            {
                if (MessageBox.Show("Error getting data from database.  Try again?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    if (PopulateDataForPosition())
                    {
                        tmHedgePadTimer.Interval = 30000;
                        tmHedgePadTimer.Start();
                    }
                    else
                    {
                        MessageBox.Show("Error getting data from database.  Please Contact System Admin.", "Hedge Order", MessageBoxButtons.OK);

                    }
                }
            }

        }

        private void tmHedgePadTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                RefreshPositions();
            }
            catch (Exception)
            {
                this.tmHedgePadTimer.Stop();
                MessageBox.Show("Error getting data from database.  Please contact system administration.", "Hedge Order");
                return;
            }
        }


        private void dgvHedgeCorn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            tmHedgePadTimer.Interval = 30000;
            Int32 AccountNumber = 0;
            Int32 QuantityInt;
            Decimal Quantity;
            String BS;
            Int32 iRowIndex = Convert.ToInt32(e.RowIndex);
            string QuantitySent;
            switch (dgvHedgeCorn.Columns[e.ColumnIndex].Name)
            {
                case "CMECorn2":
                    AccountNumber = 2;
                    QuantitySent = dgvHedgeCorn.Rows[iRowIndex].Cells["Acct2C"].Value.ToString();
                    break;
                case "CMECorn3":
                    AccountNumber = 3;
                    QuantitySent = dgvHedgeCorn.Rows[iRowIndex].Cells["Acct3C"].Value.ToString();
                    break;
                case "CMECorn5":
                    AccountNumber = 5;
                    QuantitySent = dgvHedgeCorn.Rows[iRowIndex].Cells["Acct5C"].Value.ToString();
                    break;
                default:
                    AccountNumber = 0;
                    QuantitySent = 0.ToString();
                    break;
            }
            if (AccountNumber == 0)
            {
                return;
            }
            if (QuantitySent == "")
            {
                QuantitySent = "0";
            }
            Quantity = Convert.ToDecimal(QuantitySent);
            QuantityInt = Convert.ToInt32(Quantity);
            if (QuantityInt == 0) { QuantityInt = 1; }
            QuantitySent = QuantityInt.ToString();
            if (QuantityInt > 0)
            {
                BS = "S";

            }
            else
            {
                BS = "B";
                QuantitySent = (QuantityInt * -1).ToString();
            }


            OrdersNew ord = new OrdersNew();
            try
            {
                DataTable dtCommPrice = new DataTable();
                DataTable dtHedgePrice = new DataTable();
                string OrderType = "ORD";

                String HedgeMonth = dgvHedgeCorn.Rows[iRowIndex].Cells["Month"].Value.ToString();
                String HedgeYear = dgvHedgeCorn.Rows[iRowIndex].Cells["Year"].Value.ToString();

                ord.GetPrice(22, HedgeMonth, HedgeYear, dtHedgePrice);
                String Price = dtHedgePrice.DefaultView[0]["FilledPrice"].ToString();

                ord.GetCMEPrice(22, HedgeMonth, HedgeYear, dtCommPrice);
                String DTNPrice = dtCommPrice.DefaultView[0]["Price"].ToString();

                if (OrderType == "SPR")
                {
                    //ReviseOrderSpread(OrderNumber);
                }
                else
                {
                    PlaceOrder(AccountNumber, "22", HedgeYear, Price.ToString(), QuantitySent, HedgeMonth, BS, DTNPrice.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }

        }

 
        private void dgvHedgeBean_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tmHedgePadTimer.Interval = 15000;
            Int32 AccountNumber = 0;
            Int32 QuantityInt;
            Decimal Quantity;
            String BS;
            Int32 iRowIndex = Convert.ToInt32(e.RowIndex);
            string QuantitySent;
            switch (dgvHedgeBean.Columns[e.ColumnIndex].Name)
            {
                case "CMEBean2":
                    AccountNumber = 2;
                    QuantitySent = dgvHedgeBean.Rows[iRowIndex].Cells["Acct2B"].Value.ToString();
                    break;
                case "CMEBean3":
                    AccountNumber = 3;
                    QuantitySent = dgvHedgeBean.Rows[iRowIndex].Cells["Acct3B"].Value.ToString();
                    break;
                case "CMEBean5":
                    AccountNumber = 5;
                    QuantitySent = dgvHedgeBean.Rows[iRowIndex].Cells["Acct5B"].Value.ToString();
                    break;
                default:
                    AccountNumber = 0;
                    QuantitySent = 0.ToString();
                    break;
            }
            if (AccountNumber == 0)
            {
                return;
            }
            if (QuantitySent == "")
            {
                QuantitySent = "0";
            }
            Quantity = Convert.ToDecimal(QuantitySent);
            QuantityInt = Convert.ToInt32(Quantity);
            if (QuantityInt == 0) { QuantityInt = 1; }
            QuantitySent = QuantityInt.ToString();
            if (QuantityInt > 0)
            {
                BS = "S";

            }
            else
            {
                BS = "B";
                QuantitySent = (QuantityInt * -1).ToString();
            }


            OrdersNew ord = new OrdersNew();
            try
            {
                DataTable dtCommPrice = new DataTable();
                DataTable dtHedgePrice = new DataTable();

                string OrderType = "ORD";

                String HedgeMonth = dgvHedgeBean.Rows[iRowIndex].Cells["MonthB"].Value.ToString();
                String HedgeYear = dgvHedgeBean.Rows[iRowIndex].Cells["YearB"].Value.ToString();

                ord.GetPrice(24, HedgeMonth, HedgeYear, dtHedgePrice);
                String Price = dtHedgePrice.DefaultView[0]["FilledPrice"].ToString();
                String LastDate = dtHedgePrice.DefaultView[0]["DateAdded"].ToString();

                ord.GetCMEPrice(24, HedgeMonth, HedgeYear, dtCommPrice);
                String DTNPrice = dtCommPrice.DefaultView[0]["Price"].ToString();
                if (OrderType == "SPR")
                {
                    //ReviseOrderSpread(OrderNumber);
                }
                else
                {
                    PlaceOrder(AccountNumber, "24", HedgeYear, Price.ToString(), QuantitySent, HedgeMonth, BS, DTNPrice.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }

        }

        private void dgvHedgeWheat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tmHedgePadTimer.Interval = 15000;
            Int32 AccountNumber = 0;
            Int32 QuantityInt;
            Decimal Quantity;
            String BS;
            Int32 iRowIndex = Convert.ToInt32(e.RowIndex);
            string QuantitySent = "0";
            switch (dgvHedgeWheat.Columns[e.ColumnIndex].Name)
            {
                case "CMEWheat2":
                    AccountNumber = 2;
                    QuantitySent = dgvHedgeWheat.Rows[iRowIndex].Cells["Acct2W"].Value.ToString();
                    break;
                case "CMEWheat3":
                    AccountNumber = 3;
                    QuantitySent = dgvHedgeWheat.Rows[iRowIndex].Cells["Acct3W"].Value.ToString();
                    break;
                case "CMEWheat5":
                    AccountNumber = 5;
                    QuantitySent = dgvHedgeWheat.Rows[iRowIndex].Cells["Acct5W"].Value.ToString();
                    break;
                default:
                    AccountNumber = 0;
                    QuantitySent = 0.ToString();
                    break;
            }
            if (AccountNumber == 0)
            {
                return;
            }
            if (QuantitySent == "")
            {
                QuantitySent = "0";
            }
            Quantity = Convert.ToDecimal(QuantitySent);
            QuantityInt = Convert.ToInt32(Quantity);
            if (QuantityInt == 0) { QuantityInt = 1; }
            QuantitySent = QuantityInt.ToString();
            if (QuantityInt > 0)
            {
                BS = "S";

            }
            else
            {
                BS = "B";
                QuantitySent = (QuantityInt * -1).ToString();
            }


            OrdersNew ord = new OrdersNew();
            try
            {
                DataTable dtCommPrice = new DataTable();
                DataTable dtHedgePrice = new DataTable();

                string OrderType = "ORD";

                String HedgeMonth = dgvHedgeWheat.Rows[iRowIndex].Cells["MonthW"].Value.ToString();
                String HedgeYear = dgvHedgeWheat.Rows[iRowIndex].Cells["YearW"].Value.ToString();

                ord.GetPrice(25, HedgeMonth, HedgeYear, dtHedgePrice);
                String Price = dtHedgePrice.DefaultView[0]["FilledPrice"].ToString();
                ord.GetCMEPrice(25, HedgeMonth, HedgeYear, dtCommPrice);
                String DTNPrice = dtCommPrice.DefaultView[0]["Price"].ToString();
                if (OrderType == "SPR")
                {
                    //ReviseOrderSpread(OrderNumber);
                }
                else
                {
                    PlaceOrder(AccountNumber, "25", HedgeYear, Price.ToString(), QuantitySent, HedgeMonth, BS, DTNPrice);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void dgvKCWheat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tmHedgePadTimer.Interval = 15000;
            Int32 AccountNumber = 0;
            Int32 QuantityInt;
            Decimal Quantity;
            String BS;
            Int32 iRowIndex = Convert.ToInt32(e.RowIndex);
            string QuantitySent = "0";
            switch (dgvKCWheat.Columns[e.ColumnIndex].Name)
            {
                case "CMEKC2":
                    AccountNumber = 2;
                    QuantitySent = dgvKCWheat.Rows[iRowIndex].Cells["Acct2KC"].Value.ToString();
                    break;
                case "CMEKC3":
                    AccountNumber = 3;
                    QuantitySent = dgvKCWheat.Rows[iRowIndex].Cells["Acct3KC"].Value.ToString();
                    break;
                case "CMEKC5":
                    AccountNumber = 5;
                    QuantitySent = dgvKCWheat.Rows[iRowIndex].Cells["Acct5KC"].Value.ToString();
                    break;
                default:
                    AccountNumber = 0;
                    QuantitySent = 0.ToString();
                    break;
            }
            if (AccountNumber == 0)
            {
                return;
            }
            if (QuantitySent == "")
            {
                QuantitySent = "0";
            }
            Quantity = Convert.ToDecimal(QuantitySent);
            QuantityInt = Convert.ToInt32(Quantity);
            if (QuantityInt == 0) { QuantityInt = 1; }
            QuantitySent = QuantityInt.ToString();
            if (QuantityInt > 0)
            {
                BS = "S";

            }
            else
            {
                BS = "B";
                QuantitySent = (QuantityInt * -1).ToString();
            }


            OrdersNew ord = new OrdersNew();
            try
            {
                DataTable dtCommPrice = new DataTable();
                DataTable dtHedgePrice = new DataTable();

                string OrderType = "ORD";

                String HedgeMonth = dgvKCWheat.Rows[iRowIndex].Cells["MonthKC"].Value.ToString();
                String HedgeYear = dgvKCWheat.Rows[iRowIndex].Cells["YearKC"].Value.ToString();

                ord.GetPrice(26, HedgeMonth, HedgeYear, dtHedgePrice);
                String Price = dtHedgePrice.DefaultView[0]["FilledPrice"].ToString();
                ord.GetCMEPrice(26, HedgeMonth, HedgeYear, dtCommPrice);
                String DTNPrice = dtCommPrice.DefaultView[0]["Price"].ToString();
                if (OrderType == "SPR")
                {
                    //ReviseOrderSpread(OrderNumber);
                }
                else
                {
                    PlaceOrder(AccountNumber, "26", HedgeYear, Price.ToString(), QuantitySent, HedgeMonth, BS, DTNPrice);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdRefreshPositions_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void CancelOrder(int OrderNumber, ref string OrderSent)
        {
            OrdersNew clsOrdersNew = new OrdersNew();
            string ErrorMessage = "";
            string OverrideMessage = "";
            string Override = "N";
            //string OrderSent = "";
            string ReturnMessage = "";
            try
            {
                clsOrdersNew.CancelOrder(OrderNumber, ref ErrorMessage, ref OverrideMessage, Override, ref OrderSent, ref ReturnMessage);
                if (OverrideMessage == "Y")
                {

                    if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to cancel order " + OrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        clsOrdersNew.CancelOrder(OrderNumber, ref ErrorMessage, ref OverrideMessage, "Y", ref OrderSent, ref ReturnMessage);
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                        RefreshPositions();


                    }
                }
                else
                {
                    if (ErrorMessage != "")
                    {
                        ShowMessage("4", ErrorMessage);
                        OrderSent = "9";
                    }
                    else
                    {
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }
                        RefreshPositions();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }

        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int OrderNumber = 0;
            String Status = "";
            Int32 giRowIndex = 1;
            //string Canc = "";
            string OrderSent = "";

            if (dgvOrders.Columns[e.ColumnIndex].Name == "EC")
            {

                Point p = dgvOrders.PointToClient(new Point(e.RowIndex, e.ColumnIndex));
                DataGridView.HitTestInfo info = dgvOrders.HitTest(p.X, p.Y);

                if (info.RowIndex != -1 && info.ColumnIndex != -1)
                {
                    DataGridViewCell cell = this.dgvOrders[info.ColumnIndex, info.RowIndex];
                }

                Int32 iRowIndex = Convert.ToInt32(e.RowIndex);

                // Set as selected 
                dgvOrders.Rows[iRowIndex].Selected = true;

                giRowIndex = iRowIndex;
                string TradeComp = dgvOrders.Rows[iRowIndex].Cells["Comp"].Value.ToString();
                string EO = dgvOrders.Rows[iRowIndex].Cells["chkEO"].Value.ToString();
                string GTC = dgvOrders.Rows[iRowIndex].Cells["chkGTC"].Value.ToString();
                string curAcct = dgvOrders.Rows[iRowIndex].Cells["OrdAcct"].Value.ToString();
                string Qty = dgvOrders.Rows[iRowIndex].Cells["OrdQty"].Value.ToString();
                Status = dgvOrders.Rows[iRowIndex].Cells["Status"].Value.ToString();
                OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                string OrdType = dgvOrders.Rows[iRowIndex].Cells["Type"].Value.ToString();
                GlobalStore.mdtCLOrder.Clear();
                GlobalStore.FillCLOrderDataTable(OrderNumber.ToString());

                DataView viewOrder = GlobalStore.mdtCLOrder.DefaultView;
                

                if (TradeComp == "55" || TradeComp == "33" || TradeComp == "25" || TradeComp == "19")
                {
                    if (EO.ToString() == "False")
                    {
                        MessageBox.Show("This trade company can only accept electronic orders.", "Hedge Order");
                        return;
                    }
                    if (TradeComp == "55" && GTC == "true")
                    {
                        MessageBox.Show("This trade company does not currently accept GTC orders.", "Hedge Order");
                        return;

                    }

                }
                viewAccountComps.RowFilter = "TP_ACCT = " + curAcct + " AND TP_TRADE_COMP = " + TradeComp;
                if (viewAccountComps.Count > 0)
                {
                    if (viewAccountComps[0]["SendToEC"].ToString() == "1" && Convert.ToInt32(Qty) > Convert.ToInt32(viewAccountComps[0]["ECContractLimit"].ToString()))
                    {
                        MessageBox.Show("This contract amount cannot be sent through EC.", "Hedge Order");
                        return;
                    }
                    if (OrdType == "SPR" || OrdType == "ORD" || OrdType == "EMC")
                    {
                        if (viewOrder.Count > 0)
                        {
                            
                            ReviseOrder(OrderNumber);

                        }
                        else if (OrdType.ToString() == "SPR")
                        {
                            if (OrderNumber.ToString() != dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString() && dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString() != "")
                            {
                                GlobalStore.FillCLOrderDataTable(dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString());
                                viewOrder = GlobalStore.mdtCLOrder.DefaultView;
                                if (viewOrder.Count != 0)
                                {
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Not an EC Order.", "Hedge Order");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (dgvOrders.Rows[iRowIndex].Cells["CardNumber"].Value.ToString() == "")
                            {

                                if (OrdType.ToString() == "SPR")
                                {
                                    frmAddOrderSpread frmAdd = new frmAddOrderSpread();
                                    OrdersNew clsOrdersNew = new OrdersNew();
                                    //frmAdd.frmCopyOrders = this;
                                    frmAdd.fromECButton = true;
                                    frmAdd.mOrderID = OrderNumber.ToString();
                                    frmAdd.ShowDialog(this);
                                    frmAdd.Dispose();
                                    //// frmAdd.frmCopyOrders.Dispose();

                                }
                                else
                                {
                                    frmAddOrder frmAdd = new frmAddOrder();
                                    OrdersNew clsOrdersNew = new OrdersNew();
                                    frmAdd.fromECButton = true;
                                    frmAdd.mOrderID = OrderNumber.ToString();
                                    //frmAdd.frmCopyOrders = this;
                                    frmAdd.ShowDialog(this);
                                    frmAdd.Dispose();
                                    //// frmAdd.frmCopyOrders.Dispose();
                                }

                            }
                            else
                            {
                                MessageBox.Show("This order was entered manually.", "Hedge Order");
                                return;
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Not an EC Order.", "Hedge Order");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Not an EC Order.", "Hedge Order");
                    return;
                }
                //tmrOrders.Start();
                dgvOrders.Rows[giRowIndex].Cells[mColumnIndex].Selected = true;

            }
            

            if (dgvOrders.Columns[e.ColumnIndex].Name == "Cancel")
            {

                OrderNumber = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["OrderNumb"].Value.ToString());
                GlobalStore.FillCLOrderDataTable(OrderNumber.ToString());
                DataView viewOrder = GlobalStore.mdtCLOrder.DefaultView;
                DataGridView.HitTestInfo info = dgvOrders.HitTest(e.RowIndex, e.ColumnIndex);
                Int32 iRowIndex = Convert.ToInt32(e.RowIndex);

                // Set as selected 
                dgvOrders.Rows[e.RowIndex].Selected = true;
                string OrdType = dgvOrders.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                giRowIndex = iRowIndex;
                if (OrdType == "SPR" || OrdType == "ORD" || OrdType == "EMC")
                {
                    if (viewOrder.Count > 0)
                    {
                        if (MessageBox.Show("Are you sure you want to cancel order " + dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                        else
                        {
                            OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                            CancelOrder(OrderNumber, ref OrderSent);
                        }
                    }
                    else if (OrdType.ToString() == "SPR")
                    {
                        if (OrderNumber.ToString() != dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString() && dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString() != "")
                        {
                            GlobalStore.FillCLOrderDataTable(dgvOrders.Rows[iRowIndex].Cells["Spread"].Value.ToString());
                            viewOrder = GlobalStore.mdtCLOrder.DefaultView;
                            if (viewOrder.Count != 0)
                            {
                                if (MessageBox.Show("Are you sure you want to cancel order " + dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                {
                                    return;
                                }
                                else
                                {
                                    OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                                    CancelOrder(OrderNumber, ref OrderSent);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Not an EC Order.", "Hedge Order");
                                return;
                            }
                        }
                    }
                    else
                    {


                        OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                        OrdersNew ord = new OrdersNew();
                        string Type = "";
                        string Acct = "";
                        string Ind = "";
                        string Qty = "";
                        string sMonth = "";
                        string sYear = "";
                        string Comm = "";
                        string Price = "";
                        string Filled = "";
                        string Comp = "";
                        //string PremSide = "";
                        //string S2Month = "";
                        //string S2Year = "";
                        int FixEO = 0;
                        int FixGTC = 0;
                        int Can = 0;
                        string VCAccount = "";
                        string VCComments = "";
                        string VCCustomer = "";
                        string CurrentUser = WindowsIdentity.GetCurrent().Name;
                        string ReturnMessage = "";
                        string CardNumber = "";
                        string OrderDate = "";
                        string Comments = "";
                        string ParentID = "";

                        //Boolean Grid = true;
                        if (dgvOrders.Rows[iRowIndex].Cells["chkEO"].Value.ToString() == "True")
                        {
                            FixEO = 1;
                        }
                        if (dgvOrders.Rows[iRowIndex].Cells["chkGTC"].Value.ToString() == "True")
                        {
                            FixGTC = 1;
                        }
                        Can = 1;
                        //FixEO = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkEO"].Value.ToString());
                        //FixGTC = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkGTC"].Value.ToString());
                        VCAccount = dgvOrders.Rows[e.RowIndex].Cells["VCAccount"].Value.ToString();
                        VCComments = dgvOrders.Rows[e.RowIndex].Cells["VCComments"].Value.ToString();
                        VCCustomer = dgvOrders.Rows[e.RowIndex].Cells["VCCustomer"].Value.ToString();
                        CardNumber = dgvOrders.Rows[e.RowIndex].Cells["CardNumber"].Value.ToString();
                        Status = dgvOrders.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                        OrderDate = dgvOrders.Rows[e.RowIndex].Cells["OrderDate"].Value.ToString();
                        Comments = dgvOrders.Rows[e.RowIndex].Cells["Comments"].Value.ToString();
                        Type = dgvOrders.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                        Acct = dgvOrders.Rows[e.RowIndex].Cells["OrdAcct"].Value.ToString();
                        Ind = dgvOrders.Rows[e.RowIndex].Cells["OrdInd"].Value.ToString();
                        Qty = dgvOrders.Rows[e.RowIndex].Cells["OrdQty"].Value.ToString();
                        sMonth = dgvOrders.Rows[e.RowIndex].Cells["OrdMonth"].Value.ToString();
                        sYear = dgvOrders.Rows[e.RowIndex].Cells["OrdYear"].Value.ToString();
                        Comm = dgvOrders.Rows[e.RowIndex].Cells["OrdComm"].Value.ToString();
                        Price = dgvOrders.Rows[e.RowIndex].Cells["OrdPrice"].Value.ToString();
                        Filled = dgvOrders.Rows[e.RowIndex].Cells["OrdFilled"].Value.ToString();
                        ParentID = dgvOrders.Rows[e.RowIndex].Cells["ParentID"].Value.ToString();
                        Comp = dgvOrders.Rows[e.RowIndex].Cells["Comp"].Value.ToString();
                        //Boolean CheckValue = true;

                        viewCommodities.RowFilter = "TP_COMM = " + Comm.ToString();
                        string ExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();

                        ord.EditOrderInGrid(OrderNumber.ToString(), Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                                Filled, Type, Comp, ParentID, FixEO, FixGTC, CardNumber, Status, Comments,
                                OrderDate, VCAccount, VCCustomer, VCComments, CurrentUser, ExchangeLetter, ref OrderSent,
                                ref ReturnMessage, Can);
                        if (OrderSent != "")
                        {
                            ShowMessage(OrderSent, ReturnMessage);
                        }

                        
                        dgvOrders.Rows[giRowIndex].Cells[mColumnIndex].Selected = true;

                    }
                }
                else
                {

                    OrderNumber = Convert.ToInt32(dgvOrders.Rows[iRowIndex].Cells["OrderNumb"].Value.ToString());
                    OrdersNew ord = new OrdersNew();
                    string Type = "";
                    string Acct = "";
                    string Ind = "";
                    string Qty = "";
                    string sMonth = "";
                    string sYear = "";
                    string Comm = "";
                    string Price = "";
                    string Filled = "";
                    string Comp = "";
                    //string PremSide = "";
                    //string S2Month = "";
                    //string S2Year = "";
                    int FixEO = 0;
                    int FixGTC = 0;
                    int Can = 0;
                    string VCAccount = "";
                    string VCComments = "";
                    string VCCustomer = "";
                    string CurrentUser = WindowsIdentity.GetCurrent().Name;
                    string ReturnMessage = "";
                    string CardNumber = "";
                    string OrderDate = "";
                    string Comments = "";
                    string ParentID = "";

                    //Boolean Grid = true;
                    if (dgvOrders.Rows[iRowIndex].Cells["chkEO"].Value.ToString() == "True")
                    {
                        FixEO = 1;
                    }
                    if (dgvOrders.Rows[iRowIndex].Cells["chkGTC"].Value.ToString() == "True")
                    {
                        FixGTC = 1;
                    }
                    Can = 1;
                    //FixEO = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkEO"].Value.ToString());
                    //FixGTC = Convert.ToInt16(dgvOrders.Rows[riIndex].Cells["chkGTC"].Value.ToString());
                    VCAccount = dgvOrders.Rows[e.RowIndex].Cells["VCAccount"].Value.ToString();
                    VCComments = dgvOrders.Rows[e.RowIndex].Cells["VCComments"].Value.ToString();
                    VCCustomer = dgvOrders.Rows[e.RowIndex].Cells["VCCustomer"].Value.ToString();
                    CardNumber = dgvOrders.Rows[e.RowIndex].Cells["CardNumber"].Value.ToString();
                    Status = dgvOrders.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                    OrderDate = dgvOrders.Rows[e.RowIndex].Cells["OrderDate"].Value.ToString();
                    Comments = dgvOrders.Rows[e.RowIndex].Cells["Comments"].Value.ToString();
                    Type = dgvOrders.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                    Acct = dgvOrders.Rows[e.RowIndex].Cells["OrdAcct"].Value.ToString();
                    Ind = dgvOrders.Rows[e.RowIndex].Cells["OrdInd"].Value.ToString();
                    Qty = dgvOrders.Rows[e.RowIndex].Cells["OrdQty"].Value.ToString();
                    sMonth = dgvOrders.Rows[e.RowIndex].Cells["OrdMonth"].Value.ToString();
                    sYear = dgvOrders.Rows[e.RowIndex].Cells["OrdYear"].Value.ToString();
                    Comm = dgvOrders.Rows[e.RowIndex].Cells["OrdComm"].Value.ToString();
                    Price = dgvOrders.Rows[e.RowIndex].Cells["OrdPrice"].Value.ToString();
                    Filled = dgvOrders.Rows[e.RowIndex].Cells["OrdFilled"].Value.ToString();
                    ParentID = dgvOrders.Rows[e.RowIndex].Cells["ParentID"].Value.ToString();

                    Comp = dgvOrders.Rows[e.RowIndex].Cells["Comp"].Value.ToString();
                    //Boolean CheckValue = true;

                    viewCommodities.RowFilter = "TP_COMM = " + Comm.ToString();
                    string ExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();

                    ord.EditOrderInGrid(OrderNumber.ToString(), Acct, Ind, Qty, sMonth, sYear, Comm, Price,
                            Filled, Type, Comp, ParentID, FixEO, FixGTC, CardNumber, Status, Comments,
                            OrderDate, VCAccount, VCCustomer, VCComments, CurrentUser, ExchangeLetter, ref OrderSent,
                            ref ReturnMessage, Can);
                    if (OrderSent != "")
                    {
                        ShowMessage(OrderSent, ReturnMessage);
                    }


                }
            }

        }

        public void ShowMessage(string OrderSent, string ReturnMessage)
        {
            if (OrderSent != "1")
            {
                MessageBox.Show(ReturnMessage.ToString());
            }
            RefreshPositions();

        }
        private void ReviseOrder(int OrderNumber)
        {
            frmEditOrder frmEdit = new frmEditOrder();
            OrdersNew clsOrdersNew = new OrdersNew();
            frmEdit.frmCopyOrders = this.Owner as frmOrders;
            try
            {
                frmEdit.mOrderNumber = OrderNumber;
                
                frmEdit.ShowDialog(this);
                RefreshPositions();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
            frmEdit.Dispose();
            // frmEdit.frmCopyOrders.Dispose();

        }

        

 
    }

}


