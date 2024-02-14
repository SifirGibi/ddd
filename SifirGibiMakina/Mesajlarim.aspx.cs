using MessagingToolkit.QRCode.Codec;
using System;
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

namespace SifirGibiMakina
{
    public partial class Mesajlarim : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string Lang = Session["Lang"].ToString();

                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                Master.Page.Title = "Mesajlarım | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Master.Page.MetaDescription = "Sifirgibimakine.com mesajlarım sayfası. İkinci el CNC Makinaları ve talaşlı iş makinaları.";
                Master.Page.MetaKeywords = "cnc makinaları, ikinci el makina, ücretsiz cnc,";
                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

                if (Session["Giris"] != null)
                {
                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                    ////////////////////// OKUNMAMIŞ MESAJ SAYISINI BULUYORUZ /////////////////////////////
                    int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
                    var OkunmamisMesajSayisi = (from c in nt.tbl_ilanMesajlari
                                                where c.Durum == true && c.Kime == uyeID && c.Okunma == 0
                                                select c).ToList();

              

                    if (!IsPostBack)
                    {
                        //Makinalar
                        MesajlariGoster();

                    }
                }
                else
                {
                    Response.Redirect("default.aspx", false);
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

        protected void MesajlariGoster()
        {
            //Mesajları Listeliyoruz
            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var ilanmesajlar = (from c in Gs.tbl_ilanMesajlari
                               join K in Gs.tbl_Uyeler on c.Kime equals K.uye_ID
                               join M in Gs.tbl_Makinalar on c.makina_ID equals M.makina_ID
                               where c.Durum == true && c.Kimden == uyeID || c.Kime == uyeID
                                select new
                                {
                                    c.makina_ID,
                                    M.Ust_FirmaID,
                                    c.Durum,
                                    M.Firma_ID,
                                    M.Fotograf,
                                    M.Statu,
                                    M.Yayinda,
                                    M.IlanNo,
                                    M.Baslik,
                                   c.UstMesaj_ID,
                                   M.SEOUrl,
                                }).Distinct().OrderByDescending(n => n.UstMesaj_ID);


            grdMesajlar.DataSource = ilanmesajlar.ToList();
            grdMesajlar.DataBind();

        }

        protected void grdMesajlar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int UstMesajID = Convert.ToInt32(grdMesajlar.DataKeys[e.RowIndex].Values["UstMesaj_ID"].ToString());

                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

                //Silme Sorgumuz 
                int UyeID = Convert.ToInt32(Session["uye_ID"].ToString());
                var VeriSilKimden = (from c in Gs.tbl_ilanMesajlari
                               where c.UstMesaj_ID == UstMesajID && c.Kimden == UyeID
                               select c).ToList();
                foreach (var prod in VeriSilKimden)
                {
                    prod.GonderenSildi = 1;
                    Gs.SaveChanges();
                }

                var VeriSilKime = (from c in Gs.tbl_ilanMesajlari
                               where c.UstMesaj_ID == UstMesajID && c.Kime == UyeID
                               select c).ToList();
                foreach (var prod in VeriSilKime)
                {
                    prod.AliciSildi = 1;
                    Gs.SaveChanges();
                }



                //Loglama
                log4net.Config.XmlConfigurator.Configure();
                log.Info("Mesaj Silindi-" + "Üst Mesaj ID:" + UstMesajID + "-İşlemi Yapan:" + Session["uye_ID"].ToString());

                //İşlemler bittikten sonra
                Response.AddHeader("Refresh", "0;URL=/mesajlarim");
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0} / {1}", "", ex));

            }
        }

        protected void grdMesajlar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Sıra Numarası Ekleme
                (e.Row.FindControl("lblSira") as Label).Text = (e.Row.RowIndex + 1 + (grdMesajlar.PageIndex * 150)).ToString() + ".";
                //Sıra Numarası Ekleme

                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
               
             

                //Durumu
                Literal durumlt = (Literal)e.Row.FindControl("ltDurum");
                string durum = DataBinder.Eval(e.Row.DataItem, "Statu").ToString();
                if (durum == "1")
                { durumlt.Text = "İnceleniyor"; }
                else if (durum == "2")
                { durumlt.Text = "Satışta"; }
                else if (durum == "3")
                { durumlt.Text = "Kapalı"; }
                else if (durum == "4")
                { durumlt.Text = "Satıldı"; }
                else if (durum == "5")
                { durumlt.Text = "Yakında Stokta"; }
                else if (durum == "6")
                { durumlt.Text = "Süresi Doldu"; }
                else if (durum == "7")
                { durumlt.Text = "Kullanıcı Tarafından Yayından Kaldırıldı"; }
                else if (durum == "8")
                { durumlt.Text = "Değişiklik Onayı Bekleniyor"; }
                else
                { durumlt.Text = ""; }

                //Cevap
                Literal cevaplt = (Literal)e.Row.FindControl("ltCevap");
                int UstMesajID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UstMesaj_ID").ToString());
                cevaplt.Text = "<a href=\"/mesajcevapla/"+UstMesajID+"\"><i class=\"fas fa-reply\"></i> Cevapla </a>";

                //Okunma Okunmamaya göre kolon renklendirme
                int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
                var OkunmamisMesajSayisi = (from c in Gs.tbl_ilanMesajlari
                                            where c.Durum == true && c.Kime == uyeID && c.Okunma == 0 && c.UstMesaj_ID == UstMesajID
                                            select c).ToList();
               
                if (OkunmamisMesajSayisi.Count()==0)
                { 
                    e.Row.ForeColor = Color.Green; 
                }
                else
                {
                    e.Row.ForeColor = Color.Black;
                    e.Row.Font.Bold = true;
                }

                //Resim
                Literal resimlt = (Literal)e.Row.FindControl("ltResim");

                string makinaID = "";
                makinaID = Convert.IsDBNull(DataBinder.Eval(e.Row.DataItem, "makina_ID")) ? "" : (String)DataBinder.Eval(e.Row.DataItem, "makina_ID").ToString();

                string seourl = DataBinder.Eval(e.Row.DataItem, "SEOUrl").ToString();

                int ID = Convert.ToInt32(makinaID);
                string foto = "";
                foto = Convert.IsDBNull(DataBinder.Eval(e.Row.DataItem, "Fotograf")) ? "" : (String)DataBinder.Eval(e.Row.DataItem, "Fotograf");

                //Ana Resim
                var urunresimsorgu = from c in Gs.tbl_MakinaResimler
                                     where c.Durum == true && c.makina_ID == ID && c.Vitrin == true
                                     select c;

                foreach (var prods in urunresimsorgu)
                {
                    string[] a = prods.Fotograf.Split('.');
                    resimlt.Text = "<a href=/ilan-" + seourl + "/><img src=" + WebConfigurationManager.AppSettings["imagePath"] + "/" + a[0] + "_v." + a[1] + " class=img-fluid> </a>";
                }

                if (urunresimsorgu.Count() == 0)
                {

                    resimlt.Text = "<a href=/ilan-" + seourl + "/><img src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + "/ornekfoto.jpg width=70 height=90></a>";

                }


                

                //if (string.IsNullOrEmpty(foto) == true)
                //{
                //    resimlt.Text = "";
                //}
                //else
                //{
                //    string[] a = DataBinder.Eval(e.Row.DataItem, "Fotograf").ToString().Split('.');
                //    resimlt.Text = "<a href=/urundetay/" + makinaID+ "/><img src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_kck." + a[1] + " width=70 height=90></a>";

                //}
            }
        }
    }
}