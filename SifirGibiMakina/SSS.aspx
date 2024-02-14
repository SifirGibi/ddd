<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="SSS.aspx.cs" Inherits="SifirGibiMakina.SSS" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- JS -->
	<script src="//code.jquery.com/jquery-3.2.1.min.js"></script>
	<script src="/fancybox/jquery.fancybox.min.js"></script>

        <section class="insan-kaynaklari">
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
                                      <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/1/nasil-calisir") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/1/nasil-calisir" class="btn btn-link text-left">
                                      Nasıl Çalışır
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/2/acik-artirmaya-nasil-katilabilirim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/2/acik-artirmaya-nasil-katilabilirim" class="btn btn-link text-left">
                                        Açık Arttırmaya Nasıl Katılabilirim?
                                    </a>
                                  </h2>
                                </div>
                            </div>
                              <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/16/sifir-gibi-servis") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/16/sifir-gibi-servis" class="btn btn-link text-left">
                                       Sıfır Gibi Servis
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/17/sifir-gibi-nakliye") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/17/sifir-gibi-nakliye" class="btn btn-link text-left">
                                       Sıfır Gibi Nakliye
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/3/satis-sonrasi") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/3/satis-sonrasi" class="btn btn-link text-left">
                                        Satış Sonrası
                                     </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/4/teknik-destek") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/4/teknik-destek" class="btn btn-link text-left">
                                      Teknik Destek
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/5/lojistik-teslimat") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/5/lojistik-teslimat" class="btn btn-link text-left">
                                      Lojistik Teslimat
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/6/makina-eksper") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/6/makina-eksper" class="btn btn-link text-left">
                                        Makina Exper
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/7/iade-kosullari") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/7/iade-kosullari" class="btn btn-link text-left">
                                      İade Koşulları
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/8/insan-kaynaklari") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/8/insan-kaynaklari" class="btn btn-link text-left">
                                        İnsan Kaynakları 
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/9/site-kullanim-sartlari") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/9/site-kullanim-sartlari" class="btn btn-link text-left">
                                       Site Kullanım Şartları
                                    </a>
                                  </h2>
                                </div>
                            </div>
                              <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/11/uyelik-sozlesmesi") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/11/uyelik-sozlesmesi" class="btn btn-link text-left">
                                       Üyelik Sözleşmesi
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/12/ihale-katilim-sozlesmesi") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/12/ihale-katilim-sozlesmesi" class="btn btn-link text-left">
                                       İhale Katılım Sözleşmesi
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/sayfalar/13/gizlilik-sozlesmesi") { Response.Write("class='btn btn-link text-left active'"); }%> href="/sayfalar/13/gizlilik-sozlesmesi" class="btn btn-link text-left">
                                       Gizlilik Sözleşmesi
                                    </a>
                                  </h2>
                                </div>
                            </div>
                             <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/SSS") { Response.Write("class='btn btn-link text-left active'"); }%> href="/SSS" class="btn btn-link text-left">
                                       S.S.S.
                                    </a>
                                  </h2>
                                </div>
                            </div>
                             <asp:Literal ID="ltSagMenu" runat="server"/>
                        </div>
                    </div>
                    <div class="col-md-9 profil-right-box">
                        
                              <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#profil-accordion" runat="server">
                                <div class="accordion sss-accordion" id="sss-accordion">
                                   
 <asp:Repeater ID="rptSSS" runat="server" OnItemDataBound="rptSSS_ItemDataBound">
                        <ItemTemplate>
                             <div class="card">
                                      <div class="card-header" id="sssdiv">
                                        <h2 class="mb-0">
                                          <button class="btn btn-link btn-block text-left" type="button" data-toggle="collapse" data-target="#sss-collapseOne" aria-expanded="true" runat="server" id="btndiv">
                                            <%# Eval("Baslik") %> <i class="fas fa-chevron-down"></i>
                                          </button>
                                        </h2>
                                      </div>
                                  
                                      <div id="sss_div" class="collapse"  data-parent="#sss-accordion" runat="server">
                                        <div class="card-body">
                                            <p>
                                                <asp:Literal ID="ltAciklama" runat="server" Text='<%# Eval("Aciklama") %>'></asp:Literal>
                                            </p>
                                        </div>
                                      </div>
                                    </div>
                          </ItemTemplate>
                      </asp:Repeater>

                                </div>
                            </div>
                
        </div>
        </div>
                </div></div></section>

</asp:Content>
