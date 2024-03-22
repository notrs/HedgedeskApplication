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
    public partial class frmMoveTradesTradingCompanyEdit : Form
    {
        Settings settings = new Settings();
        public frmMoveTradesTradingCompanyEdit()
        {
            InitializeComponent();
            DataTable dtBrokers = new DataTable();
            settings.GetBrokers(dtBrokers);
            cboBrokers.DataSource = dtBrokers;
            cboBrokers.DisplayMember = "BrokerDescription";
            cboBrokers.ValueMember = "Company";
            cboBrokers.SelectedIndex = 1;

        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboBrokers.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a broker.", "Trading Company");
                return;
            }
            
            
            string ReturnMessage = "";
            
            int TradingCompany = Convert.ToInt32(cboBrokers.SelectedValue.ToString());
            if (!settings.UpdateMoveToCompany(TradingCompany, ref ReturnMessage))
            {
                MessageBox.Show("Error in changing Trading Company.  Please advise system administrator.");
            }
            else
            {
                MessageBox.Show("Trading Company " + TradingCompany + " has been added set.", "TradingCompany");
            }
        }

        private void frmMoveTradesTradingCompanyEdit_Load(object sender, EventArgs e)
        {

        }

        private void cboBrokers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBrokers.SelectedIndex != -1)
            {
                btnUpdate.Enabled = true;
            }
        }

        
    }
}
