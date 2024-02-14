using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.MembershipVersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfMembershipVersionDal : EfEntityRepositoryBase<tbl_MembershipVersion, db_SifirGibiMakinaEntities>, IMembershipVersionDal
    {
        public EfMembershipVersionDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }

        public List<ListMembershipVersionDto> GetListMembershipVersion(Expression<Func<MachineShowcaseListDto, bool>> filter = null)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {

                var result = from m in context.tbl_MembershipVersion
                             join ma in context.tbl_Membership
                             on m.MembershipID equals ma.MembershipID


                             where m.IsAvaible == true



                             select new ListMembershipVersionDto
                             {
                              
                                 DisplayOfCompanyLogo = m.DisplayOfCompanyLogo,
                                 MaxAds = m.MaxAds,
                                 MaxDisplayAds = m.MaxDisplayAds,
                                 DiscountPrice = m.DiscountPrice,
                                 MembershipVersion = m.MembershipVersion,
                                 MembershipVersionID = m.MembershipVersionID,
                                 PriceWeekTr = m.PriceWeekTr,
                                 PriceYearTr = m.PriceYearTr,
                                 MembershipName = ma.MembershipName,
                                 MembershipID = ma.MembershipID,
                               





                             };

                return result.ToList();
            }
        }





        public ListMembershipVersionDto GetMembershipVersion(int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {

                var result = (from m in context.tbl_MembershipVersion
                             join ma in context.tbl_Membership
                             on m.MembershipID equals ma.MembershipID


                             where m.IsAvaible == true && m.MembershipVersionID == id



                             select new ListMembershipVersionDto
                             {

                                 DisplayOfCompanyLogo = m.DisplayOfCompanyLogo,
                                 MaxAds = m.MaxAds,
                                 MaxDisplayAds = m.MaxDisplayAds,
                                 DiscountPrice = m.DiscountPrice,
                                 MembershipVersion = m.MembershipVersion,
                                 MembershipVersionID = m.MembershipVersionID,
                                 PriceYearTr = m.PriceYearTr,
                                 PriceWeekTr= m.PriceWeekTr,
                                 MembershipName = ma.MembershipName,
                                 MembershipID = ma.MembershipID,





                             }).FirstOrDefault();

                return result;
            }
        }
    }
}