using AutoMapper;
using SifirGibiMakina.Dtos.UserMembership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class UserMemberShipProfile:Profile
    {
        public UserMemberShipProfile()
        {
            CreateMap<tbl_UserMembership , UserMembershipListDto>().ReverseMap();
            CreateMap<tbl_UserMembership , CreateUserMemberShipDto>().ReverseMap();
            CreateMap<tbl_UserMembership , UpdateUserMemberShipDto>().ReverseMap();
        }
    }
}