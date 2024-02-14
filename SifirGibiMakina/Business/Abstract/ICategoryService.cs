using SifirGibiMakina.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface ICategoryService
    {
        List<CategoryListDto> GetCategoriesWithSubcategories();
    }
}