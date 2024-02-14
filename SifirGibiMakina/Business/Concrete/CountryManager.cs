using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.Blog;
using SifirGibiMakina.Dtos.Country;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;
        private readonly IMapper _mapper;

        public CountryManager(ICountryDal countryDal, IMapper mapper)
        {
            _countryDal = countryDal;
            _mapper = mapper;
        }

        public tbl_Ulkeler GetCountry(int id)
        {
            return _countryDal.Get(c=>c.id == id);
        }

        public List<CountryListDto> GetListAllCountry()
        {
            var list = _countryDal.GetList();
            var countryDtos = _mapper.Map<List<CountryListDto>>(list);




            return new List<CountryListDto>(countryDtos);
        }
    }
}