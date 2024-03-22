using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace HedgedeskApplication
{
    public partial class frmPurchaseSettle : Form
    {

        public frmPurchaseSettle()
        {
            InitializeComponent();

        }

        private void frmPurchaseSettle_Load(object sender, EventArgs e)
        {
            FormLoad();
            //GlobalStore.mdtSystemSettings.Clear();
            //DataView viewSystem = new DataView();
            //GlobalStore.FillSystemSettingsDataTable();
            //viewSystem = GlobalStore.mdtSystemSettings.DefaultView;
            //this.dtpSettlementCutOffDate.Text = viewSystem[0]["LastPSSettlementDate"].ToString();
            //this.dtpUnSettleDate.Text = "";
            //this.txtUnsettleCurrentPSStartDate.Text = viewSystem[0]["CurrentPSStartDate"].ToString();
            //this.txtCurrentPSEndDate.Text = viewSystem[0]["CurrentPSEndDate"].ToString();
            //this.txtCurrentPSStartDate.Text = viewSystem[0]["CurrentPSStartDate"].ToString();
            //this.txtUnsettleCurrentPSEndDate.Text = viewSystem[0]["CurrentPSEndDate"].ToString();
            //this.dtpLastPSSettlementDate.Value = Convert.ToDateTime(viewSystem[0]["LastPSSettlementDate"].ToString());
            //this.dtpLastTransferDate.Value = Convert.ToDateTime(viewSystem[0]["MovedToPSDate"].ToString());
            //this.txtUnsettleSettleDate.Text = viewSystem[0]["LastPSSettlementDate"].ToString();
            
        }

        private void FormLoad()
        {
            GlobalStore.mdtSystemSettings.Clear();
            DataView viewSystem = new DataView();
            GlobalStore.FillSystemSettingsDataTable();
            viewSystem = GlobalStore.mdtSystemSettings.DefaultView;
            this.dtpSettlementCutOffDate.Text = viewSystem[0]["LastPSSettlementDate"].ToString();
            this.dtpUnSettleDate.Text = "";
            this.txtUnsettleCurrentPSStartDate.Text = viewSystem[0]["CurrentPSStartDate"].ToString();
            this.txtCurrentPSEndDate.Text = viewSystem[0]["CurrentPSEndDate"].ToString();
            this.txtCurrentPSStartDate.Text = viewSystem[0]["CurrentPSStartDate"].ToString();
            this.txtUnsettleCurrentPSEndDate.Text = viewSystem[0]["CurrentPSEndDate"].ToString();
            this.dtpLastPSSettlementDate.Value = Convert.ToDateTime(viewSystem[0]["LastPSSettlementDate"].ToString());
            this.dtpLastTransferDate.Value = Convert.ToDateTime(viewSystem[0]["MovedToPSDate"].ToString());
            this.txtUnsettleSettleDate.Text = viewSystem[0]["LastPSSettlementDate"].ToString();
        }

        private void btnTransferOrdersToPS_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseSettle ps = new PurchaseSettle();
                ps.TransferTradesToPSTables();
                MessageBox.Show("Trades have been transferred to PS tables. ", "Purchase Settle");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnUnsettle_Click(object sender, EventArgs e)
        {
            if (this.dtpUnSettleDate.Text == "")
            {
                MessageBox.Show("Please Enter a Date.");
                return;

            }

            if (this.dtpUnSettleDate.Value < Convert.ToDateTime(this.txtUnsettleCurrentPSStartDate.Text.ToString()))
            {
                MessageBox.Show("You can not un-settle orders prior to the Current Period Start Date.");
                return;

            }
            DateTime SettleDate = Convert.ToDateTime(this.dtpUnSettleDate.Value.ToString());
            PurchaseSettle ps = new PurchaseSettle();
            ps.RunPurchaseUnsettle(SettleDate.ToShortDateString());
            MessageBox.Show("Purchase UnSettle complete for " + this.dtpUnSettleDate.Value.ToString() + ".", "Purchase Settle");
            FormLoad();


        }

        private void btnRunPSRoutine_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime SettleDate = Convert.ToDateTime(dtpSettlementCutOffDate.Value.ToString());
                PurchaseSettle ps = new PurchaseSettle();
                ps.RunPurchaseSettle(SettleDate.ToShortDateString());
                MessageBox.Show("Purchase settle complete for " + SettleDate + ".", "Purchase Settle");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            FormLoad();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime SettleDate = Convert.ToDateTime(this.dtpLastPSSettlementDate.Value.ToString());
                PurchaseSettle ps = new PurchaseSettle();
                ps.UpdateLastSettleDate(SettleDate.ToShortDateString());
                MessageBox.Show("Settlement date has been updated.", "Purchase Settle");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
        }

        private void btnTransferToGEM_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dtXML = new DataSet();
                DataSet dtXMLPrices = new DataSet();

                string strXmlTestCasePath = Properties.Settings.Default.GEMDirectory + "HedgedeskFuturesPosition.xml";
                string strXmlPrices = Properties.Settings.Default.GEMDirectory + "HedgedeskFuturesPrices.xml";
                Maintenance clsMaintenance = new Maintenance();
                clsMaintenance.GetXMLForZennoh(dtXML);
                using (XmlWriter xw = XmlWriter.Create(strXmlTestCasePath))
                {
                    xw.WriteStartDocument();
                    dtXML.DataSetName = "dataroot";
                    dtXML.Tables[0].TableName = "qryTransferTextCreate_Zennoh_XML";
                    dtXML.WriteXml(xw, XmlWriteMode.IgnoreSchema);    // from here on, you can use the XmlWriter to add XML to the end; you then    // have to wrap things up by closing the enclosing "container" element:    ...    
                    xw.WriteEndDocument();
                }
                clsMaintenance.GetXMLFuturesForZennoh(dtXMLPrices);
                using (XmlWriter xw = XmlWriter.Create(strXmlPrices))
                {
                    xw.WriteStartDocument();
                    dtXMLPrices.DataSetName = "dataroot";
                    dtXMLPrices.Tables[0].TableName = "qryTransferZenNohFutures";
                    dtXMLPrices.WriteXml(xw, XmlWriteMode.IgnoreSchema);    // from here on, you can use the XmlWriter to add XML to the end; you then    // have to wrap things up by closing the enclosing "container" element:    ...    
                    xw.WriteEndDocument();
                }
                MessageBox.Show("Data transferred to GEM", "Gem Transfer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

    }
}
