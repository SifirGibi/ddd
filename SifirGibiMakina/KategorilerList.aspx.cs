using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class KategorilerList : System.Web.UI.Page
    {
       
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (RouteData.Values["turid"] != null)
            {
                //Gelen Değer int mi kontrol ediyoruz.
                if (!Int32.TryParse(RouteData.Values["turid"].ToString(), out int sayi))
                {
                    Response.Redirect("/404.aspx");
                    Environment.Exit(0);
                }
                else
                {
                    int turid = Convert.ToInt32(RouteData.Values["turid"].ToString());
                    string Lang = Session["Lang"].ToString();

                    
                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                    var sorgu = from c in nt.tbl_MakinaTurleri
                                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                where c.tur_ID == turid && c.Durum == true && c.dil_ID == 1
                                select new { c.Kategori, c.UstResim, c.FooterAciklamaSEO };
                    if (sorgu.Count() > 0)
                    {
                        foreach (var prod in sorgu)
                        {
                            lblBaslikBreadCrumb.Text = prod.Kategori;
                            lblKategoriIsmi.Text = prod.Kategori;
                            ltFooterSeo.Text = prod.FooterAciklamaSEO;
                            ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////
                            Master.Page.Title = prod.Kategori + " Liste Kategorileri | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                            Master.Page.MetaDescription = prod.Kategori + " Kategori İlanları";
                            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                            ///

                            if (prod.UstResim == "" || prod.UstResim == null)
                            {
                                imgKategori.ImageUrl = "/images/kategoriye-gore-bg.png";
                            }

                            else
                            {
                                string[] a = prod.UstResim.Split('.');
                                imgKategori.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1];
                            }

                        }

                        //Kategoriler
                        KategorileriDoldur(turid);
                        YeniEklenenleriDoldur(turid);
                        TumKategorileriDoldur(turid);
                    }
                    else
                    {
                        Response.Redirect("/404.aspx");
                    }

                }


            }


        }
        protected void KategorileriDoldur(int gelenKategori)
        {
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            string Lang = Session["Lang"].ToString();

            //Kategorileri Listeleniyoruz
            //var kategorisorgu = from c in nt.tbl_MakinaAltTurleri
            //                    where c.Durum == true & c.tur_ID==gelenKategori
            //                    orderby c.Kategori
            //                    select new { c.Kategori, c.tur_ID, c.Resim, c.Alttur_ID };

    var kategorisorgu = (from y in (
    from x in (
    from log in nt.tbl_MakinaAltTurleri
    join s in nt.tbl_Makinalar on log.Alttur_ID equals s.Alttur_ID
    where log.Durum == true && s.Durum == true && s.Yayinda == true && (s.Statu == 2 || s.Statu == 5) && s.tur_ID==gelenKategori
    group log by new { log.Kategori, log.Alttur_ID })
    select new { Kategori = x.Key.Kategori, Total = x.Count(k => k != null), x.Key.Alttur_ID, })
                                 orderby y.Total descending, y.Kategori ascending
                                 select new { y.Kategori, y.Total, y.Alttur_ID });


            rptKategoriler.DataSource = kategorisorgu.ToList();
            rptKategoriler.DataBind();
        }

        protected void rptKategoriler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                Literal Adet = (Literal)e.Item.FindControl("ltKategoriIlanAdeti");
                int altturID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Alttur_ID").ToString());
                

                //Kategorideki ilan sayısını buluyoruz.
                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = from c in nt.tbl_Makinalar
                                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                where c.Durum == true && c.Yayinda == true && c.Alttur_ID == altturID && (c.Statu == 2 || c.Statu == 5)
                                select c;

                Adet.Text = urunsorgu.Count().ToString();




                //Alt Kategorileri Doldur
                Repeater rpAlt = (Repeater)e.Item.FindControl("rptAltKategoriler");
                var kategorisorgu = from c in nt.tbl_MakinaAltTurleri2
                                    where c.Durum == true && c.Alttur_ID == altturID
                                    orderby Guid.NewGuid()
                                    select new { c.Kategori, c.Alttur_ID, c.Alttur2_ID };


                //             var kategorisorgu = (from y in (
                //from x in (
                //from log in nt.tbl_MakinaAltTurleri2
                //join s in nt.tbl_Makinalar on log.Alttur2_ID equals s.Alttur2_ID
                //where log.Durum == true && s.Durum == true && s.Yayinda == true && (s.Statu == 2 || s.Statu == 5) && s.Alttur_ID == altturID
                //group log by new { log.Kategori, log.Alttur_ID, log.Alttur2_ID })
                //select new { Kategori = x.Key.Kategori, Total = x.Count(), x.Key.Alttur_ID, x.Key.Alttur2_ID })
                //                                  orderby y.Total descending, y.Kategori ascending
                //                                  select new { y.Kategori, y.Total, y.Alttur_ID, y.Alttur2_ID });

                rpAlt.DataSource = kategorisorgu.ToList().Take(5);
                rpAlt.DataBind();


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

        protected void YeniEklenenleriDoldur(int turID)
        {
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            string Lang = Session["Lang"].ToString();

            //Ürünler Listeleniyor Seçiyoruz
            var urunsorgu = from c in nt.tbl_Makinalar
                            join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            where c.Durum == true && c.Yayinda == true && c.Statu == 2 && c.tur_ID==turID
                            orderby c.Kayit_Tarihi descending
                            select new { c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, c.Model, c.Para_Birimi, Tur = T.Kategori, Yil = Y.Kategori, Marka = M.Kategori, c.Yayinlanma_Tarihi, c.tur_ID, c.FiyatGosterilmesin, c.SEOUrl };

            rptYeniEklenenler.DataSource = urunsorgu.ToList().Take(4);
            rptYeniEklenenler.DataBind();

            if (urunsorgu.Count()>0)
            { 
                kategoriyegore.Visible= true;
                kategoriyok.Visible = false;
            }
            else
            {
                kategoriyegore.Visible = false;
                kategoriyok.Visible = true;
            }
        }

        protected void rptYeniEklenenler_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_ye." + a[1];
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

        protected void TumKategorileriDoldur(int gelenKategori)
        {
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            string Lang = Session["Lang"].ToString();

            //Kategorileri Listeleniyoruz
            var kategorisorgu = from c in nt.tbl_MakinaAltTurleri2
                                    join s in nt.tbl_MakinaAltTurleri on c.Alttur_ID equals s.Alttur_ID
                                join a in nt.tbl_MakinaTurleri on s.tur_ID equals a.tur_ID
                                where c.Durum == true & a.tur_ID == gelenKategori
                                orderby c.Kategori
                                select new { c.Kategori, c.Resim, c.Alttur_ID, c.Alttur2_ID };

            //var kategorisorgu = (from y in (
            //from x in (
            //from log in nt.tbl_MakinaAltTurleri2
            //join s in nt.tbl_Makinalar on log.Alttur_ID equals s.Alttur_ID
            //where log.Durum == true && s.Durum == true && s.Yayinda == true && (s.Statu == 2 || s.Statu == 5) && s.tur_ID == gelenKategori
            //group log by new { log.Alttur2_ID, log.Kategori })
            //select new { Kategori = x.Key.Kategori, Total = x.Count(), x.Key.Alttur2_ID, })
            //                     orderby y.Total descending, y.Kategori ascending
            //                     select new { y.Kategori, y.Total, y.Alttur2_ID });


            rptTumKategoriler.DataSource = kategorisorgu.ToList();
            rptTumKategoriler.DataBind();
        }

        protected void rptTumKategoriler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                Label Adet = (Label)e.Item.FindControl("lblToplam");
                int alttur2ID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Alttur2_ID").ToString());


                //Kategorideki ilan sayısını buluyoruz.
                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = from c in nt.tbl_Makinalar
                                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                where c.Durum == true && c.Yayinda == true && c.Alttur2_ID == alttur2ID && (c.Statu == 2 || c.Statu == 5)
                                select c;

                Adet.Text = urunsorgu.Count().ToString();
            }

        }
    }
}