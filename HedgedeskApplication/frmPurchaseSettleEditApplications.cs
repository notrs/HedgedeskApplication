﻿using System;
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
    public partial class frmPurchaseSettleEditApplications : Form
    {
        public frmPurchaseSettleInquiry frmCopyOrders;
        private PurchaseSettle clsPurchaseSettle = new PurchaseSettle();
        
        public DataTable dtBuyOrder = new DataTable();
        
        public Boolean mLoading;
        public Int32 mOrderNumber;



        public frmPurchaseSettleEditApplications()
        {
            InitializeComponent();
        }


        private void LoadForm()
        {
            try
            {
                mLoading = true;
                
                dtBuyOrder.Clear();
                
                clsPurchaseSettle.GetPurchaseSettleBuyApplications(mOrderNumber.ToString(), dtBuyOrder);
                this.dgvBuyApplications.AutoGenerateColumns = false;
                this.dgvBuyApplications.DataSource = dtBuyOrder;
                if (dtBuyOrder.Rows.Count > 0)
                {
                    this.txtBuyContracts.Text = dtBuyOrder.Rows[0]["TotalApplications"].ToString();
                }
                else
                {
                    this.txtBuyContracts.Text = "0";
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


