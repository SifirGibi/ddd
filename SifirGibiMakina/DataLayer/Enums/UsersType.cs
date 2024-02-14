using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Enums
{
    public enum UsersType
    {
        [Description("Bireysel Üyelik")]
        Individual = 1,
        [Description("Kurumsal Üyelik")]
        Institutional = 2,
        [Description("Servis Firması Üyeliği")]
        Service = 3,
    }
}