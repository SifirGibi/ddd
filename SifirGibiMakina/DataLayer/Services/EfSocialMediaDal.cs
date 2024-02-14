using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Repositories;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfSocialMediaDal : EfEntityRepositoryBase<tbl_SosyalMedya, db_SifirGibiMakinaEntities>, ISocialMediaDal
    {
        public EfSocialMediaDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}