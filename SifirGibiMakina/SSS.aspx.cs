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
    public partial class SSS : System.Web.UI.Page
    {
        int ssssay = 0;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                    
                    string Lang = Session["Lang"].ToString();
                    ///////////////////////////////////////İçerikler alınıyor//////////////////////////////////////
                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                var sorgu = from c in nt.tbl_SSS
                            join D in nt.tbl_Diller on c.dil_ID equals D.dil_ID
                            where c.Durum == true && c.dil_ID == 1 && c.Yayinda == true
                            select new { c.Aciklama, c.Baslik, c.sss_ID };

                rptSSS.DataSource = sorgu.ToList();
                rptSSS.DataBind();

                ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

                Master.Page.Title = "S.S.S. | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Master.Page.MetaDescription = "Sifirgibimakine.com Sıkça sorulan sorular sayfası.";

                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0}", ex));
            }
        }
        protected void rptSSS_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //Slider Div class ekleyip ilk olanı Active etmek
                HtmlGenericControl div = e.Item.FindControl("sssdiv") as HtmlGenericControl;
                HtmlGenericControl div1 = e.Item.FindControl("sss_div") as HtmlGenericControl;
                HtmlGenericControl div2 = e.Item.FindControl("btndiv") as HtmlGenericControl;

                if (ssssay == 0)
                {
                    
                    div.Attributes.Add("class", "collapse show");
                    div.Attributes.Add("id", ssssay.ToString());
                    div1.Attributes.Add("aria-labelledby", "sss-collapse" + ssssay.ToString());
                    div2.Attributes.Add("aria-controls", "sss-collapse" + ssssay.ToString());
                    ssssay += 1;


                }
                else
                {
                    div.Attributes.Add("class", "collapse");
                    div.Attributes.Add("id", ssssay.ToString());
                    div1.Attributes.Add("aria-labelledby", "sss-collapse" + ssssay.ToString());
                    div2.Attributes.Add("aria-controls", "sss-collapse" + ssssay.ToString());
                }
            }

        }
            }
}