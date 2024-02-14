using Microsoft.Extensions.Options;
using Microsoft.Owin.BuilderProperties;
using SifirGibiMakina.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Iyzipay;
using Options = Iyzipay.Options;
using Iyzipay.Model.V2;
using Iyzipay.Model.V2.Subscription;
using Iyzipay.Request.V2.Subscription;
using Iyzipay.Request;
using Iyzipay.Model;
using SifirGibiMakina.Models;
using SifirGibiMakina.Business.Constans;
using SifirGibiMakina.Dtos.PaymentInfo;
using SifirGibiMakina.DataLayer.İnterfaces;
using AutoMapper;
using SifirGibiMakina.Dtos.CardInfo;
using SifirGibiMakina.Dtos.PaymentProductPlan;
using SifirGibiMakina.Dtos.PaymentProdcutPayPlan;
using SifirGibiMakina.Dtos.PaymentSubscriber;
using Microsoft.AspNet.SignalR.Messaging;
using SifirGibiMakina.DataLayer.Entities;


namespace SifirGibiMakina.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentInfoDal _paymentInfoDal;
        private readonly IMapper _mapper;
        private readonly ICardInfoDal _cardInfoDal;
    
        private readonly IPaymentSubscriberDal _subscriber;

        public PaymentManager(IPaymentInfoDal paymentInfoDal, IMapper mapper, ICardInfoDal cardInfoDal, IPaymentSubscriberDal subscriber)
        {
            _paymentInfoDal = paymentInfoDal;
            _mapper = mapper;
            _cardInfoDal = cardInfoDal;
            _subscriber = subscriber;
        }

        public ResultPaymentMessage CreatePayment(PaymentModel paymentModel , MemberVersionForBasket memberVersion, PaymentInformation paymentInformation)
        {
            Options options = new Options();
            options.ApiKey = Key.apiKey;
            options.SecretKey =Key.secretKey;
            options.BaseUrl = Key.baseURL;
         
            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = paymentInformation.Id; //sipariş numaraı gibi düşünebiliriz
            request.Price = paymentModel.Price; // ürün fiyatı
            request.PaidPrice = paymentModel.Price; // gerçek tutar kdv dahil
            request.Currency = Currency.TRY.ToString(); //ödeme para birimi
            request.Installment = paymentModel.Installment; //taksit sayısı

         
        

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = paymentModel.CardHolderName;
            paymentCard.CardNumber = paymentModel.CardNumber;
            paymentCard.ExpireMonth = paymentModel.ExpireMonht;
            paymentCard.ExpireYear = paymentModel.ExpireYear;
            paymentCard.Cvc = paymentModel.Cvc;
           
            paymentCard.RegisterCard = 0; // kartın kaydedilip kaydedilmeyeceğini seçer
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = paymentInformation.Id;
            buyer.Name = paymentInformation.Name;
            buyer.Surname = paymentInformation.Surname;
            buyer.Email = paymentInformation.Email;
            buyer.IdentityNumber = paymentInformation.IdentityNumber;
            buyer.RegistrationAddress = paymentInformation.Description;
            buyer.Ip = paymentInformation.Ip;
            buyer.City = paymentInformation.City;
            buyer.Country = paymentInformation.Country;
            request.Buyer = buyer;

            Iyzipay.Model.Address shippingAddress = new Iyzipay.Model.Address();
            shippingAddress.ContactName = paymentInformation.Name +" " + paymentInformation.Surname;
            shippingAddress.City = paymentInformation.City;
            shippingAddress.Country = paymentInformation.Country;
            shippingAddress.Description = paymentInformation.Description;

            request.ShippingAddress = shippingAddress;

            Iyzipay.Model.Address billingAddress = new Iyzipay.Model.Address();
            billingAddress.ContactName = paymentInformation.Name + " " + paymentInformation.Surname;
            billingAddress.City = paymentInformation.City;
            billingAddress.Country = paymentInformation.Country;
            billingAddress.Description = paymentInformation.Description;

            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = memberVersion.Id;
            firstBasketItem.Name = memberVersion.Name;
            firstBasketItem.Category1 = memberVersion.Category1;
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();

            firstBasketItem.Price = paymentModel.Price;
            basketItems.Add(firstBasketItem);

       
            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);
          
            if(payment.Status == "success")
            {
                {
                    CreatePaymentInfoDto dto = new CreatePaymentInfoDto();
                    dto.Status = payment.Status;
                    dto.BinNumber = payment.BinNumber;
                    dto.ConversationId = payment.ConversationId;
                    dto.UserId = Convert.ToInt32(paymentInformation.Id);
                    dto.PaidPrice = payment.PaidPrice;
                    foreach (var par in payment.PaymentItems)
                    {

                        dto.PaymentTransactionId = par.PaymentTransactionId;
                        break;
                    }
                    dto.PaymentId = Convert.ToInt32(payment.PaymentId);

                    CreatePaymentInfo(dto);
                }

            
                
            }
            ResultPaymentMessage resultPaymentMessage = new ResultPaymentMessage();
            resultPaymentMessage.Status = payment.Status;
            resultPaymentMessage.ErrorMessage = payment.ErrorMessage;   
            return resultPaymentMessage;
        }

        private void CreatePaymentInfo(CreatePaymentInfoDto dto)
        {
            var paymentInfo = _mapper.Map<tbl_PaymentInfo>(dto);

            _paymentInfoDal.Add(paymentInfo);
            _paymentInfoDal.SaveChanges();
        }
        private void CreateCardInfo(CreateCardInfoDto dto)
        {
            var cardInfo = _mapper.Map<tbl_CardInfo>(dto);

            _cardInfoDal.Add(cardInfo);
            _cardInfoDal.SaveChanges();
        }
        public class ResultPaymentMessage
        {


            public string Status { get; set; }
            public string ErrorMessage { get; set; }
        }


     
        public ResultPaymentMessage CreatePaymentSubscriber(PaymentModel paymentModel, MemberVersionForBasket memberVersion, PaymentInformation paymentInformation)
        {
            Options options = new Options();
            options.ApiKey = Key.apiKey;
            options.SecretKey = Key.secretKey;
            options.BaseUrl = Key.baseURL;
            SubscriptionInitializeRequest request = new SubscriptionInitializeRequest
            {
                SubscriptionInitialStatus = "ACTIVE",
                Locale = Locale.TR.ToString(),
                Customer = new CheckoutFormCustomer
                {
                    Email = paymentInformation.Email,
                    Name = paymentInformation.Name,
                    Surname = paymentInformation.Surname,
                    BillingAddress = new Iyzipay.Model.Address
                    {
                        City = paymentInformation.City,
                        Country = paymentInformation.Country,
                        Description = paymentInformation.Description,
                        ContactName = paymentInformation.Name + " " + paymentInformation.Surname

                    },
                    ShippingAddress = new Iyzipay.Model.Address
                    {
                        City = paymentInformation.City,
                        Country = paymentInformation.Country,
                        Description = paymentInformation.Description,
                        ContactName = paymentInformation.Name + " " + paymentInformation.Surname

                    },

                    GsmNumber = paymentInformation.Phone,
                    IdentityNumber = paymentInformation.IdentityNumber
                },
                PaymentCard = new CardInfo
                {
                    CardNumber = paymentModel.CardNumber,
                    CardHolderName = paymentModel.CardHolderName,
                    ExpireMonth = paymentModel.ExpireMonht,
                    ExpireYear = paymentModel.ExpireYear,
                    Cvc = paymentModel.Cvc,
                    RegisterConsumerCard = paymentModel.RegisterCard
                },
                ConversationId = paymentInformation.Id,
                PricingPlanReferenceCode = paymentModel.ProductReferenceCode
            };

            ResponseData<SubscriptionCreatedResource> response = Iyzipay.Model.V2.Subscription.Subscription.Initialize(request, options);
           

            if (response.Status == "success")
            {


                {
                    CreatePaymentSubscriberDto subscriberDto = new CreatePaymentSubscriberDto();

                    subscriberDto.SubscriberUserId = Convert.ToInt32(paymentInformation.Id);
                    subscriberDto.SubscriberRefenceCode = response.Data.ReferenceCode;
                    subscriberDto.SubscriberParentReferenceCode = response.Data.ParentReferenceCode;
                    subscriberDto.SubscriberPricingPlanReferenceCode = response.Data.PricingPlanReferenceCode;
                    subscriberDto.SubscriberCustomerReferenceCode = response.Data.CustomerReferenceCode;
                    subscriberDto.SubscriberSubscriptionStatus = response.Data.SubscriptionStatus;
                    subscriberDto.SubscriberCreatedDate = DateTime.Now;
                    subscriberDto.SubscriberStartDate = DateTime.Now;
                    subscriberDto.SubscriberPaymentProdcutPayPlanId = memberVersion.MembershipVersionID;
                    subscriberDto.IsActive = true;



                   CreateSubscriber(subscriberDto);

                }
            }


            ResultPaymentMessage resultPaymentMessage = new ResultPaymentMessage();
            resultPaymentMessage.Status = response.Status;
            resultPaymentMessage.ErrorMessage = response.ErrorMessage;
            return resultPaymentMessage;







        }
        private void CreateSubscriber(CreatePaymentSubscriberDto createPaymentSubscriberDto)
        {
            var result = _mapper.Map<tbl_PaymentSubscriber>(createPaymentSubscriberDto);


            _subscriber.Add(result);
            _subscriber.SaveChanges();
        }


    }
}