using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace SifirGibiMakina
{
    public partial class Ana : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //Dil Algılama
            string Language = Request.QueryString["lang"];
            if (Language != null)
            {
                ChangeLanguage(Language);
                Response.Redirect(Request.UrlReferrer.AbsoluteUri);
            }

            
            //Sosyal Medya
            SosyalMedyalariDoldur();

        }

       

        protected void SosyalMedyalariDoldur()
        {
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            string Lang = Session["Lang"].ToString();

            //Footer Sosyal Medya Hesapları Listeleniyor 
            var hesapsorgufooter = from c in nt.tbl_SosyalMedya
                                   join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                                   where c.Durum == true && c.dil_ID == 1 && c.Footer_Yayinda == true
                                   orderby c.Siralama ascending
                                   select new { c.FontAwasome, c.Link, c.Baslik, c.Siralama, c.Resim };

            rptSosyalmedyaFooter.DataSource = hesapsorgufooter.ToList();
            rptSosyalmedyaFooter.DataBind();

            rptSosyalHamburger.DataSource = hesapsorgufooter.ToList();
            rptSosyalHamburger.DataBind();
        }
        protected void ChangeLanguage(string LanguageCode)
        {
            HttpCookie LangCookie = new HttpCookie("Language");
            LangCookie.Value = LanguageCode;
            LangCookie.Expires = DateTime.MaxValue;
            Response.Cookies.Add(LangCookie);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Response.Redirect("/"+search_input.Value);
            Response.Redirect("/arama?keyword=" + search_input.Value);
        }
        protected void btnSearchMobil_Click(object sender, EventArgs e)
        {
            //Response.Redirect("/"+txtSearchMobil.Value);
            Response.Redirect("/arama?keyword=" + txtSearchMobil.Value);
        }


    }
}