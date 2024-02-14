using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Repositories;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfCategoryDal : EfEntityRepositoryBase<tbl_MakinaTurleri, db_SifirGibiMakinaEntities>, ICategoryDal
    {
        public EfCategoryDal(db_SifirGibiMakinaEntities context) : base(context)
        {
            //public async Task<IEnumerable<CategoryListDto>> GetCategoriesWithSubcategoriesAsync()
            //{
            //    using (db_SifirGibiMakinaEntities _context = new db_SifirGibiMakinaEntities())
            //    {

            //        var categories = await _context.tbl_MakinaTurleri
            //        .Where(c => c.dil_ID == 1).Include(c => c.tbl_MakinaAltTurleris)
            //        .Include(c => c.tbl_MakinaAltTurleris.Where(sub => sub.dil_ID == 1))
            //        .ToListAsync();

                    
            //    }
            //}
        }
    }
}