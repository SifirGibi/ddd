<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="MakinaEkle.aspx.cs" Inherits="SifirGibiMakina.MakinaEkle"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link rel="stylesheet" href="/styles/image-uploader.min.css">

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
                </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
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
                 <asp:Panel ID="pnlError" runat="server" Visible="false" Width="700px">
                <div class="alert alert-danger alert-dismissable" >
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-ban"></i> <asp:Label ID="lblHata" runat="server" Font-Size="Small"></asp:Label></h4>
                     <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
                  </div>
             </asp:Panel>
                   <asp:Panel ID="pnlNew" runat="server" Visible="true">
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
                     <asp:TextBox ID="txtAdi" runat="server" class="form-control" placeholder="Makine Başlığı" MaxLength="63"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Makina Adı boş geçilemez" ControlToValidate="txtAdi" ForeColor="#CC3300" ValidationGroup="makina" Display="Dynamic" Font-Size="Small"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                 
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
                       <div class="form-group">
                     <asp:DropDownList ID="ddTurler" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina" OnSelectedIndexChanged="ddTurler_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Makina Türü boş geçilemez." ControlToValidate="ddTurler" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makina" Display="Dynamic" Font-Size="Small"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                     <div class="form-group">
              
                     <asp:DropDownList ID="ddTurlerAlt" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina" OnSelectedIndexChanged="ddTurlerAlt_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Makina Türü boş geçilemez." ControlToValidate="ddTurlerAlt" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makina" Display="Dynamic" Font-Size="Small"></asp:RequiredFieldValidator>
                          </div><!-- /.form-group -->
                           <div class="form-group">
                     <asp:DropDownList ID="ddTurlerAlt2" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina">
                        </asp:DropDownList>
                  </div><!-- /.form-group -->
           </ContentTemplate>
</asp:UpdatePanel>
                 
                    
                    <div class="form-group">
                     <asp:DropDownList ID="ddYillar" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina" OnSelectedIndexChanged="ddYillar_SelectedIndexChanged">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Makina Yılı boş geçilemez." ControlToValidate="ddYillar" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makina" Display="Dynamic" Font-Size="Small"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                    <div class="form-group">
                     <asp:DropDownList ID="ddMarkalar" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Makina Markası boş geçilemez." ControlToValidate="ddMarkalar" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makina" Display="Dynamic" Font-Size="Small"></asp:RequiredFieldValidator>
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
                     <asp:TextBox ID="txtFiyat" runat="server" class="form-control" placeholder="Fiyat" TextMode="Number" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;" ></asp:TextBox> <asp:DropDownList ID="ddParaBirimi" runat="server" CssClass="form-control" ValidationGroup="makina"><asp:ListItem Text="TL" Value="1"></asp:ListItem><asp:ListItem Text="Euro" Value="2"></asp:ListItem><asp:ListItem Text="Dolar" Value="3"></asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Makina Fiyatı boş geçilemez, virgül ve nokta kullanmayın" ControlToValidate="txtFiyat" ForeColor="#CC3300" ValidationGroup="makina" Display="Dynamic" Font-Size="Small"></asp:RequiredFieldValidator>
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
          
                      <asp:TextBox ID="txtCKeditor" runat="server" TextMode="MultiLine" Rows="50" Width="100%" placeholder="Açıklama" CssClass="form-control" MaxLength="4999"></asp:TextBox>
                <div id="characterCount" style="margin-top: 10px;">Karakter Sayısı: 0</div>
               

               <script type="text/javascript" lang="javascript">
                   ClassicEditor
                       .create(document.querySelector('#ContentPlaceHolder1_txtCKeditor'))
                       .then(editor => {
                           editor.model.document.on('change:data', () => {
                               updateCharacterCount(editor);
                           });
                       })
                       .catch(error => {
                           console.error(error);
                       });

                   function updateCharacterCount(editor) {
                       var textLength = editor.getData().length;
                       var characterCountElement = document.getElementById("characterCount");

                       characterCountElement.innerHTML = "Karakter Sayısı: " + textLength;

                       if (textLength > 3000) {
                           characterCountElement.style.color = "red";
                       } else {
                           characterCountElement.style.color = "black";
                       }
                   }
               </script>
              
                  </div><!-- /.form-group -->

                         </div><!-- /.col -->
              </div><!-- /.row -->
               

          <!-- Resimler -->
         
                        <div class="row"><br /><br />
                        <h5 class="form-title">
                           Makina Resimleri(Açılan pencerede CTRL tuşuna basılı tutarak birden fazla resim seçebilirsiniz.)
                                    </h5>
                <div class="col-md-12">
                    <div class="form-control">
                     <asp:FileUpload ID="uplResimler" runat="server" AllowMultiple="True" CssClass="uploaded" />
                      </div><!-- /.form-group -->
                    </div></div>
                       
          <!-- Footer --->
          <div class="text-center">  <br /><br />
              <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="makina" ForeColor="#CC3300" DisplayMode="BulletList" Font-Bold="true" HeaderText="Giriş Hataları" Font-Size="Small" CssClass="text-left"/>
                <asp:Button ID="btnSave" runat="server" Text="Makinemi Kaydet" CssClass="btn btn-success kaydet-button" Width="250px" OnClick="btnSave_Click"  ValidationGroup="makina" UseSubmitBehavior="false" CausesValidation="true" OnClientClick="if (Page_ClientValidate ()) {this.value = 'Gönderiliyor ..'; this.disabled = true; }"/>
               <br />
                
                
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
                    <script src="/js/image-uploader.min.js"></script>
    </div>
</asp:Content>



