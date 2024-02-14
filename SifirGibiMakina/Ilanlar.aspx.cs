using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.Business.Concrete;
using SifirGibiMakina.Business.Enums;
using SifirGibiMakina.Helpers.EnumHelper;
using SifirGibiMakina.Helpers.ReWriterPathHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace SifirGibiMakina
{
    public partial class Ilanlar : System.Web.UI.Page
    {
        int markaID;
        int turID;
        int? altturID;
        int? alttur2ID;
        int yil_min;
        int yil_max;
        int minfiyat;
        int maxfiyat;
        int parabirimi;
        int? chooseId = null;
        int checkedId;

 
        public IMachineService _machineService { get; set; }
        public ICategoryService _categoryManager { get; set; }
        public IMachineBrandService _machineBrandService { get; set; }
        public IMachineYearService _machineYearService { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (Session["MachineID"] != null && int.TryParse(Session["MachineID"].ToString(), out int parsedValue))
            {
                chooseId = parsedValue;
            }


            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();

            ///////////////////////////////////////SEO Gönderimi//////////////////////////////////////

            Master.Page.Title = "2. el makinalar, 2. el makineler, ikinci el makina al sat, ihaleli makineler";
            Master.Page.MetaDescription = "Sahibinden veya satıcıdan ikinci el satılık makina fiyatları ilanları yer alan 2 el sifir gibi yeni makine ilan sitesidir. Makine satıcıları ve alıcılarının buluşma portalı..";
            Master.Page.MetaKeywords = "2. el makinalar, 2. el makineler, ikinci el makina al sat, ihaleli makineler, makina al sat, makine al sat, talaşlı makina, cnc makinaları";

            /////////////////////////////////////////SEO Gönderimi/////////////////////////////////////




            VitrinUrunleriDoldur();
             
            if(chooseId == 1)
            {
                SecimleUrunleriDoldur();
                SecimleUrunleriDoldurMobil();
             
            }
            else if(chooseId == 2)
            {

                BtnSearchClick();
                BtnSearchMobilClick();



            }
            else
            {

                GetListAllMachine();
            }
     
            if (!IsPostBack)
            {

                //Ürünler
                GetStatus();
                //UrunleriDoldur();

                ReklamlariDoldur();

                //Markaları Listeliyoruz

                MachineBrandList();
              
                //Türleri Listeliyoruz
                GetAllCategories();
              

               



                //Yılları Listeliyoruz
                MachineYearList();
               

            }
           
            

        }
        private void GetListAllMachine()
        {

            var urunsorgu = _machineService.GetMachineList().Where(c => (c.Statu == 2 || c.Statu == 5)).OrderByDescending(c => c.Kayit_Tarihi); ;

            var urunList = urunsorgu.ToList();
            int pages = urunList.Count();
            CollectionPager1.DataSource = urunList;
            CollectionPager1.PageCount.CompareTo(pages / 24);
            CollectionPager1.BindToControl = rptUrunler;

            rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
            rptUrunler.DataBind();

            CollectionPager2.DataSource = urunList;
            CollectionPager2.PageCount.CompareTo(urunList.Count() / 24);
            CollectionPager2.BindToControl = rptUrunlerMobil;
            rptUrunlerMobil.DataSource = CollectionPager2.DataSourcePaged;
            rptUrunlerMobil.DataBind();

            lblToplamIlan.Text = urunList.Count().ToString();
            lblToplamIlanMobil.Text = urunList.Count().ToString();
            chooseId = 0;
            Session["MachineID"] = chooseId;


        }


        private void GetStatus()
        {


            var machineStatusValues = Enum.GetValues(typeof(MachineStatus));
            foreach (MachineStatus status in machineStatusValues)
            {
                ListItem item = new ListItem(EnumHelper.GetDescription(status), ((int)status).ToString());
                rblStatus.Items.Add(item);
                rblStatus2.Items.Add(item);
            }
        }


        private void SecimleUrunleriDoldur()
        {
            try
            {
                int selectedValue = 0;



                string Lang = Session["Lang"].ToString();
         
                turID = ddTurler.SelectedItem != null && int.TryParse(ddTurler.SelectedItem.Value, out int parsedValue1) ? parsedValue1 : 0;
                altturID = ddTurlerAlt.SelectedItem != null && int.TryParse(ddTurlerAlt.SelectedItem.Value, out int parsedValue2) ? parsedValue2 : 0;
                alttur2ID = ddTurlerAlt2.SelectedItem != null && int.TryParse(ddTurlerAlt2.SelectedItem.Value, out int parsedValue) ? parsedValue : (int?)null;
                markaID = ddMarkalar.SelectedItem != null && int.TryParse(ddMarkalar.SelectedItem.Value, out int parsedValue3) ? parsedValue3 : 0;
                if (!string.IsNullOrEmpty(rblStatus.SelectedValue))
                {
                    if (int.TryParse(rblStatus.SelectedValue, out int selectedStatus))
                    {
                        selectedValue =selectedStatus;
                    }
                }





                var urunsorgu = _machineService.GetMachineList()
                  .Where(x => x.Statu == 2 || x.Statu == 5);
                     

                if (ddMarkalar.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.marka_ID == markaID);
                }

               

                if (ddTurler.SelectedValue != "0")
                {

                    urunsorgu = urunsorgu.Where(k => k.tur_ID == turID);
                }


                if (ddTurlerAlt.SelectedValue != "0")
                {

                    urunsorgu = urunsorgu.Where(k => k.Alttur_ID == altturID);
                }

                if (ddTurlerAlt2.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur2_ID == alttur2ID);
                }
                if(selectedValue != 0)
                {
                    urunsorgu = urunsorgu.Where(k => k.SpecificType == selectedValue);
                }

                if (urunsorgu.Count() == 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.Text = "<center><strong>Aradığınız kritelere göre sonuç bulunamadı. Bu kategori için ilk ilanı siz verebilirsiniz. İlan vermek için <a href=/makina-ekle>tıklayınız</a></strong></center>";
                }
                else
                {
                    lblSonuc.Visible = false;
                    lblSonuc.Text = "";
                }
                var filteredResults = urunsorgu.OrderByDescending(c => c.Kayit_Tarihi).ToList();

                var urunList = filteredResults.ToList();
                int pages = urunList.Count();
                CollectionPager1.DataSource = urunList;
                CollectionPager1.PageCount.CompareTo(pages / 24);
                CollectionPager1.BindToControl = rptUrunler;

                rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
                rptUrunler.DataBind();


              

                lblToplamIlan.Text = filteredResults.Count().ToString();
                chooseId = 1;
                Session["MachineID"] = chooseId;
    

            }
            catch (Exception ex)
            {

            }
        }

        protected void SecimleUrunleriDoldurMobil()
        {

            try
            {
                int selectedValue = 0;
                string Lang = Session["Lang"].ToString();

                turID = Convert.ToInt32(ddTurlerMobil.SelectedItem.Value);
                altturID = Convert.ToInt32(ddTurlerAltMobil.SelectedItem.Value);
                alttur2ID = ddTurlerAlt2Mobil.SelectedItem != null && int.TryParse(ddTurlerAlt2Mobil.SelectedItem.Value, out int parsedValue) ? parsedValue : (int?)null;

                markaID = ddMarkalarMobil.SelectedItem != null && int.TryParse(ddMarkalarMobil.SelectedItem.Value, out int parsedValue1) ? parsedValue1 : 0;


                if (!string.IsNullOrEmpty(rblStatus2.SelectedValue))
                {
                    if (int.TryParse(rblStatus2.SelectedValue, out int selectedStatus))
                    {
                        selectedValue = selectedStatus;
                    }
                }


                var urunsorgu = _machineService.GetMachineList()
                   .Where(x => x.Statu == 2 || x.Statu == 5);

                if (ddMarkalarMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.marka_ID == markaID);
                }

               

                if (ddTurlerMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.tur_ID == turID);
                }
                if (ddTurlerAltMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur_ID == altturID);
                }
                if (ddTurlerAlt2Mobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur2_ID == alttur2ID);
                }
                if (selectedValue != 0)
                {
                    urunsorgu = urunsorgu.Where(k => k.SpecificType == selectedValue);
                }


                if (urunsorgu.Count() == 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.Text = "<center><strong>Aradığınız kritelere göre sonuç bulunamadı. Bu kategori için ilk ilanı siz verebilirsiniz. İlan vermek için <a href=/makina-ekle>tıklayınız</a></strong></center>";
                }
                else
                {
                    lblSonuc.Visible = false;
                    lblSonuc.Text = "";
                }


                var urunList = urunsorgu.OrderByDescending(c => c.Kayit_Tarihi).ToList();
                ;
                CollectionPager2.DataSource = urunList;
                CollectionPager2.PageCount.CompareTo(urunList.Count() / 24);
                CollectionPager2.BindToControl = rptUrunlerMobil;
                rptUrunlerMobil.DataSource = CollectionPager2.DataSourcePaged;
                rptUrunlerMobil.DataBind();


                lblToplamIlanMobil.Text = urunsorgu.Count().ToString();
                chooseId = 1;
                Session["MachineID"] = chooseId;
               

            }
            catch (Exception ex)
            {

            }
        }

        private void MachineBrandList()
        {

            var Markalar = _machineBrandService.GetAllBrandMachines();

            ddMarkalar.DataSource = Markalar.ToList();
            ddMarkalar.DataValueField = "marka_ID";
            ddMarkalar.DataTextField = "Kategori";
            ddMarkalar.DataBind();
            ListItem lim = new ListItem("Marka(Tümü)", "0");
            ddMarkalar.Items.Add(lim);
            ddMarkalar.SelectedValue = "0";

            ddMarkalarMobil.DataSource = Markalar.ToList();
            ddMarkalarMobil.DataValueField = "marka_ID";
            ddMarkalarMobil.DataTextField = "Kategori";
            ddMarkalarMobil.DataBind();
            ListItem limm = new ListItem("Marka(Tümü)", "0");
            ddMarkalarMobil.Items.Add(limm);
            ddMarkalarMobil.SelectedValue = "0";
        }
        private void MachineYearList()
        {

            var Yillar = _machineYearService.GetMachineYearList();

            ddYilMin.DataSource = Yillar.ToList();
            ddYilMin.DataValueField = "Kategori";
            ddYilMin.DataTextField = "Kategori";
            ddYilMin.DataBind();
            ListItem limym = new ListItem("Yıl(Min)", "0");
            ddYilMin.Items.Add(limym);
            ddYilMin.SelectedValue = "0";

            ddYilMinMobil.DataSource = Yillar.ToList();
            ddYilMinMobil.DataValueField = "Kategori";
            ddYilMinMobil.DataTextField = "Kategori";
            ddYilMinMobil.DataBind();
            ListItem limymmobil = new ListItem("Yıl(Min)", "0");
            ddYilMinMobil.Items.Add(limymmobil);
            ddYilMinMobil.SelectedValue = "0";

            ddYilMax.DataSource = Yillar.ToList();
            ddYilMax.DataValueField = "Kategori";
            ddYilMax.DataTextField = "Kategori";
            ddYilMax.DataBind();
            ListItem limyma = new ListItem("Yıl(Max)", "0");
            ddYilMax.Items.Add(limyma);
            ddYilMax.SelectedValue = "0";

            ddYilMaxMobil.DataSource = Yillar.ToList();
            ddYilMaxMobil.DataValueField = "Kategori";
            ddYilMaxMobil.DataTextField = "Kategori";
            ddYilMaxMobil.DataBind();
            ListItem limymaxmobil = new ListItem("Yıl(Max)", "0");
            ddYilMaxMobil.Items.Add(limymaxmobil);
            ddYilMaxMobil.SelectedValue = "0";


        }
        private void GetAllCategories()
        {
            var Turler = _categoryManager.GetCategoriesWithSubcategories();
            ddTurler.DataSource = Turler.ToList();
            ddTurler.DataValueField = "tur_ID";
            ddTurler.DataTextField = "Kategori";
            ddTurler.DataBind();
            ListItem lit = new ListItem("Makine Türü(Tümü)", "0");
            ddTurler.Items.Add(lit);
            ddTurler.SelectedValue = "0";

            ddTurlerMobil.DataSource = Turler.ToList();
            ddTurlerMobil.DataValueField = "tur_ID";
            ddTurlerMobil.DataTextField = "Kategori";
            ddTurlerMobil.DataBind();
            ListItem litm = new ListItem("Makine Türü(Tümü)", "0");
            ddTurlerMobil.Items.Add(litm);
            ddTurlerMobil.SelectedValue = "0";

            //Alt Türleri Listeliyoruz

            ListItem litaa = new ListItem("Alt Kategori(Tümü)", "0");
            ddTurlerAlt.Items.Add(litaa);
            ddTurlerAlt.SelectedValue = "0";


            ListItem litaam = new ListItem("Alt Kategori(Tümü)", "0");
            ddTurlerAltMobil.Items.Add(litaam);
            ddTurlerAltMobil.SelectedValue = "0";

            //Alt-2 Türleri Listeliyoruz

            ListItem litaaa = new ListItem("Alt-2 Kategori(Tümü)", "0");
            ddTurlerAlt2.Items.Add(litaaa);
            ddTurlerAlt2.SelectedValue = "0";


            ListItem litaaam = new ListItem("Alt-2 Kategori(Tümü)", "0");
            ddTurlerAlt2Mobil.Items.Add(litaaam);
            ddTurlerAlt2Mobil.SelectedValue = "0";

        }

        protected void rptUrunler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                BindFiyat(e);
                BindParaBirimi(e);
                BindUrunResim(e);

                // Diğer işlemler...
                // Örneğin: İhaleli mi kontrolü, satıldı mı kontrolü vb.

                // Fiyat gösterilip gösterilmemesi kontrolü
                bool fiyatgosterilmesin = Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "FiyatGosterilmesin").ToString());
                if (fiyatgosterilmesin == true)
                {
                    Literal Fiyat = (Literal)e.Item.FindControl("ltFiyat");
                    Fiyat.Visible = true;
                    Literal Para = (Literal)e.Item.FindControl("ltParaBirimi");
                    Para.Visible = false;
                    Fiyat.Text = "Fiyat Sorun";
                }
            }
        }

        protected void btnTumu_Click(object sender, EventArgs e)
        {
            try
            {
                string Lang = Session["Lang"].ToString();



                //Listeleri Sıfırlıyoruz
                ddTurler.SelectedValue = "0";
                ddTurlerAlt.SelectedValue = "0";
                ddMarkalar.SelectedValue = "0";
                txtFiyatMax.Text = "";
                txtFiyatMin.Text = "";
                ddYilMax.SelectedValue = "0";
                ddYilMin.SelectedValue = "0";
                ddParaBirimi.SelectedValue = "0";
                RadioButtonList1.ClearSelection();
                rblStatus.ClearSelection();
                rblStatus2.ClearSelection();

                ddTurlerMobil.SelectedValue = "0";
                ddTurlerAltMobil.SelectedValue = "0";
                ddMarkalarMobil.SelectedValue = "0";
                txtFiyatMaxMobil.Text = "";
                txtFiyatMinMobil.Text = "";
                ddYilMaxMobil.SelectedValue = "0";
                ddYilMinMobil.SelectedValue = "0";
                ddParaBirimiMobil.SelectedValue = "0";



                var urunSorgu = _machineService.GetMachineList().Where(c => (c.Statu == 2 || c.Statu == 5)).OrderByDescending(c => c.Kayit_Tarihi);


                CollectionPager1.DataSource = urunSorgu.ToList();
                CollectionPager1.BindToControl = rptUrunler;
                rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
                rptUrunler.DataBind();
                rptUrunlerMobil.DataSource = urunSorgu.ToList().Take(25);
                CollectionPager2.BindToControl = rptUrunlerMobil;
                rptUrunlerMobil.DataSource = CollectionPager2.DataSourcePaged;
                rptUrunlerMobil.DataBind();
                lblSonuc.Visible = false;
                lblSonuc.Text = "";
                lblToplamIlan.Text = urunSorgu.Count().ToString();
                lblToplamIlanMobil.Text = urunSorgu.Count().ToString();
                chooseId = 0;
                Session["MachineID"] = chooseId;
            }
            catch (Exception ex)
            {

            }
        }
        //filtre ayarlarını sıfırla
        protected void btnAra_Click(object sender, EventArgs e)
        {

            BtnSearchClick();
        }
        private void BtnSearchClick()
        {

            try
            {
                int selectedValue = 0;
                int selectedTimeValue = 0;

                string Lang = Session["Lang"].ToString();

                turID = Convert.ToInt32(ddTurler.SelectedItem.Value);
                altturID = Convert.ToInt32(ddTurlerAlt.SelectedItem.Value);
                alttur2ID = ddTurlerAlt2.SelectedItem != null && int.TryParse(ddTurlerAlt2.SelectedItem.Value, out int parsedValue) ? parsedValue : (int?)null;
                markaID = int.Parse(ddMarkalar.SelectedItem.Value);
         
                if (!string.IsNullOrEmpty(rblStatus.SelectedValue))
                {
                    if (int.TryParse(rblStatus.SelectedValue, out int selectedStatus))
                    {
                        selectedValue = selectedStatus;
                    }
                }
                if (!string.IsNullOrEmpty(RadioButtonList1.SelectedValue))
                {
                    if (int.TryParse(RadioButtonList1.SelectedValue, out int selectedTime))
                    {
                        selectedTimeValue = selectedTime;
                    }
                }


                

                yil_min = Convert.ToInt32(ddYilMin.SelectedItem.Value);
                yil_max = Convert.ToInt32(ddYilMax.SelectedItem.Value);
                if (txtFiyatMin.Text == "") { minfiyat = 0; } else { minfiyat = Convert.ToInt32(txtFiyatMin.Text); }
                if (txtFiyatMax.Text == "") { maxfiyat = 0; } else { maxfiyat = Convert.ToInt32(txtFiyatMax.Text); }
                parabirimi = Convert.ToInt32(ddParaBirimi.SelectedItem.Value);

                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = _machineService.GetMachineList()
                  .Where(x => x.Statu == 2 || x.Statu == 5);

                if (ddMarkalar.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.marka_ID == markaID);
                }

                if (minfiyat != 0 || maxfiyat != 0)
                {
                    if (maxfiyat == 0)
                    {
                        urunsorgu = urunsorgu.Where(k => k.Fiyat >= minfiyat);
                    }
                    else
                    {

                        urunsorgu = urunsorgu.Where(k => k.Fiyat >= minfiyat && k.Fiyat <= maxfiyat);
                    }

                   
                }
                if(selectedTimeValue != 0)
                {
                    if(selectedTimeValue == 1)
                    {
                        DateTime twentyFourHoursAgo = DateTime.Now.AddHours(-24);
                        urunsorgu = urunsorgu.Where(k => k.Kayit_Tarihi > twentyFourHoursAgo);

                    }
                    else if(selectedTimeValue == 2)
                    {
                        DateTime sevenDaysAgo = DateTime.Now.AddDays(-7);
                        urunsorgu = urunsorgu.Where(k => k.Kayit_Tarihi > sevenDaysAgo);

                    }
                    else if(selectedTimeValue == 3)
                    {
                        DateTime sevenDaysAgo = DateTime.Now.AddDays(-15);
                        urunsorgu = urunsorgu.Where(k => k.Kayit_Tarihi > sevenDaysAgo);

                    }
                    else
                    {
                        DateTime sevenDaysAgo = DateTime.Now.AddDays(-30);
                        urunsorgu = urunsorgu.Where(k => k.Kayit_Tarihi > sevenDaysAgo);

                    }


                }

                if (ddTurler.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.tur_ID == turID);
                }
                if (selectedValue != 0)
                {
                    urunsorgu = urunsorgu.Where(k => k.SpecificType == selectedValue);
                }

                if (ddTurlerAlt.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur_ID == altturID);
                }

                if (ddTurlerAlt2.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur2_ID == alttur2ID);
                }

                if (ddYilMin.SelectedValue != "0" || ddYilMax.SelectedValue != "0")
                {
                    if (ddYilMax.SelectedValue == "0")
                    {
                        urunsorgu = urunsorgu.Where(d => d.Yil >= yil_min);
                    }
                    else
                    {
                        urunsorgu = urunsorgu.Where(d => d.Yil >= yil_min && d.Yil <= yil_max);

                    }
                 
                }

                if (ddParaBirimi.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Para_Birimi == parabirimi);
                }


                if (urunsorgu.Count() == 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.Text = "<center><strong>Aradığınız kritelere göre sonuç bulunamadı. Bu kategori için ilk ilanı siz verebilirsiniz. İlan vermek için <a href=/makina-ekle>tıklayınız</a></strong></center>";
                }
                else
                {
                    lblSonuc.Visible = false;
                    lblSonuc.Text = "";
                }

                var filteredResults = urunsorgu.OrderByDescending(c => c.Kayit_Tarihi).ToList();

                var urunList = filteredResults.ToList();
                int pages = urunList.Count();
                CollectionPager1.DataSource = urunList;
                CollectionPager1.PageCount.CompareTo(pages / 24);
                CollectionPager1.BindToControl = rptUrunler;

                rptUrunler.DataSource = CollectionPager1.DataSourcePaged;
                rptUrunler.DataBind();




                lblToplamIlan.Text = filteredResults.Count().ToString();
                chooseId = 2;
                Session["MachineID"] = chooseId;

            }
            catch (Exception ex)
            {

            }
        }
        private void BtnSearchMobilClick() {

            try
            {
                int selectedValue = 0;
                int selectedTimeValue = 0;
                string Lang = Session["Lang"].ToString();

                turID = Convert.ToInt32(ddTurlerMobil.SelectedItem.Value);
                altturID = Convert.ToInt32(ddTurlerAltMobil.SelectedItem.Value);
                alttur2ID = ddTurlerAlt2Mobil.SelectedItem != null && int.TryParse(ddTurlerAlt2Mobil.SelectedItem.Value, out int parsedValue) ? parsedValue : (int?)null;

                markaID = Convert.ToInt32(ddMarkalarMobil.SelectedItem.Value);
                if (!string.IsNullOrEmpty(rblStatus2.SelectedValue))
                {
                    if (int.TryParse(rblStatus2.SelectedValue, out int selectedStatus))
                    {
                        selectedValue = selectedStatus;
                    }
                }
                if (!string.IsNullOrEmpty(RadioButtonList2.SelectedValue))
                {
                    if (int.TryParse(RadioButtonList2.SelectedValue, out int selectedTime))
                    {
                        selectedTimeValue = selectedTime;
                    }
                }

              
                yil_min = Convert.ToInt32(ddYilMinMobil.SelectedItem.Value);
                yil_max = Convert.ToInt32(ddYilMaxMobil.SelectedItem.Value);
                if (txtFiyatMinMobil.Text == "") { minfiyat = 0; } else { minfiyat = Convert.ToInt32(txtFiyatMinMobil.Text); }
                if (txtFiyatMaxMobil.Text == "") { maxfiyat = 0; } else { maxfiyat = Convert.ToInt32(txtFiyatMaxMobil.Text); }
                parabirimi = Convert.ToInt32(ddParaBirimiMobil.SelectedItem.Value);

                //Ürünler Listeleniyor Seçiyoruz
                //Ürünler Listeleniyor Seçiyoruz
                var urunsorgu = _machineService.GetMachineList()
                  .Where(x => x.Statu == 2 || x.Statu == 5);

                if (ddMarkalarMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.marka_ID == markaID);
                }

                if (minfiyat != 0 || maxfiyat != 0)
                {
                    if (maxfiyat == 0)
                    {
                        urunsorgu = urunsorgu.Where(k => k.Fiyat >= minfiyat);
                    }
                    else
                    {

                        urunsorgu = urunsorgu.Where(k => k.Fiyat >= minfiyat && k.Fiyat <= maxfiyat);
                    }


                }

                if (ddTurlerMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.tur_ID == turID);
                }
                if (selectedValue != 0)
                {
                    urunsorgu = urunsorgu.Where(k => k.SpecificType == selectedValue);
                }


                if (ddTurlerAltMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur_ID == altturID);
                }

                if (ddTurlerAlt2Mobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Alttur2_ID == alttur2ID);
                }

                if (ddYilMinMobil.SelectedValue != "0" || ddYilMaxMobil.SelectedValue != "0")
                {
                    if (ddYilMaxMobil.SelectedValue == "0")
                    {
                        urunsorgu = urunsorgu.Where(d => d.Yil >= yil_min);
                    }
                    else
                    {
                        urunsorgu = urunsorgu.Where(d => d.Yil >= yil_min && d.Yil <= yil_max);

                    }

                }
                if (selectedTimeValue != 0)
                {
                    if (selectedTimeValue == 1)
                    {
                        DateTime twentyFourHoursAgo = DateTime.Now.AddHours(-24);
                        urunsorgu = urunsorgu.Where(k => k.Kayit_Tarihi > twentyFourHoursAgo);

                    }
                    else if (selectedTimeValue == 2)
                    {
                        DateTime sevenDaysAgo = DateTime.Now.AddDays(-7);
                        urunsorgu = urunsorgu.Where(k => k.Kayit_Tarihi > sevenDaysAgo);

                    }
                    else if (selectedTimeValue == 3)
                    {
                        DateTime sevenDaysAgo = DateTime.Now.AddDays(-15);
                        urunsorgu = urunsorgu.Where(k => k.Kayit_Tarihi > sevenDaysAgo);

                    }
                    else
                    {
                        DateTime sevenDaysAgo = DateTime.Now.AddDays(-30);
                        urunsorgu = urunsorgu.Where(k => k.Kayit_Tarihi > sevenDaysAgo);

                    }


                }

                if (ddParaBirimiMobil.SelectedValue != "0")
                {
                    urunsorgu = urunsorgu.Where(k => k.Para_Birimi == parabirimi);
                }


                if (urunsorgu.Count() == 0)
                {
                    lblSonuc.Visible = true;
                    lblSonuc.Text = "<center><strong>Aradığınız kritelere göre sonuç bulunamadı. Bu kategori için ilk ilanı siz verebilirsiniz. İlan vermek için <a href=/makina-ekle>tıklayınız</a></strong></center>";
                }
                else
                {
                    lblSonuc.Visible = false;
                    lblSonuc.Text = "";
                }

                var urunList = urunsorgu.OrderByDescending(c => c.Kayit_Tarihi).ToList();
                CollectionPager2.DataSource = urunList;
                CollectionPager2.PageCount.CompareTo(urunList.Count() / 24);
                CollectionPager2.BindToControl = rptUrunlerMobil;
                rptUrunlerMobil.DataSource = CollectionPager2.DataSourcePaged;
                rptUrunlerMobil.DataBind();


                lblToplamIlanMobil.Text = urunsorgu.Count().ToString();
                chooseId = 2;
                Session["MachineID"] = chooseId;


            }
            catch (Exception ex)
            {

            }


        }
        protected void btnMobilAra_Click(object sender, EventArgs e)
        {
            BtnSearchMobilClick();
        }

        //kategoriler


        private static void AltKategori2Temizle(DropDownList dd, DropDownList ddMobil)
        {
            dd.Items.Clear();
            ListItem litaa = new ListItem("Alt Kategori(Tümü)", "0");
            dd.Items.Add(litaa);
            dd.SelectedValue = "0";

            ddMobil.Items.Clear();
            ListItem litaaMobil = new ListItem("Alt-2 Kategori(Tümü)", "0");
            ddMobil.Items.Add(litaaMobil);
            ddMobil.SelectedValue = "0";
        }
      
        protected void ddTurlerMobil_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kategoriID = Int32.Parse(ddTurlerMobil.SelectedItem.Value);

            // Alt kategorileri doldur.
            PopulateSubCategories(kategoriID, ddTurlerAltMobil);

            // Alt-2 kategorileri temizle.
            AltKategori2Temizle(ddTurlerAlt2, ddTurlerAlt2Mobil);
            
            // Ürünleri mobil için doldur.
            SecimleUrunleriDoldurMobil();
        }
        protected void ddTurler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kategoriID = Int32.Parse(ddTurler.SelectedItem.Value);
         
            PopulateSubCategories(kategoriID, ddTurlerAlt);
           
            AltKategori2Temizle(ddTurlerAlt2, ddTurlerAlt2Mobil);
            if (chooseId == 2)
            {


                BtnSearchClick();
            }
            else
            {
                SecimleUrunleriDoldur();
            }



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

        private static void EnsureListItem(DropDownList dd, string text, string value)
        {
            if (dd.Items.FindByValue(value) == null)
            {
                ListItem listItem = new ListItem(text, value);
                dd.Items.Add(listItem);
            }
            dd.SelectedValue = value;
        }


        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = RadioButtonList1.SelectedValue;

            if (selectedValue == "1")
            {
               
            }
            else if (selectedValue == "2")
            {
                
            }
          
        }


        protected void ddTurlerAlt_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddTurlerAlt2.Items.Clear();
            ddTurlerAlt2Mobil.Items.Clear();


            int subCategoryId = Int32.Parse(ddTurlerAlt.SelectedItem.Value);

           
            PopulateSubSubCategories(subCategoryId, ddTurlerAlt2);
         

           
            EnsureListItem(ddTurlerAlt2, "Seçiniz", "0");
            if (chooseId == 2)
            {


                BtnSearchClick();
            }
            else
            {
                SecimleUrunleriDoldur();

            }


     
           
        }
        private void PopulateSubSubCategories(int subCategoryId, DropDownList dd)
        {
            ddTurlerAlt2.Items.Clear(); // DropDownList'i temizle

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

        protected void ddTurlerAltMobil_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddTurlerAlt2.Items.Clear();
            ddTurlerAlt2Mobil.Items.Clear();
            int subCategoryId = Int32.Parse(ddTurlerAltMobil.SelectedItem.Value);

            PopulateSubSubCategories(subCategoryId, ddTurlerAlt2Mobil);
            EnsureListItem(ddTurlerAlt2Mobil, "Seçiniz", "0");

            SecimleUrunleriDoldurMobil();
        }

        protected void ddTurlerAlt2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (chooseId == 2)
            {


                BtnSearchClick();
            }
            else
            {
                SecimleUrunleriDoldur();

            }
        }

       

        protected void ddTurlerAlt2Mobil_SelectedIndexChanged(object sender, EventArgs e)
        {

            SecimleUrunleriDoldurMobil();
        }


        protected void ddMarkalar_SelectedIndexChanged(object sender, EventArgs e)
        {

            SecimleUrunleriDoldur();
        }
        protected void ddMarkalarMobil_SelectedIndexChanged(object sender, EventArgs e)
        {

            SecimleUrunleriDoldurMobil();
        }

        private void VitrinUrunleriDoldur()
        {


            var urunsorgu = _machineService.GetMachineList().Where(x => x.Vitrin == true && x.Statu == 2 || x.Statu == 5);
            var randomUrun = urunsorgu.OrderBy(x => Guid.NewGuid()).Take(10);


            rptUrunlerVitrin.DataSource = randomUrun.ToList();
            rptUrunlerVitrin.DataBind();

            rptUrunlerVitrinMobil.DataSource = randomUrun.ToList();
            rptUrunlerVitrinMobil.DataBind();
        }

        protected void rptUrunlerVitrin_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                BindFiyat(e);
                BindParaBirimi(e);
                BindUrunResim(e);

            }

        }







        protected void lnkResetSession_Click(object sender, EventArgs e)
        {
            chooseId = 0;
            Session["MachineID"] = chooseId;
            Response.Redirect("/Ilanlar.aspx");
        }






        private static void BindFiyat(RepeaterItemEventArgs e)
        {
            Literal Fiyat = (Literal)e.Item.FindControl("ltFiyat");
            string fiyati = DataBinder.Eval(e.Item.DataItem, "Fiyat").ToString();
            Fiyat.Text = string.Format("{0:0,0}", fiyati);
        }

        private static void BindParaBirimi(RepeaterItemEventArgs e)
        {
            Literal Para = (Literal)e.Item.FindControl("ltParaBirimi");
            string parabirimi = DataBinder.Eval(e.Item.DataItem, "Para_Birimi").ToString();
            if (parabirimi == "1")
            {
                Para.Text = "&#8378";
            }
            else if (parabirimi == "2")
            {
                Para.Text = "&euro;";
            }
            else if (parabirimi == "3")
            {
                Para.Text = "$";
            }
        }

        private static void BindUrunResim(RepeaterItemEventArgs e)
        {
            Image imgresim = (Image)e.Item.FindControl("imgUrun");
            int makinaID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "makina_ID").ToString());
            db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
            var urunresimsorgu = from c in nt.tbl_MakinaResimler
                                 where c.Durum == true && c.Vitrin == true && c.makina_ID == makinaID
                                 select c;
            foreach (var prods in urunresimsorgu)
            {
                string[] a = prods.Fotograf.Split('.');
                imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + a[0] + "_v." + a[1];
            }
            if (urunresimsorgu.Count() == 0)
            {
                imgresim.ImageUrl = ConfigurationManager.AppSettings["imagePath"].ToString() + "ornekfoto.jpg";
            }
        }


        //Reklamlar

        private static void BindReklam(Repeater repeater, int reklamAlanID)
        {
            using (db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities())
            {
                var reklam = from c in nt.tbl_Reklamlar
                             where c.Durum == true && c.dil_ID == 1 && c.reklamAlan_ID == reklamAlanID && c.Yayinda == true
                             orderby Guid.NewGuid()
                             select new { c.Dosya, c.logo_ID, c.Url, c.Adi };

                repeater.DataSource = reklam.ToList().Take(1);
                repeater.DataBind();
            }
        }
        private static void BindReklamLink(RepeaterItemEventArgs e, string urlParameter, string adsParameter)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int logoID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "logo_ID").ToString());
                string Baslik = DataBinder.Eval(e.Item.DataItem, "Adi").ToString();
                string url = DataBinder.Eval(e.Item.DataItem, "Url").ToString();
                string resim = DataBinder.Eval(e.Item.DataItem, "Dosya").ToString();

                // Gelen Logo ID'ye göre Üye ID bulunuyor
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                var uyelogoID = from c in nt.tbl_FirmaLogolari
                                where c.logo_ID == logoID
                                select c;

                foreach (var prods in uyelogoID)
                {
                    logoID = Convert.ToInt32(prods.uye_ID);
                }

                Literal Link = (Literal)e.Item.FindControl("ltLink");

                if (url != "")
                {
                    Link.Text = $"<a href=\"{DataBinder.Eval(e.Item.DataItem, "Url").ToString()}\"><img class=\"img-fluid\" src=\"{ConfigurationManager.AppSettings["imagePath"].ToString()}{resim}\"></a>";
                }
                else
                {
                    Link.Text = $"<a href=\"/satici-firma/{logoID}/{URLHelper.RewritePath("1", Baslik, 1)}/ikinci-el-makina?{urlParameter}={adsParameter}\"><img class=\"img-fluid\" src=\"{ConfigurationManager.AppSettings["imagePath"].ToString()}{resim}\"></a>";
                }
            }
        }

        private void ReklamlariDoldur()
        {

            BindReklam(rptReklamAlaniSol, 2);
            BindReklam(rptReklamAlaniHeader, 1);


        }

        protected void rptReklamAlaniSol_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                ////Link
                //int logoID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "logo_ID").ToString());
                //string Baslik = DataBinder.Eval(e.Item.DataItem, "Adi").ToString();
                //string url = DataBinder.Eval(e.Item.DataItem, "Url").ToString();
                //string resim = DataBinder.Eval(e.Item.DataItem, "Dosya").ToString();

                ////Gelen Logo ID'ye göre Üye ID bulunuyor
                //db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                //var uyelogoID = from c in nt.tbl_FirmaLogolari
                //                where c.logo_ID == logoID
                //                select c;

                //foreach (var prods in uyelogoID)
                //{
                //    logoID = Convert.ToInt32(prods.uye_ID);

                //}


                //Literal Link = (Literal)e.Item.FindControl("ltLink");


                //if (url != "")
                //{
                //    Link.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "Url").ToString() + "><img class=\"img-fluid\" src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + resim + "></a>";

                //}
                //else
                //{
                //    Link.Text = "<a href=\"/satici-firma/" + logoID + "/" + ReWriterPath("1", Baslik, "1") + "/ikinci-el-makina?ads=2\"><img class=\"img-fluid\" src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + resim + "></a>";

                //}

                BindReklamLink(e, "ads", "2");
            }

        }

        protected void rptReklamAlaniHeader_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //Link
                //int logoID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "logo_ID").ToString());
                //string Baslik = DataBinder.Eval(e.Item.DataItem, "Adi").ToString();
                //string url = DataBinder.Eval(e.Item.DataItem, "Url").ToString();
                //string resim = DataBinder.Eval(e.Item.DataItem, "Dosya").ToString();

                //Gelen Logo ID'ye göre Üye ID bulunuyor
                //db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                //var uyelogoID = from c in nt.tbl_FirmaLogolari
                //                where c.logo_ID == logoID
                //                select c;

                //foreach (var prods in uyelogoID)
                //{
                //    logoID = Convert.ToInt32(prods.uye_ID);

                //}


                //Literal Link = (Literal)e.Item.FindControl("ltLink");


                //if (url != "")
                //{
                //    Link.Text = "<a href=" + DataBinder.Eval(e.Item.DataItem, "Url").ToString() + "><img class=\"img-fluid\" src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + resim + "></a>";

                //}
                //else
                //{
                //    Link.Text = "<a href=\"/satici-firma/" + logoID + "/" + ReWriterPath("1", Baslik, "1") + "/ikinci-el-makina?ads=1\"><img class=\"img-fluid\" src=" + ConfigurationManager.AppSettings["imagePath"].ToString() + resim + "></a>";

                //}
                BindReklamLink(e, "ads", "1");
            }

        }
        protected void rblStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            SecimleUrunleriDoldur();
            SecimleUrunleriDoldurMobil();


        }
    }
}