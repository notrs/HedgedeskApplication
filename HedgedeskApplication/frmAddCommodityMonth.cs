using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;

namespace HedgedeskApplication
{
    public partial class frmAddCommodityMonth : Form
    {
        public int mCommodityID;

        public frmAddCommodityMonth()
        {
            InitializeComponent();
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            
            if (txtTradingMonth.Text.Length < 1)
            {
                MessageBox.Show("Please enter a month.", "Commodity Trading Company");
                return;
            }
            string CurrentUser = WindowsIdentity.GetCurrent().Name;

            Maintenance clsMaintenance = new Maintenance();
            string ReturnMessage = "";
            string TradingMonth = txtTradingMonth.Text;
            if (!clsMaintenance.AddCommodityMonth(TradingMonth, mCommodityID, CurrentUser, ref ReturnMessage))
            {
                MessageBox.Show("Error in adding Month.  Please advise system administrator.");
            }
            else
            {
                txtTradingMonth.Text = "";
                
            }



        }

        private void txtTradingCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{TAB}");
            }
        }

        
        private void txtTradingCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                e.Handled = true;

            }

        }


        private void txtTradingCompany_TextChanged(object sender, EventArgs e)
        {

            txtTradingMonth.Text = txtTradingMonth.Text.ToUpper();
            if (txtTradingMonth.Text != "")
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
