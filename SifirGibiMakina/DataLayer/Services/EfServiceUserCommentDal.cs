using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.ServiceComment;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfServiceUserCommentDal : EfEntityRepositoryBase<tbl_ServiceUserComment, db_SifirGibiMakinaEntities>, IServiceUserCommentDal
    {
        public EfServiceUserCommentDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }

        public List<GetListServiceCommentByUserId> GetCommentsByServiceUserID(int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {
                var result = from u in context.tbl_ServiceUserComment
                             join md in context.tbl_FirmaLogolari on u.ServiceCommenterUserID equals md.uye_ID into userDetail
                             from detail in userDetail.DefaultIfEmpty().GroupBy(d => d.uye_ID).Select(g => g.FirstOrDefault())
                             join ds in context.tbl_Uyeler on u.ServiceCommenterUserID equals ds.uye_ID
                             where u.ServiceTargetUserID == id
                             orderby u.CreatedDate descending
                             select new GetListServiceCommentByUserId
                             {
                                 CommenterUserPhoto = detail.Fotograf,
                                 CommenterUserName = ds.Adi + " " + ds.Soyadi,
                                 CommentRating = u.CommentRating ?? 1,
                                 CommentText = u.CommentText,
                                 CommentTime = u.CreatedDate,
                             };

                return result.ToList();


            }
        }


    }

}