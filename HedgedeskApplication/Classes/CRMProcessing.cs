using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;


namespace HedgedeskApplication.Classes
{
    public class CRMProcessing
    {
        public bool ProcessCRMSplitFill(DataTable Orders)
        {
            ProcessContractForSplitFill(Orders);
            return true;
        }

        public bool ProcessCRMPartialFill(DataTable Orders)
        {
            //call web service Split Partial Fill
            ProcessContractForSplitFill(Orders);
            return true;

        }

        public bool ProcessUpdateCRMonApproval(int requestId)
        {
            var status = "Processed";
            var order = GlobalStore.FillSingleRegionOrderDataTable(requestId.ToString());
            var orderNumber = 0;
            var orderType = "";
            var uri = "";
            var offerId = "";


            if (order.Rows.Count > 0)
            {
                orderNumber = Convert.ToInt32(order.DefaultView[0]["TP_ORD_NUMB"].ToString());
                orderType = order.DefaultView[0]["Type"].ToString();
                offerId = order.DefaultView[0]["GrainInsightContractGuid"].ToString();

            }

            if (orderType == "ORD")
            {
                try
                {
                    ServicePointManager.ServerCertificateValidationCallback +=
   (sender2, cert, chain, sslPolicyErrors) => true;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(@"https://giintegration.cgb.com");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        //api/ContractSigner/GetESignatureProfile?agrisId=40042683
                        //var response = client.PostAsync(@"https://giintegration.cgb.com/api/Offer/UpdateOffer?offerId=38686f48-1a6c-e811-a960-005056a975ba&hedgeTradeId=161987", new StringContent("")).Result;
                        var response =
                            client.PostAsync(
                                @"api/Offer/UpdateOffer?offerId=" + offerId + "&hedgeTradeId=" + orderNumber,
                                new StringContent("")).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            Debug.Print("Successful");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Report Issue with updating Grain Insight");
                }
                //using (var wb = new WebClient())
                //{

                //    //uri = @"https://giintegration.cgb.com/api/Offer/UpdateOffer?offerId=38686f48-1a6c-e811-a960-005056a975ba&hedgeTradeId=161987";

                //    //uri =
                //    //  @"https://giintegration.cgb.com/api/Offer/UpdateOffer?offerId=" +
                //    //   offerId + "&hedgeTradeId=" + orderNumber;

                //    var response = wb.UploadString(uri, "POST");
                //}

            }
            else
            {

                try
                {
                    ServicePointManager.ServerCertificateValidationCallback +=
   (sender2, cert, chain, sslPolicyErrors) => true;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(@"https://hedgecrminterface.cgb.com");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        //api/ContractSigner/GetESignatureProfile?agrisId=40042683
                        //var response = client.PostAsync(@"https://giintegration.cgb.com/api/Offer/UpdateOffer?offerId=38686f48-1a6c-e811-a960-005056a975ba&hedgeTradeId=161987", new StringContent("")).Result;
                        var response =
                            client.PostAsync(
                                @"api/CentralHedgeOrder/UpdateGrainInsightContractOnApprovalHttp?hedgeOrderId=" +
                                orderNumber + "&hedgeOrderStatus=" + status,
                                new StringContent("")).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            Debug.Print("Successful");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Report Issue with updating Grain Insight");
                }

                //    using (var wb = new WebClient())
                //{
                //    uri =
                //    @"https://hedgecrminterface.cgb.com/api/CentralHedgeOrder/UpdateGrainInsightContractOnApprovalHttp?hedgeOrderId=" +
                //    orderNumber + "&hedgeOrderStatus=" + status;

                //    var response = wb.UploadString(uri, "POST");
                //}

                //uri =
                //@"https://hedgecrminterface.cgb.com/api/CentralHedgeOrder/UpdateGrainInsightContractOnApprovalHttp?hedgeOrderId=" +
                //orderNumber + "&hedgeOrderStatus=" + status;
                //HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            }


            return true;
        }

        public bool ProcessUpdateCRMonCancellation(int orderId)
        {
            var status = GetStatusForOrderNumber(orderId);
            //call web service and pass ordernumber and status
            return true;
        }

        public bool ProcessUpdateCRMonUpdate(int orderId)
        {
            var status = GetStatusForOrderNumber(orderId);
            //call web service and pass ordernumber and status
            return true;
        }

        private String GetStatusForOrderNumber(int orderId)
        {
            var status = "Processed";
            var order = GlobalStore.FillOrderDataTable(orderId.ToString());
            if (order.Rows.Count > 0)
            {
                if (order.DefaultView[0]["EO"].ToString() != "0")
                {
                    status = order.DefaultView[0]["status"].ToString();
                }

            }
            return status;

        }

        private void ProcessContractForSplitFill(DataTable Orders)
        {
            var orderNumber = 0;
            var bushels = 0.00;
            var price = 0.000;
            var uri = "";
            var offerId = "";
            var acct = 0;
            var origQty = 0.00;
            var fillBushels = 0.00;
            var amountBushels = 0.00;
            if (Orders.Rows.Count > 0)
            {
                foreach (DataRow c in Orders.Rows)

                {

                    orderNumber = Convert.ToInt32(c["OrderID"].ToString());
                    bushels = Convert.ToInt32(c["FillQuantity"].ToString());
                    offerId = c["GrainInsightContractGuid"].ToString();
                    price = Convert.ToDouble(c["LastPrice"].ToString());
                    acct = Convert.ToInt32(c["AccountID"].ToString());
                    origQty = Convert.ToInt32(c["OrigQty"]);
                    fillBushels = fillBushels + bushels;

                    if (offerId == "") return;

                    try
                    {
                        ServicePointManager.ServerCertificateValidationCallback +=
   (sender2, cert, chain, sslPolicyErrors) => true;

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(@"https://giintegration.cgb.com");
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));
                            //api/ContractSigner/GetESignatureProfile?agrisId=40042683
                            //var response = client.PostAsync(@"https://giintegration.cgb.com/api/Offer/UpdateOffer?offerId=38686f48-1a6c-e811-a960-005056a975ba&hedgeTradeId=161987", new StringContent("")).Result;
                            var response =
                                client.PostAsync(
                                    @"api/Offer/OfferHit?offerId=" +
                                    offerId + "&hedgeTradeId=" + orderNumber + "&bushels=" + bushels + "&price=" + price +
                                    "&hedgeAccount=" + acct,
                                    new StringContent("")).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                Debug.Print("Successful");
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Report Issue with updating Grain Insight");
                    }

                    //using (var wb = new WebClient())
                    //{
                    //    amountBushels = origQty - fillBushels;

                    //    if (bushels> amountBushels)
                    //    {
                    //        bushels = bushels;
                    //    }

                    //    uri =
                    //     @"http://giintegration.cgb.com/api/Offer/OfferHit?offerId=" +
                    //     offerId + "&hedgeTradeId=" +  orderNumber + "&bushels=" + bushels + "&price=" + price + "&hedgeAccount=" + acct;

                    //    var response = wb.UploadString(uri, "POST");
                    //}

                }

            }
        }
    }
}
