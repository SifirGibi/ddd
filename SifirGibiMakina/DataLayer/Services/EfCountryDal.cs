using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfCountryDal : EfEntityRepositoryBase<tbl_Ulkeler, db_SifirGibiMakinaEntities>, ICountryDal
    {
        public EfCountryDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}