using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace HedgedeskApplication
{
    public partial class frmHedgeSettings : Form
    {
        Settings settings = new Settings();
        
        public frmHedgeSettings()
        {
            InitializeComponent();

        }

             
        private void frmHedgeSettings_Load(object sender, EventArgs e)
        {
            LoadForm();
            
        }

        private void LoadForm()
        {
            try
            {
                GlobalStore.mdtSystemSettings.Clear();
                DataView viewSystem = new DataView();
                DataTable dtExchangeDays = new DataTable();
                dtExchangeDays.Clear();
                settings.GetExchangeCalendarDays(dtExchangeDays);
                GlobalStore.FillHedgeSettingsDataTable();
                viewSystem = GlobalStore.mdtSystemSettings.DefaultView;
                this.txtHedgebookOrdLimit.Text = viewSystem[0]["HedgebookOrdLimit"].ToString();
                this.txtHedgeBookSpreadLimit.Text = viewSystem[0]["HedgebookSpreadLimit"].ToString();
                this.txtHedgeDeskOrdLimit.Text = viewSystem[0]["HedgeContractLimit"].ToString();
                this.txtHedgeDeskSpreadLimit.Text = viewSystem[0]["HedgedeskSpreadLimit"].ToString();
                this.txtNextTradeDate.Text = viewSystem[0]["NextTradingDay"].ToString();
                if (viewSystem[0]["isHoliday"].ToString() == "0")
                {
                    chkHoliday.Checked = false;
                }
                else
                {
                    chkHoliday.Checked = true;
                }
                this.dtpHolidayOpenDate.Value = Convert.ToDateTime(viewSystem[0]["HolidayOpen"].ToString());
                this.dtpHolidayOpenTime.Value = Convert.ToDateTime(viewSystem[0]["HolidayOpen"].ToString());
                this.dtpEMCTime.Value = Convert.ToDateTime(viewSystem[0]["EMCTime"].ToString());
                this.dtpCHOrderStart.Value = Convert.ToDateTime(viewSystem[0]["ContractHedgeStart"].ToString());
                this.dtpCHOrderEnd.Value = Convert.ToDateTime(viewSystem[0]["ContractHedgeEnd"].ToString());
                this.dtpVCFOrderStart.Value = Convert.ToDateTime(viewSystem[0]["VCFHedgeStart"].ToString());
                this.dtpVCFOrderEnd.Value = Convert.ToDateTime(viewSystem[0]["VCFHedgeEnd"].ToString());

                this.dtpGTCOrderEnd.Value = Convert.ToDateTime(viewSystem[0]["LimitStop"].ToString());
                this.dtpGTCOrderStart.Value = Convert.ToDateTime(viewSystem[0]["GTCReopen"].ToString());
                this.dtpLimitOrderStart.Value = Convert.ToDateTime(viewSystem[0]["MarketOpen"].ToString());
                this.dtpMarketOrderEnd.Value = Convert.ToDateTime(viewSystem[0]["MarketFirstClose"].ToString());
                this.dtpMarketOrderStart.Value = Convert.ToDateTime(viewSystem[0]["MarketFirstOpen"].ToString());
                this.dtpSundayPretrade.Value = Convert.ToDateTime(viewSystem[0]["SundayMarketOpen"].ToString());

                this.dgvExchangeCalendarDays.AutoGenerateColumns = false;
                this.dgvExchangeCalendarDays.DataSource = dtExchangeDays;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnUpdateHolidayInfo_Click(object sender, EventArgs e)
        {
            int isHoliday = 0;
            if (this.chkHoliday.Checked == true && this.dtpHolidayOpenDate.Text == "")
            {
                MessageBox.Show("Please Enter a Holiday Date and Time.");
                return;

            }

            if (this.chkHoliday.Checked == true && this.dtpHolidayOpenTime.Text == "")
            {
                MessageBox.Show("Please Enter a Holiday Date and Time.");
                return;

            }

            if (this.chkHoliday.Checked == true)
            {
                isHoliday = 1;
            }

            string HolidayDateTime = this.dtpHolidayOpenDate.Text + " " + this.dtpHolidayOpenTime.Text;
            
            string ReturnMessage = "";
            try
            {
                if (!settings.UpdateHolidayOrderTimes(isHoliday, HolidayDateTime, ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage.ToString(), "HedgeSettings");
                }
                else
                {
                    MessageBox.Show("Holiday date time have been set for the open.", "Hedge Settings");
                    LoadForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnUpdateHedgeBookLimits_Click(object sender, EventArgs e)
        {
            if (this.txtHedgebookOrdLimit.Text == "")
            {
                MessageBox.Show("Please Enter a Hedgebook Order Limit.");
                return;

            }

            if (this.txtHedgeBookSpreadLimit.Text == "")
            {
                MessageBox.Show("Please Enter a Hedgebook Spread Limit.");
                return;

            }

            int OrdLimit = Convert.ToInt32(txtHedgebookOrdLimit.Text.ToString());
            int SpreadLimit = Convert.ToInt32(txtHedgeBookSpreadLimit.Text.ToString());

            string ReturnMessage = "";
            try
            {
                if (!settings.UpdateHedgebookOrderLimits(OrdLimit, SpreadLimit, ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage.ToString(), "HedgeSettings");
                }
                else
                {
                    MessageBox.Show("Hedgebook Limits have been updated.", "Hedge Settings");
                    LoadForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnUpdateHedgedeskLimits_Click(object sender, EventArgs e)
        {
            if (this.txtHedgeDeskOrdLimit.Text == "")
            {
                MessageBox.Show("Please Enter a Hedgedesk Order Limit.");
                return;

            }

            if (this.txtHedgeDeskSpreadLimit.Text == "")
            {
                MessageBox.Show("Please Enter a Hedgedesk Spread Limit.");
                return;

            }

            int OrdLimit = Convert.ToInt32(txtHedgeDeskOrdLimit.Text.ToString());
            int SpreadLimit = Convert.ToInt32(txtHedgeDeskSpreadLimit.Text.ToString());
            
            string ReturnMessage = "";
            try
            {
                if(!settings.UpdateHedgeDeskOrderLimits(OrdLimit, SpreadLimit, ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage.ToString(), "HedgeSettings");
                }
                else
                {
                    MessageBox.Show("Hedgedesk Limits have been updated.", "Hedge Settings");
                    LoadForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnUpdateMarketTimes_Click(object sender, EventArgs e)
        {
            if (this.dtpSundayPretrade.Text == "")
            {
                MessageBox.Show("Please Enter a Sunday Time.");
                return;

            }

            if (this.dtpMarketOrderStart.Text == "")
            {
                MessageBox.Show("Please Enter a Market Order Start Time.");
                return;

            }

            if (this.dtpMarketOrderEnd.Text == "")
            {
                MessageBox.Show("Please Enter a Market Order End Time.");
                return;

            }

            if (this.dtpLimitOrderStart.Text == "")
            {
                MessageBox.Show("Please Enter a Limit Order Start Time.");
                return;

            }

            

            if (this.dtpGTCOrderStart.Text == "")
            {
                MessageBox.Show("Please Enter a GTC Order Start Time.");
                return;

            }

            if (this.dtpGTCOrderEnd.Text == "")
            {
                MessageBox.Show("Please Enter a GTC Order End Time.");
                return;

            }

            if (this.dtpEMCTime.Text == "")
            {
                MessageBox.Show("Please Enter an EMC Order Cutoff Time.");
                return;

            }

            string MarketStart = dtpMarketOrderStart.Value.ToLongTimeString();
            string MarketEnd = dtpMarketOrderEnd.Value.ToLongTimeString();
            string LimitStart = dtpLimitOrderStart.Value.ToLongTimeString();
            string LimitEnd = dtpMarketOrderEnd.Value.ToLongTimeString();
            string GTCStart = dtpGTCOrderStart.Value.ToLongTimeString();
            string GTCEnd = dtpGTCOrderEnd.Value.ToLongTimeString();
            string SundayStart = dtpSundayPretrade.Value.ToLongTimeString();
            string EMCEnd = dtpEMCTime.Value.ToLongTimeString();
            string ReturnMessage = "";
            try
            {
                if (!settings.UpdateMarketOrderTimes(MarketStart, MarketEnd, LimitStart, LimitEnd, GTCStart, GTCEnd, SundayStart, EMCEnd, ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage.ToString(), "HedgeSettings");
                }
                else
                {
                    MessageBox.Show("Market Hedge Times have been updated.", "Hedge Settings");
                    LoadForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnUpdateContractTimes_Click(object sender, EventArgs e)
        {
            if (this.dtpCHOrderEnd.Text == "")
            {
                MessageBox.Show("Please Enter a Contract End Time.");
                return;

            }

            if (this.dtpCHOrderStart.Text == "")
            {
                MessageBox.Show("Please Enter a Contract Start Time.");
                return;

            }

            if (this.dtpVCFOrderEnd.Text == "")
            {
                MessageBox.Show("Please Enter a VCF End Time.");
                return;

            }

            if (this.dtpVCFOrderStart.Text == "")
            {
                MessageBox.Show("Please Enter a VCF Start Time.");
                return;

            }

            string CHStart = dtpCHOrderStart.Value.ToLongTimeString();
            string CHEnd = dtpCHOrderEnd.Value.ToLongTimeString();
            string VCFStart = dtpVCFOrderStart.Value.ToLongTimeString();
            string VCFEnd = dtpVCFOrderEnd.Value.ToLongTimeString();
            string ReturnMessage = "";
            try
            {
                if(!settings.UpdateContractTimes(CHStart, CHEnd, VCFStart, VCFEnd, ref ReturnMessage))
                {
                    MessageBox.Show(ReturnMessage.ToString(), "HedgeSettings");
                }
                else
                {
                    MessageBox.Show("CH and VCF Contract Times have been updated.", "Hedge Settings");
                    LoadForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

       
       
    }
}
