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
    public partial class Content : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (RouteData.Values["id"] != null)
                {
                    //Gelen Değer int mi kontrol ediyoruz.
                    if (!Int32.TryParse(RouteData.Values["id"].ToString(), out int sayi))
                    {
                       
                        Response.Redirect("/404.aspx");
                        Environment.Exit(0);
                    }
                    else
                    {

                        int pageid = Convert.ToInt32(RouteData.Values["id"].ToString());
                        string Lang = Session["Lang"].ToString();
                        ///////////////////////////////////////İçerikler alınıyor//////////////////////////////////////
                        db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                        var sorgu = from c in nt.tbl_Icerikler
                                    join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                    join S in nt.tbl_SagMenu on c.sagMenu_ID equals S.sagMenu_ID
                                    where c.icerik_ID == pageid && c.Durum == true && c.dil_ID == 1 && c.Yayinda == true && S.Yayinda == true && S.Durum == true
                                    select new { c.Aciklama, c.Baslik, c.SeoKeywords, c.SeoDescription, c.SosyalMedyaPaylasim, c.Resim, c.sagMenu_ID, SagMenu = S.Aciklama };
                        if (sorgu.Count() > 0)
                        {
                            foreach (var prod in sorgu)
                            {
                                lblBaslik.Text = prod.Baslik;
                                lblAciklama.Text = prod.Aciklama;
                                ltSagMenu.Text = prod.SagMenu;
                                if (prod.Resim == "NULL" || prod.Resim == "" || prod.Resim == null)
                                {
                                    imgIcerik.Visible = false;
                                }
                                else
                                {
                                    imgIcerik.Visible = true;
                                    imgIcerik.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + prod.Resim;
                                }

                                ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                                Master.Page.Title = prod.Baslik + " | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                                Master.Page.MetaDescription = prod.SeoDescription.ToString();
                                Master.Page.MetaKeywords = prod.SeoKeywords.ToString();

                                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

                                ///////////////////////////////////////Paylaşım Bilgileri//////////////////////////////////////

                                if (prod.SosyalMedyaPaylasim == true)
                                {
                                    socialmediashare.Visible = true;
                                }

                                /////////////////////////////////////////Paylaşım Bilgileri/////////////////////////////////////


                            }

                        }

                        else
                        {
                            Response.Redirect("/404.aspx");
                        }
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

        
    }
}