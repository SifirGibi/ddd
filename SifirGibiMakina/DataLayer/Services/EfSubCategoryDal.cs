using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfSubCategoryDal : EfEntityRepositoryBase<tbl_MakinaAltTurleri, db_SifirGibiMakinaEntities>, ISubCategoryDal
    {
        public EfSubCategoryDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}