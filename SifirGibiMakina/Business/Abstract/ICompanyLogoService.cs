using SifirGibiMakina.Dtos.Logo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface ICompanyLogoService
    {
        List<CompanyLogoListDto> GetAllLogos(bool status, bool isLive, int languangeId);
        tbl_FirmaLogolari GetCompanyLogoById(int logoId);
        tbl_FirmaLogolari GetCompanyLogoByUser(int id);
    }
}