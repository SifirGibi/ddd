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
    public partial class MakinamNeEder : System.Web.UI.Page
    {
        Mailler BenimMailim;
        private string mailaciklama = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
                string Lang = Session["Lang"].ToString();

                /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////
                Master.Page.Title = "Makinam Ne Eder | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
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
                        //Makinam Ne Eder Formu
                        MakinamNeEderGoster();
                        ListItem liss = new ListItem("Makine Alt Türü", "0");
                        ddTurlerAlt.Items.Add(liss);

                        ListItem lisf = new ListItem("Makine Diğer Alt Türü", "0");
                        ddTurlerAlt2.Items.Add(lisf);
                    }
                }
                else
                {
                    pnlMakinamNeEderNew.Visible = false;
                    
                    Response.AddHeader("Refresh", "0;URL=/giris?ReturnUrl="+HttpUtility.UrlEncode(Request.Url.PathAndQuery));
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
        protected void MakinamNeEderGoster()
        {
            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            try
            {
                //Makina Sayısı
                var MTMakina = (from c in nt.tbl_MakinamNeEder
                                where c.uye_ID == uyeID
                                select c).Count();

                lblDegerlendirmeSayisi.Text = "Şu ana kadar değerlendirilmeye gönderilmiş makina sayınız: <strong>" + MTMakina.ToString() + "</strong> adet";

                //Türleri Listeliyoruz
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

     
                    //Makinaları Listeliyoruz
                    db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
                    var makinalar = from c in Gs.tbl_MakinamNeEder
                                    join U in Gs.tbl_Uyeler on c.uye_ID equals U.uye_ID
                                    join M in Gs.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                                    join T in Gs.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                                    join Y in Gs.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                                    where c.uye_ID == uyeID
                                    orderby c.Kayit_Tarihi descending
                                    select new
                                    {
                                        c.makinamneeder_ID,
                                        c.Baslik,
                                        c.Durum,
                                        c.Kayit_Tarihi,
                                        Yil = Y.Kategori,
                                        Tur = T.Kategori,
                                        Marka = M.Kategori,
                                        c.Fotograf,
                                        c.Rapor,
                                        c.Para_Birimi,
                                        c.Para_Birimi_Ongorulen,
                                        c.OngorulenFiyat,
                                        c.Fiyat,
                                    };

                grdMakinamNeEder.DataSource = makinalar.ToList();
                grdMakinamNeEder.DataBind();

            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0} / {1}", "", ex));
            }

        }

        protected void grdMakinamNeEder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Sıra Numarası Ekleme
                (e.Row.FindControl("lblSira") as Label).Text = (e.Row.RowIndex + 1 + (grdMakinamNeEder.PageIndex * 150)).ToString() + ".";
                //Sıra Numarası Ekleme

               

                //Fiyat Bilgisi
                Literal ongorulenfiyatlt = (Literal)e.Row.FindControl("ltOngorulen");
                Literal degerlendirilenfiyatlt = (Literal)e.Row.FindControl("ltDegerlendirilen");

                string parabirimiongorulen = DataBinder.Eval(e.Row.DataItem, "Para_Birimi_Ongorulen").ToString();
                string parabirimi = DataBinder.Eval(e.Row.DataItem, "Para_Birimi").ToString();
                

                string fiyat = DataBinder.Eval(e.Row.DataItem, "Fiyat").ToString();
                string ongorulenfiyat = DataBinder.Eval(e.Row.DataItem, "OngorulenFiyat").ToString();

                //Para Birimi
                if (parabirimi == "1")
                {
                    degerlendirilenfiyatlt.Text = fiyat + " &#8378";
                    
                }
                else if (parabirimi == "2")
                {
                    degerlendirilenfiyatlt.Text = fiyat + " &euro;";

                }
                else if (parabirimi == "3")
                {
                    degerlendirilenfiyatlt.Text = fiyat + " $";
                }

                if (parabirimiongorulen == "1")
                {
                    ongorulenfiyatlt.Text = ongorulenfiyat + " &#8378";

                }
                else if (parabirimiongorulen == "2")
                {
                    ongorulenfiyatlt.Text = ongorulenfiyat + " &euro;";

                }
                else if (parabirimiongorulen == "3")
                {
                    ongorulenfiyatlt.Text = ongorulenfiyat + " $";
                }

                
            }
        }

        protected void btnMakinamNeEder_Click(object sender, EventArgs e)
        {
            try
            {
                int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                tbl_MakinamNeEder makinalar = new tbl_MakinamNeEder();
                makinalar.Baslik = txtMakinaBaslik.Text;
                makinalar.Aciklama = txtAciklama.Text;
                makinalar.yil_ID = Convert.ToInt32(ddYillar.SelectedItem.Value.ToString());
                makinalar.marka_ID = Convert.ToInt32(ddMarkalar.SelectedItem.Value.ToString());
                makinalar.tur_ID = Convert.ToInt32(ddTurler.SelectedItem.Value.ToString());
                makinalar.Alttur_ID = Convert.ToInt32(ddTurlerAlt.SelectedItem.Value.ToString());
                makinalar.Alttur2_ID = Convert.ToInt32(ddTurlerAlt2.SelectedItem.Value.ToString());
                makinalar.Model = txtModel.Text;
                makinalar.IP = Convert.ToString(HttpContext.Current.Request.UserHostAddress);
                makinalar.OngorulenFiyat = txtOngorulenFiyat.Text;
                makinalar.Para_Birimi_Ongorulen = Convert.ToInt32(ddOnGorulenParaBirimi.SelectedItem.Value.ToString());
                makinalar.Para_Birimi = Convert.ToInt32(ddOnGorulenParaBirimi.SelectedItem.Value.ToString());
                makinalar.Fiyat = "";
                makinalar.Fotograf = "";
                makinalar.uye_ID = uyeID;
                makinalar.Durum = false;
                makinalar.Yanit = false;
                makinalar.Kayit_Tarihi = DateTime.Now;
                nt.tbl_MakinamNeEder.Add(makinalar);
                nt.SaveChanges();

                //Son Eklenen Kayıtın ID'sini alıyoruz
                int MakinaID = makinalar.makinamneeder_ID;

                //Multi Upload
                //Image Save
                if (uplResimler.HasFile == true)
                {
                    tbl_MakinamNeEderResimler makinaResimler = new tbl_MakinamNeEderResimler();

                    string dosyaismiorj = "";
                    string dosyaismi = "";
                    foreach (HttpPostedFile resimlerimiz in uplResimler.PostedFiles)
                    {
                        string deger = Guid.NewGuid().ToString("N");
                        FileInfo fi = new FileInfo(uplResimler.FileName);
                        string uzanti = fi.Extension;
                        if (uzanti == ".jpg" || uzanti == ".gif" || uzanti == ".bmp" || uzanti == ".png" || uzanti == ".jpeg" || uzanti == ".JPG" || uzanti == ".PNG" || uzanti == ".JPEG" || uzanti == ".gif" || uzanti == ".BMP" || uzanti == ".GIF")
                        {
                            dosyaismiorj = deger;
                            dosyaismi = deger + uzanti;
                            resimlerimiz.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["imagePath"].ToString()) + dosyaismi);

                            //Kayıt
                            makinaResimler.Durum = true;
                            makinaResimler.Kayit_Tarihi = DateTime.Now;
                            makinaResimler.makinamneeder_ID = MakinaID;
                            makinaResimler.Fotograf = dosyaismi;
                            nt.tbl_MakinamNeEderResimler.Add(makinaResimler);
                            nt.SaveChanges();
                        }

                    }
                }
                //Multi Upload Bitti


                //Mail İçin Makina Resimlerini Alıyoruz
                string resimyazisi = "<strong>Makinaya ait resimler;</strong> <br>";
                int sayi = 0;
              
                var DigerResimler = from c in nt.tbl_MakinamNeEderResimler
                               where c.makinamneeder_ID == MakinaID
                               select new { c.Fotograf };
                foreach (var prod in DigerResimler)
                {
                    sayi += 1;
                    resimyazisi += "<a href=https://admin.sifirgibimakine.com/Uploads/" + prod.Fotograf + " target=_blank>Resim-"+ sayi +"</a><br/>";
                }



                //Admine mail gönderiyoruz
                mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. Makina Ne Eder formu ayrıntıları aşağıda yer almaktadır. <br /><br/><br/><strong>Üye Adı Soyadı:</strong> " + Session["AdSoyad"].ToString() + "<br/><strong>Başlık:</strong> " + txtMakinaBaslik.Text + "<br /><strong>Tür:</strong> " + ddTurler.SelectedItem.Text + "<br /><strong>Alt Kategori:</strong> " + ddTurlerAlt.SelectedItem.Text + "<br/><strong>Marka:</strong> " + ddMarkalar.SelectedItem.Text + "<br /><strong>Yıl:</strong>" + ddYillar.SelectedItem.Text + "<br /><strong>Model:</strong>" + txtModel.Text + "<br /><strong>Öngörülen Fiyat:</strong> " + txtOngorulenFiyat.Text + " " + ddOnGorulenParaBirimi.SelectedItem.Text + "<br /><br /><strong>Açıklama:</strong><br /><br />" + txtAciklama.Text + "<br /><br />" + resimyazisi + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                BenimMailim = new Mailler();
                BenimMailim.Send_EMail("Makinam Ne Eder Formu", mailaciklama, "", "");

                //Kiiye mail gönderiyoruz
                //mailaciklama = "Sayın " + Session["AdSoyad"].ToString() + ",<br/><br/>Makina değerlendirme talebiniz <strong>" + DateTime.Now + "</strong> tarihinde alınmıştır. En kısa sürede sizinle iletişime geçilecektir.<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                //BenimMailim = new Mailler();
                //BenimMailim.Send_EMail("Makinam Ne Eder", mailaciklama, Session["Email"].ToString(), "");

                //Mail gönder
                var Sorgu = from c in nt.tbl_MakinamNeEder
                            join U in nt.tbl_Uyeler on c.uye_ID equals U.uye_ID
                            where c.makinamneeder_ID == MakinaID
                            select new { AdSoyad = U.Adi + " " + U.Soyadi, c.Baslik, c.Rapor, c.OngorulenFiyat, c.Para_Birimi_Ongorulen, U.EMail, c.Fotograf };

                //Gelen veriye göre tabloları dolduruyoruz
                foreach (var prod in Sorgu)
                {

                    //Ana Resim

                    var urunresimsorgu = from c in nt.tbl_MakinamNeEderResimler
                                         where c.Durum == true && c.makinamneeder_ID == MakinaID
                                         select c;

                    foreach (var prods in urunresimsorgu)
                    {
                        string[] a = prods.Fotograf.Split('.');
                        Session["Fotograf"] = a[0] + "." + a[1];
                    }

                    if (urunresimsorgu.Count() == 0)
                    {
                        Session["Fotograf"] = "ornekfoto.jpg";
                    }

                    BenimMailim = new Mailler();
                    string mailBody = BenimMailim.SetMakineDegerlendirmeMail(prod.Baslik, Session["Fotograf"].ToString(), prod.OngorulenFiyat, prod.Para_Birimi_Ongorulen.ToString());
                    BenimMailim.Send_EMail("Makinam Ne Eder", mailBody, prod.EMail, "");

                }



                //İşlem bittikten sonra yönlendirme yapılıyor
                pnlMakinamNeEderNew.Visible = false;
                MakinamNeEderFinish.Visible = true;
                ltMakinamNeEderStatus.Text = "<i class='fa fa-exclamation-circle'></i> <span class='text-success'>Makinanınızın fiyat değerlemesi için uzman ekibimize iletilmiştir. En yakın zamanda sizinle iletişime geçilecektir. Lütfen bekleyiniz ilgili sayfaya yönlendiriliyorsunuz.</span>";
                Response.AddHeader("Refresh", "2;URL=/makinam-ne-eder");

            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHataMesaji.Text = Dil.Res.HataMesaji;
                lblHata.Text = Dil.Res.Hata;
                log.Error(string.Format("{0} / {1}", "", ex));
            }
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

            ddTurlerAlt.Items.Insert(0, new ListItem("Makine Alt Türü", "0"));


            //2. Alt Tür

            ddTurlerAlt2.Items.Clear();     
            ddTurlerAlt2.Items.Insert(0, new ListItem(" ", "0"));
     
        }

        protected void ddTurlerAlt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gelen bilgiye göre alt kategorileri dolduruyoruz.
            ddTurlerAlt2.Items.Clear();
            int kategoriID = Int32.Parse(ddTurlerAlt.SelectedItem.Value);
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var AltKategori = from c in Gs.tbl_MakinaAltTurleri2
                              where c.Durum == true && c.Alttur_ID == kategoriID
                              orderby c.Kategori ascending
                              select c;

            ddTurlerAlt2.DataSource = AltKategori.ToList();
            ddTurlerAlt2.DataValueField = "Alttur2_ID";
            ddTurlerAlt2.DataTextField = "Kategori";
            ddTurlerAlt2.DataBind();

            if (AltKategori.Count()==0)
            {
                ddTurlerAlt2.Items.Insert(0, new ListItem(" ", "0"));
                //ListItem lisf = new ListItem(" ", "0");
                //ddTurlerAlt2.Items.Add(lisf);
            }
        }

    }
}