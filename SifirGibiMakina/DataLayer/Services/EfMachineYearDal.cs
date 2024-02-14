using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfMachineYearDal : EfEntityRepositoryBase<tbl_MakinaYillar, db_SifirGibiMakinaEntities>, IMachineYearDal
    {
        public EfMachineYearDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}