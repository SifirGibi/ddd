using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.Blog;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.MachineYear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class MachineYearManager : IMachineYearService
    {
        private readonly IMapper _mapper;
        private readonly IMachineYearDal _machineYearDal;

        public MachineYearManager(IMapper mapper, IMachineYearDal machineYearDal)
        {
            _mapper = mapper;
            _machineYearDal = machineYearDal;
        }

      
        public List<MachineYearListDto> GetMachineYearList()
        {
            var result = _machineYearDal.GetList(c=>c.dil_ID == 1 && c.Durum == true).OrderBy(c=>c.Kategori);

            var yearDtos = _mapper.Map<List<MachineYearListDto>>(result);




            return new List<MachineYearListDto>(yearDtos);
        }
    }
}