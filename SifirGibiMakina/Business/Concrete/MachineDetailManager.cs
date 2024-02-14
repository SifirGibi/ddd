using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.MachineDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class MachineDetailManager : IMachineDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMachineDetailDal _machineDetailDal;

        public MachineDetailManager(IMapper mapper, IMachineDetailDal machineDetailDal)
        {
            _mapper = mapper;
            _machineDetailDal = machineDetailDal;
        }

        public void CreateMAchineDetail(MachineDetailCreateDto createDto)
        {
            var cretedMachineDetail = _mapper.Map<tbl_MachineDetail>(createDto);

            _machineDetailDal.Add(cretedMachineDetail);
            _machineDetailDal.SaveChanges();
        }
    }
}