using MessagingToolkit.QRCode.Codec;
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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SifirGibiMakina
{
    public partial class Makinalarim : System.Web.UI.Page
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
                Master.Page.Title = "Makinalarim | " + WebConfigurationManager.AppSettings["MikroSiteAdi"];
                Master.Page.MetaDescription = "Sifirgibimakine.com makinalarım sayfası. İkinci el CNC Makinaları ve talaşlı iş makinaları.";
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
                        //Makinalar
                        MakinalariGoster();

                    }

                    if (RouteData.Values["DeleteimageID"] != null)
                    {
                        deleteImage(int.Parse(RouteData.Values["DeleteimageID"].ToString()));
                    }
                    if (RouteData.Values["VitrinimageID"] != null)
                    {
                        vitrinImage(int.Parse(RouteData.Values["VitrinimageID"].ToString()));
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

        protected void MakinalariGoster()
        {
            //Makinaları Listeliyoruz
            int uyeID = Convert.ToInt32(Session["uye_ID"].ToString());
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            var makinalar = from c in Gs.tbl_Makinalar
                            join D in Gs.tbl_Diller on c.dil_ID equals D.dil_ID
                            join M in Gs.tbl_MakinaMarkalari on c.marka_ID equals M.marka_ID
                            join T in Gs.tbl_MakinaTurleri on c.tur_ID equals T.tur_ID
                            join Y in Gs.tbl_MakinaYillar on c.yil_ID equals Y.yil_ID
                            where c.Durum == true && c.Ekleyen == uyeID
                            orderby c.Yayinda descending, c.Kayit_Tarihi descending
                            select new
                            {
                                c.makina_ID,
                                c.Ust_FirmaID,
                                c.Baslik,
                                c.SosyalMedyaPaylasim,
                                c.SeoKeywords,
                                c.SeoDescription,
                                c.dil_ID,
                                c.Durum,
                                c.Kayit_Tarihi,
                                D.Dil,
                                Yil = Y.Kategori,
                                Tur = T.Kategori,
                                Marka = M.Kategori,
                                c.Aciklama,
                                c.Ekleyen,
                                c.Firma_ID,
                                c.Fiyat,
                                c.Fotograf,
                                c.Ihale,
                                c.Ihale_Acilis_Fiyat,
                                c.Ihale_Baslangic,
                                c.Ihale_Bitis,
                                c.IP,
                                c.Kimden,
                                c.KM,
                                c.Makina_Order,
                                c.marka_ID,
                                c.Para_Birimi,
                                c.Statu,
                                c.Yayinda,
                                c.StokGelis_Tarihi,
                                c.GoruntulenmeSayisi,
                                c.FavoriSayisi,
                                c.IlanNo,
                                c.FiyatGosterilmesin,
                            };
            if(makinalar.Count() == 0)
            {


                pnlWithData.Visible = false;
                pnlNonData.Visible = true;
            }
            else
            {
                pnlWithData.Visible = true;
                pnlNonData.Visible = false;
                grdMakinalar.DataSource = makinalar.ToList();
                grdMakinalar.DataBind();

            }
    

        }

        protected void grdMakinalar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int makinaID = Convert.ToInt32(grdMakinalar.DataKeys[e.RowIndex].Values["makina_ID"].ToString());
                hdKaldirID.Value = makinaID.ToString();
                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();


                //Panelleri açıp kapatıyoruz
                pnlData.Visible = false;
                pnlNew.Visible = false;
                pnlYayindanKaldir.Visible = true;

                var Sorgu = from c in Gs.tbl_Makinalar
                            where c.makina_ID == makinaID
                            select c;

                //Gelen veriye göre tabloları dolduruyoruz
                foreach (var prod in Sorgu)
                {
                    ltilanbilgi.Text = "<strong>İlan No:</strong>" + prod.IlanNo + "<br/><strong>İlan Başlığı:</strong>" + prod.Baslik + "<br><br>Lütfen aşağıdan gerekli seçeneği seçerek <strong>Yayından Kaldır</strong> butonuna tıklayınız.";
                }


            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0} / {1}", "", ex));
            }
        }

        protected void grdMakinalar_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Sıra Numarası Ekleme
                (e.Row.FindControl("lblSira") as Label).Text = (e.Row.RowIndex + 1 + (grdMakinalar.PageIndex * 150)).ToString() + ".";
                //Sıra Numarası Ekleme



                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

                //Yayında
                Literal yayinlt = (Literal)e.Row.FindControl("ltYayin");
                string yayin = DataBinder.Eval(e.Row.DataItem, "Yayinda").ToString();
                string statu = DataBinder.Eval(e.Row.DataItem, "Statu").ToString();
                if (yayin == "True" && statu == "2")
                {
                    yayinlt.Text = "<img src=/images/check.png>";
                    ImageButton sil = (ImageButton)e.Row.FindControl("LinkButton3");
                    sil.Visible = true;

                    ImageButton duzenle = (ImageButton)e.Row.FindControl("LinkButton2");
                    duzenle.Visible = true;
                }
                else if (yayin == "False" && statu == "2")
                {
                    yayinlt.Text = "<img src=/images/uncheck.png>";
                    ImageButton duzenle = (ImageButton)e.Row.FindControl("LinkButton2");
                    duzenle.Visible = false;
                }
                else if (yayin == "False" && statu == "1")
                {
                    yayinlt.Text = "<img src=/images/uncheck.png>";
                    ImageButton duzenle = (ImageButton)e.Row.FindControl("LinkButton2");
                    duzenle.Visible = true;
                }

                else
                { yayinlt.Text = "<img src=/images/uncheck.png>"; }

                if (yayin == "False" && statu == "6")
                {
                    ImageButton yayinaal = (ImageButton)e.Row.FindControl("LinkButtonYayin");
                    yayinaal.Visible = true;

                    Button yayinaalbtn = (Button)e.Row.FindControl("btnYayin");
                    yayinaalbtn.Visible = true;
                }

                //Ihale
                Literal ihalelt = (Literal)e.Row.FindControl("ltIhale");
                string ihale = DataBinder.Eval(e.Row.DataItem, "Ihale").ToString();
                if (ihale == "True")
                { ihalelt.Text = "<img src=/images/check.png>"; }
                else
                { ihalelt.Text = "<img src=/images/uncheck.png>"; }

                //Durum
                // Eğer dropdownlist bulunduysa, durumu güncelle
                if (TryFindDropdown(e.Row, out DropDownList ddlDurum))
                {
                    string selectedDurum = GetSelectedDurum(e.Row);

                    if (IsSpecialState(selectedDurum))
                    {
                        SetDropdownForSpecialStates(ddlDurum, selectedDurum);
                    }
                    else
                    {
                        UpdateDropdownBasedOnState(ddlDurum, selectedDurum);
                    }
                }
                //Resim
                Literal resimlt = (Literal)e.Row.FindControl("ltResim");


                string foto = "";
                foto = Convert.IsDBNull(DataBinder.Eval(e.Row.DataItem, "Fotograf")) ? "" : (String)DataBinder.Eval(e.Row.DataItem, "Fotograf");
                int makinaid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "makina_ID").ToString());

                //Ana Resim
                var urunresimsorgu = from c in Gs.tbl_MakinaResimler
                                     where c.Durum == true && c.Vitrin == true && c.makina_ID == makinaid
                                     select c;

                foreach (var prods in urunresimsorgu)
                {
                    string[] a = prods.Fotograf.Split('.');
                    resimlt.Text = "<img src=" + ConfigurationManager.AppSettings["imagePath"] + a[0] + "_v." + a[1] + " width=70 height=90>";

                }

                if (urunresimsorgu.Count() == 0)
                {
                    resimlt.Text = "<img src=" + ConfigurationManager.AppSettings["imagePath"] + "ornekfoto.jpg width=70 height=90> ";
                }
            }
        }
        // Fonksiyonlar
        private bool TryFindDropdown(GridViewRow row, out DropDownList ddl)
        {
            ddl = row.FindControl("ddlDurum") as DropDownList;
            return ddl != null;
        }

        private string GetSelectedDurum(GridViewRow row)
        {
            return DataBinder.Eval(row.DataItem, "Statu").ToString();
        }

        private bool IsSpecialState(string state)
        {
            List<string> specialStates = new List<string> { "8", "7", "4","6","1","5" };
            return specialStates.Contains(state);
        }

        private void SetDropdownForSpecialStates(DropDownList ddl, string state)
        {
            ListItem selectedItem = ddl.Items.FindByValue(state);
            ddl.Items.Clear();
            if (selectedItem != null)
            {
                ddl.Items.Add(selectedItem);
                ddl.SelectedValue = state;
                selectedItem.Enabled = true;
            }
        }

        private void UpdateDropdownBasedOnState(DropDownList ddl, string state)
        {
            ddl.Items.Clear();

            switch (state)
            {
                case "2": // "Satışta"
                    ddl.Items.Add(new ListItem("Satışta", "2"));
                    ddl.Items.Add(new ListItem("Kapalı", "3"));
                    break;
                case "3": // "Kapalı"
                    ddl.Items.Add(new ListItem("Kapalı", "3"));
                    ddl.Items.Add(new ListItem("Satışta", "2"));
                    break;
                default:
                    SetDropdownDefaultState(ddl, state);
                    break;
            }

            ddl.SelectedValue = state;
        }

        private void SetDropdownDefaultState(DropDownList ddl, string state)
        {
            ListItem selectedItem = ddl.Items.FindByValue(state);
            if (selectedItem != null && !selectedItem.Enabled)
            {
                selectedItem.Enabled = true;
            }
        }

        protected void grdMakinalar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Panelleri açıp kapatıyoruz
            pnlData.Visible = false;
            pnlNew.Visible = true;
            btnSave.Text = "Düzenle";

            //Seçilen Değer
            int i = grdMakinalar.SelectedIndex;
            int id = Convert.ToInt32(grdMakinalar.DataKeys[e.NewEditIndex].Values["makina_ID"].ToString());

            Session["MakinaID"] = Convert.ToInt32(grdMakinalar.DataKeys[e.NewEditIndex].Values["makina_ID"].ToString());

            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

            //Düzenleme Sorgumuz 
            var Sorgu = from c in Gs.tbl_Makinalar
                        where c.makina_ID == id
                        select c;

            //Gelen veriye göre tabloları dolduruyoruz
            foreach (var prod in Sorgu)
            {
                txtAdi.Text = prod.Baslik;
                txtCKeditor.Text = prod.Aciklama;
                txtFiyat.Text = prod.Fiyat.ToString();
                txtKM.Text = prod.KM;
                txtModel.Text = prod.Model;
                txtil.Text = prod.il;
                txtIlce.Text = prod.ilce;
                ddParaBirimi.SelectedValue = prod.Para_Birimi.ToString();

                //Mevcut Statusu
                if (prod.Ihale_Baslangic.ToString() != "1.01.1753 00:00:00")
                { txtIhaleBaslangicTarihi.Text = prod.Ihale_Baslangic.Value.ToString("yyyy-MM-ddTHH:mm"); }
                if (prod.Ihale_Bitis.ToString() != "1.01.1753 00:00:00")
                { txtIhaleBitisTarihi.Text = prod.Ihale_Bitis.Value.ToString("yyyy-MM-ddTHH:mm"); }
                txtIhaleBaslangicFiyati.Text = prod.Ihale_Acilis_Fiyat.ToString();
                txtMinSatisFiyati.Text = prod.Minimum_Satis_Fiyati.ToString();
                txtKapora.Text = prod.Kapora;
                txtSatisTemsilcisiAdi.Text = prod.Satis_Temsilcisi_Adi;
                txtSatisTemsilcisiEmail.Text = prod.Satis_Temsilcisi_Email;
                txtSatisTemsilcisiTelefon.Text = prod.Satis_Temsilcisi_Telefon;

                //Türleri Listeliyoruz
                var Turler = from c in Gs.tbl_MakinaTurleri
                             where c.dil_ID == 1
                             orderby c.Kategori ascending
                             select c;

                ddTurler.DataSource = Turler.ToList();
                ddTurler.DataValueField = "tur_ID";
                ddTurler.DataTextField = "Kategori";
                ddTurler.DataBind();
                ddTurler.SelectedValue = prod.tur_ID.ToString();
                ddTurler.Enabled = false;
                //AltKaregorileri Listeliyoruz
                var AltKategori = from c in Gs.tbl_MakinaAltTurleri
                                  where c.Durum == true && c.dil_ID == prod.dil_ID && c.tur_ID == prod.tur_ID
                                  orderby c.Kategori ascending
                                  select c;

                ddTurlerAlt.DataSource = AltKategori.ToList();
                ddTurlerAlt.DataValueField = "Alttur_ID";
                ddTurlerAlt.DataTextField = "Kategori";
                ddTurlerAlt.DataBind();
                ddTurlerAlt.Enabled = false;
                ddTurlerAlt.SelectedValue = prod.Alttur_ID.ToString();

                //Yılları Listeliyoruz
                var Yillar = from c in Gs.tbl_MakinaYillar
                             where c.dil_ID == 1
                             orderby c.Kategori ascending
                             select c;

                ddYillar.DataSource = Yillar.ToList();
                ddYillar.DataValueField = "yil_ID";
                ddYillar.DataTextField = "Kategori";
                ddYillar.DataBind();
                ddYillar.SelectedValue = prod.yil_ID.ToString();

                //Markaları Listeliyoruz
                var Markalar = from c in Gs.tbl_MakinaMarkalari
                               where c.dil_ID == 1
                               orderby c.Kategori ascending
                               select c;

                ddMarkalar.DataSource = Markalar.ToList();
                ddMarkalar.DataValueField = "marka_ID";
                ddMarkalar.DataTextField = "Kategori";
                ddMarkalar.DataBind();
                ddMarkalar.SelectedValue = prod.marka_ID.ToString();

                //Ülkeleri Listeliyoruz
                var Ulkeler = from c in Gs.tbl_Ulkeler
                              orderby c.nicename ascending
                              select c;

                ddUlkeler.DataSource = Ulkeler.ToList();
                ddUlkeler.DataValueField = "id";
                ddUlkeler.DataTextField = "nicename";
                ddUlkeler.DataBind();
                ddUlkeler.SelectedValue = prod.Ulke.ToString();


                if (prod.Ihale == true)
                {
                    ddIhale.SelectedValue = "1";
                }
                else
                {
                    ddIhale.SelectedValue = "0";
                }

                if (prod.EksperTalebi == true)
                {
                    chkEksper.Checked = true;
                }

                if (prod.FiyatGosterilmesin == true)
                {
                    chkFiyatGosterilmesin.Checked = true;
                }


                //Resimleri Goster
                var images = from c in Gs.tbl_MakinaResimler
                             where c.Durum == true && c.makina_ID == id
                             select c;
                lstPhotos.DataSource = images.ToList();
                lstPhotos.DataBind();


                hdID.Value = prod.makina_ID.ToString();

                GridViewDoldurEksper();
            }
        }

        protected void GridViewDoldurEksper()
        {
            try
            {
                //Data List
                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
                var ozellikler = from c in Gs.tbl_MakinaEksper
                                 where c.Durum == true
                                 orderby c.Kategori ascending
                                 select new
                                 {
                                     c.Kategori,
                                     c.eksper_ID,
                                 };

                grdOzellikler.DataSource = ozellikler.ToList();
                grdOzellikler.DataBind();
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0} / {1}", "", ex));

            }
        }

        protected void imgPhotoBtn_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
                //Save
                if (hdID.Value != "")
                {
                    int id = Convert.ToInt32(hdID.Value);
                    //bu bölümü yapalım
                    var Guncelle = (from c in Gs.tbl_Makinalar
                                    where c.makina_ID == id && c.Durum == true
                                    select c).First();
                    Guncelle.Fotograf = null;
                    Gs.SaveChanges();
                }

                Response.AddHeader("Refresh", "0;URL=/makinalarim");
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0} / {1}", "", ex));

            }
        }

        protected void grdOzellikler_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Sıra Numarası Ekleme
                (e.Row.FindControl("lblSira") as Label).Text = (e.Row.RowIndex + 1 + (grdOzellikler.PageIndex * 500)).ToString() + ".";
                //Sıra Numarası Ekleme

                //Durumuna Göre Literale yazdırıyoruz

                DropDownList notu = (DropDownList)e.Row.FindControl("ddOzellikNot");

                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
                int eksperID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "eksper_ID"));

                if (hdID.Value != "")
                {
                    int makinaID = Convert.ToInt32(hdID.Value);
                    var Sorgu = (from c in Gs.tbl_MakinaEksperSecimi
                                 where c.makina_ID == makinaID && c.eksper_ID == eksperID
                                 select c);

                    foreach (var prod in Sorgu)
                    {
                        if (Sorgu.Count() > 0)
                        {
                            notu.SelectedValue = prod.Note.ToString();
                        }
                    }

                }
            }
        }

        protected void ddIhale_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gelen İhale bilgisine göre bilgileri değiştiriyoruz
            int ihale = Int32.Parse(ddIhale.SelectedItem.Value);
            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

            if (ihale == 1)
            {
                pnlIhale.Visible = true;
            }
            else
            {
                pnlIhale.Visible = false;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
                tbl_Makinalar makinalar = new tbl_Makinalar();
                tbl_MakinaEksperSecimi makinaEksper = new tbl_MakinaEksperSecimi();
                if (hdID.Value != "")
                {

                    int id = Convert.ToInt32(hdID.Value);
                    var Guncelle = (from c in Gs.tbl_Makinalar
                                    where c.makina_ID == id
                                    select c).First();

                    Guncelle.Baslik = txtAdi.Text;
                    Guncelle.BaslikEN = Translate.OtomatikCeviri(txtAdi.Text, "EN");
                    Guncelle.BaslikDE = Translate.OtomatikCeviri(txtAdi.Text, "DE");
                    Guncelle.BaslikRU = Translate.OtomatikCeviri(txtAdi.Text, "RU");
                    Guncelle.Aciklama = txtCKeditor.Text;
                    Guncelle.AciklamaEN = Translate.OtomatikCeviri(txtCKeditor.Text, "EN");
                    Guncelle.AciklamaDE = Translate.OtomatikCeviri(txtCKeditor.Text, "DE");
                    Guncelle.AciklamaRU = Translate.OtomatikCeviri(txtCKeditor.Text, "RU");
                    Guncelle.yil_ID = Convert.ToInt32(ddYillar.SelectedItem.Value.ToString());
                    Guncelle.marka_ID = Convert.ToInt32(ddMarkalar.SelectedItem.Value.ToString());
                    Guncelle.tur_ID = Convert.ToInt32(ddTurler.SelectedItem.Value.ToString());
                    Guncelle.Fiyat = Convert.ToInt32(txtFiyat.Text);
                    Guncelle.KM = txtKM.Text;
                    Guncelle.Model = txtModel.Text;
                    Guncelle.Para_Birimi = Convert.ToInt32(ddParaBirimi.SelectedItem.Value.ToString());

                    //Eğer ilan yayınlanmadan önce bilgi değişikliği yapılırsa statusunu değiştir
                    var Durum = (from c in Gs.tbl_Makinalar
                                 where c.makina_ID == id
                                 select c);
                    foreach (var prod in Durum)
                    {
                        if (prod.Statu == 1)
                        {
                            Guncelle.Statu = 1;
                        }
                        else
                        {
                            Guncelle.Statu = 8;
                        }
                    }

                    Guncelle.Kapora = txtKapora.Text;
                    Guncelle.Satis_Temsilcisi_Adi = txtSatisTemsilcisiAdi.Text;
                    Guncelle.Satis_Temsilcisi_Email = txtSatisTemsilcisiEmail.Text;
                    Guncelle.Satis_Temsilcisi_Telefon = txtSatisTemsilcisiTelefon.Text;
                    Guncelle.Ulke = Convert.ToInt32(ddUlkeler.SelectedItem.Value.ToString());
                    Guncelle.il = txtil.Text;
                    Guncelle.ilce = txtIlce.Text;

                    if (txtIhaleBaslangicFiyati.Text != "")
                    {
                        Guncelle.Ihale_Acilis_Fiyat = Convert.ToDecimal(txtIhaleBaslangicFiyati.Text);
                    }
                    else
                    {
                        Guncelle.Ihale_Acilis_Fiyat = 0;
                    }
                    if (txtMinSatisFiyati.Text != "")
                    {
                        Guncelle.Minimum_Satis_Fiyati = Convert.ToDecimal(txtMinSatisFiyati.Text);
                    }
                    else
                    {
                        Guncelle.Ihale_Acilis_Fiyat = 0;
                    }
                    if (txtIhaleBaslangicTarihi.Text != "")
                    {
                        Guncelle.Ihale_Baslangic = Convert.ToDateTime(txtIhaleBaslangicTarihi.Text);
                    }
                    else
                    {
                        Guncelle.Ihale_Baslangic = SqlDateTime.MinValue.Value;
                    }

                    if (txtIhaleBitisTarihi.Text != "")
                    {
                        Guncelle.Ihale_Bitis = Convert.ToDateTime(txtIhaleBitisTarihi.Text);
                    }
                    else
                    {
                        Guncelle.Ihale_Bitis = SqlDateTime.MinValue.Value;
                    }

                    Guncelle.Yayinda = false;
                    if (Convert.ToInt32(ddIhale.SelectedItem.Value) == 1) { Guncelle.Ihale = true; } else { Guncelle.Ihale = false; }


                    if (chkEksper.Checked == true) { Guncelle.EksperTalebi = true; } else { Guncelle.EksperTalebi = false; }
                    if (chkFiyatGosterilmesin.Checked == true) { Guncelle.FiyatGosterilmesin = true; } else { Guncelle.FiyatGosterilmesin = false; }

                    Gs.SaveChanges();

                    //Multi Upload
                    //Image Save
                    int resimsay = 0;
                    if (uplResimler.HasFile == true)
                    {

                        tbl_MakinaResimler makinaResimleri = new tbl_MakinaResimler();
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
                                makinaResimleri.Durum = true;
                                makinaResimleri.Kayit_Tarihi = DateTime.Now;
                                makinaResimleri.makina_ID = id;
                                makinaResimleri.Fotograf = dosyaismi;
                                if (resimsay == 0)
                                {
                                    makinaResimleri.Vitrin = true;
                                }
                                else
                                {
                                    makinaResimleri.Vitrin = false;
                                }

                                Gs.tbl_MakinaResimler.Add(makinaResimleri);
                                Gs.SaveChanges();
                                resimsay += 1;
                            }
                        }
                    }
                    //Multi Upload Bitti



                    //Makina Özellikleri
                    var VeriSila = (from c in Gs.tbl_MakinaEksperSecimi
                                    where c.makina_ID == id
                                    select c);
                    foreach (var u in VeriSila)
                    {
                        Gs.tbl_MakinaEksperSecimi.Remove(u);
                    }
                    Gs.SaveChanges();


                    ////Tekrar Ekliyoruz
                    foreach (GridViewRow satir in grdOzellikler.Rows)
                    {
                        int eksperID = int.Parse(((Label)satir.FindControl("lblEksperID")).Text);
                        int durum = Convert.ToInt32(((DropDownList)satir.FindControl("ddOzellikNot")).SelectedItem.Value);

                        if (durum != 0)
                        {
                            makinaEksper.makina_ID = id;
                            makinaEksper.eksper_ID = eksperID;
                            makinaEksper.Note = durum;
                            Gs.tbl_MakinaEksperSecimi.Add(makinaEksper);
                            Gs.SaveChanges();
                        }
                    }


                    //Loglama
                    log4net.Config.XmlConfigurator.Configure();
                    log.Info("Makina Düzenlendi-" + "Makina Adı:" + txtAdi.Text + "-İşlemi Yapan:" + Session["uye_ID"].ToString());


                    //Admine mail gönderiyoruz
                    mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. Yeni bir düzenlenen ilan talebi yapılmıştır. Talep detaylarına admin panelden ulaşabilirsiniz.<br /><br/><br/><strong>Üye Adı Soyadı:</strong> " + Session["AdSoyad"].ToString() + "<br/><strong>Ürün:</strong> " + txtAdi.Text + "<br /><strong>Model:</strong> " + txtModel.Text + "<br /><strong>Fiyat:</strong> " + txtFiyat.Text + ddParaBirimi.SelectedItem.Text + "<br /><strong>Türü:</strong>" + ddTurler.SelectedItem.Text + "<br /><br /><strong>Açıklama:</strong><br /><br />" + txtCKeditor.Text + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                    BenimMailim = new Mailler();
                    BenimMailim.Send_EMail("Yeni İlan Düzenleme Bildirimi", mailaciklama, "", "");

                    //Eksper İstiyorsa E-Mail
                    if (chkEksper.Checked == true)
                    {
                        mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. Yeni bir eksper talebi yapılmıştır. Talep detaylarına admin panelden ulaşabilirsiniz.<br /><br/><br/><strong>Üye Adı Soyadı:</strong> " + Session["AdSoyad"].ToString() + "<br/><strong>Ürün:</strong> " + txtAdi.Text + "<br /><strong>Model:</strong> " + txtModel.Text + "<br /><strong>Fiyat:</strong> " + txtFiyat.Text + ddParaBirimi.SelectedItem.Text + "<br /><strong>Türü:</strong>" + ddTurler.SelectedItem.Text + "<br /><br /><strong>Açıklama:</strong><br /><br />" + txtCKeditor.Text + "<br /><br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                        BenimMailim = new Mailler();
                        BenimMailim.Send_EMail("Yeni Eksper Talebi", mailaciklama, "", "");
                    }


                    //İşlem bittikten sonra yönlendirme yapılıyor
                    pnlNew.Visible = false;
                    PnlFinish.Visible = true;
                    lblStatus.Text = "Makina ilanınız kontrol edilmek üzere başarılı bir şekilde gönderilmiştir. İlanınız kontrol edildikten sonra yayınlanacaktır. Lütfen bekleyiniz ilgili sayfaya yönlendiriliyorsunuz";
                    Response.AddHeader("Refresh", "2;URL=/makinalarim");
                }
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0}", ex));
            }


        }

        protected void btnKaldir_Click(object sender, EventArgs e)
        {
            try
            {

                db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

                if (hdKaldirID.Value != "")
                {

                    int makinaID = Convert.ToInt32(hdKaldirID.Value);


                    //Silme Sorgumuz 
                    var VeriSil = (from c in Gs.tbl_Makinalar
                                   where c.makina_ID == makinaID
                                   select c).First();


                    VeriSil.Yayinda = false;
                    VeriSil.Statu = 7;
                    VeriSil.KaldirmaSebebi = Convert.ToInt32(ddNeden.SelectedItem.Value.ToString());
                    VeriSil.KaldirmaTarihi = DateTime.Now;
                    Gs.SaveChanges();


                    var EkleyenUye = from c in Gs.tbl_Makinalar
                                     join D in Gs.tbl_Uyeler on c.Ekleyen equals D.uye_ID
                                     where c.makina_ID == makinaID
                                     select new { AdiSoyadi = D.Adi + " " + D.Soyadi, D.EMail, c.IlanNo, c.Baslik, c.Para_Birimi, c.Fiyat };
                    foreach (var uye in EkleyenUye)
                    {

                        //Ana Resim
                        var urunresimsorgu = from c in Gs.tbl_MakinaResimler
                                             where c.Durum == true && c.makina_ID == makinaID && c.Vitrin == true
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
                        string mailBody = BenimMailim.SetIlanKaldirildiMail(uye.IlanNo, uye.Baslik, Session["Fotograf"].ToString(), uye.Fiyat.ToString(), uye.Para_Birimi.ToString());
                        BenimMailim.Send_EMail("İlan Kaldırılma Bildirimi", mailBody, uye.EMail, "");

                    }

                    //Admine mail gönderiyoruz
                    BenimMailim = new Mailler();
                    mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. <br/><br/><strong>Üye Adı Soyadı:</strong> " + Session["AdSoyad"].ToString() + "<br/><strong> olan kullanıcı tarafından " + makinaID + " nolu ilan yayından kaldırılmıştır.<br /><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                    BenimMailim.Send_EMail("İlan Kaldırılma Bildirimi", mailaciklama, "", "");




                    //Loglama
                    log4net.Config.XmlConfigurator.Configure();
                    log.Info("Makina Yayından Kaldırıldı-" + "Makina ID:" + makinaID + "-İşlemi Yapan:" + Session["uye_ID"].ToString());

                    //İşlemler bittikten sonra
                    Response.AddHeader("Refresh", "0;URL=/makinalarim");

                }
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblHata.Text = "Sistem bir hata ile karşılaştı, lütfen daha sonra tekrar deneyiniz";
                log.Error(string.Format("{0}", ex));
            }


        }

        protected void grdMakinalar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Yayin")
            {
                int makinaID = Convert.ToInt32(e.CommandArgument);

                using (db_SifirGibiMakinaEntities context = new db_SifirGibiMakinaEntities())
                {
                    tbl_Makinalar obj = context.tbl_Makinalar.First(x => x.makina_ID == makinaID);
                    obj.Yayinda = true;
                    obj.Statu = 2;
                    obj.Yayinlanma_Tarihi = DateTime.Now;
                    context.SaveChanges();

                    //Admine mail gönderiyoruz
                    mailaciklama = "Sayın İlgili,<br/><br/>Bu mesaj size <strong>" + DateTime.Now + "</strong> tarihinde <strong>" + ConfigurationManager.AppSettings["MikroSiteAdi"].ToString() + "</strong> sayfasından gönderilmiştir. </strong> " + Session["AdSoyad"].ToString() + " tarafından süresi biten " + makinaID + " nolu ilan tekrar yayına alınmıştır. Kullanıcı ilan üzerinde herhangibir değişiklik gerçekleştirmemiştir.<br><hr color=green><strong>" + ConfigurationManager.AppSettings["MikroSiteAuthor"].ToString() + "</strong><br/>";
                    BenimMailim = new Mailler();
                    BenimMailim.Send_EMail("Yeni İlan Bildirimi", mailaciklama, "", "");

                    Response.Redirect("/makinalarim");
                }
            }
        }

        protected void deleteImage(int ID)
        {

            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();
            //Silme Sorgumuz 
            var VeriSil = (from c in Gs.tbl_MakinaResimler
                           where c.makinaResim_ID == ID && c.Durum == true
                           select c).SingleOrDefault();
            Gs.tbl_MakinaResimler.Remove(VeriSil);
            //VeriSil.gamePattern_Active = false;
            Gs.SaveChanges();

            //Dosyayı sunucudan siliyoruz
            File.Delete(MapPath(ConfigurationManager.AppSettings["imagePath"].ToString() + VeriSil.Fotograf));


            //Yönlendirme
            string urlm = Request.UrlReferrer.AbsoluteUri;
            Response.Redirect(urlm, false);
        }

        protected void vitrinImage(int ID)
        {

            int makinaID = Convert.ToInt32(Session["MakinaID"]);

            db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities();

            //Seçilen Makinaya Ait Tüm Resimlerde Vitrin'i kaldır
            var VeriGuncelle = from c in Gs.tbl_MakinaResimler
                               where c.makina_ID == makinaID
                               select c;
            foreach (var prod in VeriGuncelle)
            {
                prod.Vitrin = false;

            }
            Gs.SaveChanges();

            //Düzenleme
            var VeriDuzenle = (from c in Gs.tbl_MakinaResimler
                               where c.makinaResim_ID == ID && c.Durum == true
                               select c).SingleOrDefault();
            VeriDuzenle.Vitrin = true;
            Gs.SaveChanges();



            //Yönlendirme
            string urlm = Request.UrlReferrer.AbsoluteUri;
            Response.Redirect(urlm, false);
        }

        protected void lstPhotos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Literal imgActive = (Literal)e.Item.FindControl("ltVitrin");

                if (imgActive.Text == "True")
                {
                    imgActive.Text = "<i class=\"fa fa-check\"> </i>";
                }
                else { imgActive.Text = ""; }

            }
        }
        protected void ddlDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;

            if (ddl != null)
            {
                int? selectedValueInt = null;
                int tempValue;
                if (int.TryParse(ddl.SelectedValue, out tempValue))
                {
                    selectedValueInt = tempValue;
                }

                string selectedItemText = ddl.SelectedItem.Text;

                // GridView satırını alın
                GridViewRow row = (GridViewRow)ddl.NamingContainer;

                if (row != null)
                {
                    int makinaID = Convert.ToInt32(grdMakinalar.DataKeys[row.RowIndex].Values["makina_ID"].ToString());

                    UpdateStatuInDatabase(makinaID, selectedValueInt);

                    // Satırla ilgili veriyi güncelleyin
                    Label lblDurum = row.FindControl("lblDurum") as Label;

                    if (lblDurum != null)
                    {
                        lblDurum.Text = selectedItemText;
                    }
                }
            }
        }

        private void UpdateStatuInDatabase(int makinaID, int? newStatu)
        {
            using (db_SifirGibiMakinaEntities Gs = new db_SifirGibiMakinaEntities())
            {
                tbl_Makinalar makina = Gs.tbl_Makinalar.FirstOrDefault(m => m.makina_ID == makinaID);
                if (makina != null && newStatu.HasValue)
                {
                    makina.Statu = newStatu.Value; // Değişiklik burada. ".Value" ekledik.
                    Gs.SaveChanges();
                }
            }
        }




    }
}