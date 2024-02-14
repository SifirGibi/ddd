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
    public partial class Kategoriler : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
        
            string Lang = Session["Lang"].ToString();
            ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                        Master.Page.Title = "Kategoriler | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                        Master.Page.MetaDescription = "Tüm Kategoriler";


            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////


            if (!IsPostBack)
            {
                //Türleri Listeliyoruz
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                var Turler = from c in nt.tbl_MakinaTurleri
                             where c.dil_ID == 1 && c.Durum == true
                             orderby c.Kategori ascending
                             select c;

                ddTurler.DataSource = Turler.ToList();
                ddTurler.DataValueField = "tur_ID";
                ddTurler.DataTextField = "Kategori";
                ddTurler.DataBind();
                ddTurler.Items.Insert(0, new ListItem("Kategoriler (Tümü)", "0"));
                //ddTurler.SelectedIndex = 0;


                //Markaları Listeliyoruz
                var Markalar = from c in nt.tbl_MakinaMarkalari
                               where c.dil_ID == 1 && c.Durum == true
                               orderby c.Kategori ascending
                               select c;

                ddMarkalar.DataSource = Markalar.ToList();
                ddMarkalar.DataValueField = "marka_ID";
                ddMarkalar.DataTextField = "Kategori";
                ddMarkalar.DataBind();

                ddMarkalar.Items.Insert(0, new ListItem("Markalar (Tümü)", "0"));
                //ddMarkalar.SelectedIndex = 0;
            }


            //Kategoriler
            KategorileriDoldur();


        }
        protected void KategorileriDoldur()
        {
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            string Lang = Session["Lang"].ToString();

            //Kategorileri Listeleniyoruz
            var kategorisorgu = from c in nt.tbl_MakinaTurleri
                                where c.Durum == true
                                orderby c.Kategori
                                select new { c.Kategori, c.tur_ID, c.Resim };

            //        var kategorisorgu = (from y in (
            //from x in (
            //from log in nt.tbl_MakinaTurleri
            //join s in nt.tbl_Makinalar on log.tur_ID equals s.tur_ID
            //where log.Durum == true && s.Durum == true && s.Yayinda == true  && (s.Statu == 2 || s.Statu == 5)
            //group log by new { log.Kategori, log.Resim, log.tur_ID })
            //    select new { Kategori = x.Key.Kategori, Total = x.Count(), x.Key.tur_ID, x.Key.Resim })
            //                             orderby y.Total descending, y.Kategori ascending
            //                             select new { y.Kategori, y.Total, y.tur_ID, y.Resim  });


            rptKategoriler.DataSource = kategorisorgu.ToList();
            rptKategoriler.DataBind();
        }
        protected void rptKategoriler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                Literal Adet = (Literal)e.Item.FindControl("ltKategoriIlanAdeti");
                int turID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "tur_ID").ToString());

                string foto = "";
                foto = Convert.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Resim")) ? "" : (String)DataBinder.Eval(e.Item.DataItem, "Resim");


                //Kategorideki ilan sayısını buluyoruz.
                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = from c in nt.tbl_Makinalar
                                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                where c.Durum == true && c.Yayinda == true && c.tur_ID == turID && (c.Statu == 2 || c.Statu == 5)
                                select c;

                Adet.Text = urunsorgu.Count().ToString();

                //İmaj
                Image imgkategori = (Image)e.Item.FindControl("imgKategori");


                if (foto == "" || foto == null)
                {
                    imgkategori.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + "bos-kategori.jpg";
                }

                else
                {
                    string[] a = foto.Split('.');
                    imgkategori.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_v." + a[1];
                }


                //Alt Kategorileri Doldur
                Repeater rpAlt = (Repeater)e.Item.FindControl("rptAltKategoriler");
                var kategorisorgu = from c in nt.tbl_MakinaAltTurleri
                                    where c.Durum == true && c.tur_ID == turID
                                    orderby Guid.NewGuid()
                                    select new { c.Kategori, c.tur_ID, c.Alttur_ID };

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

        protected void btnKategoriSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/arama?keyword=" + kategori_search_input.Value);
        }
        protected void btnKategoriFiyat_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("/arama?price=yes&minprice=" + txtMinFiyat.Value+"&maxprice="+ txtMaxFiyat.Value+"&currency="+ddParaBirimi.SelectedItem.Value);
        }

        protected void btnKategoriMarkaSearch_Click(object sender, EventArgs e)
        {

            Response.Redirect("/arama?kategori=" + ddTurler.SelectedItem.Value + "&marka="+ddMarkalar.SelectedItem.Value);
        }
    }
}