<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="KategorilerList.aspx.cs" Inherits="SifirGibiMakina.KategorilerList" %>


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
                        <a href="/kategoriler">Makine Al</a>
                        <span><i class="fas fa-angle-right"></i></span>
                        <a href="#">Kategoriye Göre</a>
                        <span><i class="fas fa-angle-right"></i></span>
                        <p><asp:Label ID="lblBaslikBreadCrumb" runat="server"></asp:Label></p>
                    </div>
            </div>
        </div>
    </div>

   <div class="kategoriye-gore bg-light py-5" runat="server" id="kategoriyegore">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Image ID="imgKategori" runat="server" CssClass="img-fluid" ToolTip='<%# Eval("Kategori") %>' ImageUrl='<%# Eval("UstResim") %>' AlternateText='<%# Eval("Kategori") %>'/>
                        
                    </div>
                   
                    <div class="col-md-12">
                        <div class="sgm-kategorileri py-5">
                            <div class="row">
                                <div class="col-md-12">
                                    <h4 class="title">
                                        En Popüler Kategoriler
                                    </h4>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-md-12">
                                    <div class="owl-carousel owl-theme" id="kategoriye-gore-slider">
                                         <asp:Repeater ID="rptKategoriler" runat="server" OnItemDataBound="rptKategoriler_ItemDataBound">
                     <HeaderTemplate> </HeaderTemplate>
                        <ItemTemplate>
                            <div class="item">
                         <div class="card">
                                                <div class="card-header">
                                                    <p><%# Eval("Kategori") %></p>
                                                    <span><asp:Literal ID="ltKategoriIlanAdeti" runat="server"></asp:Literal></span>
                                                </div>
                                                <div class="card-body p-0">
                                                    <div class="slider-card-items">
                                         <asp:Repeater ID="rptAltKategoriler" runat="server">
                                        <ItemTemplate>
                                        <a href="/alt-2-kategori/<%# ReWriterPath("1", Eval("Kategori").ToString(), "1")%>/ikinci-el-makina/<%# Eval("Alttur2_ID") %>"><%# Eval("Kategori") %> <i class="fas fa-angle-right float-right"></i></a>
                                        </ItemTemplate></asp:Repeater>
                                       
                                               </div>
                                   
                                </div>
                            </div>
                      </div>
                            </ItemTemplate>
                     <FooterTemplate></FooterTemplate>
                                 </asp:Repeater>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="tum-kategoriler py-0">
                            <h4 class="title">Tüm Kategoriler</h4>
                            <div class="card">
                                <div class="card-body">
  <style>
 .column {
     flex: 50%;
    }
   </style>
                                    <asp:Repeater runat="server" ID="rptTumKategoriler" OnItemDataBound="rptTumKategoriler_ItemDataBound">
      <HeaderTemplate>
         <div class="row">
      </HeaderTemplate>
      <ItemTemplate>
         <div class="col-md-6">
               <div class="text">
                <a href="/alt-2-kategori/<%# ReWriterPath("1", Eval("Kategori").ToString(), "1")%>/ikinci-el-makina/<%# Eval("Alttur2_ID") %>"><p> <%# Eval("Kategori") %></p></a><p><asp:Label ID="lblToplam" runat="server"></asp:Label></p>
               </div>
         </div>
      </ItemTemplate>
      <FooterTemplate>
         </div>
      </FooterTemplate>
   </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="kategori-ismi pt-5">
                            <div class="row">
                                <div class="col-md-12">
                                    <h4 class="title"><asp:Label ID="lblKategoriIsmi" runat="server"></asp:Label></h4>
                                </div>

                                <asp:Repeater ID="rptYeniEklenenler" runat="server" OnItemDataBound="rptYeniEklenenler_ItemDataBound">
                        <ItemTemplate>
                                <div class="col-lg-3 col-md-6 col-sm-6 col-xs-6 col-6 sifir-gibi-vitrin mt-0 mb-4 sm-pr-8">
                                    <div class="card">
                                        <div class="position-relative">
                                     <a href="/ilan-<%# Eval("SEOUrl") %>"><asp:Image ID="imgUrun" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>'/></a>
                                    <div class="card-price">
                                        <h4><asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></h4>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <p class="card-date mb-1"><%# Eval("Yayinlanma_Tarihi", "{0: dd.MM.yyyy}")%></p>
                                    <p class="card-work mb-1">
                                 <a href="/kategori/<%# ReWriterPath("1", Eval("Tur").ToString(), "1")%>/ikinci-el-makina/<%# Eval("tur_ID") %>"><%# Eval("Tur") %></a>
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

                <asp:Literal ID="ltFooterSeo" runat="server"></asp:Literal>
            </div>

       
        </div>

    <div class="kategoriye-gore bg-light py-5" runat="server" id="kategoriyok">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <img class="img-fluid" src="/images/kategoriye-gore-bg.png" alt="">
                    </div>
                   
                    <div class="col-md-12">
                        <div class="sgm-kategorileri py-5">
                            <div class="row">
                                <div class="col-md-12">
                                    <h4 class="title">
                                        İLAN BULUNAMADI
                                    </h4>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-md-12">
                                    <center><strong>Aradığınız kategoridesonuç bulunamadı. Bu kategori için ilk ilanı siz verebilirsiniz. İlan vermek için <a href=/makina-ekle>tıklayınız</a></strong></center>
                                </div>
                            </div>
                        </div>
                    </div>

                      
                </div>
            </div>
        </div>
             
    
</asp:Content>
