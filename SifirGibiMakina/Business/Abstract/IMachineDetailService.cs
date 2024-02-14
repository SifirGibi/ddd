using SifirGibiMakina.Dtos.MachineDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IMachineDetailService
    {
        void CreateMAchineDetail(MachineDetailCreateDto createDto);
    }
}