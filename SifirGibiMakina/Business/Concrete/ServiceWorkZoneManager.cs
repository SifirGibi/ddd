using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.ServiceWorkZone;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class ServiceWorkZoneManager : IServiceWorkZoneService
    {
        private readonly IServiceWorkZoneDal _serviceWorkZoneDal;

        public ServiceWorkZoneManager(IServiceWorkZoneDal serviceWorkZoneDal)
        {
            _serviceWorkZoneDal = serviceWorkZoneDal;
        }

        public List<UserWrokZoneListDto> GetListServiceCounsrtyWithId(int id)
        {
            var userZone = _serviceWorkZoneDal.GetListServiceCounsrtyWithId(id); 

            if(userZone != null)
                return userZone;

            return new List<UserWrokZoneListDto>();
        }
        public void DeleteWorkZone(int id)
        {
            var workZone = _serviceWorkZoneDal.Get(x=>x.ServiceWorkZoneID == id);

            _serviceWorkZoneDal.Delete(workZone);
            _serviceWorkZoneDal.SaveChanges();


        }

        public void CreateWorkZone(ServiceCreateWorkZoneDto serviceCreateWorkZoneDto)
        {
            tbl_ServiceWorkZone tbl_ServiceWorkZone = new tbl_ServiceWorkZone
            {

                ServiceUserID = serviceCreateWorkZoneDto.ServiceUserID,
                ServiceWorkZonceCountyID = serviceCreateWorkZoneDto.ServiceWorkZonceCountyID,
                CreatedDate = DateTime.Now,


            };

            _serviceWorkZoneDal.Add(tbl_ServiceWorkZone);
            _serviceWorkZoneDal.SaveChanges();



        }
    }
}