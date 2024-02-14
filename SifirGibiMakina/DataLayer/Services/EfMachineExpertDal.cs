using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.MachineryExpertSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DataLayer.Services
{
    public class EfMachineExpertDal : EfEntityRepositoryBase<tbl_MakinaEksperSecimi, db_SifirGibiMakinaEntities>, IMachineExpertDal
    {
        public EfMachineExpertDal(db_SifirGibiMakinaEntities context) : base(context)
        {
        }
        public List<MachineryExpertSelectionByMachineIdDto> GetListMachineryExpertSelectionByMachineID(int id)
        {
            using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
            {
                var result = from c in context.tbl_MakinaEksperSecimi
                             join M in context.tbl_Makinalar on c.makina_ID equals M.makina_ID
                             join D in context.tbl_MakinaEksper on c.eksper_ID equals D.eksper_ID
                             where c.makina_ID == id && c.Note > 0 && M.Durum == true
                             select new MachineryExpertSelectionByMachineIdDto
                             {
                                 Kategori = D.Kategori,
                                 Note = c.Note
                             };

                return result.ToList();
            }
        }
    }
}