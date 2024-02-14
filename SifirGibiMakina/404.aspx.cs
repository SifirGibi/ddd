using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina

{

    public partial class Hata : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            string Lang = Session["Lang"].ToString();

            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

            Master.Page.Title = "2. el makinalar sayfa bulunamadı | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
            Master.Page.MetaDescription = "2. el makine ilanları sitesi Sifirgibimakine.com uygun fiyatlı makine ilanları sitesidir. İkinci el makinalar için iletişime geçebilirsiniz.";
            Master.Page.MetaKeywords = "ikinci el makina, 2. el makineler, makinalar, makine al sat, makina al sat";


            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

            }
    }
}