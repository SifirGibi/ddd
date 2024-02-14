using AutoMapper;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business
{
    public class BlogManager:IBlogService
    {
     
        private readonly IMapper _mapper;
        private readonly IBlogDal _blogRepository;

        public BlogManager(IMapper mapper, IBlogDal blogRepository)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
        }

        public tbl_Duyurular GetBlog(int id)
        {
           return _blogRepository.Get(c => c.dil_ID == 1 && c.cat_ID == id && c.Yayinda == true && c.AnaSayfaYayin == true && c.BuyukBlog == true);
        }

        public List<BlogListDto> GetBlogList(int id)
        {
            var result = _blogRepository.GetList(c => c.dil_ID == 1 && c.cat_ID == id && c.Yayinda == true && c.AnaSayfaYayin == true && c.BuyukBlog == false).OrderByDescending(c=>c.Kayit_Tarihi);
            //var blogDtos = new List<BlogListDto>();

            //// Her bir sosyal medya kaydı için DTO oluşturulup, listeye ekleniyor.
            //foreach (var item in result)
            //{
            //    var dto = new BlogListDto
            //    {
            //       duy_ID = item.duy_ID,
            //       Baslik = item.Baslik,
            //       Icerik = item.Icerik,
            //       Fotograf = item.Fotograf,
            //       Kayit_Tarihi = item.Kayit_Tarihi,
            //       SeoKeywords = item.SeoKeywords,
            //       SeoDescription = item.SeoDescription,    
            //       KisaAciklama = item.KisaAciklama,
            //        SosyalMedyaPaylasim = item.SosyalMedyaPaylasim

            //    };
            //blogDtos.Add(dto);
            //}

            var blogDtos = _mapper.Map<List<BlogListDto>>(result);
            



            return new List<BlogListDto>(blogDtos);
        }
    }
}