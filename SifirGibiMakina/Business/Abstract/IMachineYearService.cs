using SifirGibiMakina.Dtos.MachineYear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IMachineYearService
    {
        List<MachineYearListDto> GetMachineYearList();
    }
}