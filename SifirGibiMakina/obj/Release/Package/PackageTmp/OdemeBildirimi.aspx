<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="OdemeBildirimi.aspx.cs" Inherits="SifirGibiMakina.OdemeBildirimi" %>


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
                        

                                                   <asp:Panel ID="pnlNew" runat="server" Visible="true">
           

              <div class="row">
                  <div class="col-md-12">
                      <h5 class="form-title">Yeni Ödeme Bildirimi</h5>
                      </div>
                <div class="col-md-6">
                     <div class="form-group">
                     <asp:DropDownList ID="ddMakina" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="intranet" AutoPostBack="true" OnSelectedIndexChanged="ddMakina_SelectedIndexChanged">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="ddMakina" ForeColor="#CC3300" InitialValue="0" ValidationGroup="odeme"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                  <div class="form-group">
                     <asp:TextBox ID="txtBanka" runat="server" class="form-control" placeholder="Banka"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtBanka" ForeColor="#CC3300" ValidationGroup="odeme"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                     <div class="form-group">
                     <asp:TextBox ID="txtDekontNo" runat="server" class="form-control" placeholder="Dekont No"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="txtDekontNo" ForeColor="#CC3300" ValidationGroup="odeme"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                </div><!-- /.col -->
                  <div class="col-md-6">
                <div class="form-group">
                     <asp:DropDownList ID="ddUyeler" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="intranet">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="ddUyeler" ForeColor="#CC3300" InitialValue="0" ValidationGroup="odeme"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                      <div class="form-group">
                     <asp:TextBox ID="txtFiyat" runat="server" class="form-control" placeholder="Ödenen miktar"></asp:TextBox> <asp:DropDownList ID="ddParaBirimi" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="odeme"><asp:ListItem Text="TL" Value="1"></asp:ListItem><asp:ListItem Text="Euro" Value="2"></asp:ListItem><asp:ListItem Text="Dolar" Value="3"></asp:ListItem></asp:DropDownList>
                  </div><!-- /.form-group -->
                   </div><!-- /.col -->
              </div><!-- /.row -->
                <div class="row">
                    <div class="col-md-12">
                          <div class="form-group">
                       <asp:TextBox ID="txtCKeditor" runat="server" TextMode="MultiLine" Width="100%" Height="100px" placeholder="Açıklama giriniz..."></asp:TextBox>
       
                  </div><!-- /.form-group -->
                         <div class="form-group">
                    <h5 class="form-title success">Dekont</h5> <asp:FileUpload ID="uplDekont" runat="server" placeholder="Dekont"/>  
                  </div><!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                          <div class="form-group">
                               <div class="text-center">
                          <asp:Button ID="btnOdemeBildirimi" runat="server" Text="Ödeme Bildirimini Gönder" CssClass="btn btn-success kaydet-button" Width="250px" OnClick="btnSaveOdeme_Click"  UseSubmitBehavior="false" ValidationGroup="odeme" ForeColor="White" CausesValidation=false />
</div>
       
                  </div><!-- /.form-group -->
                    </div>
                </div>
    

            </asp:Panel>
        
                  <asp:Panel ID="PnlFinish" runat="server" Visible="false">


              <div class="row">
                  <div class="col-md-12">
                   <br />
                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                      </div></div></asp:Panel>
      <br /><br />
  <h5 class="form-title">Yapılan Ödeme Bildirimleri</h5>

      
        <asp:GridView ID="grdOdemeler" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"  PageSize="150"  DataKeyNames="odeme_ID" OnRowDataBound="grdOdemeler_RowDataBound" CssClass="table table-striped table-bordered table-hover text-12-14-500 sgm-table">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Label ID="lblSira" runat="server" Font-Bold="true"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="odeme_ID" Visible="false"/>
                 <asp:TemplateField ShowHeader="True" HeaderText="Dekont" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltDosya" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Baslik" Visible="true" HeaderText="Ürün"/>
                <asp:BoundField DataField="AdSoyad" Visible="true" HeaderText="Üye Adı Soyadı"/>
                <asp:BoundField DataField="Banka" Visible="true" HeaderText="Banka"/>
                <asp:BoundField DataField="Verilen_Fiyat" Visible="true" HeaderText="Yatırılan"/>
                <asp:BoundField DataField="DekontNo" Visible="true" HeaderText="Dekont No"/>
                <asp:BoundField DataField="Kayit_Tarihi" Visible="true" HeaderText="Kayıt Tarihi"/>
                 <asp:TemplateField ShowHeader="True" HeaderText="İhaleye Katılabilir mi?" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltIhale" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
        </asp:GridView>
      <br />
      <strong>Not:</strong> Ödemeniz alınarak kontrol edildikten sonra "<strong>İhaleye Katılabilir mi?</strong>" alanında okey işareti görebileceksiniz. <br />




                                <%--<div class="profil-ihalelerim text-center">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h4>Üzgünüz, henüz ödeme bildirimin yok.</h4>
                                                <button class="btn btn-success">
                                                    Ödeme Bildir
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>

        </div>
    

</asp:Content>
