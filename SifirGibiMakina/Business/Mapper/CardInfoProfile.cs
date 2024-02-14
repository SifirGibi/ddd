using AutoMapper;
using SifirGibiMakina.Dtos.CardInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class CardInfoProfile:Profile
    {
        public CardInfoProfile()
        {
            CreateMap<tbl_CardInfo, CreateCardInfoDto>().ReverseMap();
        }
    }
}