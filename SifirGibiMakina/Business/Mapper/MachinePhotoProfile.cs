using AutoMapper;
using SifirGibiMakina.Dtos.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class MachinePhotoProfile:Profile
    {
        public MachinePhotoProfile()
        {
            CreateMap<GetListPhotoDto , tbl_MakinaResimler>().ReverseMap();
            CreateMap<PhotoCreateDto , tbl_MakinaResimler>().ReverseMap();
        }
    }
}