using SifirGibiMakina.Dtos.SubsReturnPaymentLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface ISubsReturnPaymentLogService
    {
        void CreateSubsReturnPaymentLog(CreateSubsReturnPaymentLogDto paymentLogDto);
    }
}