using SifirGibiMakina.Dtos.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IAuthService
    {
        int CreateAccount(CreateUserDto createUserDto);
    }
}