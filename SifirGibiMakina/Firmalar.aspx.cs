using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class Firmalar : System.Web.UI.Page
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


            int SaticiFirmaID = Convert.ToInt32(RouteData.Values["firmaid"]);
            string Lang = Session["Lang"].ToString();
            string duzenlenmistelefon = "";
            var sorgu = from c in nt.tbl_FirmaLogolari
                        join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                        join U in nt.tbl_Uyeler on c.uye_ID equals U.uye_ID
                        where c.uye_ID == SaticiFirmaID && c.Durum == true && c.dil_ID == 1
                        select new { c.Aciklama, U.Adres, U.Telefon, c.Buyuk_Logo, c.Baslik, U.Il, U.Ilce };
            foreach (var prod in sorgu)
            {

                Master.Page.Title = prod.Baslik + " 2. el ilanları - Sahibinden " + prod.Baslik + "| Makina Al Sat | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                lblFirmaismi.Text = prod.Baslik;
                lblFirmaismi1.Text = prod.Baslik;
                ltHakkimizda.Text = prod.Aciklama;
                lblAdres.Text = prod.Adres + ", " + prod.Ilce + " " + prod.Il;
                string[] a = prod.Buyuk_Logo.Split('.');
                imgLogo.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1];



                duzenlenmistelefon = prod.Telefon;


                ltTelefon.Text = "<a href=tel:" + duzenlenmistelefon + ">" + duzenlenmistelefon + "</a>";

            }

            //Reklamdan geliyorsa tıklama sayısını artıracağız

            if (Request.QueryString["ads"] != null && Request.QueryString["ads"].ToString() != "")
            {
                int reklamalani = Convert.ToInt32(Request.QueryString["ads"].ToString());
                int varolantiklamasayisi = 0;
                var sorguSayi = from c in nt.tbl_Reklamlar
                                join D in nt.tbl_FirmaLogolari on c.logo_ID equals D.logo_ID
                                where D.uye_ID == SaticiFirmaID && c.reklamAlan_ID == reklamalani
                            select new { c.TiklamaSayisi };
                    foreach (var prod in sorguSayi)
                    {
                    varolantiklamasayisi = Convert.ToInt32(prod.TiklamaSayisi);
                    }

              var Guncelle = (from c in nt.tbl_Reklamlar
                              join D in nt.tbl_FirmaLogolari on c.logo_ID equals D.logo_ID
                              where D.uye_ID == SaticiFirmaID && c.reklamAlan_ID == reklamalani
                                select c).First();

                Guncelle.TiklamaSayisi = varolantiklamasayisi + 1;
                nt.SaveChanges();
            }



            if (!IsPostBack)
                {
                //Ürünler
                UrunleriDoldur();
               
            }
        }

        protected void UrunleriDoldur()
        {
            int SaticiFirmaID = Convert.ToInt32(RouteData.Values["firmaid"]);

            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            string Lang = Session["Lang"].ToString();

            //Ürünler Listeleniyor Seçiyoruz
            var urunsorgu = from c in nt.tbl_Makinalar
                            join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                            join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && c.Ekleyen== SaticiFirmaID && (c.Statu == 2 || c.Statu == 4 || c.Statu == 5)
                            orderby c.Kayit_Tarihi descending
                            select new { c.Aciklama, c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.Ihale, c.Statu, c.StokGelis_Tarihi, c.IlanNo, c.Yayinlanma_Tarihi, c.FiyatGosterilmesin, c.SEOUrl };

            rptUrunler.DataSource = urunsorgu.ToList();
            rptUrunler.DataBind();

            lblToplamIlan.Text = urunsorgu.Count().ToString();

            //Kategorileri tek olarak alıyoruz.

            //Ürünler Listeleniyor Seçiyoruz
            var kategorisorgu = from c in nt.tbl_Makinalar
                            join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                            join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && c.Ekleyen == SaticiFirmaID && (c.Statu == 2 || c.Statu == 4 || c.Statu == 5)
                            orderby c.Kayit_Tarihi descending
                            select new { Tur = T.Kategori, c.tur_ID };

            rptKategoriler.DataSource = kategorisorgu.Distinct().ToList();
            rptKategoriler.DataBind();
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
    }
}