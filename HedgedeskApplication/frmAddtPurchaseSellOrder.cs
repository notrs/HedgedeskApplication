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
    public partial class frmAddPurchaseSellOrder : Form
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
        DataTable dtBuyOrdersFees = new DataTable();
        private string mQty = "";
        private string mPrice = "";
        public Boolean mLoading;
        public Int32 mOrderNumber;
        public Boolean fromRegion = false;
        public string ReplPrice = "0";
        public string ReplQty = "0";
        public string RequestID = "";

        public frmAddPurchaseSellOrder()
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
                viewOrder = dtBuyOrder.DefaultView;
                
                    this.txtAcct.Text = "";
                    this.txtMonth.Text = "";
                    this.txtYear.Text = "";
                    this.txtOrdType.Text = "";
                    this.txtPrice.Text = "";
                    this.txtQty.Text = "";
                    this.txtComm.Text = "";
                    this.txtCardNumber.Text = "";
                    this.txtCompany.Text = "";
                    this.txtOrderDate.Text = "";
                    this.txtOrderNumber.Text = "";

                    //BuildLabel();
                
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


        private void ShowMessage(string OrderSent, string ReturnMessage)
        {
            if (OrderSent != "1")
            {
                MessageBox.Show(ReturnMessage.ToString());
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                String strHedgerPosition = "";
                string intTradeAccount = "";
                string strTrade_Comp = "";
                string strTP_COMP = "";
                string intTP_Acct_Xref = "";
                string strTP_Trans_Type = "";
                int intCME = 0;

                if (txtOrderDate.Text == "")
                {
                    MessageBox.Show("Order Date is required.", "Hedge Order");
                    return;
                }
                if (txtAcct.Text == "")
                {
                    MessageBox.Show("Account is required.", "Hedge Order");
                    return;
                }
                if (this.txtSide.Text == "")
                {
                    MessageBox.Show("Buy/Sell is required.", "Hedge Order");
                    return;
                }
                if (txtQty.Text == "")
                {
                    MessageBox.Show("Amount is required.", "Hedge Order");
                    return;
                }
                if (txtMonth.Text == "")
                {
                    MessageBox.Show("Month is required.", "Hedge Order");
                    return;
                }
                if (txtYear.Text == "")
                {
                    MessageBox.Show("Year is required.", "Hedge Order");
                    return;
                }
                if (txtComm.Text == "")
                {
                    MessageBox.Show("Commodity is required.", "Hedge Order");
                    return;
                }
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
                        strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                    }

                }
                if (txtPrice.Text == "")
                {
                    MessageBox.Show("Filled Price is required.", "Hedge Order");
                    return;
                }
                if (txtOrdType.Text == "")
                {
                    MessageBox.Show("Order Type is required.", "Hedge Order");
                    return;
                }
                if (txtCompany.Text == "")
                {
                    MessageBox.Show("Trade Company is required.", "Hedge Order");
                    return;
                }

                if (this.CME.Checked == true)
                {
                    intCME = 1;
                }
                viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text.ToString() + " AND TP_TRADE_COMP = " + txtCompany.Text.ToString();
                if (viewAccountComps.Count == 0)
                {
                    MessageBox.Show("Invalid Trading Account/Company combination.", "Hedge Order");
                    return;

                }
                else
                {
                    intTradeAccount = viewAccountComps[0]["TP_Acct"].ToString();
                    strTrade_Comp = viewAccountComps[0]["TP_Trade_Comp"].ToString();
                    strTP_COMP = viewAccountComps[0]["TP_COMP"].ToString();
                    intTP_Acct_Xref = viewAccountComps[0]["TP_ACCT_Xref"].ToString();
                    strTP_Trans_Type = viewAccountComps[0]["TP_Trans_Type"].ToString();

                }
                if (txtSide.Text == "B")
                {
                    clsPurchaseSettle.AddPurchaseSettleBuyOrder(strTrade_Comp, txtSide.Text, txtAcct.Text, txtComm.Text, strHedgerPosition,
                        txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtOrdType.Text, strTP_COMP, intCME, 0, Convert.ToInt32(intTP_Acct_Xref.ToString()), "",
                        strTP_Trans_Type, txtCardNumber.Text, "", "", "", txtPrice.Text, txtOrderDate.Text);
                }
                if (txtSide.Text == "S")
                {
                    clsPurchaseSettle.AddPurchaseSettleBuyOrder(strTrade_Comp, txtSide.Text, txtAcct.Text, txtComm.Text, strHedgerPosition,
                        txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtOrdType.Text, strTP_COMP, intCME, 0, Convert.ToInt32(intTP_Acct_Xref.ToString()), "",
                        strTP_Trans_Type, txtCardNumber.Text, "", "", "", txtPrice.Text, txtOrderDate.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void ChangeControlColorFocus(System.Windows.Forms.TextBox tbox)
        {
            foreach (Control c in this.panel1.Controls)
            {

                if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {
                    c.BackColor = System.Drawing.Color.Transparent;
                }
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    if (c.Name != tbox.Name)
                    {
                        c.BackColor = System.Drawing.Color.White;
                        c.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        c.BackColor = System.Drawing.Color.OldLace;
                        c.ForeColor = System.Drawing.Color.DarkGreen;
                    }
            }
            CME.BackColor = Color.Transparent;

        }

        private void txtAcct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtAcct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Return:
                    case (char)Keys.Space:
                    case (char)Keys.Back:
                    case (char)Keys.Escape:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void txtAcct_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtAcct);
            txtAcct.SelectAll();
        }

        private void txtOrderDate_Enter(object sender, EventArgs e)
        {

        }

        private void txtOrderDate_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtSide_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                    e.Handled = true;
                    txtSide.Text = "S".ToUpper();
                    ChangeControlColor(txtQty);
                    break;
                case '2':
                    e.Handled = true;
                    txtSide.Text = "B".ToUpper();
                    ChangeControlColor(txtQty);
                    break;
                case 's':
                case 'S':
                    e.Handled = true;
                    txtSide.Text = "S".ToUpper();
                    ChangeControlColor(txtQty);
                    break;
                case 'b':
                case 'B':
                    e.Handled = true;
                    txtSide.Text = "B".ToUpper();
                    ChangeControlColor(txtQty);
                    break;
                case (char)Keys.Return:
                case (char)Keys.Back:
                case (char)Keys.Space:
                case (char)Keys.Escape:
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        private void txtSide_Leave(object sender, EventArgs e)
        {

        }

        private void txtSide_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtSide);
            txtSide.SelectAll();
        }

        private void ChangeControlColor(System.Windows.Forms.TextBox tbox)
        {
            foreach (Control c in this.panel1.Controls)
            {

                if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {
                    c.BackColor = System.Drawing.Color.Transparent;
                }
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    if (c.Name != tbox.Name)
                    {
                        c.BackColor = System.Drawing.Color.White;
                        c.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        c.BackColor = System.Drawing.Color.OldLace;
                        c.ForeColor = System.Drawing.Color.DarkGreen;
                        c.Focus();
                    }
            }
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtQty);
            txtQty.SelectAll();
        }

        private void txtMonth_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtMonth);
            txtMonth.SelectAll();
        }

        private void txtYear_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtYear);
            txtYear.SelectAll();
        }

        private void txtComm_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtComm);
            txtComm.SelectAll();
        }


        private void txtOrdType_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtOrdType);
            txtOrdType.SelectAll();
        }


        private void CME_Enter(object sender, EventArgs e)
        {
            ChangeControlColorCboxFocus(CME);
        }

        private void ChangeControlColorCboxFocus(System.Windows.Forms.CheckBox cbox)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.BackColor = System.Drawing.Color.White;
                    c.ForeColor = System.Drawing.Color.Black;
                }
            }
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                    if (c.Name != cbox.Name)
                    {
                        c.BackColor = System.Drawing.Color.Transparent;
                    }
                    else
                    {
                        c.BackColor = System.Drawing.Color.Turquoise;

                    }
            }
        }

        private void ChangeControlColorCbox(System.Windows.Forms.CheckBox cbox)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.BackColor = System.Drawing.Color.White;
                    c.ForeColor = System.Drawing.Color.Black;
                }
            }
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                    if (c.Name != cbox.Name)
                    {
                        c.BackColor = System.Drawing.Color.Transparent;
                    }
                    else
                    {
                        c.BackColor = System.Drawing.Color.Turquoise;
                        c.Focus();
                    }
            }
        }

        private void txtOrderDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtCardNumber_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtCardNumber);
            txtCardNumber.SelectAll();
        }

        private void txtCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtComm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtComm_KeyPress(object sender, KeyPressEventArgs e)
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
            }
        }

        private void txtComm_TextChanged(object sender, EventArgs e)
        {
            if (txtComm.Text.Length == 2)
            {
                ChangeControlColor(txtPrice);
            }
        }

        private void txtCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtCompany_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtCompany);
            txtCompany.SelectAll();
        }

        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
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
                        //case (char)Keys.OemPeriod:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            if (txtCompany.Text.Length == 2)
            {
                
                if (CME.Enabled == true)
                {
                    ChangeControlColorCbox(CME);
                }
                else
                {
                    ChangeControlColor(txtCardNumber);
                }
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtPrice);
            txtPrice.SelectAll();
        }

        private void txtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                e.Handled = true;

            }
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text.Length == 1)
            {


                viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "'";
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("Invalid Option month.", "Hedge Order");
                    return;

                }
                else
                {
                    txtMonth.Text = txtMonth.Text.ToUpper();
                    int iYear = System.DateTime.Today.Year;
                    DateTime dtHedgeDate = new DateTime(iYear, Convert.ToInt32(viewMonths[0]["Month_ID"].ToString()), Convert.ToInt32("16".ToString()));
                    DateTime time = DateTime.Now;              // Use current time
                    string format = "yy";    // Use this format

                    if (System.DateTime.Today > dtHedgeDate)
                    {
                        txtYear.Text = time.AddYears(1).ToString(format);
                    }
                    else
                    {
                        txtYear.Text = time.ToString(format);
                    }

                    ChangeControlColor(txtYear);
                }
            }
        }

        private void txtOrdType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtOrdType_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtOrdType.Text.ToString(), "\\d+"))
            {
                switch (txtOrdType.Text)
                {
                    case "1":
                        txtOrdType.Text = "MOO".ToUpper();
                        break;
                    case "2":
                        txtOrdType.Text = "MOC".ToUpper();
                        break;
                    case "3":
                        txtOrdType.Text = "SPR".ToUpper();
                        txtOrdType.Text = "SPR".ToUpper();
                        break;
                    case "4":
                        txtOrdType.Text = "ORD".ToUpper();
                        break;
                    case "5":
                        txtOrdType.Text = "CH".ToUpper();
                        break;
                    case "6":
                        txtOrdType.Text = "EX".ToUpper();
                        break;
                    case "7":
                        txtOrdType.Text = "VCF".ToUpper();
                        break;
                    case "8":
                        txtOrdType.Text = "EMC".ToUpper();
                        break;
                    default:
                        txtOrdType.Text = "";
                        break;
                }
            }
            else
            {
                switch (txtOrdType.Text)
                {
                    case "S":
                    case "s":
                        txtOrdType.Text = "SPR".ToUpper();
                        txtOrdType.Text = "SPR".ToUpper();
                        break;
                    case "O":
                    case "o":
                        txtOrdType.Text = "ORD".ToUpper();
                        break;
                    case "C":
                    case "c":
                        txtOrdType.Text = "CH".ToUpper();
                        break;
                    case "EX":
                    case "ex":
                    case "Ex":
                    case "eX":
                        txtOrdType.Text = "EX".ToUpper();
                        break;
                    case "Em":
                    case "EM":
                    case "eM":
                    case "em":
                        txtOrdType.Text = "EMC".ToUpper();
                        break;
                    case "V":
                    case "v":
                        txtOrdType.Text = "VCF".ToUpper();
                        break;
                    default:
                        txtOrdType.Text = txtOrdType.Text;
                        break;
                }

            }

        }


    
    }




}
    


