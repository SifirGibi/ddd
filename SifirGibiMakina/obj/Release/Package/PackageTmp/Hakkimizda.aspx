<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Hakkimizda.aspx.cs" Inherits="SifirGibiMakina.Hakkimizda1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      

           <div class="hakkimizda">
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <h1 class="hakkimizda-title">Sıfırgibimakine.com <br> <span>Nedir?</span> </h1>
                    </div>
                    <div class="col-md-6">
                        <p class="hakkimizda-subtitle">
                            Sıfırgibimakine.com makinesini satmak isteyenlerle makine almak isteyenleri ortak platformda buluşturan bir pazar yeridir. Sanayide kullanılmış makineleri tekrar aynı hassasiyetle ihtiyacına uygun kullanıcılara kolayca ulaştırmayı hedefliyoruz.
                        </p>
                    </div>
                    <div class="col-md-12">
                        <asp:Image ID="imgIcerik" runat="server" Visible="false" CssClass="img-fluid hakkimizda-img"/>
                    </div>
                </div>
            </div>
            <asp:Panel ID="pnlSayilar" runat="server" Visible="false">
            <div class="sgm-degerler bg-green-transparent">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="title text-center">Sıfırgibimakine.com Değerleri</h4>
                        </div>
                    </div>
                    <div class="row mt-4 countdown">
                        <div class="col-md-3">
                            <h4><asp:Label ID="lblSatilanMakina" runat="server"></asp:Label></h4>
                            <p>Adet Makine Satıldı</p>
                        </div>
                        <div class="col-md-3">
                            <h4><asp:Label ID="lblUyeSayisi" runat="server"></asp:Label></h4>
                            <p>Kişi Üye Oldu</p>
                        </div>
                        <div class="col-md-3">
                            <h4><asp:Label ID="lblAcikArtirmaUye" runat="server"></asp:Label></h4>
                            <p>Kişi Açık Arttırmaya Katıldı</p>
                        </div>
                        <div class="col-md-3">
                            <h4><asp:Label ID="lblAcikArtirmaTeklif" runat="server"></asp:Label></h4>
                            <p>Teklif verildi</p>
                        </div>
                    </div>
                </div>
            </div>
                   </asp:Panel>
            <div class="hakkimizda-other-text bg-white">
                <div class="container">
                    <div class="row">
                        <div class="col-md-5">
                            <div class="green-card">
                                <h5 class="title">
                                   2. El <br />Makina Sitesi
                                </h5>
                                <div class="text-line"></div>
                                <p class="text">
                                    Sitemizden 2. El makinalara en uygun ve doğru bilgileriyle birlikte ulaşabilir, makinanızı kendi belirlediğiniz fiyatla doğrudan veya ihale yöntemiyle satışa sunabilirsiniz.
                                </p>
                            </div>
                        </div>
                         <asp:Repeater ID="rptAciklama" runat="server">
                        <ItemTemplate>
                            <%# Eval("Aciklama") %>
                            </ItemTemplate>
                                 </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="neden-sifir-gibi-makine py-6 mt-5">
                <div class="container">
                    <div class="row mb-4">
                        <div class="col-md-12">
                            <h4 class="title">Neden Sıfır Gibi <br> Makine?</h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/acik-arttirma.png" alt="">
                                     <h5 class="card-title">Açık Arttırmaya Nasıl Katılabilirim?</h5>
                            <p class="card-text">İnternet üzerinden ikinci el makina satın almanızı sağlayan Sıfırgibi makina...   </p>
                            <a href="/sayfalar/2/acik-artirmaya-nasil-katilabilirim" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/satis-sonrasi.png" alt="">
                                     <h5 class="card-title">Satış Sonrası</h5>
                            <p class="card-text">Makinanız sifirgibimakina aracılığıyla satıldıktan sonra, satış bedeli...  </p>
                            <a href="/sayfalar/3/satis-sonrasi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/exper.png" alt="">
                                     <h5 class="card-title">Teknik Destek</h5>
                            <p class="card-text">Sıfırgibi Makina oluşturduğu büyük servis ağı, kendi bünyesinde yer alan...   </p>
                            <a href="/sayfalar/4/teknik-destek" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                                </div>
                            </div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/lojistik.png" alt="">
                                  <h5 class="card-title">Lojistik Teslimat</h5>
                            <p class="card-text">Tüm makina satışlarının yükleme,nakliye,indirme vb. tüm işlemlerin sorumlulukları...  </p>
                            <a href="/sayfalar/5/lojistik-teslimat" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/iade.png" alt="">
                                  <h5 class="card-title">İade Koşulları</h5>
                                    <p class="card-text">Sıfırgibi makina müşterilerine makinaları yerinde çalışır durumda bakma...  </p>
                                    <a href="/sayfalar/7/iade-kosullari" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/sartlar.png" alt="">
                                   <h5 class="card-title">Site Kullanım Şartları</h5>
                                    <p class="card-text">Bu sitenin sunumu ve tüm içeriği T.C. Mevzuatı ve fikri mülkiyet mevzuatı...  </p>
                                    <a href="/sayfalar/9/site-kullanim-sartlari" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/sozlesme.png" alt="">
                                    <h5 class="card-title">Üyelik Sözleşmesi</h5>
                                    <p class="card-text">İşbu sözleşme, www.sifirgibimakine.com adresinde faaliyet gösteren...  </p>
                                    <a href="/sayfalar/11/uyelik-sozlesmesi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6 col-6">
                            <div class="card neden-card border-0 mb-3">
                                <div class="card-body">
                                    <img src="images/ihale.png" alt="">
                                     <h5 class="card-title">İhale Katılım Sözleşmesi</h5>
                                    <p class="card-text">www.sifirgibimakine.com sitesi üzerinden hazırlanan ve sitede...  </p>
                                    <a href="/sayfalar/12/ihale-katilim-sozlesmesi" class="card-link hovered-d-none">Daha Fazla Bilgi <i class="fas fa-chevron-right ml-1"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                            
                         <asp:Panel ID="socialmediashare" runat="server" Visible="false">
                <br /><br />
             <div class="addthis_inline_share_toolbox"></div>
    </asp:Panel>
                 </div>   
</asp:Content>
