using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class Blog_Detail : System.Web.UI.Page
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
                    string foto = "";
                    ///////////////////////////////////////Blog Yazıları alınıyor//////////////////////////////////////
                    int varolangoruntulenmesayisi = 0;
                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                    var sorgu = from c in nt.tbl_Duyurular
                                join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                where c.duy_ID == pageid && c.Durum == true && c.dil_ID == 1 && c.Yayinda == true
                                select new { c.KisaAciklama, c.Kayit_Tarihi, c.Icerik, c.Baslik, c.SeoKeywords, c.SeoDescription, c.SosyalMedyaPaylasim, c.Fotograf, c.OkumaSayisi };
                    if (sorgu.Count() > 0)
                    {
                        foreach (var prod in sorgu)
                    {
                        lblAciklama.Text = prod.Icerik;;
                        lblBaslik.Text = prod.Baslik;
                        lblBaslikBreadCrumb.Text = prod.Baslik;
                        lblKisaAciklama.Text = prod.KisaAciklama;
                        lblKayitTarihi.Text = prod.Kayit_Tarihi.ToString();
                        varolangoruntulenmesayisi = Convert.ToInt32(prod.OkumaSayisi);

                        if (prod.Fotograf == "NULL" || prod.Fotograf == "" || prod.Fotograf == null)
                        {
                            imgIcerik.Visible = false;
                        }
                        else
                        {
                            imgIcerik.Visible = true;
                            foto = prod.Fotograf;

                            string[] a = foto.Split('.');
                            imgIcerik.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_b." + a[1];
                        }

                        
                       
                        ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                        if (prod.SeoKeywords != "")
                        {
                            string[] aa = prod.SeoKeywords.Split(',');

                            foreach (string word in aa)
                            {
                                ltKelimeler.Text += "<a class=\"btn btn-xs btn-primary\" href='#'>" + word + "</a> ";
                            }
                        }

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

                    //Görüntüleme sayısı Güncelleniyor
                    var Guncelle = (from c in nt.tbl_Duyurular
                                    where c.duy_ID == pageid && c.Durum == true
                                    select c).First();
                    Guncelle.OkumaSayisi = varolangoruntulenmesayisi + 1;
                    nt.SaveChanges();

                    ///////////////////////////////////////En Çok Okunanlar Listeleniyor//////////////////////////////////////
                    //Blog Kategori ID
                    int habercat = 1;
                    var habersorgu = from c in nt.tbl_Duyurular
                                     join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                     where c.Durum == true && c.dil_ID == 1 && c.cat_ID == habercat && c.Yayinda == true
                                     orderby c.OkumaSayisi descending
                                     select new { c.Icerik, c.Baslik, c.Fotograf, c.duy_ID, c.Kayit_Tarihi, c.SeoDescription, c.SeoKeywords, c.SosyalMedyaPaylasim, c.KisaAciklama };

                    rptBlog.DataSource = habersorgu.ToList().Take(5);
                    rptBlog.DataBind();

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

        protected void rptBlog_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //Link
                Literal Link = (Literal)e.Item.FindControl("ltLink");
                Link.Text = "<a href=/" + DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir() + "/" + DataBinder.Eval(e.Item.DataItem, "duy_ID") + ">";

                //İmaj
                string foto = "";
                foto = Convert.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Fotograf")) ? "" : (String)DataBinder.Eval(e.Item.DataItem, "Fotograf");
                Image imgresim = (Image)e.Item.FindControl("imgBlog");

                if (string.IsNullOrEmpty(foto) == true)
                {
                    imgresim.ImageUrl = "/images/Logo.png";
                }
                else
                {
                    string[] a = foto.Split('.');
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_list." + a[1];
                }
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BlogArama.aspx?keyword=" + txtSearch.Value);

        }

    }
}