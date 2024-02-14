using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.UserMembership
{
    public class CreateUserMemberShipDto
    {

        public int UserID { get; set; }
        public int MembershipID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Nullable<DateTime> EndDate { get; set; } 

        public Nullable<int> PaymentPlanID { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPaid { get; set; }

    }
}