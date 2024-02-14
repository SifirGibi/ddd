<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Ilanlar.aspx.cs" Inherits="SifirGibiMakina.Ilanlar" EnableEventValidation="true"%>
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
              <a href="/Ilanlar.aspx">Makine Al</a>
            </div>
          </div>
        </div>
      </div>
  
      <div class="sgm-makine-liste bg-light sm-d-none">
        <div class="container">
          <div class="row">
            <div class="col-md-3">
              <div class="sidebar">
                <div class="card sm-d-none">
                  <div class="card-header">İlan Arama</div>
                    <div class="card-body">

                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
                        <div class="form-group">
                            <asp:DropDownList ID="ddTurler" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddTurler_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        </div>
                        <div class="form-group">
                         <asp:DropDownList ID="ddTurlerAlt" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddTurlerAlt_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        </div>
                       <div class="form-group">
                         <asp:DropDownList ID="ddTurlerAlt2" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddTurlerAlt2_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        </div>
            </ContentTemplate>
</asp:UpdatePanel>
                 
                        <div class="form-group">
                          <asp:DropDownList ID="ddMarkalar" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddMarkalar_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        </div>
                    </div>
                  </div>
                <div class="card mt-3 sm-d-none">
                  <div class="card-header">Filtreler</div>
                  <div class="card-body bg-light">
                    <p>Fiyat</p>
                      <div class="form-group">
                           <asp:TextBox ID="txtFiyatMin" runat="server" class="form-control" placeholder="Min Tutar" TextMode="Number"></asp:TextBox>
                      </div>
                      <div class="form-group">
                       <asp:TextBox ID="txtFiyatMax" runat="server" class="form-control" placeholder="Max Tutar" TextMode="Number"></asp:TextBox>
                      </div>
                      <div class="form-group">
                      <asp:DropDownList ID="ddParaBirimi" runat="server" CssClass="form-control select2" Width="100%"><asp:ListItem Text="Para Birimi" Value="0"></asp:ListItem><asp:ListItem Text="TL" Value="1"></asp:ListItem><asp:ListItem Text="Euro" Value="2"></asp:ListItem><asp:ListItem Text="Dolar" Value="3"></asp:ListItem></asp:DropDownList>
               </div>
                  </div>
                  <div class="card-body bg-light">
                    <p>Yıl</p>
                      <div class="form-group">
                      <asp:DropDownList ID="ddYilMin" runat="server" CssClass="form-control select2" Width="100%">
                        </asp:DropDownList>
                      </div>
                      <div class="form-group">
                        <asp:DropDownList ID="ddYilMax" runat="server" CssClass="form-control select2" Width="100%">
                        </asp:DropDownList>
                      </div>
                 
                  </div>

                     <div class="card-body bg-light">
                    <p>Kelime / İlan No</p>
                  
                      <div class="form-group">
                       <asp:TextBox ID="txtKelime" runat="server" placeholder="İlan no, aranacak kelime" CssClass="form-control"></asp:TextBox>
                      </div>
                 
                  </div>

                  <div class="card-body p-0">
                      <asp:Button ID="btnAra" runat="server" Text="Filtreleri Uygula" CssClass="btn btn-success btn-block filtreleri-uygula" Width="100%" OnClick="btnAra_Click"/>

                    <div class="filtreleri-sifirla">
                        <asp:LinkButton ID="btnTumu" runat="server" OnClick="btnTumu_Click">FİLTRE AYARLARINI SIFIRLA</asp:LinkButton>

                    </div>
                  </div>
                </div>
              </div>
                <br />
                 <div class="container pb-5">
            <div class="row">
                <div class="col-md-12">
                      <asp:Repeater ID="rptReklamAlaniSol" runat="server" OnItemDataBound="rptReklamAlaniSol_ItemDataBound">
                        <ItemTemplate>
                            <div class="text-center">
                                <asp:Literal ID="ltLink" runat="server"></asp:Literal>
                                </div>
                            </ItemTemplate>
                          </asp:Repeater>
                </div>
            </div>
            </div>

            </div>
            <div class="col-md-9">

                 <div class="container pb-5">
            <div class="row">
                <div class="col-md-12">
                      <asp:Repeater ID="rptReklamAlaniHeader" runat="server" OnItemDataBound="rptReklamAlaniHeader_ItemDataBound">
                        <ItemTemplate>
                            <div class="text-center">
                                <asp:Literal ID="ltLink" runat="server"></asp:Literal>
                                </div>
                            </ItemTemplate>
                          </asp:Repeater>
                </div>
            </div>
            </div>

              <div class="vitrin-makineleri">
                <h3 class="title">Vitrin Makineleri</h3>
                <div class="row">
                  <div class="col-md-12">
                    <div class="row">
                       
                      <div class="col-md-12">
                        <div class="owl-carousel owl-theme" id="makine-al-slider">
                             <asp:Repeater ID="rptUrunlerVitrin" runat="server" OnItemDataBound="rptUrunlerVitrin_ItemDataBound">
                        <ItemTemplate>
                            <div class="item">
                            <div class="card mb-4">
                              <div class="position-relative">
                                  <a href="/ilan-<%# Eval("SEOUrl") %>"><asp:Image ID="imgUrun" runat="server" CssClass="card-img-top img-fluid" ToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>'/></a>
                                <div class="card-price">
                                  <h4><asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></h4>
                                </div>
                              </div>
                              <div class="card-body p-2">
                                <p class="card-date mb-1"><%# Eval("Yayinlanma_Tarihi", "{0: dd.MM.yyyy}")%></p>
                                <p class="card-work mb-1">
                                 <a href="/ilan-<%# Eval("SEOUrl") %>"><%# Eval("Tur") %></a>
                                        </p>
                                <p class="card-type mb-3" style="height:30px">
                                 <a href="/ilan-<%# Eval("SEOUrl") %>"><%# Eval("Baslik") %></a>
                                </p>
                                <div class="card-features">
                                  <div class="row">
                                    <div class="col-md-8 border-right">
                                      <i class="fas fa-tag"></i>
                                      <span>Marka <br />
                                        <%# Eval("Marka") %></span
                                      >
                                    </div>
                                    
                                    <div class="col-md-4 text-center">
                                      <i class="fas fa-calendar"></i>
                                      <span>Yıl <br />
                                        <%# Eval("Yil") %></span
                                      >
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
                <div class="accordion" id="listing-accordion">
                  <div class="row mt-3">
                    <div class="col-md-12">
                      <div class="row align-items-center">
                        <div class="col-md-7">
                          <p class="text-12-14-500 text-gray-light mb-0">
                            <asp:Label ID="lblToplamIlan" runat="server" CssClass="text-dark" Font-Bold="true"></asp:Label> adet ilan görüntüleniyor
                          </p>
                        </div>
                        <div class="col-md-5 boxes-filter">
                          <div class="mr-5 d-flex">
                            <div id="headingTwo">
                              <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo" >
                                <i class="fas fa-th-large"></i>
                              </button>
                            </div>
                          </div>
                          
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="row mt-3">
                    <div class="col-md-12 listing-v2" id="collapseTwo" aria-labelledby="headingTwo" data-parent="#listing-accordion">
                      <div class="row">
                           <asp:Label ID="lblSonuc" runat="server" Visible="false" CssClass="text-center" Width="100%" ForeColor="Red"></asp:Label>
                              <asp:Repeater ID="rptUrunler" runat="server" OnItemDataBound="rptUrunler_ItemDataBound">
                        <ItemTemplate>
                          <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 col-12">
                              <div class="card mb-4">
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
                                              <div class="col-md-8 border-right">
                                                  <i class="fas fa-tag"></i>
                                                 <span>Marka <br /><%# Eval("Marka") %></span>
                                              </div>
                                              <div class="col-md-4 text-center">
                                                  <i class="fas fa-calendar"></i>
                                                  <span>Yıl <br /><%# Eval("Yil") %></span>
                                              </div>
                                          </div>
                                      </div>
                                  </div>
                              </div>
                          </div>
                            </ItemTemplate>
                                 </asp:Repeater>

                      </div>
                      <div class="mt-5 d-flex justify-content-center">
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

        <cc1:CollectionPager ID="CollectionPager1" PageSize="12" runat="server" BackNextLocation="Split" BackText=" < "   FirstText=" İlk " LabelText=" " LastText=" Son " NextText=" > " QueryStringKey="Sayfa" ResultsFormat="Sayfa {0}-{1} (Toplam {2} ilan)" ControlCssClass="Sayfalama" MaxPages="10000" HideOnSinglePage="True" PagingMode="PostBack"></cc1:CollectionPager>

                        
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="sgm-makine-liste mobile just-mobile">
        <div class="container">
          <div class="row">
            <div class="col-12">


              <div class="mobile-collapse">
                <div class="filter-sort-bar">
                  <button class="btn btn-outline-success filter-collapse-button" type="button" data-toggle="collapse" data-target="#mobileCollapse" aria-expanded="false" aria-controls="mobileCollapse">
                    <i class="fas fa-filter"></i>
                    Filtreler</button>

                </div>
                <p class="text-12-14-500 text-gray-light mt-3">
                   <asp:Label ID="lblToplamIlanMobil" runat="server" CssClass="text-dark" Font-Bold="true"></asp:Label> adet ilan görüntüleniyor
                </p>


                <div class="collapse" id="mobileCollapse">
                  <div class="card">
                    <div class="card-header">İlan Arama</div>
                      <div class="card-body">
                                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
     <div class="form-group">
      
                            <asp:DropDownList ID="ddTurlerMobil" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddTurlerMobil_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        </div>
                        <div class="form-group">
                         <asp:DropDownList ID="ddTurlerAltMobil" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddTurlerAltMobil_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        </div>
                          <div class="form-group">
                         <asp:DropDownList ID="ddTurlerAlt2Mobil" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddTurlerAlt2Mobil_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        </div>

                  </ContentTemplate>
</asp:UpdatePanel>
                        <div class="form-group">
                          <asp:DropDownList ID="ddMarkalarMobil" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddMarkalarMobil_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        </div>
                      </div>
                    </div>
                  <div class="card mt-3">
                    <div class="card-header">Filtreler</div>
                    <div class="card-body bg-light">
                     <p>Fiyat</p>
                      <div class="form-group">
                           <asp:TextBox ID="txtFiyatMinMobil" runat="server" class="form-control" placeholder="Min Tutar" TextMode="Number"></asp:TextBox>
                      </div>
                      <div class="form-group">
                       <asp:TextBox ID="txtFiyatMaxMobil" runat="server" class="form-control" placeholder="Max Tutar" TextMode="Number"></asp:TextBox>
                      </div>
                      <div class="form-group">
                      <asp:DropDownList ID="ddParaBirimiMobil" runat="server" CssClass="form-control select2" Width="100%"><asp:ListItem Text="Para Birimi" Value="0"></asp:ListItem><asp:ListItem Text="TL" Value="1"></asp:ListItem><asp:ListItem Text="Euro" Value="2"></asp:ListItem><asp:ListItem Text="Dolar" Value="3"></asp:ListItem></asp:DropDownList>
                     </div>
                    </div>
                    <div class="card-body bg-light">
                      <p>Yıl</p>
                    <div class="form-group">
                       <asp:DropDownList ID="ddYilMinMobil" runat="server" CssClass="form-control select2" Width="100%">
                        </asp:DropDownList>
                      </div>
                      <div class="form-group">
                        <asp:DropDownList ID="ddYilMaxMobil" runat="server" CssClass="form-control select2" Width="100%">
                        </asp:DropDownList>
                      </div>
                    </div>
                      <div class="card-body bg-light">
                    <p>Kelime / İlan No</p>
                  
                      <div class="form-group">
                       <asp:TextBox ID="txtKelimeMobil" runat="server" placeholder="İlan no, aranacak kelime" CssClass="form-control"></asp:TextBox>
                      </div>
                 
                  </div>
                    <div class="card-body p-0">
                       <asp:Button ID="btnAramaMobil" runat="server" Text="Filtreleri Uygula" CssClass="btn btn-success btn-block filtreleri-uygula" Width="100%" OnClick="btnMobilAra_Click"/>

                      <div class="filtreleri-sifirla">
                        <asp:Button ID="btnSifirlaMobil" runat="server" Text="FİLTRE AYARLARINI SIFIRLA" CssClass="btn btn-secondary" Width="100%" OnClick="btnTumu_Click"/>
                      </div>
                    </div>
                  </div>
                </div>
                
    
              </div>

            </div>
          </div>
          <div class="row">

            <asp:Repeater ID="rptUrunlerMobil" runat="server" OnItemDataBound="rptUrunler_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-12">
              <div class="makine-liste-list-item">
                <div class="card mb-3" style="max-width: 540px;">
                  <div class="row no-gutters align-items-center">
                    <div class="col-5">
                        <a href="/ilan-<%# Eval("SEOUrl") %>"><asp:Image ID="imgUrun" runat="server" CssClass="img-fluid" ToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>'/></a>
                    </div>
                    <div class="col-7">
                      <div class="card-body">
                        <p class="card-category"><a href="/ilan-<%# Eval("SEOUrl") %>" style="color:#44b276;font-size:11px"><%# Eval("Tur") %></a></p>
                        <p class="card-name"><a href="/ilan-<%# Eval("SEOUrl") %>" style="color:#8E8E8E;font-size:12px"><%# Eval("Baslik") %></a></p>
                        <p class="card-price"><asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
                            </ItemTemplate>
                                 </asp:Repeater>
            <asp:Repeater ID="rptUrunlerVitrinMobil" runat="server" OnItemDataBound="rptUrunlerVitrin_ItemDataBound">
                        <ItemTemplate>
                              <div class="col-6 sm-pr-8">
              <div class="makine-liste-card">
                <div class="card">
                    <a href="/ilan-<%# Eval("SEOUrl") %>"><asp:Image ID="imgUrun" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Baslik") %>' ImageUrl='<%# Eval("Fotograf") %>' AlternateText='<%# Eval("Baslik") %>'/></a>
                  <div class="card-body">
                    <p class="card-date">
                      <%# Eval("Yayinlanma_Tarihi", "{0: dd.MM.yyyy}")%>
                    </p>
                    <p class="card-date">
                      <a href="/ilan-<%# Eval("SEOUrl") %>" style="color:#8E8E8E"><%# Eval("Tur") %></a>
                    </p>
                    <a href="/ilan-<%# Eval("SEOUrl") %>"><p class="card-card-text" style="height:50px;color:#8E8E8E;font-size:11px">
                     <%# Eval("Baslik") %> </p></a>
                   
                    <div class="card-features">
                      <div class="row">
                          <div class="col-12">
                              <div class="box">
                                <i class="fas fa-money-bill"></i>
                                <span><strong> <asp:Literal ID="ltFiyat" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></strong></span>
                              </div>
                          </div>
                          <div class="col-12">
                              <div class="box">
                                <i class="fas fa-tag"></i>
                                <span><strong>Marka</strong>  <%# Eval("Marka") %></span>
                              </div>
                          </div>

                          <div class="col-12">
                            <div class="box">
                              <i class="fas fa-calendar"></i>
                              <span><strong>Yıl</strong> <%# Eval("Yil") %></span>
                            </div>
                          </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
                            </ItemTemplate>
                                 </asp:Repeater> <div class="mt-5 d-flex justify-content-center">
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



                       <cc1:CollectionPager ID="CollectionPager2" PageSize="12" runat="server" BackNextLocation="Split" BackText=" < "   FirstText=" İlk " LabelText=" " LastText=" Son " NextText=" > " QueryStringKey="Sayfa" ResultsFormat="Sayfa {0}-{1} (Toplam {2} ilan)" ControlCssClass="Sayfalama" MaxPages="10000" HideOnSinglePage="True"   PagingMode="PostBack"></cc1:CollectionPager>
                        
                      </div>
          </div>
        </div>
      </div>
   
</asp:Content>
