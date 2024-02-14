using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class FotoSil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Gelen = Convert.ToInt32(Request.QueryString["ID"]);
            deleteImage(Gelen);
        }
        protected void deleteImage(int ID)
        {
            try { 
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            //Silme Sorgumuz 
            int EkleyenKisi = Convert.ToInt32(Session["uye_ID"]);
            var VeriSil = (from c in Gs.tbl_MakinaResimler
                           join D in Gs.tbl_Makinalar on c.makina_ID equals D.makina_ID
                           where c.makinaResim_ID == ID && c.Durum == true && D.Ekleyen == EkleyenKisi
                           select c).SingleOrDefault();
            Gs.tbl_MakinaResimler.Remove(VeriSil);
            //VeriSil.gamePattern_Active = false;
            Gs.SaveChanges();

            //Dosyayı sunucudan siliyoruz
            File.Delete(MapPath(ConfigurationManager.AppSettings["imagePath"].ToString() + VeriSil.Fotograf));


            //Yönlendirme
            string urlm = Request.UrlReferrer.AbsoluteUri;
                Response.Redirect(urlm, false);
            }
            catch
            {

            }
        }
    }
}