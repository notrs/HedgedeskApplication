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
    public partial class frmMoveMonthEndTrades : Form
    {
        Settings settings = new Settings();
        OrdersUpdate ord = new OrdersUpdate();

        public frmMoveMonthEndTrades()
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
                DataTable dtBrokers = new DataTable();
                settings.GetBrokers(dtBrokers);
                cboBrokers.DataSource = dtBrokers;
                cboBrokers.DisplayMember = "BrokerDescription";
                cboBrokers.ValueMember = "Company";
                txtNumberToMove.Text = 10.ToString();
                GlobalStore.mdtSystemSettings.Clear();
                DataView viewSystem = new DataView();

                GlobalStore.FillHedgeSettingsDataTable();
                viewSystem = GlobalStore.mdtSystemSettings.DefaultView;

                this.txtTradeCompTo.Text = viewSystem[0]["MoveToCompanyID"].ToString();
                cboBrokers.SelectedIndex = 1;
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void RefreshGrid()
        {
            GlobalStore.mdtSystemSettings.Clear();
            DataView viewSystem = new DataView();

            GlobalStore.FillHedgeSettingsDataTable();
            viewSystem = GlobalStore.mdtSystemSettings.DefaultView;

            this.txtTradeCompTo.Text = viewSystem[0]["MoveToCompanyID"].ToString();

            Int32 TradeCompany = 0;
            Int32 TradeYear = 0;
            String Month = "";

            if (this.cboBrokers.Text != "")
            {
                TradeCompany = Convert.ToInt32(cboBrokers.SelectedValue.ToString());
            }
            if (this.txtTradeYear.Text != "")
            {
                TradeYear = Convert.ToInt32(txtTradeYear.Text);
            }
            if (this.txtTradeMonth.Text != "")
            {
                Month = txtTradeMonth.Text;
            }

            DataTable dtMoveableTrades = new DataTable();
            DataTable dtMoveableTradesCount = new DataTable();
            dtMoveableTrades.Clear();
            ord.GetMoveableTrades(Month, TradeYear, TradeCompany, dtMoveableTrades);
            ord.GetMoveableTradesCount(Month, TradeYear, TradeCompany, dtMoveableTradesCount);

            this.txtTradeCount.Text = dtMoveableTradesCount.DefaultView[0]["CountContracts"].ToString();

            if (txtNumberToMove.Text != "" && txtTradeCount.Text != "")
            {
                if (Convert.ToInt32(txtTradeCount.Text) < Convert.ToInt32(this.txtNumberToMove.Text))
                {
                    this.txtNumberToMove.Text = txtTradeCount.Text;
                }
            }


            this.dgvMoveTradesList.AutoGenerateColumns = false;
            this.dgvMoveTradesList.DataSource = dtMoveableTrades;
        }

                 
        private void btnUpdateMoveToCompany_Click(object sender, EventArgs e)
        {

            try
            {
                frmMoveTradesTradingCompanyEdit frm = new frmMoveTradesTradingCompanyEdit();
                frm.ShowDialog();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (this.txtTradeCompTo.Text == cboBrokers.SelectedValue.ToString())
            {
                MessageBox.Show("Move from company and move to company cannot match.");
                return;

            }
            
            Int32 TradeCompany = 0;
            Int32 TradeYear = 0;
            Int32 TradeCount = 0;
            String Month = "";
            String ReturnMessage = "";

            if (this.cboBrokers.Text != "")
            {
                TradeCompany = Convert.ToInt32(cboBrokers.SelectedValue.ToString());
            }
            if (this.txtTradeYear.Text != "")
            {
                TradeYear = Convert.ToInt32(txtTradeYear.Text);
            }
            if (this.txtTradeMonth.Text != "")
            {
                Month = txtTradeMonth.Text;
            }
            if (this.txtNumberToMove.Text != "" )
            {
                TradeCount = Convert.ToInt32(txtNumberToMove.Text);
                
            }

            if (TradeCompany == 0 || TradeYear == 0 || Month == "")
            {
                MessageBox.Show("Trade Company, trade month and trade year need to be set to move trades.", "Move Trades");
                return;
            }

            ord.MoveTrades(Month, TradeYear, TradeCompany, TradeCount, ref ReturnMessage);
            if (ReturnMessage != "")
            {
                MessageBox.Show(ReturnMessage.ToString(), "Move Trades");
            }
            else
            {
                RefreshGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Int32 TradeCompany = 0;
            Int32 TradeYear = 0;
            String Month = "";

            if (this.cboBrokers.Text != "")
            {
                TradeCompany = Convert.ToInt32(cboBrokers.SelectedValue.ToString());
            }
            if (this.txtTradeYear.Text != "")
            {
                TradeYear = Convert.ToInt32(txtTradeYear.Text);
            }
            if (this.txtTradeMonth.Text != "")
            {
                Month = txtTradeMonth.Text;
            }

            if (TradeCompany == 0 || TradeYear == 0 || Month == "")
            {
                MessageBox.Show("Trade Company, trade month and trade year need to be set to refresh the grid.", "Move Trades");
                return;
            }
            
            RefreshGrid();
        }

        private void txtNumberToMove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        
        private void txtNumberToMove_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTradeMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                e.Handled = true;

            }
        }

        private void txtTradeYear_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTradeYear_Leave(object sender, EventArgs e)
        {
            if(txtTradeYear.Text.Length != 2)
            {
                MessageBox.Show("Two digit year is required.", "Move Trades");
                txtTradeYear.Focus();
            }
            else
            {
                if (txtTradeMonth.Text.Length == 1)
                {
                    RefreshGrid();
                }
            }
        }

        private void txtTradeMonth_Leave(object sender, EventArgs e)
        {
            if (txtTradeMonth.Text.Length != 1)
            {
                MessageBox.Show("One character month is required.", "Move Trades");
                txtTradeMonth.Focus();
            }
            else
            {
                if (txtTradeYear.Text.Length == 2)
                {
                    RefreshGrid();
                }
            }
        }

        private void txtTradeMonth_TextChanged(object sender, EventArgs e)
        {
            txtTradeMonth.Text = txtTradeMonth.Text.ToUpper();
        }

        private void txtNumberToMove_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumberToMove_Leave(object sender, EventArgs e)
        {
            if (txtNumberToMove.Text != "" && txtTradeCount.Text != "")
            {
                if (Convert.ToInt32(txtTradeCount.Text) < Convert.ToInt32(this.txtNumberToMove.Text))
                {
                    this.txtNumberToMove.Text = txtTradeCount.Text;
                }
            }
        }


       
       
    }
}
