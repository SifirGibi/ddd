<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Blog_Detail.aspx.cs" Inherits="SifirGibiMakina.Blog_Detail" %>
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
                        <a href="/blog">Blog</a>
                        <span><i class="fas fa-angle-right"></i></span>
                        <p><asp:Label ID="lblBaslikBreadCrumb" runat="server"></asp:Label></p>
                    </div>
                </div>
            </div>
        </div>

        <div class="blog bg-light sm-pt-1rem">
            <div class="container">
                <div class="blog-main">
                    <div class="row">
                        <div class="col-md-8">
                            <div class="row">
                                <div class="col-md-12">

                                     <asp:Panel ID="pnlError" runat="server" Visible="false" Width="100%">
                <div class="alert alert-danger alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-ban"></i> <asp:Label ID="lblHata" runat="server"></asp:Label></h4>
                     <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
                  </div>
             </asp:Panel>
                                    <div class="blog-detay">
                                        <h4 class="title">
                                            <asp:Label ID="lblBaslik" runat="server"></asp:Label> 
                                        </h4>
                                        <p class="blog-date"><asp:Label ID="lblKayitTarihi" runat="server"></asp:Label></p>
                                        <p class="blog-text">
                                            <asp:Label ID="lblKisaAciklama" runat="server"></asp:Label> 
                                        </p>
                                         <asp:Image ID="imgIcerik" runat="server" Visible="false" CssClass="img-fluid" Width="100%"/>
                                        <p class="blog-text">
                                            <asp:Label ID="lblAciklama" runat="server"></asp:Label>
                                        </p>
                                       
                                    </div>
                                </div>
                                 <div class="col-md-12 tags" style="visibility:hidden">
                                <i class="fa fa-tags"></i> Anahtar Kelimeler <asp:Literal ID="ltKelimeler" runat="server"></asp:Literal>
                            </div>
                         <div class="icerik-paylas">
                             <asp:Panel ID="socialmediashare" runat="server" Visible="false">
                                <p>&nbsp;</p>
                         <div class="addthis_inline_share_toolbox"></div>
                               </asp:Panel>
                        </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="blog-sidebar">
                                <div class="input-group">
                                    <input type="text" class="form-control" placeholder="Ara" aria-label="ara" aria-describedby="search-input-1" runat="server" id="txtSearch">
                                    <div class="input-group-prepend">
                                        <button type="submit" runat="server" id="btnsearch" onserverclick="btnSearch_Click" validationgroup="arama">
                                        <span class="input-group-text" id="search-input-1">
                                            <i class="fas fa-search"></i>   
                                        </span>
                                        </button>
                                    </div>
                                </div>
                                <div class="en-cok-okunanlar">
                                    <h4 class="title">En Çok Okunanlar</h4>
                                    
                    <asp:Repeater ID="rptBlog" runat="server" OnItemDataBound="rptBlog_ItemDataBound">
                        <ItemTemplate>

                            <div class="card">
                                        <div class="row no-gutters">
                                        <div class="col-md-5">
                                            <asp:Image ID="imgBlog" runat="server" CssClass="img-fluid" ToolTip='<%# Eval("Baslik") %>' AlternateText='<%# Eval("Baslik") %>'/>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="card-body">
                                                <h5 class="blog-title-small">
                                                    <asp:Literal ID="ltLink" runat="server"></asp:Literal><%# Eval("Baslik") %></a>
                                                </h5>
                                                <span class="blog-date-small"><%# Eval("Kayit_Tarihi") %></span>
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
            </div>
        </div>
</asp:Content>
