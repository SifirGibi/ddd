using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfSubsReturnPaymentLogDal : EfEntityRepositoryBase<tbl_SubsReturnPaymentLog, db_SifirGibiMakinaEntities>, ISubsReturnPaymentLogDal
    {
        public EfSubsReturnPaymentLogDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}