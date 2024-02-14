using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.Blog;
using SifirGibiMakina.Dtos.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class SocialMediaManager:ISocialMediaService
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(IMapper mapper, ISocialMediaDal socialMediaDal)
        {
            _mapper = mapper;
            _socialMediaDal = socialMediaDal;
        }

        public List<SocialMediaListDto> GetAllSocialMedias()
        {
            var result = _socialMediaDal.GetList(x => x.dil_ID == 1);
            //var socialMediaDtos = new List<SocialMediaListDto>();

            //// Her bir sosyal medya kaydı için DTO oluşturulup, listeye ekleniyor.
            //foreach (var sm in result)
            //{
            //    var dto = new SocialMediaListDto
            //    {
            //        Baslik = sm.Baslik,
            //        FontAwasome = sm.FontAwasome,
            //        Resim = sm.Resim,
            //        Link = sm.Link,
            //        Siralama = sm.Siralama
            //    };
            //    socialMediaDtos.Add(dto);
            //}
            var socialMediaDtos = _mapper.Map<List<SocialMediaListDto>>(result);




            return new List<SocialMediaListDto>(socialMediaDtos);

           

        }
    }
}