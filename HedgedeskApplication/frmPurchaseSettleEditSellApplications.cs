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
    public partial class frmPurchaseSettleEditSellApplications : Form
    {
        public frmPurchaseSettleInquiry frmCopyOrders;
        private PurchaseSettle clsPurchaseSettle = new PurchaseSettle();
        
        public DataTable dtSellOrder = new DataTable();
        
        public Boolean mLoading;
        public Int32 mOrderNumber;



        public frmPurchaseSettleEditSellApplications()
        {
            InitializeComponent();
        }


        private void LoadForm()
        {
            try
            {
                mLoading = true;
                
                dtSellOrder.Clear();
                
                clsPurchaseSettle.GetPurchaseSettleSellApplications(mOrderNumber.ToString(), dtSellOrder);
                this.dgvSellApplications.AutoGenerateColumns = false;
                this.dgvSellApplications.DataSource = dtSellOrder;
                if (dtSellOrder.Rows.Count > 0)
                {
                    this.txtSellContracts.Text = dtSellOrder.Rows[0]["TotalApplications"].ToString();
                }
                else
                {
                    this.txtSellContracts.Text = "0";
                }

                mLoading = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");

            }
        }


        private void frmPurchaseSettleEditApplications_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }


}


