using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Services;
using SifirGibiMakina.Dtos.Membership;
using SifirGibiMakina.Dtos.UserMembership;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class UserMemberShipManager:IUserMemberShipService
    {
        private readonly IMapper _mapper;

        private readonly IUserMembershipDal _userMemberShipDal;

        public UserMemberShipManager(IUserMembershipDal userMemberShipDal, IMapper mapper)
        {
            _userMemberShipDal = userMemberShipDal;
            _mapper = mapper;
        }


        public UserMembershipListDto GetUserMembershipById(int userId)
        {
            var query = _userMemberShipDal.GetUserMembership(userId);
          


            if (query == null)
            {


                return null;
            }
          return query;
        }


        public void CreateMemberShip(CreateUserMemberShipDto createMemberShipDto)
        {

            var userMembershio = _mapper.Map<tbl_UserMembership>(createMemberShipDto);

            _userMemberShipDal.Add(userMembershio);
            _userMemberShipDal.SaveChanges();


        }
        public bool UpdateMembership(UpdateUserMemberShipDto getMember)
        {

            var userMembershio = _mapper.Map<tbl_UserMembership>(getMember);
            if(userMembershio != null) {
                _userMemberShipDal.Update(userMembershio);
                _userMemberShipDal.SaveChanges();
                return true;

            }
            return false;
            


        }
        public tbl_UserMembership GetByDateMemberShip(int id)
        {



            var userMemberships = _userMemberShipDal.GetList(x => x.UserID == id).OrderByDescending(x => x.CreatedDate);
            var latestMembership = userMemberships.FirstOrDefault();
            if(latestMembership == null)
            {

                return null;
            }
           
            return latestMembership;

        }

        public List<UserPaymentListDto> GetListUserPaymentByID(int id)
        {

            var list = _userMemberShipDal.GetPaymentUser(id);

            if(list == null)
            {

                return null;    
            }

            return list;


        }

        public void ChangeIsActive(int userMemberId)
        {
            var machine = _userMemberShipDal.Get(x=>x.UserID == userMemberId && x.IsActive == true);

            if (machine != null)
            {
                machine.IsActive = false;
                _userMemberShipDal.SaveChanges();


            }

        }

    }
}