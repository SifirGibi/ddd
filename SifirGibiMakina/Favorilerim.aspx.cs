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
    public partial class Favorilerim : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string Lang = Session["Lang"].ToString();

                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                Master.Page.Title = "Favorilerim | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Master.Page.MetaDescription = "Sifirgibimakine.com favorilerim sayfası. İkinci el CNC Makinaları ve talaşlı iş makinaları.";
                Master.Page.MetaKeywords = "cnc makinaları, ikinci el makina, ücretsiz cnc,";
                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

                if (Session["Giris"] != null)
                {


                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                    int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());

                    ////////////////////// OKUNMAMIŞ MESAJ SAYISINI BULUYORUZ /////////////////////////////
                    var OkunmamisMesajSayisi = (from c in nt.tbl_ilanMesajlari
                                                where c.Durum == true && c.Kime == uyeID && c.Okunma == 0
                                                select c).ToList();

           

                    if (!IsPostBack)
                    {
                        //Favoriler
                        MakinalariGoster();
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

        protected void MakinalariGoster()
        {
            //Favori İlanları Listeliyoruz
            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var makinalar = from c in Gs.tbl_ilanFavorileri
                            join D in Gs.tbl_Makinalar on c.makina_ID equals D.makina_ID
                            where c.user_ID == uyeID && D.Durum== true && D.Yayinda==true
                            orderby c.Kayit_Tarihi descending
                            select new
                            {
                                c.makina_ID,
                                D.Baslik,
                                D.Durum,
                                c.Kayit_Tarihi,
                                D.Fiyat,
                                D.Fotograf,
                                D.IlanNo,
                                D.Ust_FirmaID,
                                c.favori_ID,
                                D.Statu,
                                D.Para_Birimi,
                                D.SEOUrl,
                            };
            if(makinalar.Count() == 0)
            {



                pnlData.Visible = false;
                pnlNonData.Visible = true;
            }
            else
            {
                grdFavoriler.DataSource = makinalar.ToList();
                grdFavoriler.DataBind();
                pnlData.Visible = true;
                pnlNonData.Visible = false;
            }
      

        }

        protected void grdFavoriler_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int favoriID = Convert.ToInt32(grdFavoriler.DataKeys[e.RowIndex].Values["favori_ID"].ToString());
                int makinaID=0;
                int favorisayisi = 0;
                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

                //Makina Üzerinde Favori Sayısını alıp -1 yapıyoruz.
                var sorgu = from c in Gs.tbl_ilanFavorileri
                            join D in Gs.tbl_Makinalar on c.makina_ID equals D.makina_ID
                            where c.favori_ID == favoriID
                            select new { c.makina_ID, D.FavoriSayisi };
                foreach (var prod in sorgu)
                {
                    makinaID = Convert.ToInt32(prod.makina_ID);
                    favorisayisi = Convert.ToInt32(prod.FavoriSayisi);
                }

                //Favori eklenme sayısını güncelliyoruz.
                var Guncelle = (from c in Gs.tbl_Makinalar
                                where c.makina_ID == makinaID && c.Durum == true
                                select c).First();
                Guncelle.FavoriSayisi = favorisayisi - 1;
                Gs.SaveChanges();


                //Silme Sorgumuz 
                var VeriSil = (from c in Gs.tbl_ilanFavorileri
                               where c.favori_ID == favoriID
                               select c).First();

               Gs.tbl_ilanFavorileri.Remove(VeriSil);
               Gs.SaveChanges();

               

                //Loglama
                log4net.Config.XmlConfigurator.Configure();
                log.Info("Favori Silindi-" + "Favori ID:" + favoriID + "-İşlemi Yapan:" + Session["uye_ID"].ToString());

                //İşlemler bittikten sonra
                Response.AddHeader("Refresh", "0;URL=/favorilerim");
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0} / {1}", "", ex));

            }
        }

        protected void grdFavoriler_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Sıra Numarası Ekleme
                (e.Row.FindControl("lblSira") as Label).Text = (e.Row.RowIndex + 1 + (grdFavoriler.PageIndex * 150)).ToString() + ".";
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

                Literal fiyat = (Literal)e.Row.FindControl("ltFiyat");
                string makinafiyati = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fiyat")).ToString();
                string parabirimi = DataBinder.Eval(e.Row.DataItem, "Para_Birimi").ToString();
                //Para Birimi
                if (parabirimi == "1")
                {
                    fiyat.Text = makinafiyati + " &#8378";
                }
                else if (parabirimi == "2")
                {
                    fiyat.Text = makinafiyati + " &euro;";
                }
                else if (parabirimi == "3")
                {
                    fiyat.Text = makinafiyati + " $";
                }

                //Resim
                Literal resimlt = (Literal)e.Row.FindControl("ltResim");


                string foto = "";
                foto = Convert.IsDBNull(DataBinder.Eval(e.Row.DataItem, "Fotograf")) ? "" : (String)DataBinder.Eval(e.Row.DataItem, "Fotograf");
                int makinaid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "makina_ID").ToString());
                string makinaurl = DataBinder.Eval(e.Row.DataItem, "SEOUrl").ToString();

                

                if (string.IsNullOrEmpty(foto) == true)
                {
                    resimlt.Text = "<a href=/ilan-" + makinaurl + ">İlanı Göster</a>";
                }
                else
                {
                    string[] a = DataBinder.Eval(e.Row.DataItem, "Fotograf").ToString().Split('.');
                    resimlt.Text = "<a href=/ilan-"+ makinaurl + "><img src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_kck." + a[1] + " width=70 height=90></a>";

                }
            }
        }
      
    }
}