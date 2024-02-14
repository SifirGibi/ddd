using SifirGibiMakina.Dtos.MachineBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IMachineBrandService
    {
        IEnumerable<MachineBrandListDto> GetAllBrandMachines();
    }
}
