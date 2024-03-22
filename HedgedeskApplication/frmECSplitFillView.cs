using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

//using System.Web.Mail;
using System.IO;

namespace HedgedeskApplication
{
    public partial class frmECSplitFillView : Form
    {
        public Boolean mLoading;
        public Int32 mOrderNumber;
        public DataTable mdtECSplitOrders = new DataTable();
        public DataView dvECSplitOrders = new DataView();
        public String mOrderType;
        public int Completed = 1;

        public frmECSplitFillView()
        {
            InitializeComponent();

        }
        public Boolean LoadGrid()
        {
            OrdersUpdate ordUpdate = new OrdersUpdate();
            String ReturnMessage = "";
            mdtECSplitOrders.Clear();
            ordUpdate.SplitFillFetch(mOrderNumber, ref ReturnMessage, mdtECSplitOrders);
            if (Completed == 1)
            {
                lblProcessed.Visible = true;
                btnNewSplitFill.Enabled = false;

            }
            else
            {
                lblProcessed.Visible = false;
                btnNewSplitFill.Enabled = true;
            }

            this.dgvECOrders.AutoGenerateColumns = false;
            this.dgvECOrders.DataSource = mdtECSplitOrders.DefaultView;
            this.txtTP_ORD_NUMB.Text = mOrderNumber.ToString();
            return true;
        }

        
        private void frmSplitFills_Load(object sender, EventArgs e)
        {
           

        }

         
        private void btnNewSplitFill_Click(object sender, EventArgs e)
        {
            OrdersUpdate ordUpdate = new OrdersUpdate();
            String ReturnMessage = "";
            DataTable ContractOrders = new DataTable();
            if (mOrderType == "SPR")
            {
                
                ordUpdate.ProcessSplitFillSpread(mOrderNumber, ref ReturnMessage);
                
            }
            else
            {
                ordUpdate.ProcessSplitFill(mOrderNumber, ref ReturnMessage, ContractOrders);
            }
            if (!LoadGrid())
            {
                MessageBox.Show("Error reloading form");
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }


    }

}
