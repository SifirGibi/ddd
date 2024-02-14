using SifirGibiMakina.Dtos.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IMachinePhotoService
    {
        List<GetListPhotoDto> GetListPhotos(int id);
        void CreateMachinePhoto(List<PhotoCreateDto> photoCreateDtos);
    }
}