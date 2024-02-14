using SifirGibiMakina.Dtos.ServiceCategory;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IServiceUsersCategoryService
    {
        List<UserServıceCategoryDto> GetServiceCategoryWithIdDetails(int id);
        void DeleteUserServiceCategory(int id);
        void CreateUserSeriveCategory(CreateServiceCategoryDto model);
    }
}