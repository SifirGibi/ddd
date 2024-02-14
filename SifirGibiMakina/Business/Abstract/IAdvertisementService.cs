using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IAdvertisementService
    {
        tbl_Reklamlar GetAdvertisement(int id);
    }
}