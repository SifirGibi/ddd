using SifirGibiMakina.Dtos.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IMembershipService
    {
        List<GetListMembershipDto> ListMembership();
        void CreateMembership(CreateMemberShipDto createMemberShipDto);
    }
}