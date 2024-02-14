using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace SifirGibiMakina
{
    public partial class SifremiUnuttum : System.Web.UI.Page
    {
        Mailler BenimMailim;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnUnuttum_Click(object sender, EventArgs e)
        {
            try
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                var sorgu = from c in nt.tbl_Uyeler
                            where c.EMail == txtEmail.Value && c.Durum == true && c.Aktif == true
                            select c;
                var count = sorgu.Count();
                if (count > 0)
                {
                    pnlSifre.Visible = false;
                    lblMailHatasi.Visible = false;
                    PnlBitti.Visible = true;
                    lblStatus.Text = "<br><br><center><b>Tebrikler, şifreniz e-mail adresinize (" + txtEmail.Value + ") başarıyla gönderilmiştir.</center></b><br><br>";

                    var sorgum = from c in nt.tbl_Uyeler
                                 where c.EMail == txtEmail.Value
                                 select new { c.Adi, c.Soyadi, c.EMail, c.Sifre };
                    foreach (var prod in sorgum)
                    {
                        //Mail Gönderiyoruz.
                        string mailaciklama = "Sayın <strong>" + prod.Adi.ToString().ToUpper() + " " + prod.Soyadi.ToString().ToUpper() + "</strong><br/><br/>Bu mesaj sifirgibimakine.com sayfasından şifrenizi unuttuğunuzu bildirdiğiniz için gönderilmiştir. <br><br><b>Üyelik Bilgileriniz:</b><br><br><b>E-Mail:</b>" + prod.EMail + "<br><br><b>Şifre:</b>" + prod.Sifre + " <br><br>Saygılarımızla<br>sifirgibimakine.com";
                        BenimMailim = new Mailler();
                        BenimMailim.Send_EMail("Şifre Hatırlatma", mailaciklama, txtEmail.Value, "");
                    }

                }
                else
                {
                    lblMailHatasi.Visible = true;
                    lblMailHatasi.Text = "<b>Kayıtlarımızda böyle bir e-mail adresi bulunmamaktadır.</b>";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Bir hata oluştu" + ex;
            }

        }
    }
}