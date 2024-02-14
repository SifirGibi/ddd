using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Enums
{
    public enum MachineStatus
    {
        [Description("Satılık")]
        Sale = 1,
        [Description("Kiralık")]
        Rent = 2,
      

    }
}