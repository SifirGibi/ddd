using SifirGibiMakina.Dtos.Favorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IFavoriteService
    {
        bool IsMachineFavorite(int machineId , int 
            id);
        void AddFavorite(CreateFavoriteDto createFavoriteDto);
        void DeleteFavorite(int machineId, int Userid);
    }
}