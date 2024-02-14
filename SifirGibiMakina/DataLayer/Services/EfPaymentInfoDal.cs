using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfPaymentInfoDal : EfEntityRepositoryBase<tbl_PaymentInfo, db_SifirGibiMakinaEntities>, IPaymentInfoDal
    {
        public EfPaymentInfoDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}