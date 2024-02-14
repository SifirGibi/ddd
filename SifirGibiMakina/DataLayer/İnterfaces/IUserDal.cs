using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.ServiceUserDetail;
using SifirGibiMakina.Dtos.User;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SifirGibiMakina.DataLayer.İnterfaces
{
    public interface IUserDal:IEntityRepository<tbl_Uyeler>
    {
        GetUserWithDetailsDto GetUserWithDetails(int id);
        GetServiceUserWithIDDto GetServiceUserWithDetails(int id);
       List< GetListServiceFirmDto> GetListServiceFirm(int id);
        List<ListServiceUserDto> ListServiceUser(Expression<Func<ListServiceUserDto, bool>> filter = null);
    }
}