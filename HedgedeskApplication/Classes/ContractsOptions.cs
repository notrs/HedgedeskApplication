using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms.VisualStyles;

namespace HedgedeskApplication.Classes
{
    static class ContractOptions
    {

        public static bool UpdateAcceptedOrCancelledColumns(DataGridViewCellEventArgs e, dgvCustom dgvContractOptions)
        {
            if (dgvContractOptions.Columns[e.ColumnIndex].Name == "Accepted")
            {
                if ((dgvContractOptions.Rows[e.RowIndex].Cells["Accepted"].Value.ToString() == "0") && (dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionStatus"].Value.ToString() == "Pending"))
                {
                    ContractsOptionsData.SetOptionStatusAccepted(Convert.ToInt32(dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionID"].Value.ToString()), 0);
                }
                else if ((dgvContractOptions.Rows[e.RowIndex].Cells["Accepted"].Value.ToString() == "1") && (dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionStatus"].Value.ToString() != "Cancelled")
                    && (dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionStatus"].Value.ToString() != "Executed") && (dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionStatus"].Value.ToString() != "Pending Cancelled"))
                {
                    DialogResult dr = MessageBox.Show("Do you want to change the status to Pending?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        ContractsOptionsData.SetOptionStatusAccepted(Convert.ToInt32(dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionID"].Value.ToString()), 1);
                    }
                }
                return true;
            }
            if (dgvContractOptions.Columns[e.ColumnIndex].Name == "Cancelled")
            {

                if ((dgvContractOptions.Rows[e.RowIndex].Cells["Cancelled"].Value.ToString() == "0") &&
                    ((dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionStatus"].Value.ToString() == "Pending") ||
                    (dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionStatus"].Value.ToString() == "Working") ||
                    (dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionStatus"].Value.ToString() == "Pending Cancelled")))
                {
                    DialogResult dr = MessageBox.Show("Do you want to change the status to Cancelled?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        int contractOptionID = Convert.ToInt32(dgvContractOptions.Rows[e.RowIndex].Cells["ContractOptionID"].Value.ToString());
                        ContractsOptionsData.SetOptionStatusCancelled(contractOptionID);
                        ContractsOptionsData.OptionEmail(contractOptionID, "Cancelled");
                    }

                }
                else
                {
                    MessageBox.Show("The order has a fill and cannot be cancelled.");
                }
                return true;
            }
            return false;
        }

        public static bool SaveChanges(DataGridViewCellEventArgs e, dgvCustom dgv, string originalExecutedPremium, string originalContractOptionFuturesPrice,
                string originalContractOptionOrderNumber, string originalContractOptionOrderDateTime, string originalContractOptionAssignedQuantity,
                string originalContractOptionAssignmentDate, string originalContractOptionExpirationDate, string originalContractOptionSoldPremium,
                string originalContractOptionCardNumber)
        {
            try
            {
                string appendedName = "";
                if (dgv.Name == "dgvContractOptionsNotWorking")
                {
                    appendedName = "NotWorking";
                }

                dgv.EndEdit();
                string rIndex = dgv.Rows[e.RowIndex].Index.ToString();
                int riIndex = Convert.ToInt16(rIndex);

                int contractOptionID = Convert.ToInt32(dgv["ContractOptionID" + appendedName, riIndex].Value.ToString());

                //Expiration Date changes
                if (originalContractOptionExpirationDate != dgv["ExpirationDate" + appendedName, riIndex].Value.ToString())
                {
                    DateTime expirationDate;
                    if (DateTime.TryParse(dgv["ExpirationDate" + appendedName, riIndex].Value.ToString(), out expirationDate))
                    {

                        ContractsOptionsData.SetOptionExpirationDate(contractOptionID, expirationDate);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Expiration Date is not in a correct format.", "Hedgebook");
                    }
                }
                //Executed Premium changed
                if (originalExecutedPremium != dgv["ExecutedPremium" + appendedName, riIndex].Value.ToString())
                {
                    return SaveExecutedPremiumRules(dgv, appendedName, riIndex, contractOptionID);
                }
                //Futures Price changed                    
                if (originalContractOptionFuturesPrice != dgv["OptionsFuturesPrice" + appendedName, riIndex].Value.ToString())
                {

                    DialogResult dr = MessageBox.Show("Do you want to set the futures for this option?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        decimal futuresPrice;
                        if (Decimal.TryParse(dgv["OptionsFuturesPrice" + appendedName, riIndex].Value.ToString(), out futuresPrice))
                        {
                            ContractsOptionsData.UpdateContractDetailFuturesPrice(contractOptionID, futuresPrice);
                            ContractsOptionsData.OptionEmail(contractOptionID, "FuturesSet");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Futures Price is not in a correct format.", "Hedgebook");
                        }
                    }
                }
                //Order Number changed
                if (originalContractOptionOrderNumber != dgv["OrderNo" + appendedName, riIndex].Value.ToString())
                {
                    int orderNumber;
                    if (int.TryParse(dgv["OrderNo" + appendedName, riIndex].Value.ToString(), out orderNumber))
                    {
                        ContractsOptionsData.UpdateContractDetailOrderNumber(contractOptionID, orderNumber);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Order Number is not in a correct format.", "Hedgebook");
                    }
                }
                //Order Date Time changed
                if (originalContractOptionOrderDateTime != dgv["OrderDateTime" + appendedName, riIndex].Value.ToString())
                {
                    DateTime orderDateTime;
                    if (DateTime.TryParse(dgv["OrderDateTime" + appendedName, riIndex].Value.ToString(), out orderDateTime))
                    {
                        ContractsOptionsData.UpdateContractDetailOrderDateTime(contractOptionID, orderDateTime);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Original Order Date Time is not in a correct format.", "Hedgebook");
                    }
                }
                //Assigned Qty changed
                if (originalContractOptionAssignedQuantity != dgv["AssignedQuantity" + appendedName, riIndex].Value.ToString())
                {
                    int assignedQuantity;
                    int originalAssignedQuantity = Convert.ToInt16(originalContractOptionAssignedQuantity);
                    int optionQuantity = Convert.ToInt16(Convert.ToDecimal(dgv["ContractOptionQuantity" + appendedName, riIndex].Value.ToString()));

                    if (int.TryParse(dgv["AssignedQuantity" + appendedName, riIndex].Value.ToString(), out assignedQuantity) && (assignedQuantity >= 0))
                    {
                        if (assignedQuantity <= (originalAssignedQuantity + optionQuantity))
                        {
                            ContractsOptionsData.UpdateContractDetailAssignedQuantity(contractOptionID, assignedQuantity);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Exceeded assigned quantity limit.\nMaximum: " + (originalAssignedQuantity + optionQuantity).ToString(), "Hedgebook");
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Assigned Quantity is not in a correct format.", "Hedgebook");
                    }
                }
                //Assignment Date changed
                if (originalContractOptionAssignmentDate != dgv["AssignmentDate" + appendedName, riIndex].Value.ToString())
                {
                    DateTime assignmentDate;
                    if (DateTime.TryParse(dgv["AssignmentDate" + appendedName, riIndex].Value.ToString(), out assignmentDate))
                    {
                        ContractsOptionsData.UpdateContractDetailAssignmentDate(contractOptionID, assignmentDate);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Assignment Date is not in a correct format.", "Hedgebook");
                    }
                }
                //Sold Premium changed
                if (originalContractOptionSoldPremium != dgv["SoldPremium" + appendedName, riIndex].Value.ToString())
                {

                    DialogResult dr = MessageBox.Show("Do you want to sell this option?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        decimal soldPremium;
                        decimal exitPremium;
                        string tempSoldPremium = String.IsNullOrEmpty(dgv["SoldPremium" + appendedName, riIndex].Value.ToString()) ? "0" : dgv["SoldPremium" + appendedName, riIndex].Value.ToString();
                        string tempExitPremium = String.IsNullOrEmpty(dgv["FillPremium" + appendedName, riIndex].Value.ToString()) ? "0" : dgv["FillPremium" + appendedName, riIndex].Value.ToString();
                        if (Decimal.TryParse(tempSoldPremium, out soldPremium) &&
                            Decimal.TryParse(tempExitPremium, out exitPremium))
                        {
                            bool saveSoldPremium = true;
                            //If sold less than exit
                            if (soldPremium < exitPremium)
                            {
                                DialogResult drPremiumCheck = MessageBox.Show("Premium is lower than requested.  \nAre you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (drPremiumCheck != DialogResult.Yes)
                                {
                                    saveSoldPremium = false;
                                }
                            }
                            if (saveSoldPremium)
                            {
                                string returnMessage = "";
                                ContractsOptionsData.UpdateContractDetailSoldPremium(contractOptionID, soldPremium, out returnMessage);
                                ContractsOptionsData.OptionEmail(contractOptionID, "SoldPremium");

                                if ((returnMessage != null) && (returnMessage != ""))
                                {
                                    MessageBox.Show(returnMessage, "Hedgebook");
                                }
                            }

                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Sold Premium is not in a correct format.", "Hedgebook");
                        }
                    }
                }
                //Card Number Changed
                if (originalContractOptionCardNumber != dgv["CardNumber" + appendedName, riIndex].Value.ToString())
                {
                    ContractsOptionsData.UpdateContractDetailCardNumber(contractOptionID, dgv["CardNumber" + appendedName, riIndex].Value.ToString());
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Hedge Order");
                return false;
            }
        }

        private static bool SaveExecutedPremiumRules(dgvCustom dgv, string appendedName, int riIndex, int contractOptionID)
        {
            DialogResult drExecutePremium = DialogResult.No;
            DialogResult drSetPremium = DialogResult.No;
            string emailType = "";
            if (dgv["ExecutedPremium" + appendedName, riIndex].Value.ToString() == "0")
            {
                drExecutePremium = MessageBox.Show("Do you want to change the Executed Premium to 0 and \nset the status back to Working?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                emailType = "Working";
            }
            else if (dgv["ContractOptionStatus" + appendedName, riIndex].Value.ToString() != "Pending Cancelled")
            {
                drExecutePremium = MessageBox.Show("Do you want to execute this option?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                emailType = "Executed";
            }
            else
            {
                drSetPremium = MessageBox.Show("Do you want to change the premium on this option?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }

            if (drExecutePremium == DialogResult.Yes || drSetPremium == DialogResult.Yes)
            {
                decimal executedPremium;
                if (Decimal.TryParse(dgv["ExecutedPremium" + appendedName, riIndex].Value.ToString(), out executedPremium))
                {
                    string returnMessage = "";

                    if (drExecutePremium == DialogResult.Yes)
                    {
                        decimal premium;

                        if (Decimal.TryParse(dgv["Premium" + appendedName, riIndex].Value.ToString(), out premium))
                        {
                            bool saveExecutedPremium = true;
                            //If executed premium more than premium premium.  Give message.
                            if (executedPremium > premium)
                            {
                                DialogResult drPremiumCheck = MessageBox.Show("Premium is higher than requested. \nAre you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (drPremiumCheck != DialogResult.Yes)
                                {
                                    saveExecutedPremium = false;
                                }
                            }
                            if (saveExecutedPremium)
                            {
                                ContractsOptionsData.UpdateContractOptionExecutedPremium(contractOptionID, executedPremium, out returnMessage);
                                DateTime orderDateTime = DateTime.Now;
                                ContractsOptionsData.UpdateContractDetailOrderDateTime(contractOptionID, orderDateTime);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Premium is not in a correct format.", "Hedgedesk");
                            return false;
                        }
                    }
                    else
                    {
                        //used when pending cancelled and need to sell option and input premium value
                        ContractsOptionsData.UpdateContractOptionSetPremium(contractOptionID, executedPremium);
                    }

                    ContractsOptionsData.OptionEmail(contractOptionID, emailType);

                    if ((returnMessage != null) && (returnMessage != ""))
                    {
                        MessageBox.Show(returnMessage, "Hedgedesk");
                    }
                }
                else
                {
                    MessageBox.Show("Executed Premium is not in a correct format.", "Hedgedesk");
                    return false;
                }
            }
            return true;
        }

    }
}

