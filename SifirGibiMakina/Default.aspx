<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SifirGibiMakina.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>ikinci el makine sitesi, 2. el satılık makine ilanları</title>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1254">
    <meta http-equiv="Content-Language" content="tr">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta name="robots" content="noindex">
  <meta name="googlebot" content="noindex">
    <meta name="description" content="Türkiye'nin ikinci el makine ilanları sitesi. 2.el CNC makinaları. CNC-Torna-Dik işlem-Abkant-Giyotin Freze, Pres, Lazer, Punch, Matkap.">
    <meta name="author" content="FümeGri Digital Solutions">
    <meta name="google-site-verification" content="ZdyBUARpp4bAwzrhMbkS26g64Kt0Ro2w7SL0QgOtO7w" />
    <meta property="og:type" content="business.business">
    <meta property="fb:app_id" content="">
    <meta name="twitter:card" content="summary">
    <meta name="twitter:title" content="Türkiye'nin İkinci El Makine Sitesi - 2. el makinalar, 2. el cnc">
    <meta name="twitter:description" content="Sahibinden ve makine satıcılarından ikinci el satılık makina ilanları sitesi. Ücretsiz 2.el makine ilanı verilen makina alım satım sitesi.">
    <meta name="revisit-after" content="1 days">
    <link rel="canonical" href="https://www.sifirgibimakine.com" />
    <link rel="alternate" href="https://en.sifirgibimakine.com/" hreflang="en">
    <link rel="alternate" href="https://de.sifirgibimakine.com/" hreflang="de">
    <link rel="alternate" href="https://ru.sifirgibimakine.com/" hreflang="ru">
    <meta name="ahrefs-site-verification" content="39d73b6484ef71340eacc9c7cf222c421fbad72df044336436079afc73c3b99a">
    <meta name="facebook-domain-verification" content="nk7bmampcv6ew1xlomde20wg1epqri" />

    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="/images/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="/images/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="/images/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="/images/ico/apple-touch-icon-57-precomposed.png">

    <!-- Favicons -->
    <link rel="shortcut icon" href="/images/sifir-gibi-makina-fav.png">
    <link href="/images/sifir-gibi-makina-fav.png" rel="icon">
    <link href="/images/sifir-gibi-makina-fav.png" rel="apple-touch-icon">

    <link rel="stylesheet" href="/styles/style.css">
    <link rel="stylesheet" href="/styles/owl.carousel.min.css">
    <link rel="stylesheet" href="/styles/owl.theme.default.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" integrity="sha384-zCbKRCUGaJDkqS1kPbPd7TveP5iyJE0EjAuZQTgFLD2ylzuqKfdKlfG/eSrtxUkn" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" integrity="sha512-1ycn6IcaQQ40/MKBW2W4Rhis/DbILU74C1vSrLJxCq57o941Ym01SwNsOMqvEBFlcgUa6xLiPY/NS5R+E6ztJQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <%-- <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css" referrerpolicy="no-referrer" />--%>
    <%--  <link rel="manifest" href="/Scripts/manifest.json">--%>


    <script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/1.18.5/TweenMax.min.js"></script>
    <script>
        const slides = document.querySelectorAll(".slide");
        for (const slide of slides) {
            slide.addEventListener("click", () => {
                removeActiveClass();
                slide.classList.add("active");
            });
        }
        function removeActiveClass() {
            slides.forEach((slide) => {
                slide.classList.remove("active");
            });
        }
    </script>
    <!-- Google Tag Manager -->
    <script>(function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({
                'gtm.start':
                    new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
                j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
                    'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-W34M7TQ');</script>
    <!-- End Google Tag Manager -->


    
    <link rel="manifest" href="/Scripts/manifest.json">


       <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Albert+Sans:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,400;1,500;1,600;1,700;1,800&display=swap" rel="stylesheet">
      <style type="text/css">
    body{
      font-family: 'Albert Sans', sans-serif;
    }
    .search_box{
      background: #fff;
      border-radius: 0px;
       font-size: 11px;
    }
    .relative{
      position: relative;
    }
    .searn_input img {
        position: absolute;
        top: 11px;
        left: 11px;
    }
    .searn_input button {
     position: absolute;
    border-radius: 0.25rem;
    /* opacity: 0.5; */
    background: #44b276;
    border: 0px;
    color: #FFF;
    padding: 8px 16px;
    top: 2px;
    right: 2px;
    margin-top: 4px;
    font-size: 12px;
 
    }
    .searn_input input{
      color: #94A3B8;
      font-weight: 500;
      line-height: 24px;
      letter-spacing: -0.32px;
    }
    .searn_input input {
        border-radius: 10px;
        border: 1px solid #E2E8F0;
        height: 44px;
        padding: 10px 91px 10px 38px;
        background: #FFF;
        width: 100%;
    }
    .search_box p{
        margin-bottom: 5px;
        margin-top: 15px;
        color: #74768B;
        font-family: Albert Sans;
        font-size: 14px;
        font-style: normal;
  
        line-height: 20px; /* 142.857% */
        letter-spacing: -0.42px;
    }
    .realted_searchs a{
    display: inline-block;
  color: #020617;
  padding: 6px 12px;
  border-radius: 36px;
  border: 2px solid #E2E8F0; /* Çerçeveyi biraz daha kalın yapmak için */
  background: #FFF;
  font-size: 11px;
  text-align: center;
  line-height: 20px;
  vertical-align: middle;
  text-decoration: none;
  font-weight: 500; 
    }
    .realted_searchs a:hover{
      background: #020617;
      color: #fff;
      text-decoration: none;
    }
    .banner_content h1{
      color: #FFF;
      text-align: center;
      font-family: Albert Sans;
      font-size: 56px;
      font-style: normal;
      font-weight: 600;
      line-height: 64px; /* 114.286% */
      letter-spacing: -1.68px;
    }
    .banner_content h2{
      color: #31D36D;
      font-family: Albert Sans;
      font-size: 56px;
      font-style: normal;
      font-weight: 600;
      line-height: 64px;
      letter-spacing: -1.68px;
    }
    .banner{
      background-position: center;
      background-repeat: no-repeat;
      background-size: cover;
      padding: 100px 0px;
      background-image: url(/images/deneme/banner.jpg);
    }.banner + .sifir-gibi-vitrin { 
  margin-top: 45px; /* Üst margin'i azalt veya kaldır */
}
   
    @media only screen and (max-width: 900px) {
      .banner{
        padding: 60px 0px;
      }
      .banner_content h2{
        font-size: 26px;
        line-height: 34px;
      }
      .banner_content h1{
        font-size: 26px;
        line-height: 34px;
      }
      .realted_searchs a{
     display: inline-flex;
  align-items: center; /* İçerikleri dikey olarak orta */
  justify-content: center; /* İçerikleri yatay olarak orta */
  color: #020617;
  padding: 4px 8px;
  border-radius: 36px;
  border: 2px solid #E2E8F0;
  background: #FFF;
  font-size: 0.625rem;
  height: 36px; /* Sabit bir yükseklik belirle */
  line-height: 1;
  vertical-align: middle;
  text-decoration: none;
  font-weight: 500;
  margin-right: 1px;
  margin-left: 1px;
        
      }
      
     .diva {
 
 
  margin-left: 0px; 
}
     divb > * {
  display: inline-block;
  vertical-align: top; 

}


divb > *:last-child {
  margin-right: 0;
}

@media screen and (max-width: 768px) {
  dvia a:not(.navbar-brand) {
    display: none;
  }
}

}

  </style>

</head>
<body>
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-W34M7TQ"
            height="0" width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
    <!-- End Google Tag Manager (noscript) -->
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="section">
            <div class="mobile-bar">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col">
                              <a href="/urunler">
                            <svg xmlns="https://www.w3.org/2000/svg" class="menu-icon" fill="none" viewbox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
                            </svg>
                            <p>Makine Al</p>
                        </a>
                    </div>
                    <div class="col">
                        <a href="/makina-sat">
                            <svg xmlns="https://www.w3.org/2000/svg" class="menu-icon" fill="none" viewbox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M7 7h.01M7 3h5c.512 0 1.024.195 1.414.586l7 7a2 2 0 010 2.828l-7 7a2 2 0 01-2.828 0l-7-7A1.994 1.994 0 013 12V7a4 4 0 014-4z" />
                            </svg>
                            <p>Makine Sat</p>
                        </a>
                    </div>
                    <div class="col">
                        <a href="/" class="active">
                            <svg xmlns="https://www.w3.org/2000/svg" class="menu-icon" fill="none" viewbox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6" />
                            </svg>
                            <p>Anasayfa</p>
                        </a>
                    </div>
                    <div class="col">
                        <a href="/kategoriler">
                            <svg xmlns="https://www.w3.org/2000/svg" class="menu-icon" fill="none" viewbox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
                            </svg>
                            <p>Kategoriler</p>
                        </a>
                    </div>
                <%--    <div class="col">
                        <a data-toggle="collapse" href="#searchBar" aria-expanded="false" aria-controls="searchBar">
                            <svg xmlns="https://www.w3.org/2000/svg" class="menu-icon" fill="none" viewbox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
                            </svg>
                            <p>Arama</p>
                        </a>
                    </div>--%>
                </div>
            </div>
        </div>
       

        <div class="topbar">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                      
                        <a href="https://sifirgibimakine.com" class="topbar-item">
                            <img src="/images/TR.gif" /></a>
                        <a href="https://en.sifirgibimakine.com" class="topbar-item">
                            <img src="/images/GB.gif" /></a>
                        <a href="https://de.sifirgibimakine.com" class="topbar-item">
                            <img src="/images/DE.gif" /></a>
                        <a href="https://ru.sifirgibimakine.com" class="topbar-item">
                            <img src="/images/RU.gif" /></a>
                    </div>
                </div>
            </div>
        </div>

        <nav class="navbar navbar-expand-lg navbar-light">
            <div class="container">
            
                <nav class="burger-menu" role="navigation">
                    <div id="menuToggle">
                        <input type="checkbox" />
                        <span></span>
                        <span></span>
                        <span></span>
                        <ul id="menu">
                            <a href="/">
                                <li>Anasayfa</li>
                            </a>
                            <a href="/urunler">
                                <li>Makine Al</li>
                            </a>
                            <a href="/makina-sat">
                                <li>Makine Sat</li>
                            </a>
                            <a href="/ekspertiz">
                                <li>Sıfır Gibi Ekspertiz</li>
                            </a>
                            <a href="/servis">
                                <li>Sifir Gibi Servis</li>
                            </a>
                            <a href="/hakkimizda">
                                <li>Hakkımızda</li>
                            </a>
                            <a href="/blog">
                                <li>Blog</li>
                            </a>
                            <a href="/iletisim">
                                <li>İletişim</li>
                            </a>
                            <a href="https://sifirgibimakine.com">
                                <img src="/images/TR.gif" /></a>
                            <a href="https://en.sifirgibimakine.com">
                                <img src="/images/GB.gif" /></a>
                            <a href="https://de.sifirgibimakine.com">
                                <img src="/images/DE.gif" /></a>
                            <a href="https://ru.sifirgibimakine.com">
                                <img src="/images/RU.gif" /></a>
                            <div class="social-icons">
                                <div>
                                    <asp:Repeater ID="rptSosyalHamburger" runat="server">
                                        <ItemTemplate>
                                            <a href='<%# Eval("Link") %>' target="_blank"><i class='btn btn-light <%# Eval("FontAwasome") %>' style="margin-left: 2px"></i></a>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                </div>
                            </div>
                        </ul>
                    </div>
                </nav>

                     <dvia>
                     <a class="navbar-brand" href="/">
                    <img src="/images/logo.png" alt="">
                </a>
                  <a href="/urunler" class="topbar-item">Makina Al</a>
                  <a href="/ekspertiz" class="topbar-item">Sıfır Gibi Ekspertiz</a>
                        <a href="/servis" class="topbar-item">Sıfır Gibi Servis</a>
                        <a href="/Kategoriler" class="topbar-item">Kategoriler</a>
                   
                    </dvia>
              
               
                
              
                <%if (Session["Giris"] == null)
                    {%>
                <div class="nav-login-success just-mobile">
                    <a href="https://en.sifirgibimakine.com">
                        <img src="/images/GB.gif" /></a>
                    <a href="https://de.sifirgibimakine.com">
                        <img src="/images/DE.gif" /></a>
                    <a href="https://ru.sifirgibimakine.com">
                        <img src="/images/RU.gif" /></a><br />
                    <a href="/giris"><span class="btn btn-success" style="width: 100px; margin-bottom: 5px">Giriş Yap</span></a><br />
                    <a href="/uye-ol"><span class="btn btn-outline-secondary" style="width: 100px">Üye Ol</span></a>


                    <%--<div class="dropdown">
                    <button class="btn btn-link px-0 dropdown-toggle" type="button" id="dropdownMenuButtonUye" data-toggle="dropdown" aria-expanded="false">
                        <div class="user-icon">
                            <i class="far fa-user"></i>
                        </div>
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonUye">
                        <a class="dropdown-item" href="/giris"><i class="fas fa-user"></i> Giriş Yap</a>
                        <a class="dropdown-item" href="/uye-ol"><i class="fas fa-question"></i> Üye Ol</a>
                    </div>
                </div>--%>
                </div>
                <%}
                    else if (Session["Giris"].ToString() == "OK")
                    { %>
                <div class="nav-login-success just-mobile">
                    <a href="https://en.sifirgibimakine.com">
                        <img src="/images/GB.gif" /></a>
                    <a href="https://de.sifirgibimakine.com">
                        <img src="/images/DE.gif" /></a>
                    <a href="https://ru.sifirgibimakine.com">
                        <img src="/images/RU.gif" /></a><br />
                    <div class="dropdown">
                        <button class="btn btn-link px-0 dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-expanded="false">
                            <div class="user-icon">
                                <i class="far fa-user"></i>
                            </div>
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <a class="dropdown-item" href="/profilim"><i class="fas fa-user"></i>Profilim</a>
                            <a class="dropdown-item" href="/makinam-ne-eder"><i class="fas fa-question"></i>Makinem Ne Eder?</a>
                            <a class="dropdown-item" href="/makina-ekle"><i class="fas fa-tag"></i>Makine Sat</a>
                            <a class="dropdown-item" href="/makinalarim"><i class="fas fa-cog"></i>Makinelerim</a>
                            <a class="dropdown-item" href="/ihalelerim"><i class="fas fa-list-ul"></i>İhalelerim</a>
                            <a class="dropdown-item" href="/odeme-bildirimi"><i class="fas fa-wallet"></i>Ödeme Bildirimi</a>
                            <a class="dropdown-item" href="/favorilerim"><i class="fas fa-star"></i>Favorilerim</a>
                        
                            <a class="dropdown-item" href="/cikis"><i class="fas fa-sign-out-alt"></i>Çıkış Yap</a>
                        </div>
                    </div>

                </div>
                <%} %>
                
                       
                 
             
              
                <div class="nav-login-register sm-d-none">
                             
                 
                    <%if (Session["Giris"] == null)
                        {%>
                     <a href="/makinam-ne-eder" class="topbar-item">Makinem Ne Eder?</a>
                    <a href="/giris"
                        class="topbar-item">Giriş Yap
                    </a>
                     <a href="/makina-sat">
                        <span class="btn btn-success">Ücretsiz İlan Ver</span>
                    </a>
                    <%}
                    else if (Session["Giris"].ToString() == "OK")
                    { %>
                   
                      <div class="nav-login-success">
                        <div class="dropdown">
                              <divb>
                      <a href="/makinam-ne-eder" class="topbar-item">Makinem Ne Eder?</a>
                      <a href="/makina-ekle">
                        <span class="btn btn-success">Ücretsiz İlan Ver</span>
                    </a>
                           </divb>
                            <button class="btn btn-link px-0 dropdown-toggle" type="button" id="dropdownMenuButtonDesktop" data-toggle="dropdown" aria-expanded="false">

                                <i class="fa fa-user text-green"></i>
                                <div class="user-icon">
                                    <i class="far fa-user"></i>
                                </div>
                            </button>
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonDesktop">
                                <a class="dropdown-item" href="/profilim"><i class="fas fa-user"></i>Profilim</a>
                                <a class="dropdown-item" href="/makinam-ne-eder"><i class="fas fa-question"></i>Makinem Ne Eder?</a>
                                <a class="dropdown-item" href="/makina-ekle"><i class="fas fa-tag"></i>Makine Sat</a>
                                <a class="dropdown-item" href="/makinalarim"><i class="fas fa-cog"></i>Makinelerim</a>
                                <a class="dropdown-item" href="/ihalelerim"><i class="fas fa-list-ul"></i>İhalelerim</a>
                                <a class="dropdown-item" href="/odeme-bildirimi"><i class="fas fa-wallet"></i>Ödeme Bildirimi</a>
                                <a class="dropdown-item" href="/favorilerim"><i class="fas fa-star"></i>Favorilerim</a>
                               
                                <a class="dropdown-item" href="/cikis"><i class="fas fa-sign-out-alt"></i>Çıkış Yap</a>
                            </div>
                        </div>
                    </div>
                     
                    <%} %>
                 
                       
                   
                  </div>
                    
                </div>
            </nav>
   

       


      <%--  <div class="search-bar-collapse just-mobile">
            <div class="collapse" id="searchBar">
                <div class="card card-body">
                    <div class="profil my-0">
                        <div class="profil-right-box">
                            <input class="form-control rounded-0" type="search" placeholder="Marka, Model veya İlan No ile Arayın" aria-label="Search" id="txtSearchMobil" runat="server">
                            <button class="btn btn-secondary rounded-0" type="submit" id="btnmobilsearch" runat="server" onserverclick="btnSearchMobil_Click">
                                <i class="fas fa-search"></i>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
     


     <%--   <div class="makine-al-sat">
            <div class="container">
                <div class="overlay"></div>
                <div class="row align-items-center">
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6 col-6">
                        <a href="/urunler" class="btn btn-success btn-lg btn-block mobile-btn success-hovered-1"><i class="fas fa-plus mr-2"></i>Makine Al</a>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6 col-6">
                        <a href="/makina-sat" class="btn btn-outline-success btn-lg btn-block mobile-btn success-hovered-2"><i class="fas fa-tag mr-2"></i>Makine Sat</a>
                    </div>
                    <div class="col-md-6">
                        <h4>Hemen makine alıp satmaya başlayın!</h4>
                    </div>
                </div>
            </div>
        </div>--%>
  <%--      <div class="banner-slider sm-d-none">
            <div class="container-fluid px-0">

                <asp:Repeater ID="sptSlider" runat="server" OnItemDataBound="rptSlider_ItemDataBound">
                    <ItemTemplate>

                        <div runat="server" id="sliderdiv">
                            <div class="overlay">
                                <img src="/images/logo-dikey.png" alt="">
                            </div>
                            <div class="slider-text">
                                <h5><%# Eval("UstBilgi") %></h5>
                                <p><%# Eval("AltBilgi") %> <%# Eval("Fiyat","{0:0,0}") %></p>
                                <asp:Literal ID="ltLinkBtn" runat="server" Visible="false"></asp:Literal>
                            </div>
                        </div>

                    </ItemTemplate>

                </asp:Repeater>


            </div>
        </div>--%>

         <div class="banner nsgm-mobile ">
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <div class="banner_content text-center">
          <h1>İhtiyacınız olan makineyi</h1>
          <h2>kolayca alın, değerinde satın.</h2>

        </div>
      </div>
      <div class="col-md-7 mx-auto">
        <div class="search_box p-3">
          <div class="searn_input relative">
            <img src="/images/deneme/search.png">
            <input type="text" class="search_input" name="" placeholder="Aradığınız Makineyi Bulabilirim" id="search_input" runat="server">
            <button id="btnsearch" runat="server" onserverclick="btnSearch_Click">Arama Yap</button>
          </div>
          <div>
            <p>🔥 Popüler Aramalar</p>
          </div>
          <div class="realted_searchs d-flex justify-content-between">
            <a href="http://sifirgibimakine.com/alt-2-kategori/cnc-torna/ikinci-el-makina/312">CNC Torna</a>
            <a href="http://sifirgibimakine.com/alt-kategori/is-makineleri-ve-insaat/ikinci-el-makina/619">İş Makineleri Ve İnşaat</a>
            <a href="http://sifirgibimakine.com/alt-kategori/gida-makineleri/ikinci-el-makina/618">Gıda makineleri</a>
            <a href="https://sifirgibimakine.com/alt-2-kategori/isleme-merkezi/ikinci-el-makina/338">İşleme Merkezi</a>
          </div>
        </div>
      </div>
    </div>

  </div>
                
</div>
      
                            

            <!-- Vitrin Makinaları -->
           <div class="sifir-gibi-vitrin">

                <div class="container border-bottom pb-5">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="title-button">
                                <h4>Sıfır Gibi Vitrin</h4>
                                <a href="/urunler">
                                    <span class="btn btn-success sm-d-none">Tümünü Gör <i class="fas fa-chevron-right ml-2"></i></span>
                                </a>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5">

<%--                            ana vitrin !!!--%>
                            <asp:Repeater ID="rptAnaVitrin" runat="server" OnItemDataBound="rptAnaVitrin_ItemDataBound">
                                <ItemTemplate>
                                    <div class="card shadow">
                                        <div class="position-relative">
                                            <a href="/ilan-<%# Eval("SEOUrl") %>">
                                                <asp:Image ID="imgUrun" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>' /></a>
                                            <div class="card-price">
                                                <h4>
                                                    <asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></h4>
                                            </div>
                                        </div>
                                        <div class="card-body">
                                            <p class="card-date mb-1"><%# Eval("Yayinlanma_Tarihi", "{0: dd.MM.yyyy}")%></p>
                                            <p class="card-work mb-1">
                                                <a href="/kategori/<%# SifirGibiMakina.Helpers.ReWriterPathHelper.URLHelper.RewritePath("1", Eval("Tur").ToString(), 1)%>/ikinci-el-makina/<%# Eval("tur_ID") %>"><%# Eval("Tur") %></a>
                                            </p>
                                            <p class="card-type mb-3" style="height: 30px">
                                                <a href="/ilan-<%# Eval("SEOUrl") %>"><%# Eval("Baslik") %></a>
                                            </p>
                                            <div class="card-features">
                                                <div class="row">

                                                    <div class="col-6 border-right sm-text-center" style="height: 70px">
                                                        <i class="fas fa-tag"></i>
                                                        <span class="fs-8px ln-8px">Marka
                                                            <br />
                                                            <%# Eval("Marka") %></span>
                                                    </div>

                                                    <div class="col-6 text-center sm-text-center" style="height: 70px">
                                                        <i class="fas fa-calendar"></i>
                                                        <span class="fs-8px ln-8px">Yıl
                                                            <br />
                                                            <%# Eval("Yil") %></span>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <a href="/iletisim">
                                <img class="img-fluid sm-mb-2 sm-mt-2" src="/images/ilan-min.jpg" alt="" style="margin-top: 35px;">
                            </a>
                        </div>
                        <div class="col-md-7">
                            <div class="row">

                                <asp:Repeater ID="rptUrunlerVitrin" runat="server" OnItemDataBound="rptUrunlerVitrin_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-6 sm-pr-8">
                                            <div class="card shadow mb-4">
                                                <div class="position-relative">
                                                    <a href="/ilan-<%# Eval("SEOUrl") %>">
                                                        <asp:Image ID="imgUrun" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>' /></a>
                                                    <div class="card-price">
                                                        <h4>
                                                            <asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></h4>
                                                    </div>
                                                </div>
                                                <div class="card-body">
                                                    <p class="card-date mb-1 sm-7-735-400"><%# Eval("Yayinlanma_Tarihi", "{0: dd.MM.yyyy}")%></p>
                                                    <p class="card-work mb-1">
                                                        <a href="/kategori/<%# SifirGibiMakina.Helpers.ReWriterPathHelper.URLHelper.RewritePath("1", Eval("Tur").ToString(), 1)%>/ikinci-el-makina/<%# Eval("tur_ID") %>"><%# Eval("Tur") %></a>
                                                    </p>
                                                    <p class="card-type mb-3" style="height: 30px">
                                                        <a href="/ilan-<%# Eval("SEOUrl") %>">
                                                            <asp:Literal ID="ltBaslik" runat="server"></asp:Literal></a>
                                                    </p>
                                                    <div class="card-features">
                                                        <div class="row">

                                                            <div class="col-6  border-right sm-text-center" style="height: 70px">
                                                                <i class="fas fa-tag"></i>
                                                                <span class="fs-8px ln-8px">Marka
                                                                    <br />
                                                                    <%# Eval("Marka") %></span>
                                                            </div>

                                                            <div class="col-6  text-center sm-text-center" style="height: 70px">
                                                                <i class="fas fa-calendar"></i>
                                                                <span class="fs-8px ln-8px">Yıl
                                                                    <br />
                                                                    <%# Eval("Yil") %></span>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
            


<%--            //reklam--%>
    <%--        <div class="container pb-5">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Repeater ID="rptReklamAlaniMagazaUstu" runat="server" OnItemDataBound="rptReklamAlaniMagazaUstu_ItemDataBound">
                            <ItemTemplate>
                                <div class="text-center">
                                    <asp:Literal ID="ltLink" runat="server"></asp:Literal>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>--%>

<%--            Mağazalar--%>

            <div class="sifir-gibi-magazalar">
                <div class="container border-bottom py-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="title">
                                <h4>Sıfır Gibi Mağazalar</h4>
                                <p>Siz de <span class="text-success">Sıfır Gibi Mağaza</span> avantajlarından yararlanmak için buraya ilan verin!</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="owl-carousel owl-theme" id="sgm-magazalar-slider">
                                <asp:Repeater ID="rptFirmaLogolari" runat="server">
                                    <ItemTemplate>
                                        <div class="item">
                                            <div class="card">
                                                <div class="card-body p-2 text-center">
                                                    <%# Convert.ToInt32(Eval("uye_ID")) == 0
                        ? "<a href='" + Eval("Link") + "' target='_blank'><img class='img-fluid' src='" + ConfigurationManager.AppSettings["imagePath"] + Eval("Fotograf") + "' /></a>"
                        : "<a href='satici-firma/" + Eval("uye_ID") + "/" +  SifirGibiMakina.Helpers.ReWriterPathHelper.URLHelper.RewritePath("1", Eval("Baslik").ToString(), 1) + "/ikinci-el-makina' target='_blank'><img class='img-fluid' src='" + ConfigurationManager.AppSettings["imagePath"] + Eval("Fotograf") + "' /></a>"
                                                    %>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </div>

                        </div>
                    </div>
                    <div class="row mt-3 text-right">
                        <div class="col-md-12">
                            <a href="/iletisim">Buraya İlan Ver <i class="fas fa-chevron-right"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Kısa Açıklamalar -->
            <div class="neden-sifir-gibi-makine py-5 sm-my-0">
                <div class="container sm-d-none">
                    <div class="row mb-4">
                        <div class="col-md-12">
                            <h4 class="title">Neden Sıfır Gibi
                                <br>
                                Makine?</h4>
                            <br>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/acik-arttirma.png" alt="">
                                    <h5 class="card-title">Açık Arttırmaya Nasıl Katılabilirim?</h5>
                                    <p class="card-text">İnternet üzerinden ikinci el makina satın almanızı sağlayan Sıfırgibi makina...   </p>
                                    <a href="/sayfalar/2/acik-artirmaya-nasil-katilabilirim" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/satis-sonrasi.png" alt="">
                                    <h5 class="card-title">Satış Sonrası</h5>
                                    <p class="card-text">Makinanız sifirgibimakina aracılığıyla satıldıktan sonra, satış bedeli...  </p>
                                    <a href="/sayfalar/3/satis-sonrasi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/exper.png" alt="">
                                    <h5 class="card-title">Teknik Destek</h5>
                                    <p class="card-text">Sıfırgibi Makina oluşturduğu büyük servis ağı, kendi bünyesinde yer alan...   </p>
                                    <a href="/sayfalar/4/teknik-destek" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/lojistik.png" alt="">
                                    <h5 class="card-title">Lojistik Teslimat</h5>
                                    <p class="card-text">Tüm makina satışlarının yükleme,nakliye,indirme vb. tüm işlemlerin sorumlulukları...  </p>
                                    <a href="/sayfalar/5/lojistik-teslimat" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/iade.png" alt="">
                                    <h5 class="card-title">İade Koşulları</h5>
                                    <p class="card-text">Sıfırgibi makina müşterilerine makinaları yerinde çalışır durumda bakma...  </p>
                                    <a href="/sayfalar/7/iade-kosullari" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/sartlar.png" alt="">
                                    <h5 class="card-title">Site Kullanım Şartları</h5>
                                    <p class="card-text">Bu sitenin sunumu ve tüm içeriği T.C. Mevzuatı ve fikri mülkiyet mevzuatı...  </p>
                                    <a href="/sayfalar/9/site-kullanim-sartlari" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/sozlesme.png" alt="">
                                    <h5 class="card-title">Üyelik Sözleşmesi</h5>
                                    <p class="card-text">İşbu sözleşme, www.sifirgibimakine.com adresinde faaliyet gösteren... </p>
                                    <a href="/sayfalar/11/uyelik-sozlesmesi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/ihale.png" alt="">
                                    <h5 class="card-title">İhale Katılım Sözleşmesi</h5>
                                    <p class="card-text">www.sifirgibimakine.com sitesi üzerinden hazırlanan  ve sitede... </p>
                                    <a href="/sayfalar/12/ihale-katilim-sozlesmesi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container nsgm-mobile just-mobile">
                    <div class="row mb-4">
                        <div class="col-md-12">
                            <h4 class="title">Neden Sıfır Gibi Makine?</h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="owl-carousel owl-theme" id="neden-sifir-gibi-makine">
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Açık Arttırmaya Nasıl Katılabilirim?</h5>
                                            <p class="card-text">İnternet üzerinden ikinci el makina satın almanızı sağlayan Sıfırgibi makina...  </p>
                                            <a href="/sayfalar/2/acik-artirmaya-nasil-katilabilirim" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Satış Sonrası</h5>
                                            <p class="card-text">Makinanız sifirgibimakina aracılığıyla satıldıktan sonra, satış bedeli...  </p>
                                            <a href="/sayfalar/3/satis-sonrasi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Teknik Destek</h5>
                                            <p class="card-text">Sıfırgibi Makina oluşturduğu büyük servis ağı, kendi bünyesinde yer alan...  </p>
                                            <a href="/sayfalar/4/teknik-destek" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Lojistik Teslimat</h5>
                                            <p class="card-text">Tüm makina satışlarının yükleme,nakliye,indirme vb. tüm işlemlerin sorumlulukları...  </p>
                                            <a href="/sayfalar/5/lojistik-teslimat" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">İade Koşulları</h5>
                                            <p class="card-text">Sıfırgibi makina müşterilerine makinaları yerinde çalışır durumda bakma...  </p>
                                            <a href="/sayfalar/7/iade-kosullari" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Site Kullanım Şartları</h5>
                                            <p class="card-text">Bu sitenin sunumu ve tüm içeriği T.C. Mevzuatı ve fikri mülkiyet mevzuatı...  </p>
                                            <a href="/sayfalar/9/site-kullanim-sartlari" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Üyelik Sözleşmesi</h5>
                                            <p class="card-text">İşbu sözleşme, www.sifirgibimakine.com adresinde faaliyet gösteren...  </p>
                                            <a href="/sayfalar/11/uyelik-sozlesmesi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">İhale Katılım Sözleşmesi</h5>
                                            <p class="card-text">www.sifirgibimakine.com sitesi üzerinden hazırlanan ve sitede...  </p>
                                            <a href="/sayfalar/12/ihale-katilim-sozlesmesi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Makina Değerleri -->
            <asp:Panel ID="pnlSayilar" runat="server" Visible="false">
                <div class="sgm-degerler py-5">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <h4 class="title text-center">Sıfırgibimakine.com Değerleri</h4>
                            </div>
                        </div>
                        <div class="row mt-4 countdown">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                                <asp:Literal ID="ltSatilanMakina" runat="server"></asp:Literal>
                                <p>Adet Makine Satıldı</p>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                                <asp:Literal ID="ltUyeSayisi" runat="server"></asp:Literal>
                                <p>Kişi Üye Oldu</p>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                                <asp:Literal ID="ltAcikArtirmaUye" runat="server"></asp:Literal>
                                <p>Kişi Açık Arttırmaya Katıldı</p>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                                <asp:Literal ID="ltAcikArtirmaTeklif" runat="server"></asp:Literal>
                                <p>Teklif verildi</p>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <!-- Makinam Ne Eder? -->
            <div class="sgm-ne-eder">
                <div class="overlay"></div>
                <div class="container py-6 sm-p-25px">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="title">
                                <img src="/images/neden-icon.png" alt="">
                                Makinem Ne Eder?
                            </h4>
                            <p class="subtitle">
                                Makineni değerinde alıcı ile buluşturmanın En kolay yolu sifirgibimakine.com’da. Uzman exper ekibimiz tarafından makinanın takribi değerini öğrenin.
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="subtitle">Makine Türü</label>
                                        <asp:DropDownList ID="ddTurler" runat="server" CssClass="form-control select-input"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="subtitle">Makine Markası</label>
                                        <asp:DropDownList ID="ddMarkalar" runat="server" CssClass="form-control select-input"></asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="subtitle">Makine Üretim Yılı</label>
                                        <asp:DropDownList ID="ddYillar" runat="server" CssClass="form-control select-input"></asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="sdm-ne-eder-button">
                                <a href="/makinam-ne-eder">
                                    <span class="btn btn-success">Makinemi Değerle</span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Kategoriler -->
      

      
<div class="sgm-kategorileri py-6 sm-py-40px">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h4 class="title">Sıfır Gibi Makine Kategorileri</h4>
            </div>
        </div>
    </div>

    <div class="container-fluid px-0px sm-px-15px">
        <div class="row mt-4">
            <div class="col-md-12 px-0px sm-px-15px">
                <div class="owl-carousel owl-theme" id="kategori-slider">
                  <asp:Repeater ID="rptKategoriler" runat="server" OnItemDataBound="rptKategoriler_ItemDataBound">
                        <ItemTemplate>
                            <div class="item">
                                <div class="card">
                                    <div class="position-relative">
                                       
                                     <a href="/kategori/<%# SifirGibiMakina.Helpers.ReWriterPathHelper.URLHelper.RewritePath("1", Eval("Kategori").ToString(), 1)%>/list/<%# Eval("tur_ID") %>" class="btn btn-success btn-block">Daha Fazla </a>
                              
                                     <asp:Image ID="imgKategori" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Kategori") %>' ImageUrl='<%# Eval("Resim") %>' AlternateText='<%# Eval("Kategori") %>' />
                                        </a>
                                        <div class="slider-card-text">
                                            <h5><%# Eval("Kategori") %></h5>
                                            <p>
                            
                                                <asp:Literal ID="ltKategoriIlanAdeti" runat="server"></asp:Literal>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="card-body p-0">
                                        <div class="slider-card-items">
                                         
                                            <asp:Repeater ID="rptAltKategoriler" runat="server" DataSource='<%# Eval("tbl_MakinaAltTurleris") %>'>
                                                <ItemTemplate>
                                              
                                                    <a href="/alt-kategori/<%#SifirGibiMakina.Helpers.ReWriterPathHelper.URLHelper.RewritePath("1", Eval("Kategori").ToString(), 1)%>/ikinci-el-makina/<%# Eval("Alttur_ID") %>"><%# Eval("Kategori") %> <i class="fas fa-angle-right float-right"></i></a>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                           
                                               <a href="/kategori/<%#SifirGibiMakina.Helpers.ReWriterPathHelper.URLHelper.RewritePath("1", Eval("Kategori").ToString(), 1)%>/list/<%# Eval("tur_ID") %>" class="btn btn-success btn-block">Daha Fazla </a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
              
                <a href="/kategoriler" class="btn btn-success tumunugor-button">Tümünü Gör <i class="fas fa-chevron-right ml-2"></i></a>
            </div>
        </div>
    </div>
</div>




        








            <!-- Yeni Eklenenler -->
            <div class="sgm-yeni-eklenenler">
                <div class="container pt-5">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="title">Yeni Eklenenler</h4>
                        </div>
                    </div>
                </div>
                <div class="container-fluid px-0">
                    <div class="row mt-4">
                        <div class="col-md-12 px-0">
                            <div class="owl-carousel owl-theme" id="yeni-eklenenler-slider">
                                <asp:Repeater ID="rptYeniEklenenler" runat="server" OnItemDataBound="rptYeniEklenenler_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="item">
                                            <div class="card shadow">
                                                <div class="position-relative">
                                                    <a href="/ilan-<%# Eval("SEOUrl") %>">
                                                        <asp:Image ID="imgUrun" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>' /></a>
                                                    <div class="card-price">
                                                        <h4>
                                                            <asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></h4>
                                                    </div>
                                                </div>
                                                <div class="card-body">
                                                    <p class="card-date mb-1"><%# Eval("Yayinlanma_Tarihi", "{0: dd.MM.yyyy}")%></p>
                                                    <p class="card-work mb-1">
                                                        <a href="/kategori/<%#SifirGibiMakina.Helpers.ReWriterPathHelper.URLHelper.RewritePath("1", Eval("Tur").ToString(), 1)%>/ikinci-el-makina/<%# Eval("tur_ID") %>"><%# Eval("Tur") %></a>
                                                    </p>
                                                    <p class="card-type mb-3" style="height: 30px">
                                                        <a href="/ilan-<%# Eval("SEOUrl") %>">
                                                            <asp:Literal ID="ltBaslik" runat="server"></asp:Literal></a>
                                                    </p>
                                                    <div class="card-features">
                                                        <div class="row">

                                                            <div class="col-6 border-right sm-text-center" style="height: 70px">
                                                                <i class="fas fa-tag"></i>
                                                                <span class="fs-8px ln-8px">Marka
                                                                    <br />
                                                                    <%# Eval("Marka") %></span>
                                                            </div>

                                                            <div class="col-6 text-center sm-text-center" style="height: 70px">
                                                                <i class="fas fa-calendar"></i>
                                                                <span class="fs-8px ln-8px">Yıl
                                                                    <br />
                                                                    <%# Eval("Yil") %></span>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </div>
                            <div class="container">
                                <a href="/urunler" class="btn btn-success tumunugor-button">Tümünü Gör
                            <i class="fas fa-chevron-right ml-2"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
                <asp:Panel ID="pnlIhale" runat="server" Visible="false">
                    
                    <!-- İhale Ürünleri -->
                    <div class="container py-5">
                        <div class="row">
                            <div class="col-md-12">
                                <h4 class="title">Sıfır Gibi İhale</h4>
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-md-12">
                                <div class="owl-carousel owl-theme" id="ihalelerimiz-slider">
                                    <asp:Repeater ID="rptIhaleler" runat="server" OnItemDataBound="rptIhaleler_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="item">
                                                <div class="card">
                                                    <div class="position-relative">

                                                        <div class="ihale-sure ihale-tamamlandi" id="suredoldu" runat="server" visible="true" style="z-index: 99999999999">
                                                            <div class="item" style="z-index: 99999999999">
                                                                <p>İhale Süresi Dolmuştur.</p>
                                                            </div>
                                                        </div>
                                                        <a href="/ilan-<%# Eval("SEOUrl") %>">
                                                            <asp:Image ID="imgUrun" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>' /></a>
                                                        <div class="card-price">
                                                            <h4>
                                                                <asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></h4>
                                                        </div>
                                                    </div>
                                                    <div class="card-body">
                                                        <div class="ihale-sure" id="ihalesuresi" runat="server">
                                                            <div class="wrap">
                                                                <div class="countdown">
                                                                    <div class="bloc-time days" data-init-value="7">
                                                                        <span class="count-title">Gün</span>

                                                                        <div class="figure days days-1">
                                                                            <span class="top">1</span>
                                                                            <span class="top-back">
                                                                                <span>1</span>
                                                                            </span>
                                                                            <span class="bottom">0</span>
                                                                            <span class="bottom-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                        </div>

                                                                        <div class="figure days days-2">
                                                                            <span class="top">0</span>
                                                                            <span class="top-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                            <span class="bottom">0</span>
                                                                            <span class="bottom-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                        </div>
                                                                        <h1>:</h1>
                                                                    </div>

                                                                    <div class="bloc-time hours" data-init-value="24">
                                                                        <span class="count-title">Saat</span>

                                                                        <div class="figure hours hours-1">
                                                                            <span class="top">0</span>
                                                                            <span class="top-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                            <span class="bottom">0</span>
                                                                            <span class="bottom-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                        </div>

                                                                        <div class="figure hours hours-2">
                                                                            <span class="top">0</span>
                                                                            <span class="top-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                            <span class="bottom">0</span>
                                                                            <span class="bottom-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                        </div>
                                                                        <h1>:</h1>
                                                                    </div>


                                                                    <div class="bloc-time min" data-init-value="0">
                                                                        <span class="count-title">Dakika</span>

                                                                        <div class="figure min min-1">
                                                                            <span class="top">0</span>
                                                                            <span class="top-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                            <span class="bottom">0</span>
                                                                            <span class="bottom-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                        </div>

                                                                        <div class="figure min min-2">
                                                                            <span class="top">0</span>
                                                                            <span class="top-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                            <span class="bottom">0</span>
                                                                            <span class="bottom-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                        </div>
                                                                        <h1>:</h1>
                                                                    </div>


                                                                    <div class="bloc-time sec" data-init-value="0">
                                                                        <span class="count-title">Saniye</span>

                                                                        <div class="figure sec sec-1">
                                                                            <span class="top">0</span>
                                                                            <span class="top-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                            <span class="bottom">0</span>
                                                                            <span class="bottom-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                        </div>

                                                                        <div class="figure sec sec-2">
                                                                            <span class="top">0</span>
                                                                            <span class="top-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                            <span class="bottom">0</span>
                                                                            <span class="bottom-back">
                                                                                <span>0</span>
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <p class="card-date mb-1 sm-7-735-400"><%# Eval("Yayinlanma_Tarihi", "{0: dd.MM.yyyy}")%></p>
                                                        <p class="card-work mb-1">
                                                            <a href="/kategori/<%#SifirGibiMakina.Helpers.ReWriterPathHelper.URLHelper.RewritePath("1", Eval("Tur").ToString(), 1)%>/ikinci-el-makina/<%# Eval("tur_ID") %>"><%# Eval("Tur") %></a>
                                                        </p>
                                                        <p class="card-type mb-3" style="height: 30px">
                                                            <a href="/ilan-<%# Eval("SEOUrl") %>"><%# Eval("Baslik") %></a>
                                                        </p>
                                                        <div class="card-features">
                                                            <div class="row">
                                                                <div class="col-6 border-right sm-text-center" style="height: 70px">
                                                                    <i class="fas fa-tag"></i>
                                                                    <span class="fs-8px ln-8px">Marka
                                                                        <br />
                                                                        <%# Eval("Marka") %></span>
                                                                </div>
                                                                <div class="col-6 text-center sm-text-center" style="height: 70px">
                                                                    <i class="fas fa-calendar"></i>
                                                                    <span class="fs-8px ln-8px">Yıl
                                                                        <br />
                                                                        <%# Eval("Yil") %></span>
                                                                </div>
                                                                <div class="col-md-12 mt-2 ihaleye-katil">
                                                                    <div class="col-md-12 mt-2 ihaleye-katil">
                                                                        <asp:Literal ID="ltIhaleKatilBtn" runat="server"></asp:Literal>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <a href="/ihaleler" class="btn btn-success tumunugor-button">Tümünü Gör
                        <i class="fas fa-chevron-right ml-2"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                 <br />
                    <br />
                    <asp:Literal ID="ltFooterSeo" runat="server"></asp:Literal>
          

            <!-- Blog -->
         <div class="sgm-blog">
                <div class="container py-6 sm-py-40px">
                    <div class="row">
                        <asp:Repeater ID="rptBlogAna" runat="server" OnItemDataBound="rptBlogAna_ItemDataBound">
                            <ItemTemplate>
                                <div class="col-md-4 sm-d-none">
                                    <div class="card border-0">
                                        <asp:Image ID="imgBlog" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Baslik") %>' AlternateText='<%# Eval("Baslik") %>' />
                                        <div class="card-body bg-light">
                                            <p class="card-date"><%# Eval("Kayit_Tarihi") %></p>
                                            <h5 class="card-title">
                                                <asp:Literal ID="ltLink" runat="server"></asp:Literal><%# Eval("Baslik") %></a>
                                            </h5>
                                            <p class="card-text"><%# Eval("KisaAciklama") %></p>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <div class="col-md-8 right-box">
                            <div class="row">
                                <div class="col-md-6">
                                    <h3 class="title">Blog</h3>
                                    <p class="subtitle">Makina ve sanayi hakkında güncel makalelerimiz</p>
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="owl-carousel owl-theme" id="blog-slider">
                                        <asp:Repeater ID="rptBlog" runat="server" OnItemDataBound="rptBlog_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="item">
                                                    <div class="card border-0">

                                                        <asp:Image ID="imgBlog" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Baslik") %>' AlternateText='<%# Eval("Baslik") %>' />
                                                        <div class="card-body bg-light">
                                                            <p class="card-date"><%# Eval("Kayit_Tarihi") %></p>
                                                            <h5 class="card-title">
                                                                <asp:Literal ID="ltLink" runat="server"></asp:Literal><%# Eval("Baslik") %></a>
                                                            </h5>
                                                            <p class="card-text"><%# Eval("KisaAciklama") %></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </div>

            </div>
             </div>
    </form>

    <footer>
        <div class="container sm-my-0 sm-py-40px">
            <div class="row">
                <div class="col-md-3 left-column sm-text-center">
                    <img src="/images/logo-footer.png" alt="">
                    <h6>Sıfırgibimakine.com</h6>
                    <p>Çerkeşliosb Mah. İmes-17 Cad. Küçük Sanayi Sitesi D5 No: 12 İç Kapı No: 1 Dilovası – Kocaeli</p>
                </div>
                <div class="col-md-3 footer-links sm-text-center">
                    <h6>Satış</h6>
                    <a href="/urunler">
                        <p>İlanlar</p>
                    </a>
                    <a href="/makinalarim">
                        <p>İlanları Yönet</p>
                    </a>
                    <a href="/makina-ekle">
                        <p>İlan Ver</p>
                    </a>
                    <a href="/beni-haberdar-et">
                        <p>Beni Haberdar Et</p>
                    </a>
                </div>
                <div class="col-md-3 footer-links sm-text-center">
                    <h6>Kurumsal</h6>
                    <a href="/hakkimizda">
                        <p>Hakkımızda</p>
                    </a>
                    <a href="/sayfalar/9/site-kullanim-sartlari">
                        <p>Site Kullanım Şartları</p>
                    </a>
                    <a href="/sayfalar/11/uyelik-sozlesmesi">
                        <p>Üyelik Sözleşmesi</p>
                    </a>
                    <a href="/sayfalar/13/gizlilik-sozlesmesi">
                        <p>Gizlilik Politikası</p>
                    </a>
                    <a href="/sayfalar/16/sifir-gibi-servis">
                        <p>Sıfır Gibi Servis</p>
                    </a>
                </div>
                <div class="col-md-3 footer-links sm-text-center">
                    <h6>Sosyal Medya</h6>
                    <asp:Repeater ID="rptSosyalmedyaFooter" runat="server">
                        <ItemTemplate>
                            <a href='<%# Eval("Link") %>' target="_blank">
                                <p><%# Eval("Baslik") %></p>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="container footer-bottom">
            <div class="row">
                <div class="col-md-12">
                    <p>Sıfırgibimakine.com Yazılım ve Geliştirme  -Her Hakkı Saklıdır © , 2022 </p>
                </div>
            </div>
        </div>
    </footer>


    <script src="/js/jquery.min.js"></script>
    <script src="/js/owl.carousel.min.js"></script>
    <script src="/js/main.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-fQybjgWLrvvRgtW6bFlB7jaZrFsaBXjsOMm/tB9LTS58ONXgqbR9W8oWht/amnpF" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/wow/1.1.2/wow.min.js" integrity="sha512-Eak/29OTpb36LLo2r47IpVzPBLXnAMPAVypbSZiZ4Qkf8p/7S/XRG5xp7OKWPPYfJT6metI+IORkR5G8F900+g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>

    <%-- <script src="/js/imageUploader.js"></script>--%>

    <script>
        document.addEventListener("DOMContentLoaded", () => {
            const slides = document.querySelectorAll(".slide");
            for (const slide of slides) {
                slide.addEventListener("click", () => {
                    removeActiveClass();
                    slide.classList.add("active");
                });
            }
            function removeActiveClass() {
                slides.forEach((slide) => {
                    slide.classList.remove("active");
                });
            }
        });
    </script>

</body>
</html>
