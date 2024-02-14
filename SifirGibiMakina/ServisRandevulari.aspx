<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="ServisRandevulari.aspx.cs" Inherits="SifirGibiMakina.ServisRandevulari" ValidateRequest="false" %>


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
                                <div class="card-header">
      <h2 class="mb-0">
        <a <%if (HttpContext.Current.Request.RawUrl == "/userInfo") { Response.Write("class='btn btn-link text-left active'"); }%> href="/makinam-ne-eder" class="btn btn-link text-left">
            Makinem Ne Eder?
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
     <asp:GridView ID="grdMakinalar" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"  PageSize="150" OnRowDeleting="grdMakinalar_RowDeleting" DataKeyNames="ExpertizID" OnRowEditing="grdMakinalar_RowEditing" OnPageIndexChanging="grdMakinalar_PageIndexChanging1" OnRowDataBound="grdMakinalar_RowDataBound" CssClass="table table-striped table-bordered table-hover" Font-Size="x-small" >
         <Columns>
             <asp:TemplateField ShowHeader="False">
                 <ItemTemplate>
                     <asp:Label ID="lblSira" runat="server" Font-Bold="true"></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="ExpertizID" Visible="false"/>
             <asp:BoundField DataField="UserNameRequestingService" Visible="true" HeaderText="Üye Bilgisi"/>
            <asp:BoundField DataField="UserEmailRequestingService" itemstyle-cssclass="hide" headerstyle-cssclass="hide"/>
             <asp:BoundField DataField="MachineTitleRequestingService" Visible="true" HeaderText="Ürün"/>
             <asp:BoundField DataField="MachineYearRequestingService" Visible="true" HeaderText="Yıl"/>
             <asp:BoundField DataField="CategoryNameRequestingService" Visible="true" HeaderText="Tür"/>
             <asp:BoundField DataField="MachineBrandNameRequestingService" Visible="true" HeaderText="Marka"/>
             <asp:BoundField DataField="ScheduledDate" Visible="true" HeaderText="Randevu Tarihi"/>
             <asp:BoundField DataField="CreatedDate" Visible="true" HeaderText="Kayıt Tarihi"/>
             <asp:TemplateField ShowHeader="True" HeaderText="Onay" ItemStyle-HorizontalAlign="Center">
                 <ItemTemplate>
                     <asp:Literal ID="ltDurum" runat="server" Text =" - "></asp:Literal>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField ShowHeader="True" HeaderText="Durum"  ItemStyle-HorizontalAlign="Center">
                 <ItemTemplate>
                     <asp:Literal ID="ltYanit" runat="server" Text=" - " ></asp:Literal>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField ShowHeader="False">
                 <ItemTemplate>
                     <asp:ImageButton ImageUrl="Images/Done.png" CommandName="Edit" runat="server" 
                         Width="24px" 
    Height="24px" ID="LinkButton2" ToolTip="Düzenle" CausesValidation="False" Visible="false"/>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
             </asp:TemplateField>
             <asp:TemplateField ShowHeader="False">
                 <ItemTemplate>
                     <asp:ImageButton ImageUrl="Images/Close.png" CommandName="Delete" runat="server" Width="24px" 
    Height="24px"
                             ID="LinkButton3" ToolTip="Sil" OnClientClick="return confirm('İptal etmek istediğinizden emin misiniz?');" CausesValidation="False" Visible="false"/>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
             </asp:TemplateField>
            
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
