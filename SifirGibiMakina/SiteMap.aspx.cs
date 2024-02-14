using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace SifirGibiMakina
{
    public partial class SiteMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sayfanın içeriğini temizliyoruz...
            Response.Clear();
            //Sayfanın xml formatında olduğunu belirliyoruz...
            Response.ContentType = "text/xml";
            //XML formatını oluşturmak için bir XmlTextWriter tanımlıyoruz ve
            //Encoding'ini UTF8 olarak ayarlıyoruz...
            XmlTextWriter objX = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
            //Bu kısımda sırayla elementlerimizi oluşturuyoruz...
            //urlset, url, loc, lastmod vs... gibi tanımlar 
            //bir standart tüm site map dosyalarında bu şekilde tanımlanırlar...
            //Kaynak : http://www.sitemaps.org/protocol.php
            objX.WriteStartDocument();
            objX.WriteStartElement("urlset");
            //Site Map standartlarını belirliyoruz...
            objX.WriteAttributeString("xmlns", "https://www.sitemaps.org/schemas/sitemap/0.9");
            objX.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");
            objX.WriteAttributeString("xsi:schemaLocation", "https://www.sitemaps.org/schemas/sitemap/0.9 https://www.sitemaps.org/schemas/sitemap/0.9/siteindex.xsd");
            //Sitenin sabit sayfalarını static olarak ekliyoruz...
            objX.WriteStartElement("url");
            //loc = Sayfa Adresi
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/anasayfa");
            //lastmod = En Son Değiştirilme tarihi
            //default.aspx Ana Sayfamız olduğu için her gün güncellendiğini varsayıyoruz
            //çünkü bu tarihler arama motorlarının sitenizin güncel olup olmadığı bilgisine karar veriyorlar...
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            //changefreq = Sayfanın ne kadar süre içerisinde oluşturulduğunu belirliyor...
            //monthly, weekly, daily ve hourly seçenekleri mevcut...
            //Şöyle bir mantığı var, daily aynı gün içinde eklendiğini belirliyor.
            //Arama motorlarıda o sayfaya ona göre önem veriyor.
            //Burada tabi o zaman hepsini daily yaparsak daha önem kazanır diye düşünmeyelim
            //Çünkü bu robotlar akıllı şeyler :) Tarihe göre ve daha önceki indekslere göre karşılaştırma yapıyorlar...
            objX.WriteElementString("changefreq", "daily");
            //priority = Sayfanın sitedeki önemini belirliyor...
            //Şöyle ki, örneğin Ana Sayfa için priority değerini 1 olarak tanımladık...
            //Ama biraz sonra aşağıda Haberleri dinamik olarak eklerken sayfanın değerini 0.1 olarak belirleyeceğiz...
            //Yani alt sayfaların değerlerini daha düşük, ana sayfaların değerlerini daha yüksek belirleyeceğiz...
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/iletisim");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/10/hakkimizda");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/1/nasil-calisir");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/2/acik-artirmaya-nasil-katilabilirim");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/3/satis-sonrasi");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/4/teknik-destek");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

           
            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/5/lojistik-teslimat");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/6/makina-eksper");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/7/iade-kosullari");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/8/insan-kaynaklari");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/9/yasal-sorumluluklar");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/giris");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/blog");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/makina-sat");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();

            objX.WriteStartElement("url");
            objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/urunler");
            objX.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            objX.WriteElementString("changefreq", "daily");
            objX.WriteElementString("priority", "1");
            objX.WriteEndElement();


            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            

            //haberler
            var haberler = from c in nt.tbl_Duyurular
                           join F in nt.tbl_Diller on c.dil_ID equals F.dil_ID
                           where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true
                           orderby c.Baslik ascending
                           select new { c.Kayit_Tarihi, c.Baslik, c.duy_ID };

            foreach (var prod in haberler)
            {
                objX.WriteStartElement("url");
                objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/"+prod.Baslik.UrlCevir()+"/" + prod.duy_ID);
                objX.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", prod.Kayit_Tarihi));
                if (prod.Kayit_Tarihi.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    objX.WriteElementString("priority", "1");
                    objX.WriteElementString("changefreq", "daily");
                }
                else
                {
                    int fark = TarihFark(prod.Kayit_Tarihi.Value, DateTime.Now);
                    if ((fark > 1) && (fark <= 7))
                    {
                        objX.WriteElementString("priority", "0.5");
                        objX.WriteElementString("changefreq", "weekly");
                    }
                    else if (fark > 7)
                    {
                        objX.WriteElementString("priority", "0.1");
                        objX.WriteElementString("changefreq", "monthly");
                    }
                }
                objX.WriteEndElement();
            }

            //Sayfalar
            var sayfalar = from c in nt.tbl_Icerikler
                           join F in nt.tbl_Diller on c.dil_ID equals F.dil_ID
                           where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true
                           orderby c.Baslik ascending
                           select new { c.Kayit_Tarihi, c.Baslik, c.icerik_ID };

            foreach (var prod in sayfalar)
            {
                objX.WriteStartElement("url");
                objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/" + prod.icerik_ID + "/" + ReWriterPath("1", prod.Baslik, "1"));
                objX.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", prod.Kayit_Tarihi));
                if (prod.Kayit_Tarihi.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    objX.WriteElementString("priority", "1");
                    objX.WriteElementString("changefreq", "daily");
                }
                else
                {
                    int fark = TarihFark(prod.Kayit_Tarihi.Value, DateTime.Now);
                    if ((fark > 1) && (fark <= 7))
                    {
                        objX.WriteElementString("priority", "0.5");
                        objX.WriteElementString("changefreq", "weekly");
                    }
                    else if (fark > 7)
                    {
                        objX.WriteElementString("priority", "0.1");
                        objX.WriteElementString("changefreq", "monthly");
                    }
                }
                objX.WriteEndElement();
            }

            //Ürünler
            var urunler = from c in nt.tbl_Makinalar
                           join F in nt.tbl_Diller on c.dil_ID equals F.dil_ID
                           where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true
                           orderby c.Baslik ascending
                           select new { c.Kayit_Tarihi, c.Baslik, c.makina_ID, c.SEOUrl };

            foreach (var prod in urunler)
            {
                objX.WriteStartElement("url");
                objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/ilan-" + prod.SEOUrl);
                objX.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", prod.Kayit_Tarihi));
                if (prod.Kayit_Tarihi.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    objX.WriteElementString("priority", "1");
                    objX.WriteElementString("changefreq", "daily");
                }
                else
                {
                    int fark = TarihFark(prod.Kayit_Tarihi.Value, DateTime.Now);
                    if ((fark > 1) && (fark <= 7))
                    {
                        objX.WriteElementString("priority", "0.5");
                        objX.WriteElementString("changefreq", "weekly");
                    }
                    else if (fark > 7)
                    {
                        objX.WriteElementString("priority", "0.1");
                        objX.WriteElementString("changefreq", "monthly");
                    }
                }
                objX.WriteEndElement();
            }

            //Markalar
            var markalar = from c in nt.tbl_MakinaMarkalari
                           join F in nt.tbl_Diller on c.dil_ID equals F.dil_ID
                           where c.Durum == true && c.dil_ID == 1 && c.Durum == true
                           orderby c.Kategori ascending
                           select new { c.Kayit_Tarihi, c.Kategori, c.marka_ID };

            foreach (var prod in markalar)
            {
                objX.WriteStartElement("url");
                objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/marka/"+ ReWriterPath("1", prod.Kategori, "1")+ "/ikinci-el-makina/" + prod.marka_ID );
                objX.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", prod.Kayit_Tarihi));
                if (prod.Kayit_Tarihi.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    objX.WriteElementString("priority", "1");
                    objX.WriteElementString("changefreq", "daily");
                }
                else
                {
                    int fark = TarihFark(prod.Kayit_Tarihi.Value, DateTime.Now);
                    if ((fark > 1) && (fark <= 7))
                    {
                        objX.WriteElementString("priority", "0.5");
                        objX.WriteElementString("changefreq", "weekly");
                    }
                    else if (fark > 7)
                    {
                        objX.WriteElementString("priority", "0.1");
                        objX.WriteElementString("changefreq", "monthly");
                    }
                }
                objX.WriteEndElement();
            }

            //Turler
            var turler = from c in nt.tbl_MakinaTurleri
                           join F in nt.tbl_Diller on c.dil_ID equals F.dil_ID
                           where c.Durum == true && c.dil_ID == 1 && c.Durum == true
                           orderby c.Kategori ascending
                           select new { c.Kayit_Tarihi, c.Kategori, c.tur_ID };

            foreach (var prod in turler)
            {
                objX.WriteStartElement("url");
                objX.WriteElementString("loc", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/kategori/" + ReWriterPath("1", prod.Kategori, "1") + "/ikinci-el-makina/" + prod.tur_ID);
                objX.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", prod.Kayit_Tarihi));
                if (prod.Kayit_Tarihi.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    objX.WriteElementString("priority", "1");
                    objX.WriteElementString("changefreq", "daily");
                }
                else
                {
                    int fark = TarihFark(prod.Kayit_Tarihi.Value, DateTime.Now);
                    if ((fark > 1) && (fark <= 7))
                    {
                        objX.WriteElementString("priority", "0.5");
                        objX.WriteElementString("changefreq", "weekly");
                    }
                    else if (fark > 7)
                    {
                        objX.WriteElementString("priority", "0.1");
                        objX.WriteElementString("changefreq", "monthly");
                    }
                }
                objX.WriteEndElement();
            }



            objX.WriteEndDocument();
            objX.Flush();
            objX.Close();
            Response.End();
        }

        public int TarihFark(DateTime tr1, DateTime tr2)
        {
            TimeSpan Sonuc;
            Sonuc = (tr2 - tr1);
            return (Sonuc.Days);
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