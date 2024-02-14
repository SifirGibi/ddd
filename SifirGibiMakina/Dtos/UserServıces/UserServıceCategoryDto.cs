using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.UserServıces
{
    public class UserServıceCategoryDto
    {
        public int UserCategoriesID { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> SubCategoryId { get; set; }
        public Nullable<int> SubSubCategoryId { get; set; }
        public string CategoryName {  get; set; }   
        public string SubCategoryName { get; set; }
        public string SubSubCategoryName { get; set; }

    }
}