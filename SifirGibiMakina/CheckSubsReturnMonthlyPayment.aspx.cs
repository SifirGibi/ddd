using Newtonsoft.Json;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.Dtos.PaymentLog;
using SifirGibiMakina.Dtos.SubsReturnPaymentLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class CheckSubsReturnMonthlyPayment : System.Web.UI.Page
    {
        public ISubsReturnPaymentLogService _logService {  get; set; } 
        public IPaymentSubscriberService _subscriberService { get; set; }
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

                CreateSubsReturnPaymentLogDto paymentLogDto = new CreateSubsReturnPaymentLogDto();
                paymentLogDto.SubsLogOrderReferenceCode = notificationData.orderReferenceCode;
                paymentLogDto.SubsLogCustomerReferenceCode = notificationData.customerReferenceCode;
                paymentLogDto.SubsLogSubscriptionReferenceCode = notificationData.subscriptionReferenceCode.ToString();
                paymentLogDto.SubsLogIyziReferenceCode = notificationData.iyziReferenceCode.ToString();
                paymentLogDto.SubsLogIyziEventType = notificationData.IyziEventType;
            
                paymentLogDto.SubsLogIyziEventTime = notificationData.IyziEventTime.ToString();
                   _logService.CreateSubsReturnPaymentLog(paymentLogDto);
                bool changeOrder;
              

                    changeOrder = true;
            
                    _subscriberService.GetSubsriber(notificationData.subscriptionReferenceCode, changeOrder);

                
               
                    


              
                



                }
            }

        

      
        public class NotificationData
        {
            public string orderReferenceCode { get; set; }
            public string customerReferenceCode { get; set; }
            public string subscriptionReferenceCode { get; set; }
            public string iyziReferenceCode { get; set; }
            public string IyziEventType { get; set; }
            public long IyziEventTime { get; set; }
           
        }
    }
    
}