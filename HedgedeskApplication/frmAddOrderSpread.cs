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
    public partial class frmAddOrderSpread : Form
    {
        public frmOrders frmCopyOrders;
        public DataView viewAccounts = new DataView();
        public DataView viewMonths = new DataView();
        public DataView viewCommodities = new DataView();
        public DataView viewOrdTypes = new DataView();
        public DataView viewAccountComps = new DataView();
        public DataView viewClosingPrices = new DataView();
        public Boolean fromECButton;
        public string mOrderID;
        public string SpreadID;
        public Boolean mLoading;
        public DataView viewOrder = new DataView();
        public string Comments = "";
        public string Scomments = "";


        public frmAddOrderSpread()
        {
            InitializeComponent();
        }
       
        private void frmAddOrder_Load(object sender, EventArgs e)
        {
            try
            {
                mLoading = true;
                ActiveControl = this.cmdAdd;
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
                if (fromECButton == false)
                {


                    this.txtAcct.Text = ((frmOrders)this.frmCopyOrders).txtAcct.Text;
                    this.txtInd.Text = ((frmOrders)this.frmCopyOrders).txtInd.Text;
                    this.txtMonth.Text = ((frmOrders)this.frmCopyOrders).txtMonth.Text;
                    this.txtYear.Text = ((frmOrders)this.frmCopyOrders).txtYear.Text;
                    this.txtOrdType.Text = ((frmOrders)this.frmCopyOrders).txtType.Text;
                    this.txtPrice.Text = ((frmOrders)this.frmCopyOrders).txtPrice.Text;
                    this.txtQty.Text = ((frmOrders)this.frmCopyOrders).txtQty.Text;
                    this.txtComp.Text = ((frmOrders)this.frmCopyOrders).txtComp.Text;
                    this.txtComm.Text = ((frmOrders)this.frmCopyOrders).txtComm.Text;
                    this.GTC.Checked = ((frmOrders)this.frmCopyOrders).GTC.Checked;
                    Comments = ((frmOrders)this.frmCopyOrders).txtComments.Text;
                    Scomments = ((frmOrders)this.frmCopyOrders).txtSComments.Text;
                    this.lblOrderNumber.Visible = false;
                    this.txtAcct.Enabled = true;
                    this.txtInd.Enabled = true;
                    this.txtMonth.Enabled = true;
                    this.txtYear.Enabled = true;
                    this.txtOrdType.Enabled = true;
                    this.txtPrice.Enabled = true;
                    this.txtQty.Enabled = true;
                    this.txtComp.Enabled = true;
                    this.txtComm.Enabled = true;
                    this.GTC.Enabled = true;
                    this.txtSAcct.Text = ((frmOrders)this.frmCopyOrders).txtSAcct.Text;
                    this.txtSInd.Text = ((frmOrders)this.frmCopyOrders).txtSBuy.Text;
                    this.txtSMonth.Text = ((frmOrders)this.frmCopyOrders).txtSMonth.Text;
                    this.txtSYear.Text = ((frmOrders)this.frmCopyOrders).txtSYear.Text;
                    this.txtSComp.Text = ((frmOrders)this.frmCopyOrders).txtSComp.Text;
                    this.txtSComm.Text = ((frmOrders)this.frmCopyOrders).txtSComm.Text;
                    //BuildLabel();
                    mLoading = false;
                   

                }
                else
                {
                    GlobalStore.mdsOrder.Clear();
                    GlobalStore.FillOrderDataTable(mOrderID.ToString());
                    viewOrder = GlobalStore.mdsOrder.DefaultView;
                    SpreadID = viewOrder[0]["SecondID"].ToString();
                    this.txtAcct.Text = viewOrder[0]["A/C"].ToString();
                    this.txtInd.Text = viewOrder[0]["B/S"].ToString();
                    this.txtMonth.Text = viewOrder[0]["Month"].ToString();
                    this.txtYear.Text = viewOrder[0]["Year"].ToString();
                    this.txtOrdType.Text = viewOrder[0]["Type"].ToString();
                    this.txtPrice.Text = viewOrder[0]["Price"].ToString();
                    this.txtQty.Text = viewOrder[0]["Qty"].ToString();
                    this.txtComp.Text = viewOrder[0]["Comp"].ToString();
                    this.txtComm.Text = viewOrder[0]["Comm"].ToString();
                    this.lblOrderNumber.Text = mOrderID.ToString();
                    this.lblOrderNumber.Visible = true;
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
                    this.txtSComp.Text = viewOrder[0]["Comp"].ToString();
                    this.txtSComm.Text = viewOrder[0]["Comm"].ToString();
                    
                }
                BuildLabel();
                mLoading = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
            }

        }
        private void BuildLabel()
        {

            this.lblTradeCompany.Text = "";
            this.txtSell.Text = "";
            this.txtBuy.Text = "";
            txtGTCSell.Visible = false;
            txtGTCBuy.Visible = false;
            this.txtBuyPrice.Text = "";
            this.txtSellPrice.Text = "";

            string Month = "";
            string Commodity = "";
            this.lblDate.Text = System.DateTime.Now.ToString();
            this.viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "'";
            Month = viewMonths[0]["DESC"].ToString();
            this.viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
            Commodity = viewCommodities[0]["DESC"].ToString();
            viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
            if (viewAccountComps.Count != 0)
            {
                this.Text = "Add " + viewAccountComps[0]["DESC"].ToString() + " Order";
                this.lblTradeCompany.Text = viewAccountComps[0]["DESC"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid account/trading company combination");
            }


            if (this.txtInd.Text == "B")
            {

                this.txtBuy.Text = txtQty.Text + "     " + Month.ToString() + " " + txtYear.Text + " " + Commodity.ToString() + " " + this.txtOrdType.Text;
                if (txtPrice.Text != "0" && txtPrice.Text != "")
                {
                    this.txtBuyPrice.Text = txtPrice.Text;
                }
                if (GTC.Checked)
                {
                    txtGTCBuy.Visible = true;
                }
                else
                {
                    txtGTCBuy.Visible = false;
                }
            }
            else
            {
                this.txtSell.Text = txtQty.Text + "     " + Month.ToString() + " " + txtYear.Text + " " + Commodity.ToString() + " " + this.txtOrdType.Text;
                if (txtPrice.Text != "0" && txtPrice.Text != "")
                {
                    this.txtSellPrice.Text = txtPrice.Text;
                }
                if (GTC.Checked)
                {
                    txtGTCSell.Visible = true;
                }
                else
                {
                    txtGTCSell.Visible = false;
                }

            }
            if (viewAccountComps.Count != 0)
            {
                this.lblTradeCompany.Text = viewAccountComps[0]["DESC"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid account/trading company combination");
            }


            if (this.txtInd.Text == "B")
            {

                this.txtBuy.Text = txtQty.Text + "     " + Month.ToString() + " " + txtYear.Text + " " + Commodity.ToString() + " " + this.txtOrdType.Text;
                if (txtPrice.Text != "0" && txtPrice.Text != "")
                {
                    this.txtBuyPrice.Text = txtPrice.Text;
                }
                if (GTC.Checked)
                {
                    txtGTCBuy.Visible = true;
                }
                else
                {
                    txtGTCBuy.Visible = false;
                }
            }
            else
            {
                this.txtSell.Text = txtQty.Text + "     " + Month.ToString() + " " + txtYear.Text + " " + Commodity.ToString() + " " + this.txtOrdType.Text;
                if (txtPrice.Text != "0" && txtPrice.Text != "")
                {
                    this.txtSellPrice.Text = txtPrice.Text;
                }
                if (GTC.Checked)
                {
                    txtGTCSell.Visible = true;
                }
                else
                {
                    txtGTCSell.Visible = false;
                }

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



        private void txtInd_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                    e.Handled = true;
                    txtInd.Text = "S".ToUpper();
                    txtQty.Focus();
                    break;
                case '2':
                    e.Handled = true;
                    txtInd.Text = "B".ToUpper();
                    txtQty.Focus();
                    break;
                case 's':
                case 'S':
                    e.Handled = true;
                    txtInd.Text = "S".ToUpper();
                    txtQty.Focus();
                    break;
                case 'b':
                case 'B':
                    e.Handled = true;
                    txtInd.Text = "B".ToUpper();
                    txtQty.Focus();
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
            if (!mLoading)
            {
                BuildLabel();
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

        private void txtAcct_TextChanged(object sender, EventArgs e)
        {
            if (txtAcct.Text.Length == 3)
            {
                if (!mLoading)
                {
                    BuildLabel();
                } 
                txtInd.Focus();
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
                    BuildLabel();
                }
            }
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
                    if (!mLoading)
                    {
                        BuildLabel();
                    }
                    txtYear.Focus();
                }
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Length == 2)
            {
                if (!mLoading)
                {
                    BuildLabel();
                }
                txtComm.Focus();
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
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
                if (!mLoading)
                {
                    BuildLabel();
                } 
                txtPrice.Focus();
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
                    BuildLabel();
                }
            }
        }

        private void txtFilled_KeyPress(object sender, KeyPressEventArgs e)
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
                    case '.':
                        //case (char)Keys.OemPeriod:
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }
        private void txtComp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtComp_TextChanged(object sender, EventArgs e)
        {
            if (txtComp.Text.Length == 2)
            {
                if (!mLoading)
                {
                    BuildLabel();
                } 
                GTC.Focus();
            }
        }

        private void GTC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (GTC.Checked)
                {
                    switch (this.txtOrdType.Text.ToString())
                    {
                        case "ERX":
                        case "MKT":
                        case "PIT":
                        case "ZGTC":
                        case "ORD":
                        case "EMC":
                        case "SPR":
                            break;
                        case "":
                            MessageBox.Show("Please select an order type before choosing GTC.", "Hedge Order");
                            GTC.Checked = false;
                            break;
                        default:
                            MessageBox.Show("This order type cannot be set as GTC.", "Hedge Order");
                            GTC.Checked = false;
                            break;
                    }
                    if (!mLoading)
                    {
                        BuildLabel();
                    }
                }
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (this.txtOrdType.Text != "SPR")
            {
                SingleOrders();
            }
            else
            {
                if (this.fromECButton)
                {
                    SpreadECOrders();
                }
                else
                {
                    SpreadOrders();
                }
            }
              
        }
        private void SingleOrders()
        {
            try
            {
                if (this.frmCopyOrders.ValidateEntry("0", txtAcct.Text, txtInd.Text, txtQty.Text,
                                        txtYear.Text, txtMonth.Text, txtComm.Text, txtOrdType.Text,
                                        txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                        txtSYear.Text, false, "True", this.GTC.ToString()) == true)
                    viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
                viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
                viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "' AND TP_COMM = " + txtComm.Text;
                viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + txtOrdType.Text + "'";
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
                if (this.fromECButton == false)
                {
                    Ord.AddOrderSingle(txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
                       txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtOrdType.Text, Company,
                       FixEO, FixGTC, AcctXref, CurrentUser, TransType, ref OrderSent, ref ReturnMessage);
                }
                else
                {
                    Ord.AddOrderECSingle(mOrderID, txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
                       txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtOrdType.Text, Company,
                       FixEO, FixGTC, AcctXref, CurrentUser, TransType, ref OrderSent, ref ReturnMessage);
                }
                this.frmCopyOrders.dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                this.frmCopyOrders.dgvOrders.DataSource = this.frmCopyOrders.dtOrders;

                if (OrderSent != "" && OrderSent != "1")
                {
                    frmCopyOrders.ShowMessage(OrderSent, ReturnMessage);
                    this.Close();
                }
                else
                {
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
            }
         
        }

        private void SpreadECOrders()
        {
            try
            {
                if (this.frmCopyOrders.ValidateEntry("0", txtAcct.Text, txtInd.Text, txtQty.Text,
                                        txtYear.Text, txtMonth.Text, txtComm.Text, txtOrdType.Text,
                                        txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                        txtSYear.Text, false, "True", this.GTC.ToString()) == true)
                    viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
                viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
                viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "' AND TP_COMM = " + txtComm.Text;
                viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + txtOrdType.Text + "'";
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
                if (this.fromECButton == false)
                {
                    Ord.AddOrderSpread(txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
                       txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtOrdType.Text, Company,
                       FixEO, FixGTC, AcctXref, CurrentUser, TransType, txtPremSide.Text, txtSMonth.Text,
                       txtSYear.Text, txtSInd.Text, "", "", "", ref OrderSent, ref ReturnMessage, Comments, Scomments, "Y", ref ReturnMessage);
                }
                else
                {
                    Ord.AddOrderECSpread(SpreadID.ToString(), txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
                       txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtOrdType.Text, Company,
                       FixEO, FixGTC, AcctXref, CurrentUser, TransType, txtPremSide.Text, txtSMonth.Text,
                       txtSYear.Text, txtSInd.Text, "", "", "", ref OrderSent, ref ReturnMessage);
                }
                this.frmCopyOrders.dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                this.frmCopyOrders.dgvOrders.DataSource = this.frmCopyOrders.dtOrders;

                if (OrderSent != "" && OrderSent != "1")
                {
                    frmCopyOrders.ShowMessage(OrderSent, ReturnMessage);
                    this.Close();
                }
                else
                {
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
            }

        }

        private void SpreadOrders()
        {
            try
            {
                if (this.frmCopyOrders.ValidateEntry("0", txtAcct.Text, txtInd.Text, txtQty.Text,
                                        txtYear.Text, txtMonth.Text, txtComm.Text, txtOrdType.Text,
                                        txtComp.Text, txtPrice.Text, txtPremSide.Text, txtSMonth.Text,
                                        txtSYear.Text, false, "True", this.GTC.ToString()) == true)
                    viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
                viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
                viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "' AND TP_COMM = " + txtComm.Text;
                viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + txtOrdType.Text + "'";
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
                if (this.fromECButton == false)
                {
                    Ord.AddOrderSingle(txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
                       txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtOrdType.Text, Company,
                       FixEO, FixGTC, AcctXref, CurrentUser, TransType, ref OrderSent, ref ReturnMessage);
                }
                else
                {
                    Ord.AddOrderECSingle(mOrderID, txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
                       txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtOrdType.Text, Company,
                       FixEO, FixGTC, AcctXref, CurrentUser, TransType, ref OrderSent, ref ReturnMessage);
                }
                this.frmCopyOrders.dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                this.frmCopyOrders.dgvOrders.DataSource = this.frmCopyOrders.dtOrders;

                if (OrderSent != "" && OrderSent != "1")
                {
                    frmCopyOrders.ShowMessage(OrderSent, ReturnMessage);
                    this.Close();
                }
                else
                {
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
            }

        }
        private void ChangeControlColorFocus(System.Windows.Forms.TextBox tbox)
        {
            foreach (Control c in tbAddOrder.Controls)
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
        }

        private void ChangeControlColorCboxFocus(System.Windows.Forms.CheckBox cbox)
        {
            foreach (Control c in tbAddOrder.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    c.BackColor = System.Drawing.Color.White;
                    c.ForeColor = System.Drawing.Color.Black;
                }
            }
            foreach (Control c in tbAddOrder.Controls)
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


        private void txtAcct_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtAcct);

        }

        private void txtInd_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtInd);

        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtQty);

        }

        private void txtMonth_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtMonth);

        }

        private void txtSMonth_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtSMonth);

        }

        private void txtYear_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtYear);

        }

        private void txtSYear_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtSYear);

        }

        private void txtComm_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtComm);

        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtPrice);

        }


        private void txtComp_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtComp);

        }

        private void txtPremSide_Enter(object sender, EventArgs e)
        {
            ChangeControlColorFocus(txtPremSide);
        }

        private void GTC_Enter(object sender, EventArgs e)
        {
            ChangeControlColorCboxFocus(GTC);
        }

 

    }


}
    


