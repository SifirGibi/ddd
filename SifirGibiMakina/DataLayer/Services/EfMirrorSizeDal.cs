using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfMirrorSizeDal : EfEntityRepositoryBase<tbl_MirrorSize, db_SifirGibiMakinaEntities>, IMirrorSizeDal
    {
        public EfMirrorSizeDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}