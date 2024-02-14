using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.MembershipVersion
{
    public class MembersVersionWithUserMemberListDto
    {
        public int MembershipVersionID { get; set; }
        public string MembershipVersion { get; set; }
        public Nullable<int> MembershipID { get; set; }
        public Nullable<int> MaxDisplayAds { get; set; }
        public Nullable<int> MaxAds { get; set; }
    }
}