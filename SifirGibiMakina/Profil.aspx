<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="SifirGibiMakina.Profil" %>


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
    <!-- Phone Number -->

    <link rel="stylesheet" href="/styles/intlTelInput.css" />

    <!-- JS -->
    <style>
        .leftside {
            margin-left: 12pc;
        }

        .img-bordered-sm {
            border: 2px solid #d2d6de;
            padding: 2px;
        }

        .input-container {
            margin-bottom: 10px; /* Input alanları arasında boşluk bırakmak için */
        }

        .dynamicInput {
            display: block;
            margin-bottom: 5px; /* Input alanları arasında daha az boşluk bırakmak için */
        }

        .iti__selected-dial-code {
            margin-left: 6px;
            font-size: 12px;
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
            <h4><i class="icon fa fa-ban"></i>
                <asp:Label ID="lblHata" runat="server"></asp:Label></h4>
            <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
        </div>
    </asp:Panel>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="profilim accordion" id="profil-accordion">
        <div class="container">
            <div class="row">
                <div class="col-md-3 sm-d-none">
                    <div class="profil-sidebar">
                        <div class="card acc-card">
                            <div class="card-header">
                                <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/profilim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/profilim" class="btn btn-link text-left">Profilim
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
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/makinam-ne-eder") { Response.Write("class='btn btn-link text-left active'"); }%> href="/makinam-ne-eder" class="btn btn-link text-left">Makinem Ne Eder?
                                    </a>
                                </h2>
                            </div>
                        </div>
                        <div class="card acc-card">
                            <div class="card-header">
                                <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/makina-ekle") { Response.Write("class='btn btn-link text-left active'"); }%> href="/makina-ekle" class="btn btn-link text-left">Makine Sat
                                    </a>
                                </h2>
                            </div>
                        </div>
                        <div class="card acc-card">
                            <div class="card-header">
                                <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/makinalarim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/makinalarim" class="btn btn-link text-left">Makinelerim
                                    </a>
                                </h2>
                            </div>
                        </div>
                        <div class="card acc-card">
    <div class="card-header">
      <h2 class="mb-0">
        <a <%if (HttpContext.Current.Request.RawUrl == "/userpaymentinfo") { Response.Write("class='btn btn-link text-left active'"); }%> href="/userpaymentinfo" class="btn btn-link text-left">
           Odeme Bilgileri
        </a>
      </h2>
    </div>
</div>
                        <div class="card acc-card">
                            <div class="card-header">
                                <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/ihalelerim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/ihalelerim" class="btn btn-link text-left">İhalelerim
                                    </a>
                                </h2>
                            </div>
                        </div>
                        <div class="card acc-card">
                            <div class="card-header">
                                <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/odeme-bildirimi") { Response.Write("class='btn btn-link text-left active'"); }%> href="/odeme-bildirimi" class="btn btn-link text-left">Ödeme Bildirimi
                                    </a>
                                </h2>
                            </div>
                        </div>
                        <div class="card acc-card">
                            <div class="card-header">
                                <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/favorilerim") { Response.Write("class='btn btn-link text-left active'"); }%> href="/favorilerim" class="btn btn-link text-left">Favorilerim
                                    </a>
                                </h2>
                            </div>
                        </div>
               
                        <div class="card acc-card">
                            <div class="card-header">
                                <h2 class="mb-0">
                                    <a <%if (HttpContext.Current.Request.RawUrl == "/cikis") { Response.Write("class='btn btn-link text-left active'"); }%> href="/cikis" class="btn btn-link text-left">Çıkış Yap
                                    </a>
                                </h2>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-9 profil-right-box">
                    <div>
                        <div class="card-body">
                            <div class="mb-3">
                                <h5 class="form-title">Kişisel Bilgiler
                                </h5>
                                <div class="row">
                                    <div class="col-md-6 pr-025rem sm-px-8">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="txtAdi" placeholder="Adınız" runat="server">
                                        </div>
                                    </div>
                                    <div class="col-md-6 pl-025rem sm-px-8">
                                        <div class="form-group ">
                                            <input type="text" class="form-control" id="txtSoyadi" placeholder="Soyadınız" runat="server">
                                        </div>
                                    </div>


                                </div>
                                <div class="row">
                                    <div class="col-md-6 pr-025rem sm-px-8">
                                        <div class="form-group">
                                            <input type="date" class="form-control" id="txtDogumTarihi" value="1996-01-17" placeholder="Doğum Tarihi" runat="server">
                                        </div>
                                    </div>
                                    <div class="col-md-6 pl-025rem sm-px-8">
                                        <div class="form-group">
                                            <input type="number" class="form-control" id="txtTCK" placeholder="T.C. Kimlik No" runat="server">
                                            <input type="number" class="form-control" id="txtTaxNo" placeholder="Vergi No" runat="server">
                                        </div>
                                    </div>
                                </div>
                            </div>



                            <asp:Panel ID="pnlPhoto" Visible="false" runat="server">
                                <div class="mb-3">
                                    <h5 class="form-title">Fotoğraf Bilgileri</h5>
                                    <div class="row d-flex align-items-center">
                                        <div class="form-group mr-3 col-5">
                                            <label>
                                                <asp:Label ID="lblGeneralPicture" runat="server" Text="Küçük Logo (Önerilen:374px*108px)"></asp:Label>
                                            </label>
                                            <br />
                                            <asp:Image ID="imgPicture" runat="server" CssClass="img-bordered-sm" Style="width: 157.2px; height: 50.2px;" />
                                            <asp:FileUpload ID="uplResim" runat="server" CssClass="btn" />
                                        </div>
                                        <div class="form-group col-6">
                                            <label>
                                                <asp:Label ID="lblGeneralPictureB" runat="server" Text="Büyük Logo(Önerilen:207px*209px)"></asp:Label>
                                            </label>
                                            <br />
                                            <asp:Image ID="imgPictureB" runat="server" CssClass="img-bordered-sm" Style="width: 155.2px; height: 157.2px;" />
                                            <asp:FileUpload ID="uplResimB" runat="server" CssClass="btn" />
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>


                            <div class="mb-3">
                                <h5 class="form-title">İletişim Bilgileri
                                </h5>
                                <div class="row">
                                    <div class="col-md-6 pr-025rem sm-px-8">
                                        <div class="form-group">
                                            <input type="tel" id="txtTelefon" name="txtTelefon" runat="server" class="form-control" required="" style="width: 250px">
                                            <input type="hidden" id="txtDialCode" name="txtDialCode" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 pl-025rem sm-px-8">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="txtEmail" placeholder="E-Posta" runat="server" readonly="readonly">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 pr-025rem sm-px-8">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddUlkeler" runat="server" CssClass="form-control select2" Width="100%"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 pr-025rem sm-px-8">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="txtIl" placeholder="İl" runat="server">
                                        </div>
                                    </div>
                                    <div class="col-md-4 pl-025rem sm-px-8">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="txtIlce" placeholder="İlçe" runat="server">
                                        </div>
                                    </div>
                                    <div class="col-md-12 sm-px-8">
                                        <div class="form-group">
                                            <textarea class="form-control" id="txtAdres" rows="6" placeholder="Adres" runat="server"></textarea>
                                        </div>
                                    </div>
                                </div>
                            </div>



                            <asp:Panel ID="Panel1" Visible="false" runat="server">
                                <div class="mb-3" id="CategoryArea">
                                    <h5 class="form-title">Servis Detayli Hizmet Bilgileri
                                    </h5>

                                    <div class="col-md-12 sm-px-8">
                                        <div class="form-group">
                                            <h2 class="form-title">Servis Verilen Kategoriler
                                            </h2>

                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table custom-table">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    <asp:Button ID="btnAddCategory" runat="server" Text="Ekle" CssClass="btn btn-success" ForeColor="White" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Hizmet vereceğiniz kategorileri ekleyiniz."/>
                                                                </th>

                                                                <th scope="col">Kategori Adı</th>
                                                                <th scope="col">Alt Kategori</th>
                                                                <th scope="col">Alt-Alt Kategori</th>
                                                                <th scope="col">Sil</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Container.ItemIndex + 1 %></td>
                                                        <td><%# Eval("CategoryName") %></td>
                                                        <td><%# Eval("SubCategoryName") %></td>
                                                        <td>
                                                          <%# Eval("SubSubCategoryName") != null && !string.IsNullOrEmpty(Eval("SubSubCategoryName").ToString()) ? Eval("SubSubCategoryName") : "-" %>
              
                                                        </td>

                                                        <td>
                                                            <asp:Button ID="btnDelete" runat="server" Text="Sil" OnClick="btnDelete_Click" CssClass="btn btn-danger" CommandArgument='<%# Eval("UserCategoriesID") %>' ForeColor="White" />


                                                        </td>
                                                    </tr>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
        </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <asp:CustomValidator ID="CustomValidatorMainCat" runat="server" ErrorMessage="Lütfen bir alt kategori seçiniz" ForeColor="Red" OnServerValidate="CustomValidatorMainCat_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                                            <div class="panel panel-default mt-3" style="margin-top: 10px; display: none;" id="pnlCategory">
                                                <div class="panel-body">

                                                    <div class="input-group">
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>



                                                                <p class="form-group">Ana Kategori</p>



                                                                <asp:DropDownList ID="ddCategory" runat="server" AutoPostBack="true" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged">
                                                                </asp:DropDownList>

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <p class="form-group">
                                                                    Alt Kategori
                                                                </p>

                                                                <asp:DropDownList ID="ddSubCategory" runat="server" AutoPostBack="true" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <p class="form-group">Alt-Alt Kategori</p>


                                                                <asp:DropDownList ID="ddSubSubCategory" runat="server" AutoPostBack="true" CssClass="form-control select2" Width="100%">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <span class="input-group-btn">
                                                            <asp:Button class="btn btn-success" Text="Ekle" runat="server" type="submit" OnClick="btnAddCategory_Click"  ForeColor="White" />
                                                        </span>
                                                    </div>

                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-12 sm-px-8" id="WorkZoneArea">
                                        <div class="form-group">
                                            <h2 class="form-title">Servis Verilen Ülkeler
                                            </h2>

                                            <asp:Repeater ID="RepaterCountry" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table custom-table">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    <asp:Button ID="btnAddWorkZone" runat="server" Text="Ekle" CssClass="btn btn-success" ForeColor="White" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Hizmet vermek istediğiniz ülkeleri ekleyiniz."/>

                                                                </th>

                                                                <th scope="col">Ülkeler</th>

                                                                <th scope="col">Sil</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Container.ItemIndex + 1 %></td>
                                                        <td><%# Eval("CountryName") %></td>


                                                        <td>
                                                            <asp:Button ID="btnDelete" runat="server" Text="Sil" OnClick="btnDeleteWorkZone_Click" CssClass="btn btn-danger" CommandArgument='<%# Eval("ServiceWorkZoneID") %>' ForeColor="White" />


                                                        </td>
                                                    </tr>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
        </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <div class="panel panel-default mt-3" style="margin-top: 10px; display: none;" id="myPanel">
                                                <div class="panel-body">

                                                    <div class="input-group">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddcountryList" runat="server" AutoPostBack="true" CssClass="form-control select2" Width="100%">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <span class="input-group-btn">
                                                            <asp:Button class="btn btn-default" Text="Ekle" runat="server" type="button" OnClick="btnAddWorkZone_Click" />
                                                        </span>
                                                    </div>

                                                </div>
                                            </div>


                                        </div>
                                    </div>

                                </div>

                            </asp:Panel>


                            <div class="mb-3">
                                <h5 class="form-title">Servis Mağazası Açıklama Detayları
                                </h5>
                                <div class="row">
                                    <div class="col-md-12 sm-px-8">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtCKeditor" runat="server" TextMode="MultiLine" Rows="5" Width="100%" placeholder="Açıklama" CssClass="form-control" MaxLength="3000"></asp:TextBox>
                                            <p class="text-muted">Metni girerken lütfen imla kurallarına dikkat ediniz. Çeviri işlemi otomatik olarak gerçekleştirilecektir. 3000 satırdan fazla olamaz</p>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mb-3" id="equipmentArea">
                                <div class="form-group">
                                    <h2 class="form-title">Servis Ekipman Detayları</h2>


                                    <asp:Repeater ID="rptEquipment" runat="server">

                                        <HeaderTemplate>
                                            <table class="table custom-table">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <asp:Button ID="btnAdd" runat="server" Text="Ekle" CssClass="btn btn-success" ForeColor="White" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Hizmetinizde kullanacağınız ekipmanları ekleyiniz."/>

                                                        </th>
                                                        <th scope="col">Ekipmanlar</th>
                                                        <th scope="col">Sil</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>


                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Container.ItemIndex + 1 %></td>
                                                <td><%# Eval("ServiceEquipmentDetailName") %></td>
                                                <td>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Sil" OnClick="btnDeleteEquipment_Click" CssClass="btn btn-danger" CommandArgument='<%# Eval("ServiceEquipmentDetailID") %>' ForeColor="White" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>

                                        <FooterTemplate>
                                            </tbody>
                </table>
                                        </FooterTemplate>
                                    </asp:Repeater>

                                    <div class="panel panel-default mt-3" style="margin-top: 10px; display: none;" id="pnlEquipment">
                                        <div class="panel-body">

                                            <div class="input-group">
                                                <input type="text" class="form-control" id="txtNewItem" runat="server" placeholder="Yeni bir ekipman giriniz..." />

                                                <span class="input-group-btn">
                                                    <asp:Button class="btn btn-default" Text="Ekle" runat="server" type="button" OnClick="btnAddEquipment_Click" />
                                                </span>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>



                            <div class="mb-3">

                                <div class="row">
                                    <div class="col-md-6 pr-025rem sm-px-8">
                                        <h5 class="form-title">Kullanıcı Şifresi
                                        </h5>
                                        <div class="form-group">
                                            <asp:TextBox ID="TxtYeniSifre" runat="server" class="form-control" TextMode="Password" placeholder="Şifre" ValidationGroup="profil"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 pr-025rem sm-px-8">
                                        <asp:Panel ID="pnlFirmaAdi" runat="server" Visible="false">
                                            <div class="form-group">
                                                <h5 class="form-title">Firma Adı
                                                </h5>
                                                <asp:TextBox ID="txtFirmaAdi" runat="server" class="form-control" TextMode="SingleLine" placeholder="Firma Adı" ValidationGroup="profil" Visible="false"></asp:TextBox>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="text-center">

                                    <asp:Button ID="btnProfilSave" runat="server" Text="Profilimi Güncelle" CssClass="btn btn-success kaydet-button" Width="150px" OnClick="btnProfilSave_Click" ValidationGroup="profil" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script>
        function togglePanelVisibilityEquipment(event) {
            event.preventDefault();
            var panel = document.getElementById('pnlEquipment');


            if (panel.style.display === 'none' || panel.style.display === '') {
                panel.style.display = 'block';

            }
            else {
                panel.style.display = 'none';
                requiredValidator.enabled.requiredValidator = false;
            }

        }

        document.getElementById('btnAdd').addEventListener('click', function (event) {
            togglePanelVisibilityEquipment(event);


        });

        function togglePanelVisibilityWorkZone(event) {
            event.preventDefault();
            var panel = document.getElementById('myPanel');
            if (panel.style.display === 'none' || panel.style.display === '') {
                panel.style.display = 'block';
            } else {
                panel.style.display = 'none';
            }
        }

        document.getElementById('btnAddWorkZone').addEventListener('click', function (event) {
            togglePanelVisibilityWorkZone(event);
        });

        function togglePanelVisibilityCategory(event) {
            event.preventDefault();
            var panel = document.getElementById('pnlCategory');
            if (panel.style.display === 'none' || panel.style.display === '') {
                panel.style.display = 'block';
            } else {
                panel.style.display = 'none';
            }
        }

        document.getElementById('btnAddCategory').addEventListener('click', function (event) {
            togglePanelVisibilityCategory(event);
        });

    </script>


</asp:Content>
