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
    public partial class Ihalelerim : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string Lang = Session["Lang"].ToString();

                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                Master.Page.Title = "İhalelelerim | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Master.Page.MetaDescription = "Sifirgibimakine.com ihalelerkatılım sayfası. İkinci el CNC Makinaları ve talaşlı iş makinaları.";
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
                        //Üye Bilgileri
                        IhalelerGoster();

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
        protected void IhalelerGoster()
        {
            //Ihaleleri Listeliyoruz
            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var ihaleler = from c in Gs.tbl_Ihale
                           join M in Gs.tbl_Makinalar on c.makina_ID equals M.makina_ID
                           join U in Gs.tbl_Uyeler on c.uye_ID equals U.uye_ID
                           where c.Durum == true && c.uye_ID == uyeID
                           orderby c.Kayit_Tarihi descending
                           select new
                           {
                               c.ihale_ID,
                               c.makina_ID,
                               c.uye_ID,
                               c.Verilen_Fiyat,
                               UyeAd = U.Adi + " " + U.Soyadi,
                               Makina = M.Baslik,
                               c.Durum,
                               c.Kayit_Tarihi,
                               c.SonFiyat,
                               M.Para_Birimi,

                           };
            if(ihaleler.Count() == 0){

                pnlNonData.Visible = true;
                pnlWithData.Visible = false;

            }
            else
            {

                pnlNonData.Visible = false;
                pnlWithData.Visible = true;
                grdIhale.DataSource = ihaleler.ToList();
                grdIhale.DataBind();


            }

           

        }
        protected void grdIhale_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Sıra Numarası Ekleme
                (e.Row.FindControl("lblSira") as Label).Text = (e.Row.RowIndex + 1 + (grdIhale.PageIndex * 250)).ToString() + ".";
                //Sıra Numarası Ekleme

                //Son Fiyat Bilgisi
                Literal sonteklif = (Literal)e.Row.FindControl("ltSonTeklif");
                Literal verilenfiyat = (Literal)e.Row.FindControl("ltVerilenFiyat");

                string parabirimi = DataBinder.Eval(e.Row.DataItem, "Para_Birimi").ToString();
                string sonteklifverisi = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SonFiyat")).ToString("N2");
                string verilenfiyatverisi = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Verilen_Fiyat")).ToString("N2");

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