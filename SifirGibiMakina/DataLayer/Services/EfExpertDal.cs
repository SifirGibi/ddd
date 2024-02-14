using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfExpertDal : EfEntityRepositoryBase<tbl_MakinaEksper, db_SifirGibiMakinaEntities>, IExpertDal
    {
        public EfExpertDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}