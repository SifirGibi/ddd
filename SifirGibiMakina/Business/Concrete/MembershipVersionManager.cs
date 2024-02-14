using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.MembershipVersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class MembershipVersionManager : IMembershipVersionService
    {

        private readonly IMembershipVersionDal _membershipVersionDal;

        public MembershipVersionManager(IMembershipVersionDal membershipVersionDal)
        {
            _membershipVersionDal = membershipVersionDal;
        }

        public List<tbl_MembershipVersion> GetList()
        {
           return _membershipVersionDal.GetList().ToList();  
        }

        public List<ListMembershipVersionDto> GetListMembershipVersion()
        {
           var result = _membershipVersionDal.GetListMembershipVersion();

            if (result != null)
            {


                return result;
            }


            return null;
        }


        public ListMembershipVersionDto GetMemberVersion(int id)
        {



            var result = _membershipVersionDal.GetMembershipVersion(id);

            if(result != null)
            {


                return result;
            }

            return null;
        }
    }
}