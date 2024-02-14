using SifirGibiMakina.DataLayer.Repositories;
using SifirGibiMakina.Dtos.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SifirGibiMakina.DataLayer.İnterfaces
{
    public interface IMachineDal : IEntityRepository<tbl_Makinalar>
    {
        List<MachineShowcaseListDto> GetMachineDetails(Expression<Func<MachineShowcaseListDto, bool>> filter = null);
        GetMachineDetailListWithIdDto GetMachineIdDetails(int id);

    }
}