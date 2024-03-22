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
    public partial class frmAddRegionOrder : Form
    {
        public frmOrders frmCopyOrders;
        public DataView viewAccounts = new DataView();
        public DataView viewMonths = new DataView();
        public DataView viewCommodities = new DataView();
        public DataView viewOrdTypes = new DataView();
        public DataView viewAccountComps = new DataView();
        public DataView viewClosingPrices = new DataView();
        public OrdersNew Ord = new OrdersNew();
        public OrdersUpdate OrdUpdate = new OrdersUpdate();
        public int RequestRowIndex = 0;
        public int ReqID = 0;
        public string RequestTradeCo = "";

        public frmAddRegionOrder()
        {
            InitializeComponent();
        }
       
        private void frmAddRegionOrder_Load(object sender, EventArgs e)
        {
            try
            {
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
                this.txtAcct.Text = ((frmOrders)this.frmCopyOrders).dgvRegionOrders.Rows[RequestRowIndex].Cells["Acct"].Value.ToString();
                this.txtInd.Text = ((frmOrders)this.frmCopyOrders).dgvRegionOrders.Rows[RequestRowIndex].Cells["Ind"].Value.ToString();
                this.txtMonth.Text = ((frmOrders)this.frmCopyOrders).dgvRegionOrders.Rows[RequestRowIndex].Cells["ReqMonth"].Value.ToString();
                this.txtYear.Text = ((frmOrders)this.frmCopyOrders).dgvRegionOrders.Rows[RequestRowIndex].Cells["ReqYear"].Value.ToString();
                this.txtOrdType.Text = ((frmOrders)this.frmCopyOrders).dgvRegionOrders.Rows[RequestRowIndex].Cells["ReqType"].Value.ToString();
                this.txtPrice.Text = ((frmOrders)this.frmCopyOrders).dgvRegionOrders.Rows[RequestRowIndex].Cells["ReqPrice"].Value.ToString();
                this.txtQty.Text = ((frmOrders)this.frmCopyOrders).dgvRegionOrders.Rows[RequestRowIndex].Cells["ReqQty"].Value.ToString();
                this.txtComp.Text = RequestTradeCo;
                this.txtComm.Text = ((frmOrders)this.frmCopyOrders).dgvRegionOrders.Rows[RequestRowIndex].Cells["ReqComm"].Value.ToString();
                if(((frmOrders)this.frmCopyOrders).dgvRegionOrders.Rows[RequestRowIndex].Cells["ReqGTC"].Value.ToString()=="true")
                {
                    this.GTC.Checked = true;
                }
                else
                {
                    this.GTC.Checked = false;
               }
                string Month = "";
                string Commodity = "";
                this.lblDate.Text = System.DateTime.Now.ToString();
                this.viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "'";
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("No Month specified for this order");

                    this.Close();
                }
                Month = viewMonths[0]["DESC"].ToString();
                this.viewCommodities.RowFilter = "TP_COMM = " + txtComm.Text;
                if (viewMonths.Count == 0)
                {
                    MessageBox.Show("No Commodity specified for this order");
                    this.Close();
                }
                Commodity = viewCommodities[0]["DESC"].ToString();
                viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
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
                ((frmOrders)this.frmCopyOrders).dtRegionOrders.Clear();
                ((frmOrders)this.frmCopyOrders).dtRegionOrders = GlobalStore.FillRegionOrdersDataSet().Tables[0];
                ((frmOrders)this.frmCopyOrders).dgvRegionOrders.DataSource = ((frmOrders)this.frmCopyOrders).dtRegionOrders;
                ((frmOrders)this.frmCopyOrders).dgvRegionOrders.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
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

                    txtYear.Focus();
                }
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Length == 2)
            {
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
                        break;
                    default:
                        e.Handled = true;
                        break;
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
                        case "SPR":
                        case "EMC":
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
            }
        }

        private void txtCardNumber_Leave(object sender, EventArgs e)
        {

            ValidateEntry();

        }

        private void ValidateEntry()
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

            if (txtAcct.Text == "")
            {
                MessageBox.Show("Enter an account", "Hedge Order");
                return;
            }
            else
            {
                viewAccounts.RowFilter = "TP_ACCT = " + txtAcct.Text;
                if (viewAccounts.Count == 0)
                {
                    MessageBox.Show("Invalid Account entered", "Hedge Order");
                    return;

                }
            }

            if (txtInd.Text == "")
            {
                MessageBox.Show("Enter Buy or Sell", "Hedge Order");
                return;
            }
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
            if (txtYear.Text == "")
            {
                MessageBox.Show("Enter a valid Year", "Hedge Order");
                return;
            }
            else
            {

                DateTime time = DateTime.Now;              // Use current time
                string format = "yy";    // Use this format
                if (Convert.ToInt16(txtYear.Text.ToString()) < Convert.ToInt16(time.ToString(format)))
                {
                    MessageBox.Show("Enter a valid Year.", "Hedge Order");
                    return;
                }

            }


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
            if (txtOrdType.Text == "")
            {
                MessageBox.Show("Cancel this form and Enter an Order Type", "Hedge Order");
                return;
            }
            else
            {

                viewOrdTypes.RowFilter = "TP_ORD_TYPE = '" + txtOrdType.Text + "'";
                if (viewOrdTypes.Count == 0)
                {
                    MessageBox.Show("Invalid Order type", "Hedge Order");
                    return;

                }

            }
            if (txtComp.Text == "")
            {
                MessageBox.Show("Select a Trading Company.", "Hedge Order");
                return;
            }
            else
            {

                viewAccountComps.RowFilter = "TP_COMP = " + txtComp.Text;
                if (viewAccountComps.Count == 0)
                {
                    MessageBox.Show("Invalid Trading Company.", "Hedge Order");
                    return;

                }

            }

            viewMonths.RowFilter = "TP_MON = '" + txtMonth.Text + "' AND TP_COMM = " + txtComm.Text;
            if (viewMonths.Count == 0)
            {
                MessageBox.Show("Invalid Option month for the Commodity selected.", "Hedge Order");
                return;

            }

            viewAccountComps.RowFilter = "TP_ACCT = " + txtAcct.Text + " AND TP_TRADE_COMP = " + txtComp.Text;
            if (viewAccountComps.Count == 0)
            {
                MessageBox.Show("Invalid Trading Account/Company combination.", "Hedge Order");
                return;

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
                        if ((dblPrice <= Convert.ToDouble(viewCommodities[0]["ClosingPrice"].ToString()) - dblRange_Low) || (dblPrice >= Convert.ToDouble(viewCommodities[0]["ClosingPrice"].ToString()) + dblRange_High))
                        {
                            if (MessageBox.Show("Price is out of Range." + Environment.NewLine + "Low = " + (Convert.ToDouble(viewCommodities[0]["ClosingPrice"].ToString()) - dblRange_Low).ToString() + " High = " + (Convert.ToDouble(viewCommodities[0]["ClosingPrice"].ToString()) + dblRange_High).ToString() + Environment.NewLine + "Please choose OK to continue or Cancel to return to the order.", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                return;
                            }

                        }
                    }
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
            OrdUpdate.UnSelectOrder(ReqID);
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateEntry();
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
                
                if(this.frmCopyOrders.EO.Checked)
                {
                    FixEO = 1;
                }
                else
                {
                    FixEO = 0;
                }
                if(this.GTC.Checked)
                {
                    FixGTC = 1;
                }
                else
                {
                    FixGTC = 0;
                }
                Ord.AddOrderSingle(txtComp.Text, txtInd.Text, txtAcct.Text, txtComm.Text, strExchangeLetter,
                   txtMonth.Text, txtYear.Text, txtQty.Text, txtPrice.Text, txtOrdType.Text, Company,
                   FixEO, FixGTC, AcctXref, CurrentUser, TransType, ref OrderSent, ref ReturnMessage);

                this.frmCopyOrders.dtOrders = GlobalStore.FillOrdersDataTable().Tables[0];
                this.frmCopyOrders.dgvOrders.DataSource = this.frmCopyOrders.dtOrders;
                this.Close();


        
        //' TP_ORD_NUMB
        //strFields = "TP_ORD_NUMB, "
        //strValues = intNext_Sequence & ", "
        
        //strFields = strFields & "CLORDERID, "
        //strValues = strValues & "'" & intNext_Sequence & "'" & ", "
        //' TP_ORD_SEQ
        //strFields = strFields & "TP_ORD_SEQ, "
        //strValues = strValues & 1 & ", "
        
        //strFields = strFields & "TP_DATE, "
        //strValues = strValues & "#" & FormatDateTime(Me.txtDate, vbShortDate) & "#" & ", "
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hedge Order");
            }
        }

    }


}
    


