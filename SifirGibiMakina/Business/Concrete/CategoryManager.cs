using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
      
        private readonly IMapper _mapper;
        private readonly ICategoryDal _categoryDal;
        private readonly ISubCategoryDal _subCategoryDal;
        private readonly ISubSubCategoryDal _subSubCategoryDal;
        public CategoryManager(IMapper mapper, ICategoryDal categoryDal, ISubCategoryDal subCategoryDal, ISubSubCategoryDal subSubCategoryDal)
        {
            _mapper = mapper;
            _categoryDal = categoryDal;
            _subCategoryDal = subCategoryDal;
            _subSubCategoryDal = subSubCategoryDal;
        }

        public List<CategoryListDto> GetCategoriesWithSubcategories()
        {
            //var categories = _categoryDal.GetList(c => c.Durum == true);
            //var categoryListWithSubs = new List<CategoryListDto>();

            //foreach (var category in categories)
            //{
            //    var subCategories = _subCategoryDal.GetList(sub => sub.tur_ID == category.tur_ID && sub.dil_ID == 1)
            //                                       .ToList();

            //    //// Create a new list for sub-subcategories for each subcategory
            //    //var allSubSubCategories = new List<tbl_MakinaAltTurleri2>();

            //    foreach (var subCategory in subCategories)
            //    {
            //        // Retrieve sub-subcategories for each subcategory
            //        var subSubCategories = _subSubCategoryDal.GetList(ssc => ssc.Alttur_ID == subCategory.tur_ID)
            //                                                 .ToList();

            //        //allSubSubCategories.AddRange(subSubCategories); // Collecting all sub-subcategories
            //        foreach (var subcategory in subCategories)
            //        {
            //            // Assuming the subcategory has an ID property that can be used to find its sub-subcategories
            //            subcategory.tbl_MakinaAltTurleri2s = _subSubCategoryDal.GetList(ssc => ssc.Alttur2_ID == subcategory.tur_ID).ToList();

            //            subCategory.tbl_MakinaAltTurleri2s = subSubCategories;
            //        }
            //    }

            //    categoryListWithSubs.Add(new CategoryListDto
            //    {
            //        tur_ID = category.tur_ID,
            //        Kategori = category.Kategori,
            //        Resim = category.Resim,
            //        Vitrin = category.Vitrin,
            //        tbl_MakinaAltTurleris = subCategories,
            //        //tbl_MakinaAlt2Turleris = allSubSubCategories
            //    });
            //}

            //return categoryListWithSubs;


            var categories = _categoryDal.GetList(c => c.Durum == true);
            var categoryListWithSubs = new List<CategoryListDto>();

            foreach (var category in categories)
            {
                var subCategories = _subCategoryDal.GetList(sub => sub.tur_ID == category.tur_ID && sub.dil_ID == 1)
                                                   .ToList();

                foreach (var subCategory in subCategories)
                {
                    var subSubCategories = _subSubCategoryDal.GetList(ssc => ssc.Alttur_ID == subCategory.Alttur_ID)
                                                             .ToList();

                    subCategory.tbl_MakinaAltTurleri2s = subSubCategories; // Assign sub-sub-categories to subcategory
                }

                var categoryWithSubs = new CategoryListDto
                {
                    tur_ID = category.tur_ID,
                    Kategori = category.Kategori,
                    Resim = category.Resim,
                    Vitrin = category.Vitrin,
                    tbl_MakinaAltTurleris = subCategories
                };

                categoryListWithSubs.Add(categoryWithSubs);
            }

            return categoryListWithSubs;
        }
    }
}