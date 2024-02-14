using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Services;
using SifirGibiMakina.Dtos.Expert;
using SifirGibiMakina.Dtos.MachineryExpertSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class ExperManager : IExpertService
    {
        private readonly IMapper _mapper;
        private readonly IExpertDal _expertDal;

        public ExperManager(IMapper mapper, IExpertDal expertDal)
        {
       
                _mapper = mapper;
           _expertDal = expertDal;
        }

        public List<ExpertListDto> ExpertList()
        {
            var result = _expertDal.GetList();
            var expertDtos = _mapper.Map<List<ExpertListDto>>(result);




            return new List<ExpertListDto>(expertDtos);
        }
        
    }
}