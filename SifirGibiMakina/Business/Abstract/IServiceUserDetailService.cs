using SifirGibiMakina.Dtos.SerivceDescription;
using SifirGibiMakina.Dtos.ServiceComment;
using SifirGibiMakina.Dtos.ServiceEquipment;
using SifirGibiMakina.Dtos.ServiceUserDetail;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IServiceUserDetailService
    {

        bool isSerivePhotoExists(int id);
        bool isSeriveDescriptionExists(int id);
        void AddServiceUserLogo(CreateServiceUserDetailDto createServiceUserDetailDto);
        void UpdateServiceUserLogo(CreateServiceUserDetailDto updateServiceUserDetailDto);


        List<tbl_ServiceEquipmentDetail> GetlistServiceEquipmentDetail(int id);
        void CreateDespriction(CreateSerivceDescriptionDto createSerivceDescriptionDto);
       void UpdateDespriction(CreateSerivceDescriptionDto createSerivceDescriptionDto);


        void AddEquipment(CreateEquipmentDto createEquipmentDto);


        void DeleteEquipment(int id);

        List<GetListServiceFirmDto> GetListServiceFirm(int id);

        GetServiceUserWithIDDto GetServiceUserWithDetails(int id);


        List<ListServiceUserDto> ListServiceUser();

        int UserCommentAvarge(int id);

        List<GetListServiceCommentByUserId> GetCommentList(int id);
        void AddServiceComment(CreateCommentDto dto);

    }
}