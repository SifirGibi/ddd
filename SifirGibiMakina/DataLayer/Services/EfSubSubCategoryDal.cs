using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfSubSubCategoryDal : EfEntityRepositoryBase<tbl_MakinaAltTurleri2, db_SifirGibiMakinaEntities>, ISubSubCategoryDal
    {
        public EfSubSubCategoryDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}