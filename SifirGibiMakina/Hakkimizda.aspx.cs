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
    public partial class Hakkimizda1 : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
        
                    int pageid = 14;
                    string Lang = Session["Lang"].ToString();
                    ///////////////////////////////////////İçerikler alınıyor//////////////////////////////////////
                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                    var sorgu = from c in nt.tbl_Icerikler
                                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                where c.icerik_ID == pageid && c.Durum==true && c.dil_ID==1 && c.Yayinda == true
                                select new { c.Aciklama, c.Baslik, c.SeoKeywords, c.SeoDescription,c.SosyalMedyaPaylasim, c.Resim};
                    foreach (var prod in sorgu)
                    {
                        if (prod.Resim == "NULL" || prod.Resim =="" || prod.Resim == null)
                        {
                            imgIcerik.Visible = false;
                        }
                        else
                        {
                            imgIcerik.Visible = true;
                            imgIcerik.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + prod.Resim;
                        }

                rptAciklama.DataSource = sorgu.ToList().Take(1);
                rptAciklama.DataBind();

                ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                Master.Page.Title = prod.Baslik + " | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                        Master.Page.MetaDescription = prod.SeoDescription.ToString();
                        Master.Page.MetaKeywords = prod.SeoKeywords.ToString();

                        /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

                        ///////////////////////////////////////Paylaşım Bilgileri//////////////////////////////////////

                        if(prod.SosyalMedyaPaylasim==true)
                        {
                            socialmediashare.Visible = true;
                        }

                        /////////////////////////////////////////Paylaşım Bilgileri/////////////////////////////////////



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

                        }
                        if (sayipaneli == 1)
                        {
                            pnlSayilar.Visible = true;
                        }

                        //Üye Sayısı
                        var MTUyeler = (from c in nt.tbl_Uyeler
                                        where c.Durum == true && c.Aktif == true
                                        select c).Count();
                        lblUyeSayisi.Text = (MTUyeler + ekuyesayisi).ToString();

                        //Satılan Sayısı
                        var MTMakinalar = (from c in nt.tbl_Makinalar
                                           where c.Durum == true && c.Statu == 4
                                           select c).Count();
                        lblSatilanMakina.Text = (MTMakinalar + eksatilanmakinasayisi).ToString();

                        //Verilen Teklif Sayısı
                        var MTTeklifler = (from c in nt.tbl_Ihale
                                           select c).Count();
                        lblAcikArtirmaTeklif.Text = (MTTeklifler + ekverilenteklifsayisi).ToString();

                        //Ihaleye Katılan Kişi Sayısı
                        var MTKatilanKKisi = (from c in nt.tbl_Ihale
                                              select new { c.uye_ID }).Distinct().Count();
                        lblAcikArtirmaUye.Text = (MTKatilanKKisi + ekkatilankisisayisi).ToString();
                        /////////////////////////////////////////Sayı Bilgileri/////////////////////////////////////

                    }
        }

    }
}