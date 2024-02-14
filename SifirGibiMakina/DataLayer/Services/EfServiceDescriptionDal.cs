using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfServiceDescriptionDal : EfEntityRepositoryBase<tbl_ServiceDescription, db_SifirGibiMakinaEntities>, IServiceDescriptionDal
    {
        public EfServiceDescriptionDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}