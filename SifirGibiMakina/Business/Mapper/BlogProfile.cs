using AutoMapper;
using SifirGibiMakina.Dtos.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Mapper
{
    public class BlogProfile:Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogListDto, tbl_Duyurular>().ReverseMap();
        }
    }
}