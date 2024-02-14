using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.MachineBrand;
using SifirGibiMakina.Dtos.MachineYear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class MachineBrandManager:IMachineBrandService
    {
     
        private readonly IMapper _mapper;
        private readonly IMachineBrandDal _machineBrandDal;

        public MachineBrandManager(IMapper mapper, IMachineBrandDal machineBrandDal)
        {
            _mapper = mapper;
            _machineBrandDal = machineBrandDal;
        }

        public IEnumerable<MachineBrandListDto> GetAllBrandMachines()
        {
            var result= _machineBrandDal.GetList(c=>c.dil_ID == 1 && c.Durum == true).OrderBy(c=>c.Kategori);
            var brandDtos = _mapper.Map<List<MachineBrandListDto>>(result);




            return new List<MachineBrandListDto>(brandDtos);
        }

       
    }
}