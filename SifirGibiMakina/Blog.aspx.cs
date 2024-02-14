using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class Blog : System.Web.UI.Page
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string Lang = Session["Lang"].ToString();
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                if (!IsPostBack)
                {
                    
                        //Blog Kategori ID
                        int pageid = 1;

                        ///////////////////////////////////////Bloglar alınıyor//////////////////////////////////////

                        var sorgu = from c in nt.tbl_Duyurular
                                    join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                    where c.Durum == true && c.dil_ID == 1 && c.cat_ID == pageid && c.Yayinda == true
                                    orderby c.Siralama descending, c.Kayit_Tarihi descending
                                    select new { c.Icerik, c.Baslik, c.Fotograf, c.duy_ID, c.Kayit_Tarihi, c.SeoDescription, c.SeoKeywords, c.SosyalMedyaPaylasim, c.KisaAciklama, c.Siralama };



                        CollectionPager1.DataSource = sorgu.ToList();
                        CollectionPager1.BindToControl = rptBlogAna;
                        rptBlogAna.DataSource = CollectionPager1.DataSourcePaged;
                        rptBlogAna.DataBind();

                        ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////
                        var sorgucat = from c in nt.tbl_DuyurularCat
                                       join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                       where c.Durum == true && c.dil_ID == 1 && c.cat_ID == pageid
                                       select c;

                        foreach (var prod in sorgucat)
                        {

                            Master.Page.Title = prod.Kategori + " | " + prod.SeoKeywords.ToString()+ "-"+WebConfigurationManager.AppSettings["MikroSiteAdi"];
                            Master.Page.MetaDescription = prod.SeoDescription.ToString();
                            Master.Page.MetaKeywords = prod.SeoKeywords.ToString();
                        }


                    ///////////////////////////////////////Öne Çıkanlar Listeleniyor//////////////////////////////////////
                    var habersorgu = from c in nt.tbl_Duyurular
                                     join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                     where c.Durum == true && c.dil_ID == 1 && c.cat_ID == pageid && c.Yayinda == true && c.OneCikar == true
                                     orderby c.Kayit_Tarihi descending
                                     select new { c.Icerik, c.Baslik, c.Fotograf, c.duy_ID, c.Kayit_Tarihi, c.SeoDescription, c.SeoKeywords, c.SosyalMedyaPaylasim, c.KisaAciklama };

                    rptBlog.DataSource = habersorgu.ToList().Take(4);
                    rptBlog.DataBind();


                    ///////////////////////////////////////En Çok Okunanlar Listeleniyor//////////////////////////////////////
                    var haberenconokunanlarsorgu = from c in nt.tbl_Duyurular
                                     join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                     where c.Durum == true && c.dil_ID == 1 && c.cat_ID == pageid && c.Yayinda == true
                                     orderby c.OkumaSayisi descending
                                     select new { c.Icerik, c.Baslik, c.Fotograf, c.duy_ID, c.Kayit_Tarihi, c.SeoDescription, c.SeoKeywords, c.SosyalMedyaPaylasim, c.KisaAciklama };

                    rptEncokOkunanlar.DataSource = haberenconokunanlarsorgu.ToList().Take(8);
                    rptEncokOkunanlar.DataBind();
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

        protected void dtDuyurular_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "duy_ID").ToString());
                string tarih = DataBinder.Eval(e.Item.DataItem, "Kayit_Tarihi").ToString();
                Label kayittarihi = (Label)e.Item.FindControl("lblKayitTarihi");
                kayittarihi.Text = tarih;


                //Link
                Literal Link = (Literal)e.Item.FindControl("ltLink");
                Link.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir() + "/" + DataBinder.Eval(e.Item.DataItem, "duy_ID") + " class='blog-link'>";

                Literal Link1 = (Literal)e.Item.FindControl("ltLink1");
                Link1.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir() + "/" + DataBinder.Eval(e.Item.DataItem, "duy_ID") + "  class='blog-link'>";

                Literal Link2 = (Literal)e.Item.FindControl("ltLink2");
                Link2.Text = "<a class='btn btn-default' href=" + DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir() + "/" + DataBinder.Eval(e.Item.DataItem, "duy_ID") + ">";


                //İmaj
                string foto = "";
                foto = Convert.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Fotograf")) ? "" : (String)DataBinder.Eval(e.Item.DataItem, "Fotograf");
                Image imgresim = (Image)e.Item.FindControl("imgResim");

                if (string.IsNullOrEmpty(foto) == true)
                {
                    imgresim.ImageUrl = "/images/logo.png";
                }
                else
                {
                    string[] a = foto.Split('.');
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1];

                }
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
                    imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_ana." + a[1];

                }
            }

        }

        protected void rptEncokOkunanlar_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void rptBlogAna_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //Link
                Literal Link = (Literal)e.Item.FindControl("ltLink");
                Link.Text = "<a href=/" + DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir() + "/" + DataBinder.Eval(e.Item.DataItem, "duy_ID") + " class='blog-title'>";

                Literal Link1 = (Literal)e.Item.FindControl("ltLink1");
                Link1.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "Baslik").ToString().UrlCevir() + "/" + DataBinder.Eval(e.Item.DataItem, "duy_ID") + "  class='blog-link'>";

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
            Response.Redirect("/BlogArama.aspx?keyword="+ txtSearch.Value);

        }
    }
}