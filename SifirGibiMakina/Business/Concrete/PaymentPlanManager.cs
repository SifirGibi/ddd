using Iyzipay.Model.V2.Subscription;
using Iyzipay.Model.V2;
using Iyzipay.Model;
using Iyzipay.Request.V2.Subscription;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.Dtos.PaymentProdcutPayPlan;
using SifirGibiMakina.Dtos.PaymentProductPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SifirGibiMakina.DataLayer.İnterfaces;
using System.Runtime.CompilerServices;
using AutoMapper;
using Iyzipay;
using SifirGibiMakina.Business.Constans;

namespace SifirGibiMakina.Business.Concrete
{
    public class PaymentPlanManager:IPaymentPlanService
    {
        private readonly IPaymentProductDal _paymentProductDal;
        private readonly IPaymentProdcutPayPlanDal _paymentProdcutPayPlanDal;
        private readonly IMapper _mapper;

        public PaymentPlanManager(IPaymentProductDal paymentProductDal, IPaymentProdcutPayPlanDal paymentProdcutPayPlanDal, IMapper mapper)
        {
            _paymentProductDal = paymentProductDal;
            _paymentProdcutPayPlanDal = paymentProdcutPayPlanDal;
            _mapper = mapper;
        }

        public void CreatePaymentProduct()
        {
            Options options = new Options();
            options.ApiKey = Key.apiKey;
            options.SecretKey = Key.secretKey;
            options.BaseUrl = Key.baseURL;
            CreateProductRequest request = new CreateProductRequest
            {
               
                Locale = Locale.TR.ToString(),
                Name = Guid.NewGuid().ToString() + "-" + "Premium" +"-" + "3.1",
                ConversationId = "3.1"
            };





            ResponseData<ProductResource> response = Product.Create(request, options);
            if (response.Status == "success")
            {

                CreatePaymentProductPlanDto dto = new CreatePaymentProductPlanDto();
                dto.PaymentProductStatus = response.Status;
                dto.PaymentProductCreatedDate = DateTime.Now;
                dto.PaymnetProductReferenceCode = response.Data.ReferenceCode;
                dto.PaymentProductName = response.Data.Name;
                dto.PaymentVersionId = 3;

                CreatePaymentProductPlan(dto);



            }




        }

        private void CreatePaymentProductPlan(CreatePaymentProductPlanDto planDto)
        {


            var paymentPlan = _mapper.Map<tbl_PaymentProduct>(planDto);
            _paymentProductDal.Add(paymentPlan);
            _paymentProductDal.SaveChanges();





        }


        public void CreatePaymentPlanForPaymentProduct()
        {
            Options options = new Options();
            options.ApiKey = Key.apiKey;
            options.SecretKey = Key.secretKey;
            options.BaseUrl = Key.baseURL;

            CreatePlanRequest request = new CreatePlanRequest()
            {
                Locale = Locale.TR.ToString(),
                Name = Guid.NewGuid().ToString() + "-" + "v3.2",
                ConversationId = "v3.2",

                Price = "1021",
                CurrencyCode = Currency.TRY.ToString(),
                PaymentInterval = PaymentInterval.DAILY.ToString(),
                RecurrenceCount = 12,
                PaymentIntervalCount = 1,
                PlanPaymentType = PlanPaymentType.RECURRING.ToString(),
                ProductReferenceCode = "555e4f8d-ed62-494e-a161-5b2718c294d6"
            };

            ResponseData<PlanResource> response = Plan.Create(request, options);

            if (response.Status == "success")
            {

                CreatePaymentProdcutPayPlanDto dto = new CreatePaymentProdcutPayPlanDto();

                dto.PaymentProdcutPayPlanName = response.Data.Name;
                dto.PaymentProdcutPayPlanReferenceCode = response.Data.ReferenceCode;
                dto.PaymentProdcutPayPlanPrice = Convert.ToInt32(response.Data.Price);
                dto.PaymentProdcutPayCurrencyCode = response.Data.CurrencyCode;
                dto.PaymentProdcutPayPaymentInterval = response.Data.PaymentInterval;
                dto.PaymentProdcutPayPaymentIntervalCount = response.Data.PaymentIntervalCount;
                dto.PaymentProdcutPayRecurrenceCount = response.Data.RecurrenceCount;
                dto.PaymentProdcutPayIsActive = true;
                dto.PaymentProductPayPlanVersionID = 3;
                dto.PaymentProdcutPayPlanCreatedDate = DateTime.Now;
               



                CreatePaymentPlanRequestForPaymentProduct(dto);



            }





        }
        private void CreatePaymentPlanRequestForPaymentProduct(CreatePaymentProdcutPayPlanDto payPlanDto)
        {


            var result = _mapper.Map<tbl_PaymentProdcutPayPlan>(payPlanDto);

            _paymentProdcutPayPlanDal.Add(result);
            _paymentProdcutPayPlanDal.SaveChanges();



        }


        public string GetPaymentPlanRefenceCode(int versionId)
        {
            var result = _paymentProdcutPayPlanDal.Get(x=>x.PaymentProductPayPlanVersionID == versionId);
            if(result == null)
            {

                return "";
            }
           return result.PaymentProdcutPayPlanReferenceCode;






        }


    }
}