using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Services;
using SifirGibiMakina.Dtos.ServiceCategory;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class ServiceUsersCategoryManager : IServiceUsersCategoryService
    {

        private readonly IServiceUsersCategoryDal _serviceUsersCategoryDal;

        public ServiceUsersCategoryManager(IServiceUsersCategoryDal serviceUsersCategoryDal)
        {
            _serviceUsersCategoryDal = serviceUsersCategoryDal;
        }

        public List<UserServıceCategoryDto> GetServiceCategoryWithIdDetails(int id)
        {
            var serviceUser = _serviceUsersCategoryDal.GetServiceCategoryWithIdDetails(id);

            if(serviceUser != null)
                return serviceUser;

            return new List<UserServıceCategoryDto>();
        }

        public void DeleteUserServiceCategory(int id)
        {

            var userCategory = _serviceUsersCategoryDal.Get(x => x.UserCategoriesID == id);


            _serviceUsersCategoryDal.Delete(userCategory);
            _serviceUsersCategoryDal.SaveChanges();
        }

        public void CreateUserSeriveCategory(CreateServiceCategoryDto model)
        {
            tbl_ServiceUsersCategory serviceUSerCategory = new tbl_ServiceUsersCategory
            {
                
               
               
                
                 SubCategoryID = model.SubCategoryID,
                  CategoryID = model.CategoryID,
                 UserID = model.UserID,  
                CreatedDate = DateTime.Now

            };

            if (model.SubSubCategoryID != 0) { 
            
            serviceUSerCategory.SubSubCategoryID = model.SubSubCategoryID;
            
            }

            _serviceUsersCategoryDal.Add(serviceUSerCategory);
            _serviceUsersCategoryDal.SaveChanges();


        }
    }
}