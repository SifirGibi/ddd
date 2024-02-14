using AutoMapper;
using SifirGibiMakina.Dtos.Favorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class FavoriteProfile:Profile
    {
        public FavoriteProfile()
        {
            CreateMap<tbl_ilanFavorileri,CreateFavoriteDto >().ReverseMap();
        }
    }
}