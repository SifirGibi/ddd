using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Iyzipay.Model.V2.Subscription;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using Microsoft.AspNet.SignalR.Hosting;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.Business.Concrete;
using SifirGibiMakina.Business.Enums;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.MachineDetail;
using SifirGibiMakina.Dtos.Photo;
using SifirGibiMakina.Dtos.UserMembership;
using SifirGibiMakina.Helpers.EnumHelper;
using SifirGibiMakina.Models;
namespace SifirGibiMakina
{
    public partial class MakinaEkle : System.Web.UI.Page
    {
        public ICategoryService _categoryManager { get; set; }
        public ICountryService _countryService { get; set; }
        public IMachineYearService _machineYearService { get; set; }
        public IMachineBrandService _machineBrandService { get; set; }
        public IExpertService _expertService { get; set; }
        public ICityService _cityService { get; set; }
        public IUserService _userService { get; set; }
        public IMachineService _machineService { get; set; }
        public IMachineCncDetailService _machineCncDetailService { get; set; }
        public IMachineIslemeDetailService _machineIslemeDetailService { get; set; }
        public IMembershipVersionService _membershipVersionService { get; set; }
        public IPaymentService _paymentService { get; set; }
        public IUserMemberShipService _userMemberShipService { get; set; }
        public IMachinePhotoService _machinePhotoService { get; set; }
        public IMachineDetailService _machineDetailService { get; set; }
        public IPaymentPlanService _paymentPlanService { get; set; }
        private string mailaciklama = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Mailler BenimMailim;
        int MemberVersionID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SetPageSEOAttributes();
                if (!IsPostBack)
                {
                    if (!IsLoggedIn())
                    {
                        RedirectForLogin();
                        return;
                    }
                    GetCurrentUserID();
                    CheckIsMemberShip();
                    PopulateMainCategories();
                    MachineYearList();
                    MachineBrandList();
                    CountryList();
                    //ExpertList();
                    GetStatus();
                }
            }
            catch (Exception ex)
            {
            }
        }

        //Makine Ekleme
        private MachineCreateDto CreateMachineDto()
        {
            try
            {
                MachineCreateDto machineCreateDto = new MachineCreateDto();
                string Kod = Guid.NewGuid().ToString("N").ToString();
                machineCreateDto.Baslik = txtMachineName.Text;
                machineCreateDto.BaslikEN = Translate.OtomatikCeviri(txtMachineName.Text, "EN");
                machineCreateDto.BaslikDE = Translate.OtomatikCeviri(txtMachineName.Text, "DE");
                machineCreateDto.BaslikRU = Translate.OtomatikCeviri(txtMachineName.Text, "RU");
                machineCreateDto.tur_ID = int.TryParse(lbMainCategories.SelectedValue, out int mainCategoryId) ? mainCategoryId : (int?)null;
                machineCreateDto.Alttur_ID = int.TryParse(lbSubCategories.SelectedValue, out int subCategoryId) ? subCategoryId : (int?)null;
                machineCreateDto.Alttur2_ID = lbSubSubCategories.SelectedItem != null && int.TryParse(lbSubSubCategories.SelectedItem.Value, out int subSubCategoryId) ? subSubCategoryId : (int?)null;
                machineCreateDto.yil_ID = Convert.ToInt32(ddYillar.SelectedItem.Value.ToString());
                machineCreateDto.marka_ID = Convert.ToInt32(ddMarkalar.SelectedItem.Value.ToString());
                var isMember = Session["CountMax"].ToString();
                if (isMember == CheckMemberStatus.IsMemberShip.ToString())
                {
                    machineCreateDto.Vitrin = true;//daha sonra ayrı yapılacak!
                }
                else
                {
                    machineCreateDto.Vitrin = false;//daha sonra ayrı yapılacak!
                }
                machineCreateDto.Model = txtModel.Text;
                if (rblStatus.SelectedValue == ((int)MachineStatus.Sale).ToString())
                {
                    machineCreateDto.Fiyat = int.TryParse(txtPrice.Text, out int price) ? price : 0;
                }

                machineCreateDto.Para_Birimi = int.Parse(ddlCurrency.SelectedItem.Value);
                machineCreateDto.FiyatGosterilmesin = chkShowPrice.Checked;
                machineCreateDto.Aciklama = txtCKeditor.Text;
                machineCreateDto.AciklamaEN = Translate.OtomatikCeviri(txtCKeditor.Text, "EN");
                machineCreateDto.AciklamaDE = Translate.OtomatikCeviri(txtCKeditor.Text, "DE");
                machineCreateDto.AciklamaRU = Translate.OtomatikCeviri(txtCKeditor.Text, "RU");
                machineCreateDto.SosyalMedyaPaylasim = false;//daha sonra ücretliye göre değiştirelecek eklenecek!
                machineCreateDto.Ekleyen = Convert.ToInt32(Session["uye_ID"].ToString());
                machineCreateDto.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                machineCreateDto.Satis_Temsilcisi_Adi = lblSatisTemsilcisiAdi.Text;
                machineCreateDto.Satis_Temsilcisi_Email = lblSatisTemsilcisiEmail.Text;
                machineCreateDto.Satis_Temsilcisi_Telefon = lblSatisTemsilcisiTelefon.Text;
                machineCreateDto.QRCode = Kod;
                machineCreateDto.Ulke = Convert.ToInt32(ddUlkeler.SelectedItem.Value.ToString());
                if (ddUlkeler.SelectedItem.Value.ToString() == "218")
                {
                    machineCreateDto.il = ddcitylist.Text;
                    machineCreateDto.ilce = ddistrictlist.Text;
                }
                else
                {
                    machineCreateDto.il = txtCity.Text;
                    machineCreateDto.ilce = txtDistrict.Text;
                }
                machineCreateDto.FiyatGosterilmesin = false;
                string TurTR = "";
                string TurEN = "";
                string TurDE = "";
                string TurRU = "";
                string URLTR = TurTR.UrlCevir() + "-" + txtMachineName.Text.UrlCevir();
                string URLEN = TurEN.UrlCevir() + "-" + Translate.OtomatikCeviri(txtMachineName.Text, "EN").UrlCevir();
                string URLDE = TurDE.UrlCevir() + "-" + Translate.OtomatikCeviri(txtMachineName.Text, "DE").UrlCevir();
                string URLRU = TurRU.UrlCevir() + "-" + Translate.OtomatikCeviri(txtMachineName.Text, "RU").UrlCevir();
                machineCreateDto.SEOUrl = CheckUrl(URLTR) ? URLTR + "-" + DateTime.Now.ToString().UrlCevir() : URLTR;
                machineCreateDto.SEOUrlDE = CheckUrl(URLDE) ? URLDE + "-" + DateTime.Now.ToString().UrlCevir() : URLDE;
                machineCreateDto.SEOUrlEN = CheckUrl(URLEN) ? URLEN + "-" + DateTime.Now.ToString().UrlCevir() : URLEN;
                machineCreateDto.SEOUrlRU = machineCreateDto.SEOUrlEN;


                //Daha Sonra Eklenecek
                ////eksper tarafı kontrol etme
                //if (!optionCheck.Checked)
                //{
                //    foreach (GridViewRow satir in GridViewExperts.Rows)
                //    {
                //        int eksperID = Convert.ToInt32(satir.Cells[0].Text);
                //        DropDownList ddlScore = (DropDownList)satir.FindControl("ddlScore");
                //        int durum = 0;
                //        if (ddlScore != null && ddlScore.SelectedItem != null)
                //        {
                //            durum = Convert.ToInt32(ddlScore.SelectedItem.Value);
                //        }
                //        if (durum != 0)
                //        {
                //            var eksperCreateDto = new EksperCreateDto
                //            {
                //                eksper_ID = eksperID,
                //                Note = durum
                //            };
                //            machineCreateDto.ekspertCreateListDtos.Add(eksperCreateDto);
                //        }
                //    }
                //}

                return machineCreateDto;
            }
            catch (Exception ex)
            {
                string userFriendlyMessage = "Üzgünüz, işleminizi şu anda gerçekleştiremiyoruz. Lütfen daha sonra tekrar deneyin.";
                // Opsiyonel: Hata detaylarını loglamak
                log.Error(string.Format("{0}", ex));
                // Kullanıcıya hata mesajını göster
                // Bu, bir label kontrolü, bir uyarı mesajı veya başka bir kullanıcı arayüzü öğesi olabilir.
                Response.Write("<script>alert('" + userFriendlyMessage + "');</script>");
                return null;
            }

        }
        private MachineDetailCreateDto MachineDetailCreate(int id)
        {
            try
            {
                MachineDetailCreateDto machineDetail = new MachineDetailCreateDto();


                if (rblStatus.SelectedValue == ((int)MachineStatus.Rent).ToString())
                {
                    machineDetail.DailyPrice = int.TryParse(txtDayPrice.Text, out int price) ? price : 0;
                    machineDetail.WeeklyPrice = int.TryParse(txtWeekPrice.Text, out int priceWeek) ? priceWeek : 0;
                    machineDetail.MonthlyPrice = int.TryParse(txtMonthPrice.Text, out int priceMonth) ? priceMonth : 0;
                }


                if (lbSubSubCategories.SelectedValue == "312")
                {
                    machineDetail.MirrorSizeID = Convert.ToInt32(ddMirrorSize.SelectedItem.Value.ToString());
                    machineDetail.ControlUnitID = Convert.ToInt32(ddControlUnit.SelectedItem.Value.ToString());
                    machineDetail.NumberOfAxesID = Convert.ToInt32(ddNumberOfAxes.SelectedItem.Value.ToString());
                    machineDetail.SpindleRPMID = Convert.ToInt32(ddSpindleRpm.SelectedItem.Value.ToString());
                    machineDetail.YAxisSizeID = Convert.ToInt32(ddTurningLenght.SelectedItem.Value.ToString());
                }
                if (lbSubSubCategories.SelectedValue == "338")
                {
                    machineDetail.XAxisSizeID = Convert.ToInt32(ddXAxisSize.SelectedItem.Value.ToString());
                    machineDetail.YAxisSizeID = Convert.ToInt32(ddYAxisSize.SelectedItem.Value.ToString());
                    machineDetail.ControlUnitID = Convert.ToInt32(ddContolUnitIsleme.SelectedItem.Value.ToString());
                    machineDetail.NumberOfAxesID = Convert.ToInt32(ddAxesSizeIsleme.SelectedItem.Value.ToString());
                    machineDetail.SpindleRPMID = Convert.ToInt32(ddSpindleRpmIsleme.SelectedItem.Value.ToString());
                    machineDetail.NumberOfTablesID = Convert.ToInt32(ddTableSize.SelectedItem.Value.ToString());
                }
                machineDetail.SpecificType = int.Parse(rblStatus.SelectedValue);
                machineDetail.MachineId = id;
                return machineDetail;


            }
            catch (Exception ex)
            {
                string userFriendlyMessage = "Üzgünüz, işleminizi şu anda gerçekleştiremiyoruz. Lütfen daha sonra tekrar deneyin.";
                // Opsiyonel: Hata detaylarını loglamak
                log.Error(string.Format("{0}", ex));
                // Kullanıcıya hata mesajını göster
                // Bu, bir label kontrolü, bir uyarı mesajı veya başka bir kullanıcı arayüzü öğesi olabilir.
                Response.Write("<script>alert('" + userFriendlyMessage + "');</script>");
                return null;
            }




        }
        private List<PhotoCreateDto> PhotoCreate(int id)
        {
            try
            {
                var isMember = Session["CountMax"].ToString();
                List<PhotoCreateDto> photo = new List<PhotoCreateDto>();
                int resimsay = 0;
                if (uplResimler.HasFile == true || uplResimler.HasFiles == true)
                {

                    string dosyaismiorj = "";
                    string dosyaismi = "";
                    string dosyaismi_vitrinbuyuk = "";
                    string dosyaismi_vitrin = "";
                    string dosyaismi_yenieklenenler = "";
                    string dosyaismi_detay = "";
                    string dosyaismi_kucukslider = "";
                    foreach (HttpPostedFile resimler in uplResimler.PostedFiles)
                    {


                        string deger = Guid.NewGuid().ToString("N");
                        FileInfo fi = new FileInfo(System.IO.Path.GetFileName(resimler.FileName));
                        string uzanti = fi.Extension;
                        if (uzanti == ".jpg" || uzanti == ".gif" || uzanti == ".bmp" || uzanti == ".png" || uzanti == ".jpeg" || uzanti == ".JPG" || uzanti == ".PNG" || uzanti == ".JPEG" || uzanti == ".gif" || uzanti == ".BMP" || uzanti == ".GIF")
                        {
                            dosyaismiorj = deger;
                            dosyaismi = deger + uzanti;
                            dosyaismi_vitrinbuyuk = deger + "_vb" + uzanti;
                            dosyaismi_vitrin = deger + "_v" + uzanti;
                            dosyaismi_yenieklenenler = deger + "_ye" + uzanti;
                            dosyaismi_detay = deger + "_d" + uzanti;
                            dosyaismi_kucukslider = deger + "_s" + uzanti;
                            resimler.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()) + dosyaismi);
                            ImageResizer resimBoyutlayici = new ImageResizer();
                            resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_vitrinbuyuk, 420, 456);
                            resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_vitrin, 163, 308);
                            resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_yenieklenenler, 181, 263);
                            resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_detay, 449, 653);
                            resimBoyutlayici.CreateImageCrop(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()), dosyaismi, dosyaismi_kucukslider, 109, 155);
                            //Kayıt
                            var photoDto = new PhotoCreateDto
                            {
                                Durum = true,
                                Fotograf = dosyaismi,
                                makina_ID = id,
                                Kayit_Tarihi = DateTime.Now,

                            };
                            if (resimsay == 0 && isMember == CheckMemberStatus.IsMemberShip.ToString())
                            {
                                photoDto.Vitrin = true;
                            }
                            else
                            {
                                photoDto.Vitrin = false;
                            }

                            photo.Add(photoDto);
                            resimsay += 1;
                        }
                    }


                }

                return photo;
            }
            catch (Exception ex)
            {
                string userFriendlyMessage = "Üzgünüz, işleminizi şu anda gerçekleştiremiyoruz. Lütfen daha sonra tekrar deneyin.";
                // Opsiyonel: Hata detaylarını loglamak
                log.Error(string.Format("{0}", ex));
                // Kullanıcıya hata mesajını göster
                // Bu, bir label kontrolü, bir uyarı mesajı veya başka bir kullanıcı arayüzü öğesi olabilir.
                Response.Write("<script>alert('" + userFriendlyMessage + "');</script>");
                return null;
            }

        }

        private void AddMachine()
        {
            try
            {
                var machineCreateDto = CreateMachineDto();




                var id = _machineService.CreateMachine(machineCreateDto);

                if (id != -1)
                {
                    var MachineDetailCreateDto = MachineDetailCreate(id);
                    var ListPhotoCreateDto = PhotoCreate(id);

                    if (ListPhotoCreateDto.Count != 0)
                    {
                        _machinePhotoService.CreateMachinePhoto(ListPhotoCreateDto);
                    }

                    _machineDetailService.CreateMAchineDetail(MachineDetailCreateDto);



                }

                //QR Kod Oluşturuyoruz
                //QRCodeEncoder encoder = new QRCodeEncoder();
                //Bitmap img = new Bitmap(encoder.Encode("https://www.sifirgibimakine.com/Detay.aspx?Code=" + Kod), new Size(500, 500));
                //img.Save(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString() + "QR/" + 444 + ".png"), ImageFormat.Jpeg);
                //    log4net.Config.XmlConfigurator.Configure();
                //log.Info("Makina Eklendi-" + "Makina Adı:" + txtMachineName.Text + "-İşlemi Yapan:" + Session["uye_ID"].ToString());
                ////Adminne mail gönderiyoruz
                //mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. Yeni bir ilan talebi yapılmıştır. Talep detaylarına admin panelden ulaşabilirsiniz.<br /><br/><br/><strong>Üye Adı Soyadı:</strong> " + Session["AdSoyad"].ToString() + "<br/><strong>Ürün:</strong> " + txtMachineName.Text + "<br /><strong>Model:</strong> " + txtModel.Text + "<br /><strong>Fiyat:</strong> " + txtPrice.Text + ddlCurrency.SelectedItem.Text + "<br /><strong>Türü:</strong>" + lbMainCategories.SelectedItem.Text + "<br /><br /><strong>Açıklama:</strong><br /><br />" + txtCKeditor.Text + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                //BenimMailim = new Mailler();
                //BenimMailim.Send_EMail("Yeni İlan Bildirimi", mailaciklama, "", "");
                //if (sifirGibiCheck.Checked == true)
                //{
                //    mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. Yeni bir eksper talebi yapılmıştır. Talep detaylarına admin panelden ulaşabilirsiniz.<br /><br/><br/><strong>Üye Adı Soyadı:</strong> " + Session["AdSoyad"].ToString() + "<br/><strong>Ürün:</strong> " + txtMachineName.Text + "<br /><strong>Model:</strong> " + txtModel.Text + "<br /><strong>Fiyat:</strong> " + txtPrice.Text + ddlCurrency.SelectedItem.Text + "<br /><strong>Türü:</strong>" + lbMainCategories.SelectedItem.Text + "<br /><br /><strong>Açıklama:</strong><br /><br />" + txtCKeditor.Text + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                //    BenimMailim = new Mailler();
                //    BenimMailim.Send_EMail("Yeni Eksper Talebi", mailaciklama, "", "");
                //}

                Response.Write("<script>window.setTimeout(function(){ window.location.href = 'Makinalarim.aspx'; }, 5000);</script>");
            }
            catch (Exception ex)
            {
                string userFriendlyMessage = "Üzgünüz, işleminizi şu anda gerçekleştiremiyoruz. Lütfen daha sonra tekrar deneyin.";
                // Opsiyonel: Hata detaylarını loglamak
                log.Error(string.Format("{0}", ex));
                // Kullanıcıya hata mesajını göster
                // Bu, bir label kontrolü, bir uyarı mesajı veya başka bir kullanıcı arayüzü öğesi olabilir.
                Response.Write("<script>alert('" + userFriendlyMessage + "');</script>");
            }
        }

        //MAkine Ekleme Sonu
        private PaymentModel GetPayment()
        {
            PaymentModel paymentModel = new PaymentModel();
            paymentModel.CardHolderName = txtCardholderName.Value;
            paymentModel.ExpireMonht = txtExpireMonth.Value;
            paymentModel.ExpireYear = txtExpireYear.Value;
            paymentModel.CardNumber = txtCardNumber.Value;

            if (Convert.ToInt32(hiddenField.Value) == (int)PaymentPlans.Monhtly)
            {
                int id = Convert.ToInt32(Session["MemberVersion"]);
                paymentModel.RegisterCard = true;

                paymentModel.ProductReferenceCode = _paymentPlanService.GetPaymentPlanRefenceCode(id);


            }

            paymentModel.Installment = 1;
            paymentModel.Price = spnBigPayment.InnerText;
            paymentModel.Cvc = txtCvc.Value;
            return paymentModel;
        }
        private PaymentInformation GetAddress()
        {
            PaymentInformation paymentUserInfo = new PaymentInformation();
            paymentUserInfo.Description = txtAddres.Value;
            paymentUserInfo.Country = txtInfoCountry.Value;
            paymentUserInfo.City = txtInfoCity.Value;
            paymentUserInfo.Email = txtBuyerEMail.Value;
            paymentUserInfo.Surname = txtBuyerSurname.Value;
            paymentUserInfo.Name = txtBuyerName.Value;
            paymentUserInfo.IdentityNumber = txtBuyerTc.Value;
            paymentUserInfo.Ip = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
            paymentUserInfo.Id = Session["uye_ID"].ToString();
            paymentUserInfo.Phone = txtBuyerTelefon.Value;
            return paymentUserInfo;
        }
        private MemberVersionForBasket GetBasketItem()
        {
            int id = Convert.ToInt32(Session["MemberVersion"]);
            MemberVersionForBasket basketItem = new MemberVersionForBasket();
            var result = _membershipVersionService.GetMemberVersion(id);
            basketItem.Id = result.MembershipVersionID.ToString();
            basketItem.Name = result.MembershipVersion;
            basketItem.Category1 = result.MembershipName;
            basketItem.MembershipVersionID = id;
            return basketItem;
        }
        private CreateUserMemberShipDto CreateMembershipDto(int userId, int membershipId)
        {
            CreateUserMemberShipDto createUserMemberShipDto = new CreateUserMemberShipDto();
            createUserMemberShipDto.UserID = userId;
            createUserMemberShipDto.MembershipID = membershipId;


            if (membershipId == (int)MembershipPlans.OneTime)
            {
                createUserMemberShipDto.IsActive = false;
                createUserMemberShipDto.EndDate = DateTime.Now;
            }
            else
            {
                createUserMemberShipDto.PaymentPlanID = Convert.ToInt32(hiddenField.Value);
                DateTime timeToNow = DateTime.Now;


                if (Convert.ToInt32(hiddenField.Value) == (int)PaymentPlans.Monhtly)
                {
                    DateTime newDate = timeToNow.AddMonths(1);

                    createUserMemberShipDto.EndDate = newDate;
                    createUserMemberShipDto.IsPaid = true;
                    createUserMemberShipDto.IsActive = true;

                }
                else
                {
                    DateTime newDate = timeToNow.AddYears(1);

                    createUserMemberShipDto.EndDate = newDate;
                    createUserMemberShipDto.IsActive = true;
                    createUserMemberShipDto.IsPaid = true;
                }


            }

            return createUserMemberShipDto;
        }

        private void AddUserMembership()
        {

            int userId = Convert.ToInt32(Session["uye_ID"].ToString());
            int membershipId = Convert.ToInt32(Session["MemberVersion"].ToString());



            CreateUserMemberShipDto createUserMemberShipDto = CreateMembershipDto(userId, membershipId);
            _userMemberShipService.CreateMemberShip(createUserMemberShipDto);


        }




        private void SetPageSEOAttributes()
        {
            string Lang = Session["Lang"].ToString();
            Master.Page.Title = "Makina İlanı Ekle | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
            Master.Page.MetaDescription = "";
            Master.Page.MetaKeywords = "";
        }

        private bool IsLoggedIn()
        {
            return Session["Giris"] != null; // Oturum açmış ve "ok" ise true döne
        }
        private void RedirectForLogin()
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
        private void GetCurrentUserID()
        {
            var userId = Convert.ToInt32(Session["uye_ID"].ToString());
            GetUser(userId);
        }

        private bool CheckUrl(string url)
        {
            return _machineService.machineGetUrls(url);
        }

        private void GetUserDatail()
        {
            var user = _userService.GetUserWithDEtails(Convert.ToInt32(Session["uye_ID"].ToString()));
            if (user != null)
            {
                txtBuyerName.Value = user.Adi;
                txtBuyerSurname.Value = user.Soyadi;
                txtBuyerTelefon.Value = user.Telefon;
                txtBuyerEMail.Value = user.EMail;
            }
        }
        private void CountryList()
        {
            var counties = _countryService.GetListAllCountry();
            ddUlkeler.DataSource = counties.ToList();
            ddUlkeler.DataValueField = "id";
            ddUlkeler.DataTextField = "nicename";
            ddUlkeler.DataBind();
            ListItem lim = new ListItem("Seçiniz", "0");
            ddUlkeler.Items.Add(lim);
            ddUlkeler.SelectedValue = "0";
        }
        private void MachineBrandList()
        {
            var Markalar = _machineBrandService.GetAllBrandMachines();
            ddMarkalar.DataSource = Markalar.ToList();
            ddMarkalar.DataValueField = "marka_ID";
            ddMarkalar.DataTextField = "Kategori";
            ddMarkalar.DataBind();
            ListItem lim = new ListItem("Seçiniz", "0");
            ddMarkalar.Items.Add(lim);
            ddMarkalar.SelectedValue = "0";
        }
        private void MachineYearList()
        {
            var Yillar = _machineYearService.GetMachineYearList();
            ddYillar.DataSource = Yillar.ToList();
            ddYillar.DataValueField = "yil_ID";
            ddYillar.DataTextField = "Kategori";
            ddYillar.DataBind();
            ListItem liy = new ListItem("Seçiniz", "0");
            ddYillar.Items.Add(liy);
            ddYillar.SelectedValue = "0";
        }
        //private void ExpertList()
        //{
        //    var expertList = _expertService.ExpertList();
        //    GridViewExperts.DataSource = expertList;
        //    GridViewExperts.DataBind();
        //}
        private void GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user != null)
            {
                lblSatisTemsilcisiEmail.Text = user.EMail;
                lblSatisTemsilcisiAdi.Text = $"{user.Adi} {user.Soyadi}";
                lblSatisTemsilcisiTelefon.Text = user.Telefon;
            }
        }


        //Panel Machine Detail

        private void GetMachineDetails()
        {
            lblYayinTarihi.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblBaslik1.Text = txtMachineName.Text;

            SetCityLabel();

            if (chkShowPrice.Checked)
            {
                SetCurrencyLabels();
                SetVisiblePrices(false);
            }
            else
            {
                SetPrices();
                SetCurrencyLabels();
            }

            lblBaslik2.Text = txtMachineName.Text;
            ltTemsilci.Text = lblSatisTemsilcisiAdi.Text;
            SetCityLabel();
            lblYayinTarihi1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ltMarka1.Text = ddMarkalar.SelectedItem.Text;
            ltTur1.Text = lbMainCategories.SelectedItem.Text;
            lblModel1.Text = txtModel.Text;
            ltAltTur1.Text = lbSubCategories.SelectedItem.Text;
            lblYil1.Text = ddYillar.SelectedItem.Text;
            ltAciklama.Text = txtCKeditor.Text;
        }

        private void SetCityLabel()
        {
            lblIl1.Text = (ddUlkeler.SelectedItem.Value.ToString() == "218") ? ddcitylist.Text : txtCity.Text;
        }

        private void SetCurrencyLabels()
        {
            if (ddlCurrency.SelectedValue == ((int)MachineCurrencyType.TL).ToString())
            {
                SetTurkishLiraLabels();
            }
            else if (ddlCurrency.SelectedValue == ((int)MachineCurrencyType.Euro).ToString())
            {
                SetEuroLabels();
            }
            else if (ddlCurrency.SelectedValue == ((int)MachineCurrencyType.USD).ToString())
            {
                SetDollarLabels();
            }
        }

        private void SetTurkishLiraLabels()
        {
            ltParaBirimi.Text = "&#8378";
            ltParaBirim2.Text = "&#8378";
            ltParaBirim5.Text = "&#8378";
            ltParaBirim6.Text = "&#8378";
            ltParaBirim7.Text = "&#8378";
            ltParaBirim3.Text = "&#8378";
            ltParaBirim4.Text = "&#8378";
            ltParaBirimi1.Text = "&#8378";
        }

        private void SetEuroLabels()
        {
            ltParaBirimi.Text = "&euro;";
            ltParaBirim2.Text = "&euro;";
            ltParaBirim3.Text = "&euro;";
            ltParaBirim4.Text = "&euro;";
            ltParaBirim7.Text = "&euro;";
            ltParaBirim5.Text = "&euro;";
            ltParaBirim6.Text = "&euro;";
            ltParaBirimi1.Text = "&euro;";
        }

        private void SetDollarLabels()
        {
            ltParaBirimi.Text = "$";
            ltParaBirim2.Text = "$";
            ltParaBirim3.Text = "$";
            ltParaBirim4.Text = "$";
            ltParaBirim5.Text = "$";
            ltParaBirim6.Text = "$";
            ltParaBirim7.Text = "$";
            ltParaBirimi1.Text = "$";


        }

        private void SetVisiblePrices(bool isSale)
        {
            mobilSolPrice.Visible = isSale;
            mobilRentPrice.Visible = !isSale;
            pnlPrice2.Visible = isSale;
            pnlRent.Visible = !isSale;
        }

        private void SetPrices()
        {
            if (rblStatus.SelectedValue == ((int)MachineStatus.Sale).ToString())
            {
                SetVisiblePrices(true);
                ltFiyat.Text = txtPrice.Text;
                ltFiyat1.Text = txtPrice.Text;
                stepperV1.Attributes.Add("class", "stepper-item completed");
                stepperV2.Attributes.Add("class", "stepper-item completed");
                stepperV3.Attributes.Add("class", "stepper-item active");
            }
            else
            {
                SetVisiblePrices(false);
                ltMobilDailyPrice.Text = txtDayPrice.Text;
                ltMobilDailyPrice1.Text = txtDayPrice.Text;
                ltMobilWeeklyPrice.Text = txtWeekPrice.Text;
                ltMobilWeeklyPrice1.Text = txtWeekPrice.Text;
                ltMobilMonthlyPrice.Text = txtMonthPrice.Text;
                ltMobilMonthlyPrice1.Text = txtMonthPrice.Text;
            }
        }


        //Panel buton islemleri

        protected void btnPayWithCard_Click(object sender, EventArgs e)
        {
            var payment = GetPayment();
            var paymentUserInfo = GetAddress();
            var basketItem = GetBasketItem();

            var paymentResult = (Convert.ToInt32(hiddenField.Value) == (int)PaymentPlans.Monhtly)
                ? _paymentService.CreatePaymentSubscriber(payment, basketItem, paymentUserInfo)
                : _paymentService.CreatePayment(payment, basketItem, paymentUserInfo);

            if (paymentResult.Status == "success")
            {
                AddMachine();
                AddUserMembership();
                pnlSuccess.Visible = true;
                pnlPayment.Visible = false;
            }
            else
            {
                lblKod.Visible = true;
                lblKod.Text = paymentResult.ErrorMessage;
                lblKod.CssClass = "text-danger";
            }
        }

        protected void btnBackPnl1_Click(object sender, EventArgs e)
        {
            pnlDoping.Visible = true;
            pnlAddCategories.Visible = false;
        }
        protected void btnNonInfoPaymentBack_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid && Page.IsValid)
            {
                pnlPayment.Visible = false;
                pnlDoping.Visible = true;

            }

        }
        protected void btnNonInfoPaymentNext_Click(object sender, EventArgs e)
        {
            pnlPayment.Visible = false;
            pnlSuccess.Visible = true;
        }
        protected void btNextPnl1_Click(object sender, EventArgs e)
        {
            CheckCategories();
        }
        protected void btnNextMachineDetail_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                pnlAddCategories.Visible = false;
                pnlMachineDetails.Visible = false;
                pnlCheckMachine.Visible = true;
                stepperV1.Attributes.Add("class", "stepper-item completed");
                stepperV2.Attributes.Add("class", "stepper-item completed");
                stepperV3.Attributes.Add("class", "stepper-item active");
                GetMachineDetails();
            }
        }
        protected void btnBackMachineDetail_Click(object sender, EventArgs e)
        {
            if (Page.IsValid || !Page.IsValid)
            {
                pnlAddCategories.Visible = true;
                pnlMachineDetails.Visible = false;
            }
        }
        protected void btnBackCheckMachine_Click(object sender, EventArgs e)
        {
            pnlCheckMachine.Visible = false;
            pnlMachineDetails.Visible = true;
        }
        protected void btnNextCheckMachine_Click(object sender, EventArgs e)
        {
            var isMember = Session["CountMax"].ToString();
            if (isMember == CheckMemberStatus.IsWasMemberShip.ToString())
            {
                pnlCheckMachine.Visible = false;
                pnlPayment.Visible = true;
                stepperV1.Attributes.Add("class", "stepper-item completed");
                stepperV2.Attributes.Add("class", "stepper-item completed");
                stepperV3.Attributes.Add("class", "stepper-item completed");
                stepperV4.Attributes.Add("class", "stepper-item active");
            }
            if (isMember == CheckMemberStatus.IsNotMemberShip.ToString())
            {
                pnlCheckMachine.Visible = false;
                pnlDoping.Visible = true;
                btnBackDoping.Visible = true;
                stepperV1.Attributes.Add("class", "stepper-item completed");
                stepperV2.Attributes.Add("class", "stepper-item completed");
                stepperV3.Attributes.Add("class", "stepper-item completed");
                stepperV4.Attributes.Add("class", "stepper-item active");
                MembershipVersionList();
            }
            if (isMember == CheckMemberStatus.IsMemberShip.ToString())
            {
                pnlCheckMachine.Visible = false;
                stepperV1.Attributes.Add("class", "stepper-item completed");
                stepperV2.Attributes.Add("class", "stepper-item completed");
                stepperV3.Attributes.Add("class", "stepper-item completed");
                stepperV4.Attributes.Add("class", "stepper-item active");
                AddMachine();
                int id = Convert.ToInt32(Session["uye_ID"].ToString());
                int checkifCount = Convert.ToInt32(Session["CountMachine"].ToString()) + 1;
                var CheckMaxCount = Convert.ToInt32(Session["IsMemberCheckMaxCount"].ToString());
                if (checkifCount >= CheckMaxCount)
                {


                    _userMemberShipService.ChangeIsActive(id);
                }

                pnlSuccess.Visible = true;
                pnlMachineDetails.Visible = false;
            }
        }


        private void CheckIsMemberShip()
        {
            int id = Convert.ToInt32(Session["uye_ID"].ToString());

            var userMemberVersiyon = _machineService.GetNoticeCount(id);
            Session["CountMachine"] = userMemberVersiyon.CountActiveMachine;

            if (userMemberVersiyon.IsUser == false)
            {
                lblNoticeCount.Text = "Mevcut aktif ilan sayısı: " + userMemberVersiyon.CountActiveMachine.ToString() + " / 3";

                if (userMemberVersiyon.CountActiveMachine >= 3)
                {
                    IsWasMemberShip();
                    Session["CountMax"] = CheckMemberStatus.IsWasMemberShip;

                }
                else
                {
                    IsNotMemberShip();

                    Session["CountMax"] = CheckMemberStatus.IsNotMemberShip;
                }


            }
            else
            {

                IsMemberShip();
                lblNoticeCount.Text = "Mevcut aktif ilan sayısı: " + userMemberVersiyon.CountActiveMachine.ToString() + " / " + userMemberVersiyon.MaxAds.ToString();
                Session["CountMax"] = CheckMemberStatus.IsMemberShip;

                Session["IsMemberCheckMaxCount"] = userMemberVersiyon.MaxAds.ToString();





            }
        }
        protected void btnBackDoping_Click(object sender, EventArgs e)
        {
            pnlDoping.Visible = false;
            pnlCheckMachine.Visible = true;
        }







        //Abonelik secim 


        private void UpdatePanelVisibility(bool addCategoriesVisible, bool dopingVisible, bool oneTimeVisible)
        {
            pnlAddCategories.Visible = addCategoriesVisible;
            pnlDoping.Visible = dopingVisible;
            pnlOneTime.Visible = oneTimeVisible;
        }

        private void IsWasMemberShip()
        {
            UpdatePanelVisibility(false, true, true);
            GetMemberVersion();
            MembershipVersionListIfCount3();
        }

        private void IsMemberShip()
        {
            UpdatePanelVisibility(true, false, false);
        }

        private void IsNotMemberShip()
        {
            UpdatePanelVisibility(true, false, false);
        }

        private void GetMemberVersion()
        {
            var result = _membershipVersionService.GetMemberVersion(4);
            txth2.InnerText = result.PriceWeekTr.ToString();
            txth1.InnerText = result.PriceYearTr.ToString();
            btnOpenAppointment.CommandArgument = result.MembershipVersionID.ToString();
        }

        private void MembershipVersionList()
        {
            var result = _membershipVersionService.GetListMembershipVersion();
            rptMembershipVersion.DataSource = result;
            rptMembershipVersion.DataBind();
        }
        private void MembershipVersionListIfCount3()
        {
            var result = _membershipVersionService.GetListMembershipVersion().Where(x => x.MembershipID == 2 || x.MembershipID == 3);
            rptMembershipVersion.DataSource = result;
            rptMembershipVersion.DataBind();
        }
        protected void btnOpenAppointment_Click(object sender, EventArgs e)
        {


            Button clickedButton = (Button)sender;

            var isMember = Session["CountMax"].ToString();
            MemberVersionID = Convert.ToInt32(clickedButton.CommandArgument);
            int plan = 0;
            foreach (RepeaterItem item in rptMembershipVersion.Items)
            {

                //HtmlInputRadioButton exampleRadios = item.FindControl("radioMonht") as HtmlInputRadioButton;
                //HtmlInputRadioButton exampleRadios2 = item.FindControl("radioYear") as HtmlInputRadioButton;
                CheckBox monthOrYear = item.FindControl("myCheckBox") as CheckBox;

                if (monthOrYear.Checked)
                {

                    plan = (int)PaymentPlans.Yearly;
                    MonthlyButton.Visible = false;
                    break;

                }
                if (!monthOrYear.Checked)
                {

                    plan = (int)PaymentPlans.Monhtly;
                    MonthlyButton.Visible = true;
                    break;

                }
            }
            Session["MemberVersion"] = MemberVersionID.ToString();
            if (plan == 0)
            {
                lblErrorPnlPayment.Visible = true;
                lblErrorPnlPayment.Text = "Lüften Ödeme Planı Seçiniz!";
                lblErrorPnlPayment.CssClass = "text-danger";


            }
            else
            {

                if (isMember == CheckMemberStatus.IsWasMemberShip.ToString())
                {
                    IsWasMemberShipSelect(MemberVersionID, plan);
                }
                if (isMember == CheckMemberStatus.IsNotMemberShip.ToString())
                {
                    IsNotMemberShipSelect(MemberVersionID, plan);
                }

            }

        }
        private void CommonFunctionality(int MemberVersionID, int selectedPlan)
        {
            pnlDoping.Visible = false;
            GetVersion(MemberVersionID, selectedPlan);
            GetUserDatail();
        }

        private void IsWasMemberShipSelect(int MemberVersionID, int selectedPlan)
        {
            pnlAddCategories.Visible = true;
            pnlFree.Visible = false;
            btnBackPnl.Visible = true;

            CommonFunctionality(MemberVersionID, selectedPlan);
        }

        private void IsNotMemberShipSelect(int MemberVersionID, int selectedPlan)
        {
            if (MemberVersionID == 1)
            {
                btnNonInfoPaymentNext.Visible = true;
                pnlContact.Visible = false;
            }
            else
            {
                btnNonInfoPaymentNext.Visible = false;
                pnlContact.Visible = true;
            }

            pnlPayment.Visible = true;
            pnlFree.Visible = true;

            CommonFunctionality(MemberVersionID, selectedPlan);
        }

        protected void btnOpenAppointment2_Click(object sender, EventArgs e)
        {


            Button clickedButton = (Button)sender;

            var isMember = Session["CountMax"].ToString();
            MemberVersionID = Convert.ToInt32(clickedButton.CommandArgument);



            Session["MemberVersion"] = MemberVersionID.ToString();
            IsWasMemberShipSelect(MemberVersionID, 0);



        }
        //Bunun Kategoriler İle Alakası Yok--
        private void GetVersion(int id, int selectedPlan)
        {
            var result = _membershipVersionService.GetMemberVersion(id);
            if (result != null)
            {
                if (result.MembershipID == 1)
                {
                    pnlTotal.Visible = false;
                    pnlFree.Visible = true;
                    cardInfo.Visible = false;
                    mmbrName.InnerText = result.MembershipName;
                    ftrPrice.InnerText = "0";
                    ftrPriceTotal.InnerText = "0";
                    totalPrice.InnerText = "0";
                }
                else
                {
                    if (selectedPlan == (int)PaymentPlans.Yearly)
                    {
                        pnlTotal.Visible = true;
                        pnlFree.Visible = false;
                        cardInfo.Visible = true;
                        mmbrName.InnerText = result.MembershipName;
                        ftrPrice.InnerText = result.PriceYearTr.ToString();
                        ftrPriceTotal.InnerText = result.PriceYearTr.ToString();
                        totalPrice.InnerText = result.PriceYearTr.ToString();
                        spnBigPayment.InnerText = result.PriceYearTr.ToString();
                        planPayment.InnerText = PaymentPlans.Yearly.GetDescription() + " Odeme";
                        paymentplanYear.Visible = true;
                        hiddenField.Value = selectedPlan.ToString();


                    }
                    else if (selectedPlan == (int)PaymentPlans.Monhtly)
                    {


                        pnlTotal.Visible = true;
                        pnlFree.Visible = false;
                        cardInfo.Visible = true;
                        mmbrName.InnerText = result.MembershipName;
                        ftrPrice.InnerText = result.PriceWeekTr.ToString();
                        ftrPriceTotal.InnerText = result.PriceWeekTr.ToString();
                        totalPrice.InnerText = result.PriceWeekTr.ToString();
                        spnBigPayment.InnerText = result.PriceWeekTr.ToString();
                        planPayment.InnerText = PaymentPlans.Monhtly.GetDescription() + " Odeme";
                        paymentplanYear.Visible = false;

                        hiddenField.Value = selectedPlan.ToString();

                    }
                    else
                    {
                        pnlTotal.Visible = true;
                        pnlFree.Visible = false;
                        cardInfo.Visible = true;
                        mmbrName.InnerText = result.MembershipName;
                        ftrPrice.InnerText = result.PriceWeekTr.ToString();
                        ftrPriceTotal.InnerText = result.PriceWeekTr.ToString();
                        totalPrice.InnerText = result.PriceWeekTr.ToString();
                        spnBigPayment.InnerText = result.PriceWeekTr.ToString();
                        planPayment.Visible = false;
                        paymentplanYear.Visible = false;

                    }

                }
            }
        }

        protected void ddUlkeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountry = ddUlkeler.SelectedValue;
            if (selectedCountry == "218")
            {
                ddcitylist.Visible = true;
                ddistrictlist.Visible = true;
                CityList();
                txtCity.Visible = false;
                txtDistrict.Visible = false;
            }
            else
            {
                ddcitylist.Visible = false;
                ddistrictlist.Visible = false;
                txtCity.Visible = true;
                txtDistrict.Visible = true;
            }
        }
        protected void ddcitylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Burada seçilen şehire göre ilçeleri yükleyin
            int selectedCityId = int.Parse(ddcitylist.SelectedValue);
            DistrictList(selectedCityId);
            txtCity.Visible = false;
        }
        private void CityList()
        {
            var cities = _cityService.GetAllCityAndDistrict();
            ddcitylist.DataSource = cities.ToList();
            ddcitylist.DataValueField = "SehirId";
            ddcitylist.DataTextField = "SehirAdi";
            ddcitylist.DataBind();
            ListItem liy = new ListItem("Seçiniz", "0");
            ddcitylist.Items.Add(liy);
            ddcitylist.SelectedValue = "0";
        }
        private void DistrictList(int CityId)
        {
            var allCities = _cityService.GetAllCityAndDistrict();
            var selectedCity = allCities.FirstOrDefault(c => c.SehirId == CityId);
            ddistrictlist.DataSource = selectedCity.ilcelers;
            ddistrictlist.DataValueField = "ilceId";
            ddistrictlist.DataTextField = "IlceAdi";
            ddistrictlist.DataBind();
            ListItem liy = new ListItem("Seçiniz", "0");
            ddistrictlist.Items.Add(liy);
            ddistrictlist.SelectedValue = "0";
        }
        private void MachineCncDetailList()
        {
            var mirrorSize = _machineCncDetailService.MirrorSizeList();
            ddMirrorSize.DataSource = mirrorSize.ToList();
            ddMirrorSize.DataValueField = "MirrorSizeID";
            ddMirrorSize.DataTextField = "MirrorSize";
            ddMirrorSize.DataBind();
            ListItem liy = new ListItem("Seçiniz", "0");
            ddMirrorSize.Items.Add(liy);
            ddMirrorSize.SelectedValue = "0";
            var turningLenght = _machineCncDetailService.TurningLenghtList();
            ddTurningLenght.DataSource = turningLenght.ToList();
            ddTurningLenght.DataValueField = "YAxisSizeID";
            ddTurningLenght.DataTextField = "YAxisSize";
            ddTurningLenght.DataBind();
            ListItem liy1 = new ListItem("Seçiniz", "0");
            ddTurningLenght.Items.Add(liy1);
            ddTurningLenght.SelectedValue = "0";
            var controlUnit = _machineCncDetailService.ControlUnitList();
            ddControlUnit.DataSource = controlUnit.ToList();
            ddControlUnit.DataValueField = "ControlUnitID";
            ddControlUnit.DataTextField = "ControlUnitName";
            ddControlUnit.DataBind();
            ListItem liy2 = new ListItem("Seçiniz", "0");
            ddControlUnit.Items.Add(liy2);
            ddControlUnit.SelectedValue = "0";
            var numberOfAxes = _machineCncDetailService.NumberOfAxesList();
            ddNumberOfAxes.DataSource = numberOfAxes.ToList();
            ddNumberOfAxes.DataValueField = "NumberOfAxesID";
            ddNumberOfAxes.DataTextField = "NumberOfAxes";
            ddNumberOfAxes.DataBind();
            ListItem liy3 = new ListItem("Seçiniz", "0");
            ddNumberOfAxes.Items.Add(liy3);
            ddNumberOfAxes.SelectedValue = "0";
            var spindleRpm = _machineCncDetailService.SpindleRPMsList();
            ddSpindleRpm.DataSource = spindleRpm.ToList();
            ddSpindleRpm.DataValueField = "SpindleRPMID";
            ddSpindleRpm.DataTextField = "SpindleRPMSize";
            ddSpindleRpm.DataBind();
            ListItem liy4 = new ListItem("Seçiniz", "0");
            ddSpindleRpm.Items.Add(liy4);
            ddSpindleRpm.SelectedValue = "0";
        }
        private void MachineIslemeDetailList()
        {
            var XAxisSize = _machineIslemeDetailService.XAxisSizeList();
            ddXAxisSize.DataSource = XAxisSize.ToList();
            ddXAxisSize.DataValueField = "XAxisSizeID";
            ddXAxisSize.DataTextField = "XAxisSize";
            ddXAxisSize.DataBind();
            ListItem liy = new ListItem("Seçiniz", "0");
            ddXAxisSize.Items.Add(liy);
            ddXAxisSize.SelectedValue = "0";
            var YAxisSize = _machineIslemeDetailService.YAxisSizeList();
            ddYAxisSize.DataSource = YAxisSize.ToList();
            ddYAxisSize.DataValueField = "YAxisSizeID";
            ddYAxisSize.DataTextField = "YAxisSize";
            ddYAxisSize.DataBind();
            ListItem liy1 = new ListItem("Seçiniz", "0");
            ddYAxisSize.Items.Add(liy1);
            ddYAxisSize.SelectedValue = "0";
            var contolUnitIsleme = _machineIslemeDetailService.ControlUnitList();
            ddContolUnitIsleme.DataSource = contolUnitIsleme.ToList();
            ddContolUnitIsleme.DataValueField = "ControlUnitID";
            ddContolUnitIsleme.DataTextField = "ControlUnitName";
            ddContolUnitIsleme.DataBind();
            ListItem liy2 = new ListItem("Seçiniz", "0");
            ddContolUnitIsleme.Items.Add(liy2);
            ddContolUnitIsleme.SelectedValue = "0";
            var axesSizeIsleme = _machineIslemeDetailService.NumberOfAxesList();
            ddAxesSizeIsleme.DataSource = axesSizeIsleme.ToList();
            ddAxesSizeIsleme.DataValueField = "NumberOfAxesID";
            ddAxesSizeIsleme.DataTextField = "NumberOfAxes";
            ddAxesSizeIsleme.DataBind();
            ListItem liy3 = new ListItem("Seçiniz", "0");
            ddAxesSizeIsleme.Items.Add(liy3);
            ddAxesSizeIsleme.SelectedValue = "0";
            var spindleRpmIsleme = _machineIslemeDetailService.SpindleRPMsList();
            ddSpindleRpmIsleme.DataSource = spindleRpmIsleme.ToList();
            ddSpindleRpmIsleme.DataValueField = "SpindleRPMID";
            ddSpindleRpmIsleme.DataTextField = "SpindleRPMSize";
            ddSpindleRpmIsleme.DataBind();
            ListItem liy4 = new ListItem("Seçiniz", "0");
            ddSpindleRpmIsleme.Items.Add(liy4);
            ddSpindleRpmIsleme.SelectedValue = "0";
            var tableSize = _machineIslemeDetailService.NumberOfTablesList();
            ddTableSize.DataSource = tableSize.ToList();
            ddTableSize.DataValueField = "NumberOfTablesID";
            ddTableSize.DataTextField = "NumberOfTables";
            ddTableSize.DataBind();
            ListItem liy5 = new ListItem("Seçiniz", "0");
            ddTableSize.Items.Add(liy5);
            ddTableSize.SelectedValue = "0";
        }

        protected void ddYillar_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void ddMarkalar_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void rblStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblStatus.SelectedValue == ((int)MachineStatus.Sale).ToString())
            {
                Label1.Visible = true;
                txtPrice.Visible = true;
                PricePanel.Visible = false;
            }
            else if (rblStatus.SelectedValue == ((int)MachineStatus.Rent).ToString())
            {
                Label1.Visible = false;
                txtPrice.Visible = false;
                PricePanel.Visible = true;
            }
            // Diğer durumlar için gerekirse else if ekleyebilirsiniz.
        }

        private void GetCurrency()
        {
            foreach (int value in Enum.GetValues(typeof(MachineCurrencyType)))
            {
                ddlCurrency.Items.Add(new ListItem(Enum.GetName(typeof(MachineCurrencyType), value), value.ToString()));
            }
        }
        private void GetStatus()
        {
            var machineStatusValues = Enum.GetValues(typeof(MachineStatus));
            foreach (MachineStatus status in machineStatusValues)
            {
                ListItem item = new ListItem(EnumHelper.GetDescription(status), ((int)status).ToString());
                rblStatus.Items.Add(item);
            }
        }


        //Kategoriler Islmeleri
        protected void lbMainCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mainCategoryId = int.Parse(lbMainCategories.SelectedValue);
            PopulateSubCategories(mainCategoryId);
            lbSubCategories.Visible = lbSubCategories.Items.Count > 0;
            txtSubCategories.Visible = lbSubCategories.Items.Count > 0;
            lbSubSubCategories.Visible = lbSubSubCategories.Items.Count > 0;
            txtSubSubCategories.Visible = lbSubSubCategories.Items.Count > 0;
        }

        protected void lbSubCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int subCategoryId = int.Parse(lbSubCategories.SelectedValue);
            PopulateSubSubCategories(subCategoryId);
            lbSubSubCategories.Visible = lbSubSubCategories.Items.Count > 0;
        }
        private void PopulateSubCategories(int mainCategoryId)
        {
            lbSubCategories.Items.Clear();
            lbSubSubCategories.Items.Clear();
            var mainCategory = _categoryManager.GetCategoriesWithSubcategories()
                                               .FirstOrDefault(c => c.tur_ID == mainCategoryId);
            if (mainCategory != null)
            {
                foreach (var subCategory in mainCategory.tbl_MakinaAltTurleris)
                {
                    lbSubCategories.Items.Add(new ListItem(subCategory.Kategori, subCategory.Alttur_ID.ToString()));

                }
            }
        }
        private void PopulateMainCategories()
        {
            lbSubCategories.Items.Clear();
            lbSubSubCategories.Items.Clear();
            var mainCategories = _categoryManager.GetCategoriesWithSubcategories();
            foreach (var category in mainCategories)
            {
                lbMainCategories.Items.Add(new ListItem(category.Kategori, category.tur_ID.ToString()));
            }
        }
        private void PopulateSubSubCategories(int subCategoryId)
        {
            lbSubSubCategories.Items.Clear();
            // Sub kategoriye ait alt-alt kategorileri bul
            var subCategory = _categoryManager.GetCategoriesWithSubcategories()
                                              .SelectMany(c => c.tbl_MakinaAltTurleris)
                                              .FirstOrDefault(sc => sc.Alttur_ID == subCategoryId);
            txtSubSubCategories.Visible = false;
            if (subCategory != null && subCategory.tbl_MakinaAltTurleri2s != null)
            {

                foreach (var subSubCategory in subCategory.tbl_MakinaAltTurleri2s)
                {
                    lbSubSubCategories.Items.Add(new ListItem(subSubCategory.Kategori, subSubCategory.Alttur2_ID.ToString()));
                    txtSubSubCategories.Visible = true;
                }

            }
        }
        private void CheckCategories()
        {
            if (Page.IsValid)
            {
                pnlMachineDetails.Visible = true;
                pnlAddCategories.Visible = false;
                PricePanel.Visible = false;
                string subSubCategoryId = lbSubSubCategories.SelectedValue;
                if (subSubCategoryId == "312")
                {
                    lblNoCategory.Visible = false;
                    MachineDetailPanel.Visible = true;
                    CncPanel.Visible = true;
                    IslemeMerkezi.Visible = false;
                    MachineCncDetailList();
                }
                else if (subSubCategoryId == "338")
                {
                    lblNoCategory.Visible = false;
                    MachineDetailPanel.Visible = true;
                    CncPanel.Visible = false;
                    IslemeMerkezi.Visible = true;
                    MachineIslemeDetailList();
                }
                else
                {
                    lblNoCategory.Visible = true;
                    MachineDetailPanel.Visible = false;
                    CncPanel.Visible = false;
                    IslemeMerkezi.Visible = false;
                    stepperV1.Attributes.Add("class", "stepper-item completed");
                    stepperV2.Attributes.Add("class", "stepper-item active");
                }
            }
            GetCurrency();
        }
        //Validations

        protected void CustomValidatorMainCat_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = lbMainCategories.SelectedIndex != -1 && lbSubCategories.SelectedIndex != -1;
        }

        protected void CustomValidatorStatus_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = rblStatus.SelectedIndex != -1;
        }
        protected void CustomValidatorPrice_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtPrice.Visible == true)
            {
                args.IsValid = chkShowPrice.Checked || txtPrice.Text != "";
            }
        }
        protected void CustomValidatorPanel_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool pricePanelVisible = PricePanel.Visible;
            if (pricePanelVisible)
            {
                // Eğer panel görünürse, fiyat alanlarının doldurulup doldurulmadığını kontrol et
                bool dayPriceFilled = txtDayPrice.Text.Trim() != "";
                bool weekPriceFilled = txtWeekPrice.Text.Trim() != "";
                bool monthPriceFilled = txtMonthPrice.Text.Trim() != "";
                // En az bir fiyat doluysa geçerli kabul et
                args.IsValid = dayPriceFilled || weekPriceFilled || monthPriceFilled;
            }
            if (pricePanelVisible && chkShowPrice.Checked)
            {
                args.IsValid = true;
            }
            else
            {
                // Panel görünmüyorsa doğrudan geçerli kabul et
                args.IsValid = true;
            }
        }
        protected void CustomValidatorYillar_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddYillar.SelectedValue == "0")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true; // Validation failed
            }
        }
        protected void CustomValidatorddMarkalar_ServerValidate(Object source, ServerValidateEventArgs args)
        {
            if (ddMarkalar.SelectedValue == "0")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true; // Validation failed
            }
        }


        //Daha sonra Eklencek
        //protected void optionCheck_CheckedChanged(object sender, EventArgs e)
        //{
        //    GridViewExperts.Visible = !optionCheck.Checked;
        //}

        //protected void GridViewExperts_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DropDownList ddlScore = (DropDownList)e.Row.FindControl("ddlScore");
        //        for (int i = 0; i <= 10; i++)
        //        {
        //            ddlScore.Items.Add(i.ToString());
        //        }
        //    }
        //}
        protected void paymentSelect_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)

            {

                string id = DataBinder.Eval(e.Item.DataItem, "MembershipID")?.ToString();





                Panel denemePanel = (Panel)e.Item.FindControl("deneme");


                if (denemePanel != null)
                {
                    if (id == "1" || id == "4")
                    {

                        denemePanel.Visible = false;


                    }
                }
            }
        }

    }
}