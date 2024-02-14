
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Diagnostics;
using SiteUtils;
using SifirGibiMakina.Dtos.Machine;


namespace SifirGibiMakina
{
    public partial class Arama : System.Web.UI.Page
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

        db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {



            SetSEOAttributes();

            if (!IsPostBack)
            {
                PopulateDropdowns(nt);


                Search();





            }



        }
        private void Search()
        {

            if (Request.QueryString["keyword"] != null)
            {
                string keyword = Request.QueryString["keyword"].ToString();
                keyword = keyword.Replace("ç", "c").Replace("ğ", "g")
                 .Replace("ı", "i").Replace("ö", "o")
                 .Replace("ş", "s").Replace("ü", "u")
                 .Replace("Ç", "C").Replace("Ğ", "G")
                 .Replace("İ", "I").Replace("Ö", "O")
                 .Replace("Ş", "S").Replace("Ü", "U");

                HandleKeywordSearchInCategories(nt, keyword);

            }
        }

        private void SetSEOAttributes()
        {
            Master.Page.Title = "2. el makinalar, 2. el makineler, ikinci el makina al sat, ihaleli makineler";
            Master.Page.MetaDescription = "Sahibinden veya satıcıdan ikinci el satılık makina fiyatları ilanları yer alan 2 el sifir gibi yeni makine ilan sitesidir. Makine satıcıları ve alıcılarının buluşma portalı..";
            Master.Page.MetaKeywords = "2. el makinalar, 2. el makineler, ikinci el makina al sat, ihaleli makineler, makina al sat, makine al sat, talaşlı makina, cnc makinaları";
        }

        private void PopulateDropdowns(db_SifirGibiMakinaEntities nt)
        {
            LoadMachineTypesToDropdowns(nt);
            LoadSubtypesToDropdowns(nt);
            LoadSubtypes2ToDropdowns(nt);
            LoadBrandsToDropdowns(nt);
            LoadYearsToDropdowns(nt);
        }
        private List<int> GetSubSubCategoryIDs(db_SifirGibiMakinaEntities nt, string keyword)
        {
            var result = nt.tbl_MakinaAltTurleri2
                .Where(subSubCategory => subSubCategory.Kategori.Contains(keyword))
                .Select(subSubCategory => subSubCategory.Alttur2_ID)
                .ToList();

            return result;
        }
        private List<int> GetCategoryIDs(db_SifirGibiMakinaEntities nt, string keyword)
        {
            var result = nt.tbl_MakinaTurleri
                .Where(subSubCategory => subSubCategory.Kategori.Contains(keyword))
                .Select(subSubCategory => subSubCategory.tur_ID)
                .ToList();

            return result;
        }
        private List<int> GetSubCategoryIDs(db_SifirGibiMakinaEntities nt, string keyword)
        {
            var result = nt.tbl_MakinaAltTurleri
                .Where(subSubCategory => subSubCategory.Kategori.Contains(keyword))
                .Select(subSubCategory => subSubCategory.Alttur_ID)
                .ToList();

            return result;
        }
        private List<int> GetBrandIDs(db_SifirGibiMakinaEntities nt, string keyword)
        {
            var result = nt.tbl_MakinaMarkalari
                .Where(subSubCategory => subSubCategory.Kategori.Contains(keyword))
                .Select(subSubCategory => subSubCategory.marka_ID)
                .ToList();

            return result;
        }


        private void HandleKeywordSearchInCategories(db_SifirGibiMakinaEntities nt, string keyword)
        {
            var resultSubSubCategory = GetSubSubCategoryIDs(nt, keyword);
            var resultCategory = GetCategoryIDs(nt, keyword);
            var resultSubCategory = GetSubCategoryIDs(nt, keyword);
            var resultBrand = GetBrandIDs(nt, keyword);

            var urunsorgu = (from m in nt.tbl_Makinalar
                             where m.Durum == true && m.dil_ID == 1 && m.Yayinda == true && (m.Statu == 2 || m.Statu == 5) && (m.Statu == 2 || m.Statu == 5)
                             orderby m.Kayit_Tarihi descending

                             join Y in nt.tbl_MakinaYillar on m.yil_ID equals Y.yil_ID
                             join T in nt.tbl_MakinaTurleri on m.tur_ID equals T.tur_ID
                             join M in nt.tbl_MakinaMarkalari on m.marka_ID equals M.marka_ID
                             where (resultSubSubCategory.Contains(m.Alttur2_ID ?? 0) ||
                             resultCategory.Contains(m.tur_ID ?? 0) ||
                             resultSubCategory.Contains(m.Alttur_ID ?? 0) ||
                                 resultBrand.Contains(m.marka_ID ?? 0)) || m.Aciklama.Contains(keyword.ToUpper())

                             select new MachineDetailDto
                             {
                                 makina_ID = m.makina_ID,
                                 Baslik = m.Baslik,
                                 TurAdı = T.Kategori,
                                 MarkaAdı = M.Kategori,
                                 MachineYear = Y.Kategori,
                                 Fiyat = m.Fiyat,
                                 Para_Birimi = m.Para_Birimi,
                                 Fotograf = m.Fotograf,
                                 FiyatGosterilmesin = m.FiyatGosterilmesin,
                                 Yayinlanma_Tarihi = m.Yayinlanma_Tarihi,
                                 SEOUrl = m.SEOUrl,
                                 AnaVitrin = m.AnaVitrin,
                                 Ihale = m.Ihale,
                                 Vitrin = m.Vitrin,
                                 tur_ID = m.tur_ID,
                                 Ihale_Bitis = m.Ihale_Bitis,
                                 Kayit_Tarihi = m.Kayit_Tarihi,
                             }).ToList();


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

            var urunList = urunsorgu.ToList();
            int pages = urunList.Count();
            CollectionPager1.DataSource = urunList;
            CollectionPager1.PageCount.CompareTo(pages / 24);
            CollectionPager1.BindToControl = rptUrunler;

            rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
            rptUrunler.DataBind();

            CollectionPager2.DataSource = urunList;
            CollectionPager2.PageCount.CompareTo(urunList.Count() / 24);
            CollectionPager2.BindToControl = rptUrunlerMobil;
            rptUrunlerMobil.DataSource = CollectionPager2.DataSourcePaged;
            rptUrunlerMobil.DataBind();




            lblToplamIlan.Text = urunList.Count().ToString();
            lblToplamIlanMobil.Text = urunList.Count().ToString();


            VitrinUrunleriDoldur();


        }



        private void LoadMachineTypesToDropdowns(db_SifirGibiMakinaEntities nt)
        {
            var Turler = from c in nt.tbl_MakinaTurleri
                         where c.dil_ID == 1 && c.Durum == true
                         orderby c.Kategori ascending
                         select c;

            // Dropdown listelerini dolduruyoruz
            ddTurler.DataSource = Turler.ToList();
            ddTurler.DataValueField = "tur_ID";
            ddTurler.DataTextField = "Kategori";
            ddTurler.DataBind();

            ddTurlerMobil.DataSource = Turler.ToList();
            ddTurlerMobil.DataValueField = "tur_ID";
            ddTurlerMobil.DataTextField = "Kategori";
            ddTurlerMobil.DataBind();

            // Eğer URL'den kategori bilgisi geliyorsa, dropdown listesinin seçili değerini ayarlayın
            if (Request.QueryString["kategori"] != null)
            {
                ddTurler.SelectedValue = Request.QueryString["kategori"].ToString();
                ddTurlerMobil.SelectedValue = Request.QueryString["kategori"].ToString();
            }
            else
            {
                ListItem lit = new ListItem("Makine Türü(Tümü)", "0");
                ddTurler.Items.Insert(0, lit);
                ddTurler.SelectedValue = "0";

                ListItem litm = new ListItem("Makine Türü(Tümü)", "0");
                ddTurlerMobil.Items.Insert(0, litm);
                ddTurlerMobil.SelectedValue = "0";
            }
        }

        private void LoadSubtypesToDropdowns(db_SifirGibiMakinaEntities nt)
        {
            var AltTurler = from c in nt.tbl_MakinaAltTurleri
                            where c.Durum == true && c.dil_ID == 1
                            orderby c.Kategori ascending
                            select c;

            ddTurlerAlt.DataSource = AltTurler.ToList();
            ddTurlerAlt.DataValueField = "Alttur_ID";
            ddTurlerAlt.DataTextField = "Kategori";
            ddTurlerAlt.DataBind();
            ListItem litaa = new ListItem("Alt Kategori(Tümü)", "0");
            ddTurlerAlt.Items.Insert(0, litaa);
            ddTurlerAlt.SelectedValue = "0";

            ddTurlerAltMobil.DataSource = AltTurler.ToList();
            ddTurlerAltMobil.DataValueField = "Alttur_ID";
            ddTurlerAltMobil.DataTextField = "Kategori";
            ddTurlerAltMobil.DataBind();
            ListItem litaam = new ListItem("Alt Kategori(Tümü)", "0");
            ddTurlerAltMobil.Items.Insert(0, litaam);
            ddTurlerAltMobil.SelectedValue = "0";
        }

        private void LoadSubtypes2ToDropdowns(db_SifirGibiMakinaEntities nt)
        {
            var AltTurler2 = from c in nt.tbl_MakinaAltTurleri2
                             where c.Durum == true && c.dil_ID == 1
                             orderby c.Kategori ascending
                             select c;

            ddTurlerAlt2.DataSource = AltTurler2.ToList();
            ddTurlerAlt2.DataValueField = "Alttur2_ID";
            ddTurlerAlt2.DataTextField = "Kategori";
            ddTurlerAlt2.DataBind();
            ListItem litaaa = new ListItem("Alt-2 Kategori(Tümü)", "0");
            ddTurlerAlt2.Items.Insert(0, litaaa);
            ddTurlerAlt2.SelectedValue = "0";

            ddTurlerAlt2Mobil.DataSource = AltTurler2.ToList();
            ddTurlerAlt2Mobil.DataValueField = "Alttur2_ID";
            ddTurlerAlt2Mobil.DataTextField = "Kategori";
            ddTurlerAlt2Mobil.DataBind();
            ListItem litaaam = new ListItem("Alt Kategori(Tümü)", "0");
            ddTurlerAlt2Mobil.Items.Insert(0, litaaam);
            ddTurlerAlt2Mobil.SelectedValue = "0";
        }

        private void LoadBrandsToDropdowns(db_SifirGibiMakinaEntities nt)
        {
            var Markalar = from c in nt.tbl_MakinaMarkalari
                           where c.dil_ID == 1
                           orderby c.Kategori ascending
                           select c;

            ddMarkalar.DataSource = Markalar.ToList();
            ddMarkalar.DataValueField = "marka_ID";
            ddMarkalar.DataTextField = "Kategori";
            ddMarkalar.DataBind();

            ddMarkalarMobil.DataSource = Markalar.ToList();
            ddMarkalarMobil.DataValueField = "marka_ID";
            ddMarkalarMobil.DataTextField = "Kategori";
            ddMarkalarMobil.DataBind();

            if (Request.QueryString["marka"] != null)
            {
                ddMarkalar.SelectedValue = Request.QueryString["marka"].ToString();
                ddMarkalarMobil.SelectedValue = Request.QueryString["marka"].ToString();
            }
            else
            {
                ListItem lim = new ListItem("Marka(Tümü)", "0");
                ddMarkalar.Items.Insert(0, lim);
                ddMarkalar.SelectedValue = "0";
                ListItem limm = new ListItem("Marka(Tümü)", "0");
                ddMarkalarMobil.Items.Insert(0, limm);
                ddMarkalarMobil.SelectedValue = "0";
            }
        }

        private void LoadYearsToDropdowns(db_SifirGibiMakinaEntities nt)
        {
            var Yillar = from c in nt.tbl_MakinaYillar
                         where c.dil_ID == 1
                         orderby c.Kategori ascending
                         select c;

            ddYilMin.DataSource = Yillar.ToList();
            ddYilMin.DataValueField = "Kategori";
            ddYilMin.DataTextField = "Kategori";
            ddYilMin.DataBind();
            ListItem limym = new ListItem("Yıl(Min)", "0");
            ddYilMin.Items.Insert(0, limym);
            ddYilMin.SelectedValue = "0";

            ddYilMinMobil.DataSource = Yillar.ToList();
            ddYilMinMobil.DataValueField = "Kategori";
            ddYilMinMobil.DataTextField = "Kategori";
            ddYilMinMobil.DataBind();
            ListItem limymmobil = new ListItem("Yıl(Min)", "0");
            ddYilMinMobil.Items.Insert(0, limymmobil);
            ddYilMinMobil.SelectedValue = "0";

            ddYilMax.DataSource = Yillar.ToList();
            ddYilMax.DataValueField = "Kategori";
            ddYilMax.DataTextField = "Kategori";
            ddYilMax.DataBind();
            ListItem limyma = new ListItem("Yıl(Max)", "0");
            ddYilMax.Items.Insert(0, limyma);
            ddYilMax.SelectedValue = "0";

            ddYilMaxMobil.DataSource = Yillar.ToList();
            ddYilMaxMobil.DataValueField = "Kategori";
            ddYilMaxMobil.DataTextField = "Kategori";
            ddYilMaxMobil.DataBind();
            ListItem limymaxmobil = new ListItem("Yıl(Max)", "0");
            ddYilMaxMobil.Items.Insert(0, limymaxmobil);
            ddYilMaxMobil.SelectedValue = "0";
        }





        protected void rptUrunler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //Link
                //Literal Link = (Literal)e.Item.FindControl("ltLink");
                //Link.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir() + "/" + DataBinder.Eval(e.Item.DataItem, "makina_ID") + ">";

                //Fiyat
                Literal Fiyat = (Literal)e.Item.FindControl("ltFiyat");
                string fiyati = DataBinder.Eval(e.Item.DataItem, "Fiyat").ToString();
                Fiyat.Text = string.Format("{0:0,0}", fiyati); ;

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

        protected void btnTumu_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/urunler");

                //db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                //string Lang = Session["Lang"].ToString();



                ////Listeleri Sıfırlıyoruz
                //ddTurler.SelectedValue = "0";
                //ddTurlerAlt.SelectedValue = "0";
                //ddTurlerAlt2.SelectedValue = "0";
                //ddMarkalar.SelectedValue = "0";
                //txtFiyatMax.Text = "";
                //txtFiyatMin.Text = "";
                //ddYilMax.SelectedValue= "0";
                //ddYilMin.SelectedValue= "0";
                //ddParaBirimi.SelectedValue="0";

                //ddTurlerMobil.SelectedValue = "0";
                //ddTurlerAltMobil.SelectedValue = "0";
                //ddTurlerAlt2Mobil.SelectedValue = "0";
                //ddMarkalarMobil.SelectedValue = "0";
                //txtFiyatMaxMobil.Text = "";
                //txtFiyatMinMobil.Text = "";
                //ddYilMaxMobil.SelectedValue = "0";
                //ddYilMinMobil.SelectedValue = "0";
                //ddParaBirimiMobil.SelectedValue = "0";


                ////Ürünler Listeleniyor Seçiyoruz
                //var urunsorgu = from c in nt.tbl_Makinalar
                //                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                //                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                //                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                //                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                //                where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && (c.Statu == 2 || c.Statu == 5)
                //                orderby c.Makina_Order, c.Kayit_Tarihi descending
                //                select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.Ihale, c.Statu, c.StokGelis_Tarihi, c.IlanNo, c.Yayinlanma_Tarihi };

                //CollectionPager1.DataSource = urunsorgu.ToList();
                //CollectionPager1.BindToControl = rptUrunler;
                //rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
                //rptUrunler.DataBind();
                //rptUrunlerMobil.DataSource = urunsorgu.ToList();
                //rptUrunlerMobil.DataBind();
                //lblSonuc.Visible = false;
                //lblSonuc.Text = "";
                //lblToplamIlan.Text = urunsorgu.Count().ToString();
                //lblToplamIlanMobil.Text = urunsorgu.Count().ToString();

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {

            }
        }

        protected void btnMobilAra_Click(object sender, EventArgs e)
        {
            try
            {


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



        protected void dtOneCikanKategoriler_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                string Lang = Session["Lang"].ToString();
                int id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "tur_ID").ToString());


                //Link
                Literal Link = (Literal)e.Item.FindControl("ltLink");
                Link.Text = "<a href=/kategori/" + DataBinder.Eval(e.Item.DataItem, "Tur").ToString().UrlCevir() + "/ikinci-el-makina/" + id + ">";

                Literal Link1 = (Literal)e.Item.FindControl("ltLink1");
                Link1.Text = "<a href=/kategori/" + DataBinder.Eval(e.Item.DataItem, "Tur").ToString().UrlCevir() + "/ikinci-el-makina/" + id + ">";

                Literal Link2 = (Literal)e.Item.FindControl("ltLink2");
                Link2.Text = "<a href=/kategori/" + DataBinder.Eval(e.Item.DataItem, "Tur").ToString().UrlCevir() + "/ikinci-el-makina/" + id + ">";

                //Öne Cikan Kategorilerde kaç tane makina ilanı var onu gösteriyoruz
                var SorguTurAdeti = from c in nt.tbl_Makinalar
                                    where c.Durum == true && c.Yayinda == true && c.tur_ID == id & (c.Statu == 2 || c.Statu == 5)
                                    select c;


                Literal adet = (Literal)e.Item.FindControl("ltCount");
                adet.Text = SorguTurAdeti.Count().ToString();

                //İmaj
                string foto = "";
                foto = Convert.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Fotograf")) ? "" : (String)DataBinder.Eval(e.Item.DataItem, "Fotograf");
                Image imgresim = (Image)e.Item.FindControl("imgResim");

                if (string.IsNullOrEmpty(foto) == true)
                {
                    imgresim.ImageUrl = "/images/logo.png";
                }
                else
                {
                    string[] a = foto.Split('.');
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1];

                }
            }
        }

        protected void ddTurler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gelen bilgiye göre alt kategorileri dolduruyoruz.
            ddTurlerAlt.Items.Clear();
            ddTurlerMobil.Items.Clear();

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
                            where c.Durum == true && c.Yayinda == true && c.Vitrin == true && c.Statu == 2
                            orderby Guid.NewGuid()
                            select new { c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, c.Model, c.Para_Birimi, Tur = T.Kategori, Yil = Y.Kategori, Marka = M.Kategori, c.Yayinlanma_Tarihi, c.FiyatGosterilmesin, c.SEOUrl };

            rptUrunlerVitrin.DataSource = urunsorgu.ToList().Take(10);
            rptUrunlerVitrin.DataBind();

            rptUrunlerVitrinMobil.DataSource = urunsorgu.ToList().Take(8);
            rptUrunlerVitrinMobil.DataBind();
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