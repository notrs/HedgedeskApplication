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
    public partial class frmMoveToPurchaseSettleTables : Form
    {
        public frmOrders frmCopyOrders;
        private PurchaseSettle clsPurchaseSettle = new PurchaseSettle();
        private OrdersNew clsUpdateOrder = new OrdersNew();
        public DataView viewAccounts = new DataView();
        public DataView viewMonths = new DataView();
        public DataView viewCommodities = new DataView();
        public DataView viewOrdTypes = new DataView();
        public DataView viewAccountComps = new DataView();
        public DataView viewClosingPrices = new DataView();
        public DataView viewOrder = new DataView();
        public DataTable dtBuyOrder = new DataTable();
        public DataTable dtOrderFees = new DataTable();
        DataTable dtBuyOrdersFees = new DataTable();
        public Boolean mLoading;
        public Int32 mOrderNumber;
        public Boolean fromRegion = false;
        public string ReplPrice = "0";
        public string ReplQty = "0";
        public string RequestID = "";


        public frmMoveToPurchaseSettleTables()
        {
            InitializeComponent();
        }

        public void AddOrder(string Acct, string Ind, string Month, string Year, string Type,
            string Price, string Qty, string Comp, string Comm, string GTC)
        {

        }

        private void frmAddOrder_Load(object sender, EventArgs e)
        {
            LoadForm();

        }

        private void LoadForm()
        {
            try
            {
                mLoading = true;
                GlobalStore.mdtAccounts.Clear();
                GlobalStore.mdtMonths.Clear();
                GlobalStore.mdtCommodity.Clear();
                GlobalStore.mdtAccountsComps.Clear();
                GlobalStore.FillAccountsDataTable();
                GlobalStore.mdtOrderTypes.Clear();
                dtOrderFees.Clear();
                dtBuyOrder.Clear();
                dtBuyOrdersFees.Clear();
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
                    this.txtSide.Text = viewOrder[0]["B/S"].ToString();
                    this.txtMonth.Text = viewOrder[0]["Month"].ToString();
                    this.txtYear.Text = viewOrder[0]["Year"].ToString();
                    this.txtOrdType.Text = viewOrder[0]["Type"].ToString();
                    this.txtPrice.Text = viewOrder[0]["Filled"].ToString();
                    this.txtQty.Text = viewOrder[0]["Qty"].ToString();
                    this.txtComp.Text = viewOrder[0]["TP_TRADE_COMP"].ToString();
                    this.txtComm.Text = viewOrder[0]["Comm"].ToString();
                    this.lblOrderNumber.Text = mOrderNumber.ToString();
                    this.txtExch.Text = viewOrder[0]["TP_ExchLtr"].ToString();
                    this.txtAcctXref.Text = viewOrder[0]["TP_ACCT_XREF"].ToString();
                    this.txtCardNumber.Text = viewOrder[0]["CardNumber"].ToString();
                    this.txtCompany.Text = viewOrder[0]["TP_COMP"].ToString();
                    this.txtOrderDate.Text = viewOrder[0]["TP_DATE"].ToString();
                    this.txtOrderNumber.Text = mOrderNumber.ToString();
                    this.txtSEQ.Text = viewOrder[0]["TP_SEQ"].ToString();
                    GlobalStore.mdsOrder.Clear();
                    GlobalStore.FillOrderDataTableSide2(mOrderNumber.ToString());
                    viewOrder = GlobalStore.mdsOrder.DefaultView;
                    if (viewOrder.Count > 0)
                    {
                        this.txtAcct2.Text = viewOrder[0]["A/C"].ToString();
                        this.txtSide2.Text = viewOrder[0]["B/S"].ToString();
                        this.txtMonth2.Text = viewOrder[0]["Month"].ToString();
                        this.txtYear2.Text = viewOrder[0]["Year"].ToString();
                        this.txtOrdType2.Text = viewOrder[0]["Type"].ToString();
                        this.txtPrice2.Text = viewOrder[0]["Filled"].ToString();
                        this.txtQty2.Text = viewOrder[0]["Qty"].ToString();
                        this.txtComp2.Text = viewOrder[0]["TP_TRADE_COMP"].ToString();
                        this.txtComm2.Text = viewOrder[0]["Comm"].ToString();
                        //this.lblOrderNumber.Text = mOrderNumber.ToString();
                        this.txtExch2.Text = viewOrder[0]["TP_ExchLtr"].ToString();
                        this.txtAcctXref2.Text = viewOrder[0]["TP_ACCT_XREF"].ToString();
                        this.txtCardNumber2.Text = viewOrder[0]["CardNumber"].ToString();
                        this.txtCompany2.Text = viewOrder[0]["TP_COMP"].ToString();
                        this.txtOrderDate2.Text = viewOrder[0]["TP_DATE"].ToString();
                        this.txtOrderNumber2.Text = mOrderNumber.ToString();
                        this.txtSEQ2.Text = viewOrder[0]["TP_SEQ"].ToString();
                        DisableTextbox(txtAcct2, true);
                        DisableTextbox(txtSide2, true);
                        DisableTextbox(txtMonth2, true);
                        DisableTextbox(txtYear2, true);
                        DisableTextbox(txtOrdType2, true);
                        DisableTextbox(txtPrice2, true);
                        DisableTextbox(txtQty2, true);
                        DisableTextbox(txtComp2, true);
                        DisableTextbox(txtComm2, true);
                        DisableTextbox(txtExch2, true);
                        DisableTextbox(txtAcctXref2, true);
                        DisableTextbox(txtCardNumber2, true);
                        DisableTextbox(txtCompany2, true);
                        DisableTextbox(txtExch2, true);
                        DisableTextbox(txtOrderDate2, true);
                        DisableTextbox(txtOrderNumber2, true);
                        DisableTextbox(txtSEQ2, true);
                    }
                    else
                    {
                        DisableTextbox(txtAcct2, false);
                        DisableTextbox(txtSide2, false);
                        DisableTextbox(txtMonth2, false);
                        DisableTextbox(txtYear2, false);
                        DisableTextbox(txtOrdType2, false);
                        DisableTextbox(txtPrice2, false);
                        DisableTextbox(txtQty2, false);
                        DisableTextbox(txtComp2, false);
                        DisableTextbox(txtComm2, false);
                        DisableTextbox(txtExch2, false);
                        DisableTextbox(txtAcctXref2, false);
                        DisableTextbox(txtCardNumber2, false);
                        DisableTextbox(txtCompany2, false);
                        DisableTextbox(txtExch2, false);
                        DisableTextbox(txtOrderDate2, false);
                        DisableTextbox(txtOrderNumber2, false);
                        DisableTextbox(txtSEQ2, false);
                    }
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
                //if (System.DateTime.Today > dtHedgeDate)
                //{
                //    if (MessageBox.Show("The option you entered is no longer trading." + Environment.NewLine + "Choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                //    {
                //        return;
                //    }

                //}
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
                        //if (MessageBox.Show("No Futures Closing Values was found." + Environment.NewLine + "Please choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        //{
                        //    return;
                        //}
                    }
                    else
                    {
                        if ((dblPrice <= Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) - dblRange_Low) || (dblPrice >= Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) + dblRange_High))
                        {
                            //if (MessageBox.Show("Price is out of Range." + Environment.NewLine + "Low = " + (Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) - dblRange_Low).ToString() + " High = " + (Convert.ToDouble(viewClosingPrices[0]["ClosingPrice"].ToString()) + dblRange_High).ToString() + Environment.NewLine + "Please choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            //{
                            //    return;
                            //}

                        }
                    }
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


        private void btnUpdateBuyOrder_Click(object sender, EventArgs e)
        {
            try
            {


                string ReturnMessage = "";
                int OrderID = 0;
                OrderID = Convert.ToInt32(mOrderNumber.ToString());
                string CurrentUser = WindowsIdentity.GetCurrent().Name;


                if (!clsUpdateOrder.EditOrder(mOrderNumber.ToString(), txtAcct.Text, txtSide.Text, txtQty.Text, txtMonth.Text, txtYear.Text, txtComm.Text,
                    txtExch.Text, txtPrice.Text, txtOrdType.Text, txtCompany.Text, txtOrderDate.Text, txtCardNumber.Text,
                    txtComp.Text, txtAcctXref.Text, txtSEQ.Text, txtAcct2.Text, txtSide2.Text, txtQty2.Text, txtMonth2.Text, txtYear2.Text, txtComm2.Text,
                    txtExch2.Text, txtPrice2.Text, txtOrdType2.Text, txtCompany2.Text, txtOrderDate2.Text, txtCardNumber2.Text,
                    txtComp2.Text, txtAcctXref2.Text, txtSEQ2.Text, CurrentUser, ref ReturnMessage))
                    
                {
                    MessageBox.Show(ReturnMessage, "Hedge Orders");

                }
                else
                {
                    MessageBox.Show("Order updated", "Hedge Orders");
                    LoadForm();
                    frmCopyOrders.RefreshOrderGrid();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Orders");

            }
        }

        private void btnMoveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Move " + txtOrderNumber.Text.ToString() + " to Purchase Settle tables?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    string ReturnMessage = "";
                    int OrderID = 0;
                    OrderID = Convert.ToInt32(mOrderNumber.ToString());
                    string CurrentUser = WindowsIdentity.GetCurrent().Name;

                    if (!clsPurchaseSettle.MoveSingleOrder(mOrderNumber.ToString(), CurrentUser, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage, "Hedge Orders");

                    }
                    else
                    {
                        MessageBox.Show("Order has been moved.", "Hedge Orders");
                        this.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Orders");

            }
        }

        private void cmdCreateCTSOrder_Click(object sender, EventArgs e)
        {
            OrdersNew ord = new OrdersNew();
            string ReturnMessage = "";
            if (txtCTSAmount.Text == "" || txtCTSFillPrice.Text == "")
            {
                MessageBox.Show("Please fill in the Amount and Fill Price for this order.", "CTS Copy");
                return;
            }

            ord.AddCTSOrder(txtOrderNumber.Text, txtCTSAmount.Text, txtCTSFillPrice.Text, WindowsIdentity.GetCurrent().Name.ToString(), ref ReturnMessage);
            if (ReturnMessage == "")
            {
                txtCTSAmount.Text = "";
                txtCTSFillPrice.Text = "";
                txtCTSAmount.Focus();
                frmCopyOrders.RefreshOrderGrid();
            }
            else
            {
                MessageBox.Show(ReturnMessage.ToString(), "CTS Copy");
            }
        }

        private void txtOrderDate_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            {
                txtOrderDate2.Text = txtOrderDate.Text;
            }
        }

        private void txtOrderDate2_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            {
                txtOrderDate.Text = txtOrderDate2.Text;
            } 
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtQty2.Text = txtQty.Text; }
        }

        private void txtQty2_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtQty.Text = txtQty2.Text; }
        }

        private void txtOrdType_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            {txtOrdType2.Text = txtOrdType.Text;}
        }

        private void txtOrdType2_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtOrdType.Text = txtOrdType2.Text; }
        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtCardNumber2.Text = txtCardNumber.Text; }
        }

        private void txtCardNumber2_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtCardNumber.Text = txtCardNumber2.Text; }
        }

        private void txtComm_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtComm2.Text = txtComm.Text; }
        }

        private void txtComm2_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtComm.Text = txtComm2.Text; }
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtMonth2.Text = txtMonth.Text; }
        }

        private void txtMonth2_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtMonth.Text = txtMonth2.Text; }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtYear2.Text = txtYear.Text; }
        }

        private void txtYear2_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtYear.Text = txtYear2.Text; }
        }

        private void txtExch_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtExch2.Text = txtExch.Text; }
        }

        private void txtExch2_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtExch.Text = txtExch2.Text; }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtPrice2.Text = txtPrice.Text; }
        }

        private void txtPrice2_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtPrice.Text = txtPrice2.Text; }
        }

        private void txtComp_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtComp2.Text = txtComp.Text; }
        }

        private void txtComp2_TextChanged(object sender, EventArgs e)
        {
            if (!mLoading && txtAcct.Text != "32")
            { txtComp.Text = txtComp2.Text; }
        }

        private void DisableTextbox(TextBox tbox, Boolean enabled)
        {
            tbox.Enabled = enabled;
            if (enabled == false)
            {
                tbox.BackColor = Color.Gray;
            }
        }
    }


}


