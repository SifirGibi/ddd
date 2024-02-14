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
    public partial class Giris : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                var encodedResponse = Request.Form["g-Recaptcha-Response"];
                var isCaptchaValid = recaptcha.Validate(encodedResponse);


                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                string kadi = txtEmail.Value;
                string sifre = txtSifre.Value;
                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

                var Sorgu = from c in Gs.tbl_Uyeler
                            where c.EMail == kadi && c.Sifre == sifre && c.Durum == true && c.Aktif == true
                            select c;
                foreach (var prod in Sorgu)
                {
                    if (Sorgu.Count() > 0)
                    {

                        Session["Giris"] = "OK";
                        Session["Email"] = prod.EMail;
                        Session["AdSoyadKisa"] = prod.Adi.Substring(0, 1) + ". " + prod.Soyadi.Substring(0, 1) + ". ";
                        Session["AdSoyad"] = prod.Adi + " " + prod.Soyadi;
                        Session["uye_ID"] = prod.uye_ID.ToString();
                        Session["hesapTuru"] = prod.Hesap_Turu.ToString();

                        if (this.Request.QueryString["ReturnUrl"] != null)
                        {
                            this.Response.Redirect(Request.QueryString["ReturnUrl"].ToString());
                        }
                        else
                        {
                            //Mobil Cihaz Kontrol
                            System.Web.HttpBrowserCapabilities browser = Request.Browser;
                            if (browser.IsMobileDevice == true)
                            {
                                this.Response.Redirect("/urunler");
                            }
                            else
                            {
                                this.Response.Redirect("/profilim");
                                
                            }
                        }


                        
                    }


                }

                if (Sorgu.Count() == 0)
                {
                    lblAciklama.Visible = true;
                    lblAciklama.Text = "Kullanıcı bilgileriniz hatalı kontrol ederek tekrar deneyiniz.";
                }





            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0} / {1}", "", ex));
            }
        }

    }
}