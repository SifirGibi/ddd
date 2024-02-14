using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Globalization;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.Dtos.Favorite;
using Microsoft.AspNet.SignalR;
using SifirGibiMakina.Dtos.Machine;
using Microsoft.Owin.Security.DataHandler.Encoder;
using SifirGibiMakina.Dtos.UserServıces;
using System.Text;
using SifirGibiMakina.Dtos.ServiceExpertiz;
using System.Xml.Linq;
using System.IO;

namespace SifirGibiMakina
{
    public partial class Urun_DetailSEOURL : System.Web.UI.Page
    {
        string mailaciklama = "";
        public IMachineService _machineService { get; set; }
        public IFavoriteService _favoriteService { get; set; }
        public IMachinePhotoService _photoService { get; set; }
        public ICompanyLogoService _companyLogoService { get; set; }
        public IMachineExpertService machineExpertService { get; set; }
        public IServiceUserDetailService _serviceUserDetailService { get; set; }
        public ICountryService _countryService { get; set; }
        public IServiceExpertizService _expertizService { get; set; }
        public IUserService _userService { get; set; }
        Mailler BenimMailim;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (RouteData.Values["seourl"] != null)
            {

                string seourl = RouteData.Values["seourl"].ToString();

                int urunid = 0;

                urunid = _machineService.GetIdBySeoUrl(seourl);
                Session["MachineID"] = urunid;



                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();



                string Lang = Session["Lang"].ToString();

                ///////////////////////////////////////Favori İşlemleri////////////////////////////////////////


                if (!IsPostBack)
                {

                    CheckFavorite(urunid);



                    ///////////////////////////////////////İçerikler alınıyor//////////////////////////////////////

                    GetMachine(urunid, seourl);

                }



            }

        }

        private void GetMachine(int urunid, string seourl)
        {
            string isaret = "";
            string duzenlenmistelefon = "";
            int varolangoruntulenmesayisi = 0;
            string kullaniciEmail = "";
            var sorgu = _machineService.GetMachineWithIdDetails(urunid);
            //Ürün Varsa İşlem Yap
            if (sorgu != null)
            {


                duzenlenmistelefon = sorgu.Satis_Temsilcisi_Telefon;
                kullaniciEmail = sorgu.Satis_Temsilcisi_Email;

                lblBaslik.Text = sorgu.Baslik;
                lblBaslik1.Text = sorgu.Baslik;
                lblBaslik2.Text = sorgu.Baslik;
                lblilanBaslik.Text = sorgu.Baslik;
                lblYayinTarihi.Text = Convert.ToDateTime(sorgu.Yayinlanma_Tarihi).ToString("dd.MM.yyyy");
                lblYayinTarihi1.Text = Convert.ToDateTime(sorgu.Yayinlanma_Tarihi).ToString("dd.MM.yyyy");
                lblilanNo.Text = sorgu.IlanNo.ToString();
                lblIlanNo1.Text = sorgu.IlanNo.ToString();
                lblYil1.Text = sorgu.Yil.ToString();
                ltMarka1.Text = "<a href=/marka/" + ReWriterPath("1", sorgu.Marka, "1") + "/ikinci-el-makina/" + sorgu.marka_ID + "><span>" + sorgu.Marka + "</span></a>";
                lblModel1.Text = sorgu.Model;
                ltTur1.Text = "<a href=/kategori/" + ReWriterPath("1", sorgu.Tur, "1") + "/ikinci-el-makina/" + sorgu.tur_ID + "><span>" + sorgu.Tur + "</span></a>";
                ltAltTur1.Text = sorgu.AltTur;
                ltTur2.Text = "<a href=/kategori/" + ReWriterPath("1", sorgu.Tur, "1") + "/ikinci-el-makina/" + sorgu.tur_ID + "><span>" + sorgu.Tur + "</span></a>";
                Session["AltTur"] = sorgu.Alttur_ID;

                if (sorgu.ilce != "") { isaret = ", "; }


                if (sorgu.KM.Length > 1)
                {
                    lblCalismaSaati.Text = sorgu.KM;
                }
                else
                {
                    lblCalismaSaati.Text = "Belirtilmedi";
                }
                ltAciklama.Text = sorgu.Aciklama;


                //Ülkeyi yazdırıyoruz
                var ulkesorgu = _countryService.GetCountry(sorgu.Ulke);


                lblil.Text = ToTitleCase(sorgu.ilce.ToLower()) + isaret + ToTitleCase(sorgu.il.ToLower()) + " - <img src=\"https://flagcdn.com/w40/" + ulkesorgu.iso.ToLower() + ".png\"  srcset=\"https://flagcdn.com/w80/" + ulkesorgu.iso.ToLower() + ".png 2x\"  width=\"40\"  alt=\"" + ulkesorgu.nicename + "\">";
                lblIl1.Text = ToTitleCase(sorgu.ilce.ToLower()) + isaret + ToTitleCase(sorgu.il.ToLower()) + " - <img src=\"https://flagcdn.com/w40/" + ulkesorgu.iso.ToLower() + ".png\"  srcset=\"https://flagcdn.com/w80/" + ulkesorgu.iso.ToLower() + ".png 2x\"  width=\"40\"  alt=\"" + ulkesorgu.nicename + "\">";

                if (ulkesorgu.iso != "TR")
                {
                    ltAciklama.Text += "<br/>* Bu ilan otomatik olarak çevrildiği için bazı çeviri hataları oluşmuş olabilir.";
                }

                Session["Ulke"] = ulkesorgu.GoogleTranslateCode.ToString();



                if (sorgu.SpecificType == 1)
                {
                    SellPanel.Visible = true;
                    RentPanel.Visible = false;
                    ltFiyat.Text = string.Format("{0:0,0}", sorgu.Fiyat);
                    ltFiyat1.Text = string.Format("{0:0,0}", sorgu.Fiyat);


                }
                else
                {
                    RentPanel.Visible = true;
                    SellPanel.Visible = false;
                    ltDailyPrice.Text = string.Format("{0:0,0}", sorgu.DailyPrice);
                    ltWeeklyPrice.Text = string.Format("{0:0,0}", sorgu.WeeklyPrice);
                    ltMonthlyPrice.Text = string.Format("{0:0,0}", sorgu.MonthlyPrice);


                }



                //Fiyatı Session atıyoruz favorilerde kullanmak için
                Session["Fiyat"] = sorgu.Fiyat;

                Session["TelefonGoruntulenmeSayisi"] = sorgu.TelefonNumarasiGostermeSayisi;

                Session["WhatsAppGoruntulenmeSayisi"] = sorgu.Makina_Order;
                Session["duzenlenmistelefon"] = sorgu.Satis_Temsilcisi_Telefon;
                Session["prodBaslik"] = sorgu.Baslik;
                varolangoruntulenmesayisi = Convert.ToInt32(sorgu.GoruntulenmeSayisi);

                //Ana Resim
                var urunresimsorgu = _photoService.GetListPhotos(urunid);

                foreach (var prods in urunresimsorgu)
                {
                    string[] b = prods.Fotograf.Split('.');
                    ltResim.Text = "<img src=" + WebConfigurationManager.AppSettings["imagePath"] + "/" + b[0] + "_d." + b[1] + " class=img-fluid alt=\"" + sorgu.Baslik + "\" > ";

                }

                if (urunresimsorgu.Count() == 0)
                {
                    ltResim.Text = "<img src=" + WebConfigurationManager.AppSettings["imagePath"] + "/ornekfoto.jpg class=img-fluid alt =\"" + sorgu.Baslik + "\" > ";
                }



                //Para Birimi
                string parabirimi = sorgu.Para_Birimi.ToString();
                if (parabirimi == "1" && sorgu.Fiyat.ToString() != "")
                {
                    ltParaBirimi.Text = "&#8378";
                    ltParaBirimi1.Text = "&#8378";
                    ltFiyatOneriParaBirimi.Text = "&#8378";
                    ltParaBirimi5.Text = "&#8378";
                    ltParaBirimi6.Text = "&#8378";
                    ltParaBirimi7.Text = "&#8378";
                }
                else if (parabirimi == "2" && sorgu.Fiyat.ToString() != "")
                {
                    ltParaBirimi.Text = "&euro;";
                    ltParaBirimi1.Text = "&euro;";
                    ltFiyatOneriParaBirimi.Text = "&euro;";
                    ltParaBirimi5.Text = "&euro;";
                    ltParaBirimi6.Text = "&euro;";
                    ltParaBirimi7.Text = "&euro;";
                }
                else if (parabirimi == "3" && sorgu.Fiyat.ToString() != "")
                {
                    ltParaBirimi.Text = "$";
                    ltParaBirimi1.Text = "$";
                    ltFiyatOneriParaBirimi.Text = "$";
                    ltParaBirimi5.Text = "$";
                    ltParaBirimi6.Text = "$";
                    ltParaBirimi7.Text = "$";
                }

                //Eğer İlan Fiyat Gösterilmesin sadece teklif talep edilsin olarak işaretlendiyse fiyatları gizle
                if (sorgu.FiyatGosterilmesin == true)
                {
                    ltParaBirimi.Visible = false;
                    ltParaBirimi1.Visible = false;
                    ltFiyat.Visible = false;
                    ltFiyat1.Visible = false;
                    ltTeklifTalebi.Visible = true;
                    ltTeklifTalebi.Visible = true;
                    RentPanel.Visible = false;
                }



                //Resimleri Goster
                var images = _photoService.GetListPhotos(urunid);

                rptGaleri.DataSource = images.ToList();
                rptGaleri.DataBind();
                rptGaleri1.DataSource = images.ToList();
                rptGaleri1.DataBind();

                if (images.Count() == 0)
                {
                    rptGaleri1.Visible = false;
                    rptGaleri.Visible = false;
                    ltResim.Visible = true;
                    ltResim.Text = "<img src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + "ornekfoto.jpg" + ">";
                }

                //Firma Logosu Varsa Firma adı ve Logosu Eklensin
                int userId = sorgu.Ekleyen;

                var sorguFirma = _companyLogoService.GetCompanyLogoByUser(userId);
                if (sorguFirma != null)
                {
                    lblFirmaismi.Text = sorguFirma.Baslik;
                    string[] a = sorguFirma.Buyuk_Logo.Split('.');
                    imgLogo.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1];
                    ltLink.Text = "<a href=\"/satici-firma/" + sorgu.Ekleyen + "/" + ReWriterPath("1", sorguFirma.Baslik, "1") + "/ikinci-el-makina\"><img class=\"img-fluid\" src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1] + "></a>";
                }


                //Eğer firma logolar kısmında yoksa profilde yer alan firma ismi buraya yazılacak
                if (sorguFirma == null)
                {

                    var sorguKisi = _userService.GetUser(userId);


                    lblFirmaismi.Text = sorguKisi.FirmaAdi;



                }



                //Eksper Bilgisi
                var Eksper = machineExpertService.GetMachineryExpertSelectionByMachineIds(urunid);
                rptEksper.DataSource = Eksper.ToList();
                rptEksper.DataBind();

                if (Eksper.Count() == 0)
                {
                    eksperyazi.Visible = false;
                }

                //İlan üyeden ise ve sisteme giriş yapılmış ise mesaj gonder butonu gösterilsin
                if ((sorgu.Kimden == 1 || sorgu.Kimden == 2 || sorgu.Kimden == 3) && (Session["Giris"] != null))
                {

                    ltMesajLinki.Visible = true;
                    //ltMesajLinki.Text = "<a href=/mesajgonder/" + prod.makina_ID + " class=\"btn btn-outline-success btn-block detay-button\"><span class=\"far fa-envelope\"></span> Mesaj Gönder</a>";
                    ltMesajLinki.Text = "<a href=\"#saticiiletisim\" class=\"btn btn-outline-success btn-block detay-button\"><span class=\"far fa-envelope\"></span> Mesaj Gönder</a>";
                }
                else if ((sorgu.Kimden == 1 || sorgu.Kimden == 2 || sorgu.Kimden == 3) && (Session["Giris"] == null))
                {
                    ltMesajLinki.Visible = true;
                    ltMesajLinki.Text = "<a href=\"/giris?ReturnUrl=ilan-" + seourl + "\" class=\"btn btn-outline-success btn-block detay-button\"><span class=\"far fa-envelope\"></span> Mesaj Gönder</a>";

                }

                //İhale
                if (sorgu.Ihale == true)
                {
                    if (sorgu.Ihale_Baslangic < DateTime.Now && sorgu.Ihale_Bitis < DateTime.Now)
                    {
                        //ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon+ "</a><br/>";
                        ltTemsilciWhatsapp.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + sorgu.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> Whatsapp </a>";
                        ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon.Substring(0, 2) + "** *** ****" + "</a><br/>";
                        //ltTemsilciEmail.Text = "<a href=mailto:" + prod.Satis_Temsilcisi_Email + " class=link>" + prod.Satis_Temsilcisi_Email.Substring(0, 3) + "**@*******" + "</a>";

                        ltIhale.Text = "<span class=\"btn btn-warning btn-block detay-button my-3\"><i class='fa fa-exclamation-circle'></i> İhale Tamamlandı</span>";
                        pnlIhale.Visible = false;

                        ltTemsilciWhatsapp.Visible = false;
                        ltMesajLinki.Visible = false;
                    }
                    else if (sorgu.Ihale_Baslangic > DateTime.Now && sorgu.Ihale_Bitis > DateTime.Now)
                    {
                        ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon + "</a><br/>";
                        ltTemsilciWhatsapp.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + sorgu.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> Whatsapp </a>";
                        ltIhale.Text = "<span><i class='fa fa-exclamation-circle'></i></span> İhale Henüz Başlamadı<br/><a href=/ihale/" + sorgu.makina_ID + " class=\"btn btn-warning btn-block detay-button my-3\">İhaleye Katıl</a>";
                        pnlIhale.Visible = true;
                        lblBaslangic.Text = sorgu.Ihale_Baslangic.Value.ToString();
                        lblBitis.Text = sorgu.Ihale_Bitis.Value.ToString();

                        //Gün Hesaplama
                        DateTime baslangictarihi = DateTime.Now;
                        DateTime bitistarihi = Convert.ToDateTime(sorgu.Ihale_Baslangic);
                        TimeSpan arasindakigunler = bitistarihi - baslangictarihi;
                        double days = arasindakigunler.Days;
                        double hours = arasindakigunler.Hours;
                        double minutes = arasindakigunler.Minutes;
                        double seconds = arasindakigunler.Seconds;
                        lblIhaleGun.Text = days.ToString();
                        lblIhaleSaat.Text = hours.ToString();
                        lblIhaleDakika.Text = minutes.ToString();
                        lblIhaleSaniye.Text = seconds.ToString();
                        if (parabirimi == "1")
                        {
                            lblKapora.Text = sorgu.Kapora + " &#8378";
                        }
                        else if (parabirimi == "2")
                        {
                            lblKapora.Text = sorgu.Kapora + " &euro;";
                        }
                        else if (parabirimi == "3")
                        {
                            lblKapora.Text = sorgu.Kapora + " $";
                        }
                    }
                    else if (sorgu.Ihale_Baslangic < DateTime.Now && sorgu.Ihale_Bitis > DateTime.Now)
                    {
                        ltTemsilci.Text = ToTitleCase(sorgu.Satis_Temsilcisi_Adi.ToLower());
                        ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon + "</a><br/>";
                        ltTemsilciWhatsapp.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + sorgu.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> Whatsapp </a>";
                        ltIhale.Text = "<a href=/ihale/" + sorgu.makina_ID + " class=\"btn btn-warning btn-block detay-button my-3\">İhaleye Katıl</a>";
                        live.Visible = true;
                        pnlIhale.Visible = true;
                        lblBaslangic.Text = sorgu.Ihale_Baslangic.Value.ToString();
                        lblBitis.Text = sorgu.Ihale_Bitis.Value.ToString();

                        //Gün Hesaplama
                        DateTime baslangictarihi = DateTime.Now;
                        DateTime bitistarihi = Convert.ToDateTime(sorgu.Ihale_Baslangic);
                        TimeSpan arasindakigunler = bitistarihi - baslangictarihi;
                        double days = arasindakigunler.Days;
                        double hours = arasindakigunler.Hours;
                        double minutes = arasindakigunler.Minutes;
                        double seconds = arasindakigunler.Seconds;
                        lblIhaleGun.Text = days.ToString();
                        lblIhaleSaat.Text = hours.ToString();
                        lblIhaleDakika.Text = minutes.ToString();
                        lblIhaleSaniye.Text = seconds.ToString();
                        if (parabirimi == "1")
                        {
                            lblKapora.Text = sorgu.Kapora + " &#8378";
                        }
                        else if (parabirimi == "2")
                        {
                            lblKapora.Text = sorgu.Kapora + " &euro;";
                        }
                        else if (parabirimi == "3")
                        {
                            lblKapora.Text = sorgu.Kapora + " $";
                        }
                    }
                }
                else
                {
                    //                        string mesajTurkce = "Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + prod.Baslik + " ürününü satınalmak istiyorum.";
                    //                        string mesajRusca = "Привет,%20 я хочу купить товар " + prod.Baslik + " на сайте www.sifirgibimakine.com.";
                    //                        string mesajIngilizce = "Hello,%20 I want to buy the product " + prod.Baslik + " on www.sifirgibimakine.com.";
                    //                        ltTemsilci.Text = ToTitleCase(prod.Satis_Temsilcisi_Adi.ToLower());
                    //                        ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon + "</a><br/>";
                    //                        ltTemsilciWhatsapp.Text = "<a href='https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=" + mesajTurkce + "' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> Whatsapp </a>" +
                    //"<a href='https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=" + mesajRusca + "' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> WhatsApp (Rusça) </a>" +
                    //"<a href='https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=" + mesajIngilizce + "' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> WhatsApp (İngilizce) </a>";

                    //                        ltTeklifTalebi.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + prod.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-warning btn-block detay-button my-3\"><i class=\"fas fa-whatsapp - alt\"></i> Teklif Talebi Gönder </a>";
                    //                        ltTeklifTalebi1.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + prod.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-warning btn-block detay-button my-3\"><i class=\"fas fa-whatsapp - alt\"></i> Teklif Talebi Gönder </a>";
                    //                        ltIhale.Visible = false;

                    ltTemsilci.Text = ToTitleCase(sorgu.Satis_Temsilcisi_Adi.ToLower());
                    ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon + "</a><br/>";
                    //ltTemsilciWhatsapp.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + sorgu.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> Whatsapp </a>";
                    string mailtoLink = "mailto:" + kullaniciEmail + "?subject=Teklif%20Talebi&body=Merhaba,%20www.sifirgibimakine.com sayfasındaki " + sorgu.Baslik + " ürününü satın almak istiyorum.";

                    // Mailto bağlantısını kullanarak bir HTML a elementi oluşturuluyor. Bu a elementi, bir "Teklif Talebi Gönder" düğmesi olarak tasarlanmıştır.
                    ltTeklifTalebi.Text = "<a href='" + mailtoLink + "' target=_blank class='btn btn-warning btn-block detay-button my-3'><i class='fas fa-envelope'></i> Teklif Talebi Gönder </a>";

                    ltTeklifTalebi1.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + sorgu.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-warning btn-block detay-button my-3\"><i class=\"fas fa-whatsapp - alt\"></i> Teklif Talebi Gönder </a>";
                    ltIhale.Visible = false;

                    //ltIhale.Text = "<a href=/iletisim/" + prod.makina_ID+ " class=\"btn btn-warning btn-block detay-button my-3\">Satınalmak İstiyorum</a>";
                }

                if (sorgu.Statu == 4 || sorgu.Statu == 5)
                {
                    //ltIhale.Visible = false;
                    pnlIhale.Visible = false;

                }


                ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                Master.Page.Title = sorgu.Baslik + " | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Master.Page.MetaDescription = "ikinci el makina, 2. el makine. " + sorgu.SeoDescription.ToString();
                Master.Page.MetaKeywords = sorgu.SeoKeywords.ToString();

                HtmlMeta tag0 = new HtmlMeta();
                tag0.Attributes.Add("property", "og:locale");
                tag0.Content = "tr_TR";
                Page.Header.Controls.Add(tag0);


                HtmlMeta tag = new HtmlMeta();
                tag.Attributes.Add("property", "og:title");
                tag.Content = sorgu.Baslik + " | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Page.Header.Controls.Add(tag);

                HtmlMeta tag1 = new HtmlMeta();
                tag1.Attributes.Add("property", "og:description");
                tag1.Content = "ikinci el makina, 2. el makine. " + sorgu.SeoDescription.ToString();
                Page.Header.Controls.Add(tag1);

                HtmlMeta tag02 = new HtmlMeta();
                tag02.Attributes.Add("property", "og:site_name");
                tag02.Content = "Sıfır Gibi Makina";
                Page.Header.Controls.Add(tag02);

                //Resimleri Goster
                var imagess = _photoService.GetListPhotos(urunid);

                foreach (var prodss in imagess)
                {
                    string fotograf = prodss.Fotograf;
                    string[] b = fotograf.Split('.');


                    HtmlMeta tagimg = new HtmlMeta();
                    tagimg.Attributes.Add("property", "og:image");
                    tagimg.Attributes.Add("itemprop", "image");
                    tagimg.Content = "https://sifirgibimakine.com" + WebConfigurationManager.AppSettings["imagePath"] + b[0] + "_v." + b[1];
                    Page.Header.Controls.Add(tagimg);

                    HtmlMeta tagimg1 = new HtmlMeta();
                    tagimg1.Attributes.Add("property", "og:img");
                    tagimg1.Content = "https://sifirgibimakine.com" + WebConfigurationManager.AppSettings["imagePath"] + b[0] + "_v." + b[1];
                    Page.Header.Controls.Add(tagimg1);

                    HtmlMeta tagt3img = new HtmlMeta();
                    tagt3img.Name = "twitter:image";
                    tagt3img.Content = "https://sifirgibimakine.com" + WebConfigurationManager.AppSettings["imagePath"] + b[0] + "_v." + b[1];
                    Page.Header.Controls.Add(tagt3img);


                }


                HtmlMeta tag2 = new HtmlMeta();
                tag2.Attributes.Add("property", "og:url");
                tag2.Content = Request.Url.AbsoluteUri.ToString();
                Page.Header.Controls.Add(tag2);

                HtmlMeta tag3 = new HtmlMeta();
                tag3.Attributes.Add("name", "twitter:card");
                tag3.Content = "summary";
                Page.Header.Controls.Add(tag3);


                //HtmlMeta tag05 = new HtmlMeta();
                //tag05.Attributes.Add("property", "og:image:type");
                //tag05.Content = "image/jpeg";
                //Page.Header.Controls.Add(tag05);


                HtmlMeta tagt1 = new HtmlMeta();
                tagt1.Name = "twitter:title";
                tagt1.Content = sorgu.Baslik + " | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Page.Header.Controls.Add(tagt1);

                HtmlMeta tagt2 = new HtmlMeta();
                tagt2.Name = "twitter:description";
                tagt2.Content = "ikinci el makina, 2. el makine. " + sorgu.SeoDescription.ToString();
                Page.Header.Controls.Add(tagt2);

                HtmlMeta tagt3 = new HtmlMeta();
                tagt2.Name = "twitter:url";
                tagt3.Content = Request.Url.AbsoluteUri.ToString();
                Page.Header.Controls.Add(tagt3);



                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////






                //Görüntüleme sayısı Güncelleniyor
                _machineService.IncreaseViewMachineCount(urunid);
                //Service firmaları doldur,
                if (sorgu.Alttur2_ID != 0)
                {
                    GetListSerivceFirm(sorgu.Alttur2_ID ?? 0);
                }
                else
                {
                    GetListSerivceFirm(sorgu.Alttur_ID ?? 0);
                }

                //Benzer İlanları Doldur
                BenzerIlanlarDoldur();


            }

            else
            {
                Response.Redirect("/404.aspx");
            }
        }

        private void GetListSerivceFirm(int id)
        {


            var result = _serviceUserDetailService.GetListServiceFirm(id);

            if (result != null && result.Any())
            {
                pnlServiceNoneFirm.Visible = false;
                pnlServiceFirm.Visible = true;

                rptServiceFirm.DataSource = result;
                rptServiceFirm.DataBind();
            }
            else
            {
                pnlServiceNoneFirm.Visible = true;
                pnlServiceFirm.Visible = false;
            }






        }




        protected void rptServiceFirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var imgPicture = (Image)e.Item.FindControl("imgPicture");
                var item = (GetListServiceFirmDto)e.Item.DataItem;
                if (item != null)
                {
                    HtmlInputHidden hiddenAverageRating = (HtmlInputHidden)e.Item.FindControl("hiddenAverageRating");
                    if (hiddenAverageRating != null)
                    {
                        hiddenAverageRating.Value = _serviceUserDetailService.UserCommentAvarge(item.uye_ID).ToString();
                    }
                }
                if (imgPicture != null && item != null)
                {
                    if (string.IsNullOrEmpty(item.FirmLogo))
                    {
                        imgPicture.ImageUrl = "~/images/Logo.png";
                    }
                    else
                    {
                        string[] a = item.FirmLogo.Split('.');
                        imgPicture.ImageUrl = ConfigurationManager.AppSettings["imagePath"] + a[0] + "_kck." + a[1];
                    }
                }


            }
        }






        private void CheckFavorite(int urunid)
        {

            if (Session["Giris"] != null)
            {
                int uyeNo = Convert.ToInt32(Session["uye_ID"].ToString());

                //var favori = from c in nt.tbl_ilanFavorileri
                //             where c.makina_ID == urunid && c.user_ID == uyeNo
                //             select c;

                bool IsFavorite = _favoriteService.IsMachineFavorite(urunid, uyeNo);

                if (IsFavorite)
                {
                    btnFavorilerdenCikar.Visible = true;
                    btnFavorilereEkle.Visible = false;
                }
                else
                {
                    btnFavorilerdenCikar.Visible = false;
                    btnFavorilereEkle.Visible = true;
                }

                //Giriş Yapmışsa Mesaj Gönderme Bölümü AKtif Olsun
                pnlMesajGondermeAlani.Visible = true;

            }
            else
            {
                btnFavorilerdenCikar.Visible = false;
            }




        }

        protected void rptEksper_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                Literal Smiley = (Literal)e.Item.FindControl("ltSmiley");
                Literal Prosess = (Literal)e.Item.FindControl("ltProgress");
                int Note = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Note").ToString());

                if (Note <= 3)
                {
                    Smiley.Text = "&#128577;";
                    Prosess.Text = "<div class=\"progress\"><div class=\"progress-bar progress-bar-striped bg-danger\" role=\"progressbar\" aria-valuenow=" + Note.ToString() + "0 aria-valuemin='0' aria-valuemax='10' style='width:" + Note.ToString() + 0 + "%'>" + Note.ToString() + "</div></div>";
                }
                else if (Note >= 4 && Note <= 6)
                {
                    Smiley.Text = "&#128528;";
                    Prosess.Text = "<div class=\"progress\"><div class=\"progress-bar progress-bar-striped bg-warning\" role=\"progressbar\" aria-valuenow=" + Note.ToString() + "0 aria-valuemin='0' aria-valuemax='10' style='width:" + Note.ToString() + 0 + "%'>" + Note.ToString() + "</div></div>";

                }
                else if (Note >= 7 && Note <= 9)
                {
                    Smiley.Text = "&#128578;";
                    Prosess.Text = "<div class=\"progress\"><div class=\"progress-bar progress-bar-striped bg-info\" role=\"progressbar\" aria-valuenow=" + Note.ToString() + "0 aria-valuemin='0' aria-valuemax='10' style='width:" + Note.ToString() + 0 + "%'>" + Note.ToString() + "</div></div>";

                }
                else if (Note >= 10)
                {
                    Smiley.Text = "&#128521;";
                    Prosess.Text = "<div class=\"progress\"><div class=\"progress-bar progress-bar-striped bg-success\" role=\"progressbar\" aria-valuenow=" + Note.ToString() + "0 aria-valuemin='0' aria-valuemax='10' style='width:" + Note.ToString() + 0 + "%'>" + Note.ToString() + "</div></div>";

                }

            }

        }

        protected void rptGaleri_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //İmaj
                Literal imgresim = (Literal)e.Item.FindControl("ltResim");
                string fotograf = DataBinder.Eval(e.Item.DataItem, "Fotograf").ToString();
                string[] a = fotograf.Split('.');
                imgresim.Text = "<a href=\"" + ConfigurationManager.AppSettings["imagePath"].ToString() + fotograf + "\" data-fancybox=\"gallery\"><img src=\"" + ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_d." + a[1] + "\" /></a>";
            }

        }

        protected void rptGaleri1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //İmaj
                Literal imgresim = (Literal)e.Item.FindControl("ltResim");
                string fotograf = DataBinder.Eval(e.Item.DataItem, "Fotograf").ToString();
                string[] a = fotograf.Split('.');
                imgresim.Text = "<img src=\"" + ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_s." + a[1] + "\" class=\"img-fluid\"/>";
            }

        }


        protected void btnFavorilereEkle_Click(object sender, EventArgs e)
        {
            if (Session["Giris"] != null)
            {

                int uyeNo = Convert.ToInt32(Session["uye_ID"].ToString());

                int urunid = Convert.ToInt32(Session["machineID"].ToString());




                //db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

                CreateFavoriteDto createFavoriteDto = new CreateFavoriteDto()
                {
                    user_ID = uyeNo,
                    makina_ID = urunid,
                    EklenenFiyat = Session["Fiyat"].ToString(),
                    Kayit_Tarihi = DateTime.Now,
                    IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress),


                };

                _favoriteService.AddFavorite(createFavoriteDto);
                _machineService.IncreaseFavoriteCount(urunid);




                //İşlem bitince sayfayı refresf ediyoruz.

                Page.Response.Redirect(Page.Request.Url.ToString(), false);

            }
            else
            {
                Response.AddHeader("Refresh", "0;URL=/giris");
            }


        }


        protected void btnFavorilerdenCikar_Click(object sender, EventArgs e)
        {
            int uyeNo = Convert.ToInt32(Session["uye_ID"].ToString());

            int urunid = Convert.ToInt32(Session["machineID"].ToString());

            //Favoriyi Siliyoruz    
            _favoriteService.DeleteFavorite(urunid, uyeNo);
            _machineService.ReduceFavoriteCount(urunid);
            //Favori eklenme sayısını güncelliyoruz.



            Page.Response.Redirect(Page.Request.Url.ToString(), false);

        }

        public static string ReWriterPath(string NewsID, string strTitle, string Tip)
        {
            strTitle = strTitle.Trim();

            strTitle = strTitle.Trim('-');
            strTitle = strTitle.ToLower();

            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();

            strTitle = strTitle.Replace("c#", "C-Sharp");
            strTitle = strTitle.Replace("vb.net", "VB-Net");
            strTitle = strTitle.Replace("asp.net", "Asp-Net");
            strTitle = strTitle.Replace("-", "");
            strTitle = strTitle.Replace(" ", "-");
            strTitle = strTitle.Replace("ç", "c");
            strTitle = strTitle.Replace("ğ", "g");
            strTitle = strTitle.Replace("ı", "i");
            strTitle = strTitle.Replace("ö", "o");
            strTitle = strTitle.Replace("ş", "s");
            strTitle = strTitle.Replace("ü", "u");
            strTitle = strTitle.Replace("\"", "");
            strTitle = strTitle.Replace("/", "");
            strTitle = strTitle.Replace("(", "");
            strTitle = strTitle.Replace(")", "");
            strTitle = strTitle.Replace("{", "");
            strTitle = strTitle.Replace("}", "");
            strTitle = strTitle.Replace("%", "");
            strTitle = strTitle.Replace("&", "");
            strTitle = strTitle.Replace("+", "");
            strTitle = strTitle.Replace(".", "-");
            strTitle = strTitle.Replace("?", "");
            strTitle = strTitle.Replace(",", "");
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("-----", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("--", "-");

            //Lüzumsuz karakterleri de bi güzel çevirelim 

            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                {
                    strTitle = strTitle.Replace(strChar, string.Empty);
                }

            }

            strTitle = strTitle.Trim();
            strTitle = strTitle.Trim('-');
            //Tip=1 ise video,Tip=2 ise Haber,Tip=3 ise Makale
            switch (int.Parse(Tip))
            {
                case 1:
                    return strTitle;
                    break;
                case 2:
                    return NewsID + "_" + strTitle + ".aspx";
                    break;
                case 3:
                    return "Makale/" + DateTime.Now.Date.Year.ToString() + "/" + DateTime.Now.Date.Month.ToString() + "/" + DateTime.Now.Date.Day.ToString() + "/" + NewsID + "-" + strTitle + ".aspx";
                    break;
                default:
                    return "default.aspx";
                    break;
            }
        }

        protected void BenzerIlanlarDoldur()
        {
            //db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            string Lang = Session["Lang"].ToString();

            int Tur1 = Convert.ToInt32(Session["AltTur"].ToString());


            var urunsorgu = _machineService.GetMachineList().Where(x => x.Vitrin == true && (x.Statu == 2 || x.Statu == 5) && x.Alttur_ID == Tur1).OrderByDescending(c => c.Kayit_Tarihi).Take(4);




            rptBenzerIlanlar.DataSource = urunsorgu.ToList();
            rptBenzerIlanlar.DataBind();
        }

        protected void rptBenzerIlanlar_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Fiyat
                Literal Fiyat = (Literal)e.Item.FindControl("ltFiyat");
                string fiyati = DataBinder.Eval(e.Item.DataItem, "Fiyat").ToString();
                Fiyat.Text = string.Format("{0:0,0}", fiyati); ;

                //Para Birimi
                Literal Para = (Literal)e.Item.FindControl("ltParaBirimi");
                string parabirimi = DataBinder.Eval(e.Item.DataItem, "Para_Birimi").ToString();


                if (parabirimi == "1")
                {
                    Para.Text = "&#8378";
                }
                else if (parabirimi == "2")
                {
                    Para.Text = "&euro;";
                }
                else if (parabirimi == "3")
                {
                    Para.Text = "$";
                }


                //İmaj
                Image imgresim = (Image)e.Item.FindControl("imgUrun");

                int makinaID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "makina_ID").ToString());
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();

                var urunresimsorgu = _photoService.GetListPhotos(makinaID);

                foreach (var prods in urunresimsorgu)
                {
                    string[] a = prods.Fotograf.Split('.');
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_vb." + a[1];
                }

                if (urunresimsorgu.Count() == 0)
                {
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + "ornekfoto.jpg";
                }

                //Eğer İlan Fiyat Gösterilmesin sadece teklif talep edilsin olarak işaretlendiyse fiyatları gizle
                bool fiyatgosterilmesin = Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "FiyatGosterilmesin").ToString());
                if (fiyatgosterilmesin == true)
                {
                    Fiyat.Visible = false;
                    Para.Visible = false;

                }
            }

        }

        public static string ToTitleCase(string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        protected void btnTelefonGoster_Click(object sender, EventArgs e)
        {
            int urunid = Convert.ToInt32(Session["machineID"].ToString());

            _machineService.IncreaseVisiblePhoneCount(urunid);
            //string seourl = RouteData.Values["seourl"].ToString();


            //db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

            ////Telefon Görüntülenme eklenme sayısını güncelliyoruz.
            //var Guncelle = (from c in Gs.tbl_Makinalar
            //                where c.SEOUrl == seourl && c.Durum == true
            //                select c).First();
            //Guncelle.TelefonNumarasiGostermeSayisi = Convert.ToInt32(Session["TelefonGoruntulenmeSayisi"]) + 1;
            //Gs.SaveChanges();


            linkBtnTelefonGoster.Visible = false;
            linkBtnTelefonGizle.Visible = true;
            pnlTelefon.Visible = true;


        }

        protected void btnTelefonGizle_Click(object sender, EventArgs e)
        {
            linkBtnTelefonGoster.Visible = true;
            linkBtnTelefonGizle.Visible = false;
            pnlTelefon.Visible = false;

        }

        protected void btnMesaj_Click(object sender, EventArgs e)
        {

            try
            {

                int urunid = Convert.ToInt32(Session["MachineID"].ToString());

                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();



                string aliciAdi = "";
                string aliciEmail = "";
                var sorgu = _machineService.GetMachineWithIdDetails(urunid);
                //Ürün Varsa İşlem Yap
                if (sorgu != null)
                {

                    aliciAdi = sorgu.Satis_Temsilcisi_Adi;
                    aliciEmail = sorgu.Satis_Temsilcisi_Email;
                    Session["Baslik"] = sorgu.Baslik;
                    Session["IlanNo"] = sorgu.IlanNo;
                    Session["makinaID"] = sorgu.makina_ID;
                    Session["Fiyat"] = sorgu.Fiyat;

                }
                string otomatikMetin = "";
                tbl_ilanEmail email = new tbl_ilanEmail();
                email.makina_ID = urunid;
                email.AliciAdi = aliciAdi;
                email.AliciMail = aliciEmail;

                email.GonderenAdi = txtAdi.Text;
                email.Email = txtEmail.Text;
                email.Telefon = "+" + txtDialCodeM.Value + txtTelefonM.Value.Trim();
                if (chkUygun.Checked == true) { email.UygunCheck = 1; otomatikMetin += "Bu makine hala uygun mu?"; } else { email.UygunCheck = 0; }
                if (chkGaranti.Checked == true) { email.GarantiCheck = 1; otomatikMetin += "<br><br>Bu makinenin garantisi devam ediyor mu?"; } else { email.GarantiCheck = 0; }
                if (chkDurumu.Checked == true) { email.DurumuCheck = 1; otomatikMetin += "<br><br>Makinenin durumu hakkında bilgi alabilir miyim?"; } else { email.DurumuCheck = 0; }
                if (chkFiyatOgrenme.Checked == true) { email.FiyatOgreneBilirmiyimCheck = 1; otomatikMetin += "<br><br>Makinenin fiyatını öğrenebilir miyim?"; } else { email.FiyatOgreneBilirmiyimCheck = 0; }
                if (chkFiyat.Checked == true) { email.PazarlikChek = 1; otomatikMetin += "<br><br>Fiyatta pazarlık payınız var mı? Benim teklifim" + txtFiyatOneri.Text + ltParaBirimi.Text; } else { email.PazarlikChek = 0; }
                email.FiyatOneri = txtFiyatOneri.Text + ltParaBirimi.Text;
                if (chkDahaFazlaResim.Checked == true) { email.DahaFazlaResimChek = 1; otomatikMetin += "<br><br>Daha fazla resim gönderebilir misiniz?"; } else { email.DahaFazlaResimChek = 0; }
                if (chkYasadigimYer.Checked == true) { email.YasadigimYerCheck = 1; otomatikMetin += "<br><br>Yaşadığım yer: " + txtYasadigimYer.Text; } else { email.YasadigimYerCheck = 0; }
                email.YasadigimYer = txtYasadigimYer.Text;
                if (chkKonusulanDil.Checked == true) { email.KonusulanDillerCheck = 1; otomatikMetin += "<br><br>Konuştuğum diller:" + txtKonusulanDil.Text; } else { email.KonusulanDillerCheck = 0; }
                email.KonusulanDiller = txtKonusulanDil.Text;
                if (chckGorusme.Checked == true) { email.GorusmePlanlamaCheck = 1; otomatikMetin += "<br><br>Makineye bakmak için bir görüşme planlayabilir miyiz?"; } else { email.GorusmePlanlamaCheck = 0; }
                if (chkIletisim.Checked == true) { email.IletimTalepCheck = 1; otomatikMetin += "<br><br>Detaylı iletişim bilgilerinizi gönderebilir misiniz?"; } else { email.IletimTalepCheck = 0; }
                if (chkTelefon.Checked == true) { email.DahaOnceGorusmeCheck = 1; otomatikMetin += "<br><br>Daha önce " + txtTelefondaGorusmeTarih.Text + " tarihinde telefonda görüşmüştük."; } else { email.DahaOnceGorusmeCheck = 0; }
                email.TelefonDahaOnceGorusmeTarih = txtTelefondaGorusmeTarih.Text;
                if (chkAyirtma.Checked == true) { email.AyirtmaCheck = 1; otomatikMetin += "<br><br>Makineyi ayırtabilir miyim?"; } else { email.AyirtmaCheck = 0; }
                email.Mesaj = txtMesaj.Text;
                email.Durum = true;
                email.Kayit_Tarihi = DateTime.Now;
                email.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);

                nt.tbl_ilanEmail.Add(email);
                nt.SaveChanges();

                //İşlemler bittikten sonra
                pnlError.Visible = false;

                //Kişiye mail gönderiyoruz
                var urunresimsorgu = _photoService.GetListPhotos(urunid);

                foreach (var prods in urunresimsorgu)
                {
                    string[] a = prods.Fotograf.Split('.');
                    Session["Fotograf"] = a[0] + "." + a[1];
                }

                if (urunresimsorgu.Count() == 0)
                {
                    Session["Fotograf"] = "ornekfoto.jpg";
                }

                //Telefon numarası girmişse mailde göster
                string telefon = "";
                if (txtTelefonM.Value.Length > 3)
                {
                    telefon = " / +" + txtDialCodeM.Value + txtTelefonM.Value.Trim();
                }

                string aciklama = "Sayın Bay/Bayan<b> " + txtAdi.Text.ToUpper() + " (" + txtEmail.Text + telefon + " ),</b> belirtilen özelliklere sahip makinenizle ilgileniyor. Potansiyel müşterinin mesajı aşağıdadır.<br><br>sifirgibimakine.com, makinenizin satışında size başarılar diler!<br><br>Saygılarımızla<br>SifirGibiMakine.com ekibiniz<hr>";
                string mesaj = otomatikMetin + "<br><br>" + Translate.OtomatikCeviri(txtMesaj.Text, Session["Ulke"].ToString()).ToString() + "<br><hr>Anlamayı kolaylaştırmak için, bu mesajın münferit bölümleri otomatik olarak tercüme edilmiştir. Ancak bu, müşterinin sizin dilinizi konuştuğu anlamına gelmez.";
                BenimMailim = new Mailler();
                string mailBody = BenimMailim.SetIlanMailMesaji(Session["IlanNo"].ToString(), Translate.OtomatikCeviri(Session["Baslik"].ToString(), Session["Ulke"].ToString()).ToString(), Session["Fotograf"].ToString(), Session["Fiyat"].ToString(), Session["ParaBirimi"].ToString(), Translate.OtomatikCeviri(mesaj, Session["Ulke"].ToString()).ToString(), aliciAdi, txtAdi.Text + " ( " + txtEmail.Text + telefon + " )", Translate.OtomatikCeviri(aciklama, Session["Ulke"].ToString()).ToString(), Translate.OtomatikCeviri("Yeni Bir Mesajınız Var!", Session["Ulke"].ToString()).ToString());
                BenimMailim.Send_EMailMessage(Translate.OtomatikCeviri("Yeni Mesaj", Session["Ulke"].ToString()).ToString(), mailBody, aliciEmail, txtEmail.Text);

                pnlMesaj.Visible = false;
                pnlBitti.Visible = true;
                lblMesajBaslik.Text = "Mesajınız Gönderildi";
                lblMesaj.Text = "Mesajınız başarılı bir şekilde gönderildi. Satıcı sizinle iletişime geçecektir.";
                string urlm = Request.RawUrl;
                //Response.Redirect(urlm+"#saticiiletisim", false);
                Response.AddHeader("Refresh", "2;URL=" + urlm + "#saticiiletisim");


            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0} / {1}", Session["Firma_ID"], ex));
            }
        }

        protected void whatsappLink_Click(object sender, EventArgs e)
        {
            string seourl = RouteData.Values["seourl"].ToString();

            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

            //Telefon Görüntülenme eklenme sayısını güncelliyoruz.
            var Guncelle = (from c in Gs.tbl_Makinalar
                            where c.SEOUrl == seourl && c.Durum == true
                            select c).First();
            Guncelle.Makina_Order = Convert.ToInt32(Session["WhatsAppGoruntulenmeSayisi"]) + 1;
            Gs.SaveChanges();

            var duzenlenmistelefon = Session["duzenlenmistelefon"];




            var prodBaslik = Session["prodBaslik"].ToString();

            var whatsappURL = "https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20www.sifirgibimakine.com sayfasındaki " + prodBaslik + " ürününü satın almak istiyorum.";

            string script = "var link = document.createElement('a'); link.href = '" + whatsappURL + "'; link.target = '_blank'; document.body.appendChild(link); link.click(); document.body.removeChild(link);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "openWhatsApp", script, true);

        }



        protected void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            if (Session["Giris"] != null)
            {
                foreach (RepeaterItem item in rptServiceFirm.Items)
                {
                    Button box = item.FindControl("btnOpenAppointment") as Button;
                    HtmlInputGenericControl txtAppointmentDate = item.FindControl("txtAppointmentDate") as HtmlInputGenericControl;


                    if (box != null && txtAppointmentDate.Value != "")
                    {
                        int id = Convert.ToInt32(box.CommandArgument);
                        string appointmentDateValue = txtAppointmentDate.Value; // txtAppointmentDate HTML input kontrolünün value'si alınıyor

                        // Şu anki tarih ve saat bilgisine sahip bir DateTime nesnesi oluşturuluyor
                        DateTime appointmentDateTime = Convert.ToDateTime(appointmentDateValue);
                        CreateAppointment(id, appointmentDateTime);
                        
                    }
                }
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "GirisYapilmadi",
                  "alert('Randevu alabilmek için giriş yapmalısınız.');", true);

            }
        }

        private void CreateAppointment(int id, DateTime createAppointment)
        {
            try
            {
                int urunid = Convert.ToInt32(Session["MachineID"].ToString());
                var sorgu = _machineService.GetMachineWithIdDetails(urunid);


                CreateServiceExpertizDto serviceExpertizDto = new CreateServiceExpertizDto();
                if (sorgu != null)
                {
                    int appointmentCreateUserID = Convert.ToInt32(Session["uye_ID"].ToString());
                    var serviceUser = _userService.GetUser(id);
                    var createAppointmentUser = _userService.GetUser(appointmentCreateUserID);   

                    serviceExpertizDto.Randevu_Tarihi = createAppointment;
                    serviceExpertizDto.Adi = createAppointmentUser.Adi;
                    serviceExpertizDto.Soyadi = createAppointmentUser.Soyadi;
                    serviceExpertizDto.EMail = createAppointmentUser.EMail;
                    serviceExpertizDto.Telefon = createAppointmentUser.Telefon;
                    serviceExpertizDto.Baslik = sorgu.Baslik;
                    serviceExpertizDto.yil_ID = sorgu.yearID ?? 0 ;
                    serviceExpertizDto.marka_ID = sorgu.marka_ID ?? 0;
                    serviceExpertizDto.tur_ID = sorgu.tur_ID ?? 0;
                    serviceExpertizDto.Alttur_ID = sorgu.Alttur_ID ?? 0;
                    serviceExpertizDto.Model = sorgu.Model;
                    serviceExpertizDto.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                    
                    serviceExpertizDto.Kayit_Tarihi = DateTime.Now;

                    serviceExpertizDto.ExpertizFirmasi_ID = id;
                    serviceExpertizDto.uye_ID = appointmentCreateUserID;


                    _expertizService.CreateServiceExpertiz(serviceExpertizDto);


                    ////Service user mail gönderiyoruz
                    //mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. Expertiz randevu ayrıntıları aşağıda yer almaktadır. <br /><br/><br/><strong>Üye Adı Soyadı:</strong> " + createAppointmentUser.Adi + " " + createAppointmentUser.Soyadi + "<br/><strong>Başlık:</strong> " + sorgu.Baslik + "<br /><strong>Tür:</strong> " + ltTur1.Text + "<br /><strong>Alt Kategori:</strong> " + ltAltTur1.Text + "<br/><strong>Marka:</strong> " + ltMarka1.Text + "<br /><strong>Yıl:</strong>" + lblYil1.Text + "<br /><strong>Model:</strong>" + lblModel1.Text + "<br /><strong>Randevu Tarihi:</strong> " + createAppointment + "<br /><br /><strong>E-Mail:</strong><br /><br />" + createAppointmentUser.EMail + "<br /><br /><strong>Telefon:</strong><br /><br />" + createAppointmentUser.Telefon + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                    //BenimMailim = new Mailler();
                    //BenimMailim.Send_EMail("Expertiz Talebi", mailaciklama, serviceUser.EMail, "");

                    ////Kişiye mail gönderiyoruz
                    //if (createAppointmentUser.EMail != "")
                    //{
                    //    mailaciklama = "Sayın " + createAppointmentUser.Adi +" " + createAppointmentUser.Soyadi +  ",<br/><br/>Makina ekspertiz talebiniz <strong>" + createAppointment + "</strong> tarihine alınmıştır.<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                    //    BenimMailim = new Mailler();
                    //    BenimMailim.Send_EMail("Expertiz Talebi", mailaciklama, createAppointmentUser.EMail, "");
                    //}


                    string message = $"{serviceUser.FirmaAdi} ekspertiz firması için {DateTime.Now.ToString("dd/MM/yyyy")} tarihli randevu talebiniz başarıyla alınmıştır.";

                    string script = $"var message = '{message}'; alert(message);";

                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageAlert", script, true);

                }


            }
            catch (Exception ex)
            {
                log.Error(string.Format("{0} / {1}", "", ex));
            }







        }

    }
}