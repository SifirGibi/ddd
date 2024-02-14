using SifirGibiMakina.Dtos.ServiceComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.İnterfaces
{
    public interface IServiceUserCommentDal:IEntityRepository<tbl_ServiceUserComment>
    {
        List<GetListServiceCommentByUserId> GetCommentsByServiceUserID(int id);
    }
}