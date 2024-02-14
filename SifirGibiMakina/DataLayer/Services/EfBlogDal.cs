using AutoMapper;
using SifirGibiMakina.DataLayer.Entities;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Repositories;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SifirGibiMakina.Translate;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfBlogDal : EfEntityRepositoryBase<tbl_Duyurular,db_SifirGibiMakinaEntities>, IBlogDal
    {
        public EfBlogDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}