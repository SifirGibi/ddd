using SifirGibiMakina.Dtos.ServiceExpertiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IServiceExpertizService
    {
        void CreateServiceExpertiz(CreateServiceExpertizDto serviceExpertizDto);
        List<ListOfUsersRequestingServiceByIdDto> ListOfUsersRequestingServiceById(int id);

        void ChangeStatus(int ServiceExpertizId, bool status);
        void CancelTheAppointment(int ServiceExpertizId, bool status);
    }
}