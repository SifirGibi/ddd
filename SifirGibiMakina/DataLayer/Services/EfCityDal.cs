using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfCityDal : EfEntityRepositoryBase<Sehirler, db_SifirGibiMakinaEntities>, ICityDal
    {
        public EfCityDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}