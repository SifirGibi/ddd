using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.Enums;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.SerivceDescription;
using SifirGibiMakina.Dtos.ServiceCategory;
using SifirGibiMakina.Dtos.ServiceEquipment;
using SifirGibiMakina.Dtos.ServiceUserDetail;
using SifirGibiMakina.Dtos.ServiceWorkZone;
using SifirGibiMakina.Dtos.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class Profil : System.Web.UI.Page
    {
        public ICategoryService _categoryManager { get; set; }
        public ICountryService _countryService { get; set; }
        public IMessageService _messageService { get; set; }
        public IServiceWorkZoneService _workZoneService { get; set; }
        public IServiceUsersCategoryService _usersCategoryService { get; set; }
        public IUserService _userService { get; set; }
        public IServiceUserDetailService _userDetailService { get; set; }


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string Lang = Session["Lang"].ToString();

                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                Master.Page.Title = "Profilim | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Master.Page.MetaDescription = "Sifirgibimakine.com Profil sayfası.İkinci el CNC Makinaları.";
                Master.Page.MetaKeywords = "cnc makinaları, ikinci el makina, ücretsiz cnc,";
                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

                if (Session["Giris"] != null)
                {
                    txtTaxNo.Visible = false;
                    pnlPhoto.Visible = false;
                    Panel1.Visible = false;
                    //lblMerhaba.Text = "Merhaba " + Session["AdSoyad"].ToString();

                    var hesapTur = int.Parse(Session["hesapTuru"].ToString());
                    //Hesap Türü Servis ise Servis Randevuları Panelini Göstereceğiz
                    if (hesapTur == (int)UsersType.Service)
                    {
                        if (!IsPostBack)
                        {
                            CategoryList();
                            GetListCountiesByServiceUserId();
                            GetEquipmentList();
                            GetAllCategories();
                        }

                        pnlServisRandevulari.Visible = true;
                        txtTaxNo.Visible = true;
                        txtTCK.Visible = false;
                        pnlPhoto.Visible = true;
                        Panel1.Visible = true;






                    }

                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                    int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());



               

                    if (!IsPostBack)
                    {
                        //Üye Bilgileri
                        ProfilGoster();

                        CountryList();

                    }
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
        private void CountryList()
        {

            var counties = _countryService.GetListAllCountry();
            //foreach (var country in counties)
            //{
            //    TextBox textBox = new TextBox();
            //    textBox.ID = $"textbox_{country.name}"; // TextBox ID'sini belirle
            //    textBox.Text = country.nicename; // TextBox metnini belirle
            //    textBox.CssClass = "form-control"; // Opsiyonel: CSS sınıfı atayabilirsiniz
            //    textBox.ReadOnly = true; // TextBox'i sadece okunabilir yapar

            //    CheckboxPanel.Controls.Add(textBox);
            //}
            ddUlkeler.DataSource = counties.ToList();
            ddUlkeler.DataValueField = "id";
            ddUlkeler.DataTextField = "nicename";
            ddUlkeler.DataBind();
            ListItem lit = new ListItem("Ülke", "0");

            ddcountryList.DataSource = counties.ToList();
            ddcountryList.DataValueField = "id";
            ddcountryList.DataTextField = "nicename";
            ddcountryList.DataBind();
            ListItem lit1 = new ListItem("Ülke", "0");

        }
        private void CategoryList()
        {
            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());

            var categories = _usersCategoryService.GetServiceCategoryWithIdDetails(uyeID);
            Repeater1.DataSource = categories;
            Repeater1.DataBind();

        }
        private void GetListCountiesByServiceUserId()
        {
            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());

            var countryList = _workZoneService.GetListServiceCounsrtyWithId(uyeID);
            RepaterCountry.DataSource = countryList;
            RepaterCountry.DataBind();



        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id;
            if (int.TryParse(btn.CommandArgument, out id))
            {
                _usersCategoryService.DeleteUserServiceCategory(id);
            }


            Response.Redirect(Request.Url.AbsoluteUri + "#CategoryArea");


        }
        protected void btnDeleteWorkZone_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id;
            if (int.TryParse(btn.CommandArgument, out id))
            {
                _workZoneService.DeleteWorkZone(id);
            }

            Response.Redirect(Request.Url.AbsoluteUri + "#WorkZoneArea");


        }

        protected void btnAddWorkZone_Click(object sender, EventArgs e)
        {

            try
            {

                ServiceCreateWorkZoneDto serviceCreateWorkZoneDto = new ServiceCreateWorkZoneDto();

                int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
                serviceCreateWorkZoneDto.ServiceUserID = uyeID;
                serviceCreateWorkZoneDto.ServiceWorkZonceCountyID = int.Parse(ddcountryList.SelectedValue.ToString());

                _workZoneService.CreateWorkZone(serviceCreateWorkZoneDto);

            }
            catch (Exception ex)
            {
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0}", ex));

            }
            Response.Redirect(Request.Url.AbsoluteUri + "#WorkZoneArea");
        }
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                CreateServiceCategoryDto createServiceCategoryDto = new CreateServiceCategoryDto();
                int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
                createServiceCategoryDto.CategoryID = int.Parse(ddCategory.SelectedValue.ToString());
                createServiceCategoryDto.SubCategoryID = int.Parse(ddSubCategory.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(ddSubSubCategory.SelectedValue))
                {
                    createServiceCategoryDto.SubSubCategoryID = int.Parse(ddSubSubCategory.SelectedValue);
                }

                createServiceCategoryDto.UserID = uyeID;


                _usersCategoryService.CreateUserSeriveCategory(createServiceCategoryDto);

                Response.Redirect(Request.Url.AbsoluteUri + "#CategoryArea");

            }

        }
        protected void btnAddEquipment_Click(object sender, EventArgs e)
        {


            try
            {

                int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());

                CreateEquipmentDto createEquipmentDto = new CreateEquipmentDto();

                createEquipmentDto.ServiceEquipmentDetailName = txtNewItem.Value;
                createEquipmentDto.ServiceUserID = uyeID;

                _userDetailService.AddEquipment(createEquipmentDto);
                Response.Redirect(Request.Url.AbsoluteUri + "#equipmentArea");

            }
            catch (Exception ex)
            {
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0}", ex));

            }





        }

        protected void btnDeleteEquipment_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id;
            if (int.TryParse(btn.CommandArgument, out id))
            {
                _userDetailService.DeleteEquipment(id);
            }

            Response.Redirect(Request.Url.AbsoluteUri + "#equipmentArea");


        }
        protected void ProfilGoster()
        {
            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());

            var Sorgu = _userService.GetUserWithDEtails(uyeID);



            txtEmail.Value = Sorgu.EMail;
            txtAdi.Value = Sorgu.Adi;
            txtSoyadi.Value = Sorgu.Soyadi;
            txtAdres.Value = Sorgu.Adres;
            ddUlkeler.SelectedValue = Sorgu.Ulke.ToString();
            txtIl.Value = Sorgu.Il;
            txtIlce.Value = Sorgu.Ilce;
            txtFirmaAdi.Text = Sorgu.FirmaAdi;
            this.TxtYeniSifre.Attributes.Add("value", Sorgu.Sifre);
            txtTCK.Value = Sorgu.TCK;
            //txtTelefon.Value = prod.Telefon;
            Session["Deger"] = Sorgu.Telefon;

            if (Sorgu.DogumTarihi != null)
            {
                txtDogumTarihi.Value = Sorgu.DogumTarihi.Value.ToString("yyyy-MM-dd");
            }
            if (Sorgu.Hesap_Turu == ((int)UsersType.Institutional).ToString())
            {
                pnlFirmaAdi.Visible = true;
                txtFirmaAdi.Visible = true;
            }
            if (Sorgu.Hesap_Turu == ((int)UsersType.Service).ToString())
            {

                if (Sorgu.ServiceUserLogo == null || Sorgu.ServiceUserLogo == "")
                {
                }
                else
                {
                    imgPicture.Visible = true;
                    string[] a = Sorgu.ServiceUserLogo.ToString().Split('.');
                    imgPicture.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_kck." + a[1];

                }

                if (Sorgu.ServiceUserBigLogo == null || Sorgu.ServiceUserBigLogo == "")
                {
                }
                else
                {
                    imgPictureB.Visible = true;
                    string[] a = Sorgu.ServiceUserBigLogo.ToString().Split('.');
                    imgPictureB.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_kck." + a[1];

                }
                txtCKeditor.Text = Sorgu.ServiceDescriptionTr;

            }



        }
        protected void btnProfilSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateUserDto user = new UpdateUserDto();


                //Image Save


                int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());

                user.Id = uyeID;
                user.FirmaAdi = txtFirmaAdi.Text.ToUpper();
                user.Adi = txtAdi.Value.ToUpper();
                user.Soyadi = txtSoyadi.Value.ToUpper();
                user.Telefon = "+" + txtDialCode.Value + txtTelefon.Value.Trim();
                //Guncelle.Telefon = txtTelefon.Value;
                user.Adres = txtAdres.Value;
                user.Ulke = ddUlkeler.SelectedItem.Value;
                user.Il = txtIl.Value;
                user.Ilce = txtIlce.Value;
                user.Sifre = TxtYeniSifre.Text.Trim();
                user.TCK = txtTCK.Value;
                if (txtDogumTarihi.Value != "")
                {
                    user.DogumTarihi = Convert.ToDateTime(txtDogumTarihi.Value);
                }
                else
                {
                    user.DogumTarihi = null;
                }
                _userService.Update(user);


                if (txtCKeditor.Text != "")
                {

                    CreateDescription(uyeID);



                }
                if (uplResim.HasFile == true || uplResimB.HasFile == true)
                {

                    UploadPhoto(uyeID);
                }

                //nt.SaveChanges();
                Response.AddHeader("Refresh", "1;URL=/profilim");
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0} / {1}", "", ex));
            }
        }

        private void GetEquipmentList()
        {


            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());

            var equipmentDetails = _userDetailService.GetlistServiceEquipmentDetail(uyeID);
            rptEquipment.DataSource = equipmentDetails;
            rptEquipment.DataBind();






        }


        private string[] DosyaYukle()
        {
            string[] dosyaisimler = new string[4];
            string dosyaismiorj = "";
            string dosyaismi = "";
            string dosyaismi_b = "";
            string dosyaismi_list = "";
            string dosyaismi_kck = "";
            string dosyaismi_ana = "";

            if (uplResim.HasFile)
            {
                try
                {
                    string deger = Guid.NewGuid().ToString("N");
                    FileInfo fi = new FileInfo(uplResim.FileName);
                    string uzanti = fi.Extension;
                    if (uzanti == ".jpg" || uzanti == ".JPG" || uzanti == ".gif" || uzanti == ".bmp" || uzanti == ".png" || uzanti == ".jpeg" || uzanti == ".PNG" || uzanti == ".JPEG")
                    {
                        dosyaismiorj = deger;
                        dosyaismi = deger + uzanti;
                        dosyaismi_kck = deger + "_kck" + uzanti;
                        dosyaismi_b = deger + "_b" + uzanti;
                        dosyaismi_list = deger + "_list" + uzanti;
                        dosyaismi_ana = deger + "_ana" + uzanti;

                        uplResim.PostedFile.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()) + dosyaismi);

                        uplResim.Dispose();


                        ImageResizer resimBoyutlayici = new ImageResizer();
                        resimBoyutlayici.CreateImage(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_kck, 150);
                        resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_b, 209, 207);
                        resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_ana, 51, 129);
                        resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_list, 70, 70);


                    }
                }
                catch
                {
                    dosyaismi_kck = "";
                    dosyaismiorj = "";
                }
            }
            else
            {
                dosyaismi_kck = "";
                dosyaismiorj = "";
            }
            dosyaisimler[0] = dosyaismi;


            return dosyaisimler;
        }

        private string[] DosyaYukleB()
        {
            string[] dosyaisimler = new string[4];
            string dosyaismiorj = "";
            string dosyaismi = "";
            string dosyaismi_b = "";
            string dosyaismi_list = "";
            string dosyaismi_kck = "";
            string dosyaismi_ana = "";

            if (uplResimB.HasFile)
            {
                try
                {
                    string deger = Guid.NewGuid().ToString("N");
                    FileInfo fi = new FileInfo(uplResimB.FileName);
                    string uzanti = fi.Extension;
                    if (uzanti == ".jpg" || uzanti == ".JPG" || uzanti == ".gif" || uzanti == ".bmp" || uzanti == ".png" || uzanti == ".jpeg" || uzanti == ".PNG" || uzanti == ".JPEG")
                    {
                        dosyaismiorj = deger;
                        dosyaismi = deger + uzanti;
                        dosyaismi_kck = deger + "_kck" + uzanti;
                        dosyaismi_b = deger + "_b" + uzanti;
                        dosyaismi_list = deger + "_list" + uzanti;
                        dosyaismi_ana = deger + "_ana" + uzanti;

                        uplResimB.PostedFile.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()) + dosyaismi);

                        uplResimB.Dispose();


                        ImageResizer resimBoyutlayici = new ImageResizer();
                        resimBoyutlayici.CreateImage(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_kck, 150);
                        resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_b, 209, 207);
                        resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_ana, 51, 129);
                        resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_list, 70, 70);


                    }
                }
                catch
                {
                    dosyaismi_kck = "";
                    dosyaismiorj = "";
                }
            }
            else
            {
                dosyaismi_kck = "";
                dosyaismiorj = "";
            }
            dosyaisimler[0] = dosyaismi;


            return dosyaisimler;
        }

        private void UploadPhoto(int uyeID)
        {
            CreateServiceUserDetailDto createServiceUserDetailDto = new CreateServiceUserDetailDto();



            bool isPhotoExists = _userDetailService.isSerivePhotoExists(uyeID);

            createServiceUserDetailDto.ServiceUserID = uyeID;

            byte count = 0;
            if (uplResim.HasFile == true)
            {
                string[] dosyasonuc = DosyaYukle();
                createServiceUserDetailDto.ServiceUserLogo = dosyasonuc[0];
                count = 1;
            }

            if (uplResimB.HasFile == true)
            {
                string[] dosyasonuc = DosyaYukleB();
                createServiceUserDetailDto.ServiceUserBigLogo = dosyasonuc[0];
                count = 1;
            }



            if (!isPhotoExists)
            {


                if (count != 0)
                    _userDetailService.AddServiceUserLogo(createServiceUserDetailDto);


            }
            else
            {


                if (count != 0)
                    _userDetailService.UpdateServiceUserLogo(createServiceUserDetailDto);







            }










        }
        private void CreateDescription(int uyeID)
        {
            CreateSerivceDescriptionDto createSerivceDescriptionDto = new CreateSerivceDescriptionDto();

            var userDescription = _userDetailService.isSeriveDescriptionExists(uyeID);
            createSerivceDescriptionDto.ServiceUserID = uyeID;

            createSerivceDescriptionDto.ServiceDescriptionTr = txtCKeditor.Text;
            if (!userDescription)
            {


                _userDetailService.CreateDespriction(createSerivceDescriptionDto);


            }
            else
            {

                _userDetailService.UpdateDespriction(createSerivceDescriptionDto);


            }


        }



        private void GetAllCategories()
        {
            var Turler = _categoryManager.GetCategoriesWithSubcategories();
            ddCategory.DataSource = Turler.ToList();
            ddCategory.DataValueField = "tur_ID";
            ddCategory.DataTextField = "Kategori";
            ddCategory.DataBind();
            ListItem lit = new ListItem("Seçiniz", "0");
            ddCategory.Items.Add(lit);
            ddCategory.SelectedValue = "0";


            //Alt Türleri Listeliyoruz

            ListItem litaa = new ListItem("Alt Kategori(Tümü)", "0");
            ddSubCategory.Items.Add(litaa);
            ddSubCategory.SelectedValue = "0";

            //Alt-2 Türleri Listeliyoruz

            ListItem litaaa = new ListItem("Alt-2 Kategori(Tümü)", "0");
            ddSubSubCategory.Items.Add(litaaa);
            ddSubSubCategory.SelectedValue = "0";



        }
        protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kategoriID = Int32.Parse(ddCategory.SelectedItem.Value);

            PopulateSubCategories(kategoriID, ddSubCategory);

            AltKategori2Temizle(ddSubSubCategory);




        }
        private void PopulateSubCategories(int mainCategoryId, DropDownList dd)
        {
            var mainCategory = _categoryManager.GetCategoriesWithSubcategories()
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
        private static void AltKategori2Temizle(DropDownList dd)
        {
            dd.Items.Clear();
            ListItem litaa = new ListItem("Alt Kategori(Tümü)", "0");
            dd.Items.Add(litaa);
            dd.SelectedValue = "0";


        }


        protected void ddSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddSubSubCategory.Items.Clear();



            int subCategoryId = Int32.Parse(ddSubCategory.SelectedItem.Value);


            PopulateSubSubCategories(subCategoryId, ddSubSubCategory);







        }
        private void PopulateSubSubCategories(int subCategoryId, DropDownList dd)
        {
            ddSubSubCategory.Items.Clear(); // DropDownList'i temizle

            var subCategory = _categoryManager.GetCategoriesWithSubcategories()
                                              .SelectMany(c => c.tbl_MakinaAltTurleris)
                                              .FirstOrDefault(sc => sc.Alttur_ID == subCategoryId);

            if (subCategory != null && subCategory.tbl_MakinaAltTurleri2s != null)
            {
                foreach (var subSubCategory in subCategory.tbl_MakinaAltTurleri2s)
                {
                    dd.Items.Add(new ListItem(subSubCategory.Kategori, subSubCategory.Alttur2_ID.ToString()));
                }
            }
        }

        protected void CustomValidatorMainCat_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddSubCategory.SelectedValue == "0")
            {

                args.IsValid = false;

            }
            else
                args.IsValid = true;
        }


    }
}