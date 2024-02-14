using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina

{

    public partial class Iletisim : System.Web.UI.Page
    {
        Mailler BenimMailim;
        private string mailaciklama = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            string Lang = Session["Lang"].ToString();

            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

            Master.Page.Title = "2. el makinalar İletişim Formu | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
            Master.Page.MetaDescription = "2. el makine ilanları sitesi Sifirgibimakine.com uygun fiyatlı makine ilanları sitesidir. İkinci el makinalar için iletişime geçebilirsiniz.";
            Master.Page.MetaKeywords = "ikinci el makina, 2. el makineler, makinalar, makine al sat, makina al sat";


            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////


            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            var Sorgu = from c in nt.tbl_Ayarlar
                        select c;

            foreach (var prod in Sorgu)
            {
                ltAdres.Text = prod.Adres;
                ltIlce.Text = prod.Ilce;
                ltMail.Text = "<a href=mailto:" + prod.Email + " style=color:#212529>" + prod.Email + "</a>";
                ltMaps.Text = prod.GoogleMap;
                ltPhone.Text = "<a href=tel:"+prod.Telefon.UrlCevir() + " style=color:#212529>" + prod.Telefon+"</a>";
                ltSehir.Text = prod.Il;
            }


            //Ürün Satınalma
            if (RouteData.Values["makid"] != null)
            {
                int urunid = Convert.ToInt32(RouteData.Values["makid"].ToString());
                var sorgu = from c in nt.tbl_Makinalar
                            join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                            join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            where c.makina_ID == urunid && c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && c.Statu == 2
                            select new { c.Aciklama, c.Baslik, c.Para_Birimi, c.SeoKeywords, c.SeoDescription, c.SosyalMedyaPaylasim, c.Fotograf, Marka = M.Kategori, c.Model, Yil = Y.Kategori, c.Fiyat, Tur = T.Kategori, c.Ihale, c.Satis_Temsilcisi_Adi, c.Satis_Temsilcisi_Email, c.Satis_Temsilcisi_Telefon, c.makina_ID };
                foreach (var prod in sorgu)
                {
                    if (Session["Giris"] != null)
                    {
                        txtAdSoyad.Text = Session["AdSoyad"].ToString();
                        txtEmail.Text = Session["Email"].ToString();
                    }
                        txtKonu.Text = "Hızlı Satınalma";
                    txtMesaj.Text = prod.Baslik + " isimli ürünü satınalmak istiyorum. Lütfen benimle iletişime geçiniz.";
                }
                    
            }

            }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                    tbl_Iletisim iletisim = new tbl_Iletisim();

                    iletisim.AdSoyad = txtAdSoyad.Text;
                    iletisim.Email = txtEmail.Text;
                    iletisim.Telefon = txtTelefon.Text;
                    iletisim.Durum = true;
                    iletisim.Kayit_Tarihi = DateTime.Now;
                    iletisim.Mesaj = txtMesaj.Text;
                    iletisim.Konu = txtKonu.Text;
                    iletisim.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);

                    nt.tbl_Iletisim.Add(iletisim);
                    nt.SaveChanges();

                    //İşlemler bittikten sonra
                    //pnlIletisim.Visible = false;
                    //pnlError.Visible = false;
                    //lblAciklama.Text = "Mesajınız başarılı bir şekilde gönderildi. En kısa sürede sizinle iletişime geçeceğiz.";


                    //Eğer ilanı ekleyen kişi bir üye ise ona mail gönderttireceğiz.
                    string mail = "";
                    if (RouteData.Values["makid"] != null)
                    {
                        string Lang = Session["Lang"].ToString();
                        int urunid = Convert.ToInt32(RouteData.Values["makid"].ToString());
                        var sorgu = from c in nt.tbl_Makinalar
                                    join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                    join U in nt.tbl_Uyeler on c.Ekleyen equals U.uye_ID
                                    where c.makina_ID == urunid && c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && c.Statu == 2 && (c.Kimden == 2 || c.Kimden == 3)
                                    select new { U.EMail };
                        foreach (var prod in sorgu)
                        {
                            mail = prod.EMail;
                        }

                        

                    }

                    //Kişiye mail gönderiyoruz
                    mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. İletişim formu ayrıntıları aşağıda yer almaktadır. <br /><br/><br/><strong>Adı Soyadı:</strong> " + txtAdSoyad.Text + "<br /><strong>E-mail:</strong> " + txtEmail.Text + "<br /><strong>Telefon:</strong> " + txtTelefon.Text + "<br /><strong>Konu:</strong>" + txtKonu.Text + "<br /><br /><strong>Talep Mesajı:</strong><br /><br />" + txtMesaj.Text + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                    BenimMailim = new Mailler();
                    BenimMailim.Send_EMail("İletişim Formu - "+ txtKonu.Text, mailaciklama, mail,  "");
               
                pnlIletisim.Visible = false;
                pnlBitti.Visible = true;
                Response.AddHeader("Refresh", "2;URL=/anasayfa");

            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0} / {1}", Session["Firma_ID"], ex));
            }
        }
    }
}