using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfMembershipDal : EfEntityRepositoryBase<tbl_Membership, db_SifirGibiMakinaEntities>, IMembershipDal
    {
        public EfMembershipDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}