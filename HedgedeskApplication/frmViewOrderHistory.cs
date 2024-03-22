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
    public partial class frmViewOrderHistory : Form
    {
        public frmOrders frmCopyOrders;
        public DataView viewAccounts = new DataView();
        public DataView viewMonths = new DataView();
        public DataView viewCommodities = new DataView();
        public DataView viewOrdTypes = new DataView();
        public DataView viewAccountComps = new DataView();
        public DataView viewClosingPrices = new DataView();
        public DataView viewOrder = new DataView();
        public DataView viewOrderDetail = new DataView();
        public DataView viewOrderView = new DataView();
        private string mQty = "";
        private string mPrice = "";
        public Boolean mLoading;
        public Int32 mOrderNumber;

        public frmViewOrderHistory()
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
                GlobalStore.mdtOrdersDetail.Clear();
                GlobalStore.mdtOrdersView.Clear();
                GlobalStore.FillOrderDataTable(mOrderNumber.ToString());
                GlobalStore.FillOrderDetailDataTable(mOrderNumber.ToString());
                GlobalStore.FillOrderViewDataTable(mOrderNumber.ToString());
                viewOrder = GlobalStore.mdsOrder.DefaultView;
                viewOrderDetail = GlobalStore.mdtOrdersDetail.DefaultView;
                viewOrderView = GlobalStore.mdtOrdersView.DefaultView;
                this.dgvECOrders.AutoGenerateColumns = false;
                this.dgvOrders.AutoGenerateColumns = false;
                dgvECOrders.DataSource = viewOrderDetail;
                dgvOrders.DataSource = viewOrderView;
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
                //BuildLabel();
                mLoading = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
            }

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
                if (!mLoading)
                {
                    //BuildLabel();
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                    case (char)Keys.Left:
                    case (char)Keys.Right:
                    case (char)Keys.Decimal:
                    case '.':
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
                if (!mLoading)
                {
                    //BuildLabel();
                }
            }
        }

        private void ValidateCancelReplaceEntry()
        {

            if (txtQty.Text == "")
            {
                MessageBox.Show("Enter a Quantity", "Hedge Order");
                return;
            }

            if (txtPrice.Text == "" && mPrice != "")
            {
                MessageBox.Show("Click the 'Cancel Market' button to cancel this order and place a market order.", "Hedge Order");
                return;
            }

            if (txtQty.Text == mQty && txtPrice.Text == mPrice)
            {
                MessageBox.Show("Change either price or quantity to revise an order.", "Hedge Order");
                return;

            }

            if (txtMonth.Text == "")
            {
                MessageBox.Show("Enter a Month", "Hedge Order");
                return;
            }
            else
            {
                viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "'";
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("Invalid Month entered", "Hedge Order");
                    return;

                }
            }

            if (txtYear.Text != "" && txtMonth.Text != "")
            {
                int iYear = Get4LetterYear(Convert.ToInt32(txtYear.Text.ToString()));
                DateTime dtHedgeDate = new DateTime(iYear, Convert.ToInt32(viewMonths[0]["Month_ID"].ToString()), Convert.ToInt32("16".ToString()));
                if (System.DateTime.Today > dtHedgeDate)
                {
                    if (MessageBox.Show("The option you entered is no longer trading." + Environment.NewLine + "Choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }

                }
            }
            else
            {
                MessageBox.Show("Please enter a month and year.");
                return;
            }

            return;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            string OrderSent = "";
            if (MessageBox.Show("Are you sure you want to cancel order " + mOrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                this.frmCopyOrders.CancelOrder(mOrderNumber, ref OrderSent);
            }
        }

        private int Get4LetterYear(int twoLetterYear)
        {
            int firstTwoDigits = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(0, 2));
            return Get4LetterYear(twoLetterYear, firstTwoDigits);
        }
        private int Get4LetterYear(int twoLetterYear, int firstTwoDigits)
        {
            return Convert.ToInt32(firstTwoDigits.ToString() + twoLetterYear.ToString());
        }
        private int Get2LetterYear(int fourLetterYear)
        {
            return Convert.ToInt32(fourLetterYear.ToString().Substring(2, 2));
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            double dblPrice = 0;
            double dblRange_Low = 0;
            string strExchangeLetter = "";
            string strHedgerPosition = "";
            double dblRange_High = 0;

            DataTable dtClosingPrices = new DataTable();
            OrdersUpdate ords = new OrdersUpdate();

            ords.GetClosingPrices(dtClosingPrices);
            viewClosingPrices = dtClosingPrices.DefaultView;

            if (txtComm.Text == "")
            {
                MessageBox.Show("Enter a Commodity", "Hedge Order");
                return;
            }
            else
            {

                viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
                if (viewCommodities.Count == 0)
                {
                    MessageBox.Show("Invalid Commodity entered", "Hedge Order");
                    return;

                }
                else
                {
                    for (int i = 0; i < viewCommodities.Count; i++)
                    {
                        dblRange_High = Convert.ToDouble(viewCommodities[0]["Range_High"].ToString());
                        dblRange_Low = Convert.ToDouble(viewCommodities[0]["Range_Low"].ToString());
                        strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                        strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                    }

                }

            }

            if (txtPrice.Text != "")
            {
                dblPrice = Convert.ToDouble(txtPrice.Text.ToString());
                if (dblPrice > 0 && txtOrdType.Text != "SPR")
                {
                    viewClosingPrices.RowFilter = "Commodity = '" + strHedgerPosition.ToString() + "' AND OptionMonth = '" + txtMonth.Text + "' AND OptionYear = " + txtYear.Text;
                    if (viewClosingPrices.Count == 0)
                    {
                        if (MessageBox.Show("No Futures Closing Values was found." + Environment.NewLine + "Please choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if ((dblPrice <= Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) - dblRange_Low) || (dblPrice >= Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) + dblRange_High))
                        {
                            if (MessageBox.Show("Price is out of Range." + Environment.NewLine + "Low = " + (Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) - dblRange_Low).ToString() + " High = " + (Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) + dblRange_High).ToString() + Environment.NewLine + "Please choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                return;
                            }

                        }
                    }
                }
            }
        }

        private void btnRevise_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateCancelReplaceEntry();
                string OrderSent = "";
                string ReturnMessage = "";
                string ErrorMessage = "";
                string ReturnOverrideMessage = "";
                string Override = "N";

                int FixGTC = 0;
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                if (this.GTC.Checked)
                {
                    FixGTC = 1;
                }
                else
                {
                    FixGTC = 0;
                }
                OrdersNew Ord = new OrdersNew();
                if (txtOrdType.Text != "SPR")
                {
                    Ord.CancelReplaceOrder(mOrderNumber, txtQty.Text, txtPrice.Text,
                        FixGTC, CurrentUser, ref ErrorMessage, ref ReturnOverrideMessage, Override, ref OrderSent, ref ReturnMessage);
                }
                else
                {
                    Ord.CancelReplaceSpreadOrder(mOrderNumber, txtQty.Text, txtPrice.Text,
                        FixGTC, CurrentUser, ref ErrorMessage, ref ReturnOverrideMessage, Override, ref OrderSent, ref ReturnMessage);
                }
                if (ReturnOverrideMessage == "Y")
                {

                    if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to revise order " + mOrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        if (txtOrdType.Text != "SPR")
                        {
                            Ord.CancelReplaceOrder(mOrderNumber, txtQty.Text, txtPrice.Text,
                                FixGTC, CurrentUser, ref ErrorMessage, ref ReturnOverrideMessage, "Y", ref OrderSent, ref ReturnMessage);
                        }
                        else
                        {
                            Ord.CancelReplaceSpreadOrder(mOrderNumber, txtQty.Text, txtPrice.Text,
                                FixGTC, CurrentUser, ref ErrorMessage, ref ReturnOverrideMessage, Override, ref OrderSent, ref ReturnMessage);
                        }
                        ShowMessage(OrderSent, ReturnMessage);

                    }
                }
                else
                {
                    if (ErrorMessage != "")
                    {
                        ShowMessage("4", ErrorMessage);
                    }
                    else
                    {
                        ShowMessage(OrderSent, ReturnMessage);
                    }
                }
                this.frmCopyOrders.dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                this.frmCopyOrders.dgvOrders.DataSource = this.frmCopyOrders.dtOrders;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
            }
            finally
            {
                this.Close();
            }
        }

        private void btnCancelMarket_Click(object sender, EventArgs e)
        {
            try
            {
                string OrderSent = "";
                string ReturnMessage = "";
                string ErrorMessage = "";
                string ReturnOverrideMessage = "";
                string Override = "N";
                if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to cancel order " + mOrderNumber.ToString() + " and place a market order?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }

                //int FixGTC = 0;
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                
                OrdersNew Ord = new OrdersNew();
                if (txtOrdType.Text != "SPR")
                {
                    Ord.CancelReplaceMarketOrder(CurrentUser, mOrderNumber, ref ErrorMessage, ref ReturnOverrideMessage, Override, ref OrderSent, ref ReturnMessage);
                }
                else
                {
                    Ord.CancelReplaceMarketSpreadOrder(CurrentUser, mOrderNumber, ref ErrorMessage, ref ReturnOverrideMessage, Override, ref OrderSent, ref ReturnMessage);
                }
                if (ReturnOverrideMessage == "Y")
                {

                    if (MessageBox.Show(ErrorMessage.ToString() + Environment.NewLine + "Are you sure you want to revise order " + mOrderNumber.ToString(), "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        if (txtOrdType.Text != "SPR")
                        {
                            Ord.CancelReplaceMarketOrder(CurrentUser, mOrderNumber, ref ErrorMessage, ref ReturnOverrideMessage, "Y", ref OrderSent, ref ReturnMessage);
                        }
                        else
                        {
                            Ord.CancelReplaceMarketSpreadOrder(CurrentUser, mOrderNumber, ref ErrorMessage, ref ReturnOverrideMessage, "Y", ref OrderSent, ref ReturnMessage);
                        }
                        ShowMessage(OrderSent, ReturnMessage);

                    }
                }
                else
                {
                    if (ErrorMessage != "")
                    {
                        ShowMessage("4", ReturnMessage);
                    }
                    else
                    {
                        ShowMessage(OrderSent, ReturnMessage);
                    }
                }
                this.frmCopyOrders.dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                this.frmCopyOrders.dgvOrders.DataSource = this.frmCopyOrders.dtOrders;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
            }
            finally
            {
                this.Close();
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
    


