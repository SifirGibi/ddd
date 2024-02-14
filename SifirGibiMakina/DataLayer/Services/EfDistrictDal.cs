using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfDistrictDal : EfEntityRepositoryBase<Ilceler, db_SifirGibiMakinaEntities>, IDistrictDal
    {
        public EfDistrictDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}