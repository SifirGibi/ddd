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

    public partial class Servis : System.Web.UI.Page
    {
        Mailler BenimMailim;
        private string mailaciklama = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {

            string Lang = Session["Lang"].ToString();

            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

            Master.Page.Title = "2. el makinalar Servis | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
            Master.Page.MetaDescription = "2. el makine ilanları sitesi Sifirgibimakine.com uygun fiyatlı makine ilanları sitesidir. İkinci el makinalar için iletişime geçebilirsiniz.";
            Master.Page.MetaKeywords = "ikinci el makina, 2. el makineler, makinalar, makine al sat, makina al sat";


            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

            if (!IsPostBack)
            {
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

        protected void btnServis1_Click(object sender, EventArgs e)
        {
            pnlServis1.Visible = false;
            pnlServis2.Visible = true;
            pnlServis3.Visible = false;
            pnlServis4.Visible = false;
            pnlServis5.Visible = false;
        }

        protected void btnServis2_Click(object sender, EventArgs e)
        {
            pnlServis1.Visible = false;
            pnlServis2.Visible = false;
            pnlServis3.Visible = true;
            pnlServis4.Visible = false;
            pnlServis5.Visible = false;
            txtRandevuTarihi.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void btnServis3_Click(object sender, EventArgs e)
        {
            pnlServis1.Visible = false;
            pnlServis2.Visible = false;
            pnlServis3.Visible = false;
            pnlServis4.Visible = true;
            pnlServis5.Visible = false;
            lblSecilenTarih.Text = Convert.ToDateTime(txtRandevuTarihi.Value).ToString("dd-MM-yyyy"); ;


        }

        protected void btnServis4_Click(object sender, EventArgs e)
        {
            try
            {

                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                tbl_Servis makinalar = new tbl_Servis();
                makinalar.Randevu_Tarihi = Convert.ToDateTime(txtRandevuTarihi.Value);
                makinalar.Adi = ad.Value;
                makinalar.Soyadi = soyad.Value;
                makinalar.EMail = eposta.Value;
                makinalar.Telefon = telefonno.Value;
                makinalar.Baslik = txtMakinaBaslik.Text;
                makinalar.yil_ID = Convert.ToInt32(ddYillar.SelectedItem.Value.ToString());
                makinalar.marka_ID = Convert.ToInt32(ddMarkalar.SelectedItem.Value.ToString());
                makinalar.tur_ID = Convert.ToInt32(ddTurler.SelectedItem.Value.ToString());
                makinalar.Alttur_ID = Convert.ToInt32(ddTurlerAlt.SelectedItem.Value.ToString());
                makinalar.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                makinalar.Model = txtModel.Text;
                makinalar.Fotograf = "";
                makinalar.ServisFirmasi_ID = 1;
                makinalar.uye_ID = 0;
                makinalar.Durum = false;
                makinalar.Yanit = false;
                makinalar.Kayit_Tarihi = DateTime.Now;
                nt.tbl_Servis.Add(makinalar);
                nt.SaveChanges();

                //Admine mail gönderiyoruz
                mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. Servis randevu ayrıntıları aşağıda yer almaktadır. <br /><br/><br/><strong>Üye Adı Soyadı:</strong> " + ad.Value + " " + soyad.Value + "<br/><strong>Başlık:</strong> " + txtMakinaBaslik.Text + "<br /><strong>Tür:</strong> " + ddTurler.SelectedItem.Text + "<br /><strong>Alt Kategori:</strong> " + ddTurlerAlt.SelectedItem.Text + "<br/><strong>Marka:</strong> " + ddMarkalar.SelectedItem.Text + "<br /><strong>Yıl:</strong>" + ddYillar.SelectedItem.Text + "<br /><strong>Model:</strong>" + txtModel.Text + "<br /><strong>Randevu Tarihi:</strong> " + txtRandevuTarihi.Value + "<br /><br /><strong>E-Mail:</strong><br /><br />" + eposta.Value + "<br /><br /><strong>Telefon:</strong><br /><br />" + telefonno.Value + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                BenimMailim = new Mailler();
                BenimMailim.Send_EMail("Servis Talebi", mailaciklama, "", "");

                //Kişiye mail gönderiyoruz
                if (eposta.Value != "") 
                { 
                mailaciklama = "Sayın " + ad.Value + " " + soyad.Value + ",<br/><br/>Makina servis talebiniz <strong>" + txtRandevuTarihi.Value + "</strong> tarihine alınmıştır.<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                BenimMailim = new Mailler();
                BenimMailim.Send_EMail("Servis Talebi", mailaciklama, eposta.Value, "");
                }

                //İşlem bittikten sonra yönlendirme yapılıyor
                pnlServis1.Visible = false;
                pnlServis2.Visible = false;
                pnlServis3.Visible = false;
                pnlServis4.Visible = false;
                pnlServis5.Visible = true;
                lblRandevuTarihiBilgi.Text = Convert.ToDateTime(txtRandevuTarihi.Value).ToString("dd-MM-yyyy"); ;


            }
            catch (Exception ex)
            {
                log.Error(string.Format("{0} / {1}", "", ex));
            }
           
        }

        protected void MyLnkButton_Click(Object sender, EventArgs e)
        {
            pnlServis1.Visible = false;
            pnlServis2.Visible = false;
            pnlServis3.Visible = true;
            pnlServis4.Visible = false;
            pnlServis5.Visible = false;
            
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


    }
}