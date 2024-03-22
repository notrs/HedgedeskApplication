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
    public partial class frmDeleteCommodityTradingCompanies : Form
    {
        public frmDeleteCommodityTradingCompanies()
        {
            InitializeComponent();
        }

        private void txtTradingYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtTradingCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        private void txtTradingYear_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTradingCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                e.Handled = true;

            }
            
        }

        private void txtTradingYear_TextChanged(object sender, EventArgs e)
        {

            
            if ((txtTradingYear.Text != "" && txtTradingYear.Text.Length == 2) && (txtTradingMonth.Text != ""))
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            if (txtTradingYear.Text.Length > 2)
            {
                MessageBox.Show("Please enter a two digit year.", "Commodity Trading Company");
                return;
            }
            if (txtTradingMonth.Text.Length < 1)
            {
                MessageBox.Show("Please enter a month.", "Commodity Trading Company");
                return;
            }
            if (MessageBox.Show("Delete Trading Month Year for " + txtTradingMonth.Text + txtTradingYear.Text + "?", "Hedge Order", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            Maintenance clsMaintenance = new Maintenance();
            string ReturnMessage = "";
            string TradingYear = txtTradingYear.Text;
            string TradingMonth = txtTradingMonth.Text;
            if (!clsMaintenance.DeleteCommoditiesTradingMonthYear(TradingYear, TradingMonth, ref ReturnMessage))
            {
                MessageBox.Show("Error in adding Trading Company.  Please advise system administrator.");
            }
            else
            {
                MessageBox.Show("Trading Company " + txtTradingMonth.Text + " has been removed for all commodities for " + txtTradingMonth.Text + txtTradingYear.Text + ".", "Commodity Trading Company");
            }



        }

        private void txtTradingCompany_TextChanged(object sender, EventArgs e)
        {

            txtTradingMonth.Text = txtTradingMonth.Text.ToUpper();
            if ((txtTradingYear.Text != "" && txtTradingYear.Text.Length == 2) && (txtTradingMonth.Text != ""))
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
