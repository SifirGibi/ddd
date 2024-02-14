using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfXAxisSizeDal : EfEntityRepositoryBase<tbl_XAxisSize, db_SifirGibiMakinaEntities>, IXAxisSizeDal
    {
        public EfXAxisSizeDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}