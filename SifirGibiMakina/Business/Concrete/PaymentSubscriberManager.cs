using AutoMapper;
using Microsoft.AspNet.SignalR.Messaging;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.Membership;
using SifirGibiMakina.Dtos.PaymentSubscriber;
using SifirGibiMakina.Dtos.UserMembership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class PaymentSubscriberManager : IPaymentSubscriberService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentSubscriberDal _subsDal;
        private readonly IUserMemberShipService _userMemberShipService;

        public PaymentSubscriberManager(IMapper mapper, IPaymentSubscriberDal subsDal, IUserMemberShipService userMemberShipService)
        {
            _mapper = mapper;
            _subsDal = subsDal;
            _userMemberShipService = userMemberShipService;
        }



        public void GetSubsriber(string subsCode , bool status)
        {

            var subs = _subsDal.Get(x=>x.SubscriberRefenceCode == subsCode);
        
            if (subs != null) {
            int id = subs.SubscriberUserId ?? 0;
                if (status == false)
                {

                  
                    subs.SubscriberIsActive = false;
               

                
               
                    _subsDal.SaveChanges();
                   


                }
                else
                {

                    subs.SubscriberIsActive = true;




                    _subsDal.SaveChanges();


                }
               

             var user =  _userMemberShipService.GetByDateMemberShip(id);
              if(user != null)
                {

                    UpdateUserMemberShipDto updateUser = new UpdateUserMemberShipDto();

                    updateUser.MembershipID = user.MembershipID;
                    updateUser.UserMembershipID = user.UserMembershipID;
                    updateUser.UserID = user.UserID;
                    updateUser.UpdatedDate = DateTime.Now;
                    updateUser.CreatedDate = user.CreatedDate;
                    updateUser.EndDate = user.EndDate;
                    updateUser.IsActive = false ;
                    updateUser.IsPaid = user.IsPaid;
                    updateUser.PaymentPlanID = user.PaymentPlanID;
                  bool CheckStatus =  _userMemberShipService.UpdateMembership(updateUser);
                    if(CheckStatus == true) 
                    {
                       CreateUserMemberShipDto shipDto = new CreateUserMemberShipDto();
                        shipDto.UserID = user.UserID;
                        shipDto.MembershipID = user.UserID;
                        shipDto.PaymentPlanID = user.PaymentPlanID;
                        shipDto.IsActive = status;
                        if(status == true)
                        {
                            shipDto.IsPaid = true;
                        }
                        else
                        {
                            shipDto.IsPaid= false;
                        }
                        shipDto.CreatedDate = DateTime.Now;
                        DateTime timeToNow = DateTime.Now;
                        DateTime newDate = timeToNow.AddDays(1);
                        shipDto.EndDate = newDate;
                        _userMemberShipService.CreateMemberShip(shipDto);






                    }





                }


            }


        }
    }
}