using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfPaymentLogDal : EfEntityRepositoryBase<tbl_PaymentLog, db_SifirGibiMakinaEntities>, IPaymentLogDal
    {
        public EfPaymentLogDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}