using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfServiceEquipmentDetailDal : EfEntityRepositoryBase<tbl_ServiceEquipmentDetail, db_SifirGibiMakinaEntities>, IServiceEquipmentDetailDal
    {
        public EfServiceEquipmentDetailDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}