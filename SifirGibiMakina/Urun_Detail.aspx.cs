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

namespace SifirGibiMakina
{
    public partial class Urun_Detail : System.Web.UI.Page
    {
        Mailler BenimMailim;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (RouteData.Values["urunid"] != null)
                {
                    
                    int urunid = Convert.ToInt32(RouteData.Values["urunid"].ToString());
                    string Lang = Session["Lang"].ToString();

                    ///////////////////////////////////////Favori İşlemleri////////////////////////////////////////
                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();

                    if (Session["Giris"] != null)
                    {
                        int uyeNo = Convert.ToInt32(Session["uye_ID"].ToString());
                        var favori = from c in nt.tbl_ilanFavorileri
                                    where c.makina_ID == urunid && c.user_ID==uyeNo
                                    select c;
                        var count = favori.Count();
                        if (count > 0)
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
                    ///////////////////////////////////////İçerikler alınıyor//////////////////////////////////////
                    
                    string isaret = "";
                    string duzenlenmistelefon = "";
                    int varolangoruntulenmesayisi = 0;
                    var sorgu = from c in nt.tbl_Makinalar
                                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                join A in nt.tbl_MakinaAltTurleri on c.Alttur_ID equals A.Alttur_ID
                                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                where c.makina_ID == urunid && c.Durum==true && c.dil_ID==1 && c.Yayinda == true && (c.Statu== 2 || c.Statu == 4 || c.Statu == 5)
                                select new { c.marka_ID, c.tur_ID, c.Alttur_ID, c.Aciklama, c.Baslik, c.Para_Birimi, c.SeoKeywords, c.SeoDescription,c.SosyalMedyaPaylasim, c.Fotograf, Marka= M.Kategori, c.Model, Yil= Y.Kategori, c.Fiyat, Tur= T.Kategori, c.Ihale, c.Satis_Temsilcisi_Adi, c.Satis_Temsilcisi_Email, c.Satis_Temsilcisi_Telefon, c.makina_ID, c.Ihale_Baslangic, c.Ihale_Bitis, c.Kapora, c.KM, c.Statu, c.il, c.ilce, c.GoruntulenmeSayisi, c.IlanNo, c.FavoriSayisi, c.Kimden, c.Yayinlanma_Tarihi, AltTur = A.Kategori, c.Ekleyen, c.FiyatGosterilmesin, c.Ulke, c.TelefonNumarasiGostermeSayisi, c.SEOUrl};
                    //Ürün Varsa İşlem Yap
                    if(sorgu.Count() > 0)
                    { 
                    
                    foreach (var prod in sorgu)
                    {
                        ////Telefon numarası doğru mu?
                        //if (prod.Satis_Temsilcisi_Telefon.Length < 11)
                        //{
                        //    duzenlenmistelefon = "0" + prod.Satis_Temsilcisi_Telefon;
                        //}
                        //else
                        //{
                        //    duzenlenmistelefon = prod.Satis_Temsilcisi_Telefon;
                        //}

                        duzenlenmistelefon = prod.Satis_Temsilcisi_Telefon;

                        lblBaslik.Text = prod.Baslik;
                        lblBaslik1.Text = prod.Baslik;
                        lblBaslik2.Text = prod.Baslik;
                        lblilanBaslik.Text = prod.Baslik;
                        lblYayinTarihi.Text = Convert.ToDateTime(prod.Yayinlanma_Tarihi).ToString("dd.MM.yyyy");
                        lblYayinTarihi1.Text = Convert.ToDateTime(prod.Yayinlanma_Tarihi).ToString("dd.MM.yyyy");
                        lblilanNo.Text = prod.IlanNo.ToString();
                        lblIlanNo1.Text = prod.IlanNo.ToString();
                        lblYil1.Text = prod.Yil.ToString();
                        ltMarka1.Text = "<a href=/marka/" + ReWriterPath("1", prod.Marka, "1") + "/ikinci-el-makina/" + prod.marka_ID + "><span>" + prod.Marka + "</span></a>";
                        lblModel1.Text = prod.Model;
                        ltTur1.Text = "<a href=/kategori/" + ReWriterPath("1", prod.Tur, "1") + "/ikinci-el-makina/" + prod.tur_ID + "><span>" + prod.Tur + "</span></a>";
                        ltAltTur1.Text = prod.AltTur;
                        ltTur2.Text = "<a href=/kategori/" + ReWriterPath("1", prod.Tur, "1") + "/ikinci-el-makina/" + prod.tur_ID + "><span>" + prod.Tur + "</span></a>";
                        Session["AltTur"] = prod.Alttur_ID;

                        if (prod.ilce != "") { isaret = ", "; }


                        if (prod.KM.Length > 1)
                        {
                            lblCalismaSaati.Text = prod.KM;
                        }
                        else
                        {
                            lblCalismaSaati.Text = "Belirtilmedi";
                        }
                        ltAciklama.Text = prod.Aciklama;
                       

                        //Ülkeyi yazdırıyoruz
                        var ulkesorgu = from c in nt.tbl_Ulkeler
                        
                                    where c.id == prod.Ulke
                                    select new { c.nicename, c.iso, c.GoogleTranslateCode };

                        foreach (var produlke in ulkesorgu)
                        {
                            lblil.Text = ToTitleCase(prod.ilce.ToLower()) + isaret + ToTitleCase(prod.il.ToLower()) + " - <img src=\"https://flagcdn.com/w40/" + produlke.iso.ToLower() + ".png\"  srcset=\"https://flagcdn.com/w80/" + produlke.iso.ToLower() + ".png 2x\"  width=\"40\"  alt=\"" + produlke.nicename + "\">";
                            lblIl1.Text = ToTitleCase(prod.ilce.ToLower()) + isaret + ToTitleCase(prod.il.ToLower()) + " - <img src=\"https://flagcdn.com/w40/" + produlke.iso.ToLower() + ".png\"  srcset=\"https://flagcdn.com/w80/" + produlke.iso.ToLower() + ".png 2x\"  width=\"40\"  alt=\"" + produlke.nicename + "\">";

                            if (produlke.iso != "TR")
                            {
                                ltAciklama.Text += "<br/>* Bu ilan otomatik olarak çevrildiği için bazı çeviri hataları oluşmuş olabilir.";
                            }

                            Session["Ulke"] = produlke.GoogleTranslateCode.ToString();
                        }


                        

                       

                        ltFiyat.Text = string.Format("{0:0,0}", prod.Fiyat);
                        ltFiyat1.Text = string.Format("{0:0,0}", prod.Fiyat);
                        //Fiyatı Session atıyoruz favorilerde kullanmak için
                        Session["Fiyat"] = prod.Fiyat;
                        Session["FavoriSayisi"] = prod.FavoriSayisi;
                        Session["TelefonGoruntulenmeSayisi"] = prod.TelefonNumarasiGostermeSayisi;
                        varolangoruntulenmesayisi = Convert.ToInt32(prod.GoruntulenmeSayisi);

                        //Ana Resim
                        var urunresimsorgu = from c in nt.tbl_MakinaResimler
                                             where c.Durum == true && c.Vitrin == true && c.makina_ID == urunid
                                             select c;

                        foreach (var prods in urunresimsorgu)
                        {
                            string[] a = prods.Fotograf.Split('.');
                            ltResim.Text = "<img src=" + WebConfigurationManager.AppSettings["imagePath"] + "/" + a[0] + "_d." + a[1]+ " class=img-fluid alt=\"" + prod.Baslik + "\" > ";

                        }

                        if (urunresimsorgu.Count() == 0)
                        {
                            ltResim.Text = "<img src=" + WebConfigurationManager.AppSettings["imagePath"] + "/ornekfoto.jpg class=img-fluid alt =\"" + prod.Baslik + "\" > ";
                        }

                        
                        //Para Birimi
                        string parabirimi = prod.Para_Birimi.ToString();
                        if (parabirimi == "1" && prod.Fiyat.ToString() != "")
                        {
                            ltParaBirimi.Text = "&#8378";
                            ltParaBirimi1.Text = "&#8378";
                            ltFiyatOneriParaBirimi.Text = "&#8378";
                        }
                        else if (parabirimi == "2" && prod.Fiyat.ToString() != "")
                        {
                            ltParaBirimi.Text = "&euro;";
                            ltParaBirimi1.Text = "&euro;";
                            ltFiyatOneriParaBirimi.Text = "&euro;";
                        }
                        else if (parabirimi == "3" && prod.Fiyat.ToString() != "")
                        {
                            ltParaBirimi.Text = "$";
                            ltParaBirimi1.Text = "$";
                            ltFiyatOneriParaBirimi.Text = "$";
                        }

                        //Eğer İlan Fiyat Gösterilmesin sadece teklif talep edilsin olarak işaretlendiyse fiyatları gizle
                        if (prod.FiyatGosterilmesin==true)
                        {
                            ltParaBirimi.Visible = false;
                            ltParaBirimi1.Visible = false;
                            ltFiyat.Visible = false;
                            ltFiyat1.Visible = false;
                            ltTeklifTalebi.Visible = true;
                            ltTeklifTalebi.Visible = true;
                        }

                        //Benzer İlanları Doldur
                        BenzerIlanlarDoldur();

                        //Resimleri Goster
                        var images = from c in nt.tbl_MakinaResimler
                                     where c.Durum == true && c.makina_ID == urunid
                                     select c;

                        rptGaleri.DataSource = images.ToList();
                        rptGaleri.DataBind();
                        rptGaleri1.DataSource = images.ToList();
                        rptGaleri1.DataBind();

                        if (images.Count() == 0)
                        {
                            rptGaleri1.Visible = false;
                            rptGaleri.Visible = false;
                            ltResim.Visible = true;
                            ltResim.Text = "<img src="+ConfigurationManager.AppSettings["imagePath"].ToString() + "ornekfoto.jpg"+">";
                        }

                        //Firma Logosu Varsa Firma adı ve Logosu Eklensin
                        var sorguFirma = from c in nt.tbl_FirmaLogolari
                                         join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                         join U in nt.tbl_Uyeler on c.uye_ID equals U.uye_ID
                                         where c.uye_ID == prod.Ekleyen && c.Durum == true && c.dil_ID == 1
                                         select new { c.Aciklama, U.Adres, U.Telefon, c.Buyuk_Logo, c.Baslik, U.Il, U.Ilce };
                        foreach (var prods in sorguFirma)
                        {

                            lblFirmaismi.Text = prods.Baslik;
                            string[] a = prods.Buyuk_Logo.Split('.');
                            imgLogo.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1];
                            ltLink.Text = "<a href=\"/satici-firma/" + prod.Ekleyen + "/" + ReWriterPath("1", prods.Baslik, "1") + "/ikinci-el-makina\"><img class=\"img-fluid\" src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1] + "></a>";

                        }

                        //Eğer firma logolar kısmında yoksa profilde yer alan firma ismi buraya yazılacak
                        if (sorguFirma.Count() <= 0)
                        {

                            var sorguKisi = from c in nt.tbl_Uyeler
                                            where c.uye_ID == prod.Ekleyen
                                            select new { c.FirmaAdi };
                            foreach (var prods in sorguKisi)
                            {

                                lblFirmaismi.Text = prods.FirmaAdi;

                            }

                        }



                        //Eksper Bilgisi
                        var Eksper = from c in nt.tbl_MakinaEksperSecimi
                                     join M in nt.tbl_Makinalar on c.makina_ID equals M.makina_ID
                                     join D in nt.tbl_MakinaEksper on c.eksper_ID equals D.eksper_ID
                                     where c.makina_ID == urunid && c.Note > 0 && M.Durum == true
                                     select new { D.Kategori, c.Note };
                        rptEksper.DataSource = Eksper.ToList();
                        rptEksper.DataBind();

                        if (Eksper.Count() == 0)
                        {
                            eksperyazi.Visible = false;
                        }

                        //İlan üyeden ise ve sisteme giriş yapılmış ise mesaj gonder butonu gösterilsin
                        if ((prod.Kimden == 1 || prod.Kimden == 2 || prod.Kimden == 3) && (Session["Giris"] != null))
                        {
                            
                            ltMesajLinki.Visible = true;
                            //ltMesajLinki.Text = "<a href=/mesajgonder/" + prod.makina_ID + " class=\"btn btn-outline-success btn-block detay-button\"><span class=\"far fa-envelope\"></span> Mesaj Gönder</a>";
                            ltMesajLinki.Text = "<a href=\"#saticiiletisim\" class=\"btn btn-outline-success btn-block detay-button\"><span class=\"far fa-envelope\"></span> Mesaj Gönder</a>";
                        }
                        else if ((prod.Kimden == 1 || prod.Kimden == 2 || prod.Kimden == 3) && (Session["Giris"] == null))
                        {
                            ltMesajLinki.Visible = true;
                            ltMesajLinki.Text = "<a href=\"/uye-ol\" class=\"btn btn-outline-success btn-block detay-button\"><span class=\"far fa-envelope\"></span> Mesaj Gönder</a>";

                        }

                        //İhale
                        if (prod.Ihale==true)
                        {
                            if (prod.Ihale_Baslangic < DateTime.Now && prod.Ihale_Bitis < DateTime.Now)
                            {
                                //ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon+ "</a><br/>";
                                ltTemsilciWhatsapp.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + prod.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> Whatsapp </a>";
                                ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon.Substring(0, 2) + "** *** ****" + "</a><br/>";
                                //ltTemsilciEmail.Text = "<a href=mailto:" + prod.Satis_Temsilcisi_Email + " class=link>" + prod.Satis_Temsilcisi_Email.Substring(0, 3) + "**@*******" + "</a>";

                                ltIhale.Text = "<span class=\"btn btn-warning btn-block detay-button my-3\"><i class='fa fa-exclamation-circle'></i> İhale Tamamlandı</span>";
                                pnlIhale.Visible = false;
                                
                                ltTemsilciWhatsapp.Visible = false;
                                ltMesajLinki.Visible=false;
                            }
                            else if (prod.Ihale_Baslangic > DateTime.Now && prod.Ihale_Bitis > DateTime.Now)
                            {
                                ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon + "</a><br/>";
                                ltTemsilciWhatsapp.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + prod.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> Whatsapp </a>";
                                ltIhale.Text = "<span><i class='fa fa-exclamation-circle'></i></span> İhale Henüz Başlamadı<br/><a href=/ihale/" + prod.makina_ID + " class=\"btn btn-warning btn-block detay-button my-3\">İhaleye Katıl</a>";
                                pnlIhale.Visible = true;
                                lblBaslangic.Text = prod.Ihale_Baslangic.Value.ToString();
                                lblBitis.Text = prod.Ihale_Bitis.Value.ToString();

                                //Gün Hesaplama
                                DateTime baslangictarihi = DateTime.Now;
                                DateTime bitistarihi = Convert.ToDateTime(prod.Ihale_Baslangic);
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
                                    lblKapora.Text = prod.Kapora + " &#8378";
                                }
                                else if (parabirimi == "2")
                                {
                                    lblKapora.Text = prod.Kapora + " &euro;";
                                }
                                else if (parabirimi == "3")
                                {
                                    lblKapora.Text = prod.Kapora + " $";
                                }
                            }
                            else if (prod.Ihale_Baslangic < DateTime.Now && prod.Ihale_Bitis > DateTime.Now)
                            {
                                ltTemsilci.Text = ToTitleCase(prod.Satis_Temsilcisi_Adi.ToLower());
                                ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon + "</a><br/>";
                                ltTemsilciWhatsapp.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + prod.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> Whatsapp </a>";
                                ltIhale.Text = "<a href=/ihale/" + prod.makina_ID + " class=\"btn btn-warning btn-block detay-button my-3\">İhaleye Katıl</a>";
                                live.Visible = true;
                                pnlIhale.Visible = true;
                                lblBaslangic.Text = prod.Ihale_Baslangic.Value.ToString();
                                lblBitis.Text = prod.Ihale_Bitis.Value.ToString();

                                //Gün Hesaplama
                                DateTime baslangictarihi = DateTime.Now;
                                DateTime bitistarihi = Convert.ToDateTime(prod.Ihale_Baslangic);
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
                                    lblKapora.Text = prod.Kapora + " &#8378";
                                }
                                else if (parabirimi == "2")
                                {
                                    lblKapora.Text = prod.Kapora + " &euro;";
                                }
                                else if (parabirimi == "3")
                                {
                                    lblKapora.Text = prod.Kapora + " $";
                                }
                            }
                            }
                        else
                        {
                            ltTemsilci.Text = ToTitleCase(prod.Satis_Temsilcisi_Adi.ToLower());
                            ltTemsilciTel.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon + "</a><br/>";
                            ltTemsilciWhatsapp.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + prod.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-success btn-block detay-button my-3\"><i class=\"fas fa-phone - alt\"></i> Whatsapp </a>";
                            ltTeklifTalebi.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + prod.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-warning btn-block detay-button my-3\"><i class=\"fas fa-whatsapp - alt\"></i> Teklif Talebi Gönder </a>";
                            ltTeklifTalebi1.Text = "<a href = 'https://api.whatsapp.com/send?phone=" + duzenlenmistelefon + "&text=Merhaba,%20 www.sifirgibimakine.com sayfasındaki " + prod.Baslik + " ürününü satınalmak istiyorum.' target=_blank class=\"btn btn-warning btn-block detay-button my-3\"><i class=\"fas fa-whatsapp - alt\"></i> Teklif Talebi Gönder </a>";
                            ltIhale.Visible = false;
                            //ltIhale.Text = "<a href=/iletisim/" + prod.makina_ID+ " class=\"btn btn-warning btn-block detay-button my-3\">Satınalmak İstiyorum</a>";
                        }

                        if (prod.Statu == 4 || prod.Statu == 5)
                        {
                            //ltIhale.Visible = false;
                            pnlIhale.Visible = false;
                            
                        }


                        ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                        Master.Page.Title = prod.Baslik + " | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                        Master.Page.MetaDescription = "ikinci el makina, 2. el makine. "+ prod.SeoDescription.ToString();
                        Master.Page.MetaKeywords = prod.SeoKeywords.ToString();

                        HtmlMeta tag0 = new HtmlMeta();
                        tag0.Attributes.Add("property", "og:locale");
                        tag0.Content = "tr_TR";
                        Page.Header.Controls.Add(tag0);


                        HtmlMeta tag = new HtmlMeta();
                        tag.Attributes.Add("property", "og:title");
                        tag.Content = prod.Baslik + " | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                        Page.Header.Controls.Add(tag);

                        HtmlMeta tag1 = new HtmlMeta();
                        tag1.Attributes.Add("property", "og:description");
                        tag1.Content = "ikinci el makina, 2. el makine. " + prod.SeoDescription.ToString();
                        Page.Header.Controls.Add(tag1);

                        HtmlMeta tag02 = new HtmlMeta();
                        tag02.Attributes.Add("property", "og:site_name");
                        tag02.Content = "Sıfır Gibi Makina";
                        Page.Header.Controls.Add(tag02);

                        //Resimleri Goster
                        var imagess = from c in nt.tbl_MakinaResimler
                                      where c.Durum == true && c.makina_ID == urunid && c.Vitrin == true
                                      select c;

                        foreach (var prodss in imagess)
                        {
                            string fotograf = prodss.Fotograf;
                            string[] a = fotograf.Split('.');


                            HtmlMeta tagimg = new HtmlMeta();
                            tagimg.Attributes.Add("property", "og:image");
                            tagimg.Attributes.Add("itemprop", "image");
                            tagimg.Content = "https://sifirgibimakine.com" + WebConfigurationManager.AppSettings["imagePath"] + a[0] + "_v." + a[1];
                            Page.Header.Controls.Add(tagimg);

                            HtmlMeta tagimg1 = new HtmlMeta();
                            tagimg1.Attributes.Add("property", "og:img");
                            tagimg1.Content = "https://sifirgibimakine.com" + WebConfigurationManager.AppSettings["imagePath"] + a[0] + "_v." + a[1];
                            Page.Header.Controls.Add(tagimg1);

                            HtmlMeta tagt3img = new HtmlMeta();
                            tagt3img.Name = "twitter:image";
                            tagt3img.Content = "https://sifirgibimakine.com" + WebConfigurationManager.AppSettings["imagePath"] + a[0] + "_v." + a[1];
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
                        tagt1.Content = prod.Baslik + " | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                        Page.Header.Controls.Add(tagt1);

                        HtmlMeta tagt2 = new HtmlMeta();
                        tagt2.Name = "twitter:description";
                        tagt2.Content = "ikinci el makina, 2. el makine. " + prod.SeoDescription.ToString();
                        Page.Header.Controls.Add(tagt2);

                        HtmlMeta tagt3 = new HtmlMeta();
                        tagt2.Name = "twitter:url";
                        tagt3.Content = Request.Url.AbsoluteUri.ToString();
                        Page.Header.Controls.Add(tagt3);

                        

                        /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

                        

                    }


                    //Görüntüleme sayısı Güncelleniyor
                    var Guncelle = (from c in nt.tbl_Makinalar
                                    where c.makina_ID == urunid && c.Durum == true
                                    select c).First();
                    Guncelle.GoruntulenmeSayisi = varolangoruntulenmesayisi + 1;
                    nt.SaveChanges();
                }

                else
                    {
                        Response.Redirect("/404.aspx");
                    }

            }

            //}
            //catch (Exception ex)
            //{
            //    pnlError.Visible = true;
            //    lblHataMesaji.Text = Dil.Res.HataMesaji;
            //    lblHata.Text = Dil.Res.Hata;
            //    log.Error(string.Format("{0}", ex));
            //}
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
                    Prosess.Text = "<div class=\"progress\"><div class=\"progress-bar progress-bar-striped bg-danger\" role=\"progressbar\" aria-valuenow=" + Note.ToString() +"0 aria-valuemin='0' aria-valuemax='10' style='width:"+Note.ToString()+0+"%'>"+Note.ToString()+ "</div></div>";
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
                int urunid = Convert.ToInt32(RouteData.Values["urunid"].ToString());
                int uyeNo = Convert.ToInt32(Session["uye_ID"].ToString());

                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
                tbl_ilanFavorileri favori = new tbl_ilanFavorileri();

                favori.user_ID = uyeNo;
                favori.makina_ID = urunid;
                favori.EklenenFiyat = Session["Fiyat"].ToString();
                favori.Kayit_Tarihi = DateTime.Now;
                favori.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                Gs.tbl_ilanFavorileri.Add(favori);
                Gs.SaveChanges();

                //Favori eklenme sayısını güncelliyoruz.
                var Guncelle = (from c in Gs.tbl_Makinalar
                                where c.makina_ID == urunid && c.Durum == true
                                select c).First();
                Guncelle.FavoriSayisi = Convert.ToInt32(Session["FavoriSayisi"]) + 1;
                Gs.SaveChanges();

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
            int urunid = Convert.ToInt32(RouteData.Values["urunid"].ToString());
            int uyeNo = Convert.ToInt32(Session["uye_ID"].ToString());
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            //Favoriyi Siliyoruz

            var VeriSila = (from c in Gs.tbl_ilanFavorileri
                            where c.makina_ID == urunid && c.user_ID == uyeNo
                            select c);
            foreach (var u in VeriSila)
            {
                Gs.tbl_ilanFavorileri.Remove(u);
            }
            Gs.SaveChanges();

            //Favori eklenme sayısını güncelliyoruz.
            var Guncelle = (from c in Gs.tbl_Makinalar
                            where c.makina_ID == urunid && c.Durum == true
                            select c).First();
            Guncelle.FavoriSayisi = Convert.ToInt32(Session["FavoriSayisi"]) - 1;
            Gs.SaveChanges();


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
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            string Lang = Session["Lang"].ToString();
            int Tur = Convert.ToInt32(Session["AltTur"].ToString());
            //Ürünler Listeleniyor Seçiyoruz
            var urunsorgu = from c in nt.tbl_Makinalar
                            join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            where c.Durum == true && c.Yayinda == true && c.Statu == 2 && c.Alttur_ID == Tur
                            orderby c.Kayit_Tarihi descending
                            select new { c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, c.Model, c.Para_Birimi, Tur = T.Kategori, Yil = Y.Kategori, Marka = M.Kategori, c.Yayinlanma_Tarihi, c.FiyatGosterilmesin, c.SEOUrl };

            rptBenzerIlanlar.DataSource = urunsorgu.ToList().Take(4);
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

                var urunresimsorgu = from c in nt.tbl_MakinaResimler
                                     where c.Durum == true && c.Vitrin == true && c.makina_ID == makinaID
                                     select c;

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

            int urunid = Convert.ToInt32(RouteData.Values["urunid"].ToString());


            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

            //Telefon Görüntülenme eklenme sayısını güncelliyoruz.
            var Guncelle = (from c in Gs.tbl_Makinalar
                            where c.makina_ID == urunid && c.Durum == true
                            select c).First();
            Guncelle.TelefonNumarasiGostermeSayisi = Convert.ToInt32(Session["TelefonGoruntulenmeSayisi"]) + 1;
            Gs.SaveChanges();


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
                
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                int urunid = Convert.ToInt32(RouteData.Values["urunid"].ToString());
                string aliciAdi = "";
                string aliciEmail = "";
                var sorgu = from c in nt.tbl_Makinalar
                            join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                            join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join A in nt.tbl_MakinaAltTurleri on c.Alttur_ID equals A.Alttur_ID
                            join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            where c.makina_ID == urunid && c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && (c.Statu == 2 || c.Statu == 4 || c.Statu == 5)
                            select new { c.Satis_Temsilcisi_Adi, c.Satis_Temsilcisi_Email, c.Satis_Temsilcisi_Telefon, c.makina_ID, c.Baslik, c.IlanNo, c.Fiyat, c.Para_Birimi };
                //Ürün Varsa İşlem Yap
                if (sorgu.Count() > 0)
                {
                    foreach (var prod in sorgu)
                    {
                        aliciAdi = prod.Satis_Temsilcisi_Adi;
                        aliciEmail = prod.Satis_Temsilcisi_Email;
                        Session["Baslik"] = prod.Baslik;
                        Session["IlanNo"] = prod.IlanNo;
                        Session["makinaID"] = prod.makina_ID;
                        Session["Fiyat"] = prod.Fiyat;
                        Session["ParaBirimi"] = prod.Para_Birimi;
                    }
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
                var urunresimsorgu = from c in nt.tbl_MakinaResimler
                                     where c.Durum == true && c.makina_ID == urunid && c.Vitrin == true
                                     select c;

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
                if (txtTelefonM.Value.Length>3)
                {
                    telefon = " / +" + txtDialCodeM.Value + txtTelefonM.Value.Trim();
                }

                string aciklama = "Sayın Bay/Bayan<b> " + txtAdi.Text.ToUpper() + " (" + txtEmail.Text + telefon + " ),</b> belirtilen özelliklere sahip makinenizle ilgileniyor. Potansiyel müşterinin mesajı aşağıdadır.<br><br>sifirgibimakine.com, makinenizin satışında size başarılar diler!<br><br>Saygılarımızla<br>SifirGibiMakine.com ekibiniz<hr>";
                string mesaj = otomatikMetin + "<br><br>" + Translate.OtomatikCeviri(txtMesaj.Text, Session["Ulke"].ToString()).ToString() + "<br><hr>Anlamayı kolaylaştırmak için, bu mesajın münferit bölümleri otomatik olarak tercüme edilmiştir. Ancak bu, müşterinin sizin dilinizi konuştuğu anlamına gelmez.";
                BenimMailim = new Mailler();
                string mailBody = BenimMailim.SetIlanMailMesaji(Session["IlanNo"].ToString(), Translate.OtomatikCeviri(Session["Baslik"].ToString(), Session["Ulke"].ToString()).ToString(), Session["Fotograf"].ToString(), Session["Fiyat"].ToString(), Session["ParaBirimi"].ToString(), Translate.OtomatikCeviri(mesaj, Session["Ulke"].ToString()).ToString(), aliciAdi, txtAdi.Text + " ( "+txtEmail.Text+ telefon +" )", Translate.OtomatikCeviri(aciklama, Session["Ulke"].ToString()).ToString(), Translate.OtomatikCeviri("Yeni Bir Mesajınız Var!", Session["Ulke"].ToString()).ToString());
                BenimMailim.Send_EMailMessage(Translate.OtomatikCeviri("Yeni Mesaj", Session["Ulke"].ToString()).ToString(), mailBody, aliciEmail, txtEmail.Text);

                pnlMesaj.Visible = false;
                pnlBitti.Visible = true;
                lblMesajBaslik.Text = "Mesajınız Gönderildi";
                lblMesaj.Text = "Mesajınız başarılı bir şekilde gönderildi. Satıcı sizinle iletişime geçecektir.";
                string urlm = Request.RawUrl;
                //Response.Redirect(urlm+"#saticiiletisim", false);
                Response.AddHeader("Refresh", "2;URL="+urlm+"#saticiiletisim");


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