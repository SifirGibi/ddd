using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.PaymentLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class PaymentLogManager : IPaymentLogService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentLogDal _logDal;

        public PaymentLogManager(IMapper mapper, IPaymentLogDal logDal)
        {
            _mapper = mapper;
            _logDal = logDal;
        }

        public void CreatePaymentog(CreatePaymentLogDto logDto)
        {
            var mapper = _mapper.Map<tbl_PaymentLog>(logDto);

            _logDal.Add(mapper);
            _logDal.SaveChanges();
        }
    }
}