using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.İnterfaces
{
    public interface IServiceWorkZoneDal:IEntityRepository<tbl_ServiceWorkZone>
    {
        List<UserWrokZoneListDto> GetListServiceCounsrtyWithId(int id);
    }
}