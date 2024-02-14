<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="MesajCevapla.aspx.cs" Inherits="SifirGibiMakina.MesajCevapla" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox.min.css">
    <style>
        .direct-chat-text {
            border-radius: 5px;
            position: relative;
            padding: 5px 10px;
            background: #d2d6de;
            border: 1px solid #d2d6de;
            margin: 5px 0 0 50px;
            color: #444;
            font-size:14px;
        }

    .direct-chat-text-benden {
    border-radius: 5px;
    position: relative;
    padding: 5px 10px;
    background: #cdffb1;
    border: 1px solid #ceffb3;
    margin: 5px 0 0 50px;
    color: black;
    text-align:left;
    font-size:14px;
}
    </style>
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
                
                   <asp:Panel ID="pnlNew" runat="server" Visible="true">
           
           
            <div class="container delay border">

          <!-- Genel Bilgileri -->
          <div class="box">             
            <div class="box-body">
                <div class="row">
                    <div class="col-md-3"><asp:Literal ID="ltResim" runat="server"></asp:Literal><br /><asp:Label ID="lblilanNo" runat="server"></asp:Label><br /><br /><br /></div>
                    <div class="col-md-6"><asp:Label ID="lblBaslik" runat="server" CssClass="color-e" Font-Bold="true"></asp:Label><br /><asp:Label ID="lblil" runat="server"></asp:Label></div>
                    <div class="col-md-3 text-secondary"><asp:Literal ID="ltFiyat" runat="server" ></asp:Literal>	<asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal></div>
                </div>
                      <asp:Repeater ID="rtMesajlar" runat="server">
                                    <ItemTemplate>
                                        
                                        <div class="row">
                                        <%# Eval("Kimden").ToString() == Session["uye_ID"].ToString() ? "<div class=\"col-md-11 direct-chat-text-benden\">" : Eval("Kimden").ToString() != Session["uye_ID"].ToString() ? "<div class=\"col-md-11 direct-chat-text\">" : "" %>
                                             <strong><%# Eval("KimdenAdiSoyadi") %></strong>, <%# Eval("Kayit_Tarihi") %> <br /><br /><%# Eval("Mesaj") %><br />
                    
                                    </div></div>
                                        
                                    </ItemTemplate>
                                </asp:Repeater>
     
                    
                 <div class="row">
                     <div class="col-md-12">
                   <hr />
                    </div></div>
                <div class="col-md-12">
              <div class="row">
             
                <div class="col-md-12">
                  <div class="form-group">
                    <label><strong>Mesajınız</strong></label>
                     <asp:TextBox ID="txtMesaj" runat="server" class="form-control" placeholder="Mesajınızı Giriniz..."></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtMesaj" ForeColor="#CC3300" ValidationGroup="mesaj"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->

                   </div><!-- /.col -->
                  <div class="col-md-12">
                  <div class="form-group">
                      <asp:Button ID="btnGonder" runat="server" Text="Gönder" CssClass="btn btn-block btn-success pull-right" Width="150px" OnClick="btnSave_Click"  UseSubmitBehavior="false" ValidationGroup="mesaj" ForeColor="White"/>
                    </div><!-- /.form-group -->
                   </div><!-- /.col -->
              </div><!-- /.row -->
                
            </div><!-- /.box-body -->
          </div><!-- /.box -->

            </div>

            </asp:Panel>
        
                  <asp:Panel ID="PnlFinish" runat="server" Visible="false">
                <div class="box box-primary">
           
            <div class="box-body">

              <div class="row">
                  <div class="col-md-12">
                   <br />
                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                      </div></div></div></div>

                  </asp:Panel>


                   </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>
