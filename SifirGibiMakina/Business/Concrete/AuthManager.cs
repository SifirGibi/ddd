using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.Business.DependencyResolvers;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Services;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.User;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly IServiceUsersCategoryDal _serviceUsersCategoryDal;
        private readonly IServiceWorkZoneDal _workZoneDal;

        public AuthManager(IUserDal userDal, IServiceUsersCategoryDal serviceUsersCategoryDal, IServiceWorkZoneDal workZoneDal)
        {
            _userDal = userDal;
            _serviceUsersCategoryDal = serviceUsersCategoryDal;
            _workZoneDal = workZoneDal;
        }

        public int CreateAccount(CreateUserDto createUserDto)
        {
           

            UserExists(createUserDto.EMail, createUserDto.Telefon);



            tbl_Uyeler account = new tbl_Uyeler
            {
                Adi = createUserDto.Adi,
                Soyadi = createUserDto.Soyadi,
                EMail = createUserDto.EMail,
                Hesap_Turu = createUserDto.Hesap_Turu,
                Cinsiyet = createUserDto.Cinsiyet,
                Sifre = createUserDto.Sifre,
                Telefon = createUserDto.Telefon,
                IP = createUserDto.IP,
                Il = createUserDto.Il,
                FirmaAdi = createUserDto.FirmaAdi,
                KayitOlunanSite = createUserDto.KayitOlunanSite,
                CountryID = createUserDto.CountryID,
                Durum = true,
                Kayit_Tarihi = DateTime.Now,
                Aktif = true,
                Ulke = createUserDto.Ulke
                
                
            };


            _userDal.Add(account);
            _userDal.SaveChanges();
                var id = account.uye_ID;

             

                return id;
        }
            

        

       
        private void UserExists(string email,string phone) // bool yerine void
        {
            if (_userDal.GetAny(x => x.EMail == email) || _userDal.GetAny(x => x.Telefon == phone))
            {
                throw new UserExistsException("Kullanıcı zaten mevcut. Lütfen farklı bir e-posta veya telefon numarası kullanın.");
            }

        
        }

        
       
    }
}