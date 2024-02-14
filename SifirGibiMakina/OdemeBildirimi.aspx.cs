using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class OdemeBildirimi : System.Web.UI.Page
    {
        Mailler BenimMailim;
        private string mailaciklama = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string Lang = Session["Lang"].ToString();

                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                Master.Page.Title = "Ödeme Bildirimi | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Master.Page.MetaDescription = "Sifirgibimakine.com ikinci el makinanızın değerlemesini yapar. İsterseniz sizin adınıza satar veya açık artırmaya çıkartır.";
                Master.Page.MetaKeywords = "cnc makinaları, ikinci el makina, ücretsiz cnc,";
                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////

                if (Session["Giris"] != null)
                {

                    

                    db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                    int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());

                    ////////////////////// OKUNMAMIŞ MESAJ SAYISINI BULUYORUZ /////////////////////////////
                    var OkunmamisMesajSayisi = (from c in nt.tbl_ilanMesajlari
                                                where c.Durum == true && c.Kime == uyeID && c.Okunma == 0
                                                select c).ToList();

                 

                    if (!IsPostBack)
                    {
                        //Ödeme Bildirimi
                        OdemeBildirimiFormu();

                    }
                }
                else
                {
                    pnlNew.Visible = false;
                    
                    Response.AddHeader("Refresh", "0;URL=/giris");
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
        protected void OdemeBildirimiFormu()
        {
            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();

            //Üyeleri Listeliyoruz
            var Uyeler = from c in nt.tbl_Uyeler
                         where c.Durum == true && c.Aktif == true && c.uye_ID == uyeID
                         orderby c.Adi, c.Soyadi ascending
                         select new { AdSoyad = c.Adi + " " + c.Soyadi, c.uye_ID };

            ddUyeler.DataSource = Uyeler.ToList();
            ddUyeler.DataValueField = "uye_ID";
            ddUyeler.DataTextField = "AdSoyad";
            ddUyeler.DataBind();
            ddUyeler.SelectedValue = Session["uye_ID"].ToString();
            ddUyeler.Enabled = false;

            //Makinaları Listeliyoruz
            DateTime simdi = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-ddTHH:mm"));
            var Makinalar = from c in nt.tbl_Makinalar
                            where c.Durum == true && c.Ihale == true && c.Statu == 2 && simdi < c.Ihale_Bitis
                            orderby c.Kayit_Tarihi, c.Baslik ascending
                            select c;

            ddMakina.DataSource = Makinalar.ToList();
            ddMakina.DataValueField = "makina_ID";
            ddMakina.DataTextField = "Baslik";
            ddMakina.DataBind();
            ListItem liy = new ListItem("Ödeme Yapılacak Makina", "0");
            ddMakina.Items.Add(liy);
            ddMakina.SelectedValue = "0";

            //Yapılan Ödeme Bildilerimleri Listeleniyor
            var makinalar = from c in nt.tbl_OdemeBildirimleri
                            join D in nt.tbl_Makinalar on c.makina_ID equals D.makina_ID
                            join M in nt.tbl_Uyeler on c.uye_ID equals M.uye_ID
                            where c.Durum == true && c.uye_ID == uyeID
                            orderby c.Kayit_Tarihi descending
                            select new
                            {
                                c.uye_ID,
                                c.makina_ID,
                                c.Kayit_Tarihi,
                                c.odeme_ID,
                                c.Verilen_Fiyat,
                                c.DekontNo,
                                c.Dekont,
                                c.Banka,
                                c.Aciklama,
                                D.Baslik,
                                AdSoyad = M.Adi + " " + M.Soyadi,
                            };

            grdOdemeler.DataSource = makinalar.ToList();
            grdOdemeler.DataBind();
        }
        protected void grdOdemeler_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Sıra Numarası Ekleme
                (e.Row.FindControl("lblSira") as Label).Text = (e.Row.RowIndex + 1 + (grdOdemeler.PageIndex * 150)).ToString() + ".";
                //Sıra Numarası Ekleme

                //Ihale
                Literal ihalelt = (Literal)e.Row.FindControl("ltIhale");
                int uyeID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "uye_ID").ToString());
                int makinaID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "makina_ID").ToString());

                //Daha önce eklenmemişse ekliyoruz
                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
                var Veriler = (from c in Gs.tbl_MakinaIhale
                               where c.makina_ID == makinaID && c.uye_ID == uyeID
                               select c);
                if (Veriler.Count() == 0)
                {
                    ihalelt.Text = "<img src=/images/uncheck.png>";
                }
                else
                {
                    ihalelt.Text = "<img src=/images/check.png>";
                }


                //Dosya
                Literal dosyalt = (Literal)e.Row.FindControl("ltDosya");
                string dosya = "";
                string dosyam = DataBinder.Eval(e.Row.DataItem, "Dekont").ToString();
                dosya = Convert.IsDBNull(dosyam) ? "" : (String)dosyam;
                if (string.IsNullOrEmpty(dosya) == true)
                {
                    dosyalt.Text = "";
                }
                else
                {
                    dosyalt.Text = "<a href=http://www.sifirgibimakine.com/admin/Uploads/" + DataBinder.Eval(e.Row.DataItem, "Dekont").ToString() + " target=_blank>Görüntüle</a>";
                }

            }
        }

        protected void ddMakina_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gelen Makina bilgisine göre fiyatları Listeliyoruz
            int makinaID = Int32.Parse(ddMakina.SelectedItem.Value);
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var Makina = from c in Gs.tbl_Makinalar
                         where c.Durum == true && c.makina_ID == makinaID && c.Ihale == true
                         orderby c.Baslik ascending
                         select c;
            foreach (var prod in Makina)
            {
                txtFiyat.Text = prod.Kapora;
                ddParaBirimi.SelectedValue = prod.Para_Birimi.ToString();
            }

        }
        protected void btnSaveOdeme_Click(object sender, EventArgs e)
        {
            try
            {

                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
                tbl_OdemeBildirimleri odemeler = new tbl_OdemeBildirimleri();

                odemeler.Banka = txtBanka.Text;
                odemeler.DekontNo = txtDekontNo.Text;
                odemeler.Aciklama = txtCKeditor.Text;
                odemeler.makina_ID = Convert.ToInt32(ddMakina.SelectedItem.Value.ToString());
                odemeler.uye_ID = Convert.ToInt32(ddUyeler.SelectedItem.Value.ToString());
                odemeler.Verilen_Fiyat = Convert.ToDecimal(txtFiyat.Text);

                //Image Save
                if (uplDekont.HasFile == true)
                {
                    string[] dosyasonuc = DosyaYukleDekont();
                    odemeler.Dekont = dosyasonuc[0];
                }
                else
                {
                    odemeler.Dekont = "";
                }


                odemeler.Durum = true;
                odemeler.Kayit_Tarihi = DateTime.Now;
                Gs.tbl_OdemeBildirimleri.Add(odemeler);
                Gs.SaveChanges();


                //Loglama
                log4net.Config.XmlConfigurator.Configure();
                log.Info("Ödeme Bildirimi Eklendi-" + "Üye Adı:" + ddUyeler.SelectedItem.Text.ToString() + "-İşlemi Yapan:" + ddUyeler.SelectedItem.Text.ToString());

                //Adminne mail gönderiyoruz
                mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. Ödeme Bildirim formu ayrıntıları aşağıda yer almaktadır. <br /><br/><br/><strong>Üye Adı Soyadı:</strong> " + Session["AdSoyad"].ToString() + "<br/><strong>Banka:</strong> " + txtBanka.Text + "<br /><strong>Dekont No:</strong> " + txtDekontNo.Text + "<br /><strong>Yatırılan Ücret:</strong> " + txtFiyat.Text + ddParaBirimi.SelectedItem.Text + "<br /><strong>Makina:</strong>" + ddMakina.SelectedItem.Text + "<br /><br /><strong>Açıklama:</strong><br /><br />" + txtCKeditor.Text + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                BenimMailim = new Mailler();
                BenimMailim.Send_EMail("Ödeme Bildirimi", mailaciklama, "", "");

                //İşlem bittikten sonra yönlendirme yapılıyor
                pnlNew.Visible = false;
                PnlFinish.Visible = true;
                lblStatus.Text = "Ödeme kaydınız kontrol edilmek üzere başarılı bir şekilde gönderilmiştir. Lütfen bekleyiniz ilgili sayfaya yönlendiriliyorsunuz";
                Response.AddHeader("Refresh", "1;URL=/odeme-bildirimi");
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0}", ex));
            }


        }
        public string[] DosyaYukleDekont()
        {
            string[] dosyaisimler = new string[2];
            string dosyaismiorj = "";
            string dosyaismi = "";
            if (uplDekont.HasFile)
            {
                try
                {
                    string deger = Guid.NewGuid().ToString("N");
                    FileInfo fi = new FileInfo(uplDekont.FileName);
                    string uzanti = fi.Extension;
                    if (uzanti == ".jpg" || uzanti == ".JPG" || uzanti == ".gif" || uzanti == ".bmp" || uzanti == ".png" || uzanti == ".PNG" || uzanti == ".jpeg" || uzanti == ".doc" || uzanti == ".docx" || uzanti == ".pdf" || uzanti == ".ppt" || uzanti == ".pptx")
                    {
                        dosyaismiorj = deger;
                        dosyaismi = deger + uzanti;
                        uplDekont.PostedFile.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()) + dosyaismi);

                        uplDekont.Dispose();
                    }
                }
                catch
                {
                    dosyaismiorj = "";
                }
            }
            else
            {

                dosyaismiorj = "";
            }
            dosyaisimler[0] = dosyaismi;


            return dosyaisimler;
        }

    }
}