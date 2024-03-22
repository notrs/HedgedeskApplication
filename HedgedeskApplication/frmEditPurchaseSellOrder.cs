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
    public partial class frmEditPurchaseSellOrder : Form
    {
        public frmPurchaseSettleInquiry frmCopyOrders;
        private PurchaseSettle clsPurchaseSettle = new PurchaseSettle();
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
        int mColumnIndex;
        int mRowIndex;
        Boolean isNotValidated = false;
        Boolean isRowChanged = false;

        public frmEditPurchaseSellOrder()
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
                GlobalStore.FillBuyOrderDataTable(mOrderNumber.ToString(), dtBuyOrder);
                GlobalStore.FillOrderFeeTypesDataTable(dtOrderFees);
                cboPSFeeType.DataSource = dtOrderFees;
                cboPSFeeType.DisplayMember = "PSFeeType";
                cboPSFeeType.ValueMember = "PSFeeTypeID";
                cboPSFeeType.SelectedIndex = -1;
                GlobalStore.FillBuyOrderFeesDataTable(mOrderNumber.ToString(), dtBuyOrdersFees);
                viewOrder = dtBuyOrder.DefaultView;
                if (viewOrder.Count > 0)
                {
                    this.txtAcct.Text = viewOrder[0]["Account"].ToString();
                    this.txtExch.Text = viewOrder[0]["ExchLtr"].ToString();
                    this.txtMonth.Text = viewOrder[0]["OptionMonth"].ToString();
                    this.txtYear.Text = viewOrder[0]["OptionYear"].ToString();
                    this.txtOrdType.Text = viewOrder[0]["OrderType"].ToString();
                    this.txtPrice.Text = viewOrder[0]["FilledPrice"].ToString();
                    this.txtQty.Text = viewOrder[0]["Amount"].ToString();
                    this.txtComp.Text = viewOrder[0]["TradeCompany"].ToString();
                    this.txtComm.Text = viewOrder[0]["Commodity"].ToString();
                    this.lblOrderNumber.Text = viewOrder[0]["OrderNumber"].ToString();
                    this.txtAcctXref.Text = viewOrder[0]["AccountXref"].ToString();
                    this.txtCardNumber.Text = viewOrder[0]["CardNumber"].ToString();
                    this.txtCompany.Text = viewOrder[0]["Company"].ToString();
                    this.txtOrderDate.Text = viewOrder[0]["OrderDate"].ToString();
                    this.txtOrderID.Text = viewOrder[0]["OrderID"].ToString();
                    this.txtOrderNumber.Text = viewOrder[0]["OrderNumber"].ToString();
                    this.txtSEQ.Text = viewOrder[0]["OrderSeq"].ToString();

                    this.dgvBuyOrdersFees.AutoGenerateColumns = false;
                    this.dgvBuyOrdersFees.DataSource = dtBuyOrdersFees;
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

        private void dgvBuyOrdersFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvBuyOrdersFees.Columns[e.ColumnIndex].Name != "DeleteFees") return;
            Point p = dgvBuyOrdersFees.PointToClient(new Point(e.RowIndex, e.ColumnIndex));
            DataGridView.HitTestInfo info = dgvBuyOrdersFees.HitTest(p.X, p.Y);

            if (info.RowIndex != -1 && info.ColumnIndex != -1)
            {
                DataGridViewCell cell = this.dgvBuyOrdersFees[info.ColumnIndex, info.RowIndex];
            }

            Int32 iRowIndex = Convert.ToInt32(e.RowIndex);

            // Set as selected 
            dgvBuyOrdersFees.Rows[iRowIndex].Selected = true;

            var feeID = Convert.ToInt32(dgvBuyOrdersFees.Rows[iRowIndex].Cells["DeleteFees"].Value.ToString());
            Maintenance ord = new Maintenance();

            if (ord.DeleteFee(feeID, "Buy"))
            {
                MessageBox.Show("Fee removed.", "Fees", MessageBoxButtons.OK);
            }


            LoadForm();
        }

        private void dgvBuyOrdersFees_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvBuyOrdersFees.CurrentCell.ColumnIndex;
                mRowIndex = dgvBuyOrdersFees.CurrentCell.RowIndex;
            }
            isRowChanged = true;
        }

        private void dgvBuyOrdersFees_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    dgvBuyOrdersFees.EndEdit();
                    string rIndex = dgvBuyOrdersFees.Rows[e.RowIndex].Index.ToString();
                    int riIndex = Convert.ToInt16(rIndex);
                    string FeeTypeID = "";
                    string Amount = "";
                    int OrderID = 0;
                    string ReturnMessage = "";

                    OrderID = Convert.ToInt32(mOrderNumber.ToString());
                    FeeTypeID = dgvBuyOrdersFees.Rows[riIndex].Cells["FeeTypeID"].Value.ToString();
                    Amount = dgvBuyOrdersFees.Rows[riIndex].Cells["Amount"].Value.ToString();


                    if (!clsPurchaseSettle.UpdateBuyOrdersFees(OrderID, FeeTypeID, Amount, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage, "Hedge Orders");
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                    else
                    {
                        dtBuyOrdersFees.Clear();
                        GlobalStore.FillBuyOrderFeesDataTable(mOrderNumber.ToString(), dtBuyOrdersFees);
                        this.dgvBuyOrdersFees.AutoGenerateColumns = false;
                        this.dgvBuyOrdersFees.DataSource = dtBuyOrdersFees;
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

        private void btnUpdateBuyOrder_Click(object sender, EventArgs e)
        {
            try
            {


                string ReturnMessage = "";
                int OrderID = 0;
                OrderID = Convert.ToInt32(mOrderNumber.ToString());


                if (!clsPurchaseSettle.UpdatePurchaseSettleBuyOrders(OrderID, txtCardNumber.Text, txtQty.Text, txtOrdType.Text, txtPrice.Text,
                    txtAcct.Text, txtExch.Text, txtMonth.Text, txtYear.Text, txtComp.Text, txtComm.Text, txtAcctXref.Text,
                    txtCompany.Text, txtOrderDate.Text, txtOrderNumber.Text, this.txtSEQ.Text, ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage, "Hedge Orders");

                }
                else
                {
                    MessageBox.Show("Order updated", "Hedge Orders");
                    dtBuyOrdersFees.Clear();
                    GlobalStore.FillBuyOrderFeesDataTable(mOrderNumber.ToString(), dtBuyOrdersFees);
                    this.dgvBuyOrdersFees.AutoGenerateColumns = false;
                    this.dgvBuyOrdersFees.DataSource = dtBuyOrdersFees;
                    LoadForm();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Orders");

            }
        }

        private void dgvBuyOrdersFees_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvBuyOrdersFees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvBuyOrdersFees.EndEdit();
                isRowChanged = false;
            }
        }

        private void btnMoveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Move " + txtOrderNumber.Text.ToString() + " to Sell Order table?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    string ReturnMessage = "";
                    int OrderID = 0;
                    OrderID = Convert.ToInt32(mOrderNumber.ToString());

                    if (!clsPurchaseSettle.MoveBuyOrders(OrderID, ref ReturnMessage))
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

        private void btnAddFee_Click(object sender, EventArgs e)
        {

            try
            {

                String PSFeeTypeID = "";
                String PSFeeAmount = "";
                string ReturnMessage = "";
                int OrderID = 0;
                OrderID = Convert.ToInt32(mOrderNumber.ToString());

                if (this.txtFeeAmount.Text != "")
                {
                    PSFeeAmount = txtFeeAmount.Text;
                }
                else
                {
                    MessageBox.Show("Fee Amount is required.", "Hedge Order");
                    return;
                }

                if (this.cboPSFeeType.Text != "")
                {
                    PSFeeTypeID = cboPSFeeType.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Fee Type is required.", "Hedge Order");
                    return;
                }

                if (!clsPurchaseSettle.AddBuyOrdersFees(OrderID, PSFeeTypeID, PSFeeAmount, ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage, "Hedge Orders");

                }
                else
                {
                    dtBuyOrdersFees.Clear();
                    GlobalStore.FillBuyOrderFeesDataTable(mOrderNumber.ToString(), dtBuyOrdersFees);
                    this.dgvBuyOrdersFees.AutoGenerateColumns = false;
                    this.dgvBuyOrdersFees.DataSource = dtBuyOrdersFees;
                    this.cboPSFeeType.SelectedIndex = -1;
                    this.txtFeeAmount.Text = "";

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");

            }
        }

    }


}
    


