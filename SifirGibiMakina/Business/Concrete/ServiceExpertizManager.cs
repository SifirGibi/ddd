using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.ServiceExpertiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class ServiceExpertizManager : IServiceExpertizService
    {
        private readonly IServiceExpertizDal _serviceExpertizDal;
        private readonly IMapper _mapper;

        public ServiceExpertizManager(IServiceExpertizDal serviceExpertizDal, IMapper mapper)
        {
            _serviceExpertizDal = serviceExpertizDal;
            _mapper = mapper;
        }

        public void CreateServiceExpertiz(CreateServiceExpertizDto serviceExpertizDto)
        {

            var expertizEntity = _mapper.Map<tbl_Expertiz>(serviceExpertizDto);

            _serviceExpertizDal.Add(expertizEntity);
            _serviceExpertizDal.SaveChanges();

        }

        public List<ListOfUsersRequestingServiceByIdDto> ListOfUsersRequestingServiceById(int id)
        {
           var result  = _serviceExpertizDal.ListOfUsersRequestingServiceById(id);

            if(result != null)
            {
                return result.ToList();

            }

            return null;    
        }

        public void ChangeStatus(int ServiceExpertizId , bool status)
        {
            var result = _serviceExpertizDal.Find(ServiceExpertizId);

            if(result != null)
            {

                result.Durum = status;
                _serviceExpertizDal.SaveChanges();
            }

        }


        public void CancelTheAppointment(int ServiceExpertizId, bool status)
        {
            var result = _serviceExpertizDal.Find(ServiceExpertizId);

            if (result != null)
            {

                result.Yanit = status;
                _serviceExpertizDal.SaveChanges();
            }

        }
    }
}