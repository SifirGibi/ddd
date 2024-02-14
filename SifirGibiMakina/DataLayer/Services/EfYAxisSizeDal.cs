using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfYAxisSizeDal : EfEntityRepositoryBase<tbl_YAxisSize, db_SifirGibiMakinaEntities>, IYAxisSizeDal
    {
        public EfYAxisSizeDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}