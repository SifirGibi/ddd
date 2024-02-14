using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfServiceUserDetailDal : EfEntityRepositoryBase<tbl_ServiceUserDetail, db_SifirGibiMakinaEntities>, IServiceUserDetailDal
    {
        public EfServiceUserDetailDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}