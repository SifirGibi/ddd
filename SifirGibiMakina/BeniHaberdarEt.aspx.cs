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

    public partial class BeniHaberdarEt : System.Web.UI.Page
    {
        Mailler BenimMailim;
        private string mailaciklama = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            string Lang = Session["Lang"].ToString();

            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

            Master.Page.Title = "Beni Haberdar Et Formu | ikinci el makina, 2. el makina sitesi, ihaleli 2. el makina | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
            Master.Page.MetaDescription = "İstediğiniz makina özelliklerini bize iletin, kriterlerinize uygun makina geldiğinde sizi haberdar edelim. 2. el makina sitesi";
            Master.Page.MetaKeywords = "ikinci el makina, 2. el makina siteleri, ücretsiz 2. el makina, ihaleli 2. el makina";


            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////


            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            var Sorgu = from c in nt.tbl_Ayarlar
                        select c;

            foreach (var prod in Sorgu)
            {
                ltAdres.Text = prod.Adres;
                ltIlce.Text = prod.Ilce;
                ltMail.Text = "<a href=mailto:" + prod.Email + ">" + prod.Email + "</a>";
                ltMaps.Text = prod.GoogleMap;
                ltPhone.Text = "<a href=tel:"+prod.Telefon.UrlCevir() + ">"+prod.Telefon+"</a>";
                ltSehir.Text = prod.Il;
            }
            if (!IsPostBack)
            {
                //Türleri Listeliyoruz
                var Turler = from c in nt.tbl_MakinaTurleri
                             where c.dil_ID == 1
                             orderby c.Kategori ascending
                             select c;

                ddTurler.DataSource = Turler.ToList();
                ddTurler.DataValueField = "tur_ID";
                ddTurler.DataTextField = "Kategori";
                ddTurler.DataBind();
                ListItem lit = new ListItem("Makina Türü", "0");
                ddTurler.Items.Add(lit);
                ddTurler.SelectedValue = "0";

                //Yılları Listeliyoruz
                var Yillar = from c in nt.tbl_MakinaYillar
                             where c.dil_ID == 1
                             orderby c.Kategori ascending
                             select c;

                ddYillar.DataSource = Yillar.ToList();
                ddYillar.DataValueField = "yil_ID";
                ddYillar.DataTextField = "Kategori";
                ddYillar.DataBind();
                ListItem liy = new ListItem("Makina Yılı", "0");
                ddYillar.Items.Add(liy);
                ddYillar.SelectedValue = "0";


                //Markaları Listeliyoruz
                var Markalar = from c in nt.tbl_MakinaMarkalari
                               where c.dil_ID == 1
                               orderby c.Kategori ascending
                               select c;

                ddMarkalar.DataSource = Markalar.ToList();
                ddMarkalar.DataValueField = "marka_ID";
                ddMarkalar.DataTextField = "Kategori";
                ddMarkalar.DataBind();
                ListItem lim = new ListItem("Makina Markası", "0");
                ddMarkalar.Items.Add(lim);
                ddMarkalar.SelectedValue = "0";
            }


            }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var encodedResponse = Request.Form["g-Recaptcha-Response"];
                var isCaptchaValid = recaptcha.Validate(encodedResponse);

                if (isCaptchaValid)
                {
                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                    tbl_BeniHaberdarEt benihaberdaret = new tbl_BeniHaberdarEt();

                    benihaberdaret.AdSoyad = txtAdSoyad.Text;
                    benihaberdaret.EMail = txtEmail.Text;
                    benihaberdaret.Telefon = txtTelefon.Text;
                    benihaberdaret.yil_ID = Convert.ToInt32(ddYillar.SelectedItem.Value.ToString());
                    benihaberdaret.marka_ID = Convert.ToInt32(ddMarkalar.SelectedItem.Value.ToString());
                    benihaberdaret.tur_ID = Convert.ToInt32(ddTurler.SelectedItem.Value.ToString());
                    benihaberdaret.Alttur_ID = Convert.ToInt32(ddTurlerAlt.SelectedItem.Value.ToString());
                    benihaberdaret.Model = txtModel.Text;
                    benihaberdaret.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                    benihaberdaret.Kayit_Tarihi = DateTime.Now;
                    benihaberdaret.Aciklama = txtMesaj.Text;
                    benihaberdaret.Fiyat = txtFiyat1.Text + "-" + txtFiyat2.Text;
                    benihaberdaret.Para_Birimi = Convert.ToInt32(ddParaBirimi.SelectedItem.Value.ToString());
                    benihaberdaret.Durum = true;
                    benihaberdaret.Yanit = false;
                    
                    

                    nt.tbl_BeniHaberdarEt.Add(benihaberdaret);
                    nt.SaveChanges();

                    //İşlemler bittikten sonra
                    pnlIletisim.Visible = false;
                    pnlError.Visible = false;
                    lblAciklama.Text = "Beni Haberdar Et formunuz başarılı bir şekilde gönderildi. Size uygun makina geldiğinde bilgilendirileceksiniz.";



                    //Kişiye mail gönderiyoruz
                    mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. Beni Haberdar Et formu ayrıntıları aşağıda yer almaktadır. <br /><br/><br/><strong>Adı Soyadı:</strong> " + txtAdSoyad.Text + "<br /><strong>E-mail:</strong> " + txtEmail.Text + "<br /><strong>Telefon:</strong> " + txtTelefon.Text + "<br/><strong>Model:</strong>" + txtModel.Text + " < br /><strong>Makina Türü:</strong>" + ddTurler.SelectedItem.Text + "<br /><strong>Makina Markası:</strong>" + ddMarkalar.SelectedItem.Text + "<br /><strong>Makina Yılı:</strong>" + ddYillar.SelectedItem.Text + "<br /><strong>Fiyat Aralığı:</strong>" +txtFiyat1.Text +"-"+txtFiyat2.Text+" "+ ddParaBirimi.SelectedItem.Text + "<br /><br /><strong>Özellikler ve Açıklama:</strong><br /><br />" + txtMesaj.Text + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                    BenimMailim = new Mailler();
                    BenimMailim.Send_EMail("Beni Haberdar Et Formu", mailaciklama, "",  "");
                    Response.AddHeader("Refresh", "2;URL=/anasayfa");
                }
                else
                {
                    lblAciklama.Text = Dil.Res.IletisimDogrulama;
                }


            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0} / {1}", Session["Firma_ID"], ex));
            }
        }

        protected void ddTurler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gelen bilgiye göre alt kategorileri dolduruyoruz.
            ddTurlerAlt.Items.Clear();
            int kategoriID = Int32.Parse(ddTurler.SelectedItem.Value);
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var AltKategori = from c in Gs.tbl_MakinaAltTurleri
                              where c.Durum == true && c.tur_ID == kategoriID
                              orderby c.Kategori ascending
                              select c;

            ddTurlerAlt.DataSource = AltKategori.ToList();
            ddTurlerAlt.DataValueField = "Alttur_ID";
            ddTurlerAlt.DataTextField = "Kategori";
            ddTurlerAlt.DataBind();
        }
    }
}