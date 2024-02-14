using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.ServiceExpertiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfServiceExpertizDal : EfEntityRepositoryBase<tbl_Expertiz, db_SifirGibiMakinaEntities>, IServiceExpertizDal
    {
        public EfServiceExpertizDal(db_SifirGibiMakinaEntities context) : base(context)
        {
            
        }
        public List<ListOfUsersRequestingServiceByIdDto> ListOfUsersRequestingServiceById(int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {

                var result = from s in context.tbl_Expertiz
                             join c in context.tbl_MakinaTurleri
                             on s.tur_ID equals c.tur_ID
                             join sc in context.tbl_MakinaAltTurleri
                             on s.Alttur_ID equals sc.Alttur_ID
                             join b in context.tbl_MakinaMarkalari
                             on s.marka_ID equals b.marka_ID
                             join y in context.tbl_MakinaYillar
                             on s.yil_ID equals y.yil_ID
                           



                             where s.ExpertizFirmasi_ID == id orderby s.Kayit_Tarihi descending



                             select new ListOfUsersRequestingServiceByIdDto
                             {
                                 SubCategoryNameRequestingService = sc.Kategori,
                                 CategoryNameRequestingService = c.Kategori,
                                 MachineBrandNameRequestingService = b.Kategori,
                                 MachineYearRequestingService = y.Kategori ?? 0,
                                 MachineTitleRequestingService = s.Baslik,
                                 ScheduledDate = s.Randevu_Tarihi,
                                 CreatedDate = s.Kayit_Tarihi,
                                 ExpertizID = s.expertiz_ID ,
                                 UserEmailRequestingService = s.EMail ,
                                 UserNameRequestingService = s.Adi + " " + s.Soyadi,
                                 UserIdRequestingService = s.uye_ID ?? 0 ,
                                 Durum = s.Durum,
                                 Yanit = s.Yanit,
                                 







                             };

                return result.ToList();
            }
        }
    }
}