using AutoMapper;
using SifirGibiMakina.Dtos.MembershipVersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class MembershipVersionProfile:Profile
    {
        public MembershipVersionProfile()
        {
            CreateMap<tbl_MembershipVersion , MembersVersionWithUserMemberListDto>().ReverseMap();  
        }
    }
}