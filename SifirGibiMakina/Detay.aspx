<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Detay.aspx.cs" Inherits="SifirGibiMakina.Detay" %>


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
<link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <main id="main">

        <section class="urun-incele">
                        <asp:Panel ID="pnlError" runat="server" Visible="false" Width="450px">
                <div class="alert alert-danger alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-ban"></i> <asp:Label ID="lblHata" runat="server"></asp:Label></h4>
                     <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
                  </div>
             </asp:Panel>
            <div class="container">

                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-12 makina-baslik" style="text-align:center;">
                             
                         <h5><asp:Label ID="lblBaslik" runat="server"></asp:Label></h5>
                            <asp:Literal ID="ltResim" runat="server"></asp:Literal>
                         </div>
                  
                    <div class="col-md-12 makina-bilgileri">
                        <div class="container">
                            <div class="row">
                            <div class="col-md-12">
                        <div class="makina-detay-baslik"><strong><span >Makina Özellikleri</span></strong></div>
                                </div></div>
                        <br /><br />
                         <div class="row">
                            <div class="col-md-2"><strong>Marka:</strong></div><div class="col-md-10"><asp:Label ID="lblMarka1" runat="server"></asp:Label></div>
                          </div>
                        <div class="row">  
                            <div class="col-md-2"><strong>Tür:</strong></div><div class="col-md-10"><asp:Label ID="lblTur1" runat="server"></asp:Label></div>
                        </div>
                        <div class="row">
                             <div class="col-md-2"><strong>Model:</strong></div><div class="col-md-10"><asp:Label ID="lblModel1" runat="server"></asp:Label></div>
                       </div>
                        <div class="row">
                             <div class="col-md-2"><strong>Model Yılı:</strong></div><div class="col-md-10"><asp:Label ID="lblYil1" runat="server"></asp:Label></div>
                        </div>
                        <div class="row">
                             <div class="col-md-2"><strong>Çalışma Saati:</strong></div><div class="col-md-10"><asp:Label ID="lblCalismaSaati" runat="server"></asp:Label></div>
                        </div>
                        <div class="row">
                             <div class="col-md-12"><br /><strong>Açıklama:</strong></div><div class="col-md-12"><asp:Literal ID="ltAciklama" runat="server"></asp:Literal></div>
                             </div></div>

                        <br /><br />
                        <div class="container">
                            <div class="row">
                            <div class="col-md-12">
                         <div class="makina-detay-baslik"><strong><span >Eksper Bilgisi</span></strong></div>
                                </div></div>
                       
                        <br /><br />
                         <asp:Repeater ID="rptEksper" runat="server" OnItemDataBound="rptEksper_ItemDataBound">
                             <HeaderTemplate> <div class="container mt-2">
                            <div class="row"></HeaderTemplate>
                        <ItemTemplate>
                            <div class="col-md-4">
                           <span class="fa fa-arrow-circle-o-right text-success"></span> <%# Eval("Kategori") %>
                                <div class="progress-bar progress-bar"></div>
                                </div>
                              <div class="col-md-7">
                            <asp:Literal ID="ltProgress" runat="server"></asp:Literal>
                                </div>
                            <div class="col-md-1">
                            <asp:Literal ID="ltSmiley" runat="server"></asp:Literal>
           
                                 </div>           

                                </ItemTemplate>
                             <FooterTemplate></div></div></FooterTemplate>
                                 </asp:Repeater>

                             <br /><br />
                          <div class="makina-detay-baslik"><strong><span >Yapılan İşlemler</span></strong></div>
                        <br /><br />
                                      <div class="table-responsive">
        <asp:GridView ID="grdIslemler" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"  PageSize="150"  DataKeyNames="islem_ID" OnRowDataBound="grdIslemler_RowDataBound" CssClass="table table-striped table-bordered table-hover">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Label ID="lblSira" runat="server" Font-Bold="true"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="islem_ID" Visible="false"/>
                <asp:BoundField DataField="Tarih" Visible="true" HeaderText="Tarih"/>
                <asp:BoundField DataField="Islemi_Yapan_Firma" Visible="true" HeaderText="İşlemi Yapan Firma"/>
                <asp:BoundField DataField="Islemi_Yapan_Muhendis" Visible="true" HeaderText="İşlemi Yapan Mühendis"/>
                <asp:TemplateField ShowHeader="True" HeaderText="Açıklama" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltAciklama" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
        </asp:GridView>
                        </div>
                        </div>
                    </div>
                                <!-- ======= Vitrin ======= -->
        <section class="section-news section-t8">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="title-wrap d-flex justify-content-between">
                            <div class="title-box">
                                <h2 class="title-a">Satın Alabileceğiniz Makinalar</h2>
                            </div>
                            <div class="title-link">
                                
                                <a href="/urunler">Tümünü Göster
                                    <span class="ion-ios-arrow-forward"></span>
                                </a>
                                
                                    
                            </div>
                        </div>
                    </div>
                </div>

                <div id="new-carousel" class="owl-carousel owl-theme">
                    <asp:Repeater ID="rptUrunler" runat="server" OnItemDataBound="rptUrunler_ItemDataBound">
                        <ItemTemplate>
                              <div class="carousel-item-c">
                        <div class="card">
                                    <a href="/ilan-<%# Eval("SEOUrl") %>">
                                        <asp:Image ID="imgUrun" runat="server" CssClass="card-img-top" wToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>'  Width="100%" Height="260"/>
                                    </a>
                            <div class="card-body">
                                <div style="height:30px">
                                <a href="/ilan-<%# Eval("SEOUrl") %>">
                                <h5 class="card-title"><%# Eval("Baslik") %></h5>
                                </a>
                                    </div>
                                <br />
                                <p class="detay"><strong>Fiyat :</strong> <asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></p>
                                <p class="detay"><strong>Türü :</strong> <%# Eval("Tur") %></p>
                                <p class="detay"><strong>Marka :</strong> <%# Eval("Marka") %></p>
                                <p class="detay"><strong>Model :</strong> <%# Eval("Model") %></p>
                                <p class="detay"><strong>Model Yılı :</strong> <%# Eval("Yil") %></p>
                                
                                <a href="/ilan-<%# Eval("SEOUrl") %>" class="card-link"><i class="fa fa-search"></i> İncele</a>
                            </div>
                        </div>
                    </div>
                        </ItemTemplate>
                                 </asp:Repeater>
                    
                </div>
            </div>
        </section>
        <!-- End Latest News Section -->
                </div>

            </div>
        </section>
</main>
</asp:Content>
