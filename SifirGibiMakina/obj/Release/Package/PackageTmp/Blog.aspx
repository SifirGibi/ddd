<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="SifirGibiMakina.Blog" %>
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
                        <a href="/blog">Blog</a>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="blog bg-light">
            <div class="container">

                <asp:Panel ID="pnlError" runat="server" Visible="false" Width="450px">
                <div class="alert alert-danger alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-ban"></i> <asp:Label ID="lblHata" runat="server"></asp:Label></h4>
                     <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
                  </div>
             </asp:Panel>

                <div class="one-cikanlar">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="title">Öne Çıkanlar</h4>
                        </div>

                          <asp:Repeater ID="rptBlog" runat="server" OnItemDataBound="rptBlog_ItemDataBound">
                        <ItemTemplate>
                             <div class="col-md-3 sm-mb-8">
                            <div class="card">
                                <asp:Image ID="imgBlog" runat="server" CssClass="card-img-top img-fluid" ToolTip='<%# Eval("Baslik") %>' AlternateText='<%# Eval("Baslik") %>'/>
                                <div class="card-body">
                                    <p>
                                       <asp:Literal ID="ltLink" runat="server"></asp:Literal><%# Eval("Baslik") %></a>
                                    </p>
                                    <span><%# Eval("Kayit_Tarihi") %></span>
                                </div>
                            </div>
                        </div>
                            </ItemTemplate>
                                 </asp:Repeater>
                    </div>
                </div>
                <div class="blog-main">
                    <div class="row">
                        <div class="col-md-8">
                            <div class="row">
                                <div class="col-md-12">
                                      <asp:Repeater ID="rptBlogAna" runat="server" OnItemDataBound="rptBlogAna_ItemDataBound">
                        <ItemTemplate>
                            <div class="card">
                                        <div class="row no-gutters">
                                        <div class="col-md-5">
                                             <asp:Image ID="imgBlog" runat="server" CssClass="img-fluid" ToolTip='<%# Eval("Baslik") %>' AlternateText='<%# Eval("Baslik") %>'/>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="card-body">
                                                <h5 class="blog-title">
                                                    <asp:Literal ID="ltLink" runat="server"></asp:Literal><%# Eval("Baslik") %></a> 
                                                </h5>
                                                 <span class="blog-date"><%# Eval("Kayit_Tarihi") %></span>
                                                <p class="blog-text">
                                                    <%# Eval("KisaAciklama") %>
                                                </p>
                                                    <asp:Literal ID="ltLink1" runat="server"></asp:Literal>Daha Fazla <i class="fas fa-chevron-right"></i></a>
                                                </a>
                                            </div>
                                        </div>
                                        </div>
                                    </div>

                            </ItemTemplate>
                                 </asp:Repeater>
                                    

                                </div>
 <style type="text/css">

.Sayfalama{text-align:center;}

.Sayfalama a{
    display: inline-block;
    text-align: center;
    height: 34px;
    width: 34px;
    color: #888;
    line-height: 33px;
    border: 1px solid #eee;
    border-radius: 2px;
    -webkit-border-radius: 2px;
    -moz-border-radius: 2px;
    -o-border-radius: 2px;
    transition: all 0.2s ease-in-out;
    -moz-transition: all 0.2s ease-in-out;
    -webkit-transition: all 0.2s ease-in-out;
    -o-transition: all 0.2s ease-in-out;}

.Sayfalama a:active{ background-color:#003399;}

.Sayfalama a:link, .Sayfalama a:visited

{    display: inline-block;
    text-align: center;
    height: 34px;
    width: 34px;
    color: #888;
    line-height: 33px;
    border: 1px solid #eee;
    border-radius: 2px;
    -webkit-border-radius: 2px;
    -moz-border-radius: 2px;
    -o-border-radius: 2px;
    transition: all 0.2s ease-in-out;
    -moz-transition: all 0.2s ease-in-out;
    -webkit-transition: all 0.2s ease-in-out;
    -o-transition: all 0.2s ease-in-out;}

.Sayfalama a:hover{border-color: #ddd;}

 .Sayfalama INPUT{    width: auto;
    padding: 0 14px;}
   
   
    /*Aktif sayfa*/
.Sayfalama B{
    display: inline-block;
    text-align: center;
    height: 34px;
    width: 34px;
    color: #FFF;
    background-color:#44B276;
    line-height: 33px;
    border: 1px solid #eee;
    border-radius: 2px;
    -webkit-border-radius: 2px;
    -moz-border-radius: 2px;
    -o-border-radius: 2px;
    transition: all 0.2s ease-in-out;
    -moz-transition: all 0.2s ease-in-out;
    -webkit-transition: all 0.2s ease-in-out;
    -o-transition: all 0.2s ease-in-out;}
.Sayfalama span{
    width: auto;
    padding: 0 5px;
}
</style>
                                  <div style="text-align:center;margin:auto">
                       <cc1:CollectionPager ID="CollectionPager1" PageSize="5" runat="server" BackNextLocation="Split" BackText="&lt;"   FirstText="İlk" LabelText=" " LastText="Son" NextText=" > " QueryStringKey="Sayfa" ResultsFormat="Sayfa {0}-{1} (Toplam {2})" ControlCssClass="Sayfalama" BackNextDisplay="HyperLinks" ShowFirstLast="False" ShowLabel="True"></cc1:CollectionPager>
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
                                   <asp:Repeater ID="rptEncokOkunanlar" runat="server" OnItemDataBound="rptEncokOkunanlar_ItemDataBound">
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
