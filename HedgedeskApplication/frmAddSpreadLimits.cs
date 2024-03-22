using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HedgedeskApplication
{
    public partial class frmAddSpreadLimits : Form
    {
        public frmAddSpreadLimits()
        {
            InitializeComponent();
            cboAccount.DataSource = GlobalStore.mdtAccounts.Copy();
            cboAccount.DisplayMember = "TP_ACCT";
            cboAccount.ValueMember = "TP_ACCT";
        }

        private void txtSpreadLimit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtCommodityID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
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
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
        }

        private void txtSpreadLimit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTradingYear_TextChanged(object sender, EventArgs e)
        {
            if ((txtCommodityID.Text != "" && cboAccount.Text != "") && (txtSpreadLimit.Text != ""))
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            if (cboAccount.Text.Length == 0)
            {
                MessageBox.Show("Please choose an account.", "Spread Limits");
                return;
            }
            if (txtSpreadLimit.Text.Length == 0)
            {
                MessageBox.Show("Please enter Spread Limit.", "Spread Limits");
                return;
            }
            if (txtCommodityID.Text.Length == 0)
            {
                MessageBox.Show("Please enter Commodity.", "Spread Limits");
                return;
            }
            Maintenance clsMaintenance = new Maintenance();
            string ReturnMessage = "";
            int Account = Convert.ToInt32(cboAccount.Text);
            int SpreadLimit = Convert.ToInt32(txtSpreadLimit.Text);
            int CommodityID = Convert.ToInt32(txtCommodityID.Text);
            if (!clsMaintenance.AddSpreadLimitForAccount(CommodityID, Account, SpreadLimit, ref ReturnMessage))
            {
                MessageBox.Show("Error in adding Trading Company.  Please advise system administrator.");
            }
            else
            {
                if (ReturnMessage != "")
                {
                    MessageBox.Show(this, ReturnMessage, "Spread Limit" );
                }
                else
                {
                    txtSpreadLimit.Text = "";
                    txtCommodityID.Text = "";
                }

            }
            



        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSpreadLimit_TextChanged(object sender, EventArgs e)
        {
            if ((txtSpreadLimit.Text != "" && txtSpreadLimit.Text.Length < 4) && (txtSpreadLimit.Text != ""))
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }
    }
}
