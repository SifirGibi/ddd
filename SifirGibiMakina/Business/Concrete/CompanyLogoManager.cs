using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.Blog;
using SifirGibiMakina.Dtos.Logo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class CompanyLogoManager:ICompanyLogoService
    {
       
        private readonly IMapper _mapper;
        private readonly ICompanyLogoDal _companyLogoDal;

        public CompanyLogoManager(IMapper mapper, ICompanyLogoDal companyLogoDal)
        {
            _mapper = mapper;
            _companyLogoDal = companyLogoDal;
        }

        public List<CompanyLogoListDto> GetAllLogos(bool status, bool isLive, int languangeId)
        {
            var result = _companyLogoDal.GetList(x => x.Durum == status && x.Yayinda == true && x.dil_ID == languangeId);
            //var mapperDtos = new List<CompanyLogoListDto>();

            //foreach (var item in result)
            //{

            //    var dto = new CompanyLogoListDto
            //    {
            //        logo_ID = item.logo_ID,
            //        Baslik = item.Baslik,
            //        Fotograf = item.Fotograf,
            //        Link = item.Link,
            //        //Siralama = item.Siralama,
            //        uye_ID = item.uye_ID

            //    };
            //    mapperDtos.Add(dto);
            //}
            var mapperDtos = _mapper.Map<List<CompanyLogoListDto>>(result);




            return new List<CompanyLogoListDto>(mapperDtos);
         
        }

        public tbl_FirmaLogolari GetCompanyLogoById(int logoId)
        {
            return _companyLogoDal.Find(logoId);
        }
        
        public tbl_FirmaLogolari GetCompanyLogoByUser(int id)
        {

            return _companyLogoDal.Get(c => c.uye_ID == id && c.Durum == true && c.dil_ID == 1);

        }
    }
}