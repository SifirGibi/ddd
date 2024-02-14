using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class Detay : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Code"] != null)
                {
                    int urunid = 0;
                    string Code = Request.QueryString["Code"].ToString();

                    ///////////////////////////////////////İçerikler alınıyor//////////////////////////////////////
                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                    var sorgu = from c in nt.tbl_Makinalar
                                join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                where c.QRCode == Code && c.Durum==true && c.dil_ID == 1 && c.Yayinda == true
                                select new { c.Aciklama, c.Baslik, c.Para_Birimi, c.SeoKeywords, c.SeoDescription,c.SosyalMedyaPaylasim, c.Fotograf, Marka= M.Kategori, c.Model, Yil= Y.Kategori, c.Fiyat, Tur= T.Kategori, c.Ihale, c.Satis_Temsilcisi_Adi, c.Satis_Temsilcisi_Email, c.Satis_Temsilcisi_Telefon, c.makina_ID, c.Ihale_Baslangic, c.Ihale_Bitis, c.Kapora, c.KM, c.FiyatGosterilmesin, c.SEOUrl };
                    foreach (var prod in sorgu)
                    {
                        lblBaslik.Text = prod.Baslik;
                        lblYil1.Text = prod.Yil.ToString();
                        lblMarka1.Text = prod.Marka;
                        lblModel1.Text = prod.Model;
                        lblTur1.Text = prod.Tur;
                        lblCalismaSaati.Text = prod.KM;
                        ltAciklama.Text = prod.Aciklama;
                       
                        urunid = prod.makina_ID;

                        //Resimleri Goster
                        var images = from c in nt.tbl_MakinaResimler
                                     where c.Durum == true && c.makina_ID == prod.makina_ID && c.Vitrin==true
                                     select c;
                        foreach (var prods in images)
                        {
                            ltResim.Text = "<img src=" + WebConfigurationManager.AppSettings["imagePath"] + "/" + prods.Fotograf + " class=img-responsive>";
                        }

                            ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                            Master.Page.Title = prod.Baslik + " | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                        Master.Page.MetaDescription = prod.SeoDescription.ToString();
                        Master.Page.MetaKeywords = prod.SeoKeywords.ToString();

                        /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

                    }

                    //Eksper Bilgisi
                    var Eksper = from c in nt.tbl_MakinaEksperSecimi
                                 join D in nt.tbl_MakinaEksper on c.eksper_ID equals D.eksper_ID
                                where c.makina_ID == urunid && c.Note>0
                                select new { D.Kategori, c.Note };
                    rptEksper.DataSource = Eksper.ToList();
                    rptEksper.DataBind();

                    //İşlem Bilgisi
                    var Islemler = from c in nt.tbl_MakinaIslemler
                                   where c.makina_ID == urunid && c.Durum == true
                                   orderby c.Tarih descending
                                   select new { c.Islemi_Yapan_Firma, c.Islemi_Yapan_Muhendis, c.Aciklama, c.Tarih, c.islem_ID };
                    

                    grdIslemler.DataSource = Islemler.ToList();
                    grdIslemler.DataBind();

                    //Ürünler
                    UrunleriDoldur();
                }

            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0}", ex));
            }
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
                    Prosess.Text = "<div class=\"progress\"><div class=\"progress-bar progress-bar-danger progress-bar-striped\" role=\"progressbar\" aria-valuenow=" + Note.ToString() +"0 aria-valuemin='0' aria-valuemax='100' style='width:"+Note.ToString()+0+"%'>"+Note.ToString()+ "</div></div>";
                }
                else if (Note >= 4 && Note <= 6)
                {
                    Smiley.Text = "&#128528;";
                    Prosess.Text = "<div class=\"progress\"><div class=\"progress-bar progress-bar-warning progress-bar-striped\" role=\"progressbar\" aria-valuenow=" + Note.ToString() + "0 aria-valuemin='0' aria-valuemax='100' style='width:" + Note.ToString() + 0 + "%'>" + Note.ToString() + "</div></div>";

                }
                else if (Note >= 7 && Note <= 9)
                {
                    Smiley.Text = "&#128578;";
                    Prosess.Text = "<div class=\"progress\"><div class=\"progress-bar progress-bar-info progress-bar-striped\" role=\"progressbar\" aria-valuenow=" + Note.ToString() + "0 aria-valuemin='0' aria-valuemax='100' style='width:" + Note.ToString() + 0 + "%'>" + Note.ToString() + "</div></div>";

                }
                else if (Note >= 10)
                {
                    Smiley.Text = "&#128521;";
                    Prosess.Text = "<div class=\"progress\"><div class=\"progress-bar progress-bar-success progress-bar-striped\" role=\"progressbar\" aria-valuenow=" + Note.ToString() + "0 aria-valuemin='0' aria-valuemax='100' style='width:" + Note.ToString() + 0 + "%'>" + Note.ToString() + "</div></div>";

                }

            }

        }

        protected void grdIslemler_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Sıra Numarası Ekleme
                (e.Row.FindControl("lblSira") as Label).Text = (e.Row.RowIndex + 1 + (grdIslemler.PageIndex * 150)).ToString() + ".";
                //Sıra Numarası Ekleme

            

                //Açıklama
                Literal aciklamalt = (Literal)e.Row.FindControl("ltAciklama");
                string aciklama = DataBinder.Eval(e.Row.DataItem, "Aciklama").ToString();

                aciklamalt.Text = aciklama;

            }
        }

        protected void UrunleriDoldur()
        {
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();


            //Ürünler Listeleniyor Seçiyoruz
            var urunsorgu = from c in nt.tbl_Makinalar
                            join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            where c.Durum == true && c.Yayinda == true && c.Vitrin == true && c.Statu == 2
                            orderby c.Kayit_Tarihi descending
                            select new { c.Baslik, c.Fotograf, c.makina_ID, c.Kayit_Tarihi, c.Fiyat, c.KM, c.Makina_Order, c.Model, c.Para_Birimi, Tur = T.Kategori, Yil = Y.Kategori, Marka = M.Kategori, c.SEOUrl };

            rptUrunler.DataSource = urunsorgu.ToList().Take(3);
            rptUrunler.DataBind();
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
                string foto = "";
                foto = Convert.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Fotograf")) ? "" : (String)DataBinder.Eval(e.Item.DataItem, "Fotograf");
                Image imgresim = (Image)e.Item.FindControl("imgUrun");

                if (string.IsNullOrEmpty(foto) == true)
                {
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + "ornekfoto.jpg";
                }
                else
                {
                    string[] a = foto.Split('.');
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1];

                }

                
            }

        }


    }
}