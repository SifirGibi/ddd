using SifirGibiMakina.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class Uyeoldunuz : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {

            var hesapTur = int.Parse(Session["hesapTuru"].ToString());
            if(hesapTur == (int)UsersType.Service)
            {

                btnAnaSayfa.Visible = false;
                btnProfil.Visible = true;
                pService.Visible = true;



            }
        }
        protected void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void btnProfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profil.aspx");
        }

    }
}