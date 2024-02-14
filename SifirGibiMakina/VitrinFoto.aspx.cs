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
    public partial class VitrinFoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Gelen = Convert.ToInt32(Request.QueryString["ID"]);
            vitrinImage(Gelen);
        }
        protected void vitrinImage(int ID)
        {
            try {

                int makinaID = Convert.ToInt32(Session["MakinaID"]);
                int EkleyenKisi = Convert.ToInt32(Session["uye_ID"]);
                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

                //Seçilen Makinaya Ait Tüm Resimlerde Vitrin'i kaldır
                var VeriGuncelle = from c in Gs.tbl_MakinaResimler
                                   join D in Gs.tbl_Makinalar on c.makina_ID equals D.makina_ID
                                   where c.makina_ID == makinaID && c.Durum == true && D.Ekleyen == EkleyenKisi
                                   select c;
                foreach (var prod in VeriGuncelle)
                {
                    prod.Vitrin = false;

                }
                Gs.SaveChanges();

                //Düzenleme
                var VeriDuzenle = (from c in Gs.tbl_MakinaResimler
                                   join D in Gs.tbl_Makinalar on c.makina_ID equals D.makina_ID
                                   where c.makinaResim_ID == ID && c.Durum == true && D.Ekleyen == EkleyenKisi
                                   select c).SingleOrDefault();
                VeriDuzenle.Vitrin = true;
                Gs.SaveChanges();



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