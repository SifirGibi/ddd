using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Services;
using SifirGibiMakina.Dtos.Favorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class FavoriteManager:IFavoriteService
    {
        private readonly IFavoriteDal _favoriteDal;
        private readonly IMapper _mapper;

        public FavoriteManager(IFavoriteDal favoriteDal, IMapper mapper)
        {
            _favoriteDal = favoriteDal;
            _mapper = mapper;
        }

        public void AddFavorite(CreateFavoriteDto createFavoriteDto)
        {
            var favoriteEntity = _mapper.Map<tbl_ilanFavorileri>(createFavoriteDto);
            _favoriteDal.Add(favoriteEntity);
            _favoriteDal.SaveChanges();
        }

        public bool IsMachineFavorite(int machineId , int id)
        {
            return _favoriteDal.GetAny(c=>c.user_ID == id && c.makina_ID == machineId);
        }

        public void DeleteFavorite(int machineId, int Userid)
        {
            var result = _favoriteDal.Get(c=>c.makina_ID == machineId && c.user_ID == Userid);

            _favoriteDal.Delete(result);
            _favoriteDal.SaveChanges();

        }
    }
}