using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.İnterfaces
{
    public interface IServiceUsersCategoryDal:IEntityRepository<tbl_ServiceUsersCategory>
    {
       List< UserServıceCategoryDto> GetServiceCategoryWithIdDetails(int id);
    }
}