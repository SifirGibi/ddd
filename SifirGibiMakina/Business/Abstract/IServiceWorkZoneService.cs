using SifirGibiMakina.Dtos.ServiceWorkZone;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IServiceWorkZoneService
    {
        void DeleteWorkZone(int id);
        void CreateWorkZone(ServiceCreateWorkZoneDto serviceCreateWorkZoneDto);
        List<UserWrokZoneListDto> GetListServiceCounsrtyWithId(int id);
    }
}