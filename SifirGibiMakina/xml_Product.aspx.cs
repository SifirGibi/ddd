using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;

namespace SifirGibiMakina
{
    public partial class xml_Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["security_key"] == "Segmentify")
            { 
                Response.Clear();
                Response.ContentType = "text/xml";
                XmlTextWriter objX = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
                objX.WriteStartDocument();
                objX.WriteStartElement("rss");
                objX.WriteAttributeString("version", "2.0");
                objX.WriteStartElement("channel");
                objX.WriteElementString("title", ConfigurationManager.AppSettings["MikroSiteAdi"].ToString());
                objX.WriteElementString("link", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/xml_Product.aspx");
                objX.WriteElementString("description", ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + " - Product");
                objX.WriteElementString("language", "tr");

                //Ürünler
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                var urunsorgu = from c in nt.tbl_Makinalar
                                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                join R in nt.tbl_MakinaResimler on c.makina_ID equals R.makina_ID
                                where c.Durum == true && c.dil_ID == 1 && R.Durum == true && R.Vitrin == true
                                orderby c.Kayit_Tarihi descending
                                select new { c.Aciklama, c.Baslik, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, Yil = Y.Kategori, Tur = T.Kategori, Marka = M.Kategori, c.Model, c.Para_Birimi, c.Ihale, c.Statu, c.StokGelis_Tarihi, c.IlanNo, c.Yayinlanma_Tarihi, c.FiyatGosterilmesin, R.Fotograf, c.Yayinda, c.SEOUrl };


                foreach (var prod in urunsorgu)
                {
                    objX.WriteStartElement("item");
                    objX.WriteElementString("id", prod.IlanNo.ToString());
                    objX.WriteElementString("title", prod.Baslik);
                    objX.WriteElementString("description", prod.Aciklama);
                    objX.WriteElementString("product_type", prod.Tur);
                    objX.WriteElementString("product_year", prod.Yil.ToString());
                    objX.WriteElementString("product_model", prod.Model);
                    objX.WriteElementString("link", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/ilan-" + prod.SEOUrl);
                    objX.WriteElementString("image_link", "https://sifirgibimakine.com/admin/Uploads/" + prod.Fotograf);
                    objX.WriteElementString("condition", prod.Yayinda.ToString());
                    if (prod.Statu == 1){ objX.WriteElementString("availability", "İnceleniyor"); }
                    else if (prod.Statu == 2){ objX.WriteElementString("availability", "Satışta"); }
                    else if (prod.Statu == 3){ objX.WriteElementString("availability", "Kapalı"); }
                    else if (prod.Statu == 4){ objX.WriteElementString("availability", "Satıldı"); }
                    else if (prod.Statu == 5){ objX.WriteElementString("availability", "Yakında Stokta"); }
                    else if (prod.Statu == 6){ objX.WriteElementString("availability", "Süresi Doldu"); }
                    else if (prod.Statu == 7){ objX.WriteElementString("availability", "Kullanıcı Tarafından Yayından Kaldırıldı"); }
                    else if (prod.Statu == 8){ objX.WriteElementString("availability", "Değişiklik Onayı Bekleniyor"); }
                    else{ objX.WriteElementString("availability", ""); }
                    objX.WriteElementString("identifier_exists", "no");
                    objX.WriteElementString("brand", prod.Marka);
                    if (prod.Para_Birimi == 1 && prod.Fiyat != 0){objX.WriteElementString("price", prod.Fiyat + " TRY");}
                    else if (prod.Para_Birimi == 2 && prod.Fiyat != 0){objX.WriteElementString("price", prod.Fiyat + " €");}
                    else if (prod.Para_Birimi == 3 && prod.Fiyat != 0){objX.WriteElementString("price", prod.Fiyat + " $");}
                    else if (prod.Fiyat == 0) { objX.WriteElementString("price", prod.Fiyat.ToString()); }
                    if (prod.Para_Birimi == 1 && prod.Fiyat != 0) { objX.WriteElementString("sale_price", prod.Fiyat + " TRY"); }
                    else if (prod.Para_Birimi == 2 && prod.Fiyat != 0) { objX.WriteElementString("sale_price", prod.Fiyat + " €"); }
                    else if (prod.Para_Birimi == 3 && prod.Fiyat != 0) { objX.WriteElementString("sale_price", prod.Fiyat + " $"); }
                    else if (prod.Fiyat == 0) { objX.WriteElementString("sale_price", prod.Fiyat.ToString()); }
                    objX.WriteEndElement();
               
                }

           

                objX.WriteEndElement();
                objX.WriteEndElement();
                objX.WriteEndDocument();
                objX.Flush();
                objX.Close();
                Response.End();
        }
        }
    }
}