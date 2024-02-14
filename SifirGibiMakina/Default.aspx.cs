using SifirGibiMakina.Business;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Dtos.Category;
using SifirGibiMakina.Helpers.ReWriterPathHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace SifirGibiMakina
{
    public partial class Default : System.Web.UI.Page
    {
        int slidersay = 0;
        int slidersaymobil = 0;
        int slidersaymobilindi = 0;
        public IMachineBrandService _machineBrandService { get; set; }
        public ISocialMediaService _socialMediaService { get; set; }
        public ICompanyLogoService _companyLogoService { get; set; } 
        public IBlogService _blogService { get; set; }
        public IAdvertisementService _advertisementService { get; set; }
        public ICategoryService _categoryService { get; set; }
        public IMachineService _machineService { get; set; }
        public IMachineYearService _machineYearService { get; set; }


    









        protected void Page_Load(object sender, EventArgs e)
        {
           

            //Dil Algılamatb
            string Language = Request.QueryString["lang"];
            if (Language != null)
            {
                ChangeLanguage(Language);
                Response.Redirect(Request.UrlReferrer.AbsoluteUri);
            }

            
            string Lang = Session["Lang"].ToString();
            if (!IsPostBack)
            {  //Sosyal Medya
                SosyalMedyalariDoldur();
                HaberleriDoldur();
                //Firma Logoları
                LogolariDoldur();
                //Reklamlari Doldur
                //ReklamlariDoldur();
                KategorileriDoldur();
                AllCategories();
                MachineYearList(); 
                MachineBrandList();
            }
               

            //Blog
  

            //Vitrin Ürünleri
            UrunleriDoldur();

     
         

            //Sarılar
            SayilariDoldur();

            //Yeni Eklenenler
            YeniEklenenleriDoldur();

            //Vitrin 1 tane büyük ilan doldur
            AnaVitrinDoldur();

      

           

            //İhaleleri Doldur
            IhaleleriDoldur();

    

            

        }
        private void MachineBrandList()
        {

            var Markalar = _machineBrandService.GetAllBrandMachines();

            ddMarkalar.DataSource = Markalar.ToList();
            ddMarkalar.DataValueField = "marka_ID";
            ddMarkalar.DataTextField = "Kategori";
            ddMarkalar.DataBind();
            ListItem lim = new ListItem("Seçiniz", "0");
            ddMarkalar.Items.Add(lim);
            ddMarkalar.SelectedValue = "0";
        }
        private void MachineYearList()
        {

            var Yillar = _machineYearService.GetMachineYearList();

            ddYillar.DataSource = Yillar.ToList();
            ddYillar.DataValueField = "yil_ID";
            ddYillar.DataTextField = "Kategori";
            ddYillar.DataBind();
            ListItem liy = new ListItem("Seçiniz", "0");
            ddYillar.Items.Add(liy);
            ddYillar.SelectedValue = "0";
        }
        private void SosyalMedyalariDoldur()
        {
            
            var hesapsorgufooter = _socialMediaService.GetAllSocialMedias();
                rptSosyalmedyaFooter.DataSource = hesapsorgufooter.ToList();
                rptSosyalmedyaFooter.DataBind();

                rptSosyalHamburger.DataSource = hesapsorgufooter.ToList();
                rptSosyalHamburger.DataBind();
            
        }
        //blog
        private void HaberleriDoldur()
        {
            
            string Lang = Session["Lang"].ToString();
         
         
                int habercat = 1;

      
            var blogAnasorgu = _blogService.GetBlogList(habercat);

             rptBlogAna.DataSource = blogAnasorgu.ToList().Take(1);
            rptBlogAna.DataBind();

      
                var habersorgu = _blogService.GetBlogList(habercat);

                 rptBlog.DataSource = habersorgu.ToList().Take(4);
                rptBlog.DataBind();
            
        }

        private void UrunleriDoldur()
        {
          
           
            //Ürünler Listeleniyor Seçiyoruz
            var urunsorgu = _machineService.GetMachineList().Where(x=>x.Vitrin == true);
            var randomUrun = urunsorgu.OrderBy(x => Guid.NewGuid()).Take(4);

            rptUrunlerVitrin.DataSource = randomUrun.ToList();
            rptUrunlerVitrin.DataBind();
        }

        private void KategorileriDoldur()
        {

            string Lang = Session["Lang"].ToString();

            
            var kategorisorgu = _categoryService.GetCategoriesWithSubcategories();

            var ilk5AnaKategori = kategorisorgu.Take(5).ToList();

           
            foreach (var anaKategori in ilk5AnaKategori)
            {
                anaKategori.tbl_MakinaAltTurleris = anaKategori.tbl_MakinaAltTurleris.Take(5).ToList();
            }

         
            rptKategoriler.DataSource = ilk5AnaKategori;
            rptKategoriler.DataBind();

        }
        private void AllCategories()
        {
            var Turler = _categoryService.GetCategoriesWithSubcategories();

            ddTurler.DataSource = Turler.ToList();
            ddTurler.DataValueField = "tur_ID";
            ddTurler.DataTextField = "Kategori";
            ddTurler.DataBind();
            ListItem lit = new ListItem("Seçiniz", "0");
            ddTurler.Items.Add(lit);
            ddTurler.SelectedValue = "0";
        }

    
        //private void ReklamlariDoldur()
        //{
              
        //        int reklamAnaSayfaHeader = 6;

           
        //        var Reklam1 = _advertisementService.GetAdvertisement(reklamAnaSayfaHeader);
        //        rptReklamAlaniHeader.DataSource = new[] { Reklam1 };
        //        rptReklamAlaniHeader.DataBind();


               
            

            
        //}

       

        protected void ChangeLanguage(string LanguageCode)
        {
            HttpCookie LangCookie = new HttpCookie("Language");
            LangCookie.Value = LanguageCode;
            LangCookie.Expires = DateTime.MaxValue;
            Response.Cookies.Add(LangCookie);
        }

        protected void rptBlog_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //Link
                Literal Link = (Literal)e.Item.FindControl("ltLink");
                Link.Text = "<a href="+DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir()+"/"+ DataBinder.Eval(e.Item.DataItem, "duy_ID")+">";
                
                //İmaj
                string foto = "";
                foto = Convert.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Fotograf")) ? "" : (String)DataBinder.Eval(e.Item.DataItem, "Fotograf");
                Image imgresim = (Image)e.Item.FindControl("imgBlog");

                if (string.IsNullOrEmpty(foto) == true)
                {
                    imgresim.ImageUrl = "/images/logo.png";
                }
                else
                {
                    string[] a = foto.Split('.');
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_analist." + a[1];

                }
            }

        }

        protected void rptBlogAna_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //Link
                Literal Link = (Literal)e.Item.FindControl("ltLink");
                Link.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir() + "/" + DataBinder.Eval(e.Item.DataItem, "duy_ID") + ">";

                //İmaj
                string foto = "";
                foto = Convert.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Fotograf")) ? "" : (String)DataBinder.Eval(e.Item.DataItem, "Fotograf");
                Image imgresim = (Image)e.Item.FindControl("imgBlog");

                if (string.IsNullOrEmpty(foto) == true)
                {
                    imgresim.ImageUrl = "/images/logo.png";
                }
                else
                {
                    string[] a = foto.Split('.');
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_analist." + a[1];

                }
            }

        }


        protected void rptReklamAlaniHeader_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //Link
                int logoID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "logo_ID").ToString());
                string Baslik = DataBinder.Eval(e.Item.DataItem, "Adi").ToString();
                string url = DataBinder.Eval(e.Item.DataItem, "Url").ToString();
                string resim = DataBinder.Eval(e.Item.DataItem, "Dosya").ToString();

                //Gelen Logo ID'ye göre Üye ID bulunuyor
                using (var nt = new db_SifirGibiMakinaEntities())
                {
                    //var uyelogoID = from c in nt.tbl_FirmaLogolari
                    //                where c.logo_ID == logoID
                    //                select c;

                    //foreach (var prods in uyelogoID)
                    //{
                    //    logoID = Convert.ToInt32(prods.uye_ID);

                    //}
                    var firmaLogosu = _companyLogoService.GetCompanyLogoById(logoID);

                    // Eğer bir üye ID'si almak istiyorsanız, firmaLogosu nesnesinden erişebilirsiniz
                    if (firmaLogosu != null)
                    {
                        logoID = Convert.ToInt32(firmaLogosu.uye_ID);
                    }


                    Literal Link = (Literal)e.Item.FindControl("ltLink");


                    if (url != "")
                    {
                        Link.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "Url").ToString() + "><img class=\"img-fluid\" src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + resim + "></a>";

                    }
                    else
                    {
                        Link.Text = "<a href=\"/satici-firma/" + logoID + "/" + URLHelper.RewritePath("1", Baslik, 1) + "/ikinci-el-makina?ads=6\"><img class=\"img-fluid\" src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + resim + "></a>";

                    }
                }
            }

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
                using (var nt = new db_SifirGibiMakinaEntities())
                {

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

                    //Mobil Cihaz Kontrol
                    System.Web.HttpBrowserCapabilities browser = Request.Browser;
                    Literal BaslikLT = (Literal)e.Item.FindControl("ltBaslik");
                    string Baslik = DataBinder.Eval(e.Item.DataItem, "Baslik").ToString();

                    if (browser.IsMobileDevice == true)
                    {

                        if (Baslik.Length >= 40)
                        {
                            BaslikLT.Text = Baslik.Substring(0, 36) + "...";
                        }
                        else
                        {
                            BaslikLT.Text = Baslik;
                        }

                    }
                    else
                    {
                        BaslikLT.Text = Baslik;
                    }

                }
            }

        }

        protected void YeniEklenenleriDoldur()
        {
           
            
            
              
                var urunsorgu = _machineService.GetMachineList().OrderByDescending(x=>x.Kayit_Tarihi);

                rptYeniEklenenler.DataSource = urunsorgu.ToList().Take(10);
                rptYeniEklenenler.DataBind();
            
        }

        protected void rptYeniEklenenler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Fiyat
                Literal Fiyat = (Literal)e.Item.FindControl("ltFiyat");
                string fiyati = DataBinder.Eval(e.Item.DataItem, "Fiyat").ToString();
                Fiyat.Text = string.Format("{0:0,0}", fiyati);

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
                using (var nt = new db_SifirGibiMakinaEntities())
                {

                    var urunresimsorgu = from c in nt.tbl_MakinaResimler
                                         where c.Durum == true && c.Vitrin == true && c.makina_ID == makinaID
                                         select c;

                    foreach (var prods in urunresimsorgu)
                    {
                        string[] a = prods.Fotograf.Split('.');
                        imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_ye." + a[1];
                    }

                    if (urunresimsorgu.Count() == 0)
                    {
                        imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + "ornekfoto1.jpg";
                    }

                    //Eğer İlan Fiyat Gösterilmesin sadece teklif talep edilsin olarak işaretlendiyse fiyatları gizle
                    bool fiyatgosterilmesin = Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "FiyatGosterilmesin").ToString());
                    if (fiyatgosterilmesin == true)
                    {
                        Fiyat.Visible = true;
                        Para.Visible = false;
                        Fiyat.Text = "Fiyat Sorun";

                    }

                    //Mobil Cihaz Kontrol
                    System.Web.HttpBrowserCapabilities browser = Request.Browser;
                    Literal BaslikLT = (Literal)e.Item.FindControl("ltBaslik");
                    string Baslik = DataBinder.Eval(e.Item.DataItem, "Baslik").ToString();

                    if (browser.IsMobileDevice == true)
                    {

                        if (Baslik.Length >= 40)
                        {
                            BaslikLT.Text = Baslik.Substring(0, 36) + "...";
                        }
                        else
                        {
                            BaslikLT.Text = Baslik;
                        }

                    }
                    else
                    {
                        BaslikLT.Text = Baslik;
                    }
                }
            }

        }

        protected void AnaVitrinDoldur()
        {
          
          
                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = _machineService.GetMachineList().Where(x => x.AnaVitrin == true);
            var randomUrun = urunsorgu.OrderBy(x => Guid.NewGuid()).Take(1);
            rptAnaVitrin.DataSource = randomUrun.ToList();
                rptAnaVitrin.DataBind();
            
        }

        protected void rptAnaVitrin_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                    Fiyat.Visible = true;
                    Para.Visible = false;
                    Fiyat.Text = "Fiyat Sorun";

                }
            }

        }

        private void SayilariDoldur()
        {
         
            string Lang = Session["Lang"].ToString();
            using (var nt = new db_SifirGibiMakinaEntities())
            {
                /////////////////////////////////////////Sayı Bilgileri/////////////////////////////////////
                int sayipaneli = 0;
                int ekuyesayisi = 0;
                int eksatilanmakinasayisi = 0;
                int ekverilenteklifsayisi = 0;
                int ekkatilankisisayisi = 0;
                var Sorgu = from c in nt.tbl_Ayarlar
                            select c;

                foreach (var prods in Sorgu)
                {
                    sayipaneli = Convert.ToInt32(prods.SayilarPanel);
                    ekuyesayisi = Convert.ToInt32(prods.EkUyeSayisi);
                    eksatilanmakinasayisi = Convert.ToInt32(prods.EkSatilanMakinaSayisi);
                    ekverilenteklifsayisi = Convert.ToInt32(prods.EkTeklifSayisi);
                    ekkatilankisisayisi = Convert.ToInt32(prods.EkAcikArtirmaSayisi);
                    ltFooterSeo.Text = prods.SEOAnaSayfa;
                }
                if (sayipaneli == 1)
                {
                    pnlSayilar.Visible = true;
                }

                //Üye Sayısı
                var MTUyeler = (from c in nt.tbl_Uyeler
                                where c.Durum == true && c.Aktif == true
                                select c).Count();
                ltUyeSayisi.Text = "<h4 class=\"counting\" data-count=\"" + (MTUyeler + ekuyesayisi).ToString() + "\">0</h4>";


                //Satılan Sayısı
                var MTMakinalar = (from c in nt.tbl_Makinalar
                                   where c.Durum == true && c.Statu == 4
                                   select c).Count();
                ltSatilanMakina.Text = "<h4 class=\"counting\" data-count=\"" + (MTMakinalar + eksatilanmakinasayisi).ToString() + "\">0</h4>";

                //Verilen Teklif Sayısı
                var MTTeklifler = (from c in nt.tbl_Ihale
                                   select c).Count();
                ltAcikArtirmaTeklif.Text = "<h4 class=\"counting\" data-count=\"" + (MTTeklifler + ekverilenteklifsayisi).ToString() + "\">0</h4>";

                //Ihaleye Katılan Kişi Sayısı
                var MTKatilanKKisi = (from c in nt.tbl_Ihale
                                      select new { c.uye_ID }).Distinct().Count();
                ltAcikArtirmaUye.Text = "<h4 class=\"counting\" data-count=\"" + (MTKatilanKKisi + ekkatilankisisayisi).ToString() + "\">0</h4>";

                /////////////////////////////////////////Sayı Bilgileri/////////////////////////////////////
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Response.Redirect(search_input.Value);
            Response.Redirect("/arama?keyword="+search_input.Value);
        }

        //protected void btnSearchMobil_Click(object sender, EventArgs e)
        //{
        //    //Response.Redirect(txtSearchMobil.Value);
        //    Response.Redirect("/arama?keyword="+txtSearchMobil.Value);
        //}

        protected void rptKategoriler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

          
                Image imgkategori = (Image)e.Item.FindControl("imgKategori");
                string Resim = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Resim"));
                string imagePath = ConfigurationManager.AppSettings["imagePath"].ToString();

                imgkategori.ImageUrl = String.IsNullOrEmpty(Resim)
                                        ? imagePath + "bos-kategori.jpg"
                                        : imagePath + Path.GetFileNameWithoutExtension(Resim) + "_v" + Path.GetExtension(Resim);







            }

        }

        

      

        private void LogolariDoldur()
        {
           
            string Lang = Session["Lang"].ToString();

            var logoSorgu = _companyLogoService.GetAllLogos(true, true, 1);
      

            rptFirmaLogolari.DataSource = logoSorgu.ToList().Take(30);
            rptFirmaLogolari.DataBind();
        }

       

        protected void IhaleleriDoldur()
        {
            using (var nt = new db_SifirGibiMakinaEntities())
            {
                string Lang = Session["Lang"].ToString();

                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = _machineService.GetMachineList().Where(x => x.Ihale == true);
                //var urunsorgu = from c in nt.tbl_Makinalar
                //                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                //                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                //                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                //                where c.Durum == true && c.Yayinda == true && (c.Statu == 2 || c.Statu == 4) && c.Ihale == true
                //                orderby c.Makina_Order, Guid.NewGuid()
                //                select new { c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, c.Model, c.Para_Birimi, Tur = T.Kategori, Yil = Y.Kategori, Marka = M.Kategori, c.Yayinlanma_Tarihi, c.tur_ID, c.Ihale_Baslangic, c.Ihale_Bitis, c.FiyatGosterilmesin, c.SEOUrl };

                rptIhaleler.DataSource = urunsorgu.ToList().Take(3);
                rptIhaleler.DataBind();

                if (urunsorgu.Count() > 0)
                {
                    pnlIhale.Visible = true;
                }
            }
            
        }

        protected void rptIhaleler_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                using (var nt = new db_SifirGibiMakinaEntities()) { 

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

                //ihale süresi doldu mu ?

                DateTime bitisuresi = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "Ihale_Bitis").ToString());
                HtmlGenericControl div = e.Item.FindControl("suredoldu") as HtmlGenericControl;
                HtmlGenericControl divihalesuresi = e.Item.FindControl("ihalesuresi") as HtmlGenericControl;
                Literal ihalekatilbtn = (Literal)e.Item.FindControl("ltIhaleKatilBtn");

                if (DateTime.Now > bitisuresi)
                {
                    div.Visible = true;
                    divihalesuresi.Visible = false;
                    imgresim.CssClass = "card-img-top img-GreyFiltrer";
                    ihalekatilbtn.Visible = false;
                    ihalekatilbtn.Text = "<a href=ihale/" + makinaID + " class=\"text-muted\">İhaleye Katıl <i class=\"fas fa-chevron-right ml-1 text-muted\"></i></a>";
                }
                else
                {
                    div.Visible = false;
                    divihalesuresi.Visible = true;
                    ihalekatilbtn.Text = "<a href=ihale/"+makinaID+ " class=\"text-muted\">İhaleye Katıl <i class=\"fas fa-chevron-right ml-1 text-muted\"></i></a>";
                }
                }

            }

        }

    }
}