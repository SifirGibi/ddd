using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class MachinePhotoManager : IMachinePhotoService
    {
        private readonly IMachinePhotoDal _machinePhotoDal;
        private readonly IMapper _mapper;
        public MachinePhotoManager(IMachinePhotoDal machinePhotoDal, IMapper mapper)
        {
            _machinePhotoDal = machinePhotoDal;
            _mapper = mapper;
        }

        public List<GetListPhotoDto> GetListPhotos(int id)
        {
            var result = _machinePhotoDal.GetList(c => c.Durum == true && c.Vitrin == true && c.makina_ID == id);
            var photoDtos = _mapper.Map<List<GetListPhotoDto>>(result);




            return new List<GetListPhotoDto>(photoDtos);
        }

        public void CreateMachinePhoto(List<PhotoCreateDto> photoCreateDtos)
        {


            foreach (var photoCreateDto in photoCreateDtos)
            {

               var createdPhoto = _mapper.Map<tbl_MakinaResimler>(photoCreateDto);


                _machinePhotoDal.Add(createdPhoto);
                _machinePhotoDal.SaveChanges();


            }


        }
    }
}