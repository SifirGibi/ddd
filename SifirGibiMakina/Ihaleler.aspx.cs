using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class Ihaleler : System.Web.UI.Page
    {
        int markaID;
        int turID;
        int altturID;
        int yil_min;
        int yil_max;
        int minfiyat;
        int maxfiyat;
        int parabirimi;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();

            ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

            Master.Page.Title = "2. el makinalar, 2. el makineler, ikinci el makina al sat, ihaleli makineler";
            Master.Page.MetaDescription = "Sahibinden veya satıcıdan ikinci el satılık makina fiyatları ilanları yer alan 2 el sifir gibi yeni makine ilan sitesidir. Makine satıcıları ve alıcılarının buluşma portalı..";
            Master.Page.MetaKeywords = "2. el makinalar, 2. el makineler, ikinci el makina al sat, ihaleli makineler, makina al sat, makine al sat, talaşlı makina, cnc makinaları";

            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

            

            //////Mobilden giriniyorsa diğer datalist görünsün
            //System.Web.HttpBrowserCapabilities browser = Request.Browser;
            
            //if (browser.IsMobileDevice == true)
            //{
            //    dtOneCikanKategorilerMobil.Visible = true;
            //    //Kategoriler sadece ilk sayfada görünsün
            //    if (Request.Url.AbsoluteUri.ToString() == "https://sifirgibimakina.com/urunler" || Request.Url.AbsoluteUri.ToString() == "https://sifirgibimakina.com/urunler?Sayfa=1" || Request.Url.AbsoluteUri.ToString() == "https://www.sifirgibimakina.com/urunler" || Request.Url.AbsoluteUri.ToString() == "https://www.sifirgibimakina.com/urunler?Sayfa=1" || Request.Url.AbsoluteUri.ToString() == "http://localhost:55465/urunler" || Request.Url.AbsoluteUri.ToString() == "http://localhost:55465/urunler?Sayfa=1")
            //    {
            //        dtOneCikanKategorilerMobil.Visible = true;
            //    }
            //    else
            //    {
            //        dtOneCikanKategorilerMobil.Visible = false;
            //    }
            //    //dtOneCikanKategoriler.RepeatColumns = 2;
            //    //dtOneCikanKategoriler.Visible = false;
               

            //}
            //else if (browser.IsMobileDevice == false)
            //{
            //    dtOneCikanKategoriler.Visible = true;
            //    //Kategoriler sadece ilk sayfada görünsün
            //    if (Request.Url.AbsoluteUri.ToString() == "https://sifirgibimakina.com/urunler" || Request.Url.AbsoluteUri.ToString() == "https://sifirgibimakina.com/urunler?Sayfa=1" || Request.Url.AbsoluteUri.ToString() == "https://www.sifirgibimakina.com/urunler" || Request.Url.AbsoluteUri.ToString() == "https://www.sifirgibimakina.com/urunler?Sayfa=1" || Request.Url.AbsoluteUri.ToString() == "http://localhost:55465/urunler" || Request.Url.AbsoluteUri.ToString() == "http://localhost:55465/urunler?Sayfa=1")
            //    {
            //        dtOneCikanKategoriler.Visible = true;
            //    }
            //    else
            //    {
            //        dtOneCikanKategoriler.Visible = false;
            //    }

            //    //dtOneCikanKategoriler.Visible = true;
            //    //dtOneCikanKategorilerMobil.Visible = false;

            //    var control = FindHtmlControlByIdInControl(this, "collapse1");

            //    if (control != null)
            //    {
            //        control.Attributes["class"] = " in show";
            //    }
            //}


            if (!IsPostBack)
            {

                //Türleri Listeliyoruz
                var Turler = from c in nt.tbl_MakinaTurleri
                             where c.dil_ID == 1 && c.Durum==true
                             orderby c.Kategori ascending
                             select c;

                ddTurler.DataSource = Turler.ToList();
                ddTurler.DataValueField = "tur_ID";
                ddTurler.DataTextField = "Kategori";
                ddTurler.DataBind();
                ListItem lit = new ListItem("Makine Türü(Tümü)", "0");
                ddTurler.Items.Add(lit);
                ddTurler.SelectedValue = "0";

                ddTurlerMobil.DataSource = Turler.ToList();
                ddTurlerMobil.DataValueField = "tur_ID";
                ddTurlerMobil.DataTextField = "Kategori";
                ddTurlerMobil.DataBind();
                ListItem litm = new ListItem("Makine Türü(Tümü)", "0");
                ddTurlerMobil.Items.Add(litm);
                ddTurlerMobil.SelectedValue = "0";

                //Alt Türleri Listeliyoruz
                var AltTurler = from c in nt.tbl_MakinaAltTurleri
                                where c.Durum == true && c.dil_ID == 1
                                orderby c.Kategori ascending
                                select c;

                ddTurlerAlt.DataSource = AltTurler.ToList();
                ddTurlerAlt.DataValueField = "Alttur_ID";
                ddTurlerAlt.DataTextField = "Kategori";
                ddTurlerAlt.DataBind();
                ListItem litaa = new ListItem("Alt Kategori(Tümü)", "0");
                ddTurlerAlt.Items.Add(litaa);
                ddTurlerAlt.SelectedValue = "0";

                ddTurlerAltMobil.DataSource = AltTurler.ToList();
                ddTurlerAltMobil.DataValueField = "Alttur_ID";
                ddTurlerAltMobil.DataTextField = "Kategori";
                ddTurlerAltMobil.DataBind();
                ListItem litaam = new ListItem("Alt Kategori(Tümü)", "0");
                ddTurlerAltMobil.Items.Add(litaam);
                ddTurlerAltMobil.SelectedValue = "0";


                //Markaları Listeliyoruz
                var Markalar = from c in nt.tbl_MakinaMarkalari
                               where c.dil_ID == 1 && c.Durum==true
                               orderby c.Kategori ascending
                               select c;

                ddMarkalar.DataSource = Markalar.ToList();
                ddMarkalar.DataValueField = "marka_ID";
                ddMarkalar.DataTextField = "Kategori";
                ddMarkalar.DataBind();
                ListItem lim = new ListItem("Marka(Tümü)", "0");
                ddMarkalar.Items.Add(lim);
                ddMarkalar.SelectedValue = "0";

                ddMarkalarMobil.DataSource = Markalar.ToList();
                ddMarkalarMobil.DataValueField = "marka_ID";
                ddMarkalarMobil.DataTextField = "Kategori";
                ddMarkalarMobil.DataBind();
                ListItem limm = new ListItem("Marka(Tümü)", "0");
                ddMarkalarMobil.Items.Add(limm);
                ddMarkalarMobil.SelectedValue = "0";


                //Yılları Listeliyoruz
                var Yillar = from c in nt.tbl_MakinaYillar
                               where c.dil_ID == 1 && c.Durum==true
                               orderby c.Kategori ascending
                               select c;

                
               
                ddYilMin.DataSource = Yillar.ToList();
                ddYilMin.DataValueField = "Kategori";
                ddYilMin.DataTextField = "Kategori";
                ddYilMin.DataBind();
                ListItem limym = new ListItem("Yıl(Min)", "0");
                ddYilMin.Items.Add(limym);
                ddYilMin.SelectedValue = "0";

                ddYilMinMobil.DataSource = Yillar.ToList();
                ddYilMinMobil.DataValueField = "Kategori";
                ddYilMinMobil.DataTextField = "Kategori";
                ddYilMinMobil.DataBind();
                ListItem limymmobil = new ListItem("Yıl(Min)", "0");
                ddYilMinMobil.Items.Add(limymmobil);
                ddYilMinMobil.SelectedValue = "0";

                ddYilMax.DataSource = Yillar.ToList();
                ddYilMax.DataValueField = "Kategori";
                ddYilMax.DataTextField = "Kategori";
                ddYilMax.DataBind();
                ListItem limyma = new ListItem("Yıl(Max)", "0");
                ddYilMax.Items.Add(limyma);
                ddYilMax.SelectedValue = "0";

                ddYilMaxMobil.DataSource = Yillar.ToList();
                ddYilMaxMobil.DataValueField = "Kategori";
                ddYilMaxMobil.DataTextField = "Kategori";
                ddYilMaxMobil.DataBind();
                ListItem limymaxmobil = new ListItem("Yıl(Max)", "0");
                ddYilMaxMobil.Items.Add(limymaxmobil);
                ddYilMaxMobil.SelectedValue = "0";



                //Ürünler
                UrunleriDoldur();
                VitrinUrunleriDoldur();
            }
        }

        protected void UrunleriDoldur()
        {

            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            string Lang = Session["Lang"].ToString();

            //Ürünler Listeleniyor Seçiyoruz
            var urunsorgu = from c in nt.tbl_Makinalar
                            join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                            join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && (c.Statu == 2 || c.Statu == 4) && c.Ihale==true
                            orderby c.Kayit_Tarihi descending
                            select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.Ihale, c.Statu, c.StokGelis_Tarihi, c.IlanNo, c.Yayinlanma_Tarihi, c.FiyatGosterilmesin, c.SEOUrl };

            CollectionPager1.DataSource = urunsorgu.ToList();
            CollectionPager1.BindToControl = rptUrunler;
            rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
            rptUrunler.DataBind();
            rptUrunlerMobil.DataSource = urunsorgu.ToList();
            rptUrunlerMobil.DataBind();
            lblToplamIlan.Text = urunsorgu.Count().ToString();
            lblToplamIlanMobil.Text = urunsorgu.Count().ToString();

        }

        protected void rptUrunler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //Link
                //Literal Link = (Literal)e.Item.FindControl("ltLink");
                //Link.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir() + "/" + DataBinder.Eval(e.Item.DataItem, "makina_ID") + ">";

                //Fiyat
                //Literal Fiyat = (Literal)e.Item.FindControl("ltFiyat");
                //string fiyati = DataBinder.Eval(e.Item.DataItem, "Fiyat").ToString();
                //Fiyat.Text = string.Format("{0:0,0}", fiyati); ;

                //Para Birimi
                Literal Para = (Literal)e.Item.FindControl("ltParaBirimi");
                string parabirimi = DataBinder.Eval(e.Item.DataItem, "Para_Birimi").ToString();
                string fiyat = DataBinder.Eval(e.Item.DataItem, "Fiyat").ToString();
                if (parabirimi == "1" && fiyat != "")
                {
                    Para.Text = "&#8378";
                }
                else if (parabirimi == "2" && fiyat != "")
                {
                    Para.Text = "&euro;";
                }
                else if (parabirimi == "3" && fiyat != "")
                {
                    Para.Text = "$";
                }

                ////İhaleli mi?
                //Literal Ihale = (Literal)e.Item.FindControl("ltihale");
                //Literal Detay = (Literal)e.Item.FindControl("ltdetay");
                //string ihaleli = DataBinder.Eval(e.Item.DataItem, "Ihale").ToString();
                //int makinaid = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "makina_ID"));
                //if (ihaleli=="True")
                //{
                //    Ihale.Text = "<a href =/ihale/" + makinaid + "><span class=right><i class=\"fa fa-file\"></i> İhaleye Katıl</span></a>";
                //    Detay.Text = "<a href =/urundetay/" + makinaid + "><span class=left><i class=\"fa fa-search\"></i> İncele</span></a>";
                //}
                //else
                //{
                //    Ihale.Text = "<a href =/iletisim/" + makinaid + "><span class=right><i class=\"fa fa-file\"></i> Hızlı Satınal</span></a>";
                //    Detay.Text = "<a href =/urundetay/" + makinaid + "><span class=left><i class=\"fa fa-search\"></i> İncele</span></a>";
                //}

                ////Satıldı mı?
                //int satildi = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Statu"));
                //DateTime stokgelistarihi = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "StokGelis_Tarihi"));
                //Label SatildiLbl = (Label)e.Item.FindControl("lblsatildi");
                //Panel link1 = (Panel)e.Item.FindControl("pnlUrunLinki");
                //Panel link2 = (Panel)e.Item.FindControl("pnlUrunLinki1");
                //HtmlGenericControl div = e.Item.FindControl("altbilgi") as HtmlGenericControl;
                //if (satildi == 4)
                //{
                //    div.Attributes.Add("class", "card-bottom-satildi");
                //    SatildiLbl.Text = "Satıldı";
                //    SatildiLbl.Visible = true;
                //    Ihale.Visible = false;
                //    Detay.Visible = false;
                //    link1.Visible = true;
                //    link2.Visible = true;
                //}

                //if (satildi == 5)
                //{
                //    Ihale.Visible = true;
                //    Detay.Visible = true;
                //    link1.Visible = true;
                //    link2.Visible = true;
                //    Ihale.Text = "<span class=yakinda><i class=\"fa fa-calendar\"></i><span style=font-size:10px> Geliş Tarihi<br>" + stokgelistarihi.ToShortDateString() + "</span></span>";
                //    Detay.Text = "<a href =/urundetay/" + makinaid + "><span class=left><i class=\"fa fa-search\"></i> İncele</span></a>";
                //}

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
                    //Fiyat.Visible = true;
                    //Para.Visible = false;
                    //Fiyat.Text = "Fiyat Sorun";

                }

            }

        }

        protected void btnTumu_Click(object sender, EventArgs e)
        {
            try
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                string Lang = Session["Lang"].ToString();



                //Listeleri Sıfırlıyoruz
                ddTurler.SelectedValue = "0";
                ddTurlerAlt.SelectedValue = "0";
                ddMarkalar.SelectedValue = "0";
                txtFiyatMax.Text = "";
                txtFiyatMin.Text = "";
                ddYilMax.SelectedValue= "0";
                ddYilMin.SelectedValue= "0";
                ddParaBirimi.SelectedValue="0";

                ddTurlerMobil.SelectedValue = "0";
                ddTurlerAltMobil.SelectedValue = "0";
                ddMarkalarMobil.SelectedValue = "0";
                txtFiyatMaxMobil.Text = "";
                txtFiyatMinMobil.Text = "";
                ddYilMaxMobil.SelectedValue = "0";
                ddYilMinMobil.SelectedValue = "0";
                ddParaBirimiMobil.SelectedValue = "0";


                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = from c in nt.tbl_Makinalar
                                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && (c.Statu == 2 || c.Statu == 5)
                                orderby c.Kayit_Tarihi descending
                                select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.Ihale, c.Statu, c.StokGelis_Tarihi, c.IlanNo, c.Yayinlanma_Tarihi, c.SEOUrl };

                CollectionPager1.DataSource = urunsorgu.ToList();
                CollectionPager1.BindToControl = rptUrunler;
                rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
                rptUrunler.DataBind();
                rptUrunlerMobil.DataSource = urunsorgu.ToList();
                rptUrunlerMobil.DataBind();
                lblSonuc.Visible = false;
                lblSonuc.Text = "";
                lblToplamIlan.Text = urunsorgu.Count().ToString();
                lblToplamIlanMobil.Text = urunsorgu.Count().ToString();

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                string Lang = Session["Lang"].ToString();

                turID = Convert.ToInt32(ddTurler.SelectedItem.Value);
                altturID = Convert.ToInt32(ddTurlerAlt.SelectedItem.Value);
                markaID = Convert.ToInt32(ddMarkalar.SelectedItem.Value);
                yil_min = Convert.ToInt32(ddYilMin.SelectedItem.Value);
                yil_max = Convert.ToInt32(ddYilMax.SelectedItem.Value);
                if (txtFiyatMin.Text == "") { minfiyat = 0; } else { minfiyat = Convert.ToInt32(txtFiyatMin.Text); }
                if (txtFiyatMax.Text == "") { maxfiyat = 0; } else { maxfiyat = Convert.ToInt32(txtFiyatMax.Text); }
                parabirimi = Convert.ToInt32(ddParaBirimi.SelectedItem.Value);

                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = from c in nt.tbl_Makinalar
                            join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                            join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && (c.Baslik.Contains(txtKelime.Text) || c.Aciklama.Contains(txtKelime.Text) || c.IlanNo.Contains(txtKelime.Text) || c.SeoKeywords.Contains(txtKelime.Text) || c.SeoDescription.Contains(txtKelime.Text)) && (c.Statu == 2 || c.Statu == 5)
                                orderby c.Kayit_Tarihi descending
                            select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.marka_ID, c.tur_ID, c.yil_ID, c.Ihale, c.StokGelis_Tarihi, c.Statu, c.IlanNo, c.Yayinlanma_Tarihi, c.Alttur_ID, c.SEOUrl };

            if (ddMarkalar.SelectedValue != "0")
            {
                urunsorgu = urunsorgu.Where(k => k.marka_ID == markaID);
            }

                if (minfiyat != 0 || maxfiyat != 0)
                {
     
                    urunsorgu = urunsorgu.Where(k => k.Fiyat >= minfiyat && k.Fiyat <= maxfiyat);
                }

                if (ddTurler.SelectedValue != "0")
             {
                 urunsorgu = urunsorgu.Where(k => k.tur_ID == turID);
             }


             if (ddTurlerAlt.SelectedValue != "0")
             {
                    urunsorgu = urunsorgu.Where(k => k.Alttur_ID == altturID);
             }
             if (ddYilMin.SelectedValue != "0" || ddYilMax.SelectedValue != "0")
             {
                    urunsorgu = urunsorgu.Where(d => (int)d.Yil >= yil_min && (int)d.Yil <= yil_max);
             }

             if (ddParaBirimi.SelectedValue != "0")
              {
                    urunsorgu = urunsorgu.Where(k => k.Para_Birimi == parabirimi);
             }

             if (urunsorgu.Count()==0)
             {
                    lblSonuc.Visible = true;
                    lblSonuc.Text = "<center><strong>Aradığınız kritelere göre sonuç bulunamadı.</strong></center>";
             }
             else
              {
                    lblSonuc.Visible = false;
                    lblSonuc.Text = "";
              }
                CollectionPager1.DataSource = urunsorgu.ToList();
                CollectionPager1.BindToControl = rptUrunler;
                rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
                rptUrunler.DataBind();

                lblToplamIlan.Text = urunsorgu.Count().ToString();

            }
            catch (Exception ex)
            {
              
            }
        }

        protected void btnMobilAra_Click(object sender, EventArgs e)
        {
            try
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                string Lang = Session["Lang"].ToString();

                turID = Convert.ToInt32(ddTurlerMobil.SelectedItem.Value);
                altturID = Convert.ToInt32(ddTurlerAltMobil.SelectedItem.Value);
                markaID = Convert.ToInt32(ddMarkalarMobil.SelectedItem.Value);
                yil_min = Convert.ToInt32(ddYilMinMobil.SelectedItem.Value);
                yil_max = Convert.ToInt32(ddYilMaxMobil.SelectedItem.Value);
                if (txtFiyatMinMobil.Text == "") { minfiyat = 0; } else { minfiyat = Convert.ToInt32(txtFiyatMinMobil.Text); }
                if (txtFiyatMaxMobil.Text == "") { maxfiyat = 0; } else { maxfiyat = Convert.ToInt32(txtFiyatMaxMobil.Text); }
                parabirimi = Convert.ToInt32(ddParaBirimiMobil.SelectedItem.Value);

                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = from c in nt.tbl_Makinalar
                                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && (c.Baslik.Contains(txtKelimeMobil.Text) || c.Aciklama.Contains(txtKelimeMobil.Text) || c.IlanNo.Contains(txtKelimeMobil.Text) || c.SeoKeywords.Contains(txtKelimeMobil.Text) || c.SeoDescription.Contains(txtKelimeMobil.Text)) && (c.Statu == 2 || c.Statu == 5)
                                orderby c.Kayit_Tarihi descending
                                select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.marka_ID, c.tur_ID, c.yil_ID, c.Ihale, c.StokGelis_Tarihi, c.Statu, c.IlanNo, c.Yayinlanma_Tarihi, c.Alttur_ID, c.SEOUrl };

                if (ddMarkalarMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.marka_ID == markaID);
                }

                if (minfiyat != 0 || maxfiyat != 0)
                {

                    urunsorgu = urunsorgu.Where(k => k.Fiyat >= minfiyat && k.Fiyat <= maxfiyat);
                }

                if (ddTurlerMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.tur_ID == turID);
                }
                if (ddTurlerAltMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur_ID == altturID);
                }
                if (ddYilMinMobil.SelectedValue != "0" || ddYilMax.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(d => (int)d.Yil >= yil_min && (int)d.Yil <= yil_max);
                }

                if (ddParaBirimiMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Para_Birimi == parabirimi);
                }

                if (urunsorgu.Count() == 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.Text = "<center><strong>Aradığınız kritelere göre sonuç bulunamadı.</strong></center>";
                }
                else
                {
                    lblSonuc.Visible = false;
                    lblSonuc.Text = "";
                }
                rptUrunlerMobil.DataSource = urunsorgu.ToList();
                rptUrunlerMobil.DataBind();

                lblToplamIlanMobil.Text = urunsorgu.Count().ToString();

            }
            catch (Exception ex)
            {

            }
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

            UrunleriDoldur();
        }

        protected void VitrinUrunleriDoldur()
        {
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            string Lang = Session["Lang"].ToString();

            //Ürünler Listeleniyor Seçiyoruz
            var urunsorgu = from c in nt.tbl_Makinalar
                            join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            where c.Durum == true && c.Yayinda == true && c.Vitrin == true && (c.Statu == 2 || c.Statu == 5) && c.Ihale==true
                            orderby Guid.NewGuid()
                            select new { c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, c.Model, c.Para_Birimi, Tur = T.Kategori, Yil = Y.Kategori, Marka = M.Kategori, c.Yayinlanma_Tarihi, c.SEOUrl };

            rptUrunlerVitrin.DataSource = urunsorgu.ToList().Take(10);
            rptUrunlerVitrin.DataBind();

            rptUrunlerVitrinMobil.DataSource = urunsorgu.ToList().Take(8);
            rptUrunlerVitrinMobil.DataBind();
        }

        protected void rptUrunlerVitrin_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
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
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_v." + a[1];
                }

                if (urunresimsorgu.Count() == 0)
                {
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + "ornekfoto.jpg";
                }

            }

        }

    }
}