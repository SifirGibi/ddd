using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class Member_Exit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["makinaUser"] != null)
                {
                    Response.Cookies["makinaUser"].Expires = DateTime.Now.AddDays(-1);
                }

                FormsAuthentication.SignOut();

                Session.Abandon();
                Response.Redirect("/", false);
            }
            catch (Exception ex)
            {
              
            }
        }
    }
}