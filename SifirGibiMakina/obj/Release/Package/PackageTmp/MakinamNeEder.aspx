<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="MakinamNeEder.aspx.cs" Inherits="SifirGibiMakina.MakinamNeEder" %>


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
                
                        <asp:Panel ID="pnlMakinamNeEderNew" runat="server">
                             <h5 class="form-title">
                                        Makine Özellikleri
                                    </h5>
                  <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                     <asp:DropDownList ID="ddTurler" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makinamneeder" OnSelectedIndexChanged="ddTurler_SelectedIndexChanged" AutoPostBack="true" required>
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Makine türünü giriniz." ControlToValidate="ddTurler" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makinamneeder" Display="Dynamic"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                    <div class="form-group">
                     <asp:DropDownList ID="ddTurlerAlt" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makinamneeder" OnSelectedIndexChanged="ddTurlerAlt_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Makine alt türünü giriniz." ControlToValidate="ddTurlerAlt" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makinamneeder" Display="Dynamic"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                     <div class="form-group">
                     <asp:DropDownList ID="ddTurlerAlt2" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makinamneeder">
                        </asp:DropDownList>
                  </div><!-- /.form-group -->
                    <div class="form-group">
                     <asp:DropDownList ID="ddYillar" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makinamneeder">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Yıl giriniz" ControlToValidate="ddYillar" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makinamneeder"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                    <div class="form-group">
                     <asp:DropDownList ID="ddMarkalar" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makinamneeder">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* Marka giriniz" ControlToValidate="ddMarkalar" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makinamneeder"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                       <div class="form-group">
                     <asp:TextBox ID="txtOngorulenFiyat" runat="server" class="form-control" placeholder="Öngördüğünüz Fiyat"></asp:TextBox> <asp:DropDownList ID="ddOnGorulenParaBirimi" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makinamneeder"><asp:ListItem Text="TL" Value="1"></asp:ListItem><asp:ListItem Text="Euro" Value="2"></asp:ListItem><asp:ListItem Text="Dolar" Value="3"></asp:ListItem></asp:DropDownList>
                  </div><!-- /.form-group -->
                </div><!-- /.col -->
                  <div class="col-md-6">
                       <div class="form-group">
                     <asp:TextBox ID="txtMakinaBaslik" runat="server" class="form-control" placeholder="Makine Başlığı" required="required"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Makine başlığını giriniz" ControlToValidate="txtMakinaBaslik" ForeColor="#CC3300" ValidationGroup="makinamneeder"></asp:RequiredFieldValidator>
                  </div><!-- /.form-group -->
                      <div class="form-group">
                     <asp:TextBox ID="txtModel" runat="server" class="form-control" placeholder="Makine Modeli" required="required"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Makine modelini giriniz" ControlToValidate="txtModel" ForeColor="#CC3300" ValidationGroup="makinamneeder"></asp:RequiredFieldValidator>
                      </div><!-- /.form-group -->
                
                       <div class="form-group">
                     <asp:TextBox ID="txtAciklama" runat="server" class="form-control" placeholder="Açıklama giriniz..." TextMode="MultiLine" Height="160px"></asp:TextBox>
                      </div><!-- /.form-group -->
   
                       
                   </div><!-- /.col -->
              </div><!-- /.row -->
                <div class="row"><br /><br />
                        <h5 class="form-title">
                           Ürüne Ait Fotoğraflar(Birden fazla resim seçebilirsiniz)
                                    </h5>
                <div class="col-md-12">
                    <div class="form-control">
                     <asp:FileUpload ID="uplResimler" runat="server" AllowMultiple="True" CssClass="uploaded" />
                      </div><!-- /.form-group -->
                    </div></div>

                  <div class="row">
                <div class="col-md-12">

                  <div class="form-group">
                      <asp:ValidationSummary ID="form1ValidationSummary" runat="server" ValidationGroup="makinamneeder"/>
                        <div class="text-center"><br /><br />
                   <asp:Button ID="btnMakinamNeEder" runat="server" Text="Makinemi Değerlendirin" CssClass="btn btn-success kaydet-button" Width="250px" Height="50px" OnClick="btnMakinamNeEder_Click" ValidationGroup="makinamneeder"  ForeColor="White" OnClientClick="if (Page_ClientValidate ()) {this.value = 'Gönderiliyor ..'; this.disabled = true; }" UseSubmitBehavior="false"/>
                  </div>
                        </div><!-- /.form-group -->
                    </div>
                    <div class="col-md-12">
                  <div class="form-group">
                      <hr />
                      <h4><span class="form-title">Değerlendirmeye Gönderilen Makinalar</span></h4>
                      <br />
                      <asp:Label ID="lblDegerlendirmeSayisi" runat="server" ForeColor="Green"></asp:Label>
      <div class="table-responsive">
        <asp:GridView ID="grdMakinamNeEder" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"  PageSize="150"  DataKeyNames="makinamneeder_ID" OnRowDataBound="grdMakinamNeEder_RowDataBound" CssClass="table table-striped table-bordered table-hover text-12-14-500 sgm-table">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Label ID="lblSira" runat="server" Font-Bold="true"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="makinamneeder_ID" Visible="false"/>
                <asp:BoundField DataField="Baslik" Visible="true" HeaderText="Ürün"/>
                <asp:BoundField DataField="Yil" Visible="true" HeaderText="Yıl"/>
                <asp:BoundField DataField="Tur" Visible="true" HeaderText="Kategori"/>
                <asp:BoundField DataField="Marka" Visible="true" HeaderText="Marka"/>
                 <asp:TemplateField ShowHeader="True" HeaderText="Ön Görülen Fiyat" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltOngorulen" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField ShowHeader="True" HeaderText="Değerlendirilen Fiyat" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Literal ID="ltDegerlendirilen" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Kayit_Tarihi" Visible="true" HeaderText="Kayıt Tarihi"/>

            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-ys" />
        </asp:GridView></div>
                  </div><!-- /.form-group -->
                    </div></div><!-- /.row -->
                  </asp:Panel>

                        <asp:Panel ID="MakinamNeEderFinish" runat="server" Visible="false">
                        <div class="row">
                            <div class="col-md-12">
                               <asp:Literal ID="ltMakinamNeEderStatus" runat="server"></asp:Literal>
                            </div>
                        </div>
                        </asp:Panel>

     
                        
                  
                    </div></div></div></div>

</asp:Content>
