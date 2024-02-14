using Microsoft.AspNet.SignalR.Hubs;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.ServiceUserDetail;
using SifirGibiMakina.Dtos.User;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services.Description;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfUserDal : EfEntityRepositoryBase<tbl_Uyeler, db_SifirGibiMakinaEntities>, IUserDal
    {
        public EfUserDal(db_SifirGibiMakinaEntities context) : base(context)
        {


        }

        public GetUserWithDetailsDto GetUserWithDetails(int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {
                var result = (from u in context.tbl_Uyeler
                              join md in context.tbl_ServiceUserDetail on u.uye_ID equals md.ServiceUserID into userDetail
                              from detail in userDetail.DefaultIfEmpty()
                              join ds in context.tbl_ServiceDescription on u.uye_ID equals ds.ServiceUserID into serviceDescription
                from description in serviceDescription.DefaultIfEmpty()
                              join co in context.tbl_Ulkeler on u.CountryID equals co.id into countries
                              from county in countries.DefaultIfEmpty()
                              where u.uye_ID == id
                              select new GetUserWithDetailsDto
                              {
                                   Adi = u.Adi,
                                  Soyadi = u.Soyadi,
                                  EMail = u.EMail,
                                  Ulke = u.Ulke,
                                  Adres = u.Adres,
                                  CountryID = u.CountryID,
                                  Il = u.Il,    
                                  Ilce = u.Ilce,
                                  TCK = u.TCK,  
                                  Sifre = u.Sifre,
                                  FirmaAdi = u.FirmaAdi,
                                  Telefon = u.Telefon,  
                                  Hesap_Turu = u.Hesap_Turu,
                                  DogumTarihi = u.DogumTarihi,  
                                  ServiceDescriptionTr = description.ServiceDescriptionTr,
                                  ServiceUserBigLogo = detail.ServiceUserBigLogo,
                                  ServiceUserLogo = detail.ServiceUserLogo,
                                  CountryName = county.nicename 

                              }).SingleOrDefault();

                return result;
            }
        }
        

        public GetServiceUserWithIDDto GetServiceUserWithDetails(int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {
                var result = (from u in context.tbl_Uyeler
                              join md in context.tbl_ServiceUserDetail on u.uye_ID equals md.ServiceUserID into userDetail
                              from detail in userDetail.DefaultIfEmpty()
                              join ds in context.tbl_ServiceDescription on u.uye_ID equals ds.ServiceUserID into serviceDescription
                              from description in serviceDescription.DefaultIfEmpty()
                              join co in context.tbl_Ulkeler on u.CountryID equals co.id 
                              where u.uye_ID == id
                              select new GetServiceUserWithIDDto
                              {
                                  ServiceFirmName = u.FirmaAdi ?? ""    ,
                                  Adress = u.Adres ?? "",
                                  CountryName = co.nicename ?? "",
                                  Description = description.ServiceDescriptionTr ?? "",
                                  BigLogo = detail.ServiceUserBigLogo ?? "",
                                  EmailAdress = u.EMail ?? "",
                                  
                              }).SingleOrDefault();

                return result;
            }
        }
        

        public List<GetListServiceFirmDto> GetListServiceFirm(int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {
                var result = from u in context.tbl_Uyeler
                             join md in context.tbl_ServiceUserDetail on u.uye_ID equals md.ServiceUserID into userDetail
                             from detail in userDetail.DefaultIfEmpty()
                             join ds in context.tbl_ServiceDescription on u.uye_ID equals ds.ServiceUserID into serviceDescription
                             from description in serviceDescription.DefaultIfEmpty()
                             join cat in context.tbl_ServiceUsersCategory on u.uye_ID equals cat.UserID

                             where u.Hesap_Turu == "3" && (cat.SubCategoryID == id || cat.SubSubCategoryID == id)

                             select new GetListServiceFirmDto
                             {
                                 FirmDescription = description.ServiceDescriptionTr ?? "",
                                 FirmName = u.FirmaAdi,
                                 uye_ID = u.uye_ID,
                                 FirmLogo = detail.ServiceUserBigLogo,
                                 Address = u.Adres ?? "",
                                 SubCategoryID = cat.SubCategoryID,
                                 SubSubCategoryID = cat.SubSubCategoryID
                             };

                return result.ToList();

            }
        }



        public List<ListServiceUserDto> ListServiceUser(Expression<Func<ListServiceUserDto, bool>> filter = null)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {
                var result = from u in context.tbl_Uyeler
                             join md in context.tbl_ServiceUserDetail on u.uye_ID equals md.ServiceUserID into userDetail
                             from detail in userDetail.DefaultIfEmpty().GroupBy(d => d.ServiceUserID).Select(g => g.FirstOrDefault())

                             join cat in context.tbl_ServiceUsersCategory on u.uye_ID equals cat.UserID into userCategory
                             from category in userCategory.DefaultIfEmpty().GroupBy(d=>d.UserID).Select(g => g.FirstOrDefault())
                             join co in context.tbl_ServiceWorkZone on u.uye_ID equals co.ServiceUserID into userWorkZone
                             from countries in userWorkZone.DefaultIfEmpty().GroupBy(a=>a.ServiceUserID).Select(g => g.FirstOrDefault())

                             where u.Hesap_Turu == "3" && !string.IsNullOrEmpty(u.FirmaAdi)

                             select new ListServiceUserDto
                             {
                                
                                 FirmName = u.FirmaAdi,
                                 ServiceUserID = u.uye_ID,
                              
                                 Address = u.Adres ?? "",
                                 Email = u.EMail,
                                 CategoryID = category.CategoryID,
                                 SubCategoryID = category.SubCategoryID,
                                 CountryID = countries.ServiceWorkZonceCountyID
            

                             };

                return result.ToList();

            }
        }
    }
}