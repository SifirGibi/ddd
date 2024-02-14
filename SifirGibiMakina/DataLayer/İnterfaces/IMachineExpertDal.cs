using SifirGibiMakina.Dtos.MachineryExpertSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.İnterfaces
{
    public interface IMachineExpertDal:IEntityRepository<tbl_MakinaEksperSecimi>
    {
        List<MachineryExpertSelectionByMachineIdDto> GetListMachineryExpertSelectionByMachineID(int id);
    }
}