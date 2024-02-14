using SifirGibiMakina.Dtos.User;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IUserService
    {
        tbl_Uyeler GetUser(int id);
        void Update(UpdateUserDto updateUserDto);
        GetUserWithDetailsDto GetUserWithDEtails(int id);


     


    }
}