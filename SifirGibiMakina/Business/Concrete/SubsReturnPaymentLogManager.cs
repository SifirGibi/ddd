using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.SubsReturnPaymentLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class SubsReturnPaymentLogManager : ISubsReturnPaymentLogService
    {
        private readonly IMapper _mapper;
        private readonly ISubsReturnPaymentLogDal _logDal;

        public SubsReturnPaymentLogManager(IMapper mapper, ISubsReturnPaymentLogDal logDal)
        {
            _mapper = mapper;
            _logDal = logDal;
        }

        public void CreateSubsReturnPaymentLog(CreateSubsReturnPaymentLogDto paymentLogDto)
        {
            var log = _mapper.Map<tbl_SubsReturnPaymentLog>(paymentLogDto);

            _logDal.Add(log);
            _logDal.SaveChanges();  
        }
    }
}