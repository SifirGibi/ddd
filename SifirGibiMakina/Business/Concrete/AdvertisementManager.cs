using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class AdvertisementManager : IAdvertisementService
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisementDal _advertisementDal;
        public AdvertisementManager( IMapper mapper, IAdvertisementDal advertisementDal)
        {

            _mapper = mapper;
            _advertisementDal = advertisementDal;
        }

        public  tbl_Reklamlar GetAdvertisement(int id)
        {
            return _advertisementDal.Get(c => c.Durum == true && c.dil_ID == 1 && c.reklamAlan_ID == id && c.Yayinda == true);
            
        }
    }
}