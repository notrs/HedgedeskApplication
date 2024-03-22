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
    public partial class frmCommodityAddEdit : Form
    {
        public Int32 mUpdate = 0;
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
        public DataTable dtCommodities = new DataTable();
        public Int32 inActive;


        public frmCommodityAddEdit()
        {
            InitializeComponent();
        }


        private void UpdateCommodity()
        {
            mLoading = true;
            Maintenance maint = new Maintenance();
            maint.GetCommoditiesForUpdate(dtCommodities, inActive);
            viewAccounts = GlobalStore.mdtAccounts.DefaultView;
            viewMonths = GlobalStore.mdtMonths.DefaultView;
            viewCommodities = dtCommodities.DefaultView;
            viewAccountComps = GlobalStore.mdtAccountsComps.DefaultView;
            viewOrdTypes = GlobalStore.mdtOrderTypes.DefaultView;
            GlobalStore.FillCommodityTradingCompDataTable();

            viewCommodityTradingComp = GlobalStore.mdtCommodityTradingComp.DefaultView;
            GlobalStore.mdsOrder.Clear();

            OrdersNew ord = new OrdersNew();

            viewCommodities.RowFilter = "TP_COMM = '" + mCommodity.ToString() + "'";
            txtCommodityID.Text = viewCommodities[0]["TP_COMM"].ToString();
            txtCommodityID.Enabled = false;
            
            this.txtConfirmationConversion.Text = viewCommodities[0]["ConfirmationConversion"].ToString();
            this.txtContractConversion.Text = viewCommodities[0]["ContractConversion"].ToString();
            this.txtContractHedgedeskLimit.Text = viewCommodities[0]["ContractHedgedeskLimit"].ToString();
            this.txtDescription.Text = viewCommodities[0]["DESC"].ToString();
            this.txtExchangeLetter.Text = viewCommodities[0]["TP_EXCHLTR"].ToString();
            this.txtHedgerPosition.Text = viewCommodities[0]["Hedger_Position"].ToString();
            this.txtInitialMargin.Text = viewCommodities[0]["InitialMargin"].ToString();
            this.txtLowLimit.Text = viewCommodities[0]["LowLimit"].ToString();
            this.txtRangeHigh.Text = viewCommodities[0]["Range_High"].ToString();
            this.txtRangeLow.Text = viewCommodities[0]["Range_Low"].ToString();
            this.txtRoundingDivisor.Text = viewCommodities[0]["RoundingDivisor"].ToString();
            this.txtCGBOnlineID.Text = viewCommodities[0]["CGBID"].ToString();
            this.txtAbbreviation.Text = viewCommodities[0]["ABBREV"].ToString();
            this.txtSendtoHedgedeskLimit.Text = viewCommodities[0]["SendtoHedgedeskLimit"].ToString();
            this.txtSymbol.Text = viewCommodities[0]["Symbol"].ToString();
            this.txtDailyPriceLimit.Text = viewCommodities[0]["DailyPriceLimit"].ToString();
            if (viewCommodities[0]["TrackBushels"].ToString() == "1")
            {
                chkTrackBushels.Checked = true;
            }
            else
            {
                chkTrackBushels.Checked = false;
            }
            this.txtTickSizeID.Text = viewCommodities[0]["TickSizeID"].ToString();

        }

        private void AddCommodity()
        {
            mLoading = true;

            this.txtConfirmationConversion.Text = 5.ToString();
            this.txtContractConversion.Text = 5000.ToString();
            this.txtContractHedgedeskLimit.Text = 25000.ToString();
            this.txtLowLimit.Text = 2500.ToString();
            this.txtRoundingDivisor.Text = 5000.ToString();
            this.txtSendtoHedgedeskLimit.Text = 200000.ToString();
            this.txtTickSizeID.Text = "1";
            this.chkTrackBushels.Checked = true;
            

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


        private void frmCommodityAddEdit_Load(object sender, EventArgs e)
        {
            try
            {
                if (mUpdate == 0)
                {
                    AddCommodity();
                }
                else
                {
                    UpdateCommodity();
                }
                mLoading = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Commodity");

            }
        }

        private void txtRangeLow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtRangeHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtLowLimit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtRoundingDivisor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCGBOnlineID_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSendtoHedgedeskLimit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtContractHedgedeskLimit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtConfirmationConversion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTickSizeID_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtInitialMargin_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtContractConversion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCommodityID_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtDescription.Text == "" || txtExchangeLetter.Text == "")
                {
                    MessageBox.Show("All commodities require a Descripion and Exchange Letter.", "Commodity");
                    return;
                }

                
                
                Decimal RangeHigh = (txtRangeHigh.Text == "") ? 0 : Convert.ToDecimal(txtRangeHigh.Text);
                Decimal RangeLow = (txtRangeLow.Text == "") ? 0 : Convert.ToDecimal(txtRangeLow.Text);
                Decimal DailyPriceLimit = (txtDailyPriceLimit.Text == "") ? 0 : Convert.ToDecimal(txtDailyPriceLimit.Text); 
                int ConfirmationConversion = (txtConfirmationConversion.Text == "") ? 0 : Convert.ToInt32(txtConfirmationConversion.Text); 
                int ContractConversion = (txtContractConversion.Text == "") ? 0 : Convert.ToInt32(txtContractConversion.Text); 
                int ContractHedgedeskLimit = (txtContractHedgedeskLimit.Text == "") ? 0 : Convert.ToInt32(txtContractHedgedeskLimit.Text);
                int SendToHedgedeskLimit = (this.txtSendtoHedgedeskLimit.Text == "") ? 200000 : Convert.ToInt32(txtSendtoHedgedeskLimit.Text); 
                int InitialMargin = (txtInitialMargin.Text == "") ? 0 : Convert.ToInt32(txtInitialMargin.Text); 
                int LowLimit = (txtLowLimit.Text == "") ? 0 : Convert.ToInt32(txtLowLimit.Text); 
                int RoundingDivisor = (txtRoundingDivisor.Text == "") ? 0 : Convert.ToInt32(txtRoundingDivisor.Text); 
                int CGBOnlineID = (txtCGBOnlineID.Text == "") ? 0 : Convert.ToInt32(txtCGBOnlineID.Text); 

                int TrackBushels = 0;

                string Description = txtDescription.Text;
                string ExchangeLetter = this.txtExchangeLetter.Text;
                string HedgerPosition = this.txtHedgerPosition.Text;
                string Abbreviation = this.txtAbbreviation.Text;
                string Symbol = this.txtSymbol.Text;

                string ReturnMessage = "";

                string CurrentUser = WindowsIdentity.GetCurrent().Name;
                int TickSizeID = (txtTickSizeID.Text == "") ? 0 : Convert.ToInt32(txtTickSizeID.Text); 
                
                Maintenance maint = new Maintenance();

                if (chkTrackBushels.Checked == true)
                {
                    TrackBushels = 1;
                }
                if(mUpdate == 1)
                {
                    int CommodityID = Convert.ToInt32(mCommodity);

                    if (!maint.UpdateCommodity(CommodityID, Description, Abbreviation, HedgerPosition, RangeLow, RangeHigh, ContractConversion, ExchangeLetter,
                        Symbol, ConfirmationConversion, TrackBushels, TickSizeID, InitialMargin, CurrentUser, LowLimit, RoundingDivisor, CGBOnlineID,
                        SendToHedgedeskLimit, ContractHedgedeskLimit, 0, DailyPriceLimit, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage.ToString(), "Commodities");
                        return;
                    }
                }
                else
                {
                    int CommodityID = Convert.ToInt32(0);

                    if (!maint.AddCommodity(CommodityID, Description, Abbreviation, HedgerPosition, RangeLow, RangeHigh, ContractConversion, ExchangeLetter,
                        Symbol, ConfirmationConversion, TrackBushels, TickSizeID, InitialMargin, CurrentUser, LowLimit, RoundingDivisor, CGBOnlineID,
                        SendToHedgedeskLimit, ContractHedgedeskLimit, DailyPriceLimit, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage.ToString(), "Commodities");
                        return;
                    }
                }

                GlobalStore.FillCommodityDataTable();
                this.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Commodities");
            }
        }

        private void txtDailyPriceLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}



    


