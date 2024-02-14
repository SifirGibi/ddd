using SifirGibiMakina.Dtos.MachineryExpertSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IMachineExpertService
    {
        List<MachineryExpertSelectionByMachineIdDto> GetMachineryExpertSelectionByMachineIds(int machineId);
    }
}