using SifirGibiMakina.Dtos.MembershipVersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IMembershipVersionService
    {
        List<ListMembershipVersionDto> GetListMembershipVersion();

        List<tbl_MembershipVersion> GetList();
        ListMembershipVersionDto GetMemberVersion(int id);
    }
}