using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.User;
using SifirGibiMakina.Dtos.UserMembership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfUserMembershipDal : EfEntityRepositoryBase<tbl_UserMembership, db_SifirGibiMakinaEntities>, IUserMembershipDal
    {
        public EfUserMembershipDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }

        public List<UserPaymentListDto> GetPaymentUser(int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {
                var result = (from um in context.tbl_UserMembership
                              join md in context.tbl_MembershipVersion
                              on um.MembershipID equals md.MembershipVersionID

                              join ds in context.tbl_Membership
                              on md.MembershipID equals ds.MembershipID
                              join co in context.tbl_PaymentPlan on um.PaymentPlanID equals co.PaymentPlanID into payment
                              from paymentPan in payment.DefaultIfEmpty()

                              where um.UserID == id

                              select new UserPaymentListDto
                              {
                                  IsActive = um.IsActive,
                                  MaxAds = md.MaxAds,
                                  CreatedDate = um.CreatedDate,
                                  IsPaid = um.IsPaid,
                                  MembershipName = ds.MembershipName,
                                  MembershipVersion = md.MembershipVersion,
                                  PaymentPlanName = paymentPan.PaymentPlanName ?? " ",
                                  UserID = um.UserID,
                                  MembershipID = um.MembershipID,



                              }).ToList();

                return result;
            }
        }

        public UserMembershipListDto GetUserMembership(int userId)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {

                var result = (from um in context.tbl_UserMembership
                              join md in context.tbl_MembershipVersion
                              on um.MembershipID equals md.MembershipVersionID

                              where um.UserID == userId && um.IsActive == true

                              select new UserMembershipListDto
                              {
                                  UserID = um.UserID,
                                  MembershipID= um.MembershipID,    
                                  MembershipVersion= md.MembershipVersion,
                                  MembershipVersionID= md.MembershipVersionID,  
                                  MaxAds= md.MaxAds,
                                  IsActive = um.IsActive,   
                                  CreatedDate = um.CreatedDate,

                              }).SingleOrDefault();

                return result;

             }

        }

    }
}