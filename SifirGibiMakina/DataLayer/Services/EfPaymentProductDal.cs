using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfPaymentProductDal : EfEntityRepositoryBase<tbl_PaymentProduct, db_SifirGibiMakinaEntities>, IPaymentProductDal
    {
        public EfPaymentProductDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}