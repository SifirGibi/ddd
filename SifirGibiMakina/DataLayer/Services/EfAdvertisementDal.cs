using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Repositories;
using SifirGibiMakina.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfAdvertisementDal : EfEntityRepositoryBase<tbl_Reklamlar, db_SifirGibiMakinaEntities>, IAdvertisementDal
    {
        public EfAdvertisementDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}