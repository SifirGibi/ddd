<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Urun_Detail.aspx.cs" Inherits="SifirGibiMakina.Urun_Detail" %>


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
 <!-- FancyBox -->
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox.min.css">

    <!-- Phone Number -->
     <link rel="stylesheet" href="/styles/intlTelInput.css" />

        <!-- JS -->
     <style>
  .iti__selected-dial-code {
  margin-left: 6px;
  font-size: 12px;
}
            </style> 
    <link rel="stylesheet" type="text/css" href="/styles/flip-clock.css">
    <link rel="stylesheet" type="text/css" href="/styles/cssanimation.css">
   <%-- <script type="text/javascript" src="//platform-api.sharethis.com/js/sharethis.js#property=#{property?._id}&product=custom-share-buttons"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="/fancybox/jquery.fancybox.min.js"></script>
    <!-- FancyBox -->

    <asp:ScriptManager runat="server" ></asp:ScriptManager>
                <asp:Panel ID="pnlError" runat="server" Visible="false" Width="450px">
                <div class="alert alert-danger alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-ban"></i> <asp:Label ID="lblHata" runat="server"></asp:Label></h4>
                     <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
                  </div>
             </asp:Panel>

             <div class="breadcrumb-comp">
          <div class="container">
            <div class="row">
              <div class="col-md-12">
                <a href="/">Anasayfa</a>
                <span><i class="fas fa-angle-right"></i></span>
                <a href="/Ilanlar.aspx">Makine Al</a>
                <span><i class="fas fa-angle-right"></i></span>
                <asp:Literal ID="ltTur2" runat="server"></asp:Literal>
                <span><i class="fas fa-angle-right"></i></span>
                <p><asp:Label ID="lblBaslik" runat="server"></asp:Label></p>
              </div>
            </div>
          </div>
        </div>
    
        <div class="urun-detay bg-light sm-py-0">
            <div class="container">
                <div class="row">
                    <div class="urun-detay just-mobile text-center">
                        <div class="col-12">
                            <div class="row">
                                <div class="col-12">
                                    <div class="d-flex justify-content-around align-items-center">
                                        <p class="seri-no"><asp:Label ID="lblilanNo" runat="server"></asp:Label></p>
                                        <p class="date"><asp:Label ID="lblYayinTarihi" runat="server" CssClass="date"></asp:Label></p>
                                    </div>
                                </div>
                                <div class="col-12">
                                     <img src="/images/LIVE2.gif" runat="server" id="live" visible="false" width="50" height="50"/>
                                    <h4 class="title"><asp:Label ID="lblBaslik1" runat="server" CssClass="title"></asp:Label></h4>
                                </div>
                                <div class="col-12">
                                    <h5 class="location">
                                        <i class="fas fa-map-marker-alt"></i>
                                        <asp:Label ID="lblil" runat="server"></asp:Label>
                                    </h5>
                                </div>
                                <div class="col-12">
                                   <asp:Literal ID="ltTeklifTalebi1" runat="server" Visible="false"></asp:Literal>
                                    <h3 class="price">
                                       <asp:Literal ID="ltFiyat" runat="server"></asp:Literal>	<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal>
                                    </h3>
                                     
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-7">

                        <asp:Literal ID="ltResim" runat="server" Visible="false"></asp:Literal>

                       <div class="owl-carousel owl-theme" id="urun-detay-slider">

                           <asp:Repeater ID="rptGaleri" runat="server" OnItemDataBound="rptGaleri_ItemDataBound">
                               <ItemTemplate>
                                   <div class="item" data-hash="<%# Eval("makinaResim_ID") %>">
                                       <asp:Literal ID="ltResim" runat="server"></asp:Literal>
                                        
                            </div>
                                   </ItemTemplate>

                           </asp:Repeater>

                        </div>
                        <div class="mt-3">
                            <div class="row px-2">

                                 <asp:Repeater ID="rptGaleri1" runat="server" OnItemDataBound="rptGaleri1_ItemDataBound">
                               <ItemTemplate>
                                      <div class="col-lg-3 col-md-3 col-sm-3 col-3 px-1">
                                    <a class="button secondary url" href="#<%# Eval("makinaResim_ID") %>">
                                        <asp:Literal ID="ltResim" runat="server"></asp:Literal>
                                    </a> <br /><br />
                                </div>
                                   </ItemTemplate>

                           </asp:Repeater>

                            </div>
                        </div>
                    </div>

                    <div class="col-md-5">
                        <h3 class="title"><asp:Label ID="lblBaslik2" runat="server" CssClass="title"></asp:Label></h3>
                        <p class="seri-no">#<asp:Label ID="lblIlanNo1" runat="server"></asp:Label></p>
                        <div class="favoriye-ekle">
                            <asp:LinkButton runat="server" ID="btnFavorilereEkle" OnClick="btnFavorilereEkle_Click">
                                <i class="fas fa-star"></i> <p class="mb-0">Favori İlanlara Ekle</p></asp:LinkButton> 
                           <asp:LinkButton runat="server" ID="btnFavorilerdenCikar" class="mb-0" OnClick="btnFavorilerdenCikar_Click">
                                <i class="fas fa-minus"></i>  <p class="mb-0">Favorilerden Çıkar</p></asp:LinkButton>
                            
                        </div>
                        <div class="price">
                             <asp:Literal ID="ltTeklifTalebi" runat="server" Visible="false"></asp:Literal>
                            <h2><asp:Literal ID="ltFiyat1" runat="server"></asp:Literal>	<asp:Literal ID="ltParaBirimi1" runat="server"></asp:Literal></h2>
                        </div>
                        <div class="card bg-transparent">
                            <div class="card-body p-4">
                                <div class="satici-card">
                                    <div class="first-line">
                                          <div class="img">
                                              <asp:Literal ID="ltLink" runat="server"></asp:Literal>
                                            <asp:Image ID="imgLogo" runat="server"  ToolTip='<%# Eval("Baslik") %>' AlternateText='<%# Eval("Baslik") %>' Visible="false"/>
                                        </div>
                                        <div class="texts">
                                             <h6><asp:Label ID="lblFirmaismi" runat="server"></asp:Label></h6>
                                            <h6><p><asp:Literal ID="ltTemsilci" runat="server"></asp:Literal></p></h6>
                                        </div>
                                    </div>
                                    <div class="second-line">
                                      
<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
   <ContentTemplate> 
          <asp:LinkButton runat="server" ID="linkBtnTelefonGoster" OnClick="btnTelefonGoster_Click">
                               <span class="btn btn-danger"><i class="fas fa-phone"></i> Telefon Numarasını Göster</span>

                                        </asp:LinkButton> 

      <asp:Panel runat="server" ID="pnlTelefon" Visible="False">
                                            <asp:LinkButton runat="server" ID="linkBtnTelefonGizle" class="mb-0" OnClick="btnTelefonGizle_Click" Visible="False">
                                <span class="btn btn-warning">Telefon Numarasını Gizle <i class="fas fa-arrow-up"></i></span></asp:LinkButton>
                                            <p><i class="fas fa-phone"></i> <asp:Literal ID="ltTemsilciTel" runat="server"></asp:Literal></p>
                                        </asp:Panel>
      </ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="linkBtnTelefonGoster" EventName="click"/>
</Triggers>
</asp:UpdatePanel>

                                     </div>
                                     <div class="second-line">
                                       <p><i class="fas fa-map-marker-alt"></i> <asp:Label ID="lblIl1" runat="server"></asp:Label></p>
                                       <p class="date"><i class="fas fa-calendar"></i> <asp:Label ID="lblYayinTarihi1" runat="server" CssClass="date"></asp:Label></p>
                                     </div>
                                </div>
                            </div>
                        </div>
                        <asp:Literal ID="ltTemsilciWhatsapp" runat="server"></asp:Literal>
                        <asp:Literal ID="ltMesajLinki" runat="server" Visible="false"></asp:Literal>
                        <asp:Literal ID="ltIhale" runat="server"></asp:Literal>
                    </div>

                    <asp:ListView ID="lstPhotos" GroupItemCount="50" runat="server" DataKeyNames="makinaResim_ID" Visible="false">
                            <LayoutTemplate>
                                <asp:Placeholder id="groupPlaceholder" runat="server" />
                            </LayoutTemplate>
                            <GroupTemplate>
                               <asp:Placeholder id="itemPlaceholder" runat="server" />
                                </div>
                            </GroupTemplate>
                            <ItemTemplate>
                                <a href='<%# ConfigurationManager.AppSettings["imagePath"].ToString() + Eval("Fotograf") %>' data-fancybox="gallery"><img src='<%# ConfigurationManager.AppSettings["imagePath"].ToString() + Eval("Fotograf") %>'  class="urunresimleri"/></a>
                            </ItemTemplate> 
                                    
                        </asp:ListView>
                    
                    <div class="col-md-12">
                        <div class="card mt-4">
                            <div class="card-body">
                                <div class="urun-ozellikleri">
                                    <div>
                                        <div class="item">
                                            <p>Marka: </p>
                                            <asp:Literal ID="ltMarka1" runat="server"></asp:Literal>
                                        </div>
                                        <div class="item">
                                            <p>Kategori: </p>
                                            <asp:Literal ID="ltTur1" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div>
                                       <div class="item">
                                            <p>Model: </p>
                                            <span><asp:Label ID="lblModel1" runat="server"></asp:Label></span>
                                        </div>
                                        <div class="item">
                                            <p>Alt Kategori: </p>
                                            <asp:Literal ID="ltAltTur1" runat="server"></asp:Literal>
                                        </div>
                                          
                                        
                                    </div>
                                    <div>
                                        <div class="item">
                                            <p>Model Yılı: </p>
                                            <span><asp:Label ID="lblYil1" runat="server"></asp:Label></span>
                                        </div>
                                       <div class="item">
                                            <p>Çalışma Saati: </p>
                                            <span><asp:Label ID="lblCalismaSaati" runat="server"></asp:Label></span>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:Panel ID="pnlIhale" runat="server" Visible="false">
                     <div class="col-md-12 detay-aciklama">
                        <h5 class="title">İhale</h5>
                        <div class="row">
                                <div class="col-md-12">
                                   <div class="sayac1">
                            <div class="sayac-gun1">
                                <span>Gün</span>
                                <span>Saat</span>
                                <span>Dakika</span>
                                <span>Saniye</span>
                            </div>
                            <ul class="flip-clock-container">
                                <li class="flip-item-seconds"><asp:Label ID="lblIhaleSaniye" runat="server"></asp:Label></li>
                                <li class="flip-item-minutes"><asp:Label ID="lblIhaleDakika" runat="server"></asp:Label></li>
                                <li class="flip-item-hours"><asp:Label ID="lblIhaleSaat" runat="server"></asp:Label></li>
                                <li class="flip-item-days"><asp:Label ID="lblIhaleGun" runat="server"></asp:Label></li>
                            </ul>
                        </div></div>
  
                            </div>

                         <h5 class="title">İhale Bilgileri</h5>
                         <div class="row">
                        <div class="col-md-4">
                                    <span><i class="fa fa-calendar"></i><strong>Başlangıç Tarihi</strong></span> <asp:Label ID="lblBaslangic" runat="server"></asp:Label>
                                     </div>
                              <div class="col-md-4">
                            <span><i class="fa fa-calendar-check-o"></i><strong>Bitiş Tarihi</strong></span> <asp:Label ID="lblBitis" runat="server"></asp:Label>
                                  </div>  
                                   <div class="col-md-4">
                                  <span><i class="fa fa-money"></i><strong>Teminat Bedeli</strong></span> <asp:Label ID="lblKapora" runat="server"></asp:Label>
                               </div>
                                   </div>
                    </div>

                    </asp:Panel>

                    <div class="col-md-12 detay-aciklama">
                        <h5 class="title">Açıklama</h5>
                        <p>
                            <asp:Literal ID="ltAciklama" runat="server"></asp:Literal>
                        </p>
                          <strong>Paylaş : </strong>
                           <div data-network="twitter" class="st-custom-button"><i class="fab fa-twitter"> </i></div>
                           <div data-network="facebook" class="st-custom-button" ><i class="fab fa-facebook"> </i></div> 
                           <div data-network="whatsapp" class="st-custom-button"><i class="fab fa-whatsapp"> </i></div> 
                           <div data-network="telegram" class="st-custom-button"><i class="fab fa-telegram"></i></div> 
                           <div data-network="linkedin" class="st-custom-button"><i class="fab fa-linkedin"> </i></div> 
                           <div data-network="email" class="st-custom-button"><i class="fas fa-envelope"> </i></div>
                    </div>

                    <asp:Panel ID="pnlMesajGondermeAlani" runat="server" Visible="false">
                    <div class="col-md-12">
                        <div class="card mt-4">
                             <div class="satici_iletisim">
                            <a id="saticiiletisim"><span class="far fa-envelope"></span> <strong>Satıcıyla İletişim Kurun</strong></a>
                            </div>
                          
                            <div class="card-body">
                                <asp:Panel ID="pnlMesaj" runat="server">
                                  * Mesaj otomatik olarak satıcının diline çevrilir
                                <br /><br />
                            Merhaba, benim adım <asp:TextBox ID="txtAdi" runat="server" CssClass="contact-seller " Width="200"></asp:TextBox> ve şu konuda daha daha fazla bilgi almak istiyorum: <strong><asp:Label ID="lblilanBaslik" runat="server" CssClass="text-green"></asp:Label></strong> <br /><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lütfen adınızı giriniz." ControlToValidate="txtAdi" ForeColor="#CC3300" ValidationGroup="mesaj" Display="None" Font-Size="Small"></asp:RequiredFieldValidator>
                                <br />
                                <asp:CheckBox ID="chkUygun" runat="server" CssClass="formcheck form-check"/> Bu makine hala uygun mu?<br /><br />
                                <asp:CheckBox ID="chkDurumu" runat="server" CssClass="formcheck form-check"/> Makinenin durumu hakkında bilgi alabilir miyim?<br /><br />
                                <asp:CheckBox ID="chkGaranti" runat="server" CssClass="formcheck form-check"/> Bu makinenin garantisi var mı?<br /><br />
                                <asp:CheckBox ID="chkFiyatOgrenme" runat="server" CssClass="formcheck form-check"/> Bu makinenin fiyatını öğrenebilir miyim?<br /><br />
                                <asp:CheckBox ID="chkFiyat" runat="server" CssClass="formcheck form-check"/> Fiyatta pazarlık payımız var mı? Benim önerim <asp:TextBox ID="txtFiyatOneri" runat="server" CssClass="contact-seller " Width="100"></asp:TextBox><asp:Literal ID="ltFiyatOneriParaBirimi" runat="server" ></asp:Literal><br /><br />
                                <asp:CheckBox ID="chkDahaFazlaResim" runat="server" CssClass="formcheck form-check"/> Makineyle ilgili daha fazla resim gönderebilir misiniz?<br /><br />
                                <asp:CheckBox ID="chkYasadigimYer" runat="server" CssClass="formcheck form-check"/> Yaşadığım yer <asp:TextBox ID="txtYasadigimYer" runat="server" CssClass="contact-seller " Width="200"></asp:TextBox><br /><br />
                                <asp:CheckBox ID="chkKonusulanDil" runat="server" CssClass="formcheck form-check"/> Şu dilleri konuşuyorum <asp:TextBox ID="txtKonusulanDil" runat="server" CssClass="contact-seller " Width="200"></asp:TextBox><br /><br />
                                <asp:CheckBox ID="chckGorusme" runat="server" CssClass="formcheck form-check"/> Makineye bakmak için bir görüşme planlayabilir miyiz?<br /><br />
                                <asp:CheckBox ID="chkIletisim" runat="server" CssClass="formcheck form-check"/> İletişim bilgilerinizi almak istiyordum. <br /><br />
                                <asp:CheckBox ID="chkTelefon" runat="server" CssClass="formcheck form-check"/> Daha önce telefonda görüşmüştük <asp:TextBox ID="txtTelefondaGorusmeTarih" runat="server" CssClass="contact-seller " Width="150" TextMode="Date"></asp:TextBox><br /><br />
                                <asp:CheckBox ID="chkAyirtma" runat="server" CssClass="formcheck form-check"/> Makineyi ayırtabilir miyim? <br /><br />
                                 E-mail adresimden <asp:TextBox ID="txtEmail" runat="server" CssClass="contact-seller " Width="200" placeholder="e-mail adresiniz" TextMode="Email"></asp:TextBox> veya telefon numarasından <input type="number" id="txtTelefonM" name="txtTelefonM" runat="server" class="form-control">
                                    <input type="hidden" id="txtDialCodeM" name="txtDialCodeM" runat="server" /> bana ulaşabiliriniz.<br /><br />
                               
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Lütfen E-Mail adresinizi giriniz." ControlToValidate="txtEmail" ForeColor="#CC3300" ValidationGroup="mesaj" Display="None" Font-Size="Small"></asp:RequiredFieldValidator>
                                <strong>Mesajınız</strong><br />
                                <asp:TextBox ID="txtMesaj" runat="server"  Height="150" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                <br />
                                <br />

                                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="mesaj" ForeColor="White" DisplayMode="List" Font-Bold="true" HeaderText="" Font-Size="Small" CssClass="alert-error" ShowMessageBox="false" BackColor="Red" BorderStyle="Solid" />
                                <asp:Button ID="btnMesaj" runat="server" Text="Mesaj Gönder" CssClass="btn btn-warning" ValidationGroup="mesaj" OnClick="btnMesaj_Click"/>
                           </asp:Panel>

                                 <asp:Panel ID="pnlBitti" runat="server" Visible="false">
                                     <div class="alert alert-success alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-check"></i> <asp:Label ID="lblMesajBaslik" runat="server"></asp:Label></h4>
                     <asp:Label ID="lblMesaj" runat="server"></asp:Label>
                  </div>
                                     </asp:Panel>

                                    </div>
                        </div>
                    </div>
                    </asp:Panel>

                    <div class="col-md-12">
                        <div class="eksper-bilgileri">
                            <div class="row">
                                <div class="col-md-12" runat="server" id="eksperyazi">
                                    <h5>Eksper Bilgisi</h5>
                                </div>
                             <asp:Repeater ID="rptEksper" runat="server" OnItemDataBound="rptEksper_ItemDataBound">
                             <HeaderTemplate>
                                 <div class="col-md-12">
                                    
                              </HeaderTemplate>
                        <ItemTemplate>
                            
                          <div class="row mt-1rem">
                            <div class="col-md-4">
                           <p class="progress-title">  <i class="fa fa-solid fa-arrow-right text-green"></i> <%# Eval("Kategori") %></p>
                                </div>
                            <div class="col-md-7">
                            <asp:Literal ID="ltProgress" runat="server"></asp:Literal>
                                </div>
                            <div class="col-md-1">
                            <asp:Literal ID="ltSmiley" runat="server"></asp:Literal>
                                 </div>           
                                </div>
                                
                                </ItemTemplate>

                             <FooterTemplate></div></FooterTemplate>
                                 </asp:Repeater>
                            
                        </div>
                    </div>
                       
                </div>
            </div>
        </div></div>
    
        <div class="urun-detay-cards bg-white py-5">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 sm-mb-8">
                        <div class="card card-1 bg-light border-0">
                            <div class="card-items">
                                <div class="icon bg-green">
                                    <i class="fas fa-file-excel"></i>
                                </div>
                                <div class="title">
                                    <h5>Expertiz <br> Raporu</h5>
                                </div>
                                <div class="text">
                                    <p>Sıfır Gibi Ekspertiz raporu sayesinde satın alacağın makinenin tüm detaylarını görerek güvenle alışveriş yap! </p>
                                </div>
                                <div class="link">
                                    <a href="/ekspertiz">Daha fazla</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 sm-my-8">
                        <div class="card card-2 bg-light border-0">
                            <div class="card-items">
                                <div class="icon bg-dark-blue">
                                    <i class="fas fa-plus"></i>
                                </div>
                                <div class="title">
                                    <h5>Değerinde <br> Makine Al</h5>
                                </div>
                                <div class="text">
                                    <p>Üretimim hiç durmadan devam etsin, aynı zamanda hız ve verimlilik kazansın diyorsan doğru yerdesin. </p>
                                </div>
                                <div class="link">
                                    <a href="/urunler">Daha fazla</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 sm-mt-8">
                        <div class="card card-3 bg-light border-0">
                            <div class="card-items">
                                <div class="icon bg-light-orange">
                                    <i class="fas fa-tag"></i>
                                </div>
                                <div class="title">
                                    <h5>Değerinde <br> Makine Sat</h5>
                                </div>
                                <div class="text">
                                    <p>Uzman exper ekibimiz tarafından makinanın takrini değerini öğrenin makinanızı değerinde satın. </p>
                                </div>
                                <div class="link">
                                    <a href="/makina-ekle">Daha fazla</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    
        <div class="urun-detay-benzer-urunler bg-light">
            <div class="container py-6 sm-py-40px">
                <div class="row">
                    <div class="col-md-12">
                        <h4 class="title">
                            Benzer İlanlar
                        </h4>
                    </div>
                </div>
                <div class="row mt-4">
                    <div class="col-md-12">
                        <div class="owl-carousel owl-theme" id="benzer-urunler-slider">

                             <asp:Repeater ID="rptBenzerIlanlar" runat="server" OnItemDataBound="rptBenzerIlanlar_ItemDataBound">
                        <ItemTemplate>

                            <div class="item">
                                <div class="card mb-4">
                                    <div class="position-relative">
                                         <a href="/ilan-<%# Eval("SEOUrl") %>"><asp:Image ID="imgUrun" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>'/></a>
                                    </div>
                                    <div class="card-body">
                                        <p class="card-date mb-1"><%# Eval("Yayinlanma_Tarihi", "{0: dd.MM.yyyy}")%></p>
                                        <p class="card-work mb-1">
                                           <a href="/ilan-<%# Eval("SEOUrl") %>"><%# Eval("Tur") %></a>
                                        </p>
                                        <p class="card-type mb-3"" style="height:30px">
                                            <a href="/ilan-<%# Eval("SEOUrl") %>"><%# Eval("Baslik") %></a> <asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal>
                                        </p>
                                        <div class="card-features">
                                            <div class="row">
                                                <div class="col-6 border-right" style="height:70px">
                                                    <i class="fas fa-tag"></i>
                                                    <span>Marka <br> <%# Eval("Marka") %></span>
                                                </div>
                                                
                                                <div class="col-6 text-center" style="height:70px">
                                                    <i class="fas fa-calendar"></i>
                                                    <span>Yıl <br> <%# Eval("Yil") %></span>
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
    <script src="/scripts/flip-clock.js"></script>
    
          
    
</asp:Content>
