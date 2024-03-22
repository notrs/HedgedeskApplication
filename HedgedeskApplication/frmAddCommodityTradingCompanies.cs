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
    public partial class frmAddCommodityTradingCompanies : Form
    {
        public frmAddCommodityTradingCompanies()
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
            if ((txtTradingYear.Text != "" && txtTradingYear.Text.Length == 2) && (txtTradingCompany.Text != ""))
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
           
            if (txtTradingYear.Text.Length > 2)
            {
                MessageBox.Show("Please enter a two digit year.", "Commodity Trading Company");
                return;
            }
            if (txtTradingCompany.Text.Length < 2)
            {
                MessageBox.Show("Please enter a Trading Company.", "Commodity Trading Company");
                return;
            }
            Maintenance clsMaintenance = new Maintenance();
            string ReturnMessage = "";
            int TradingYear = Convert.ToInt32(txtTradingYear.Text);
            int TradingCompany = Convert.ToInt32(txtTradingCompany.Text);
            if (!clsMaintenance.AddCommodityTradingCompanyForYear(TradingYear, TradingCompany, ref ReturnMessage))
            {
                MessageBox.Show("Error in adding Trading Company.  Please advise system administrator.");
            }
            else
            {
                MessageBox.Show("Trading Company " + txtTradingCompany.Text + " has been added for all commodities for " + txtTradingYear.Text + ".", "Commodity Trading Company");
            }



        }

        private void txtTradingCompany_TextChanged(object sender, EventArgs e)
        {
            if ((txtTradingYear.Text != "" && txtTradingYear.Text.Length == 2) && (txtTradingCompany.Text != ""))
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
