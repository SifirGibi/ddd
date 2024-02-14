using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfServiceWorkZoneDal : EfEntityRepositoryBase<tbl_ServiceWorkZone, db_SifirGibiMakinaEntities>, IServiceWorkZoneDal
    {
        public EfServiceWorkZoneDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }

        public List<UserWrokZoneListDto> GetListServiceCounsrtyWithId(int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {

                var result = from m in context.tbl_ServiceWorkZone
                             join b in context.tbl_Ulkeler
                             on m.ServiceWorkZonceCountyID equals b.id
                            


                             where m.ServiceUserID == id



                             select new UserWrokZoneListDto
                             {
                                 ServiceWorkZoneID = m.ServiceWorkZoneID,
                               CountryName = b.nicename





                             };

                return result.ToList();
            }
        }
    }
}