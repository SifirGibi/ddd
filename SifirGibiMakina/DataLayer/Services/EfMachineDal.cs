using AutoMapper;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Repositories;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.Machine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfMachineDal : EfEntityRepositoryBase<tbl_Makinalar, db_SifirGibiMakinaEntities>, IMachineDal
    {
        public EfMachineDal(db_SifirGibiMakinaEntities context) : base(context)
        {


        }

        public List<MachineShowcaseListDto> GetMachineDetails(Expression<Func<MachineShowcaseListDto, bool>> filter = null)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {

                var result = from m in context.tbl_Makinalar
                             join b in context.tbl_MakinaYillar
                             on m.yil_ID equals b.yil_ID
                             join tu in context.tbl_MakinaTurleri
                             on m.tur_ID equals tu.tur_ID
                             join ma in context.tbl_MakinaMarkalari
                             on m.marka_ID equals ma.marka_ID
                             join md in context.tbl_MachineDetail
                               on m.makina_ID equals md.MachineId into joinedData
                             from detail in joinedData.DefaultIfEmpty()


                             where m.Durum == true
                             && m.dil_ID == 1
                             && m.Yayinda == true



                             select new MachineShowcaseListDto
                             {
                                 makina_ID = m.makina_ID,
                                 Baslik = m.Baslik,
                                 Tur = tu.Kategori,
                                 Marka = ma.Kategori,
                                 Yil = b.Kategori,
                                 Fiyat = m.Fiyat,
                                 Para_Birimi = m.Para_Birimi,
                                 Fotograf = m.Fotograf,
                                 FiyatGosterilmesin = m.FiyatGosterilmesin,
                                 Yayinlanma_Tarihi = m.Yayinlanma_Tarihi,
                                 SEOUrl = m.SEOUrl,
                                 AnaVitrin = m.AnaVitrin,
                                 Ihale = m.Ihale,
                                 Vitrin = m.Vitrin,
                                 tur_ID = m.tur_ID,
                                 Ihale_Bitis = m.Ihale_Bitis,
                                 Kayit_Tarihi = m.Kayit_Tarihi,
                                 Statu = m.Statu,
                                 Alttur_ID = m.Alttur_ID,
                                 Alttur2_ID = m.Alttur2_ID,
                                 marka_ID = m.marka_ID,
                                 SpecificType = detail.SpecificType,




                             };

                return result.ToList();
            }
        }
        public GetMachineDetailListWithIdDto GetMachineIdDetails( int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {

                var result = (from m in context.tbl_Makinalar
                              join b in context.tbl_MakinaYillar
                              on m.yil_ID equals b.yil_ID
                              join tu in context.tbl_MakinaTurleri
                              on m.tur_ID equals tu.tur_ID
                              join A in context.tbl_MakinaAltTurleri
                              on m.Alttur_ID equals A.Alttur_ID

                              join ma in context.tbl_MakinaMarkalari
                              on m.marka_ID equals ma.marka_ID
                              join md in context.tbl_MachineDetail
                                on m.makina_ID equals md.MachineId into joinedData
                              from detail in joinedData.DefaultIfEmpty()

                              where m.Durum == true
                              && m.dil_ID == 1
                              && m.Yayinda == true
                              && (m.Statu == 2 || m.Statu == 4 || m.Statu == 5)
                              && m.makina_ID == id



                              select new GetMachineDetailListWithIdDto
                              {
                                  makina_ID = m.makina_ID,
                                  Baslik = m.Baslik,
                                  Tur = tu.Kategori,
                                  Marka = ma.Kategori,
                                  Yil = b.Kategori,
                                  Fiyat = m.Fiyat,
                                  Para_Birimi = m.Para_Birimi,
                                  Fotograf = m.Fotograf,
                                  FiyatGosterilmesin = m.FiyatGosterilmesin,
                                  Yayinlanma_Tarihi = m.Yayinlanma_Tarihi,
                                  SEOUrl = m.SEOUrl,
                                  AnaVitrin = m.AnaVitrin,
                                  Ihale = m.Ihale,
                                  Vitrin = m.Vitrin,
                                  tur_ID = m.tur_ID,
                                  Ihale_Bitis = m.Ihale_Bitis,
                                  Kayit_Tarihi = m.Kayit_Tarihi,
                                  Statu = m.Statu,
                                  Alttur_ID = m.Alttur_ID,
                                  Alttur2_ID = m.Alttur2_ID,
                                  marka_ID = m.marka_ID,
                                  SpecificType = detail.SpecificType,
                                  Aciklama = m.Aciklama,
                                  SeoKeywords = m.SeoKeywords,
                                  SeoDescription = m.SeoDescription,
                                  Satis_Temsilcisi_Adi = m.Satis_Temsilcisi_Adi,
                                  Satis_Temsilcisi_Email = m.Satis_Temsilcisi_Email,
                                  Satis_Temsilcisi_Telefon = m.Satis_Temsilcisi_Telefon,
                                  Kapora = m.Kapora,
                                  Model = m.Model,
                                  KM = m.KM,
                                  il = m.il,
                                  ilce = m.ilce,
                                  GoruntulenmeSayisi = m.GoruntulenmeSayisi,
                                  IlanNo = m.IlanNo,
                                  Kimden = m.Kimden,
                                  Ekleyen = m.Ekleyen ?? 0,
                                  Ulke = m.Ulke ?? 0,
                                  TelefonNumarasiGostermeSayisi = m.TelefonNumarasiGostermeSayisi,
                                  AltTur = A.Kategori,
                                  Ihale_Baslangic = m.Ihale_Baslangic,
                                  DailyPrice = detail.DailyPrice,
                                  WeeklyPrice = detail.WeeklyPrice,
                                  MonthlyPrice = detail.MonthlyPrice,
                                  Makina_Order = m.Makina_Order ?? 0,
                                  yearID = m.yil_ID ?? null,

                              }).SingleOrDefault();

                return result;
            }
        }
    }
}