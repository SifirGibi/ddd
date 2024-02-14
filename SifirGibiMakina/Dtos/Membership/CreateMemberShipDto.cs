using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Membership
{
    public class CreateMemberShipDto
    {
   
        public string MembershipName { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
    }
}