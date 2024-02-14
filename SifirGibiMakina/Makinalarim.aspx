<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Makinalarim.aspx.cs" Inherits="SifirGibiMakina.Makinalarim" ValidateRequest="false" %>


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
            .customDropdown {
            max-width: 150px; /* İstediğiniz genişliğe göre ayarlayın */
            word-wrap: break-word;
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
                                   <a <%if (HttpContext.Current.Request.RawUrl == "/cikis") { Response.Write("class='btn btn-link text-left active'"); }%> href="/cikis" class="btn btn-link text-left">
                                        Çıkış Yap
                                    </a>
                                  </h2>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-9 profil-right-box">
                       <asp:Panel ID="pnlWithData" runat="server"> 
                         <asp:Panel ID="pnlNew" runat="server" Visible="false">
                       <div class="row">
                            <div class="card-body">
                                <div class="mb-3">
                                    <h5 class="form-title">
                                        Makine Özellikleri
                                    </h5>
                                    </div></div>
                           </div>
                       <div class="row">
                <div class="col-md-6 pr-025rem sm-px-8">
                  <div class="form-group">
                     <asp:TextBox ID="txtAdi" runat="server" class="form-control" placeholder="Makine Başlığı"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Makina Adı boş geçilemez" ControlToValidate="txtAdi" ForeColor="#CC3300" ValidationGroup="makina" Display="Dynamic"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                    <div class="form-group">
                     <asp:DropDownList ID="ddTurler" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Makina Türü boş geçilemez." ControlToValidate="ddTurler" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makina" Display="Dynamic"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                     <div class="form-group">
                     <asp:DropDownList ID="ddTurlerAlt" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Makina Türü boş geçilemez." ControlToValidate="ddTurlerAlt" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makina" Display="Dynamic"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                    <div class="form-group">
                     <asp:DropDownList ID="ddYillar" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Makina Yılı boş geçilemez." ControlToValidate="ddYillar" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makina" Display="Dynamic"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                    <div class="form-group">
                     <asp:DropDownList ID="ddMarkalar" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Makina Markası boş geçilemez." ControlToValidate="ddMarkalar" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makina" Display="Dynamic"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                    <div class="form-group">
                     <asp:TextBox ID="txtModel" runat="server" class="form-control" placeholder="Makine Modeli"></asp:TextBox>
                  </div><!-- /.form-group -->
                </div><!-- /.col -->
                  <div class="col-md-6 pl-025rem sm-px-8">
                    <div class="form-group">
                     <asp:TextBox ID="txtKM" runat="server" class="form-control" placeholder="Çalışma Saati"></asp:TextBox>
                  </div><!-- /.form-group -->
                      <div class="form-group">
                     <asp:DropDownList ID="ddUlkeler" runat="server" CssClass="form-control select2" Width="100%">
                        </asp:DropDownList>
                  </div><!-- /.form-group -->
                       <div class="form-group">
                     <asp:TextBox ID="txtil" runat="server" class="form-control" placeholder="İl"></asp:TextBox>
                  </div><!-- /.form-group -->
                       <div class="form-group">
                     <asp:TextBox ID="txtIlce" runat="server" class="form-control" placeholder="İlçe"></asp:TextBox>
                  </div><!-- /.form-group -->
                      <div class="form-group">
                     <asp:TextBox ID="txtFiyat" runat="server" class="form-control" placeholder="Fiyat" TextMode="Number"></asp:TextBox> <asp:DropDownList ID="ddParaBirimi" runat="server" CssClass="form-control" ValidationGroup="makina"><asp:ListItem Text="TL" Value="1"></asp:ListItem><asp:ListItem Text="Euro" Value="2"></asp:ListItem><asp:ListItem Text="Dolar" Value="3"></asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Makina Fiyatı boş geçilemez" ControlToValidate="txtFiyat" ForeColor="#CC3300" ValidationGroup="makina" Display="Dynamic"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                       <div class="form-group form-check">
                                                 <asp:CheckBox ID="chkFiyatGosterilmesin" runat="server" CssClass="form-check-input"/>
                                                <input type="checkbox" class="form-check-input" id="fiyat-gosterilmesin">
                                                <label class="form-check-label" for="fiyat-gosterilmesin">
                                                    Fiyat gösterilmesin, sadece teklif talebi alınsın.
                                                </label>
                                            </div>
                   </div><!-- /.col -->
              </div><!-- /.row -->


          <!-- Satış Temsilcisi -->
        
                <div class="row">
                            <div class="card-body">
                                <div class="mb-3">
                                    <h5 class="form-title">
                                        Satış Temsilcisi
                                    </h5>
                                    </div></div>
                           </div>
                <div class="row">
                <div class="col-md-4">
                  <div class="form-group">
                     <asp:TextBox ID="txtSatisTemsilcisiAdi" runat="server" class="form-control" placeholder="Satış Temsilcisi Adı" MaxLength="250"></asp:TextBox>
                  </div><!-- /.form-group -->  
                  </div><!-- /.col -->
                  <div class="col-md-4">
                  <div class="form-group">
                     <asp:TextBox ID="txtSatisTemsilcisiEmail" runat="server" class="form-control" placeholder="Satış Temsilcisi E-Mail" MaxLength="150"></asp:TextBox>
                  </div><!-- /.form-group -->  
                  </div><!-- /.col -->
                  <div class="col-md-4">
                  <div class="form-group">
                     <asp:TextBox ID="txtSatisTemsilcisiTelefon" runat="server" class="form-control" placeholder="Satış Temsilcisi Telefon"></asp:TextBox>
                  </div><!-- /.form-group -->  
                  </div><!-- /.col -->
              </div><!-- /.row -->
                <div class="row">
                    <div class="col-md-12">
                        <hr />
                    </div>
                </div>
           
          
          <!-- Eksper Bilgileri -->


                <div class="row">
                            <div class="card-body">
                 <div class="mb-3">
                                    <h5 class="form-title">
                                        Eksper Bilgiler
                                    </h5></div></div></div>
                <div class="row exper-talep">
                                        <div class="col-md-12">
                                            <p>
                                                Makinanıza ait eksper bilgilerini aşağıda işaretleyebilirsiniz. Dilerseniz sizin adınıza ekspertiz hizmeti verebiliriz. Ekspertiz hizmeti almak için şağıdaki seçeneği işaretleyebilirsiniz.
                                            </p>
                                        </div>
<div class="col-md-12">
                                            <div class="form-group form-check mb-0">
                                                 <asp:CheckBox ID="chkEksper" runat="server" CssClass="form-check-input"/>
                                                <input type="checkbox" class="form-check-input" id="exper-talep">
                                                <label class="form-check-label" for="exper-talep">
                                                    Sıfır Gibi Eksper Talep Etmek İstiyorum.
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                
                <br /><br />
                <div class="table-responsive">
                  <asp:GridView ID="grdOzellikler" runat="server" AutoGenerateColumns="False" PageSize="500" DataKeyNames="eksper_ID" OnRowDataBound="grdOzellikler_RowDataBound" CssClass="table table-striped table-bordered table-hover mb-3 exper-table text-12-14-500">

            <Columns>
                  <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Label ID="lblSira" runat="server" Font-Bold="true"></asp:Label>
                        <asp:Label ID="lblEksperID" runat="server" Text ='<%#Eval("eksper_ID") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="Kategori" HeaderText="Özellik" />
               
                <asp:TemplateField ShowHeader="False" HeaderStyle-HorizontalAlign="Center" HeaderText="Puan">
                     <ItemTemplate>
                        <asp:DropDownList ID="ddOzellikNot" runat="server" CssClass="form-control" Width="100%">
                            <asp:ListItem Value="0" Text="0"></asp:ListItem>
                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                        </asp:DropDownList>
                      </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                    </div>


          <!-- İhale -->
              <div class="row">
                            <div class="card-body">
                                <div class="mb-3">
                                    <h5 class="form-title">
                                       İhale Bilgileri
                                    </h5>
                                    </div></div>
                           </div>
              <div class="row">
                <div class="col-md-12">
                  <div class="form-group">
                    <p class="p-label">Makineniz ihale ile satılsın mı?</p>
                     <asp:DropDownList ID="ddIhale" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina" OnSelectedIndexChanged="ddIhale_SelectedIndexChanged" AutoPostBack="true">
                         <asp:ListItem Text="Hayır" Value="0"></asp:ListItem>
                         <asp:ListItem Text="Evet" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                  </div><!-- /.form-group -->  
                  </div><!-- /.col -->
              </div><!-- /.row -->
              <asp:Panel ID="pnlIhale" runat="server" Visible="false">
                <div class="row">
                <div class="col-md-6">
                  <div class="form-group">
                     <h5 class="form-title">İhale Başlangıç Tarihi</h5>
                      <div class="input-group">
                      <asp:TextBox ID="txtIhaleBaslangicTarihi" runat="server" CssClass="form-control pull-right" type="date" Text='<%# DateTime.Today %>' TextMode="DateTimeLocal" Visible="true"></asp:TextBox>
                    </div><!-- /.input group -->
                  </div><!-- /.form-group -->  
                  </div><!-- /.col -->
                  <div class="col-md-6">
                  <div class="form-group">
                    <h5 class="form-title">İhale Bitiş Tarihi</h5>
                       <div class="input-group">
                      <asp:TextBox ID="txtIhaleBitisTarihi" runat="server" CssClass="form-control pull-right" type="date" Text='<%# DateTime.Today %>' TextMode="DateTimeLocal" Visible="true"></asp:TextBox>
                    </div><!-- /.input group -->
                  </div><!-- /.form-group -->  
                  </div><!-- /.col -->
                  <div class="col-md-4">
                  <div class="form-group">
                    <h5 class="form-title">İhale Başlangıç Fiyatı</h5>
                     <asp:TextBox ID="txtIhaleBaslangicFiyati" runat="server" class="form-control" place="Fiyat giriniz..." Visible="true" TextMode="Number"></asp:TextBox>
                  </div><!-- /.form-group -->  
                  </div><!-- /.col -->
                     <div class="col-md-4">
                  <div class="form-group">
                      <h5 class="form-title">Min. Satış Fiyatı</h5>
                     <asp:TextBox ID="txtMinSatisFiyati" runat="server" class="form-control" place="Fiyat giriniz..." Visible="true" TextMode="Number"></asp:TextBox>
                  </div><!-- /.form-group -->  
                  </div><!-- /.col -->
                    <div class="col-md-4">
                  <div class="form-group">
                    <h5 class="form-title">Teminat Bedeli</h5>
                     <asp:TextBox ID="txtKapora" runat="server" class="form-control" place="Fiyat giriniz..." Visible="true"></asp:TextBox>
                  </div><!-- /.form-group -->  
                  </div><!-- /.col -->
              </div><!-- /.row -->
                    </asp:Panel>
              
                    
          <!-- İçerik -->
              <div class="row">
                            <div class="card-body">
                                <div class="mb-3">
                                    <h5 class="form-title">
                                       Ürün Açıklaması
                                    </h5>
                                    </div></div>
                           </div>
              <div class="row">
                <div class="col-md-12">
        <div class="form-group">
                       <asp:TextBox ID="txtCKeditor" runat="server" TextMode="MultiLine" rows="7" Width="100%" placeholde="Açıklama" CssClass="form-control"></asp:TextBox>
                <script type="text/javascript" lang="javascript">
         ClassicEditor.create(document.querySelector('#ContentPlaceHolder1_txtCKeditor'));
                </script>
                  </div><!-- /.form-group -->

                         </div><!-- /.col -->
              </div><!-- /.row -->
               

          <!-- Resimler -->
           <asp:HiddenField ID="hdID" runat="server" Visible="false"/>
           <div class="row"><br /><br />
                        <h5 class="form-title">
                           Makina Resimleri(Açılan pencerede CTRL tuşuna basılı tutarak birden fazla resim seçebilirsiniz.)
                                    </h5>
                <div class="col-md-12">
                    
                     <asp:FileUpload ID="uplResimler" runat="server" AllowMultiple="True" CssClass="uploaded" />


                         <asp:ListView ID="lstPhotos" GroupItemCount="5" runat="server" DataKeyNames="makinaResim_ID" OnItemDataBound="lstPhotos_ItemDataBound">
                             
                            <LayoutTemplate>
                                <asp:Placeholder id="groupPlaceholder" runat="server" />
                            </LayoutTemplate>
                            <GroupTemplate>
                                <div class="row"> <asp:Placeholder id="itemPlaceholder" runat="server" /></div>
                            </GroupTemplate>
                            <ItemTemplate>
							<div class="col-md-2">
                                <div class="form-group">
                                <a href='<%# "/admin/Uploads/" + Eval("Fotograf") %>' class="highslide" onclick="return hs.expand(this,
			                    {src: '<%# "/admin/Uploads/" + Eval("Fotograf") %>', wrapperClassName: 'highslide-white', outlineType: 'rounded-white', dimmingOpacity: 0.75, align: 'center' })"><img src='<%# "/admin/Uploads/" + Eval("Fotograf") %>'  class="img" width="50" height="50"/></a>
                                <a href="/FotoSil.aspx?ID=<%# Eval("makinaResim_ID") %>" class="btn-danger btn-delete" data-id='<%# Eval("makinaResim_ID") %>'/>SİL</a><br /> 
                                <a href="/VitrinFoto.aspx?ID=<%# Eval("makinaResim_ID") %>" class="btn-success btn-delete" data-id='<%# Eval("makinaResim_ID") %>'/>Ana Foto Yap</a>
                                    <asp:Literal ID="ltVitrin" runat="server" Text='<%#Eval("Vitrin")%>'></asp:Literal>
      
                                </div></div>
                            </ItemTemplate> 
                        </asp:ListView>
                      </div>
                    </div>
                          
          <!-- Footer --->
                             <div class="row">
                                 <div class="col-12">
                             <div class="text-center">
           <br /><br />
              <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="makina" ForeColor="#CC3300" DisplayMode="BulletList" Font-Bold="true" HeaderText="Giriş Hataları"/>
                <asp:Button ID="btnSave" runat="server" Text="Makinemi Kaydet" CssClass="btn btn-success kaydet-button text-center" Width="250px" OnClick="btnSave_Click"  ValidationGroup="makina" UseSubmitBehavior="false" CausesValidation="false"/>
               <br />
                </div>
                </div>
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
                         <asp:Panel ID="pnlData" runat="server">
                                      <div class="row">
                <div class="col-md-12">
                    <div class="table-responsive">
                   
                    <asp:GridView ID="grdMakinalar" runat="server" AutoGenerateColumns="False" PageSize="150" OnRowDeleting="grdMakinalar_RowDeleting" DataKeyNames="makina_ID"  OnRowDataBound="grdMakinalar_RowDataBound" OnRowEditing="grdMakinalar_RowEditing" CssClass="table table-striped table-bordered table-hover text-12-14-500  sgm-table" OnRowCommand="grdMakinalar_RowCommand">
            <Columns>
                <asp:TemplateField ShowHeader="False" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblSira" runat="server" Font-Bold="true"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="makina_ID" Visible="false"/>
                <asp:BoundField DataField="Ust_FirmaID" Visible="false"/>
                 <asp:TemplateField ShowHeader="true" HeaderText="" HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="Images/Edit.png" CommandName="Edit" runat="server" ID="LinkButton2" ToolTip="Düzenle" CausesValidation="False" Visible="false"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="true" HeaderText="Yayından Kaldır">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="Images/delete.png" CommandName="Delete" runat="server"
                                ID="LinkButton3" ToolTip="Yayından Kaldır" OnClientClick="return confirm('Yayından kaldırmak istediğinizden emin misiniz?');" CausesValidation="False" Visible="false"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                 <asp:TemplateField ShowHeader="True" HeaderText="Resim" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltResim" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="IlanNo" Visible="true" HeaderText="İlan No"/>
                <asp:BoundField DataField="Baslik" Visible="true" HeaderText="Ürün"/>
                <asp:BoundField DataField="Yil" Visible="false" HeaderText="Yıl"/>
                <asp:BoundField DataField="Tur" Visible="false" HeaderText="Tür"/>
                <asp:BoundField DataField="Marka" Visible="false" HeaderText="Marka"/>
                <asp:BoundField DataField="GoruntulenmeSayisi" Visible="true" HeaderText="Görünüm"/>
                <asp:BoundField DataField="FavoriSayisi" Visible="true" HeaderText="Favori"/>
                <asp:BoundField DataField="Kayit_Tarihi" Visible="false" HeaderText="Kayıt Tarihi"/>
                <asp:TemplateField ShowHeader="True" HeaderText="Onay" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltYayin" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField ShowHeader="True" HeaderText="İhale Durumu" ItemStyle-HorizontalAlign="Center" Visible="false">
                    <ItemTemplate>
                        <asp:Literal ID="ltIhale" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ShowHeader="True" HeaderText="Durumu" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
<asp:DropDownList ID="ddlDurum" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDurum_SelectedIndexChanged" CssClass="customDropdown">
    <asp:ListItem Text="İnceleniyor" Value="1" Enabled="false"></asp:ListItem>
    <asp:ListItem Text="Satışta" Value="2" Enabled="false"></asp:ListItem>
    <asp:ListItem Text="Kapalı" Value="3"></asp:ListItem>
    <asp:ListItem Text="Satıldı" Value="4" Enabled="false"></asp:ListItem>
    <asp:ListItem Text="Yakında Stokta" Value="5" Enabled="false"></asp:ListItem>
    <asp:ListItem Text="Süresi Doldu" Value="6" Enabled="false"></asp:ListItem>
    <asp:ListItem Text="Kullanıcı tarafından Yayından kaldırıldı" Value="7" Enabled="false"></asp:ListItem>
    <asp:ListItem Text="Değişiklik Onayı Bekleniyor" Value="8"></asp:ListItem>
</asp:DropDownList>

                         <asp:ImageButton ImageUrl="Images/bekleniyor.png" CommandName="Yayin" CommandArgument='<%#Eval ("makina_ID") %>' runat="server"
                                ID="LinkButtonYayin" ToolTip="Tekrar Yayınla" OnClientClick="return confirm('Tekrar yayına almak istediğinizden emin misiniz?');" CausesValidation="False" Visible="false" AlternateText="İlanı Tekrar Yayınla"/>
                         <asp:Button ID="btnYayin" runat="server" Text="İlanı Tekrar Yayınla" CommandName="Yayin" CommandArgument='<%#Eval ("makina_ID") %>' 
                                ToolTip="Tekrar Yayınla" OnClientClick="return confirm('Tekrar yayına almak istediğinizden emin misiniz?');" CausesValidation="False" Visible="false" AlternateText="İlanı Tekrar Yayınla" />
                    </ItemTemplate>
                </asp:TemplateField>

  
               
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
        </asp:GridView>

                          
            </div>
                   </div><!-- /.col -->
              </div><!-- /.row -->
                            </asp:Panel>
                         <asp:Panel ID="pnlYayindanKaldir" runat="server" Visible="false">
                             <div class="row">
                                 <div class="col-12">
                             <div class="text-center">
                                 <asp:Literal ID="ltilanbilgi" runat="server"></asp:Literal><br /><br />
                                
                             <asp:DropDownList ID="ddNeden" runat="server" CssClass="form-control" Width="100%" ValidationGroup="kaldir">
                            <asp:ListItem Value="0" Text="İlanı kaldırma sebebini lütfen seçiniz"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Sifirgibimakine.com vasıtasıyla sattım"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Başka bir platformda sattım "></asp:ListItem>
                            <asp:ListItem Value="3" Text="Satmaktan vazgeçtim"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Diğer"></asp:ListItem>
                        </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="* Neden seçiniz." ControlToValidate="ddNeden" ForeColor="#CC3300" InitialValue="0" ValidationGroup="kaldir"></asp:RequiredFieldValidator>
                             <br /><br /><asp:Button ID="btnKaldir" runat="server" Text="Yayından Kaldır" CssClass="btn btn-danger text-center" Width="250px" OnClick="btnKaldir_Click"  ValidationGroup="kaldir" UseSubmitBehavior="false" CausesValidation="true"/>

                                 </div></div></div>

                             <asp:HiddenField ID="hdKaldirID" runat="server" Visible="false"/>
                        </asp:Panel>

                           </asp:Panel>
                               <asp:Panel runat="server" ID="pnlNonData">

              <div class="card-body">
                  <h5>Aktif Ilanınız Bulunmamaktadır!</h5>
                  </div>


       </asp:Panel>
                             </div>
                <script src="/js/image-uploader.min.js"></script>
                 
        </div>
</asp:Content>
