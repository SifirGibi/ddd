using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using log4net;
using System.Threading;
using System.Globalization;
using System.Web.UI;
using Autofac.Integration.Web;
using Autofac;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.DataLayer.Services;
using SifirGibiMakina.DataLayer.İnterfaces;
using System.Configuration;
using SifirGibiMakina.DependencyResolvers.Microsoft;

namespace SifirGibiMakina
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;
        IContainer container;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterType<Uow>().As<IUow>().InstancePerRequest();
            //builder.RegisterType<MachineBrandService>().As<IMachineBrandService>().InstancePerRequest();
            //builder.RegisterType<db_SifirGibiMakinaEntities>().InstancePerRequest();
            ConfigureContainer();

           

            //Log4Net Standart Tanımlamaları
            GlobalContext.Properties["page"] = new GetCurrentPage();
            GlobalContext.Properties["host"] = new GetCurrentHost();
            GlobalContext.Properties["ipaddress"] = new GetCurrentIPAddress();
            GlobalContext.Properties["browser"] = new GetCurrentBrowser();
            GlobalContext.Properties["platform"] = new GetCurrentPlatform();
            GlobalContext.Properties["device"] = new GetCurrentDevice();
            //UrlKalip(RouteTable.Routes);

            RouteTable.Routes.Add("Anasayfa", new Route("anasayfa", new PageRouteHandler("~/Default.aspx")));
            RouteTable.Routes.Add("Icerik", new Route("{icerik}/{id}/{baslik}", new PageRouteHandler("~/Content.aspx")));
            RouteTable.Routes.Add("Iletisim", new Route("iletisim", new PageRouteHandler("~/Iletisim.aspx")));
            RouteTable.Routes.Add("Iletisim1", new Route("iletisim/{makid}", new PageRouteHandler("~/Iletisim.aspx")));
            RouteTable.Routes.Add("MakinaSat", new Route("makina-sat", new PageRouteHandler("~/MakinaSat.aspx")));
            RouteTable.Routes.Add("UyeOl", new Route("uye-ol", new PageRouteHandler("~/UyeOl.aspx")));
            RouteTable.Routes.Add("Giris", new Route("giris", new PageRouteHandler("~/Giris.aspx")));
            RouteTable.Routes.Add("Profil", new Route("profilim", new PageRouteHandler("~/Profil.aspx")));
            RouteTable.Routes.Add("Ihalelerim", new Route("ihalelerim", new PageRouteHandler("~/Ihalelerim.aspx")));
            RouteTable.Routes.Add("OdemeBildirimi", new Route("odeme-bildirimi", new PageRouteHandler("~/OdemeBildirimi.aspx")));
            RouteTable.Routes.Add("MakinaEkle", new Route("makina-ekle", new PageRouteHandler("~/MakinaEkle.aspx")));
            RouteTable.Routes.Add("Makinalarim", new Route("makinalarim", new PageRouteHandler("~/Makinalarim.aspx")));
            RouteTable.Routes.Add("Favorilerim", new Route("favorilerim", new PageRouteHandler("~/Favorilerim.aspx")));
            RouteTable.Routes.Add("Hakkimizda", new Route("hakkimizda", new PageRouteHandler("~/Hakkimizda.aspx")));
            RouteTable.Routes.Add("MesajGonder", new Route("mesajgonder/{ilanid}", new PageRouteHandler("~/MesajGonder.aspx")));
            RouteTable.Routes.Add("MesajCevapla", new Route("mesajcevapla/{ustmesajid}", new PageRouteHandler("~/MesajCevapla.aspx")));
       
            RouteTable.Routes.Add("SifremiUnuttum", new Route("sifremi-unuttum", new PageRouteHandler("~/Password_Reminder.aspx")));
            RouteTable.Routes.Add("Aktivasyon", new Route("uye-aktivasyon", new PageRouteHandler("~/Member_Activation.aspx")));
            RouteTable.Routes.Add("Cikis", new Route("cikis", new PageRouteHandler("~/Member_Exit.aspx")));
            RouteTable.Routes.Add("Urunler", new Route("urunler", new PageRouteHandler("~/Ilanlar.aspx")));
            RouteTable.Routes.Add("UrunDetay", new Route("urundetay/{urunid}", new PageRouteHandler("~/Urun_Detail.aspx")));
            RouteTable.Routes.Add("Ihale", new Route("ihale/{urunihaleid}", new PageRouteHandler("~/Ihale.aspx")));
            RouteTable.Routes.Add("MakinamNeEder", new Route("makinam-ne-eder", new PageRouteHandler("~/MakinamNeEder.aspx")));
            RouteTable.Routes.Add("Blog", new Route("blog", new PageRouteHandler("~/Blog.aspx")));
            RouteTable.Routes.Add("BlogDetay", new Route("{Baslik}/{id}", new PageRouteHandler("~/Blog_Detail.aspx")));
            RouteTable.Routes.Add("BeniHaberdarEt", new Route("beni-haberdar-et", new PageRouteHandler("~/BeniHaberdarEt.aspx")));
            RouteTable.Routes.Add("Markalar", new Route("marka/{markaadi}/ikinci-el-makina/{markaid}", new PageRouteHandler("~/Markalar.aspx")));
            RouteTable.Routes.Add("Turler", new Route("kategori/{turadi}/ikinci-el-makina/{turid}", new PageRouteHandler("~/Turler.aspx")));
            RouteTable.Routes.Add("TurlerList", new Route("kategori/{turadi}/list/{turid}", new PageRouteHandler("~/KategorilerList.aspx")));
            RouteTable.Routes.Add("TurlerAlt", new Route("alt-kategori/{altturadi}/ikinci-el-makina/{altturid}", new PageRouteHandler("~/AltTurler.aspx")));
            RouteTable.Routes.Add("TurlerAlt2", new Route("alt-2-kategori/{alttur2adi}/ikinci-el-makina/{alttur2id}", new PageRouteHandler("~/AltTurler2.aspx")));
            RouteTable.Routes.Add("TurlerAltList", new Route("alt-2-kategori/{altturadi}/list/{altturid}", new PageRouteHandler("~/KategorilerList2.aspx")));
            RouteTable.Routes.Add("SSS", new Route("sss", new PageRouteHandler("~/SSS.aspx")));
            RouteTable.Routes.Add("Ekspertiz", new Route("ekspertiz", new PageRouteHandler("~/Expertiz.aspx")));
            RouteTable.Routes.Add("Servis", new Route("servis", new PageRouteHandler("~/Servis.aspx")));
            RouteTable.Routes.Add("Kategoriler", new Route("kategoriler", new PageRouteHandler("~/Kategoriler.aspx")));
            RouteTable.Routes.Add("Ihaleler", new Route("ihaleler", new PageRouteHandler("~/Ihaleler.aspx")));
            RouteTable.Routes.Add("Arama", new Route("arama", new PageRouteHandler("~/Arama.aspx")));
            RouteTable.Routes.Add("FirmaSatici", new Route("satici-firma/{firmaid}/{firmaadi}/ikinci-el-makina", new PageRouteHandler("~/Firmalar.aspx")));
            RouteTable.Routes.Add("SEOURL", new Route("ilan-{seourl}", new PageRouteHandler("~/Urun_DetailSEOURL.aspx")));
            RouteTable.Routes.Add("SegmentifyList", new Route("list", new PageRouteHandler("~/SegmentifyList.aspx")));
            RouteTable.Routes.Add("Uyeoldunuz", new Route("uyeoldunuz", new PageRouteHandler("~/Uyeoldunuz.aspx")));
            RouteTable.Routes.Add("ServisRandevulari", new Route("servis-randevulari", new PageRouteHandler("~/ServisRandevulari.aspx")));
            RouteTable.Routes.Add("ServisFirm", new Route("servis-{serviceID}", new PageRouteHandler("~/ServisFirm.aspx")));
            RouteTable.Routes.Add("UserPaymentInfo", new Route("userpaymentinfo", new PageRouteHandler("~/UserPaymentInfo.aspx")));
            RouteTable.Routes.Add("RunEveryDay", new Route("runeveryday", new PageRouteHandler("~/RunEveryDay.aspx")));
            RouteTable.Routes.Add("CheckFirstSubsReturnPayment", new Route("checkfirstsubsreturnpayment", new PageRouteHandler("~/CheckFirstSubsReturnPayment.aspx")));
            RouteTable.Routes.Add("CheckSubsReturnMonthlyPayment", new Route("checksubsreturnmonthlypayment", new PageRouteHandler("~/CheckSubsReturnMonthlyPayment.aspx")));
            RouteTable.Routes.Add("CheckSubsReturnMonthlyPaymentError", new Route("checksubsreturnmonthlypaymenterror", new PageRouteHandler("~/CheckSubsReturnMonthlyPaymentError.aspx")));



        }
        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DependencyExtension(builder));
            container = builder.Build();
            _containerProvider = new ContainerProvider(container);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string Lang;
            HttpCookie LangCookie = Request.Cookies["Language"];
            if (LangCookie != null && LangCookie.Value != string.Empty)
            {
                Lang = LangCookie.Value;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);

                HttpContext.Current.Items["__SessionLang"] = Lang;
            }
            else
            {
                HttpContext.Current.Items["__SessionLang"] = "tr-TR";
            }

        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (context != null && context.Session != null)
            {
                context.Session["Lang"] = HttpContext.Current.Items["__SessionLang"];
            }
        }


        void UrlKalip(RouteCollection routes)
        {

            routes.MapPageRoute("Anasayfa", "anasayfa","~/Default.aspx");
            routes.MapPageRoute("Icerik", "{icerik}/{id}/{baslik}","~/Content.aspx");
            routes.MapPageRoute("Iletisim", "iletisim","~/Iletisim.aspx");
            routes.MapPageRoute("Iletisim1", "iletisim/{makid}","~/Iletisim.aspx");
            routes.MapPageRoute("MakinaSat", "makina-sat","~/MakinaSat.aspx");
            routes.MapPageRoute("UyeOl", "uye-ol","~/UyeOl.aspx");
            routes.MapPageRoute("Giris", "giris","~/Giris.aspx");
            routes.MapPageRoute("Profil", "profilim","~/Profil.aspx");
            routes.MapPageRoute("Ihalelerim", "ihalelerim","~/Ihalelerim.aspx");
            routes.MapPageRoute("OdemeBildirimi", "odeme-bildirimi","~/OdemeBildirimi.aspx");
            routes.MapPageRoute("MakinaEkle", "makina-ekle","~/MakinaEkle.aspx");
            routes.MapPageRoute("Makinalarim", "makinalarim","~/Makinalarim.aspx");
            routes.MapPageRoute("Favorilerim", "favorilerim","~/Favorilerim.aspx");
            routes.MapPageRoute("Hakkimizda", "hakkimizda","~/Hakkimizda.aspx");
            routes.MapPageRoute("MesajGonder", "mesajgonder/{ilanid}","~/MesajGonder.aspx");
            routes.MapPageRoute("MesajCevapla", "mesajcevapla/{ustmesajid}","~/MesajCevapla.aspx");
    
            routes.MapPageRoute("SifremiUnuttum", "sifremi-unuttum","~/Password_Reminder.aspx");
            routes.MapPageRoute("Aktivasyon", "uye-aktivasyon","~/Member_Activation.aspx");
            routes.MapPageRoute("Cikis", "cikis","~/Member_Exit.aspx");
            routes.MapPageRoute("Urunler", "urunler","~/Ilanlar.aspx");
            routes.MapPageRoute("UrunDetay", "urundetay/{urunid}","~/Urun_Detail.aspx");
            routes.MapPageRoute("Ihale", "ihale/{urunihaleid}","~/Ihale.aspx");
            routes.MapPageRoute("MakinamNeEder", "makinam-ne-eder","~/MakinamNeEder.aspx");
            routes.MapPageRoute("Blog", "blog","~/Blog.aspx");
            routes.MapPageRoute("BlogDetay", "{Baslik}/{id}","~/Blog_Detail.aspx");
            routes.MapPageRoute("BeniHaberdarEt", "beni-haberdar-et","~/BeniHaberdarEt.aspx");
            routes.MapPageRoute("Markalar", "marka/{markaadi}/ikinci-el-makina/{markaid}","~/Markalar.aspx");
            routes.MapPageRoute("Turler", "kategori/{turadi}/ikinci-el-makina/{turid}","~/Turler.aspx");
            routes.MapPageRoute("TurlerAlt", "alt-kategori/{altturadi}/ikinci-el-makina/{altturid}","~/AltTurler.aspx");
            routes.MapPageRoute("SSS", "sss","~/SSS.aspx");
            routes.MapPageRoute("Kategoriler", "kategoriler", "~/Kategoriler.aspx");
            routes.MapPageRoute("Arama", "{keyword}","~/Arama.aspx");
            routes.MapPageRoute("SEOURL", "ilan-{seourl}", "~/Urun_DetailSEOURL.aspx");
            routes.MapPageRoute("SegmentifyList", "list", "~/SegmentifyList.aspx");
        }

    }
}