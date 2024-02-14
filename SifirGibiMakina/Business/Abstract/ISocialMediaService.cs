using SifirGibiMakina.DataLayer.Repositories;
using SifirGibiMakina.Dtos.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface ISocialMediaService
    {
        List<SocialMediaListDto> GetAllSocialMedias();
    }
}