using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfSpindleRPMDal : EfEntityRepositoryBase<tbl_SpindleRPM, db_SifirGibiMakinaEntities>, ISpindleRPMDal
    {
        public EfSpindleRPMDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}