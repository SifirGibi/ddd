using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfMachineDetailDal : EfEntityRepositoryBase<tbl_MachineDetail, db_SifirGibiMakinaEntities>, IMachineDetailDal
    {
        public EfMachineDetailDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}