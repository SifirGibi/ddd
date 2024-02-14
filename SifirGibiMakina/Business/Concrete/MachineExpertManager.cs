using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Services;
using SifirGibiMakina.Dtos.MachineryExpertSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class MachineExpertManager: IMachineExpertService
    {

        private readonly IMachineExpertDal _machineExpertDal;

        public MachineExpertManager(IMachineExpertDal machineExpertDal)
        {
            _machineExpertDal = machineExpertDal;
        }

        public List<MachineryExpertSelectionByMachineIdDto> GetMachineryExpertSelectionByMachineIds(int machineId)
        {
            return _machineExpertDal.GetListMachineryExpertSelectionByMachineID(machineId);
        }
    }
}