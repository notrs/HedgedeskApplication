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
    public partial class frmOrderPlace : Form
    {
        public frmOrders frmCopyOrders;
        public DataView viewAccounts = new DataView();
        public DataView viewMonths = new DataView();
        public DataView viewCommodities = new DataView();
        public DataView viewOrdTypes = new DataView();
        public DataView viewAccountComps = new DataView();
        public DataView viewClosingPrices = new DataView();
        public DataView viewCommodityTradingComp = new DataView();
        public DataView viewOrder = new DataView();
        public string mQty = "";
        public string mPrice = "";
        public Boolean mLoading;
        public Int32 mAcct;
        public String mCommodity;
        public String mMonth;
        public String mYear;
        public Boolean fromRegion = false;
        public string ReplPrice = "0";
        public string ReplQty = "0";
        public string RequestID = "";
        public string mBS;
        public string mDTNPrice;
        public DataTable dtCHPrices = new DataTable();
        public DataView dvCHPrices = new DataView();


        public frmOrderPlace()
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
                viewAccounts = GlobalStore.mdtAccounts.DefaultView;
                viewMonths = GlobalStore.mdtMonths.DefaultView;
                viewCommodities = GlobalStore.mdtCommodity.DefaultView;
                viewAccountComps = GlobalStore.mdtAccountsComps.DefaultView;
                viewOrdTypes = GlobalStore.mdtOrderTypes.DefaultView;
                GlobalStore.FillCommodityTradingCompDataTable();
                
                viewCommodityTradingComp = GlobalStore.mdtCommodityTradingComp.DefaultView;
                GlobalStore.mdsOrder.Clear();

                OrdersNew ord = new OrdersNew();

                viewOrdTypes.RowFilter = "TP_ORD_Type = '" + "MOC" + "' OR " + " TP_ORD_Type = '" + "ORD" + "' OR TP_ORD_TYPE = '" + "EMC" + "'";
                cboAcct.DataSource = GlobalStore.mdtAccounts.Copy();
                cboAcct.DisplayMember = "TP_ACCT";
                cboAcct.ValueMember = "TP_ACCT";
                cboMon.DataSource = GlobalStore.mdtMonths.Copy();
                cboMon.DisplayMember = "SelectMonth";
                cboMon.ValueMember = "TP_MON";
                cboCommodities.DataSource = GlobalStore.mdtCommodity.Copy();
                cboCommodities.DisplayMember = "DESC";
                cboCommodities.ValueMember = "TP_COMM";
                cboOrderType.DataSource = viewOrdTypes;
                cboOrderType.DisplayMember = "TP_ORD_TYPE";
                cboOrderType.ValueMember = "TP_ORD_TYPE";

                cboOrderType.SelectedValue = "ORD";


                this.cboCommodities.SelectedValue = mCommodity;
                this.cboAcct.SelectedValue = mAcct;
                this.txtInd.Text = mBS;
                this.cboMon.SelectedValue = mMonth;
                this.txtYear.Text = mYear;
                string TradingCompany;

                ord.GetPrice(Convert.ToInt32(mCommodity), mMonth, mYear, dtCHPrices);
                this.lstLastFiveCHPrices.DataSource = dtCHPrices;
                this.lstLastFiveCHPrices.DisplayMember = "FillPrice";
                this.lstLastFiveCHPrices.ValueMember = "FillPrice";

                this.txtSavedWeightedAverage.Text = dtCHPrices.DefaultView[0]["SavedAverage"].ToString();
                this.txtSavedPosition.Text = dtCHPrices.DefaultView[0]["SavedPosition"].ToString();

                dtCHPrices.DefaultView.RowFilter = "Show = 1"; 

                if (dtCHPrices.DefaultView.Count > 0)
                {
                    this.txtWeightedAverage.Text = dtCHPrices.DefaultView[0]["WeightedAverage"].ToString();
                }
                else
                {
                    this.txtWeightedAverage.Text = "0";
                }

                if (txtWeightedAverage.Text == "0" && this.txtSavedWeightedAverage.Text != "0")
                {
                    txtWeightedAverage.Text = this.txtSavedWeightedAverage.Text;
                }

                string Filter = "CommodityID = " + cboCommodities.SelectedValue.ToString() + " AND YEAR = " + txtYear.Text + " AND MONTH = " + "'" + cboMon.SelectedValue + "'";
                this.viewCommodityTradingComp.RowFilter = Filter; // "CommodityID = " + cboCommodities.SelectedValue.ToString() + " AND YEAR = " + txtYear.Text + " AND MONTH = " + "'" + cboMon.SelectedValue + "'"; 
                if (viewCommodityTradingComp.Count == 0)
                {
                    TradingCompany = Properties.Settings.Default.TradeCompanyID.ToString();
                    txtComp.Text = TradingCompany;
                }
                else
                {
                    TradingCompany = viewCommodityTradingComp[0]["TradingCompany"].ToString();
                    txtComp.Text = TradingCompany;
                }

                this.cboOrderType.SelectedValue = "ORD";
                this.txtPrice.Text = mPrice;
                this.txtQty.Text = mQty;
                //this.txtComp.Text = "19";
                this.cboCommodities.SelectedValue = mCommodity;
                this.GTC.Checked = false;
                this.txtCMEPrice.Text = mDTNPrice;

                //BuildLabel();
                if(cboAcct.Text == "5")
                {
                    cboAcct.SelectedIndex = -1;
                    txtComp.Focus();
                    cboAcct.Text = " ";
                    cboAcct.Select(0, 1);
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

        private Boolean ValidateCancelReplaceEntry()
        {


            if (cboOrderType.Text == "EMC" || cboOrderType.Text == "ORD")
            {
                if (txtQty.Text != "")
                {
                    if (Convert.ToDecimal(txtQty.Text) > Convert.ToDecimal(Properties.Settings.Default.HedgeContractLimit))
                    {
                        MessageBox.Show("Quantity cannot be greater than " + Properties.Settings.Default.HedgeContractLimit.ToString() + " contracts.");
                        return false;
                    }
                }
            }
            if (txtQty.Text == "")
            {
                MessageBox.Show("Enter a Quantity", "Hedge Order");
                return false;
            }



            if (cboMon.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Enter a Month", "Hedge Order");
                return false;
            }
            else
            {
                viewMonths.RowFilter = "TP_MON = '" + cboMon.SelectedValue + "'";
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("Invalid Month entered", "Hedge Order");
                    return false;

                }
            }

            if (txtYear.Text != "" && cboMon.SelectedValue.ToString() != "")
            {
                int iYear = Get4LetterYear(Convert.ToInt32(txtYear.Text.ToString()));
                DateTime dtHedgeDate = new DateTime(iYear, Convert.ToInt32(viewMonths[0]["Month_ID"].ToString()), Convert.ToInt32("16".ToString()));
                if (System.DateTime.Today > dtHedgeDate)
                {
                    if (MessageBox.Show("The option you entered is no longer trading." + Environment.NewLine + "Choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return false;
                    }

                }
            }
            else
            {
                MessageBox.Show("Please enter a month and year.");
                return false;
            }

            return true;
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

            if (cboCommodities.Text == "")
            {
                MessageBox.Show("Enter a Commodity", "Hedge Order");
                return;
            }
            else
            {

                viewCommodities.RowFilter = "TP_COMM = " + cboCommodities.SelectedValue;
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
                if (dblPrice > 0 && cboOrderType.Text != "SPR")
                {
                    viewClosingPrices.RowFilter = "Commodity = '" + strHedgerPosition.ToString() + "' AND OptionMonth = '" + cboMon.SelectedValue + "' AND OptionYear = " + txtYear.Text;
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

        private void AddNonECOrder()
        {
            string OrderSent = "";
            string ReturnMessage = "";

            viewAccountComps.RowFilter = "TP_ACCT = " + cboAcct.SelectedValue + " AND TP_TRADE_COMP = " + txtComp.Text;
            viewCommodities.RowFilter = "TP_COMM = " + cboCommodities.SelectedValue;
            viewMonths.RowFilter = "TP_MON = '" + cboMon.SelectedValue + "' AND TP_COMM = " + cboCommodities.SelectedValue;
            viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + cboOrderType.Text + "'";
            string strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
            string strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
            int AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
            int FixEO = 0;
            int FixGTC = 0;
            string Company = viewAccountComps[0]["TP_COMP"].ToString();
            string CurrentUser = WindowsIdentity.GetCurrent().Name;
            string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
            FixEO = 0;

            if (this.GTC.Checked)
            {
                FixGTC = 1;
            }
            else
            {
                FixGTC = 0;
            }

            OrdersNew Ord = new OrdersNew();
            Ord.AddNonECOrder(txtComp.Text, txtInd.Text, cboAcct.SelectedValue.ToString(), cboCommodities.SelectedValue.ToString(), strExchangeLetter,
               cboMon.SelectedValue.ToString(), txtYear.Text, txtQty.Text, txtPrice.Text, cboOrderType.Text, Company,
               FixEO, FixGTC, AcctXref, CurrentUser, TransType, "", "", "", "", txtPrice.Text, ref OrderSent,
                        ref ReturnMessage);

            if (OrderSent != "")
            {
                ShowMessage(OrderSent, ReturnMessage);
            }
            else
            {

                this.Refresh();
                this.Close();
            }
        }




        private void AddECOrder()
        {
            try
            {
                if (!ValidateCancelReplaceEntry())
                {
                    return;
                }
                viewAccountComps.RowFilter = "TP_ACCT = " + cboAcct.SelectedValue + " AND TP_TRADE_COMP = " + txtComp.Text;
                viewCommodities.RowFilter = "TP_COMM = " + cboCommodities.SelectedValue;
                viewMonths.RowFilter = "TP_MON = '" + cboMon.SelectedValue + "' AND TP_COMM = " + cboCommodities.SelectedValue;
                //viewOrdTypes.RowFilter = "";
                //viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + cboOrderType.Text + "'";
                string strExchangeLetter = viewCommodities[0]["TP_EXCHLTR"].ToString();
                string strHedgerPosition = viewCommodities[0]["HEDGER_POSITION"].ToString();
                int AcctXref = Convert.ToInt32(viewAccountComps[0]["TP_ACCT_XREF"].ToString());
                int FixEO = 0;
                int FixGTC = 0;
                string OrderSent = "";
                string ReturnMessage = "";
                string Company = viewAccountComps[0]["TP_COMP"].ToString();
                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                string TransType = viewAccountComps[0]["TP_Trans_Type"].ToString();
                FixEO = 1;

                if (this.GTC.Checked)
                {
                    FixGTC = 1;
                }
                else
                {
                    FixGTC = 0;
                }
                OrdersNew Ord = new OrdersNew();
                Ord.AddOrderSingle(txtComp.Text, txtInd.Text, cboAcct.SelectedValue.ToString(), cboCommodities.SelectedValue.ToString(), strExchangeLetter,
                   cboMon.SelectedValue.ToString(), txtYear.Text, txtQty.Text, txtPrice.Text, cboOrderType.Text, Company,
                   FixEO, FixGTC, AcctXref, CurrentUser, TransType, ref OrderSent, ref ReturnMessage);

                if (OrderSent != "")
                {
                    ShowMessage(OrderSent, ReturnMessage);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
            }
        }


        private void ShowMessage(string OrderSent, string ReturnMessage)
        {
            if (OrderSent != "1")
            {
                MessageBox.Show(ReturnMessage.ToString());
            }
            else
            {
                this.Close();
            }
        }

        private void btnMarketOrder_Click(object sender, EventArgs e)
        {
            if(cboAcct.Text == "" || cboAcct.Text == " ")
            {
                MessageBox.Show("Please Enter an Account", "HedgeOrder");
                return;

            }
            this.txtPrice.Text = "0";

            if (cboOrderType.SelectedValue.ToString() != "MOC")
            {
                AddECOrder();
            }
            else
            {
                AddNonECOrder();
            }
        }

        private void btnLimitOrder_Click(object sender, EventArgs e)
        {

            if (cboAcct.Text == "" || cboAcct.Text == " ")
            {
                MessageBox.Show("Please Enter an Account", "HedgeOrder");
                return;

            }
            if (cboOrderType.SelectedValue.ToString() != "MOC")
            {
                AddECOrder();
            }
            else
            {
                AddNonECOrder();
            }

        }

        private void chkCMEPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (mLoading == false)
            {
                if (chkCMEPrice.Checked == true)
                {

                    this.chkWeightedAverage.Checked = false;
                    this.txtPrice.Text = this.txtCMEPrice.Text;

                }
                else
                {
                    this.txtPrice.Text = mPrice;
                }
            }


        }

        private void cboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrderType.Text == "MOC")
            {
                GTC.Checked = false;
                GTC.Enabled = false;

            }
            else
            {
                GTC.Enabled = true;
            }
        }

        //private void chkWeightedAverage_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkWeightedAverage.Checked == true)
        //    {
        //        this.txtPrice.Text = this.chkWeightedAverage.Text;
        //        this.chkCMEPrice.Checked = false;
        //    }
        //    else
        //    {
        //        this.txtPrice.Text = mPrice;
        //    }


        //}

        private void lstLastFiveCHPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mLoading == false)
            {
                if (lstLastFiveCHPrices.Items.Count > 0)
                {

                    this.chkCMEPrice.Checked = false;
                    this.chkWeightedAverage.Checked = false;
                    if (Convert.ToDecimal(lstLastFiveCHPrices.SelectedValue.ToString()) < 0)
                    {
                        this.txtPrice.Text = (Convert.ToDecimal(lstLastFiveCHPrices.SelectedValue.ToString()) * -1).ToString();
                    }
                    else
                    {
                        this.txtPrice.Text = lstLastFiveCHPrices.SelectedValue.ToString();
                    }
                }
            }
        }

        private void chkWeightedAverage_CheckedChanged(object sender, EventArgs e)
        {
            if(mLoading == false)
            {
                if (chkWeightedAverage.Checked == true)
                {
                    this.chkCMEPrice.Checked = false; 
                    this.txtPrice.Text = this.txtWeightedAverage.Text;

                }
                else
                {
                    this.txtPrice.Text = mPrice;
                }
            }


        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInd_TextChanged(object sender, EventArgs e)
        {
           
            txtInd.Text = txtInd.Text.ToUpper().ToString();
        }

        private void txtInd_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case (char)Keys.Return:
                case (char)Keys.Back:
                case (char)Keys.Escape:
                case (char)Keys.Left:
                case (char)Keys.Right:
                case (char)Keys.B:
                case (char)Keys.S:
                case 'b':
                case 's':
                    break;
                default:
                    e.Handled = true;
                    break;
            }
            
        }
    }
}


    


