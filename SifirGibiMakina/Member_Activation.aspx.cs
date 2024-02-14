using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class MemberActivation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string code= Request.QueryString["ActiveCode"];
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                var sorgu = from c in nt.tbl_Uyeler
                            where c.Code == code && c.Durum == true && c.Aktif==false
                            select c;
                var count = sorgu.Count();
                if (count > 0)
                {
                    var Guncelle = (from c in nt.tbl_Uyeler
                                    where c.Code == code
                                    select c).First();
                    Guncelle.Aktif = true;
                    Guncelle.Code = "";
                    nt.SaveChanges();

                    lblStatus.Text = "Hesabınız başarıyla aktif edilmiştir. Giriş sayfasına yönlendiriliyorsunuz";
                    Response.AddHeader("Refresh", "2;URL=/profilim");
                }
                else
                {
                    lblStatus.Text = "<span class=alert-warning>Bu hesap daha önceden aktif edilmiş veya aktivasyon kodu hatalı. <br><br>Lütfen sorununuzla ilgili iletişim sayfasından bize ulaşınız.<br><br></span>";
                }



            }
            catch (Exception ex)
            {
                lblStatus.Text = "Bir hata oluştu" + ex;
            }

        }
    }
}