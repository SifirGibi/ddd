using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.MembershipVersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SifirGibiMakina.DataLayer.İnterfaces
{
    public interface IMembershipVersionDal:IEntityRepository<tbl_MembershipVersion>
    {
        List<ListMembershipVersionDto> GetListMembershipVersion(Expression<Func<MachineShowcaseListDto, bool>> filter = null);
        ListMembershipVersionDto GetMembershipVersion(int id);
    }
}