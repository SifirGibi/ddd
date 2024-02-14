using Microsoft.AspNet.SignalR.Messaging;
using SifirGibiMakina.DataLayer.Enums;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.Logo;
using SifirGibiMakina.Dtos.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Repositories
{
    public class EfCompanyLogoDal : EfEntityRepositoryBase<tbl_FirmaLogolari, db_SifirGibiMakinaEntities>, ICompanyLogoDal
    {
        public EfCompanyLogoDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
    }
}