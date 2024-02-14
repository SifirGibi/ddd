using SifirGibiMakina.Dtos.ServiceExpertiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.İnterfaces
{
    public interface IServiceExpertizDal:IEntityRepository<tbl_Expertiz>
    {
        List<ListOfUsersRequestingServiceByIdDto> ListOfUsersRequestingServiceById(int id);
    }
}