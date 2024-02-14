<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="SifirGibiMakina.Profil" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
    <!-- Phone Number -->

     <link rel="stylesheet" href="/styles/intlTelInput.css" />

        <!-- JS -->
     <style>
  .iti__selected-dial-code {
  margin-left: 6px;
  font-size: 12px;
}
            </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- JS -->
	<script src="//code.jquery.com/jquery-3.2.1.min.js"></script>
	<script src="/fancybox/jquery.fancybox.min.js"></script>

        
            <asp:Panel ID="pnlError" runat="server" Visible="false" Width="450px">
                <div class="alert alert-danger alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-ban"></i> <asp:Label ID="lblHata" runat="server"></asp:Label></h4>
                     <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
                  </div>
             </asp:Panel>
           


    <div class="profilim accordion" id="profil-accordion">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 sm-d-none">
                        <div class="profil-sidebar">
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                      <a <%if (HttpContext.Current.Request.RawUrl == "/profilim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/profilim" class="btn btn-link text-left">
                                      Profilim
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <asp:Panel ID="pnlServisRandevulari" runat="server" Visible="false">
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                      <a <%if (HttpContext.Current.Request.RawUrl == "/servis-randevulari") { Response.Write("class='btn btn-link text-left active'"); }%> href="/servis-randevulari" class="btn btn-link text-left">
                                      Servis Randevuları
                                    </a>
                                  </h2>
                                </div>
                            </div>
                                </asp:Panel>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/makinam-ne-eder") { Response.Write("class='btn btn-link text-left active'"); }%> href="/makinam-ne-eder" class="btn btn-link text-left">
                                        Makinem Ne Eder?
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                     <a <%if (HttpContext.Current.Request.RawUrl == "/makina-ekle") { Response.Write("class='btn btn-link text-left active'"); }%> href="/makina-ekle" class="btn btn-link text-left">
                                        Makine Sat
                                     </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/makinalarim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/makinalarim" class="btn btn-link text-left">
                                      Makinelerim
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/ihalelerim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/ihalelerim" class="btn btn-link text-left">
                                      İhalelerim
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/odeme-bildirimi") { Response.Write("class='btn btn-link text-left active'"); }%> href="/odeme-bildirimi" class="btn btn-link text-left">
                                        Ödeme Bildirimi
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/favorilerim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/favorilerim" class="btn btn-link text-left">
                                      Favorilerim
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/mesajlarim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/mesajlarim" class="btn btn-link text-left">
                                        Mesajlarım (<asp:Label ID="lblOkunmamis" runat="server" ForeColor="Red"></asp:Label>)
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/cikis") { Response.Write("class='btn btn-link text-left active'"); }%> href="/cikis" class="btn btn-link text-left">
                                        Çıkış Yap
                                    </a>
                                  </h2>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-9 profil-right-box">
                        <div>
                            <div class="card-body">
                                <div class="mb-3">
                                    <h5 class="form-title">
                                        Kişisel Bilgiler
                                    </h5>
                                    <div class="row">
                                        <div class="col-md-6 pr-025rem sm-px-8">
                                            <div class="form-group">
                                                <input type="text" class="form-control" id="txtAdi" placeholder="Adınız" runat="server">
                                            </div>
                                        </div>
                                        <div class="col-md-6 pl-025rem sm-px-8">
                                            <div class="form-group">
                                                <input type="text" class="form-control" id="txtSoyadi" placeholder="Soyadınız" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 pr-025rem sm-px-8">
                                            <div class="form-group">
                                                <input type="date" class="form-control" id="txtDogumTarihi" value="1996-01-17" placeholder="Doğum Tarihi" runat="server">
                                            </div>
                                        </div>
                                        <div class="col-md-6 pl-025rem sm-px-8">
                                            <div class="form-group">
                                                <input type="number" class="form-control" id="txtTCK" placeholder="T.C. Kimlik No" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="mb-3">
                                    <h5 class="form-title">
                                        İletişim Bilgileri
                                    </h5>
                                    <div class="row">
                                        <div class="col-md-6 pr-025rem sm-px-8">
                                            <div class="form-group">
                                                <input type="tel" id="txtTelefon" name="txtTelefon" runat="server" class="form-control" required="" style="width:250px">
                                                  <input type="hidden" id="txtDialCode" name="txtDialCode" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6 pl-025rem sm-px-8">
                                            <div class="form-group">
                                                <input type="text" class="form-control" id="txtEmail" placeholder="E-Posta" runat="server" readonly="readonly">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4 pr-025rem sm-px-8">
                                            <div class="form-group">
                                               <asp:DropDownList ID="ddUlkeler" runat="server" CssClass="form-control select2" Width="100%"> </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4 pr-025rem sm-px-8">
                                            <div class="form-group">
                                                <input type="text" class="form-control" id="txtIl" placeholder="İl" runat="server">
                                            </div>
                                        </div>
                                        <div class="col-md-4 pl-025rem sm-px-8">
                                            <div class="form-group">
                                                <input type="text" class="form-control" id="txtIlce" placeholder="İlçe" runat="server">
                                            </div>
                                        </div>
                                        <div class="col-md-12 sm-px-8">
                                            <div class="form-group">
                                                <textarea class="form-control" id="txtAdres" rows="6" placeholder="Adres" runat="server"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="mb-3">
                                    
                                    <div class="row">
                                        <div class="col-md-6 pr-025rem sm-px-8">
                                            <h5 class="form-title">
                                        Kullanıcı Şifresi
                                    </h5>
                                            <div class="form-group">
                                                <asp:TextBox ID="TxtYeniSifre" runat="server" class="form-control" TextMode="Password" placeholder="Şifre" ValidationGroup="profil"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="col-md-6 pr-025rem sm-px-8">
                                             <asp:Panel ID="pnlFirmaAdi" runat="server" Visible="false">
                                            <div class="form-group">
                                                <h5 class="form-title">
                                       Firma Adı
                                    </h5>
                                                <asp:TextBox ID="txtFirmaAdi" runat="server" class="form-control" TextMode="SingleLine" placeholder="Firma Adı" ValidationGroup="profil" Visible="false"></asp:TextBox>
                                            </div>
                                                 </asp:Panel>
                                        </div>
                                </div>
                                <div class="text-center">
                                    <asp:Button ID="btnProfilSave" runat="server" Text="Profilimi Güncelle" CssClass="btn btn-success kaydet-button" Width="150px" OnClick="btnProfilSave_Click" ValidationGroup="profil"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>

</asp:Content>
