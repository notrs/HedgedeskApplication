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
    public partial class frmOrderFills : Form
    { 
        DataTable dtOrders = new DataTable();
        Maintenance clsMaintenance = new Maintenance();
        int mColumnIndex;
        int mRowIndex;
        Boolean isNotValidated = false;
        Boolean isRowChanged = false;
        public frmOrderFills()
        {
            InitializeComponent();
        }
          
        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void frmOrderFills_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
         
        private void LoadForm()
        {
            //int inActive = 0;
            clsMaintenance.GetOrdersForFill(dtOrders);
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = dtOrders;


        }

        private void dgvOrders_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvOrders.CurrentCell.ColumnIndex;
                mRowIndex = dgvOrders.CurrentCell.RowIndex;
            }
            isRowChanged = true;

        }

        private void dgvOrders_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvOrders_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (isRowChanged)
            {
                try
                {
                    dgvOrders.EndEdit();
                    string rIndex = dgvOrders.Rows[e.RowIndex].Index.ToString();
                    int riIndex = Convert.ToInt16(rIndex);
                    int OrderID = 0;
                    decimal FillPrice = 0;
                    string ReturnMessage = "";

                    OrderID = Convert.ToInt32(dgvOrders.Rows[riIndex].Cells["OrderNumber"].Value.ToString());
                    FillPrice = Convert.ToDecimal(dgvOrders.Rows[riIndex].Cells["FilledPrice"].Value.ToString());


                    if (!clsMaintenance.UpdateOpenOrder(OrderID, FillPrice, ref ReturnMessage))
                    {
                        MessageBox.Show(ReturnMessage, "Order Maintenance");
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                    else
                    { 
                        dtOrders.Clear();
                        clsMaintenance.GetOrdersForFill(dtOrders);
                        dgvOrders.DataSource = dtOrders;
                        isRowChanged = false;
                        isNotValidated = false;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Order Maintenance");
                    isRowChanged = false;
                    isNotValidated = false;
                }
            }
        }

        private void dgvOrders_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvOrders.EndEdit();
                isRowChanged = false;
            }
        }

        

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == tpCommodity)
            //{
            //    MessageBox.Show("Currently in testing", "Hedgedesk");
            //    tabControl1.SelectedTab = tabPage2;

            //}
        }


    }
            
}



