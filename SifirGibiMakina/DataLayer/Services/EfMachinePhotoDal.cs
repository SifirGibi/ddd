using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfMachinePhotoDal : EfEntityRepositoryBase<tbl_MakinaResimler, db_SifirGibiMakinaEntities>, IMachinePhotoDal
    {
        public EfMachinePhotoDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}