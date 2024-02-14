using SifirGibiMakina.Dtos.UserMembership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.İnterfaces
{
    public interface IUserMembershipDal:IEntityRepository<tbl_UserMembership>
    {
        List<UserPaymentListDto> GetPaymentUser(int id);
        UserMembershipListDto GetUserMembership(int userId);
    }
}