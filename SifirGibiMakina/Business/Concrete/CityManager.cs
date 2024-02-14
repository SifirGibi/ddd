using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly IMapper _mapper;
        private readonly ICityDal _cityDal;
        private readonly IDistrictDal _districtDal;

        public CityManager(IMapper mapper, ICityDal cityDal, IDistrictDal districtDal)
        {
            _mapper = mapper;
            _cityDal = cityDal;
            _districtDal = districtDal;
        }

        public List<CityAndDistrictListDto> GetAllCityAndDistrict()
        {
            var cities = _cityDal.GetList();
            var cityListDtos= new List<CityAndDistrictListDto>();
            foreach (var city in cities) { 
            
                var district = _districtDal.GetList(d => d.SehirId == city.SehirId).ToList();

                var result = new CityAndDistrictListDto
                {
                    SehirId = city.SehirId,
                    SehirAdi = city.SehirAdi,
                    ilcelers = district

                };
                cityListDtos.Add(result);
            
            }

            return cityListDtos;    
        }
    }
}