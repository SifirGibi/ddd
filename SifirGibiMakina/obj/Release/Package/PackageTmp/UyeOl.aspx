<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="SifirGibiMakina.UyeOl" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Üyelik Formu - ikinci el makine sitesi, 2. el satýlýk makine ilanlarý</title>
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
    <meta name="google-site-verification" content="VdBFFfxSw3eiQLiWJ06x59PxzyouEpP4BLiEBL_P5H4" />
    <meta property="og:title" content="Türkiye'nin Ýkinci El Makine Sitesi - 2. el makinalar, 2. el cnc">
    <meta property="og:description" content="Sahibinden ve makine satýcýlarýndan ikinci el satýlýk makina ilanlarý sitesi. Ücretsiz 2.el makine ilaný verilen makina alým satým sitesi.">
    <meta property="og:image" content="../images/logo.png">
    <meta property="og:site_name" content="Türkiye'nin Ýkinci El Makine Sitesi - 2. el makinalar, 2. el cnc">
    <meta property="og:url" content="www.sifirgibimakine.com">
    <meta property="og:type" content="business.business">
    <meta property="fb:app_id" content="">
    <meta name="twitter:card" content="summary">
    <meta name="twitter:title" content="Türkiye'nin Ýkinci El Makine Sitesi - 2. el makinalar, 2. el cnc">
    <meta name="twitter:description" content="Sahibinden ve makine satýcýlarýndan ikinci el satýlýk makina ilanlarý sitesi. Ücretsiz 2.el makine ilaný verilen makina alým satým sitesi.">
    <meta name="revisit-after" content="1 days">
    <link rel="canonical" href="https://www.sifirgibimakine.com"/>
    <meta name="ahrefs-site-verification" content="39d73b6484ef71340eacc9c7cf222c421fbad72df044336436079afc73c3b99a">
    
   
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="/images/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="/images/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="/images/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="/images/ico/apple-touch-icon-57-precomposed.png">

        <!-- Select2 -->
    <link rel="stylesheet" href="/styles/select2.min.css" />

    <!-- Favicons -->
    <link rel="shortcut icon" href="/images/sifir-gibi-makina-fav.png">
    <link href="/images/sifir-gibi-makina-fav.png" rel="icon">
    <link href="/images/sifir-gibi-makina-fav.png" rel="apple-touch-icon">

    <link rel="stylesheet" href="/styles/style.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" integrity="sha384-zCbKRCUGaJDkqS1kPbPd7TveP5iyJE0EjAuZQTgFLD2ylzuqKfdKlfG/eSrtxUkn" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" integrity="sha512-1ycn6IcaQQ40/MKBW2W4Rhis/DbILU74C1vSrLJxCq57o941Ym01SwNsOMqvEBFlcgUa6xLiPY/NS5R+E6ztJQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />

    <link rel="manifest" href="/Scripts/manifest.json">

      <!-- Phone Number -->
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/16.0.8/css/intlTelInput.css" />
    
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
        <form id="form1" runat="server" >
   <!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-W34M7TQ"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
                      <style>

                .form-control {
                    width: 250px;
                }

                select.form-control[multiple], select.form-control[size] {
    display:none;
}
                .iti__selected-dial-code {
  margin-left: 6px;
  font-size: 12px;
}
            </style>

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
                            sýfýrgibimakine.com’<span>a <br> Hoþgeldin! </span>
                        </h1>
                        <p>
                            sifirgibimakine.com'a üye olarak hayalinizdeki makinayý kolayca bulabilir ya da kendi makinanýzý hýzlýca satabilirsiniz.
                        </p>
                    </div>
                </div>
            </div>
              
            
            <div class="col-md-6 px-0">
                <div class="login-left bg-light">
                    <h4>Üye Ol</h4>
                
                        <div class="form-group mb-025rem sm-mb-8">
                            <div class="row">
                                <div class="col-md-6 px-025rem sm-px-15px sm-mb-8">
                                    <div class="form-group mb-0px">
                                        
                                        <asp:DropDownList ID="ddKayitTuru" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddKayitTuru_SelectedIndexChanged" AutoPostBack="true" Width="250px" required="" ValidationGroup="kayit">
                                                <asp:ListItem Text="Lütfen Üyelik Türünü Seçiniz" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Bireysel Üyelik" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Kurumsal Üyelik" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Servis Üyeliði" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Üyelik türü seçilmesi zorunludur." ControlToValidate="ddKayitTuru" ForeColor="#CC3300" InitialValue="0" ValidationGroup="kayit" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6 px-0px sm-px-15px">
                                    <div class="form-group mb-0px">
                                        <asp:DropDownList ID="ddCinsiyet" runat="server" CssClass="form-control" Width="250px">
                                                <asp:ListItem Text="Erkek" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Kadýn" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group mb-025rem sm-mb-8">
                            <div class="row">
                                <div class="col-md-6 px-025rem sm-px-15px sm-mb-8">
                                    <input type="text" class="form-control" id="txtAd" placeholder="Ad" name="txtAd" required="" runat="server" autocomplete="none"/>
                                </div>
                                <div class="col-md-6 px-0px sm-px-15px">
                                    <input type="text" class="form-control" id="txtSoyad" placeholder="Soyad" name="txtSoyad" required="" runat="server"  autocomplete="none">
                                </div>
                            </div>
                        </div>
                        <div class="form-group mb-025rem sm-mb-8">
                            <div class="row">
                                <div class="col-md-6 px-025rem sm-px-15px sm-mb-8">
                                    <input type="email" class="form-control" id="txtEmail" placeholder="E-Posta" name="txtEmail" required="" runat="server"  autocomplete="none" >
                                </div>
                                <div class="col-md-6 px-0px sm-px-15px">
                                    <input type="number" id="txtTelefon" name="txtTelefon" runat="server" class="form-control" required="">
                                    <input type="hidden" id="txtDialCode" name="txtDialCode" runat="server" />
                                </div>
                            </div>
                        </div>
                     <div class="form-group mb-025rem sm-mb-8">
                            <div class="row">
                                <div class="col-md-6 px-025rem sm-px-15px sm-mb-8">
                                      <asp:DropDownList ID="ddUlkeler" runat="server" CssClass="form-control" Width="250" ValidationGroup="kayit">
                                            </asp:DropDownList>
                                </div>
                                <div class="col-md-6 px-0px sm-px-15px">
                                     <input type="text" class="form-control" id="txtSehir" placeholder="Þehir" name="txtsehir" required="" runat="server"  autocomplete="none">
                                </div>
                            </div>
                        </div>
                        <div class="form-group mb-025rem sm-mb-8">
                            <div class="row">
                                <div class="col-md-6 px-025rem sm-px-15px sm-mb-8">
                                   <input type="password" class="form-control" id="txtSifre" placeholder="Þifre" name="txtSifre" required="" runat="server">
                                </div>
                                <div class="col-md-6 px-0px sm-px-15px">
                                    <input type="password" class="form-control" id="txtSifre2" placeholder="Þifre Tekrar" name="txtSifre2" required="" runat="server">
                                </div>
                            </div>
                        </div>

                     <div class="form-group mb-025rem sm-mb-8">
                            <div class="row">
                                <div class="col-md-6 px-025rem sm-px-15px sm-mb-8" style="float:left">
                                     <input type="text" class="form-control" id="txtFirmaAd" placeholder="Firma Adý" name="txtFirmaAd"  runat="server" autocomplete="none" visible="false"/>
                                       
                                </div>
                                
                            </div>
                        </div>
                    <asp:Panel ID="pnlSehir" runat="server" Visible="false">
                     <div class="form-group mb-025rem sm-mb-8">
                            <div class="row">
                                <div class="col-md-6 px-025rem sm-px-15px sm-mb-8" style="float:left">
                                    
          <asp:ListBox SelectionMode="Multiple" runat="server" CssClass="form-control select2"  ID="listSehirler" data-placeholder="Hizmet Verilecek Þehirler" Width="500">
                      </asp:ListBox>
                                
                                   
                                </div>
                                
                            </div>
                        </div>
                                </asp:Panel>
                     <div class="form-group">  
                          <div class="row">
                              <div class="col-md-12 px-025rem sm-px-15px sm-mb-12">
                                            <span id="passNotMatch">
                                                   <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtSifre" ControlToValidate="txtSifre2" ValidationGroup="kayit" ErrorMessage="* Þifreleriniz Eþleþmiyor." ForeColor="Red"></asp:CompareValidator></span>
                          </div>   </div>       
                          </div>
                        <div class="form-group form-check mb-0px mt-3 register-checboxs">
                            <asp:Label ID="lblKod" runat="server" Visible="false"></asp:Label>
                          <input class="form-check-input" type="checkbox" id="gridCheck" required="" runat="server">
                               <label class="form-check-label kabul-et" for="gridCheck">
                            <a href="/sayfalar/11/uyelik-sozlesmesi" target="_blank">Bireysel Üyelik Sözleþmesi ve Ekleri</a>'ni kabul ediyorum.
                          </label>
                        </div>
                        <div class="form-group form-check mb-0px mt-3 register-checboxs">
                              <input class="form-check-input" type="checkbox" id="gridCheckiletisim" runat="server">
                              <label class="form-check-label kabul-et" for="gridCheckiletisim">
                                Ýletiþim bilgilerime kampanya, tanýtým ve reklam içerikli<br /> ticari elektronik ileti gönderilmesine,  izin veriyorum.
                              </label>
                        </div>
                        <div class="text-center">
                             <asp:Button ID="btn_UyeOl" runat="server" Text="Kayýt Ol"  CssClass="btn btn-success login-button" ValidationGroup="kayit" OnClick="btnSave_Click"/>
                        </div>
                        <div class="text-center uye-ol">
                            <p>
                                Zaten üye misin?
                            </p>
                            <a href="/giris">Giriþ Yap</a>
                        </div>
                      <div class="veya">
                            <h5>...</h5>
                        </div>
                        <div class="login-logo sm-d-none">
                            <a href="/"><img src="/images/logo.png" alt=""></a>
                        </div>

                </div>
            </div>
               
           
            <div class="col-md-6 px-0 sm-d-none">
                <div class="login-right">
                    <div class="overlay"></div>
                    <div class="text">
                        <h1>
                            sýfýrgibimakine.com’<span>a Hoþgeldin! </span>
                        </h1>
                        <p>
                            sifirgibimakine.com'a üye olarak hayalinizdeki makinayý kolayca bulabilir ya da kendi makinanýzý hýzlýca satabilirsiniz.
                        </p>
                    </div>
                </div>
            </div>
                
        </div>
    </div>
    
             
</div>

    <script src="/js/jquery.min.js"></script>
    <script src="/js/main.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-fQybjgWLrvvRgtW6bFlB7jaZrFsaBXjsOMm/tB9LTS58ONXgqbR9W8oWht/amnpF" crossorigin="anonymous"></script>

    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/16.0.8/js/intlTelInput-jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            
            var code = ""; // Assigning value from model.
            $('#txtTelefon').val(code);
            $('#txtTelefon').intlTelInput({
                autoHideDialCode: true,
                autoPlaceholder: "ON",
                dropdownContainer: document.body,
                formatOnDisplay: true,
                hiddenInput: "full_number",
                initialCountry: "tr",
                nationalMode: true,
                placeholderNumberType: "MOBILE",
                preferredCountries: ['TR'],
                separateDialCode: true,
                geoIpLookup: "auto"
            });
            $('#btn_UyeOl').on('click', function () {
                var code = $("#txtTelefon").intlTelInput("getSelectedCountryData").dialCode;
                $("#txtDialCode").val(code);
            });

        });
    </script>

            <script>
                $(function () {

                    //Initialize Select2 Elements
                    $('.select2').select2();

                    
                });
            </script>
         <!-- Select2 -->
    <script src="/styles/select2.full.min.js"></script>
</form>
</body>
</html>
