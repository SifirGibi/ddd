using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Repositories;
using SifirGibiMakina.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfMachineBrandDal : EfEntityRepositoryBase<tbl_MakinaMarkalari, db_SifirGibiMakinaEntities>, IMachineBrandDal
    {
        public EfMachineBrandDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}