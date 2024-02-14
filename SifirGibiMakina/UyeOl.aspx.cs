using Newtonsoft.Json.Linq;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.Business.DependencyResolvers;
using SifirGibiMakina.Business.Enums;
using SifirGibiMakina.DataLayer.Enums;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.SignIn;
using SifirGibiMakina.Dtos.User;
using SifirGibiMakina.Helpers.EnumHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;   
using System.Web.UI.WebControls;
using System.Xml;

namespace SifirGibiMakina
{
  
    public partial class UyeOl : System.Web.UI.Page
    {
        public ICountryService _countryService { get; set; }
        public IAuthService _authService { get; set; }
  
        public ICategoryService _categoryService { get; set; }
        Mailler BenimMailim;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {


         
            string gelenLink = this.Request.QueryString["IncomingURL"];
          


            if (!IsPostBack)
            {
                GetStatus();
               

            }


            CountryList();







        }




        private void CountryList()
        {

            var counties = _countryService.GetListAllCountry();

            ddUlkeler.DataSource = counties.ToList();
            ddUlkeler.DataValueField = "id";
            ddUlkeler.DataTextField = "nicename";
            ddUlkeler.DataBind();
            ddUlkeler.SelectedValue = "218";
        
        }
     

        private void GetStatus()
        {
            ddKayitTuru.Items.Add(new ListItem("Lütfen Üyelik Türünü Seçiniz", "0")); // Boş öğe eklendi.

            var userStatusValues = Enum.GetValues(typeof(UsersType));
            foreach (UsersType status in userStatusValues)
            {
                ListItem item = new ListItem(EnumHelper.GetDescription(status), ((int)status).ToString());
                ddKayitTuru.Items.Add(item);
                
            }
        }




        protected void btnSave_Click(object sender, EventArgs e)
        {
            int KayitTuruID = Int32.Parse(ddKayitTuru.SelectedItem.Value);

            try
            {
                CreateUserDto createUser = new CreateUserDto()
                {

 
                };
            

             
                    //Listeyi alır 
                 

                string mail = txtEmail.Value;
             

                  
                    string Kod = Guid.NewGuid().ToString("N").ToString();
         

                    createUser.Adi = txtAd.Value;
                    createUser.Soyadi = txtSoyad.Value;
                    createUser.EMail = txtEmail.Value;
                    createUser.Telefon = "+" + txtDialCode.Value + txtTelefon.Value.Trim();
               
                    createUser.Cinsiyet = ddCinsiyet.SelectedItem.Value;
                    createUser.Hesap_Turu = ddKayitTuru.SelectedItem.Value;
                    createUser.Sifre = txtSifre.Value;
             
                    createUser.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
            
                    createUser.KayitOlunanSite = "sifirgibimakine.com";
                    createUser.Il = txtSehir.Value;
                    createUser.CountryID =Convert.ToInt32(ddUlkeler.SelectedItem.Value);
                createUser.Ulke = ddUlkeler.SelectedItem.Value;
               
                if (KayitTuruID == (int)UsersType.Service || KayitTuruID == (int)UsersType.Institutional) 
                {

                    createUser.FirmaAdi = txtFirmaAd.Value;

                }









                int result = _authService.CreateAccount(createUser);
             

                //Son Kayıt ID Alınıyor
                 int uyeID = result;
                //İşlemler bittikten sonra
                //pnlUye.Visible = false;
                pnlError.Visible = false;
                    lblKod.Visible = false;
               
                    BenimMailim = new Mailler();
           
                    string mailBody = BenimMailim.SetYeniUyelikMailBody(txtEmail.Value, txtSifre.Value, txtAd.Value.ToUpper() + " " + txtSoyad.Value.ToUpper());

                    BenimMailim.Send_EMail("Üyelik Aktivasyonu", mailBody, txtEmail.Value, "");


                    //Otomatik Giriş Yap
                    Session["Giris"] = "OK";
                    Session["Email"] = txtEmail.Value;
                    Session["AdSoyadKisa"] = txtAd.Value.Substring(0, 1) + ". " + txtSoyad.Value.Substring(0, 1) + ". ";
                    Session["AdSoyad"] = txtAd.Value + " " + txtSoyad.Value;
                    Session["uye_ID"] = uyeID.ToString();
                    Session["hesapTuru"] = ddKayitTuru.SelectedItem.Value.ToString();


                    Response.Redirect("~/Uyeoldunuz.aspx");


              


            }
            catch (UserExistsException ex)
            {
                lblKod.Visible = true;
                  lblKod.Text = ex.Message;
                  lblKod.CssClass = "text-danger";
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0} / {1}", Session["Firma_ID"], ex));
            }
        }

        protected void ddKayitTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            int KayitTuruID = Int32.Parse(ddKayitTuru.SelectedItem.Value);

            //Kayıt türü kurumsal ve servis üyeliği ise firma adını göster
            if (KayitTuruID == (int)UsersType.Institutional || KayitTuruID == (int)UsersType.Service)
            {
                txtFirmaAd.Visible = true;
                ddCinsiyet.Visible = false;

            }
            
            else
            {
                txtFirmaAd.Visible = false;
           
                ddCinsiyet.Visible = true;

            }
        }
       

      

        

      

    }
}