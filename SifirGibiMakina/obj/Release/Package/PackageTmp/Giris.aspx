<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="SifirGibiMakina.Giris" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>ikinci el makine sitesi, 2. el sat�l�k makine ilanlar�</title>
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
    <meta name="description" content="T�rkiye'nin ikinci el makine ilanlar� sitesi. 2.el CNC makinalar�. CNC-Torna-Dik i�lem-Abkant-Giyotin Freze, Pres, Lazer, Punch, Matkap.">
    <meta name="author" content="F�meGri Digital Solutions">
    <meta name="google-site-verification" content="VdBFFfxSw3eiQLiWJ06x59PxzyouEpP4BLiEBL_P5H4" />
<%--    <meta property="og:title" content="T�rkiye'nin �kinci El Makine Sitesi - 2. el makinalar, 2. el cnc">
    <meta property="og:description" content="Sahibinden ve makine sat�c�lar�ndan ikinci el sat�l�k makina ilanlar� sitesi. �cretsiz 2.el makine ilan� verilen makina al�m sat�m sitesi.">
    <meta property="og:image" content="../images/logo.png">
    <meta property="og:site_name" content="T�rkiye'nin �kinci El Makine Sitesi - 2. el makinalar, 2. el cnc">
    <meta property="og:url" content="www.sifirgibimakine.com">--%>
    <meta property="og:type" content="business.business">
    <meta property="fb:app_id" content="">
    <meta name="twitter:card" content="summary">
    <meta name="twitter:title" content="T�rkiye'nin �kinci El Makine Sitesi - 2. el makinalar, 2. el cnc">
    <meta name="twitter:description" content="Sahibinden ve makine sat�c�lar�ndan ikinci el sat�l�k makina ilanlar� sitesi. �cretsiz 2.el makine ilan� verilen makina al�m sat�m sitesi.">
    <meta name="revisit-after" content="1 days">
    <link rel="canonical" href="https://www.sifirgibimakine.com"/>
    <meta name="ahrefs-site-verification" content="39d73b6484ef71340eacc9c7cf222c421fbad72df044336436079afc73c3b99a">
    
   
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="/images/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="/images/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="/images/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="/images/ico/apple-touch-icon-57-precomposed.png">

    <!-- Favicons -->
    <link rel="shortcut icon" href="/images/sifir-gibi-makina-fav.png">
    <link href="/images/sifir-gibi-makina-fav.png" rel="icon">
    <link href="/images/sifir-gibi-makina-fav.png" rel="apple-touch-icon">

    <link rel="stylesheet" href="/styles/style.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" integrity="sha384-zCbKRCUGaJDkqS1kPbPd7TveP5iyJE0EjAuZQTgFLD2ylzuqKfdKlfG/eSrtxUkn" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" integrity="sha512-1ycn6IcaQQ40/MKBW2W4Rhis/DbILU74C1vSrLJxCq57o941Ym01SwNsOMqvEBFlcgUa6xLiPY/NS5R+E6ztJQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />

    <link rel="manifest" href="/Scripts/manifest.json">

</head>
<body>
        <form id="form1" runat="server" >
    <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-175351405-1"></script>
<script>
    window.dataLayer = window.dataLayer || [];
    function gtag() { dataLayer.push(arguments); }
    gtag('js', new Date());

    gtag('config', 'UA-175351405-1');
</script>
 <div class="section">
     <asp:Panel ID="pnlError" runat="server" Visible="false" Width="450px">
     <div class="alert alert-danger alert-dismissable">
      <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
       <h5>	<i class="icon fa fa-ban"></i> <asp:Label ID="lblHata" runat="server"></asp:Label></h5>
       <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
     </div>
   </asp:Panel>
    <div class="container-fluid px-0">
        <div class="row">
            <div class="col-12 mobile-login just-mobile">
                <div class="login-right">
                    <div class="overlay"></div>
                    <div class="text">
                        <h1>
                            s�f�rgibimakine.com�<span>a <br> Ho�geldin! </span>
                        </h1>
                        <p>
                            sifirgibimakine.com'a �ye olarak hayalinizdeki makinay� kolayca bulabilir ya da kendi makinan�z� h�zl�ca satabilirsiniz.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-6 px-0">
                <div class="login-left bg-light">
                    <h4>�ye Giri�i</h4>
                        <div class="form-group mb-1">
                            <input type="email" class="form-control" name="txtEmail" id="txtEmail" placeholder="E-Posta" runat="server" required="" size="50">
                        </div>
                        <div class="form-group mb-3">
                            <input type="password" class="form-control" name="txtSifre" id="txtSifre" placeholder="�ifre" runat="server" required="" size="50">
                        </div>
                        <div class="form-group form-check mb-0">

                          <a href="/sifremi-unuttum" class="sifremi-unuttum">�ifremi Unuttum</a>
                        </div>
                        <div class="text-center">
                            <asp:Label ID="lblAciklama" runat="server" Visible="false" CssClass="alert-danger text-center align-content-center" Width="100%" Font-Bold="true"></asp:Label>
                            <asp:Button ID="btnGiris" runat="server" Text="Giri� Yap"  CssClass="btn btn-success login-button" OnClick="btnGiris_Click"/>
                        </div>
                        <div class="text-center uye-ol">
                            <p>
                                Hen�z �ye de�il misin?
                            </p>
                            <a href="/uye-ol">�ye Ol</a>
                        </div>
                        
                        <div class="login-logo">
                            <a href="/"><img src="/images/logo.png" alt=""></a>
                        </div>
                   
                </div>
            </div>
            <div class="col-md-6 px-0 sm-d-none">
                <div class="login-right">
                    <div class="overlay"></div>
                    <div class="text">
                        <h1>
                            s�f�rgibimakine.com�<span>a Ho�geldin! </span>
                        </h1>
                        <p>
                            sifirgibimakine.com'a �ye olarak hayalinizdeki makinay� kolayca bulabilir ya da kendi makinan�z� h�zl�ca satabilirsiniz.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</div>
    <script src="//cdn.segmentify.com/1f98b5f6-c687-4682-acdf-e69d797e9ebb/segmentify.js" charset="UTF-8"></script>
    <script src="/js/jquery.min.js"></script>
    <script src="/js/main.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-fQybjgWLrvvRgtW6bFlB7jaZrFsaBXjsOMm/tB9LTS58ONXgqbR9W8oWht/amnpF" crossorigin="anonymous"></script>
</form>
</body>
</html>