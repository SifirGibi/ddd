using Microsoft.Owin.Security.DataHandler;
using SifirGibiMakina.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class Turler : System.Web.UI.Page
    {
        int markaID;
        int turID;
        int altturID;
        int alttur2ID;
        int yil_min;
        int yil_max;
        int minfiyat;
        int maxfiyat;
        int parabirimi;
        public IMachineService _machineService { get; set; }

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();


        //    int Tur = Convert.ToInt32(RouteData.Values["turid"]);
        //    string Lang = Session["Lang"].ToString();

        //    var sorgu = from c in nt.tbl_MakinaTurleri
        //                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
        //                where c.tur_ID == Tur && c.Durum == true && c.dil_ID == 1
        //                select new { c.tur_ID, c.Kategori, c.SeoDescription, c.SeoKeywords, c.FooterAciklamaSEO };
        //    foreach (var prod in sorgu)
        //    {

        //        ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

        //        Master.Page.Title = prod.Kategori + " 2. el ilanları - Sahibinden " + prod.Kategori + "| Makina Al Sat | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
        //        Master.Page.MetaDescription = prod.SeoDescription.ToString();
        //        Master.Page.MetaKeywords = prod.SeoKeywords.ToString();
        //        lblTurH1.Text = prod.Kategori + " İlanları";
        //        lblTurDesc.Text = prod.SeoDescription + " İkinci el <strong><u><i>" + prod.Kategori + "</i></u></strong> makina alımı. Tüm 2. el <strong>" + prod.Kategori + "</strong> ilanları. 2. el <strong>" + prod.Kategori + "</strong> makinasi ilanları ve <strong>" + prod.Kategori + "</strong> makine fiyatları Sıfır Gibi Makina'da. 2. el makina <strong>" + prod.Kategori + "</strong> kategorisinde; makina satıcılarıdan ikinci el satılık <strong>" + prod.Kategori + "</strong> makina ilanları, sahibinden ikinci el satılık makina ilanları ve ilan detaylarında ikinci el makina fiyatları bulunmaktadır.";
        //        ltFooterSeo.Text = prod.FooterAciklamaSEO;
        //        /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
        //    }



        //    if (!IsPostBack)
        //        {

        //        //Ürünler
        //        UrunleriDoldur();

        //        //Türleri Listeliyoruz
        //        var Turler = from c in nt.tbl_MakinaTurleri
        //                     where c.dil_ID == 1 && c.Durum == true
        //                     orderby c.Kategori ascending
        //                     select c;

        //        ddTurler.DataSource = Turler.ToList();
        //        ddTurler.DataValueField = "tur_ID";
        //        ddTurler.DataTextField = "Kategori";
        //        ddTurler.DataBind();
        //        ListItem lit = new ListItem("Makine Türü(Tümü)", "0");
        //        ddTurler.Items.Add(lit);
        //        ddTurler.SelectedValue = Tur.ToString();

        //        ddTurlerMobil.DataSource = Turler.ToList();
        //        ddTurlerMobil.DataValueField = "tur_ID";
        //        ddTurlerMobil.DataTextField = "Kategori";
        //        ddTurlerMobil.DataBind();
        //        ListItem litm = new ListItem("Makine Türü(Tümü)", "0");
        //        ddTurlerMobil.Items.Add(litm);
        //        ddTurlerMobil.SelectedValue = Tur.ToString();

        //        //Alt Türleri Listeliyoruz
        //        var AltTurler = from c in nt.tbl_MakinaAltTurleri
        //                        where c.Durum == true && c.dil_ID == 1 && c.tur_ID==Tur
        //                        orderby c.Kategori ascending
        //                        select c;

        //        ddTurlerAlt.DataSource = AltTurler.ToList();
        //        ddTurlerAlt.DataValueField = "Alttur_ID";
        //        ddTurlerAlt.DataTextField = "Kategori";
        //        ddTurlerAlt.DataBind();
        //        ListItem litaa = new ListItem("Alt Kategori(Tümü)", "0");
        //        ddTurlerAlt.Items.Add(litaa);
        //        ddTurlerAlt.SelectedValue = "0";

        //        ddTurlerAltMobil.DataSource = AltTurler.ToList();
        //        ddTurlerAltMobil.DataValueField = "Alttur_ID";
        //        ddTurlerAltMobil.DataTextField = "Kategori";
        //        ddTurlerAltMobil.DataBind();
        //        ListItem litaam = new ListItem("Alt Kategori(Tümü)", "0");
        //        ddTurlerAltMobil.Items.Add(litaam);
        //        ddTurlerAltMobil.SelectedValue = "0";

        //        //Alt-2 Türleri Listeliyoruz
        //        var AltTurler2 = from c in nt.tbl_MakinaAltTurleri2
        //                         where c.Durum == true && c.dil_ID == 1
        //                         orderby c.Kategori ascending
        //                         select c;

        //        ddTurlerAlt2.DataSource = AltTurler2.ToList();
        //        ddTurlerAlt2.DataValueField = "Alttur2_ID";
        //        ddTurlerAlt2.DataTextField = "Kategori";
        //        ddTurlerAlt2.DataBind();
        //        ListItem litaaa = new ListItem("Alt-2 Kategori(Tümü)", "0");
        //        ddTurlerAlt2.Items.Add(litaaa);
        //        ddTurlerAlt2.SelectedValue = "0";

        //        ddTurlerAlt2Mobil.DataSource = AltTurler2.ToList();
        //        ddTurlerAlt2Mobil.DataValueField = "Alttur2_ID";
        //        ddTurlerAlt2Mobil.DataTextField = "Kategori";
        //        ddTurlerAlt2Mobil.DataBind();
        //        ListItem litaaam = new ListItem("Alt Kategori(Tümü)", "0");
        //        ddTurlerAlt2Mobil.Items.Add(litaaam);
        //        ddTurlerAlt2Mobil.SelectedValue = "0";


        //        //Markaları Listeliyoruz
        //        var Markalar = from c in nt.tbl_MakinaMarkalari
        //                       where c.dil_ID == 1 && c.Durum == true
        //                       orderby c.Kategori ascending
        //                       select c;

        //        ddMarkalar.DataSource = Markalar.ToList();
        //        ddMarkalar.DataValueField = "marka_ID";
        //        ddMarkalar.DataTextField = "Kategori";
        //        ddMarkalar.DataBind();
        //        ListItem lim = new ListItem("Marka(Tümü)", "0");
        //        ddMarkalar.Items.Add(lim);
        //        ddMarkalar.SelectedValue = "0";

        //        ddMarkalarMobil.DataSource = Markalar.ToList();
        //        ddMarkalarMobil.DataValueField = "marka_ID";
        //        ddMarkalarMobil.DataTextField = "Kategori";
        //        ddMarkalarMobil.DataBind();
        //        ListItem limm = new ListItem("Marka(Tümü)", "0");
        //        ddMarkalarMobil.Items.Add(limm);
        //        ddMarkalarMobil.SelectedValue = "0";


        //        //Yılları Listeliyoruz
        //        var Yillar = from c in nt.tbl_MakinaYillar
        //                     where c.dil_ID == 1 && c.Durum == true
        //                     orderby c.Kategori ascending
        //                     select c;
        //        ddYilMin.DataSource = Yillar.ToList();
        //        ddYilMin.DataValueField = "Kategori";
        //        ddYilMin.DataTextField = "Kategori";
        //        ddYilMin.DataBind();
        //        ListItem limym = new ListItem("Yıl(Min)", "0");
        //        ddYilMin.Items.Add(limym);
        //        ddYilMin.SelectedValue = "0";

        //        ddYilMinMobil.DataSource = Yillar.ToList();
        //        ddYilMinMobil.DataValueField = "Kategori";
        //        ddYilMinMobil.DataTextField = "Kategori";
        //        ddYilMinMobil.DataBind();
        //        ListItem limymmobil = new ListItem("Yıl(Min)", "0");
        //        ddYilMinMobil.Items.Add(limymmobil);
        //        ddYilMinMobil.SelectedValue = "0";

        //        ddYilMax.DataSource = Yillar.ToList();
        //        ddYilMax.DataValueField = "Kategori";
        //        ddYilMax.DataTextField = "Kategori";
        //        ddYilMax.DataBind();
        //        ListItem limyma = new ListItem("Yıl(Max)", "0");
        //        ddYilMax.Items.Add(limyma);
        //        ddYilMax.SelectedValue = "0";

        //        ddYilMaxMobil.DataSource = Yillar.ToList();
        //        ddYilMaxMobil.DataValueField = "Kategori";
        //        ddYilMaxMobil.DataTextField = "Kategori";
        //        ddYilMaxMobil.DataBind();
        //        ListItem limymaxmobil = new ListItem("Yıl(Max)", "0");
        //        ddYilMaxMobil.Items.Add(limymaxmobil);
        //        ddYilMaxMobil.SelectedValue = "0";



        //    }
        //}

        //protected void UrunleriDoldur()
        //{
        //    int Tur = Convert.ToInt32(RouteData.Values["turid"]);

        //    ddTurler.SelectedValue = Tur.ToString();
        //    ddTurlerMobil.SelectedValue = Tur.ToString();


        //    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
        //    string Lang = Session["Lang"].ToString();

        //    //Ürünler Listeleniyor Seçiyoruz
        //    var urunsorgu = from c in nt.tbl_Makinalar
        //                    join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
        //                    join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
        //                    join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
        //                    join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
        //                    where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && c.tur_ID== Tur && (c.Statu == 2 || c.Statu == 4 || c.Statu == 5)
        //                    orderby c.Makina_Order, c.Kayit_Tarihi descending
        //                    select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.Ihale, c.Statu, c.StokGelis_Tarihi, c.IlanNo, c.Yayinlanma_Tarihi, c.FiyatGosterilmesin, c.SEOUrl };

        //    CollectionPager1.DataSource = urunsorgu.ToList();
        //    CollectionPager1.BindToControl = rptUrunler;
        //    rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
        //    rptUrunler.DataBind();
        //    rptUrunlerMobil.DataSource = urunsorgu.ToList();
        //    rptUrunlerMobil.DataBind();

        //    lblToplamIlan.Text = urunsorgu.Count().ToString();
        //    lblToplamIlanMobil.Text = urunsorgu.Count().ToString();
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            int Tur = Convert.ToInt32(RouteData.Values["turid"]);
            string Lang = Session["Lang"].ToString();

            SetSEOValues(Tur, Lang, nt);

            if (!IsPostBack)
            {
                PopulateDropdowns(Tur, Lang, nt);
                UrunleriDoldur(Tur, Lang, nt);
            }
        }

        private void SetSEOValues(int Tur, string Lang, db_SifirGibiMakinaEntities nt)
        {
            var sorgu = from c in nt.tbl_MakinaTurleri
                        join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                        where c.tur_ID == Tur && c.Durum == true && c.dil_ID == 1
                        select new { c.tur_ID, c.Kategori, c.SeoDescription, c.SeoKeywords, c.FooterAciklamaSEO };

            foreach (var prod in sorgu)
            {
                Master.Page.Title = $"{prod.Kategori} 2. el ilanları - Sahibinden {prod.Kategori} | Makina Al Sat | {WebConfigurationManager.AppSettings["MikroSiteAdi"]}";
                Master.Page.MetaDescription = prod.SeoDescription.ToString();
                Master.Page.MetaKeywords = prod.SeoKeywords.ToString();
                lblTurH1.Text = $"{prod.Kategori} İlanları";
                lblTurDesc.Text = $"{prod.SeoDescription} İkinci el <strong><u><i>{prod.Kategori}</i></u></strong> makina alımı. ...";
                ltFooterSeo.Text = prod.FooterAciklamaSEO;
            }
        }

        private void PopulateDropdowns(int Tur, string Lang, db_SifirGibiMakinaEntities nt)
        {
            // Türleri Dropdown
            PopulateDropdown(nt.tbl_MakinaTurleri.Where(c => c.dil_ID == 1 && c.Durum == true).OrderBy(c => c.Kategori),
                             ddTurler, "tur_ID", "Kategori", "Makine Türü(Tümü)");
            PopulateDropdown(nt.tbl_MakinaTurleri.Where(c => c.dil_ID == 1 && c.Durum == true).OrderBy(c => c.Kategori),
                             ddTurlerMobil, "tur_ID", "Kategori", "Makine Türü(Tümü)");

            // Alt Türleri Dropdown
            PopulateDropdown(nt.tbl_MakinaAltTurleri.Where(c => c.Durum == true && c.dil_ID == 1 && c.tur_ID == Tur).OrderBy(c => c.Kategori),
                             ddTurlerAlt, "Alttur_ID", "Kategori", "Alt Kategori(Tümü)");
            PopulateDropdown(nt.tbl_MakinaAltTurleri.Where(c => c.Durum == true && c.dil_ID == 1 && c.tur_ID == Tur).OrderBy(c => c.Kategori),
                             ddTurlerAltMobil, "Alttur_ID", "Kategori", "Alt Kategori(Tümü)");

            // Alt-2 Türleri Dropdown
            PopulateDropdown(nt.tbl_MakinaAltTurleri2.Where(c => c.Durum == true && c.dil_ID == 1).OrderBy(c => c.Kategori),
                             ddTurlerAlt2, "Alttur2_ID", "Kategori", "Alt-2 Kategori(Tümü)");
            PopulateDropdown(nt.tbl_MakinaAltTurleri2.Where(c => c.Durum == true && c.dil_ID == 1).OrderBy(c => c.Kategori),
                             ddTurlerAlt2Mobil, "Alttur2_ID", "Kategori", "Alt-2 Kategori(Tümü)");

            // Markaları Dropdown
            PopulateDropdown(nt.tbl_MakinaMarkalari.Where(c => c.dil_ID == 1 && c.Durum == true).OrderBy(c => c.Kategori),
                             ddMarkalar, "marka_ID", "Kategori", "Marka(Tümü)");
            PopulateDropdown(nt.tbl_MakinaMarkalari.Where(c => c.dil_ID == 1 && c.Durum == true).OrderBy(c => c.Kategori),
                             ddMarkalarMobil, "marka_ID", "Kategori", "Marka(Tümü)");

            // Yılları Dropdown
            PopulateDropdown(nt.tbl_MakinaYillar.Where(c => c.dil_ID == 1 && c.Durum == true).OrderBy(c => c.Kategori),
                             ddYilMin, "Kategori", "Kategori", "Yıl(Min)");
            PopulateDropdown(nt.tbl_MakinaYillar.Where(c => c.dil_ID == 1 && c.Durum == true).OrderBy(c => c.Kategori),
                             ddYilMinMobil, "Kategori", "Kategori", "Yıl(Min)");

            PopulateDropdown(nt.tbl_MakinaYillar.Where(c => c.dil_ID == 1 && c.Durum == true).OrderBy(c => c.Kategori),
                             ddYilMax, "Kategori", "Kategori", "Yıl(Max)");
            PopulateDropdown(nt.tbl_MakinaYillar.Where(c => c.dil_ID == 1 && c.Durum == true).OrderBy(c => c.Kategori),
                             ddYilMaxMobil, "Kategori", "Kategori", "Yıl(Max)");
        }

        private void PopulateDropdown(IQueryable<dynamic> source, DropDownList dropdown, string valueField, string textField, string initialText)
        {
            dropdown.DataSource = source.ToList();
            dropdown.DataValueField = valueField;
            dropdown.DataTextField = textField;
            dropdown.DataBind();
            ListItem initialItem = new ListItem(initialText, "0");
            dropdown.Items.Add(initialItem);
            dropdown.SelectedValue = "0";
        }

        protected void UrunleriDoldur(int Tur, string Lang, db_SifirGibiMakinaEntities nt)
        {
            SetSelectedValues(Tur);
            var urunsorgu = _machineService.GetMachineList().Where(c => c.tur_ID == Tur).OrderByDescending(m => m.Kayit_Tarihi);
           var urunList = urunsorgu.ToList();
        
           int pages = urunList.Count();
            CollectionPager1.DataSource = urunList;
    
            CollectionPager1.PageCount.CompareTo(pages/ 24);
            CollectionPager1.BindToControl = rptUrunler;

            rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
            rptUrunler.DataBind();

            CollectionPager2.DataSource = urunList;
            CollectionPager2.PageCount.CompareTo(pages / 24);
            CollectionPager2.BindToControl = rptUrunlerMobil;
            rptUrunlerMobil.DataSource = CollectionPager2.DataSourcePaged;
            rptUrunlerMobil.DataBind();

         
         

            lblToplamIlan.Text = urunList.Count().ToString();
            lblToplamIlanMobil.Text = urunList.Count().ToString();
        
        }

        private void SetSelectedValues(int Tur)
        {
            string turStr = Tur.ToString();
            ddTurler.SelectedValue = turStr;
            ddTurlerMobil.SelectedValue = turStr;
        }

        //private IQueryable<dynamic> GetUrunSorgu(int Tur, string Lang, db_SifirGibiMakinaEntities nt)
        //{
        //    return from c in nt.tbl_Makinalar
        //           join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
        //           join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
        //           join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
        //           join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
        //           where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && c.tur_ID == Tur && (c.Statu == 2 || c.Statu == 4 || c.Statu == 5)
        //           orderby c.Makina_Order, c.Kayit_Tarihi descending
        //           select new
        //           {
        //               c.Aciklama,
        //               c.Baslik,
        //               c.Fotograf,
        //               c.makina_ID,
        //               c.Kayit_Tarihi,
        //               c.Fiyat,
        //               c.KM,
        //               c.Makina_Order,
        //               Yil = Y.Kategori,
        //               Tur = T.Kategori,
        //               Marka = M.Kategori,
        //               c.Model,
        //               c.Para_Birimi,
        //               c.Ihale,
        //               c.Statu,
        //               c.StokGelis_Tarihi,
        //               c.IlanNo,
        //               c.Yayinlanma_Tarihi,
        //               c.FiyatGosterilmesin,
        //               c.SEOUrl
        //           };
        //}
       
        protected void rptUrunler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Fiyat
                Literal Fiyat = (Literal)e.Item.FindControl("ltFiyat");
                string fiyati = DataBinder.Eval(e.Item.DataItem, "Fiyat").ToString();
                Fiyat.Text = string.Format("{0:0,0}", fiyati);

                // Para Birimi
                SetParaBirimiForItem(e);

                // İmaj
                SetImageForItem(e);
            }
        }

        private void SetParaBirimiForItem(RepeaterItemEventArgs e)
        {
            Literal Para = (Literal)e.Item.FindControl("ltParaBirimi");
            string parabirimi = DataBinder.Eval(e.Item.DataItem, "Para_Birimi").ToString();
            string fiyat = DataBinder.Eval(e.Item.DataItem, "Fiyat").ToString();
            if (fiyat != "")
            {
                switch (parabirimi)
                {
                    case "1":
                        Para.Text = "&#8378";
                        break;
                    case "2":
                        Para.Text = "&euro;";
                        break;
                    case "3":
                        Para.Text = "$";
                        break;
                    default:
                        Para.Text = ""; // Or some default value
                        break;
                }
            }
        }

        private void SetImageForItem(RepeaterItemEventArgs e)
        {
            Image imgresim = (Image)e.Item.FindControl("imgUrun");
            int makinaID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "makina_ID").ToString());

            // Fetch the necessary image data for the item outside the loop
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            var urunresim = nt.tbl_MakinaResimler
                            .Where(c => c.Durum == true && c.Vitrin == true && c.makina_ID == makinaID)
                            .FirstOrDefault();

            if (urunresim != null)
            {
                string[] a = urunresim.Fotograf.Split('.');
                imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_vb." + a[1];
            }
            else
            {
                imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + "ornekfoto.jpg";
            }
        }

        //protected void rptUrunler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {

        //        //Link
        //        //Literal Link = (Literal)e.Item.FindControl("ltLink");
        //        //Link.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir() + "/" + DataBinder.Eval(e.Item.DataItem, "makina_ID") + ">";

        //        //Fiyat
        //        Literal Fiyat = (Literal)e.Item.FindControl("ltFiyat");
        //        string fiyati = DataBinder.Eval(e.Item.DataItem, "Fiyat").ToString();
        //        Fiyat.Text = string.Format("{0:0,0}", fiyati); ;

        //        //Para Birimi
        //        Literal Para = (Literal)e.Item.FindControl("ltParaBirimi");
        //        string parabirimi = DataBinder.Eval(e.Item.DataItem, "Para_Birimi").ToString();
        //        string fiyat = DataBinder.Eval(e.Item.DataItem, "Fiyat").ToString();
        //        if (parabirimi == "1" && fiyat != "")
        //        {
        //            Para.Text = "&#8378";
        //        }
        //        else if (parabirimi == "2" && fiyat != "")
        //        {
        //            Para.Text = "&euro;";
        //        }
        //        else if (parabirimi == "3" && fiyat != "")
        //        {
        //            Para.Text = "$";
        //        }



        //        //İmaj
        //        Image imgresim = (Image)e.Item.FindControl("imgUrun");

        //        int makinaID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "makina_ID").ToString());
        //        db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();

        //        var urunresimsorgu = from c in nt.tbl_MakinaResimler
        //                             where c.Durum == true && c.Vitrin == true && c.makina_ID == makinaID
        //                             select c;

        //        foreach (var prods in urunresimsorgu)
        //        {
        //            string[] a = prods.Fotograf.Split('.');
        //            imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_vb." + a[1];
        //        }

        //        if (urunresimsorgu.Count() == 0)
        //        {
        //            imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + "ornekfoto.jpg";
        //        }

        //        //Eğer İlan Fiyat Gösterilmesin sadece teklif talep edilsin olarak işaretlendiyse fiyatları gizle
        //        bool fiyatgosterilmesin = Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "FiyatGosterilmesin").ToString());
        //        if (fiyatgosterilmesin == true)
        //        {
        //            Fiyat.Visible = true;
        //            Para.Visible = false;
        //            Fiyat.Text = "Fiyat Sorun";

        //        }

        //    }

        //}

        protected void btnTumu_Click(object sender, EventArgs e)
        {
            try
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                string Lang = Session["Lang"].ToString();



                //Listeleri Sıfırlıyoruz
                ddTurler.SelectedValue = "0";
                ddTurlerAlt.SelectedValue = "0";
                ddTurlerAlt2.SelectedValue = "0";
                ddMarkalar.SelectedValue = "0";
                txtFiyatMax.Text = "";
                txtFiyatMin.Text = "";
                ddYilMax.SelectedValue = "0";
                ddYilMin.SelectedValue = "0";
                ddParaBirimi.SelectedValue = "0";

                ddTurlerMobil.SelectedValue = "0";
                ddTurlerAltMobil.SelectedValue = "0";
                ddTurlerAlt2Mobil.SelectedValue = "0";
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
                                select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.Ihale, c.Statu, c.StokGelis_Tarihi, c.IlanNo, c.Yayinlanma_Tarihi, c.FiyatGosterilmesin, c.SEOUrl };

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
                alttur2ID = Convert.ToInt32(ddTurlerAlt2.SelectedItem.Value);
                markaID = Convert.ToInt32(ddMarkalar.SelectedItem.Value);
                yil_min = Convert.ToInt32(ddYilMin.SelectedItem.Value);
                yil_max = Convert.ToInt32(ddYilMax.SelectedItem.Value);
                if (txtFiyatMin.Text == "") { minfiyat = 0; } else { minfiyat = Convert.ToInt32(txtFiyatMin.Text); }
                if (txtFiyatMax.Text == "") { maxfiyat = 0; } else { maxfiyat = Convert.ToInt32(txtFiyatMax.Text); }
                parabirimi = Convert.ToInt32(ddParaBirimi.SelectedItem.Value);

               //Seçilen türe göre açıklamalr koyuluyor
                var sorgu1 = from c in nt.tbl_MakinaTurleri
                             join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                             where c.tur_ID == turID && c.Durum == true && c.dil_ID == 1
                             select new { c.tur_ID, c.Kategori, c.SeoDescription, c.SeoKeywords };
                foreach (var prod in sorgu1)
                {

                    ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                    Master.Page.Title = prod.Kategori + " 2. el ilanları - Sahibinden " + prod.Kategori + "| Makina Al Sat | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                    Master.Page.MetaDescription = prod.SeoDescription.ToString();
                    Master.Page.MetaKeywords = prod.SeoKeywords.ToString();
                    lblTurH1.Text = prod.Kategori + " İlanları";
                    lblTurDesc.Text = prod.SeoDescription + " İkinci el <strong><u><i>" + prod.Kategori + "</i></u></strong> makina alımı. Tüm 2. el <strong>" + prod.Kategori + "</strong> ilanları. 2. el " + prod.Kategori + " makinasi ilanları ve " + prod.Kategori + " makine fiyatları Sıfır Gibi Makina'da. 2. el makina " + prod.Kategori + " kategorisinde; makina satıcılarıdan ikinci el satılık " + prod.Kategori + " makina ilanları, sahibinden ikinci el satılık makina ilanları ve ilan detaylarında ikinci el makina fiyatları bulunmaktadır.";

                    /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                }



                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = from c in nt.tbl_Makinalar
                                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && (c.Baslik.Contains(txtKelime.Text) || c.Aciklama.Contains(txtKelime.Text) || c.IlanNo.Contains(txtKelime.Text) || c.SeoKeywords.Contains(txtKelime.Text) || c.SeoDescription.Contains(txtKelime.Text)) && (c.Statu == 2 || c.Statu == 5)
                                orderby c.Kayit_Tarihi descending
                                select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, TurSeo = T.SeoDescription, Marka = M.Kategori, c.Model, c.Para_Birimi, c.marka_ID, c.tur_ID, c.yil_ID, c.Ihale, c.StokGelis_Tarihi, c.Statu, c.IlanNo, c.Yayinlanma_Tarihi, c.Alttur_ID, c.Alttur2_ID, c.FiyatGosterilmesin, c.SEOUrl };
               
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
                if (ddTurlerAlt2.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur2_ID == alttur2ID);
                }
                if (ddYilMin.SelectedValue != "0" || ddYilMax.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(d => (int)d.Yil >= yil_min && (int)d.Yil <= yil_max);
                }

                if (ddParaBirimi.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Para_Birimi == parabirimi);
                }

                if (urunsorgu.Count() == 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.Text = "<center><strong>Aradığınız kritelere göre sonuç bulunamadı. Bu kategori için ilk ilanı siz verebilirsiniz. İlan vermek için <a href=/makina-ekle>tıklayınız</a></strong></center>";
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
                alttur2ID = Convert.ToInt32(ddTurlerAlt2Mobil.SelectedItem.Value);
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
                                select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.marka_ID, c.tur_ID, c.yil_ID, c.Ihale, c.StokGelis_Tarihi, c.Statu, c.IlanNo, c.Yayinlanma_Tarihi, c.Alttur_ID,c.Alttur2_ID, c.FiyatGosterilmesin, c.SEOUrl };

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
                if (ddTurlerAlt2Mobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur2_ID == alttur2ID);
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
                    lblSonuc.Text = "<center><strong>Aradığınız kritelere göre sonuç bulunamadı. Bu kategori için ilk ilanı siz verebilirsiniz. İlan vermek için <a href=/makina-ekle>tıklayınız</a></strong></center>";
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

        protected void SecimleUrunleriDoldur()
        {
            try
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                string Lang = Session["Lang"].ToString();

                turID = Convert.ToInt32(ddTurler.SelectedItem.Value);
                altturID = Convert.ToInt32(ddTurlerAlt.SelectedItem.Value);
                alttur2ID = Convert.ToInt32(ddTurlerAlt2.SelectedItem.Value);
                markaID = Convert.ToInt32(ddMarkalar.SelectedItem.Value);
                yil_min = Convert.ToInt32(ddYilMin.SelectedItem.Value);
                yil_max = Convert.ToInt32(ddYilMax.SelectedItem.Value);
                if (txtFiyatMin.Text == "") { minfiyat = 0; } else { minfiyat = Convert.ToInt32(txtFiyatMin.Text); }
                if (txtFiyatMax.Text == "") { maxfiyat = 0; } else { maxfiyat = Convert.ToInt32(txtFiyatMax.Text); }
                parabirimi = Convert.ToInt32(ddParaBirimi.SelectedItem.Value);

                //Seçilen türe göre açıklamalr koyuluyor
                var sorgu1 = from c in nt.tbl_MakinaTurleri
                             join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                             where c.tur_ID == turID && c.Durum == true && c.dil_ID == 1
                             select new { c.tur_ID, c.Kategori, c.SeoDescription, c.SeoKeywords };
                foreach (var prod in sorgu1)
                {

                    ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                    Master.Page.Title = prod.Kategori + " 2. el ilanları - Sahibinden " + prod.Kategori + "| Makina Al Sat | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                    Master.Page.MetaDescription = prod.SeoDescription.ToString();
                    Master.Page.MetaKeywords = prod.SeoKeywords.ToString();
                    lblTurH1.Text = prod.Kategori + " İlanları";
                    lblTurDesc.Text = prod.SeoDescription + " İkinci el <strong><u><i>" + prod.Kategori + "</i></u></strong> makina alımı. Tüm 2. el <strong>" + prod.Kategori + "</strong> ilanları. 2. el " + prod.Kategori + " makinasi ilanları ve " + prod.Kategori + " makine fiyatları Sıfır Gibi Makina'da. 2. el makina " + prod.Kategori + " kategorisinde; makina satıcılarıdan ikinci el satılık " + prod.Kategori + " makina ilanları, sahibinden ikinci el satılık makina ilanları ve ilan detaylarında ikinci el makina fiyatları bulunmaktadır.";

                    /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                }



                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = from c in nt.tbl_Makinalar
                                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && (c.Baslik.Contains(txtKelime.Text) || c.Aciklama.Contains(txtKelime.Text) || c.IlanNo.Contains(txtKelime.Text) || c.SeoKeywords.Contains(txtKelime.Text) || c.SeoDescription.Contains(txtKelime.Text)) && (c.Statu == 2 || c.Statu == 5)
                                orderby c.Kayit_Tarihi descending
                                select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, TurSeo = T.SeoDescription, Marka = M.Kategori, c.Model, c.Para_Birimi, c.marka_ID, c.tur_ID, c.yil_ID, c.Ihale, c.StokGelis_Tarihi, c.Statu, c.IlanNo, c.Yayinlanma_Tarihi, c.Alttur_ID, c.Alttur2_ID, c.FiyatGosterilmesin, c.SEOUrl };

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
                if (ddTurlerAlt2.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur2_ID == alttur2ID);
                }
                if (ddYilMin.SelectedValue != "0" || ddYilMax.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(d => (int)d.Yil >= yil_min && (int)d.Yil <= yil_max);
                }

                if (ddParaBirimi.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Para_Birimi == parabirimi);
                }

                if (urunsorgu.Count() == 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.Text = "<center><strong>Aradığınız kritelere göre sonuç bulunamadı. Bu kategori için ilk ilanı siz verebilirsiniz. İlan vermek için <a href=/makina-ekle>tıklayınız</a></strong></center>";
                }
                else
                {
                    lblSonuc.Visible = false;
                    lblSonuc.Text = "";
                }


                rptUrunler.DataSource = urunsorgu.ToList();
                rptUrunler.DataBind();

                lblToplamIlan.Text = urunsorgu.Count().ToString();

            }
            catch (Exception ex)
            {

            }
        }

        protected void SecimleUrunleriDoldurMobil()
        {
            try
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                string Lang = Session["Lang"].ToString();

                turID = Convert.ToInt32(ddTurlerMobil.SelectedItem.Value);
                altturID = Convert.ToInt32(ddTurlerAltMobil.SelectedItem.Value);
                alttur2ID = Convert.ToInt32(ddTurlerAlt2Mobil.SelectedItem.Value);
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
                                select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.marka_ID, c.tur_ID, c.yil_ID, c.Ihale, c.StokGelis_Tarihi, c.Statu, c.IlanNo, c.Yayinlanma_Tarihi, c.Alttur_ID, c.Alttur2_ID, c.FiyatGosterilmesin, c.SEOUrl };

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
                if (ddTurlerAlt2Mobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur2_ID == alttur2ID);
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
                    lblSonuc.Text = "<center><strong>Aradığınız kritelere göre sonuç bulunamadı. Bu kategori için ilk ilanı siz verebilirsiniz. İlan vermek için <a href=/makina-ekle>tıklayınız</a></strong></center>";
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

            ListItem litaa = new ListItem("Alt Kategori(Tümü)", "0");
            ddTurlerAlt.Items.Add(litaa);
            ddTurlerAlt.SelectedValue = "0";


            ddTurlerAltMobil.DataSource = AltKategori.ToList();
            ddTurlerAltMobil.DataValueField = "Alttur_ID";
            ddTurlerAltMobil.DataTextField = "Kategori";
            ddTurlerAltMobil.DataBind();

            ListItem litaam = new ListItem("Alt Kategori(Tümü)", "0");
            ddTurlerAltMobil.Items.Add(litaam);
            ddTurlerAltMobil.SelectedValue = "0";

            //Alt-2 Türler Sil
            ddTurlerAlt2.Items.Clear();
            ListItem litaaa = new ListItem("Alt Kategori(Tümü)", "0");
            ddTurlerAlt2.Items.Add(litaaa);
            ddTurlerAlt2.SelectedValue = "0";
            ListItem litaaam = new ListItem("Alt-2 Kategori(Tümü)", "0");
            ddTurlerAlt2Mobil.Items.Add(litaaam);
            ddTurlerAlt2Mobil.SelectedValue = "0";

            SecimleUrunleriDoldur();
        }

        protected void ddTurlerMobil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gelen bilgiye göre alt kategorileri dolduruyoruz.
            ddTurlerAltMobil.Items.Clear();

            int kategoriID = Int32.Parse(ddTurlerMobil.SelectedItem.Value);
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var AltKategori = from c in Gs.tbl_MakinaAltTurleri
                              where c.Durum == true && c.tur_ID == kategoriID
                              orderby c.Kategori ascending
                              select c;

            ddTurlerAltMobil.DataSource = AltKategori.ToList();
            ddTurlerAltMobil.DataValueField = "Alttur_ID";
            ddTurlerAltMobil.DataTextField = "Kategori";
            ddTurlerAltMobil.DataBind();

            ListItem litaam = new ListItem("Alt Kategori(Tümü)", "0");
            ddTurlerAltMobil.Items.Add(litaam);
            ddTurlerAltMobil.SelectedValue = "0";

            //Alt-2 Türler Sil
            ddTurlerAlt2Mobil.Items.Clear();

            ListItem litaaam = new ListItem("Alt-2 Kategori(Tümü)", "0");
            ddTurlerAlt2Mobil.Items.Add(litaaam);
            ddTurlerAlt2Mobil.SelectedValue = "0";

            SecimleUrunleriDoldurMobil();
        }

        protected void ddTurlerAlt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gelen bilgiye göre alt-2 kategorileri dolduruyoruz.
            ddTurlerAlt2.Items.Clear();
            ddTurlerAlt2Mobil.Items.Clear();
            int kategoriID = Int32.Parse(ddTurlerAlt.SelectedItem.Value);
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var AltKategori2 = from c in Gs.tbl_MakinaAltTurleri2
                               where c.Durum == true && c.Alttur_ID == kategoriID
                               orderby c.Kategori ascending
                               select c;

            ddTurlerAlt2.DataSource = AltKategori2.ToList();
            ddTurlerAlt2.DataValueField = "Alttur2_ID";
            ddTurlerAlt2.DataTextField = "Kategori";
            ddTurlerAlt2.DataBind();

            ListItem litaa = new ListItem("Alt Kategori(Tümü)", "0");
            ddTurlerAlt2.Items.Add(litaa);
            ddTurlerAlt2.SelectedValue = "0";

            ddTurlerAlt2Mobil.DataSource = AltKategori2.ToList();
            ddTurlerAlt2Mobil.DataValueField = "Alttur2_ID";
            ddTurlerAlt2Mobil.DataTextField = "Kategori";
            ddTurlerAlt2Mobil.DataBind();

            ListItem litaam = new ListItem("Alt-2 Kategori(Tümü)", "0");
            ddTurlerAlt2Mobil.Items.Add(litaam);
            ddTurlerAlt2Mobil.SelectedValue = "0";

            SecimleUrunleriDoldur();
        }

        protected void ddTurlerAltMobil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gelen bilgiye göre alt-2 kategorileri dolduruyoruz.
            ddTurlerAlt2Mobil.Items.Clear();
            int kategoriID = Int32.Parse(ddTurlerAltMobil.SelectedItem.Value);
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var AltKategori2 = from c in Gs.tbl_MakinaAltTurleri2
                               where c.Durum == true && c.Alttur_ID == kategoriID
                               orderby c.Kategori ascending
                               select c;


            ddTurlerAlt2Mobil.DataSource = AltKategori2.ToList();
            ddTurlerAlt2Mobil.DataValueField = "Alttur2_ID";
            ddTurlerAlt2Mobil.DataTextField = "Kategori";
            ddTurlerAlt2Mobil.DataBind();

            ListItem litaam = new ListItem("Alt-2 Kategori(Tümü)", "0");
            ddTurlerAlt2Mobil.Items.Add(litaam);
            ddTurlerAlt2Mobil.SelectedValue = "0";

            SecimleUrunleriDoldurMobil();
        }

        protected void ddTurlerAlt2_SelectedIndexChanged(object sender, EventArgs e)
        {

            SecimleUrunleriDoldur();
        }

        protected void ddMarkalar_SelectedIndexChanged(object sender, EventArgs e)
        {

            SecimleUrunleriDoldur();
        }

        protected void ddTurlerAlt2Mobil_SelectedIndexChanged(object sender, EventArgs e)
        {

            SecimleUrunleriDoldurMobil();
        }

        protected void ddMarkalarMobil_SelectedIndexChanged(object sender, EventArgs e)
        {

            SecimleUrunleriDoldurMobil();
        }


        protected void rptUrunlerVitrin_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_v." + a[1];
                }

                if (urunresimsorgu.Count() == 0)
                {
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + "ornekfoto.jpg";
                }

                //Eğer İlan Fiyat Gösterilmesin sadece teklif talep edilsin olarak işaretlendiyse fiyatları gizle
                bool fiyatgosterilmesin = Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "FiyatGosterilmesin").ToString());
                if (fiyatgosterilmesin == true)
                {
                    Fiyat.Visible = true;
                    Para.Visible = false;
                    Fiyat.Text = "Fiyat Sorun";

                }

            }

        }


    }
}