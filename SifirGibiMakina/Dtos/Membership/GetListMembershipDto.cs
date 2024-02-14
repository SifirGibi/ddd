using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Membership
{
    public class GetListMembershipDto
    {
        public string MembershipName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}