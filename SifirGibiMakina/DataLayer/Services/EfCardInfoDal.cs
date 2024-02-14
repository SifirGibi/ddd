using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfCardInfoDal : EfEntityRepositoryBase<tbl_CardInfo, db_SifirGibiMakinaEntities>, ICardInfoDal
    {
        public EfCardInfoDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}