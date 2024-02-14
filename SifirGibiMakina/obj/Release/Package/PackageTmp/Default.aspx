<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SifirGibiMakina.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>ikinci el makine sitesi, 2. el satýlýk makine ilanlarý</title>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1254">
    <meta http-equiv="Content-Language" content="tr">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="robots" content="index, follow">
    <meta name="robots" content="index, archive">
    <meta name="robots" content="all">
    <meta name="googlebot" content="index, follow">
    <meta name="googlebot" content="index, archive">
    <meta name="googlebot" content="all">
    <meta name="description" content="Türkiye'nin ikinci el makine ilanlarý sitesi. 2.el CNC makinalarý. CNC-Torna-Dik iþlem-Abkant-Giyotin Freze, Pres, Lazer, Punch, Matkap.">
    <meta name="author" content="FümeGri Digital Solutions">
    <meta name="google-site-verification" content="ZdyBUARpp4bAwzrhMbkS26g64Kt0Ro2w7SL0QgOtO7w" />
    <meta property="og:type" content="business.business">
    <meta property="fb:app_id" content="">
    <meta name="twitter:card" content="summary">
    <meta name="twitter:title" content="Türkiye'nin Ýkinci El Makine Sitesi - 2. el makinalar, 2. el cnc">
    <meta name="twitter:description" content="Sahibinden ve makine satýcýlarýndan ikinci el satýlýk makina ilanlarý sitesi. Ücretsiz 2.el makine ilaný verilen makina alým satým sitesi.">
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
                        <div class="col">
                            <a data-toggle="collapse" href="#searchBar" aria-expanded="false" aria-controls="searchBar">
                                <svg xmlns="https://www.w3.org/2000/svg" class="menu-icon" fill="none" viewbox="0 0 24 24" stroke="currentColor">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
                                </svg>
                                <p>Arama</p>
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <div class="topbar">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <a href="/ekspertiz" class="topbar-item">Sýfýr Gibi Ekspertiz</a>
                            <a href="/servis" class="topbar-item">Sýfýr Gibi Servis</a>
                            <a href="/hakkimizda" class="topbar-item">Hakkýmýzda</a>
                            <a href="/blog" class="topbar-item">Blog</a>
                            <a href="/iletisim" class="topbar-item">Ýletiþim</a>
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
                                    <li>Sýfýr Gibi Ekspertiz</li>
                                </a>
                                <a href="/servis">
                                    <li>Sifir Gibi Servis</li>
                                </a>
                                <a href="/hakkimizda">
                                    <li>Hakkýmýzda</li>
                                </a>
                                <a href="/blog">
                                    <li>Blog</li>
                                </a>
                                <a href="/iletisim">
                                    <li>Ýletiþim</li>
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


                    <a class="navbar-brand" href="/">
                        <img src="/images/logo.png" alt="">
                    </a>

                    <%if (Session["Giris"] == null)
                        {%>
                    <div class="nav-login-success just-mobile">
                        <a href="https://en.sifirgibimakine.com">
                            <img src="/images/GB.gif" /></a>
                        <a href="https://de.sifirgibimakine.com">
                            <img src="/images/DE.gif" /></a>
                        <a href="https://ru.sifirgibimakine.com">
                            <img src="/images/RU.gif" /></a><br />
                        <a href="/giris"><span class="btn btn-success" style="width: 100px; margin-bottom: 5px">Giriþ Yap</span></a><br />
                        <a href="/uye-ol"><span class="btn btn-outline-secondary" style="width: 100px">Üye Ol</span></a>


                        <%--<div class="dropdown">
                        <button class="btn btn-link px-0 dropdown-toggle" type="button" id="dropdownMenuButtonUye" data-toggle="dropdown" aria-expanded="false">
                            <div class="user-icon">
                                <i class="far fa-user"></i>
                            </div>
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonUye">
                            <a class="dropdown-item" href="/giris"><i class="fas fa-user"></i> Giriþ Yap</a>
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
                                <a class="dropdown-item" href="/ihalelerim"><i class="fas fa-list-ul"></i>Ýhalelerim</a>
                                <a class="dropdown-item" href="/odeme-bildirimi"><i class="fas fa-wallet"></i>Ödeme Bildirimi</a>
                                <a class="dropdown-item" href="/favorilerim"><i class="fas fa-star"></i>Favorilerim</a>
                                <a class="dropdown-item" href="/mesajlarim"><i class="fas fa-comment-alt"></i>Mesajlarým</a>
                                <a class="dropdown-item" href="/cikis"><i class="fas fa-sign-out-alt"></i>Çýkýþ Yap</a>
                            </div>
                        </div>

                    </div>
                    <%} %>


                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <input class="form-inline my-2 my-lg-0 form-control rounded-0" type="search" placeholder="Marka, Model veya Ýlan No ile Arayýn" aria-label="Search" runat="server" id="search_input" name="search_input">
                        <button class="btn btn-secondary rounded-0 my-2 my-sm-0" type="submit" runat="server" id="btnsearch" onserverclick="btnSearch_Click">
                            <i class="fas fa-search"></i>
                        </button>

                    </div>
                    <div class="nav-login-register sm-d-none">
                        <%if (Session["Giris"] == null)
                            {%>
                        <a href="/giris">
                            <span class="btn btn-success">Giriþ Yap</span>
                        </a>
                        <%}
                            else if (Session["Giris"].ToString() == "OK")
                            { %>
                        <div class="nav-login-success">
                            <div class="dropdown">
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
                                    <a class="dropdown-item" href="/ihalelerim"><i class="fas fa-list-ul"></i>Ýhalelerim</a>
                                    <a class="dropdown-item" href="/odeme-bildirimi"><i class="fas fa-wallet"></i>Ödeme Bildirimi</a>
                                    <a class="dropdown-item" href="/favorilerim"><i class="fas fa-star"></i>Favorilerim</a>
                                    <a class="dropdown-item" href="/mesajlarim"><i class="fas fa-comment-alt"></i>Mesajlarým</a>
                                    <a class="dropdown-item" href="/cikis"><i class="fas fa-sign-out-alt"></i>Çýkýþ Yap</a>
                                </div>
                            </div>
                        </div>

                        <%} %>
                        <%if (Session["Giris"] == null)
                            {%>
                        <a href="/uye-ol">
                            <span class="btn btn-outline-secondary">Üye Ol</span>
                        </a>
                        <%} %>
                    </div>
                </div>
            </nav>

            <div class="search-bar-collapse just-mobile">
                <div class="collapse" id="searchBar">
                    <div class="card card-body">
                        <div class="profil my-0">
                            <div class="profil-right-box">
                                <input class="form-control rounded-0" type="search" placeholder="Marka, Model veya Ýlan No ile Arayýn" aria-label="Search" id="txtSearchMobil" runat="server">
                                <button class="btn btn-secondary rounded-0" type="submit" id="btnmobilsearch" runat="server" onserverclick="btnSearchMobil_Click">
                                    <i class="fas fa-search"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container pb-5">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Repeater ID="rptReklamAlaniHeader" runat="server" OnItemDataBound="rptReklamAlaniHeader_ItemDataBound">
                            <ItemTemplate>
                                <div class="text-center">
                                    <asp:Literal ID="ltLink" runat="server"></asp:Literal>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

            <%--Web Slider--%>
            <div class="banner-slider sm-d-none">
                <div class="container-fluid px-0">
                    <div class="slide active slide-1" style="background-image: url('/images/slider/12c48526513e4210a8c31f79d2b114ac.jpg');">
                        <div class="overlay">
                            <img src="/images/logo-dikey.png" alt="">
                        </div>
                        <div class="slider-text">
                            <h5>TÜRKÝYE’NÝN MAKÝNE PAZARI
                                <br>
                                KOLAY. GÜVENLÝ. HIZLI.</h5>
                            <p>
                                Hangi sektörde olursan ol, ihtiyacýn olan makineyi burada anýnda bulur,
                                <br>
                                elindekini deðerine satarsýn.
                            </p>

                        </div>
                    </div>
                    <div class="slide slide-2" style="background-image: url('/images/slider/9c9664d44aea4fd9b64758326698bed7.jpg');">
                        <div class="overlay">
                            <img src="/images/logo-dikey.png" alt="">
                        </div>
                        <div class="slider-text">
                            <h5>TEK TIKLA,
                                <br>
                                DÜNYANIN DÖRT BÝR YANINDA! </h5>
                            <p>
                                Ýhtiyacýn olan makine aslýnda çok yakýnda. 
                                <br>
                                Yurt içi ya da yurt dýþý fark etmez, Sýfýr Gibi Makine sýnýrlarý kaldýrýr. 
                            </p>

                        </div>
                    </div>
                    <div class="slide slide-2" style="background-image: url('/images/slider/71e0b981cc7b4e44bbf1d5b4d3282d2f.jpg');">

                        <div class="overlay">
                            <img src="/images/logo-dikey.png" alt="">
                        </div>
                        <div class="slider-text">
                            <h5>SIFIR GÝBÝ MAKÝNE
                                <br>
                                DEÐERÝNÝ BÝLÝR.</h5>
                            <p>
                                Piyasa rekabeti, makinenin modeli, yaþý, kalitesi…
                                <br>
                                Tüm detaylarý senin için düþünür en iyi fiyatý birlikte belirleriz. 
                            </p>

                        </div>
                    </div>
                    <!-- Diðer slaytlarý buraya ekleyin -->
                </div>
            </div>

            <%--        Mobil Slider--%>
            <div id="main-carousel" class="carousel slide just-mobile" data-ride="carousel" data-interval="5000">
                <ol class="carousel-indicators">
                    <li data-target="#main-carousel" data-slide-to="0" class="active"></li>
                    <li data-target="#main-carousel" data-slide-to="1"></li>
                    <li data-target="#main-carousel" data-slide-to="2"></li>
                
                </ol>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="/images/slidermobil/3457408d50cf4a09968cfc000b71ff4e.jpg" class="d-block w-100" alt="carousel-1">
                        <div class="carousel-caption d-none d-md-block">
                    
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img src="/images/slidermobil/6fab3ba850a14ab68a1b249fcd6e66a7.jpg" class="d-block w-100" alt="carousel-2">
                        <div class="carousel-caption d-none d-md-block">
                    
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img src="/images/slidermobil/afde6cd0a2f94f80a2f46ae47fe6ad0a.jpg" class="d-block w-100" alt="carousel-3">
                        <div class="carousel-caption d-none d-md-block">
                     
                        </div>
                    </div>
                  
                </div>
              
            </div>




            <div class="makine-al-sat">
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
                            <h4>Hemen makine alýp satmaya baþlayýn!</h4>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Vitrin Makinalarý -->
           <div class="sifir-gibi-vitrin">

                <div class="container border-bottom pb-5">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="title-button">
                                <h4>Sýfýr Gibi Vitrin</h4>
                                <a href="/urunler">
                                    <span class="btn btn-success sm-d-none">Tümünü Gör <i class="fas fa-chevron-right ml-2"></i></span>
                                </a>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5">
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
                                                <a href="/kategori/<%# ReWriterPath("1", Eval("Tur").ToString(), "1")%>/ikinci-el-makina/<%# Eval("tur_ID") %>"><%# Eval("Tur") %></a>
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
                                                        <span class="fs-8px ln-8px">Yýl
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
                                                        <a href="/kategori/<%# ReWriterPath("1", Eval("Tur").ToString(), "1")%>/ikinci-el-makina/<%# Eval("tur_ID") %>"><%# Eval("Tur") %></a>
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
                                                                <span class="fs-8px ln-8px">Yýl
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

<%--            Maðazalar--%>

            <div class="sifir-gibi-magazalar">
                <div class="container border-bottom py-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="title">
                                <h4>Sýfýr Gibi Maðazalar</h4>
                                <p>Siz de <span class="text-success">Sýfýr Gibi Maðaza</span> avantajlarýndan yararlanmak için buraya ilan verin!</p>
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
                            <a href="/iletisim">Buraya Ýlan Ver <i class="fas fa-chevron-right"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Kýsa Açýklamalar -->
            <div class="neden-sifir-gibi-makine py-5 sm-my-0">
                <div class="container sm-d-none">
                    <div class="row mb-4">
                        <div class="col-md-12">
                            <h4 class="title">Neden Sýfýr Gibi
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
                                    <h5 class="card-title">Açýk Arttýrmaya Nasýl Katýlabilirim?</h5>
                                    <p class="card-text">Ýnternet üzerinden ikinci el makina satýn almanýzý saðlayan Sýfýrgibi makina...   </p>
                                    <a href="/sayfalar/2/acik-artirmaya-nasil-katilabilirim" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/satis-sonrasi.png" alt="">
                                    <h5 class="card-title">Satýþ Sonrasý</h5>
                                    <p class="card-text">Makinanýz sifirgibimakina aracýlýðýyla satýldýktan sonra, satýþ bedeli...  </p>
                                    <a href="/sayfalar/3/satis-sonrasi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/exper.png" alt="">
                                    <h5 class="card-title">Teknik Destek</h5>
                                    <p class="card-text">Sýfýrgibi Makina oluþturduðu büyük servis aðý, kendi bünyesinde yer alan...   </p>
                                    <a href="/sayfalar/4/teknik-destek" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/lojistik.png" alt="">
                                    <h5 class="card-title">Lojistik Teslimat</h5>
                                    <p class="card-text">Tüm makina satýþlarýnýn yükleme,nakliye,indirme vb. tüm iþlemlerin sorumluluklarý...  </p>
                                    <a href="/sayfalar/5/lojistik-teslimat" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/iade.png" alt="">
                                    <h5 class="card-title">Ýade Koþullarý</h5>
                                    <p class="card-text">Sýfýrgibi makina müþterilerine makinalarý yerinde çalýþýr durumda bakma...  </p>
                                    <a href="/sayfalar/7/iade-kosullari" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/sartlar.png" alt="">
                                    <h5 class="card-title">Site Kullaným Þartlarý</h5>
                                    <p class="card-text">Bu sitenin sunumu ve tüm içeriði T.C. Mevzuatý ve fikri mülkiyet mevzuatý...  </p>
                                    <a href="/sayfalar/9/site-kullanim-sartlari" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/sozlesme.png" alt="">
                                    <h5 class="card-title">Üyelik Sözleþmesi</h5>
                                    <p class="card-text">Ýþbu sözleþme, www.sifirgibimakine.com adresinde faaliyet gösteren... </p>
                                    <a href="/sayfalar/11/uyelik-sozlesmesi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/ihale.png" alt="">
                                    <h5 class="card-title">Ýhale Katýlým Sözleþmesi</h5>
                                    <p class="card-text">www.sifirgibimakine.com sitesi üzerinden hazýrlanan  ve sitede... </p>
                                    <a href="/sayfalar/12/ihale-katilim-sozlesmesi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container nsgm-mobile just-mobile">
                    <div class="row mb-4">
                        <div class="col-md-12">
                            <h4 class="title">Neden Sýfýr Gibi Makine?</h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="owl-carousel owl-theme" id="neden-sifir-gibi-makine">
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Açýk Arttýrmaya Nasýl Katýlabilirim?</h5>
                                            <p class="card-text">Ýnternet üzerinden ikinci el makina satýn almanýzý saðlayan Sýfýrgibi makina...  </p>
                                            <a href="/sayfalar/2/acik-artirmaya-nasil-katilabilirim" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Satýþ Sonrasý</h5>
                                            <p class="card-text">Makinanýz sifirgibimakina aracýlýðýyla satýldýktan sonra, satýþ bedeli...  </p>
                                            <a href="/sayfalar/3/satis-sonrasi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Teknik Destek</h5>
                                            <p class="card-text">Sýfýrgibi Makina oluþturduðu büyük servis aðý, kendi bünyesinde yer alan...  </p>
                                            <a href="/sayfalar/4/teknik-destek" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Lojistik Teslimat</h5>
                                            <p class="card-text">Tüm makina satýþlarýnýn yükleme,nakliye,indirme vb. tüm iþlemlerin sorumluluklarý...  </p>
                                            <a href="/sayfalar/5/lojistik-teslimat" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Ýade Koþullarý</h5>
                                            <p class="card-text">Sýfýrgibi makina müþterilerine makinalarý yerinde çalýþýr durumda bakma...  </p>
                                            <a href="/sayfalar/7/iade-kosullari" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Site Kullaným Þartlarý</h5>
                                            <p class="card-text">Bu sitenin sunumu ve tüm içeriði T.C. Mevzuatý ve fikri mülkiyet mevzuatý...  </p>
                                            <a href="/sayfalar/9/site-kullanim-sartlari" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Üyelik Sözleþmesi</h5>
                                            <p class="card-text">Ýþbu sözleþme, www.sifirgibimakine.com adresinde faaliyet gösteren...  </p>
                                            <a href="/sayfalar/11/uyelik-sozlesmesi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="item">
                                    <div class="card neden-card border-0">
                                        <div class="card-body">
                                            <img src="images/neden-icon.png" alt="">
                                            <h5 class="card-title">Ýhale Katýlým Sözleþmesi</h5>
                                            <p class="card-text">www.sifirgibimakine.com sitesi üzerinden hazýrlanan ve sitede...  </p>
                                            <a href="/sayfalar/12/ihale-katilim-sozlesmesi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Makina Deðerleri -->
            <asp:Panel ID="pnlSayilar" runat="server" Visible="false">
                <div class="sgm-degerler py-5">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <h4 class="title text-center">Sýfýrgibimakine.com Deðerleri</h4>
                            </div>
                        </div>
                        <div class="row mt-4 countdown">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                                <asp:Literal ID="ltSatilanMakina" runat="server"></asp:Literal>
                                <p>Adet Makine Satýldý</p>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                                <asp:Literal ID="ltUyeSayisi" runat="server"></asp:Literal>
                                <p>Kiþi Üye Oldu</p>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-6">
                                <asp:Literal ID="ltAcikArtirmaUye" runat="server"></asp:Literal>
                                <p>Kiþi Açýk Arttýrmaya Katýldý</p>
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
                                Makineni deðerinde alýcý ile buluþturmanýn En kolay yolu sifirgibimakine.com’da. Uzman exper ekibimiz tarafýndan makinanýn takribi deðerini öðrenin.
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
                                        <label class="subtitle">Makine Markasý</label>
                                        <asp:DropDownList ID="ddMarkalar" runat="server" CssClass="form-control select-input"></asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label class="subtitle">Makine Üretim Yýlý</label>
                                        <asp:DropDownList ID="ddYillar" runat="server" CssClass="form-control select-input"></asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="sdm-ne-eder-button">
                                <a href="/makinam-ne-eder">
                                    <span class="btn btn-success">Makinemi Deðerle</span>
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
                <h4 class="title">Sýfýr Gibi Makine Kategorileri</h4>
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
                                                        <a href="/kategori/<%# ReWriterPath("1", Eval("Tur").ToString(), "1")%>/ikinci-el-makina/<%# Eval("tur_ID") %>"><%# Eval("Tur") %></a>
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
                                                                <span class="fs-8px ln-8px">Yýl
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
                <asp:Panel ID="pnlIhale" runat="server" Visible="false">
                    <!-- Ýhale Ürünleri -->
                    <div class="container py-5">
                        <div class="row">
                            <div class="col-md-12">
                                <h4 class="title">Sýfýr Gibi Ýhale</h4>
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
                                                                <p>Ýhale Süresi Dolmuþtur.</p>
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
                                                            <a href="/kategori/<%# ReWriterPath("1", Eval("Tur").ToString(), "1")%>/ikinci-el-makina/<%# Eval("tur_ID") %>"><%# Eval("Tur") %></a>
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
                                                                    <span class="fs-8px ln-8px">Yýl
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
            </div>
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
                                    <p class="subtitle">Makina ve sanayi hakkýnda güncel makalelerimiz</p>
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
                    <h6>Sýfýrgibimakine.com</h6>
                    <p>Çerkeþliosb Mah. Ýmes-17 Cad. Küçük Sanayi Sitesi D5 No: 12 Ýç Kapý No: 1 Dilovasý – Kocaeli</p>
                </div>
                <div class="col-md-3 footer-links sm-text-center">
                    <h6>Satýþ</h6>
                    <a href="/urunler">
                        <p>Ýlanlar</p>
                    </a>
                    <a href="/makinalarim">
                        <p>Ýlanlarý Yönet</p>
                    </a>
                    <a href="/makina-ekle">
                        <p>Ýlan Ver</p>
                    </a>
                    <a href="/beni-haberdar-et">
                        <p>Beni Haberdar Et</p>
                    </a>
                </div>
                <div class="col-md-3 footer-links sm-text-center">
                    <h6>Kurumsal</h6>
                    <a href="/hakkimizda">
                        <p>Hakkýmýzda</p>
                    </a>
                    <a href="/sayfalar/9/site-kullanim-sartlari">
                        <p>Site Kullaným Þartlarý</p>
                    </a>
                    <a href="/sayfalar/11/uyelik-sozlesmesi">
                        <p>Üyelik Sözleþmesi</p>
                    </a>
                    <a href="/sayfalar/13/gizlilik-sozlesmesi">
                        <p>Gizlilik Politikasý</p>
                    </a>
                    <a href="/sayfalar/16/sifir-gibi-servis">
                        <p>Sýfýr Gibi Servis</p>
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
                    <p>Sýfýrgibimakine.com Yazýlým ve Geliþtirme  -Her Hakký Saklýdýr © , 2022 </p>
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
