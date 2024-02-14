using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfPaymentSubscriberDal : EfEntityRepositoryBase<tbl_PaymentSubscriber, db_SifirGibiMakinaEntities>, IPaymentSubscriberDal
    {
        public EfPaymentSubscriberDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}