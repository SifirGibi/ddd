using MessagingToolkit.QRCode.Codec;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.Enums;
using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;




namespace SifirGibiMakina
{
    public partial class ServisRandevulari : System.Web.UI.Page
    {
        public IServiceExpertizService _serviceExpertizService { get; set; }
        Mailler BenimMailim;
        private string mailaciklama = "";
       
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                string Lang = Session["Lang"].ToString();

                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                Master.Page.Title = "Servis Randevuları | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Master.Page.MetaDescription = "Sifirgibimakine.com makinalarım sayfası. İkinci el CNC Makinaları ve talaşlı iş makinaları.";
                Master.Page.MetaKeywords = "cnc makinaları, ikinci el makina, ücretsiz cnc,";
                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                var hesapTur = int.Parse(Session["hesapTuru"].ToString());
                //Hesap Türü Servis ise Servis Randevuları Panelini Göstereceğiz
          
               
                    if (Session["Giris"] != null && hesapTur == (int)UsersType.Service)
                {
                      pnlServisRandevulari.Visible = true;
           
                    int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());


                    if (!IsPostBack)
                    {
                        GetListOfUsersRequestingService();


                    }
                }
                else
                {
                    Response.Redirect("default.aspx", false);
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
        protected void grdMakinalar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Sıra Numarası Ekleme
                (e.Row.FindControl("lblSira") as Label).Text = (e.Row.RowIndex + 1 + (grdMakinalar.PageIndex * 150)).ToString() + ".";
                //Sıra Numarası Ekleme

               
                    ImageButton duzenle = (ImageButton)e.Row.FindControl("LinkButton2");
                    ImageButton sil = (ImageButton)e.Row.FindControl("LinkButton3");
               




                Literal yanitlt = (Literal)e.Row.FindControl("ltYanit");
                string yanit = DataBinder.Eval(e.Row.DataItem, "Yanit").ToString();

                if (string.IsNullOrEmpty(yanit) || yanit == "False")
                {
                    Literal durumlt = (Literal)e.Row.FindControl("ltDurum");
                    string durum = DataBinder.Eval(e.Row.DataItem, "Durum")?.ToString();
                    duzenle.Visible = true;
                    sil.Visible = true;
                    if (durum == "True")
                    {
                        durumlt.Text = "Onaylandı";
                        e.Row.ForeColor = Color.Green;
                        duzenle.Visible = false;
                    }
                    else if (durum == "False")
                    {
                        durumlt.Text = "Bekliyor";
                        e.Row.ForeColor = Color.Red;
                    }
                }
                else
                {
                 
                    yanitlt.Text = "İptal Edildi";
                    e.Row.ForeColor = Color.Red;
                    duzenle.Visible = false;
                    sil.Visible = false;
                }






            }
        }

        protected void GetListOfUsersRequestingService()
        {
            //Randevu Taleplerini Listeliyoruz

            int id = Convert.ToInt32(Session["uye_ID"].ToString());


            var makinalar = _serviceExpertizService.ListOfUsersRequestingServiceById(id);

            if (makinalar != null) {
                pnlData.Visible = true; 
                grdMakinalar.DataSource = makinalar.ToList();
                grdMakinalar.DataBind();


            }
            else
            {

                pnlData.Visible = false;


            }

           

        }
        protected void grdMakinalar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;

               
                // Satırın içindeki ID değerini almak için, örneğin DataKeys kullanabilirsiniz
                int expertizID = Convert.ToInt32(grdMakinalar.DataKeys[rowIndex].Value);
                   DateTime randevuTarihi = Convert.ToDateTime(grdMakinalar.Rows[rowIndex].Cells[8].Text);
                string Name = grdMakinalar.Rows[rowIndex].Cells[2].Text;
               
                    string Email = grdMakinalar.Rows[rowIndex].Cells[3].Text;



                bool status = true;

                _serviceExpertizService.CancelTheAppointment(expertizID, status);


                //Loglama
                log4net.Config.XmlConfigurator.Configure();
                log.Info("Randevu Talebi iptal edildi-" + "Randevu ID:" + ID + "-İşlemi Yapan:" + ID.ToString());

                if (Email != "")
                {
                    mailaciklama = "Sayın " + Name + " " + randevuTarihi + " 'li" + "<br/><br/>Makina ekspertiz talebiniz servis firması tarafından iptal edilmiştir.<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                    BenimMailim = new Mailler();
                    BenimMailim.Send_EMail("Expertiz Talebi", mailaciklama, Email, "");
                }

                Response.Redirect(Request.RawUrl); 
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0} / {1}", Session["uye_ID"], ex));

            }
        }
        protected void grdMakinalar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                int rowIndex = e.NewEditIndex;


                // Satırın içindeki ID değerini almak için, örneğin DataKeys kullanabilirsiniz
                int expertizID = Convert.ToInt32(grdMakinalar.DataKeys[rowIndex].Value);
                DateTime randevuTarihi = Convert.ToDateTime(grdMakinalar.Rows[rowIndex].Cells[8].Text);
                string Name = grdMakinalar.Rows[rowIndex].Cells[2].Text;

                string Email = grdMakinalar.Rows[rowIndex].Cells[3].Text;



                bool status = true;

                _serviceExpertizService.ChangeStatus(expertizID, status);


                //Loglama
                log4net.Config.XmlConfigurator.Configure();
                log.Info("Randevu Talebi Onaylandı-" + "Randevu ID:" + ID + "-İşlemi Yapan:" + ID.ToString());

                if (Email != "")
                {
                    mailaciklama = "Sayın " + Name + " " + randevuTarihi + " 'li" + "<br/><br/>Makina ekspertiz talebiniz servis firması tarafından iptal edilmiştir.<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                    BenimMailim = new Mailler();
                    BenimMailim.Send_EMail("Expertiz Talebi", mailaciklama, Email, "");
                }
                Response.Redirect(Request.RawUrl);

            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0} / {1}", Session["uye_ID"], ex));

            }
        }
        protected void grdMakinalar_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdMakinalar.PageIndex = e.NewPageIndex;
            GetListOfUsersRequestingService();
        }

        //protected void ExceleAktarLinkButton_Click(object sender, EventArgs e)
        //{
        //    this.grdMakinalar.EditIndex = -1;

        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Today.ToShortDateString() + "_ExpertizRandevu.xls");
        //    Response.Charset = "";
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentEncoding = System.Text.Encoding.Unicode;
        //    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
        //    Response.Charset = "utf-8";
        //    Response.ContentType = "application/vnd.ms-excel";

        //    Yeni bir HtmlForm oluşturun
        //    HtmlForm frm = new HtmlForm();
        //    this.grdMakinalar.Parent.Controls.Add(frm);
        //    frm.Attributes["runat"] = "server";
        //    frm.Controls.Add(this.grdMakinalar);

        //    RegisterForEventValidation'ı çağırın
        //    Page.RegisterForEventValidation(frm);

        //    GetListOfUsersRequestingService(); // Eğer burada hata alıyorsanız, bu fonksiyonu çağırma işlemi hata kaynağı olabilir. 

        //    StringWriter swriter = new StringWriter();
        //    HtmlTextWriter hwriter = new HtmlTextWriter(swriter);
        //    this.grdMakinalar.AllowPaging = false;

        //    RenderControl metodunu çağırın
        //    frm.RenderControl(hwriter);
        //    Response.Write(swriter.ToString());
        //    Response.End();
        //}


    }
}