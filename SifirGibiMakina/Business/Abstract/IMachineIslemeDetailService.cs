using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IMachineIslemeDetailService
    {

         List<tbl_ControlUnit> ControlUnitList();
        List<tbl_NumberOfAxes> NumberOfAxesList();
        List<tbl_SpindleRPM> SpindleRPMsList();
        List<tbl_XAxisSize> XAxisSizeList();
        List<tbl_YAxisSize> YAxisSizeList();
        List<tbl_NumberOfTables> NumberOfTablesList();
    }
}