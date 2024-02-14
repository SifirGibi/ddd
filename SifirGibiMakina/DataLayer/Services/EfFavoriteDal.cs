using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfFavoriteDal : EfEntityRepositoryBase<tbl_ilanFavorileri, db_SifirGibiMakinaEntities>, IFavoriteDal
    {
        public EfFavoriteDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}