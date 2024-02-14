<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Firmalar.aspx.cs" Inherits="SifirGibiMakina.Firmalar" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="breadcrumb-comp">
        <div class="container">
          <div class="row">
            <div class="col-md-12">
              <a href="/">Anasayfa</a>
              <span><i class="fas fa-angle-right"></i></span>
              <a href="/urunler">Ilanlar</a>
              <span><i class="fas fa-angle-right"></i></span>
              <p><asp:Label ID="lblFirmaismi1" runat="server"></asp:Label></p>
            </div>
          </div>
        </div>
      </div>
      
      <div class="satici-detay bg-light py-5">
          <div class="container">
              <div class="row">
                  <div class="col-md-12 position-relative">
                      <div class="satici-banner"></div>
                      <div class="satici-logo">
                          <asp:Image ID="imgLogo" runat="server"  ToolTip='<%# Eval("Baslik") %>' AlternateText='<%# Eval("Baslik") %>'/>
                      </div>
                  </div>
              </div>
              <div class="row">
                  <div class="col-md-3">
                      <div class="card satici-card-comp">
                          <div class="card-body">
                              <h4 class="title"><asp:Label ID="lblFirmaismi" runat="server"></asp:Label></h4>
                              <p class="text"><strong>Tel No:</strong> <asp:Literal ID="ltTelefon" runat="server"></asp:Literal></p>
                              <p class="text"><strong>Adres:</strong> <asp:Label ID="lblAdres" runat="server"></asp:Label></p>
                          </div>
                      </div>
                       <div class="card satici-card-comp">
                          <div class="card-body">
                              <h4 class="title">Kategoriler</h4>
                              <asp:Repeater ID="rptKategoriler" runat="server">
                        <ItemTemplate>
                            <p class="text text-light-gray">- <a href="/kategori/<%# ReWriterPath("1", Eval("Tur").ToString(), "1")%>/ikinci-el-makina/<%# Eval("tur_ID") %>" class="text text-light-gray"><%# Eval("Tur") %></a></p>
                            </ItemTemplate>
                            </asp:Repeater>
                              
                              
                          </div>
                      </div>
                  </div>
                  <div class="col-md-9">
                      <div class="row">
                          <div class="col-md-12">
                              <div class="card satici-card-comp">
                                  <div class="card-body">
                                      <h4 class="title">Hakkımızda</h4>
                                      <p class="text">
                                          <asp:Literal ID="ltHakkimizda" runat="server"></asp:Literal>
                                      </p>
                                  </div>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-md-12">
                              <div class="row align-items-center">
                                  <div class="col-md-12 boxes-filter">
                                      <div class="form-group mb-0">
                                          <p class="text-12-14-500 text-gray-light mb-0">
                                              İlan Sayısı: <strong class="text-dark"><asp:Label ID="lblToplamIlan" runat="server" CssClass="text-dark"></asp:Label></strong> 
                                          </p>
                                      </div>
                                  </div>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                           <asp:Repeater ID="rptUrunler" runat="server" OnItemDataBound="rptUrunler_ItemDataBound">
                        <ItemTemplate>
                          <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 col-12">
                              <div class="card product-card">
                                  <div class="position-relative">

                                      <a href="/ilan-<%# Eval("SEOUrl") %>"><asp:Image ID="imgUrun" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>'/></a>
                                      <div class="card-price">
                                          <h4><asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></h4>
                                      </div>
                                  </div>
                                  <div class="card-body">
                                      <p class="card-date mb-1"><%# Eval("Yayinlanma_Tarihi", "{0: dd.MM.yyyy}")%></p>
                                      <p class="card-work mb-1">
                                           <a href="/ilan-<%# Eval("SEOUrl") %>"><%# Eval("Tur") %></a>
                                        </p>
                                      <p class="card-type mb-3" style="height:30px">
                                            <a href="/ilan-<%# Eval("SEOUrl") %>"><%# Eval("Baslik") %></a>
                                        </p>
                                       <div class="card-features">
                                <div class="row">
                                    
                                            <div class="col-6 border-right sm-text-center" style="height:70px">
                                                <i class="fas fa-tag"></i>
                                                <span class="fs-8px ln-8px">Marka <br /><%# Eval("Marka") %></span>
                                            </div>
                                           
                                            <div class="col-6 text-center sm-text-center" style="height:70px">
                                                <i class="fas fa-calendar"></i>
                                                <span class="fs-8px ln-8px">Yıl <br /><%# Eval("Yil") %></span>
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
</asp:Content>