using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfNumberOfAxesDal : EfEntityRepositoryBase<tbl_NumberOfAxes, db_SifirGibiMakinaEntities>, INumberOfAxesDal
    {
        public EfNumberOfAxesDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}