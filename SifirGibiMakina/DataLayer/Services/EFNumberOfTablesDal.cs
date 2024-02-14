using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EFNumberOfTablesDal : EfEntityRepositoryBase<tbl_NumberOfTables, db_SifirGibiMakinaEntities>, INumberOfTablesDal
    {
        public EFNumberOfTablesDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}