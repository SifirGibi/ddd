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
    public partial class Ihale : System.Web.UI.Page
    {
        DateTime baslangic;
        DateTime bitis;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (RouteData.Values["urunihaleid"] != null)
                {

                    //Kullanıcı Giriş yapmadıysa
                    if (Session["Giris"] != null)
                    {
                        int urunid = Convert.ToInt32(RouteData.Values["urunihaleid"].ToString());
                        string Lang = Session["Lang"].ToString();


                        int uyeid = Convert.ToInt32(Session["uye_ID"].ToString());
                        db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                        string isaret = "";


                        ///////////////////////////////////////İçerikler alınıyor//////////////////////////////////////
                        var sorgu = from c in nt.tbl_Makinalar
                                    join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                    join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                    join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                    join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                    where c.makina_ID == urunid && c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && c.Statu == 2
                                    select new { c.Aciklama, c.Baslik, c.Para_Birimi, c.SeoKeywords, c.SeoDescription, c.SosyalMedyaPaylasim, c.Fotograf, Marka = M.Kategori, c.Model, Yil = Y.Kategori, c.Fiyat, Tur = T.Kategori, c.Ihale, c.Satis_Temsilcisi_Adi, c.Satis_Temsilcisi_Email, c.Satis_Temsilcisi_Telefon, c.makina_ID, c.Ihale_Baslangic, c.Ihale_Bitis, c.Kapora, c.Ihale_Acilis_Fiyat, c.il, c.ilce, c.IlanNo };

                        //Ürün Varsa İşlem Yap
                        if (sorgu.Count() > 0)
                        { 
                            foreach (var prod in sorgu)
                        {
                            lblBaslik.Text = prod.Baslik;
                            lblilanNo.Text = prod.IlanNo.ToString();
                            lblYil.Text = prod.Yil.ToString();
                            lblMarka.Text = prod.Marka;
                            lblModel.Text = prod.Model;
                            if (prod.ilce != "") { isaret = " / "; }
                            lblil.Text = prod.il + isaret + prod.ilce;
                            ltFiyat.Text = prod.Fiyat.ToString();
                            ltResim.Text = "<img src=" + WebConfigurationManager.AppSettings["imagePath"] + "/" + prod.Fotograf + " class=img-fluid>";
                            //Para Birimi
                            string parabirimi = prod.Para_Birimi.ToString();
                            if (parabirimi == "1" && (prod.Fiyat.ToString() == "" || prod.Fiyat.ToString() == "0"))
                            {
                                ltParaBirimi.Text = "&#8378";
                            }
                            else if (parabirimi == "2" && (prod.Fiyat.ToString() == "" || prod.Fiyat.ToString() == "0"))
                            {
                                ltParaBirimi.Text = "&euro;";
                            }
                            else if (parabirimi == "3" && (prod.Fiyat.ToString() == "" || prod.Fiyat.ToString() == "0"))
                            {
                                ltParaBirimi.Text = "$";
                            }

                            //İhale
                            if (prod.Ihale == true)
                            {
                                lblBaslangic.Text = prod.Ihale_Baslangic.Value.ToString();
                                lblBitis.Text = prod.Ihale_Bitis.Value.ToString();

                                //Gün Hesaplama
                                DateTime baslangictarihi = DateTime.Now;
                                DateTime bitistarihi = Convert.ToDateTime(prod.Ihale_Baslangic);
                                TimeSpan arasindakigunler = bitistarihi - baslangictarihi;
                                double days = arasindakigunler.Days;
                                double hours = arasindakigunler.Hours;
                                double minutes = arasindakigunler.Minutes;
                                double seconds = arasindakigunler.Seconds;
                                lblIhaleGun.Text = days.ToString();
                                lblIhaleSaat.Text = hours.ToString();
                                lblIhaleDakika.Text = minutes.ToString();
                                lblIhaleSaniye.Text = seconds.ToString();

                                //Başlangıç ve Bitiş Tarihine Göre Butonları Kapatıyoruz
                                if (prod.Ihale_Baslangic < DateTime.Now && prod.Ihale_Bitis < DateTime.Now)
                                {
                                    ltIhale.Text = "<span><i class='fa fa-flag-checkered'></i></span> Bitti";
                                    btn250.Visible = false;
                                    btn500.Visible = false;
                                    btn1000.Visible = false;
                                    lblSonuc.Text = "İhale tamamlanmıştır.";
                                    lblSonuc.CssClass = "text-center alert-danger";
                                    ihalesaati.Visible = false;
                                    live.Visible = false;
                                }
                                else if (prod.Ihale_Baslangic > DateTime.Now && prod.Ihale_Bitis > DateTime.Now)
                                {
                                    ltIhale.Text = "<span><i class='fa fa-exclamation-circle'></i></span> Henüz Başlamadı";
                                    btn250.Visible = false;
                                    btn500.Visible = false;
                                    btn1000.Visible = false;
                                    live.Visible = false;
                                    lblSonuc.Text = "İhale henüz başlamamıştır.";
                                    lblSonuc.CssClass = "text-center alert-warning";
                                }
                                else if (prod.Ihale_Baslangic < DateTime.Now && prod.Ihale_Bitis > DateTime.Now)
                                {
                                    ltIhale.Text = "<span><i class='fa fa-check'></i></span> Aktif";
                                    btn250.Visible = true;
                                    btn500.Visible = true;
                                    btn1000.Visible = true;
                                    lblSonuc.Text = "İhale devam etmektedir.";
                                    lblSonuc.CssClass = "text-center alert-success";
                                    ihalesaati.Visible = false;
                                }

                                if (parabirimi == "1")
                                {
                                    btn250.Text = "250 ₺ Artır";
                                    btn500.Text = "500 ₺ Artır";
                                    btn1000.Text = "1000 ₺ Artır";
                                    lblBaslangicMiktari.Text = prod.Ihale_Acilis_Fiyat + " &#8378";
                                }
                                else if (parabirimi == "2")
                                {
                                    btn250.Text = "250 € Artır";
                                    btn500.Text = "500 € Artır";
                                    btn1000.Text = "1000 € Artır";
                                    lblBaslangicMiktari.Text = prod.Ihale_Acilis_Fiyat + " &euro;";
                                }
                                else if (parabirimi == "3")
                                {
                                    btn250.Text = "250  $ Artır";
                                    btn500.Text = "500 $ Artır";
                                    btn1000.Text = "1000 $ Artır";
                                    lblBaslangicMiktari.Text = prod.Ihale_Acilis_Fiyat + " $";
                                }

                                pnlIhale.Visible = true;

                                //Üye İhaleye Katılmaya Uygun mu?
                                var Sorgu = from c in nt.tbl_MakinaIhale
                                            where c.makina_ID == urunid && c.uye_ID == uyeid
                                            select c;
                                if (Sorgu.Count() > 0)
                                {
                                    pnlIhaleKatilim.Visible = true;
                                    lblKatilabilir.Text = "Ödemeniz alınmıştır. İhaleye katılabilirsiniz.";
                                    lblKatilabilir.CssClass = "text-success";

                                }
                                else
                                {
                                    pnlIhaleKatilim.Visible = true;
                                    lblKatilabilir.Text = "İhaleye katılabilmeniz için teminat bedelini yatırmanız gerekmektedir. Gerekli açıklamaya <a href=/sayfalar/2/acik-artirmaya-nasil-katilabilirim>Nasıl katılabilirim</a> sayfasından ulaşabilirsiniz. Ödemenizi yaptıktan sonra profil kısmından <strong><a href=/odeme-bildirimi class=\"btn btn-success\" style=\"width:300px\">Ödeme Bildirimi</a></strong>'nde bulunabilir ve ihaleye katılabilirsiniz.";
                                    lblKatilabilir.CssClass = "text-danger";
                                    btn250.Visible = false;
                                    btn500.Visible = false;
                                    btn1000.Visible = false;
                                }

                                int makinaID = prod.makina_ID;
                                //Verilen Teklifler
                                    var ihaleler = from c in nt.tbl_Ihale
                                                   join M in nt.tbl_Makinalar on c.makina_ID equals M.makina_ID
                                                   join U in nt.tbl_Uyeler on c.uye_ID equals U.uye_ID
                                                   where c.makina_ID== makinaID
                                                   orderby c.Kayit_Tarihi descending
                                                   select new
                                                   {
                                                       c.ihale_ID,
                                                       c.makina_ID,
                                                       c.uye_ID,
                                                       c.Verilen_Fiyat,
                                                       UyeAd = "Üye-"+ U.Adi.Substring(0,1) + "." + U.Soyadi.Substring(0,1)+"." + c.uye_ID,
                                                       Makina = M.Baslik,
                                                       c.Durum,
                                                       c.Kayit_Tarihi,
                                                       c.SonFiyat,
                                                       M.Para_Birimi,
                                                       M.Minimum_Satis_Fiyati,
                                                   };

                                    grdIhale.DataSource = ihaleler.ToList();
                                    grdIhale.DataBind();

                            }
 


                            ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                            Master.Page.Title = "İhale | " + prod.Baslik + " | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                            Master.Page.MetaDescription = prod.SeoDescription.ToString();
                            Master.Page.MetaKeywords = prod.SeoKeywords.ToString();

                            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

                        }
                        }
                        else
                        {
                            Response.Redirect("/404.aspx");
                        }

                    }
                    else
                    {
                        ihaledetay.Visible = false;
                        pnlError.Visible = true;
                        lblHataMesaji.Text = "İhaleye katılabilmeniz ve teminat bedelini yatırabilmeniz için üye olmanız gerekmektedir. Hesabınıza <a href=/giris/>buradan</a> giriş yapabilir veya yeni üyelik oluşturabilirsiniz.";
                        lblHata.Text = Dil.Res.Hata;
                        
                    }
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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            int makinaID = Convert.ToInt32(RouteData.Values["urunihaleid"].ToString());
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            //Verilen Teklifler
            var ihaleler = from c in nt.tbl_Ihale
                           join M in nt.tbl_Makinalar on c.makina_ID equals M.makina_ID
                           join U in nt.tbl_Uyeler on c.uye_ID equals U.uye_ID
                           where c.makina_ID == makinaID
                           orderby c.Kayit_Tarihi descending
                           select new
                           {
                               c.ihale_ID,
                               c.makina_ID,
                               c.uye_ID,
                               c.Verilen_Fiyat,
                               UyeAd = "Üye-" + U.Adi.Substring(0, 1) + "." + U.Soyadi.Substring(0, 1) + "." + c.uye_ID,
                               Makina = M.Baslik,
                               c.Durum,
                               c.Kayit_Tarihi,
                               c.SonFiyat,
                               M.Para_Birimi,

                           };

            grdIhale.DataSource = ihaleler.ToList();
            grdIhale.DataBind();

        }
        protected void btn250_Click(object sender, EventArgs e)
        {

            int urunid = Convert.ToInt32(RouteData.Values["urunihaleid"].ToString());
            int uyeid = Convert.ToInt32(Session["uye_ID"].ToString());
            
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();

            //Şu ana kadar verilen tekliflerin toplamı
            var total = nt.tbl_Ihale.Where(t => t.makina_ID == urunid).Sum(i => i.Verilen_Fiyat);

            if (total==null)
            {
                total = 0;
            }
            //Ekleme Komutu
            decimal acilisfiyati = 0;
            var sorgu = from c in nt.tbl_Makinalar
                        where c.makina_ID == urunid
                        select new { c.Ihale_Acilis_Fiyat, c.Ihale_Baslangic, c.Ihale_Bitis };
            foreach (var prod in sorgu)
            {
                acilisfiyati = Convert.ToDecimal(prod.Ihale_Acilis_Fiyat);
                baslangic = Convert.ToDateTime(prod.Ihale_Baslangic);
                bitis = Convert.ToDateTime(prod.Ihale_Bitis);
            }

            if (baslangic < DateTime.Now && bitis > DateTime.Now)
            {
                tbl_Ihale ihaleekle = new tbl_Ihale();
                ihaleekle.makina_ID = urunid;
                ihaleekle.uye_ID = uyeid;
                ihaleekle.Verilen_Fiyat = 250;
                ihaleekle.SonFiyat = 250 + acilisfiyati + total;
                ihaleekle.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                ihaleekle.Kayit_Tarihi = DateTime.Now;
                ihaleekle.Durum = true;
                nt.tbl_Ihale.Add(ihaleekle);
                nt.SaveChanges();
            }
            else
            {
                lblBitti.Text = "İhale bitmiştir. Artık bu makinaya teklif veremezsiniz.";
            }

            

        }
        protected void btn500_Click(object sender, EventArgs e)
        {

            int urunid = Convert.ToInt32(RouteData.Values["urunihaleid"].ToString());
            int uyeid = Convert.ToInt32(Session["uye_ID"].ToString());
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();

            //Şu ana kadar verilen tekliflerin toplamı
            var total = nt.tbl_Ihale.Where(t => t.makina_ID == urunid).Sum(i => i.Verilen_Fiyat);

            if (total == null)
            {
                total = 0;
            }
            //Ekleme Komutu
            decimal acilisfiyati = 0;
            var sorgu = from c in nt.tbl_Makinalar
                        where c.makina_ID == urunid
                        select new { c.Ihale_Acilis_Fiyat, c.Ihale_Baslangic, c.Ihale_Bitis };
            foreach (var prod in sorgu)
            {
                acilisfiyati = Convert.ToDecimal(prod.Ihale_Acilis_Fiyat);
                baslangic = Convert.ToDateTime(prod.Ihale_Baslangic);
                bitis = Convert.ToDateTime(prod.Ihale_Bitis);
            }
            if (baslangic < DateTime.Now && bitis > DateTime.Now)
            {
            tbl_Ihale ihaleekle = new tbl_Ihale();
            ihaleekle.makina_ID = urunid;
            ihaleekle.uye_ID = uyeid;
            ihaleekle.Verilen_Fiyat = 500;
            ihaleekle.SonFiyat = 500 + acilisfiyati + total;
            ihaleekle.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
            ihaleekle.Kayit_Tarihi = DateTime.Now;
            ihaleekle.Durum = true;
            nt.tbl_Ihale.Add(ihaleekle);
            nt.SaveChanges();
            }
            else
            {
                lblBitti.Text = "İhale bitmiştir. Artık bu makinaya teklif veremezsiniz.";
            }
        }
        protected void btn1000_Click(object sender, EventArgs e)
        {

            int urunid = Convert.ToInt32(RouteData.Values["urunihaleid"].ToString());
            int uyeid = Convert.ToInt32(Session["uye_ID"].ToString());
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();

            //Şu ana kadar verilen tekliflerin toplamı
            var total = nt.tbl_Ihale.Where(t => t.makina_ID == urunid).Sum(i => i.Verilen_Fiyat);

            if (total == null)
            {
                total = 0;
            }
            //Ekleme Komutu
            decimal acilisfiyati = 0;
            var sorgu = from c in nt.tbl_Makinalar
                        where c.makina_ID == urunid
                        select new { c.Ihale_Acilis_Fiyat, c.Ihale_Baslangic, c.Ihale_Bitis };
            foreach (var prod in sorgu)
            {
                acilisfiyati = Convert.ToDecimal(prod.Ihale_Acilis_Fiyat);
                baslangic = Convert.ToDateTime(prod.Ihale_Baslangic);
                bitis = Convert.ToDateTime(prod.Ihale_Bitis);
            }
            if (baslangic < DateTime.Now && bitis > DateTime.Now)
            {
                tbl_Ihale ihaleekle = new tbl_Ihale();
                ihaleekle.makina_ID = urunid;
                ihaleekle.uye_ID = uyeid;
                ihaleekle.Verilen_Fiyat = 1000;
                ihaleekle.SonFiyat = 1000 + acilisfiyati + total;
                ihaleekle.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                ihaleekle.Kayit_Tarihi = DateTime.Now;
                ihaleekle.Durum = true;
                nt.tbl_Ihale.Add(ihaleekle);
                nt.SaveChanges();
            }
            else
            {
                lblBitti.Text = "İhale bitmiştir. Artık bu makinaya teklif veremezsiniz.";
            }

        }
        protected void grdIhale_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Son Fiyat Bilgisi
                Literal sonteklif = (Literal)e.Row.FindControl("ltSonTeklif");
                Literal verilenfiyat = (Literal)e.Row.FindControl("ltVerilenFiyat");

                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                string parabirimi = DataBinder.Eval(e.Row.DataItem, "Para_Birimi").ToString();
                string sonteklifverisi = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SonFiyat")).ToString("N2");
                string verilenfiyatverisi = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Verilen_Fiyat")).ToString("N2");

                //Teklif Veren Aynı Kişi Mi?
                Literal sizsiniz = (Literal)e.Row.FindControl("ltSiz");
                string sizmisiniz = DataBinder.Eval(e.Row.DataItem, "uye_ID").ToString();
                string uyeid = Session["uye_ID"].ToString();

                if (sizmisiniz == uyeid)
                {
                    sizsiniz.Text = "<img src=/images/check.png>";
                }
                else
                {
                    sizsiniz.Text = "<img src=/images/uncheck.png>";
                }

                

                //Para Birimi
                if (parabirimi == "1")
                {
                    sonteklif.Text = sonteklifverisi + " &#8378";
                    verilenfiyat.Text = verilenfiyatverisi + " &#8378";
                }
                else if (parabirimi == "2")
                {
                    sonteklif.Text = sonteklifverisi + " &euro;";
                    verilenfiyat.Text = verilenfiyatverisi + " &euro;";
                }
                else if (parabirimi == "3")
                {
                    sonteklif.Text = sonteklifverisi + " $";
                    verilenfiyat.Text = verilenfiyatverisi + " $";
                }


            }
        }

    }
}