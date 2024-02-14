using SifirGibiMakina.Dtos.MembershipVersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.UserMembership
{
    public class UserMembershipListDto
    {
        public Nullable<int> UserID { get; set; }

        public Nullable<int> MembershipID { get; set; }

        public Nullable<bool> IsActive { get; set; }

        public Nullable<int> MaxAds { get; set; }
        public int MembershipVersionID { get; set; }
        public string MembershipVersion { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }


    }
}