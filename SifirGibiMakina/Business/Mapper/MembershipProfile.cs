using AutoMapper;
using SifirGibiMakina.Dtos.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class MembershipProfile:Profile
    {

        public MembershipProfile()
        {
            CreateMap<tbl_Membership , GetListMembershipDto>().ReverseMap();
            CreateMap<tbl_Membership , CreateMemberShipDto>().ReverseMap();

        }
    }
}