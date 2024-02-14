using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.SerivceDescription
{
    public class CreateSerivceDescriptionDto
    {
        public string ServiceDescriptionTr { get; set; }
        public string ServiceDescriptionEng { get; set; }
        public string ServiceDescriptionDe { get; set; }
        public string ServiceDescriptionRu { get; set; }
        public int ServiceUserID { get; set; }
    }
}