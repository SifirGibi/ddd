using Newtonsoft.Json;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.Dtos.PaymentLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class CheckFirstSubsReturnPayment : System.Web.UI.Page
    {
        public IPaymentLogService _paymentLog {  get; set; }   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
             
                string requestBody;

                using (var reader = new StreamReader(Request.InputStream))
                {
                    requestBody = reader.ReadToEnd();
                }
               
              
                var notificationData = JsonConvert.DeserializeObject<NotificationData>(requestBody);

               CreatePaymentLogDto logDto = new CreatePaymentLogDto();
                logDto.Status = notificationData.Status;
                logDto.MerchantId = notificationData.MerchantId;    
                logDto.PaymentConversationId = notificationData.PaymentConversationId.ToString();
                logDto.Token = notificationData.Token;
                logDto.IyziReferenceCode = notificationData.IyziReferenceCode;
                logDto.IyziEventType = notificationData.IyziEventType;
                logDto.IyziEventTime = notificationData.IyziEventTime.ToString();
                logDto.IyziPaymentId = notificationData.IyziPaymentId.ToString();


                _paymentLog.CreatePaymentog(logDto);


             
            }
        }

       

      
        public class NotificationData
        {
            public string PaymentConversationId { get; set; }
            public int MerchantId { get; set; }
            public string Token { get; set; }
            public string Status { get; set; }
            public string IyziReferenceCode { get; set; }
            public string IyziEventType { get; set; }
            public long IyziEventTime { get; set; }
            public long IyziPaymentId { get; set; }
        }
    }
}