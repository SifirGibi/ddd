<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Ihale.aspx.cs" Inherits="SifirGibiMakina.Ihale" %>


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
                       
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                         <asp:Panel ID="pnlError" runat="server" Visible="false" Width="100%">
                <div class="alert alert-danger alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-ban"></i> <asp:Label ID="lblHata" runat="server"></asp:Label></h4>
                     <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
                  </div>
             </asp:Panel>
                    </div>
                </div>
                <div class="row" id="ihaledetay" runat="server">
                    <div class="col-md-12">

                         <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner">
                                
                                <div class="carousel-item active">
                                      <asp:Literal ID="ltResim" runat="server"></asp:Literal>
                                </div>
                                
                                
                            </div>

                            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            </a>
                            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            </a>
                    </div>

                    <div class="col-md-12 makina-detay-bilgi">
                        <div class="container mt-3">
                            <div class="row">
                                <div class="col-md-12 makina-baslik">
                                    <h5><asp:Label ID="lblBaslik" runat="server"></asp:Label>&nbsp;<asp:Literal ID="ltFiyat" runat="server"></asp:Literal>	<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></h5>
                                    <p><strong>İlan No:</strong> <asp:Label ID="lblilanNo" runat="server"></asp:Label> <br /><strong>Marka:</strong> <asp:Label ID="lblMarka" runat="server"></asp:Label> / <strong>Model:</strong> <asp:Label ID="lblModel" runat="server"></asp:Label> / <strong>Model Yılı:</strong> <asp:Label ID="lblYil" runat="server"></asp:Label> <br /><strong>İl / İlçe:</strong> <asp:Label ID="lblil" runat="server"></asp:Label></p>
                                </div>
                            </div>
                        </div>
                    </div>
                        <asp:Panel ID="pnlIhale" runat="server" Visible="false">
                             <div class="col-md-12 odeme-yontemleri" runat="server" id="ihalesaati">
                        <div class="container">
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
                        </div>
                    </div>
                         <div class="col-md-12 odeme-yontemleri">
                        <div class="container mt-2">
                            <div class="row">
    
                                <div class="col-md-4">
                                    <span><i class="fa fa-calendar"></i><strong>Başlangıç </strong></span> <asp:Label ID="lblBaslangic" runat="server"></asp:Label>
                                    </div> 
                                    <div class="col-md-4">
                                    <span><i class="fa fa-calendar-check-o"></i><strong>Bitiş </strong></span> <asp:Label ID="lblBitis" runat="server"></asp:Label>
                                     </div>
                                        <div class="col-md-4">
                                         <span><i class="fa fa-money"></i><strong>Açılış Fiyatı</strong></span> <asp:Label ID="lblBaslangicMiktari" runat="server"></asp:Label>
                                     </div>
     
                            </div>
                             <div class="row">
                                 <div class="col-md-12">
                                     <asp:Literal ID="ltIhale" runat="server"></asp:Literal>
                                     </div></div>
                        </div>
                    </div>
                            <asp:Panel ID="pnlIhaleKatilim" runat="server" Visible="false">
                             <div class="col-md-12 odeme-yontemleri">
                        <div class="container mt-2">
                            <div class="row">
                                <div class="col-md-12 odeme-text">
                                    <span><i class="fa fa-user"></i><strong> İhale Katılım Durumu : </strong> <asp:Label ID="lblKatilabilir" runat="server"></asp:Label></span><br /><br />
                                </div>
                            </div>
                            <div class="row" style="background-color:white;padding-top:20px">
                                <div class="col-md-3">
                                     <img src="/images/LIVE2.gif" runat="server" id="live" width="50" height="50"/>
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btn250" runat="server" OnClick="btn250_Click"  UseSubmitBehavior="false" CssClass="btn btn-success btn-block detay-button my-3"/>
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btn500" runat="server" OnClick="btn500_Click"  UseSubmitBehavior="false" CssClass="btn btn-success btn-block detay-button my-3"/>
                                </div>
                                <div class="col-md-3">
                                   <asp:Button ID="btn1000" runat="server" OnClick="btn1000_Click"  UseSubmitBehavior="false" CssClass="btn btn-success btn-block detay-button my-3"/>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-12">
                                    <br />
                                    <hr />
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-12 text-center">
                                    <asp:Label ID="lblBitti" runat="server" CssClass="alert-danger"></asp:Label><br />
                                    <asp:Label ID="lblSonuc" runat="server"></asp:Label><br /><br />
                                   <asp:ScriptManager ID="ScriptManager1" runat="server" />

      <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>
 <asp:UpdatePanel runat="server">
          <ContentTemplate>
                                    <div class="table-responsive">
        <asp:GridView ID="grdIhale" runat="server" AutoGenerateColumns="False" DataKeyNames="ihale_ID" CssClass="table table-striped table-bordered table-hover" OnRowDataBound="grdIhale_RowDataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False" HeaderText="Sizin Teklifiniz" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                         <asp:Label ID="lblIhaleID" runat="server" Text ='<%#Eval("ihale_ID") %>' Visible="false"></asp:Label>
                        <asp:Literal ID="ltSiz" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ihale_ID" Visible="false"/>
                <asp:BoundField DataField="UyeAd" Visible="true" HeaderText="Üye"/>
                <asp:BoundField DataField="Kayit_Tarihi" Visible="true" HeaderText="Teklif Tarihi"/>
                <asp:TemplateField ShowHeader="True" HeaderText="Artırılan Fiyat" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltVerilenFiyat" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="True" HeaderText="Son Teklif Tutarı" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltSonTeklif" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                        </div>
               </ContentTemplate>
          <Triggers>
              <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />

          </Triggers>

      </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                                </asp:Panel>
                    </asp:Panel>

                    </div>

                </div>

            </div>
        </section>
</main>
</asp:Content>
