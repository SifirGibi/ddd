using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace SifirGibiMakina
{
    public partial class Rss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "text/xml";
            XmlTextWriter objX = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
            objX.WriteStartDocument();
            objX.WriteStartElement("rss");
            objX.WriteAttributeString("version", "2.0");
            objX.WriteStartElement("channel");
            objX.WriteElementString("title", ConfigurationManager.AppSettings["MikroSiteAdi"].ToString());
            objX.WriteElementString("link", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/Rss.aspx");
            objX.WriteElementString("description", ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + " - Rss");

            //haberler
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            var haberler = from c in nt.tbl_Duyurular
                           join F in nt.tbl_Diller on c.dil_ID equals F.dil_ID
                           where c.Durum == true && c.dil_ID==1 && c.Yayinda == true
                           orderby c.Baslik ascending
                           select new { c.Kayit_Tarihi, c.Baslik, c.duy_ID, c.KisaAciklama };

            foreach (var prod in haberler)
            {
                objX.WriteStartElement("item");
                objX.WriteElementString("title", prod.Baslik);
                objX.WriteElementString("description", prod.KisaAciklama);
                objX.WriteElementString("link", "https://" + ConfigurationManager.AppSettings["MikroSiteDomain"].ToString() + "/sayfalar/" + prod.duy_ID);
                objX.WriteEndElement();
               
            }

           

            objX.WriteEndElement();
            objX.WriteEndElement();
            objX.WriteEndDocument();
            objX.Flush();
            objX.Close();
            Response.End();
        }
    }
}