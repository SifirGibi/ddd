using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.ServiceCategory
{
    public class CreateServiceCategoryDto
    {
        public int UserID { get; set; }
        public int CategoryID {  get; set; }   
        public int SubCategoryID {  get; set; }   
        public int SubSubCategoryID {  get; set; }   

    }
}