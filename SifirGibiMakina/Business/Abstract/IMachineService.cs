using SifirGibiMakina.Dtos.Blog;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IMachineService
    {
        List<MachineShowcaseListDto>    GetMachineList();
        GetMachineDetailListWithIdDto GetMachineWithIdDetails(int id);
        int CreateMachine(MachineCreateDto machineCreateDto);
        bool machineGetUrls(string url);
        CheckCountModel GetNoticeCount(int id);
        tbl_Makinalar GetMachine(int id);
        int GetIdBySeoUrl(string seoUrl);
        void IncreaseFavoriteCount(int machineId);
        void IncreaseVisiblePhoneCount(int machineId);
        void ReduceFavoriteCount(int machineId);
        int FavoriteCount(int machineId);
        void IncreaseViewMachineCount(int machineId);


    }
}