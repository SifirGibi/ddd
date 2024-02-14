<%@ Page Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="UserPaymentInfo.aspx.cs" Inherits="SifirGibiMakina.UserPaymentInfo"  ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox.min.css">
         <style>
            .ck-editor__editable[role="textbox"] {
                /* editing area */
                min-height: 200px;
            }
            .ck-content .image {
                /* block images */
                max-width: 80%;
                margin: 20px auto;
            }
             .hide
    {
        display: none;
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
                                 <asp:Panel ID="pnlServisRandevulari" runat="server" Visible="false">
         <div class="card acc-card">
             <div class="card-header">
                 <h2 class="mb-0">
                     <a <%if (HttpContext.Current.Request.RawUrl == "/servis-randevulari") { Response.Write("class='btn btn-link text-left active'"); }%> href="/servis-randevulari" class="btn btn-link text-left">Servis Randevuları
                     </a>
                 </h2>
             </div>
         </div>
     </asp:Panel>
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
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/cikis") { Response.Write("class='btn btn-link text-left active'"); }%> href="/cikis" class="btn btn-link text-left">
                                        Çıkış Yap
                                    </a>
                                  </h2>
                                </div>
                            </div>
                        </div>
                    </div>
                                        <div class="col-md-9 profil-right-box">
                       
                        <asp:Panel ID="pnlData" runat="server"> 
             <div class="box box-warning">
                 <div class="box-body">

     <br /><br />
     <div class="table-responsive">
     <asp:GridView ID="grdUserPayment" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"  PageSize="150" OnRowDeleting="grdUserPayment_RowDeleting" DataKeyNames="UserID" OnRowEditing="grdUserPayment_RowEditing" OnPageIndexChanging="grdUserPayment_PageIndexChanging1" OnRowDataBound="grdUserPayment_RowDataBound" CssClass="table table-striped table-bordered table-hover" Font-Size="x-small" >
         <Columns>
             <asp:TemplateField ShowHeader="False">
                 <ItemTemplate>
                     <asp:Label ID="lblSira" runat="server" Font-Bold="true"></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="UserID" Visible="false"/>
             <asp:BoundField DataField="MembershipID" Visible="false"/>
             <asp:BoundField DataField="MembershipName" Visible="true" HeaderText="Paket"/>
             <asp:BoundField DataField="MembershipVersion" Visible="true" HeaderText="Version"/>
             <asp:BoundField DataField="MaxAds" Visible="true" HeaderText="Adet Ilan"/>
             <asp:BoundField DataField="IsPaid" Visible="true" HeaderText="Odeme"/>
             <asp:BoundField DataField="IsActive" Visible="true" HeaderText="Aktif"/>
             <asp:BoundField DataField="PaymentPlanName" Visible="true" HeaderText="Odeme Plani"/>
             <asp:BoundField DataField="CreatedDate" Visible="true" HeaderText="Kayit Tarihi"/>
           
         
            
         </Columns>
         <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
     </asp:GridView>
                     </div>
                    
 <%--     <br /><br />
                     <img src="/images/excel.png" /><asp:LinkButton ID="ExceleAktarLinkButton" runat="server" OnClick="ExceleAktarLinkButton_Click">Excele Aktar</asp:LinkButton>--%>
          </div></div>
                     </asp:Panel>
                                            




                             </div>
                    </div>
                </div>
        </div>
                <script src="/js/image-uploader.min.js"></script>
                 
</asp:Content>