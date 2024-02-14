using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfMessageDal : EfEntityRepositoryBase<tbl_ilanMesajlari, db_SifirGibiMakinaEntities>, IMessageDal
    {
        public EfMessageDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}