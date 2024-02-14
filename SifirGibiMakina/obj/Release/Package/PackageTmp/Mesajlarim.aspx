<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Mesajlarim.aspx.cs" Inherits="SifirGibiMakina.Mesajlarim" ValidateRequest="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- JS -->
	<script src="//code.jquery.com/jquery-3.2.1.min.js"></script>
	<script src="/fancybox/jquery.fancybox.min.js"></script>

       
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
                                      <a <%if (HttpContext.Current.Request.RawUrl == "/profilim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/profilim" class="btn btn-link text-left">
                                      Profilim
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/makinam-ne-eder") { Response.Write("class='btn btn-link text-left active'"); }%> href="/makinam-ne-eder" class="btn btn-link text-left">
                                        Makinem Ne Eder?
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                      <a <%if (HttpContext.Current.Request.RawUrl == "/makina-ekle") { Response.Write("class='btn btn-link text-left active'"); }%> href="/makina-ekle" class="btn btn-link text-left">
                                        Makine Sat
                                     </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/makinalarim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/makinalarim" class="btn btn-link text-left">
                                      Makinelerim
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/ihalelerim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/ihalelerim" class="btn btn-link text-left">
                                      İhalelerim
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/odeme-bildirimi") { Response.Write("class='btn btn-link text-left active'"); }%> href="/odeme-bildirimi" class="btn btn-link text-left">
                                        Ödeme Bildirimi
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/favorilerim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/favorilerim" class="btn btn-link text-left">
                                      Favorilerim
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/mesajlarim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/mesajlarim" class="btn btn-link text-left">
                                        Mesajlarım (<asp:Label ID="lblOkunmamis" runat="server" ForeColor="Red"></asp:Label>)
                                    </a>
                                  </h2>
                                </div>
                            </div>
                            <div class="card acc-card">
                                <div class="card-header">
                                  <h2 class="mb-0">
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/cikis") { Response.Write("class='btn btn-link text-left active'"); }%> href="/cikis" class="btn btn-link text-left">
                                        Çıkış Yap
                                    </a>
                                  </h2>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-9 profil-right-box">
                        <div>

           
                         <asp:Panel ID="pnlData" runat="server">
                                      <div class="row">
                <div class="col-md-12">
                    <div class="table-responsive">
                    <asp:GridView ID="grdMesajlar" runat="server" AutoGenerateColumns="False" PageSize="150" OnRowDeleting="grdMesajlar_RowDeleting" DataKeyNames="UstMesaj_ID"  OnRowDataBound="grdMesajlar_RowDataBound" CssClass="table table-striped table-bordered table-hover text-12-14-500 sgm-table">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Label ID="lblSira" runat="server" Font-Bold="true"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="mesaj_ID" Visible="false"/>
                <asp:BoundField DataField="UstMesaj_ID" Visible="false"/>
                <asp:BoundField DataField="makina_ID" Visible="false"/>
                <asp:BoundField DataField="Ust_FirmaID" Visible="false"/>
                 <asp:TemplateField ShowHeader="True" HeaderText="Resim" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltResim" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IlanNo" Visible="true" HeaderText="İlan No"/>
                <asp:BoundField DataField="Baslik" Visible="true" HeaderText="Ürün"/>
                <asp:TemplateField ShowHeader="True" HeaderText="İlan Durumu" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltDurum" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField ShowHeader="False" HeaderText="Cevapla">
                    <ItemTemplate>

                        <asp:Literal ID="ltCevap" runat="server"></asp:Literal>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="Images/delete.png" CommandName="Delete" runat="server"
                                ID="LinkButton3" ToolTip="Mesajlaşmayı Sil" OnClientClick="return confirm('Mesajlaşmayı silmek istediğinizden emin misiniz?');" CausesValidation="False" Visible="false"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
               
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
        </asp:GridView>
            </div>
                   </div><!-- /.col -->
              </div><!-- /.row -->
                            </asp:Panel>
                         
                   </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>
