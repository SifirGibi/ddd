using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfControlUnitDal : EfEntityRepositoryBase<tbl_ControlUnit, db_SifirGibiMakinaEntities>, IControlUnitDal
    {
        public EfControlUnitDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}