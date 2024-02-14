using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public interface IMachineCncDetailService
    {
        List<tbl_MirrorSize> MirrorSizeList();
        List<tbl_ControlUnit> ControlUnitList();
        List<tbl_NumberOfAxes> NumberOfAxesList();
        List<tbl_SpindleRPM> SpindleRPMsList();
        List<tbl_YAxisSize> TurningLenghtList();
    
    }
}