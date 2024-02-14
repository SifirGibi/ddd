using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfServiceUsersCategoryDal : EfEntityRepositoryBase<tbl_ServiceUsersCategory, db_SifirGibiMakinaEntities>, IServiceUsersCategoryDal
    {
        public EfServiceUsersCategoryDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }

        public List<UserServıceCategoryDto> GetServiceCategoryWithIdDetails(int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {

                var result = from m in context.tbl_ServiceUsersCategory
                             join b in context.tbl_MakinaTurleri
                             on m.CategoryID equals b.tur_ID
                             join tu in context.tbl_MakinaAltTurleri
                             on m.SubCategoryID equals tu.Alttur_ID
                             join ma in context.tbl_MakinaAltTurleri2 on m.SubSubCategoryID equals ma.Alttur2_ID into subSubCategoryJoin
                             from ma in subSubCategoryJoin.DefaultIfEmpty()


                             where m.UserID == id



                             select new UserServıceCategoryDto
                             {
                                 UserCategoriesID = m.UserCategoriesID,
                                 CategoryId = m.CategoryID,
                                 SubCategoryId = m.SubCategoryID,
                                 SubSubCategoryId = m.SubSubCategoryID,
                                 CategoryName = b.Kategori,
                                 SubCategoryName = tu.Kategori,
                                 SubSubCategoryName = ma.Kategori ?? "-"






                             };

                return result.ToList();
            }
        }
    }
}