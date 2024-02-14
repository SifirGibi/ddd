using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.Business.Concrete;
using SifirGibiMakina.Business.Enums;
using SifirGibiMakina.DataLayer.Enums;
using SifirGibiMakina.Dtos.ServiceExpertiz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SifirGibiMakina

{

    public partial class Ekspertiz : System.Web.UI.Page
    {
        Mailler BenimMailim;
        private string mailaciklama = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ICountryService _countryService { get; set; }
        public ICategoryService _categoryService { get; set; }
        public IServiceUserDetailService _serviceUserDetailService { get; set; }
        public IServiceExpertizService _serviceExpertizService { get; set; }
        public IUserService _userService { get; set; }
        string selectedServiceUserID;
        int turID;
        int altturID;
        int countryID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Lang = Session["Lang"].ToString();

            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

            Master.Page.Title = "2. el makinalar Ekspertiz | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
            Master.Page.MetaDescription = "2. el makine ilanları sitesi Sifirgibimakine.com uygun fiyatlı makine ilanları sitesidir. İkinci el makinalar için iletişime geçebilirsiniz.";
            Master.Page.MetaKeywords = "ikinci el makina, 2. el makineler, makinalar, makine al sat, makina al sat";


            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
     
            if (!IsPostBack)
            {

                CountryList();
                PopulateMainCategories();
                GetListSerivceFirm();

               
                //Türleri Listeliyoruz
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                var Turler = from c in nt.tbl_MakinaTurleri
                             where c.dil_ID == 1
                             orderby c.Kategori ascending
                             select c;

                ddTurler.DataSource = Turler.ToList();
                ddTurler.DataValueField = "tur_ID";
                ddTurler.DataTextField = "Kategori";
                ddTurler.DataBind();
                ListItem lit = new ListItem("Makine Türü", "0");
                ddTurler.Items.Add(lit);
                ddTurler.SelectedValue = "0";

                //Yılları Listeliyoruz
                var Yillar = from c in nt.tbl_MakinaYillar
                             where c.dil_ID == 1
                             orderby c.Kategori ascending
                             select c;

                ddYillar.DataSource = Yillar.ToList();
                ddYillar.DataValueField = "yil_ID";
                ddYillar.DataTextField = "Kategori";
                ddYillar.DataBind();
                ListItem liy = new ListItem("Makine Yılı", "0");
                ddYillar.Items.Add(liy);
                ddYillar.SelectedValue = "0";


                //Markaları Listeliyoruz
                var Markalar = from c in nt.tbl_MakinaMarkalari
                               where c.dil_ID == 1
                               orderby c.Kategori ascending
                               select c;

                ddMarkalar.DataSource = Markalar.ToList();
                ddMarkalar.DataValueField = "marka_ID";
                ddMarkalar.DataTextField = "Kategori";
                ddMarkalar.DataBind();
                ListItem lim = new ListItem("Makine Markası", "0");
                ddMarkalar.Items.Add(lim);
                ddMarkalar.SelectedValue = "0";
            }

        }

        private void GetListSerivceFirm()
        {


            var result = _serviceUserDetailService.ListServiceUser();
            
      
            if(result != null)
            {

                rptServiceFirm.DataSource = result;
                rptServiceFirm.DataBind();

              

            }

              
           





        }
        private void GetServiceListFirmWithFilter()
        {

           

           turID = ddCategory.SelectedItem != null && int.TryParse(ddCategory.SelectedItem.Value, out int parsedValue1) ? parsedValue1 : 0;
            altturID = ddSubCateory.SelectedItem != null && int.TryParse(ddSubCateory.SelectedItem.Value, out int parsedValue2) ? parsedValue2 : 0;
            countryID = ddCountries.SelectedItem != null && int.TryParse(ddCountries.SelectedItem.Value, out int parsedValue3) ? parsedValue3 : 0;

            var result = _serviceUserDetailService.ListServiceUser();


            result = result.Where(k =>
             (turID == 0 || k.CategoryID == turID) &&
             (altturID == 0 || k.SubCategoryID == altturID) &&
             (countryID == 0 || k.CountryID == countryID)
              ).ToList();



            if (result != null)
            {

                rptServiceFirm.DataSource = result;
                rptServiceFirm.DataBind();



            }



        }
        private void CountryList()
        {

            var counties = _countryService.GetListAllCountry();

            ddCountries.DataSource = counties.ToList();
            ddCountries.DataValueField = "id";
            ddCountries.DataTextField = "nicename";
            ddCountries.DataBind();
            ListItem lit = new ListItem("Ülkeler (Tümü)", "0");
            ddCountries.Items.Add(lit);
            ddCountries.SelectedValue = "0";
        }
        protected void ddCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetServiceListFirmWithFilter();



        }
        private void PopulateMainCategories()
        {
            var Turler = _categoryService.GetCategoriesWithSubcategories();
            ddCategory.DataSource = Turler.ToList();
            ddCategory.DataValueField = "tur_ID";
            ddCategory.DataTextField = "Kategori";
            ddCategory.DataBind();
            ListItem lit = new ListItem("Makine Türü(Tümü)", "0");
            ddCategory.Items.Add(lit);
            ddCategory.SelectedValue = "0";
        }
       
        protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kategoriID = Int32.Parse(ddCategory.SelectedItem.Value);


            PopulateSubCategories(kategoriID, ddSubCateory);
            GetServiceListFirmWithFilter();

        }
        protected void ddSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetServiceListFirmWithFilter();
        }
        private void PopulateSubCategories(int mainCategoryId, DropDownList dd)
        {
            var mainCategory = _categoryService.GetCategoriesWithSubcategories()
                                               .FirstOrDefault(c => c.tur_ID == mainCategoryId);

            if (mainCategory != null)
            {
                var subCategories = mainCategory.tbl_MakinaAltTurleris.OrderBy(c => c.Kategori).ToList();

                dd.DataSource = subCategories;
                dd.DataValueField = "Alttur_ID";
                dd.DataTextField = "Kategori";
                dd.DataBind();
                ListItem liy = new ListItem("Seçiniz", "0");
                dd.Items.Add(liy);
                dd.SelectedValue = "0";

            }


        }

        protected void btnExpertiz1_Click(object sender, EventArgs e)
        {
            if (Session["Giris"] != null)
            {

                pnlExpertiz1.Visible = false;
                pnlExpertiz2.Visible = true;
                pnlExpertiz3.Visible = false;
                pnlExpertiz4.Visible = false;
                pnlExpertiz5.Visible = false;
            }
            else
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
        protected void btnOpenAppointment_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            selectedServiceUserID = clickedButton.CommandArgument.ToString();
            Session["ServiceID"] = selectedServiceUserID;

            pnlExpertiz1.Visible = false;
            pnlExpertiz2.Visible = false;
            pnlExpertiz3.Visible = true;
            pnlExpertiz4.Visible = false;
            pnlExpertiz5.Visible = false;
            GetServiceUserByID(Convert.ToInt32(Session["ServiceID"]));
            txtRandevuTarihi.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }

  

        private void GetServiceUserByID(int id)
        {

            var deneme = _serviceUserDetailService.ListServiceUser().Where(x=>x.ServiceUserID == id);
            if(deneme != null)
            {


                foreach(var item in deneme)
                {
                    if(pnlExpertiz3.Visible == true)
                    {
                        adress.InnerText = item.Address;
                        prfEmail.InnerText = item.Email;
                        hName.InnerText = item.FirmName;
                       
                    }
                    else
                    {

                        pnl4Adress.InnerText = item.Address;
                        pnl4Email.InnerText = item.Email;
                        pnl4Name.InnerText = item.FirmName;

                    }
                   



                }
            }
            


        }

        protected void btnExpertiz3_Click(object sender, EventArgs e)
        {

          
                pnlExpertiz1.Visible = false;
                pnlExpertiz2.Visible = false;
                pnlExpertiz3.Visible = false;
                pnlExpertiz4.Visible = true;
                pnlExpertiz5.Visible = false;
                lblSecilenTarih.Text = Convert.ToDateTime(txtRandevuTarihi.Value).ToString("dd-MM-yyyy"); ;
                GetServiceUserByID(Convert.ToInt32(Session["ServiceID"]));
                 ShowUserInformation();


        }

        protected void btnExpertiz4_Click(object sender, EventArgs e)
        {
            try
            {
                CreateServiceExpertizDto serviceExpertizDto = new CreateServiceExpertizDto();
              
                serviceExpertizDto.Randevu_Tarihi = Convert.ToDateTime(txtRandevuTarihi.Value);
                serviceExpertizDto.Adi = ad.Value;
                serviceExpertizDto.Soyadi = soyad.Value;
                serviceExpertizDto.EMail = eposta.Value;
                serviceExpertizDto.Telefon = telefonno.Value;
                serviceExpertizDto.Baslik = txtMakinaBaslik.Text;
                serviceExpertizDto.yil_ID = Convert.ToInt32(ddYillar.SelectedItem.Value.ToString());
                serviceExpertizDto.marka_ID = Convert.ToInt32(ddMarkalar.SelectedItem.Value.ToString());
                serviceExpertizDto.tur_ID = Convert.ToInt32(ddTurler.SelectedItem.Value.ToString());
                serviceExpertizDto.Alttur_ID = Convert.ToInt32(ddTurlerAlt.SelectedItem.Value.ToString());

                serviceExpertizDto.Model = txtModel.Text;
                serviceExpertizDto.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
              
                serviceExpertizDto.Kayit_Tarihi = DateTime.Now;
       
                serviceExpertizDto.ExpertizFirmasi_ID = Convert.ToInt32(Session["ServiceID"]);
                serviceExpertizDto.uye_ID = Convert.ToInt32(Session["uye_ID"].ToString());


                _serviceExpertizService.CreateServiceExpertiz(serviceExpertizDto);


                //   //Service user mail gönderiyoruz
                //   mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. Expertiz randevu ayrıntıları aşağıda yer almaktadır. <br /><br/><br/><strong>Üye Adı Soyadı:</strong> " + ad.Value + " " + soyad.Value + "<br/><strong>Başlık:</strong> " + txtMakinaBaslik.Text + "<br /><strong>Tür:</strong> " + ddTurler.SelectedItem.Text + "<br /><strong>Alt Kategori:</strong> " + ddTurlerAlt.SelectedItem.Text + "<br/><strong>Marka:</strong> " + ddMarkalar.SelectedItem.Text + "<br /><strong>Yıl:</strong>" + ddYillar.SelectedItem.Text + "<br /><strong>Model:</strong>" + txtModel.Text + "<br /><strong>Randevu Tarihi:</strong> " + txtRandevuTarihi.Value + "<br /><br /><strong>E-Mail:</strong><br /><br />" + eposta.Value + "<br /><br /><strong>Telefon:</strong><br /><br />" + telefonno.Value + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                //BenimMailim = new Mailler();
                //BenimMailim.Send_EMail("Expertiz Talebi", mailaciklama, prfEmail.InnerText, "");

                ////Kişiye mail gönderiyoruz
                //if (eposta.Value != "") 
                //{ 
                //mailaciklama = "Sayın " + ad.Value + " " + soyad.Value + ",<br/><br/>Makina ekspertiz talebiniz <strong>" + txtRandevuTarihi.Value + "</strong> tarihine alınmıştır.<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                //BenimMailim = new Mailler();
                //BenimMailim.Send_EMail("Expertiz Talebi", mailaciklama, eposta.Value, "");
                //}

                //İşlem bittikten sonra yönlendirme yapılıyor
                pnlExpertiz1.Visible = false;
                pnlExpertiz2.Visible = false;
                pnlExpertiz3.Visible = false;
                pnlExpertiz4.Visible = false;
                pnlExpertiz5.Visible = true;
                lblRandevuTarihiBilgi.Text = $"<strong>{hName.InnerText}</strong> ekspertiz firması için {DateTime.Now.ToString("dd/MM/yyyy")} tarihli randevu talebiniz başarıyla alınmıştır.";


            }
            catch (Exception ex)
            {
                log.Error(string.Format("{0} / {1}", "", ex));
            }
           
        }

        protected void MyLnkButton_Click(Object sender, EventArgs e)
        {
            pnlExpertiz1.Visible = false;
            pnlExpertiz2.Visible = false;
            pnlExpertiz3.Visible = true;
            pnlExpertiz4.Visible = false;
            pnlExpertiz5.Visible = false;
            
        }

        protected void ddTurler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gelen bilgiye göre alt kategorileri dolduruyoruz.
            ddTurlerAlt.Items.Clear();
            int kategoriID = Int32.Parse(ddTurler.SelectedItem.Value);
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var AltKategori = from c in Gs.tbl_MakinaAltTurleri
                              where c.Durum == true && c.tur_ID == kategoriID
                              orderby c.Kategori ascending
                              select c;

            ddTurlerAlt.DataSource = AltKategori.ToList();
            ddTurlerAlt.DataValueField = "Alttur_ID";
            ddTurlerAlt.DataTextField = "Kategori";
            ddTurlerAlt.DataBind();
        }
        private void ShowUserInformation()
        {
            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());

            var Sorgu = _userService.GetUserWithDEtails(uyeID);



            eposta.Value = Sorgu.EMail;
            ad.Value = Sorgu.Adi;
            soyad.Value = Sorgu.Soyadi;

            telefonno.Value = Sorgu.Telefon;

        



        }

    }
}