using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.Enums;
using SifirGibiMakina.Dtos.Favorite;
using SifirGibiMakina.Dtos.ServiceComment;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SifirGibiMakina
{
    public partial class ServisFirm : System.Web.UI.Page
    {

        public IServiceWorkZoneService _workZoneService { get; set; }
        public IServiceUsersCategoryService _usersCategoryService { get; set; }
        public IServiceUserDetailService _serviceUserDetailService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string uye_ID = RouteData.Values["serviceID"] as string;
            int serviceFirmID = Convert.ToInt32(uye_ID);
                GetServiceUser(serviceFirmID);
      

       
            int averageRating = _serviceUserDetailService.UserCommentAvarge(serviceFirmID);
            AverageRatingHiddenField.Value = averageRating.ToString();
            if (Session["Giris"] != null)
            { 
            pnlCommentUser.Visible = true;
                pnlCommentNonUser.Visible = false;
            }
        }
        //buraya bak
        private void GetServiceUser(int id)
        {
            int deneme = id;

            var result = _serviceUserDetailService.GetServiceUserWithDetails(deneme);

            if (result != null ) {
           
                Master.Page.Title = result.ServiceFirmName + " 2. el ilanları - Sahibinden " + result.ServiceFirmName + "| Makina Al Sat | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                ltHakkimizda.Text = result.Description;
                lblFirmaismi.Text = result.ServiceFirmName;
                lblServerFirmName.Text = result.ServiceFirmName;
                lblAdres.Text = result.Adress + ", " + result.CountryName;
                ltTelefon.Text = result.EmailAdress;


                string[] a = result.BigLogo.Split('.');
                //imgLogo.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1];
                if (a[0] == "")
                {
                    imgLogo.ImageUrl = "~/images/Logo.png";
                }
                else
                {
                
                    imgLogo.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "." + a[1];
                }


                GetEquipmentList(id);
                GetListCountiesByServiceUserId(id);

                CategoryList(id);
                GetCommentList(id);

            }

          




        }


        private void GetCommentList(int uyeID)
        {


            var comments = _serviceUserDetailService.GetCommentList(uyeID);

            commentRepeater.DataSource = comments;
            commentRepeater.DataBind();
        }
        private void CategoryList(int uyeID)
        {
          

            var categories = _usersCategoryService.GetServiceCategoryWithIdDetails(uyeID);
            RepeaterCategory.DataSource = categories;
            RepeaterCategory.DataBind();

        }
        private void GetEquipmentList(int id)
        {



            var equipmentDetails = _serviceUserDetailService.GetlistServiceEquipmentDetail(id);
            rptEkipmanlar.DataSource = equipmentDetails;
            rptEkipmanlar.DataBind();






        }
        private void GetListCountiesByServiceUserId(int uyeID)
        {
            

            var countryList = _workZoneService.GetListServiceCounsrtyWithId(uyeID);
            RepaterCountry.DataSource = countryList;
            RepaterCountry.DataBind();



        }
        protected void rptCommenterPhoto_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var imgPicture = (Image)e.Item.FindControl("imgPicture");
                var item = (GetListServiceCommentByUserId)e.Item.DataItem;

                if (imgPicture != null && item != null)
                {
                    if (string.IsNullOrEmpty(item.CommenterUserPhoto))
                    {
                        imgPicture.ImageUrl = "~/images/Logo.png";
                    }
                    else
                    {
                        string[] a = item.CommenterUserPhoto.Split('.');
                        imgPicture.ImageUrl = ConfigurationManager.AppSettings["imagePath"] + a[0] + "_kck." + a[1];
                    }
                }
                if (DataBinder.Eval(e.Item.DataItem, "CommentTime") != null)
                {
                    DateTime commentDate = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "CommentTime"));
                    TimeSpan difference = DateTime.Now.Subtract(commentDate);
                    int daysDifference = (int)difference.TotalDays;

                    Label lblCommentTime = (Label)e.Item.FindControl("lblCommentTime"); // Örnek bir Label kontrolü
                    if (lblCommentTime != null)
                    {
                        string timeText = "";

                        if (daysDifference < 30)
                        {
                            timeText = daysDifference + " gün önce";
                        }
                        else
                        {
                            int monthsDifference = daysDifference / 30;
                            timeText = monthsDifference + " ay önce";
                        }

                        lblCommentTime.Text = timeText;
                    }
                }


            }
        }
        public static string ReWriterPath(string NewsID, string strTitle, string Tip)
        {
            strTitle = strTitle.Trim();

            strTitle = strTitle.Trim('-');
            strTitle = strTitle.ToLower();

            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();

            strTitle = strTitle.Replace("c#", "C-Sharp");
            strTitle = strTitle.Replace("vb.net", "VB-Net");
            strTitle = strTitle.Replace("asp.net", "Asp-Net");
            strTitle = strTitle.Replace("-", "");
            strTitle = strTitle.Replace(" ", "-");
            strTitle = strTitle.Replace("ç", "c");
            strTitle = strTitle.Replace("ğ", "g");
            strTitle = strTitle.Replace("ı", "i");
            strTitle = strTitle.Replace("ö", "o");
            strTitle = strTitle.Replace("ş", "s");
            strTitle = strTitle.Replace("ü", "u");
            strTitle = strTitle.Replace("\"", "");
            strTitle = strTitle.Replace("/", "");
            strTitle = strTitle.Replace("(", "");
            strTitle = strTitle.Replace(")", "");
            strTitle = strTitle.Replace("{", "");
            strTitle = strTitle.Replace("}", "");
            strTitle = strTitle.Replace("%", "");
            strTitle = strTitle.Replace("&", "");
            strTitle = strTitle.Replace("+", "");
            strTitle = strTitle.Replace(".", "-");
            strTitle = strTitle.Replace("?", "");
            strTitle = strTitle.Replace(",", "");
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("-----", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("--", "-");

            //Lüzumsuz karakterleri de bi güzel çevirelim 

            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                {
                    strTitle = strTitle.Replace(strChar, string.Empty);
                }

            }

            strTitle = strTitle.Trim();
            strTitle = strTitle.Trim('-');
            //Tip=1 ise video,Tip=2 ise Haber,Tip=3 ise Makale
            switch (int.Parse(Tip))
            {
                case 1:
                    return strTitle;
                    break;
                case 2:
                    return NewsID + "_" + strTitle + ".aspx";
                    break;
                case 3:
                    return "Makale/" + DateTime.Now.Date.Year.ToString() + "/" + DateTime.Now.Date.Month.ToString() + "/" + DateTime.Now.Date.Day.ToString() + "/" + NewsID + "-" + strTitle + ".aspx";
                    break;
                default:
                    return "default.aspx";
                    break;
            }
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
           
           
            if (Session["Giris"] != null)
            {
                CreateCommentDto dto = new CreateCommentDto();
                var deneme = Request.Form["rating"];
                dto.ServiceCommenterUserID = Convert.ToInt32(Session["uye_ID"].ToString());
                string servviceUser_ID = RouteData.Values["serviceID"] as string;
                dto.ServiceTargetUserID = Convert.ToInt32(servviceUser_ID);
                dto.CommentRating = Convert.ToInt32(deneme);
                dto.CommentText = txtComment.Value;

                _serviceUserDetailService.AddServiceComment(dto);

                Page.Response.Redirect(Page.Request.Url.ToString(), false);

            }
            
        }
        
     protected void btnReturnComment_Click(object sender, EventArgs e)
        {

            string returnUrl = Request.Url.AbsoluteUri; // Geçerli sayfanın URL'sini alır
            string loginUrl = "/giris"; // Giriş sayfasının URL'si

            // returnUrl'i query string olarak ekler
            if (!string.IsNullOrEmpty(returnUrl))
            {
                loginUrl += "?returnUrl=" + Server.UrlEncode(returnUrl);
            }

            Response.Redirect(loginUrl);
        }
    }
}