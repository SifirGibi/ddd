using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfPaymentProdcutPayPlanDal : EfEntityRepositoryBase<tbl_PaymentProdcutPayPlan, db_SifirGibiMakinaEntities>, IPaymentProdcutPayPlanDal
    {
        public EfPaymentProdcutPayPlanDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}