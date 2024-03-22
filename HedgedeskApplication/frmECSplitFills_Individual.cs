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
using HedgedeskApplication.Classes;

namespace HedgedeskApplication
{
    public partial class frmECSplitFills_Individual : Form
    {
        public frmOrders frmCopyOrders;
        public DataView viewAccounts = new DataView();
        public DataView viewMonths = new DataView();
        public DataView viewCommodities = new DataView();
        public DataView viewOrdTypes = new DataView();
        public DataView viewAccountComps = new DataView();
        public DataView viewClosingPrices = new DataView();
        public DataView viewOrder = new DataView();
        //private string mQty = "";
        //private string mPrice = "";
        public Boolean mLoading;
        public Int32 mOrderNumber;
        public Int32 mOrig_Qty;
        public string mOrderType;
        public DataTable mdtECSplitOrders = new DataTable();
        public DataTable mvFillHistory = new DataTable();
        public DataTable mFutemp = new DataTable();
        public DataView dvECSplitOrders = new DataView();
        public DataView dvRemainingQuantity = new DataView();
        public string FilledPrice;
        public string mTradeCompany = "";
        public int Completed = 1;
        CRMProcessing crm = new CRMProcessing();
        DataTable ContractOrders = new DataTable();

        public frmECSplitFills_Individual()
        {
            InitializeComponent();

        }
        public Boolean LoadGrid()
        {
            this.dgvECOrders.AutoGenerateColumns = false;
            this.dgvECOrders.DataSource = dvECSplitOrders;
            this.txtTP_ORD_NUMB.Text = mOrderNumber.ToString();
            this.txtAMT.Text = mOrig_Qty.ToString();
            if (Completed == 1)
            {
                lblProcessed.Visible = true;
                btnNewSplitFill.Enabled = false;
                btnFillSelectedOriginal.Enabled = false;
                cmdFillCheckedItems.Enabled = false;

            }
            else
            {
                lblProcessed.Visible = false;
                btnNewSplitFill.Enabled = true;
                btnFillSelectedOriginal.Enabled = true;
                cmdFillCheckedItems.Enabled = true;
            }
            this.txtRemainingQty.Text = dvECSplitOrders[0]["RemainingQuantity"].ToString();
            return true;
        }

        private void dgvECOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OrdersUpdate ordUpdate = new OrdersUpdate();
            int remainingQuantity = 0;

            if (Completed == 1)
            {
                MessageBox.Show("This Split Fill has been processed.  This tab is for informational purposes only.", "Split Fills");
                return;
            }

            if (dgvECOrders.Columns[e.ColumnIndex].Name == "SFFill")
            {
               
                
                string Applied = "0";
                string ReturnMessage = "";
                string OrderSent = "0";
                string CompletedFill = "0";
                string isChecked = "0";
                //string TradeCompany = "";
                string MessageID = "0";
                //string FilledPrice = "0";
                int FillQty = 0;
                string uLastPrice = "0";
                int SelectedAmount = 0;


                if (dgvECOrders.Rows[e.RowIndex].Cells["ECApp"].Value.ToString() == "1")
                {
                    Applied = "1";
                }
                if (dgvECOrders.Rows[e.RowIndex].Cells["ECSplitOrderID"].Value.ToString() != "")
                {
                    CompletedFill = "1";
                }
                if (Applied == "1")
                {
                    MessageBox.Show("This fill has already been applied.", "Split Fill");
                    return;
                }
                else if (CompletedFill == "1")
                {
                    MessageBox.Show("This fill has been completed.", "Split Fill");
                    return;
                }
                else
                {
                    dgvECOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    DataGridViewCheckBoxCell oCell;

                    oCell = dgvECOrders.Rows[e.RowIndex].Cells["SFFill"] as DataGridViewCheckBoxCell;

                    if ((null != oCell && null != oCell.Value && true == (bool)oCell.Value))
                    {
                        isChecked = "1";
                    }
                    else
                    {
                        isChecked = "0";
                    }

                    FilledPrice = dgvECOrders.Rows[e.RowIndex].Cells["ECPrice"].Value.ToString();
                    string newCheck = isChecked;
                    //int col = 12;
                    //for (int row = 0; row < dgvECOrders.Rows.Count; row++)
                    //{
                    //    if (dgvECOrders[col, row].Value.ToString() == FilledPrice.ToString())
                    //    {
                    //        MessageID = dgvECOrders.Rows[row].Cells["MessageID"].Value.ToString();
                    //        FillQty = Convert.ToInt32(dgvECOrders.Rows[row].Cells["ECFilledQty"].Value.ToString());
                            uLastPrice = dgvECOrders.Rows[e.RowIndex].Cells["uLastPrice"].Value.ToString();
                    //        //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
                    //        if (dgvECOrders.Rows[row].Cells["ECApp"].Value.ToString() == "1" || dgvECOrders.Rows[e.RowIndex].Cells["ECSplitOrderID"].Value.ToString() != "")
                    //        {
                    //        }
                    //        else
                    //        {
                                ordUpdate.CheckSplitFillOrder(mOrderNumber, Applied, CompletedFill, ref ReturnMessage,
                                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                                uLastPrice, isChecked, ref SelectedAmount);
                        //    }


                        //    mdtECSplitOrders.Clear();
                        //    mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString()).Tables[0];
                        //    dvECSplitOrders = mdtECSplitOrders.DefaultView;
                        //    //dvECSplitOrders.RowFilter = "ClientOrderID = " + mOrderNumber.ToString();
                        //    dgvECOrders.DataSource = dvECSplitOrders;
                        //    dgvECOrders.Refresh();
                        //}
                    //}
                    txtSelectedQuantity.Text = SelectedAmount.ToString();
                    mdtECSplitOrders.Clear();
                    dvECSplitOrders = mdtECSplitOrders.DefaultView;
                    GlobalStore.mdsECSplitOrders.Clear();
                    mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString()).Tables[0];
                    dvECSplitOrders = mdtECSplitOrders.DefaultView;
                    //dvECSplitOrders.RowFilter = "ClientOrderID = " + mOrderNumber.ToString();
                    dgvECOrders.DataSource = dvECSplitOrders;
                    dgvECOrders.Refresh();


                    //MessageID = dgvECOrders.Rows[e.RowIndex].Cells["MessageID"].Value.ToString();
                    //FilledPrice = dgvECOrders.Rows[e.RowIndex].Cells["ECPrice"].Value.ToString();
                    //FillQty = Convert.ToInt32(dgvECOrders.Rows[e.RowIndex].Cells["ECFilledQty"].Value.ToString());
                    //uLastPrice = dgvECOrders.Rows[e.RowIndex].Cells["uLastPrice"].Value.ToString();
                    ////mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
                    //OrdersUpdate ordUpdate = new OrdersUpdate();
                    //ordUpdate.CheckSplitFillOrder(mOrderNumber, Applied, CompletedFill, ref ReturnMessage,
                    //    ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                    //    uLastPrice, isChecked);
                }

            }
            else if (dgvECOrders.Columns[e.ColumnIndex].Name == "CreateRecord")
            {
                string Applied = "0";
                string ReturnMessage = "";
                string OrderSent = "0";
                string CompletedFill = "0";
                string isChecked = "0";
                //string TradeCompany = "";
                string MessageID = "0";
                //string FilledPrice = "0";
                string LeavesQty = "0";
                string OriginalQty = "0";
                int FillQty = 0;
                string uLastPrice = "0";

                dgvECOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
                DataGridViewCheckBoxCell oCell;

                oCell = dgvECOrders.Rows[e.RowIndex].Cells["SFFill"] as DataGridViewCheckBoxCell;

                if ((null != oCell && null != oCell.Value && true == (bool)oCell.Value))
                {
                    isChecked = "1";
                }
                else
                {
                    isChecked = "0";
                }

                if (dgvECOrders.Rows[e.RowIndex].Cells["ECApp"].Value.ToString() == "True")
                {
                    Applied = "1";
                }
                if (dgvECOrders.Rows[e.RowIndex].Cells["ECSplitOrderID"].Value.ToString() != "")
                {
                    CompletedFill = "1";
                }


                //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
                MessageID = dgvECOrders.Rows[e.RowIndex].Cells["MessageID"].Value.ToString();
                FilledPrice = dgvECOrders.Rows[e.RowIndex].Cells["ECPrice"].Value.ToString();
                FillQty = Convert.ToInt32(dgvECOrders.Rows[e.RowIndex].Cells["ECFilledQty"].Value.ToString());
                LeavesQty = dgvECOrders.Rows[e.RowIndex].Cells["ECRemQty"].Value.ToString();
                OriginalQty = dgvECOrders.Rows[e.RowIndex].Cells["CMEQty"].Value.ToString();
                uLastPrice = dgvECOrders.Rows[e.RowIndex].Cells["uLastPrice"].Value.ToString();
                //OrdersUpdate ordUpdate = new OrdersUpdate();
                ordUpdate.AddSplitFillOrder(mOrderNumber, Applied, CompletedFill, ref ReturnMessage,
                    ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                    uLastPrice, isChecked, LeavesQty, OriginalQty, ref remainingQuantity, ContractOrders);

                if (OrderSent != "" && OrderSent != "1")
                {
                    frmCopyOrders.ShowMessage(OrderSent, ReturnMessage);
                }
                else
                {
                    if (ContractOrders.Rows.Count > 0)
                    {
                        crm.ProcessCRMSplitFill(ContractOrders);
                    }
                    this.txtRemainingQty.Text = remainingQuantity.ToString();
                    mdtECSplitOrders.Clear();
                    dvECSplitOrders = mdtECSplitOrders.DefaultView;
                    GlobalStore.mdsECSplitOrders.Clear();
                    mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString()).Tables[0];
                    dvECSplitOrders = mdtECSplitOrders.DefaultView;
                    //dvECSplitOrders.RowFilter = "ClientOrderID = " + mOrderNumber.ToString();
                    dgvECOrders.DataSource = dvECSplitOrders;
                    dgvECOrders.Refresh();
                }



            }
            else if (dgvECOrders.Columns[e.ColumnIndex].Name == "FillOriginal")
            {
                string Applied = "0";
                string ReturnMessage = "";
                string OrderSent = "0";
                string CompletedFill = "0";
                //string isChecked = "0";
                //string TradeCompany = "";
                string MessageID = "0";
                //string FilledPrice = "0";
                string LeavesQty = "0";
                string OriginalQty = "0";
                int FillQty = 0;
                string uLastPrice = "0";

                dgvECOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
                DataGridViewCheckBoxCell oCell;

                oCell = dgvECOrders.Rows[e.RowIndex].Cells["SFFill"] as DataGridViewCheckBoxCell;

                //if ((null != oCell && null != oCell.Value && true == (bool)oCell.Value))
                //{
                //    isChecked = "1";
                //}
                //else
                //{
                //    isChecked = "0";
                //}

                if (dgvECOrders.Rows[e.RowIndex].Cells["ECApp"].Value.ToString() == "True")
                {
                    Applied = "1";
                }
                if (dgvECOrders.Rows[e.RowIndex].Cells["ECSplitOrderID"].Value.ToString() != "")
                {
                    CompletedFill = "1";
                }
                //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
                MessageID = dgvECOrders.Rows[e.RowIndex].Cells["MessageID"].Value.ToString();
                FilledPrice = dgvECOrders.Rows[e.RowIndex].Cells["ECPrice"].Value.ToString();
                FillQty = Convert.ToInt32(dgvECOrders.Rows[e.RowIndex].Cells["ECFilledQty"].Value.ToString());
                LeavesQty = dgvECOrders.Rows[e.RowIndex].Cells["ECRemQty"].Value.ToString();
                OriginalQty = mOrig_Qty.ToString();
                uLastPrice = dgvECOrders.Rows[e.RowIndex].Cells["uLastPrice"].Value.ToString();
                //OrdersUpdate ordUpdate = new OrdersUpdate();
                ordUpdate.AddSplitFillOriginal(mOrderNumber, Applied, CompletedFill, ref ReturnMessage,
                    ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                    uLastPrice, "N", LeavesQty, OriginalQty, ref remainingQuantity, ContractOrders);
                if (OrderSent != "" && OrderSent != "1")
                {
                    if (OrderSent == "5")
                    {
                        if (MessageBox.Show(this, ReturnMessage.ToString(), "Split Fill", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            ordUpdate.AddSplitFillOriginal(mOrderNumber, Applied, CompletedFill, ref ReturnMessage,
                                                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                                                uLastPrice, "Y", LeavesQty, OriginalQty, ref remainingQuantity, ContractOrders);
                            if (OrderSent != "" && OrderSent != "1")
                            {
                                frmCopyOrders.ShowMessage(OrderSent, ReturnMessage);

                            }
                            else
                            {
                                if (ContractOrders.Rows.Count > 0)
                                {
                                    crm.ProcessCRMSplitFill(ContractOrders);
                                }
                                MessageBox.Show(this, "Original Filled", "Split Fill");
                                frmCopyOrders.RefreshOrderGrid();
                                this.txtRemainingQty.Text = remainingQuantity.ToString();
                                mdtECSplitOrders.Clear();
                                dvECSplitOrders = mdtECSplitOrders.DefaultView;
                                mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString()).Tables[0];
                                dvECSplitOrders = mdtECSplitOrders.DefaultView;
                                //dvECSplitOrders.RowFilter = "ClientOrderID = " + mOrderNumber.ToString();
                                dgvECOrders.DataSource = dvECSplitOrders;
                                dgvECOrders.Refresh();
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {

                        frmCopyOrders.ShowMessage(OrderSent, ReturnMessage);
                    }
                }
                else
                {
                    if (ContractOrders.Rows.Count > 0)
                    {
                        crm.ProcessCRMSplitFill(ContractOrders);
                    }
                    //MessageBox.Show(this, "Fill Completed", "Split Fill");
                    frmCopyOrders.RefreshOrderGrid();
                    this.txtRemainingQty.Text = remainingQuantity.ToString();
                    mdtECSplitOrders.Clear();
                    mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString()).Tables[0];
                    dvECSplitOrders = mdtECSplitOrders.DefaultView;
                    //                   dvECSplitOrders.RowFilter = "ClientOrderID = " + mOrderNumber.ToString();
                    dgvECOrders.DataSource = dvECSplitOrders;
                    dgvECOrders.Refresh();
                }

            }
        }


        private void frmSplitFills_Load(object sender, EventArgs e)
        {
            mLoading = true;
            this.dgvECOrders.AutoGenerateColumns = false;
            this.dgvECOrders.DataSource = dvECSplitOrders;
            this.txtTP_ORD_NUMB.Text = mOrderNumber.ToString();
            this.txtAMT.Text = mOrig_Qty.ToString();
            //return true;
            //mdtECSplitOrders.Clear();
            //GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString());
            //mdtECSplitOrders = GlobalStore.mdsECSplitOrders.Tables[0];
            //dvECSplitOrders = mdtECSplitOrders.DefaultView;
            //this.dgvECOrders.DataSource = dvECSplitOrders;
            //this.txtTP_ORD_NUMB.Text = mOrderNumber.ToString();
            //this.txtAMT.Text = mOrig_Qty.ToString();


        }

        private void dgvECOrders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvECOrders.Columns[e.ColumnIndex].Name == "SFFill")
            {
                //    string Applied = "0";
                //    string ReturnMessage = "";
                //    int OrderSent = 0;
                //    string CompletedFill = "0";
                //    string isChecked = "0";
                //    string TradeCompany = "";
                //    string MessageID = "0";
                //    string FilledPrice = "0";
                //    int FillQty = 0;
                //    string uLastPrice = "0";

                //    if (dgvECOrders.Rows[e.RowIndex].Cells["SFFill"].Value.ToString() == "True")
                //    {
                //        isChecked = "1";
                //    }
                //    if (dgvECOrders.Rows[e.RowIndex].Cells["ECApp"].Value.ToString() == "True")
                //    {
                //        Applied = "1";
                //    }
                //    if (dgvECOrders.Rows[e.RowIndex].Cells["ECSplitOrderID"].Value.ToString() != "")
                //    {
                //        CompletedFill = "1";
                //    }
                //    TradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
                //    MessageID = dgvECOrders.Rows[e.RowIndex].Cells["MessageID"].Value.ToString();
                //    FilledPrice = dgvECOrders.Rows[e.RowIndex].Cells["ECPrice"].Value.ToString();
                //    FillQty = Convert.ToInt32(dgvECOrders.Rows[e.RowIndex].Cells["ECFilledQty"].Value.ToString());
                //    uLastPrice = dgvECOrders.Rows[e.RowIndex].Cells["uLastPrice"].Value.ToString();
                //    OrdersUpdate ordUpdate = new OrdersUpdate();
                //    ordUpdate.CheckSplitFillOrder(mOrderNumber, Applied, CompletedFill, ref ReturnMessage,
                //        ref OrderSent, TradeCompany, MessageID, FilledPrice, FillQty,
                //        uLastPrice, isChecked);
            }
        }

        private void cmdFillCheckedItems_Click(object sender, EventArgs e)
        {
            //string Applied = "0";
            string ReturnMessage = "";
            string OrderSent = "0";
            //string CompletedFill = "0";
            //string isChecked = "0";
            //string TradeCompany = "";
            int MessageID = 0;
            //string FilledPrice = "0";
            //string LeavesQty = "0";
            //string OriginalQty = "0";
            int FillQty = 0;
            string uLastPrice = "0";
            int remainingQuantity = 0;

            dgvECOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //DataGridViewCheckBoxCell oCell;

            OrdersUpdate ordUpdate = new OrdersUpdate();
            for (int row = 0; row < dgvECOrders.Rows.Count; row++)
            {
                if (dgvECOrders.Rows[row].Cells["SFFill"].Value.ToString() == "True")
                {
                    MessageID = Convert.ToInt32(dgvECOrders.Rows[row].Cells["MessageID"].Value.ToString());
                    FillQty = Convert.ToInt32(dgvECOrders.Rows[row].Cells["ECFilledQty"].Value.ToString());
                    uLastPrice = dgvECOrders.Rows[row].Cells["uLastPrice"].Value.ToString();
                }
            }
            //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
            ordUpdate.AddMultipleSplitFillOrder(mOrderNumber, ref ReturnMessage,
                ref OrderSent, mTradeCompany, FilledPrice, mOrig_Qty.ToString(), MessageID, "N", ref remainingQuantity, ContractOrders);
            if (OrderSent != "" && OrderSent != "1")
            {
                if (OrderSent == "5")
                {
                    if (MessageBox.Show(this, ReturnMessage.ToString(), "Split Fill", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        ordUpdate.AddMultipleSplitFillOrder(mOrderNumber, ref ReturnMessage,
                            ref OrderSent, mTradeCompany, FilledPrice, mOrig_Qty.ToString(), MessageID, "Y", ref remainingQuantity, ContractOrders);

                        if (OrderSent != "" && OrderSent != "1")
                        {
                            frmCopyOrders.ShowMessage(OrderSent, ReturnMessage);

                        }
                        else
                        {
                            if (ContractOrders.Rows.Count > 0)
                            {
                                crm.ProcessCRMSplitFill(ContractOrders);
                            }
                            //MessageBox.Show(this, "Fill Completed", "Split Fill");
                            frmCopyOrders.RefreshOrderGrid();
                            this.txtRemainingQty.Text = remainingQuantity.ToString();
                            mdtECSplitOrders.Clear();
                            dvECSplitOrders = mdtECSplitOrders.DefaultView;
                            GlobalStore.mdsECSplitOrders.Clear();
                            mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString()).Tables[0];
                            dvECSplitOrders = mdtECSplitOrders.DefaultView;
                            //dvECSplitOrders.RowFilter = "ClientOrderID = " + mOrderNumber.ToString();
                            dgvECOrders.DataSource = dvECSplitOrders;
                            dgvECOrders.Refresh();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {

                    frmCopyOrders.ShowMessage(OrderSent, ReturnMessage);
                }
            }
            else
            {
                if (ContractOrders.Rows.Count > 0)
                {
                    crm.ProcessCRMSplitFill(ContractOrders);
                }
                //MessageBox.Show(this, "Fill Completed", "Split Fill");
                frmCopyOrders.RefreshOrderGrid();
                this.txtRemainingQty.Text = remainingQuantity.ToString();
                mdtECSplitOrders.Clear();
                dvECSplitOrders = mdtECSplitOrders.DefaultView;
                GlobalStore.mdsECSplitOrders.Clear();
                mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString()).Tables[0];
                dvECSplitOrders = mdtECSplitOrders.DefaultView;
                //dvECSplitOrders.RowFilter = "ClientOrderID = " + mOrderNumber.ToString();
                dgvECOrders.DataSource = dvECSplitOrders;
                dgvECOrders.Refresh();
            }

        }

        private void cmdDeSelect_Click(object sender, EventArgs e)
        {

            string MessageID;
            Int32 FillQty;
            string uLastPrice;
            string Applied = "0";
            string CompletedFill = "0";
            string ReturnMessage = "";
            string OrderSent = "";
            string isChecked = "0";
            int SelectedQuantity = 0;
            //int col = 1;
            OrdersUpdate ordUpdate = new OrdersUpdate();

            for (int row = 0; row < dgvECOrders.Rows.Count; row++)
            {
                MessageID = dgvECOrders.Rows[row].Cells["MessageID"].Value.ToString();
                FillQty = Convert.ToInt32(dgvECOrders.Rows[row].Cells["ECFilledQty"].Value.ToString());
                uLastPrice = dgvECOrders.Rows[row].Cells["uLastPrice"].Value.ToString();
                //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();

                ordUpdate.CheckSplitFillOrder(mOrderNumber, Applied, CompletedFill, ref ReturnMessage,
                ref OrderSent, mTradeCompany, MessageID, FilledPrice, FillQty,
                uLastPrice, isChecked, ref SelectedQuantity);

                this.txtSelectedQuantity.Text = SelectedQuantity.ToString();
                mdtECSplitOrders.Clear();
                dvECSplitOrders = mdtECSplitOrders.DefaultView;
                GlobalStore.mdsECSplitOrders.Clear();
                mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString()).Tables[0];
                dvECSplitOrders = mdtECSplitOrders.DefaultView;
                //dvECSplitOrders.RowFilter = "ClientOrderID = " + mOrderNumber.ToString();
                dgvECOrders.DataSource = dvECSplitOrders;
                dgvECOrders.Refresh();
            }
        }

        private void btnFillSelectedOriginal_Click(object sender, EventArgs e)
        {
            //string Applied = "0";
            string ReturnMessage = "";
            string OrderSent = "0";
            //string CompletedFill = "0";
            //string isChecked = "0";
            //string TradeCompany = "";
            int MessageID = 0;
            //string FilledPrice = "0";
            //string LeavesQty = "0";
            //string OriginalQty = "0";
            int FillQty = 0;
            string uLastPrice = "0";
            int RemainingQuantity = 0;

            dgvECOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //DataGridViewCheckBoxCell oCell;

            OrdersUpdate ordUpdate = new OrdersUpdate();
            for (int row = 0; row < dgvECOrders.Rows.Count; row++)
            {
                if (dgvECOrders.Rows[row].Cells["SFFill"].Value.ToString() == "True")
                {
                    MessageID = Convert.ToInt32(dgvECOrders.Rows[row].Cells["MessageID"].Value.ToString());
                    FillQty = Convert.ToInt32(dgvECOrders.Rows[row].Cells["ECFilledQty"].Value.ToString());
                    uLastPrice = dgvECOrders.Rows[row].Cells["uLastPrice"].Value.ToString();
                }
            }
            //mTradeCompany = dgvECOrders.Rows[e.RowIndex].Cells["TradeCompany"].Value.ToString();
            ordUpdate.AddMultipleSplitFillOriginal(mOrderNumber, ref ReturnMessage,
                ref OrderSent, mTradeCompany, FilledPrice, mOrig_Qty.ToString(), MessageID, "N", ref RemainingQuantity, ContractOrders);
            if (OrderSent != "" && OrderSent != "1")
            {
                if (OrderSent == "5")
                {
                    if (MessageBox.Show(this, ReturnMessage.ToString(), "Split Fill", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        ordUpdate.AddMultipleSplitFillOriginal(mOrderNumber, ref ReturnMessage,
                            ref OrderSent, mTradeCompany, FilledPrice, mOrig_Qty.ToString(), MessageID, "Y", ref RemainingQuantity, ContractOrders);

                        if (OrderSent != "" && OrderSent != "1")
                        {
                            frmCopyOrders.ShowMessage(OrderSent, ReturnMessage);

                        }
                        else
                        {
                            if (ContractOrders.Rows.Count > 0)
                            {
                                crm.ProcessCRMSplitFill(ContractOrders);
                            }
                            //MessageBox.Show(this, "Fill Completed", "Split Fill");
                            frmCopyOrders.RefreshOrderGrid();
                            this.txtRemainingQty.Text = RemainingQuantity.ToString();
                            mdtECSplitOrders.Clear();
                            dvECSplitOrders = mdtECSplitOrders.DefaultView;
                            GlobalStore.mdsECSplitOrders.Clear();
                            mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString()).Tables[0];
                            dvECSplitOrders = mdtECSplitOrders.DefaultView;
                            //dvECSplitOrders.RowFilter = "ClientOrderID = " + mOrderNumber.ToString();
                            dgvECOrders.DataSource = dvECSplitOrders;
                            dgvECOrders.Refresh();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {

                    frmCopyOrders.ShowMessage(OrderSent, ReturnMessage);
                }
            }
            else
            {
                if (ContractOrders.Rows.Count > 0)
                {
                    crm.ProcessCRMSplitFill(ContractOrders);
                }
                //MessageBox.Show(this, "Fill Completed", "Split Fill");
                frmCopyOrders.RefreshOrderGrid();
                this.txtRemainingQty.Text = RemainingQuantity.ToString();
                mdtECSplitOrders.Clear();
                dvECSplitOrders = mdtECSplitOrders.DefaultView;
                GlobalStore.mdsECSplitOrders.Clear();
                mdtECSplitOrders = GlobalStore.FillECSplitOrdersDataSet(mOrderNumber.ToString()).Tables[0];
                dvECSplitOrders = mdtECSplitOrders.DefaultView;
                //dvECSplitOrders.RowFilter = "ClientOrderID = " + mOrderNumber.ToString();
                dgvECOrders.DataSource = dvECSplitOrders;
                dgvECOrders.Refresh();
            }
        }

        private void cmdSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                //Microsoft.Office.Interop.Outlook.Application MSO = new Microsoft.Office.Interop.Outlook.Application();
                //Microsoft.Office.Interop.Outlook.MailItem msg;
                //msg = (Microsoft.Office.Interop.Outlook.MailItem)MSO.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                //msg.Subject = "Split Fill for Order " + mOrderNumber.ToString();
                //StreamWriter sw = new StreamWriter("file.html", true, Encoding.UTF8);//creating html file
                //sw.Write(htmlMessageBody(dgvECOrders).ToString());//write datagridview contents to HTML file
                //sw.Close();
                //String body = "";
                //body = htmlMessageBody(dgvECOrders).ToString();
                //msg.Display(true);
                //msg = null;
                //MSO = null;
                //create message with datagridview contents in attachment
                //MailMessage myMessage = new MailMessage();
                //MailAddress frommail = new MailAddress("MyDomain");
                //SmtpClient client = new SmtpClient();
                //try
                //{
                //    MailAddress tomail = new MailAddress("MyDomain");
                //    myMessage.From = frommail; //"from@yourDomain.com".ToString();//place here from address
                //    myMessage.To.Add(tomail); // MailAddress("MyDomain"); //"to@recipientsDomain";//place here to address
                //    //myMessage.Cc = "cc@someDomain.com";//place here copy address
                //    myMessage.BodyEncoding = Encoding.UTF8;
                //    myMessage.IsBodyHtml = true;
                //    myMessage.Body = "some body text";//place here some text
                //    myMessage.Subject = "message subject";//place here your subject
                //    //creating attachment
                //    StreamWriter sw = new StreamWriter("file.html", true, Encoding.UTF8);//creating html file
                //    sw.Write(htmlMessageBody(dgvECOrders).ToString());//write datagridview contents to HTML file
                //    sw.Close();
                //    Attachment myAttach = new Attachment("file.html");//create attachment
                //    myMessage.Attachments.Add(myAttach);//add attachment to our message

                //    //if it is needed set up credentials
                //    //myMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");//Basic Authentication
                //    //myMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "userName");//user name
                //    //myMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "password");//password
                //    //client.SmtpServer = "your SMTP server";//place here SMTP server
                //    client.Send(myMessage);
                //    MessageBox.Show("Message sent!");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private StringBuilder htmlMessageBody(DataGridView dg)
        {
            StringBuilder strB = new StringBuilder();
            //create html & table
            strB.AppendLine("<html><body><center><" +
                            "table border='1' cellpadding='0' cellspacing='0'>");
            strB.AppendLine("<tr>");
            //cteate table header
            for (int i = 0; i < dg.Columns.Count; i++)
            {
                strB.AppendLine("<td align='center' valign='middle'>" +
                                dg.Columns[i].HeaderText + "</td>");
            }
            //create table body
            strB.AppendLine("<tr>");
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                strB.AppendLine("<tr>");
                foreach (DataGridViewCell dgvc in dg.Rows[i].Cells)
                {
                    strB.AppendLine("<td align='center' valign='middle'>" +
                                    dgvc.Value.ToString() + "</td>");
                }
                strB.AppendLine("</tr>");

            }
            //table footer & end of html file
            strB.AppendLine("</table></center></body></html>");
            return strB;

        }

        private void frmECSplitFills_Individual_FormClosing(object sender, FormClosingEventArgs e)
        {
                frmCopyOrders.dtECSplitOrders.Clear();
                GlobalStore.mdsECSplitOrders.Clear();
                frmCopyOrders.dtECSplitOrders = GlobalStore.FillSplitFillOrdersDataSet().Tables[0];
                //frmSplit.Dispose();
                //frmSplit.frmCopyOrders.Dispose();
                //dgvOrders.DataSource = null;

        }

        private void btnNewSplitFill_Click(object sender, EventArgs e)
        {
            OrdersUpdate ordUpdate = new OrdersUpdate();
            DataTable Orders = new DataTable();
            String ReturnMessage = "";
            if (mOrderType == "SPR")
            {
                
                ordUpdate.ProcessSplitFillSpread(mOrderNumber, ref ReturnMessage);
                
            }
            else
            {
                ordUpdate.ProcessSplitFill(mOrderNumber, ref ReturnMessage, Orders);
            }
        }

        // Create a message with datagridview contents
        // in its body and set up the recipients.

    }

}
