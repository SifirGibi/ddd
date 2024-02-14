﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;

namespace SifirGibiMakina
{
    public partial class MesajGonder : System.Web.UI.Page
    {
        int urunid;
        Mailler BenimMailim;
        private string mailaciklama = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (RouteData.Values["ilanid"] != null)
                {
                    urunid = Convert.ToInt32(RouteData.Values["ilanid"].ToString());
                    string Lang = Session["Lang"].ToString();

                    /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                    Master.Page.Title = "Mesaj Gonder | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                    Master.Page.MetaDescription = "";
                    Master.Page.MetaKeywords = "";
                    /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                    ///
                    if (Session["Giris"] != null)
                    {

                        
                        db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                        int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());

                        ////////////////////// OKUNMAMIŞ MESAJ SAYISINI BULUYORUZ /////////////////////////////
                        var OkunmamisMesajSayisi = (from c in nt.tbl_ilanMesajlari
                                                    where c.Durum == true && c.Kime == uyeID && c.Okunma == 0
                                                    select c).ToList();

      

                        //////////////////////// DAHA ÖNCEKİ YAZIŞMALAR //////////////////////////
                        var ilanmesajlar = from c in nt.tbl_ilanMesajlari
                                           join KU in nt.tbl_Uyeler on c.Kimden equals KU.uye_ID
                                           where c.Durum == true && c.makina_ID== urunid && (c.Kimden == uyeID)
                                           orderby c.Kayit_Tarihi ascending
                                           select new
                                           {
                                              c.Kayit_Tarihi,
                                              KimdenAdiSoyadi = KU.Adi + " " + KU.Soyadi,
                                              c.Mesaj,
                                              c.Kimden,
                                           };
                        rtMesajlar.DataSource=ilanmesajlar.ToList();
                        rtMesajlar.DataBind();
                        //////////////////////// DAHA ÖNCEKİ YAZIŞMALAR //////////////////////////
                        
                        
                        //İlan Bilgileri
                        string isaret = "";
                        var sorgu = from c in nt.tbl_Makinalar
                                    join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                    join M in nt.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                    join T in nt.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                    join Y in nt.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                    where c.makina_ID == urunid && c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && (c.Statu == 2 || c.Statu == 4 || c.Statu == 5)
                                    select new { c.Aciklama, c.Baslik, c.Para_Birimi, c.SeoKeywords, c.SeoDescription, c.SosyalMedyaPaylasim, c.Fotograf, Marka = M.Kategori, c.Model, Yil = Y.Kategori, c.Fiyat, Tur = T.Kategori, c.Ihale, c.Satis_Temsilcisi_Adi, c.Satis_Temsilcisi_Email, c.Satis_Temsilcisi_Telefon, c.makina_ID, c.Ihale_Baslangic, c.Ihale_Bitis, c.Kapora, c.KM, c.Statu, c.il, c.ilce, c.GoruntulenmeSayisi, c.IlanNo, c.FavoriSayisi, c.Kimden };
                        foreach (var prod in sorgu)
                        {

                            lblBaslik.Text = prod.Baslik;
                            lblilanNo.Text = "<strong>İlan No:</strong>" + prod.IlanNo.ToString();
                            if (prod.ilce != "") { isaret = " / "; }
                            lblil.Text = prod.il + isaret + prod.ilce;
                            ltFiyat.Text = prod.Fiyat.ToString();
                            //Ana Resim
                            var urunresimsorgu = from c in nt.tbl_MakinaResimler
                                                 where c.Durum == true && c.makina_ID == urunid && c.Vitrin == true
                                                 select c;

                            foreach (var prods in urunresimsorgu)
                            {
                                string[] a = prods.Fotograf.Split('.');
                                ltResim.Text = "<img src=" + WebConfigurationManager.AppSettings["imagePath"] + "/" + a[0] + "_v." + a[1] + " class=img-fluid alt=\"" + prod.Baslik + "\" > ";
                            }

                            if (urunresimsorgu.Count() == 0)
                            {
                                ltResim.Text = "<img src=" + WebConfigurationManager.AppSettings["imagePath"] + "/ornekfoto.jpg class=img-fluid alt=\"" + prod.Baslik + "\" > ";

                            }
                            //Para Birimi
                            string parabirimi = prod.Para_Birimi.ToString();
                            if (parabirimi == "1" && prod.Fiyat.ToString() != "")
                            {
                                ltParaBirimi.Text = "&#8378";
                            }
                            else if (parabirimi == "2" && prod.Fiyat.ToString() != "")
                            {
                                ltParaBirimi.Text = "&euro;";
                            }
                            else if (parabirimi == "3" && prod.Fiyat.ToString() != "")
                            {
                                ltParaBirimi.Text = "$";
                            }
                        }

                    }
                    else
                    {
                        pnlNew.Visible = false;
                        Response.AddHeader("Refresh", "0;URL=/giris");
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

       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int GonderenKisi = Convert.ToInt32(Session["uye_ID"].ToString());
                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
                tbl_ilanMesajlari mesajlar = new tbl_ilanMesajlari();

              
                var Sorgu = from c in Gs.tbl_Makinalar
                            join U in Gs.tbl_Uyeler on c.Ekleyen equals U.uye_ID
                            where c.makina_ID == urunid 
                            select new { c.Ekleyen, U.EMail, AdiSoyad = U.Adi + " " + U.Soyadi, c.Baslik, c.Fotograf, c.IlanNo, c.makina_ID, c.Fiyat, c.Para_Birimi};
                foreach (var prod in Sorgu)
                {
                    //Login olup mesaj gönderen kişi İlanı Ekleyen kişinden farklı ise 
                    if(prod.Ekleyen != Convert.ToInt32(Session["uye_ID"].ToString()))
                    { 
                        Session["Kime"] = prod.Ekleyen;
                        Session["GonderilecekMail"] = prod.EMail;
                        Session["GonderilecekAdSoyad"] = prod.AdiSoyad;
                        Session["Baslik"] = prod.Baslik;
                        Session["IlanNo"] = prod.IlanNo;
                        Session["makinaID"] = prod.makina_ID;
                        Session["Fiyat"] = prod.Fiyat;
                        Session["ParaBirimi"] = prod.Para_Birimi;
                    }
                    else
                    {

                    }

                    
                }

                mesajlar.Mesaj = txtMesaj.Text;
                mesajlar.makina_ID = urunid;
                mesajlar.Kimden = Convert.ToInt32(Session["uye_ID"].ToString());
                mesajlar.Kime = Convert.ToInt32(Session["Kime"].ToString());
                mesajlar.Okunma = 0;
                mesajlar.AliciSildi = 0;
                mesajlar.GonderenSildi = 0;
                mesajlar.Durum = true;
                mesajlar.Kayit_Tarihi = DateTime.Now;
                mesajlar.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);

                Gs.tbl_ilanMesajlari.Add(mesajlar);
                Gs.SaveChanges();

                //Son Eklenen Kayıtın ID'sini alıyoruz
                int MesajID = mesajlar.mesaj_ID;
                //Üst Mesaj No Güncelliyoruz

                int kimden = Convert.ToInt32(Session["uye_ID"].ToString());
                int kime = Convert.ToInt32(Session["Kime"].ToString());
                var ilanmesajlar = from c in Gs.tbl_ilanMesajlari
                                    where c.Durum == true && c.makina_ID == urunid && c.Kimden == kimden && c.Kime == kime && c.UstMesaj_ID != null
                                   select new { c.UstMesaj_ID };
                ilanmesajlar.Count();
                
                foreach (var prod in ilanmesajlar)
                {
                    Session["UstID"] = prod.UstMesaj_ID;
                }

                if (ilanmesajlar.Count() > 0)
                {
                    var Guncelle = (from c in Gs.tbl_ilanMesajlari
                                    where c.mesaj_ID == MesajID
                                    select c).First();

                    Guncelle.UstMesaj_ID = Convert.ToInt32(Session["UstID"].ToString());
                    Gs.SaveChanges();
                }
                else { 

                var Guncelle = (from c in Gs.tbl_ilanMesajlari
                                where c.mesaj_ID == MesajID
                                select c).First();
                
                Guncelle.UstMesaj_ID = MesajID;
                Gs.SaveChanges();
                }

                //Loglama
                log4net.Config.XmlConfigurator.Configure();
                log.Info("Mesaj Eklendi-" + "Kimden:" + Session["uye_ID"].ToString() + "Kime:" + Session["Kime"].ToString() + "-İşlemi Yapan:" + Session["uye_ID"].ToString());


                //Kullanıcıya mail gönderiyoruz

                //Ana Resim
                int makinaID = Convert.ToInt32(Session["makinaID"].ToString());
                var urunresimsorgu = from c in Gs.tbl_MakinaResimler
                                     where c.Durum == true && c.makina_ID == makinaID && c.Vitrin == true
                                     select c;

                foreach (var prods in urunresimsorgu)
                {
                    string[] a = prods.Fotograf.Split('.');
                    Session["Fotograf"] = a[0] + "." + a[1];
                }

                if (urunresimsorgu.Count() == 0)
                {
                    Session["Fotograf"] = "ornekfoto.jpg";
                }

                //mailaciklama = "Sayın "+ Session["GonderilecekAdSoyad"].ToString()+ ",<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. <br /><br/><br/><strong>İlan:</strong> " + Session["Baslik"].ToString() + "<br/><strong>Gönderen Adı Soyadı:</strong> " + Session["AdSoyad"].ToString() + "<br/><strong>Mesaj:</strong> " + txtMesaj.Text + "<br /><br />Mesaja cevap vermek için <a href=https://www.sifirgibimakine.com/mesajcevapla/"+ MesajID + ">buraya</a> tıklayabilir veya https://www.sifirgibimakine.com/mesajcevapla/"+MesajID+" adresi ziyaret edebilirsiniz. <hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                BenimMailim = new Mailler();

                string mailBody = BenimMailim.SetIlanMesajMail(Session["IlanNo"].ToString(), Session["Baslik"].ToString(), Session["Fotograf"].ToString(), Session["Fiyat"].ToString(), Session["ParaBirimi"].ToString(), MesajID.ToString(), txtMesaj.Text, Session["GonderilecekAdSoyad"].ToString(), Session["AdSoyad"].ToString());

                //BenimMailim.Send_EMail("Yeni Mesaj", mailBody, Session["GonderilecekMail"].ToString(), "");
                BenimMailim.Send_EMail("Yeni Mesaj", mailBody, Session["GonderilecekMail"].ToString(), "");


                //İşlem bittikten sonra yönlendirme yapılıyor
                pnlNew.Visible = false;
                PnlFinish.Visible = true;
                lblStatus.Text = "Mesajınız başarılı bir şekilde gönderilmiştir. Lütfen bekleyiniz ilgili sayfaya yönlendiriliyorsunuz";
                Response.AddHeader("Refresh", "2;URL=/mesajlarim");
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0}", ex));
            }


        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

    }
}