using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.MembershipVersion
{
    public class ListMembershipVersionDto
    {

        public int MembershipVersionID { get; set; }
        public int MembershipID { get; set; }
        public string MembershipVersion { get; set; }
     
        public Nullable<int> MaxDisplayAds { get; set; }
        public Nullable<int> MaxAds { get; set; }
        public Nullable<bool> DisplayOfCompanyLogo { get; set; }

        public Nullable<int> PriceYearTr { get; set; }
        public Nullable<int> PriceWeekTr { get; set; }
        public string MembershipName { get; set; }

        public Nullable<int> DiscountPrice { get; set; }


      
    }
}