using SifirGibiMakina.Dtos.UserMembership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IUserMemberShipService
    {
        UserMembershipListDto GetUserMembershipById(int userId);

        void CreateMemberShip(CreateUserMemberShipDto createMemberShipDto);
        List<UserPaymentListDto> GetListUserPaymentByID(int id);
        void ChangeIsActive(int userMemberId);
        tbl_UserMembership GetByDateMemberShip(int id);
        bool UpdateMembership(UpdateUserMemberShipDto member);
    }
}