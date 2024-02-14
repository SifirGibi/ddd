using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.User;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        

        public tbl_Uyeler GetUser(int id)
        {
            return _userDal.Get(c=>c.uye_ID == id);
        }

        public void Update(UpdateUserDto updateUserDto)
        {
            var user = _userDal.Get(x => x.uye_ID == updateUserDto.Id);

            if (user != null)
            {


                user.FirmaAdi = updateUserDto.FirmaAdi;
                user.Adi = updateUserDto.Adi;
                user.Soyadi = updateUserDto.Soyadi;
                user.Telefon = updateUserDto.Telefon;
                user.Adres = updateUserDto.Adres;
                user.Ulke = updateUserDto.Ulke;
                user.CountryID = Convert.ToInt32(updateUserDto.CountryID);
                user.Il = updateUserDto.Il;
                user.Ilce = updateUserDto.Ilce;
                user.Sifre = updateUserDto.Sifre;
                user.TCK = updateUserDto.TCK;
                user.DogumTarihi = updateUserDto.DogumTarihi;


              

                _userDal.Update(user);
                _userDal.SaveChanges();





            }
        }

        public GetUserWithDetailsDto GetUserWithDEtails(int id)
        {





           return _userDal.GetUserWithDetails(id);

           
        }
      
    }
}